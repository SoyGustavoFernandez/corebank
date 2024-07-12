using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using EntityLayer.MotorDecisionWebService;

namespace CRE.Presentacion
{
    public partial class frmEvalResumenPreAprob : frmBase
    {
        #region Variables
        private string cMsjCaption = "Evaluación Resumida - Pre Aprobada";

        private clsCNEvaluacion objCapaNegocio;

        private clsEvalCred objEvalCred;
        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsReferenciaEval> listReferencia;
        private List<clsDestCredProp> listDestCredProp;
        private List<int> idProductosAwaWasi;

        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private clsCNEstadosFinancierosResumen objEstadosFinancieros;

        private DateTime dFechaBase;
        private clsCreditoProp objSolicitud;
        private const int nAnioMinimo = 2000;
        private int idTipEvalCred = 17;     //RESUMIDA - PRE APROBADO
        private int idCanal;

        private string cIdProductoNoPasan;
        private string cProductosAWAWASI;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private bool lAgricola;
        private DataTable dtTipReferEval;
        private DataTable dtTipVinculoEval;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private ClsOfertaClienteExclusivo objOferta;

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        private bool lEsMNB;

        clsCNSeleccionarDocEvalAnterior objCNCargaArchivoDocEval = new clsCNSeleccionarDocEvalAnterior();
        #endregion

        public frmEvalResumenPreAprob()
        {
            InitializeComponent();

            this.objCapaNegocio = new clsCNEvaluacion();
            this.objEstadosFinancieros = new clsCNEstadosFinancierosResumen();

            DataSet dsIni = this.objCapaNegocio.CNInicializaEvalResumida();
            //-- Table[0] : Tipos de Referencia Personal
            this.dtTipReferEval = dsIni.Tables[0];

            //-- Table[1] : Tipos de Vinculo x Tipo de Referencia
            this.dtTipVinculoEval = dsIni.Tables[1];

            HabilitarBotones(false);
            this.btnBusqueda.Enabled = true;

            Evaluacion.DataTableMoneda = (new clsCNMoneda()).listarMoneda();

            this.cboMoneda.DisplayMember = "cMoneda";
            this.cboMoneda.ValueMember = "idMoneda";
            this.cboMoneda.DataSource = Evaluacion.DataTableMoneda;

            this.lAgricola = false;
            #region Asignar Datos
            //Evaluacion.DataTableMoneda = this.dtTipMoneda;

            var dtTipoFrecuencia = new DataTable();
            dtTipoFrecuencia.Columns.Add("idFrecuencia", typeof(int));
            dtTipoFrecuencia.Columns.Add("cFrecuencia", typeof(string));
            dtTipoFrecuencia.Columns.Add("cAbreviatura", typeof(string));
            dtTipoFrecuencia.Rows.Add(1, "MENSUAL", "MEN");
            dtTipoFrecuencia.Rows.Add(2, "BIMENSUAL", "BIM");
            dtTipoFrecuencia.Rows.Add(3, "TRIMESTRAL", "TRI");
            dtTipoFrecuencia.Rows.Add(4, "CUATRIMESTRAL", "CUA");
            dtTipoFrecuencia.Rows.Add(5, "QUIMESTRAL", "QUI");
            dtTipoFrecuencia.Rows.Add(6, "SEMESTRAL", "SEM");
            dtTipoFrecuencia.Rows.Add(12, "ANUAL", "ANU");
            Evaluacion.DataTipoFrecuencia = dtTipoFrecuencia;
            #endregion


            this.cboTipoPeriodo.DisplayMember = "cDescripTipoPeriodo";
            this.cboTipoPeriodo.ValueMember = "idTipoPeriodo";
            this.cboTipoPeriodo.DataSource = (new clsCNTipoPeriodo()).dtListaTipoPeriodo();
            tbcCredito.SelectedIndex = 1;
        }

        #region Métodos Privados
        private void RecuperarDatos(int idEvalCred)
        {
            #region Recuperar de DataBase
            DataSet dsResult = this.objCapaNegocio.BuscarEvalRapiCredito(idEvalCred);

            //-- Table[0] : Evaluacion Maestro
            var aEval = DataTableToList.ConvertTo<clsEvalCred>(dsResult.Tables[0]) as List<clsEvalCred>;
            this.objEvalCred = aEval[0];

            this.objEvalCred.idEstablecimiento = (this.objEvalCred.idEstablecimiento == 0) ? clsVarGlobal.User.idEstablecimiento : this.objEvalCred.idEstablecimiento;
            this.objEvalCred.idTipoEstablec = (this.objEvalCred.idTipoEstablec == 0) ? clsVarGlobal.User.idTipoEstablec : this.objEvalCred.idTipoEstablec;

            if (this.objEvalCred.idSolicitud > 0)
            {
                //-- Table[1] : Solicitud del Crédito
                var aSolicitud = DataTableToList.ConvertTo<clsCreditoProp>(dsResult.Tables[1]) as List<clsCreditoProp>;
                if (aSolicitud.Count == 1)
                {
                    this.objSolicitud = aSolicitud[0];
                    this.objSolicitud.idClasificacionInterna = this.objEvalCred.idClasificacionInterna;
                    //btnAdministradorFiles1.idSolicitud = this.objSolicitud.idSolicitud;
                    //btnAdministradorFiles1.actualizarDatos();
                    //btnAdministradorFiles1.Enabled = true;
                    this.btnGestObs.Enabled = true;

                    btnVincularVisita1.idSolicitud = this.objSolicitud.idSolicitud;
                    btnVincularVisita1.idCli = this.objEvalCred.idCli;
                    this.ObtenerOfertaSolicitud(this.objSolicitud.idOferta);
                }
                else
                {
                    MessageBox.Show("La solicitud Nº " + this.objEvalCred.idSolicitud + " no se puede recuperar.",
                        "Recuperando Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se tiene vinculado la evaluación con la solicitud.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //-- Table[2] : Balance General
            this.listBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(dsResult.Tables[2]) as List<clsBalGenEval>;

            //-- Table[3] : Estado de Resultados
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsResult.Tables[3]) as List<clsEstResEval>;

            //-- Table[4] : Indicadores Financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[4]) as List<clsIndicadorEval>;

            //-- Table[6] : Deudas
            List<clsDeudasEval> listaDeudas = DataTableToList.ConvertTo<clsDeudasEval>(dsResult.Tables[6]) as List<clsDeudasEval>;

            this.lAgricola = Convert.ToBoolean(dsResult.Tables[8].Rows[0]["lAgricola"]);

            this.objEstadosFinancieros.listCredDirectos = (List<clsDeudasEval>)listaDeudas.Where(x => x.idTipoDeuda == 1).ToList();
            this.objEstadosFinancieros.listCredIndirect = (List<clsDeudasEval>)listaDeudas.Where(x => x.idTipoDeuda == 2).ToList();

            this.cargaSaldoDeudaProvision();      

            //-- Table[11] : Referencias del Cliente
            this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(dsResult.Tables[11]) as List<clsReferenciaEval>;

            //-- Table[12] : Lista de Sub-Destinos de crédito
            this.dtTipDestCred = dsResult.Tables[12];

            //-- Table[13] : Lista del Detalle de los Destinos de Crédito
            this.dtTipDestCredDetalle = dsResult.Tables[13];

            //-- Table[14] : Destinos de Crédito Propuesto
            this.listDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(dsResult.Tables[14]) as List<clsDestCredProp>;

            #endregion

            if (((DateTime)(this.objEvalCred.dFecUltimaEval)).Year < nAnioMinimo) Evaluacion.FechaUltimaEval = null;
            else Evaluacion.FechaUltimaEval = this.objEvalCred.dFecUltimaEval;

            #region Asignar a Componentes
            // -- Asignar Información general
            this.txtIdEvalCred.Text = String.Format("{0:d8}", this.objEvalCred.idEvalCred);
            this.txtIdSolicitud.Text = (this.objEvalCred.idSolicitud != 0) ? String.Format("{0:d8}", this.objEvalCred.idSolicitud) : "";
            this.txtModCredito.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cModalidadCredito : "";
            this.txtOperacion.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cOperacion : "";
            this.txtTipoCambio.Text = (this.objEvalCred.nTipoCambio != 0) ? this.objEvalCred.nTipoCambio.ToString("n4") : "";

            // -- Asignar Estados Financieros
            this.conEstadosFinancierosResumen.AsignarDatos(this.listBalGenEval, this.listEstResEval, this.listIndiFinanc);

            // -- Asignar Condiciones de crédito y propuesta
            this.txtActPrincipal.Text = this.objEvalCred.cActPriDescripcion;
            this.txtActSecundaria.Text = this.objEvalCred.cActSecDescripcion;
            this.txtDestPrestamo.Text = this.objEvalCred.cComDestCredito;
            this.txtGarantias.Text = this.objEvalCred.cComGarantias;
            this.txtAntecedentes.Text = this.objEvalCred.cComAnteCred;
            this.txtConclusiones.Text = this.objEvalCred.cComConclusiones;

            this.conCreditoTasa.AsignarDatos(new clsCreditoProp()
            {
                idSolicitud = this.objEvalCred.idSolicitud,
                idMoneda = this.objEvalCred.idMoneda,
                nMonto = this.objEvalCred.nCapitalPropuesto,
                nCuotas = this.objEvalCred.nCuotas,
                idTipoPeriodo = this.objEvalCred.idTipoPeriodo,
                nPlazoCuota = this.objEvalCred.nPlazoCuota,
                nDiasGracia = this.objEvalCred.nDiasGracia,
                dFechaDesembolso = this.objEvalCred.dFechaDesembolso,
                idProducto = this.objEvalCred.idProducto,
                cTipoCredito = this.objEvalCred.cTipoProducto,
                cSubProducto = this.objEvalCred.cSubProducto,
                idTasa = this.objEvalCred.idTasa,
                nTasaCompensatoria = this.objEvalCred.nTEA,

                nCuotasGracia = this.objEvalCred.nCuotasGracia,
                idOperacion = this.objSolicitud.idOperacion,
                idAgencia = this.objSolicitud.idAgencia,
                idCli = this.objSolicitud.idCli,
                idClasificacionInterna = this.objEvalCred.idClasificacionInterna
            });

            // -- Crédito Solicitado
            this.cboMoneda.SelectedValue = this.objSolicitud.idMoneda;
            this.txtMonto.Text = this.objSolicitud.nMonto.ToString("n2");
            this.nudCuotas.Value = this.objSolicitud.nCuotas;
            this.cboTipoPeriodo.SelectedValue = this.objSolicitud.idTipoPeriodo;
            this.nudPlazoCuota.Value = this.objSolicitud.nPlazoCuota;
            this.nudDiasGracia.Value = this.objSolicitud.nDiasGracia;
            this.dtFechaDesembolso.Value = this.objSolicitud.dFechaDesembolso;
            this.txtTEA.Text = this.objSolicitud.nTea.ToString("n4");

            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                this.lblBase19.Text = "Día de Pago";
                this.lblBase7.Text = "";
            }
            else
            {
                this.lblBase19.Text = "Frecuencia";
                this.lblBase7.Text = "días";
            }

            this.txtCuotaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaAprox());
            this.txtCuotaGraciaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaGraciaAprox());

