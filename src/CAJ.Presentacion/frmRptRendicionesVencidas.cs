using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRptRendicionesVencidas : frmBase
    {
        #region Variables
        private clsCNCuentasPorPagar cnCuentasPorPagar = new clsCNCuentasPorPagar();
        #endregion

        #region Metodos
        public frmRptRendicionesVencidas()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtRendiciones = cnCuentasPorPagar.listarRendicionesVencidas();

            if (dtRendiciones.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge.ToString(), false));

                dtslist.Add(new ReportDataSource("dtRendicionesPendientes", dtRendiciones));
                string reportpath = "rptRendicionesVencidas.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
            else
            {
                MessageBox.Show("No se ha encontrado Rendicones Vencidas", "Rendiciones Vencidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
