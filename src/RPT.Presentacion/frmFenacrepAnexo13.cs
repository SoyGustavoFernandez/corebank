using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace RPT.Presentacion
{
    public partial class frmFenacrepAnexo13 : frmBase
    {
        public frmFenacrepAnexo13()
        {
            InitializeComponent();
        }

        private void frmFenacrepAnexo13_Load(object sender, EventArgs e)
        {
            this.dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExporExcel_Click(object sender, EventArgs e)
        {
            DateTime dfechaPro = dtpFechaProceso.Value.Date;
            DataTable dtDatos = new clsRPTCNDeposito().CNFenacrepAnexo13(dfechaPro);
            if (dtDatos.Rows.Count > 0)
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta;
                string cNomArc;
                string cNomArcDes;
                string cFecha;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;
                    string pcMes = dfechaPro.Month.ToString("00");
                    string pcNombMes = dfechaPro.ToString("MMMM");
                    cFecha = pcMes + dfechaPro.Year.ToString();
                    cNomArcDes = cRuta + "\\" + cFecha + "13" + Convert.ToString(clsVarApl.dicVarGen["idInstFin"]) + ".xls";

                    cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\Anexo13.xls";

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                    Excel.Worksheet worksheet = workbook.Sheets[1];

                    string pcCodIns = clsVarApl.dicVarGen["cCodInst"];
                    string pcNomIns = clsVarApl.dicVarGen["cNomEmpresa"];

                    string pcAnio = dfechaPro.Year.ToString();

                    worksheet.Cells[1, 6] = pcNomIns;
                    worksheet.Cells[3, 6] = pcAnio;
                    worksheet.Cells[4, 6] = pcNombMes;

                    var columns = dtDatos.Columns.Count;
                    var rows = dtDatos.Rows.Count;
                    int pnFilaInicio = 6;
                    int pnColInicio = 1;

                    for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                    {
                        worksheet.Cells[rowNumber + pnFilaInicio, 4] = rowNumber;
                        for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                        {
                            worksheet.Cells[rowNumber + pnFilaInicio, columnNumber + pnColInicio] = dtDatos.Rows[rowNumber][columnNumber];
                        }
                    }

                    workbook.SaveAs(cNomArcDes);
                    workbook.Close();
                    Marshal.ReleaseComObject(application);

                    MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "Datos FENACREP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Anexo 13", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = this.dtpFechaProceso.Value.Date;
            DataTable dtAnexo13 = new clsRPTCNDeposito().CNFenacrepAnexo13(dFecProceso);
            if (dtAnexo13.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsFenacrepAnexo13", dtAnexo13));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("x_cAnio", dFecProceso.Year.ToString(), false));
                paramlist.Add(new ReportParameter("x_cMes", dFecProceso.ToString("MMMM"), false));
                paramlist.Add(new ReportParameter("x_dFecProces", dFecProceso.ToString("dd/MM/yyyy"), false));

                string reportpath = "rptFenacrepAnexo13.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Anexo 13", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
