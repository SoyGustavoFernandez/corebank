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
using System.Collections;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using CreGrupoSol = CRE.CapaNegocio.clsCNGrupoSolidario;
using ADM.CapaNegocio;
using PdfSharp.Pdf.Content.Objects;
using CLI.CapaNegocio;
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmGeneraPlanPagoGrupoSolidario : frmBase
    {
        #region Variable Globales

        private DataTable dtCalendarioPagos = new DataTable("dtPlanPago");
        private DataTable dtModificaciones;
        private DataTable dtCuotasDobles;
        private DataTable dtAuxConfigGastos;
        private DataTable dtConfigGasto;
        private clsCNPlanPago cnplanpago = new clsCNPlanPago();
        private clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        private clsCNReaprobSol cnReaprobSol = new clsCNReaprobSol();
        clsCreditoProp objCreditoPropGrupo = new clsCreditoProp();
        private DataTable dtDatosModGPP = new DataTable();
        private CreGrupoSol objGrupoSol = new CreGrupoSol();
        private List<clsSolicitudGrupoSol> listSoli;
        private List<clsSolCreIntegranteGrupoSol> listDetIntgGrupoSol;
        private List<clsSolCreIntegranteGrupoSol> listDetIntgGrupoSol_copia = new List<clsSolCreIntegranteGrupoSol>();
        private clsMsjError oMsjGenPlanPagos;
        private clsCNAdministracionFiles clsFiles = new clsCNAdministracionFiles();
        private int idMoneda;
        private decimal nCapitalMaxCobSeg;
        private bool lAplicaSeguro;
        private string cTituloForm;

        private int idSolicitudCredGrupoSol;
        private int idGrupoSolidario;
        private int idOperacion;
        private int idModalidadCredito;
        private DateTime dFechaDesembolso;

        private BindingSource bindSource;

        DateTime dtpFecPrimeraCuota = DateTime.Today;
        TranPlanPagos nTransac = TranPlanPagos.Nuevo;
        
        private bool lProceso;
        private int nCuentasVinculadas;
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsCNPaqueteSeguro cnPaqueteSeguro = new clsCNPaqueteSeguro();
        private bool cambiarValorComboSeguro = false;
        #endregion

        public frmGeneraPlanPagoGrupoSolidario()
        {
            InitializeComponent();
            conPlanPagos1.cboAccionCuota1.Enabled = false;
            conPlanPagos1.btnCancelarModificaciones.Enabled = false;
            conPlanPagos1.dtgModificaciones.Enabled = false;
            conCondiCreditoGrupoSol.dtFechaPrimeraCuota.Enabled = true;
            conCondiCreditoGrupoSol.txtCuotasGracia.Enabled = false;
            this.cTituloForm = "Generación de plan de pagos grupales";
            this.dFechaDesembolso = clsVarGlobal.dFecSystem;
            this.idSolicitudCredGrupoSol= 0;
            this.idModalidadCredito = 0;
            this.idGrupoSolidario= 0;
            this.idOperacion = 0;
            this.listSoli = new List<clsSolicitudGrupoSol>();
            this.listDetIntgGrupoSol = new List<clsSolCreIntegranteGrupoSol>();
            this.bindSource = new BindingSource();
            this.IniDtGastos();
            this.IniEstructuradtModifica();
            this.lProceso = false;
            this.oMsjGenPlanPagos = new clsMsjError();
            cboAsesorNegociosGrupoSolidario.ListarPorAgencia(0);
            this.nCuentasVinculadas = 0;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            //--Validar si La solicitud de crédito todavía cuenta con uno o más expedientes que deben ser revisados
            if (ValidarChecklist() == "ERROR")
            {
                return;
            }
            //Validar si algun integrante cuenta con un plan de seguro vigente
            if (!ValidarSeguroVigente(dtgIntegrantesGrupoSol.Rows))
            {
                return;
            }
            this.lProceso = true;
            dtgIntegrantesGrupoSol.SelectionChanged -= dtgIntegrantesGrupoSol_SelectionChanged;
            foreach (DataGridViewRow item in dtgIntegrantesGrupoSol.Rows)
            {
                clsSolCreIntegranteGrupoSol obj = ((clsSolCreIntegranteGrupoSol)item.DataBoundItem);
                if (generaPlanPagosXIntegrante(obj.idSolicitud, ref obj))
                {
                    obj.lSelGeneraPlanPagos = true;
                    item.Selected = true;
                    dtgIntegrantesGrupoSol.FirstDisplayedScrollingRowIndex = item.Index;
                    dtgIntegrantesGrupoSol.Focus();
                }
                else
                {
                    MessageBox.Show("Corrija las observaciones mostradas anteriormente.\n"+
                    "* Se interrumpirá el procesamiento de los planes de pagos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lProceso = false;
                    return;
                }
            }

            dtgIntegrantesGrupoSol.SelectionChanged += dtgIntegrantesGrupoSol_SelectionChanged;
            
            ControlBotones(TranPlanPagos.Procesa);
        }

        private bool ValidarSeguroVigente(DataGridViewRowCollection rows)
        {

            #region PlanesDeSeguro
            //Validar vigencia de planes de seguro
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(cnPaqueteSeguro.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            foreach (DataGridViewRow item in rows)
            {
                clsSolCreIntegranteGrupoSol obj = ((clsSolCreIntegranteGrupoSol)item.DataBoundItem);
                DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(obj.idCli);

                DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                              where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                              select fila).FirstOrDefault();
                if (dr != null && cboOperacionCre.SelectedIndex == 3)
                {
                    MessageBox.Show("El cliente " + obj.cNombre + "tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro", this.cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPaqueteSeguro1.SelectedIndex = 0;
                    return false;
                }
                else if (dr != null && cboOperacionCre.SelectedIndex != 3)
                {
                    MessageBox.Show("El cliente " + obj.cNombre + " tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPaqueteSeguro1.SelectedIndex = 0;
                    return false;
                }
            }
            return true;
            #endregion
        }

        private void chcExtractoPagos_CheckedChanged(object sender, EventArgs e)
        {
            grbExtracto.Visible = chcExtractoPagos.Checked;
        }

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                return;
            }

            this.CargarDatos(conBusGrupoSol.dtGrupo, conBusGrupoSol.dtIntegrantes);
            //ControlBotones(TranPlanPagos.Selecciona);
            this.habilitarControles(clsAcciones.DEFECTO);

            if (this.idSolicitudCredGrupoSol > 0)
            {
                this.habilitarControles(clsAcciones.BUSCAR);
                this.vincularAhorro();
            }
        }

        private void LimpiarControles()
        {
            this.conCondiCreditoGrupoSol.LimpiarControl();
            this.conCondiCreditoGrupoSol.cargarProductoSol(Convert.ToInt32(clsVarApl.dicVarGen["nProductoGrupoSolMicro"]));
        }
        private void vincularAhorro()
        {
            if(this.idModalidadCredito == (int)ModalidadCredito.Estacional)
            {
                MessageBox.Show("Las solicitudes de crédito grupal con modalidad de crédito ESTACIONAL,  no requieren la vinculación de cuentas de ahorro.\n\n"+
                "*Continúe con el proceso de generación de planes de pagos de forma normal.",
                    "AHORRO NO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.CONTINUAR);
                return;
            }
            frmGrupoSolidarioVincularAhorro objFrmGrupoSolidarioVincularAhorro = new frmGrupoSolidarioVincularAhorro(this.idGrupoSolidario, this.idSolicitudCredGrupoSol, this.idOperacion);
            objFrmGrupoSolidarioVincularAhorro.ShowDialog();
            this.nCuentasVinculadas = objFrmGrupoSolidarioVincularAhorro.nCuentasVinculadas;

            if (this.nCuentasVinculadas >= this.listDetIntgGrupoSol.Count)
            {
                this.habilitarControles(clsAcciones.CONTINUAR);
            }
            else
            {
                MessageBox.Show("Vincule cuentas de ahorro para todos los integrantes del grupo.\n"+
                    "* Faltan "+ (this.listDetIntgGrupoSol.Count - this.nCuentasVinculadas) + " cuentas por vincular." +
                    "* No se permitira generar el plan de pagos.","CUENTAS VINCULADAS INCOMPLETAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.habilitarControles(clsAcciones.BUSCAR);
            }
        }

        private void CargarDatos(DataTable dtGrupo, DataTable dtIntegrantes)
        {
            this.idGrupoSolidario = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]);

            DataTable dtSolicitud = objGrupoSol.CNSolicitudesAprobadasGrupoSol(Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]));
            this.listSoli = DataTableToList.ConvertTo<clsSolicitudGrupoSol>(dtSolicitud) as List<clsSolicitudGrupoSol>;

            if (dtSolicitud.Rows.Count == 0)
            {
                MessageBox.Show("El grupo solidario " + dtGrupo.Rows[0]["cNombre"].ToString() + ", no tiene ninguna solicitud aprobada", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.idSolicitudCredGrupoSol = 0;
                this.idModalidadCredito = 0;
                return;
            }

            this.idSolicitudCredGrupoSol = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitudCredGrupoSol"]);
            this.idModalidadCredito = Convert.ToInt32(dtSolicitud.Rows[0]["idModalidadCredito"]);
            this.idOperacion = Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]);
            DataTable dtDetSolCreIntegrGrupoSol = objGrupoSol.CNDetalleSolicitudCredIntegranteGrupoSol(idGrupoSolidario, this.idSolicitudCredGrupoSol);
            this.listDetIntgGrupoSol = DataTableToList.ConvertTo<clsSolCreIntegranteGrupoSol>(dtDetSolCreIntegrGrupoSol) as List<clsSolCreIntegranteGrupoSol>;
            CrearCopiaDePaqueteSeguro();
            this.bindSource.DataSource = this.listDetIntgGrupoSol;

            dtgIntegrantesGrupoSol.DataSource = this.bindSource;
            this.FormatoGridIntegrantes();
            this.CargarInformacionGeneral();
            
            //if(listSoli[0].nCuotasGracia>0)
            //{
            //    conPlanPagos1.cboAccionCuota1.SelectedValue = 5; //cuotas de gracia
            //    conPlanPagos1.txtNumCuotaGracia.Text = listSoli[0].nCuotasGracia.ToString();
            //}
            conCondiCreditoGrupoSol.dtFechaPrimeraCuota.Enabled = true;
            conCondiCreditoGrupoSol.txtCuotasGracia.Enabled = false;

            if (Convert.ToInt32(conCondiCreditoGrupoSol.cboTipoPeriodo.SelectedValue) == 2)
            {
                conCondiCreditoGrupoSol.nudPlazoCuota.Enabled = false;
                conCondiCreditoGrupoSol.dtFechaPrimeraCuota.Enabled = false;
            }
            else
            {
                conCondiCreditoGrupoSol.nudPlazoCuota.Enabled = true;
                conCondiCreditoGrupoSol.dtFechaPrimeraCuota.Enabled = true;
            }

        }

        private void CargarInformacionGeneral()
        {
            this.objCreditoPropGrupo = null;
            this.objCreditoPropGrupo = new clsCreditoProp();

            this.idGrupoSolidario = listSoli[0].idGrupoSolidario;
            this.idSolicitudCredGrupoSol = listSoli[0].idSolicitudCredGrupoSol;

            this.lblBaseCustom1.Text = "Modalidad de crédito: " + listSoli[0].cModalidadCredito;
            this.objCreditoPropGrupo.idMoneda = listSoli[0].idMoneda;
            this.objCreditoPropGrupo.nCuotas = listSoli[0].nCuotas;
            this.objCreditoPropGrupo.idTipoPeriodo = listSoli[0].idTipoPeriodo;
            this.objCreditoPropGrupo.nPlazoCuota = listSoli[0].nPlazoCuota;
            this.objCreditoPropGrupo.nDiasGracia = listSoli[0].nDiasGracia;
            this.objCreditoPropGrupo.nCuotasGracia = listSoli[0].nCuotasGracia;
            this.objCreditoPropGrupo.dFechaDesembolso = listSoli[0].dFechaDesembolsoPropuesto;
            //this.objCreditoPropGrupo.dFechaDesembolso = clsVarGlobal.dFecSystem;
            this.objCreditoPropGrupo.idAsesor = listSoli[0].idUsuario;
            this.objCreditoPropGrupo.idAgencia = listSoli[0].idAgencia;
            this.objCreditoPropGrupo.idProducto = listSoli[0].idProducto;
            
            //this.objCreditoPropGrupo.idSubProducto = a;

            this.objCreditoPropGrupo.idOperacion = listSoli[0].idOperacion;
            this.objCreditoPropGrupo.idModalidadCredito = listSoli[0].idModalidadCredito;

            this.conCondiCreditoGrupoSol.AsignarDatos(objCreditoPropGrupo);
            this.conCondiCreditoGrupoSol.idTipoGrupoSolidario = this.objCreditoPropGrupo.idGrupoSolidarioTipo;
            this.cboAsesorNegociosGrupoSolidario.SelectedValue = this.objCreditoPropGrupo.idAsesor;
            this.cboOperacionCre.SelectedValue = this.idOperacion;
        }

        private void FormatoGridIntegrantes()
        {
            dtgIntegrantesGrupoSol.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgIntegrantesGrupoSol.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
            }

            dtgIntegrantesGrupoSol.Columns["lSelImpresion"].Visible = true;
            dtgIntegrantesGrupoSol.Columns["lSelGeneraPlanPagos"].Visible = true;
            dtgIntegrantesGrupoSol.Columns["cDocumentoID"].Visible = true;
            dtgIntegrantesGrupoSol.Columns["cNombre"].Visible = true;
            dtgIntegrantesGrupoSol.Columns["nCapitalAprobado"].Visible = true;
            dtgIntegrantesGrupoSol.Columns["nTasaAprobada"].Visible = true;

            dtgIntegrantesGrupoSol.Columns["lSelImpresion"].HeaderText = "Imp.";
            dtgIntegrantesGrupoSol.Columns["lSelGeneraPlanPagos"].HeaderText = "PP";
            dtgIntegrantesGrupoSol.Columns["cDocumentoID"].HeaderText = "N. Documento";
            dtgIntegrantesGrupoSol.Columns["cNombre"].HeaderText = "Cliente";
            dtgIntegrantesGrupoSol.Columns["nCapitalAprobado"].HeaderText = "Capital Aprobado";
            dtgIntegrantesGrupoSol.Columns["nTasaAprobada"].HeaderText = "TEA";

            dtgIntegrantesGrupoSol.Columns["lSelImpresion"].DisplayIndex = 0;
            dtgIntegrantesGrupoSol.Columns["lSelGeneraPlanPagos"].DisplayIndex = 1;
            dtgIntegrantesGrupoSol.Columns["cDocumentoID"].DisplayIndex = 2;
            dtgIntegrantesGrupoSol.Columns["cNombre"].DisplayIndex = 3;
            dtgIntegrantesGrupoSol.Columns["nCapitalAprobado"].DisplayIndex = 4;
            dtgIntegrantesGrupoSol.Columns["nTasaAprobada"].DisplayIndex = 5;

            dtgIntegrantesGrupoSol.Columns["lSelImpresion"].ReadOnly = false;

        }

        /// <summary>
        /// Genera plan de pagos por integrante del grupo solidario
        /// </summary>
        /// <param name="idSolicitud">identificador de la solicitud individual</param>
        /// <param name="oSelInte">objeto donde se tiene toda la información de la solicitud individual</param>
        private bool generaPlanPagosXIntegrante(int idSolicitud, ref clsSolCreIntegranteGrupoSol oSelInte)
        {
            // ***************************************************************
            // cargando configuracion de gasto
            // ***************************************************************
            dtConfigGasto = null;
            dtAuxConfigGastos = null;
            CargarConfiguracionesDeGasto(idSolicitud, ref oSelInte);
            
            conPlanPagos1.dtgCalendario.DataSource = null;
            if (conPlanPagos1.dtgModificaciones.DataSource != null)
            {
                ((DataTable)conPlanPagos1.dtgModificaciones.DataSource).Clear();
            }
            int nNumsolicitud = idSolicitud;

            if (!ValidarDatosProcesoPp())
            {
                return false;
            }

            DataTable dtSolOpiRecu = cnsolicitud.verificarSolReaprobacion(nNumsolicitud);
            if (dtSolOpiRecu.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud tiene pendiente la opinión de recuperaciones.", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #region SETEO DE PARAMETROS PARA EL PLAN DE PAGOS

            decimal nMonDesemb = oSelInte.nCapitalAprobado;                    // Monto Desembolsado
            decimal nTasaInteres = oSelInte.nTasaAprobada/100.00m;             // Tasa de Interes Efectiva
            
            DateTime dFecDesemb = conCondiCreditoGrupoSol.dtFechaDesembolso.Value.Date;          // Fecha de Desembolso

            int nNumCuoCta = oSelInte.nCuotas;                                 // Número de Cuotas del Crédito
            int nDiaGraCta = oSelInte.nDiasGracia;                             // Días de Gracia
            short nTipPerPag = short.Parse(oSelInte.idTipoPeriodo.ToString()); // Tipo de periodo de pago (Fecha o Periodo Fijo)
            int nDiaFecPag = conCondiCreditoGrupoSol.PlazoCuota() ; // oSelInte.nPlazoCuota;                             // Día o Periodo fijo de pago

            #endregion

            if (CargarValidarGastos())
            {
                return false;
            }

            dtCuotasDobles = cnplanpago.retornarCuotasDobles(dtModificaciones, dFecDesemb, nNumCuoCta);

            //reiniciando el data table de gastos
            cnplanpago.iniciarDTGastos();

            var objSolicitudCreditoSeguroActual = objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud);
            objSolicitudCreditoSeguroActual.dFechaPrimeraCuota = conCondiCreditoGrupoSol.dtFechaPrimeraCuota.Value;
            objSolicitudCreditoSeguroActual.dFechaDesembolso = conCondiCreditoGrupoSol.dtFechaDesembolso.Value;
            objSolicitudCreditoSeguroActual.idTipoPlazo = conCondiCreditoGrupoSol.TipoPeriodo();

            objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro
                .Where(x => x.lSeleccionado && x.lVigente && x.idTipoValor == (int)TipoValorSeguroOptativo.MONTO_FIJO)
                .ToList()
                .ForEach(x => x.lSeleccionado = false);

            int idTipoSeguro = cboPaqueteSeguro1.ObtenerPaqueteSeleccionado(oSelInte.idPaqueteSeguro.In(0,-2) ? -1 : oSelInte.idPaqueteSeguro).idTipoSeguro;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int idUsuario = clsVarGlobal.User.idUsuario;
            var seguroPreliminar = objCNCreditoCargaSeguro.CNObtenerSolicitudCreditoSeguroPreliminar(nNumsolicitud, idTipoSeguro, dFechaSistema, idUsuario);

            objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro
                .Where(x => x.idTipoSeguro == idTipoSeguro)
                .ToList()
                .ForEach(x =>
                {
                    x.idSolicitud = seguroPreliminar.idSolicitud;
                    x.idSolicitudCreditoSeguro = seguroPreliminar.idSolicitudCreditoSeguro;
                    x.idMoneda = seguroPreliminar.idMoneda;
                    x.lSeleccionado = seguroPreliminar.lSeleccionado;
                    x.idTipoSeguro = seguroPreliminar.idTipoSeguro;
                    x.dFechaInicioVigencia = seguroPreliminar.dFechaInicioVigencia;
                    x.cMoneda = seguroPreliminar.cMoneda;
                    x.dFechaFinVigencia = seguroPreliminar.dFechaFinVigencia;
                    x.cTipoSeguro = seguroPreliminar.cTipoSeguro;
                    x.idUsuarioCancelacion = seguroPreliminar.idUsuarioCancelacion;
                    x.nValor = seguroPreliminar.nValor;
                    x.dFechaRegistro = seguroPreliminar.dFechaRegistro;
                    x.idTipoValor = seguroPreliminar.idTipoValor;
                    x.dFechaCancelacion = seguroPreliminar.dFechaCancelacion;
                    x.idConceptoRecibo = seguroPreliminar.idConceptoRecibo;
                    x.nMontoCobertura = seguroPreliminar.nMontoCobertura;
                    x.nPlazoCobertura = seguroPreliminar.nPlazoCobertura;
                    x.nValorCobertura = seguroPreliminar.nValorCobertura;
                    x.nMontoPrima = seguroPreliminar.nMontoPrima;
                    x.idZona = seguroPreliminar.idZona;
                    x.idAgencia = seguroPreliminar.idAgencia;
                    x.idUsuario = seguroPreliminar.idUsuario;
                    x.lVigente = seguroPreliminar.lVigente;
                    x.idCanalRegistro = seguroPreliminar.idCanalRegistro;
                    x.idConcepto = seguroPreliminar.idConcepto;
                });

            //Generar el plan de pagos manteniendo o no las cuotas a pagar constantes 
            dtCalendarioPagos = cnplanpago.CalculaPpgCuotasConstantes2(nMonDesemb, nTasaInteres, dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag,
                                                        nNumsolicitud, dtAuxConfigGastos, idMoneda, dtCuotasDobles, conCondiCreditoGrupoSol.dFechaPrimeraCuota().Date,
                                                        0, oSelInte.nCapitalMaxCobSeg, oSelInte.nCuotasGracia, chcMantenerCuotasCtes.Checked,
                                                        0, objSolicitudCreditoSeguroActual);
            tabPlanPagos.SelectedIndex = 1;

            foreach (DataRow item in dtCalendarioPagos.Rows)
            {
                item["nIdSolicitud"] = idSolicitud;
            }


            oSelInte.dFechaUltimoPagoCredito = dtCalendarioPagos.AsEnumerable().Last().Field<DateTime>("fecha");

            conPlanPagos1.dtCalendarioPagos = dtCalendarioPagos;
            conPlanPagos1.dtCargaGastos = dtAuxConfigGastos;
            conPlanPagos1.dtGastosPP = cnplanpago.ObtenerGastos(nNumsolicitud);
            conPlanPagos1.nTipPeriodo = nTipPerPag;
            conPlanPagos1.nNumCuotas = nNumCuoCta;
            conPlanPagos1.dFechaDesembolso = dFecDesemb;
            conPlanPagos1.nMonto = nMonDesemb;
            conPlanPagos1.nPlazo = nDiaFecPag;
            conPlanPagos1.nDiasGracia = nDiaGraCta;
            conPlanPagos1.nTasaInteres = oSelInte.nTasaAprobada;
            conPlanPagos1.idMoneda = idMoneda;
            conPlanPagos1.lCuotaCte = chcMantenerCuotasCtes.Checked;
            conPlanPagos1.dFecPriCuota = conCondiCreditoGrupoSol.dFechaPrimeraCuota().Date;
            conPlanPagos1.cnplanpago = cnplanpago;
            conPlanPagos1.IdSolicitud = nNumsolicitud;
            conPlanPagos1.cargarDatos();

            // *****************************************************************************
            // Obteniedo Plan de pagos
            // *****************************************************************************
            DataSet dsPlanPagos = new DataSet("dsPlanPagos");
            dtCalendarioPagos = conPlanPagos1.dtCalendarioPagos;
            dtCalendarioPagos.TableName = "dtPlanPago";

            dsPlanPagos.Tables.Add(dtCalendarioPagos);
            //Formar el Detalle De Gastos de la Solicitud tal como va ser registrado en Base de Datos

            //dsPlanPagos.Tables.Add(cnplanpago.FormarTablaDetalleGastos(dtAuxConfigGastos, this.conPlanPagos1.dtCalendarioPagos.Rows.Count, nNumsolicitud));
            DataTable dtGastosSolicitud = conPlanPagos1.dtGastosPP ?? cnplanpago.ObtenerGastos(nNumsolicitud);
            dtGastosSolicitud.TableName = "TablaDetalleGastosSolicitud";
            dsPlanPagos.Tables.Add(dtGastosSolicitud);

            dtModificaciones = conPlanPagos1.dtModificaciones;
            dtModificaciones.TableName = "dtModificaciones";

            dsPlanPagos.Tables.Add(dtModificaciones);

            dtConfigGasto.TableName = "dtConfigGasto";
            dsPlanPagos.Tables.Add(dtConfigGasto);

            #region Datos de crédito a xml

            DataTable dtDatCred = new DataTable("dtDatCred");

            dtDatCred.Columns.Add("idTipoPeriodo", typeof(int));
            dtDatCred.Columns.Add("nPlazoCuota", typeof(int));
            dtDatCred.Columns.Add("nDiasGracia", typeof(int));

            // ========================================================================================
            // Guardando la aplicación del seguro y el monto de cobertura del crédito
            // ========================================================================================
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof (decimal));
            // ========================================================================================
            // Final Guardando la aplicación del seguro y el monto de cobertura del crédito
            // ========================================================================================

            dtDatCred.Columns.Add("idPaqueteSeguro", typeof(int));
            dtDatCred.Columns.Add("idFrmPaqueteSeguro", typeof(int));

            oSelInte.idPaqueteSeguro = oSelInte.idPaqueteSeguro == -2 ? 0 : oSelInte.idPaqueteSeguro;
            oSelInte.idFrmPaqueteSeguro = oSelInte.idFrmPaqueteSeguro == 0 ? 2 : oSelInte.idFrmPaqueteSeguro;//Registrado en plan de pagos

            dtDatCred.Rows.Add(oSelInte.idTipoPeriodo, oSelInte.nPlazoCuota, oSelInte.nDiasGracia,
                                oSelInte.lAplicaSeguro, oSelInte.nCapitalMaxCobSeg, conPlanPagos1.cnplanpago.nMontoCuota,
                                oSelInte.idPaqueteSeguro, oSelInte.idFrmPaqueteSeguro);
            dsPlanPagos.Tables.Add(dtDatCred);

            #endregion

            string xmlPpg = dsPlanPagos.GetXml();
            xmlPpg = clsCNFormatoXML.EncodingXML(xmlPpg);
            dsPlanPagos.Tables.Clear();

            oSelInte.cXmlPlanPagos = xmlPpg;
            oSelInte.nTCEA = conPlanPagos1.txtTCEA.nDecValor;
            return true;

        }

        /// <summary>
        /// Valida el procesamiento del plan de pagos
        /// </summary>
        /// <returns>Indicador verdadero o falso</returns>
        private bool ValidarDatosProcesoPp()
        {
            
            const string cTitulo = "Validación Plan de Pago";
            if (this.idSolicitudCredGrupoSol <= 0)
            {
                MessageBox.Show("Se necesita cargar los datos de una solicitud para generar su plan de pagos", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (conCondiCreditoGrupoSol.dtFechaDesembolso.Value.Date != clsVarGlobal.dFecSystem.Date && !chcBancoNacion.Checked)
            {
                MessageBox.Show("La fecha de desembolso no puede ser diferente a la fecha del sistema. Verifique", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (conCondiCreditoGrupoSol.dtFechaDesembolso.Value.Date < clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de desembolso no puede ser menor a la fecha del sistema. Verifique", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void IniDtGastos()
        {
            dtAuxConfigGastos = new DataTable("TablaDetalleGastosSolicitud");

            dtAuxConfigGastos.Columns.Add("idSolicitud", typeof(int));
            dtAuxConfigGastos.Columns.Add("idPlanPagos", typeof(int));
            dtAuxConfigGastos.Columns.Add("idCuota", typeof(int));
            dtAuxConfigGastos.Columns.Add("nGasto", typeof(decimal));
            dtAuxConfigGastos.Columns.Add("nValor", typeof(decimal));
            dtAuxConfigGastos.Columns.Add("idTipoGasto", typeof(int));
            dtAuxConfigGastos.Columns.Add("idTipoValor", typeof(int));
            dtAuxConfigGastos.Columns.Add("idAplicaConc", typeof(int));
            dtAuxConfigGastos.Columns.Add("lVigente", typeof(bool));
        }

        private void IniEstructuradtModifica()
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
            dtModificaciones.Columns.Add("idCuotalibre", typeof(int));
            dtModificaciones.Columns.Add("nDia", typeof(int));
        }

        private void CargarConfiguracionesDeGasto(int nNumSolicitud, ref clsSolCreIntegranteGrupoSol oSel)
        {
            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            #region Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            DataTable dtTodosConfigGastos = objSegDes.validarAplicaSeguroDesgravamen(nNumSolicitud, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal);
            oSel.nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            oSel.lAplicaSeguro = objSegDes.obternerNAplicaSeguro();
            conPlanPagos1.nCapitalMaxCobSeg = nCapitalMaxCobSeg;

            #endregion

            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 
            dtConfigGasto = SeleccionarTipoTasaEnConfiguracion(dtTodosConfigGastos);

            
        }

        private static DataTable SeleccionarTipoTasaEnConfiguracion(DataTable dtTodosConfigGastos)
        {
            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 

            //Contedrá los Gastos PORCENTUALES SIMPLES ó COMPUESTOS independiente de los FIJOS
            DataTable dtConfigGasto = dtTodosConfigGastos.Clone();

            bool lUsaPorcentualSimple = dtTodosConfigGastos.AsEnumerable()
                .Any(x => x.Field<string>("cIdTipoValor").ToUpper().Equals("PORCENTUAL SIMPLE"));
            bool lUsaPorcentualCompuesto = dtTodosConfigGastos.AsEnumerable()
                .Any(x => x.Field<string>("cIdTipoValor").ToUpper().Equals("PORCENTUAL COMPUESTO"));

            //Validar el uso de sólo un tipo de TASA PORCENTUAL
            if (lUsaPorcentualSimple && lUsaPorcentualCompuesto)//Existen en la configuración las 2 Tasas, entonces elegir uno de ellos
            {
                DialogResult result = MostarVentanaPregunta("Elección de tipo de Tasa:.");

                switch (result)
                {
                    case DialogResult.OK:
                        foreach (DataRow row in dtTodosConfigGastos.Rows.Cast<DataRow>()
                                                .Where(row => !row["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL COMPUESTO")))
                        {
                            dtTodosConfigGastos.ImportRow(row);
                        }
                        break;
                    case DialogResult.Cancel:
                        foreach (DataRow row in dtTodosConfigGastos.Rows.Cast<DataRow>()
                            .Where(row => !row["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL SIMPLE")))
                        {
                            dtTodosConfigGastos.ImportRow(row);
                        }
                        break;
                }
            }
            else//En la configuración sólo existe un tipo de tasa porcentual (SIMPLE ó COMPUESTO)
            {
                dtConfigGasto = dtTodosConfigGastos;
            }

            return dtConfigGasto;
        }

        private static DialogResult MostarVentanaPregunta(string cTituloVentana)
        {
            Form frmDecision = new Form();

            Label lblTexto = new Label();

            PictureBox pictureBox = new PictureBox();

            Button btnPorcentualSimple = new Button();
            Button btnPorcentualCompuesto = new Button();

            frmDecision.Text = cTituloVentana;
            lblTexto.Text = "Existen 2 tipos de tasas (PORCENTUAL SIMPLE y PORCENTUAL COMPUESTO) en las configuraciones para ésta solicitud. Elija un tipo de Tasa.";
            lblTexto.AutoSize = false;

            btnPorcentualSimple.Text = "SIMPLE";
            btnPorcentualCompuesto.Text = "COMPUESTO";

            btnPorcentualSimple.DialogResult = DialogResult.OK;//Para la elección de Tasa Porcentual Simple
            btnPorcentualCompuesto.DialogResult = DialogResult.Cancel;//Para la elección de Tasa Porcentual Compuesta

            Icon Icono = SystemIcons.Question;
            pictureBox.Image = Icono.ToBitmap();

            lblTexto.SetBounds(65, 20, 400, 32);
            btnPorcentualSimple.SetBounds(68, 75, 135, 23);
            btnPorcentualCompuesto.SetBounds(288, 75, 165, 23);
            pictureBox.SetBounds(15, 20, 73, 50);
            //lblTexto.ForeColor = System.Drawing.Color.Navy;

            frmDecision.Height = 175;
            frmDecision.Width = 500;
            frmDecision.Controls.AddRange(new Control[] { lblTexto, btnPorcentualSimple, btnPorcentualCompuesto, pictureBox });

            frmDecision.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmDecision.StartPosition = FormStartPosition.CenterScreen;
            frmDecision.MinimizeBox = false;
            frmDecision.MaximizeBox = false;
            frmDecision.ControlBox = false;//deshabilitar el boton X del formulario
            frmDecision.CancelButton = btnPorcentualCompuesto;

            DialogResult dialogResult = frmDecision.ShowDialog();
            return dialogResult;
        }

        private void dtgIntegrantesGrupoSol_SelectionChanged(object sender, EventArgs e)
        {
            clsSolCreIntegranteGrupoSol oSel = (clsSolCreIntegranteGrupoSol)dtgIntegrantesGrupoSol.SelectedRows[0].DataBoundItem;
            cboDetalleGasto.SelectedValue = oSel.idDetalleGasto;
            cboPaqueteSeguro1.SelectedIndexChanged -= cboPaqueteSeguro_SelectedIndexChanged;
            CargarPaquetesSeguro(oSel.idPaqueteSeguro);
            cboPaqueteSeguro1.SelectedIndexChanged += cboPaqueteSeguro_SelectedIndexChanged;
            cboPaqueteSeguro1.Enabled = false;

            if (this.lProceso)
            {
                oSel = (clsSolCreIntegranteGrupoSol) dtgIntegrantesGrupoSol.SelectedRows[0].DataBoundItem;
                
                DataSet ds = obtenerDataSetDesdeXml(oSel.cXmlPlanPagos);

                conPlanPagos1.dtCalendarioPagos = ds.Tables["dtPlanPago"];
                conPlanPagos1.dtCargaGastos = ds.Tables["dtConfigGasto"];
                conPlanPagos1.dtGastosPP = ds.Tables["TablaDetalleGastosSolicitud"];
                conPlanPagos1.nTipPeriodo = short.Parse(oSel.idTipoPeriodo.ToString());
                conPlanPagos1.nNumCuotas = oSel.nCuotas;
                conPlanPagos1.dFechaDesembolso = oSel.dFechaDesembolsoPropuesto;
                conPlanPagos1.nMonto = oSel.nCapitalAprobado;
                conPlanPagos1.nPlazo = oSel.nPlazoCuota;
                conPlanPagos1.nDiasGracia = oSel.nDiasGracia;
                conPlanPagos1.nTasaInteres = oSel.nTasaAprobada;
                conPlanPagos1.idMoneda = oSel.idMoneda;
                conPlanPagos1.lCuotaCte = chcMantenerCuotasCtes.Checked;
                conPlanPagos1.dFecPriCuota = conCondiCreditoGrupoSol.dFechaPrimeraCuota().Date;
                conPlanPagos1.cnplanpago = cnplanpago;
                conPlanPagos1.IdSolicitud = oSel.idSolicitud;
                conPlanPagos1.cargarDatos();       
         
                //*********************************************************************
                // cargando datos en tasa
                //*********************************************************************
                nudMonto.Text = oSel.nCapitalAprobado.ToString("N2");
                txtTasaEfectivaAnual.Text = oSel.nTasaAprobada.ToString("N2");

                cboPaqueteSeguro1.Enabled = true;
            }
        }

        private DataSet obtenerDataSetDesdeXml(string cXml)
        {
            IniDtGastos();
            DataSet dsPlanPagosTmp = new DataSet("dsPlanPagos");
            DataTable dtPlanPagos = conPlanPagos1.dtCalendarioPagos.Clone();
            DataTable dtGastos = dtAuxConfigGastos.Clone();
            DataTable dtMod = dtModificaciones.Clone();
            DataTable dtConfigGas = dtConfigGasto.Clone();

            DataTable dtDatCred = new DataTable("dtDatCred");

            dtDatCred.Columns.Add("idTipoPeriodo", typeof(int));
            dtDatCred.Columns.Add("nPlazoCuota", typeof(int));
            dtDatCred.Columns.Add("nDiasGracia", typeof(int));

            // ========================================================================================
            // Guardando la aplicación del seguro y el monto de cobertura del crédito
            // ========================================================================================
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof(decimal));
            dtDatCred.Columns.Add("idPaqueteSeguro", typeof(int));
            


            dtPlanPagos.TableName = "dtPlanPago";
            dtGastos.TableName = "TablaDetalleGastosSolicitud";
            dtMod.TableName = "dtModificaciones";
            dtConfigGas.TableName = "dtConfigGasto";

            dsPlanPagosTmp.Tables.Add(dtPlanPagos);
            dsPlanPagosTmp.Tables.Add(dtGastos);
            dsPlanPagosTmp.Tables.Add(dtMod);
            dsPlanPagosTmp.Tables.Add(dtConfigGas);


            System.IO.StringReader xmlSR = new System.IO.StringReader(cXml);
            dsPlanPagosTmp.EnforceConstraints = false;
            dsPlanPagosTmp.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);

            return dsPlanPagosTmp;
        }

        private bool CargarValidarGastos()
        {
            //llamando a la función que calcula el plan de pagos en la capa de negocios          
            DataTable dtConfig = dtConfigGasto;//Se utiliza sólo para mostrar al Usuario en Pantalla

            //DataTable con el que se trabajará los 'Gastos Seleccionados' (check) que afectarán al Plan de Pagos
            dtAuxConfigGastos = dtConfig.Clone();//copiar la estructura del DataTable
            StringBuilder sbMensajesError = new StringBuilder();//Definir cadena en la que se acumluará los errores a mostrar
            bool lSwitchError = false;//permitirá verificar si hay algún error en la combinación de Asignación de Gastos al Plan de Pagos

            #region Carga de Gastos

            for (int i = 0; i < dtConfig.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtConfig.Rows[i]["lObligatorio"].ToString()))
                //Trabajar solo con los Configuración de Gastos que tienen check
                {
                    DataRow dr = dtAuxConfigGastos.NewRow();
                    dr["lObligatorio"] = dtConfig.Rows[i]["lObligatorio"];
                    dr["nIdCuota"] = dtConfig.Rows[i]["nIdCuota"];
                    dr["nIdTipoGasto"] = dtConfig.Rows[i]["nIdTipoGasto"];
                    dr["nIdTipoValor"] = dtConfig.Rows[i]["nIdTipoValor"];
                    dr["nIdAplicaConcepto"] = dtConfig.Rows[i]["nIdAplicaConcepto"];
                    dr["cIdCuota"] = dtConfig.Rows[i]["cIdCuota"];
                    dr["cIdTipoGasto"] = dtConfig.Rows[i]["cIdTipoGasto"];
                    dr["nGasto"] = dtConfig.Rows[i]["nGasto"];
                    dr["nValor"] = dtConfig.Rows[i]["nValor"];
                    dr["cIdTipoValor"] = dtConfig.Rows[i]["cIdTipoValor"];
                    dr["cMoneda"] = dtConfig.Rows[i]["cMoneda"];
                    dr["cIdAplicaConcepto"] = dtConfig.Rows[i]["cIdAplicaConcepto"];
                    dr["nTasaEfectivaDiaria"] = dtConfig.Rows[i]["nTasaEfectivaDiaria"];

                    if (chcMantenerCuotasCtes.Checked) //Mantener cuotas constantes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] +
                                                       " - " + dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine +
                                                       dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }

                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                    if (chcMantenerCuotasCtes.Checked == false) //cuotas no constntes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                }
            }

            //Verificar si la elección de la combinación de asignación de Gastos al Plan de Pagos es correcta
            if (lSwitchError)
            {
                MessageBox.Show(string.Format("No se permite la siguiente Combinación de Asignación de Gastos:{0}", sbMensajesError), "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que los Gastos que afecten a SALDO CAPITAL sean sólo PORCENTUAL SIMPLE ó PROCENTUAL COMPUESTO (no ambos) sólo para que las CUOTAS sean CONSTANTES
            string cTipoValor = string.Empty;
            string cMensajeError = string.Empty;
            int nContador = 0;
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") && Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nClasificTipoGasto"]) == 1)
                {
                    if (nContador == 0)
                    {
                        cTipoValor = dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString();
                        nContador++;
                    }
                    else
                    {
                        if (!cTipoValor.Equals(dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString()))
                        {
                            cMensajeError = Environment.NewLine + "Para que las CUOTAS sean CONSTANTES" +
                                            Environment.NewLine + "Los gastos que afecten a SALDO CAPITAL deben ser" +
                                            Environment.NewLine +
                                            "PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO (no ambos a la vez)";
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show(sbMensajesError + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que se cumpla con la asignación a cuotas determinadas
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show("No está permitido aplicar a:" + Environment.NewLine + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            #endregion

            return false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            guardarPlanesPagos();
            if (this.oMsjGenPlanPagos.HasErrors)
            {
                MessageBox.Show("Se ha registrado el plan de pagos para los siguientes integrantes del grupo solidario: \n \n"+ this.oMsjGenPlanPagos.GetErrors(), "Plan de Pagos - Grupal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.oMsjGenPlanPagos.clearList();
            }
            ControlBotones(TranPlanPagos.Graba);
        }

        private void guardarPlanesPagos()
        {
            foreach (DataGridViewRow item in dtgIntegrantesGrupoSol.Rows)
            {
                clsSolCreIntegranteGrupoSol obj = ((clsSolCreIntegranteGrupoSol)item.DataBoundItem);
                this.guardarPlanIndividual(obj);
            }

            DataTable dtRes = cnplanpago.CNGuardarPlanPagosGrupoSol(listSoli[0].idSolicitudCredGrupoSol);

            if (Convert.ToInt32(dtRes.Rows[0]["nResultado"].ToString()) == 1)
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Plan de Pagos - Grupal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Plan de Pagos - Grupal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cnPaqueteSeguro.CNEjecutarReactivacionSeguroOpcionalPorGrupo(listSoli[0].idSolicitudCredGrupoSol);
        }

        private void guardarPlanIndividual(clsSolCreIntegranteGrupoSol oSel)
        {
            string xmlPpg = oSel.cXmlPlanPagos;

            bool lDesembolsoExterno = chcBancoNacion.Checked;
            bool lExtractoPagos = chcExtractoPagos.Checked;
            int idMedioEnvio = rbtMedEnvio1.Checked ? 1 : rbtMedEnvio2.Checked ? 2 : 3;


            DataTable TablaInsPpg = cnplanpago.InsPpg(xmlPpg, conCondiCreditoGrupoSol.dtFechaDesembolso.Value.Date, oSel.nTCEA, conPlanPagos1.txtTEA.nDecValor,
                Convert.ToInt32(conPlanPagos1.txtTotDias.Text), oSel.dFechaUltimoPagoCredito, lDesembolsoExterno, lExtractoPagos, idMedioEnvio);

            TablaInsPpg.Columns[0].ColumnName = "cuota";
            conPlanPagos1.dtgCalendario.DataSource = TablaInsPpg;

            cnsolicitud.CNUpdtasaSolCre(oSel.idSolicitud, oSel.nTCEA);

            this.oMsjGenPlanPagos.AddError("Doc. Nro: - "+oSel.cDocumentoID+" - "+ oSel.cNombre);

            btnGrabar1.Enabled = false;
            btnPPInd.Enabled = true;
//            btnHojaResumen.Enabled = true;
            btnVincularPagare.Enabled = true;
  //          registrarRastreo(conBusCuentaCli1.nIdCliente, 0, "Fin - Registro de Plan de Pago", btnGrabar1);
        }

        private void btnVincularPagare_Click(object sender, EventArgs e)
        {
            frmVincularPagare frmpagare = new frmVincularPagare(0, 2, idSolicitudCredGrupoSol);
            frmpagare.ShowDialog();

            btnVincularPagare.Enabled = !frmpagare.lVinculado;
        }

        private void frmGeneraPlanPagoGrupoSolidario_Load(object sender, EventArgs e)
        {
            conCondiCreditoGrupoSol.bloqueoGenPlanPagos();
            ControlBotones(TranPlanPagos.Nuevo);
            conBusGrupoSol.txtIdGrupoSolidario.Enabled = true;
            cboDetalleGasto.listarDetalleGastoEnSolicitud();
            cboPaqueteSeguro1.SelectedIndexChanged -= cboPaqueteSeguro_SelectedIndexChanged;
            CargarPaquetesSeguro(-1);
            cboPaqueteSeguro1.SelectedIndexChanged += cboPaqueteSeguro_SelectedIndexChanged;
            cboPaqueteSeguro1.Enabled = false;
            validarPlanesDeSeguroActivados();
        }

        private void validarPlanesDeSeguroActivados()
        {
            //Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(cnPaqueteSeguro.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (lstPaqueteSeguros.Count == 0)
            {
                lblPaqueteSeguro.Visible = false;
                cboPaqueteSeguro1.Visible = false;
            }
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (clsSolCreIntegranteGrupoSol item in this.listDetIntgGrupoSol)
	        {
                item.lSelImpresion = chcBase1.Checked;
		 
	        }
            dtgIntegrantesGrupoSol.Refresh();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            foreach (clsSolCreIntegranteGrupoSol item in this.listDetIntgGrupoSol)
            {
                if (item.lSelImpresion)
                {
                    nCount++;
                    imprimirPPIndividual(item.idSolicitud, item.idCli);
                }
            }

            if (nCount == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun integrante para la impresión", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void imprimirPPIndividual(int idSolicitud, int idCli)
        {
            if (idSolicitud == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente con solicitud vigente", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtPpgCred = new clsRPTCNPlanPagos().ADCronogramaXSolicitud(idSolicitud);
            int idcli = Convert.ToInt32(dtPpgCred.Rows[0]["idCli"]);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false));
            //paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().DatosSolicitudImpPPG(idSolicitud)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNdocumento(idCli)));
            dtslist.Add(new ReportDataSource("dsIntervinientes", cncredito.DetalleImpPagare(idSolicitud)));

            string reportpath = "rptCalendarioPagos.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
        }

        private void btnHojaResumen_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            foreach (clsSolCreIntegranteGrupoSol item in this.listDetIntgGrupoSol)
            {
                if (item.lSelImpresion)
                {
                    nCount++;
                    imprimirHojaResumen(item.idSolicitud);
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun integrante para la impresión", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void imprimirHojaResumen(int idSolicitud)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();


            DataTable dtPpgCred = new clsRPTCNSolicitud().CNRptHojaResumen(idSolicitud);
            DataTable dtPpgCred1 = new clsRPTCNSolicitud().CNRptHojaResumenPlanPago(idSolicitud);
            DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaResolucion1", clsVarApl.dicVarGen["dFechaSalidaImpContratos"].ToString(), false));
            dtslist.Add(new ReportDataSource("dsHojaResumen", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred1));
            dtslist.Add(new ReportDataSource("dtVariables", dtVariable));

            //const string reportpath = "RptHojaResumen.rdlc";
            const string reportpath = "RptHojaResumenNuevoGS.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
        }

        private void ControlBotones(TranPlanPagos nTran)
        {
            switch (nTran)
            {
                case TranPlanPagos.Nuevo:
                    btnProcesar1.Enabled = false;
                    btnPPGrupal.Enabled = false;
                    btnPPInd.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnVincularPagare.Enabled = false;
                    btnHojaResumen.Enabled = false;

                    this.btnVincular.Enabled = false;
                    break;
                case TranPlanPagos.Selecciona:
                    btnProcesar1.Enabled = true;
                    btnPPGrupal.Enabled = false;
                    btnPPInd.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnVincularPagare.Enabled = false;
                    btnHojaResumen.Enabled = false;
                    break;
                case TranPlanPagos.Procesa:
                    btnProcesar1.Enabled = true;
                    btnPPGrupal.Enabled = false;
                    btnPPInd.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnVincularPagare.Enabled = false;
                    btnHojaResumen.Enabled = false;

                    this.conBusGrupoSol.Enabled = false;
                    break;
                case TranPlanPagos.Graba:
                    btnProcesar1.Enabled = false;
                    btnPPGrupal.Enabled = true;
                    btnPPInd.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnVincularPagare.Enabled = true;
                    btnHojaResumen.Enabled = true;

                    this.btnVincular.Enabled = false;
                    this.tabPlanPagos.Enabled = false;

                    this.conBusGrupoSol.Enabled = true;
                    break;
                default:
                    break;
            }

        }
        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.CONTINUAR:
                    this.gbxIntregantes.Enabled = true;
                    this.tabPlanPagos.Enabled = true;

                    this.btnVincular.Enabled = true;

                    this.btnProcesar1.Enabled = true;
                    this.btnChecklist.Enabled = true;
                    this.btnPPGrupal.Enabled = false;
                    this.btnPPInd.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.btnVincularPagare.Enabled = false;
                    this.btnHojaResumen.Enabled = false;
                    break;
                case clsAcciones.DEFECTO:
                    this.gbxIntregantes.Enabled = false;
                    this.tabPlanPagos.Enabled = false;

                    this.btnVincular.Enabled = false;

                    this.btnProcesar1.Enabled = false;
                    this.btnPPGrupal.Enabled = false;
                    this.btnPPInd.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.btnVincularPagare.Enabled = false;
                    this.btnHojaResumen.Enabled = false;
                    break;
                case clsAcciones.BUSCAR:
                    this.gbxIntregantes.Enabled = false;
                    this.tabPlanPagos.Enabled = false;

                    this.btnVincular.Enabled = true;

                    this.btnProcesar1.Enabled = false;
                    this.btnPPGrupal.Enabled = false;
                    this.btnPPInd.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.btnVincularPagare.Enabled = false;
                    this.btnHojaResumen.Enabled = false;
                    break;

            }
        }

        private void btnPPGrupal_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtInt = cnplanpago.CNrptIntegrantesGrupo(listSoli[0].idSolicitudCredGrupoSol);
            DataTable dtPP = cnplanpago.CNrptPlanPagosGrupal(listSoli[0].idSolicitudCredGrupoSol);
            DataTable dtDatosGrup = cnplanpago.CNrptDatosCreditoGrupal(listSoli[0].idSolicitudCredGrupoSol);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false));
            //paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("DatosGrupo_Credito", dtDatosGrup));
            dtslist.Add(new ReportDataSource("planPagos", dtPP));
            dtslist.Add(new ReportDataSource("integrantes", dtInt));

            string reportpath = "rptCronogramaPagosGrupal.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();

        }

        #region
        private void btnVincular_Click(object sender, EventArgs e)
        {
            this.vincularAhorro();
        }
        #endregion        

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            if (this.conBusGrupoSol.txtIdGrupoSolidario.Text != "")
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(idSolicitudCredGrupoSol, false, true, true, false);
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
            DataTable dtResCheckList = clsFiles.DtObtenerTipoGrupoArchivoCheckList(this.idSolicitudCredGrupoSol, true);
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

        private void CargarPaquetesSeguro(int idPaqueteSeguro)
        {
            int idDetalleGasto = Convert.ToInt16(cboDetalleGasto.SelectedValue);

            if (idDetalleGasto > 0)
            {
                int idAgencia = clsVarGlobal.nIdAgencia;
                int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;

                cboPaqueteSeguro1.CargarPaqueteSeguroVenta(idDetalleGasto, idPerfil, idAgencia, idPaqueteSeguro);
                cboPaqueteSeguro1.AgregarNinguno();
                cboPaqueteSeguro1.SelectedValue = idPaqueteSeguro;
            }
            else
            {
                cboPaqueteSeguro1.AgregarNinguno();
                cboPaqueteSeguro1.SelectedValue = -1;
            }
        }
        private void CrearCopiaDePaqueteSeguro()
        {
            listDetIntgGrupoSol_copia = new List<clsSolCreIntegranteGrupoSol>();
            foreach (var item in listDetIntgGrupoSol)
            {
                clsSolCreIntegranteGrupoSol nuevoItem = new clsSolCreIntegranteGrupoSol()
                {
                    idSolicitud = item.idSolicitud,
                    idPaqueteSeguro = item.idPaqueteSeguro,
                };
                listDetIntgGrupoSol_copia.Add(nuevoItem);
            }
        }

        private void cboPaqueteSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cambiarValorComboSeguro)
            {
                // No se hace nada si el cambio es provocado por el código
                return;
            }

            clsSolCreIntegranteGrupoSol oSel = (clsSolCreIntegranteGrupoSol)dtgIntegrantesGrupoSol.SelectedRows[0].DataBoundItem;
            var index = listDetIntgGrupoSol.FindIndex(x => x.idSolicitud == oSel.idSolicitud);
            var item = listDetIntgGrupoSol[index];
            item.idPaqueteSeguro = Convert.ToInt16(cboPaqueteSeguro1.SelectedValue);
            listDetIntgGrupoSol[index] = item;

            if (!ValidarDesactivacionPaquetesSeguros(oSel, Convert.ToInt32(cboPaqueteSeguro1.SelectedValue)))
            {
                cambiarValorComboSeguro = true;
                cboPaqueteSeguro1.SelectedValue = listDetIntgGrupoSol_copia[index].idPaqueteSeguro;
                cambiarValorComboSeguro = false;
                return;
            }

            if (!ValidarReactivacionPaquetesSeguros(oSel))
                return;

            MessageBox.Show("Vuelva a PROCESAR para actualizar el plan de pagos.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGrabar1.Enabled = false;

        }

        private bool ValidarDesactivacionPaquetesSeguros(clsSolCreIntegranteGrupoSol oSel, int cboSeguro)
        {
            clsCNPaqueteSeguro objPaqueteSeguroCN = new clsCNPaqueteSeguro();

            foreach (var item in listDetIntgGrupoSol)
            {
                if (item.idCli != oSel.idCli)
                    continue;

                DataTable resp = objPaqueteSeguroCN.CNObtenerPromotorInicialSeguroOptativo(item.idSolicitud, item.idPaqueteSeguro);
                int idUsuarioOriginal = resp.Rows.Count == 0 ? 0 : Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);
                DataTable verificacion = objPaqueteSeguroCN.CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(item.idSolicitud);

                if (verificacion.Rows.Count > 0)
                {
                    int idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);

                    if (idEstadoSolicitud == 1) //SOLICITADO
                    {
                        MessageBox.Show("Existe una solicitud pendiente de aprobación. No puede proceder", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

                foreach (var x in lstPaqueteSeguros)
                {
                    if (x.idTipoSeguro == item.idPaqueteSeguro)
                    {
                        item.idPaqueteSeguro = x.idPaqueteSeguro;
                        break;
                    }
                }

                if (idUsuarioOriginal != clsVarGlobal.PerfilUsu.idUsuario)      //Adquirido por otro usuario
                {
                    DialogResult drResultadoPaquete = MessageBox.Show(clsVarApl.dicVarGen["cAlertaPlanesDeSeguro"], cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResultadoPaquete == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void EnviarCorreoPorDesactivacionPaqueteSeguro(List<clsDesactivacionPaqueteSeguro> desactivacionPaqueteSeguro)
        {
            List<string> cEmailDestino = new List<string>();
            List<string> cc = new List<string>();
            string cAsunto = "Notificacion por desactivacion de plan seguro";
            string cCuerpoMensaje = "Se notifica el cambio en los planes de seguro vendido con el siguiente detalle: <br><br>";
            cEmailDestino.Add("gustavofernandezsaavedra@gmail.com");
            cc.Add("soygustavofernandez@gmail.com");

            foreach (var item in desactivacionPaqueteSeguro)
            {
                item.cPaqueteSeguroActual = "PlanSeguroActual:"+item.idPaqueteSeguroActual;
                item.cPaqueteSeguroOriginal = "PlanSeguroOriginal:"+item.idPaqueteSeguroOriginal;
                // TODO: usar el SP que ha creado Gustavo CRE_ObtenerListaPaquetesDeSeguro

                cCuerpoMensaje += "<b>Solicitud: " + item.idSolicitud+"</b><br>";
                cCuerpoMensaje += "Nombre: " + item.cNombreCompleto+"<br>";
                cCuerpoMensaje += "Documento: " +item.cDocumentoID+"<br>";
                cCuerpoMensaje += "Plan seguro original: " + item.cPaqueteSeguroOriginal+"<br>";
                cCuerpoMensaje += "Plan seguro actual: " + item.cPaqueteSeguroActual+"<br>";
                cCuerpoMensaje += "<br><br>";
            }

            clsCNServicioCorreo cnCorreo = new clsCNServicioCorreo();
            var rpta = cnCorreo.enviarMensaje(cEmailDestino, cAsunto, cCuerpoMensaje, cc);
            if (!rpta)
            {
                MessageBox.Show("Ocurrió un error al enviar el correo.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool NotificarPorSMSPaqueteSeguro()
        {
            if (listDetIntgGrupoSol.All(x => x.idPaqueteSeguro == -1))
                return true;

            var listaPaquetesSeleccionados = listDetIntgGrupoSol.Where(x => x.idPaqueteSeguro != -1).ToList();

            clsCNPaqueteSeguro cnPaqueteSeguro = new clsCNPaqueteSeguro();
            clsCNCliente cnCliente = new clsCNCliente();
            clsServicioSMS cnServicioSMS = new clsServicioSMS();
            var listaPaquetesSeguro = cnPaqueteSeguro.CNListarTodosLosPaqueteDeSeguro();
            var clsListaPaquetesSeguro = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(listaPaquetesSeguro) as List<clsMantenimientoPaqueteSeguro>;

            var listaTelefonos = new List<clsRegistroTelefono>();

            foreach (var item in listaPaquetesSeleccionados)
            {
                var dtTelefonos = (DataTableToList.ConvertTo<clsRegistroTelefono>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(item.idCli)) as List<clsRegistroTelefono>).FirstOrDefault();
                if (dtTelefonos == null || string.IsNullOrEmpty(dtTelefonos.cNumeroTelefonico))
                {
                    MessageBox.Show("El cliente " + item.cNombre + " no tiene registrado su número de teléfono. No se puede enviar el mensaje de texto. Actualice y vuelva a intentar", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                listaTelefonos.Add(dtTelefonos);
            }

            foreach (var item in listaPaquetesSeleccionados)
            {
                clsMantenimientoPaqueteSeguro objpaquete = clsListaPaquetesSeguro.Where(x => x.idPaqueteSeguro == item.idPaqueteSeguro).FirstOrDefault();
                string cTelefono = listaTelefonos.Where(x => x.idCli == item.idCli).FirstOrDefault().cNumeroTelefonico;
                clsSmsRequest requestSMS = new clsSmsRequest
                {
                    phone = cTelefono,
                    content = "Caja Los Andes informa que se ha adquirido el plan de seguro " + objpaquete.cNombreCompleto + " en etapa de plan de pagos, el cual podrá consultar en el siguiente enlace: " + objpaquete.cLink

                };
                clsSmsResponse responseSMS = cnServicioSMS.EnviarSMS(requestSMS);
                cnServicioSMS.GuardarTramaSMS(requestSMS, responseSMS, item.idCli);
            }

            MessageBox.Show("Se ha enviado los SMS a los clientes con algún plan de seguro seleccionado", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public bool ValidarReactivacionPaquetesSeguros(clsSolCreIntegranteGrupoSol oSel)
        {
            bool rpta = true;
            foreach (var item in listDetIntgGrupoSol)
            {
                if (item.idCli != oSel.idCli)
                    continue;

                int idSolicitud = item.idSolicitud;
                int idUsuario = clsVarGlobal.User.idUsuario;
                int idAgencia = clsVarGlobal.nIdAgencia;
                int idPaqueteSeguro = item.idPaqueteSeguro;

                // Solo lo ha desactivado
                if (idPaqueteSeguro == -1)
                    continue;
                    //TODO: Gustavo VALIDAR
                clsDBResp dbResp = cnPaqueteSeguro.CNVerificarSituacionSeguroOpcional(idSolicitud, idUsuario, idAgencia, idPaqueteSeguro, item.idFrmPaqueteSeguro);

                // No tenia nada
                if (dbResp.nMsje == -1)
                    continue;

                // Registra solicitud
                if (dbResp.nMsje == 0)
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rpta = true && rpta;
                    var index = listDetIntgGrupoSol.FindIndex(x => x.idSolicitud == oSel.idSolicitud);
                    listDetIntgGrupoSol_copia[index].idPaqueteSeguro = idPaqueteSeguro;
                    break;
                }

                // 1:Rechazo automatico, 3:rechazo por aprobador
                if (dbResp.nMsje.In(1, 3))
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rpta = false && rpta;
                }

                // Otra solicitud de otro usuario
                if (dbResp.nMsje == 2)
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rpta = false && rpta;
                    continue;
                }

                // Solicitud pendiente
                if (dbResp.nMsje == 4)
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rpta = false && rpta;
                    break;
                }

                // Cuando lo rechazaron automaticamente o por aprobador
                var pregunta = MessageBox.Show("¿Desea registrar otra solicitud?", cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.Yes)
                {
                    //TODO: Gustavo VALIDAR
                    dbResp = cnPaqueteSeguro.CNSolicitarReactivacionSeguroOpcional(idSolicitud, idUsuario, idAgencia, 0, 0);
                    if (dbResp.nMsje == 0)
                    {
                        MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rpta = false && rpta;
                        continue;
                    }
                    if (dbResp.nMsje == 1)
                    {
                        var index = listDetIntgGrupoSol.FindIndex(x => x.idSolicitud == oSel.idSolicitud);
                        listDetIntgGrupoSol_copia[index].idPaqueteSeguro = idPaqueteSeguro;
                        MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rpta = false && rpta;
                    }
                }
            }
            return rpta;
        }
    }
}
