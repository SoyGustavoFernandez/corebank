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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptConcCarteraActEco : frmBase
    {
        #region Variable Globales

        clsRPTCNCredito cnrptcredito = new clsRPTCNCredito();

        #endregion

        public frmRptConcCarteraActEco()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            dtpFecReporte.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DateTime dFecha = dtpFecReporte.Value.Date;
                DataTable dtCartera = cnrptcredito.CNrptConcActEco(dFecha);

                decimal nTipoCambio = 0;

                DataTable dtTiposCambios = new clsCNGenAdmOpe().RetornaTiposCambio(dFecha);
                nTipoCambio = Convert.ToDecimal(dtTiposCambios.Rows[0]["nTipCamFij"]);

                if (dtCartera.Rows.Count > 0)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsConcActiEco", dtCartera));

                    paramList.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("nTipoCambio", Convert.ToString(nTipoCambio), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("nIndMoraMin", Convert.ToString(clsVarApl.dicVarGen["nIndMoraMin"]), false));

                    string reportPath = "rptConcActiEcono.rdlc";

                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe datos para los parámetros seleccionados", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (dtpFecReporte.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Seleccione una fecha válida", "Validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        #endregion

       
    }
}
