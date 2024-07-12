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
    public partial class frmReporteCartasFianzaVenYXVen : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        public frmReporteCartasFianzaVenYXVen()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtCartasFianza = new DataTable();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));                        

            string reportpath = "";
            

            if (rbPorVencer.Checked)
            {
                dtCartasFianza = cnCartaFianza.obtenerCartasFianzasPorVencer();
                reportpath = "rptCartasFianzasPorVencer.rdlc";
            }
            else if (rbVencidas.Checked)
            {
                dtCartasFianza = cnCartaFianza.obtenerCartasFianzasVencidas();
                reportpath = "rptCartasFianzasVencidas.rdlc";
            }
            dtslist.Add(new ReportDataSource("dsCartasFianza", dtCartasFianza));
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
