using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace RPT.Presentacion
{
    public partial class frmRptDeudoresAnexo6A : frmBase
    {
        DateTime dfechaPro;
    public frmRptDeudoresAnexo6A()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string codEmpresa = Convert.ToString(clsVarApl.dicVarGen["idInstFin"]);
            dfechaPro = dtpFecha.Value.Date;
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dfechaPro.ToString(), false));
            paramlist.Add(new ReportParameter("cNomEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("idInstFin", codEmpresa, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsDeudores", new clsRPTCNSocio().CNDeudorAnexo6(dfechaPro)));

            string reportpath = "rptDeudorAnex6A.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            dfechaPro = dtpFecha.Value.Date;
            DataTable dtDatos = new clsRPTCNSocio().CNDeudorAnexo6(dfechaPro);
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
                cNomArcDes = cRuta + "\\" + cFecha + "12" + Convert.ToString(clsVarApl.dicVarGen["idInstFin"]) + ".xls";

                cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\Anexo06.xls";

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                Excel.Worksheet worksheet = workbook.Sheets[1];

                string pcCodIns = clsVarApl.dicVarGen["cCodInst"];
                string pcNomIns = clsVarApl.dicVarGen["cNomEmpresa"];

                string pcAnio = dfechaPro.Year.ToString();

                worksheet.Cells[1, 4] = pcNomIns;
                worksheet.Cells[3, 4] = pcAnio;
                worksheet.Cells[4, 4] = pcNombMes;

                var columns = dtDatos.Columns.Count;
                var rows = dtDatos.Rows.Count;
                int pnFilaInicio = 6;
                int pnColInicio = 5;

                for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                {
                    worksheet.Cells[rowNumber + pnFilaInicio, 4] = rowNumber;
                    for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                    {
                        if (columnNumber == 0)
                        {
                            worksheet.Cells[rowNumber + pnFilaInicio, 1] = pcCodIns;
                            worksheet.Cells[rowNumber + pnFilaInicio, 2] = pcMes;
                            worksheet.Cells[rowNumber + pnFilaInicio, 3] = pcAnio;
                        }
                        worksheet.Cells[rowNumber + pnFilaInicio, columnNumber + pnColInicio] = dtDatos.Rows[rowNumber][columnNumber];
                    }
                }

                workbook.SaveAs(cNomArcDes);
                workbook.Close();
                Marshal.ReleaseComObject(application);

                MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "Datos FENACREP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
