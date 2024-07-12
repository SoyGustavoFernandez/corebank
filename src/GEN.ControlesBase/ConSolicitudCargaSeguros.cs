using CLI.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ADM.CapaNegocio;
using Microsoft.VisualBasic;

namespace GEN.ControlesBase
{
    public partial class ConSolicitudCargaSeguros : UserControl
    {
        #region Variables

        // Declaro eventos personalizados que se activarán cuando se presione btnSalir y btnAceptar
        public event EventHandler SalirClicked;
        public event EventHandler AceptarClicked;

        public event EventHandler BotonCerrarClick;
        public event EventHandler SeleccionarSeguro;
        public bool lformulario;
        public clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro { get; set; }
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro { get; set; }
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro { get; set; }
        private BindingSource bsSolicitudCreditoCargaSeguro { get; set; }
        private int idSolicitud { get; set; }
        private DataTable dtDatosZonaUsuario { get; set; }
        private clsFunUtiles objFunUtiles { get; set; }
        private List<int> lstOperacionExcluidas { get; set; }
        private clsCNPlanPago objCNPlanPagos { get; set; }
        public bool lValidoSeguros = false;
        public bool lCerrar = false;
        private int nParam_;
        private DataTable dtPlanPagoSeguros;
        private int idTipoPlanVidaSeleccionado;
        private clsCNSeguros clsSeguros = new clsCNSeguros();

        #region SeguroOncologico
        private clsCNConfigurarSeguroOptativo clsMantenimientoSeguros = new clsCNConfigurarSeguroOptativo();
        private int idTipoPlanOncologicoSeleccionado;
        private int idTipoVida;
        private int idTipoOncologico;
        private int idTipoVidaInicial;
        private int idTipoOncologicoInicial;
        DataTable dtSustento = new DataTable();
        List<clsSegurosNoPermitidos> objSegurosNoPermitidos = new List<clsSegurosNoPermitidos>();
        List<clsSegurosDesmarcados> lstSegurosDesmarcados = new List<clsSegurosDesmarcados>();
        private string cTituloForm = "Carga de Seguros";
        #endregion

        #region PlanesDeSeguro
        private int idPlanOriginal;
        private int idFrmOriginal;
        private bool linvocadoDesdeSimulador;
        private bool lSimuladorConDesgravamen = true;
        private List<clsMantenimientoPaqueteSeguro> lstPaqueteSegurosTmp = new List<clsMantenimientoPaqueteSeguro>();
        private List<clsMantenimientoPaqueteSeguro> lstPaqueteSegurosPrima = new List<clsMantenimientoPaqueteSeguro>();
        private clsCNPaqueteSeguro objPaqueteSeguroCN = new clsCNPaqueteSeguro();
        public clsClienteRegistros lstTelefonos = new clsClienteRegistros();
        #endregion

        #endregion

        public ConSolicitudCargaSeguros()
        {
            InitializeComponent();
        }

        public void InicializaControl1(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro, int _idTipoVida, int _idTipoOncologico)
        {
            idPlanOriginal = _objSolicitudCreditoCargaSeguro.idPaqueteSeguro;
            idFrmOriginal = _objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;
            objSolicitudCreditoCargaSeguro = _objSolicitudCreditoCargaSeguro;
            idTipoVida = _idTipoVida;
            idTipoOncologico = _idTipoOncologico;
            lformulario = true;
            cargarComponentes(_objSolicitudCreditoCargaSeguro);
        }

        public void InicializaControl2(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro, int nParam, bool lformulario, int _idTipoVida, int _idTipoOncologico)
        {
            idPlanOriginal = _objSolicitudCreditoCargaSeguro.idPaqueteSeguro;
            idFrmOriginal = _objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;
            objSolicitudCreditoCargaSeguro = _objSolicitudCreditoCargaSeguro;
            idTipoVida = _idTipoVida;
            idTipoOncologico = _idTipoOncologico;

            if (!lformulario)
            {
                this.btnAceptar.Visible = false;
                this.btnSalir.Visible = false;
            }
            else
            {
                this.btnAceptar.Visible = true;
                this.btnSalir.Visible = true;
            }

            this.lformulario = lformulario;

            nParam_ = nParam;
            cargarComponentes(_objSolicitudCreditoCargaSeguro);
        }


        public void InicializaControl3(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro, bool lformulario, int _idTipoVida, int _idTipoOncologico, bool _linvocadoDesdeSimulador = false, bool _ldesgravamenSimulador = false)
        {
            idPlanOriginal = _objSolicitudCreditoCargaSeguro.idPaqueteSeguro;
            idFrmOriginal = _objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;
            objSolicitudCreditoCargaSeguro = _objSolicitudCreditoCargaSeguro;
            idTipoVida = _idTipoVida;
            idTipoOncologico = _idTipoOncologico;
            lSimuladorConDesgravamen = _ldesgravamenSimulador;
            linvocadoDesdeSimulador = _linvocadoDesdeSimulador;

            if (!lformulario)
            {
                this.btnAceptar.Visible = false;
                this.btnSalir.Visible = false;
            }
            else
            {
                this.btnAceptar.Visible = true;
                this.btnSalir.Visible = true;
            }

            this.lformulario = lformulario;

            cargarComponentes(_objSolicitudCreditoCargaSeguro);
        }


        public bool ConSolicitudCargaSeguros_ValidaSeguros()
        {
            btnAceptar_Click(null, null);
            return this.lValidoSeguros;
        }

        #region Enumeradores

        private enum AccionFormulario
        {
            DEFECTO = 0,
            ACEPTA_SEGURO = 1,
            RECHAZA_SEGURO = 2
        }

        #endregion

        #region Propiedades

        public bool RechazaListaSeguro
        {
            get { return this.rbtRechazaListaSeguro.Checked; }
            set { this.rbtRechazaListaSeguro.Checked = value; }
        }

        public BindingSource bsCargaSeguros
        {
            get { return bsSolicitudCreditoCargaSeguro; }
        }

        #endregion

        #region Metodos Publicos

        public clsSolicitudCreditoCargaSeguro ObtenerSolicitudCreditoCargaSeguro()
        {
            objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = rbtAceptaListaSeguro.Checked;
            objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital = rbtAceptaInclusionCapital.Checked;
            objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro = (objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro == 0) ? objSolicitudCreditoCargaSeguro.nMontoSolicitado : objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
            objSolicitudCreditoCargaSeguro.nMontoPrimaTotal = lstSolicitudCreditoSeguro.Where(item => item.lSeleccionado && (item.idTipoSeguro == idTipoVida || item.idTipoSeguro == idTipoOncologico)).Sum(item => item.nMontoPrima);
            objSolicitudCreditoCargaSeguro.nPlazoCoberturaSeguro = (objSolicitudCreditoCargaSeguro.idTipoPlazo == 1) ? objSolicitudCreditoCargaSeguro.nCuotas : objSolicitudCreditoCargaSeguro.nCuotas * objSolicitudCreditoCargaSeguro.nPlazo / 30;
            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = lstSolicitudCreditoSeguro;
            objSolicitudCreditoCargaSeguro.nEstado = 1;
            if (objSolicitudCreditoCargaSeguro.nEsSimulador == 1)
                lstSolicitudCreditoSeguro.ForEach(e =>
                {
                    e.lVigente = true;
                });
            return objSolicitudCreditoCargaSeguro;
        }

