using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace RPT.Presentacion
{
    public partial class frmBCRForma05 : frmBase
    {
        #region Eventos
        public frmBCRForma05()
        {
            InitializeComponent();
        }

        private void frmBCRForma05_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dfechaPro = dtpFecha.Value.Date;
            if (clsVarGlobal.dFecSystem < dfechaPro)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida reporte BCR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cRuta;
            string cNomArc;
            string cNomArcDes = null;
            string pcNombMes = dfechaPro.ToString("yyyyMM");
            cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\";
            DataTable dtDatos = new clsRPTCNContabilidad().BCRForma05(dfechaPro);

            if (dtDatos.Rows.Count > 0)
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;

                    cNomArc = cNomArc + "BCRForma05.xlsx";
                    cNomArcDes = cRuta + "\\" + "BCR_Forma05_" + pcNombMes + ".xlsx";

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                    Excel.Worksheet worksheetDG = workbook.Sheets["FO05"];

                    DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;

                    string pcAnio = dfechaPro.Year.ToString();
                    worksheetDG.Cells[7, 3] = clsVarApl.dicVarGen["cNomEmpresa"];
                    worksheetDG.Cells[8, 3] = dtinfo.GetMonthName(dfechaPro.Month);
                    worksheetDG.Cells[8, 5] = pcAnio;

                    int fila = 13;
                    int filaDt = 0;
                    var rows = dtDatos.Rows.Count;

                    for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                    {
                        fila = rowNumber + 13;
                        worksheetDG.Cells[fila, 4] = dtDatos.Rows[filaDt]["nValSol"];
                        worksheetDG.Cells[fila, 5] = dtDatos.Rows[filaDt]["nValDol"];
                        worksheetDG.Cells[fila, 6] = dtDatos.Rows[filaDt]["ntotal"];

                        fila++;
                        filaDt++;
                    }

                    workbook.CheckCompatibility = false;
                    workbook.SaveAs(cNomArcDes);
                    workbook.Close();
                    Marshal.ReleaseComObject(application);
                    MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "BCR Anexo 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
