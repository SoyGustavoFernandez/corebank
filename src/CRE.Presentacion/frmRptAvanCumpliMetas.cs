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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptAvanCumpliMetas : frmBase
    {
        #region Variable Globales

        clsRPTCNCredito cnrptcredito = new clsRPTCNCredito();

        #endregion

        public frmRptAvanCumpliMetas()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            dtpFecReporte.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }


        #endregion

        #region Métodos

        private bool Validar()
        {
            if (dtpFecReporte.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show(@"Seleccione una fecha válida", @"Validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DataTable dtCartera = cnrptcredito.CNrptCumpliMetasAsesor(dtpFecReporte.Value.Date);

                if (dtCartera.Rows.Count > 0)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsCumpleMetaAsesor", dtCartera));

                    paramList.Add(new ReportParameter("dFecha", dtpFecReporte.Value.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("nTipoCambio", Convert.ToString(clsVarApl.dicVarGen["nTipoCambio"]), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("cMesAnio", "JULIO -2011", false));

                    string reportPath = "rptCumplimientoMetaAsesor.rdlc";

                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe datos para los parámetros seleccionados", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
