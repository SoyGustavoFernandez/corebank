using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADDeposito
    {
        public DataTable ADCronogramaDeposito()
        {
            return new clsGENEjeSP().EjecSP("DEP_FechaAbono_sp");
        }
        public DataTable ADDatoCuenta(int idcuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_DatoCuenta_sp", idcuenta);
        }
        public DataTable ADOperacionesDep(DateTime dFecha, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("DEP_OperacionesUsuario_sp", dFecha, idUsuario);
        }
        public DataTable ADClientes(int idUsuario, int idPro)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListadoCliente_sp", idUsuario, idPro);
        }
        public DataTable ADEntregaProducto(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("DEP_ReporteEntregaProducto_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADSbsAnexo24(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("DEP_SBSAnexo24_SP", dFecha);
        }
        public DataSet ADAnexo11(DateTime dFechaProceso, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("DEP_rptAnexo11_sp", dFechaProceso, cCodSBS, cAnexo);
        }
        public DataSet ADReporte6E(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_ReporteE6_SP", dFecha, cCodSBS, cAnexo);
        }
        public DataTable ADExtractoCta(int idCuenta, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_ExtractoCuenta_sp", idCuenta, dFechaIni, dFechaFin);
        }
        public DataTable ADDatosExtractoCta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_DtGenExtracCta_sp", idCuenta);
        }
        public DataTable ADDatosExtornos(DateTime dFechaIni, DateTime dFechaFin, int cboAgencia, int idModulo)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListaExtornos_sp", dFechaIni, dFechaFin, cboAgencia, idModulo);
        }
        public DataTable ADDatosExtornosCta(DateTime dFechaInicio, DateTime dFechaFin, int nCuenta)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListarExtornosCta_SP", dFechaInicio, dFechaFin, nCuenta);
        }
        public DataTable ADDatosCtasPorCliente(int nCliente, string nEstadoCta)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListarCtasPorCliente_SP", nCliente, nEstadoCta);
        }
        public DataTable ADDatosReasigPromPorPromotor(DateTime dFecIni ,   DateTime dFecFin , int    idAgeDes ,int idUsuPromotor )
        {
            return new clsGENEjeSP().EjecSP("RPT_ReasignacionPromotor_SP", dFecIni ,   dFecFin ,     idAgeDes , idUsuPromotor);
        }
        public DataTable ADDatosHistReasigPromPorPromotor(int nPromotor,DateTime dFecIni ,   DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("RPT_HistReasigPromPorPromotor_SP", nPromotor, dFecIni, dFecFin);
        }
        //--=========================================================================
        //--Reporte de Compra y Venta de Dolares
        //--=========================================================================
        public DataTable ADDatosCompraVenta(int idAgencia, DateTime dFechaIni, DateTime dFechaFin, int nTipoComVenta, int nEstadoComVenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCompraVenta_Sp", idAgencia, dFechaIni, dFechaFin, nTipoComVenta, nEstadoComVenta);
        }
        public DataTable ADListarTipoComVenta()
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarTipoComVenta_SP");
        }
        public DataTable ADListarEstadoComVenta()
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarEstadoComVenta_SP");
        }
        //--=========================================================================
        //--Reporte de Cuentas Bloqueadas
        //--=========================================================================
        public DataTable ADDatosCtasBloqueadas(int idAgencia, int idMoneda, int idTipBloq, DateTime dFecInicio, DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCtasBloqueadas_Sp", idAgencia, idMoneda, idTipBloq, dFecInicio, dFecFin);
        }

        //--=========================================================================
        //--Reporte de Cuentas Renovadas
        //--=========================================================================
        public DataTable ADDatosCtasRenovadas(string idAgencia, string idMoneda, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCtasRenovadas_Sp", idAgencia, idMoneda, dFechaIni, dFechaFin);
        }

        //Certificado de Ahorros
        public DataTable ADRetornaDatosCerti(int idCuenta, bool lOriginal)
        {
            return new clsGENEjeSP().EjecSP("DEP_RetornaDatosAhorro_sp", idCuenta, lOriginal);
        }

        //Lista los Intervinientes del Depósito
        public DataTable ADRetornaDatosInterv(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarIntervDep_SP", idCuenta);
        }
        public DataTable ADRetornaDatosIntervDetalle(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListaDetalleIntervinientes_SP", idCuenta);
        }


        //Cronograma de Depositos
        public DataTable ADRetornaDatosCronograma(int idCuenta, int idestado)
        {
            return new clsGENEjeSP().EjecSP("DEP_RetornaAhoProgramado_sp", idCuenta, idestado);
        }
        public DataTable CNAperturasCta(string idProduc, DateTime dFechaIni, DateTime dFechaFin, int idZona, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RPT_AperturaCta_sp", idProduc, dFechaIni, dFechaFin, idZona, idAgencia);
        }
        //--=========================================================================
        //--Evolución de Saldos de Ahorros : ADEstadisRangoFecha
        //--=========================================================================
        public DataTable ADEvolucionSaldosAhorros(DateTime dFecIni, DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_EvolucionSaldosAhorros_SP", dFecIni, dFecFin);
        }
        //--=========================================================================
        //--Evolución Mensual de Saldos de Ahorros : ADEstadisRangoFecha
        //--=========================================================================
        public DataTable ADEvolucionMensualSaldosAhorros(DateTime dFecIni, DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_EvolucionSaldosMensualAhorros_SP", dFecIni, dFecFin);
        }
        //--=========================================================================
        //--Reporte de Devengados de AHorros
        //--=========================================================================
        public DataTable ADReporteDevengados(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("DEP_ReporteDevengados_SP", dFecha);
        }

        //--=========================================================================
        //--Reporte de Composición de Cartera de Ahorros
        //--=========================================================================
        public DataTable ADComposicionCartera(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("DEP_ComposicionCartera_SP", dFecha);
        }

        //--=========================================================================
        //--Reporte de Exoneracion de ITF
        //--=========================================================================
        public DataTable ADExoneracionITF(string idProduc, string TipoBusqueda, DateTime dFechaIni, DateTime dFechaFin, int cboAgencia, int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListaExoneracionITF_SP", idProduc, TipoBusqueda, dFechaIni, dFechaFin, cboAgencia, idTipoOperacion);
        }
        //--=========================================================================
        //--Reporte de Cuentas con Tasas Especiales
        //--=========================================================================
        public DataTable ADTasasEspeciales(string idProducto, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RPT_CtsTasasEspeciales_SP", idProducto, idAgencia);
        }
        //--=========================================================================
        //--Reporte de Tipo de Cambio
        //--=========================================================================
        public DataTable ADTipoCambio(string cTpBusqueda, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("RPT_TipoCambio_SP", cTpBusqueda, dFechaIni, dFechaFin);
        }
        //--=========================================================================
        //--Reporte de Traslados de CTS
        //--=========================================================================
        public DataTable ADDatosTrasladosCTS(DateTime dFecInicio, DateTime dFecFin, string Agencias, string EstadoSolic1)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListarTraslCTS_SP", dFecInicio, dFecFin, Agencias, EstadoSolic1);
        }
        
        //--=========================================================================
        //-- Anexo 13 - FENACREP
        //--=========================================================================
        public DataTable ADFenacrepAnexo13(DateTime dFecProces)
        {
            return new clsGENEjeSP().EjecSP("RPT_FenacrepAnexo13_SP", dFecProces);
        }

        //--=========================================================================
        //-- Anexo 17A (FSD) - SBS
        //--=========================================================================
        public DataSet ADSBSAnexo17_G(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo17_G_sp", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADSBSAnexo17AParteA(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_SBSAnexo17AParteA_SP", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADSBSAnexo17AParteB(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_SBSAnexo17AParteB_SP", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADSBSAnexo17AParteC(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_SBSAnexo17AParteC_SP", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADSBSAnexo17AParteD(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_SBSAnexo17AParteD_SP", dFecha, cCodSBS, cAnexo);
        }

        public DataTable ADAnexo17Afecciones(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarAfeccionFSD_SP", dFecha);
        }

        //--=========================================================================
        //-- Anexo 17B (FSD) - SBS
        //--=========================================================================
        public DataSet ADSBSAnexo17B(string cCodInstFin, int idLimiteFSD, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_SBSAnexo17B_SP", cCodInstFin, idLimiteFSD, cCodSBS, cAnexo);
        }
        //--=========================================================================
        //-- Certificado Deposito Plazo
        //--=========================================================================
        public DataTable ADDatosCertificadoDP(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_RetornaDatosAhorro_sp", idCuenta);
        }
        //--=========================================================================
        //-- Orden de Apertura Ahorro Plazo
        //--=========================================================================
        public DataTable ADDatosOrden(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_DatosOrdenDP_sp", idCuenta);
        }
        //--=========================================================================
        //-- Datos Intervinientes de cuenta de Transferencia
        //--=========================================================================
        public DataTable ADDatosCueTransfer(int idCuenta, string cNroCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListaCueTransfer_sp", idCuenta, cNroCuenta);
        }
        //--=========================================================================
        //-- Listado de clientes principales de ahorros
        //--=========================================================================
        public DataTable ADListadoCliPrin(DateTime dFechaCorte, int nTop)
        {
            return new clsGENEjeSP().EjecSP("DEP_TopTenSociosAho_sp", dFechaCorte, nTop);
        }
        public DataTable ADDetalleTransaccion(int idKardex, bool nIndSaldo)
        {
            return new clsGENEjeSP().EjecSP("DEP_DetalleTrx_sp", idKardex, nIndSaldo);
        }
		//--=========================================================================
        //-- Reportes de Plazo Fijo
        //--=========================================================================
        public DataTable ADRptCuentasPlazosFijoxVencer(DateTime dFecSis, int idAgencia, int idMoneda, int nNumDiasAntes, int lindRen)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptCuentasPlazosFijoxVencer_Sp", dFecSis, idAgencia, idMoneda, nNumDiasAntes, lindRen);
        }
        public DataTable ADRptCuentasPlazosFijoxRenovaAuto(DateTime dFecSis, int idAgencia, int idMoneda, int nNumDiasAntes)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptCuentasPlazosFijoxRenovaAuto_Sp", dFecSis, idAgencia, idMoneda, nNumDiasAntes);
        }

        public DataTable ADSaldoAHo(int idMoneda, string idProduc, int idAgencia, DateTime dFecProceso)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptSaldosHistAhorros_Sp", idMoneda, idProduc, idAgencia, dFecProceso);
                                            
        }
        public DataTable ADDetSaldoAHo(int idMoneda, string idProduc, int idAgencia, DateTime dFecProceso)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptDetalleSaldosHistAhorros_Sp", idMoneda, idProduc, idAgencia, dFecProceso);

        }
        public DataTable ADSaldoLinea(int idMoneda, string idProduc, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptSaldosLineaAhorros_Sp", idMoneda, idProduc, idAgencia);
        }
        public DataTable ADDetSaldoLinea(int idMoneda, string idProduc, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptDetalleSaldosLineaAhorros_Sp", idMoneda, idProduc, idAgencia);
        }
        public DataTable ADRptSaldosProductoHistAhorros(DateTime dFecha, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptSaldosProductoHistAhorros_Sp", dFecha, idAgencia);
        }

        public DataTable ADRptSaldosOnlineProductoAhorros(int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptSaldosOnlineProductoAhorros_Sp", idAgencia);
        }

        public DataTable ADRptCuentasPlazosFijosxProducto(int idAgencia, int idMoneda, int idEstado)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCuentasPlazosFijosRangos_Sp", idAgencia, idMoneda, idEstado);
        }

        public DataTable ADRptCuentasPlazosFijosxRangos(int idAgencia, int idMoneda, int idEstado, int idPlazo)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCtasPlazosFijosRangos_Sp", idAgencia, idMoneda, idEstado, idPlazo);
        }
        //--=========================================================================
        //-- Registro del numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable ADRptRegistroImpresionesExtCta(int idCuenta, DateTime dFecImpresion, int idUsuImprime, int idAgeImprime)
        {
            return new clsGENEjeSP().EjecSP("DEP_RegistraImpresionExtCueta_SP", idCuenta, dFecImpresion, idUsuImprime, idAgeImprime);
        }
        //--=========================================================================
        //-- obtiene el numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable ADRptObtieneNroImpExtractoCta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("Dep_ObtenerNroImpresionExtCta_SP", idCuenta);
        }
        //--=========================================================================
        //-- obtiene la dirección de correo electronico la cuenta
        //--=========================================================================
        public DataTable ADObtieneDirecCorreoExtractoCta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("Dep_ObtenerDirecCorreoExtCta_SP", idCuenta);
        }
        //--=========================================================================
        //-- obtiene el numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable ADRptDepositoMasivo(int idCliente, int idMoneda, int idAgencia, int idProducto, string cNombreArc)
        {
            return new clsGENEjeSP().EjecSP("DEP_rptDetDepositoMasivo_SP", idCliente, idMoneda, idAgencia, idProducto, cNombreArc);
        }
        //--=========================================================================
        //-- obtiene el resultado del reporte gerencial por oficina
        //--=========================================================================
        public DataTable ADRptGerencialXOfi(int idAgencia, int idMoneda, DateTime dFecProc, int idProducto)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptConcentracionAhoOfiMonPro_Sp", idMoneda, idProducto, idAgencia, dFecProc);
        }

        //--=========================================================================
        //-- Reporte de Compra Venta segun Tipo de Cambio
        //--=========================================================================
        public DataTable ADRptCompraVentaTipoCambio(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCompraVentaTipoCambio_SP", dFechaInicio, dFechaFinal);
        }

        //--=========================================================================
        //-- Reporte de Concentración de Ahorros por Moneda
        //--=========================================================================
        public DataTable ADRptConAhoMonTpAho(DateTime dFechaCorte)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptConAhoMonTpAho_SP", dFechaCorte);
        }

        //--=========================================================================
        //-- Reporte de Concentración de Movimientos de Ahorros
        //--=========================================================================
        public DataTable ADRptConMovMonTpAho(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptConMovMonTpAho_SP", dFechaInicio, dFechaFinal);
        }
        //--=========================================================================
        //-- obtiene el resultado del reporte resumen de concentracion de ahorros por moneda y tipo de producto
        //--=========================================================================
        public DataTable ADRptConAhoMonTipProRes(int idMoneda, DateTime dFecProc, int idProducto)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptConcentracionAhoMonProRes_Sp", idMoneda, idProducto,  dFecProc);
        }
        public DataTable ADExtractoCtaDetalle(int idCuenta, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_ExtractoCuentaDet_sp", idCuenta, dFechaIni, dFechaFin);
        }
        public DataTable ADListaTalonarioPorEstado(int idAgeDestino, int idAgeMod, int idTipoValorado, int idEstaVal)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListaTalonarioPorEstado_SP", idAgeDestino, idAgeMod , idTipoValorado,	idEstaVal );
        }
        //--=========================================================================
        //-- Reporte Detalle de Solicitud de Cambio de Titulares de Cuenta
        //--=========================================================================
        public DataTable ADRptDetalleSolCambioTitular(int idSolicitud, int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptDetalleSolCambioTitular_SP", idSolicitud, idCuenta);            
        }
        //--=========================================================================
        //-- Reporte Extracto de Cuenta para Envio por Correo Electronico
        //--=========================================================================
        public DataTable ADRptExtCtaCorreo(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_DtGenExtracCta_sp", idCuenta);            
        }
        public DataTable ADRptMovimientosExtCtaCorreo(int idCuenta, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_ExtractoCuenta_sp", idCuenta, dFechaInicio, dFechaFin);
        }
        public DataSet ADFormato302(DateTime dFechaProceso, string cCodSBS, string cAnexo)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Formato302_sp", dFechaProceso, cCodSBS, cAnexo);
        }

        #region reporte semestral SUNAT
        public DataTable ADObtenerDatosTitular(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("RPT_ObtenerReporteSUNATDatosTitular_SP", parametros);
        }

        public DataTable ADObtenerDatosCuenta(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("RPT_ObtenerReporteSUNATDatosCuenta_SP", parametros);
        }

        public DataTable ADObtenerCuentasPorTitular(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("RPT_ObtenerReporteSUNATCuentasPorTitular_SP", parametros);
        }
        #endregion
    }
}
