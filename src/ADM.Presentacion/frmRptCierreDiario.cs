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
using CRE.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmRptCierreDiario : frmBase
    {
        #region Variable Globales

        clsCNCierreCredito cncierre = new clsCNCierreCredito();

        #endregion

        public frmRptCierreDiario()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            dtpProceso.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtCierreDiario = cncierre.CNrptCierreDiario(dtpProceso.Value.Date);

                if (dtCierreDiario.Rows.Count > 0)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsCierreDiario", dtCierreDiario));

                    paramList.Add(new ReportParameter("dFechaProceso", dtpProceso.Value.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                    string reportPath = "rptCierreDiario.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe datos para la fecha seleccionada", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (dtpProceso.Value.Date >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Por favor seleccione una fecha válida", "Validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        #endregion        
    }
}
