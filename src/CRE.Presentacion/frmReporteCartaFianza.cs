using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmReporteCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        public frmReporteCartaFianza()
        {
            InitializeComponent();
        }

        private void frmReporteCartaFianza_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = dtpA.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if ((DateTime)dtpDesde.Value > (DateTime)dtpA.Value)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor a la fecha A", "Reporte carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dtCartasFianza = cnCartaFianza.obtenerReporteCartasFianza((DateTime)dtpDesde.Value,(DateTime)dtpA.Value);
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();
            
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaIni", ((DateTime)dtpDesde.Value).ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", ((DateTime)dtpA.Value).ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsCartasFianza", dtCartasFianza));

            string reportpath = "rptReporteCartaFianza.rdlc";            
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }
    }
}
