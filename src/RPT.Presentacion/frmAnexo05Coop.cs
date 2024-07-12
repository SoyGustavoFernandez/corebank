using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;

namespace RPT.Presentacion
{
    public partial class frmAnexo05Coop : frmBase
    {        
        DateTime dFecha;
        public frmAnexo05Coop()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            dFecha = dtpFecha.Value.Date;
            DataTable dtProvision = new clsRPTCNProvision().CNAnexo05(dFecha);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;
            string cNomArcDes;
            string cFecha;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                string pcMes = dFecha.Month.ToString("00");
                string pcNombMes = dFecha.ToString("MMMM");
                cFecha = dFecha.Year.ToString() + pcMes;
                cNomArcDes = cRuta + "\\Anexo05_" + cFecha + ".xlsx";

                cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\Anexo05.xlsx";

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                Excel.Worksheet worksheet = workbook.Sheets[1];

                string pcCodIns = clsVarApl.dicVarGen["cCodInst"];
                string pcNomIns = clsVarApl.dicVarGen["cNomEmpresa"];

                string pcAnio = dFecha.Year.ToString();

                worksheet.Cells[1, 1] = "Institución " + pcNomIns;
                worksheet.Cells[3, 1] = "Año " + pcAnio;
                worksheet.Cells[4, 1] = "Mes " + pcNombMes;

                string RangoCol = String.Format("{0}{1}", GetExcelColumnName(3), 128);

                Excel.Range range = worksheet.Range["A7", RangoCol];

                object[,] data = new object[122,3];

                for (int rowNumber = 0; rowNumber < 122; rowNumber++)
                {
                    data[rowNumber, 0] = pcCodIns;
                    data[rowNumber, 1] = pcMes;
                    data[rowNumber, 2] = pcAnio;
                }
                range.Value = data;

                var query = from row in dtProvision.AsEnumerable()
                            select new
                            {
                                nSalNor = row.Field<decimal>("nSalNor"),
                                nSalCPP = row.Field<decimal>("nSalCPP"),
                                nSalDef = row.Field<decimal>("nSalDef"),
                                nSalDud = row.Field<decimal>("nSalDud"),
                                nSalPer = row.Field<decimal>("nSalPer"),
                                pnGrupo = row.Field<int>("idGrupo"),
                            };

                DataTable dtProv = (from d in query
                                     select d).AsDataTable();

                var columns = dtProv.Columns.Count - 1;
                var rows = dtProv.Rows.Count;
                int pnGrp = Convert.ToInt32(dtProv.Rows[0][5]);
                int pnGrpSgt = 0;
                int pnFilaInicio = 7;
                int pnColInicio = 6;

                for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                {
                    if (pnGrp != pnGrpSgt)
                    {
                        pnGrp = Convert.ToInt32(dtProv.Rows[rowNumber][5]);
                        rowNumber--;
                        if (pnGrp == 1 || pnGrpSgt == 8 || pnGrpSgt == 11)
                        {
                            pnFilaInicio++;
                        }
                        else
                        {
                            pnFilaInicio = pnFilaInicio + 2;
                        }
                    }
                    else
                    {
                        for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                        {
                            worksheet.Cells[rowNumber + pnFilaInicio, columnNumber + pnColInicio] = dtProv.Rows[rowNumber][columnNumber];
                        }
                    }
                    if (rowNumber+1<rows)
                    {
                        pnGrpSgt = Convert.ToInt32(dtProv.Rows[rowNumber + 1][5]);
                    }
                }
                workbook.SaveAs(cNomArcDes);
                workbook.Close();
                Marshal.ReleaseComObject(application);
                
                MessageBox.Show("El archivo se genero Correctamente", "Archivo ANEXO 05", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }

    }
}
static class Extensions
{
    public static DataTable AsDataTable<T>(this IEnumerable<T> enumberable)
    {
        DataTable table = new DataTable("Generated");

        T first = enumberable.FirstOrDefault();
        if (first == null)
            return table;

        PropertyInfo[] properties = first.GetType().GetProperties();
        foreach (PropertyInfo pi in properties)
            table.Columns.Add(pi.Name, pi.PropertyType);

        foreach (T t in enumberable)
        {
            DataRow row = table.NewRow();
            foreach (PropertyInfo pi in properties)
                row[pi.Name] = t.GetType().InvokeMember(pi.Name, BindingFlags.GetProperty, null, t, null);
            table.Rows.Add(row);
        }

        return table;
    }
}