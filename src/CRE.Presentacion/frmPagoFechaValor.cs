using GEN.ControlesBase;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;
using System.Data;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using System.ComponentModel;
using Credito = CRE.CapaNegocio.clsCNCredito;
using System.Transactions;
using System.Text;

namespace CRE.Presentacion
{
    public partial class frmPagoFechaValor : frmBase
    {
        #region Variables Globales

        private Excel.Application excelApp = null;
        private const string cTituloForm = "Pagos masivos con Fecha Valor";
        private readonly clsCNFechaValor clsCNFechaValor = new clsCNFechaValor();
        private readonly clsCNCanal clsCNCanal = new clsCNCanal();
        private readonly clsUtils clsUtils = new clsUtils();
        private readonly Credito clsCNCredito = new Credito();
        private readonly clsCNPlanPago clsCNPlanPago = new clsCNPlanPago();
        private readonly List<string> cabeceraEsperada = new List<string> { "Canal", "Número de Crédito", "Fecha Valor", "Número de Operación del Canal Externo", "Monto Pagado" };
        private byte[] archivoPlantilla = null;
        private string nombrePlantilla = string.Empty;
        private static frmCargarArchivosFechaValor frmCargaArchivosInstancia;
        private List<clsPlantillaFechaValor> lstPlantilla = new List<clsPlantillaFechaValor>();
        private List<clsArchivoCargadoFechaValor> archivosSustento = new List<clsArchivoCargadoFechaValor>();
        private DataSet dsPlanesPagoActuales = new DataSet();
        private List<clsPlanPagoFechaValor> resultadosRecalculados = new List<clsPlanPagoFechaValor>();
        private List<clsFechaPagoProcesados> lstProcesadasAnteriormente = new List<clsFechaPagoProcesados>();

        #endregion

        #region Constructor

        public frmPagoFechaValor()
        {
            InitializeComponent();

            dtgDatos.CurrentCellDirtyStateChanged += dtgDatos_CurrentCellDirtyStateChanged;
        }

        #endregion

        #region Métodos Privados

        private void CargaInicial()
        {
            txtRutaArchivo.Text = string.Empty;
            txtSustento.Text = string.Empty;
            lblContador.Text = txtSustento.Text.Trim().Length + "/250";
            lblPorcentaje.Visible = false;
            lblPorcentaje.Text = "0%";
            cboMotivo.SelectedIndex = -1;
            archivosSustento.Clear();
            lstPlantilla.Clear();
            dtgDatos.Columns.Clear();
            ActualizarCantidadSustentos();
            DeshabilitarBotones();
        }

        private void DeshabilitarBotones()
        {
            btnValidar.Enabled = false;
            btnConsultar.Enabled = false;
            btnProcesar.Enabled = false;
        }

        private void ActualizarCantidadSustentos()
        {
            lblCantidadSustentos.Text = archivosSustento.Count.ToString();
        }

        private void LlenarHojaDeInstrucciones(Excel.Workbook workbook)
        {
            Excel.Worksheet worksheetInstrucciones = (Excel.Worksheet)workbook.Worksheets.Add();
            worksheetInstrucciones.Name = "Instrucciones";

            //Establezco fondo blanco y fuente Roboto tamaño 12 en toda la hoja "Instrucciones"
            worksheetInstrucciones.Cells.Interior.Color = Excel.XlRgbColor.rgbWhite;
            worksheetInstrucciones.Cells.Font.Name = "Roboto";
            worksheetInstrucciones.Cells.Font.Size = 12;

            //Completo instrucciones estáticas
            worksheetInstrucciones.Cells[2, 2] = @"Instrucciones para llenar la plantilla:";
            worksheetInstrucciones.Cells[4, 2] = @"1. Llene los datos en la hoja ""Datos"", a partir de la fila 2.";
            worksheetInstrucciones.Cells[5, 2] = @"2. Asegúrese de que las fechas en la columna ""Fecha Valor"" estén en formato dd/MM/yyyy.";
            worksheetInstrucciones.Cells[6, 2] = @"3. Utilice el punto (.) como separador decimal para los montos en la columna ""Monto pagado"".";
            worksheetInstrucciones.Cells[7, 2] = @"4. No deje filas vacías entre el encabezado y los datos.";
            worksheetInstrucciones.Cells[8, 2] = @"5. No modifique el nombre ni el orden de las columnas.";
            worksheetInstrucciones.Cells[9, 2] = @"6. Utilice MAYÚSCULAS para indicar el canal de pago.";
            worksheetInstrucciones.Cells[11, 2] = @"Ejemplos de datos válidos:";
            worksheetInstrucciones.Cells[13, 2] = @"Canal";
            worksheetInstrucciones.Cells[13, 3] = @"Número de Crédito";
            worksheetInstrucciones.Cells[13, 4] = @"Fecha Valor";
            worksheetInstrucciones.Cells[13, 5] = @"Número de Operación del Canal Externo";
            worksheetInstrucciones.Cells[13, 6] = @"Monto Pagado";

            worksheetInstrucciones.get_Range("B2", "F2").Merge();
            worksheetInstrucciones.get_Range("B2", "F2").Font.Bold = true;  // Negrita
            worksheetInstrucciones.get_Range("B3", "F3").Merge();
            worksheetInstrucciones.get_Range("B4", "F4").Merge();
            worksheetInstrucciones.get_Range("B5", "F5").Merge();
            worksheetInstrucciones.get_Range("B6", "F6").Merge();
            worksheetInstrucciones.get_Range("B7", "F7").Merge();
            worksheetInstrucciones.get_Range("B8", "F8").Merge();
            worksheetInstrucciones.get_Range("B9", "F9").Merge();
            worksheetInstrucciones.get_Range("B11", "F11").Merge();
            worksheetInstrucciones.get_Range("B11", "F11").Font.Bold = true; // Negrita

            //Traigo la lista de canales activos
            DataTable dtCanales = clsCNCanal.CNListaCanalActivo();

            if (dtCanales.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron canales activos.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < dtCanales.Rows.Count; i++)
            {
                //Lleno canal con la lista de BD
                worksheetInstrucciones.Cells[14 + i, 2] = dtCanales.Rows[i]["cCanal"].ToString();
                //Lleno número de crédito con un número aleatorio de 5 dígitos
                worksheetInstrucciones.Cells[14 + i, 3] = clsUtils.GenerarNumeroAleatorio(10000, 99999);
                //Lleno fecha valor con valor menor o igual la fecha de sistema
                worksheetInstrucciones.Cells[14 + i, 4] = clsUtils.GenerarFechaAleatoria().ToString("dd/MM/yyyy");
                //Lleno número de operación del canal externo con un número aleatorio de 7 dígitos
                worksheetInstrucciones.Cells[14 + i, 5] = clsUtils.GenerarNumeroAleatorio(1000000, 9999999);
                //Lleno monto pagado con un número aleatorio de 4 dígitos y 2 decimales
                worksheetInstrucciones.Cells[14 + i, 6] = clsUtils.GenerarNumeroAleatorio(1000, 9999) + clsUtils.GenerarNumeroAleatorio(0, 99) / 100.0;
            }

            //Establezco bordes continuos a toda la tabla
            Excel.Range headerRange = worksheetInstrucciones.Range["B13", "F13"];
            Excel.Range dataRange = worksheetInstrucciones.Range[worksheetInstrucciones.Cells[14, 2], worksheetInstrucciones.Cells[14 + dtCanales.Rows.Count - 1, 6]];

            headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheetInstrucciones.Columns.AutoFit();
        }

