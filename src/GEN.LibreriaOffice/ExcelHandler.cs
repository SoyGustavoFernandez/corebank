using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using form = System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace GEN.LibreriaOffice
{
    public class ExcelHandler
    {
        /// <summary>
        /// Intancia de la Aplicación EXCEL.
        /// </summary>
        private Application app;

        /// <summary>
        /// Libro de EXCEL.
        /// </summary>
        private Workbook book;

        /// <summary>
        /// Ruta del Archivo de EXCEL.
        /// </summary>
        private string path;

        /// <summary>
        /// Constructor Objeto ExcelHandler.
        /// </summary>
        public ExcelHandler()
        {
            this.app = null;
            this.book = null;
            this.path = null;
        }

        /// <summary>
        /// Destructor Objeto ExcelHandler.
        /// </summary>
        ~ExcelHandler()
        {
            if (this.app != null)
            {
                Release(app);
                Release(book);
            }
        }

        /// <summary>
        /// Crea Nuevo Archivo EXCEL.
        /// </summary>
        /// <param name="path">Ruta.</param>
        /// <param name="fileName">Nombre.</param>
        public void New(string path, string fileName)
        {
            try
            {
                this.path = Path.Combine(path, fileName);
                this.app = new Application();
                this.app.Visible = false;
                this.app.ScreenUpdating = false;
                this.app.DisplayAlerts = false;
                book = app.Workbooks.Add(Missing.Value);
                book.SaveAs(this.path, XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Abre Archivo EXCEL.
        /// </summary>
        /// <param name="path">Ruta.</param>
        /// <param name="fileName">Nombre.</param>
        public bool Open(string path, string fileName)
        {
            bool res = true;
            try
            {
                this.path = Path.Combine(path, fileName);
                this.app = new Application();
                this.app.Visible = false;
                this.app.ScreenUpdating = false;
                this.app.DisplayAlerts = false;
                this.book = this.app.Workbooks.Open(this.path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                if (this.book == null)
                    form.MessageBox.Show("No se puede Abrir el Archivo de EXCEL.", "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                res = false;
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
            return res;
        }

        /// <summary>
        /// Escribe en Celda de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <param name="value">Valor.</param>
        public void Write(string sheet, string cell, string value)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);
                range.Value2 = value;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        public void WriteCell(string sheet, int cell_X, int cell_Y, string value)
        {
            try
            {
                this.getSheet(sheet).Cells[cell_X, cell_Y] = value;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Escribe una Formula en una Celda de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <param name="value">Formula.</param>
        public void WriteFormula(string sheet, string cell, string formula)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);
                range.FormulaLocal = formula;
                range.Calculate();
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ocultar Fila o Columna de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <param name="row">Fila.</param>
        /// <param name="column">Columna.</param>
        public void HiddenCell(string sheet, string cell, bool row, bool column)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);

                if (row)
                {
                    range.EntireRow.Hidden = true;
                }

                if (column)
                {
                    range.EntireColumn.Hidden = true;
                }
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lee Valor de Celda de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <returns>Valor.</returns>
        public string Read(string sheet, string cell)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);

                if (range.Value2 != null)
                    return range.Value2.ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// Borra Contenido de Libro EXCEL.
        /// </summary>
        public void ClearAll()
        {
            try
            {
                Worksheet sheet = null;

                for (int i = 1; i <= this.book.Worksheets.Count; i++)
                {
                    sheet = (Worksheet)this.book.Worksheets[i];
                    sheet.Cells.Clear();
                }
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Borra Contenido de Celda en Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        public void Clear(string sheet, string cell)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);

                if (range.Value2 != null)
                    wsheet.Range[cell, cell].Clear();
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combina Celdas en Hoja de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        public void CombineCell(string sheet, string cellI, string cellF)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).Merge(Missing.Value);
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece el Ancho de Columna para un Rango de Celdas.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="width">Ancho de Celda.</param>
        public void SetWidthColumns(string sheet, string cellI, string cellF, double width)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).ColumnWidth = width;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece el Alto de Columna para un Rango de Celdas.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="width">Ancho de Celda.</param>
        public void SetRowHeight(string sheet, string cellI, string cellF, double width)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).RowHeight = width;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece Formato Numerico para un Rango de Celdas.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="width">Ancho de Celda.</param>
        public void SetNumberFormat(string sheet, string cellI, string cellF)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).NumberFormat = "[Blue]0#";
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece Ancho Automatico Columna en Rango de Celdas de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="row">Alto de Fila.</param>
        /// <param name="column">Ancho de Columna.</param>
        public void AutoSizeCell(string sheet, string cellI, string cellF, bool row, bool column)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cellI, cellF);

                if (row)
                {
                    range.EntireRow.AutoFit();
                }

                if (column)
                {
                    range.EntireColumn.AutoFit();
                }
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ajusta Ancho Columna en Rango de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        public void AutoSizeWidthCell(string sheet, string cellI, string cellF)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cellI, cellF);
                range.EntireColumn.AutoFit();
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ajusta Alto Fila en Rango de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        public void AutoSizeHeightCell(string sheet, string cellI, string cellF)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cellI, cellF);
                range.EntireRow.AutoFit();
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ajusta Rango de Celdas de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        public void AutoSizeRangeCell(string sheet, string cellI, string cellF)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cellI, cellF);
                range.Cells.AutoFit();
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Orientacion del Texto en Celda
        /// </summary>
        /// <param name="sheet">Hoja</param>
        /// <param name="cell">Celda</param>
        /// <param name="ang">Angulo</param>
        public void Orientation(string sheet, string cell, double ang)
        {
            try
            {
                this.getSheet(sheet).get_Range(cell, cell).Orientation = ang;
                //Worksheet wsheet = this.getSheet(sheet);
                //Range range = wsheet.get_Range(cell, cell);
                //range.Orientation = ang;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece la Alineación Horizontal de una Celda.
        /// </summary>
        /// <param name="sheet">Hoja</param>
        /// <param name="cell">Celda</param>
        /// <param name="Alignment">Tipo de Alineación (C:Center / L:Left / R:Right / J;Justify)</param>
        public void HorizontalAlignment(string sheet, string cell, char Alignment)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);
                if (Alignment == 'C')
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                else if (Alignment == 'L')
                    range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                else if (Alignment == 'R')
                    range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                else if (Alignment == 'J')
                    range.HorizontalAlignment = XlHAlign.xlHAlignJustify;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece la Alineación Vertical de una Celda.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="cell"></param>
        /// <param name="Alignment"></param>
        public void VerticalAlignment(string sheet, string cell, char Alignment)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);
                if (Alignment == 'C')
                    range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                else if (Alignment == 'B')
                    range.VerticalAlignment = XlVAlign.xlVAlignBottom;
                else if (Alignment == 'T')
                    range.VerticalAlignment = XlVAlign.xlVAlignTop;
                else if (Alignment == 'J')
                    range.VerticalAlignment = XlVAlign.xlVAlignJustify;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece la Alineación Horizontal de una Celda.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="alignment">Alineación (C:Center / L:Left / R:Right / J:Justify).</param>
        /// <param name="horizontal">Alineación Horizontal.</param>
        /// <param name="vertical">Alineación Vertical.</param>
        public void AlignmentCell(string sheet, string cellI, string cellF, char alignment, bool horizontal, bool vertical)
        {
            try
            {
                XlHAlign? _alignment = null;

                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cellI, cellF);

                switch (alignment)
                {
                    case 'C':
                        _alignment = XlHAlign.xlHAlignCenter;
                        break;
                    case 'L':
                        _alignment = XlHAlign.xlHAlignLeft;
                        break;
                    case 'R':
                        _alignment = XlHAlign.xlHAlignRight;
                        break;
                    case 'J':
                        _alignment = XlHAlign.xlHAlignJustify;
                        break;
                    default:
                        break;
                }

                if (horizontal)
                {
                    range.HorizontalAlignment = _alignment;
                }

                if (vertical)
                {
                    range.VerticalAlignment = _alignment;
                }
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Formatea Celda.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="Bold">Estado de BOLD.</param>
        /// <param name="Italic">Estado de ITALICA.</param>
        /// <param name="Size">Tamaño de Fuente.</param>
        public void FormatCell(string sheet, string cellI, string cellF, bool Bold = false, bool Italic = false, int Size = 11)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).Font.Bold = Bold;
                wsheet.get_Range(cellI, cellF).Font.Italic = Italic;
                wsheet.get_Range(cellI, cellF).Font.Size = Size;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece el Color de un Rango de Celdas.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellI">Celda Inicial.</param>
        /// <param name="cellF">Celda Final.</param>
        /// <param name="Colour">Indice de Color a Asignar.</param>
        public void FormatColourCell(string sheet, string cellI, string cellF, int ColourBorder, int ColourInterior)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).Borders.ColorIndex = ColourBorder;
                wsheet.get_Range(cellI, cellF).Interior.ColorIndex = ColourInterior;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        public void FormatBorderCell(string sheet, string cellI, string cellF, int ColourBorder)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                wsheet.get_Range(cellI, cellF).Borders.ColorIndex = ColourBorder;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cierra un Archivo de EXCEL.
        /// </summary>
        public void Close()
        {
            try
            {
                if (this.book != null)
                    this.book.Close(true, Missing.Value, Missing.Value);
                this.app.Quit();
                Release(app);
                if (this.book != null)
                    Release(book);
                this.path = null;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cierra y Guarda Archivo (New/Open) de EXCEL.
        /// </summary>
        public void CloseAndSave()
        {
            try
            {
                this.book.SaveAs(this.path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                this.book.Close(true, Missing.Value, Missing.Value);
                this.app.Quit();
                Release(app);
                Release(book);
                this.path = null;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda un Archivo de EXCEL.
        /// </summary>
        public void SaveAs(string path, string fileName)
        {
            try
            {
                this.book.SaveAs(Path.Combine(path, fileName), Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lista nombres de Hojas en Libro EXCEL.
        /// </summary>
        /// <returns>Lista Nombres de Hojas.</returns>
        public string[] GetSheetsNames()
        {
            List<string> names = new List<string>();
            Worksheet sheet = null;

            for (int i = 1; i <= this.book.Worksheets.Count; i++)
            {
                sheet = (Worksheet)this.book.Worksheets[i];
                names.Add(sheet.Name);
            }

            return names.ToArray();
        }

        /// <summary>
        /// Bloquea/Desbloquea todas las Celdas de una Hoja.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="locked">Estado de Bloqueo (True/False).</param>
        public void LockedAllCell(string sheet, bool locked)
        {
            try
            {
                this.getSheet(sheet).Cells.Locked = locked;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Bloquea/Desbloquea un Rango Celdas.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cellInicial">Celda Inicial.</param>
        /// <param name="cellFinal">Celda Final.</param>
        /// <param name="locked">Estado de Bloqueo (True/False).</param>
        public void LockedRangeCell(string sheet, string cellInicial, string cellFinal, bool locked)
        {
            try
            {
                this.getSheet(sheet).get_Range(cellInicial, cellFinal).Locked = locked;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Selecciona Hoja X Nombre.
        /// </summary>
        /// <param name="name">Nombre.</param>
        /// <returns>Hoja de EXCEL.</returns>
        protected Worksheet getSheet(string name)
        {
            int index = this.getSheetIndex(name);

            if (index == 0)
                form.MessageBox.Show("Nombre de Hoja Invalido.", "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);

            Worksheet sheet = (Worksheet)this.book.Worksheets[index];

            return sheet;
        }

        /// <summary>
        /// Selecciona Indice de Hoja X Nombre.
        /// </summary>
        /// <param name="name">Nombre.</param>
        /// <returns>Indice.</returns>
        protected int getSheetIndex(string name)
        {
            Worksheet sheet = null;

            for (int i = 1; i <= this.book.Worksheets.Count; i++)
            {
                sheet = (Worksheet)this.book.Worksheets[i];

                if (sheet.Name == name)
                    return i;
            }
            return 0;
        }

        /// <summary>
        /// Quita de la Memoria Objeto.
        /// </summary>
        /// <param name="obj">Objeto.</param>
        protected void Release(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
            finally
            {
                int id = GetIDProcces("EXCEL");

                GC.Collect();
                obj = null;

                if (id != -1)
                {
                    try
                    {
                        Process.GetProcessById(id).Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene ID por Nombre de Proceso
        /// </summary>
        /// <param name="nameProcces">Nombre de Proceso</param>
        /// <returns></returns>
        private int GetIDProcces(string nameProcces)
        {
            try
            {
                Process[] asProccess = Process.GetProcessesByName(nameProcces);

                foreach (Process pProccess in asProccess)
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
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="password"></param>
        public void ProtectSheet(string sheet, object password)
        {
            try
            {
                this.getSheet(sheet).Protect(password, Missing.Value, Missing.Value, Missing.Value, Missing.Value, false, false, false, false, false, Missing.Value, false, false, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Asigna Validacion de Rango en Celda de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <param name="min">Valor Minimo.</param>
        /// <param name="max">Valor Maximo.</param>
        public void ValidationBetweenCell(string sheet, string cell, int min, int max)
        {
            try
            {
                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);

                range.Validation.Add(XlDVType.xlValidateDecimal, Missing.Value, XlFormatConditionOperator.xlBetween, min, max);
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tipo Formato en Celda de Libro EXCEL.
        /// </summary>
        /// <param name="sheet">Hoja.</param>
        /// <param name="cell">Celda.</param>
        /// <param name="formato">Formato.</param>
        public void NumberFormatCell(string sheet, string cell, string formato)
        {
            try
            {
                string _numFormat = string.Empty;

                Worksheet wsheet = this.getSheet(sheet);
                Range range = wsheet.get_Range(cell, cell);

                switch (formato)
                {
                    case "Accounting":
                        _numFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                        break;
                    case "Currency":
                        _numFormat = "$#,##0.00_);($#,##0.00)";
                        break;
                    case "Date":
                        _numFormat = "m/d/yyyy";
                        break;
                    case "General":
                        _numFormat = "General";
                        break;
                    case "Text":
                        _numFormat = "@";
                        break;
                    case "Number":
                        _numFormat = "0#";
                        //_numFormat = "#,##0.00";
                        break;
                    default:
                        _numFormat = string.Empty;
                        break;
                }

                range.NumberFormat = _numFormat;
            }
            catch (Exception ex)
            {
                form.MessageBox.Show(ex.Message.ToString(), "ERROR", form.MessageBoxButtons.OK, form.MessageBoxIcon.Error);
            }
        }

        //
        public System.Data.DataTable ImportExcelToDataTable(String path, String cHoja = "Hoja1")
        {
            // creating Excel Application
            //_Application app = new Application();

            ////// creating new WorkBook within Excel application
            //_Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            //_Worksheet workSheet = (_Worksheet)workBook.ActiveSheet;
            //int index = 0;
            //object rowIndex = 2;
            System.Data.DataTable dt = new System.Data.DataTable();

            string strconn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + path + ";Extended Properties= 'Excel 8.0;HDR=Yes'";             
            //string strconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
            System.Data.OleDb.OleDbConnection mconn = new System.Data.OleDb.OleDbConnection(strconn);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("Select * from [" + cHoja + "$]", mconn);
            mconn.Open();
            ad.Fill(dt);
            mconn.Close();
            

            //dt.Columns.Add("Column1"); //your column name
            //dt.Columns.Add("Column2");
            //dt.Columns.Add("Column4");

            //System.Data.DataRow row;
            //while (((Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
            //{
            //    row = dt.NewRow();
            //    row[0] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 1]).Value2);
            //    row[1] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 2]).Value2);
            //    row[2] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 3]).Value2);
            //    index++;
            //    rowIndex = 2 + index;
            //    dt.Rows.Add(row);
            //}
            //app.Quit();
            //GC.Collect();
            //app.Workbooks.Close();

            return dt;
         
        }

        public ClsResponse ValidaCamposObligatorios(string[] cColumnas, System.Data.DataTable dt)
        {
            int nRespuesta = 1;
            string cRespuesta ="";
            foreach (string cColumna in cColumnas)
            {
                if (!dt.Columns.Contains(cColumna))
                {
                    nRespuesta = 0;
                    cRespuesta += "\t" + cColumna + "\n";
                }
            }
            return new ClsResponse(nRespuesta, cRespuesta);
        }
    }
}
