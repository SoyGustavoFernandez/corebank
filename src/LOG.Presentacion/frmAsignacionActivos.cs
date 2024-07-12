using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.ControlesBase;
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace LOG.Presentacion
{
    public partial class frmAsigancionActivos : frmBase
    {
        #region Variables

        DataTable dtDetalleAct = new DataTable();
        int idUsuDest, nidAgenciaDest;
        string cNom , cDocID , idCargoPer,  cCargoPer, idCliPer;
        clsCNPersonal DatosPersonal = new clsCNPersonal();        
        DataTable dtDetActivoOrigen = new DataTable();
        clsCNActivos CNActivo = new clsCNActivos();
        DataTable dtUpdActivo = new DataTable();
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

        #endregion

        #region Constructor

        public frmAsigancionActivos()
        {
            InitializeComponent();

            var dtTiposCargoEntrega = CNActivo.CNlistaTipoEncargo();
            cboTipodeImpresion.DataSource = dtTiposCargoEntrega;
            cboTipodeImpresion.ValueMember = dtTiposCargoEntrega.Columns[0].ToString();
            cboTipodeImpresion.DisplayMember = dtTiposCargoEntrega.Columns[1].ToString();
        }

        #endregion

        #region Eventos

        private void frmAsigancionActivos_Load(object sender, EventArgs e)
        {
            ActivarControl(false);
            dtpActivacion.Value = dFechaSis;
            btnImprimir.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpia();
            ActivarControl(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpia();
            ActivarControl(false);
            btnImprimir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarControl(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Valida())
                return;

            string cSust = txtSustento.Text.Trim();
            DataSet dsDetActivo = new DataSet("dsDetActivo");
            dsDetActivo.Tables.Add(dtDetActivoOrigen);
            string xmlDetActivo = dsDetActivo.GetXml();
            xmlDetActivo = clsCNFormatoXML.EncodingXML(xmlDetActivo);
            dsDetActivo.Tables.Clear();

            int idUsuReg = clsVarGlobal.User.idUsuario;
            int idAgenciaReg = clsVarGlobal.nIdAgencia;
            DateTime dFechaReg = dFechaSis;
            DateTime dFechaActivacion = dtpActivacion.Value;

            dtUpdActivo = CNActivo.CNUpdActivos(xmlDetActivo, idUsuDest, nidAgenciaDest, idUsuReg, idAgenciaReg, dFechaReg, dFechaActivacion, cSust);
            MessageBox.Show("El Activo se Asigno al Colaborador Correctamente", "Asignación de Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActivarControl(false);
        }

        private void btnAddActivos_Click(object sender, EventArgs e)
        {
            frmBuscaActivoColab FrmBuscaActColab = new frmBuscaActivoColab();
            FrmBuscaActColab.cIdEstado = "1,2";
            FrmBuscaActColab.ShowDialog();
            DataTable dtDetalleAct = FrmBuscaActColab.dtDetalleActivo;

            if (dtDetalleAct.Rows.Count == 0)
            {
                MessageBox.Show("No seleccionó ningun Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                string idActivos = "";
                for (int i = 0; i < dtDetalleAct.Rows.Count; i++)
                {
                    idActivos += (dtDetalleAct.Rows[i]["idActivo"] + ",");
                }

                dtDetActivoOrigen = CNActivo.CNListaActivosId(idActivos);

                dtDetActivoOrigen.Columns.Add("cTipModif", typeof(string));
                dtDetActivoOrigen.DefaultView.RowFilter = ("cTipModif <> 'D'");
                for (int i = 0; i < dtDetActivoOrigen.Rows.Count; i++)
                {
                    dtDetActivoOrigen.Rows[i]["cTipModif"] = "I";
                }

                this.dtgActivoOrigen.DataSource = dtDetActivoOrigen.DefaultView;
                FormatGrid();
            }

        }

        private void btnQuitActivos_Click(object sender, EventArgs e)
        {
            if (this.dtgActivoOrigen.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida Asignación de Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgActivoOrigen.SelectedCells[0].RowIndex);
                if (dtgActivoOrigen.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgActivoOrigen.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgActivoOrigen.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgActivoOrigen.Focus();
                ProcessTabKey(true);
            }
        }

        private void btnAddUsuario_Click(object sender, EventArgs e)
        {
            CleanDataUsu();
            BuscaColaborador();
            Buscar(idUsuDest);
        }

        private void btnQuitUsuario_Click(object sender, EventArgs e)
        {
            if (this.dtgActivoDestino.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida Asignación de Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgActivoDestino.SelectedCells[0].RowIndex);
                if (dtgActivoDestino.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgActivoDestino.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgActivoDestino.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgActivoOrigen.Focus();
                ProcessTabKey(true);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idMovimiento;
            if (Int32.TryParse(dtUpdActivo.Rows[0]["idMovimiento"].ToString(), out idMovimiento))
            {
                // nuevas opciones de impresion //////////////////////////////////////////
                int nIdTipoImpresion = Convert.ToInt32(cboTipodeImpresion.SelectedValue);

                if (nIdTipoImpresion != 1) 
                {
                    if (nIdTipoImpresion == 2)
                    {
                        int nIdMovimiento = Convert.ToInt32(dtUpdActivo.Rows[0]["idMovimiento"]);
                        ImprimirFormatoParaMoviles(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 3)
                    {
                        int nIdMovimiento = Convert.ToInt32(dtUpdActivo.Rows[0]["idMovimiento"]);
                        ImprimirFormatoParaComputadores(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 4)
                    {
                        int nIdMovimiento = Convert.ToInt32(dtUpdActivo.Rows[0]["idMovimiento"]);
                        ImprimirFormatoParaCamionetas(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 5)
                    {
                        int nIdMovimiento = Convert.ToInt32(dtUpdActivo.Rows[0]["idMovimiento"]);
                        ImprimirFormatoParaMotos(nIdMovimiento);
                        return;
                    }
                }
                // end nuevas opciones de impresion //////////////////////////////////////////


                String cNomAgen = clsVarGlobal.cNomAge;
                String cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsactivos", new clsCNActivos().CNActivos(idMovimiento)));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idMovimiento", idMovimiento.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));

                string reportpath = "RptAsigActivo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se cargó ninguna asignación de activos", "Registrar Asignación del Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region Metodos

        private void ImprimirFormatoParaMoviles(int nIdMovimiento)
        {
            frmCargoEntregaMoviles frmcargoentregamoviles = new frmCargoEntregaMoviles(nIdMovimiento);
            frmcargoentregamoviles.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaComputadores(int nIdMovimiento)
        {
            frmCargoEntregaComputadores frmcargoentregacomputadores = new frmCargoEntregaComputadores(nIdMovimiento);
            frmcargoentregacomputadores.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaMotos(int nIdMovimiento)
        {
            frmCargoEntregaMoto frmcargoentregamotos = new frmCargoEntregaMoto(nIdMovimiento);
            frmcargoentregamotos.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaCamionetas(int nIdMovimiento)
        {
            frmCargoEntregaCamionetas frmcargoentregacamionetas = new frmCargoEntregaCamionetas(nIdMovimiento);
            frmcargoentregacamionetas.ShowDialog();
            return;
        }

        private void CleanDataUsu()
        {
            idUsuDest = 0;
            cNom = "";
            cDocID = "";
            idCargoPer = "";
            cCargoPer = "";
            idCliPer = "";
            nidAgenciaDest = 0;
        }

        private void BuscaColaborador()
        {
            FrmBusCol frm = new FrmBusCol();
            frm.ShowDialog();
            if (Convert.ToString(frm.idUsu) != "")
            {
                idUsuDest = Convert.ToInt32(frm.idUsu);
                cNom = frm.cNom;
                cDocID = frm.cDocID;
                idCargoPer = frm.idCargoPer;
                cCargoPer = frm.cCargoPer;
                idCliPer = frm.idCliPer;
                nidAgenciaDest = Convert.ToInt32(frm.nidAgencia);
            }
        }

        public void Buscar(int idUsuResp)
        {
            DataTable dt = DatosPersonal.CNBuscaPersonal(idUsuResp);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Personal no vigente, no se le puede asignar un activo", "Validar asignacion de activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            dt.Columns.Add("cTipModif", typeof(string));
            dt.DefaultView.RowFilter = ("cTipModif <> 'D'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["cTipModif"] = "I";
            }

            dtgActivoDestino.DataSource = dt.DefaultView;


            FormatoDataGrid();
        }

        private void FormatoDataGrid()
        {
            dtgActivoDestino.Columns["idUsuario"].Visible = true;
            dtgActivoDestino.Columns["cNombre"].Visible = true;
            dtgActivoDestino.Columns["cDocumentoID"].Visible = true;
            dtgActivoDestino.Columns["cCargo"].Visible = true;
            dtgActivoDestino.Columns["cArea"].Visible = true;
            dtgActivoDestino.Columns["cNombreAge"].Visible = true;
            dtgActivoDestino.Columns["cTipModif"].Visible = false;

            dtgActivoDestino.Columns["idUsuario"].HeaderText = "Cod. Usuario";
            dtgActivoDestino.Columns["cNombre"].HeaderText = "Colaborador Responsable";
            dtgActivoDestino.Columns["cDocumentoID"].HeaderText = "N° Documento";
            dtgActivoDestino.Columns["cCargo"].HeaderText = "Cargo";
            dtgActivoDestino.Columns["cArea"].HeaderText = "Área";
            dtgActivoDestino.Columns["cNombreAge"].HeaderText = "Agencia";

        }

        private void ActivarControl(bool lActivar)
        {
            txtSustento.Enabled = lActivar;
            btnImprimir.Enabled = !lActivar;
            btnNuevo.Enabled = !lActivar;
            btnEditar.Enabled = !lActivar;
            btnGrabar.Enabled = lActivar;
            btnAddActivos.Enabled = lActivar;
            btnQuitActivos.Enabled = lActivar;
            btnAddUsuario.Enabled = lActivar;
            btnQuitUsuario.Enabled = lActivar;
            dtgActivoOrigen.Enabled = lActivar;
            dtgActivoDestino.Enabled = lActivar;
            dtpActivacion.Enabled = lActivar;

        }

        private bool Valida()
        {
            if (dtgActivoOrigen.SelectedCells.Count == 0)
            {
                MessageBox.Show("No existe Activos de Origen", "Valida Asignación de Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtgActivoDestino.SelectedCells.Count == 0)
            {
                MessageBox.Show("No existe Colaborador Responsable de Destino", "Valida Asignación de Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento de la Asignación del Activo", "Registrar Asignación del Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSustento.Focus();
                return false;
                
            }

            return true;
        }

        public void FormatGrid()
        {
            dtgActivoOrigen.Columns["idActivo"].Visible = true;
            dtgActivoOrigen.Columns["cProducto"].Visible = true;
            dtgActivoOrigen.Columns["cObservacion"].Visible = false;
            dtgActivoOrigen.Columns["idUsuOrig"].Visible = false;
            dtgActivoOrigen.Columns["cNombreColResp"].Visible = true;
            dtgActivoOrigen.Columns["idAgenciaOrig"].Visible = false;
            dtgActivoOrigen.Columns["cNombreAge"].Visible = true;
            dtgActivoOrigen.Columns["cCargo"].Visible = true;
            dtgActivoOrigen.Columns["cArea"].Visible = true;
            dtgActivoOrigen.Columns["cTipModif"].Visible = false;

            dtgActivoOrigen.Columns["idActivo"].HeaderText = "Cod Activo";
            dtgActivoOrigen.Columns["cProducto"].HeaderText = "Producto";
            dtgActivoOrigen.Columns["cNombreColResp"].HeaderText = "Responsable";
            dtgActivoOrigen.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgActivoOrigen.Columns["cCargo"].HeaderText = "Cargo";
            dtgActivoOrigen.Columns["cArea"].HeaderText = "Area Resp.";

            dtgActivoOrigen.Columns["idActivo"].Width = 50;
        }

        public void limpia()
        {
            dtgActivoOrigen.DataSource = null;
            dtgActivoDestino.DataSource = null;
            dtDetActivoOrigen.Clear();
            dtDetalleAct.Clear();
            txtSustento.Text = string.Empty;
            dtpActivacion.Value = dFechaSis;
        }

        #endregion

    }
}