        public void ActualizarParametroAprobado()
        {
            #region SeguroOncologico
            if (objSolicitudCreditoCargaSeguro.lEsPlanPagos || objSolicitudCreditoCargaSeguro.lEsDesembolso)
            {
                if (!ValidarCambioPrimaSeguro(false))
                    return;
            }
            #endregion
            clsCNBuscaSolicitud objCNBuscaSolicitud = new clsCNBuscaSolicitud();
            clsSolicitudCreditoCargaSeguro objSolicitudSeguroValidacion = new clsSolicitudCreditoCargaSeguro();
            DataTable dtSolcitud = new DataTable();

            decimal nMontoAprobado = Decimal.Zero;
            decimal nMontoSolicitado = Decimal.Zero;
            int nCuotas = 0;
            int idTipoPlazo = 0;
            int nPlazoCuotaSolicitado = 0;
            int nPlazoCuotaAprobado = 0;
            DateTime dFechaDesembolso = clsVarGlobal.dFecSystem;
            decimal nMontoCoberturaSeguro = Decimal.Zero;
            decimal nMontoAmpliado = Decimal.Zero;

            if (idSolicitud != 0)
            {
                dtSolcitud = objCNBuscaSolicitud.DatoSolicitud(idSolicitud);
                nMontoAprobado = Convert.ToDecimal(dtSolcitud.Rows[0]["nCapitalAprobado"]);
                nMontoSolicitado = Convert.ToDecimal(dtSolcitud.Rows[0]["nCapitalSolicitado"]);
                nMontoCoberturaSeguro = Convert.ToDecimal(dtSolcitud.Rows[0]["nCapitalAprobado"]);
                idTipoPlazo = Convert.ToInt32(dtSolcitud.Rows[0]["idTipoPeriodo"]);
                nPlazoCuotaSolicitado = Convert.ToInt32(dtSolcitud.Rows[0]["nPlazoCuota"]);
                nPlazoCuotaAprobado = Convert.ToInt32(dtSolcitud.Rows[0]["nPlazoCuotaAprobado"]);
                nCuotas = Convert.ToInt32(dtSolcitud.Rows[0]["nCuotas"]);
                dFechaDesembolso = Convert.ToDateTime(dtSolcitud.Rows[0]["dFechaDesembolsoSugerido"]);
                nMontoAmpliado = Convert.ToDecimal(dtSolcitud.Rows[0]["nMontoAmpliado"]);


                if (Convert.ToInt32(dtSolcitud.Rows[0]["idEstado"]) == 2)
                {
                    objSolicitudSeguroValidacion = objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud);
                    if (objSolicitudSeguroValidacion.lParametrosActualizado)
                    {
                        objSolicitudSeguroValidacion.nMontoCoberturaSeguro = nMontoAprobado;
                        objSolicitudSeguroValidacion.nMontoSolicitado = nMontoCoberturaSeguro;
                        objSolicitudSeguroValidacion.nMontoAmpliado = nMontoAmpliado;
                        objSolicitudSeguroValidacion.dFechaDesembolso = dFechaDesembolso;
                        objSolicitudSeguroValidacion.nCuotas = nCuotas;
                        objSolicitudSeguroValidacion.nPlazo = nPlazoCuotaAprobado;
                        objSolicitudSeguroValidacion.idTipoPlazo = idTipoPlazo;
                        objSolicitudSeguroValidacion.nPlazoCoberturaSeguro = (objSolicitudSeguroValidacion.idTipoPlazo == 1) ? objSolicitudSeguroValidacion.nCuotas : objSolicitudSeguroValidacion.nCuotas * objSolicitudSeguroValidacion.nPlazo / 30;

                        int idUsuarioZona = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idZona"]);
                        int idUsuarioAgencia = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idAgencia"]);

                        objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro = (objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro.Count > 0) ? objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro : objCNCreditoCargaSeguro.CNObtenerSolicitudSeguroTipo(objSolicitudSeguroValidacion.idSolicitud);
                        decimal nMontoFavorClientePrima = 0;

                        int nNumeroDiasCredito = new clsCNSolicitud().ObtieneTotalDias(objSolicitudSeguroValidacion.dFechaDesembolso, objSolicitudSeguroValidacion.nCuotas, objSolicitudSeguroValidacion.nDiasGracia, objSolicitudSeguroValidacion.idTipoPlazo, objSolicitudSeguroValidacion.nPlazo);
                        DateTime dFechaPrimeraCuota = (objSolicitudSeguroValidacion.idTipoPlazo == 1) ? objSolicitudSeguroValidacion.dFechaDesembolso.AddMonths(1).AddDays(objSolicitudSeguroValidacion.nDiasGracia) : objSolicitudSeguroValidacion.dFechaDesembolso.AddDays(objSolicitudSeguroValidacion.nPlazo + objSolicitudSeguroValidacion.nDiasGracia);
                        DataTable dtPlanPagosTemporal = (objSolicitudSeguroValidacion.idTipoPlazo == 3 && objSolicitudCreditoCargaSeguro.idEstadoSolicitud.In(2, 5)) ?
                            objCNPlanPagos.CalcularCuotasLibresEvalRural(objSolicitudSeguroValidacion.nCuotas, objSolicitudSeguroValidacion.nMontoSolicitado, objSolicitudSeguroValidacion.dFechaDesembolso, objSolicitudSeguroValidacion.idSolicitud, 0, objSolicitudSeguroValidacion.dFechaDesembolso, new DataTable()) :
                            objCNPlanPagos.CalculaPpgCuotasConstantes2(objSolicitudSeguroValidacion.nMontoSolicitado, 0, objSolicitudSeguroValidacion.dFechaDesembolso, objSolicitudSeguroValidacion.nCuotas, objSolicitudSeguroValidacion.nDiasGracia, (short)objSolicitudSeguroValidacion.idTipoPlazo, objSolicitudSeguroValidacion.nPlazo, 0, new DataTable(), 1, new DataTable(), dFechaPrimeraCuota, 0, 0, objSolicitudSeguroValidacion.nCuotaGracia, true);
                        DateTime dFechaFinSeguro = dtPlanPagosTemporal.AsEnumerable().OrderByDescending(item => item["cuota"]).First().Field<DateTime>("fecha");

                        int nTotalDiasCalendario = (objSolicitudSeguroValidacion.idEstadoSolicitud == 2) ? (dFechaFinSeguro - objSolicitudSeguroValidacion.dFechaDesembolso).Days : dtPlanPagosTemporal.AsEnumerable().Sum(item => Convert.ToInt32(item["dias"]));

                        if (dFechaFinSeguro != objSolicitudSeguroValidacion.dFechaCancelacion)
                        {
                            dFechaFinSeguro = objSolicitudSeguroValidacion.dFechaCancelacion = (objSolicitudSeguroValidacion.lPlanPagosGenerado) ? objSolicitudSeguroValidacion.dFechaCancelacion : dFechaFinSeguro;
                            nTotalDiasCalendario = (objSolicitudSeguroValidacion.dFechaCancelacion - objSolicitudSeguroValidacion.dFechaDesembolso).Days;
                        }
                        int nCuotasMinimo = (objSolicitudSeguroValidacion.idTipoPlazo == 1) ? objSolicitudSeguroValidacion.nCuotas : (objSolicitudSeguroValidacion.nPlazo * objSolicitudSeguroValidacion.nCuotas) / 30;

                        objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro = objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro.Select(item =>
                        {
                            item.nMontoCobertura = (objSolicitudSeguroValidacion.nMontoCoberturaSeguro != 0) ? objSolicitudSeguroValidacion.nMontoCoberturaSeguro : objSolicitudSeguroValidacion.nMontoSolicitado;
                            item.dFechaInicioVigencia = objSolicitudSeguroValidacion.dFechaDesembolso;
                            item.dFechaFinVigencia = dFechaFinSeguro;
                            if (item.idTipoSeguro != 2)
                            {
                                item.nPlazoCobertura = (nTotalDiasCalendario / 30 < nCuotasMinimo) ? nCuotasMinimo : nTotalDiasCalendario / 30;
                            }
                            if (item.idTipoSeguro == 1)
                            {
                                item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                                item.nValorCobertura = item.nValor;
                                decimal nTotalPrima = ObtenerTotalPrimaMultiRiesgo(item.nValor, dtPlanPagosTemporal, objSolicitudCreditoCargaSeguro, item.nMontoCobertura, objSolicitudCreditoCargaSeguro.lCuotasConstantes);
                                item.nMontoPrima = nTotalPrima;
                            }
                            else if (item.idTipoSeguro == idTipoVida && item.lSeleccionado && item.lVigente)
                            {
                                decimal nMontoPrimaSeguro = 0;
                                var plazoSeleccionado = cboSeguroVida.SelectedValue;
                                dtPlanPagoSeguros = clsSeguros.obtenerPrecioPlanSeguro(plazoSeleccionado == null ? 0 : (int)plazoSeleccionado, 0);

                                if (Convert.ToInt32(cboSeguroVida.SelectedValue) == 0)
                                {
                                    item.nPlazoCobertura = item.nPlazoCobertura;
                                    item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                                    item.nValorCobertura = item.nValor;
                                    nMontoPrimaSeguro = item.nMontoPrima;
                                }
                                else
                                {
                                    /*Para seguro vida, actualizar el plazo y prima*/
                                    if (dtPlanPagoSeguros.Rows.Count > 0)
                                    {
                                        item.nPlazoCobertura = Convert.ToInt32(dtPlanPagoSeguros.Rows[0]["nMeses"]);
                                        item.nValor = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioMensual"]);
                                        item.nValorCobertura = item.nValor;
                                        nMontoPrimaSeguro = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioTotal"]);
                                    }
                                }
                                if (Convert.ToInt32(cboSeguroVida.SelectedValue) != 0) { item.lSeleccionado = true; }
                                item.nMontoPrima = nMontoPrimaSeguro;
                                item.dFechaFinVigencia = item.dFechaInicioVigencia.AddMonths(item.nPlazoCobertura);
                            }
                            else if (item.idTipoSeguro == 3)
                            {
                                item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                                item.nValorCobertura = item.nValor;
                                item.nMontoPrima = objFunUtiles.redondearBCR(objFunUtiles.truncarNumero(item.nMontoCobertura * item.nValor, 2), ref nMontoFavorClientePrima, objSolicitudSeguroValidacion.idMoneda, true, true);
                            }
                            #region PlanesDeSeguro
                            else if (lstPaqueteSegurosPrima.Any(x => x.idTipoSeguro == item.idTipoSeguro))
                            {
                                item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                                item.nValorCobertura = item.nValor;
                                decimal nTotalPrima = ObtenerTotalPrimaPaquetes(item.nValor, dtPlanPagosTemporal, dFechaPrimeraCuota, objSolicitudCreditoCargaSeguro.dFechaDesembolso, objSolicitudCreditoCargaSeguro.idTipoPlazo, objSolicitudCreditoCargaSeguro.lCuotasConstantes);
                                item.nMontoPrima = nTotalPrima;
                            }
                            #endregion
                            #region SeguroOncologico
                            else if (item.idTipoSeguro == idTipoOncologico && item.lSeleccionado && item.lVigente)
                            {
                                decimal nMontoPrimaSeguro = 0;
                                var plazoSeleccionado = cboSeguroOncologico.SelectedValue;
                                dtPlanPagoSeguros = clsSeguros.obtenerPrecioPlanSeguro(plazoSeleccionado == null ? 0 : (int)plazoSeleccionado, 0);

                                if (Convert.ToInt32(cboSeguroOncologico.SelectedValue) == 0)
                                {
                                    item.nPlazoCobertura = item.nPlazoCobertura;
                                    item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                                    item.nValorCobertura = item.nValor;
                                    nMontoPrimaSeguro = item.nMontoPrima;
                                }
                                else
                                {
                                    if (dtPlanPagoSeguros.Rows.Count > 0)
                                    {
                                        item.nPlazoCobertura = Convert.ToInt32(dtPlanPagoSeguros.Rows[0]["nMeses"]);
                                        item.nValor = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioMensual"]);
                                        item.nValorCobertura = item.nValor;
                                        nMontoPrimaSeguro = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioTotal"]);
                                    }
                                }
                                if (Convert.ToInt32(cboSeguroOncologico.SelectedValue) != 0) { item.lSeleccionado = true; }
                                item.nMontoPrima = nMontoPrimaSeguro;
                                item.dFechaFinVigencia = item.dFechaInicioVigencia.AddMonths(item.nPlazoCobertura);
                            }
                            #endregion
                            item.idUsuario = (item.idUsuario == 0) ? clsVarGlobal.User.idUsuario : item.idUsuario;
                            item.idAgencia = (item.idAgencia == 0) ? idUsuarioAgencia : item.idAgencia;
                            item.idZona = (item.idZona == 0) ? idUsuarioZona : item.idZona;
                            item.idMoneda = (item.idMoneda == 0) ? objSolicitudSeguroValidacion.idMoneda : item.idMoneda;
                            item.idCargo = (item.idCargo == 0) ? clsVarGlobal.User.idCargo : item.idCargo;
                            item.idCanalRegistro = (item.idCanalRegistro == 0) ? clsVarGlobal.idCanal : item.idCanalRegistro;
                            return item;
                        }).ToList();

                        objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro = filtrarTipoSeguro(objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro);

                        objSolicitudSeguroValidacion.nMontoPrimaTotal = objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro.Where(item => item.lSeleccionado).Sum(item => item.nMontoPrima);
                        objSolicitudSeguroValidacion.nPlazoCoberturaSeguro = (objSolicitudSeguroValidacion.idTipoPlazo == 1) ? objSolicitudSeguroValidacion.nCuotas : objSolicitudSeguroValidacion.nCuotas * objSolicitudSeguroValidacion.nPlazo / 30;

                        if ((objSolicitudSeguroValidacion.lAceptacionListaSeguro) || objSolicitudSeguroValidacion.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
                        {
                            string xmlSolicitudCreditoSeguro = objSolicitudSeguroValidacion.GetXml();

                            DataTable dtResultadoSeguro = new clsCNCreditoCargaSeguro().CNRegistrarSolicitudCreditoSeguro(idSolicitud, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                            if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 0 || Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == -1)
                            {
                                MessageBox.Show("Los datos de los seguros no se pudieron actualizar a las condiciones del crédito.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 1)
                            {
                                MessageBox.Show("Los datos de los seguros fueron actualizados correctamente.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public void EnvioDatos()
        {
            objSolicitudCreditoCargaSeguro = ObtenerSolicitudCreditoCargaSeguro();
            this.lCerrar = true;
            this.Dispose();
        }

        #region SegurosOncologicos

        public void cargaInicialOncologico(string mensajeSeguros)
        {
            grbInclusionSeguroCapital.Text = mensajeSeguros;
        }

        public void ValidarSegurosQueNoSePuedenMarcar()
        {
            List<clsSegurosDesmarcados> lstBloquearMarcados = new List<clsSegurosDesmarcados>();
            //Busca los seguros que no se pueden marcar en la lista lstSegurosDesmarcados
            foreach (var item in lstSegurosDesmarcados)
            {
                if (item.idSolicitud == objSolicitudCreditoCargaSeguro.idSolicitud)
                {
                    //Validar que sea uno de los seguros no permitidos
                    if (objSegurosNoPermitidos.Any(x => x.idTipoSeguro == item.idTipoSeguro))
                    {
                        lstBloquearMarcados.Add(item);
                    }
                }
            }

            foreach (var item in lstBloquearMarcados)
            {
                foreach (DataGridViewRow row in dtgCargaSeguros.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idTipoSeguro"].Value) == item.idTipoSeguro)
                    {
                        Color colorPintado = Color.FromName(clsVarApl.dicVarGen["cColorSeguroDesactivado"]);
                        string textoPintado = clsVarApl.dicVarGen["cMensajeSeguroDesactivado"];

                        row.Cells["lSeleccionado"].ReadOnly = true;
                        row.DefaultCellStyle.BackColor = colorPintado;
                        row.Cells["lSeleccionado"].ToolTipText = textoPintado;

                        if (item.idTipoSeguro == idTipoVida)
                            cboSeguroVida.Enabled = false;

                        if (item.idTipoSeguro == idTipoOncologico)
                            cboSeguroOncologico.Enabled = false;

                        pbDesmarcado.BackColor = colorPintado;
                        lblDesmarcado.Text = textoPintado;
                    }
                }
            }
        }

        public void ValidarSeguroActivo()
        {
            if (lstSolicitudCreditoSeguro != null && lstSolicitudCreditoSeguro.Any(x => x.idTipoSeguro == idTipoOncologico))
            {
                cboSeguroOncologico.Visible = true;
                lblBase1.Visible = true;
                cargaInicialOncologico(clsVarApl.dicVarGen["cMensajeSeguros"]);
            }
            else
            {
                cboSeguroOncologico.Visible = false;
                lblBase1.Visible = false;
                grbInclusionSeguroCapital.Text = "¿El cliente desea incluir el monto de seguro en el crédito solicitado?, “Aplica para seguro Vida”";
            }
        }
        #endregion

        #endregion

        #region Metodos Privados

        private bool validaSeguros()
        {
            int nNumeroSeguroSeleccionado = lstSolicitudCreditoSeguro.Count(item => item.lSeleccionado == true);
            if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro && nNumeroSeguroSeleccionado == 0)
            {
                MessageBox.Show("No ha seleccionado un seguro de la lista.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidoSeguros = false;
                return false;
            }

            if (!ValidarSegurosOpcionales())
            {
                lValidoSeguros = false;
                return lValidoSeguros;
            }

            if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
            {
                var cTipoSeguros = XElement.Parse(objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Where(item => item.lSeleccionado == true).ToList().GetXml());
                DataTable dtResultado;
                if (cTipoSeguros.Descendants("idTipoSeguro").Count() > 0)
                {
                    if (lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoVida).lSeleccionado)
                    {
                        #region SeguroVida
                        dtResultado = objCNCreditoCargaSeguro.CNValidarSeguros(objSolicitudCreditoCargaSeguro.idCli, cTipoSeguros.Descendants("idTipoSeguro").ToList().GetXml(), objSolicitudCreditoCargaSeguro.nPlazoCoberturaSeguro, objSolicitudCreditoCargaSeguro.idOperacion);

                        if (dtResultado.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                            {
                                MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lValidoSeguros = false;
                                return false;
                            }
                        }
                        #endregion
                    }
                }

                var seguroOncologicoExiste = lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoOncologico);

                if (seguroOncologicoExiste != null && seguroOncologicoExiste.lSeleccionado)
                {
                    #region SeguroOncologico
                    dtResultado = objCNCreditoCargaSeguro.CNValidarSeguroOncologico(objSolicitudCreditoCargaSeguro.idCli, objSolicitudCreditoCargaSeguro.nPlazoCoberturaSeguro, objSolicitudCreditoCargaSeguro.idSolicitud);
                    if (dtResultado.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lValidoSeguros = false;
                            return false;
                        }
                    }
                    #endregion
                }
            }

            if (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idTipoSeguro == idTipoVida && item.nMontoPrima == 0 && rbtAceptaListaSeguro.Checked == true && item.lSeleccionado == true))
            {
                MessageBox.Show("Debe seleccionar un plan de Seguro Vida", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidoSeguros = false;
                return false;
            }
            else if (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idTipoSeguro == idTipoOncologico && item.nMontoPrima == 0 && rbtAceptaListaSeguro.Checked == true && item.lSeleccionado == true))
            {
                MessageBox.Show("Debe seleccionar un plan de Seguro Oncológico", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidoSeguros = false;
                return false;
            }

            lValidoSeguros = true;
            return true;
        }

        private bool ValidarSegurosOpcionales()
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            if (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado) //1	SEGURO MULTIRIESGO
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                {
                    MessageBox.Show("El seguro multiriesgo solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Ir al tab 2
                    return false;
                }

                //VERIFICAR QUE NO EXCEDA DE LOS 100,000.00
                if (Convert.ToDecimal(objSolicitudCreditoCargaSeguro.nMontoSolicitado) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo supera los " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //VERIFICAR QUE SE CUMPLA EL MONTO MINIMO
                if (Convert.ToDecimal(objSolicitudCreditoCargaSeguro.nMontoSolicitado) < Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo para aplicar multiriesgo debe ser mayor o igual a " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado = false;
                    return false;
                }
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                {
                    //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                    if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                    {
                        //VERIFICAR SI TIENE OTRO SEGURO MULTIRIESGO
                        DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && fila.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"]) //FILTRANDO MULTIRIESGO
                                      select fila).FirstOrDefault();
                        if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    //VERIFICAR QUE EN LOS DATOS DE DIRECCION PRINCIPAL, EL CLIENTE TENGA LOS CINCO CAMPOS AGREGADOS EN ESTE REQUERIMIENTO
                    DataTable tbDirCli = new clsCNDirecCli().ListaDirCli(objSolicitudCreditoCargaSeguro.idCli);
                    DataRow ieRegistro = (from fila in tbDirCli.AsEnumerable()
                                          where fila.Field<bool>("lDirPrincipal") == true
                                          select fila).FirstOrDefault();
                    if (ieRegistro == null)
                    {
                        MessageBox.Show("No tiene registrado una dirección. No puedes seleccionar este seguro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        bool tieneCamposInvalidos = tbDirCli.AsEnumerable().Any(row =>
                        {
                            int nAñoConstruccion = Convert.ToInt32(string.IsNullOrEmpty(row["nAñoConstruccion"].ToString()) ? 0 : row["nAñoConstruccion"]);
                            int nPisos = Convert.ToInt32(string.IsNullOrEmpty(row["nPisos"].ToString()) ? 0 : row["nPisos"]);
                            string nSotanos = row["nSotanos"].ToString();
                            int nIdTipoEstructura = Convert.ToInt32(string.IsNullOrEmpty(row["nIdTipoEstructura"].ToString()) ? 0 : row["nIdTipoEstructura"]);
                            int nIdUsoDelPredio = Convert.ToInt32(string.IsNullOrEmpty(row["nIdUsoDelPredio"].ToString()) ? 0 : row["nIdUsoDelPredio"]);

                            return nAñoConstruccion == 0 || nAñoConstruccion < Convert.ToInt32(clsVarApl.dicVarGen["nAnioMinimoConstruccion"]) || nPisos == 0 || string.IsNullOrEmpty(nSotanos) || nIdTipoEstructura == 0 || nIdUsoDelPredio == 0;
                        });
                        if (tieneCamposInvalidos)
                        {
                            MessageBox.Show("Primero actualiza la dirección y completa los datos exigidos para el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            #region PlanesDeSeguro
            else if (lstPaqueteSeguros.Select(p => p.idPaqueteSeguro).ToList().Contains(objSolicitudCreditoCargaSeguro.idPaqueteSeguro))
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                {
                    MessageBox.Show("Los planes de seguro solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                {
                    DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                    DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                  where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                                  select fila).FirstOrDefault();
                    if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }

        private void VisualizarMensaje()
        {
            if (dtgCargaSeguros.RowCount == 0)
            {
                lblAlerta.Visible = true;
                btnAceptar.Enabled = false;
                rbtRechazaListaSeguro.Enabled = false;
                rbtAceptaListaSeguro.Enabled = false;
                rbtRechazaInclusionCapital.Enabled = false;
                rbtAceptaInclusionCapital.Enabled = false;
                cboSeguroVida.Enabled = false;
                cboSeguroOncologico.Enabled = false;
            }
        }

        private List<clsSolicitudCreditoSeguro> filtrarTipoSeguro(List<clsSolicitudCreditoSeguro> _lstSolicitudCreditoSeguro)
        {
            List<clsSolicitudCreditoSeguro> lstResultado = new List<clsSolicitudCreditoSeguro>();
            DataTable dtSegurosHabilitados = objCNCreditoCargaSeguro.CNVerificarConfiguracionSeguro(objSolicitudCreditoCargaSeguro.idProducto, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);

            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == 1 && dtSegurosHabilitados.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == idTipoVida && dtSegurosHabilitados.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == 3 && dtSegurosHabilitados.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => lstPaqueteSegurosPrima.Any(x => x.idTipoSeguro == item.idTipoSeguro) && dtSegurosHabilitados.AsEnumerable().Any(itemDT => lstPaqueteSegurosPrima.Any(x => x.idTipoSeguro == item.idTipoSeguro)))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == idTipoOncologico && dtSegurosHabilitados.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            return lstResultado;
        }

        private List<clsSolicitudCreditoSeguro> filtrarTipoSeguroActivos(List<clsSolicitudCreditoSeguro> _lstSolicitudCreditoSeguro)
        {
            List<clsSolicitudCreditoSeguro> lstResultado = new List<clsSolicitudCreditoSeguro>();
            DataTable dtSegurosHabilitadosActivos = objCNCreditoCargaSeguro.CNVerificarConfiguracionSeguroActivos(idSolicitud, objSolicitudCreditoCargaSeguro.idProducto, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);

            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == 1 && dtSegurosHabilitadosActivos.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == idTipoVida && dtSegurosHabilitadosActivos.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == 3 && dtSegurosHabilitadosActivos.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => lstPaqueteSegurosPrima.Any(x => x.idTipoSeguro == item.idTipoSeguro) && dtSegurosHabilitadosActivos.AsEnumerable().Any(itemDT => lstPaqueteSegurosPrima.Any(x => x.idTipoSeguro == item.idTipoSeguro)))).ToList();
            lstResultado = lstResultado.Concat(_lstSolicitudCreditoSeguro.Where(item => item.idTipoSeguro == idTipoOncologico && dtSegurosHabilitadosActivos.AsEnumerable().Any(itemDT => item.idTipoSeguro == Convert.ToInt32(itemDT["idTipoSeguro"])))).ToList();
            return lstResultado;
        }

        private void cargarComponentes()
        {
            objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
            lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
            objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            objCNPlanPagos = new clsCNPlanPago();
            bsSolicitudCreditoCargaSeguro = new BindingSource();
        }

        private void cargarComponentes(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro)
        {
            objSegurosNoPermitidos = clsSeguros.CNListaSegurosNoPermitidos();
            lstSegurosDesmarcados = clsSeguros.CNListaSegurosDesmarcados(_objSolicitudCreditoCargaSeguro.idSolicitud);

            if (!_objSolicitudCreditoCargaSeguro.lEsDesembolso)
                _objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FindAll(x => x.idTipoSeguro == 1).ForEach(x => { if (!x.cTipoSeguro.StartsWith("(*) ")) { x.cTipoSeguro = "(*) " + x.cTipoSeguro; } });

            if (objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 0 || objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 1)
                _objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro = _objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital ?
               _objSolicitudCreditoCargaSeguro.nMontoSolicitado - _objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.
                   Where(item => item.lSeleccionado && item.idTipoSeguro == idTipoVida || item.idTipoSeguro == idTipoOncologico).Sum(item => item.nMontoPrima) :
               _objSolicitudCreditoCargaSeguro.nMontoSolicitado;

            _objSolicitudCreditoCargaSeguro.nMontoSolicitado = _objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro > 0 ? _objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro : _objSolicitudCreditoCargaSeguro.nMontoSolicitado;

            objFunUtiles = new clsFunUtiles();
            objSolicitudCreditoCargaSeguro = _objSolicitudCreditoCargaSeguro;
            lstSolicitudCreditoSeguro = _objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro;
            objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            objCNPlanPagos = new clsCNPlanPago();
            bsSolicitudCreditoCargaSeguro = new BindingSource();
            idSolicitud = objSolicitudCreditoCargaSeguro.idSolicitud;

            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaOperacionAplicaInclusionSeguro"));

            lstOperacionExcluidas = objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

            dtDatosZonaUsuario = objCNCreditoCargaSeguro.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);
            habilitarEventHandler(false);

            bsSolicitudCreditoCargaSeguro.DataSource = lstSolicitudCreditoSeguro;
            dtgCargaSeguros.DataSource = bsSolicitudCreditoCargaSeguro;

            formatearGridCargaSeguro(_objSolicitudCreditoCargaSeguro.lEsDesembolso);
            dtgCargaSeguros.Refresh();
            habilitarEventHandler(true);

            //Deshabilita el combo
            cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
            cboSeguroVida.SelectedIndex = -1;
            cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;

            cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
            cboSeguroOncologico.SelectedIndex = -1;
            cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;

            cargarDatos();

            #region Seguro Vida
            InicializarComboVida();
            #endregion

            #region SeguroOncologico
            InicializarComboOncologico();
            #endregion

            if (objSolicitudCreditoCargaSeguro.lEsPlanPagos || objSolicitudCreditoCargaSeguro.lEsDesembolso)
                ValidarCambioPrimaSeguro();

            DataTable dtSeguroVida = (DataTable)cboSeguroVida.DataSource;
            DataTable dtSeguroOncologico = (DataTable)cboSeguroOncologico.DataSource;

            cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
            DataRow rowVida = dtSeguroVida.NewRow();
            rowVida["idTipoSeguro"] = idTipoVida;
            rowVida["cDescripcion"] = "NINGUNO";
            rowVida["idTipoPlan"] = 0;
            rowVida["lRedondear"] = true;

            //Valido previamente si existe la opción NINGUNO en el combo, si no existe la agrego
            if (!dtSeguroVida.AsEnumerable().Any(item => Convert.ToInt32(item["idTipoPlan"]) == 0))
                dtSeguroVida.Rows.Add(rowVida);
            cboSeguroVida.DataSource = dtSeguroVida.AsEnumerable().Where(item => Convert.ToInt32(item["idTipoSeguro"]) == idTipoVida).OrderBy(fila => fila.Field<Int32>("idTipoPlan")).CopyToDataTable();
            cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;

            cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
            DataRow rowOnco = dtSeguroOncologico.NewRow();
            rowOnco["idTipoSeguro"] = idTipoOncologico;
            rowOnco["cDescripcion"] = "NINGUNO";
            rowOnco["idTipoPlan"] = 0;
            rowOnco["lRedondear"] = true;

            //Valido previamente si existe la opción NINGUNO en el combo, si no existe la agrego
            if (!dtSeguroOncologico.AsEnumerable().Any(item => Convert.ToInt32(item["idTipoPlan"]) == 0))
                dtSeguroOncologico.Rows.Add(rowOnco);
            cboSeguroOncologico.DataSource = dtSeguroOncologico.AsEnumerable().Where(item => Convert.ToInt32(item["idTipoSeguro"]) == idTipoOncologico).OrderBy(fila => fila.Field<Int32>("idTipoPlan")).CopyToDataTable();
            cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;

            #region Seguro Vida
            InicializarComboVida();
            #endregion

            #region SeguroOncologico
            InicializarComboOncologico();
            #endregion

            //Valido si el seguro oncológico está activo para mostrar u ocultar el combo del seguro
            ValidarSeguroActivo();
        }

        private void InicializarComboVida()
        {
            cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
            var _nPlazoCoberturatmpVida = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoVida && x.lSeleccionado);
            int _nPlazoCoberturaBDVida = _nPlazoCoberturatmpVida == null ? 0 : objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoVida).nPlazoCobertura;
            PlazoSeguroVida plazoVidaEnum = (PlazoSeguroVida)_nPlazoCoberturaBDVida;
            int indiceComboVida = 0;
            switch (plazoVidaEnum)
            {
                case PlazoSeguroVida.SEIS_MESES:
                    indiceComboVida = (int)ValorComboSeguroVida.SEIS_MESES;
                    break;
                case PlazoSeguroVida.DOCE_MESES:
                    indiceComboVida = (int)ValorComboSeguroVida.DOCE_MESES;
                    break;
                case PlazoSeguroVida.DIECIOCHO_MESES:
                    indiceComboVida = (int)ValorComboSeguroVida.DIECIOCHO_MESES;
                    break;
                default:
                    // Manejar un caso no esperado, si es necesario
                    break;
            }
            cboSeguroVida.SelectedIndex = indiceComboVida;
            idTipoVidaInicial = Convert.ToInt32(cboSeguroVida.SelectedValue);
            cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;
        }

        public void limpiar()
        {
            habilitarEventHandler(false);
            rbtAceptaListaSeguro.Checked = false;
            rbtRechazaListaSeguro.Checked = true;
            rbtAceptaInclusionCapital.Checked = false;
            rbtRechazaInclusionCapital.Checked = true;
            objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
            lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
            bsSolicitudCreditoCargaSeguro = new BindingSource();

            lstSolicitudCreditoSeguro.Clear();
            habilitarEventHandler(true);

            actualizarDatosGridCargaSeguro();
        }

        private void actualizarDatosGridCargaSeguro(bool lActivarPlan = true)
        {
            habilitarEventHandler(false);
            if (lActivarPlan) SeleccionarPlanSeguro();
            lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro;
            bsSolicitudCreditoCargaSeguro.DataSource = lstSolicitudCreditoSeguro;
            bsSolicitudCreditoCargaSeguro.ResetBindings(false);
            dtgCargaSeguros.DataSource = bsSolicitudCreditoCargaSeguro;
            formatearGridCargaSeguro();
            dtgCargaSeguros.Refresh();
            habilitarEventHandler(true);
            PintarPlanesDeSeguro();
        }

        private void habilitarEventHandler(bool lValor)
        {
            if (!lValor)
            {
                rbtAceptaListaSeguro.CheckedChanged -= new EventHandler(rbtAceptaListaSeguro_CheckedChanged);
                rbtAceptaInclusionCapital.CheckedChanged -= new EventHandler(rbtAceptaInclusionCapital_CheckedChanged);
                dtgCargaSeguros.Leave -= new EventHandler(dtgCargaSeguros_Leave);
                dtgCargaSeguros.CellContentClick -= new DataGridViewCellEventHandler(dtgCargaSeguros_CellContentClick);
                dtgCargaSeguros.CellValueChanged -= new DataGridViewCellEventHandler(dtgCargaSeguros_CellValueChanged);
            }
            else
            {
                rbtAceptaListaSeguro.CheckedChanged += new EventHandler(rbtAceptaListaSeguro_CheckedChanged);
                rbtAceptaInclusionCapital.CheckedChanged += new EventHandler(rbtAceptaInclusionCapital_CheckedChanged);
                dtgCargaSeguros.Leave += new EventHandler(dtgCargaSeguros_Leave);
                dtgCargaSeguros.CellContentClick += new DataGridViewCellEventHandler(dtgCargaSeguros_CellContentClick);
                dtgCargaSeguros.CellValueChanged += new DataGridViewCellEventHandler(dtgCargaSeguros_CellValueChanged);
            }
        }

        private void activarControles(AccionFormulario evento)
        {
            if (nParam_ >= 1)
            {
                grbInclusionSeguroCapital.Enabled = false;
                switch (evento)
                {
                    case AccionFormulario.ACEPTA_SEGURO:
                        grbListaSeguro.Enabled = true;
                        cboSeguroVida.Enabled = true;
                        cboSeguroOncologico.Enabled = true;
                        break;
                    case AccionFormulario.RECHAZA_SEGURO:
                        grbListaSeguro.Enabled = false;
                        cboSeguroVida.Enabled = false;
                        cboSeguroOncologico.Enabled = false;
                        break;
                    default:
                        cboSeguroVida.Enabled = true;
                        cboSeguroOncologico.Enabled = true;
                        grbListaSeguro.Enabled = true;
                        break;
                }
            }
            else
            {
                switch (evento)
                {
                    case AccionFormulario.DEFECTO:
                        grbAdquirirListaSeguro.Enabled = true;
                        grbInclusionSeguroCapital.Enabled = (lstOperacionExcluidas.Contains(objSolicitudCreditoCargaSeguro.idOperacion)) ? false : false;
                        grbListaSeguro.Enabled = false;
                        btnAceptar.Enabled = true;
                        btnSalir.Enabled = true;
                        break;
                    case AccionFormulario.ACEPTA_SEGURO:
                        grbAdquirirListaSeguro.Enabled = true;
                        grbInclusionSeguroCapital.Enabled = (lstOperacionExcluidas.Contains(objSolicitudCreditoCargaSeguro.idOperacion)) ? false : true;
                        grbListaSeguro.Enabled = true;
                        btnAceptar.Enabled = true;
                        btnSalir.Enabled = true;
                        cboSeguroVida.Enabled = true;
                        cboSeguroOncologico.Enabled = true;
                        break;
                    case AccionFormulario.RECHAZA_SEGURO:
                        grbAdquirirListaSeguro.Enabled = true;
                        grbInclusionSeguroCapital.Enabled = (lstOperacionExcluidas.Contains(objSolicitudCreditoCargaSeguro.idOperacion)) ? false : false;
                        grbListaSeguro.Enabled = false;
                        btnAceptar.Enabled = true;
                        btnSalir.Enabled = true;
                        cboSeguroVida.Enabled = false;
                        cboSeguroOncologico.Enabled = false;
                        cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
                        cboSeguroVida.SelectedValue = 0;
                        cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;
                        cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                        cboSeguroOncologico.SelectedValue = 0;
                        cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
                        break;
                    default:
                        grbAdquirirListaSeguro.Enabled = false;
                        grbInclusionSeguroCapital.Enabled = (lstOperacionExcluidas.Contains(objSolicitudCreditoCargaSeguro.idOperacion)) ? false : false;
                        grbListaSeguro.Enabled = false;
                        btnAceptar.Enabled = false;
                        btnSalir.Enabled = false;
                        break;
                }
            }
        }

        private void formatearGridCargaSeguro(bool _esDesembolso = false)
        {
            dtgCargaSeguros.ReadOnly = false;
            foreach (DataGridViewColumn dgvColumn in dtgCargaSeguros.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.HeaderText = dgvColumn.Name;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvColumn.ReadOnly = true;
            }

            dtgCargaSeguros.Columns["lSeleccionado"].Visible = true;
            dtgCargaSeguros.Columns["cTipoSeguro"].Visible = true;
            dtgCargaSeguros.Columns["cMoneda"].Visible = true;
            dtgCargaSeguros.Columns["nMontoCobertura"].Visible = true;
            dtgCargaSeguros.Columns["nPlazoCobertura"].Visible = true;
            dtgCargaSeguros.Columns["nMontoPrima"].Visible = true;

            dtgCargaSeguros.Columns["lSeleccionado"].HeaderText = "Seleccionado";
            dtgCargaSeguros.Columns["cTipoSeguro"].HeaderText = "Tipo de Seguro";
            dtgCargaSeguros.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCargaSeguros.Columns["nMontoCobertura"].HeaderText = "Monto Cobertura";
            dtgCargaSeguros.Columns["nPlazoCobertura"].HeaderText = "Plazo Seguro";
            dtgCargaSeguros.Columns["nMontoPrima"].HeaderText = "Prima";

            dtgCargaSeguros.Columns["lSeleccionado"].ReadOnly = false;

            lblRefMultiriesgo.Visible = !_esDesembolso;
        }

        private void cargarDatos(int nCodSeguro = 0, int nCodSeguroAnt = 0)
        {
            int idUsuarioZona = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idZona"]);
            int idUsuarioAgencia = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idAgencia"]);

            #region PlanesDeSeguro

            lblAlertaPaquetes.Text = string.Format(clsVarApl.dicVarGen["cAlertaMultiplePlanesSeleccionado"], Convert.ToString(clsVarApl.dicVarGen["nMaximoPlanesSeguro"]));
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;

            //Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();

            //Obtengo la lista de todos los paquetes que se pueden vender segun el perfil y la agencia
            IEnumerable<clsPaqueteSeguro> lstPaqueteSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, idPerfil, idUsuarioAgencia);

            //Obtengo la lista de todos los paquetes que no se pueden vender para eliminarlos de la lista principal
            var lstPaquetesAEliminar = lstPaqueteSeguros.Where(x => !lstPaqueteSegurosPermitidos.Any(p => p.idTipoSeguro == x.idTipoSeguro)).ToList();

            //Valido que la lista a eliminar no incluya el paquete previo seleccionado
            lstPaquetesAEliminar.RemoveAll(x => x.idPaqueteSeguro == objSolicitudCreditoCargaSeguro.idPaqueteSeguro);

            #endregion

            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Count > 0) ? objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro : objCNCreditoCargaSeguro.CNObtenerSolicitudSeguroTipo(objSolicitudCreditoCargaSeguro.idSolicitud);

            #region PlanesDeSeguro
            if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
            {
                //Elimino la lista de los planes de seguro si es que no se seleccionó Seguro desgravamen individual
                if (objSolicitudCreditoCargaSeguro.idDetalleGasto != 1)  //Seguro desgravamen individual
                {
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.RemoveAll(x => lstPaqueteSeguros.Any(seguro => seguro.idTipoSeguro == x.idTipoSeguro));
                }
            }
            else if (!lSimuladorConDesgravamen)  //Seguro desgravamen individual
            {
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.RemoveAll(x => lstPaqueteSeguros.Any(seguro => seguro.idTipoSeguro == x.idTipoSeguro));
            }

            //Elimino los paquetes de seguro que no se pueden mostrar por restricción de perfil y agencia siempre y cuando la solicitud sea nueva
            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.RemoveAll(x => lstPaquetesAEliminar.Any(seguro => seguro.idTipoSeguro == x.idTipoSeguro));

            #endregion
            decimal nMontoFavorClientePrima = 0;
            bool lSeguroActivo = true;

            if (objSolicitudCreditoCargaSeguro.idSolicitud != 0 || objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.lSeleccionado))
            {
                habilitarEventHandler(false);
                rbtAceptaListaSeguro.Checked = objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro;
                rbtRechazaListaSeguro.Checked = !objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro;
                rbtAceptaInclusionCapital.Checked = objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital;
                rbtRechazaInclusionCapital.Checked = !objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital;
                habilitarEventHandler(true);
                if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro)
                {
                    activarControles(AccionFormulario.ACEPTA_SEGURO);
                }
                else
                {
                    activarControles(AccionFormulario.RECHAZA_SEGURO);
                }
            }
            else if (cboSeguroVida.SelectedIndex < 0 || cboSeguroOncologico.SelectedIndex < 0)
            {
                habilitarEventHandler(false);
                rbtAceptaInclusionCapital.Checked = false;
                rbtRechazaInclusionCapital.Checked = true;
                rbtAceptaListaSeguro.Checked = false;
                rbtRechazaListaSeguro.Checked = true;
                habilitarEventHandler(true);
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Select(item => { item.idMoneda = objSolicitudCreditoCargaSeguro.idMoneda; item.cMoneda = objSolicitudCreditoCargaSeguro.cMoneda; return item; }).ToList();
                activarControles(AccionFormulario.DEFECTO);
            }

            int nNumeroDiasCredito = new clsCNSolicitud().ObtieneTotalDias(objSolicitudCreditoCargaSeguro.dFechaDesembolso, objSolicitudCreditoCargaSeguro.nCuotas, objSolicitudCreditoCargaSeguro.nDiasGracia, objSolicitudCreditoCargaSeguro.idTipoPlazo, objSolicitudCreditoCargaSeguro.nPlazo);
            DateTime dFechaPrimeraCuota = objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota;

            if (objSolicitudCreditoCargaSeguro.idTipoPlazo != 3)
            {
                dFechaPrimeraCuota = (objSolicitudCreditoCargaSeguro.idTipoPlazo == 1) ? objSolicitudCreditoCargaSeguro.dFechaDesembolso.AddMonths(1).AddDays(objSolicitudCreditoCargaSeguro.nDiasGracia) : objSolicitudCreditoCargaSeguro.dFechaDesembolso.AddDays(objSolicitudCreditoCargaSeguro.nPlazo + objSolicitudCreditoCargaSeguro.nDiasGracia);
            }

            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = dFechaPrimeraCuota;

            DataTable dtPlanPagosTemporal = (objSolicitudCreditoCargaSeguro.idTipoPlazo == 3 && objSolicitudCreditoCargaSeguro.idEstadoSolicitud.In(2, 5)) ?
                objCNPlanPagos.CalcularCuotasLibresEvalRural(objSolicitudCreditoCargaSeguro.nCuotas, objSolicitudCreditoCargaSeguro.nMontoSolicitado, objSolicitudCreditoCargaSeguro.dFechaDesembolso, objSolicitudCreditoCargaSeguro.idSolicitud, 0, objSolicitudCreditoCargaSeguro.dFechaDesembolso, new DataTable()) :
                objCNPlanPagos.CalculaPpgCuotasConstantes2(objSolicitudCreditoCargaSeguro.nMontoSolicitado, 0, objSolicitudCreditoCargaSeguro.dFechaDesembolso, objSolicitudCreditoCargaSeguro.nCuotas, objSolicitudCreditoCargaSeguro.nDiasGracia, (short)objSolicitudCreditoCargaSeguro.idTipoPlazo, objSolicitudCreditoCargaSeguro.nPlazo, 0, new DataTable(), 1, new DataTable(), dFechaPrimeraCuota, 0, 0, objSolicitudCreditoCargaSeguro.nCuotaGracia, true);
            DateTime dFechaFinSeguro = dtPlanPagosTemporal.AsEnumerable().OrderByDescending(item => item["cuota"]).First().Field<DateTime>("fecha");

            int nTotalDiasCalendario = (objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 2) ? (dFechaFinSeguro - objSolicitudCreditoCargaSeguro.dFechaDesembolso).Days : dtPlanPagosTemporal.AsEnumerable().Sum(item => Convert.ToInt32(item["dias"]));

            if (dFechaFinSeguro != objSolicitudCreditoCargaSeguro.dFechaCancelacion)
            {
                dFechaFinSeguro = objSolicitudCreditoCargaSeguro.dFechaCancelacion = (objSolicitudCreditoCargaSeguro.lPlanPagosGenerado) ? objSolicitudCreditoCargaSeguro.dFechaCancelacion : dFechaFinSeguro;
                nTotalDiasCalendario = (objSolicitudCreditoCargaSeguro.dFechaCancelacion - objSolicitudCreditoCargaSeguro.dFechaDesembolso).Days;
            }
            int nCuotasMinimo = 0;

            if (objSolicitudCreditoCargaSeguro.idTipoPlazo != 3)
                nCuotasMinimo = (objSolicitudCreditoCargaSeguro.idTipoPlazo == 1) ? objSolicitudCreditoCargaSeguro.nCuotas : (objSolicitudCreditoCargaSeguro.nPlazo * objSolicitudCreditoCargaSeguro.nCuotas) / 30;

            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Select(item =>
            {
                if (objSolicitudCreditoCargaSeguro.nEsSimulador == 1)
                {
                    item.nMontoCobertura = objSolicitudCreditoCargaSeguro.nMontoSolicitado;
                }
                else
                {
                    item.nMontoCobertura = (objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro != 0) ? objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro : objSolicitudCreditoCargaSeguro.nMontoSolicitado;
                }
                item.nPlazoCobertura = item.nPlazoCobertura != 0 ? item.nPlazoCobertura : (nTotalDiasCalendario / 30 < nCuotasMinimo) ? nCuotasMinimo : nTotalDiasCalendario / 30;  //Eliminar si quieren que los no seleccionados quede en 0;

                //Evaluo si estamos en cuotas libres para mostrar el plazo de cobertura segun la cantidad de cuotas de la evaluación
                if (item.lPagoCuotas && item.lSeleccionado)//Solo seguros que se pagan en cuotas
                    item.nPlazoCobertura = objSolicitudCreditoCargaSeguro.idTipoPlazo == 3 ? dtPlanPagosTemporal.Rows.Count : item.nPlazoCobertura;

                item.dFechaInicioVigencia = objSolicitudCreditoCargaSeguro.dFechaDesembolso;
                item.dFechaFinVigencia = dFechaFinSeguro;

                if (item.idTipoSeguro == nCodSeguro)
                    lSeguroActivo = ValidarDesactivacionSeguro(item, true);

                // Seguro multiriesgo
                if (item.idTipoSeguro == 1)
                {
                    item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                    item.nValorCobertura = item.nValor;
                    decimal nTotalPrima = ObtenerTotalPrimaMultiRiesgo(item.nValor, dtPlanPagosTemporal, objSolicitudCreditoCargaSeguro, item.nMontoCobertura, objSolicitudCreditoCargaSeguro.lCuotasConstantes);
                    item.nMontoPrima = nTotalPrima;
                }
                // Seguro vida
                else if (item.idTipoSeguro == idTipoVida)
                {
                    object plazoSeleccionado;

                    if (nCodSeguro == item.idTipoSeguro)
                        plazoSeleccionado = nCodSeguroAnt;
                    else
                        plazoSeleccionado = cboSeguroVida.SelectedValue;

                    decimal nMontoPrimaSeguro = 0;
                    dtPlanPagoSeguros = clsSeguros.obtenerPrecioPlanSeguro(plazoSeleccionado == null ? 0 : (int)plazoSeleccionado, 0);

                    if (Convert.ToInt32(cboSeguroVida.SelectedValue) == 0 && nCodSeguroAnt == 0)
                    {
                        item.nPlazoCobertura = item.nPlazoCobertura;
                        item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                        item.nValorCobertura = item.nValor;
                        nMontoPrimaSeguro = item.nMontoPrima;
                    }
                    else
                    {
                        /*Para seguro vida, actualizar el plazo y prima*/
                        if (dtPlanPagoSeguros.Rows.Count > 0)
                        {
                            item.nPlazoCobertura = Convert.ToInt32(dtPlanPagoSeguros.Rows[0]["nMeses"]);
                            item.nValor = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioMensual"]);
                            item.nValorCobertura = item.nValor;
                            nMontoPrimaSeguro = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioTotal"]);
                        }
                    }
                    if (Convert.ToInt32(cboSeguroVida.SelectedValue) != 0 && cboSeguroVida.SelectedValue != null) { item.lSeleccionado = true; item.idTipoValor = idTipoPlanVidaSeleccionado; }
                    else if (Convert.ToInt32(cboSeguroVida.SelectedValue) == 0 && cboSeguroVida.SelectedValue != null) { item.lSeleccionado = false; item.idTipoValor = idTipoPlanVidaSeleccionado; }
                    if (nCodSeguro == item.idTipoSeguro && nCodSeguroAnt > 0 && !lSeguroActivo)
                    {
                        item.lSeleccionado = true; item.idTipoValor = nCodSeguroAnt;
                    }
                    item.nMontoPrima = nMontoPrimaSeguro;
                    item.dFechaFinVigencia = item.dFechaInicioVigencia.AddMonths(item.nPlazoCobertura);
                }
                // Seguro agrario
                else if (item.idTipoSeguro == 3)
                {
                    item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                    item.nValorCobertura = item.nValor;
                    item.nMontoPrima = objFunUtiles.redondearBCR(objFunUtiles.truncarNumero(item.nMontoCobertura * item.nValor, 2), ref nMontoFavorClientePrima, objSolicitudCreditoCargaSeguro.idMoneda, true, true);
                }
                #region PlanesDeSeguro
                else if (lstPaqueteSeguros.Any(x => x.idTipoSeguro == item.idTipoSeguro))
                {
                    item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                    item.nValorCobertura = item.nValor;
                    decimal nTotalPrima = ObtenerTotalPrimaPaquetes(item.nValor, dtPlanPagosTemporal, dFechaPrimeraCuota, objSolicitudCreditoCargaSeguro.dFechaDesembolso, objSolicitudCreditoCargaSeguro.idTipoPlazo, objSolicitudCreditoCargaSeguro.lCuotasConstantes);
                    item.nMontoPrima = nTotalPrima;
                }
                #endregion
                #region SeguroOncologico
                else if (item.idTipoSeguro == idTipoOncologico)
                {
                    object plazoSeleccionado;

                    if (nCodSeguro == item.idTipoSeguro)
                        plazoSeleccionado = nCodSeguroAnt;
                    else
                        plazoSeleccionado = cboSeguroOncologico.SelectedValue;

                    decimal nMontoPrimaSeguro = 0;
                    dtPlanPagoSeguros = clsSeguros.obtenerPrecioPlanSeguro(plazoSeleccionado == null ? 0 : (int)plazoSeleccionado, 0);

                    if (Convert.ToInt32(cboSeguroOncologico.SelectedValue) == 0 && nCodSeguroAnt == 0)
                    {
                        item.nPlazoCobertura = item.nPlazoCobertura;
                        item.nValor = item.nValorCobertura != 0 ? item.nValorCobertura : item.nValor;
                        item.nValorCobertura = item.nValor;
                        nMontoPrimaSeguro = item.nMontoPrima;
                    }
                    else
                    {
                        if (dtPlanPagoSeguros.Rows.Count > 0)
                        {
                            item.nPlazoCobertura = Convert.ToInt32(dtPlanPagoSeguros.Rows[0]["nMeses"]);
                            item.nValor = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioMensual"]);
                            item.nValorCobertura = item.nValor;
                            nMontoPrimaSeguro = Convert.ToDecimal(dtPlanPagoSeguros.Rows[0]["nPrecioTotal"]);
                        }
                    }
                    if (Convert.ToInt32(cboSeguroOncologico.SelectedValue) != 0 && cboSeguroOncologico.SelectedValue != null) { item.lSeleccionado = true; item.idTipoValor = idTipoPlanOncologicoSeleccionado; }
                    else if (Convert.ToInt32(cboSeguroOncologico.SelectedValue) == 0 && cboSeguroOncologico.SelectedValue != null) { item.lSeleccionado = false; item.idTipoValor = idTipoPlanOncologicoSeleccionado; }
                    if (nCodSeguro == item.idTipoSeguro && nCodSeguroAnt > 0 && !lSeguroActivo)
                    {

                        cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                        dtgCargaSeguros.CellValueChanged -= dtgCargaSeguros_CellValueChanged;
                        cboSeguroOncologico.SelectedValue = nCodSeguroAnt;
                        item.lSeleccionado = true;
                        item.idTipoValor = nCodSeguroAnt;
                        cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
                        dtgCargaSeguros.CellValueChanged += dtgCargaSeguros_CellValueChanged;
                    }
                    item.nMontoPrima = nMontoPrimaSeguro;
                    item.dFechaFinVigencia = item.dFechaInicioVigencia.AddMonths(item.nPlazoCobertura);

                    //Obtengo el plazo de cobertura seleccionado en el combo del seguro oncologico (cboSeguroOncologico)
                    int idTipoPlanSeleccionado = Convert.ToInt32(cboSeguroOncologico.SelectedValue);

                    if (idTipoPlanSeleccionado > 0)
                    {
                        //Busco el idTipoPlan en el DataSource del combo y obtengo el valor de nMeses
                        int nPlazoCobertura = Convert.ToInt32(((DataRowView)cboSeguroOncologico.SelectedItem).Row["nMeses"]);

                        //VALIDO REGLAS DEL SEGURO ONCOLOGICO
                        DataTable dtResultado = objCNCreditoCargaSeguro.CNValidarSeguroOncologico(objSolicitudCreditoCargaSeguro.idCli, nPlazoCobertura, 0);

                        if (dtResultado.Rows.Count > 0 && objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                        {
                            if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                            {
                                MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                item.lSeleccionado = false;
                                cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                                cboSeguroOncologico.SelectedValue = 0;
                                cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
                            }
                        }
                    }
                }
                #endregion
                item.idUsuario = (item.idUsuario == 0) ? clsVarGlobal.User.idUsuario : item.idUsuario;
                item.idAgencia = (item.idAgencia == 0) ? idUsuarioAgencia : item.idAgencia;
                item.idZona = (item.idZona == 0) ? idUsuarioZona : item.idZona;
                item.idMoneda = (item.idMoneda == 0) ? objSolicitudCreditoCargaSeguro.idMoneda : item.idMoneda;
                item.idCargo = (item.idCargo == 0) ? clsVarGlobal.User.idCargo : item.idCargo;
                item.idCanalRegistro = (item.idCanalRegistro == 0) ? clsVarGlobal.idCanal : item.idCanalRegistro;
                return item;
            }).ToList();

            if (objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 0 || objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 1)
                objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro = objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital ?
               objSolicitudCreditoCargaSeguro.nMontoSolicitado + objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.
                    Where(item => item.lSeleccionado && (item.idTipoSeguro == idTipoVida || item.idTipoSeguro == idTipoOncologico)).Sum(item => item.nMontoPrima) :
               objSolicitudCreditoCargaSeguro.nMontoSolicitado;

            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.ForEach(x => x.nMontoCobertura = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro);

            var objMultiriesgoTmp = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1);
            if (objMultiriesgoTmp == null)
            {
                decimal tmpTotalMultiriesgo = ObtenerTotalPrimaMultiRiesgo(objMultiriesgoTmp.nValor, dtPlanPagosTemporal, objSolicitudCreditoCargaSeguro, objMultiriesgoTmp.nMontoCobertura, objSolicitudCreditoCargaSeguro.lCuotasConstantes);
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FindAll(x => x.idTipoSeguro == 1).ForEach(x => x.nMontoPrima = tmpTotalMultiriesgo);

                if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro || objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
                {
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = filtrarTipoSeguroActivos(objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro);
                }
                else
                {
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = filtrarTipoSeguro(objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro);
                }
            }
            bool algunPaqueteSeleccionado = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(x => lstPaqueteSeguros.Any(seguro => seguro.idTipoSeguro == x.idTipoSeguro && x.lSeleccionado));
            if (objSolicitudCreditoCargaSeguro.lEsRegistro && objSolicitudCreditoCargaSeguro.idPaqueteSeguro > 0) algunPaqueteSeleccionado = true;
            actualizarDatosGridCargaSeguro(algunPaqueteSeleccionado);
            validarSegurosDesmarcadosEnMemoria();
            VisualizarMensaje();
            ValidarSegurosQueNoSePuedenMarcar();
        }

        private decimal ObtenerTotalPrimaMultiRiesgo(decimal nValorPrimaMultiriesgo, DataTable dtPlanPagosTemporal, clsSolicitudCreditoCargaSeguro objSolCreCarSeg, decimal nMontoCobertura, bool lCuotasConstantes)
        {
            DataTable dtCuotasSeguroMultiriesgo = objCNPlanPagos.ObtenerDistribucionPrimaMultiriesgo(nValorPrimaMultiriesgo, dtPlanPagosTemporal, objSolCreCarSeg, nMontoCobertura, lCuotasConstantes);

            decimal nTotalPrima = 0m;
            nTotalPrima = dtCuotasSeguroMultiriesgo.AsEnumerable().Sum(x => Convert.ToDecimal(x["monto"]));
            return nTotalPrima;
        }

        private void deshabilitarSelSeguro(string msg, bool value = false)
        {
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.dtgCargaSeguros.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCargaSeguros_CellValueChanged);
            dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value = value;
            this.dtgCargaSeguros.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCargaSeguros_CellValueChanged);
        }