            if (lAgricola)
            {
                int idTipDestCred = Convert.ToInt32(dsResult.Tables[8].Rows[0]["idTipDestCred"]);
                this.cboTipDestCred.listarTipDestCred(idTipDestCred, 0);
                this.cboTipDestCred.SelectedValue = idTipDestCred;

                this.cboTipDestCredEspef.listarTipDestCred(0, idTipDestCred);

                if (dsResult.Tables[9].Rows.Count > 0)
                {
                    this.cboTipDestCredEspef.SelectedValue = Convert.ToInt32(dsResult.Tables[9].Rows[0]["idDetalle"]);
                }

                this.cboCultivoEval.SelectedValueChanged -= new System.EventHandler(this.cboCultivoEval_SelectedValueChanged);
                this.cboCultivoEval.cargarCultivoEval();
                this.cboCultivoEval.SelectedValue = 0;
                this.cboCultivoEval.SelectedValueChanged += new System.EventHandler(this.cboCultivoEval_SelectedValueChanged);
                this.cboUnidadProductiva.listarUnidadProductiva();
                if (dsResult.Tables[10].Rows.Count > 0)
                {
                    this.cboCultivoEval.SelectedValue = Convert.ToInt32(dsResult.Tables[10].Rows[0]["idCultivoEval"]);
                    this.cboVariedadCultivoEval.SelectedValue = Convert.ToInt32(dsResult.Tables[10].Rows[0]["idVariedadCultivoEval"]);
                    this.cboUnidadProductiva.SelectedValue = Convert.ToInt32(dsResult.Tables[10].Rows[0]["idUnidadProductiva"]);
                    this.nudUnidadesProduccion.Value = Convert.ToInt32(dsResult.Tables[10].Rows[0]["nUniProdPropiasAct"]);
                }
            }
            else
            {
                this.gbxAgricola.Visible = false;
            }

            // Asignación de referencias
            this.conReferencias1.AsignarDataTable(this.dtTipReferEval, this.dtTipVinculoEval);
            this.conReferencias1.AsignarDatos(this.listReferencia);

            // Asignación de los subdestinos y los detalles
            this.conDestinoCredito1.AsignarDataTable(this.dtTipDestCred, this.dtTipDestCredDetalle);
            this.conDestinoCredito1.AsignarDatos(this.objEvalCred.nCapitalPropuesto, this.listDestCredProp);
            this.conDestinoCredito1.EstablacerActivoAdquirir(this.objEvalCred.nActivoAdquirir);
            #endregion

            #region Asignar Fechas
            this.conEstadosFinancierosResumen.UltEvaluacionLimpiarCeldas = false;
            this.conEstadosFinancierosResumen.UltEvaluacionChecked = true;
            this.conEstadosFinancierosResumen.UltEvaluacionLimpiarCeldas = true;

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);

            Evaluacion.listMesFechasEval = null;
            Evaluacion.listMesFechasEval = new List<clsMesFechasEval>();

            DateTime dFecha;
            for (int i = 1; i < 480; i++)     //40 años por 12 meses
            {
                //dFecha = (new DateTime(this.dFechaBase.Year, this.dFechaBase.Month, 1)).AddMonths(i);
                dFecha = this.dFechaBase.AddMonths(i);
                Evaluacion.listMesFechasEval.Add(new clsMesFechasEval()
                {
                    nMes = i,
                    dFecha = dFecha,
                    cFechaCorto = dFecha.ToString("MMM/yy").ToUpper(),
                    cFechaLargo = dFecha.ToString("MMMM/yy").ToUpper()
                });
            }
            #endregion

            if (this.objEvalCred.lEditar == true)
            {
                TituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
                HabilitarBotonesSegunModo(clsAcciones.BUSCAR);
            }
            else
            {
                TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
            }


            // ------------------------
            var aMoneda = (from p in Evaluacion.DataTableMoneda.AsEnumerable()
                           where p.Field<int>("idMoneda") == this.objEvalCred.idMoneda
                           select new
                           {
                               cSimbolo = p.Field<string>("cSimbolo"),
                               idMoneda = p.Field<int>("idMoneda")
                           }).ToList().FirstOrDefault();

            if (aMoneda == null)
            {
                Evaluacion.idMoneda = 1;
                Evaluacion.MonedaSimbolo = "S/.";
            }
            else
            {
                Evaluacion.TipoCambio = this.objEvalCred.nTipoCambio;
                Evaluacion.idMoneda = this.objEvalCred.idMoneda;
                Evaluacion.MonedaSimbolo = aMoneda.cSimbolo;
            }

            // ----------------------
            this.objEstadosFinancieros.listVentasCostos = new List<clsVentasCostos>();
            this.objEstadosFinancieros.listGFamiliares = new List<clsDetEstResEval>();
            this.objEstadosFinancieros.listGPersonales = new List<clsDetEstResEval>();
            this.objEstadosFinancieros.listGOperativos = new List<clsDetEstResEval>();
            this.objEstadosFinancieros.listOtrosEgresos = new List<clsDetEstResEval>();
            this.objEstadosFinancieros.listOtrosIngresos = new List<clsDetEstResEval>();
            this.objEstadosFinancieros.listCredDirectos = new List<clsDeudasEval>();
            this.objEstadosFinancieros.listCredIndirect = new List<clsDeudasEval>();

            //-- Evaluar si pertenece al MNB
            DataTable dtMNB = new clsCNMotorDecision().ClasificacionInternaxCli(this.objEvalCred.idSolicitud);
            int clasInternaCli = Convert.ToInt32(dtMNB.Rows[0]["idClasifInterna"]);
            this.lEsMNB = clasInternaCli == 9 ? true : false;

