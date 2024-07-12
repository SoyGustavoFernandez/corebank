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
    public partial class frmAnexo10 : frmBase
    {
        public frmAnexo10()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            DataTable dtAnexo10 = new clsRPTCNCredito().CNAnexo10(dFecProceso);
            if (dtAnexo10.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 10", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cCodIns", clsVarApl.dicVarGen["cCodInst"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsAnexo10", dtAnexo10));

                string reportpath = "RptAnexo10.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void frmAnexo10_Load(object sender, EventArgs e)
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;

            DataTable dtAnexo10 = new clsRPTCNCredito().CNAnexo10(dFecProceso);
            if (dtAnexo10.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 10", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;
                    cNomArc = "\\01" +
                                dFecProceso.Year.ToString().Substring(2, 2) +
                                dFecProceso.Month.ToString("00") +
                                dFecProceso.Day.ToString("00") + ".110";

                    StreamWriter sr = new StreamWriter(cRuta + @cNomArc, false, Encoding.ASCII);
                    string pcCadena;

                    pcCadena = "011001" + clsVarApl.dicVarGen["cCodInst"] +
                                dFecProceso.Year.ToString() +
                                dFecProceso.Month.ToString("00") +
                                dFecProceso.Day.ToString("00") + "012";
                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtAnexo10.Rows.Count; i++)
                    {
                        pcCadena = dtAnexo10.Rows[i]["nidFila"].ToString().PadLeft(4, ' ') +
                                    dtAnexo10.Rows[i]["cPais"].ToString().PadLeft(4, ' ') +
                                    dtAnexo10.Rows[i]["cDpto"].ToString().PadLeft(2, ' ') +
                                    dtAnexo10.Rows[i]["cProv"].ToString().PadLeft(2, ' ') +
                                    dtAnexo10.Rows[i]["cDist"].ToString().PadLeft(2, ' ') +
                                    dtAnexo10.Rows[i]["cTipo"].ToString().PadLeft(2, ' ') +
                                    dtAnexo10.Rows[i]["cOfi"].ToString() +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nVisSol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nVisDol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nVisTot"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nAhoSol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nAhoDol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nAhoTot"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nPFSol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nPFDol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nPFTot"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round((Convert.ToDecimal(dtAnexo10.Rows[i]["nPFTot"]) + Convert.ToDecimal(dtAnexo10.Rows[i]["nVisTot"]) + Convert.ToDecimal(dtAnexo10.Rows[i]["nAhoTot"])) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nSldCreSol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nSldCreDol"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    Math.Round(Convert.ToDecimal(dtAnexo10.Rows[i]["nSldCreTot"]) * 100, 0).ToString().PadLeft(15, ' ') +
                                    dtAnexo10.Rows[i]["nGerente"].ToString().PadLeft(15, ' ') +
                                    dtAnexo10.Rows[i]["nFunc"].ToString().PadLeft(15, ' ') +
                                    dtAnexo10.Rows[i]["nEmplea"].ToString().PadLeft(15, ' ') +
                                    dtAnexo10.Rows[i]["nOtros"].ToString().PadLeft(15, ' ') +
                                    dtAnexo10.Rows[i]["nPerTotal"].ToString().PadLeft(15, ' ');
                        sr.WriteLine(pcCadena);
                    }
                    sr.Flush();
                    sr.Close();

                    MessageBox.Show("El Archivo " + cNomArc + " se generó correctamente", "Anexo 10", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
