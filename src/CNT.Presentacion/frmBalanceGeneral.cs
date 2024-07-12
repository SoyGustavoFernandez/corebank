using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace CNT.Presentacion
{
    public partial class frmBalanceGeneral : frmBase
    {
        public frmBalanceGeneral()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;
            cboMoneda.CargaDatosContaIntegrado();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFecha = dtpFechaSistema.Value.Date;

            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida estado de situción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 

            int idMoneda = (int)cboMoneda.SelectedValue;
            int idAgencia = (int)cboAgencia.SelectedValue;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsBalanceGeneral", new clsRPTCNContabilidad().CNBalanceGeneral(dFecha, idMoneda, idAgencia)));

            string reportpath = "RptBalanceGeneral.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dfechaPro = dtpFechaSistema.Value.Date;
            DataTable dtDatos = new clsRPTCNContabilidad().CNBGFenacrep(dfechaPro);
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
                    cNomArcDes = cRuta + "\\" + cFecha + "01" + Convert.ToString(clsVarApl.dicVarGen["idInstFin"]) + ".xls";

                    cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\FormaA.xls";

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
        }
    }
}
