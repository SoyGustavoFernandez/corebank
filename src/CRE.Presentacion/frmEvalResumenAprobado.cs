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

namespace CRE.Presentacion
{
    public partial class frmEvalResumenAprobado : frmBase
    {
        #region Variables
        private string cMsjCaption = "Evaluación Resumida - Aprobada";

        private clsCNEvaluacion objCapaNegocio;

        private clsEvalCred objEvalCred;
        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;

        private clsCNEstadosFinancierosResumen objEstadosFinancieros;

        private DateTime dFechaBase;
        private clsCreditoProp objSolicitud;
        private const int nAnioMinimo = 2000;
        private int idTipEvalCred = 16;     //RESUMIDA - APROBADO
        private int idCanal;
        private string cIdProductoNoPasan;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private bool lAgricola;
        #endregion

        public frmEvalResumenAprobado()
        {
            InitializeComponent();

            this.objCapaNegocio = new clsCNEvaluacion();
            this.objEstadosFinancieros = new clsCNEstadosFinancierosResumen();

            HabilitarBotones(false);
            this.btnBusqueda.Enabled = true;

            Evaluacion.DataTableMoneda = (new clsCNMoneda()).listarMoneda();

            this.cboMoneda.DisplayMember = "cMoneda";
            this.cboMoneda.ValueMember = "idMoneda";
            this.cboMoneda.DataSource = Evaluacion.DataTableMoneda;

            this.cboTipoPeriodo.DisplayMember = "cDescripTipoPeriodo";
            this.cboTipoPeriodo.ValueMember = "idTipoPeriodo";
            this.cboTipoPeriodo.DataSource = (new clsCNTipoPeriodo()).dtListaTipoPeriodo();
            tbcCredito.SelectedIndex = 1;

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
                    //btnAdministradorFiles1.idSolicitud = this.objSolicitud.idSolicitud;
                    //btnAdministradorFiles1.actualizarDatos();
                    //btnAdministradorFiles1.Enabled = true;

                    btnVincularVisita1.idSolicitud = this.objSolicitud.idSolicitud;
                    btnVincularVisita1.idCli = this.objEvalCred.idCli;
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

            this.lAgricola = Convert.ToBoolean(dsResult.Tables[8].Rows[0]["lAgricola"]);


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
                idCli = this.objSolicitud.idCli
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
        }

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
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
                this.btnValidar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;

                this.conEstadosFinancierosResumen.Enabled = true;
                this.panel2.Enabled = true;
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnValidar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = false;

