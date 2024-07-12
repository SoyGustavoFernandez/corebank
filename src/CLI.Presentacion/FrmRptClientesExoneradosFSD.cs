using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;

namespace CLI.Presentacion
{
    public partial class FrmRptClientesExoneradosFSD : frmBase
    {
        public FrmRptClientesExoneradosFSD()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtExoneracionFSD = new clsCNCliente().CNListarExoneracionFSD();
            if (dtExoneracionFSD.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el anexo", "Anexo 24", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgencia", cNomAgencia, false));
				paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsExoneracionFSD", dtExoneracionFSD));

                string reportpath = "RptClientesExoneradosFSD.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