        #region PlanesDeSeguro

        private bool validarDuplicidadPaqueteSeguros()
        {
            DataTableToList objDataTableConfig = new DataTableToList();
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();

            int nmaximoPaqueteSeguros = clsVarApl.dicVarGen["nMaximoPlanesSeguro"];
            int nTotalSegurosAgregados = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.AsEnumerable().Count(x => x.lSeleccionado == true && x.idTipoSeguro != null && lstPaqueteSegurosTmp.Any(objeto => objeto.idTipoSeguro.ToString() == x.idTipoSeguro.ToString()));

            lstPaqueteSegurosTmp = lstPaqueteSeguros;
            if (nTotalSegurosAgregados <= nmaximoPaqueteSeguros)
            {
                List<clsMantenimientoPaqueteSeguro> lstPaqueteSegurosTemp = ObtenerListaCompletaPlanes();

                var paqueteSeleccionado = lstSolicitudCreditoSeguro.FirstOrDefault(x => x.lSeleccionado == true && lstPaqueteSegurosTemp.Any(y => y.idTipoSeguro == x.idTipoSeguro));

                int idPaqueteSeguro = -1;

                if (paqueteSeleccionado != null)
                {
                    var paqueteSeguroCorrespondiente = lstPaqueteSegurosTemp.FirstOrDefault(x => x.idTipoSeguro == paqueteSeleccionado.idTipoSeguro);

                    if (paqueteSeguroCorrespondiente != null)
                        idPaqueteSeguro = paqueteSeguroCorrespondiente.idPaqueteSeguro;
                }
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = idPaqueteSeguro;
            }
            return nTotalSegurosAgregados <= nmaximoPaqueteSeguros;
        }

