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
using RCP.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
namespace RCP.Presentacion
{
    public partial class frmAprobacionComisionRecuperacion : frmBase
    {
        #region Variables Globales
        private clsCNRecuperacionComision objCNRecuperacionComision;
        private List<clsAproSolicitudRecComision> lstAproSolicitudRecComision;
        private clsAproSolicitudRecComision objAproSolicitudRecComision;
        private BindingSource bsAproSolicitudRecComision;
        #endregion
        public frmAprobacionComisionRecuperacion()
        {
            InitializeComponent();
            this.inicializarDatos();
        }        
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNRecuperacionComision = new clsCNRecuperacionComision();
            this.lstAproSolicitudRecComision = new List<clsAproSolicitudRecComision>();
            this.objAproSolicitudRecComision = new clsAproSolicitudRecComision();
            this.bsAproSolicitudRecComision = new BindingSource();

            this.bsAproSolicitudRecComision.DataSource = this.lstAproSolicitudRecComision;
            this.dtgAprobacionRecuperacionComision.DataSource = this.bsAproSolicitudRecComision;

            this.formatearAproSolicitudRecComision();

            this.habilitarControles(clsAcciones.NUEVO);
        }
        private void formatearAproSolicitudRecComision()
        {
            foreach(DataGridViewColumn dtgColumn in this.dtgAprobacionRecuperacionComision.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.dtgAprobacionRecuperacionComision.Columns["idAproSolicitudRecComision"].Visible = true;
            this.dtgAprobacionRecuperacionComision.Columns["idNivelAprobacion"].Visible = true;
            this.dtgAprobacionRecuperacionComision.Columns["dFechaComision"].Visible = true;
            this.dtgAprobacionRecuperacionComision.Columns["nMontoComision"].Visible = true;
            this.dtgAprobacionRecuperacionComision.Columns["cNombre"].Visible = true;
            this.dtgAprobacionRecuperacionComision.Columns["dFecha"].Visible = true;

            this.dtgAprobacionRecuperacionComision.Columns["idAproSolicitudRecComision"].HeaderText = "Cod.Sol.";
            this.dtgAprobacionRecuperacionComision.Columns["idNivelAprobacion"].HeaderText = "Nivel Apro.";
            this.dtgAprobacionRecuperacionComision.Columns["dFechaComision"].HeaderText = "Fec. Comisión";
            this.dtgAprobacionRecuperacionComision.Columns["nMontoComision"].HeaderText = "Monto";
            this.dtgAprobacionRecuperacionComision.Columns["cNombre"].HeaderText = "Solicitante";
            this.dtgAprobacionRecuperacionComision.Columns["dFecha"].HeaderText = "Fec.Solic";

            this.dtgAprobacionRecuperacionComision.Columns["idAproSolicitudRecComision"].DisplayIndex = 0;
            this.dtgAprobacionRecuperacionComision.Columns["idNivelAprobacion"].DisplayIndex = 1;
            this.dtgAprobacionRecuperacionComision.Columns["dFechaComision"].DisplayIndex = 2;
            this.dtgAprobacionRecuperacionComision.Columns["nMontoComision"].DisplayIndex = 3;
            this.dtgAprobacionRecuperacionComision.Columns["cNombre"].DisplayIndex = 4;
            this.dtgAprobacionRecuperacionComision.Columns["dFecha"].DisplayIndex = 5;
        }
        private void habilitarControles(int nAccion)
        {
            switch(nAccion)
            {
                case clsAcciones.RESOLVER:
                    this.txtComentario.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    
                    break;
                case clsAcciones.DENEGAR:
                    this.txtComentario.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    break;
                case clsAcciones.NUEVO:
                    this.txtComentario.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    break;
                case clsAcciones.BUSCAR:
                    this.txtComentario.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnAprobar.Enabled = true;
                    this.btnDenegar.Enabled = true;
                    break;
            }
        }
        private void listarAproSolicitudRecComision()
        {
            this.lstAproSolicitudRecComision.Clear();
            this.lstAproSolicitudRecComision.AddRange(this.objCNRecuperacionComision.listarAproSolicitudRecComision());

            if (this.lstAproSolicitudRecComision.Count > 0)
            {
                this.habilitarControles(clsAcciones.BUSCAR);
            }
            else
            {
                MessageBox.Show("No hay solicitudes de aprobación de comisiones pendientes.","SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.bsAproSolicitudRecComision.ResetBindings(false);
            this.dtgAprobacionRecuperacionComision.Refresh();
        }
        private void grabarResolucionAproSolRecComision(int idEstado, int idNivelAprobacionSig, string cComentario)
        {
            DataTable dtResultado = this.objCNRecuperacionComision.grabarResolucionAproSolRecComision(
                this.objAproSolicitudRecComision.idAproSolicitudRecComision,
                idEstado,
                this.objAproSolicitudRecComision.idNivelAprobacion,
                idNivelAprobacionSig,
                this.objAproSolicitudRecComision.nMontoComision,
                this.objAproSolicitudRecComision.dFechaComision,
                cComentario
                );

            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.RESOLVER);
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.NUEVO);
            }
        }
        private void gestionarAprobacionRecuperacionComision()
        {
            DataTable dtResultado = this.objCNRecuperacionComision.gestionarAprobacionRecuperacionComision(this.objAproSolicitudRecComision.idNivelAprobacion);
            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                DialogResult oDResult = MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDResult == DialogResult.Yes)
                {
                    this.grabarResolucionAproSolRecComision(
                           Convert.ToInt32(dtResultado.Rows[0]["idEstado"]),
                           Convert.ToInt32(dtResultado.Rows[0]["idNivelAprobacionSig"]),
                           this.txtComentario.Text
                        );
                }
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.NUEVO);
            }
        }
        #endregion
        #region Eventos
        private void frmAprobacionComisionRecuperacion_Shown(object sender, EventArgs e)
        {
            this.listarAproSolicitudRecComision();
        }
        private void dtgAprobacionRecuperacionComision_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dtgAprobacionRecuperacionComision.SelectedRows.Count ==0)return;
            int nIndice;
            nIndice = this.dtgAprobacionRecuperacionComision.SelectedRows[0].Index;
            this.objAproSolicitudRecComision = this.lstAproSolicitudRecComision[nIndice];
        }
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            this.gestionarAprobacionRecuperacionComision();
        }
        private void btnDenegar_Click(object sender, EventArgs e)
        {
            this.grabarResolucionAproSolRecComision(
                           (int)EstadoEvalCred.DENEGADO,
                           this.objAproSolicitudRecComision.idNivelAprobacion,
                           this.txtComentario.Text
                        );
            this.habilitarControles(clsAcciones.DENEGAR);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.dtgAprobacionRecuperacionComision.SelectedRows.Count == 0)
                return;

            int nIndice = this.dtgAprobacionRecuperacionComision.SelectedRows[0].Index;

            DateTime dFecha = this.lstAproSolicitudRecComision[nIndice].dFechaComision;
            DataSet dsReporte = (new clsCNRecuperacionComision()).recuperacionComisionHistorico(dFecha);

            if (dsReporte.Tables.Count == 3)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.User.cEstablecimiento, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
                paramlist.Add(new ReportParameter("idZona", "0", false));
                paramlist.Add(new ReportParameter("idEstablecimiento", clsVarGlobal.User.idEstablecimiento.ToString(), false));
                paramlist.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRecupComisionHistorico", dsReporte.Tables[0]));
                dtslist.Add(new ReportDataSource("dsRecupComisionHistoricoEspecial", dsReporte.Tables[1]));
                dtslist.Add(new ReportDataSource("dsEvolucionRecupComision", dsReporte.Tables[2]));

                string reportpath = "rptRecuperacionComisionHistorico.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
        #endregion
    }
}
