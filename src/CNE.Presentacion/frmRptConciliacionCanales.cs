using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmRptConciliacionCanales : frmBase
    {
        #region Variables Globales

        private clsCNConciliacionPagos API = new clsCNConciliacionPagos();
        DateTime dFecSystem = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Reporte del Proceso de Conciliación";
        clsCNPdp cnRptPdp = new clsCNPdp();
        
        private enum StatusCode
        {
            OK = 200,
            BadRequest = 400
        }
        
        private enum EnumCanal
        {
            BancoNacion = 4,
            BancoCredito = 5,
            Kasnet = 7,
            BilleteraElectronicaMovil = 8,
            Niubiz = 10
        }

        #endregion

        #region Metodos Publicos

        public frmRptConciliacionCanales()
        {
            InitializeComponent();
            CargaComboCanales();
            this.dtpFecha.Value = this.dFecSystem;
        }

        #endregion

        #region Metodos Privados

        private void CargaComboCanales()
        {
            var dtCanales = new clsCNConciliacionPagos().ObtenerConfiguracionCanalesElectronicos();

            List<object> listCanales = new List<object>();

            foreach (DataRow row in dtCanales.Rows)
            {
                var objeto = new
                {
                    idCanal = Convert.ToInt32(row["idCanal"]),
                    cNombreCanal = row["cNombreCanal"].ToString()
                };
                listCanales.Add(objeto);
            }

            this.cboCanalElec.DataSource = listCanales;
            this.cboCanalElec.ValueMember = "idCanal";
            this.cboCanalElec.DisplayMember = "cNombreCanal";
        }

        private void ReportePagosCargados()
        {
            int idCanal = Convert.ToInt32(this.cboCanalElec.SelectedValue);
            DateTime dFecha = this.dtpFecha.Value;
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            var callResult = API.ObtenerReportePagosCargados(idCanal, dFecha);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet result = callResult.Data;

            if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCabecera", result.Tables[0]));
                dtsList.Add(new ReportDataSource("dsDetalle", result.Tables[1]));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idCanal", idCanal.ToString(), false));
                paramlist.Add(new ReportParameter("dFecha", this.dtpFecha.Value.ToString("yyyy-MM-dd"), false));
                paramlist.Add(new ReportParameter("dFechaSis", this.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = string.Empty;
                switch (idCanal)
                {
                    case (int)EnumCanal.BancoNacion:
                        reportPath = "rptReporteDatosCargadosBN.rdlc";
                        break;
                    case (int)EnumCanal.BancoCredito:
                        reportPath = "rptReporteDatosCargadosBCP.rdlc";
                        break;
                    case (int)EnumCanal.Kasnet:
                        reportPath = "rptReporteDatosCargadosKasnet.rdlc";
                        break;
                    case (int)EnumCanal.BilleteraElectronicaMovil:
                        reportPath = "rptReporteDatosCargadosBIN.rdlc";
                        break;
                    case (int)EnumCanal.Niubiz:
                        reportPath = "rptReporteDatosCargadosNiubiz.rdlc";
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(reportPath))
                {
                    new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ReporteResultadoConciliacion()
        {
            int idCanal = Convert.ToInt16(this.cboCanalElec.SelectedValue);
            DateTime dFecha = this.dtpFecha.Value;
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            var callResult = API.ObtenerReporteResultadoConciliacion(idCanal, dFecha);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet result = callResult.Data;

            if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dtPagosKardex", result.Tables[0]));
                dtsList.Add(new ReportDataSource("dtTransacciones", result.Tables[1]));
                dtsList.Add(new ReportDataSource("dtBitacora", result.Tables[2]));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idCanal", idCanal.ToString(), false));
                paramlist.Add(new ReportParameter("dFecha", this.dtpFecha.Value.ToString("yyyy-MM-dd"), false));

                paramlist.Add(new ReportParameter("dFechaSis", this.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteConciliacionCanales.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        #endregion

        #region Eventos

        private void btnReportePagosCargados_Click(object sender, EventArgs e)
        {
            ReportePagosCargados();
        }

        private void btnReporteResultadoConciliacion_Click(object sender, EventArgs e)
        {
            ReporteResultadoConciliacion();
        }

        #endregion
    }
}