            // Evaluar si el producto es AWA y WASI
            int idProducto = 0;
            cProductosAWAWASI = clsVarApl.dicVarGen["cProductosAWAWASI"];
            idProductosAwaWasi = cProductosAWAWASI.Split(',')
                                    .Select(int.Parse)
                                    .ToList();

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                 idProducto = (int)dsResult.Tables[0].Rows[0]["idProducto"];
            }


            if (idProductosAwaWasi.Contains(idProducto))
            {
                conDestinoCredito1.Visible = true;
            }                                                
        }

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnTasaN.Enabled = lHabilitado;
            //this.btnDenegar.Enabled = lHabilitado;
            //this.btnChecklist.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;
            //this.btnVincular.Enabled = lHabilitado;
            this.btnBusqueda.Enabled = lHabilitado;
            //this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
            //this.btnCancelar.Enabled = lHabilitado;
            //this.btnSalir.Enabled = lHabilitado;
        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado;
            //btnAdministradorFiles1.lectura = true;
            if (nModo == clsAcciones.EDITAR)
            {
                lHabilitado = true;
                //btnAdministradorFiles1.lectura = false;
                this.btnImprimir.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                this.btnValidar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;

                this.conEstadosFinancierosResumen.Enabled = true;
                this.panel2.Enabled = true;
                this.conReferencias1.Enabled = true;
                this.btnHabilitarSeguro.Enabled = true;

                this.conDestinoCredito1.Enabled = true;
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnValidar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = false;

                this.conEstadosFinancierosResumen.Enabled = false;
                this.panel2.Enabled = false;
                this.conReferencias1.Enabled = false;
                this.btnHabilitarSeguro.Enabled = false;
                this.conDestinoCredito1.Enabled = false;
            }
            else if (nModo == clsAcciones.ENVIAR)
            {
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnValidar.Enabled = false;
                this.btnBusqueda.Enabled = lHabilitado;
                //this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;

                this.conEstadosFinancierosResumen.Enabled = false;
                this.panel2.Enabled = false;
                this.conReferencias1.Enabled = false;
                this.conDestinoCredito1.Enabled = false;
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnObservacion1.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                //this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;

                this.btnEditar.Focus();

                this.conEstadosFinancierosResumen.Enabled = false;
                this.panel2.Enabled = false;
                this.conReferencias1.Enabled = false;
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnObservacion1.Enabled = false;
                this.tabEval.Enabled = true;

                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = false;
                //this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = true;

                this.conEstadosFinancierosResumen.Enabled = true;
                this.panel2.Enabled = false;
                this.conReferencias1.Enabled = false;
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                //this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;

                this.conEstadosFinancierosResumen.Enabled = false;
                this.panel2.Enabled = false;
                this.conReferencias1.Enabled = false;
            }
        }

        private string EvalCredToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idUsuMod", typeof(int));
            //dt.Columns.Add("dFecMod", typeof(DateTime));
            dt.Columns.Add("nCapitalPropuesto", typeof(decimal));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nCuotas", typeof(int));
            dt.Columns.Add("idTipoPeriodo", typeof(int));
            dt.Columns.Add("nPlazoCuota", typeof(int));
            dt.Columns.Add("nDiasGracia", typeof(int));
            dt.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dt.Columns.Add("idTasa", typeof(int));
            dt.Columns.Add("nTEA", typeof(decimal));
            dt.Columns.Add("nTEM", typeof(decimal));
            dt.Columns.Add("nCuotaAprox", typeof(decimal));
            dt.Columns.Add("dFecUltimaEval", typeof(DateTime));
            dt.Columns.Add("dFecActualEval", typeof(DateTime));
            dt.Columns.Add("nCajaInicial", typeof(decimal));
            dt.Columns.Add("idActividad", typeof(int));
            dt.Columns.Add("idSectorEcon", typeof(int));
            dt.Columns.Add("lActSecundaria", typeof(bool));
            dt.Columns.Add("idActividadInternaPri", typeof(int));
            dt.Columns.Add("idTipoActividadPri", typeof(int));
            dt.Columns.Add("nActPriAnios", typeof(int));
            dt.Columns.Add("cActPriDireccion", typeof(string));
            dt.Columns.Add("cActPriReferencia", typeof(string));
            dt.Columns.Add("cActPriDescripcion", typeof(string));
            dt.Columns.Add("idActividadInternaSec", typeof(int));
            dt.Columns.Add("idTipoActividadSec", typeof(int));
            dt.Columns.Add("nActSecAnios", typeof(int));
            dt.Columns.Add("cActSecDireccion", typeof(string));
            dt.Columns.Add("cActSecReferencia", typeof(string));
            dt.Columns.Add("cActSecDescripcion", typeof(string));
            dt.Columns.Add("cComEntFamiliar", typeof(string));
            dt.Columns.Add("cComDestCredito", typeof(string));
            dt.Columns.Add("cComAnteCred", typeof(string));
            dt.Columns.Add("cComAnalisisFinan", typeof(string));
            dt.Columns.Add("cComGarantias", typeof(string));
            dt.Columns.Add("cComConclusiones", typeof(string));
            dt.Columns.Add("lExpuestoRcc", typeof(bool));
            dt.Columns.Add("nTotalPasivoAC", typeof(decimal));

            dt.Columns.Add("nPlazo", typeof(int));
            dt.Columns.Add("nCuotasGracia", typeof(int));
            dt.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dt.Columns.Add("cCalendarioPagos", typeof(string));
            dt.Columns.Add("nTotalMontoPagar", typeof(decimal));
            dt.Columns.Add("nActivoAdquirir", typeof(decimal));

            DataRow row = dt.NewRow();

            row["idEvalCred"] = this.objEvalCred.idEvalCred;
            row["idUsuMod"] = clsVarGlobal.User.idUsuario;
            //row["dFecMod"] = clsVarGlobal.dFecSystem;
            row["nCapitalPropuesto"] = this.objEvalCred.nCapitalPropuesto;
            row["idMoneda"] = this.objEvalCred.idMoneda;
            row["nCuotas"] = this.objEvalCred.nCuotas;
            row["idTipoPeriodo"] = this.objEvalCred.idTipoPeriodo;
            row["nPlazoCuota"] = this.objEvalCred.nPlazoCuota;
            row["nDiasGracia"] = this.objEvalCred.nDiasGracia;
            row["dFechaDesembolso"] = this.objEvalCred.dFechaDesembolso;
            row["idTasa"] = this.objEvalCred.idTasa;
            row["nTEA"] = this.objEvalCred.nTEA;
            row["nTEM"] = clsMathFinanciera.TEM(Convert.ToDouble(this.objEvalCred.nTEA));
            row["nCuotaAprox"] = this.objEvalCred.nCuotaAprox;
            row["dFecUltimaEval"] = this.objEvalCred.dFecUltimaEval;    //validr
            row["dFecActualEval"] = this.objEvalCred.dFecActualEval;
            row["nCajaInicial"] = this.objEvalCred.nCajaInicial;
            row["idActividad"] = this.objEvalCred.idActividad;
            row["idSectorEcon"] = this.objEvalCred.idSectorEcon;
            row["lActSecundaria"] = this.objEvalCred.lActSecundaria;
            row["idActividadInternaPri"] = this.objEvalCred.idActividadInternaPri;
            row["idTipoActividadPri"] = this.objEvalCred.idTipoActividadPri;
            row["nActPriAnios"] = this.objEvalCred.nActPriAnios;
            row["cActPriDireccion"] = this.objEvalCred.cActPriDireccion;
            row["cActPriReferencia"] = this.objEvalCred.cActPriReferencia;
            row["cActPriDescripcion"] = this.objEvalCred.cActPriDescripcion;
            row["idActividadInternaSec"] = this.objEvalCred.idActividadInternaSec;
            row["idTipoActividadSec"] = this.objEvalCred.idTipoActividadSec;
            row["nActSecAnios"] = this.objEvalCred.nActSecAnios;
            row["cActSecDireccion"] = this.objEvalCred.cActSecDireccion;
            row["cActSecReferencia"] = this.objEvalCred.cActSecReferencia;
            row["cActSecDescripcion"] = this.objEvalCred.cActSecDescripcion;
            row["cComEntFamiliar"] = this.objEvalCred.cComEntFamiliar;
            row["cComDestCredito"] = this.objEvalCred.cComDestCredito;
            row["cComAnteCred"] = this.objEvalCred.cComAnteCred;
            row["cComAnalisisFinan"] = this.objEvalCred.cComAnalisisFinan;
            row["cComGarantias"] = this.objEvalCred.cComGarantias;
            row["cComConclusiones"] = this.objEvalCred.cComConclusiones;
            row["lExpuestoRcc"] = this.objEvalCred.lExpuestoRcc;
            row["nTotalPasivoAC"] = this.objEvalCred.nTotalPasivoAC;
            row["nPlazo"] = this.objEvalCred.nPlazo;
            row["nCuotasGracia"] = this.objEvalCred.nCuotasGracia;
            row["nCuotaGraciaAprox"] = this.objEvalCred.nCuotaGraciaAprox;
            row["cCalendarioPagos"] = this.objEvalCred.cCalendarioPagos;
            row["nTotalMontoPagar"] = this.objEvalCred.nTotalMontoPagar;
            row["nActivoAdquirir"] = this.objEvalCred.nActivoAdquirir;

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private string BalGenEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idBalGenEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));

            foreach (clsBalGenEval bg in listBalGenEval)
            {
                dt.Rows.Add(
                    bg.idBalGenEval,
                    bg.nTotalUltEvMA,
                    bg.nTotalMA,
                    bg.nAnalisisVerti,
                    bg.nAnalisisHoriz
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "BalGenEval", "Item");
        }

        private string EstResEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEstResEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));
            dt.Columns.Add("nTotalMN", typeof(decimal));
            dt.Columns.Add("nTotalME", typeof(decimal));

            foreach (clsEstResEval er in listEstResEval)
            {
                dt.Rows.Add(
                    er.idEstResEval,
                    er.nTotalUltEvMA,
                    er.nTotalMA,
                    er.nAnalisisVerti,
                    er.nAnalisisHoriz,
                    er.nTotalMN,
                    er.nTotalME
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "EstResEval", "Item");
        }

        private string IndicadoresToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idIndicadorEval", typeof(int));
            dt.Columns.Add("nRatio", typeof(decimal));

            foreach (clsIndicadorEval rc in this.listIndiFinanc)
            {
                dt.Rows.Add(rc.idIndicadorEval, rc.nRatio);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "IndicadorEval", "Item");
        }

        private string DestCredPropToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idDestCredProp", typeof(int));
            dt.Columns.Add("idTipDestCred", typeof(int));
            dt.Columns.Add("idDetalle", typeof(int));
            dt.Columns.Add("nPorcentaje", typeof(decimal));
            dt.Columns.Add("nMonto", typeof(decimal));

            foreach (clsDestCredProp dc in this.listDestCredProp)
            {
                dc.nMontoProp = this.objEvalCred.nCapitalPropuesto;
                dt.Rows.Add(
                    dc.idDestCredProp,
                    dc.idTipDestCred,
                    dc.idDetalle,
                    dc.nPorcentaje,
                    dc.nMonto
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "DestCredProp", "Item");
        }

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            if(this.idProductosAwaWasi.Contains(this.objEvalCred.idProducto))
            {                
                objMsjError.addList(conDestinoCredito1.ValidarDestino());
            }           

            var objCreditoTasaMsjError = this.conCreditoTasa.Validar();

            if (objCreditoTasaMsjError.HasErrors)
            {
                foreach (var err in objCreditoTasaMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            decimal nMontoSolicitado = (String.IsNullOrWhiteSpace(this.txtMonto.Text)) ? 0 : Convert.ToDecimal(this.txtMonto.Text);

            if (this.conCreditoTasa.MontoPropuesto > nMontoSolicitado)
            {
                objMsjError.AddError("El monto propuesto es mayor a lo solicitado.");
            }

            if (!TieneActividadPrincipal())
            {
                objMsjError.AddError("Descripción de la Actividad Principal está VACIO.");
            }

            objMsjError.addList(conReferencias1.validarReferencias(0));

            /*if (!TieneActividadSecundaria())
            {
                objMsjError.AddError("Entorno Familiar está VACIO.");
            }*/

            if (!TieneDestinoPrestamo())
            {
                objMsjError.AddError("Descripción del Destino del crédito está VACIO.");
            }

            if (!TieneGarantias())
            {
                objMsjError.AddError("Descripción de Garantías está VACIO.");
            }

            if (!TieneAntecedentes())
            {
                objMsjError.AddError("Descripción de Antecedentes Crediticios está VACIO.");
            }

            if (!TieneConclusiones())
            {
                objMsjError.AddError("Descripción de Conclusiones, Riesgos está VACIO.");
            }

            //if (!btnAdministradorFiles1.obligatoriosCompletos())
            //{
            //    objMsjError.AddError(btnAdministradorFiles1.msgObligatorios);
            //}

            if (lAgricola)
            {
                if (this.cboTipDestCredEspef.SelectedIndex < 0)
                {
                    objMsjError.AddError("Campaña Agrícola: tipo de destino no seleccionado.");
                }
                if (this.cboCultivoEval.SelectedIndex < 0)
                {
                    objMsjError.AddError("Campaña Agrícola: cultivo agrícola no seleccionado.");
                }
                if (this.cboVariedadCultivoEval.SelectedIndex < 0)
                {
                    objMsjError.AddError("Campaña Agrícola: variedad de cultivo agrícola no seleccionado.");
                }
                if (this.cboUnidadProductiva.SelectedIndex < 0)
                {
                    objMsjError.AddError("Campaña Agrícola: unidad productiva no seleccionado.");
                }
                if (this.nudUnidadesProduccion.Value <= decimal.Zero)
                {
                    objMsjError.AddError("Campaña Agrícola: unidades en productiva debe ser mayor que CERO.");
                }
            }

            decimal nVentasNetasTotal = this.listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            decimal nCostoVentasTotal = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
            decimal nGastosFamiliaresTotal = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);

           #region Estados Financieros

            if (nVentasNetasTotal == decimal.Zero)
                objMsjError.AddError("Estados Financ.: Las Ventas Netas están en CERO.");

            if (nCostoVentasTotal == decimal.Zero)
                objMsjError.AddError("Estados Financ.: El Costo de Ventas está en CERO.");

            if (nGastosFamiliaresTotal == decimal.Zero)
                objMsjError.AddError("Estados Financ.: Los Gastos Familiares están en CERO.");
            #endregion
            
            objMsjError.addList(conEstadosFinancierosResumen.validarIndiFinanc());

            #region Carga de Archivos
            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(this.objEvalCred.idSolicitud);
            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
            {
                objMsjError.AddError(dtCargaArchivos.Rows[0]["cMsg"].ToString());
            }
            #endregion

            return objMsjError;
        }


        private  clsMsjError ValidarDestinoCredito()
        {
            clsMsjError objMsjError = new clsMsjError();
            decimal nPorcentaje = this.listDestCredProp.Sum(x => x.nPorcentaje);

            if (nPorcentaje < 1)
                objMsjError.AddError("Cond. Crédito: Total % de Destinos del Crédito es MENOR al 100%.");

            if (nPorcentaje > 1)
                objMsjError.AddError("Cond. Crédito: Total % de Destinos del Crédito es MAYOR al 100%.");

            return objMsjError;

        }
        private bool TieneActividadPrincipal()
        {
            if ((this.txtActPrincipal.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtActPrincipal.Text)))
                return false;

            return true;
        }

        private bool TieneActividadSecundaria()
        {
            if ((this.txtActSecundaria.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtActSecundaria.Text)))
                return false;

            return true;
        }

        private bool TieneDestinoPrestamo()
        {
            if ((this.txtDestPrestamo.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtDestPrestamo.Text)))
                return false;

            return true;
        }

        private bool TieneGarantias()
        {
            if ((this.txtGarantias.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtGarantias.Text)))
                return false;

            return true;
        }

        private bool TieneAntecedentes()
        {
            if ((this.txtAntecedentes.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtAntecedentes.Text)))
                return false;

            return true;
        }

        private bool TieneConclusiones()
        {
            if ((this.txtConclusiones.Enabled == true) && (String.IsNullOrWhiteSpace(this.txtConclusiones.Text)))
                return false;

            return true;
        }

        private void TituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación {0}", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación {0} - ({1})", cTipEvalCred, cMensaje);
        }
        private string datosAgricolaXML()
        {
            DataSet dsAgricola = new DataSet("Agricolas");
            DataTable dtAgricola = new DataTable("Agricola");
            dtAgricola.Columns.Add("idEvalCred", typeof(int));
            dtAgricola.Columns.Add("idTipDestCred", typeof(int));
            dtAgricola.Columns.Add("idDetalle", typeof(int));
            dtAgricola.Columns.Add("idCultivoEval", typeof(int));
            dtAgricola.Columns.Add("idVariedadCultivoEval", typeof(int));
            dtAgricola.Columns.Add("idUnidadProductiva", typeof(int));
            dtAgricola.Columns.Add("nUniProdPropiasAct", typeof(int));

            if (this.lAgricola)
            {
                DataRow drFila = dtAgricola.NewRow();
                drFila["idEvalCred"] = this.objEvalCred.idEvalCred;
                drFila["idTipDestCred"] = this.cboTipDestCred.SelectedValue;
                drFila["idDetalle"] = this.cboTipDestCredEspef.SelectedValue;
                drFila["idCultivoEval"] = this.cboCultivoEval.SelectedValue;
                drFila["idVariedadCultivoEval"] = this.cboVariedadCultivoEval.SelectedValue;
                drFila["idUnidadProductiva"] = this.cboUnidadProductiva.SelectedValue;
                drFila["nUniProdPropiasAct"] = this.nudUnidadesProduccion.Value;

                dtAgricola.Rows.Add(drFila);
            }

            dsAgricola.Tables.Add(dtAgricola);

            return dsAgricola.GetXml();
        }

        private void CargarConfiguracionSeguro(int nMuestraFrm)
        {
            clsCreditoProp objDatos = new clsCreditoProp();
            objDatos = conCreditoTasa.ObtenerCreditoPropuesto();
            int idSolicitud = this.objEvalCred.idSolicitud;
            int nParam = 1;

            if (objDatos.nPlazoCuota == 0)
            {
                MessageBox.Show("Debe seleccionar frecuencia.", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            objSolicitudCreditoSeguroActual = (objSolicitudCreditoSeguroActual.idSolicitud == 0) ? objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud) : objSolicitudCreditoSeguroActual;
            objSolicitudCreditoSeguroActual.idProducto        = objDatos.idProducto;
            objSolicitudCreditoSeguroActual.nMontoSolicitado  = objDatos.nMonto;
            objSolicitudCreditoSeguroActual.nCuotas           = objDatos.nCuotas;
            objSolicitudCreditoSeguroActual.idTipoPlazo       = objDatos.idTipoPeriodo;
            objSolicitudCreditoSeguroActual.nPlazo            = objDatos.nPlazoCuota;
            objSolicitudCreditoSeguroActual.idMoneda          = objDatos.idMoneda;
            objSolicitudCreditoSeguroActual.cMoneda           = objDatos.cMoneda;
            objSolicitudCreditoSeguroActual.dFechaDesembolso  = objDatos.dFechaDesembolso;
            objSolicitudCreditoSeguroActual.dFechaCancelacion = clsVarGlobal.dFecSystem;
            objSolicitudCreditoSeguroActual.nDiasGracia       = objDatos.nDiasGracia;
            objSolicitudCreditoSeguroActual.nCuotaGracia      = objDatos.nCuotasGracia;
            objSolicitudCreditoSeguroActual.lPlanSeguroBD     = objSolicitudCreditoSeguroActual.idPaqueteSeguro > 0 ? true : false;
            frmSolicitudCreditoCargaSeguro frmCreditoCargaSeguro = new frmSolicitudCreditoCargaSeguro(objSolicitudCreditoSeguroActual, nParam);

            if (nMuestraFrm == 1)
            {
                frmCreditoCargaSeguro.ShowDialog();
            }
            else if (nMuestraFrm == 0)
            {
                //frmCreditoCargaSeguro.Visible = false;
                //frmCreditoCargaSeguro.FormBorderStyle = FormBorderStyle.None;
                //frmCreditoCargaSeguro.Show();
                //frmCreditoCargaSeguro.Close();
                frmCreditoCargaSeguro.EnvioDatos();
            }

            //objSolicitudCreditoSeguroActual = frmCreditoCargaSeguro.objSolicitudCreditoCargaSeguro;

            if (objSolicitudCreditoSeguroActual.nEstado == 1)
            {
                if ((objSolicitudCreditoSeguroActual.lAceptacionListaSeguro) || objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
                {
                    string xmlSolicitudCreditoSeguro = objSolicitudCreditoSeguroActual.GetXml();

                    DataTable dtResultadoSeguro = new clsCNCreditoCargaSeguro().CNRegistrarSolicitudCreditoSeguro(this.objEvalCred.idSolicitud, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                    if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 0 || Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == -1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        #region Eventos
        private void tabEval_Selected(object sender, TabControlEventArgs e)
        {
            /*if (tabEval.SelectedTab == tabEval.TabPages["tbpCondCredito"] && this.objEvalCred.idSolicitud == 0)
            {
                this.plMsjBloqueo.Location = new System.Drawing.Point(260, 121);
                this.plMsjBloqueo.Visible = true;
            }
            else
            {
                this.plMsjBloqueo.Visible = false;
                this.plMsjBloqueo.Location = new System.Drawing.Point(759, 319);
            }*/
        }

        private void btnCopiado_Click(object sender, EventArgs e)
        {
            /*frmCopiarEval frmCopiarEval = new frmCopiarEval(this.objEvalCred, "Copiado de Evaluaciones");
            frmCopiarEval.ShowDialog();

            if (frmCopiarEval.lEjecutado == true)
            {
                RecuperarDatos(this.objEvalCred.idEvalCred);
                RecuperarDetalleEstRes(this.objEvalCred.idEvalCred);

                btnGrabar.PerformClick();

                MessageBox.Show("Evaluación recuperada correctamente.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            int idEvalCred = 0;

            FrmBuscarEvalRapido formBuscarEv = new FrmBuscarEvalRapido(this.idTipEvalCred.ToString(), "Buscar Evaluaciones");
            formBuscarEv.ShowDialog();

            if (formBuscarEv.idCli != 0)
            {
                idEvalCred = formBuscarEv.idEvalCred;

                if (formBuscarEv.idSolicitud != 0)
                {
                    if (formBuscarEv.idTipEvalCred > 0 && formBuscarEv.idTipEvalCred != this.idTipEvalCred)
                    {
                        //TODO: SolTechnologies - 15.Evita alerta de cambio de formulario
                        DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(formBuscarEv.idSolicitud);

                        if (existe.Rows.Count <= 0)
                        {
                        MessageBox.Show("Debe evaluarse en el formulario de evaluación: " + formBuscarEv.cTipEvalCred, this.cMsjCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    }

                    if (idEvalCred == 0)
                    {
                        DataTable dt = objCapaNegocio.CrearEvalRapiCredito(formBuscarEv.idSolicitud, this.idTipEvalCred, clsVarGlobal.User.idUsuario);

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["idMsje"].ToString().Equals("0"))
                            {
                                //Visita Presencial-Remoto
                                idEvalCred = Convert.ToInt32(dt.Rows[0]["idEvalCred"]);
                                ValidarVisitaPresencialRemota(formBuscarEv, idEvalCred);

                                DataTable existe2 = new clsCNMotorDecision().ValidaExistenciaMNB(formBuscarEv.idSolicitud);
                                if (idEvalCred > 0 && existe2.Rows.Count > 0)
                                    new clsCNMotorDecision().MigracionEvalMNB(idEvalCred, "frmEvalResumenPreAprob");
                            }
                            else { return; }
                        }
                        else { return; }
                    }

                    this.txtNroDoc.Text = formBuscarEv.cNroDocumento;
                    this.txtNombre.Text = formBuscarEv.cNombreCliente;
                    
                    RecuperarDatos(idEvalCred);
                }
            }

            formBuscarEv.Close();
            formBuscarEv.Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            //TODO: SolTechnologies - 13.Validaciones del Porspecto Nuevo No Bancarizado
            DataTable dtexiste = new clsCNMotorDecision().ValidaExistenciaMNB(oEvalCredTemp.idSolicitud);

            if (dtexiste.Rows.Count > 0)
            {
                //Tercera Validacion del MNB
                clsVarGen nMontoDecisionEngineMax = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecisionMax"));
                decimal montoParametrisableMax = Convert.ToDecimal(nMontoDecisionEngineMax.cValVar);
                decimal montoSolic = oEvalCredTemp.nMonto;
                if (montoSolic > montoParametrisableMax)
                {
                    MessageBox.Show("El monto del Modelo no Bancarizado no debe exceder los S/." + montoParametrisableMax, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (this.lAgricola)
            {
                if (cboCultivoEval.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el Cultivo", "Evaluación Resumida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboCultivoEval.Focus();
                    return;
                }

                if (cboVariedadCultivoEval.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar la Variedad de Cultivo", "Evaluación Resumida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboVariedadCultivoEval.Focus();
                }
            }

            //idMoneda
            this.objEvalCred.nCapitalPropuesto = oEvalCredTemp.nMonto;
            this.objEvalCred.nCuotas = oEvalCredTemp.nCuotas;
            this.objEvalCred.idTipoPeriodo = oEvalCredTemp.idTipoPeriodo;
            this.objEvalCred.nPlazoCuota = oEvalCredTemp.nPlazoCuota;
            this.objEvalCred.dFechaDesembolso = oEvalCredTemp.dFechaDesembolso;
            this.objEvalCred.nDiasGracia = oEvalCredTemp.nDiasGracia;
            this.objEvalCred.idTasa = oEvalCredTemp.idTasa;
            this.objEvalCred.nTEA = oEvalCredTemp.nTea;
            this.objEvalCred.nTEM = oEvalCredTemp.nTem;
            //idProducto
            this.objEvalCred.nCuotasGracia = oEvalCredTemp.nCuotasGracia;
            this.objEvalCred.nPlazo = oEvalCredTemp.nPlazo;
            this.objEvalCred.nCuotaAprox = oEvalCredTemp.nCuotaAprox;
            this.objEvalCred.nCuotaGraciaAprox = oEvalCredTemp.nCuotaGraciaAprox;
            this.objEvalCred.dtCalendarioPagos = oEvalCredTemp.dtCalendarioPagos;
            this.objEvalCred.cCalendarioPagos = oEvalCredTemp.cCalendarioPagos;
            this.objEvalCred.nTotalMontoPagar = oEvalCredTemp.nTotalMontoPagar;

            this.objEvalCred.dFecUltimaEval = this.conEstadosFinancierosResumen.UltimaFechaEvaluacion();

            // Recuperar información de la propuesta de crédito
            this.objEvalCred.lActSecundaria = true;
            this.objEvalCred.cActPriDescripcion = this.txtActPrincipal.Text;
            this.objEvalCred.cActSecDescripcion = this.txtActSecundaria.Text;
            this.objEvalCred.cComDestCredito = this.txtDestPrestamo.Text;
            this.objEvalCred.cComGarantias = this.txtGarantias.Text;
            this.objEvalCred.cComAnteCred = this.txtAntecedentes.Text;
            this.objEvalCred.cComConclusiones = this.txtConclusiones.Text;

            this.objEvalCred.nActivoAdquirir = this.conDestinoCredito1.ObtenerActivoAdquirir();


            // -- Convertir a XML
            string xmlEvalCred = this.EvalCredToXML();
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();
            string xmlIndicadorEval = this.IndicadoresToXML();
            string xmlReferencias = this.ReferenciasToXML();
            string xmlDestCredProp = this.DestCredPropToXML();

            string xmlDatosAgricola = this.datosAgricolaXML();

            int nMuestraFrm = 0;
            CargarConfiguracionSeguro(nMuestraFrm);
            DataTable td = this.objCapaNegocio.ActualizarEval(this.objEvalCred.idEvalCred,
                        xmlEvalCred,
                        xmlBalGenEval,
                        xmlEstResEval,
                        xmlIndicadorEval,
                        this.lAgricola,
                        xmlDatosAgricola,
                        xmlReferencias,
                        xmlDestCredProp
            );

            if (td.Rows.Count > 0)
            {
                DataRow drResult = td.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(drResult["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //RecuperarEvalCredito();
                    HabilitarBotonesSegunModo(clsAcciones.GRABAR);
                }
            }

            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            ValidarReglas(false, aReglasEvaluadas);

            //TODO: SolTechnologies - 14.Evaluacion PYME Resumido
            #region MNB - Motor de decisiones

            int idSol = Convert.ToInt32(txtIdSolicitud.Text);
            int idEval = Convert.ToInt32(txtIdEvalCred.Text);
            int idCli = Convert.ToInt32(oEvalCredTemp.idCli);
            
            DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(this.objEvalCred.idSolicitud);


            if (this.lEsMNB && existe.Rows.Count > 0)
            {
                //Actualiza el monto y plazo que ingresa al Motor de decisiones 
                decimal monto = Convert.ToDecimal(oEvalCredTemp.nMonto);
                int nuevoPlazoCuota = oEvalCredTemp.nPlazoCuota;
                int nuevoCuotas = oEvalCredTemp.nCuotas;
                int nuevoIdPeriodo = oEvalCredTemp.idTipoPeriodo;
                int nuevoPlazo = (nuevoIdPeriodo == 1) ? 30 * nuevoCuotas : nuevoPlazoCuota * nuevoCuotas;

                clsVarGen nMontoDecisionEngine = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecision"));
                decimal montoParametrisable = Convert.ToDecimal(nMontoDecisionEngine.cValVar);

                bool migra = monto > montoParametrisable ? true : false;

                var motorDecision = new clsMotorDecision();
                var respuestaMNB = motorDecision.CallMotorDecisionEvaluacion(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, this.Name);

                if (respuestaMNB == null)
                    MessageBox.Show("No se ha podido establecer conexión con el Motor de decisiones", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                motorDecision.MensajesPorExcepcionesYRespuestaApi(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, aReglasEvaluadas, respuestaMNB);


                if (migra)
                {
                    MessageBox.Show("Debe pasar por un proceso de evaluación normal", "Motor de Decisión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new clsCNMotorDecision().MigracionEvalMNB(idEval, "frmEvalPyme");
                    this.Close();
                    this.Dispose();
                }

            }
            #endregion
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            clsMsjError objMsjError = Validar();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnEnviar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se encontraron errores en la Evaluación.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            if (!ValidarIndicadorObser())
                {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            clsMsjError objMsjError = Validar();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();
                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("La evaluación aún no esta vinculada.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BLOQUEO DEL BOTON DE ENVIO PARA EVITAR ENVIOS DUPLICADOS
            this.btnEnviar.Enabled = false;

            if (!ValidarReglas(true))
            {
                this.btnEnviar.Enabled = true;
                return;
            }
            if (this.invocarExcepciones(true))
            {
                this.btnEnviar.Enabled = true;
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //TODO: SolTechnologies - 12.Se verifica el flujo de aprobacion de la solicitud del MNB
            DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(this.objEvalCred.idSolicitud);
            if (existe.Rows.Count > 0)
            {
                DataTable dtScoreMNB = new clsCNMotorDecision().ListarScoreMNB(this.objEvalCred.idSolicitud);
                int resultadoScoreMNB = 0;

                if (dtScoreMNB.Rows.Count > 0)
                    resultadoScoreMNB = Convert.ToInt32(dtScoreMNB.Rows[0]["idPrediccion"]);

                if (resultadoScoreMNB == 1) //Aceptado
                {
                    clsRespuestaServidor objRespuesta = new clsCNExcepcionesCreditos().validarAprobExcepcioneReglaNeg(this.objEvalCred.idSolicitud);
                    if (objRespuesta.idResultado == ResultadoServidor.Error)
                    {
                        MessageBox.Show(objRespuesta.cMensaje, "ALERTA DE EXCEPCIÓN DE REGLA CREDITICIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

                    // ------------------------------------------------------------------------
                    int nCantidadCanales = 0;
                    int lCanalAproCredEditable = 0;

                    DataSet dsCanales = this.objCapaNegocio.DeterminarCanalesAprobacion(this.objEvalCred.idEstablecimiento,
                        this.objEvalCred.idTipoEstablec,
                        this.objEvalCred.idSolicitud,
                        this.objEvalCred.idCli,
                        (oEvalCredTemp.idMoneda == 1) ? oEvalCredTemp.nMonto : oEvalCredTemp.nMonto * this.objEvalCred.nTipoCambio,
                        oEvalCredTemp.idProducto,
                        this.objSolicitud.idOperacion
                        );

                    if (dsCanales.Tables.Count > 0)
                    {
                        nCantidadCanales = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["nCantidadCanales"]);

                        if (nCantidadCanales == -1)
                        {
                            MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (nCantidadCanales == 0)
                        {
                            MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else { return; }

                    if (nCantidadCanales == 1)
                    {
                        idCanal = Convert.ToInt32(dsCanales.Tables[1].Rows[0]["idCanalAproCred"]);
                    }
                    else
                    {
                        lCanalAproCredEditable = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["lCanalAproCredEditable"]);
                    }

                    /*  Guardar Expedientes - Evaluacion de Credito  */
                    bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                    if (!lRespuesta)
                    {
                        return;
                    }
                    // ------------------------------------------------------------------------

                    oEvalCredTemp.idOrigenCredProp = 2;
                    oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                    oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                    oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                    oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                    string xmlDestCredProp = oEvalCredTemp.GetXml();

                    DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditosRapid(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanal);

                    string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                    int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                    if (idMsj == 1)
                    {
                        this.objCNAprobacionCredito.InicializarAprobacionEvalCred(this.objEvalCred.idEvalCred, 3265, 224, clsVarGlobal.dFecSystem);
                        bool aprobCreAut = this.GestionarAprobacion();
                        if (!aprobCreAut)
                        {
                            return;
                        }
                        DialogResult msg = MessageBox.Show("El Prospecto ha sido Aprobado por el Motor de decisiones.\n " +
                        "Debera continuar con el proceso de desembolso.", "¡Envio exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                        this.objEvalCred.lEstado = false;
                        TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    }
                    else
                    {
                        MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (resultadoScoreMNB == 2) //Excepcion
                {
                    clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

                    // ------------------------------------------------------------------------
                    int nCantidadCanales = 0;
                    int lCanalAproCredEditable = 0;

                    DataSet dsCanales = this.objCapaNegocio.DeterminarCanalesAprobacion(this.objEvalCred.idEstablecimiento,
                        this.objEvalCred.idTipoEstablec,
                        this.objEvalCred.idSolicitud,
                        this.objEvalCred.idCli,
                        (oEvalCredTemp.idMoneda == 1) ? oEvalCredTemp.nMonto : oEvalCredTemp.nMonto * this.objEvalCred.nTipoCambio,
                        oEvalCredTemp.idProducto,
                        this.objSolicitud.idOperacion
                        );

                    if (dsCanales.Tables.Count > 0)
                    {
                        nCantidadCanales = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["nCantidadCanales"]);

                        if (nCantidadCanales == -1)
                        {
                            MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (nCantidadCanales == 0)
                        {
                            MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else { return; }

                    if (nCantidadCanales == 1)
                    {
                        idCanal = Convert.ToInt32(dsCanales.Tables[1].Rows[0]["idCanalAproCred"]);
                    }
                    else
                    {
                        lCanalAproCredEditable = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["lCanalAproCredEditable"]);
                    }

                    /*  Guardar Expedientes - Evaluacion de Credito  */
                    bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                    if (!lRespuesta)
                    {
                        return;
                    }
                    // ------------------------------------------------------------------------

                    oEvalCredTemp.idOrigenCredProp = 2;
                    oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                    oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                    oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                    oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                    string xmlDestCredProp = oEvalCredTemp.GetXml();

                    DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditosRapid(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanal);

                    string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                    int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (idMsj == 1)
                    {
                        HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                        this.objEvalCred.lEstado = false;
                        TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    }
                }
                else if (resultadoScoreMNB == 3) //Rechazado
                {
                    DialogResult msg = MessageBox.Show("El prospecto se encuentra rechazado por el Motor de Decisiones, debera rechazar la solicitud.",
                    "Error de envio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult msg = MessageBox.Show("No se ha podido establecer conexion con el Motor de Decisiones.\n" +
                    "Comunicate con un administrador.", "Error de envio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a aprobación de Créditos?",
                "Enviar a Aprobación de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

                // ------------------------------------------------------------------------
                int idCanalAproCredTemp = 0;
                int nCantidadCanales = 0;
                int lCanalAproCredEditable = 0;

                DataSet dsCanales = this.objCapaNegocio.DeterminarCanalesAprobacion(this.objEvalCred.idEstablecimiento,
                    this.objEvalCred.idTipoEstablec,
                    this.objEvalCred.idSolicitud,
                    this.objEvalCred.idCli,
                    (oEvalCredTemp.idMoneda == 1) ? oEvalCredTemp.nMonto : oEvalCredTemp.nMonto * this.objEvalCred.nTipoCambio,
                    oEvalCredTemp.idProducto,
                    this.objSolicitud.idOperacion
                    );

                if (dsCanales.Tables.Count > 0)
                {
                    nCantidadCanales = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["nCantidadCanales"]);

                    if (nCantidadCanales == -1)
                    {
                        MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (nCantidadCanales == 0)
                    {
                        MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else { return; }

                if (nCantidadCanales == 1)
                {
                    idCanal = Convert.ToInt32(dsCanales.Tables[1].Rows[0]["idCanalAproCred"]);
                }
                else
                {                    
                    lCanalAproCredEditable = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["lCanalAproCredEditable"]);

                    if (lCanalAproCredEditable == 1)    // Se puede cambiar el canal de otorgamiento
                    {
                        frmCanalResolucionCreditos frmCanalResolCred = new frmCanalResolucionCreditos(dsCanales.Tables[1]);
                        frmCanalResolCred.ShowDialog();
                        idCanalAproCredTemp = frmCanalResolCred.idCanalAproCred;

                        if (idCanalAproCredTemp > 0)
                            idCanal = idCanalAproCredTemp;
                        else
                        {
                            MessageBox.Show("No se seleccionó ningún canal de aprobación de créditos, por lo tanto se cancelará en envío a aprobación de créditos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnEnviar.Enabled = true;
                            return;
                        }
                    }
                }

                /*  Guardar Expedientes - Evaluacion de Credito  */
                bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                if (!lRespuesta)
                {
                    return;
                }
                // ------------------------------------------------------------------------

                oEvalCredTemp.idOrigenCredProp = 2;
                oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                string xmlDestCredProp = oEvalCredTemp.GetXml();

                DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditosRapid(this.objEvalCred.idEvalCred,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    xmlDestCredProp,
                    idCanal,
                    lCanalAproCredEditable
                );

                string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idMsj == 1)
                {
                    HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                    this.objEvalCred.lEstado = false;

                    TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                }
            }
            else
            {
                this.btnEnviar.Enabled = true;
            }
            }
        }

        private bool GestionarAprobacion()
        {
            bool flagcheck = false;
            clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            DialogResult resMensaje = MessageBox.Show(
                  "Acepto las condiciones anteriormente descritas,\n"
                + "declaro  y  aseguro   que   esta  propuesta  de\n"
                + "crédito   cumple  con   todos  los  requisitos,\n"
                + "documentación,  verificación  y  evaluación que\n"
                + "corresponde  según  las normativas  internas de\n"
                + "créditos  de  la  empresa.   Asimismo,  declaro\n"
                + "conocer  que  toda  vulneración  a  los  puntos\n"
                + "anteriores, constituye en una infracción sujeta\n"
                + "a sanción  disciplinaria  según  el  reglamento\n"
                + "interno    de   la   empresa   e  inclusive  de\n"
                + "comprobarse la falsedad en lo declarado, conoce\n"
                + "que  corresponde a  la  empresa promover acción\n"
                + "civil (laboral) y/o penal por  el delito contra\n"
                + "la  Fe  Pública  previsto  en el vigente Código\n"
                + "Penal.", "APROBACIÓN DE CRÉDITO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resMensaje == DialogResult.No)
            {
                return flagcheck;
            }

            DataTable dtGes = new clsCNAprobacionCredito().GestionarAprobacion(this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred, clsVarGlobal.nIdAgencia, oEvalCredTemp.nMonto, true); //Aprobacion automatica
            List<clsAprobacionCredito> objAproCred = new List<clsAprobacionCredito>();
            objAproCred = DataTableToList.ConvertTo<clsAprobacionCredito>(dtGes) as List<clsAprobacionCredito>;

            if (objAproCred[0].idError == 0)
            {
                DialogResult dlres = MessageBox.Show("" + objAproCred[0].cMensaje, "Aprobacion en proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlres == DialogResult.Yes)
                {
                    new frmAprobacionCred().GuardarDecisionAprobador(objAproCred[0].idEstadoEvalCred, 4, objAproCred[0].idNivelAprobacion, objAproCred[0].lEnviaSolInfRiesgos, objAproCred[0].lRevision, this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred);
                    flagcheck = true;
                }
            }
            else if (objAproCred[0].idError == 1)
            {
                MessageBox.Show("" + objAproCred[0].cMensaje, "Error al intentar consultar aprobacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return flagcheck;
            }
            return flagcheck;
        }

        private void conEstadosFinancieros_DeudasClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            FrmDeudasFinancResum frmdeudasFinanc = new FrmDeudasFinancResum(this.objEvalCred.idEvalCred, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda,
                                                            Evaluacion.MonedaSimbolo, txtNroDoc.Text, this.objEvalCred.idCli, this.objEvalCred.idSolicitud);
            frmdeudasFinanc.ShowDialog();

            lGuardado = frmdeudasFinanc.lGuardado;
            if (lGuardado == true)
            {
                this.objEstadosFinancieros.listCredDirectos = frmdeudasFinanc.CredDirectos();
                this.objEstadosFinancieros.listCredIndirect = frmdeudasFinanc.CredIndirect();

                this.objEvalCred.nTotalDeudas = this.objEstadosFinancieros.CDirectosTotalSaldoMA();
                this.objEvalCred.nTotalPasivoAC = this.objEstadosFinancieros.TotalPasivoAC();
            
                ActualizarEstadoResultados();
                //ActualizarEstadosFinancieros();
            }

            frmdeudasFinanc.Dispose();
        }

        private void ActualizarEstadoResultados()
        {
            int nPlazo = this.conCreditoTasa.Plazo();
            this.objEstadosFinancieros.ActualizarPlazo(nPlazo, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, this.objEvalCred.idTipEvalCred);

            //--------------------------------
            decimal nTotalVentas = this.objEstadosFinancieros.TotalVentasMA();
            decimal nTotalCostos = this.objEstadosFinancieros.TotalCostosMA();
            decimal nTotalGFamiliares = this.objEstadosFinancieros.TotalGFamiliaresMA();
            decimal nTotalGPersonales = this.objEstadosFinancieros.TotalGPersonalesMA();
            decimal nTotalGOperativos = this.objEstadosFinancieros.TotalGOperativosMA();
            decimal nTotalOtrosIngresos = this.objEstadosFinancieros.TotalOtrosIngresosMA();
            decimal nTotalOtrosEgresos = this.objEstadosFinancieros.TotalOtrosEgresosMA();
            decimal nGastosFinancieros = this.objEstadosFinancieros.TotalGFinancierosMA();

            decimal nTotalVentasMN = this.objEstadosFinancieros.TotalVentasMN();
            decimal nTotalCostosMN = this.objEstadosFinancieros.TotalCostosMN();
            decimal nTotalGFamiliaresMN = this.objEstadosFinancieros.TotalGFamiliaresMN();
            decimal nTotalGPersonalesMN = this.objEstadosFinancieros.TotalGPersonalesMN();
            decimal nTotalGOperativosMN = this.objEstadosFinancieros.TotalGOperativosMN();
            decimal nTotalOtrosIngresosMN = this.objEstadosFinancieros.TotalOtrosIngresosMN();
            decimal nTotalOtrosEgresosMN = this.objEstadosFinancieros.TotalOtrosEgresosMN();
            decimal nGastosFinancierosMN = this.objEstadosFinancieros.TotalGFinancierosMN();

            decimal nTotalVentasME = this.objEstadosFinancieros.TotalVentasME();
            decimal nTotalCostosME = this.objEstadosFinancieros.TotalCostosME();
            decimal nTotalGFamiliaresME = this.objEstadosFinancieros.TotalGFamiliaresME();
            decimal nTotalGPersonalesME = this.objEstadosFinancieros.TotalGPersonalesME();
            decimal nTotalGOperativosME = this.objEstadosFinancieros.TotalGOperativosME();
            decimal nTotalOtrosIngresosME = this.objEstadosFinancieros.TotalOtrosIngresosME();
            decimal nTotalOtrosEgresosME = this.objEstadosFinancieros.TotalOtrosEgresosME();
            decimal nGastosFinancierosME = this.objEstadosFinancieros.TotalGFinancierosME();

            //--------------------------------
            decimal nCDirectosTotalSaldoCortoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoCortoPlazoMA();
            decimal nCDirectosTotalSaldoLargoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoLargoPlazoMA();
            decimal nLargoPlazo = nCDirectosTotalSaldoLargoPlazo + this.objEstadosFinancieros.ProvicionCIndirectosMA();
            //--------------------------------

            this.cargaSaldoDeudaProvision();

            foreach (clsEstResEval item in this.listEstResEval)
            {
                //if (item.idEEFF == EEFF.VentasNetas)
                //{
                //    item.nTotalMA = nTotalVentas;
                //    item.nTotalMN = nTotalVentasMN;
                //    item.nTotalME = nTotalVentasME;
                //}
                //else if (item.idEEFF == EEFF.CostoVentas)
                //{
                //    item.nTotalMA = nTotalCostos;
                //    item.nTotalMN = nTotalCostosMN;
                //    item.nTotalME = nTotalCostosME;
                //}
                //else if (item.idEEFF == EEFF.GastosNegocio)
                //{
                //    item.nTotalMA = nTotalGOperativos + nTotalGPersonales;
                //    item.nTotalMN = nTotalGOperativosMN + nTotalGPersonalesMN;
                //    item.nTotalME = nTotalGOperativosME + nTotalGPersonalesME;
                //}
                //else if (item.idEEFF == EEFF.OtrosIngresos)
                //{
                //    item.nTotalMA = nTotalOtrosIngresos;
                //    item.nTotalMN = nTotalOtrosIngresosMN;
                //    item.nTotalME = nTotalOtrosIngresosME;
                //}
                //else if (item.idEEFF == EEFF.OtrosEgresos)
                //{
                //    item.nTotalMA = nTotalOtrosEgresos;
                //    item.nTotalMN = nTotalOtrosEgresosMN;
                //    item.nTotalME = nTotalOtrosEgresosME;
                //}
                //else if (item.idEEFF == EEFF.GastosFamiliares)
                //{
                //    item.nTotalMA = nTotalGFamiliares;
                //    item.nTotalMN = nTotalGFamiliaresMN;
                //    item.nTotalME = nTotalGFamiliaresME;
                //}
                if (item.idEEFF == EEFF.GastosFinancieros)
                {
                    item.nTotalMA = nGastosFinancieros;
                    item.nTotalMN = nGastosFinancierosMN;
                    item.nTotalME = nGastosFinancierosME;
                }
            }

            foreach (clsBalGenEval item in this.listBalGenEval)
            {
                if (item.idEEFF == EEFF.PrestamosCP) item.nTotalMA = nCDirectosTotalSaldoCortoPlazo;
                else if (item.idEEFF == EEFF.PrestamosLP) item.nTotalMA = nLargoPlazo;
            }

            this.conEstadosFinancierosResumen.ListBalanceGeneral = this.listBalGenEval;
            this.conEstadosFinancierosResumen.ListEstadoResultados = this.listEstResEval;
        }

        private void cargaSaldoDeudaProvision()
        {
            decimal nSaldoDirectosMA = this.objEstadosFinancieros.CDirectosTotalSaldoSoloNormalMA();
            decimal nSaldoDirectosMN = this.objEstadosFinancieros.CDirectosTotalSaldoSoloNormalMN();
            decimal nSaldoDirectosME = this.objEstadosFinancieros.CDirectosTotalSaldoSoloNormalME();

            //--------------------------------
            decimal nProvIndirectosMA = this.objEstadosFinancieros.nTotalProvisionDeudasIndirectasMA();
            decimal nProvIndirectosMN = this.objEstadosFinancieros.nTotalProvisionDeudasIndirectasMN();
            decimal nProvIndirectosME = this.objEstadosFinancieros.nTotalProvisionDeudasIndirectasME();

            conEstadosFinancierosResumen.nMontoDirectas = nSaldoDirectosMA;
            conEstadosFinancierosResumen.nMontoIndirectas = nProvIndirectosMA;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
            {
                MessageBox.Show("No se ha seleccionado la evaluación", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCred.idSolicitud, this.objEvalCred.idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void btnObservacion1_Click(object sender, EventArgs e)
        {
            if (this.objSolicitud == null)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", "Solicitud Vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmVistaObservacionesApro frmVistaObsAproSol = new frmVistaObservacionesApro(this.objSolicitud.idSolicitud);
            frmVistaObsAproSol.ShowDialog();
        }

        private void conEstadosFinancieros_EHZTLClick(object sender, EventArgs e)
        {
            /*frmBusHorizontal frmBusHorizontal = new frmBusHorizontal(this.objEvalCred.idCli, this.objEvalCred.idTipEvalCred, "Buscar Evalaución Horizontal");
            frmBusHorizontal.ShowDialog();

            if (frmBusHorizontal.listBalGenEval == null || frmBusHorizontal.listEstResEval == null) return;

            List<clsEstResEval> listEstResEvalHoriz = frmBusHorizontal.listEstResEval;
            List<clsBalGenEval> listBalGenEvalHoriz = frmBusHorizontal.listBalGenEval;

            decimal nTotal = 0;
            int nPlazoUltEval = (frmBusHorizontal.nPlazoUltEval == null || frmBusHorizontal.nPlazoUltEval <= 0 || Evaluacion.PlazoEval == 1) ? 1 : frmBusHorizontal.nPlazoUltEval;
            int nPlazoEvalAct = Evaluacion.PlazoEval;

            foreach (clsBalGenEval item in this.listBalGenEval)
            {
                nTotal = (from p in listBalGenEvalHoriz
                          where p.idEEFF == item.idEEFF
                          select p).ToList().Sum(x => x.nTotalMA);
                item.nTotalUltEvMA = nTotal;
            }

            this.conEstadosFinancieros.ListBalanceGeneral = this.listBalGenEval;

            foreach (clsEstResEval item in this.listEstResEval)
            {
                nTotal = (from p in listEstResEvalHoriz
                          where p.idEEFF == item.idEEFF
                          select p).ToList().Sum(x => x.nTotalMA);
                item.nTotalUltEvMA = Math.Round((nTotal / nPlazoUltEval) * nPlazoEvalAct, 2);
            }

            this.conEstadosFinancieros.ListEstadoResultados = this.listEstResEval;

            this.conEstadosFinancieros.ActualizarFechaUltEval(frmBusHorizontal.dFechaUltEval);
            //this.conEstadosFinancieros.Refresh();
            */
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            this.ValidarReglas(false, aReglasEvaluadas);
            this.invocarExcepciones(false);

            //TODO: SolTechnologies - 16.Muestra el resultado del score en el btn Excepcion
            int idSolicitud = this.objEvalCred.idSolicitud;

            var aReglasTruncantesFallidas = aReglasEvaluadas.FindAll(x => x.lResul == "NO" && x.lIndExcepcion == 0);
            if (aReglasTruncantesFallidas.Count > 0)
            {
                List<String> listExp = new List<String>();
                foreach (var item in aReglasTruncantesFallidas)
                {
                    listExp.Add(item.cMensajeError);
                }
                var _cMotivoRechazo = string.Join("\r\n", listExp);

                frmRespuestaMotor msjRespuesta = new frmRespuestaMotor(
                                                        3
                                                        , idSolicitud
                                                        , "Rechazado"
                                                        , DateTime.Now.ToString("hh:mm:ss tt")
                                                        , "Rechazado por reglas No Excepcionables."
                                                        , _cMotivoRechazo
                                                        );
                msjRespuesta.ShowDialog();
            }
            else
            {
                if (idSolicitud > 0)
                {
                    var dtscoreMNB = new clsCNMotorDecision().ValidaRestriccionesMNB(idSolicitud);
                    if (dtscoreMNB.Rows.Count > 0)
                    {
                        var ultimoScoreMNB = dtscoreMNB.Rows[0];
                        string hora = DateTime.Now.ToString("hh:mm:ss tt");
                        int idScoreMNB = Convert.ToInt32(dtscoreMNB.Rows[0]["idPrediccion"]);

                        DataTable _configuracionMotor = new clsCNMotorDecision().ListarConfiguracion();
                        if (_configuracionMotor.Rows.Count > 0)
                        {
                            string comentario = string.Empty;
                            foreach (DataRow item in _configuracionMotor.Rows)
                            {
                                if (Convert.ToInt32(item["idRespuesta"]) == idScoreMNB)
                                {
                                    comentario = item["Comentario"].ToString();
                                }
                            }

                            //comentario = comentario + "\r\n" + ultimoScoreMNB["CMotivoRechazo"].ToString();

                            frmRespuestaMotor msjRespuesta =
                            new frmRespuestaMotor(Convert.ToInt32(ultimoScoreMNB["idPrediccion"]),
                                                  idSolicitud,
                                                  ultimoScoreMNB["cResultadoModelo"].ToString().ToUpper(),
                                                  hora,
                                                  comentario,
                                                  "");
                            msjRespuesta.ShowDialog();

                            return;
                        }
                    }
                }
            }
        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            int nMuestraFrm = 1;
            CargarConfiguracionSeguro(nMuestraFrm);
        }
        #endregion

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.objEvalCred.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = this.objEvalCred.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEvalCred";
            drfila[1] = this.objEvalCred.idEvalCred;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.objSolicitud.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = this.objEvalCred.nPlazoCuota;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = this.objEvalCred.nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = this.objEvalCred.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = this.objEvalCred.idProducto;
            dtTablaParametros.Rows.Add(drfila); 

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = this.objSolicitud.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = this.conCreditoTasa.Plazo();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = this.conCreditoTasa.Monto();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idOferta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.nMontoOferta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.nPlazo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacionOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCreditoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idModalidadCredito.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nFrecuenciaOferta";
            drfila[1] = (this.objOferta == null) ? "0" : (this.objOferta.nMeses / 30).ToString(); // crear un campo donde se obtenga los meses de frecuencia
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;


        }

        private bool ValidarReglasfrmEvalResumenPreAprob(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: "frmEvalResumenPreAprob",
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: this.objEvalCred.idCli,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: this.objEvalCred.idMoneda,
                                                                            idProducto: this.objEvalCred.idProducto,
                                                                            nValAproba: this.objEvalCred.nCapitalPropuesto,
                                                                            idDocument: this.objEvalCred.idSolicitud,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 2,
                                                                            idEstadoSol: 13,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto, lMostrarAlerta: lMostrarAlerta,
                                                                            aReglasEvaluadas: null);

            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            return false;
        }

        private bool ValidarReglas(bool lMostrarAlerta, List<clsReglaNegocioEvaluada> aReglasEvaluadas = null)
        {
            string cNombreFormulario = this.Name;
            if (this.lEsMNB)
            {
                cNombreFormulario = "ReglasMNB_CredPyme";
            } 
            
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
            //////////////////**//////////////

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: cNombreFormulario,
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: this.objEvalCred.idCli,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: this.objEvalCred.idMoneda,
                                                                            idProducto: this.objEvalCred.idProducto,
                                                                            nValAproba: this.objEvalCred.nCapitalPropuesto,
                                                                            idDocument: this.objEvalCred.idSolicitud,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 2,
                                                                            idEstadoSol: 13,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto, lMostrarAlerta: lMostrarAlerta,
                                                                            aReglasEvaluadas: aReglasEvaluadas);
            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool invocarExcepciones(bool lSilencioso)
        {
            clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            int nIdSolicitud = Convert.ToInt32(this.objEvalCred.idSolicitud);
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            int nIdCliente = Convert.ToInt32(this.objEvalCred.idCli);
            int nIdMoneda = Convert.ToInt32(this.objEvalCred.idMoneda);
            int nIdProducto = Convert.ToInt32(this.objEvalCred.idProducto);
            decimal nValAproba = Convert.ToDecimal(oEvalCredTemp.nMonto);
            int nIdUsuRegist = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            String cOpcion = this.Name;

            String cNombreForm = this.Name;
            if (this.lEsMNB) cNombreForm = "ReglasMNB_CredPyme";

            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, cNombreForm, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }

        private void conCreditoTasa_ChangeCuotaAprox(object sender, EventArgs e)
        {
            this.txtCuotaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaAprox());
            this.txtCuotaGraciaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaGraciaAprox());

            this.conEstadosFinancierosResumen.ActualizarPorIndPorMPropPorMAprox(this.listIndiFinanc, this.conCreditoTasa.Monto(), this.conCreditoTasa.CuotaAprox());
        }

        #region Método Privados
        private string ReferenciasToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReferenciaEval", typeof(int));
            dt.Columns.Add("idTipReferEval", typeof(int));
            dt.Columns.Add("idTipVinculoEval", typeof(int));
            dt.Columns.Add("cConcepto", typeof(string));
            dt.Columns.Add("cDireccion", typeof(string));
            dt.Columns.Add("cNumeroCelular", typeof(string));
            dt.Columns.Add("nEstado", typeof(byte));
            dt.Columns.Add("cComentarios", typeof(string)); //paulgpp

            foreach (clsReferenciaEval rc in this.listReferencia)
            {
                dt.Rows.Add(
                    rc.idReferenciaEval,
                    rc.idTipReferEval,
                    rc.idTipVinculoEval,
                    rc.cConcepto,
                    rc.cDireccion,
                    rc.cNumeroCelular,
                    rc.nEstado,
                    rc.cComentarios // paulgpp
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "ReferenciaEval", "Item");
        }
        #endregion

        /// <summary>
        /// Filtra datos de un datatable por columna
        /// </summary>
        /// <param name="dt">Datatable original de donde se aplicará el filtro</param>
        /// <param name="cColumnaNombre">Nombre de la columna del datatable a filtrar</param>
        /// <param name="nValor">valor por el cual filtrar</param>
        /// <returns>Retorna un datatable con los valores filtrados</returns>
        private DataTable filtrarDataValorColumna(DataTable dt, string cColumnaNombre, int nValor)
        {
            DataTable dtResultado = dt.Clone();

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item[cColumnaNombre]) == nValor)
                {
                    dtResultado.ImportRow(item);
                }
            }

            return dtResultado;
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objEvalCred.idSolicitud, !this.objEvalCred.lEditar);
                frmCargaArchivo.ShowDialog();
            }
        }
        private void cboCultivoEval_SelectedValueChanged(object sender, EventArgs e)
        {
            int idCultivoEval = Convert.ToInt32(cboCultivoEval.SelectedValue);
            if (idCultivoEval > 0)
            {
                this.cboVariedadCultivoEval.CargaVariedadPorCultivo(idCultivoEval);
            }
        }

        private void frmEvalResumenPreAprob_Shown(object sender, EventArgs e)
        {
            this.conEstadosFinancierosResumen.VisibleButtonDeudas = true;
        }

        private void ObtenerOfertaSolicitud(int idOferta)
        {
            ClsCNClienteExclusivo objCliExclu = new ClsCNClienteExclusivo();
            DataTable dt = objCliExclu.CNObtenerOfertaClienteOferta(idOferta);
            if (dt.Rows.Count == 0)
                return;

            this.objOferta = DataTableToList.ConvertTo<ClsOfertaClienteExclusivo>(dt).ToList<ClsOfertaClienteExclusivo>()[0];
        }

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
            frmGestObs.lEditar = this.objEvalCred.lEditar;
            frmGestObs.idEtapaEvalCred = 3;
            frmGestObs.nModoFunc = 2;
            frmGestObs.idSolicitud = this.objSolicitud.idSolicitud == 0 ? this.objEvalCred.idSolicitud : this.objSolicitud.idSolicitud;
            frmGestObs.ConfigSelecFiltros(true, false, false, true);
            frmGestObs.ConfigHabilitarFiltros(false, true, true, false);
            frmGestObs.ShowDialog();
            }

        private bool ValidarIndicadorObser()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.objSolicitud.idSolicitud == 0 ? this.objEvalCred.idSolicitud : this.objSolicitud.idSolicitud, 3);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>("lResolCom"));
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            if (txtIdSolicitud.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar una solicitud de crédito válido.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTasaNegociable frm = new frmTasaNegociable();
            frm.flowLayoutPanel2.Visible = false;
            frm.grbDato_Solicitud.Visible = false;
            frm.Size = new System.Drawing.Size(705, 500);
            frm.lTasafrm = true;
            frm.BuscarSolicitud(Convert.ToInt32(txtIdSolicitud.Text));
            if (frm.lTasaNegociada == true)
            {
                frm.idSolicitud_frm = Convert.ToInt32(txtIdSolicitud.Text);
                frm.ShowDialog();
            }
        }
        #region Evaluacion Presencial-remota
        private void ValidarVisitaPresencialRemota(FrmBuscarEvalRapido formulario, int idEvalCred)
        {
            string cNombreFormulario = this.Name;
            List<Tuple<int, string>> listTiposEvaluacionPresencialRemota = new List<Tuple<int, string>>();

            DataTable dtTipoEvaluacion = objCNCargaArchivoDocEval.CNListaTipoEvaluacion();

            foreach (DataRow row in dtTipoEvaluacion.Rows)
            {
                int idTipEvalConfig = Convert.ToInt32(row["idTipEvalConfig"]);
                DataTable dtRespuestaEvalPreRem = ArmarTablaParametrosEvalPreRemo(idTipEvalConfig, formulario);
                string cCumpleReglas = new clsCNValidaReglaConfig().ValidarReglasConfig(dtRespuestaEvalPreRem, cNombreFormulario, idTipEvalConfig);

                if (cCumpleReglas == "OK")
                {
                    string cTipEvalConfig = row["cTipEvalConfig"].ToString();
                    Tuple<int, string> listTipoEvaluacionTuple = new Tuple<int, string>(idTipEvalConfig, cTipEvalConfig);

                    if (idTipEvalConfig == 3)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                    else if (idTipEvalConfig == 2)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                }
            }

            if (listTiposEvaluacionPresencialRemota.Count > 0)
            {
                RecuperarDocEvalAnterior(listTiposEvaluacionPresencialRemota, formulario, idEvalCred);
            }
            else
            {
                MessageBox.Show("No cumple con las reglas de validación para una solicitud anterior.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable ArmarTablaParametrosEvalPreRemo(int idTipEvalConfig, FrmBuscarEvalRapido formulario)
        {
            DataTable dtTablaParametrosEval = new DataTable();
            dtTablaParametrosEval.Columns.Add("cNombreCampo");
            dtTablaParametrosEval.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametrosEval.NewRow();

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idCli";
            drfila[1] = formulario.idCli;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idTipEvalConfig";
            drfila[1] = idTipEvalConfig;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "nMontoSol";
            drfila[1] = formulario.nMontoProp;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "cIdTipEvalCred";
            drfila[1] = this.idTipEvalCred.ToString();
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametrosEval.Rows.Add(drfila);

            return dtTablaParametrosEval;
        }

        private void RecuperarDocEvalAnterior(List<Tuple<int, string>> listTiposEvaluacion, FrmBuscarEvalRapido formulario, int idEvalCred)
        {
            int idTipEvalConfig = listTiposEvaluacion[0].Item1;
            int idSolicitudAnterior = 0;
            int idSolicitud = formulario.idSolicitud;
            int idCli = formulario.idCli;
            string cIdTipEvalCred = this.idTipEvalCred.ToString();
            int idEvalCredAnterior = 0;
            int idTipEvalConfigRespuesta = 0;

            DataTable dtSolicitudEvalAnterior = objCNCargaArchivoDocEval.CNRecuperaSolicitudAnterior(idCli, Convert.ToDateTime(Evaluacion.FechaActualEval), cIdTipEvalCred, idTipEvalConfig);

            if (Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]) == 0)
            {
                MessageBox.Show("La validación de las reglas remota y presencial ha fallado.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtSolicitudEvalAnterior.Rows.Count > 0)
            {
                idSolicitudAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]);

                frmSeleccionarDocEvalAnterior frmSeleccionarDoc = new frmSeleccionarDocEvalAnterior(idSolicitudAnterior, idSolicitud, listTiposEvaluacion);
                frmSeleccionarDoc.ShowDialog();
                idTipEvalConfigRespuesta = frmSeleccionarDoc.idTipEvalConfig;

                idEvalCredAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idEvalCred"]);
                ActualizaInformacionEvaluacion(idEvalCred, idEvalCredAnterior, idTipEvalConfigRespuesta, cIdTipEvalCred);
            }
        }

        private void ActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            clsCNSeleccionarDocEvalAnterior objCNCargaArchivoDocEval = new clsCNSeleccionarDocEvalAnterior();

            DataTable dt = objCNCargaArchivoDocEval.CNActualizaInformacionEvaluacion(idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
    }
}
