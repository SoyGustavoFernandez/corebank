using SolIntEls.GEN.Helper;
using System;
using System.Data;
using EntityLayer;


namespace CRE.AccesoDatos
{
    public class clsADCartaFianza
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable obtenerCaracteristicasCartaFianza(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarCartaFianza_SP", idSolicitud);
        }

        public DataTable actualizarCaracteristicasCartaFianza(int idCartaFianza,int idSolicitud, int idTipoCartaFianza, int idUsuBeneficiario, string cProcesoSelec)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCartaFianza_SP", idCartaFianza, idSolicitud, idTipoCartaFianza, idUsuBeneficiario, cProcesoSelec);
        }

        public DataTable actualizarSustentoCartaFianza(int idCartaFianza, decimal dMontoPropuesto, int nPlazo, string dFechaInicio, string cGiroNegocio, string cDestino, string cGarantia, string cConclusiones)
        {
            return objEjeSp.EjecSP("CRE_ActualizarSustentoCartaFianza_SP", idCartaFianza, dMontoPropuesto, nPlazo, dFechaInicio, cGiroNegocio, cDestino, cGarantia, cConclusiones);
        }

        public DataTable listarGarantias(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarGarantiasCartaFianza_sp", idSolicitud);
        }

        public DataTable obtenerDatosClienteREAC(int idSolicitud, int idCliente, int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosClienteREAC", idSolicitud, idCliente, idProducto);
        }

        public DataTable obtenerDatosClienteREAC(int idCartaFianza)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosClienteREACxCodigo_SP", idCartaFianza);
        }

        public DataTable listarIntervinientes(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_LisIntervxSolREAC_SP", idSolicitud);
        }

        public DataTable obtenerDatosCartaFianzaAprobada(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCartaFianzaAprobada_SP", idSolicitud);
        }
        public DataTable ListarComisionesCartaFianza(int idMoneda, int idProducto,  int idTipopersona ,Decimal nMonto , int nPlazo, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarOtrasComisionesCartaFianza_SP", idMoneda, idProducto, idTipopersona, nMonto, nPlazo, idAgencia);
        }

        public DataTable pagarComision(int idCartaFianza, Decimal nComision, Decimal nItf, Decimal nRedondeoFavCli, DateTime dFecSystem, int idUsuario, int idAgencia, Decimal nItfNormal, Decimal nComisionSinAfectacion, bool lModificaSaldoLinea, int idMoneda_Saldo, int idTipoTransac)
        {
            return objEjeSp.EjecSP("CRE_CobrarComisionCartaFianza_SP", idCartaFianza, nComision, nItf, nRedondeoFavCli, dFecSystem, idUsuario, idAgencia, nItfNormal, nComisionSinAfectacion,
                                                       lModificaSaldoLinea, idMoneda_Saldo, idTipoTransac);
        }

        public DataTable listarCartasFianza(int idEstado)
        {
            return objEjeSp.EjecSP("CRE_ListarCartaFianzaXEstado_SP", idEstado);
        }

        public DataTable obtenerCartaFianzaImprimir(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCartaFianzaImpresion_SP", idSolicitud);
        }

        public DataTable obtenerConsorciados(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarConsorcioCartaFianza_SP", idSolicitud);
        }

        public DataTable emitirCartaFianza(int idSolicitud, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_EmitirCartaFianza_SP", idSolicitud,idUsuario);
        }

        public DataTable listarCartasFianzaAprobadas(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_LisCartaFianzaAprobadas_SP", idUsuario);
        }

        public DataTable obtenerCartaFianza(int idCartaFianza)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCartaFianzaAprobadaConDatos_SP", idCartaFianza);
        }

        public DataTable listarDetalleGarantias(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarDetalleGarantiasCartaFianza_sp", idSolicitud);
        }

        public DataTable listarAprobadores(int idSolAproba)
        {
            return objEjeSp.EjecSP("CRE_LisAprobaSolicitudCartaFianza_SP", idSolAproba);
        }

        public DataTable listarDetalleComisiones(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarDetalleComisionesCartaFianzas_sp", idSolicitud);
        }

        public DataTable aprobarCartaFianza(int idCartaFianza,int idSolicitud, int idSolAproba, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_AprobarCartaFianza_SP", idCartaFianza, idSolicitud, idSolAproba, idUsuario);
        }

        public DataTable listaExtornosAprobados(int idUsuario, DateTime dFecSystem)
        {
            return objEjeSp.EjecSP("CRE_LisExtornosComisionesAprobadas_SP", idUsuario, dFecSystem);
        }

        public DataTable obtenerOperacionAExtornar(int idKardex)
        {
            return objEjeSp.EjecSP("CRE_ObtenerPagoComisionCartaFianza_SP", idKardex);
        }

        public DataTable extornarComision(int idKardex, DateTime dFecSystem, int idSolicitoAproba, bool lModificaSaldoLinea, int idTipoTransac, int idAgencia, int idMoneda, decimal nMontoOpe, int IdUsuario)
        {
            return objEjeSp.EjecSP("CRE_ExtornarComisionCartaFianza_SP", idKardex, dFecSystem, idSolicitoAproba, lModificaSaldoLinea, idTipoTransac, idAgencia, idMoneda, nMontoOpe, IdUsuario);
        }

        public DataTable obtenerCartaFianzaXCliente(int idCliente, int lRenovado)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCartaFianzaVigenteXCli_SP", idCliente, lRenovado);
        }

        public DataTable renovarCartaFianza(int idCartaFianza, int nPlazoNuevo)
        {
            return objEjeSp.EjecSP("CRE_RenovarCartaFianza_SP", idCartaFianza, nPlazoNuevo);
        }

        public DataTable listarReimpresionCartasFianzaAprobadas(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListarReimpresionAprobCF_sp", idUsuario);
        }

        public DataTable reimpresionCartaFianza(int idCartaFianza, int idSolAproba, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ReimpresionCartaFianza_sp", idCartaFianza, idSolAproba, idUsuario);
        }

        public DataTable obtenerReporteCartasFianza(DateTime dtDesde, DateTime dtA)
        {
            return objEjeSp.EjecSP("CRE_ListarCartasConGarantia_sp", dtDesde, dtA);
        }

        public DataTable obtenerReporteComisionesDiferidasCF(DateTime dtFecha)
        {
            return objEjeSp.EjecSP("CRE_ListarCartasComisionDiferida_sp", dtFecha);
        }

        public DataTable obtenerCartasFianzasVencidas()
        {
            return objEjeSp.EjecSP("CRE_ListarCartasFianzasVencidas_sp");
        }

        public DataTable obtenerCartasFianzasPorVencer()
        {
            return objEjeSp.EjecSP("CRE_ListarCartasFianzasProxVencer_sp");
        }

        public DataTable ValidarDatosCompletos(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidarDatosCompletosCartaFianza_SP", idSolicitud);
        }

        public DataTable ActualizarEstadoCartaFianza(int idSolicitud, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEstadoCartaFianza_SP", idSolicitud, idEstado);
        }

        public DataTable ObtenerDatosBasicos(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtDatosBasicoCartaFianza_SP", idSolicitud);
        }

        public DataTable cancelarCartaFianza(int idCartaFianza, int idMotivo, string cDocumentoRef, string cMotivoSustento, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_CancelarCartaFianza_SP", idCartaFianza, idMotivo, cDocumentoRef, cMotivoSustento, dFechaSistema, idUsuario);
        }

        public DataTable obtenerCartaFianzaCancelada(int idCartaFianza)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCartaFianzaCancelada_SP", idCartaFianza);
        }

        public DataTable obtenerGarantiasDetalle(int idCartaFianza, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_LstGaranYTitularesCF_SP", idCartaFianza, lVigente);
        }

        public DataTable DesvinculaGarantiasYDesbloqueaDep(int idCartaFianza, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_LibGarantiasYDesbloDep_SP", idCartaFianza, dFechaSistema, idUsuario);
        }

        public clsDBResp EnviarPropCartaFianza(int idAgencia, int idCli, int idTipOpe, int idProducto, decimal nValAproba,
                                                    int idDocument, int nOrdenAproba, string cSustento,string xmlCreditoProp,
                                                    DateTime dFecha, int idUsuario)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_EnviarPropuestaCartaFianza_Sp", idAgencia, idCli, idTipOpe, idProducto, nValAproba,
                                                    idDocument, nOrdenAproba, cSustento, xmlCreditoProp,
                                                    dFecha, idUsuario);
            return  new clsDBResp(dtResult);
        }
    }
}