                this.conEstadosFinancierosResumen.Enabled = false;
                this.panel2.Enabled = false;
            }
            else if (nModo == clsAcciones.ENVIAR)
            {
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = lHabilitado;
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
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnObservacion1.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
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
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnObservacion1.Enabled = false;
                this.tabEval.Enabled = true;

                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnEnviar.Enabled = false;
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
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;
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

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

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
            /*var nTotalActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
            var nTotalPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);
            var nVentasNetas = this.listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            var nUDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);
            var nCaja = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Caja).Sum(x => x.nTotalMA);
            decimal nTotalPrestamos = this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosCP).Sum(x => x.nTotalMA) +
                                 this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosLP).Sum(x => x.nTotalMA);

            var nOtrosIngresos = this.listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            var nUtilidadNeta = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);

            decimal nPorcentaje = this.listDestCredProp.Sum(x => x.nPorcentaje);


           #region Estados Financieros
            if (this.lBalanceGeneral)
            {
                if (nTotalActivo == 0)
                    objMsjError.AddError("Estados Financ.: Total Activo es CERO.");

                if (nTotalPrestamos < this.objEvalCred.nTotalDeudas)
                    objMsjError.AddError("Estados Financ.: Actualice las Deudas con Entidades Financieras.");

            }

            if (nVentasNetas == 0)
                objMsjError.AddError("Estados Financ.: Las Ventas Netas estan en CERO.");

            if (nUDisponible < 0)
                objMsjError.AddError("Estados Financ.: Utilidad Disponible es un valor NEGATIVO.");

            if (nUDisponible > 0 && nOtrosIngresos > nUtilidadNeta)
            {
                objMsjError.AddError("Estados Financ.: \"Otros Ingresos\" es mayor que la \"Utilidad Neta\".");
            }

            if (this.objEvalCred.nCajaInicial > nCaja)
            {
                objMsjError.AddError("Estados Financ.: \"Caja Inicial\" es mayor a la Cuenta. del BBGG.");
            }
            #endregion
            */

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
            /******************** Convierte a partir de si_finVaribale->cNoEvaResApro ***************************/
            cIdProductoNoPasan = clsVarApl.dicVarGen["cNoEvaResApro"];
            String[] cArrayIdProductoNoPasan;
            int[] nArrayIdProductoNoPasan;
            cArrayIdProductoNoPasan = cIdProductoNoPasan.Split(',');
            nArrayIdProductoNoPasan = Array.ConvertAll<string, int>(cArrayIdProductoNoPasan, int.Parse);
            /****************************************************************************************************/


            FrmBuscarEvalRapido formBuscarEv = new FrmBuscarEvalRapido(this.idTipEvalCred.ToString(), "Buscar Evaluaciones");
            formBuscarEv.ShowDialog();

            if (formBuscarEv.idCli != 0)
            {
                idEvalCred = formBuscarEv.idEvalCred;

                if (formBuscarEv.idSolicitud != 0)
                {
                    if (formBuscarEv.idTipEvalCred > 0 && formBuscarEv.idTipEvalCred != this.idTipEvalCred)
                    {
                        MessageBox.Show("Debe evaluarse en el formulario de evaluación: " + formBuscarEv.cTipEvalCred, this.cMsjCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                    int idProducto = formBuscarEv.idProducto;
                    if (idProducto.In(nArrayIdProductoNoPasan))
                    {
                        MessageBox.Show("Este producto no puede evaluarse mediante este formulario.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    /***********************************************************************************
                    * Validacion de Campañas (Escolar)
                    * 0->false (cuando no cumple con la condicion de la campaña)
                    * 1->true (cuando si cumple con la condicion de la campaña)
                    * 2->Clasificacion interna incorrecta (Cuando no cumple con la condcion de la campaña)
                    * 3->No corresponde a campaña (cuando no esta dentro de la campaña , por o que se considera TRUE)
                    * ************************************************************************************/
                    DataTable dtValidacionCampania = (new clsCNEvaluacion()).CNRetornaValidacionCampania(formBuscarEv.idSolicitud, this.Name);
                    int idDtValidaCampania = Convert.ToInt32(dtValidacionCampania.Rows[0]["idError"].ToString());
                    string cDtValidaCampania = Convert.ToString(dtValidacionCampania.Rows[0]["cMsjError"].ToString());

                    if (idDtValidaCampania == 0 || idDtValidaCampania == 2)
                    {
                        MessageBox.Show("Este producto no puede evaluarse mediante este formulario." + Environment.NewLine + cDtValidaCampania, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    /*****************************************************************************************/



                    if(idEvalCred == 0)
                    {
                        DataTable dt = objCapaNegocio.CrearEvalRapiCredito(formBuscarEv.idSolicitud, this.idTipEvalCred, clsVarGlobal.User.idUsuario);

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["idMsje"].ToString().Equals("0"))
                            {
                                idEvalCred = Convert.ToInt32(dt.Rows[0]["idEvalCred"]);
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
            clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

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

            // -- Convertir a XML
            string xmlEvalCred = this.EvalCredToXML();
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();
            string xmlIndicadorEval = this.IndicadoresToXML();

            string xmlDatosAgricola = this.datosAgricolaXML();
            string xmlReferencias = "<ReferenciaEval/>";     
            
            DataTable td = this.objCapaNegocio.ActualizarEval(this.objEvalCred.idEvalCred,
                        xmlEvalCred,
                        xmlBalGenEval,
                        xmlEstResEval,
                        xmlIndicadorEval,
                        this.lAgricola,
                        xmlDatosAgricola,
                        xmlReferencias
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

            ValidarReglas(false);
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
            }
            else
            {
                MessageBox.Show("No se encontraron errores en la Evaluación.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

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

            foreach (clsEstResEval item in this.listEstResEval)
            {
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
            invocarExcepciones();
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
            drfila[0] = "idSubProducto";
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
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.objEvalCred.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = this.objEvalCred.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool ValidarReglas(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
            //////////////////**//////////////

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: this.Name,
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
                                                                            idSolApr: ref nNivAuto, lMostrarAlerta: lMostrarAlerta);
            if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void invocarExcepciones()
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
            frmExcepciones excepciones = new frmExcepciones(nIdSolicitud, nIdAgencia, nIdCliente, nIdMoneda, nIdProducto, nValAproba, nIdUsuRegist, cOpcion);
            excepciones.ShowDialog();
        }

        private void conCreditoTasa_ChangeCuotaAprox(object sender, EventArgs e)
        {
            this.txtCuotaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaAprox());
            this.txtCuotaGraciaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaGraciaAprox());

            this.conEstadosFinancierosResumen.ActualizarPorIndPorMPropPorMAprox(this.listIndiFinanc, this.conCreditoTasa.Monto(), this.conCreditoTasa.CuotaAprox());
        }

        #region Método Privados

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
            if ( idCultivoEval > 0)
            {
                this.cboVariedadCultivoEval.CargaVariedadPorCultivo(idCultivoEval);
            }
        }

        private void frmEvalResumenAprobado_Shown(object sender, EventArgs e)
        {
            this.conEstadosFinancierosResumen.VisibleButtonDeudas = true;
        }
    }
}
