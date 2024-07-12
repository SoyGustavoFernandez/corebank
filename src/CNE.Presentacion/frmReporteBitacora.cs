using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CNE.Presentacion
{
    public partial class frmReporteBitacora : frmBase
    {
        #region Variables

        private DateTime dFechaSis = clsVarGlobal.dFecSystem;
        private clsCNConciliacionPagos API = new clsCNConciliacionPagos();
        private List<object> listCanales;
        private string cUltimoCanalBuscado;
        private DataTable dtActualDTObservaciones;
        private string InitialDirectory = "C:\\";
        private enum StatusCode
        {
            OK = 200,
            BadRequest = 400
        }

        #endregion

        #region Metodos Publicos

        public frmReporteBitacora(int idCanal)
        {
            InitializeComponent();
            CargarComboCanales(idCanal);
            CargarDataPickers();
            this.btnExporExcel.Enabled = false;
        }

        #endregion

        #region Metodos Privados

        private void CargarComboCanales(int idCanal)
        {
            var dtCanales = new clsCNConciliacionPagos().ObtenerConfiguracionCanalesElectronicos();

            List<object> listCanales = new List<object>();

            foreach (DataRow row in dtCanales.Rows)
            {
                var objeto = new
                {
                    idCanal = Convert.ToInt32(row["idCanal"]),
                    cNombreCanal = row["cNombreCanal"].ToString()
                };
                listCanales.Add(objeto);
            }

            this.cboCanal.DataSource = listCanales;
            this.cboCanal.ValueMember = "idCanal";
            this.cboCanal.DisplayMember = "cNombreCanal";
            this.cboCanal.SelectedValue = idCanal;
        }

        private void CargarDataPickers()
        {
            this.dtpFechaInicio.Value = new DateTime(this.dFechaSis.Year, this.dFechaSis.Month,1) ;
            this.dtpFechaFin.Value = this.dFechaSis;
        }
        
        private void ObtenerBitacoraConciliacion()
        {
            DateTime dFechaIni = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            int idCanal = (int)this.cboCanal.SelectedValue;

            var callResult = API.ObtenerBitacoraConciliacion(dFechaIni, dFechaFin, idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtBitacora = callResult.Data;

            if (dtBitacora.Rows.Count <= 0)
            {
                this.dtgConciliacionPagosObservacion.DataSource = null;
                return;
            }

            this.dtgConciliacionPagosObservacion.DataSource = dtBitacora;
            this.dtgConciliacionPagosObservacion.Refresh();

            this.dtActualDTObservaciones = dtBitacora;
            this.cUltimoCanalBuscado = this.cboCanal.Text;
            this.btnExporExcel.Enabled = true;
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
            catch (Exception)
            {
                return -1;
            }
        }

        private void ExportarExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = this.InitialDirectory;
            saveFileDialog.FileName = string.Format("Reporte Observaciones Conciliaciones {0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                this.InitialDirectory = Path.GetDirectoryName(rutaArchivo);

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook oWorkBook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = oWorkBook.Worksheets[1];

                var colorCabecera = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(214, 234, 248));

                //Titulo
                worksheet.Cells[1, 1].Value = "Reporte: BITACORA DE CONCILIACIONES";
                Excel.Range range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
                range.Merge();
                range.Font.Size = 12;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.Font.Bold = true;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                //Canal
                worksheet.Cells[2, 2].Value = "Canal";
                worksheet.Cells[2, 3].Value = this.cUltimoCanalBuscado;

                // Cabeceras
                Excel.Range column = worksheet.Columns[1];
                column.ColumnWidth = 20;
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                column = worksheet.Columns[2];
                column.ColumnWidth = 15;
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                column = worksheet.Columns[3];
                column.ColumnWidth = 60;
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                column = worksheet.Columns[4];
                column.ColumnWidth = 20;
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                column = worksheet.Columns[5];
                column.ColumnWidth = 20;
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Excel.Range cell = worksheet.Cells[3, 1];
                cell.Value = "FECHA CONCILIACIÓN";
                cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                cell = worksheet.Cells[3, 2];
                cell.Value = "ESTADO";
                cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                cell = worksheet.Cells[3, 3];
                cell.Value = "DESCRIPCIÓN";
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                cell = worksheet.Cells[3, 4];
                cell.Value = "USUARIO REGISTRO";
                cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                cell = worksheet.Cells[3, 5];
                cell.Value = "FECHA REGISTRO";
                cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                range = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 5]];
                range.Interior.Color = colorCabecera;

                int fila = 4;
                foreach (DataRow row in this.dtActualDTObservaciones.Rows)
                {
                    worksheet.Cells[fila, 1].Value = row["dFechaConci"].ToString();
                    worksheet.Cells[fila, 2].Value = row["cEstadoBitacora"].ToString();
                    worksheet.Cells[fila, 3].Value = row["cDescripcion"].ToString();
                    worksheet.Cells[fila, 4].Value = row["cUsuarioReg"].ToString();
                    worksheet.Cells[fila, 5].Value = row["dFechaReg"].ToString();
                    fila++;
                }

                oWorkBook.SaveAs(rutaArchivo);
                oWorkBook.Close(false);
                excelApp.Quit();

                liberarObjecto(worksheet);
                liberarObjecto(worksheet);
                liberarObjecto(excelApp);
            }
        }

        #endregion

        #region Eventos

        private void btnExporExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
            this.btnExporExcel.Enabled = false;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            ObtenerBitacoraConciliacion();
        }

        #endregion
    }
}
