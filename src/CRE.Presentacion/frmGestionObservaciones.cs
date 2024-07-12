using System;
using CRE.CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using System.Xml.Linq;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmGestionObservaciones : frmBase
    {
        #region Variables

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionObservaciones));
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private List<clsConfigDataGridView> listConfigDtg = new List<clsConfigDataGridView>();
        private Dictionary<string, int> objEstados = new Dictionary<string, int>();
        public int nModoFunc, idSolicitud, idEtapaEvalCred;
        public bool lEditar;

        #endregion

        public frmGestionObservaciones()
        {
            InitializeComponent();

            this.cboTipObs.SelectedIndexChanged -= new System.EventHandler(this.cboTipObs_SelectedIndexChanged);
            this.dtpFechaInicio.ValueChanged -= new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            this.dtpFechaFin.ValueChanged -= new System.EventHandler(this.dtpFechaFin_ValueChanged);
            this.chbSolicitud.CheckedChanged -= new System.EventHandler(this.chbSolicitud_CheckedChanged);
            this.chbUsuario.CheckedChanged -= new System.EventHandler(this.chbUsuario_CheckedChanged);
            this.chbEtapa.CheckedChanged -= new System.EventHandler(this.chbEtapa_CheckedChanged);
            this.chbVigente.CheckedChanged -= new System.EventHandler(this.chbVigente_CheckedChanged);
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.idEtapaEvalCred = 0;
            this.idSolicitud = 0;
            this.lEditar = true;
            this.nModoFunc = 1; // 1 = REMITENTE, 2 = DESTINATARIO
        }

        #region Eventos

        private void frmGestionObservaciones_Load(object sender, EventArgs e)
        {
            CargarConfig();
            CargarObservaciones();
            ConfigDataGridView();
            AdicionandoBotones();

            this.btnAddObs.Visible = (this.nModoFunc == 1 ? true : false );
            //this.btnEmitirObs.Visible = (this.nModoFunc == 1 ? true : false);

            this.cboTipObs.SelectedIndexChanged += new System.EventHandler(this.cboTipObs_SelectedIndexChanged);
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            this.chbSolicitud.CheckedChanged += new System.EventHandler(this.chbSolicitud_CheckedChanged);
            this.chbUsuario.CheckedChanged += new System.EventHandler(this.chbUsuario_CheckedChanged);
            this.chbEtapa.CheckedChanged += new System.EventHandler(this.chbEtapa_CheckedChanged);
            this.chbVigente.CheckedChanged += new System.EventHandler(this.chbVigente_CheckedChanged);
            this.lblSolicitud.Text = this.idSolicitud.ToString();
        }

        private void dtgObservaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dtgObservaciones.Columns["btnMasDet"].Index && e.RowIndex >= 0)
            {
                frmDetProcesObserv frmDetObs = new frmDetProcesObserv();
                frmDetObs.idRegistroObs = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idRegistroObs"].Value);
                frmDetObs.idSolicitud = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idSolicitud"].Value);
                frmDetObs.ShowDialog();
            }
            if (Convert.ToBoolean(this.dtgObservaciones.Rows[e.RowIndex].Cells["lVigente"].Value) && this.lEditar) 
            {
                if (e.ColumnIndex == this.dtgObservaciones.Columns["btnEditar"].Index && e.RowIndex >= 0)
                {
                    clsObservacionAprobador objObservacion = new clsObservacionAprobador();
                    objObservacion.cObservacion = (this.dtgObservaciones.Rows[e.RowIndex].Cells["cDescripcion"].Value).ToString();
                    objObservacion.idTipObservacion = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idTipObs"].Value);
                    objObservacion.idEstado = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value);
                    objObservacion.idEtapaEvalCred = this.idEtapaEvalCred;
                    objObservacion.lEdit = true;
                    
                    objObservacion.lEditEstado = ((Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) == objEstados["EMITIDO"] &&
                                                   Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioSol"].Value) == clsVarGlobal.User.idUsuario) ||
                                                  (Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) == objEstados["RECHAZADO"] &&
                                                   Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioSol"].Value) == clsVarGlobal.User.idUsuario) ||
                                                  (Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) == objEstados["RESUELTO"]) &&
                                                  ValidarAbsolucion(Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEtapaEvalCred"].Value)));

                    objObservacion.lEditObserv = (
                        Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioReg"].Value) == clsVarGlobal.User.idUsuario &&
                        objEstados["REGISTRADO"] == Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) &&
                        objEstados["RESUELTO"] != Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) &&
                        Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEtapaEvalCred"].Value) == this.idEtapaEvalCred &&
                        this.nModoFunc == 1
                        ?
                            true :
                            false);
                    
                    frmObsAprobacion frmEditObs = new frmObsAprobacion();
                    frmEditObs.objObservacion = objObservacion;
                    frmEditObs.ShowDialog();

                    if (objObservacion.lModif)
                    {
                        List<clsGestDatObservacion> listObservaciones = new List<clsGestDatObservacion>();
                        listObservaciones.Add(new clsGestDatObservacion()
                        {
                            idRegistroObs = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idRegistroObs"].Value),
                            idSolicitud = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idSolicitud"].Value),
                            cDescripcion = objObservacion.cObservacion,
                            cComentario = objObservacion.cComentario,
                            idUsuario = clsVarGlobal.User.idUsuario,
                            idUsuarioReg = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioReg"].Value),
                            idTipObs = objObservacion.idTipObservacion,
                            cFecha = clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd"),
                            idPerfil = clsVarGlobal.PerfilUsu.idPerfil,
                            idEtapaEvalCred = this.idEtapaEvalCred,
                            idEstado = objObservacion.idEstado,
                            idMenu = clsVarGlobal.idMenu,
                            lVigente = 1
                        });

                        RegistrarObservaciones(listObservaciones);
                        CargarObservaciones();
                        AdicionandoBotones();

                        MessageBox.Show("Edición satisfactoria.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (!frmEditObs.lAceptado) return;
                }
                else if (this.nModoFunc == 1)
                {
                    if (e.ColumnIndex == this.dtgObservaciones.Columns["btnBaja"].Index && e.RowIndex >= 0 && Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioReg"].Value) == clsVarGlobal.User.idUsuario)
                    {
                        DialogResult result = MessageBox.Show("Desea dar de baja esta observación?", "Gestión de observaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (
                                objEstados["RESUELTO"] != Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEstado"].Value) &&
                                Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idEtapaEvalCred"].Value) == this.idEtapaEvalCred
                                ?
                                true :
                                false)
                            {
                                List<clsGestDatObservacion> listObservaciones = new List<clsGestDatObservacion>();
                                listObservaciones.Add(new clsGestDatObservacion()
                                {
                                    idRegistroObs = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idRegistroObs"].Value),
                                    idUsuario = clsVarGlobal.User.idUsuario,
                                    idUsuarioReg = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idUsuarioReg"].Value),
                                    idTipObs = Convert.ToInt32(this.dtgObservaciones.Rows[e.RowIndex].Cells["idTipObs"].Value),
                                    cDescripcion = (this.dtgObservaciones.Rows[e.RowIndex].Cells["cDescripcion"].Value).ToString(),
                                    lVigente = 0
                                });

                                RegistrarObservaciones(listObservaciones);
                                CargarObservaciones();
                                AdicionandoBotones();
                            }
                            else
                            {
                                MessageBox.Show("No puede eliminar esta observación porque: \n " +
                                    "* El estado debe ser diferente de resuelto. \n " +
                                    "* Debe pertenece a la etapa en la que fue registrada.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            clsObservacionAprobador objObservacion = new clsObservacionAprobador();
            objObservacion.idEtapaEvalCred = this.idEtapaEvalCred;
            objObservacion.lEdit = false;
            objObservacion.lEditEstado = false;
            objObservacion.lEditObserv = false;

            frmObsAprobacion frmEditObs = new frmObsAprobacion();
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            if (objObservacion.lModif)
            {
                List<clsGestDatObservacion> listObservaciones = new List<clsGestDatObservacion>();
                listObservaciones.Add(new clsGestDatObservacion()
                {
                    idRegistroObs = 0,
                    idSolicitud = this.idSolicitud,
                    cDescripcion = objObservacion.cObservacion,
                    idUsuario = clsVarGlobal.User.idUsuario,
                    idTipObs = objObservacion.idTipObservacion,
                    cFecha = clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd"),
                    idPerfil = clsVarGlobal.PerfilUsu.idPerfil,
                    idEtapaEvalCred = this.idEtapaEvalCred,
                    idEstado = objEstados["REGISTRADO"],
                    idMenu = clsVarGlobal.idMenu,
                    lVigente = 1
                });

                RegistrarObservaciones(listObservaciones);
                CargarObservaciones();
                AdicionandoBotones();
                MessageBox.Show("Registro satisfactorio.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!frmEditObs.lAceptado) return;
        }

        private void dtgObservaciones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dtgObservaciones.Columns["cDescripcion"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show((this.dtgObservaciones.Rows[e.RowIndex].Cells["cDescripcion"].Value).ToString(), "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy-MM-dd")) ||
                Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > clsVarGlobal.dFecSystem)
            {
                this.dtpFechaInicio.Value = this.dtpFechaFin.Value;
                MessageBox.Show("La Fecha Inicial debe ser menor o igual a la Fecha Final o del sistema.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy-MM-dd")) ||
                Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy-MM-dd")) > clsVarGlobal.dFecSystem)
            {
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
                MessageBox.Show("La Fecha Final debe ser menor o igual a la Fecha Final o del sistema.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void cboTipObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void chbSolicitud_CheckedChanged(object sender, EventArgs e)
        {
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void chbEtapa_CheckedChanged(object sender, EventArgs e)
        {
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void chbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void chbVigente_CheckedChanged(object sender, EventArgs e)
        {
            CargarObservaciones();
            AdicionandoBotones();
        }

        private void btnEmitirObs_Click(object sender, EventArgs e)
        {
            EmitirObserv();
        }

        public string GenEmitirObs(bool lValida, int idUsuario, DateTime dFecha)
        {
            DataTable dtCantObsEmit = objCNGestionObservaciones.EmitirObservCredito(lValida, idUsuario, dFecha);
            if (Convert.ToInt32(dtCantObsEmit.AsEnumerable().FirstOrDefault().Field<int>("nCant")) > 0)
            {
                return (dtCantObsEmit.AsEnumerable().FirstOrDefault().Field<string>("cMensaje"));
            }
            return "";
        }

        private void dtgObservaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dtgObservaciones.Rows[e.RowIndex];
                if ((row.Cells["lVigente"].Value != null ? Convert.ToBoolean(row.Cells["lVigente"].Value) : false) == false)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(204, 255, 204);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                }
            }
        }

        private void dtgObservaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                using (Font font = new Font(this.dtgObservaciones.Font, FontStyle.Bold))
                {
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        using (Brush backBrush = new SolidBrush(Color.Blue))
                        {
                            e.PaintBackground(e.CellBounds, true);
                            e.Graphics.FillRectangle(backBrush, e.CellBounds);
                            e.Graphics.DrawString(e.Value.ToString(), font, textBrush, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void frmGestionObservaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            EmitirObserv();
            DataTable dtCantObsEmit = objCNGestionObservaciones.EmitirObservCredito(true, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtCantObsEmit.AsEnumerable().FirstOrDefault().Field<int>("nCant")) > 0)
            {
                MessageBox.Show("Tiene observaciones pendientes por emitir.", "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Metodos

        public void ConfigSelecFiltros(bool lSolicitud, bool lUsuario, bool lEtapa, bool lVigente) 
        {
            this.chbSolicitud.Checked = lSolicitud;
            this.chbUsuario.Checked = lUsuario;
            this.chbEtapa.Checked = lEtapa;
            this.chbVigente.Checked = lVigente;
        }

        public void ConfigHabilitarFiltros(bool lSolicitud, bool lUsuario, bool lEtapa, bool lVigente)
        {
            this.chbSolicitud.Enabled = lSolicitud;
            this.chbUsuario.Enabled = lUsuario;
            this.chbEtapa.Enabled = lEtapa;
            this.chbVigente.Enabled = lVigente;
        }

        private void CargarConfig()
        {
            this.cboTipObs.LisTipObs(0, 0, this.idEtapaEvalCred, true);
            DataTable dtEstObs = objCNGestionObservaciones.ObtenerEstObs(0);
            objEstados["REGISTRADO"] = Convert.ToInt32(dtEstObs.AsEnumerable().FirstOrDefault(row => row.Field<string>("cEstado") == "REGISTRADO").Field<int>("idEstado"));
            objEstados["EMITIDO"] = Convert.ToInt32(dtEstObs.AsEnumerable().FirstOrDefault(row => row.Field<string>("cEstado") == "EMITIDO").Field<int>("idEstado"));
            objEstados["ABSUELTO"] = Convert.ToInt32(dtEstObs.AsEnumerable().FirstOrDefault(row => row.Field<string>("cEstado") == "ABSUELTO").Field<int>("idEstado"));
            objEstados["RECHAZADO"] = Convert.ToInt32(dtEstObs.AsEnumerable().FirstOrDefault(row => row.Field<string>("cEstado") == "RECHAZADO").Field<int>("idEstado"));
            objEstados["RESUELTO"] = Convert.ToInt32(dtEstObs.AsEnumerable().FirstOrDefault(row => row.Field<string>("cEstado") == "RESUELTO").Field<int>("idEstado"));
        }

        private void CargarIndicadores()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.idSolicitud, this.idEtapaEvalCred);
            lblEmisionCompl.Text = (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<string>("cEmisComp")).ToString();
            lblResolComplet.Text = (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<string>("cResolComp")).ToString();
            lblRechazo.Text = (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<string>("cRechazado")).ToString();
            lblAbsolComplet.Text = (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<string>("cAbsuelto")).ToString();
        }

        private void CargarObservaciones()
        {
            DataTable dtObserv = objCNGestionObservaciones.ObtenerObservacionCredito(
                                    (this.chbVigente.Checked),
                                    (this.chbSolicitud.Checked == true ? this.idSolicitud : 0),
                                    (this.chbUsuario.Checked == true ? clsVarGlobal.User.idUsuario : 0), 
                                    Convert.ToInt32(this.cboTipObs.SelectedValue), 
                                    (this.chbEtapa.Checked == true ? this.idEtapaEvalCred : 0), 
                                    this.dtpFechaInicio.Value, 
                                    this.dtpFechaFin.Value);

            DataRow[] drEliminar = dtObserv.Select("idUsuarioReg <> " + clsVarGlobal.User.idUsuario.ToString() + " AND cEstado = 'REGISTRADO'");
            foreach (DataRow row in drEliminar)
            {
                row.Delete();
            }
            dtObserv.AcceptChanges();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtObserv;
            this.dtgObservaciones.DataSource = bindingSource;

            CargarIndicadores();
        }

        private void ConfigDataGridView() 
        {
            this.dtgObservaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.MultiSelect = true;

            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cTipObs", cNombre = "TIPO OBS", nWidth = 190 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cDescripcion", cNombre = "DESCRIPCIÓN", nWidth = (this.lEditar ? 300 + (this.nModoFunc == 1 ? 0 : 30) : 360 ) });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cWinUser", cNombre = "USUARIO", nWidth = 110 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cPerfil", cNombre = "PERFIL", nWidth = 140 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEtapa", cNombre = "ETAPA", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEstado", cNombre = "ESTADO", nWidth = 80 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFechaReg", cNombre = "FECHA", nWidth = 70 });

            foreach (DataGridViewColumn columna in this.dtgObservaciones.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgObservaciones.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgObservaciones.Columns[columna.Index].Width = objItemConfig.nWidth;
                    this.dtgObservaciones.Columns[columna.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dtgObservaciones.Columns[columna.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    this.dtgObservaciones.Columns[columna.Index].Visible = false;
                }
            }

            DataGridViewButtonColumn dtgBotonDet = new DataGridViewButtonColumn();
            dtgBotonDet.HeaderText = "";
            dtgBotonDet.Name = "btnMasDet";
            this.dtgObservaciones.Columns.Add(dtgBotonDet);
            this.dtgObservaciones.Columns["btnMasDet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dtgObservaciones.Columns["btnMasDet"].Width = 30;

            if (this.lEditar) 
            {
                DataGridViewImageColumn dtgBotonEditar = new DataGridViewImageColumn();
                dtgBotonEditar.HeaderText = "";
                dtgBotonEditar.Name = "btnEditar";
                this.dtgObservaciones.Columns.Add(dtgBotonEditar);
                this.dtgObservaciones.Columns["btnEditar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dtgObservaciones.Columns["btnEditar"].Width = 30;

                if(this.nModoFunc == 1)
                {
                    DataGridViewImageColumn dtgBotonBaja = new DataGridViewImageColumn();
                    dtgBotonBaja.HeaderText = "";
                    dtgBotonBaja.Name = "btnBaja";
                    this.dtgObservaciones.Columns.Add(dtgBotonBaja);
                    this.dtgObservaciones.Columns["btnBaja"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    this.dtgObservaciones.Columns["btnBaja"].Width = 30;
                }
            }

        }
        
        private void AdicionandoBotones()
        {
            Image imgVacio = new Bitmap(1, 1);
            for (int i = 0; i < dtgObservaciones.Rows.Count; i++)
            {
                DataGridViewRow row = this.dtgObservaciones.Rows[i];
                if (this.lEditar) 
                {
                    if ((row.Cells["lVigente"].Value != null ? Convert.ToBoolean(row.Cells["lVigente"].Value) : false))
                    {
                        Image imgEditar = ((System.Drawing.Bitmap)(resources.GetObject("btnEditObs.BackgroundImage")));
                        DataGridViewImageCell btnEditar = new DataGridViewImageCell();
                        btnEditar.ToolTipText = "Editar Observación.";
                        btnEditar.Value = imgEditar;
                        row.Cells["btnEditar"] = btnEditar;
                        if (this.nModoFunc == 1)
                        {
                            if (Convert.ToInt32(row.Cells["idUsuarioReg"].Value) == clsVarGlobal.User.idUsuario &&
                                (
                                    Convert.ToInt32(row.Cells["idEstado"].Value) != objEstados["RESUELTO"] &&
                                    Convert.ToInt32(row.Cells["idEstado"].Value) != objEstados["ABSUELTO"]
                            ))
                            {
                                Image imgBaja = ((System.Drawing.Bitmap)(resources.GetObject("btnQuitObs.BackgroundImage")));
                                DataGridViewImageCell btnBaja = new DataGridViewImageCell();
                                btnBaja.ToolTipText = "Dar de baja Observación.";
                                btnBaja.Value = imgBaja;
                                row.Cells["btnBaja"] = btnBaja;
                            }
                            else
                            {
                                DataGridViewImageCell btnBaja = new DataGridViewImageCell();
                                btnBaja.Value = imgVacio;
                                row.Cells["btnBaja"] = btnBaja;
                            }
                        }
                    }
                    else
                    {
                        DataGridViewImageCell btnEditar = new DataGridViewImageCell();
                        btnEditar.Value = imgVacio;
                        row.Cells["btnEditar"] = btnEditar;

                        if (this.nModoFunc == 1)
                        {
                            DataGridViewImageCell btnBaja = new DataGridViewImageCell();
                            btnBaja.Value = imgVacio;
                            row.Cells["btnBaja"] = btnBaja;
                        }
                    }
                }
                
                DataGridViewButtonCell btnMasDet = (DataGridViewButtonCell)row.Cells["btnMasDet"];
                btnMasDet.ToolTipText = "Detalle del procedimiento";
                btnMasDet.Value = "...";
                
                dtgObservaciones.Rows[i].Cells["cDescripcion"].Style.WrapMode = DataGridViewTriState.True;
                dtgObservaciones.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgObservaciones.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }

        private void EmitirObserv(){
            string cRespEmision = GenEmitirObs(false, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (cRespEmision != "")
            {
                CargarObservaciones();
                AdicionandoBotones();
                MessageBox.Show(cRespEmision, "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RegistrarObservaciones(List<clsGestDatObservacion> listObservaciones)
        {
            var xDataObserv = new XElement("dsLisObs", from item in listObservaciones
                                                       select new XElement("Observ",
                                                        new XElement("idRegistroObs", item.idRegistroObs),
                                                        new XElement("idSolicitud", item.idSolicitud),
                                                        new XElement("cDescripcion", item.cDescripcion),
                                                        new XElement("cComentario", item.cComentario),
                                                        new XElement("idUsuario", item.idUsuario),
                                                        new XElement("idUsuarioReg", item.idUsuarioReg),
                                                        new XElement("idTipObs", item.idTipObs),
                                                        new XElement("dFecha", item.cFecha),
                                                        new XElement("idPerfil", item.idPerfil),
                                                        new XElement("idEtapaEvalCred", item.idEtapaEvalCred),
                                                        new XElement("idEstado", item.idEstado),
                                                        new XElement("idMenu", item.idMenu),
                                                        new XElement("lVigente", item.lVigente)));

            objCNGestionObservaciones.RegistrarObservCredito(
                ("<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>" + xDataObserv.ToString())
                .Replace("\r\n", "").Replace(Environment.NewLine, ""));

        }

        public bool ValidarIndicadorObser(int idSolicitud, string cFiltro)
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(idSolicitud, this.idEtapaEvalCred);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>(cFiltro));
        }

        private bool ValidarAbsolucion(int idEptEval)
        {
            switch (this.idEtapaEvalCred)
            {
                case 9: //Opinion Riesgos
                    return ValidaPerfil("235|236|111|238") && idEptEval == 9 ? true : false;
                case 4: //Decision Comite
                    return idEptEval != 9 ? true : false;
                case 5: //Aprobacion Credito
                    return idEptEval != 9 ? true : false;
                default:
                    return false;
            }
        }

        private bool ValidaPerfil(string cListPerfiles) {
            foreach (string cIdPerfil in (cListPerfiles.Replace(" ", "")).Split('|')){
                if (clsVarGlobal.PerfilUsu.idPerfil == Convert.ToInt32(cIdPerfil)){
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
