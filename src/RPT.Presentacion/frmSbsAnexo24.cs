using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RPT.Presentacion
{
    public partial class frmSbsAnexo24 : frmBase
    {
        public frmSbsAnexo24()
        {
            InitializeComponent();
        }

        private void frmSbsAnexo24_Load(object sender, EventArgs e)
        {
            
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataTable dtSbsAnexo24 = new clsRPTCNDeposito().CNSbsAnexo24(dFecProceso);
            if (dtSbsAnexo24.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el anexo", "Anexo 24", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dtslist.Add(new ReportDataSource("dsAnexo24", dtSbsAnexo24));

                string reportpath = "RptSbsAnexo24.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            DataTable dtSbsAnexo24 = new clsRPTCNDeposito().CNSbsAnexo24(dFecProceso);
            
            if (dtSbsAnexo24.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el anexo", "Anexo 24", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog.SelectedPath;
                    cNomArc = cRuta + "\\01" + dFecProceso.Year.ToString().Substring(2, 2) +
                                               dFecProceso.Month.ToString("00") +
                                               dFecProceso.Day.ToString("00") + ".124";

                    StreamWriter sr = new StreamWriter(@cNomArc);
                    string pcCadena;

                    pcCadena = "012401" + clsVarApl.dicVarGen["cCodInst"] +
                                          dFecProceso.Year.ToString() +
                                          dFecProceso.Month.ToString("00") +
                                          dFecProceso.Day.ToString("00") + "012";
                    
                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtSbsAnexo24.Rows.Count; i++)
                    {
                        pcCadena =  Convert.ToInt32(dtSbsAnexo24.Rows[i]["nCodRegistro"]).ToString().PadLeft(4, ' ') +
                                    Convert.ToString(dtSbsAnexo24.Rows[i]["cUbigeoSBS"]).PadLeft(2, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonDepCtsMN"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonDepCtsME"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonDepCts"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonGarCtsMN"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonGarCtsME"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonGarCts"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCtsMN"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCtsME"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCts"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCtsMes"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCtsHip"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCtsCon"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Math.Round(Convert.ToDecimal(dtSbsAnexo24.Rows[i]["nMonCreCts"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Convert.ToInt32(dtSbsAnexo24.Rows[i]["nNumClientes"]).ToString().PadLeft(18, ' ') +
                                    Convert.ToInt32(dtSbsAnexo24.Rows[i]["nNumEmpleador"]).ToString().PadLeft(18, ' ');

                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se genero correctamente", "Anexo 24", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
        }
    }
}
