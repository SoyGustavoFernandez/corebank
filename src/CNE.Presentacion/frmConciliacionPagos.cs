using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmConciliacionPagos : frmBase
    {
        #region Variables

        private List<object> listCanales;
        private DateTime dFechaSis = clsVarGlobal.dFecSystem;
        private string InitialDirectory = "C:\\";
        private clsCNConciliacionPagos API = new clsCNConciliacionPagos();
        private DataTable dtPagosCargados = new DataTable();
        private DataTable dtPagosCoreBank = new DataTable();

        private enum TipoCarga
        {
            Manual = 1,
            Automatico = 2
        }
        private enum StatusCode
        {
            OK = 200,
            BadRequest = 400
        }
        private enum TipoTransaccion
        {
            Pago = 1,
            Extorno = 2
        }

        #endregion

        #region Metodos Publicos

        public frmConciliacionPagos()
        {
            InitializeComponent();
            CargaComboCanales();
            CargaComboArchivosCargados();
            LimpiaFormulario();
        }

        #endregion

        #region Metodos Privados

        private void CargaComboCanales()
        {
            var dtCanales = new clsCNConciliacionPagos().ObtenerConfiguracionCanalesElectronicos();

            List<object> listCanales = new List<object>();

            foreach (DataRow row in dtCanales.Rows)
            {
                var objeto = new
                {
                    idCanal = Convert.ToInt32(row["idCanal"]),
                    cNombreCanal = row["cNombreCanal"].ToString(),
                    idTipoCarga = Convert.ToInt32(row["idTipoCarga"]),
                    cExtencion = row["cExtencion"].ToString(),
                    lHabilitaPagos = Convert.ToBoolean(row["lHabilitaPagos"]),
                };
                listCanales.Add(objeto);
            }

            this.cboCanalesElec.DataSource = listCanales;
            this.cboCanalesElec.ValueMember = "idCanal";
            this.cboCanalesElec.DisplayMember = "cNombreCanal";

            this.cboCanalesElec2.DataSource = listCanales;
            this.cboCanalesElec2.ValueMember = "idCanal";
            this.cboCanalesElec2.DisplayMember = "cNombreCanal";

            this.listCanales = listCanales;
        }

        private void CargaComboArchivosCargados()
        {
            dynamic objCanal = canal();
            DateTime dFechaCarga = this.dtpFechaCarga.Value;

            var callResult = API.ObtenerArchivosCargados(dFechaCarga, objCanal.idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtArchivosCargados = callResult.Data;

            if (dtArchivosCargados.Rows.Count <= 0)
            {
                this.cboArchivoCargado.DataSource = null;
                this.cboArchivoCargado2.DataSource = null;
                return;
            }

            this.cboArchivoCargado.DataSource = dtArchivosCargados;
            this.cboArchivoCargado.ValueMember = "idCabecera";
            this.cboArchivoCargado.DisplayMember = "cArchivoCargado";

            this.cboArchivoCargado2.DataSource = dtArchivosCargados;
            this.cboArchivoCargado2.ValueMember = "idCabecera";
            this.cboArchivoCargado2.DisplayMember = "cArchivoCargado";
            this.cboArchivoCargado2.SelectedIndex = cboArchivoCargado2.Items.Count - 1;

            if (this.cboArchivoCargado.Items.Count > 0)
                this.cboArchivoCargado.SelectedIndex = this.cboArchivoCargado.Items.Count - 1;
        }

        private void LimpiaFormulario()
        {
            this.dtpFechaCarga.ValueChanged -= new System.EventHandler(this.dtpFechaCarga_ValueChanged);
            this.dtpFechaCarga.Value = dFechaSis;
            this.dtpFechaConci.Value = dFechaSis;
            btnCargar.Enabled = false;
            btnCargar.Visible = false;
            btnEjecutar.Enabled = false;
            btnEjecutar.Visible = false;
            btnAbsolver.Enabled = false;
            cboArchivoCargado2.Enabled = false;
            this.dtpFechaCarga.ValueChanged += new System.EventHandler(this.dtpFechaCarga_ValueChanged);
            cboCanalesElec_SelectedIndexChanged(null, null);
            dtpFechaCarga_ValueChanged(null, null);
            tabControl_SelectedIndexChanged(null, null);
        }

        private void HabilitaOpcionCarga(int idTipoCarga)
        {
            if (idTipoCarga == (int)TipoCarga.Manual)
            {
                btnCargar.Visible = true;
                btnEjecutar.Visible = false;
            }
            else
            {
                btnCargar.Visible = false;
                btnEjecutar.Visible = true;
            }
        }

        private void HabilitaOpcionPago(bool lHabilitaPagos)
        {
            if (lHabilitaPagos)
                this.btnPagar.Visible = true;
            else
                this.btnPagar.Visible = false;
        }

        private dynamic canal()
        {
            var listCanalesConv = (this.listCanales ?? Enumerable.Empty<object>()).Cast<dynamic>();
            return listCanalesConv.FirstOrDefault(x => x.idCanal == (int)this.cboCanalesElec.SelectedValue);
        }

        private void ProcesarDatos()
        {
            dynamic objCanal = canal();
            DateTime dFechaCarga = this.dtpFechaCarga.Value;
            String ruta = string.Empty;
            MultipartFormDataContent formData = new MultipartFormDataContent();

            if (objCanal.idTipoCarga == (int)TipoCarga.Manual)
            {
                // Definir el filtro de archivos a cargar
                OpenFileDialog openfile = new OpenFileDialog();
                var ext = objCanal.cExtencion;
                string filtro = ext.TrimStart('.').ToUpper() + " files (*" + ext + ")|*" + ext;
                openfile.Title = "Seleccione el archivo del Canal Externo";
                openfile.Filter = filtro;

                if (openfile.ShowDialog() != DialogResult.OK)
                    return;

                if (string.IsNullOrEmpty(openfile.FileName))
                {
                    MessageBox.Show("El nombre del archivo seleccionado es inválido", "Carga de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ruta = openfile.FileName;

                DialogResult result = MessageBox.Show("¿Está seguro de importar el archivo?", "Carga de Datos " + objCanal.cNombreCanal, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result != DialogResult.Yes)
                    return;

                // Cargar el contenido del archivo en un objeto ByteArrayContent
                byte[] fileContent = File.ReadAllBytes(ruta);
                ByteArrayContent content = new ByteArrayContent(fileContent);

                // Agregar el objeto ByteArrayContent al objeto MultipartFormDataContent
                formData.Add(content, "file", Path.GetFileName(ruta));
            }

            var callResult = API.ProcesarDatos(dFechaCarga, objCanal.idCanal, clsVarGlobal.User.cNomUsu, this.dFechaSis, formData);
            if (callResult == null) return;

            switch ((int)callResult.StatusCode)
            {
                case (int)StatusCode.OK:
                    DataTable dtData = callResult.Data;
                    int idCabecera = Convert.ToInt32(dtData.Rows[0]["idCabecera"]);
                    MessageBox.Show(callResult.Response, "Carga de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObtenerDatosCargados(idCabecera);
                    CargaComboArchivosCargados();
                    break;

                case (int)StatusCode.BadRequest:
                    MessageBox.Show(callResult.Error, "Carga de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    MessageBox.Show("Ocurrio un error desconocido", "Carga de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ObtenerDatosCargados(int idCabecera)
        {
            dynamic objCanal = canal();
            DateTime dFechaCarga = this.dtpFechaCarga.Value;

            var callResult = API.ObtenerDatosCargados(dFechaCarga, objCanal.idCanal, idCabecera);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtDatosCargados = callResult.Data;
            dtgDatosCargados.DataSource = dtDatosCargados;
        }

        private void ProcesarPagos(DateTime dFechaPago, int idCanal)
        {
            if(dFechaPago != this.dFechaSis)
            {
                MessageBox.Show("Solo se pueden registrar pagos del dia.", "Proceso de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var callResult = API.ObtenerPagosCargados(idCanal, dFechaPago);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtPagosCargadosAll = callResult.Data;

            DataTable dtPagosCargados = dtPagosCargadosAll.Select("cTipoOperacion <> 'E'").CopyToDataTable();

            List<clsPagos> listPagos = new List<clsPagos>();

            foreach (DataRow row in dtPagosCargados.Rows)
            {
                listPagos.Add(new clsPagos()
                {
                    dFechaPago = Convert.ToDateTime(row["dFechaPago"]),
                    idCuenta = Convert.ToInt32(row["nCodigoCredito"]),
                    nMonto = Convert.ToDecimal(row["nMontoPagado"])
                });
            }

            callResult = API.ObtenerTransacciones(dFechaPago, (int)TipoTransaccion.Pago, idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtTransacciones = callResult.Data;

            if (dtTransacciones.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ya se han registrado pagos para este canal por el Modulo de conciliaciones, los pagos previamente procesados no se volveran" +
                    " a cargar, ¿Desea Continuar?", "Proceso de Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result != DialogResult.Yes)
                    return;
            }

            List<clsPagos> listTransacciones = new List<clsPagos>();

            foreach (DataRow row in dtTransacciones.Rows)
            {
                listTransacciones.Add(new clsPagos()
                {
                    dFechaPago = Convert.ToDateTime(row["dFechaPago"]),
                    idCuenta = Convert.ToInt32(row["nCodigoCredito"]),
                    nMonto = Convert.ToDecimal(row["nMontoPagado"])
                });
            }

            List<clsPagos> listResultado = listPagos.Where(pago => !listTransacciones.Any(transaccion =>
            transaccion.dFechaPago == pago.dFechaPago &&
            transaccion.idCuenta == pago.idCuenta &&
            transaccion.nMonto == pago.nMonto)).ToList();

            DataTable dtPagos = new DataTable();
            dtPagos.Columns.Add("idCuenta", typeof(int));
            dtPagos.Columns.Add("nMontoTotalPag", typeof(decimal));

            foreach (var item in listResultado)
            {
                DataRow row = dtPagos.NewRow();

                row["idCuenta"] = item.idCuenta;
                row["nMontoTotalPag"] = item.nMonto;

                dtPagos.Rows.Add(row);
            }

            DataTable dtTransaccion = new DataTable();
            dtTransaccion.Columns.Add("dFechaPago", typeof(DateTime));
            dtTransaccion.Columns.Add("nCodigoCredito", typeof(int));
            dtTransaccion.Columns.Add("nMontoPagado", typeof(decimal));

            foreach (var item in listResultado)
            {
                DataRow row = dtTransaccion.NewRow();

                row["dFechaPago"] = item.dFechaPago;
                row["nCodigoCredito"] = item.idCuenta;
                row["nMontoPagado"] = item.nMonto;

                dtTransaccion.Rows.Add(row);
            }

            var data = new { dtPagos = dtPagos, dtTransaccion = dtTransaccion };

            callResult = API.RegistraPago(idCanal, dFechaPago, (int)TipoTransaccion.Pago, clsVarGlobal.User.cNomUsu, data);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Procesado correctamente", "Conciliacion de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ObtenerLogCarga()
        {
            dynamic objCanal = canal();
            DateTime dFechaCarga = this.dtpFechaCarga.Value;

            var callResult = API.ObtenerLogCarga(dFechaCarga, objCanal.idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<clsLogCargaDatosConci> listaLog = callResult.Data;

            DialogResult result = MessageBox.Show("Desea descargar el Log?", "Log de Carga de Datos ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = this.InitialDirectory;
            saveFileDialog.FileName = string.Format("LogDeCarga {0}.txt", DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                this.InitialDirectory = Path.GetDirectoryName(rutaArchivo);

                string texto = string.Format("LOG DE PROCESAMIENTO DE DATOS, Fecha de carga: {0} , Canal: {1}\n\r", dFechaCarga.ToString("yyyy-MM-dd"), objCanal.cNombreCanal);
                texto += "Fecha y Hora | Estado | Archivo | Usuario\n\r";

                foreach (var log in listaLog)
                {
                    texto += string.Format("{0} | {1} | {2} | {3}\r"
                        , log.dFechaCarga.ToString("yyyy-MM-dd HH:mm:ss")
                        , log.lResultadoExitoso ? "Exito" : "Error"
                        , string.IsNullOrWhiteSpace(log.cArchivoCargado) ? "-" : log.cArchivoCargado
                        , log.cUsuarioReg
                        );

                    foreach (var logExc in log.logExcepciones)
                    {
                        texto += string.Format("---- MensajeError: {0}\r", logExc.cMensajeError);
                    }
                    texto += "\n";
                }
                File.WriteAllText(rutaArchivo, texto);
            }
        }

        private void GuardaConciliacionActual(DataTable dtPagosCargados, DataTable dtPagosCoreBank)
        {
            this.dtPagosCargados.Clear();
            this.dtPagosCargados = dtPagosCargados;
            this.dtPagosCoreBank.Clear();
            this.dtPagosCoreBank = dtPagosCoreBank;
        }

        private void CargarDatosConciliacion()
        {
            // Obtencion de datos
            dynamic objCanal = canal();
            DataTable dtPagosCargados = new DataTable();
            DataTable dtPagosCoreBank = new DataTable();

            var idCanal = Convert.ToInt32(this.cboCanalesElec2.SelectedValue);
            DateTime dFechaConci = this.dtpFechaConci.Value;
            DateTime dFechaConciA = this.dtpFechaConci.Value;

            var callResult = API.ObtenerPagosCargados(idCanal, dFechaConci);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dFechaConciFinalA = this.dtpFechaConci.Value;

            if (objCanal.idCanal == 10)
            {
                var callResultRango = API.ObtenerRangoFechasReal(idCanal, dFechaConci);

                if (callResultRango.Data.Rows.Count == 0)
                {
                    MessageBox.Show(callResult.Error, "No hay datos para los rangos de fechas.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow dtrRangFechas = callResultRango.Data.Rows[0];
                string dFechaConciStr = dtrRangFechas["FechaMinimaGlobal"].ToString();
                string dFechaConciFinalStr = dtrRangFechas["FechaMaximaGlobal"].ToString();

                string inputFormat = "yyyy-MM-dd";

                dFechaConciA = DateTime.ParseExact(dFechaConciStr, inputFormat, null);
                dFechaConciFinalA = DateTime.ParseExact(dFechaConciFinalStr, inputFormat, null);
            }

            dtPagosCargados = callResult.Data;
            dtPagosCoreBank = new clsCNConciliacionPagos().ObtenerPagosKardex(idCanal, dFechaConciA, dFechaConciFinalA);

            //Validacion de Diferencias
            List<clsPagos> ListPagosCargados = new List<clsPagos>();
            List<clsPagos> ListDifPagosCargados = new List<clsPagos>();

            List<clsPagos> ListPagosCoreBank = new List<clsPagos>();
            List<clsPagos> ListDifPagosCoreBank = new List<clsPagos>();

            int index = 0;

            foreach (DataRow Row in dtPagosCargados.Rows)
            {
                if (Row["cTipoOperacion"].ToString() != "P")
                {
                    Row["idEstado"] = 2; // Estado de Pago: Extornado
                    continue;
                }

                if (ListPagosCargados.Exists(x => x.idCuenta == Convert.ToInt32(Row["nCodigoCredito"].ToString())))
                {
                    index = ListPagosCargados.FindIndex(x => x.idCuenta == Convert.ToInt32(Row["nCodigoCredito"].ToString()));
                    ListPagosCargados[index].nMonto = ListPagosCargados[index].nMonto + Convert.ToDecimal(Row["nMontoPagado"].ToString());
                    Row["idEstado"] = 1; // Estado de Pago: Coincide
                }
                else
                {
                    ListPagosCargados.Add(new clsPagos()
                    {
                        idCuenta = Convert.ToInt32(Row["nCodigoCredito"].ToString()),
                        nMonto = Convert.ToDecimal(Row["nMontoPagado"].ToString())
                    });
                    Row["idEstado"] = 1; // Estado de Pago: Coincide
                }
            }

            dtPagosCoreBank.Columns["idEstado"].ReadOnly = false;

            foreach (DataRow Row in dtPagosCoreBank.Rows)
            {
                if (Convert.ToInt32(Row["idEstadoKardex"].ToString()) != 1) // 1 = Pagos, 2 = Extornos
                {
                    Row["idEstado"] = 2; // Estado de Pago: Extornado
                    continue;
                }

                if (ListPagosCoreBank.Exists(x => x.idCuenta == Convert.ToInt32(Row["idCuenta"].ToString())))
                {
                    index = ListPagosCoreBank.FindIndex(x => x.idCuenta == Convert.ToInt32(Row["idCuenta"].ToString()));
                    ListPagosCoreBank[index].nMonto = ListPagosCoreBank[index].nMonto + Convert.ToDecimal(Row["nMontoOperacion"].ToString());
                    Row["idEstado"] = 1; // Estado de Pago: Coincide
                }
                else
                {
                    ListPagosCoreBank.Add(new clsPagos()
                    {
                        idCuenta = Convert.ToInt32(Row["idCuenta"].ToString()),
                        nMonto = Convert.ToDecimal(Row["nMontoOperacion"].ToString())
                    });
                    Row["idEstado"] = 1; // Estado de Pago: Coincide
                }
            }

            foreach (var item in ListPagosCargados)
            {
                index = ListPagosCoreBank.FindIndex(x => x.idCuenta == item.idCuenta && x.nMonto == item.nMonto);
                if (index < 0)
                {
                    foreach (DataRow row in dtPagosCargados.Rows)
                    {
                        if (Convert.ToInt32(row["nCodigoCredito"].ToString()) == item.idCuenta)
                            row["idEstado"] = 3; // Estado de Pago: Diferencia
                    }

                    ListDifPagosCargados.Add(item);
                }
            }

            foreach (var item in ListPagosCoreBank)
            {
                index = ListPagosCargados.FindIndex(x => x.idCuenta == item.idCuenta && x.nMonto == item.nMonto);
                if (index < 0)
                {
                    foreach (DataRow row in dtPagosCoreBank.Rows)
                    {
                        if (Convert.ToInt32(row["idCuenta"].ToString()) == item.idCuenta)
                            row["idEstado"] = 3; // Estado de Pago: Diferencia
                    }

                    ListDifPagosCoreBank.Add(item);
                }
            }

            GuardaConciliacionActual(dtPagosCargados, dtPagosCoreBank);

            // Valida Absolucion de Diferencias
            callResult = API.ObtenerMPagosKardex(dFechaConci, idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtAbsoluciones = callResult.Data;

            if (dtAbsoluciones.Rows.Count == 0)
            {
                bool lSaved = GuardarConciliacion();

                if (lSaved)
                    btnAbsolver.Enabled = true;
                else
                    return;
            }
            else if(dtAbsoluciones.Rows.Count == 1)
            {
                btnAbsolver.Enabled = true;
            }
            else
            {
                btnAbsolver.Enabled = false;
            }

            this.dtgPagosCargados.SelectionChanged -= new System.EventHandler(this.dtgPagosCargados_SelectionChanged);

            int nCantidadPagCar = 0;
            decimal nMontoTotalPagCar = 0;

            foreach (DataRow Row in dtPagosCargados.Rows)
            {
                if (Row["cTipoOperacion"].ToString() != "P")
                    continue;

                nMontoTotalPagCar += Convert.ToDecimal(Row["nMontoPagado"].ToString());
                nCantidadPagCar++;
            }

            this.dtgPagosCargados.DataSource = dtPagosCargados;
            this.dtgPagosCargados.Refresh();

            foreach (DataGridViewRow Row in this.dtgPagosCargados.Rows)
            {
                if (Row.Cells["cTipo"].Value.ToString() == "P")
                {
                    if (ListDifPagosCargados.Exists(x => x.idCuenta == Convert.ToInt32(Row.Cells["nCodigoCredito"].Value)))
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
                else if (Row.Cells["cTipo"].Value.ToString() == "E")
                {
                    Row.DefaultCellStyle.ForeColor = Color.Orange;
                }
            }

            this.txtCantidadConci.Text = nCantidadPagCar.ToString();
            this.txtTotalConci.Text = nMontoTotalPagCar.ToString();

            this.dtgPagosCargados.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            this.dtgPagosCargados.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dtgPagosCargados.ClearSelection();

            this.dtgPagosCargados.SelectionChanged += new System.EventHandler(this.dtgPagosCargados_SelectionChanged);

            this.dtgPagosCoreBank.SelectionChanged -= new System.EventHandler(this.dtgPagosCoreBank_SelectionChanged);

            int nCantidadCore = 0;
            decimal nTotalCore = 0;

            //Totales Cantidad y Monto
            foreach (DataRow Row in dtPagosCoreBank.Rows)
            {
                if (Convert.ToInt32(Row["idEstadoKardex"].ToString()) != 1) // 1 = Pagos, 2 = Extornos
                    continue;

                nTotalCore += Convert.ToDecimal(Row["nMontoOperacion"].ToString());
                nCantidadCore++;
            }

            this.dtgPagosCoreBank.DataSource = dtPagosCoreBank;
            this.dtgPagosCoreBank.Refresh();

            foreach (DataGridViewRow Row in this.dtgPagosCoreBank.Rows)
            {
                if (Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 1) // 1 = Pagos, 2 = Extornos
                {
                    if (ListDifPagosCoreBank.Exists(x => x.idCuenta == Convert.ToInt32(Row.Cells["idCuenta"].Value)))
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
                else if (Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 2 || Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 4)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            this.txtCantidadCore.Text = nCantidadCore.ToString();
            this.txtTotalCore.Text = nTotalCore.ToString();

            this.dtgPagosCoreBank.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            this.dtgPagosCoreBank.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dtgPagosCoreBank.ClearSelection();

            this.dtgPagosCoreBank.SelectionChanged += new System.EventHandler(this.dtgPagosCoreBank_SelectionChanged);

            if (ListDifPagosCargados.Count == 0 && ListDifPagosCoreBank.Count == 0)
            {
                MessageBox.Show("No se encontro diferencias, el resultado de la conciliacion es correcto.",
                            "Conciliacion de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAbsolver.Enabled = false;
            }
        }

        private bool GuardarConciliacion()
        {
            var data = new { dtPagosCargados = this.dtPagosCargados, dtPagosCoreBank = this.dtPagosCoreBank };

            dynamic objCanal = canal();
            string cUsuarioReg = clsVarGlobal.User.cNomUsu;
            DateTime dFechaConci = this.dtpFechaConci.Value;

            var callResult = API.GuardarConciliacion(objCanal.idCanal, dFechaConci, cUsuarioReg, data);
            if (callResult == null) return false;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CorreccionesAutomaticas(DateTime dFechaConci, int idCanal)
        {
            List<clsPagos> ListDifPagosCargados = new List<clsPagos>();

            foreach (DataRow row in this.dtPagosCargados.Rows)
            {
                int idEstado = Convert.ToInt32(row["idEstado"]);

                if (idEstado == 3) // Diferencia
                {
                    DateTime dFechaP = Convert.ToDateTime(row["dFechaPago"]);
                    int nCodigoCredito = Convert.ToInt32(row["nCodigoCredito"]);
                    decimal nMontoPagado = Convert.ToDecimal(row["nMontoPagado"]);
                    int idCanalServicio = Convert.ToInt32(row["idCanalServicio"]);

                    ListDifPagosCargados.Add(new clsPagos()
                    {
                        idCuenta = nCodigoCredito,
                        nMonto = nMontoPagado,
                        dFechaPago = dFechaP,
                        idCanalServicio = idCanalServicio
                    });
                }
            }

            List<clsPagos> ListDifPagosCoreBank = new List<clsPagos>();

            foreach (DataRow row in this.dtPagosCoreBank.Rows)
            {
                int idEstado = Convert.ToInt32(row["idEstado"]);

                if (idEstado == 3)
                {
                    DateTime dFechaOpe = Convert.ToDateTime(row["dFechaOpe"]);
                    int idCuenta = Convert.ToInt32(row["idCuenta"]);
                    decimal nMontoOperacion = Convert.ToDecimal(row["nMontoOperacion"]);
                    int idKardex = Convert.ToInt32(row["idKardex"]);

                    ListDifPagosCoreBank.Add(new clsPagos()
                    {
                        idCuenta = idCuenta,
                        idKardex = idKardex,
                        nMonto = nMontoOperacion,
                        dFechaPago = dFechaOpe
                    });
                }
            }

            List<clsPagos> listResultadoC1 = ListDifPagosCargados.Where(pagoCar => !ListDifPagosCoreBank.Any(pagoCor =>
            pagoCor.idCuenta == pagoCar.idCuenta)).ToList();

            List<clsPagos> listResultadoC2 = ListDifPagosCoreBank.Where(pagoCor => !ListDifPagosCargados.Any(pagoCar =>
            pagoCar.idCuenta == pagoCor.idCuenta)).ToList();

            //CASO 1: En caso la diferencia encontrada se haya dado por un pago que sí fue reportado por el Canal Externo
            //y no fue procesado por Los Andes en el Corebank, se debe realizar un alineamiento de pagos con una afectación
            //automática (pagar el crédito). 

            if (listResultadoC1.Count > 0)
            {
                DialogResult response = MessageBox.Show("Se encontraron " + listResultadoC1.Count + " pagos que no fueron procesados por Los Andes en el CoreBank. " +
                "¿Desea realizar el alineamiento de pagos?", "Operaciones automaticas", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (response != DialogResult.Yes)
                    return;

                var _callResult = API.ObtenerTransacciones(dFechaConci, (int)TipoTransaccion.Pago, idCanal);
                if (_callResult == null) return;
                if (_callResult.StatusCode == (int)StatusCode.BadRequest)
                {
                    MessageBox.Show(_callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtTransacciones = _callResult.Data;

                if (dtTransacciones.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Ya se han registrado pagos para este canal por el Modulo de conciliaciones, los pagos previamente procesados no se volveran" +
                        " a cargar, ¿Desea Continuar?", "Operaciones automaticas", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result != DialogResult.Yes)
                        return;
                }

                DataTable dtPagos = new DataTable();
                dtPagos.Columns.Add("idCuenta", typeof(int));
                dtPagos.Columns.Add("nMontoTotalPag", typeof(decimal));
                dtPagos.Columns.Add("idCanalServicio", typeof(int));

                foreach (var item in listResultadoC1)
                {
                    DataRow row = dtPagos.NewRow();

                    row["idCuenta"] = item.idCuenta;
                    row["nMontoTotalPag"] = item.nMonto;
                    row["idCanalServicio"] = item.idCanalServicio;

                    dtPagos.Rows.Add(row);
                }

                DataTable dtTransaccion = new DataTable();
                dtTransaccion.Columns.Add("dFechaPago", typeof(DateTime));
                dtTransaccion.Columns.Add("nCodigoCredito", typeof(int));
                dtTransaccion.Columns.Add("nMontoPagado", typeof(decimal));

                foreach (var item in listResultadoC1)
                {
                    DataRow row = dtTransaccion.NewRow();

                    row["dFechaPago"] = item.dFechaPago;
                    row["nCodigoCredito"] = item.idCuenta;
                    row["nMontoPagado"] = item.nMonto;

                    dtTransaccion.Rows.Add(row);
                }

                var data = new { dtPagos = dtPagos, dtTransaccion = dtTransaccion };

                var callResult = API.RegistraPago(idCanal, dFechaConci, (int)TipoTransaccion.Pago, clsVarGlobal.User.cNomUsu, data);
                if (callResult == null) return;
                if (callResult.StatusCode == (int)StatusCode.BadRequest)
                {
                    MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Pagos Procesados correctamente", "Operaciones automaticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //CASO 2: En caso la diferencia se originó porque el canal externo no tiene el pago y fue procesado por Los Andes en el Corebank,
            //la regularización se debe realizar con un extorno del pago ya que no debió ser procesado.

            if (listResultadoC2.Count > 0)
            {
                DialogResult response = MessageBox.Show("Se encontraron " + listResultadoC2.Count + " pagos que no fueron reportados por el Canal Externo. " +
                "¿Desea realizar el extorno de pagos?", "Operaciones automaticas", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (response != DialogResult.Yes)
                    return;

                DataTable dtExtornos = new DataTable();
                dtExtornos.Columns.Add("idKardex", typeof(int));

                foreach (var item in listResultadoC2)
                {
                    DataRow row = dtExtornos.NewRow();

                    row["idKardex"] = item.idKardex;

                    dtExtornos.Rows.Add(row);
                }

                DataTable dtTransaccion = new DataTable();
                dtTransaccion.Columns.Add("dFechaPago", typeof(DateTime));
                dtTransaccion.Columns.Add("nCodigoCredito", typeof(int));
                dtTransaccion.Columns.Add("nMontoPagado", typeof(decimal));

                foreach (var item in listResultadoC2)
                {
                    DataRow row = dtTransaccion.NewRow();

                    row["dFechaPago"] = item.dFechaPago;
                    row["nCodigoCredito"] = item.idCuenta;
                    row["nMontoPagado"] = item.nMonto;

                    dtTransaccion.Rows.Add(row);
                }

                var data = new { dtExtornos = dtExtornos, dtTransaccion = dtTransaccion };

                var callResult = API.RegistraExtorno(idCanal, dFechaConci, (int)TipoTransaccion.Extorno, clsVarGlobal.User.cNomUsu, data);
                if (callResult == null) return;
                if (callResult.StatusCode == (int)StatusCode.BadRequest)
                {
                    MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Extornos Procesados correctamente", "Operaciones automaticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnConsultarConci_Click(null, null);
            GuardarConciliacion();
        }

        #endregion

        #region Eventos

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (this.cboArchivoCargado.Items.Count > 0)
            {
                DialogResult response = MessageBox.Show("Ya se ha procesado un archivo para la fecha seleccionada, " +
                "¿Desea remplazarlo por uno nuevo?", "Carga de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (response != DialogResult.Yes)
                    return;
            }

            ProcesarDatos();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (this.cboArchivoCargado.Items.Count > 0)
            {
                DialogResult response = MessageBox.Show("Ya se ha procesado un archivo para la fecha seleccionada, " +
                "¿Desea remplazarlo por uno nuevo?", "Carga de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (response != DialogResult.Yes)
                    return;
            }

            ProcesarDatos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (this.cboArchivoCargado.Items.Count < 1)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Carga de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var idCabecera = this.cboArchivoCargado.SelectedValue;
            ObtenerDatosCargados(Convert.ToInt32(idCabecera));
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (this.cboArchivoCargado.Items.Count < 1)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Proceso de Pagos por BATCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cboArchivoCargado.SelectedIndex != (cboArchivoCargado.Items.Count - 1))
            {
                MessageBox.Show("Debe seleccionar el ultimo archivo cargado para proceder con el registro de Pagos.", "Proceso de Pagos por BATCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic objCanal = canal();
            DateTime dFechaCarga = this.dtpFechaCarga.Value;

            ProcesarPagos(dFechaCarga, objCanal.idCanal);
        }

        private void btnAbsolver_Click(object sender, EventArgs e)
        {
            if (this.dtgPagosCargados.CurrentRow == null && this.dtgPagosCoreBank.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Conciliación de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic objCanal = canal();
            DateTime dFechaConci = this.dtpFechaConci.Value.Date;

            CorreccionesAutomaticas(dFechaConci, objCanal.idCanal);
        }

        private void btnExporLog_Click(object sender, EventArgs e)
        {
            ObtenerLogCarga();
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            frmConciliacionPagosObservaciones objConciliacionPagosObservaciones =
                new frmConciliacionPagosObservaciones(this.dtpFechaCarga.Value, (int)this.cboCanalesElec.SelectedValue);
            objConciliacionPagosObservaciones.ShowDialog();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            frmReporteBitacora objReporteBitacora =
                new frmReporteBitacora((int)this.cboCanalesElec.SelectedValue);
            objReporteBitacora.ShowDialog();
        }

        private void btnConsultarConci_Click(object sender, EventArgs e)
        {
            if (this.cboArchivoCargado2.GetItemText(this.cboArchivoCargado2.SelectedItem) == string.Empty)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Conciliación de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatosConciliacion();

            if (this.dtpFechaConci.Value != this.dFechaSis)
                btnAbsolver.Enabled = false;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == tabPageCarga.Name)
            {
                btnBitacora.Visible = false;
                btnExporLog.Visible = true;
            }
            else
            {
                btnBitacora.Visible = true;
                btnExporLog.Visible = false;
                dtgDatosCargados.DataSource = null;
            }
        }

        private void cboCanalesElec_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objCnal = canal();
            if (objCnal != null)
            {
                HabilitaOpcionCarga(objCnal.idTipoCarga);
                HabilitaOpcionPago(objCnal.lHabilitaPagos);
                CargaComboArchivosCargados();
            }
        }

        private void dtpFechaCarga_ValueChanged(object sender, EventArgs e)
        {
            var cboFechaCarga = this.dtpFechaCarga.Value.Date;
            var sysFecha = this.dFechaSis.Date;

            if (cboFechaCarga != this.dtpFechaConci.Value)
                this.dtpFechaConci.Value = cboFechaCarga;

            if (cboFechaCarga <= sysFecha)
            {
                btnEjecutar.Enabled = true;
                btnCargar.Enabled = true;
                btnPagar.Enabled = true;
            }
            else
            {
                btnEjecutar.Enabled = false;
                btnCargar.Enabled = false;
                btnPagar.Enabled = false;
            }

            CargaComboArchivosCargados();
        }

        private void dtpFechaConci_ValueChanged(object sender, EventArgs e)
        {
            var cboFechaConci = this.dtpFechaConci.Value.Date;

            if (cboFechaConci != this.dtpFechaCarga.Value)
                this.dtpFechaCarga.Value = cboFechaConci;
        }

        private void dtgPagosCargados_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPagosCargados.CurrentRow == null)
                return;

            this.dtgPagosCoreBank.SelectionChanged -= new System.EventHandler(this.dtgPagosCoreBank_SelectionChanged);

            if (this.dtgPagosCoreBank.RowCount > 0)
            {
                this.dtgPagosCoreBank.CurrentRow.Selected = false;
            }

            int nRowSelection = this.dtgPagosCargados.CurrentCell.RowIndex;
            DataGridViewCell dtgc = this.dtgPagosCargados.CurrentCell;

            int nCodigoCredito = Convert.ToInt32(this.dtgPagosCargados.Rows[nRowSelection].Cells["nCodigoCredito"].Value);

            foreach (DataGridViewRow row in this.dtgPagosCargados.Rows)
            {
                if (row.Index != nRowSelection)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            foreach (DataGridViewRow row in this.dtgPagosCoreBank.Rows)
            {
                if (Convert.ToInt32(row.Cells["idCuenta"].Value) == nCodigoCredito)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            this.dtgPagosCoreBank.SelectionChanged += new System.EventHandler(this.dtgPagosCoreBank_SelectionChanged);
        }

        private void dtgPagosCoreBank_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPagosCoreBank.CurrentRow == null)
                return;

            this.dtgPagosCargados.SelectionChanged -= new System.EventHandler(this.dtgPagosCargados_SelectionChanged);

            if (this.dtgPagosCargados.RowCount > 0)
            {
                this.dtgPagosCargados.CurrentRow.Selected = false;
            }

            int nRowSelection = this.dtgPagosCoreBank.CurrentCell.RowIndex;

            int idCuenta = Convert.ToInt32(this.dtgPagosCoreBank.Rows[nRowSelection].Cells["idCuenta"].Value);

            foreach (DataGridViewRow row in this.dtgPagosCoreBank.Rows)
            {
                if (row.Index != nRowSelection)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            foreach (DataGridViewRow row in this.dtgPagosCargados.Rows)
            {
                if (Convert.ToInt32(row.Cells["nCodigoCredito"].Value) == idCuenta)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            this.dtgPagosCargados.SelectionChanged += new System.EventHandler(this.dtgPagosCargados_SelectionChanged);
        }

        #endregion

        #region Clases Internas

        class clsPagos
        {
            public DateTime dFechaPago { get; set; }
            public int idCuenta { get; set; }
            public int idKardex { get; set; }
            public decimal nMonto { get; set; }
            public int idCanalServicio { get; set; }
        }

        #endregion
    }
}