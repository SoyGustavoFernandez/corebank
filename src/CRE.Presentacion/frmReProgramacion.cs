using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using GEN.Servicio;
using CLI.Presentacion;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmReProgramacion : frmBase
    {

        #region Variables
        private clsSolicitudCreditoDetalle objSolicitudCreditoDetalle;
        private clsSolicitudReprogramacion objSolicitudReprogramacion;

        private int idSolicitud;
        private bool lIndModificaciones;
        private decimal nCapitalMaxCobSeg;
        private bool lAplicaSeguro;
        private int nCuotasPagadas;
        //private int idOperacion = 0;
        private DateTime dFecDesembolsoCred;
        private DateTime dFecPrimeraCuotaPendiente;
        private DateTime dFechaUltimoPago;

        private clsPlanPago objPlanPagos;
        private clsPlanPago objPlanPagosNuevo;
        public clsCNPlanPago objCNPlanPago;
        private clsCNSolicitud objCNSolicitud;
        private clsCNAdministracionFiles clsFiles = new clsCNAdministracionFiles();

        private DataTable dtCalendarioPagos = new DataTable("dtPlanPago");
        private DataTable dtModificaciones;
        private DataTable dtCuotasDobles;
        private DataTable dtConfigGastos;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = new List<clsMantenimientoPaqueteSeguro>();
        private clsCNPaqueteSeguro objPaqueteSeguroCN = new clsCNPaqueteSeguro();

        #endregion

        #region Constructores

        public frmReProgramacion()
        {
            InitializeComponent();

            this.inicializarDatos();
            conBusCuentaCli.cTipoBusqueda = "S";
            conBusCuentaCli.cEstado = "[2]";
            cargarEstructuradtModifica();

            this.lIndModificaciones = true;
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            if (ValidarInicioOpe() != "A")
            {
                Dispose();
                return;
            }
            dtpFecDesembolso.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecPrimeraCuota.Value = clsVarGlobal.dFecSystem.Date;
            dtgPpgActual.AutoGenerateColumns = false;

            activarControlObjetos(this, EventoFormulario.INICIO);

            conBusCuentaCli.txtNroBusqueda.Select();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            this.idSolicitud = conBusCuentaCli.nValBusqueda;
            CargarDatos();
            cargarConfiguracionesDeGasto();

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
        }
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            this.idSolicitud = conBusCuentaCli.nValBusqueda;
            CargarDatos();
            cargarConfiguracionesDeGasto();

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
        }
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPeriodo.SelectedIndex < 0)
                return;

            if ((int)cboTipoPeriodo.SelectedValue == 1)
            {
                lblDesTipo.Text = "Día de Pago:";
                nudPeriodo.Maximum = 31;
            }
            else
            {
                lblDesTipo.Text = "Frecuencia:";
                nudPeriodo.Maximum = 1800;
        }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            const string reportpath = "RptCalendarioCredito.rdlc";

            int idCuenta = this.objSolicitudCreditoDetalle.idCuenta;
            int idCliente = conBusCuentaCli.nIdCliente;

            DataTable dtListPPG = new clsRPTCNPlanPagos().CNCronogramaCreditoGastosNoConfirmados(idCuenta, this.idSolicitud, this.objSolicitudReprogramacion.idOperacion);
            dtListPPG.Columns["nITF"].ReadOnly = false;

            for (int i = 0; i < dtListPPG.Rows.Count; i++)
            {
                dtListPPG.Rows[i]["nITF"] = 0;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();

            /****************/
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
            paramlist.Add(new ReportParameter("nNumCredito", idCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsPPG", new clsRPTCNPlanPagos().CNCronogramaCreditoGastosNoConfirmados(idCuenta, this.idSolicitud, this.objSolicitudReprogramacion.idOperacion)));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(idCuenta)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNDireccion(idCuenta)));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (ValidarChecklist() == "ERROR")
            {
                return;
            }
            if (nudNumCuota.Value <= 0)
            {
                MessageBox.Show("Por favor ingresar el número de cuotas", "Validación Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            distribuirReprogramacion();
            btnGrabar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarOperacion())
                return;

            if (!ValidarReglas())
                return;

            int idCuotaIni = 1;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem.Date;
            this.dtCalendarioPagos = conPlanPagos.dtCalendarioPagos;

            List<clsCuota> lstCuotasPagadas = (from item in this.objPlanPagos where item.idEstadocuota == 2 select item).ToList();
            int idCuotaIniGastos = lstCuotasPagadas.Count + 1;

            DataTable dtGastos = this.objCNPlanPago.ObtenerGastos(this.idSolicitud);
            
            this.objPlanPagosNuevo = this.objCNPlanPago.PlanPagosFinalReprogramacion(this.objPlanPagos, this.dtCalendarioPagos, this.dFechaUltimoPago, txtTasaInteres.nDecValor, dtGastos);

            DataTable dtPlanCuotasPagadas = this.objCNPlanPago.ConvertToDataTablePlanPagos(lstCuotasPagadas, this.idSolicitud);

            bool existeColumna = false;
            bool existeColumnaPaquete = false;
            if (!dtPlanCuotasPagadas.Columns.Contains("seguro"))
            {
                existeColumna = true;
                DataColumn segurosColumn = new DataColumn("seguro", typeof(decimal));
                segurosColumn.DefaultValue = 0;
                dtPlanCuotasPagadas.Columns.Add(segurosColumn);
            }

            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (lstPaqueteSeguros.Count > 0)
            {
                if (!dtPlanCuotasPagadas.Columns.Contains("paquete"))
                {
                    existeColumnaPaquete = true;
                    DataColumn segurosColumn = new DataColumn("paquete", typeof(decimal));
                    segurosColumn.DefaultValue = 0;
                    dtPlanCuotasPagadas.Columns.Add(segurosColumn);
                }
            }

            var enumCuotas = dtPlanCuotasPagadas.AsEnumerable()
                                                .Union(this.dtCalendarioPagos.AsEnumerable())
                                                .OrderBy(x => x.Field<DateTime>("fecha"));

            DataTable dtPlanPagos = enumCuotas.Any() ? enumCuotas.CopyToDataTable() : this.dtCalendarioPagos.Clone();

            foreach (DataRow drCuota in dtPlanPagos.Rows)
            {
                drCuota["cuota"] = idCuotaIni++;
            }

            idCuotaIni = 1;
            foreach (clsCuota cuota in this.objPlanPagosNuevo)
            {
                cuota.idCuota = idCuotaIni++;
            }

            foreach (DataRow drGasto in dtGastos.Rows)
            {
                drGasto["idCuota"] = drGasto.Field<int>("idCuota") + idCuotaIniGastos - 1;
                drGasto["idCuenta"] = objSolicitudReprogramacion.idCuenta;
            }

            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta),
                             "Inicio - Registro de Reprogramación", btnGrabar);

            tbcReprograma.SelectedIndex = 2;

            List<clsCuota> objPlanPagos = this.objPlanPagosNuevo.Where(item => item.dFechaProg < clsVarGlobal.dFecSystem && item.idEstadocuota == 1).Cast<clsCuota>().ToList();
            decimal nTotalPendiente = objPlanPagos.Sum(item => item.nCapitalSaldo) +
                                        objPlanPagos.Sum(item => item.nInteresSaldo) +
                                        objPlanPagos.Sum(item => item.nMoraSaldo) +
                                        objPlanPagos.Sum(item => item.nOtrosSaldo) +
                                        objPlanPagos.Sum(item => item.nIntCompSaldo);

            string cMensaje = "¿Está seguro de realizar la reprogramación?";
            if (objPlanPagos.Count > 0)
            {
                cMensaje = "El crédito tiene " + objPlanPagos.Count + " Cuota" + ((objPlanPagos.Count > 1) ? "s" : String.Empty) + " Atrasadas" + ((objPlanPagos.Count > 1) ? "s" : String.Empty) + " a la fecha.\nLa suma total de las cuotas seran: S/." + nTotalPendiente + "\n" + cMensaje;
            }


            DialogResult result = MessageBox.Show(cMensaje, "Validación fecha",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            DataSet ds = new DataSet("dsReprogramacion");

            dtGastos.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtGastos);

            dtModificaciones = conPlanPagos.dtModificaciones;
            dtModificaciones.TableName = "dtModificaciones";
            ds.Tables.Add(dtModificaciones);

            DataTable dtDatCred = new DataTable("dtCreditos");
            dtDatCred.Columns.Add("idCuenta", typeof(int));
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof(decimal));
            dtDatCred.Columns.Add("nTCEA", typeof(decimal));
            dtDatCred.Columns.Add("nTEA", typeof(decimal));
            dtDatCred.Rows.Add(this.objSolicitudCreditoDetalle.idCuenta, this.lAplicaSeguro, this.nCapitalMaxCobSeg, this.objCNPlanPago.nMontoCuota, conPlanPagos.txtTCEA.nDecValor, conPlanPagos.txtTEA.nDecValor);

            ds.Tables.Add(dtDatCred);

            string xmlReprogramacion = ds.GetXml();
            xmlReprogramacion = clsCNFormatoXML.EncodingXML(xmlReprogramacion);
            ds.Tables.Clear();
            int idUsuario = clsVarGlobal.User.idUsuario;
            clsDBResp objDebResp = this.objCNPlanPago.RegistrarReprogramacion(this.objSolicitudCreditoDetalle.idCuenta, this.objSolicitudCreditoDetalle.idSolicitud, this.objSolicitudCreditoDetalle.ndiasgracia,
                this.objPlanPagosNuevo, xmlReprogramacion, dFechaSistema, idUsuario);

            if (existeColumna) dtPlanCuotasPagadas.Columns.Remove("seguro");
            if (lstPaqueteSeguros.Count > 0 && existeColumnaPaquete) dtPlanCuotasPagadas.Columns.Remove("Paquete");
            
            if (objDebResp.nMsje == 0)
            {
                MessageBox.Show("Se registró correctamente la reprogramación. A continuación imprima el nuevo plan de pagos",
                                "Registro de Reprogramación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                conPlanPagos.dFechaDesembolso = this.objPlanPagos.First().dFechaDesembolso;
                conPlanPagos.dtgCalendario.DataSource = dtPlanPagos;
                Pintargrid(1, lstCuotasPagadas.Count);
                btnGrabar.Enabled = false;
                btnProcesar.Enabled = false;
                btnCancelar.Enabled = true;
                btnImprimir.Enabled = true;

                conPlanPagos.grbEditor.Enabled = false;

                /*  Guardar Expedientes - Reprogramacion de Credito  */
                clsProcesoExp.guardarCopiaExpediente("Reprogramacion de Credito", this.idSolicitud, this);
            }

            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta),
                             "Fin - Registro de Reprogramación", btnGrabar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = false;
            btnProcesar.Enabled = false;
            btnChecklist.Enabled = false;
            tbcReprograma.SelectedIndex = 0;
            conPlanPagos.grbEditor.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
            conDatosReprogramacion.limpiarDatos();
        }

        private void conPlanPagos_clickModificaciones(object sender, EventArgs e)
        {
            cargarGastosManuales();
        }

        private void conPlanPagos_ModificacionesCanceladas(object sender, EventArgs e)
        {
            cargarGastosManuales();
        }

        private void dtpFecPrimeraCuota_ValueChanged(object sender, EventArgs e)
        {
            int nDiasGracia = 0;

            if (this.objSolicitudCreditoDetalle.idTipoPeriodo == 1)
            {
                int nPlazoCuota = this.objSolicitudCreditoDetalle.nPlazoCuota;
                DateTime dFecPrimeraCuota = this.dtpFecPrimeraCuota.Value;
                DateTime dFecSiguienteCuota;
                int nAnio = this.objSolicitudCreditoDetalle.dFechaUltPago.Year;
                int nMes = this.objSolicitudCreditoDetalle.dFechaUltPago.Month;

                nMes++;
                if (nMes > 12)
                {
                    nMes = 1;
                    nAnio = nAnio + 1;
                }

                while (!DateTime.TryParse(string.Concat(nAnio.ToString(), "-",
                   nMes.ToString(), "-", nPlazoCuota.ToString()), out dFecSiguienteCuota))
                {
                    nPlazoCuota--;
                }

                nDiasGracia = (int)(this.dtpFecPrimeraCuota.Value - this.objSolicitudCreditoDetalle.dFechaUltPago).TotalDays;
                int nDiasSiguienteCuota = (int)(dFecSiguienteCuota - this.objSolicitudCreditoDetalle.dFechaUltPago).TotalDays;
                if (nDiasGracia >= nDiasSiguienteCuota)
                {
                    nDiasGracia = nDiasGracia - nDiasSiguienteCuota;
                }
                else
                {
                    DateTime dFecCuotaCero = new DateTime();
                    int nPlazoCuotaCero = this.objSolicitudCreditoDetalle.nPlazoCuota;
                    int nMesCero = this.objSolicitudCreditoDetalle.dFechaUltPago.Month;
                    int nAnioCero = this.objSolicitudCreditoDetalle.dFechaUltPago.Year;

                    while (!DateTime.TryParse(string.Concat(nAnioCero.ToString(), "-",
                        nMesCero.ToString(), "-", nPlazoCuotaCero.ToString()), out dFecCuotaCero))
                    {
                        nPlazoCuotaCero--;
                    }

                    if (dFecCuotaCero > this.objSolicitudCreditoDetalle.dFechaUltPago)
                    {
                        nDiasGracia = (int)(this.dtpFecPrimeraCuota.Value - dFecCuotaCero).TotalDays;
                    }
                    else
                    {
                        nDiasGracia = nDiasGracia - nDiasSiguienteCuota;
                    }
                }
            }
            else
            {
                int nDiasPrimeraCuota = 0;
                nDiasPrimeraCuota = (int)(this.dtpFecPrimeraCuota.Value - this.objSolicitudCreditoDetalle.dFechaUltPago).TotalDays;
                nDiasGracia = nDiasPrimeraCuota - this.objSolicitudCreditoDetalle.nPlazoCuota;

            }
            this.objSolicitudCreditoDetalle.ndiasgracia = nDiasGracia;
            this.nudDiasGracia.Value = nDiasGracia;
        }
        #endregion

        #region Metodos
        private void inicializarDatos()
        {
            this.objCNPlanPago = new clsCNPlanPago();
            this.objCNSolicitud = new clsCNSolicitud();
            this.objSolicitudCreditoDetalle = new clsSolicitudCreditoDetalle();
            this.objSolicitudReprogramacion = new clsSolicitudReprogramacion();
        }
        private bool ValidarReglas()
        {
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            string cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglas(dtTablaParametros: dtParametros,
                                                                                  cNombreFormulario: this.Name,
                                                                                  idAgencia: clsVarGlobal.nIdAgencia,
                                                                                  idCliente: 0,
                                                                                  idEstadoOperac: 1,
                                                                                  idMoneda: 1,
                                                                                  idProducto: 1,
                                                                                  nValAproba: 0,
                                                                                  idDocument: 0,
                                                                                  dFecSolici: clsVarGlobal.dFecSystem,
                                                                                  idMotivo: 0,
                                                                                  idEstadoSol: 1,
                                                                                  idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                                  idSolApr: ref nNivAuto);

            return cCumpleReglas.Equals("Cumple");
        }

        private bool ValidarOperacion()
        {
            if (conPlanPagos.dtgCalendario.DataSource == null)
            {
                MessageBox.Show("Aún no se ha generado el plan de pagos, por favor procesar", "Validación fecha",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (conPlanPagos.dtgCalendario.Rows.Count <= 0)
            {
                MessageBox.Show("Aún no se ha generado el plan de pagos, por favor procesar", "Validación fecha",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            DateTime dFechaPrimerPago = conPlanPagos.dtCalendarioPagos.AsEnumerable().Min(x => x.Field<DateTime>("fecha"));
            DateTime dFechaFinPpg = this.objPlanPagos.Max(x => x.dFechaProg);
            DateTime dFechaNewMax = conPlanPagos.dtCalendarioPagos.AsEnumerable().Max(x => x.Field<DateTime>("fecha"));

            DateTime dFechaMaxReprograma = (this.objSolicitudCreditoDetalle.idTipoPeriodo == 1) ?
                dFechaFinPpg.AddMonths(1) :
                dFechaFinPpg.AddDays(this.objSolicitudCreditoDetalle.nPlazoCuota);

            if (!this.objSolicitudCreditoDetalle.idTipoPlanPago.In(
                (int)TipoPlanPago.ReprogCuotaConstante, (int)TipoPlanPago.ReprogModifCalendario, (int)TipoPlanPago.ReprogPerdonDias,
                (int)TipoPlanPago.CalendarioInteresComp) &&
                dFechaPrimerPago.Date < clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de primera pago no puede ser menor a la fecha del sistema.", "Validación fecha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarSolicitudPendientePaquete())
            {
                return false;
            }

            return true;
        }

        private void CargarDatos()
        {

            this.objSolicitudReprogramacion = this.objCNSolicitud.obtenerSolicitudReprogramacion(this.idSolicitud);

            if (this.objSolicitudReprogramacion.idSoliCambio == 0)
            {
                MessageBox.Show("No se tiene solicitudes de reprogramación", "Validación solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCuentaCli.LiberarCuenta();
                limpiarControles();
                btnProcesar.Enabled = false;
                btnChecklist.Enabled = false;
                return;
            }

            DataTable dtSolExtorno = this.objCNSolicitud.CNObtenerSolicitudExtornoPendiente(objSolicitudReprogramacion.idCuenta);

            if (dtSolExtorno.Rows.Count > 0)
            {
                int idSolAproba = Convert.ToInt32(dtSolExtorno.Rows[0]["idSolAproba"]);
                string cEstadoSol = Convert.ToString(dtSolExtorno.Rows[0]["cEstadoSol"]);

                MessageBox.Show("La cuenta tiene la solicitud de Extorno Nro: " + idSolAproba + " con estado: " + cEstadoSol + " ", "Validación solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCuentaCli.LiberarCuenta();
                limpiarControles();
                btnProcesar.Enabled = false;
                btnChecklist.Enabled = false;

                return;
            }

            /*if (this.objSolicitudReprogramacion.nSaldoCapitalOrigen != this.objSolicitudReprogramacion.nCapitalAprobado)
            {
                MessageBox.Show("El CAPITAL APROBADO no coinside con el SALDO CAPITAL del crédito a reprogramar\n"
                    + "Comunique a su aprobador para que realice la ACTUALIZACION respectiva", "CAPITAL APROBADO DESACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }*/

            if (this.objSolicitudReprogramacion.idOperacion != (int)OperacionCredito.ReprogramacionSBS && this.objSolicitudReprogramacion.nAtrasoCuota > 0)
            {
                MessageBox.Show("El CREDITO presenta ATRASO DE " + this.objSolicitudReprogramacion.nAtrasoCuota + " DIAS en su proxima cuota.\n"
                    + "El cliente debe regularizar su cuota, luego realizar una nueva solicitud de reprogramación.", "CAPITAL APROBADO DESACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.objSolicitudReprogramacion.idOperacion == (int)OperacionCredito.ReprogramacionCambioMoneda)
            {
            }

            this.objSolicitudCreditoDetalle = this.objCNSolicitud.obtenerSolicitudCreditoDetalle(this.idSolicitud);
            if (this.objSolicitudReprogramacion.idOperacion.In(3, 12, 13, 14, 15, 16))
            {
                nudDiasGracia.Maximum = 360;
            }
            else
            {
                nudDiasGracia.Maximum = 180;
            }

            dtpFecDesembolso.Value = clsVarGlobal.dFecSystem.Date;
            txtMonAprobado.Text = this.objSolicitudCreditoDetalle.nCapitalAprobado.ToString("#,0.00");
            nudNumCuota.Value = this.objSolicitudCreditoDetalle.nCuotas;
            nudDiasGracia.Value = this.objSolicitudCreditoDetalle.ndiasgracia;
            cboTipoPeriodo.SelectedValue = this.objSolicitudCreditoDetalle.idTipoPeriodo;
            nudPeriodo.Value = this.objSolicitudCreditoDetalle.nPlazoCuota;
            txtTasaInteres.Text = this.objSolicitudCreditoDetalle.nTasaCompensatoria.ToString("#,0.0000");
            cboMoneda.SelectedValue = this.objSolicitudCreditoDetalle.IdMoneda;

            clsCredito objCredito = new CRE.CapaNegocio.clsCNCredito().retornaDatosCredito(this.objSolicitudCreditoDetalle.idCuenta);
            this.dFecDesembolsoCred = objCredito.dFechaDesembolso;

            clsPlanPago objPlanPagoActual = this.objCNPlanPago.retonarPlanPagoTotal(this.objSolicitudCreditoDetalle.idCuenta);
            dtgPpgActual.DataSource = objPlanPagoActual;

            this.objPlanPagos = this.objCNPlanPago.retonarPlanPagoTotal(this.objSolicitudCreditoDetalle.idCuenta);

            this.nCuotasPagadas = this.objPlanPagos.Count(x => x.idEstadocuota == 2);

            this.dFechaUltimoPago = this.objSolicitudCreditoDetalle.dFechaUltPago;

            this.dFecPrimeraCuotaPendiente = this.objPlanPagos.Where(x => x.idEstadocuota == 1).Min(x => x.dFechaProg);

            dtpFecDesembolso.Value = this.dFechaUltimoPago;
            if (this.objSolicitudReprogramacion.idTipoPlanPago.In((int)TipoPlanPago.CalendarioInteresComp))
            {
                dtpFecPrimeraCuota.Enabled = false;
            }
            else
            {
                dtpFecPrimeraCuota.Enabled = true;
            }

            this.calcularFechaPrimeraCuota();
            btnProcesar.Enabled = true;
            btnChecklist.Enabled = true;

            //Validar que no exista una solicitud pendiente o aprobada
            DataTable SolicDuplicada = new clsCNCondonacion().DatosSolicCond(conBusCuentaCli.nIdCliente, this.objSolicitudCreditoDetalle.idCuenta);
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show(
                                string.Format(
                                              "Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   {0}\n \tAgencia:   {1}\n \tFecha:   {2}",
                                              SolicDuplicada.Rows[0]["cNombre"], SolicDuplicada.Rows[0]["cNombreAge"],
                                              Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"])
                                                     .ToShortDateString()), "Solicitud de Condonación",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnProcesar.Enabled = false;
                btnChecklist.Enabled = false;
                return;
            }

            if (this.objSolicitudCreditoDetalle.idTipoPeriodo == 1)
            {
                lblBase6.Text = "Día de Pago:";
                nudPeriodo.Maximum = 31;
            }
            else
            {
                lblBase6.Text = "Frecuencia:";
                nudPeriodo.Maximum = 1800;
            }
            conDatosReprogramacion.cargarComponentes(this.objSolicitudCreditoDetalle.idCuenta, false, true);

            dtgPpgActual.CellFormatting += dtgPpgActual_CellFormatting;
        }

        private void calcularFechaPrimeraCuota()
        {

            int idTipoPeriodo = this.objSolicitudCreditoDetalle.idTipoPeriodo;
            int nPlazoCuota = this.objSolicitudCreditoDetalle.nPlazoCuota;
            int nDiasGracia = this.objSolicitudCreditoDetalle.ndiasgracia;
            DateTime dFechaUltPago = this.objSolicitudCreditoDetalle.dFechaUltPago;
            DateTime dFecSiguienteCuota = new DateTime();

            if (nPlazoCuota == 0)
            {
                this.dtpFecPrimeraCuota.Value = this.objSolicitudCreditoDetalle.dFechaProximoVencimiento;
                return;
            }
            dtpFecPrimeraCuota.ValueChanged -= dtpFecPrimeraCuota_ValueChanged;
            if (idTipoPeriodo == 1)
            {
                int nAnio = dFechaUltPago.Year;
                int nMes = dFechaUltPago.Month;
                nMes++;
                if (nMes > 12)
            {
                    nMes = 1;
                    nAnio = nAnio + 1;
                }

                while (!DateTime.TryParse(string.Concat(nAnio.ToString(), "-",
                    nMes.ToString(), "-", nPlazoCuota.ToString()), out dFecSiguienteCuota))
                {
                    nPlazoCuota--;
                }
                this.objSolicitudCreditoDetalle.nPlazoCuota = nPlazoCuota;

                dtpFecPrimeraCuota.Value = dFecSiguienteCuota.AddDays(objSolicitudCreditoDetalle.ndiasgracia);
            }
            else
            {
                dtpFecPrimeraCuota.Value = dFechaUltPago.AddDays(nDiasGracia + nPlazoCuota);
            }
            dtpFecPrimeraCuota.ValueChanged += dtpFecPrimeraCuota_ValueChanged;
        }

        private void limpiarControles()
        {
            this.idSolicitud = 0;
            this.objPlanPagos = null;

            nudNumCuota.Value = 1;
            nudPeriodo.Value = 1;
            nudDiasGracia.Value = 0;
            txtMonAprobado.Text = "0.00";
            txtTasaInteres.Text = "0.0000";
            conPlanPagos.limpiarControlesTotales();
            conPlanPagos.dtgCalendario.DataSource = null;
            conBusCuentaCli.Enabled = true;
            conBusCuentaCli.LiberarCuenta();
            conBusCuentaCli.limpiarControles();
            dtgPpgActual.DataSource = null;
            dtgConfigGasto.DataSource = null;
            conPlanPagos.dtModificaciones.Rows.Clear();
            conPlanPagos.dtgModificaciones.DataSource = conPlanPagos.dtModificaciones;

            this.nCapitalMaxCobSeg = 0.0m;
            this.lAplicaSeguro = true;
        }

        private void distribuirReprogramacion()
        {
            decimal nSaldoCapitalCuenta = this.objSolicitudReprogramacion.nCapitalAprobado;
            //decimal nMontoDistribuir = nSaldoCapitalCuenta;
            decimal nMontoDistribuir = this.objPlanPagos.Where(x => x.idEstadocuota == 1).Sum(y => y.nCapital);

            txtMonAprobado.Text = string.Format("{0:#,0.00}", nSaldoCapitalCuenta);
            dtpFecDesembolso.Value = this.dFechaUltimoPago;
            
            #region Calculo de Plan de pago incluye variaciones

            decimal nTasaEfectivaMensual = txtTasaInteres.nDecValor / 100.00m;

            //VALIDANDO MULTIRIESGO EXISTENTE
            clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsCNCreditoCargaSeguro().CNObtenerSolicitudCargaSeguro(objSolicitudCreditoDetalle.idSolicitud);
            if (!objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado)
            {
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lVigente = validarMultiriesgoExistente(objSolicitudCreditoCargaSeguro.idCli);
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).nMontoCobertura = nMontoDistribuir;
            }

            bool lAplicaNuevoMultirriesgo = objCNCreditoCargaSeguro.CNValidaNuevoSeguroMultiriesgo(idSolicitud);
            
            //VALIDANDO PAQUETE SEGURO EXISTENTE
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            if (lstPaqueteSeguros.Count > 0)
            {
                var tiposSeguroEnSolicitud = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.lSeleccionado && lstPaqueteSeguros.Any(y => y.idTipoSeguro == x.idTipoSeguro));
                if (tiposSeguroEnSolicitud == null)
                {
                    int paq = validarPlanSeguroExistente(objSolicitudCreditoCargaSeguro.idCli);
                    if (paq > 0)
                    {
                        foreach (var item in objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro)
                        {
                            if (item.idTipoSeguro == paq)
                            {
                                item.lSeleccionado = item.lVigente = true;
                                item.nMontoCobertura = nMontoDistribuir;
                                break;
                            }
                        }
                    }
                }
            }

            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = dtpFecPrimeraCuota.Value.Date;
           
            dtCuotasDobles = this.objCNPlanPago.retornarCuotasDobles(dtModificaciones, this.dFechaUltimoPago, this.objSolicitudCreditoDetalle.nCuotas);
            //Generar el plan de pagos manteniendo o no las cuotas a pagar constantes

            this.conPlanPagos.AsignaObjetoSeguroOptativo(objSolicitudCreditoCargaSeguro);

            this.dtCalendarioPagos = this.objCNPlanPago.CalculaPpgCuotasConstantes2(
                nMontoDistribuir,
                nTasaEfectivaMensual,
                this.dFechaUltimoPago,
                this.objSolicitudCreditoDetalle.nCuotas,
                this.objSolicitudCreditoDetalle.ndiasgracia,
                (short)this.objSolicitudCreditoDetalle.idTipoPeriodo,
                this.objSolicitudCreditoDetalle.nPlazoCuota,
                this.idSolicitud,
                dtConfigGastos,
                this.objSolicitudCreditoDetalle.IdMoneda,
                dtCuotasDobles,
                dtpFecPrimeraCuota.Value.Date,
                0,
                this.nCapitalMaxCobSeg,
                0,
                chcMantenerCuotasCtes.Checked,
                0,
                objSolicitudCreditoCargaSeguro,
                lAplicaNuevoMultirriesgo
                );

            this.dtCalendarioPagos = this.objCNPlanPago.AgregarGastosManualesReprogramacion(this.dtCalendarioPagos, this.dFechaUltimoPago, this.objSolicitudReprogramacion, this.conPlanPagos.dtModificaciones);

            this.objCNPlanPago.calcularInteresCompReprog(this.dtCalendarioPagos, this.objSolicitudCreditoDetalle.nTasaCompensatoria);

            tbcReprograma.SelectedIndex = 2;

            conPlanPagos.dtCalendarioPagos = this.dtCalendarioPagos;
            conPlanPagos.dtCargaGastos = dtConfigGastos;
            conPlanPagos.dtGastosPP = this.objCNPlanPago.ObtenerGastos(this.idSolicitud);
            conPlanPagos.nTipPeriodo = (short)this.objSolicitudCreditoDetalle.idTipoPeriodo;
            conPlanPagos.nNumCuotas = this.objSolicitudCreditoDetalle.nCuotas;
            conPlanPagos.dFechaDesembolso = this.dFechaUltimoPago;
            conPlanPagos.nMonto = nMontoDistribuir;
            conPlanPagos.nPlazo = this.objSolicitudCreditoDetalle.nPlazoCuota;
            conPlanPagos.nDiasGracia = this.objSolicitudCreditoDetalle.ndiasgracia;
            conPlanPagos.nTasaInteres = txtTasaInteres.nDecValor;
            conPlanPagos.idMoneda = this.objSolicitudCreditoDetalle.IdMoneda;
            conPlanPagos.lCuotaCte = chcMantenerCuotasCtes.Checked;
            conPlanPagos.dFecPriCuota = dtpFecPrimeraCuota.Value.Date;
            conPlanPagos.cnplanpago = this.objCNPlanPago;
            conPlanPagos.IdSolicitud = this.idSolicitud;
            conPlanPagos.nCapitalMaxCobSeg = this.nCapitalMaxCobSeg;
            conPlanPagos.dtModificaciones.Rows.Clear();
            conPlanPagos.dtgModificaciones.DataSource = conPlanPagos.dtModificaciones;
            conPlanPagos.idTipoPlanPago = objSolicitudReprogramacion.idTipoPlanPago;

            conPlanPagos.cargarDatos();

            #endregion

            Pintargrid(0, 0);
        }

        private bool validarMultiriesgoExistente(int nIdcli)
        {
            DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(nIdcli);
            DataRow dr = (from x in dtLsSeguros.AsEnumerable() where x.Field<bool>("lVigente") == true && x.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"]) select x).FirstOrDefault();
            return dr != null;
        }

        private int validarPlanSeguroExistente(int nIdcli)
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(nIdcli);
            //Valido si existe data en dtLsSeguros
            if (dtLsSeguros.Rows.Count == 0)
                return 0;

            DataRow dr = (from x in dtLsSeguros.AsEnumerable()
                          where x.Field<bool>("lVigente") && lstPaqueteSeguros.Select(p => p.idConcepto).Contains(x.Field<int>("idConcepto"))
                          select x).FirstOrDefault();

            if (dr == null)
                return 0;

            var tiposSeguroEnSolicitud = lstPaqueteSeguros.FirstOrDefault(y => y.idConcepto== dr.Field<int>("idConcepto"));

            if (tiposSeguroEnSolicitud == null)
                return 0;

            return tiposSeguroEnSolicitud.idTipoSeguro;
        }
        
        private void Pintargrid(int nOpcion, int nNumCuoPagadas)
        {
            if (nOpcion == 0)
            {
                foreach (DataGridViewRow row in conPlanPagos.dtgCalendario.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            else
            {
                for (int i = 0; i < conPlanPagos.dtgCalendario.Rows.Count; i++)
                {
                    if (i < nNumCuoPagadas)
                        conPlanPagos.dtgCalendario.Rows[i].DefaultCellStyle.BackColor = Color.NavajoWhite;

                    if (i >= nNumCuoPagadas)
                        conPlanPagos.dtgCalendario.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void cargarEstructuradtModifica()
        {
            dtModificaciones = new DataTable("dtModificaciones");

            dtModificaciones.Columns.Add("cTipoAccion", typeof(string));
            dtModificaciones.Columns.Add("idTipoAccion", typeof(int));
            dtModificaciones.Columns.Add("nCuota", typeof(int));
            dtModificaciones.Columns.Add("nOtraCuota", typeof(int));
            dtModificaciones.Columns.Add("nMes", typeof(int));
            dtModificaciones.Columns.Add("cMes", typeof(string));
            dtModificaciones.Columns.Add("nAnio", typeof(int));
            dtModificaciones.Columns.Add("cAnio", typeof(string));
            dtModificaciones.Columns.Add("nMonto", typeof(decimal));
            dtModificaciones.Columns.Add("lIndTodAnios", typeof(bool));
        }

        private void cargarConfiguracionesDeGasto()
        {
            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            objSegDes.validarAplicaSeguroDesgravamen(0, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal, 0, this.objSolicitudCreditoDetalle.idCuenta);
            this.nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            this.lAplicaSeguro = objSegDes.obternerNAplicaSeguro();

            dtConfigGastos = new clsCNConfigGastComiSeg().CNGetConfigGastosCuenta(this.objSolicitudCreditoDetalle.idCuenta);

            dtgConfigGasto.DataSource = dtConfigGastos;
            formatearGastos();
        }

        /// <summary>
        /// Aplica estilo a Grid de Configuraciones de Gasto Aplicables
        /// </summary>
        private void formatearGastos()
        {
            dtgConfigGasto.ReadOnly = false;
            foreach (DataColumn column in dtConfigGastos.Columns)
            {
                column.ReadOnly = false;
            }
            foreach (DataGridViewColumn column in dtgConfigGasto.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgConfigGasto.Columns["lObligatorio"].Visible = true;
            dtgConfigGasto.Columns["cIdCuota"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoGasto"].Visible = true;
            dtgConfigGasto.Columns["nValor"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoValor"].Visible = true;
            dtgConfigGasto.Columns["cMoneda"].Visible = true;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].Visible = true;

            dtgConfigGasto.Columns["lObligatorio"].HeaderText = "Aplicar ";
            dtgConfigGasto.Columns["cIdCuota"].HeaderText = "Cuota";
            dtgConfigGasto.Columns["cIdTipoGasto"].HeaderText = "Tipo de Gasto";
            dtgConfigGasto.Columns["nValor"].HeaderText = "Valor";
            dtgConfigGasto.Columns["cIdTipoValor"].HeaderText = "Tipo de Valor";
            dtgConfigGasto.Columns["cMoneda"].HeaderText = "Moneda";
            dtgConfigGasto.Columns["cIdAplicaConcepto"].HeaderText = "Aplicar al concepto";

            dtgConfigGasto.Columns["lObligatorio"].FillWeight = 5;
            dtgConfigGasto.Columns["cIdCuota"].FillWeight = 15;
            dtgConfigGasto.Columns["cIdTipoGasto"].FillWeight = 20;
            dtgConfigGasto.Columns["nValor"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdTipoValor"].FillWeight = 15;
            dtgConfigGasto.Columns["cMoneda"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].FillWeight = 25;

            dtgConfigGasto.Columns["lObligatorio"].ReadOnly = false;

            //Dar permisos de lectura/Escritura al campo obligatorio
            for (int i = 0; i < dtgConfigGasto.Rows.Count; i++)
            {
                var dgcCampoObligatorio = dtgConfigGasto.Rows[i].Cells["lObligatorio"];
                dgcCampoObligatorio.ReadOnly = Convert.ToBoolean(dgcCampoObligatorio.Value);
            }
        }

        private void cargarGastosManuales()
        {
            if (conPlanPagos.dtCalendarioPagos == null)
                return;

            this.dtCalendarioPagos = conPlanPagos.dtCalendarioPagos;
            this.dtCalendarioPagos = this.objCNPlanPago.AgregarGastosManualesReprogramacion(this.dtCalendarioPagos, conPlanPagos.dFechaDesembolso, this.objSolicitudReprogramacion, this.conPlanPagos.dtModificaciones);
            conPlanPagos.dtCalendarioPagos = this.dtCalendarioPagos;

            conPlanPagos.CargarGridPlanPagos();
            Pintargrid(0, 0);
        }

        private DataTable ArmarTablaParametros()
        {
            int idCli = conBusCuentaCli.nIdCliente;

            DateTime dFecProxPago = Convert.ToDateTime(conPlanPagos.dtCalendarioPagos.Rows[0]["fecha"]);

            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            //Obtenemos los datos generales del cliente

            DataTable dtDatCli = new clsCNBuscarCli().GetDatosGenCli(idCli);

            if (dtDatCli.Rows.Count > 0)
            {
                foreach (DataColumn column in dtDatCli.Columns)
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                                               column.DataType == typeof(DateTime)
                                                   ? ((DateTime)dtDatCli.Rows[0][column.ColumnName]).ToString(
                                                                                                               "yyyy-MM-dd")
                                                   : dtDatCli.Rows[0][column.ColumnName].ToString());
                }
            }


            DataTable dtDatSolCre = new clsCNSolicitud().CNGetDatGenCreSolCre(this.idSolicitud);

            foreach (DataColumn column in dtDatSolCre.Columns)
            {
                dtTablaParametros.Rows.Add(column.ColumnName,
                                           column.DataType == typeof(DateTime)
                                               ? ((DateTime)dtDatSolCre.Rows[0][column.ColumnName]).ToString(
                                                                                                              "yyyy-MM-dd")
                                               : dtDatSolCre.Rows[0][column.ColumnName].ToString());
            }

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipCamFij";
            drfila[1] = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.Year.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaProxPago";
            drfila[1] = string.Format("'{0:yyyy-MM-dd}'", dFecProxPago);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaProxPagoActual";
            drfila[1] = string.Format("'{0:yyyy-MM-dd}'", this.dFecPrimeraCuotaPendiente);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        #endregion

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli.txtNroBusqueda.Text != "")
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(this.conBusCuentaCli.txtNroBusqueda.Text), false, true);
                frmCargaArchivo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Solicitud", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string ValidarChecklist()
        {
            string cRpta = "OK";
            string cXmlCheckList = "";
            DataTable dtResCheckList_ = new DataTable("dtLista");
            DataTable dtResCheckList = clsFiles.DtObtenerTipoGrupoArchivoCheckList(Convert.ToInt32(this.conBusCuentaCli.txtNroBusqueda.Text), false);
            dtResCheckList_.Merge(dtResCheckList);
            DataSet dsResCheckListTemp = new DataSet("dsCheckList");
            dsResCheckListTemp.Tables.Add(dtResCheckList_);
            cXmlCheckList = dsResCheckListTemp.GetXml();
            bool lLista = false;
            DataSet dsResPendientes = clsFiles.listarSolicitudesCreditoObsPendientes(cXmlCheckList, lLista);
            DataTable dtResPendientes = dsResPendientes.Tables[0];
            if (dtResPendientes.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud de crédito todavía cuenta con uno o más documentos que deben ser revisados - Debe ingresar al botón de Checklist.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            return cRpta;
        }

        private void dtgPpgActual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dtgPpgActual.Columns["nOtros"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private void dtgPpgActual_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgPpgActual.Columns[e.ColumnIndex].Name == "nOtros")
                {
                    DataGridViewRow selectedRow = dtgPpgActual.Rows[e.RowIndex];
                    string nCuenta = this.objSolicitudCreditoDetalle.idCuenta.ToString();

                    List<clsOtrosGastos> listaGastos = DataTableToList.ConvertTo<clsOtrosGastos>(new clsCNCargaGastosCred().listarGastosPorCuenta(Convert.ToInt32(nCuenta))) as List<clsOtrosGastos>;
                    frmDetalleOtrosGastos detalleForm = new frmDetalleOtrosGastos();
                    DataGridView dataGridViewDetalleGastos = detalleForm.dtgDetalleGastos;


                    var query = from gasto in listaGastos
                                join concepto in lstConceptos on gasto.idTipoGasto equals concepto.idConcepto
                                select new
                                {
                                    gasto.idCuota,
                                    concepto.cNombreCorto,
                                    gasto.nGasto
                                };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuota", typeof(string));

                    foreach (var item in query)
                    {
                        if (!dataTable.Columns.Contains(item.cNombreCorto))
                            dataTable.Columns.Add(item.cNombreCorto, typeof(decimal));

                        DataRow existingRow = null;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (Convert.ToInt32(row["Cuota"]) == item.idCuota)
                            {
                                existingRow = row;
                                break;
                            }
                        }

                        if (existingRow == null)
                        {
                            existingRow = dataTable.NewRow();
                            existingRow["Cuota"] = item.idCuota;
                            dataTable.Rows.Add(existingRow);
                        }
                        existingRow[item.cNombreCorto] = item.nGasto;
                    }

                    dataTable.Columns.Add("Total", typeof(decimal));

                    DataRow totalRow = dataTable.NewRow();

                    int totalFilas = dataTable.Rows.Count;
                    int totalColumnas = dataTable.Columns.Count;

                    decimal[] sumatorias = new decimal[totalColumnas];

                    for (int fila = 0; fila < totalFilas; fila++)
                    {
                        for (int columna = 0; columna < totalColumnas; columna++)
                        {
                            object cellValue = dataTable.Rows[fila][columna];
                            if (cellValue != null)
                            {
                                decimal valorCelda;
                                if (decimal.TryParse(cellValue.ToString(), out valorCelda))
                                {
                                    sumatorias[columna] += valorCelda;
                                }
                            }
                        }
                    }
                    DataRow sumRow = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        sumRow[columna] = sumatorias[columna];

                    dataTable.Rows.Add(sumRow);

                    int ultimaFilaIndex = dataTable.Rows.Count - 1;
                    dataTable.Rows[ultimaFilaIndex][0] = "Total";

                    dataGridViewDetalleGastos.DataSource = dataTable;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            if (cell.ColumnIndex > 0 && (cell.Value == null || cell.Value is DBNull))
                            {
                                cell.Value = 0m;
                            }
                        }
                    }

                    dataGridViewDetalleGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dgvRow.Cells.Count; i++)
                        {
                            decimal valor;
                            if (dgvRow.Cells[i].Value != null && decimal.TryParse(dgvRow.Cells[i].Value.ToString(), out valor))
                                total += valor;
                        }
                        dgvRow.Cells["TOTAL"].Value = total;
                    }

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                    {
                        if (columna.Name == "Cuota")
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        else
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dataGridViewDetalleGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dataGridViewDetalleGastos.Columns["Cuota"].Width = 50;
                    dataGridViewDetalleGastos.Columns["Total"].Width = 70;

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                        if (columna.Name != "Cuota" && columna.Name != "Total")
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error interno: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private bool ValidarSolicitudPendientePaquete()
        {
            //Validamos que no existan solicitudes de aprobación en estado pendientes para paquetes de seguro
            DataTable verificacion = new clsCNPaqueteSeguro().CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(objSolicitudReprogramacion.idSolicitud);

            if (verificacion.Rows.Count > 0)
            {
                int x_idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);
                int x_numeroSolicitud = Convert.ToInt32(verificacion.Rows[0]["idSolAproba"]);

                if (x_idEstadoSolicitud == 1) //SOLICITADO
                {
                    string x_mensaje = string.Format(clsVarApl.dicVarGen["cMensajeEstadoSolicitud"], x_numeroSolicitud);
                    MessageBox.Show(x_mensaje, "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar.Enabled = false;
                    return false;
                }
            }

            var x_solicitud = new clsCNSolicitud().SolicitudDesembolso(objSolicitudReprogramacion.idSolicitud);

            if (x_solicitud.Rows.Count > 0)
            {
                bool solicitudRechazada = Convert.ToBoolean(x_solicitud.Rows[0]["SolPlanRechazada"]);

                if (solicitudRechazada)
                {
                    MessageBox.Show("La solicitud ha cambiado de estado, por favor dirigirse al formulario de plan de pagos para generar el cronograma actualizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar.Enabled = false;
                    return false;
                }
            }
            return true;
        }
    }
}
