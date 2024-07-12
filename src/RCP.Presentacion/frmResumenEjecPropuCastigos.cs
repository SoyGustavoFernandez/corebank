using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmResumenEjecPropuCastigos : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();
        public frmResumenEjecPropuCastigos()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtResumenCastigos = cnReportes.listarResumenCastigos();
            DataTable dtResumenMesualCartCast = cnReportes.listarResumenCartCast();
            DataTable dtCastigosPorProducto = cnReportes.listarCreditosCastPorProduc();            

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Add(new ReportDataSource("dsResumenCastigos", dtResumenCastigos));
            dtsList.Add(new ReportDataSource("dsResumenMesualCartCast", dtResumenMesualCartCast));
            dtsList.Add(new ReportDataSource("dsCastigosPorProducto", dtCastigosPorProducto));

            DateTime dFechaAntMes = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("dFecFinMesAnt", clsVarGlobal.dFecSystem.AddMonths(-1).ToString(), false));
            paramList.Add(new ReportParameter("dFechaSis", dFechaAntMes.AddDays(-1).ToString(), false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            string reportPath = "rptResumenEjecutivoPropCastigos.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
    }
}
