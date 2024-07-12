using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmReporte6E : frmBase
    {
        public frmReporte6E()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataSet dtReporte6E = new clsRPTCNDeposito().CNReporte6E(dFecProceso,"","");
            //if (dtReporte6E.Tables.Rows.Count == 0)
            //{
            //    MessageBox.Show("No existen datos para el reporte", "Reporte 6E", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else
            //{
            //    List<ReportParameter> paramlist = new List<ReportParameter>();
            //    paramlist.Clear();

            //    paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
            //    paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            //    List<ReportDataSource> dtslist = new List<ReportDataSource>();
            //    dtslist.Clear();

            //    dtslist.Add(new ReportDataSource("dsReporte6E", dtReporte6E));

            //    string reportpath = "RptReporte6E.rdlc";
            //    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            //} 
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            //DataTable dtReporte6E = new clsRPTCNDeposito().CNReporte6E(dFecProceso,"","");
            //if (dtReporte6E.Rows.Count == 0)
            //{
            //    MessageBox.Show("No existen datos para el reporte", "Reporte 6E", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else
            //{
            //    DataTable dtReporte6ESoles;
            //    DataTable dtReporte6EDolar;
            //    DataRow[] Registro;

            //    dtReporte6ESoles = dtReporte6E.Clone();
            //    dtReporte6EDolar = dtReporte6E.Clone();

            //    Registro = dtReporte6E.Select("idMoneda = 1", "nIdReporte");
            //    foreach (DataRow dr in Registro)
            //    {
            //        dtReporte6ESoles.ImportRow(dr);
            //    }
            //    Registro = dtReporte6E.Select("idMoneda = 2", "nIdReporte");
            //    foreach (DataRow dr in Registro)
            //    {
            //        dtReporte6EDolar.ImportRow(dr);
            //    }

            //    DialogResult result;
            //    result = folderBrowserDialog1.ShowDialog();
            //    string cRuta;
            //    string cNomArc;

            //    if (result == DialogResult.OK)
            //    {
            //        cRuta = folderBrowserDialog1.SelectedPath;
            //        cNomArc = cRuta + "\\05" +
            //                    clsVarGlobal.dFecSystem.Year.ToString().Substring(2, 2) +
            //                    clsVarGlobal.dFecSystem.Month.ToString("00") +
            //                    clsVarGlobal.dFecSystem.Day.ToString("00") + ".206";

            //        StreamWriter sr = new StreamWriter(@cNomArc);
            //        string pcCadena;

            //        pcCadena = "020605" + clsVarApl.dicVarGen["cCodInst"] +
            //                    clsVarGlobal.dFecSystem.Year.ToString() +
            //                    clsVarGlobal.dFecSystem.Month.ToString("00") +
            //                    clsVarGlobal.dFecSystem.Day.ToString("00") + "012";
            //        sr.WriteLine(pcCadena);

            //        for (int i = 0; i < dtReporte6ESoles.Rows.Count; i++)
            //        {
                        
            //                pcCadena = (Convert.ToInt32(dtReporte6ESoles.Rows[i]["nIdReporte"]) * 100).ToString().PadLeft(4, ' ') +
            //                    Math.Round(Convert.ToDecimal(dtReporte6ESoles.Rows[i]["TEAPromedio"]), 2).ToString().PadLeft(6, ' ') +
            //                    Math.Round(Convert.ToDecimal(dtReporte6ESoles.Rows[i]["nMonOpez"]),2 ).ToString().PadLeft(15, ' ') +
            //                    Math.Round(Convert.ToDecimal(dtReporte6EDolar.Rows[i]["TEAPromedio"]), 2).ToString().PadLeft(6, ' ') +
            //                    Math.Round(Convert.ToDecimal(dtReporte6EDolar.Rows[i]["nMonOpez"]),2 ).ToString().PadLeft(15, ' ');
                        
            //            sr.WriteLine(pcCadena);
            //        }
            //        sr.Close();
            //        MessageBox.Show("El archivo se genero correctamente", "Reporte 6E", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void frmReporte6E_Load(object sender, EventArgs e)
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }
    }
}
