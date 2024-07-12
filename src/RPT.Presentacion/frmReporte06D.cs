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
    public partial class frmReporte06D : frmBase
    {
        public frmReporte06D()
        {
            InitializeComponent();
        }

        private void frmReporte06D_Load(object sender, EventArgs e)
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.Date.AddDays(-1);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataTable dtReporte06D = new clsRPTCNCredito().CNReporte06(dFecProceso);
            if (dtReporte06D.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 06D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte06D", dtReporte06D));

                string reportpath = "RptReporte06D.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataTable dtReporte06D = new clsRPTCNCredito().CNReporte06(dFecProceso);
            if (dtReporte06D.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 06 D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataTable dtReporte06DSoles;
                DataTable dtReporte06DDolar;
                DataRow[] Registro;

                dtReporte06DSoles = dtReporte06D.Clone();
                dtReporte06DDolar = dtReporte06D.Clone();

                Registro = dtReporte06D.Select("idMoneda = 1", "nIdReporte");
                foreach (DataRow dr in Registro)
                {
                    dtReporte06DSoles.ImportRow(dr);
                }
                Registro = dtReporte06D.Select("idMoneda = 2", "nIdReporte");
                foreach (DataRow dr in Registro)
                {
                    dtReporte06DDolar.ImportRow(dr);
                }

                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;
                    cNomArc = cRuta + "\\04" +
                                clsVarGlobal.dFecSystem.Year.ToString().Substring(2, 2) +
                                clsVarGlobal.dFecSystem.Month.ToString("00") +
                                clsVarGlobal.dFecSystem.Day.ToString("00") + ".206";

                    StreamWriter sr = new StreamWriter(@cNomArc);
                    string pcCadena;

                    pcCadena = "020604" + clsVarApl.dicVarGen["cCodInst"] +
                                clsVarGlobal.dFecSystem.Year.ToString() +
                                clsVarGlobal.dFecSystem.Month.ToString("00") +
                                clsVarGlobal.dFecSystem.Day.ToString("00") + "012";
                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtReporte06DSoles.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nNivel"]) == 1)
                        {
                            pcCadena = (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nIdReporte"]) * 100).ToString().PadLeft(6, ' ');
                            
                        }
                        else
                        {
                            pcCadena = (Convert.ToInt32(dtReporte06DSoles.Rows[i]["nIdReporte"]) * 100).ToString().PadLeft(6, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMontoTEA"]), 2).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMontoTCEA"]), 2).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DSoles.Rows[i]["nMonOpe"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMontoTEA"]), 2).ToString().PadLeft(18, ' ') +
                                Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMonOpe"]) * 100, 0).ToString().PadLeft(18, ' ') +
                            Math.Round(Convert.ToDecimal(dtReporte06DDolar.Rows[i]["nMontoTCEA"]), 2).ToString().PadLeft(18, ' ');
                        }
                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se genero correctamente", "Reporte 06 D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
        }
    }
}