        private bool ValidarDesactivacionPaquetesSeguros(int idTipoPaquete = 0)
        {
            DataTable resp = new clsCNPaqueteSeguro().CNObtenerPromotorInicialSeguroOptativo(idSolicitud, idTipoPaquete);
            int idUsuarioOriginal = resp.Rows.Count == 0 ? 0 : Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);
            DataTable verificacion = objPaqueteSeguroCN.CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(idSolicitud);

            if (verificacion.Rows.Count > 0)
            {
                int idplanActual = objSolicitudCreditoCargaSeguro.idPaqueteSeguro;
                int idPlanSolicitud = Convert.ToInt32(verificacion.Rows[0]["idPlan"]);

                int idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);

                if (idEstadoSolicitud == 1) //SOLICITADO
                {
                    string agencia = verificacion.Rows[0]["cNombreAge"].ToString();
                    int numSoli = Convert.ToInt32(verificacion.Rows[0]["idSolAproba"]);

                    MessageBox.Show("Existe una solicitud con número: " + numSoli + " pendiente de aprobación en la agencia: " + agencia.Trim() + ".\nNo puede proceder", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    return false;
                }
                else
                {
                    if (idplanActual != idPlanSolicitud)     //Se envió la solicitud de aprobación pero no se guardaron los cambios en formulario.
                    {
                        CancelarSolicitudPlanesPorArrepentimiento();
                    }
                }
            }

            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();

