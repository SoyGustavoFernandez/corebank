using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmReportePaqueteSeguroSMS :  frmBase
    {
        #region Variables Globales
        private clsCNAdministracionEnvioSMS objCNAdministracionEnvioSMS { get; set; }
        #endregion

        public frmReportePaqueteSeguroSMS()
        {
            InitializeComponent();
            cargarComponentes();
        }
        public void cargarComponentes()
        {
            objCNAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            this.cboZona.cargarZona(true, false);
            this.cboAgencia.FiltrarPorZona(-1, false, false);
            this.cboEstablecimiento.CargarEstablecimiento(0);
        }

        public void cargarDatos()
        {
            this.cboZona.SelectedIndex = -1;
            this.cboAgencia.SelectedIndex = -1;
            this.cboEstablecimiento.SelectedIndex = -1;

            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;

            this.cboZona.Enabled = true;
            this.cboAgencia.Enabled = false;
            this.cboEstablecimiento.Enabled = false;
            this.cboZona.Focus();
        }
        public bool validar()
        {
            if (cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Zona.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Agencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboEstablecimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Establecimiento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La Fecha Final no puede ser anterior a la Fecha Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void frmReportePaqueteSeguroSMS_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarDatos();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZona.SelectedIndex != -1)
            {
                int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
                this.cboAgencia.FiltrarPorZonaTodos(idZonaSeleccionado);
                this.cboEstablecimiento.CargarEstablecimientos(0);

                cboAgencia.SelectedIndex = -1;
                cboEstablecimiento.SelectedIndex = -1;
                cboAgencia.Enabled = true;
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex != -1)
            {
                int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
                this.cboEstablecimiento.CargarEstablecimientos(idAgenciaSeleccionado);
                this.cboEstablecimiento.SelectedIndex = -1;

                cboEstablecimiento.Enabled = true;
            }
            else
            {
                this.cboEstablecimiento.SelectedIndex = -1;
                cboEstablecimiento.Enabled = false;
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtRPTSMSPaqueteSeguro = objCNAdministracionEnvioSMS.CNObtenerRPTSMSPaqueteSeguro(idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);

           
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaDesde", Convert.ToString(dFechaDesde), false));
            paramlist.Add(new ReportParameter("dFechaHasta", Convert.ToString(dFechaHasta), false));

            dtslist.Add(new ReportDataSource("DataSetSMSPS", dtRPTSMSPaqueteSeguro));

            string reportpath = "rptPaqueteSeguroSMS.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }
    }
}
