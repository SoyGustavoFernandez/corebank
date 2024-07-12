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
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmRetiroActivos : frmBase
    {

        #region Variables

        DataTable dtDetActivoOrigen = new DataTable();
        clsCNActivos Activos = new clsCNActivos();
        public string cNom, cDocID, idCargoPer, cCargoPer, idCliPer;
        public int idCliProveed, idUsu, nidAgencia;
        DataTable dtUpdActivo = new DataTable();

        #endregion

        #region Eventos

        private void frmRetiroActivos_Load(object sender, EventArgs e)
        {
            dtpFeBaja.Value = clsVarGlobal.dFecSystem;
            ActivarControl(false);
            btnEditar1.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpia();
            ActivarControl(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarControl(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }

            DataSet dsDetActivo = new DataSet("dsDetActivo");
            dsDetActivo.Tables.Add(dtDetActivoOrigen);
            string xmlDetActivo = dsDetActivo.GetXml();
            xmlDetActivo = clsCNFormatoXML.EncodingXML(xmlDetActivo);
            dsDetActivo.Tables.Clear();

            int idUsuReg = clsVarGlobal.User.idUsuario;
            int idAgenciaReg = clsVarGlobal.nIdAgencia;
            DateTime dFechaBaja = dtpFeBaja.Value;
            string cMotivoBaja = txtDescripBaja.Text.ToString();
            int idMotBajaActivo = Convert.ToInt32(cboMotBajaActivo.SelectedValue);

            dtUpdActivo = Activos.CNDarBajaActivos(xmlDetActivo, idUsu, idMotBajaActivo, dFechaBaja, cMotivoBaja);

            MessageBox.Show(dtUpdActivo.Rows[0]["cMensaje"].ToString(), "Retiro de Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Convert.ToInt32(dtUpdActivo.Rows[0]["idError"]) == 0)
            {
                ActivarControl(false);
                btnImprimir.Enabled = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpia();
            ActivarControl(false);
            btnEditar1.Enabled = false;
        }

        private void btnAddActivos_Click(object sender, EventArgs e)
        {
            frmBuscaActivoColab FrmBuscaActColab = new frmBuscaActivoColab();
            FrmBuscaActColab.cIdEstado = "2";
            FrmBuscaActColab.ShowDialog();
            DataTable dtDetalleAct = FrmBuscaActColab.dtDetalleActivo;

            if (dtDetalleAct.Rows.Count == 0)
            {
                MessageBox.Show("No seleccionó ningun Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                String idActivos = "";
                for (int i = 0; i < dtDetalleAct.Rows.Count; i++)
                {
                    idActivos += (dtDetalleAct.Rows[i]["idActivo"] + ",");
                }

                dtDetActivoOrigen = Activos.CNListaActivosId(idActivos);

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

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CleanDataUsu();
            BuscaColaborador();
            txtUsuario.Text = cNom;
        }

        #endregion

        #region Metodos

        public frmRetiroActivos()
        {
            InitializeComponent();
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
            this.dtgActivoOrigen.DataSource = null;
            this.dtDetActivoOrigen.Clear();
            txtDescripBaja.Text = "";
            cboMotBajaActivo.SelectedValue = 1;
            txtUsuario.Text = string.Empty;
        }

        private void ActivarControl(bool lActivar)
        {
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = !lActivar;
            btnEditar1.Enabled = !lActivar;
            btnGrabar.Enabled = lActivar;
            btnAddActivos.Enabled = lActivar;
            btnQuitActivos.Enabled = lActivar;
            dtgActivoOrigen.Enabled = lActivar;
            btnBusqueda.Enabled = lActivar;
            cboMotBajaActivo.Enabled = lActivar;
            txtDescripBaja.Enabled = lActivar;
        }

        private bool Valida()
        {
            if (this.dtgActivoOrigen.SelectedCells.Count == 0)
            {
                MessageBox.Show("No existe Activos a dar de Baja", "Valida Retiro de Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnAddActivos.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar el Usuario que Retiro el activo", "Valida Retiro Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnBusqueda.Focus();
                return false;
            }

            return true;
        }

        private void CleanDataUsu()
        {
            idUsu = 0;
            cNom = "";
            cDocID = "";
            idCargoPer = "";
            cCargoPer = "";
            idCliPer = "";
            nidAgencia = 0;
        }

        private void BuscaColaborador()
        {
            FrmBusCol frm = new FrmBusCol();
            frm.ShowDialog();
            if (Convert.ToString(frm.idUsu) != "")
            {
                idUsu = Convert.ToInt32(frm.idUsu);
                cNom = frm.cNom;
                cDocID = frm.cDocID;
                idCargoPer = frm.idCargoPer;
                cCargoPer = frm.cCargoPer;
                idCliPer = frm.idCliPer;
                nidAgencia = Convert.ToInt32(frm.nidAgencia);
            }
        }

        #endregion

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dsBienesBaja = ((DataView)dtgActivoOrigen.DataSource).Table;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            string cObservacion = txtDescripBaja.Text;
            if (cObservacion == "")
                cObservacion = "No Detalla";

            paramlist.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("cObservacion", cObservacion, false));
            paramlist.Add(new ReportParameter("cResponsableBaja", txtUsuario.Text, false));
            paramlist.Add(new ReportParameter("cUsuarioAtencion", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("dFechaBaja", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("cTipoBaja", cboMotBajaActivo.Text, false));
            

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsBienesBaja", dsBienesBaja));


            string reportpath = "rptActaBajaActivos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