            foreach (var x in lstPaqueteSeguros)
            {
                if (x.idTipoSeguro == idTipoPaquete)
                {
                    idTipoPaquete = x.idPaqueteSeguro;
                    break;
                }
            }

            if (idTipoPaquete == objSolicitudCreditoCargaSeguro.idPaqueteSeguro && idUsuarioOriginal != clsVarGlobal.PerfilUsu.idUsuario)      //2 = Adquirido en plan de pagos o por otro usuario
            {
                DialogResult drResultadoPaquete = MessageBox.Show(clsVarApl.dicVarGen["cAlertaPlanesDeSeguro"], cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultadoPaquete == DialogResult.No)
                {
                    deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    return false;
                }
            }
            return false;
        }

        private void CancelarSolicitudPlanesPorArrepentimiento()
        {
            try
            {
                new clsCNPaqueteSeguro().CNEDesactivarSolicitudPorArrepentimiento(objSolicitudCreditoCargaSeguro.idSolicitud);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex);
            }
        }

        private void SeleccionarPlanSeguro()
        {
            try
            {
                int nSeguroSelecionado = 0;
                DataTableToList objDataTableConfig = new DataTableToList();
                List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();
                lstPaqueteSegurosTmp = lstPaqueteSeguros;

                //Me aseguro de que todos los paquetes estén desmarcados, antes de marcar el que se seleccionó
                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Where(x => lstPaqueteSeguros.Any(p => p.idTipoSeguro == x.idTipoSeguro)).ToList().ForEach(x => x.lSeleccionado = false);

                if (objSolicitudCreditoCargaSeguro.idPaqueteSeguro > 0)
                {
                    nSeguroSelecionado = lstPaqueteSeguros.FirstOrDefault(x => x.idPaqueteSeguro == objSolicitudCreditoCargaSeguro.idPaqueteSeguro).idTipoSeguro;
                }
                if (nSeguroSelecionado > 0)
                {
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Select(item =>
                    {
                        if (item.idTipoSeguro == nSeguroSelecionado)
                        {
                            item.lSeleccionado = true;
                        }
                        return item;
                    }).ToList();

                    if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro)
                    {
                        activarControles(AccionFormulario.ACEPTA_SEGURO);
                        rbtAceptaListaSeguro.Checked = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AsignarPaqueteSeguroSolicitud()
        {
            if (objSolicitudCreditoCargaSeguro.nEsSimulador == 1) return;
            //NO SE ENVIARÁ SMS - DESCOMENTAR CUANDO SE APRUEBE EL ENVÍO
            //lstTelefonos = (DataTableToList.ConvertTo<clsClienteRegistros>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(objSolicitudCreditoCargaSeguro.idCli)) as List<clsClienteRegistros>).First(x => x.idTipoTelefono == 1);
            int nSeguroSelecionado = 0;
            DataTableToList objDataTableConfig = new DataTableToList();
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();
            lstPaqueteSegurosTmp = lstPaqueteSeguros;
            lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro;
            var objSeguroTemporal = lstPaqueteSeguros.FirstOrDefault(x => lstSolicitudCreditoSeguro.Any(y => y.idTipoSeguro == x.idTipoSeguro && y.lSeleccionado == true));
            if (objSeguroTemporal == null)
            {
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = 0; return;
            }
            nSeguroSelecionado = objSeguroTemporal.idPaqueteSeguro;
            if (nSeguroSelecionado > 0)
            {
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = nSeguroSelecionado;

                //NO SE ENVIARÁ SMS - DESCOMENTAR CUANDO SE APRUEBE EL ENVÍO
                #region Enviar SMS
                //clsMantenimientoPaqueteSeguro objpaquete = new clsMantenimientoPaqueteSeguro();
                //objpaquete = lstPaqueteSeguros.Find(x => x.idPaqueteSeguro == nSeguroSelecionado);
                //NO SE ENVIARÁ SMS - DESCOMENTAR CUANDO SE APRUEBE EL ENVÍO
                //if (lstTelefonos != null)
                //{
                //    clsSmsRequest requestSMS = new clsSmsRequest { phone = lstTelefonos.cNumeroTelefonico, content = "Caja Los Andes informa que se ha adquirido el plan de seguro " + objpaquete.cNombreCompleto + ", el cual podrá consultar en el siguiente enlace: " + objpaquete.cLink };
                //    clsSmsResponse responseSMS = new clsServicioSMS().EnviarSMS(requestSMS);
                //    //Registrar constancia de SMS enviado
                //    GuardarTramaSMS(requestSMS, responseSMS, objSolicitudCreditoCargaSeguro.idCli);
                //}
                //else
                //{
                //    MessageBox.Show("No se ha encontrado un número de teléfono del cliente para informar del plan de seguro adquirido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                #endregion
                rbtAceptaListaSeguro.Checked = true;
            }
            else
            {
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = -1;
            }

        }

        private void GuardarTramaSMS(clsSmsRequest requestSMS, clsSmsResponse responseSMS, int idCli)
        {
            clsNotificacionSMS objNotificacionSMS = new clsNotificacionSMS();
            //TRAER EL ID DEL TELEFONO AL QUE SE ENVIÓ EL SMS
            //clsClienteRegistros lstTelefonos = DataTableToList.ConvertDataTableToList<clsClienteRegistros>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(idCli)).FirstOrDefault(x => x.cNumeroTelefonico == requestSMS.phone);
            objNotificacionSMS.idCliente = idCli;
            objNotificacionSMS.idTipoMensaje = 5;//NOTIFICACION
            objNotificacionSMS.idRegistro = Convert.ToInt32(responseSMS.id);
            objNotificacionSMS.idModulo = clsVarGlobal.idModulo;
            objNotificacionSMS.idAgencia = clsVarGlobal.nIdAgencia;
            objNotificacionSMS.idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            objNotificacionSMS.cCodigoValidacion = string.Empty;
            objNotificacionSMS.cNumeroTelefonico = responseSMS.phone;
            objNotificacionSMS.idNumeroTelefonico = lstTelefonos.idRegTel;
            objNotificacionSMS.cIDMensajeTexto = responseSMS.id;
            objNotificacionSMS.cMensajeSMS = requestSMS.content;
            objNotificacionSMS.idTipoPlantillaSMS = 0;
            objNotificacionSMS.objRegistroTelefono = new clsRegistroTelefono();
            string xmlNotificacionSMS = objNotificacionSMS.GetXml();
            clsCNAdministracionEnvioSMS objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            DataTable dtResultado = objAdministracionEnvioSMS.CNRegistrarNotificacionIndividualSMS(xmlNotificacionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, true);
        }

        public void PintarPlanesDeSeguro()
        {
            try
            {
                if (objCNCreditoCargaSeguro == null) return;

                DataTable dtZonaUsuario = objCNCreditoCargaSeguro.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);

                //Obtengo la lista de todos los paquetes de seguro vigentes
                List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();

                if (lstPaqueteSeguros.Count == 0 || !lSimuladorConDesgravamen)
                {
                    lblAlertaPaquetes.Visible = false;
                    pictureBox3.Visible = false;
                    return;
                }

                lblAlertaPaquetes.Visible = true;
                pictureBox3.Visible = true;

                int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
                int idUsuarioAgencia = Convert.ToInt32(dtZonaUsuario.Rows[0]["idAgencia"]);
                IEnumerable<clsPaqueteSeguro> lstPaqueteSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, idPerfil, idUsuarioAgencia);

                foreach (DataGridViewRow fila in dtgCargaSeguros.Rows)
                {
                    if (fila.Cells["IdTipoSeguro"].Value != null)
                    {
                        int idTipoSeguro = Convert.ToInt32(fila.Cells["IdTipoSeguro"].Value);

                        if (lstPaqueteSegurosPermitidos.Any(item => item.idTipoSeguro == idTipoSeguro))
                        {
                            fila.DefaultCellStyle.BackColor = Color.Aquamarine;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool ValidarReactivacionPaquetesSeguros(clsSolicitudCreditoSeguro objSolicitudCreditoSeguroReactivacion)
        {
            bool rpta = true;
            int idSolicitud = objSolicitudCreditoSeguroReactivacion.idSolicitud;
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idPaqueteSeguro = objSolicitudCreditoSeguroReactivacion.idTipoSeguro;

            // Solo lo ha desactivado
            if (idPaqueteSeguro == -1)
            {
                // No se debe usar continue fuera de un bucle, puedes simplemente retornar rpta aquí
                return rpta;
            }

            clsDBResp dbResp = objPaqueteSeguroCN.CNVerificarSituacionSeguroOpcional(idSolicitud, idUsuario, idAgencia, objSolicitudCreditoCargaSeguro.idPaqueteSeguro, objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro);

            switch (dbResp.nMsje)
            {
                case -1:
                    // No tenía nada
                    return rpta;
                case 0:
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rpta = false && rpta;
                    return rpta;
                case 1:
                case 3:
                    // Cuando lo rechazaron automáticamente o por aprobador
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rpta = false || rpta;
                    deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    objSolicitudCreditoCargaSeguro.idPaqueteSeguro = -1;
                    break;
                case 2:
                    // Otra solicitud de otro usuario
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rpta = false || rpta;
                    return rpta;
                case 4:
                    // Solicitud pendiente
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rpta = false || rpta;
                    return rpta;
                default:
                    // Manejar otros casos si es necesario
                    break;
            }

            var pregunta = MessageBox.Show("¿Desea registrar otra solicitud?", cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                dbResp = objPaqueteSeguroCN.CNSolicitarReactivacionSeguroOpcional(idSolicitud, idUsuario, idAgencia, objSolicitudCreditoCargaSeguro.idPaqueteSeguro, objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro);
                if (dbResp.nMsje == 0)
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rpta = false || rpta;
                    return rpta;// Usar el operador || en lugar de &&
                                // No es necesario el continue aquí
                }
                if (dbResp.nMsje == 1)
                {
                    MessageBox.Show(dbResp.cMsje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rpta = false || rpta;  // Usar el operador || en lugar de &&
                    deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    objSolicitudCreditoCargaSeguro.idPaqueteSeguro = -1;
                }
            }
            else
            {
                deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = -1;
            }

            return rpta;
        }

        private List<clsMantenimientoPaqueteSeguro> ObtenerListaCompletaPlanes()
        {
            return DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
        }

        private void AsignarPlan(int idPaquete, bool asignado = true)
        {
            if (!asignado)
            {
                objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro = idFrmOriginal;
                objSolicitudCreditoCargaSeguro.idPaqueteSeguro = idPlanOriginal;
                return;
            }

            if (objSolicitudCreditoCargaSeguro.lEsRegistro)
            {
                objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro = 1;  //INVOCADO DESDE EL REGISTRO DE SOLICITUD
            }
            else if (objSolicitudCreditoCargaSeguro.lEsPlanPagos)
            {
                objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro = 2;  //INVOCADO DESDE EL PLAN DE PAGOS DE SOLICITUD
            }
            else
            {
                objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro = 3;  //INVOCADO DESDE LA EVALUACIÓN DE SOLICITUD
                try
                {
                    // Me aseguro de seleccionar el plan de seguro
                    int idPaqueteSel = -1;
                    List<clsMantenimientoPaqueteSeguro> listaPlanes = ObtenerListaCompletaPlanes();
                    // Crea una nueva lista con todos los seguros seleccionados de objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro
                    List<clsSolicitudCreditoSeguro> lstSeguroSeleccionados = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Where(item => item.lSeleccionado).ToList();
                    //Busca si alguno de los seguros seleccionados es un plan de seguro, solo puede existir uno, devuelvelo como objeto
                    clsSolicitudCreditoSeguro objSeguroPlan = lstSeguroSeleccionados.FirstOrDefault(item => listaPlanes.Any(x => x.idTipoSeguro == item.idTipoSeguro));
                    if (objSeguroPlan != null)
                        idPaqueteSel = listaPlanes.FirstOrDefault(x => x.idTipoSeguro == objSeguroPlan.idTipoSeguro).idPaqueteSeguro;
                    objSolicitudCreditoCargaSeguro.idPaqueteSeguro = idPaqueteSel <= 0 ? -1 : objSolicitudCreditoCargaSeguro.idPaqueteSeguro;
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion

        #region SeguroOncologico

        private bool ValidarCambioPrimaSeguro(bool lMostrarMensaje = true)
        {
            bool returnVal = true;
            foreach (var seguro in objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Where(x => x.lCambioPrima && x.lVigente))
            {
                string mensaje = "El precio del seguro seleccionado: " + seguro.cTipoSeguro + " ha cambiado";
                if (objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital)
                    mensaje += " y se ha refinanciado el monto del seguro en el capital desembolsado. No se puede continuar, se debe realizar nuevamente la solicitud";

                if (seguro.lModificado)
                {
                    if (lMostrarMensaje)
                        MessageBox.Show(mensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    objSolicitudCreditoCargaSeguro.lPrimaModificada = true;
                    returnVal = false;
                }
                else
                {
                    if (seguro.lPagoCuotas)
                    {
                        returnVal = SeguroOptativoTieneModificacion(seguro, mensaje, lMostrarMensaje);
                    }
                    else
                    {
                        returnVal = PlanSeguroTieneModificacion(seguro, mensaje, lMostrarMensaje);
                    }
                }
            }
            return returnVal;
        }

        private bool SeguroOptativoTieneModificacion(clsSolicitudCreditoSeguro seguro, string mensaje, bool lMostrarMensaje)
        {
            DataTable lstSeguros;
            try
            {
                lstSeguros = clsMantenimientoSeguros.CNListaSeguroOptativo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la lista de seguros: " + ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (DataRow rowSeguros in lstSeguros.Rows)
            {
                if (Convert.ToInt32(rowSeguros["idTipoSeguro"]) == seguro.idTipoSeguro)
                {
                    if (Convert.ToDecimal(rowSeguros["nValor"]) != ObtenerPrimaActual(seguro))
                    {
                        if (lMostrarMensaje)
                            MessageBox.Show(mensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objSolicitudCreditoCargaSeguro.lPrimaModificada = true;
                        return false;
                    }
                }
            }
            return true;
        }

        private bool PlanSeguroTieneModificacion(clsSolicitudCreditoSeguro seguro, string mensaje, bool lMostrarMensaje)
        {
            DataTable lstPlanes;
            try
            {
                lstPlanes = clsMantenimientoSeguros.CNListaPlanSeguro(seguro.idTipoSeguro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la lista de planes de seguro: " + ex.Message, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Me aseguro de trabajar solo con los planes activos segun la columna lFijo
            lstPlanes = lstPlanes.AsEnumerable().Where(x => x.Field<bool>("lFijo")).CopyToDataTable();

            foreach (DataRow rowPlanes in lstPlanes.Rows)
            {
                if (Convert.ToInt32(rowPlanes["nMeses"]) == seguro.nPlazoCobertura)
                {
                    if (Convert.ToDecimal(rowPlanes["nPrecioMensual"]) != ObtenerPrimaActual(seguro))
                    {
                        if (lMostrarMensaje)
                            MessageBox.Show(mensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objSolicitudCreditoCargaSeguro.lPrimaModificada = true;
                        return false;
                    }
                }
            }
            return true;
        }

        private decimal ObtenerPrimaActual(clsSolicitudCreditoSeguro seguro)
        {
            return seguro.lPagoCuotas ? seguro.nMontoPrima : seguro.nValorCobertura;
        }

        private bool ValidarDesactivacionSeguro(clsSolicitudCreditoSeguro objSolicitudCreditoSeguro, bool lVieneDeCombo = false)
        {
            if (!objSegurosNoPermitidos.Any(x => x.idTipoSeguro == objSolicitudCreditoSeguro.idTipoSeguro))
                return true;

            DataTable resp = objCNCreditoCargaSeguro.CNObtenerPromotorInicialSeguro(objSolicitudCreditoSeguro.idSolicitud, objSolicitudCreditoSeguro.idTipoSeguro);
            int idUsuarioOriginal = resp.Rows.Count == 0 ? clsVarGlobal.PerfilUsu.idUsuario : Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);
            if (idUsuarioOriginal != clsVarGlobal.PerfilUsu.idUsuario)    //Adquirido por otro usuario
            {
                string mensaje = string.Format(clsVarApl.dicVarGen["cMensajeDesactivacionSeguro"], objSolicitudCreditoSeguro.cTipoSeguro);
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Verificar la respuesta del usuario
                if (resultado == DialogResult.Yes)
                {
                    //referencia el formulario frmRegistroSustento para obtener el sustento que ingrese el usuario
                    frmRegistroSustento frmRegistroSustento = new frmRegistroSustento();
                    frmRegistroSustento.ShowDialog();
                    string sustento = frmRegistroSustento._sustento;
                    if (string.IsNullOrEmpty(sustento))
                    {
                        // El usuario no ingresó un sustento, vuelve a marcar el CheckBox
                        if (!lVieneDeCombo)
                            deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                        return false;
                    }
                    else
                    {
                        // El usuario ingresó un sustento, realiza la acción
                        // Lógica para guardar sustento

                        lstSegurosDesmarcados.Add(new clsSegurosDesmarcados
                        {
                            idSolicitud = objSolicitudCreditoSeguro.idSolicitud,
                            idTipoSeguro = objSolicitudCreditoSeguro.idTipoSeguro,
                            idSolicitudCreditoSeguro = objSolicitudCreditoSeguro.idSolicitudCreditoSeguro,
                            dFecha = DateTime.Now,
                            idUsuario = clsVarGlobal.User.idUsuario,
                            cSustento = sustento,
                            idUsuReg = clsVarGlobal.User.idUsuario,
                            dFecReg = clsVarGlobal.dFecSystem,
                            lVigente = true
                        });

                        objSolicitudCreditoCargaSeguro.lstSegurosDesmarcados = lstSegurosDesmarcados;
                        objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == objSolicitudCreditoSeguro.idTipoSeguro).lSeleccionado = false;

                        return true;
                    }
                }
                else
                {
                    // El usuario ha cancelado, vuelve a marcar el CheckBox
                    if (!lVieneDeCombo)
                        deshabilitarSelSeguro("", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    return false;
                }
            }
            return true;
        }

        private bool ValidarDesactivacionSeguroCompleto(List<clsSolicitudCreditoSeguro> lista)
        {
            foreach (var objSolicitudCreditoSeguro in lista)
            {
                if (!objSegurosNoPermitidos.Any(x => x.idTipoSeguro == objSolicitudCreditoSeguro.idTipoSeguro))
                    continue;

                if (!objSolicitudCreditoSeguro.lSeleccionado)
                    continue;

                DataTable resp = objCNCreditoCargaSeguro.CNObtenerPromotorInicialSeguro(objSolicitudCreditoSeguro.idSolicitud, objSolicitudCreditoSeguro.idTipoSeguro);
                int idUsuarioOriginal = resp.Rows.Count == 0 ? clsVarGlobal.PerfilUsu.idUsuario : Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);
                if (idUsuarioOriginal != clsVarGlobal.PerfilUsu.idUsuario)    //Adquirido por otro usuario
                {
                    string mensaje = string.Format(clsVarApl.dicVarGen["cMensajeDesactivacionSeguro"], objSolicitudCreditoSeguro.cTipoSeguro);
                    // Mostrar un cuadro de diálogo de confirmación
                    DialogResult resultado = MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Verificar la respuesta del usuario
                    if (resultado == DialogResult.Yes)
                    {
                        //referencia el formulario frmRegistroSustento para obtener el sustento que ingrese el usuario
                        frmRegistroSustento frmRegistroSustento = new frmRegistroSustento();
                        frmRegistroSustento.ShowDialog();
                        string sustento = frmRegistroSustento._sustento;
                        if (string.IsNullOrEmpty(sustento))
                        {
                            // El usuario no ingresó un sustento
                            return false;
                        }
                        else
                        {
                            // El usuario ingresó un sustento,

                            //antes de agregar el objeto a la lista, me aseguro que no exista
                            if (lstSegurosDesmarcados.Any(x => x.idSolicitud == objSolicitudCreditoSeguro.idSolicitud && x.idTipoSeguro == objSolicitudCreditoSeguro.idTipoSeguro))
                                continue;

                            lstSegurosDesmarcados.Add(new clsSegurosDesmarcados
                            {
                                idSolicitud = objSolicitudCreditoSeguro.idSolicitud,
                                idTipoSeguro = objSolicitudCreditoSeguro.idTipoSeguro,
                                idSolicitudCreditoSeguro = objSolicitudCreditoSeguro.idSolicitudCreditoSeguro,
                                dFecha = DateTime.Now,
                                idUsuario = clsVarGlobal.User.idUsuario,
                                cSustento = sustento,
                                idUsuReg = clsVarGlobal.User.idUsuario,
                                dFecReg = clsVarGlobal.dFecSystem,
                                lVigente = true
                            });

                            objSolicitudCreditoCargaSeguro.lstSegurosDesmarcados = lstSegurosDesmarcados;
                            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == objSolicitudCreditoSeguro.idTipoSeguro).lSeleccionado = false;

                            continue;
                        }
                    }
                    else
                    {
                        // El usuario ha cancelado, vuelve a marcar el CheckBox
                        return false;
                    }
                }
            }
            return true;
        }

        private void InicializarComboOncologico()
        {
            cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
            var _nPlazoCoberturatmpOncologico = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoOncologico && x.lSeleccionado);
            int _nPlazoCoberturaBDOncologico = _nPlazoCoberturatmpOncologico == null ? 0 : objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idTipoSeguro == idTipoOncologico).nPlazoCobertura;
            PlazoSeguroOncologico plazoOncologicoEnum = (PlazoSeguroOncologico)_nPlazoCoberturaBDOncologico;
            int indiceComboOncologico = 0;
            switch (plazoOncologicoEnum)
            {
                case PlazoSeguroOncologico.DOCE_MESES:
                    indiceComboOncologico = (int)ValorComboSeguroOncologico.DOCE_MESES;
                    break;
                case PlazoSeguroOncologico.VEINTICUATRO_MESES:
                    indiceComboOncologico = (int)ValorComboSeguroOncologico.VEINTICUATRO_MESES;
                    break;
                default:
                    // Manejar un caso no esperado, si es necesario
                    break;
            }
            cboSeguroOncologico.SelectedIndex = indiceComboOncologico;
            idTipoOncologicoInicial = Convert.ToInt32(cboSeguroOncologico.SelectedValue);
            cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
        }

        private void validarSegurosDesmarcadosEnMemoria()
        {
            if (lstSegurosDesmarcados == null || lstSegurosDesmarcados.Count == 0)
                return;

            foreach (var item in objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro)
            {
                if (lstSegurosDesmarcados.Any(x => x.idTipoSeguro == item.idTipoSeguro))
                {
                    item.lSeleccionado = false;
                }
            }
        }
        #endregion

        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                #region PlanesDeSeguro
                List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();
                #endregion

                objSolicitudCreditoCargaSeguro = ObtenerSolicitudCreditoCargaSeguro();
                if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro)
                {
                    if (objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital)
                    {
                        //Cuento cuantos seguros que tiene lPagoCuotas = 0 están seleccionados
                        int nSegurosSeleccionados = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Count(x => !x.lPagoCuotas && x.lSeleccionado);
                        if (nSegurosSeleccionados == 0)
                        {
                            string cMensaje = "Debe marcar el seguro a financiar: Seguro Vida.";

                            if (lstSolicitudCreditoSeguro != null && lstSolicitudCreditoSeguro.Any(x => x.idTipoSeguro == idTipoOncologico))
                            {
                                cMensaje = string.Format(clsVarApl.dicVarGen["cMensajeSeguroRefinanciado"]);
                            }

                            MessageBox.Show(cMensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 0 || objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 1)
                            objSolicitudCreditoCargaSeguro.nMontoSolicitado = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
                        else
                            objSolicitudCreditoCargaSeguro.nMontoSolicitado = (objSolicitudCreditoCargaSeguro.nMontoSolicitado != 0) ? objSolicitudCreditoCargaSeguro.nMontoSolicitado : objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
                    }
                    else
                    {
                        objSolicitudCreditoCargaSeguro.nMontoSolicitado = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
                    }
                }
                else
                {
                    objSolicitudCreditoCargaSeguro.nMontoSolicitado = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
                }

                if (!validaSeguros() && objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                {
                    this.lCerrar = false;
                    this.lValidoSeguros = false;
                    return;
                }
                if (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idTipoSeguro == idTipoVida && item.nMontoPrima == 0 && rbtAceptaListaSeguro.Checked == true && item.lSeleccionado == true))
                {
                    MessageBox.Show("Debe seleccionar un plan de Seguro Vida", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.lCerrar = false;
                    return;
                }
                if (objSolicitudCreditoCargaSeguro.idDetalleGasto == 1)
                {
                    List<clsMantenimientoPaqueteSeguro> elementosCoincidentes = lstPaqueteSeguros.Where(x => objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(y => y.idConcepto == x.idConcepto && y.lSeleccionado)).ToList();

                    if (linvocadoDesdeSimulador && !lSimuladorConDesgravamen && (elementosCoincidentes.Count > 0))
                    {
                        throw new Exception("Para seleccionar un plan de seguros, debe haber seleccionado el seguro Desgravamen Individual");
                    }
                    else
                    {
                        AsignarPaqueteSeguroSolicitud();
                        this.lCerrar = true;
                        this.lValidoSeguros = true;
                    }
                }
                else
                {
                    this.lCerrar = true;
                    this.lValidoSeguros = true;
                }

                if (objSolicitudCreditoCargaSeguro.idEstadoSolicitud == 2)
                    MessageBox.Show("ADVERTENCIA: Los cambios realizados se actualizarán una vez que ejecute la opción de GRABAR el formulario.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.lValidoSeguros = true;
                this.lCerrar = true;

                if (BotonCerrarClick != null && lformulario)
                    BotonCerrarClick(this, EventArgs.Empty);

                // Disparar el evento AceptarClicked si está suscrito desde el formulario
                if (AceptarClicked != null)
                {
                    AceptarClicked(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!validaSeguros())
                return;

            DateTime dFechaPrimeraCuota = objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota;
            limpiar();
            objSolicitudCreditoCargaSeguro = objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud);
            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = dFechaPrimeraCuota;
            this.lCerrar = true;

            if (BotonCerrarClick != null)
                BotonCerrarClick(this, EventArgs.Empty);

            // Disparar el evento SalirClicked si está suscrito desde el formulario
            if (SalirClicked != null)
            {
                SalirClicked(this, EventArgs.Empty);
            }
        }

        private void rbtAceptaListaSeguro_CheckedChanged(object sender, EventArgs e)
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();

            objSolicitudCreditoCargaSeguro = ObtenerSolicitudCreditoCargaSeguro();
            if (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro)
            {
                if (lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
                {
                    clsSolicitudCreditoCargaSeguro objSolicitudCargaSeguro = objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(objSolicitudCreditoCargaSeguro.idSolicitud);
                    lstSolicitudCreditoSeguro = lstSolicitudCreditoSeguro.Select(item => { item.lSeleccionado = (item.idSolicitudCreditoSeguro != 0) ? true : item.lSeleccionado; return item; }).ToList();
                    rbtAceptaInclusionCapital.Checked = objSolicitudCargaSeguro.lAceptacionInclusionCapital;
                    rbtRechazaInclusionCapital.Checked = !objSolicitudCargaSeguro.lAceptacionInclusionCapital;
                    validarSegurosDesmarcadosEnMemoria();
                    actualizarDatosGridCargaSeguro();
                    #region Seguro Vida
                    InicializarComboVida();
                    #endregion
                    #region SeguroOncologico
                    InicializarComboOncologico();
                    #endregion
                }
                activarControles(AccionFormulario.ACEPTA_SEGURO);
            }
            else
            {
                objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital = false;
                if (lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0) && lstSolicitudCreditoSeguro.Any(item => item.lSeleccionado))
                {
                    DialogResult drResultado = MessageBox.Show("¿Está seguro que desea desvincular todos los seguros cargados?", cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResultado == DialogResult.No)
                    {
                        objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = true;
                        rbtAceptaListaSeguro.Checked = true;
                        activarControles(AccionFormulario.ACEPTA_SEGURO);
                        return;
                    }
                    else if (drResultado == DialogResult.Yes && lstSolicitudCreditoSeguro.First(x => x.idTipoSeguro == 1).lSeleccionado && objSolicitudCreditoCargaSeguro.lEsDesembolso)
                    {
                        MessageBox.Show("El seguro multiriesgo no se puede vender/modificar en el proceso de desembolso. Por favor dirigirse a la Generación de Plan de Pagos", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = true;
                        rbtAceptaListaSeguro.Checked = true;
                        activarControles(AccionFormulario.ACEPTA_SEGURO);
                        return;
                    }
                    #region PlanesDeSeguro
                    else if (drResultado == DialogResult.Yes)
                    {
                        if (lstPaqueteSeguros.Count > 0)
                        {
                            int idTipoPaquete = 0;
                            string tmpNombrePaquete = string.Empty;
                            var solicitudSeleccionada = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Where(x => x.lSeleccionado).FirstOrDefault();

                            if (solicitudSeleccionada != null)
                            {
                                foreach (var x in lstPaqueteSeguros)
                                {
                                    if (x.idTipoSeguro == solicitudSeleccionada.idTipoSeguro)
                                    {
                                        tmpNombrePaquete = x.cNombreCompleto;
                                        idTipoPaquete = x.idPaqueteSeguro;
                                        break;
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(tmpNombrePaquete) && objSolicitudCreditoCargaSeguro.lEsDesembolso)
                            {
                                MessageBox.Show("El Plan: " + tmpNombrePaquete + " no se puede vender/modificar en el proceso de desembolso. Por favor dirigirse a la Generación de Plan de Pagos", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = true;
                                rbtAceptaListaSeguro.Checked = true;
                                activarControles(AccionFormulario.ACEPTA_SEGURO);
                                return;
                            }
                            AsignarPlan(0, false);
                        }
                    }
                    #endregion
                    else if (drResultado == DialogResult.Yes && lstSolicitudCreditoSeguro.Any(x => objSegurosNoPermitidos.Any(y => y.idTipoSeguro == x.idTipoSeguro && x.lSeleccionado)))
                    {
                        if (!ValidarDesactivacionSeguroCompleto(lstSolicitudCreditoSeguro))
                        {
                            objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = true;
                            rbtAceptaListaSeguro.Checked = true;
                            activarControles(AccionFormulario.ACEPTA_SEGURO);
                            ValidarSegurosQueNoSePuedenMarcar();
                            return;
                        }
                    }
                }
                else if (lstPaqueteSeguros.Count > 0)
                    AsignarPlan(0, false);
                activarControles(AccionFormulario.RECHAZA_SEGURO);
                rbtRechazaInclusionCapital.Checked = true;
                lstSolicitudCreditoSeguro = lstSolicitudCreditoSeguro.Select(item => { item.lSeleccionado = false; return item; }).ToList();
                actualizarDatosGridCargaSeguro(false);
            }
            ValidarSegurosQueNoSePuedenMarcar();
            if (SeleccionarSeguro != null)
                SeleccionarSeguro(sender, e);
        }

        private void rbtAceptaInclusionCapital_CheckedChanged(object sender, EventArgs e)
        {
            objSolicitudCreditoCargaSeguro = ObtenerSolicitudCreditoCargaSeguro();
            cargarDatos();
        }

        private void dtgCargaSeguros_Leave(object sender, EventArgs e)
        {
            objSolicitudCreditoCargaSeguro = ObtenerSolicitudCreditoCargaSeguro();
        }

        private void dtgCargaSeguros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgCargaSeguros.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dtgCargaSeguros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            #region PlanesDeSeguro
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = ObtenerListaCompletaPlanes();
            #endregion
            clsSolicitudCreditoSeguro objSolicitudCreditoSeguro = (clsSolicitudCreditoSeguro)dtgCargaSeguros.SelectedRows[0].DataBoundItem;

            if (!Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value))
                if (!ValidarDesactivacionSeguro(objSolicitudCreditoSeguro))
                    return;

            if (objSolicitudCreditoCargaSeguro.lEsDesembolso && objSolicitudCreditoSeguro.idTipoSeguro == idTipoVida && objSolicitudCreditoCargaSeguro.nMontoAmpliado < objSolicitudCreditoSeguro.nMontoPrima)
            {
                deshabilitarSelSeguro("El monto de Prima del seguro Vida supera el Monto Coberturado. Por favor revise las condiciones del Crédito.", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                dtgCargaSeguros.CurrentRow.ReadOnly = true;
                dtgCargaSeguros.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Control;

                return;
            }

            if (objSolicitudCreditoCargaSeguro.lEsDesembolso && objSolicitudCreditoSeguro.idTipoSeguro == 1)
            {
                deshabilitarSelSeguro("El seguro multiriesgo no se puede vender/modificar en el proceso de desembolso. Por favor dirigirse a la Generación de Plan de Pagos.", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                dtgCargaSeguros.CurrentRow.ReadOnly = true;
                dtgCargaSeguros.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Control;

                return;
            }

            if (Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && objSolicitudCreditoSeguro.idTipoSeguro == 1) //1	SEGURO MULTIRIESGO
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                {
                    deshabilitarSelSeguro("El seguro multiriesgo solo se puede vender a personas naturales.");
                    return;
                }

                //VERIFICAR QUE NO EXCEDA DE LOS 100,000.00
                if (objSolicitudCreditoCargaSeguro.nMontoSolicitado > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]))
                {
                    deshabilitarSelSeguro("El importe del préstamo supera los " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.");
                    return;
                }

                //VERIFICAR QUE SE CUMPLA EL MONTO MINIMO
                if (objSolicitudCreditoCargaSeguro.nMontoSolicitado < Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]))
                {
                    deshabilitarSelSeguro("El importe del préstamo para aplicar multiriesgo debe ser mayor o igual a " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.");
                    return;
                }


                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                {
                    //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                    if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                    {
                        //VERIFICAR SI TIENE OTRO SEGURO MULTIRIESGO
                        DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && fila.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"]) //FILTRANDO MULTIRIESGO
                                      select fila).FirstOrDefault();
                        if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                        {
                            deshabilitarSelSeguro("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo seguro");
                            return;
                        }
                        else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                        {
                            deshabilitarSelSeguro("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".");
                            return;
                        }
                    }

                    //VERIFICAR QUE EN LOS DATOS DE DIRECCION PRINCIPAL, EL CLIENTE TENGA LOS CINCO CAMPOS AGREGADOS EN ESTE REQUERIMIENTO
                    DataTable tbDirCli = new clsCNDirecCli().ListaDirCli(objSolicitudCreditoCargaSeguro.idCli);
                    DataRow ieRegistro = (from fila in tbDirCli.AsEnumerable()
                                          where fila.Field<bool>("lDirPrincipal") == true
                                          select fila).FirstOrDefault();
                    if (ieRegistro == null)
                    {
                        deshabilitarSelSeguro("No tiene registrado una dirección. No puedes seleccionar este seguro.");
                        return;
                    }
                    else
                    {
                        bool tieneCamposInvalidos = tbDirCli.AsEnumerable().Any(row =>
                        {
                            int nAñoConstruccion = Convert.ToInt32(string.IsNullOrEmpty(row["nAñoConstruccion"].ToString()) ? 0 : row["nAñoConstruccion"]);
                            int nPisos = Convert.ToInt32(string.IsNullOrEmpty(row["nPisos"].ToString()) ? 0 : row["nPisos"]);
                            string nSotanos = row["nSotanos"].ToString();
                            int nIdTipoEstructura = Convert.ToInt32(string.IsNullOrEmpty(row["nIdTipoEstructura"].ToString()) ? 0 : row["nIdTipoEstructura"]);
                            int nIdUsoDelPredio = Convert.ToInt32(string.IsNullOrEmpty(row["nIdUsoDelPredio"].ToString()) ? 0 : row["nIdUsoDelPredio"]);

                            return nAñoConstruccion == 0 || nAñoConstruccion < Convert.ToInt32(clsVarApl.dicVarGen["nAnioMinimoConstruccion"]) || nPisos == 0 || string.IsNullOrEmpty(nSotanos) || nIdTipoEstructura == 0 || nIdUsoDelPredio == 0;
                        });

                        if (tieneCamposInvalidos)
                        {
                            deshabilitarSelSeguro("Primero actualiza la dirección y completa los datos exigidos para el seguro multiriesgo.");
                            return;
                        }
                    }
                }

                objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Select(item =>
                {
                    item.lVigente = true; return item;
                }).ToList();
            }

            #region PlanesDeSeguro
            else if (lstPaqueteSeguros.Count > 0)
            {
                if (Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && lstPaqueteSeguros.Select(p => p.idTipoSeguro).ToList().Contains(objSolicitudCreditoSeguro.idTipoSeguro))
                {
                    //VERIFICAR QUE SEA CLIENTE NATURAL
                    if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                    {
                        deshabilitarSelSeguro("Los planes de seguro solo se puede vender a personas naturales.");
                        return;
                    }

                    //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                    if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                    {
                        DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                                      select fila).FirstOrDefault();
                        if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                        {
                            deshabilitarSelSeguro("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro");
                            return;
                        }
                        else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                        {
                            deshabilitarSelSeguro("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".");
                            return;
                        }
                    }

                    if (!validarDuplicidadPaqueteSeguros())
                    {
                        //bool estadoSeleccionado = objSolicitudCreditoCargaSeguro.lEsDesembolso ? Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) : !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value);
                        deshabilitarSelSeguro(string.Format(clsVarApl.dicVarGen["cAlertaMultiplePlanesSeleccionado"], clsVarApl.dicVarGen["nMaximoPlanesSeguro"]));
                        return;
                    }
                    AsignarPlan(lstPaqueteSeguros.FirstOrDefault(x => x.idTipoSeguro == Convert.ToInt32(dtgCargaSeguros.CurrentRow.Cells["idTipoSeguro"].Value)).idPaqueteSeguro);

                }

                int idTipoSeguroSeleccionado = Convert.ToInt32(dtgCargaSeguros.CurrentRow.Cells["idTipoSeguro"].Value);
                var idPaqueteSeleccionado = lstPaqueteSeguros.FirstOrDefault(x => x.idTipoSeguro == idTipoSeguroSeleccionado);

                if (objSolicitudCreditoCargaSeguro.lEsDesembolso && idPaqueteSeleccionado != null)
                {
                    deshabilitarSelSeguro("El Plan de seguro: " + idPaqueteSeleccionado.cNombreCompleto + " no se puede vender/modificar en el proceso de desembolso. Por favor dirigirse a la Generación de Plan de Pagos.", !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                    dtgCargaSeguros.CurrentRow.ReadOnly = true;
                    return;
                }

                if (!Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && idPaqueteSeleccionado != null && idPaqueteSeleccionado.idPaqueteSeguro == objSolicitudCreditoCargaSeguro.idPaqueteSeguro)
                {
                    AsignarPlan(0, false);
                    if (!objSolicitudCreditoCargaSeguro.lPlanSeguroBD) return;
                    if (objSolicitudCreditoSeguro.idSolicitud > 0 && !ValidarDesactivacionPaquetesSeguros(objSolicitudCreditoSeguro.idTipoSeguro))
                        return;
                }

                if (Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && idPaqueteSeleccionado != null && idPaqueteSeleccionado.idPaqueteSeguro == objSolicitudCreditoCargaSeguro.idPaqueteSeguro)
                {
                    if (objSolicitudCreditoSeguro.idSolicitud > 0 && !ValidarReactivacionPaquetesSeguros(objSolicitudCreditoSeguro))
                        return;
                }
            }
            #endregion

            #region SeguroOncologico
            if (dtgCargaSeguros.CurrentRow != null && Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && objSolicitudCreditoSeguro.idTipoSeguro == idTipoVida)
            {
                cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
                cboSeguroVida.SelectedIndex = 1;
                cargarDatos();
                cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;
            }

            if (dtgCargaSeguros.CurrentRow != null && Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && objSolicitudCreditoSeguro.idTipoSeguro == idTipoOncologico)
            {
                cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                cboSeguroOncologico.SelectedIndex = 1;
                cargarDatos();
                cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;

                //Obten el plazo de cobertura seleccionado en el combo del seguro oncologico (cboSeguroOncologico)
                int idTipoPlanSeleccionado = Convert.ToInt32(cboSeguroOncologico.SelectedValue);

                //Busco el idTipoPlan en el DataSource del combo y obtengo el valor de nMeses validando que no sea null
                object valorMeses = ((DataRowView)cboSeguroOncologico.SelectedItem).Row["nMeses"];

                if (valorMeses != DBNull.Value)
                {
                    int nPlazoCobertura = valorMeses != DBNull.Value ? Convert.ToInt32(valorMeses) : 0;

                    DataTable dtResultado = objCNCreditoCargaSeguro.CNValidarSeguroOncologico(objSolicitudCreditoCargaSeguro.idCli, nPlazoCobertura, 0);

                    if (dtResultado.Rows.Count > 0 && objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                    {
                        if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                        {
                            deshabilitarSelSeguro(dtResultado.Rows[0]["cRespuesta"].ToString(), !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value));
                            cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                            cboSeguroOncologico.SelectedValue = 0;
                            cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
                            return;
                        }
                    }
                }
                else
                {
                    cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                    cboSeguroOncologico.SelectedValue = 0;
                    cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
                    return;
                }
            }

            if (dtgCargaSeguros.CurrentRow != null && !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && objSolicitudCreditoSeguro.idTipoSeguro == idTipoVida)
            {
                cboSeguroVida.SelectedIndexChanged -= cboSeguroVida_SelectedIndexChanged;
                cboSeguroVida.SelectedValue = 0;
                cargarDatos();
                cboSeguroVida.SelectedIndexChanged += cboSeguroVida_SelectedIndexChanged;
            }
            if (dtgCargaSeguros.CurrentRow != null && !Convert.ToBoolean(dtgCargaSeguros.CurrentRow.Cells["lSeleccionado"].Value) && objSolicitudCreditoSeguro.idTipoSeguro == idTipoOncologico)
            {
                cboSeguroOncologico.SelectedIndexChanged -= cboSeguroOncologico_SelectedIndexChanged;
                cboSeguroOncologico.SelectedValue = 0;
                cargarDatos();
                cboSeguroOncologico.SelectedIndexChanged += cboSeguroOncologico_SelectedIndexChanged;
            }
            #endregion

            if (objSolicitudCreditoSeguro.idSolicitudCreditoSeguro != 0)
            {
                if (!objSolicitudCreditoSeguro.lSeleccionado)
                {
                    //validar que no haya sido desmarcado en cola
                    if (objSolicitudCreditoCargaSeguro.lstSegurosDesmarcados != null && objSolicitudCreditoCargaSeguro.lstSegurosDesmarcados.Find(x => x.idSolicitudCreditoSeguro == objSolicitudCreditoSeguro.idSolicitudCreditoSeguro) == null)
                    {
                        string cMensaje = "¿Está seguro que desea desvincular el " + objSolicitudCreditoSeguro.cTipoSeguro + " de la solicitud?";
                        DialogResult drResultado = MessageBox.Show(cMensaje, cTituloForm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drResultado == DialogResult.No)
                        {
                            lstSolicitudCreditoSeguro = lstSolicitudCreditoSeguro.Select(item => { item.lSeleccionado = (item.idSolicitudCreditoSeguro == objSolicitudCreditoSeguro.idSolicitudCreditoSeguro) ? true : item.lSeleccionado; return item; }).ToList();
                            actualizarDatosGridCargaSeguro();
                        }
                    }
                }
            }
            if (SeleccionarSeguro != null)
                SeleccionarSeguro(sender, e);

            ValidarSegurosQueNoSePuedenMarcar();
        }

        private void cboSeguroVida_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoVidaInicial = idTipoPlanVidaSeleccionado > 0 ? idTipoPlanVidaSeleccionado : idTipoVidaInicial;
            idTipoPlanVidaSeleccionado = Convert.ToInt32(cboSeguroVida.SelectedValue);
            objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = rbtAceptaListaSeguro.Checked;
            cargarDatos(idTipoPlanVidaSeleccionado == 0 ? idTipoVida : -1, idTipoVidaInicial);
        }

        private void cboSeguroOncologico_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoOncologicoInicial = idTipoPlanOncologicoSeleccionado > 0 ? idTipoPlanOncologicoSeleccionado : idTipoOncologicoInicial;
            idTipoPlanOncologicoSeleccionado = Convert.ToInt32(cboSeguroOncologico.SelectedValue);
            objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = rbtAceptaListaSeguro.Checked;
            cargarDatos(idTipoPlanOncologicoSeleccionado == 0 ? idTipoOncologico : -1, idTipoOncologicoInicial);
        }

        private decimal ObtenerTotalPrimaPaquetes(decimal nCargoMensual, DataTable dtPlanPago, DateTime dFechaPrimeraCuota, DateTime dFechaDesembolso, int idTipoPeriodoCredito, bool lCuotasConstantes)
        {
            DataTable dtCuotasPaquetesSeguro = objCNPlanPagos.ObtenerDistribucionPorCargoMensual(nCargoMensual, dtPlanPago, dFechaPrimeraCuota, dFechaDesembolso, idTipoPeriodoCredito, lCuotasConstantes);

            decimal nTotalPrima = 0m;
            nTotalPrima = dtCuotasPaquetesSeguro.AsEnumerable().Sum(x => Convert.ToDecimal(x["monto"]));
            return nTotalPrima;
        }

        private void ConSolicitudCargaSeguros_Load(object sender, EventArgs e)
        {
            // --
        }
        #endregion
    }
}