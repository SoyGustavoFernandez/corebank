using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CNE.Presentacion
{
    public partial class frmRptComisionesCanalesElec : frmBase
    {
        #region Variables Globales

        private clsCNComisionesCanalesElec oCNComisionesCanalesElec = new clsCNComisionesCanalesElec();

        private DateTime dFecSystem = clsVarGlobal.dFecSystem;
        private string cTituloMsjes = "Reporte de Comisiones de Canales Externos";
        private clsCNPdp cnRptPdp = new clsCNPdp();
        private string InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private enum StatusCode
        {
            OK = 200,
            BadRequest = 400
        }

        static class eAsumeComs
        {
            public const string CLA = "Caja los Andes";
            public const string Cliente = "Cliente";
        }

        static class eModalidadComs
        {
            public const string Porcentual = "Valor Porcentual";
            public const string Fijo = "Monto Fijo";
        }

        static class eRangoComs
        {
            public const string Cantidad = "Cantidad";
            public const string Monto = "Monto";
        }

        static class eComsEspeciales
        {
            public const int BN = 4;
            public const int Niubiz = 10;
        }

        private class RangoComision
        {
            public int nNumeroOrden { get; set; }
            public decimal nMontoMin { get; set; }
            public decimal nMontoMax { get; set; }
            public decimal nComision { get; set; }
        }

        private class CantidadComision
        {
            public int idPago { get; set; }
            public int idComision { get; set; }
        }

        #endregion

        #region Metodos Publicos

        public frmRptComisionesCanalesElec()
        {
            InitializeComponent();
            cargaComboCanales();
            cargaDataPickers();
        }

        #endregion

        #region Metodos Privados

        private void cargaComboCanales()
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

            this.cboCanalElec.DataSource = listCanales;
            this.cboCanalElec.ValueMember = "idCanal";
            this.cboCanalElec.DisplayMember = "cNombreCanal";
        }

        private void cargaDataPickers()
        {
            this.dtpFechaInicio.Value = new DateTime(dFecSystem.Year, dFecSystem.Month, 1);
            this.dtpFechaFin.Value = dFecSystem.Date;
        }

        private void obtenerComisiones()
        {
            int idCanal = (int)this.cboCanalElec.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;

            DataTable dtResumenComisiones;

            if (!calcularComisiones(idCanal, dFechaInicio, dFechaFin, false, out dtResumenComisiones)) return;

            //Mostrar en el formulario
            this.dtgComisiones.DataSource = dtResumenComisiones;

            foreach (DataGridViewColumn column in dtgComisiones.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dtgComisiones.Refresh();
            this.dtgComisiones.ClearSelection();
        }

        private void obtenerDetalleComisiones()
        {
            DialogResult result = MessageBox.Show("¿Desea generar el reporte excel?", "Detalle de Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                return;

            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            int idCanal = (int)this.cboCanalElec.SelectedValue;

            DataTable dtDetalleComisiones;
            if (!calcularComisiones(idCanal, dFechaInicio, dFechaFin, true, out dtDetalleComisiones))
            {
                return;
            }

            // Crear Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook oWorkBook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = oWorkBook.Worksheets[1];

            var colorCabecera = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(214, 234, 248));

            // Ancho y alineamiento de columnas
            Excel.Range column = worksheet.Columns[1];
            column.ColumnWidth = 5;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[2];
            column.ColumnWidth = 12;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[3];
            column.ColumnWidth = 12;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[4];
            column.ColumnWidth = 12;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[5];
            column.ColumnWidth = 12;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[6];
            column.ColumnWidth = 17;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[7];
            column.ColumnWidth = 17;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[8];
            column.ColumnWidth = 17;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[9];
            column.ColumnWidth = 17;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[10];
            column.ColumnWidth = 12;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[11];
            column.ColumnWidth = 25;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[12];
            column.ColumnWidth = 25;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[13];
            column.ColumnWidth = 25;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            column = worksheet.Columns[14];
            column.ColumnWidth = 15;
            column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Titulo
            worksheet.Cells[1, 1].Value = "Reporte: Reporte Detalle de Comisiones";
            Excel.Range range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 14]];
            range.Merge();
            range.Font.Size = 12;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Font.Bold = true;
            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            // Datos Sub titulo
            worksheet.Cells[2, 1].Value = "Desde: " + dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[2, 3].Value = "Hasta: " + dtpFechaFin.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[2, 5].Value = "Usuario: " + clsVarGlobal.User.cWinUser + " - " + clsVarGlobal.User.idUsuario;
            worksheet.Cells[2, 9].Value = "Canal: " + this.cboCanalElec.Text;
            range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 12]];
            range.Font.Size = 10;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Cabeceras
            Excel.Range cell = worksheet.Cells[3, 1];
            cell.Value = "N°";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 2];
            cell.Value = "FECHA CARGA";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 3];
            cell.Value = "HORA CARGA";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 4];
            cell.Value = "N. CUENTA";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 5];
            cell.Value = "MONEDA";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 6];
            cell.Value = "MONTO PAGADO";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 7];
            cell.Value = "COMISIÓN LOS ANDES";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 8];
            cell.Value = "COMISIÓN CLIENTE";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 9];
            cell.Value = "COMISIÓN TOTAL";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 10];
            cell.Value = "ITF";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 11];
            cell.Value = "CANAL DE SERVICIO";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 12];
            cell.Value = "ZONA";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 13];
            cell.Value = "MODALIDAD DE PAGO";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            cell = worksheet.Cells[3, 14];
            cell.Value = "TIPO DE PAGO";
            cell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            range = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 14]];
            range.Interior.Color = colorCabecera;
            range.Font.Size = 10;
            range.Font.Bold = true;

            // Insercion de datos
            int fila = 4;
            foreach (DataRow row in dtDetalleComisiones.Rows)
            {
                worksheet.Cells[fila, 1].Value = row["nRowNumber"].ToString();
                DateTime fechaPago = (DateTime)row["dFechaPago"];
                worksheet.Cells[fila, 2].Value = fechaPago;
                worksheet.Cells[fila, 3].Value = row["dHoraPago"].ToString();
                worksheet.Cells[fila, 4].Value = row["nCuenta"].ToString();
                worksheet.Cells[fila, 5].Value = row["cMoneda"].ToString();
                worksheet.Cells[fila, 6].Value = row["nMontoPagado"].ToString();
                worksheet.Cells[fila, 7].Value = row["nComisionLosAndes"].ToString();
                worksheet.Cells[fila, 8].Value = row["nComisionCliente"].ToString();
                worksheet.Cells[fila, 9].Value = row["nComisionTotal"].ToString();
                worksheet.Cells[fila, 10].Value = row["nITF"].ToString();
                worksheet.Cells[fila, 11].Value = row["cCanalServicio"].ToString();
                worksheet.Cells[fila, 12].Value = row["cZona"].ToString();
                worksheet.Cells[fila, 13].Value = row["cModalidadPago"].ToString();
                worksheet.Cells[fila, 14].Value = row["cTipoPago"].ToString();
                fila++;
            }

            range = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[fila, 14]];
            range.Font.Size = 10;

            // Formato numero decimal
            range = worksheet.Range[worksheet.Cells[4, 6], worksheet.Cells[fila, 10]];
            range.NumberFormat = "0.00";

            // Seleccionar ruta de guardado
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = this.InitialDirectory;
            saveFileDialog.FileName = string.Format("Reporte Detalle de Comisiones {0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                this.InitialDirectory = Path.GetDirectoryName(rutaArchivo);
                oWorkBook.SaveAs(rutaArchivo);
            }

            oWorkBook.Close(false);
            excelApp.Quit();

            liberarObjecto(worksheet);
            liberarObjecto(worksheet);
            liberarObjecto(excelApp);
        }

        private bool calcularComisiones(int idCanal, DateTime dFechaInicio, DateTime dFechaFin, bool lObtenerDetalle, out DataTable dtCalculoComisiones)
        {
            // Obtener pagos desde la API
            var callResult = oCNComisionesCanalesElec.ObtenerXmlHPagosCargados(idCanal, dFechaInicio, dFechaFin);
            if (callResult == null)
            {
                dtCalculoComisiones = null;
                return false;
            }

            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show("Error al obtener los Pagos por Canales: " + callResult.Error,
                            "Reporte de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtCalculoComisiones = null;
                return false;
            }

            DataTable dtPagos = callResult.Data;
            if (string.IsNullOrEmpty(dtPagos.Rows[0]["xmlPagos"].ToString()))
            {
                MessageBox.Show("No se encontraron pagos, intente con otros rangos de fechas.",
                            "Reporte de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtCalculoComisiones = null;
                return false;
            }

            DataSet dsConfComisiones = this.oCNComisionesCanalesElec.ObtenerConfComisiones(idCanal);

            if (dsConfComisiones.Tables[0].Rows.Count <= 0 || dsConfComisiones.Tables[1].Rows.Count <= 0)
            {
                MessageBox.Show("No se encontraron configuracion para el Canal seleccionado.",
                            "Reporte de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtCalculoComisiones = null;
                return false;
            }

            DataTable dtPagosCompleto = this.oCNComisionesCanalesElec.ObtenerComisionesCore(dtPagos.Rows[0]["xmlPagos"].ToString());

            if (dtPagosCompleto.Rows.Count <= 0)
            {
                MessageBox.Show("Error al conectar los pagos de los canales externos con el CoreBank",
                            "Reporte de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtCalculoComisiones = null;
                return false;
            }

            dtCalculoComisiones = procesasComisiones(idCanal, dtPagosCompleto, dsConfComisiones, lObtenerDetalle);
            return true;
        }

        private DataTable procesasComisiones(int idCanal, DataTable dtPagos, DataSet dsConfComisiones, bool lObtenerDetalle)
        {
            List<clsConfigComisiones> listConfComisiones = DataTableToList.ConvertTo<clsConfigComisiones>(dsConfComisiones.Tables[0]) as List<clsConfigComisiones>;
            List<clsDetalleConfigComisiones> listConfComisionesD = DataTableToList.ConvertTo<clsDetalleConfigComisiones>(dsConfComisiones.Tables[1]) as List<clsDetalleConfigComisiones>;

            foreach (var item in listConfComisiones)
                item.listDetalleConfigComisiones = listConfComisionesD.FindAll(x => x.idMConfComision == item.idMConfComision);

            var listPagosCLAxCant = new List<CantidadComision>();
            
            foreach (DataRow item in dtPagos.Rows)
            {
                int idCanalServicio = item.Field<int>("idCanalServicio");
                DateTime dFechaPago = item.Field<DateTime>("dFechaPago").Date;
                decimal nMontoPagado = item.Field<decimal>("nMontoPagado");

                var listConf = listConfComisiones.FindAll(x => x.idCanalServicio == idCanalServicio);
                bool lComisionMixta = listConf.GroupBy(x => x.idCanalServicio)
                                    .Any(g => g.Count() > 1);

                string cTipoPago = (lComisionMixta) ? "MIXTO" : "TOTAL";
                item.SetField<string>("cTipoPago", cTipoPago);

                var listConfxAplicar = listConf.FindAll(x => x.dFechaInicioVigencia <= dFechaPago && x.dFechaFinVigencia >= dFechaPago);

                if(listConfxAplicar.Count <= 0)
                    continue;

                if(listConfxAplicar.Any(x => x.cAsumeComision == eAsumeComs.Cliente))
                {
                    var listDetalleConf = listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.Cliente).listDetalleConfigComisiones;
                    bool lComisionPorcentual = (listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.Cliente).cTipoModalidadPago == eModalidadComs.Porcentual) ? true : false;

                    listDetalleConf = listDetalleConf.OrderBy(x => x.nMontoCuotaMin).ToList();

                    var rangosDeComision = listDetalleConf.Select((detalle, index) => new RangoComision
                    {
                        nNumeroOrden = index + 1,
                        nMontoMin = detalle.nMontoCuotaMin,
                        nMontoMax = detalle.nMontoCuotaMax,
                        nComision = (lComisionPorcentual) ? detalle.nPorcentajeCosto : detalle.nMontoCosto
                    }).ToList();

                    var rangoActual = rangosDeComision.Find(x => nMontoPagado >= x.nMontoMin && nMontoPagado <= x.nMontoMax);
                    if (rangoActual != null)
                    {
                        decimal nMontoComisionAnterior = (rangoActual.nNumeroOrden == 1) ? rangoActual.nComision : rangosDeComision.Find(x => x.nNumeroOrden == rangoActual.nNumeroOrden - 1).nComision;
                        decimal nMontoSinComision = nMontoPagado - nMontoComisionAnterior;
                        decimal nValorComision = (nMontoSinComision >= rangoActual.nMontoMin && nMontoSinComision <= rangoActual.nMontoMax) ? rangoActual.nComision : rangosDeComision.Find(x => x.nNumeroOrden == rangoActual.nNumeroOrden - 1).nComision;
                        decimal nMontoComision = (lComisionPorcentual) ? nMontoPagado * ((nValorComision / 100)) : nValorComision;

                        string cModalidadPago = (lComisionPorcentual) ? eModalidadComs.Porcentual : eModalidadComs.Fijo;

                        item.SetField<decimal>("nComisionCliente", nMontoComision);
                        item.SetField<string>("cModalidadPago", cModalidadPago);

                        //Comisiones Especiales
                        if (idCanal == eComsEspeciales.BN && (nMontoPagado - nMontoComision) >= rangosDeComision.Max(rango => rango.nMontoMin))
                        {
                            decimal nValorPorcentualCom = ((decimal)clsVarApl.dicVarGen["nComsEspecialBN"] / 100);
                            decimal nMontoComisionBN = ((nMontoPagado / (1 + nValorPorcentualCom))* nValorPorcentualCom) - nMontoComision;
                            item.SetField<decimal>("nComisionLosAndes", nMontoComisionBN);
                        }
                    }
                }

                if (listConfxAplicar.Any(x => x.cAsumeComision == eAsumeComs.CLA))
                {
                    var listDetalleConfM = listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.CLA);

                    if (listDetalleConfM.cTipoRango == eRangoComs.Monto)
                    {
                        var listDetalleConf = listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.CLA).listDetalleConfigComisiones;
                        bool lComisionPorcentual = (listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.CLA).cTipoModalidadPago == eModalidadComs.Porcentual) ? true : false;

                        listDetalleConf = listDetalleConf.OrderBy(x => x.nMontoCuotaMin).ToList();

                        var rangosDeComision = listDetalleConf.Select((detalle, index) => new RangoComision
                        {
                            nNumeroOrden = index + 1,
                            nMontoMin = detalle.nMontoCuotaMin,
                            nMontoMax = detalle.nMontoCuotaMax,
                            nComision = (lComisionPorcentual) ? detalle.nPorcentajeCosto : detalle.nMontoCosto
                        }).ToList();

                        var rangoActual = rangosDeComision.Find(x => nMontoPagado >= x.nMontoMin && nMontoPagado <= x.nMontoMax);
                        if (rangoActual != null)
                        {
                            decimal nMontoComisionAnterior = (rangoActual.nNumeroOrden == 1) ? rangoActual.nComision : rangosDeComision.Find(x => x.nNumeroOrden == rangoActual.nNumeroOrden - 1).nComision;
                            decimal nMontoSinComision = nMontoPagado - nMontoComisionAnterior;
                            decimal nValorComision = (nMontoSinComision >= rangoActual.nMontoMin && nMontoSinComision <= rangoActual.nMontoMax) ? rangoActual.nComision : rangosDeComision.Find(x => x.nNumeroOrden == rangoActual.nNumeroOrden - 1).nComision;
                            decimal nMontoComision = (lComisionPorcentual) ? nMontoPagado * ((nValorComision / 100)) : nValorComision;

                            string cModalidadPago = (lComisionPorcentual) ? eModalidadComs.Porcentual : eModalidadComs.Fijo;

                            item.SetField<decimal>("nComisionLosAndes", nMontoComision);

                            if (string.IsNullOrEmpty(item.Field<string>("cModalidadPago")))
                                item.SetField<string>("cModalidadPago", cModalidadPago);
                            else
                                item.SetField<string>("cModalidadPago", item.Field<string>("cModalidadPago") + " - " + cModalidadPago);

                            //Comisiones Especiales
                            if (idCanal == eComsEspeciales.Niubiz)
                            {
                                decimal nMontoFijo = (decimal)clsVarApl.dicVarGen["nComsEspecialNiubiz"];
                                decimal nMontoComisionNiubiz = item.Field<decimal>("nComisionLosAndes") + nMontoFijo;
                                item.SetField<decimal>("nComisionLosAndes", nMontoComisionNiubiz);
                            }
                        }
                    }
                    else
                    {
                        bool lComisionPorcentual = (listConfxAplicar.Find(x => x.cAsumeComision == eAsumeComs.CLA).cTipoModalidadPago == eModalidadComs.Porcentual) ? true : false;

                        var objComision = new CantidadComision()
                        {
                            idPago = item.Field<int>("idPagosCargados"),
                            idComision = listDetalleConfM.idMConfComision
                        };

                        listPagosCLAxCant.Add(objComision);

                        string cModalidadPago = (lComisionPorcentual) ? eModalidadComs.Porcentual : eModalidadComs.Fijo;

                        if (string.IsNullOrEmpty(item.Field<string>("cModalidadPago")))
                            item.SetField<string>("cModalidadPago", cModalidadPago);
                        else
                            item.SetField<string>("cModalidadPago", item.Field<string>("cModalidadPago") + " - " + cModalidadPago);
                    }
                }
            }

            if (listPagosCLAxCant.Count > 0)
            {
                foreach (DataRow item in dtPagos.Rows)
                {
                    decimal nMontoPagado = item.Field<decimal>("nMontoPagado");

                    if (listPagosCLAxCant.Any(objeto => objeto.idPago == item.Field<int>("idPagosCargados")))
                    {
                        int idConfComision = listPagosCLAxCant.Find(objeto => objeto.idPago == item.Field<int>("idPagosCargados")).idComision;
                        int nCantidadPagos = listPagosCLAxCant.FindAll(objeto => objeto.idComision == idConfComision).Count();
                        var listConfxAplicar = listConfComisionesD.FindAll(x => x.idMConfComision == idConfComision);

                        var listConfMaestro = listConfComisiones.Find(x => x.idMConfComision == listConfxAplicar.First().idMConfComision);
                        bool lComisionPorcentual = (listConfMaestro.cTipoModalidadPago == eModalidadComs.Porcentual) ? true : false;


                        decimal nValorComision = (lComisionPorcentual) ? listConfxAplicar.Find(x => x.nCantidadMin <= nCantidadPagos && x.nCantidadMax >= nCantidadPagos).nPorcentajeCosto :
                                                                         listConfxAplicar.Find(x => x.nCantidadMin <= nCantidadPagos && x.nCantidadMax >= nCantidadPagos).nMontoCosto;
                        decimal nMontoComision = (lComisionPorcentual) ? nMontoPagado * ((nValorComision / 100)) : nValorComision;

                        string cModalidadPago = (lComisionPorcentual) ? eModalidadComs.Porcentual : eModalidadComs.Fijo;

                        item.SetField<decimal>("nComisionLosAndes", nMontoComision);

                        if (string.IsNullOrEmpty(item.Field<string>("cModalidadPago")))
                            item.SetField<string>("cModalidadPago", cModalidadPago);
                        else
                            item.SetField<string>("cModalidadPago", item.Field<string>("cModalidadPago") + " - " + cModalidadPago);
                    }
                }
            }

            dtPagos.Columns.Add("nRowNumber", typeof(int));

            foreach (DataRow item in dtPagos.Rows)
            {
                int nRowNumber = dtPagos.Rows.IndexOf(item) + 1;
                item.SetField<int>("nRowNumber", nRowNumber);
                decimal nMontoTotal = item.Field<decimal>("nComisionLosAndes") + item.Field<decimal>("nComisionCliente");
                item.SetField<decimal>("nComisionTotal", nMontoTotal);

                decimal nMontoSinComision = item.Field<decimal>("nMontoPagado") - item.Field<decimal>("nComisionCliente");
                int canUnidadesITF = (int)Math.Round(nMontoSinComision / 1000, 1);
                decimal ValorITF = (decimal)clsVarApl.dicVarGen["nValorITFComs"];
                decimal nMontoITF = canUnidadesITF * (ValorITF / 100);
                item.SetField<decimal>("nITF", nMontoITF);
            }

            if (!lObtenerDetalle)
            {
                DataTable dtConsolidado = new DataTable();
                dtConsolidado.Columns.Add("Canal de Servicio", typeof(string));
                dtConsolidado.Columns.Add("Cantidad de Pagos", typeof(int));
                dtConsolidado.Columns.Add("Total Montos Operacion", typeof(string));
                dtConsolidado.Columns.Add("Total Comision del Cliente", typeof(string));
                dtConsolidado.Columns.Add("Total Comision Los Andes", typeof(string));

                var groupedData = from row in dtPagos.AsEnumerable()
                                  group row by row.Field<string>("cCanalServicio") into grp
                                  select new
                                  {
                                      CanalServicio = grp.Key,
                                      CantidadRegistros = grp.Count(),
                                      TotalMontosOperacion = grp.Sum(r => r.Field<decimal>("nMontoPagado") - r.Field<decimal>("nComisionCliente")),
                                      TotalComisionCliente = grp.Sum(r => r.Field<decimal>("nComisionCliente")),
                                      TotalComisionCaja = grp.Sum(r => r.Field<decimal>("nComisionLosAndes"))
                                  };

                foreach (var group in groupedData)
                {
                    dtConsolidado.Rows.Add(
                        group.CanalServicio, 
                        group.CantidadRegistros, 
                        "S/. " + Math.Round(group.TotalMontosOperacion, 2),
                        "S/. " + Math.Round(group.TotalComisionCliente,2),
                        "S/. " + Math.Round(group.TotalComisionCaja,2)
                        );
                }
                return dtConsolidado;
            }

            return dtPagos;
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
        
        #endregion

        #region Eventos

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            obtenerComisiones();
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            obtenerDetalleComisiones();
        }
        
        #endregion
    }
}
