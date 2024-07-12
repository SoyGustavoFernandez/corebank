using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
using ADM.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmReprogCreditoMasivo : frmBase
    {
        #region Variables Globales
        private clsCNReprogramacion objCNReprogramacion;
        private List< clsCreditoReprogExcel> lstCreditoReprogArchivo;
        private List< clsCreditoReprogExcel> lstCreditoReprogBD;
        private List<clsCreditoReprogExcel> lstCreditoReprog;
        private BindingSource bsCreditoReprog;
        private clsCNPlanPago objCNPlanPago;

        private int nAnio;
        private int nMes;
        private string cDireccionRuta;
        private Excel.Application appExcel { get; set; }
        private Excel.Workbook workBookExcel { get; set; }
        private Excel.Worksheet workSheetExcel { get; set; }
        #endregion
        public frmReprogCreditoMasivo()
        {
            InitializeComponent();
            this.inicializarDatos();
        }      

        #region Metodos
        private void inicializarDatos()
        {
            this.objCNReprogramacion = new clsCNReprogramacion();

            this.nAnio = clsVarGlobal.dFecSystem.Year;
            this.nMes = clsVarGlobal.dFecSystem.Month;
            this.cDireccionRuta = string.Empty;
            this.lstCreditoReprogArchivo = new List<clsCreditoReprogExcel>();
            this.lstCreditoReprogBD = new List<clsCreditoReprogExcel>();
            this.lstCreditoReprog = new List<clsCreditoReprogExcel>();
            this.bsCreditoReprog = new BindingSource();
            this.objCNPlanPago = new clsCNPlanPago();

            this.bsCreditoReprog.DataSource = this.lstCreditoReprog;
            this.dtgReprogCredito.DataSource = this.bsCreditoReprog;

            this.formatearReprogCredito();

            this.habilitarControles(clsAcciones.NUEVO);
        }
        private void importarReprogCreditoArchivo()
        {
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Office Files|*.xls;*.xlsx";
            objOpenFileDialog.InitialDirectory = @"C:\";
            objOpenFileDialog.Title = "Selección el archivo de carga de metas";

            DialogResult drResultado = objOpenFileDialog.ShowDialog();

            if (drResultado == DialogResult.OK)
            {
                if (objOpenFileDialog.SafeFileName != String.Empty)
                {
                    DialogResult drConsulta = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (drConsulta == DialogResult.Yes)
                    {
                        cDireccionRuta = objOpenFileDialog.FileName;
                        this.txtUbicacionArchivo.Text = cDireccionRuta;
                        this.procesarReproCreditoMasivo();
                        this.btnImportar.Enabled = false;
                        this.btnCancelar.Enabled = true;
                    }
                    else
                    {
                        txtUbicacionArchivo.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó un archivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void procesarReproCreditoMasivo()
        {
            bool lValor = true;
            appExcel = new Excel.Application();
            workBookExcel = appExcel.Workbooks.Open(cDireccionRuta, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            workSheetExcel = workBookExcel.Worksheets.get_Item(1);
            lstCreditoReprogArchivo.Clear();

            int i = 2;
            int nProcesados = 0;
            bool lGrabado = true;
            while (lValor)
            {
                int j = 0;
                while (j < 100)
                {

                    clsCreditoReprogExcel objReprogCredito = new clsCreditoReprogExcel();
                    objReprogCredito.idCli = Convert.ToInt32((workSheetExcel.Cells[i, 1] as Excel.Range).Value2);
                    objReprogCredito.idCuenta = Convert.ToInt32((workSheetExcel.Cells[i, 2] as Excel.Range).Value2);
                    if (this.cboTipoPlanPago.SelectedIndex == 3)
                    {
                        objReprogCredito.nTasaNueva = Convert.ToDouble((workSheetExcel.Cells[i, 3] as Excel.Range).Value2);
                    }
                    else
                    {
                        objReprogCredito.nDiasReprog = Convert.ToInt32((workSheetExcel.Cells[i, 3] as Excel.Range).Value2);
                    }
                    

                    if (objReprogCredito.idCuenta != 0)
                    {
                        lstCreditoReprogArchivo.Add(objReprogCredito);
                    }
                    else
                    {
                        lValor = false;
                        break;
                    }
                    i++;
                    j++;
                }
                this.lstCreditoReprog.Clear();
                this.lstCreditoReprog.AddRange(this.lstCreditoReprogArchivo);
                this.bsCreditoReprog.ResetBindings(false);
                this.dtgReprogCredito.Refresh();

                lGrabado = this.grabarReprogCredito();
                if(!lGrabado)
                {
                    workBookExcel.Close(false, null, null);
                    appExcel.Quit();
                    liberarObjeto(workSheetExcel);
                    liberarObjeto(workBookExcel);
                    liberarObjeto(appExcel);
                    return;
                }

                this.lstCreditoReprogArchivo.Clear();

                nProcesados += j;
                this.txtProcesados.Text = nProcesados.ToString();
            }

            workBookExcel.Close(false, null, null);
            appExcel.Quit();
            liberarObjeto(workSheetExcel);
            liberarObjeto(workBookExcel);
            liberarObjeto(appExcel);
            MessageBox.Show("¡Proceso de reprogramación masiva finalizada!", "FINALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // this.cboTipoPlanPago.SelectedIndex = 0;
        }
        private bool grabarReprogCredito()
        {
            DataSet dsResultado = this.objCNReprogramacion.grabarSolicitudReprogMasivo(this.lstCreditoReprog, this.cboTipoPlanPago.SelectedIndex);

            if (dsResultado.Tables.Count == 0)
            {
                MessageBox.Show("No se obtuvo ningun resultado del servidor al grabar las solicitudes","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            bool lResultadoEjecucion = true;
            if (Convert.ToInt32(dsResultado.Tables[0].Rows[0]["idResultado"]) == 1)
            {
                foreach (DataRow drFila in dsResultado.Tables[1].Rows)
                {
                    lResultadoEjecucion = this.ejecutarReprogramacion(drFila);
                    if (!lResultadoEjecucion) return lResultadoEjecucion;
                }
                return true;
            }
            else
            {
                MessageBox.Show("" + dsResultado.Tables[0].Rows[0]["cMensaje"].ToString(), "Error de Grabado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool ejecutarReprogramacion(DataRow drSolicitud)
        {
            DataTable dtCalendarioPagos;

            int idCuenta = Convert.ToInt32(drSolicitud["idCuenta"]);
            int idSolicitud = Convert.ToInt32(drSolicitud["idSolicitud"]);
            int idOperacion = Convert.ToInt32(drSolicitud["idOperacion"]);
            int nCuotas = Convert.ToInt32(drSolicitud["nCuotas"]);
            int idCuotaOrigen = Convert.ToInt32(drSolicitud["idCuotaOrigen"]);
            int nCuotasDestino = Convert.ToInt32(drSolicitud["nCuotasDestino"]);
            int ndiasgracia = Convert.ToInt32(drSolicitud["ndiasgracia"]);
            int idTipoPeriodo = Convert.ToInt32(drSolicitud["idTipoPeriodo"]);
            int nPlazoCuota = Convert.ToInt32(drSolicitud["nPlazoCuota"]);
            decimal nTasaCompensatoria = Convert.ToDecimal(drSolicitud["nTasaCompensatoria"]);
            DateTime dFechaUltimoPago = Convert.ToDateTime(drSolicitud["dFechaUltimoPago"]);
            int idSolicitudOrigen = Convert.ToInt32(drSolicitud["idSolicitudOrigen"]);
            decimal nCapitalAprobado = Convert.ToDecimal(drSolicitud["nCapitalAprobado"]);
            int IdMoneda = Convert.ToInt32(drSolicitud["IdMoneda"]);
            decimal nCapitalMaxCobSeg = Convert.ToDecimal(drSolicitud["nCapitalMaxCobSeg"]);
            DateTime dFecPrimeraCuota = Convert.ToDateTime(drSolicitud["dFecPrimeraCuota"]);
            bool lAplicaSeguro = Convert.ToBoolean(drSolicitud["lAplicaSeguro"]);
            decimal nMontoCuota = Convert.ToDecimal(drSolicitud["nMontoCuota"]);

            DataTable dtModificaciones = new DataTable();
            DataTable dtConfigGastos;
            DataTable dtCuotasDobles;
            

            dtModificaciones.Columns.Add("idTipoAccion", typeof(int));
            dtModificaciones.Columns.Add("cTipoAccion", typeof(string));
            dtModificaciones.Columns.Add("nCuota", typeof(int));
            dtModificaciones.Columns.Add("nOtraCuota", typeof(int));
            dtModificaciones.Columns.Add("nMes", typeof(int));
            dtModificaciones.Columns.Add("cMes", typeof(string));
            dtModificaciones.Columns.Add("nAnio", typeof(int));
            dtModificaciones.Columns.Add("cAnio", typeof(string));
            dtModificaciones.Columns.Add("nMonto", typeof(int));
            dtModificaciones.Columns.Add("lIndTodAnios", typeof(bool));

            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            objSegDes.validarAplicaSeguroDesgravamen(0, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal, 0, idCuenta, false);
            nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            lAplicaSeguro = objSegDes.obternerNAplicaSeguro();
            dtConfigGastos = new clsCNConfigGastComiSeg().CNGetConfigGastosCuenta(idCuenta);

            decimal nSaldoCapitalCuenta = nCapitalAprobado;
            decimal nMontoDistribuir = nSaldoCapitalCuenta;

            clsSolicitudReprogramacion objSolicitudReprogramacion = new clsSolicitudReprogramacion();

            objSolicitudReprogramacion.idSolicitudOrigen = idSolicitudOrigen;
            objSolicitudReprogramacion.nCuotasDestino = nCuotasDestino;
            objSolicitudReprogramacion.idOperacion = idOperacion;
            objSolicitudReprogramacion.idCuotaOrigen = idCuotaOrigen;

            decimal nTasaEfectivaMensual = nTasaCompensatoria / 100.00m;
            if (this.cboTipoPlanPago.SelectedIndex == 1)
            {
                nMontoCuota = decimal.Zero;
            }
            
            dtCuotasDobles = this.objCNPlanPago.retornarCuotasDobles(dtModificaciones, dFechaUltimoPago, nCuotas);
            //Generar el plan de pagos manteniendo o no las cuotas a pagar constantes
            dtCalendarioPagos = this.objCNPlanPago.CalculaPpgCuotasConstantes2(
                nMontoDistribuir,
                nTasaEfectivaMensual,
                dFechaUltimoPago,
                nCuotas,
                ndiasgracia,
                (short)idTipoPeriodo,
                nPlazoCuota,
                idSolicitud,
                dtConfigGastos,
                IdMoneda,
                dtCuotasDobles,
                dFecPrimeraCuota,
                0,
                nCapitalMaxCobSeg,
                0,
                true,
                nMontoCuota
                );

            dtCalendarioPagos = this.objCNPlanPago.AgregarGastosManualesReprogramacion(dtCalendarioPagos, dFechaUltimoPago, objSolicitudReprogramacion, dtModificaciones);
            foreach (DataRow drCuota in dtCalendarioPagos.Rows)
            {
                drCuota["nAtrasoCuota"] = decimal.Zero;
                drCuota["nInteresComp"] = decimal.Zero;
            }

            int idCuotaIni = 1;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem.Date;
            clsPlanPago objPlanPagos = objCNPlanPago.retonarPlanPagoTotal(idCuenta);
            clsPlanPago objPlanPagosNuevo = new clsPlanPago();

            List<clsCuota> lstCuotasPagadas = (from item in objPlanPagos where item.idEstadocuota == 2 select item).ToList();
            int idCuotaIniGastos = lstCuotasPagadas.Count + 1;

            DataTable dtGastos = this.objCNPlanPago.ObtenerGastos(idSolicitud);
            
            objPlanPagosNuevo = this.objCNPlanPago.PlanPagosFinalReprogramacion(objPlanPagos, dtCalendarioPagos, dFechaUltimoPago, nTasaCompensatoria, dtGastos);

            DataTable dtPlanCuotasPagadas = this.objCNPlanPago.ConvertToDataTablePlanPagos(lstCuotasPagadas, idSolicitud);

            var enumCuotas = dtPlanCuotasPagadas.AsEnumerable()
                                                .Union(dtCalendarioPagos.AsEnumerable())
                                                .OrderBy(x => x.Field<DateTime>("fecha"));

            DataTable dtPlanPagos = enumCuotas.Any() ? enumCuotas.CopyToDataTable() : dtCalendarioPagos.Clone();

            foreach (DataRow drCuota in dtPlanPagos.Rows)
            {
                drCuota["cuota"] = idCuotaIni++;
            }

            idCuotaIni = 1;
            foreach (clsCuota cuota in objPlanPagosNuevo)
            {
                cuota.idCuota = idCuotaIni++;
            }

            foreach (DataRow drGasto in dtGastos.Rows)
            {
                drGasto["idCuota"] = drGasto.Field<int>("idCuota") + idCuotaIniGastos - 1;
                drGasto["idCuenta"] = objSolicitudReprogramacion.idCuenta;
            }

            DataSet ds = new DataSet("dsReprogramacion");

            dtGastos.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtGastos);

            dtModificaciones.TableName = "dtModificaciones";
            ds.Tables.Add(dtModificaciones);

            DataTable dtDatCred = new DataTable("dtCreditos");
            dtDatCred.Columns.Add("idCuenta", typeof(int));
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof(decimal));
            dtDatCred.Columns.Add("nTCEA", typeof(decimal));
            dtDatCred.Columns.Add("nTEA", typeof(decimal));
            decimal nTCEA = this.calcularTasaCompEfectivaAnual(dtCalendarioPagos, nCapitalAprobado, nTasaCompensatoria);
            dtDatCred.Rows.Add(idCuenta, lAplicaSeguro, nCapitalMaxCobSeg, this.objCNPlanPago.nMontoCuota, nTCEA, nTasaCompensatoria);

            ds.Tables.Add(dtDatCred);

            string xmlReprogramacion = ds.GetXml();
            xmlReprogramacion = clsCNFormatoXML.EncodingXML(xmlReprogramacion);
            ds.Tables.Clear();
            int idUsuario = clsVarGlobal.User.idUsuario;
            clsDBResp objDebResp = this.objCNPlanPago.RegistrarReprogramacion(idCuenta, idSolicitud, ndiasgracia, objPlanPagosNuevo, xmlReprogramacion, dFechaSistema, idUsuario);

            this.txtCuentaProcesada.Text = idCuenta.ToString();
            this.txtSolicitudProcesada.Text = idSolicitud.ToString();
            this.txtMensaje.Text = objDebResp.cMsje;
            if (objDebResp.nMsje == 0)
            {
                this.txtEstado.Text = "CORRECTO";
                return true;
                /*  Guardar Expedientes - Reprogramacion de Credito  */
                //clsProcesoExp.guardarCopiaExpediente("Reprogramacion de Credito", this.idSolicitud, this);
            }
            else
            {
                this.txtEstado.Text = "ERROR";
                MessageBox.Show("" + objDebResp.cMsje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private decimal calcularTasaCompEfectivaAnual(DataTable dtCalendarioPagos, decimal nMonDesemb, decimal nTEA)
        {

            DataTable dtPlanPago = new DataTable();
            dtPlanPago.Columns.Add("dias", typeof(decimal));
            dtPlanPago.Columns.Add("dias_acu", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));

            int nDiasAcum = 0;
            for (int i = 0; i < dtCalendarioPagos.Rows.Count; i++)
            {

                DataRow drCuota = dtPlanPago.NewRow();
                int nDias = Convert.ToInt32(dtCalendarioPagos.Rows[i]["dias"]);
                drCuota["dias"] = nDias;
                nDiasAcum += nDias;
                drCuota["dias_acu"] = nDiasAcum;
                drCuota["imp_cuota"] = Convert.ToDecimal(dtCalendarioPagos.Rows[i]["imp_cuota"]);
                dtPlanPago.Rows.Add(drCuota);
            }
            decimal nTCEA = decimal.Zero;


            nTCEA = this.objCNPlanPago.CNnCalculaTCEA(dtPlanPago, nMonDesemb, nTEA);
            nTCEA = nTCEA < nTEA ? nTEA : nTCEA;
            return nTCEA;
        }
       
       
        private void formatearReprogCredito()
        {
            foreach (DataGridViewColumn dtgColumn in this.dtgReprogCredito.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dtgReprogCredito.Columns["idCuenta"].Visible = true;
            this.dtgReprogCredito.Columns["idCli"].Visible = true;
            this.dtgReprogCredito.Columns["nDiasReprog"].Visible = this.cboTipoPlanPago.SelectedIndex != 3;
            this.dtgReprogCredito.Columns["nTasaNueva"].Visible = this.cboTipoPlanPago.SelectedIndex == 3;

            this.dtgReprogCredito.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgReprogCredito.Columns["idCli"].HeaderText = "Cliente";
            this.dtgReprogCredito.Columns["nDiasReprog"].HeaderText = "DiasReprog";
            this.dtgReprogCredito.Columns["nTasaNueva"].HeaderText = "TasaNueva";
            this.dtgReprogCredito.Columns["nTasaNueva"].ValueType = typeof(double);
        }
        public void formatearModificacion()
        {
           
        }
        private void limpiar()
        {
            this.lstCreditoReprog.Clear();
            this.lstCreditoReprogArchivo.Clear();
            this.lstCreditoReprogBD.Clear();

            this.bsCreditoReprog.ResetBindings(false);
            this.dtgReprogCredito.Refresh();

            this.txtUbicacionArchivo.Text = string.Empty;
            this.nMes = clsVarGlobal.dFecSystem.Month;
        }
        private void habilitarControles(int nAccion)
        {
            switch (nAccion)
            {
                case clsAcciones.NUEVO:
                    this.btnImportar.Enabled = true;
                    this.btnCancelar.Enabled = false;
                    break;
                case clsAcciones.GRABAR:
                    this.btnImportar.Enabled = false;
                    break;
                case clsAcciones.CANCELAR:
                    this.btnImportar.Enabled = true;
                    break;
                case clsAcciones.BUSCAR:
                    this.btnImportar.Enabled = true;
                    break;
            }
        }
        private void liberarObjeto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = getIDProcess("EXCEL");

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
        private int getIDProcess(string nameProcess)
        {
            try
            {
                System.Diagnostics.Process[] asProcess = System.Diagnostics.Process.GetProcessesByName(nameProcess);
                foreach (System.Diagnostics.Process pProcess in asProcess)
                {
                    if (pProcess.MainWindowTitle == "")
                        return pProcess.Id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        private void imprimirFormato()
        {
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            List<ReportParameter> paramList = new List<ReportParameter>();

            string reportPath = "RptFormatoReprogCredito.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
        #endregion
        #region Eventos
        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (this.cboTipoPlanPago.SelectedIndex.In(-1,0))
            {
                MessageBox.Show("¡Seleccione el tipo de plan pago que desea generar!", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.importarReprogCreditoArchivo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitarControles(clsAcciones.CANCELAR);
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            this.imprimirFormato();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void cboTipoPlanPagos_Change(object sender, EventArgs e)
        {
            this.formatearReprogCredito();
        }
    }
}
