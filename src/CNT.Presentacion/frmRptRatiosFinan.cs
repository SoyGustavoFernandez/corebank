using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using System.Data;
using CNT.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;
using GEN.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmRptRatiosFinan : frmBase
    {
        public frmRptRatiosFinan()
        {
            InitializeComponent();
        }
    private void frmRptRatiosFinan_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida Ratios e Indicadores Financieros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            string cAgencia = cboAgencia.Text;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            Boolean lDistribuido = chcDistri.Checked;
            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFechaSis", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
  

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            Cursor.Current = Cursors.WaitCursor;

            dtslist.Add(new ReportDataSource("dsRatioFinanciero", new clsRPTCNContabilidad().CNRptRatioFinanciero(idAgencia, dFecha, lDistribuido)));

            Cursor.Current = Cursors.Default;

            string reportpath = "rptRatioFinancieroCtb.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Seleccione el archivo de Excel";
            dialog.FileName = string.Empty;
            string cArchivo;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cArchivo = dialog.FileName;
                DataTable dtTmp = LLenarDataTable(cArchivo);
                CargaSQL(dtTmp);
            }
        }
        private void CargaSQL(DataTable dtExcel)
        {
            DateTime dFecha = dtpFechaSistema.Value;
            DataSet dsDetalle = new DataSet(); // creamos la instancia del objeto DataSet
            dsDetalle.Tables.Add(dtExcel);
            string XmlDetalle = "";
            XmlDetalle = dsDetalle.GetXml();
            XmlDetalle = clsCNFormatoXML.EncodingXML(XmlDetalle);
            DataTable dtResultado = new clsCNBalance().CNInsEPGManual(dFecha, XmlDetalle);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show("Datos almacenados correctamente", "Historico tipos de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataTable LLenarDataTable(string archivo)
        {
            Cursor = Cursors.WaitCursor;
            DataTable tmpdtImpDatInd = new DataTable();
            tmpdtImpDatInd.Columns.Add("idEpg", typeof(int));
            tmpdtImpDatInd.Columns.Add("cDesEpg", typeof(string));

            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook oWorkBook = oExcel.Workbooks.Open(archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            string cColumna, cDescripcion;
            decimal nValColumna;
            int idEpg;
            bool lIndValCol = true;

            int i = 3, j=3;
            for (int Fil = 3; Fil < 41; Fil++)
            {
                idEpg = Convert.ToInt16((oWorkSheet.Cells[i, 1] as Excel.Range).Value);
                cDescripcion = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value);
                tmpdtImpDatInd.Rows.Add(idEpg, cDescripcion);
                i = i + 1;
            }

            j = 3;
            while (lIndValCol)
            {
                cColumna = Convert.ToString((oWorkSheet.Cells[1,j] as Excel.Range).Value);
                if (string.IsNullOrEmpty(cColumna))
                {
                    lIndValCol = false;
                }
                else
                {
                    tmpdtImpDatInd.Columns.Add(cColumna, typeof(decimal));
                    for (int Fil = 3; Fil < 41; Fil++)
                    {
                        nValColumna = Convert.ToDecimal((oWorkSheet.Cells[Fil,j] as Excel.Range).Value);
                        tmpdtImpDatInd.Rows[Fil - 3][j - 1] = nValColumna;
                    }
                }
                j = j + 1;
            }
            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);

            DataTable tmpUnPivotEpg = new DataTable();
            tmpUnPivotEpg.Columns.Add("idAgencia", typeof(int));
            tmpUnPivotEpg.Columns.Add("idEpg", typeof(int));
            tmpUnPivotEpg.Columns.Add("nValor", typeof(decimal));

            for (int Col = 2; Col < tmpdtImpDatInd.Columns.Count-1; Col++)
            {
                int idAge = Convert.ToInt16(tmpdtImpDatInd.Columns[Col].ColumnName);
                for (int Fila = 0; Fila < tmpdtImpDatInd.Rows.Count; Fila++)
                {
                    int nIdEPG = Convert.ToInt16(tmpdtImpDatInd.Rows[Fila][0]);
                    decimal nValor = Convert.ToDecimal(tmpdtImpDatInd.Rows[Fila][Col]);

                    tmpUnPivotEpg.Rows.Add(idAge, nIdEPG, nValor);
                }
            }
            Cursor = Cursors.Default;
            return tmpUnPivotEpg;
        }
        private void liberarObjecto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
                int id = GetIDProcces("EXCEL");
                if (id != -1)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(id).Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private int GetIDProcces(string nameProcces)
        {
            try
            {
                System.Diagnostics.Process[] asProccess = System.Diagnostics.Process.GetProcessesByName(nameProcces);

                foreach (System.Diagnostics.Process pProccess in asProccess)
                {
                    if (pProccess.MainWindowTitle == "")
                    {
                        return pProccess.Id;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaSistema.Value;
            if (Valida(dFecha))
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            
            DataTable dtProcesa = new clsCNBalance().CNGeneraEPG(dFecha);

            Cursor = Cursors.Default;

            if (Convert.ToInt16(dtProcesa.Rows[0][0])==0)
            {
                MessageBox.Show("Error proceso de Estado Perdidas y Ganancias por Oficinas", "Ratios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Estado Perdidas y Ganancias por Oficinas generado correctamente", "Ratios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private Boolean Valida(DateTime dFecha)
        {
            if (dFecha > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Fecha de proceso no puede ser mayor a la fecha del sistema", "Ratios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return false;
        }

        private void btnEpgOfi_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaSistema.Value.Date;
            if (clsVarGlobal.dFecSystem <= dFecha)
            {
                MessageBox.Show("La fecha debe ser menor", "Valida Ratios e Indicadores Financieros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            Boolean lDistribuido = chcDistri.Checked;

            DataTable dtEPGOfi = new clsRPTCNContabilidad().CNEPGAgencias(dFecha, idAgencia, lDistribuido);
            if (dtEPGOfi.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Ratios e Indicadores Financieros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsPerdidasGanancias", dtEPGOfi));

            string reportpath = "RptEPGOfi.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void chcDistri_CheckedChanged(object sender, EventArgs e)
        {
            if (chcDistri.Checked)
            {
                chcOriginal.Checked = false;
            }
            else
            {
                chcOriginal.Checked = true;
            }
        }

        private void chcOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (chcOriginal.Checked)
            {
                chcDistri.Checked = false;
            }
            else
            {
                chcDistri.Checked = true;
            }
        }
        
    }
}
