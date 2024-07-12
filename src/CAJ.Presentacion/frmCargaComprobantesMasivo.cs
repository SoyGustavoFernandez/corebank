using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace CAJ.Presentacion
{
    public partial class frmCargaComprobantesMasivo : frmBase
    {
        #region Variables

        clsCNCargaMasivaComprobantes objCNCargaMasiva = new clsCNCargaMasivaComprobantes();

        private DataSet dsDatosConf = new DataSet();
        private DataTable dtCabeceras = new DataTable();
        private DataTable dtComprobantesCargados = new DataTable();
        private DataTable dtIgv = new DataTable();

        private string InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private Thread excelThread;

        private enum eTipoPlantilla 
        {
            Resumido = 1,
            Completo = 2 
        }

        #endregion

        #region Métodos Publicos

        public frmCargaComprobantesMasivo()
        {
            InitializeComponent();
            this.btnExporExcel.cText = "&Plantilla";
        }

        #endregion

        #region Métodos Privados

        private void ObtenerDatos()
        {
            this.dsDatosConf = this.objCNCargaMasiva.CNObtieneConfiguracionPlantilla((int)eTipoPlantilla.Completo);
            this.dtCabeceras = this.dsDatosConf.Tables[0];
            this.dtIgv = new clsCNIGV().obtenerListaIGV();
        }

        private void GenerarPlantilla()
        {
            int progress = 5;
            UpdateProgress(progress);

            Excel.Application excelApp = new Excel.Application();
            excelApp.ScreenUpdating = false;
            excelApp.DisplayAlerts = false;

            Excel.Workbook oWorkBook = excelApp.Workbooks.Add();

            Excel.Worksheet oWorkSheetCatalogos = (Excel.Worksheet)oWorkBook.Sheets[1];
            oWorkSheetCatalogos.Name = "Catalogos";

            Excel.Worksheet oWorkSheetFormato = (Excel.Worksheet)oWorkBook.Sheets.Add();
            oWorkSheetFormato.Name = "Formato";

            progress += 10;
            UpdateProgress(progress);

            foreach (DataRow dr in dtCabeceras.Rows)
            {
                bool lObligatorio = dr.Field<bool>("lRequerido");
                string cRequerido = lObligatorio ? "(*)" : "";
                bool lDetalle = dr.Field<bool>("lDetalle");
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")] = dr["cCabecera"].ToString() + cRequerido;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].Interior.Color = lDetalle ? ColorTranslator.ToOle(Color.LightYellow) : ColorTranslator.ToOle(Color.SkyBlue);
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].Font.Bold = true;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].ColumnWidth = 20;
            }

            DataTable dtCatalogos = dtCabeceras.Select("cTipoDato = 'collection'").CopyToDataTable();
            int nCantidadCatalogos = dtCatalogos.Rows.Count;

            for (int i = 1; i <= dtCatalogos.Rows.Count; i++)
            {
                dsDatosConf.Tables[i].TableName = dtCatalogos.Rows[i - 1]["cCabecera"].ToString();
            }

            progress += 10;
            UpdateProgress(progress);

            int step = 1;
            step = 75 / nCantidadCatalogos;

            for (int i = 1; i < nCantidadCatalogos * 3; i += 3)
            {
                string cNombreCatalogo = dtCatalogos.Rows[(i - 1) / 3]["cCabecera"].ToString();

                oWorkSheetCatalogos.Cells[1, i] = cNombreCatalogo;
                oWorkSheetCatalogos.Range[oWorkSheetCatalogos.Cells[1, i], oWorkSheetCatalogos.Cells[1, i + 1]].Merge();
                oWorkSheetCatalogos.Cells[1, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetCatalogos.Cells[1, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[1, i].Interior.Color = ColorTranslator.ToOle(Color.SkyBlue);
                oWorkSheetCatalogos.Cells[1, i].Font.Bold = true;

                oWorkSheetCatalogos.Cells[2, i] = "Código";
                oWorkSheetCatalogos.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetCatalogos.Cells[2, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[2, i].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                oWorkSheetCatalogos.Cells[2, i].Font.Bold = true;

                oWorkSheetCatalogos.Cells[2, i + 1] = "Descripción";
                oWorkSheetCatalogos.Cells[2, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oWorkSheetCatalogos.Cells[2, i + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[2, i + 1].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                oWorkSheetCatalogos.Cells[2, i + 1].Font.Bold = true;

                foreach (DataRow dr in dsDatosConf.Tables[cNombreCatalogo].Rows)
                {
                    int index = dsDatosConf.Tables[cNombreCatalogo].Rows.IndexOf(dr);

                    oWorkSheetCatalogos.Cells[3 + index, i] = dr["idCodigo"].ToString();
                    oWorkSheetCatalogos.Cells[3 + index, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    oWorkSheetCatalogos.Cells[3 + index, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    oWorkSheetCatalogos.Cells[3 + index, i + 1] = dr["cDescripcion"].ToString();
                    oWorkSheetCatalogos.Cells[3 + index, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    oWorkSheetCatalogos.Cells[3 + index, i + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    oWorkSheetCatalogos.Cells[3 + index, i + 2] = " ";
                }

                progress += (step > 100) ? 100 : step;
                UpdateProgress(progress);
            }

            for (int i = 1; i <= nCantidadCatalogos * 3; i += 3)
            {
                oWorkSheetCatalogos.Cells[1, i].ColumnWidth = 8;
                oWorkSheetCatalogos.Cells[1, i + 1].ColumnWidth = 30;
                oWorkSheetCatalogos.Cells[1, i + 2].ColumnWidth = 3;
            }

            UpdateProgress(100);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = InitialDirectory;
            saveFileDialog.FileName = string.Format("Plantilla de Carga Masiva para varios Comprobantes - {0}.xlsx", DateTime.Now.ToString("ddMMyyyy"));
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                InitialDirectory = Path.GetDirectoryName(rutaArchivo);
                oWorkBook.SaveAs(rutaArchivo);
            }

            oWorkBook.Close();
            excelApp.Quit();
            UpdateProgress(0);

            // Libera recursos COM
            ReleaseComObject(oWorkSheetFormato);
            ReleaseComObject(oWorkSheetCatalogos);
            ReleaseComObject(oWorkBook);
            ReleaseComObject(excelApp);

            HabilitarBotones(true);

            if (this.InvokeRequired)
                Invoke(new Action(() => this.progressBar.Visible = false));
        }

        private void ImportarDatos(string rutaArchivo)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(rutaArchivo);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            Excel.Range usedRange = worksheet.UsedRange;
            object[,] valores = (object[,])usedRange.Value2;

            DataTable dt = new DataTable();

            for (int col = 1; col <= valores.GetLength(1); col++)
            {
                dt.Columns.Add(valores[1, col] == null ? string.Empty : valores[1, col].ToString());
            }

            for (int row = 2; row <= valores.GetLength(0); row++)
            {
                DataRow dataRow = dt.NewRow();
                for (int col = 1; col <= valores.GetLength(1); col++)
                {
                    dataRow[col - 1] = valores[row, col];
                }
                dt.Rows.Add(dataRow);
            }

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                bool isRowEmpty = true;

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null && !string.IsNullOrWhiteSpace(dt.Rows[i][j].ToString()))
                    {
                        isRowEmpty = false;
                        break;
                    }
                }

                if (isRowEmpty)
                {
                    dt.Rows[i].Delete();
                }
            }

            workbook.Close(false);
            excelApp.Quit();

            ReleaseComObject(worksheet);
            ReleaseComObject(workbook);
            ReleaseComObject(excelApp);

            ValidaDatos(dt);
        }

        private void ValidaDatos(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataColumn dc in dtDatosCargados.Columns)
            {
                if (dc.ColumnName.Contains("(*)"))
                    dc.ColumnName = dc.ColumnName.Replace("(*)", "");
            }

            if(!ValidaCabecerasExcel(dtDatosCargados))
                return;

            DataTable dtCatalogos = dtCabeceras.Select("cTipoDato = 'collection'").CopyToDataTable();

            for (int i = 1; i <= dtCatalogos.Rows.Count; i++)
            {
                this.dsDatosConf.Tables[i].TableName = dtCatalogos.Rows[i - 1]["cCabecera"].ToString();
            }

            if(!ValidaCatalogosExcel(dtDatosCargados))
                return;

            if(!ValidaCamposObligatoriosExcel(dtDatosCargados))
                return;

            if(!ValidaFlujoEspecialExcel(dtDatosCargados))
                return;
            
            if(!ValidaFormatosExcel(dtDatosCargados))
                return;

            GeneraDetalleComprobante(dtDatosCargados);
            GeneraDataGrid();
            HabilitarBotones(true);
        }

        private bool ValidaCabecerasExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drCabecera in this.dtCabeceras.Rows)
            {
                var cNombreCabecera = drCabecera.Field<string>("cCabecera");
                if (!dtDatosCargados.Columns.Contains(cNombreCabecera))
                    lstErrores.Add($"No se encontró la columna {cNombreCabecera} en el archivo.");
            }

            foreach (DataColumn dc in dtDatosCargados.Columns)
            {
                if (!this.dtCabeceras.Rows.Cast<DataRow>().Any(c => c.Field<string>("cCabecera") == dc.ColumnName))
                    lstErrores.Add($"No se encontró la configuración de la columna {dc.ColumnName} en la base de datos.");
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores en las cabeceras, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Cabeceras");
                return false;
            }

            return true;
        }

        private bool ValidaCatalogosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drCabecera in this.dtCabeceras.Rows)
            {
                string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                string cTipoDato = drCabecera.Field<string>("cTipoDato");

                if (cTipoDato == "collection" && !this.dsDatosConf.Tables.Contains(cNombreCabecera))
                    lstErrores.Add($"No se encontró el catalogo de valores para la columna {cNombreCabecera} en la base de datos.");
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores de catálogos, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Catálogos");
                return false;
            }

            return true;
        }

        private bool ValidaCamposObligatoriosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drDatos in dtDatosCargados.Rows)
            {
                foreach (DataRow drCabecera in this.dtCabeceras.Rows)
                {
                    string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                    bool lRequerido = drCabecera.Field<bool>("lRequerido");
                    string cValor = drDatos.Field<string>(cNombreCabecera);

                    if (string.IsNullOrEmpty(cValor))
                    {
                        if (lRequerido)
                            lstErrores.Add($"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} es requerido.");
                        continue;
                    }
                }
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " campos obligatorios vacíos, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Campos Obligatorios");
                return false;
            }

            return true;
        }

        private bool ValidaFlujoEspecialExcel(DataTable dtDatosCargados)
        {
            if (!Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["lValidEspecCargaMasivaCompr"])))
                return true;

            var lstErrores = new List<string>();

            DataTable dtConfigTipCompr = objCNCargaMasiva.CNValidacionesEspecialesCargaMasiva();

            foreach (DataRow row in dtDatosCargados.Rows)
            {
                string cTipoOperacion = row["Tipo Operación"] == null ? string.Empty : row["Tipo Operación"].ToString().ToUpper();
                string cBienServicio = row["Bien/Servicio"] == null ? string.Empty : row["Bien/Servicio"].ToString().ToUpper();
                string dFechaDetraccion = row["Fecha de Detracción"] == null ? string.Empty : row["Fecha de Detracción"].ToString();
                string cAplicaDetraccion = row["Aplica Detracción"] == null ? "NO" : row["Aplica Detracción"].ToString().ToUpper();

                //Valida Detracción
                if (cAplicaDetraccion == "SI")
                {
                    if (string.IsNullOrEmpty(cTipoOperacion))
                        lstErrores.Add($"Cuando aplica detracción, el campo Tipo Operación en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerido.");
                    if (string.IsNullOrEmpty(cBienServicio))
                        lstErrores.Add($"Cuando aplica detracción, el campo Bien/Servicio en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerido.");
                    if (string.IsNullOrEmpty(dFechaDetraccion))
                        lstErrores.Add($"Cuando aplica detracción, el campo Fecha de Detracción en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerido.");
                }
                else if (cAplicaDetraccion == "NO")
                {
                    if (!string.IsNullOrEmpty(cTipoOperacion))
                        lstErrores.Add($"Cuando no aplica detracción, el campo Tipo Operación en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                    if (!string.IsNullOrEmpty(cBienServicio))
                        lstErrores.Add($"Cuando no aplica detracción, el campo Bien/Servicio en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                    if (!string.IsNullOrEmpty(dFechaDetraccion))
                        lstErrores.Add($"Cuando no aplica detracción, el campo Fecha de Detracción en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                }

                //Validaciones de IGV
                string cTipoComprobante = row["Tipo Comprobante"] == null ? string.Empty : row["Tipo Comprobante"].ToString().ToUpper();
                string cDestino = row["Destino"] == null ? string.Empty : row["Destino"].ToString().ToUpper();
                string cIGV = row["IGV"] == null ? string.Empty : row["IGV"].ToString();
                decimal nIgv = decimal.Zero;

                if (cDestino == "NO GRAVADO SIN IGV")
                {
                    if (!string.IsNullOrEmpty(cIGV))
                        lstErrores.Add($"Cuando el destino es NO GRAVADO SIN IGV, el campo IGV en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                }
                else if (cDestino == "NO GRAVADO CON IGV")
                {
                    if (string.IsNullOrEmpty(cIGV))
                    {
                        lstErrores.Add($"Cuando el destino es NO GRAVADO CON IGV, el campo IGV en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerido.");
                    }
                    else
                    {
                        decimal.TryParse(cIGV, out nIgv);

                        if (!dtConfigTipCompr.AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cTipoComprobante && c.Field<decimal>("nValIgv") == nIgv))
                            lstErrores.Add($"El valor de IGV en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no es válido para el tipo de comprobante {cTipoComprobante}.");
                    }
                }

                //Validacion de comprobantes de referencia
                string cDocRef = row["Documento de Ref"] == null ? string.Empty : row["Documento de Ref"].ToString();

                if (dtConfigTipCompr.AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cTipoComprobante && c.Field<bool>("lPermiteDocRef")))
                {
                    if (string.IsNullOrEmpty(cDocRef))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, el comprobante de referencia en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerido.");
                }
                else
                {
                    if (!string.IsNullOrEmpty(cDocRef))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, el comprobante de referencia en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                }

                //Validacion de fecha de vencimiento
                string cFechaVencimiento = row["Fecha Vencimiento"] == null ? string.Empty : row["Fecha Vencimiento"].ToString();

                if (dtConfigTipCompr.AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cTipoComprobante && c.Field<int>("nnumero") == 14))
                {
                    if (string.IsNullOrEmpty(cFechaVencimiento))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, la fecha de vencimiento en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} es requerida.");
                }
                else
                {
                    if (!string.IsNullOrEmpty(cFechaVencimiento))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, la fecha de vencimiento en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                }

                //Validaciones de 4ta categoría y ley de impuesto a la renta
                string cAfecto4taCat = row["Afecto 4ta Categoría"] == null ? string.Empty : row["Afecto 4ta Categoría"].ToString();
                string cAfectoImpRenta = row["Afecto Impuesto a la Renta"] == null ? string.Empty : row["Afecto Impuesto a la Renta"].ToString();

                if (dtConfigTipCompr.AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cTipoComprobante && c.Field<decimal>("nValCuartaCateg") <= 0))
                {
                    if (!string.IsNullOrEmpty(cAfecto4taCat))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, el campo Afecto a 4ta Categoría en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                    if (!string.IsNullOrEmpty(cAfectoImpRenta))
                        lstErrores.Add($"Cuando el tipo de comprobante es {cTipoComprobante}, el campo Afecto Impuesto a la Renta en la fila {dtDatosCargados.Rows.IndexOf(row) + 2} no debe tener valor.");
                }
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores de flujo especial, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Flujo Especial");
                return false;
            }

            return true;
        }

        private bool ValidaFormatosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drDatos in dtDatosCargados.Rows)
            {
                foreach (DataRow drCabecera in this.dtCabeceras.Rows)
                {
                    string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                    string cTipoDato = drCabecera.Field<string>("cTipoDato");
                    string cFormato = drCabecera.Field<string>("cFormato");
                    string cValor = drDatos[cNombreCabecera] == null ? string.Empty : drDatos[cNombreCabecera].ToString();
                    bool lRequerido = drCabecera.Field<bool>("lRequerido");

                    if (!lRequerido && string.IsNullOrEmpty(cValor))
                        continue;

                    if (cTipoDato == "collection")
                    {
                        if (!this.dsDatosConf.Tables[cNombreCabecera].AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cValor.ToUpper()))
                            lstErrores.Add($"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} no se encuentra en el catálogo.");
                    }
                    else
                    {
                        if (cTipoDato == "datetime" && double.TryParse(cValor, out double cValorEntero))
                        {
                            DateTime dFecha;
                            if (DateTime.TryParse(DateTime.FromOADate(cValorEntero).ToString(), out dFecha))
                            {
                                cValor = dFecha.ToString("dd/MM/yyyy");
                                drDatos[cNombreCabecera] = cValor;
                            }
                        }

                        bool ExisteFormato() => !string.IsNullOrEmpty(cFormato);
                        bool FormatoValido() => Regex.IsMatch(cValor, cFormato);

                        string cMensajeError = $"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} no cumple con el formato requerido.";

                        switch (cTipoDato)
                        {
                            case "string":
                                if (ExisteFormato() && !FormatoValido())
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "datetime":
                                if (ExisteFormato())
                                {
                                    if (!DateTime.TryParseExact(cValor, cFormato, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                                        lstErrores.Add(cMensajeError);
                                }
                                else
                                {
                                    if (!DateTime.TryParse(cValor, out _))
                                        lstErrores.Add(cMensajeError);
                                }
                                break;

                            case "int":
                                if ((ExisteFormato() && !FormatoValido()) || (!int.TryParse(cValor, out _)))
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "decimal":
                                if ((ExisteFormato() && !FormatoValido()) || (!decimal.TryParse(cValor, out _)))
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "bool":
                                if (string.IsNullOrEmpty(cValor))
                                    drDatos[cNombreCabecera] = "NO";
                                else if (cValor.ToUpper() != "SI" && cValor.ToUpper() != "NO")
                                    lstErrores.Add(cMensajeError);
                                break;
                        }
                    }
                }
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores de formato, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Formato");
                return false;
            }

            return true;
        }

        private void GeneraDetalleComprobante(DataTable dtDatosCargados) 
        {
            string[] aColumnasPrincipales = this.dtCabeceras.AsEnumerable().Where(row => !row.Field<bool>("lDetalle"))
                .Select(row => row.Field<string>("cCabecera")).ToArray();

            string[] aColumnasDetalle = this.dtCabeceras.AsEnumerable().Where(row => row.Field<bool>("lDetalle"))
            .Select(row => row.Field<string>("cCabecera")).ToArray();

            var query = dtDatosCargados.AsEnumerable()
            .GroupBy(row => new
            {
                ValoresPrincipales = string.Join("|", aColumnasPrincipales.Select(col => row[col]))
            })
            .Select(g => new
            {
                Key = g.Key.ValoresPrincipales,
                Detalles = g.CopyToDataTable().DefaultView.ToTable(false, aColumnasDetalle)
            });

            DataTable dtResultados = new DataTable("dtResultados");

            foreach (var columna in aColumnasPrincipales)
            {
                dtResultados.Columns.Add(columna, typeof(string));
            }

            dtResultados.Columns.Add("dtDetalle", typeof(DataTable));

            foreach (var grupo in query)
            {
                var row = dtResultados.NewRow();
                var valoresPrincipales = grupo.Key.Split('|');

                for (int i = 0; i < aColumnasPrincipales.Length; i++)
                {
                    row[aColumnasPrincipales[i]] = valoresPrincipales[i];
                }

                row["dtDetalle"] = grupo.Detalles;
                dtResultados.Rows.Add(row);
            }

            this.dtComprobantesCargados = dtResultados;
        }

        private void GeneraDataGrid()
        {
            this.dtgDatosCargados.Columns.Clear();
            this.dtgDatosCargados.DataSource = this.dtComprobantesCargados;

            DataGridViewButtonColumn btnDetalle = new DataGridViewButtonColumn();
            {
                btnDetalle.Name = "btnDetalle";
                btnDetalle.HeaderText = "Detalle";
                btnDetalle.Text = "VER";
                btnDetalle.UseColumnTextForButtonValue = true;
                btnDetalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDetalle.FlatStyle = FlatStyle.Standard;
                btnDetalle.DefaultCellStyle.Padding = new Padding(1, 1, 1, 1);
                this.dtgDatosCargados.Columns.Add(btnDetalle);
            }

            foreach (DataGridViewColumn col in this.dtgDatosCargados.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.Visible = col.Name == "dtDetalle" ? false : true;
            }

            this.btnCancelar.Enabled = true;
            this.lblContador.Text = "Cantidad de Comprobantes: " + this.dtgDatosCargados.Rows.Count;
        }

        private void GeneraDetalleErrores(List<string> lstErrores, string cNivel)
        {
            string cRutaArchivo = Path.Combine(this.InitialDirectory, DateTime.Now.ToString("ddMMyyyy-HHmmss") + "-ErroresCargaMasiva(" + cNivel + ").txt");

            using (StreamWriter sw = new StreamWriter(cRutaArchivo))
            {
                foreach (string cError in lstErrores)
                {
                    sw.WriteLine(cError);
                }
            }

            MessageBox.Show("Se generó un archivo con los errores en la siguiente ruta: " + cRutaArchivo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateProgress(int progress)
        {
            if (this.InvokeRequired)
                Invoke(new Action<int>(UpdateProgress), progress);
            
            this.progressBar.Value = progress;
        }

        private void ReleaseComObject(object obj)
        {
            if (obj != null && System.Runtime.InteropServices.Marshal.IsComObject(obj))
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }

        private void HabilitarBotones(bool lHabilita)
        {
            if (this.InvokeRequired)
                Invoke(new Action<bool>(HabilitarBotones), lHabilita);

            this.btnExporExcel.Enabled = lHabilita;
            this.btnImportar.Enabled = lHabilita;

            bool lExisteDatos = this.dtgDatosCargados.Rows.Count > 0;
            this.btnGrabar.Enabled = (!lExisteDatos) ? false : lHabilita;
            this.btnCancelar.Enabled = (!lExisteDatos) ? false : lHabilita;
        }

        private string GeneraXML()
        {
            DataTable dtComprobantesXml = CopyDataTable(this.dtComprobantesCargados);

            foreach (DataColumn columnM in dtComprobantesXml.Columns)
            {
                if (columnM.DataType == typeof(DataTable))
                {
                    foreach (DataRow row in dtComprobantesXml.Rows)
                    {
                        DataTable dtDetalle = row[columnM] as DataTable;
                        foreach (DataColumn columnD in dtDetalle.Columns)
                        {
                            columnD.ColumnName = this.dtCabeceras.AsEnumerable().Where(x => x.Field<string>("cCabecera") == columnD.ColumnName)
                                .Select(x => x.Field<string>("cCampoXML")).FirstOrDefault();
                        }
                    }
                }
                else
                {
                    columnM.ColumnName = this.dtCabeceras.AsEnumerable().Where(x => x.Field<string>("cCabecera") == columnM.ColumnName)
                        .Select(x => x.Field<string>("cCampoXML")).FirstOrDefault();
                }
            }

            dtComprobantesXml = AgregaIDCatalogos(dtComprobantesXml);
            dtComprobantesXml = AgregaColumnasCalculadas(dtComprobantesXml);

            XDocument xmlDocument = new XDocument
            (
                new XElement("dsComprobantesCargados", from row in dtComprobantesXml.AsEnumerable()
                                                       select
                new XElement("dtComprobantesCargados", from column in dtComprobantesXml.Columns.Cast<DataColumn>()
                                                       where column.ColumnName != "dtDetalle"
                                                       select
                new XElement(column.ColumnName, row[column]),
                new XElement("dtDetalle", from detalleRow in ((DataTable)row["dtDetalle"]).AsEnumerable()
                                          select
                new XElement("Row", from detalleColumn in ((DataTable)row["dtDetalle"]).Columns.Cast<DataColumn>()
                                    select
                new XElement(detalleColumn.ColumnName, detalleRow[detalleColumn])))))
            );

            return xmlDocument.ToString();
        }

        private DataTable AgregaIDCatalogos(DataTable dtComprobantesXml)
        {
            foreach (DataRow row in dtComprobantesXml.Rows)
            {
                foreach (DataColumn column in dtComprobantesXml.Columns)
                {
                    if (column.DataType == typeof(DataTable))
                    {
                        AgregaIDCatalogos(row[column] as DataTable);
                    }
                    else
                    {
                        string cNombreCabecera = column.ColumnName;
                        var dtConfColumna = this.dtCabeceras.AsEnumerable().Where(x => x.Field<string>("cCampoXML") == cNombreCabecera).FirstOrDefault();
                        string cTipoDato = dtConfColumna.Field<string>("cTipoDato");

                        if (cTipoDato == "collection")
                        {
                            string cNombreCatalogo = dtConfColumna.Field<string>("cCabecera");
                            bool lDetalle = dtConfColumna.Field<bool>("lDetalle");

                            if (this.dsDatosConf.Tables.Contains(cNombreCatalogo))
                            {
                                int nId = this.dsDatosConf.Tables[cNombreCatalogo].AsEnumerable()
                                    .Where(c => c.Field<string>("cDescripcion").ToUpper() == row[cNombreCabecera].ToString().ToUpper())
                                    .Select(c => c.Field<int>("idCodigo")).FirstOrDefault();

                                row[cNombreCabecera] = nId;
                            }
                        }
                        else if (cTipoDato == "datetime" && !string.IsNullOrEmpty(row[cNombreCabecera].ToString()))
                        {
                            DateTime dFecha = DateTime.Parse(row[cNombreCabecera].ToString());
                            row[cNombreCabecera] = dFecha.ToString("yyyy-MM-dd");
                        }
                        else if (cTipoDato == "bool")
                        {
                            row[cNombreCabecera] = row[cNombreCabecera].ToString().ToUpper() == "SI" ? true : false;
                        }
                    }
                }
            }

            return dtComprobantesXml;
        }

        private DataTable AgregaColumnasCalculadas(DataTable dtComprobantesXml)
        {
            dtComprobantesXml.Columns.Add("idIgv", typeof(int));
            dtComprobantesXml.Columns.Add("nSubTotal", typeof(decimal));
            dtComprobantesXml.Columns.Add("nTotalIGV", typeof(decimal));
            dtComprobantesXml.Columns.Add("nTotalOtros", typeof(decimal));
            dtComprobantesXml.Columns.Add("nTotalDetraccion", typeof(decimal));
            dtComprobantesXml.Columns.Add("nPorc4taCat", typeof(decimal));
            dtComprobantesXml.Columns.Add("nTotal4taCat", typeof(decimal));
            dtComprobantesXml.Columns.Add("nTotal", typeof(decimal));

            foreach (DataRow row in dtComprobantesXml.Rows)
            {
                var dtDetalle = (row["dtDetalle"] as DataTable);

                dtDetalle.Columns.Add("nMontoIGV", typeof(decimal));
                dtDetalle.Columns.Add("nMontoImporte", typeof(decimal));
                dtDetalle.Columns.Add("nMontoDetraccion", typeof(decimal));
                dtDetalle.Columns.Add("nMonto4taCat", typeof(decimal));

                decimal nPorcentajeDetraccion = this.dsDatosConf.Tables["Bien/Servicio"].AsEnumerable()
                    .Where(c => c.Field<int>("idCodigo") == Convert.ToInt32(row.Field<string>("idBienServicio")))
                    .Select(c => c.Field<decimal>("nPorcentaje")).FirstOrDefault();

                decimal nValCuartaCateg = this.dsDatosConf.Tables["Tipo Comprobante"].AsEnumerable()
                    .Where(c => c.Field<int>("idCodigo") == Convert.ToInt32(row.Field<string>("idTipoComprobante")))
                    .Select(c => c.Field<decimal>("nValCuartaCateg")).FirstOrDefault();

                decimal nTotalBaseImp = dtDetalle.AsEnumerable().Sum(c => Convert.ToDecimal(c.Field<string>("nSubTotal")));
                decimal nTotalIgv = decimal.Zero;
                decimal nTotalOtros = decimal.Zero;
                decimal nTotalDetraccion = decimal.Zero;
                decimal nTotal4taCat = decimal.Zero;

                decimal nIgv = string.IsNullOrEmpty(row["nIgv"].ToString()) ? decimal.Zero : Convert.ToDecimal(row["nIgv"]);
                row["nIgv"] = nIgv;

                foreach (DataRow rowD in dtDetalle.Rows)
                {
                    decimal nOtros = string.IsNullOrEmpty(rowD["nOtros"].ToString()) ? decimal.Zero : Convert.ToDecimal(rowD["nOtros"]);
                    rowD["nOtros"] = nOtros;
                    decimal nSubTotal = string.IsNullOrEmpty(rowD["nSubTotal"].ToString()) ? decimal.Zero : Convert.ToDecimal(rowD["nSubTotal"]);
                    rowD["nSubTotal"] = nSubTotal;

                    rowD["nMontoIGV"] = Math.Round(nSubTotal * nIgv / 100.00M, 2);
                    rowD["nMontoImporte"] = Math.Round(nSubTotal + nOtros + Convert.ToDecimal(rowD["nMontoIGV"]), 2);
                    rowD["nMontoDetraccion"] = Math.Round((Math.Round((nTotalBaseImp + Math.Round(nTotalBaseImp * nIgv / 100.00M, 2)) * 
                                                nPorcentajeDetraccion / 100.00M, 0)) * (nSubTotal / nTotalBaseImp), 2);
                    rowD["nMonto4taCat"] = Math.Round(Convert.ToDecimal(rowD["nMontoImporte"]) * nValCuartaCateg / 100.00M, 2);

                    nTotalOtros += nOtros;
                    nTotalIgv += Convert.ToDecimal(rowD["nMontoIGV"]);
                    nTotalDetraccion += Convert.ToDecimal(rowD["nMontoDetraccion"]);
                    nTotal4taCat += Convert.ToDecimal(rowD["nMonto4taCat"]);
                }

                row["idIgv"] = this.dtIgv.AsEnumerable().Where(c => c.Field<decimal>("nValorIGV") == nIgv)
                    .Select(c => c.Field<int>("idIGV")).FirstOrDefault();
                row["nSubTotal"] = nTotalBaseImp;
                row["nTotalIGV"] = nTotalIgv;
                row["nTotalOtros"] = nTotalOtros;
                row["nTotalDetraccion"] = nTotalDetraccion;
                row["nPorc4taCat"] = nValCuartaCateg;
                row["nTotal4taCat"] = nTotal4taCat;
                row["nTotal"] = nTotalBaseImp + nTotalIgv + nTotalOtros - nTotalDetraccion - nTotal4taCat;
            }

            return dtComprobantesXml;
        }

        private DataTable CopyDataTable(DataTable dtOriginal)
        {
            DataTable dtCopy = dtOriginal.Copy();

            foreach (DataColumn column in dtOriginal.Columns)
            {
                if (column.DataType == typeof(DataTable))
                {
                    foreach (DataRow row in dtCopy.Rows)
                    {
                        DataTable nestedTable = row[column.ColumnName] as DataTable;
                        if (nestedTable != null)
                            row[column.ColumnName] = CopyDataTable(nestedTable);
                    }
                }
            }

            return dtCopy;
        }

        #endregion

        #region Eventos

        private void btnExporExcel_Click(object sender, EventArgs e)
        {
            ObtenerDatos();

            string cMensaje = "¿Deseas generar una plantilla?";

            if (MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;

            HabilitarBotones(false);

            this.progressBar.Visible = true;
            this.progressBar.Value = 0;
            this.excelThread = new Thread(GenerarPlantilla);
            this.excelThread.SetApartmentState(ApartmentState.STA);
            this.excelThread.Start();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtgDatosCargados.DataSource = null;
            this.dtgDatosCargados.Columns.Clear();
            HabilitarBotones(true);
            this.lblContador.Text = "Cantidad de Comprobantes: 0";
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = InitialDirectory;
            openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                ImportarDatos(openFileDialog.FileName);

            this.txtFiltro.Text = string.Empty;
        }

        private void frmCargaComprobantesMasivo_FormClosing(object sender, EventArgs e)
        {
            if (this.excelThread != null && this.excelThread.IsAlive)
                this.excelThread.Abort();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string xmlComprobantes = GeneraXML();

            DataTable dtRespuesta = this.objCNCargaMasiva.CNGuardaComprobantesCargaMasiva(xmlComprobantes);
            
            if (dtRespuesta.Rows[0].Field<bool>("lRespuesta"))
            {
                MessageBox.Show("Se guardaron los comprobantes correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgDatosCargados.DataSource = null;
                this.dtgDatosCargados.Columns.Clear();
                HabilitarBotones(true);
                this.lblContador.Text = "Cantidad de Comprobantes: 0";
            }
            else
            {
                MessageBox.Show($"Ocurrió un error al guardar los comprobantes: {dtRespuesta.Rows[0].Field<string>("cError")}", 
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgDatosCargados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dtgDatosCargados.Columns["btnDetalle"].Index && e.RowIndex >= 0)
            {
                new frmDetalleCargaComprobantesMasivo
                (
                    this.dtComprobantesCargados.Rows[e.RowIndex]["Serie"].ToString(),
                    this.dtComprobantesCargados.Rows[e.RowIndex]["Número"].ToString(),
                    (DataTable)this.dtComprobantesCargados.Rows[e.RowIndex]["dtDetalle"]
                ).ShowDialog();
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if(this.dtgDatosCargados.DataSource == null)
                return;

            string cFiltro = string.Empty;

            if (!string.IsNullOrWhiteSpace(this.txtFiltro.Text))
                cFiltro = $"Número LIKE '%{this.txtFiltro.Text}%'";

            (this.dtgDatosCargados.DataSource as DataTable).DefaultView.RowFilter = cFiltro;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        #endregion
    }
}