        private void LlenarHojaDeDatos(Excel.Workbook workbook)
        {
            Excel.Worksheet worksheetDatos = (Excel.Worksheet)workbook.Worksheets[1];
            worksheetDatos.Name = "Datos";

            //Agrego encabezados en la hoja "Datos"
            worksheetDatos.Cells[1, 1] = "Canal";
            worksheetDatos.Cells[1, 2] = "Número de Crédito";
            worksheetDatos.Cells[1, 3] = "Fecha Valor";
            worksheetDatos.Cells[1, 4] = "Número de Operación del Canal Externo";
            worksheetDatos.Cells[1, 5] = "Monto Pagado";

            //Ajusto el ancho de las columnas en la hoja "Datos" para que se lea completo
            worksheetDatos.Columns.AutoFit();

            //Agrego comentarios a las celdas de encabezado
            worksheetDatos.Cells[1, 1].AddComment("Ingrese el canal de pago, en mayúsculas.");
            worksheetDatos.Cells[1, 3].AddComment("Ingrese la fecha en formato dd/MM/yyyy.");
            worksheetDatos.Cells[1, 5].AddComment("Ingrese el monto pagado usando punto (.) como separador decimal.");
        }

        private void GuardarArchivoExcel(Excel.Workbook workbook)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Guardar archivo de Excel",
                FileName = "Plantilla_Pagos_Fecha_Valor.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("La plantilla se ha descargado correctamente.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImprimirReporteErroresImportacion(List<clsPlantillaFechaValor> dbResp)
        {
            try
            {
                List<ReportParameter> paramlist = new List<ReportParameter>
            {
                new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false),
                new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false),
                new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false),
                new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false)
            };

                List<ReportDataSource> dtslist = new List<ReportDataSource>
            {
                new ReportDataSource("dsErroresImportacionFechaValor", dbResp)
            };

                string reportPath = "rptErroresImportacionPlantilla.rdlc";
                frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportPath, paramlist);
                frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                frmReporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el reporte de errores de importación: " + ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dtgDatos.Columns.Clear();
            dtgDatos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "lSeleccionado", HeaderText = "", Width = 30, ReadOnly = false, HeaderCell = { Value = CheckState.Unchecked } });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "idCanal", HeaderText = "ID Canal", ReadOnly = true, Visible = false });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cCanal", HeaderText = "Canal", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nCodigoCliente", HeaderText = "Codigo Cliente", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cDNI", HeaderText = "DNI", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nNumeroCredito", HeaderText = "Número de Crédito", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "dFechaPagoCanalExterno", HeaderText = "Fecha de pago por el Canal Externo", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nNumeroOperacionCanalExterno", HeaderText = "Número de Operación del Canal Externo", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cMoneda", HeaderText = "Moneda", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cOficinaEOB", HeaderText = "Oficina/EOB", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cNombre", HeaderText = "Nombre", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cDireccion", HeaderText = "Dirección", ReadOnly = true, Visible = false });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "dFechaPagoCronograma", HeaderText = "Fecha de pago según cronograma", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "dFechaValorizacion", HeaderText = "Fecha de Valorización", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nMontoCuotaCronograma", HeaderText = "Monto de cuota según cronograma", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nMontoCuotaFechaActual", HeaderText = "Monto de cuota a la fecha actual", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nDiasAtraso", HeaderText = "Días de Atraso", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nCapital", HeaderText = "Capital", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nInteresProgramado", HeaderText = "Interés Programado", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nInteresCompensatorio", HeaderText = "Interés Compensatorio", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nInteresMoratorio", HeaderText = "Interés Moratorio", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nInteresMoratorioFechaValor", HeaderText = "Interés Moratorio Fecha Valor", ReadOnly = true, Visible = false });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nInteresDevengado", HeaderText = "Interés Devengado", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nOtros", HeaderText = "Otros", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nOtrosFechaValor", HeaderText = "Otros Fecha Valor", ReadOnly = true, Visible = false });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nSaldoTotal", HeaderText = "Saldo Total", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nMontoPagarFechaValor", HeaderText = "Monto a Pagar con Fecha Valor", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cEstadoPago", HeaderText = "Estado Pago", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "idCuota", HeaderText = "Cuota", ReadOnly = true, Visible = false });

            //Ajusto las columnas y filas al contenido
            dtgDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Habilito scroll
            dtgDatos.ScrollBars = ScrollBars.Both;
        }

        private void PintarDatosGridView(clsImpresionFechaValor dbResp)
        {
            foreach (clsPlanPagoFechaValor item in dbResp.lsPlanPagos)
            {
                dtgDatos.Rows.Add(CheckState.Unchecked, item.idCanal, item.cCanal, item.nCodigoCliente, item.cDNI, item.nNumeroCredito, item.dFechaPagoCanalExterno, item.nNumeroOperacionCanalExterno, item.cMoneda, item.cOficinaEOB, item.cNombre, item.cDireccion, item.dFechaPagoCronograma, item.dFechaValorizacion, item.nMontoCuotaCronograma, item.nMontoCuotaFechaActual, item.nDiasAtraso, /*item.nCapital, item.nInteresProgramado, item.nInteresCompensatorio,*/0, 0, 0, 0, item.nInteresMoratorioFechaValor, item.nInteresMoratorio, /*item.nOtros, item.nSaldoTotal,*/  0, item.nOtrosFechaValor, item.nSaldoTotal, item.nMontoPagarFechaValor, item.cEstadoPago, item.idCuota);
            }
        }

        private void MostrarMensajeAdvertencia(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void MostrarResultados(List<clsPlanPagoFechaValor> resultados)
        {
            foreach (var resultado in resultados)
            {
                DataGridViewRow row = dtgDatos.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["nNumeroOperacionCanalExterno"].Value) == resultado.nNumeroOperacionCanalExterno && Convert.ToInt32(r.Cells["nNumeroCredito"].Value) == resultado.nNumeroCredito);

                if (row != null)
                {
                    row.Cells["nCapital"].Value = resultado.nCapital;
                    row.Cells["nInteresProgramado"].Value = resultado.nInteresProgramado;
                    row.Cells["nInteresCompensatorio"].Value = resultado.nInteresCompensatorio;
                    row.Cells["nInteresMoratorio"].Value = resultado.nInteresMoratorio;
                    row.Cells["nOtros"].Value = resultado.nOtros;
                }
            }
        }

        private void ActualizarCredito(DataRow item, BackgroundWorker worker)
        {
            try
            {
                if (!ValidarFilaParaProcesamiento(item)) return;

                IEnumerable<DataRow> filteredRows = dsPlanesPagoActuales.Tables.Cast<DataTable>()
                    .SelectMany(table => table.AsEnumerable())
                    .Where(row => row.Field<int>("idCuenta") == item.Field<long>("nNumeroCredito") && row["dFechaPago"] != DBNull.Value);

                if (!filteredRows.Any())
                {
                    MessageBox.Show($"No se encontró el plan de pago para el crédito {item.Field<long>("nNumeroCredito")}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = CrearDataSetConFilasFiltradas(filteredRows);
                DataTable dtDetalleCargaGasto = clsCNPlanPago.DistribuirGastosPagados(ds.Tables["dtPlanPagos"]);
                dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
                ActualizarFechasDePago(filteredRows, dtDetalleCargaGasto);

                ds.Tables.Add(dtDetalleCargaGasto);
                DataTable dtPagador = CrearTablaDatosPagador(item);
                dtPagador.TableName = "TablaDatosPagador";
                ds.Tables.Add(dtPagador);

                ValidarCuotasPagadasPorDuplicidad(item);

                string xmlPpg = clsCNFormatoXML.EncodingXML(ds.GetXml());
                ds.Tables.Clear();

                DataTable TablaUpPpg = ActualizarCobros(item, xmlPpg);
                if (TablaUpPpg.Rows.Count > 0)
                {
                    item["cEstadoPago"] = "PAGADO";
                    item["idKardex"] = Convert.ToInt64(TablaUpPpg.Rows[0]["idKardex"]);
                }

                worker.ReportProgress(progressBarLoading.Value + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el crédito {item.Field<long>("nNumeroCredito")}: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarFechasDePago(IEnumerable<DataRow> filteredRows, DataTable dtDetalleCargaGasto)
        {
            foreach (DataRow row in dtDetalleCargaGasto.Rows)
            {
                DataRow rowFiltered = filteredRows.FirstOrDefault(r => r.Field<int>("idCuota") == row.Field<int>("nIdNumCuota") && r.Field<int>("idPlanPagos") == row.Field<int>("idPlanPagos") && r.Field<int>("idCuenta") == row.Field<int>("nidNumCuenta"));
                if (rowFiltered != null)
                {
                    row["dFechaPago"] = Convert.ToDateTime(rowFiltered["dFechaPago"]).ToString("yyyy-MM-dd");
                }
            }
        }

        private void ValidarCuotasPagadasPorDuplicidad(DataRow item)
        {
            DataTable dtPlanPagoAct = clsCNPlanPago.CNdtPlanPago((int)item.Field<long>("nNumeroCredito"));
            if (!dtPlanPagoAct.AsEnumerable().Any(rowAct => rowAct.Field<int>("idCuota") == item.Field<int>("idCuota")))
            {
                throw new Exception($"Se ha detectado que la cuota {item["idCuota"]} ya ha sido pagada, por favor actualice.");
            }
        }

        private void RegistrarDocumentosDeSustento(int idCabecera)
        {
            try
            {
                foreach (clsArchivoCargadoFechaValor archivo in archivosSustento)
                {
                    clsCNFechaValor.CNInsArchivoSustento(archivo.cNombreArchivo, archivo.cByteArchivo, Path.GetExtension(archivo.cNombreArchivo), clsVarGlobal.User.idUsuario, idCabecera);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarGridConResultados(DataTable resultadosRecalculadosTMP)
        {
            try
            {
                foreach (DataRow item in resultadosRecalculadosTMP.Rows)
                {
                    DataGridViewRow row = dtgDatos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt64(r.Cells["nNumeroOperacionCanalExterno"].Value) == item.Field<long>("nNumeroOperacionCanalExterno"));
                    if (row != null)
                    {
                        row.Cells["cEstadoPago"].Value = item["cEstadoPago"];
                    }
                }

                //Muestro mensaje de éxito de proceso
                MessageBox.Show("Proceso de pago de Fecha Valor realizado con éxito.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Bloqueo el botón de consultar y procesar
                btnConsultar.Enabled = false;
                btnProcesar.Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int ObtenerIndiceColumna(Excel.Worksheet worksheet, string headerName, int headerRow = 1)
        {
            for (int col = 1; col <= worksheet.Columns.Count; col++)
            {
                if (((Excel.Range)worksheet.Cells[headerRow, col]).Value?.ToString() == headerName)
                {
                    return col;
                }
            }
            throw new Exception($"Cabecera '{headerName}' no encontrada.");
        }

        private int RegistrarCabecera(DataTable resultadosRecalculadosTMP)
        {
            try
            {
                int motivoSeleccionado = 0;
                if (string.IsNullOrEmpty(resultadosRecalculadosTMP.TableName))
                {
                    resultadosRecalculadosTMP.TableName = "ResultadosRecalculados";
                }

                cboMotivo.Invoke(new Action(() =>
                {
                    motivoSeleccionado = (int)cboMotivo.SelectedValue;
                }));

                string xmlDetalle = clsUtils.toXmlObject(resultadosRecalculadosTMP);
                int idInsertado = clsCNFechaValor.CNInsPagoFechaValor(nombrePlantilla, archivoPlantilla, clsVarGlobal.User.idUsuario, motivoSeleccionado, txtSustento.Text, xmlDetalle);

                return idInsertado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ValidarEntradas()
        {
            //Valido que se haya seleccionado un motivo
            if (cboMotivo.SelectedIndex == -1)
            {
                MostrarMensajeAdvertencia("Debe seleccionar un motivo.", cboMotivo);
                return false;
            }

            //Valido que se haya seleccionado un archivo de Fecha Valor
            if (string.IsNullOrEmpty(txtRutaArchivo.Text))
            {
                MostrarMensajeAdvertencia("Debe seleccionar un archivo de Fecha Valor.", btnImportar);
                return false;
            }

            //Valido que se haya seleccionado al menos un sustento
            if (archivosSustento.Count == 0)
            {
                MostrarMensajeAdvertencia("Debe seleccionar al menos un sustento.", btnArchivos);
                return false;
            }

            //Valido que se haya ingresado un sustento
            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MostrarMensajeAdvertencia("Debe ingresar un sustento.", txtSustento);
                return false;
            }

            //El sustento tiene que tener un mínimo 10 y máximo 250 caracteres sin contar espacios en blanco
            if (txtSustento.Text.Trim().Length < 10 || txtSustento.Text.Trim().Length > 250)
            {
                MostrarMensajeAdvertencia("El sustento debe tener entre 10 y 250 caracteres.", txtSustento);
                return false;
            }

            return true;
        }

        private bool ValidarFilaParaProcesamiento(DataRow item)
        {
            //Verifico si los montos suman cero
            return !(item.Field<decimal>("nCapital") +
                     item.Field<decimal>("nInteresProgramado") +
                     item.Field<decimal>("nInteresCompensatorio") +
                     item.Field<decimal>("nInteresMoratorio") +
                     item.Field<decimal>("nOtros") == 0);
        }

        private bool TodasLasFilasMarcadas()
        {
            for (int i = 0; i < dtgDatos.Rows.Count; i++)
            {
                var cellValue = dtgDatos.Rows[i].Cells[0].Value; //Obtener el valor de la celda

                if (cellValue == null || (cellValue is bool && !(bool)cellValue) || (cellValue is CheckState checkState && checkState != CheckState.Checked))
                {
                    return false; //Hay al menos una fila no marcada
                }
            }
            return true;
        }

        private bool ValidarOperacion(clsPlanPagoFechaValor fila)
        {
            return clsCNFechaValor.CNValidarOperacion(fila);
        }

        private T ObtenerValorCelda<T>(Excel.Worksheet worksheet, int row, int col)
        {
            try
            {
                object cellValue = (worksheet.Cells[row, col] as Excel.Range)?.Value2;

                if (cellValue != null)
                {
                    if (typeof(T) == typeof(DateTime))
                    {
                        if (cellValue is double doubleValue)
                            return (T)(object)DateTime.FromOADate(doubleValue);

                        if (DateTime.TryParse(cellValue.ToString(), out DateTime dateValue))
                            return (T)(object)dateValue;
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        return (T)(object)cellValue.ToString();
                    }
                    else
                    {
                        dynamic dynamicValue = Convert.ChangeType(cellValue, typeof(T));
                        return (T)dynamicValue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el valor de la celda en la fila {row}, columna {col}: {ex.Message}");
            }

            return default;
        }

        private List<clsPlantillaFechaValor> LeerDatosExcel(Excel.Worksheet worksheet, BackgroundWorker worker)
        {
            List<clsPlantillaFechaValor> lstPlantillaExcel = new List<clsPlantillaFechaValor>();
            List<string> erroresFormato = new List<string>(); //Almaceno los errores de formato
            int row = 2; //Segunda fila, después del encabezado
            int totalFilas = worksheet.UsedRange.Rows.Count;

            //Obtengo los índices de las columnas según las cabeceras
            Dictionary<string, int> colIndices = new Dictionary<string, int>();
            foreach (string header in cabeceraEsperada)
            {
                int colIndex = ObtenerIndiceColumna(worksheet, header);
                colIndices.Add(header, colIndex);
            }

            while (((Excel.Range)worksheet.Cells[row, 1]).Value != null)
            {
                try
                {
                    string canal = ObtenerValorCelda<string>(worksheet, row, colIndices["Canal"]);
                    int numeroCredito = ObtenerValorCelda<int>(worksheet, row, colIndices["Número de Crédito"]);
                    DateTime fechaValor = ObtenerValorCelda<DateTime>(worksheet, row, colIndices["Fecha Valor"]);
                    int numeroOperacionCanalExterno = ObtenerValorCelda<int>(worksheet, row, colIndices["Número de Operación del Canal Externo"]);
                    decimal montoPagado = ObtenerValorCelda<decimal>(worksheet, row, colIndices["Monto Pagado"]);

                    clsPlantillaFechaValor objPlantilla = new clsPlantillaFechaValor
                    {
                        cCanal = canal,
                        nNumeroCredito = numeroCredito,
                        dFechaValor = fechaValor,
                        nNumeroOperacionCanalExterno = numeroOperacionCanalExterno,
                        nMontoPagado = montoPagado
                    };

                    lstPlantillaExcel.Add(objPlantilla);
                }
                catch (FormatException ex)
                {
                    erroresFormato.Add(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    erroresFormato.Add($"Celda vacía en la fila {row}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    erroresFormato.Add($"Error inesperado en la fila {row}: {ex.Message}");
                }
                int porcentaje = (int)(((double)row / totalFilas) * 100);
                worker.ReportProgress(porcentaje);
                row++;
            }

            //Elimino duplicados
            var listaSinDuplicados = lstPlantillaExcel.Distinct(new clsPlantillaFechaValorCompara()).ToList();

            //Muestro mensaje si hay errores
            if (erroresFormato.Count > 0)
            {
                string mensajeError = "Se encontraron los siguientes errores de formato:\n\n" + string.Join("\n", erroresFormato);
                MessageBox.Show(mensajeError, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //Muestro mensaje si la plantilla está sin datos
            if (lstPlantillaExcel.Count == 0)
            {
                MessageBox.Show("La plantilla no contiene datos.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            //Muestro mensaje de éxito con la cantidad de pagos importados solo si existe duplicados
            if (lstPlantillaExcel.Count != listaSinDuplicados.Count)
            {
                MessageBox.Show($"Se han importado correctamente {listaSinDuplicados.Count} pagos de préstamos, quitando los duplicados.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Se importaron {listaSinDuplicados.Count} pagos.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information); //Sin duplicados
            }

            return listaSinDuplicados;
        }

        private clsImpresionFechaValor ValidarPlantilla(BackgroundWorker worker = null)
        {
            string xmlPlantilla = clsUtils.toXmlObject(lstPlantilla);

            try
            {
                return clsCNFechaValor.CNValidarPlantilla(xmlPlantilla, worker);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private clsPlanPagoFechaValor ObtenerDatosFila(DataGridViewRow row)
        {
            try
            {
                return new clsPlanPagoFechaValor
                {
                    lSeleccionado = row.Cells["lSeleccionado"].Value is bool seleccionado && seleccionado,
                    idCanal = Convert.ToInt32(row.Cells["idCanal"].Value),
                    cCanal = Convert.ToString(row.Cells["cCanal"].Value),
                    nCodigoCliente = Convert.ToInt32(row.Cells["nCodigoCliente"].Value),
                    cDNI = Convert.ToString(row.Cells["cDNI"].Value),
                    nNumeroCredito = Convert.ToInt32(row.Cells["nNumeroCredito"].Value),
                    dFechaPagoCanalExterno = Convert.ToDateTime(row.Cells["dFechaPagoCanalExterno"].Value),
                    nNumeroOperacionCanalExterno = Convert.ToInt32(row.Cells["nNumeroOperacionCanalExterno"].Value),
                    cMoneda = Convert.ToString(row.Cells["cMoneda"].Value),
                    cOficinaEOB = Convert.ToString(row.Cells["cOficinaEOB"].Value),
                    cNombre = Convert.ToString(row.Cells["cNombre"].Value),
                    cDireccion = Convert.ToString(row.Cells["cDireccion"].Value),
                    dFechaPagoCronograma = Convert.ToDateTime(row.Cells["dFechaPagoCronograma"].Value),
                    dFechaValorizacion = Convert.ToDateTime(row.Cells["dFechaValorizacion"].Value),
                    nMontoCuotaCronograma = Convert.ToDecimal(row.Cells["nMontoCuotaCronograma"].Value),
                    nMontoCuotaFechaActual = Convert.ToDecimal(row.Cells["nMontoCuotaFechaActual"].Value),
                    nDiasAtraso = Convert.ToInt32(row.Cells["nDiasAtraso"].Value),
                    nCapital = Convert.ToDecimal(row.Cells["nCapital"].Value),
                    nInteresProgramado = Convert.ToDecimal(row.Cells["nInteresProgramado"].Value),
                    nInteresCompensatorio = Convert.ToDecimal(row.Cells["nInteresCompensatorio"].Value),
                    nInteresMoratorio = Convert.ToDecimal(row.Cells["nInteresMoratorio"].Value),
                    nInteresMoratorioFechaValor = Convert.ToDecimal(row.Cells["nInteresMoratorioFechaValor"].Value),
                    nInteresDevengado = Convert.ToDecimal(row.Cells["nInteresDevengado"].Value),
                    nOtros = Convert.ToDecimal(row.Cells["nOtros"].Value),
                    nOtrosFechaValor = Convert.ToDecimal(row.Cells["nOtrosFechaValor"].Value),
                    nSaldoTotal = Convert.ToDecimal(row.Cells["nSaldoTotal"].Value),
                    nMontoPagarFechaValor = Convert.ToDecimal(row.Cells["nMontoPagarFechaValor"].Value),
                    cEstadoPago = Convert.ToString(row.Cells["cEstadoPago"].Value),
                    idCuota = Convert.ToInt32(row.Cells["idCuota"].Value)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private clsPlanPagoFechaValor RecalcularMontoPagar(clsPlanPagoFechaValor fila)
        {
            try
            {
                int nCredito = (int)fila.nNumeroCredito;

                //Obtengo detalles del crédito
                DataTable dtCredito = clsCNCredito.CNdtDataCreditoCobro(nCredito);

                if (dtCredito == null || dtCredito.Rows.Count == 0)
                {
                    throw new Exception("No se encontraron detalles del crédito.");
                }

                decimal nMonSalCredito = new Credito().nSaldoCredito(dtCredito);
                nMonSalCredito = Math.Round(nMonSalCredito, 2);

                if (nMonSalCredito < fila.nMontoPagarFechaValor)
                {
                    MessageBox.Show($"Monto a pagar {fila.nMontoPagarFechaValor} no puede exceder al saldo {nMonSalCredito} del crédito {nCredito}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new clsPlanPagoFechaValor { lSeleccionado = false };
                }

                DataTable dtOrdenPrelacion = clsCNCredito.ObtenerOrdenPrelacion(nCredito, Convert.ToInt32(dtCredito.Rows[0]["idOrdenPrelacion"]));
                DataTable dtPlanPagoActual = new DataTable();

                dtPlanPagoActual = clsCNPlanPago.CNdtPlanPago(nCredito);

                if (dtPlanPagoActual == null || dtPlanPagoActual.Rows.Count == 0)
                {
                    throw new Exception("No se encontraron detalles del plan de pago.");
                }

                //Agrego el plan de pagos actual al dataset
                dsPlanesPagoActuales.Tables.Add(dtPlanPagoActual);

                DataTable dtPlanPagado = clsCNPlanPago.dtCNPagoDistConOrdenPrelacion(dtPlanPagoActual, fila.nMontoPagarFechaValor, true, dtOrdenPrelacion, fila);

                if (dtPlanPagado == null || dtPlanPagado.Rows.Count == 0)
                {
                    throw new Exception("No se encontraron detalles del plan pagado.");
                }

                fila.nCapital = Convert.ToDecimal(dtPlanPagado.Rows[0]["nCapitalPag"].ToString());
                fila.nInteresProgramado = Convert.ToDecimal(dtPlanPagado.Rows[0]["nInteresPag"].ToString());
                fila.nInteresCompensatorio = Convert.ToDecimal(dtPlanPagado.Rows[0]["nIntCompPag"].ToString());
                fila.nInteresMoratorio = Convert.ToDecimal(dtPlanPagado.Rows[0]["nMoraPag"].ToString());
                fila.nOtros = Convert.ToDecimal(dtPlanPagado.Rows[0]["nOtrosPag"].ToString());
                fila.lSeleccionado = true;

                return fila;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recalcular el monto a pagar: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new clsPlanPagoFechaValor { lSeleccionado = false };
            }
        }

        private DataSet CrearDataSetConFilasFiltradas(IEnumerable<DataRow> filteredRows)
        {
            DataSet ds = new DataSet("dsPlanPagos");
            DataTable dtPlanPagoActualFiltrado = filteredRows.CopyToDataTable();
            dtPlanPagoActualFiltrado.TableName = "dtPlanPagos";
            ds.Tables.Add(dtPlanPagoActualFiltrado);
            return ds;
        }
        
        private DataTable CrearTablaDatosPagador(DataRow item)
        {
            DataTable dtPagador = new DataTable("TablaDatosPagador");
            dtPagador.Columns.Add("cNroDNI", typeof(string));
            dtPagador.Columns.Add("cNomCliente", typeof(string));
            dtPagador.Columns.Add("cDireccion", typeof(string));

            DataRow drfila = dtPagador.NewRow();
            drfila["cNroDNI"] = item.Field<string>("cDNI");
            drfila["cNomCliente"] = item.Field<string>("cNombre");
            drfila["cDireccion"] = item.Field<string>("cDireccion");
            dtPagador.Rows.Add(drfila);

            return dtPagador;
        }

        private DataTable ActualizarCobros(DataRow item, string xmlPpg)
        {
            try
            {
                return clsCNPlanPago.UpCobroPpg(
                    PpgXml: xmlPpg,
                    dFecSis: clsVarGlobal.dFecSystem,
                    nUsuSis: clsVarGlobal.User.idUsuario,
                    nIdAgencia: clsVarGlobal.nIdAgencia,
                    nMoraPagada: item.Field<decimal>("nInteresMoratorio"),
                    idCuenta: (int)item.Field<long>("nNumeroCredito"),
                    idCanal: item.Field<int>("idCanal"),
                    nMonRedondeo: 0,
                    nImpuesto: 0,
                    nITFNormal: 0,
                    idTipoPago: 2,  //Transferencia Interna
                    idEntidad: 0,
                    idCtaEntidad: 0,
                    cNroTrx: "",
                    idMotivoOperacion: 2,   //Se valida igual por BD el codigo correcto de fecha valor.
                    cXmlCobs: "<xmlCobs/>",
                    lModificaSaldoLinea: false,
                    idTipoTransac: 1,
                    idMoneda: 1,
                    nMontoOpe: item.Field<decimal>("nMontoPagarFechaValor"));
            }

            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Métodos públicos

        public void ActualizarListaArchivos(List<clsArchivoCargadoFechaValor> listaActualizada)
        {
            archivosSustento = listaActualizada;
            ActualizarCantidadSustentos();
        }

        #endregion

        #region Eventos

        private void frmPagoFechaValor_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            if (ValidarInicioOpe() != "A")
            {
                Dispose();
                return;
            }
            CargaInicial();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Excel.Workbook workbook = null;

            try
            {
                //Muestro el ProgressBar y establecer valores iniciales
                progressBarLoading.Visible = true;
                lblPorcentaje.Visible = true;
                progressBarLoading.Minimum = 0;
                progressBarLoading.Value = 0;
                Cursor = Cursors.WaitCursor;

                BackgroundWorker worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };

                worker.DoWork += (s, args) =>
                {
                    excelApp = new Excel.Application();
                    workbook = excelApp.Workbooks.Add();

                    //Lleno las hojas y simulo progreso
                    for (int i = 1; i <= 50; i++)
                    {
                        System.Threading.Thread.Sleep(10);
                        worker.ReportProgress(i);
                    }
                    LlenarHojaDeDatos(workbook);
                    for (int i = 51; i <= 100; i++)
                    {
                        System.Threading.Thread.Sleep(10);
                        worker.ReportProgress(i);
                    }
                    LlenarHojaDeInstrucciones(workbook);
                };

                worker.ProgressChanged += (s, args) =>
                {
                    progressBarLoading.Value = args.ProgressPercentage;
                    lblPorcentaje.Text = $"{args.ProgressPercentage}%";
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    //Oculto el ProgressBar
                    progressBarLoading.Visible = false;
                    lblPorcentaje.Visible = false;
                    lblPorcentaje.Text = "0%";
                    Cursor = Cursors.Default;

                    GuardarArchivoExcel(workbook);
                    if (workbook != null)
                    {
                        workbook.Close(false);
                        Marshal.ReleaseComObject(workbook);
                    }
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                        excelApp = null;
                    }
                };
                worker.RunWorkerAsync(); //Inicio la tarea en segundo plano
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descargar el archivo Excel: " + ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBarLoading.Visible = false;
                lblPorcentaje.Visible = false;
                lblPorcentaje.Text = "0%";
                Cursor = Cursors.Default;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Archivos de Excel 97-2003 (*.xls)|*.xls",
                Title = "Selección del archivo Fecha Valor"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                //Guardo el nombre del archivo en la variable nombrePlantilla
                nombrePlantilla = Path.GetFileName(filePath);

                //Guardo el archivo en la variable archivoPlantilla
                archivoPlantilla = File.ReadAllBytes(filePath);

                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;

                try
                {
                    excelApp = new Excel.Application();
                    workbook = excelApp.Workbooks.Open(filePath);

                    //Valido que la plantilla tenga la hoja "Datos"
                    bool hojaDatosExiste = false;
                    foreach (Excel.Worksheet sheet in workbook.Worksheets)
                    {
                        if (sheet.Name == "Datos")
                        {
                            hojaDatosExiste = true;
                            worksheet = sheet;
                            break;
                        }
                    }

                    if (!hojaDatosExiste)
                    {
                        throw new Exception("La plantilla no contiene la hoja 'Datos'.");
                    }

                    //Valido las cabeceras de la hoja
                    foreach (string columnaEsperada in cabeceraEsperada)
                    {
                        bool columnaEncontrada = false;
                        for (int col = 1; col <= worksheet.UsedRange.Columns.Count; col++)
                        {
                            if (((Excel.Range)worksheet.Cells[1, col]).Value?.ToString() == columnaEsperada)
                            {
                                columnaEncontrada = true;
                                break;
                            }
                        }
                        if (!columnaEncontrada)
                        {
                            throw new Exception($"La columna '{columnaEsperada}' es obligatoria y no se encuentra en la plantilla.");
                        }
                    }

                    //Me aseguro de limpiar el datagridview
                    dtgDatos.Columns.Clear();

                    //Muestro el ProgressBar
                    progressBarLoading.Visible = true;
                    lblPorcentaje.Visible = true;
                    progressBarLoading.Minimum = 0;
                    progressBarLoading.Value = 0;
                    Cursor = Cursors.WaitCursor;

                    BackgroundWorker worker = new BackgroundWorker
                    {
                        WorkerReportsProgress = true
                    };

                    worker.DoWork += (s, args) =>
                    {
                        lstPlantilla = LeerDatosExcel(worksheet, worker);
                    };

                    worker.ProgressChanged += (s, args) =>
                    {
                        progressBarLoading.Value = args.ProgressPercentage;
                        lblPorcentaje.Text = $"{args.ProgressPercentage}%";
                    };

                    worker.RunWorkerCompleted += (s, args) =>
                    {
                        DeshabilitarBotones();

                        //Limpio el grid de datos
                        dtgDatos.Rows.Clear();

                        progressBarLoading.Visible = false;
                        lblPorcentaje.Visible = false;
                        lblPorcentaje.Text = "0%";

                        Cursor = Cursors.Default;

                        if (lstPlantilla == null)
                        {
                            workbook.Close(false);
                            excelApp.Quit();
                            if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                            if (workbook != null) Marshal.ReleaseComObject(workbook);
                            if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                            return;
                        }

                        txtRutaArchivo.Text = filePath;

                        workbook.Close(false);
                        excelApp.Quit();
                        if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                        if (workbook != null) Marshal.ReleaseComObject(workbook);
                        if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                        // Habilito el botón de validar si hay sustentos cargados
                        if (archivosSustento.Count > 0)
                        {
                            btnValidar.Enabled = true;
                        }
                    };
                    worker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar la plantilla: " + ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBarLoading.Visible = false;
                    lblPorcentaje.Visible = false;
                    lblPorcentaje.Text = "0%";
                    Cursor = Cursors.Default;
                    if (workbook != null)
                    {
                        workbook.Close(false);
                        Marshal.ReleaseComObject(workbook);
                    }
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                    return;
                }
            }
        }

        private void btnArchivos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos permitidos|*.pdf;*.xlsx;*.msg;*.txt;*.png|Todos los archivos|*.*",
                Title = "Seleccionar archivo de sustento",
                Multiselect = true // Permitir seleccionar varios archivos
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    clsArchivoCargadoFechaValor oArchivo = new clsArchivoCargadoFechaValor
                    {
                        cNombreArchivo = Path.GetFileName(filePath),
                        cPathCompleto = filePath,
                        cByteArchivo = File.ReadAllBytes(filePath)
                    };
                    //Valido si el archivo existe con el mismo nombre
                    if (archivosSustento.Any(x => x.cNombreArchivo == oArchivo.cNombreArchivo))
                    {
                        MessageBox.Show($"El archivo {oArchivo.cNombreArchivo} ya ha sido cargado.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    archivosSustento.Add(oArchivo);
                }
                ActualizarCantidadSustentos();
            }
            //Habilito el botón de validar si es que se ha cargado un archivo de Fecha Valor y mínimo un sustento
            if (!string.IsNullOrEmpty(txtRutaArchivo.Text) && archivosSustento.Count > 0)
            {
                btnValidar.Enabled = true;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            //Limpio el grid de datos
            dtgDatos.Rows.Clear();

            //Limpio el dataset de planes de pago actuales
            dsPlanesPagoActuales.Tables.Clear();

            if (!ValidarEntradas()) return;

            progressBarLoading.Visible = true;
            lblPorcentaje.Visible = true;
            progressBarLoading.Minimum = 0;
            progressBarLoading.Value = 0;
            Cursor = Cursors.WaitCursor;

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            worker.DoWork += (s, args) =>
            {
                args.Result = ValidarPlantilla(worker);
            };

            worker.ProgressChanged += (s, args) =>
            {
                progressBarLoading.Value = args.ProgressPercentage;
                lblPorcentaje.Text = $"{args.ProgressPercentage}%";
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                progressBarLoading.Visible = false;
                lblPorcentaje.Visible = false;
                lblPorcentaje.Text = "0%";
                Cursor = Cursors.Default;

                clsImpresionFechaValor dbResp = (clsImpresionFechaValor)args.Result;

                if (dbResp != null) //Validación completa
                {
                    if (dbResp.lsPlantilla.Count > 0)
                    {
                        //Si hay errores en la plantilla, muestro el reporte
                        MessageBox.Show("Se han encontrado los siguientes errores, por favor corregir.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ImprimirReporteErroresImportacion(dbResp.lsPlantilla);
                        btnConsultar.Enabled = false;
                        btnProcesar.Enabled = false;
                    }
                    else
                    {
                        ConfigurarDataGridView();
                        PintarDatosGridView(dbResp);
                        btnConsultar.Enabled = true;
                        btnProcesar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error al validar la plantilla.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            worker.RunWorkerAsync();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Listo la lista lstProcesadasAnteriormente
            lstProcesadasAnteriormente = new List<clsFechaPagoProcesados>();

            //Limpio el DS dsPlanesPagoActuales
            dsPlanesPagoActuales.Tables.Clear();

            //Bloqueo el botón de consultar y procesar para evitar que se ejecute nuevamente mientras se procesa
            btnConsultar.Enabled = false;
            btnProcesar.Enabled = false;

            lblPorcentaje.Visible = true;
            progressBarLoading.Visible = true;
            progressBarLoading.Minimum = 0;
            progressBarLoading.Value = 0;
            Cursor = Cursors.WaitCursor;

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            worker.DoWork += (s, args) =>
            {
                resultadosRecalculados = new List<clsPlanPagoFechaValor>();

                List<clsFechaPagoProcesados> setProcesados = new List<clsFechaPagoProcesados>();

                int totalFilas = dtgDatos.Rows.Count;
                int filasProcesadas = 0;

                foreach (DataGridViewRow row in dtgDatos.Rows.Cast<DataGridViewRow>().Where(r => Convert.ToBoolean(r.Cells["lSeleccionado"].Value)))
                {
                    clsPlanPagoFechaValor fila = ObtenerDatosFila(row);
                    if (fila != null)
                    {
                        //Valido si el registro ya se procesó anteriormente
                        if (ValidarOperacion(fila))
                        {
                            clsFechaPagoProcesados objFilaTmp = new clsFechaPagoProcesados
                            {
                                nNumeroOperacionCanalExterno = fila.nNumeroOperacionCanalExterno,
                                nNumeroCredito = fila.nNumeroCredito
                            };
                            //Si la operación ya se registró anteriormente, lo registro en la lista setProcesados para mostrarlo en un mensaje
                            setProcesados.Add(objFilaTmp);
                            lstProcesadasAnteriormente.Add(objFilaTmp);
                            continue;
                        }
                        clsPlanPagoFechaValor nuevoMontoPagar = RecalcularMontoPagar(fila);

                        //Actualizo el objeto con el nuevo monto a pagar
                        fila.nCapital = nuevoMontoPagar.nCapital;
                        fila.nInteresProgramado = nuevoMontoPagar.nInteresProgramado;
                        fila.nInteresCompensatorio = nuevoMontoPagar.nInteresCompensatorio;
                        fila.nInteresMoratorio = nuevoMontoPagar.nInteresMoratorio;
                        fila.nOtros = nuevoMontoPagar.nOtros;
                        fila.lSeleccionado = nuevoMontoPagar.lSeleccionado;

                        if (!fila.lSeleccionado)
                        {
                            //Desmarco de la grilla
                            dtgDatos.Invoke(new Action(() => row.Cells["lSeleccionado"].Value = CheckState.Unchecked));
                            continue;
                        }

                        resultadosRecalculados.Add(fila);
                    }

                    filasProcesadas++;
                    int porcentaje = (int)(((double)filasProcesadas / totalFilas) * 100);
                    worker.ReportProgress(porcentaje);
                }

                args.Result = setProcesados;
            };

            worker.ProgressChanged += (s, args) =>
            {
                progressBarLoading.Value = args.ProgressPercentage;
                lblPorcentaje.Text = $"{args.ProgressPercentage}%";
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                //Desbloqueo el botón de consultar y procesar
                btnConsultar.Enabled = true;
                btnProcesar.Enabled = true;

                progressBarLoading.Visible = false;
                lblPorcentaje.Visible = false;
                lblPorcentaje.Text = "0%";
                Cursor = Cursors.Default;

                //Verifico si hubo errores durante la consulta
                if (args.Error != null)
                {
                    MessageBox.Show($"Error al consultar: {args.Error.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<clsFechaPagoProcesados> setProcesados = (List<clsFechaPagoProcesados>)args.Result; //Lista de procesados

                //Si la lista de procesados tiene elementos, muestro un mensaje con los numeros de operación que ya se procesaron, separandolo por salto de linea
                if (setProcesados.Count > 0)
                {
                    var message = new StringBuilder();
                    message.AppendLine("Los siguientes números de operación ya han sido procesados anteriormente y se desmarcarán de la lista:");
                    foreach (var item in setProcesados)
                    {
                        message.AppendLine($"- {item.nNumeroOperacionCanalExterno}, correspondiente al crédito: {item.nNumeroCredito}");
                    }

                    MessageBox.Show(message.ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Desmarco la casilla de los registros que ya se procesaron
                dtgDatos.Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow row in dtgDatos.Rows.Cast<DataGridViewRow>())
                    {
                        //Obtenemos los valores de las celdas
                        long nNumeroOperacionCanalExterno = Convert.ToInt64(row.Cells["nNumeroOperacionCanalExterno"].Value);
                        long nNumeroCredito = Convert.ToInt64(row.Cells["nNumeroCredito"].Value);

                        //Buscamos el registro coincidente
                        clsFechaPagoProcesados registroActual = setProcesados.Find(x => x.nNumeroOperacionCanalExterno == nNumeroOperacionCanalExterno && x.nNumeroCredito == nNumeroCredito);

                        if (registroActual != null)
                        {
                            row.Cells["lSeleccionado"].Value = CheckState.Unchecked;

                            //Elimino el registro de la lista para evitar procesarlo de nuevo
                            setProcesados.Remove(registroActual);
                        }
                    }
                    dtgDatos.Columns[0].HeaderCell.Value = CheckState.Unchecked;
                }));

                if (resultadosRecalculados.Count == 0 && setProcesados.Count == 0)
                {
                    MessageBox.Show("No se ha seleccionado ninguna fila para recalcular.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MostrarResultados(resultadosRecalculados);

                //Si todo está bien, habilito el botón de procesar
                btnProcesar.Enabled = true;
            };

            worker.RunWorkerAsync();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarEntradas()) return;

                DataTable resultadosRecalculadosTMP = DataTableToList.CreateDataTable(resultadosRecalculados);

                //Valido si algunos de los registros de resultadosRecalculadosTMP se encuentran en lstProcesadasAnteriormente para mostrar mensaje y desmarcarlos
                if (lstProcesadasAnteriormente.Count > 0)
                {
                    var lstProcesadas = lstProcesadasAnteriormente.Select(x => x.nNumeroOperacionCanalExterno.ToString()).ToList();
                    var lstProcesadasTMP = resultadosRecalculadosTMP.AsEnumerable().Where(x => lstProcesadas.Contains(x.Field<long>("nNumeroOperacionCanalExterno").ToString()) && lstProcesadas.Contains(x.Field<long>("nNumeroCredito").ToString())).ToList();

                    if (lstProcesadasTMP.Count > 0)
                    {
                        var message = new StringBuilder();
                        message.AppendLine("Los siguientes números de operación ya han sido procesados anteriormente y se desmarcarán de la lista:");
                        foreach (var numeroOperacion in lstProcesadasTMP)
                        {
                            message.AppendLine($"- {numeroOperacion["nNumeroOperacionCanalExterno"]}");
                        }

                        MessageBox.Show(message.ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Desmarco la casilla de los registros que ya se procesaron
                        foreach (DataRow row in lstProcesadasTMP)
                        {
                            row["lSeleccionado"] = false;
                        }

                        //Desmarco el checkbox de la cabecera
                        dtgDatos.Columns[0].HeaderCell.Value = CheckState.Unchecked;
                    }
                }

                if (!resultadosRecalculadosTMP.AsEnumerable().Any(x => x.Field<bool>("lSeleccionado")))
                {
                    MessageBox.Show("No se ha seleccionado ninguna fila para procesar.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Muestro Mensaje con la cantidad de registros seleccionados con opción de continuar o no
                DialogResult dialogResult = MessageBox.Show($"Se han seleccionado {resultadosRecalculadosTMP.AsEnumerable().Count(x => x.Field<bool>("lSeleccionado"))} registros para procesar. ¿Desea continuar?", cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                //Filtro las filas seleccionadas
                resultadosRecalculadosTMP = resultadosRecalculadosTMP.AsEnumerable().Where(x => x.Field<bool>("lSeleccionado")).CopyToDataTable();

                progressBarLoading.Visible = true;
                lblPorcentaje.Visible = true;
                progressBarLoading.Minimum = 0;
                progressBarLoading.Value = 0;
                Cursor = Cursors.WaitCursor;

                BackgroundWorker worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };

                worker.DoWork += (s, args) =>
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { Timeout = TimeSpan.FromMinutes(1) }))
                    {
                        try
                        {
                            int filasProcesadas = 0;
                            foreach (DataRow item in resultadosRecalculadosTMP.Rows)
                            {
                                ActualizarCredito(item, worker);
                                filasProcesadas++;
                                int porcentaje = (int)(((double)filasProcesadas / resultadosRecalculadosTMP.Rows.Count) * 100);
                                progressBarLoading.Invoke(new Action(() =>
                                {
                                    progressBarLoading.Value = porcentaje;
                                    lblPorcentaje.Text = $"{porcentaje}%";
                                    lblPorcentaje.Refresh();
                                }));
                            }
                            int idRegistro = RegistrarCabecera(resultadosRecalculadosTMP);
                            RegistrarDocumentosDeSustento(idRegistro);
                            scope.Complete();
                        }
                        catch (TransactionAbortedException ex)
                        {
                            MessageBox.Show($"La operación fue anulada: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (TimeoutException ex)
                        {
                            MessageBox.Show($"La operación excedió el tiempo de espera: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error en la opración: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            scope.Dispose(); // Liberar recursos en todos los casos
                        }
                    }
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    progressBarLoading.Visible = false;
                    lblPorcentaje.Visible = false;
                    lblPorcentaje.Text = "0%";
                    Cursor = Cursors.Default;

                    ActualizarGridConResultados(resultadosRecalculadosTMP);
                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el procesamiento: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void lblCantidadSustentos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (archivosSustento.Count > 0)
            {
                if (frmCargaArchivosInstancia == null || frmCargaArchivosInstancia.IsDisposed)
                {
                    frmCargaArchivosInstancia = new frmCargarArchivosFechaValor(archivosSustento, Name);

                    frmCargaArchivosInstancia.ArchivosActualizados += (formularioCargaArchivos, nuevaLista) =>
                    {
                        archivosSustento = nuevaLista;
                        ActualizarCantidadSustentos();
                    };
                    frmCargaArchivosInstancia.FormClosed += FrmCargaArchivos_FormClosed;
                }
                frmCargaArchivosInstancia.Show();
                frmCargaArchivosInstancia.BringToFront();
            }
            else
            {
                MessageBox.Show("No se cargó ningún archivo", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmCargaArchivos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCargaArchivosInstancia = null;
        }

        private void txtSustento_TextChanged(object sender, EventArgs e)
        {
            //Cuento la cantidad de caracteres ingresados en el campo de sustento y voy actualizando el label lblContador
            lblContador.Text = txtSustento.Text.Trim().Length + "/250";
        }

        private void dtgDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Actualizo el valor de la columna lSeleccionado del grid en resultadosRecalculados
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = dtgDatos.Rows[e.RowIndex];
                clsPlanPagoFechaValor fila = resultadosRecalculados.FirstOrDefault(x => x.nNumeroOperacionCanalExterno == Convert.ToInt32(row.Cells["nNumeroOperacionCanalExterno"].Value) && x.nNumeroCredito == Convert.ToInt64(row.Cells["nNumeroCredito"].Value));
                if (fila != null)
                {
                    fila.lSeleccionado = Convert.ToBoolean(row.Cells["lSeleccionado"].Value);
                }

                //Verifico si todas las filas están marcadas y actualizo el checkbox de la cabecera
                dtgDatos.Columns[0].HeaderCell.Value = TodasLasFilasMarcadas() ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0) // Cabecera
            {
                dtgDatos.ClearSelection();

                CheckState nuevoEstado = (TodasLasFilasMarcadas()) ? CheckState.Unchecked : CheckState.Checked;

                //Deshabilito el botón de consultar y procesar para evitar que se ejecute mientras se procesa
                btnConsultar.Enabled = false;
                btnProcesar.Enabled = false;
                progressBarLoading.Visible = true;
                lblPorcentaje.Visible = true;
                progressBarLoading.Minimum = 0;
                progressBarLoading.Value = 0;
                Cursor = Cursors.WaitCursor;

                BackgroundWorker worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };

                worker.DoWork += (s, args) =>
                {
                    // Marcar/desmarcar todos los checkbox
                    for (int i = 0; i < dtgDatos.Rows.Count; i++)
                    {
                        dtgDatos.Invoke(new Action(() => dtgDatos.Rows[i].Cells[0].Value = nuevoEstado));
                        worker.ReportProgress(i + 1);
                    }
                };

                worker.ProgressChanged += (s, args) =>
                {
                    progressBarLoading.Value = args.ProgressPercentage * 100 / dtgDatos.Rows.Count;
                    lblPorcentaje.Text = $"{args.ProgressPercentage * 100 / dtgDatos.Rows.Count}%";
                    lblPorcentaje.Refresh();
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    //Habilito el botón de consultar y procesar (SOLO SI resultadosRecalculados TIENE DATA)
                    btnConsultar.Enabled = true;
                    if (resultadosRecalculados.Count > 0)
                    {
                        btnProcesar.Enabled = true;
                    }
                    progressBarLoading.Visible = false;
                    lblPorcentaje.Visible = false;
                    lblPorcentaje.Text = "0%";
                    Cursor = Cursors.Default;

                    dtgDatos.Columns[0].HeaderCell.Value = nuevoEstado;

                    dtgDatos.RefreshEdit(); // Me aseguro que la edición se refresque
                    dtgDatos.Refresh();
                };
                worker.RunWorkerAsync();
            }
        }

        private void dtgDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0) // Cabecera
            {
                e.PaintBackground(e.CellBounds, true); //Pinto el fondo
                e.PaintContent(e.CellBounds); //Pinto el contenido

                bool lMarcado = TodasLasFilasMarcadas();

                //Dibujo el checkbox de la cabecera
                ControlPaint.DrawCheckBox(
                    e.Graphics,
                    e.CellBounds.X + (e.CellBounds.Width - 16) / 2, //Centraddo horizontal
                    e.CellBounds.Y + (e.CellBounds.Height - 16) / 2, //Centrado vertical
                    15, 15,
                    lMarcado ? ButtonState.Checked : ButtonState.Flat);

                e.Handled = true;
            }
        }

        private void dtgDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDatos.IsCurrentCellDirty) //Valido si la celda actual ha cambiado
            {
                dtgDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //Verifico si todas las filas están marcadas y actualizo el checkbox de la cabecera
                if (dtgDatos.CurrentCell.ColumnIndex == 0)
                {
                    dtgDatos.Columns[0].HeaderCell.Value = TodasLasFilasMarcadas() ? CheckState.Checked : CheckState.Unchecked;
                }
            }
        }

        #endregion

        #region Overrides

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //Me aseguro de cerrar todas las instancias de Excel
            if (excelApp != null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
                excelApp = null;
            }
        }

        #endregion
    }
}