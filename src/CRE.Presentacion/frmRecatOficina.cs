using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using System.IO;

namespace CRE.Presentacion
{
    public partial class frmRecatOficina : frmBase
    {
        public frmRecatOficina()
        {
            InitializeComponent();
        }
        #region Variables Globales
        private Boolean lModoEdicionPendiente = false;
        private Boolean lPendiente = false;
        private Byte[] vDocumentoSesion;
        private clsCNCategoriaOficina cnCategoriaOficina = new clsCNCategoriaOficina();
        private DataTable dtCategorias = new DataTable();
        private DataTable dtDatosCategorizacion = new DataTable();
        private DataTable dtDatosPendiente = new DataTable();
        private DataTable dtDocumento = new DataTable();
        private DataTable dtOficina = new DataTable();
        private int idCategoriaOficinaPendiente = 0;
        private int idCategoriaOficinaVigente = 0;
        private int nFila;
        private String cDocumentoSesion;
        private String cExtension;
        private String cTituloMensaje = "Recategorización de oficinas";

        #endregion
        #region Eventos
        private void frmRecatOficina_Load(object sender, EventArgs e)
        {
            cargarInicio();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (lModoEdicionPendiente)
            {
                lModoEdicionPendiente = false;
            }
            if (lPendiente)
            {
                lPendiente = false;
            }
            habilitarControles(2, false);
            dtgCategoriasOficinas.Enabled = true;
            limpiarControles(1);
            modificarTituloGrupoRec(0);
            cargarInicio();
            llenarDetalle(0);
            verificarPendiente();
        }
        private void btnMiniAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cArchivo = fDialog.FileName;
                FileInfo fInfo = new FileInfo(cArchivo);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                this.txtDocumento.Text = cArchivo;
                cDocumentoSesion = fInfo.Name;
                vDocumentoSesion = br.ReadBytes((int)numBytes);
                cExtension = fInfo.Extension;
                fStream.Flush();
                fStream.Close();
                br.Close();
            }
        }
        private void btnMiniDescargar_Click(object sender, EventArgs e)
        {
            if (lPendiente)
            {
                dtDocumento = cnCategoriaOficina.obtenerDocRecategorizacion(idCategoriaOficinaPendiente);
            }
            else
            {
                dtDocumento = cnCategoriaOficina.obtenerDocRecategorizacion(idCategoriaOficinaVigente);
            }

            descargarArchivo(dtDocumento);
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validarRegistro())
            {
                return;
            }

            if (lModoEdicionPendiente)
            {
                actualizarRecategorizacion();
                lModoEdicionPendiente = false;
            }
            if (lPendiente)
            {
                lPendiente = false;
            }
            else
            {
                insertarRecategorizacion();
                habilitarControles(2,false);
            }

            limpiarControles(1);
            cargarInicio();
            llenarDetalle(0);
            verificarPendiente();
        }
        private void btnRecategorizar_Click(object sender, EventArgs e)
        {
            limpiarControles(2);
            habilitarControles(1, true);
            habilitarControles(9, true);
            this.txtColaborador.Text = clsVarGlobal.User.cWinUser;
        }
        private void btnPendiente_Click(object sender, EventArgs e)
        {
            lPendiente = true;
            habilitarControles(3, true);
            habilitarControles(7, true);
            habilitarControles(8,true);
            modificarTituloGrupoRec(2);
            mostrarPendiente();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            lModoEdicionPendiente = true;
            habilitarControles(7, false);
            habilitarControles(1, true);
            habilitarControles(9, true);
            modificarTituloGrupoRec(1);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            DataTable dtEliminarRecategorizacion = cnCategoriaOficina.eliminarRecategorizacion(idCategoriaOficinaPendiente, idUsuMod, dFechaMod);
            MessageBox.Show(dtEliminarRecategorizacion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtEliminarRecategorizacion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            dtgCategoriasOficinas.Enabled = true;
            if (lPendiente)
            {
                lPendiente = false;
            }
            limpiarControles(1);
            cargarInicio();
            llenarDetalle(0);
            verificarPendiente();
        }
        private void dtgCategoriasOficinas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            llenarDetalle(e.RowIndex);
            this.btnEditar.Enabled = false;
            this.btnEditar.Visible = false;
            verificarPendiente();
        }
        private void dtgCategoriasOficinas_Sorted(object sender, EventArgs e)
        {
            colorearCeldas();
        }
        #endregion
        #region Métodos
        private void actualizarRecategorizacion()
        {
            DateTime dFechaInicio = dtpDesde.Value;
            DateTime dFechaFin = dtpFin.Value;
            int idGrupo = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["AidGrupo"].Value);
            int idCategoria = Convert.ToInt16(this.cboCategoria.SelectedValue);
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            String cJustificacion = txtJustificacion.Text;
            if (vDocumentoSesion != null)
            {
                DataTable dtResultado = cnCategoriaOficina.actualizarRecategorizacion(true,idCategoriaOficinaPendiente, dFechaInicio, dFechaFin, idCategoria, idGrupo, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuMod, dFechaMod);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else
            {
                DataTable dtResultado = cnCategoriaOficina.actualizarRecategorizacion(false, idCategoriaOficinaPendiente, dFechaInicio, dFechaFin, idCategoria, idGrupo, cJustificacion, "", System.Text.Encoding.ASCII.GetBytes(""), "", idUsuMod, dFechaMod);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            dtgCategoriasOficinas.Enabled = true;
        }
        private void cargarInicio()
        {
            DataTable dtPeriodoCateOficina = cnCategoriaOficina.ListarPeriodoCateOficina(false);
            for (int i = 0; i < dtPeriodoCateOficina.Rows.Count; i++)
            {
                if (Convert.ToInt16(dtPeriodoCateOficina.Rows[i]["idEstadoCateOfi"]) == 1)
                {
                    lblValorClasificacion.Text = Convert.ToString(dtPeriodoCateOficina.Rows[i]["cNombre"]);
                }
            }

            habilitarControles(2, false);
            this.dtgCategoriasOficinas.RowEnter -= dtgCategoriasOficinas_RowEnter;
            llenarGridCatOficina();
            this.dtgCategoriasOficinas.RowEnter += dtgCategoriasOficinas_RowEnter;
            obtenerDatosCategorizacion();
            obtenerDatosPendiente();
        }
        private void colorearTexto(int nValor)
        {
            switch (nValor)
            {
                case 1:
                    this.lblValorAutomatico.Text = "Automático";
                    this.lblValorAutomatico.ForeColor = Color.Green;
                    break;
                case 2:
                    this.lblValorAutomatico.Text = "Manual (Ejecutado)";
                    this.lblValorAutomatico.ForeColor = Color.Green;
                    break;
                case 3:
                    this.lblValorAutomatico.Text = "Manual (Pendiente)";
                    this.lblValorAutomatico.ForeColor = Color.DarkOrange;
                    break;
                default:
                    this.lblValorAutomatico.ForeColor = Color.Navy;
                    break;
            }
        }
        private void colorearCeldas()
        {
            for (int i = 0; i < this.dtgCategoriasOficinas.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(dtgCategoriasOficinas.Rows[i].Cells["MidHistCatOficina"].Value.ToString()))
                {
                    dtgCategoriasOficinas.Rows[i].Cells["AcCategoria"].Style.BackColor = Color.FromArgb(173, 239, 156);
                }
                else
                {
                    dtgCategoriasOficinas.Rows[i].Cells["McCategoria"].Style.BackColor = Color.FromArgb(173, 239, 156);
                }
                if (!String.IsNullOrEmpty(dtgCategoriasOficinas.Rows[i].Cells["PidHistCatOficina"].Value.ToString()))
                {
                    dtgCategoriasOficinas.Rows[i].Cells["PcCategoria"].Style.BackColor = Color.FromArgb(255, 237, 170);
                }
            }
        }
        private void descargarArchivo(DataTable dt)
        {
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            string cNombreArchivo = Convert.ToString(dt.Rows[0]["cDocSustento"]);
            byte[] bDocumento = (Byte[])dt.Rows[0]["vDocSustento"];

            SaveFileDialog fbd = new SaveFileDialog();
            fbd.FileName = cNombreArchivo;
            fbd.Filter = "All files (*.*)|*.*";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                using (
                FileStream fileStream = new FileStream(fbd.FileName, FileMode.Create))
                {
                    for (int i = 0; i < bDocumento.Length; i++)
                    {
                        fileStream.WriteByte(bDocumento[i]);
                    }
                    fileStream.Seek(0, SeekOrigin.Begin);

                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (bDocumento[i] != fileStream.ReadByte())
                        {
                            MessageBox.Show("Error al descargar el archivo: " + cNombreArchivo, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.btnMiniAdjuntar.Focus();
                            this.btnMiniAdjuntar.Select();
                            return;
                        }
                    }
                    MessageBox.Show("Descarga exitosa del archivo: " + fileStream.Name, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void formatearGridCatOficina()
        {
            foreach (DataGridViewColumn item in dtgCategoriasOficinas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.Automatic;
                item.Visible = false;
                item.ReadOnly = true;
            }

            this.dtgCategoriasOficinas.Columns["AcNombreCorto"].Visible = true;
            this.dtgCategoriasOficinas.Columns["AnSaldoAnt"].Visible = true;
            this.dtgCategoriasOficinas.Columns["AnMoraAnt"].Visible = true;
            this.dtgCategoriasOficinas.Columns["AcGrupo"].Visible = true;
            this.dtgCategoriasOficinas.Columns["AcCategoria"].Visible = true;
            this.dtgCategoriasOficinas.Columns["McCategoria"].Visible = true;
            this.dtgCategoriasOficinas.Columns["PcCategoria"].Visible = true;

            this.dtgCategoriasOficinas.Columns["AcNombreCorto"].DisplayIndex = 1;
            this.dtgCategoriasOficinas.Columns["AdfechaCreacion"].DisplayIndex = 2;
            this.dtgCategoriasOficinas.Columns["AnSaldoAnt"].DisplayIndex = 3;
            this.dtgCategoriasOficinas.Columns["AnMoraAnt"].DisplayIndex = 4;
            this.dtgCategoriasOficinas.Columns["AcGrupo"].DisplayIndex = 5;
            this.dtgCategoriasOficinas.Columns["AcCategoria"].DisplayIndex = 6;
            this.dtgCategoriasOficinas.Columns["McCategoria"].DisplayIndex = 9;
            this.dtgCategoriasOficinas.Columns["PcCategoria"].DisplayIndex = 12;

            this.dtgCategoriasOficinas.Columns["AnSaldoAnt"].DefaultCellStyle.Format = "N2";
            this.dtgCategoriasOficinas.Columns["AnMoraAnt"].DefaultCellStyle.Format = "0.00\\%";

            this.dtgCategoriasOficinas.Columns["AcNombreCorto"].HeaderText = "Oficina";
            this.dtgCategoriasOficinas.Columns["AcGrupo"].HeaderText = "Grupo Automático";
            this.dtgCategoriasOficinas.Columns["AcCategoria"].HeaderText = "Categoria Automática";
            this.dtgCategoriasOficinas.Columns["AdfechaCreacion"].HeaderText = "Inicio de actividades";
            this.dtgCategoriasOficinas.Columns["AnSaldoAnt"].HeaderText = "Saldo Capital";
            this.dtgCategoriasOficinas.Columns["AnMoraAnt"].HeaderText = "Mora contable";
            this.dtgCategoriasOficinas.Columns["McCategoria"].HeaderText = "Categoría Manual";
            this.dtgCategoriasOficinas.Columns["PcCategoria"].HeaderText = "Recat. Pendiente";

            this.dtgCategoriasOficinas.Columns["AcNombreCorto"].Width = 150;

            colorearCeldas();
        }
        private void habilitarControles(int nValor, Boolean lValor)
        {
            switch (nValor)
            {
                case 1:
                    this.btnCancelar.Enabled = lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.btnGrabar.Visible = lValor;
                    this.btnPendiente.Enabled = lValor;
                    this.btnRecategorizar.Enabled = !lValor;
                    this.cboCategoria.Enabled = lValor;
                    this.dtgCategoriasOficinas.Enabled = !lValor;
                    this.dtpDesde.Enabled = lValor;
                    this.dtpFin.Enabled = lValor;
                    this.lblColaborador.Visible = lValor;
                    this.lblDocumento.Visible = lValor;
                    this.lblJustificacion.Visible = lValor;
                    this.txtColaborador.Visible = lValor;
                    this.txtDocumento.Visible = lValor;
                    this.txtJustificacion.Enabled = lValor;
                    this.txtJustificacion.Visible = lValor;
                    break;
                case 2:
                    this.btnMiniAdjuntar.Enabled = lValor;
                    this.btnMiniDescargar.Enabled = lValor;
                    this.btnMiniAdjuntar.Visible = lValor;
                    this.btnMiniDescargar.Visible = lValor;
                    this.btnCancelar.Enabled = lValor;
                    this.btnEditar.Enabled = lValor;
                    this.btnEditar.Visible = lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.btnGrabar.Visible = !lValor;
                    this.btnPendiente.Enabled = lValor;
                    this.btnPendiente.Visible = lValor;
                    this.btnRecategorizar.Enabled = lValor;
                    this.cboCategoria.Enabled = lValor;
                    this.dtpDesde.Enabled = lValor;
                    this.dtpFin.Enabled = lValor;
                    this.txtJustificacion.Enabled = lValor;
                    this.btnEliminar.Visible = lValor;
                    this.btnEliminar.Enabled = lValor;
                    break;
                case 3:
                    this.btnMiniDescargar.Visible = lValor;
                    this.btnMiniDescargar.Enabled = lValor;
                    this.btnMiniAdjuntar.Visible = false;
                    this.lblColaborador.Visible = lValor;
                    this.lblDocumento.Visible = lValor;
                    this.lblJustificacion.Visible = lValor;
                    this.txtColaborador.Visible = lValor;
                    this.txtDocumento.Visible = lValor;
                    this.txtJustificacion.Visible = lValor;
                    break;
                case 4:
                    this.btnCancelar.Enabled = lValor;
                    this.btnEditar.Enabled = lValor;
                    this.btnEditar.Visible = lValor;
                    this.btnGrabar.Enabled = !lValor;
                    this.btnGrabar.Visible = !lValor;
                    this.btnPendiente.Enabled = !lValor;
                    this.dtgCategoriasOficinas.Enabled = !lValor;
                    break;
                case 6:
                    this.btnPendiente.Enabled = lValor;
                    this.btnPendiente.Visible = lValor;
                    this.btnRecategorizar.Enabled = !lValor;
                    this.btnRecategorizar.Visible = !lValor;
                    break;
                case 7:
                    this.btnCancelar.Enabled = lValor;
                    this.btnEditar.Enabled = lValor;
                    this.btnEditar.Visible = lValor;
                    this.btnGrabar.Enabled = !lValor;
                    this.btnGrabar.Visible = !lValor;
                    this.btnPendiente.Enabled = !lValor;
                    this.dtgCategoriasOficinas.Enabled = !lValor;
                    break;
                case 8:
                    this.btnEliminar.Visible = lValor;
                    this.btnEliminar.Enabled = lValor;
                    break;
                case 9:
                    this.btnMiniAdjuntar.Enabled = lValor;
                    this.btnMiniAdjuntar.Visible = lValor;
                    this.btnMiniDescargar.Enabled = !lValor;
                    this.btnMiniDescargar.Visible = !lValor;
                    this.btnEliminar.Enabled = !lValor;
                    this.btnPendiente.Enabled = !lValor;
                    break;
                default:
                    break;
            }
        }
        private void insertarRecategorizacion()
        {
            DateTime dFechaInicio = dtpDesde.Value;
            DateTime dFechaFin = dtpFin.Value;
            int idOficina = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["AidOficina"].Value);
            int idGrupo = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["AidGrupo"].Value);
            int idCategoria = Convert.ToInt16(this.cboCategoria.SelectedValue);

            int idUsuReg = clsVarGlobal.User.idUsuario;
            DateTime dFechaReg = clsVarGlobal.dFecSystem; ;
            String cJustificacion = txtJustificacion.Text;

            DataTable dtResultado = cnCategoriaOficina.insertarRecategorizacion(dFechaInicio, dFechaFin, idOficina, idGrupo, idCategoria, idCategoriaOficinaVigente, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuReg, dFechaReg);

            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            dtgCategoriasOficinas.Enabled = true;
        }
        private void llenarDetalle(int nValor)
        {
            nFila = nValor;
            if (String.IsNullOrEmpty(dtgCategoriasOficinas.Rows[nFila].Cells["MidHistCatOficina"].Value.ToString()))
            {
                mostrarDatosOficina(true);
            }
            else
            {
                mostrarDatosOficina(false);
            }
        }
        private void llenarCategorias(int idGrupoCate) {

            dtCategorias = cnCategoriaOficina.listarCategoriaXGrupo(idGrupoCate);
            this.cboCategoria.DataSource = dtCategorias;
            this.cboCategoria.ValueMember = dtCategorias.Columns["idCategoria"].ToString();
            this.cboCategoria.DisplayMember = dtCategorias.Columns["cDescripcion"].ToString();
        }
        private void llenarGridCatOficina()
        {
            dtOficina = cnCategoriaOficina.ListarInformacionCateOfi();
            dtgCategoriasOficinas.DataSource = dtOficina;
            formatearGridCatOficina();
        }
        private void limpiarControles(int nValor)
        {
            switch (nValor)
            {
                case 1:
                    this.txtOficina.Clear();
                    this.txtGrupo.Clear();
                    this.txtColaborador.Clear();
                    this.txtDocumento.Clear();
                    this.txtJustificacion.Clear();
                    break;
                case 2:
                    this.txtDocumento.Clear();
                    this.txtJustificacion.Clear();
                    break;
                case 3:
                    this.txtColaborador.Clear();
                    this.txtDocumento.Clear();
                    this.txtJustificacion.Clear();
                    this.txtDocumento.Clear();
                    break;
                default:
                    break;
            }
        }
        private void modificarTituloGrupoRec(int nValor )
        {
            switch (nValor)
            {
                case 1:
                    this.grbActivo.Text = "Edición: Categorización pendiente";
                    break;
                case 2:
                    this.grbActivo.Text = "Detalle: Categorización pendiente";
                    break;
                default:
                    this.grbActivo.Text = "Categorización Vigente";
                    break;
            }
        }
        private void mostrarDatosOficina(Boolean lAutomatico)
        {
            limpiarControles(3);
            txtOficina.Text = Convert.ToString(dtgCategoriasOficinas.Rows[nFila].Cells["AcNombreCorto"].Value);
            dtpFechaCreacion.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["AdfechaCreacion"].Value);
            if (lAutomatico)
            {
                this.txtGrupo.Text = Convert.ToString(dtgCategoriasOficinas.Rows[nFila].Cells["AcGrupo"].Value);
                llenarCategorias(Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["AidGrupoCategoriaOfi"].Value));
                dtpDesde.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["AdFechaInicio"].Value);
                dtpFin.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["AdFechaFin"].Value);
                this.cboCategoria.SelectedValue = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["AidCategoria"].Value);
                idCategoriaOficinaVigente = Convert.ToInt32(dtgCategoriasOficinas.Rows[nFila].Cells["AidHistCatOficina"].Value);
                habilitarControles(3, false);
                colorearTexto(1);
            }
            else
            {
                this.txtGrupo.Text = Convert.ToString(dtgCategoriasOficinas.Rows[nFila].Cells["McGrupo"].Value);
                llenarCategorias(Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["MidGrupoCategoriaOfi"].Value));
                dtpDesde.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["MdFechaInicio"].Value);
                dtpFin.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["MdFechaFin"].Value);
                this.cboCategoria.SelectedValue = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["MidCategoria"].Value);
                idCategoriaOficinaVigente = Convert.ToInt32(dtgCategoriasOficinas.Rows[nFila].Cells["MidHistCatOficina"].Value);
                for (int i = 0; i <= dtDatosCategorizacion.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dtDatosCategorizacion.Rows[i]["idHistCatOficina"]) == Convert.ToInt32(dtgCategoriasOficinas.Rows[nFila].Cells["MidHistCatOficina"].Value))
                    {
                        this.txtColaborador.Text = Convert.ToString(dtDatosCategorizacion.Rows[i]["cColaborador"]);
                        this.txtJustificacion.Text = Convert.ToString(dtDatosCategorizacion.Rows[i]["cJustificacion"]);
                        this.txtDocumento.Text = Convert.ToString(dtDatosCategorizacion.Rows[i]["cDocSustento"]);
                    }

                }
                habilitarControles(3, true);
                colorearTexto(2);
            }
        }
        private void mostrarPendiente()
        {
            this.txtGrupo.Text = Convert.ToString(dtgCategoriasOficinas.Rows[nFila].Cells["PcGrupo"].Value);
            llenarCategorias(Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["PidGrupoCategoriaOfi"].Value));
            dtpDesde.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["PdFechaInicio"].Value);
            dtpFin.Value = Convert.ToDateTime(dtgCategoriasOficinas.Rows[nFila].Cells["PdFechaFin"].Value);
            colorearTexto(3);
            this.cboCategoria.SelectedValue = Convert.ToInt16(dtgCategoriasOficinas.Rows[nFila].Cells["PidCategoria"].Value);
            idCategoriaOficinaPendiente = Convert.ToInt32(dtgCategoriasOficinas.Rows[nFila].Cells["PidHistCatOficina"].Value);
            for (int i = 0; i <= dtDatosPendiente.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dtDatosPendiente.Rows[i]["idHistCatOficina"]) == Convert.ToInt32(dtgCategoriasOficinas.Rows[nFila].Cells["PidHistCatOficina"].Value))
                {
                    this.txtColaborador.Text = Convert.ToString(dtDatosPendiente.Rows[i]["cColaborador"]);
                    this.txtJustificacion.Text = Convert.ToString(dtDatosPendiente.Rows[i]["cJustificacion"]);
                    this.txtDocumento.Text = Convert.ToString(dtDatosPendiente.Rows[i]["cDocSustento"]);
                }
            }
        }
        private void obtenerDatosCategorizacion()
        {
            dtDatosCategorizacion = cnCategoriaOficina.listarDatosCategorizacion(1);
        }
        private void obtenerDatosPendiente()
        {
            dtDatosPendiente = cnCategoriaOficina.listarDatosCategorizacion(2);
        }
        private Boolean retornarUltimaDiaMes(DateTime dFecha)
        {
            int nMes = dFecha.Month;
            int nAnio = dFecha.Year;
            int nDia = dFecha.Day;
            int comparar = DateTime.DaysInMonth(nAnio, nMes);
            if (nDia == comparar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean validarRegistro()
        {
            if (clsVarGlobal.dFecSystem >= dtpDesde.Value)
            {
                MessageBox.Show("La fecha inicio deberá ser como mínimo un día posterior al de hoy.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpDesde.Focus();
                this.dtpDesde.Select();
                return false;
            }
            if (clsVarGlobal.dFecSystem >= dtpFin.Value)
            {
                MessageBox.Show("La fecha fin deberá ser como mínimo un día posterior al de hoy.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFin.Focus();
                this.dtpFin.Select();
                return false;
            }
            if (!retornarUltimaDiaMes(dtpFin.Value))
            {
                MessageBox.Show("La fecha fin de la recategorización deberá ser el último día de mes.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFin.Focus();
                this.dtpFin.Select();
                return false;
            }
            if (dtpFin.Value < dtpDesde.Value)
            {
                MessageBox.Show("La fecha final debe ser posterior a la inicial.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFin.Focus();
                this.dtpFin.Select();
                return false;
            }
            if (String.IsNullOrEmpty(txtDocumento.Text))
            {
                MessageBox.Show("Debe de adjuntar documento de sustento.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtJustificacion.Focus();
                this.txtJustificacion.Select();
                return false;
            }
            if (String.IsNullOrEmpty(txtJustificacion.Text))
            {
                MessageBox.Show("Ingrese la justificación de la recategorización.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtJustificacion.Focus();
                this.txtJustificacion.Select();
                return false;
            }
            return true;
        }
        private void verificarPendiente()
        {
            if (String.IsNullOrEmpty(dtgCategoriasOficinas.Rows[nFila].Cells["PidGrupoCategoriaOfi"].Value.ToString()))
            {
                habilitarControles(6, false);
            }
            else
            {
                habilitarControles(6, true);
            }
        }
        #endregion
    }
}
