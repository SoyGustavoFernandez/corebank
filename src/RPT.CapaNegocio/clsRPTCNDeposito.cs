using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNDeposito
    {
        clsRPTADDeposito ADDeposito = new clsRPTADDeposito();

        public DataTable CNCronogramaDeposito()
        {
            return ADDeposito.ADCronogramaDeposito();
        }
        public DataTable CNDatoCuenta(int idCuenta)
        {
            return ADDeposito.ADDatoCuenta(idCuenta);
        }
        public DataTable CNOperacionesDep(DateTime dFecha, int idUsuario)
        {
            return ADDeposito.ADOperacionesDep(dFecha, idUsuario);
        }
        public DataTable CNClientes(int idUsuario, int idPro)
        {
            return ADDeposito.ADClientes(idUsuario, idPro);
        }
        public DataTable CNEntregaProducto(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADDeposito.ADEntregaProducto(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNSbsAnexo24(DateTime dFecha)
        {
            return ADDeposito.ADSbsAnexo24(dFecha);
        }
        public DataSet CNAnexo11(DateTime dFechaProceso, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADAnexo11(dFechaProceso, cCodSBS, cAnexo);
        }
        public DataSet CNReporte6E(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADReporte6E(dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNExtractoCta(int idCuenta, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADDeposito.ADExtractoCta(idCuenta, dFechaIni, dFechaFin);
        }
        
        public DataTable CNDatosExtractoCta(int idCuenta)
        {
            return ADDeposito.ADDatosExtractoCta(idCuenta);
        }
        public DataTable CNDatosExtornos(DateTime dFechaIni, DateTime dFechaFin, int cboAgencia,int idModulo)
        {
            return ADDeposito.ADDatosExtornos(dFechaIni, dFechaFin, cboAgencia, idModulo);
        }
        public DataTable ADDatosExtornosCta(DateTime dFechaInicio, DateTime dFechaFin, int nCuenta)
        {
            return ADDeposito.ADDatosExtornosCta(dFechaInicio, dFechaFin, nCuenta);
        }
        public DataTable ADDatosCtasPorCliente(int nCliente, string nEstadoCta)
        {
            return ADDeposito.ADDatosCtasPorCliente(nCliente, nEstadoCta);
        }
        public DataTable ADDatosReasigPromPorPromotor(DateTime dFecIni ,   DateTime dFecFin , int    idAgeDes ,int idUsuPromotor)
        {
            return ADDeposito.ADDatosReasigPromPorPromotor( dFecIni ,    dFecFin ,     idAgeDes , idUsuPromotor);
        }
        public DataTable ADDatosHistReasigPromPorPromotor(int nPromotor,DateTime dFecIni ,   DateTime dFecFin)
        {
            return ADDeposito.ADDatosHistReasigPromPorPromotor(nPromotor, dFecIni ,    dFecFin  );
        }
        //--=========================================================================
        //--Reporte de Compra y Venta de Dolares
        //--=========================================================================
        public DataTable CNDatosCompraVenta(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,int  nTipoComVenta, int nEstadoComVenta)
        {
            return ADDeposito.ADDatosCompraVenta(idAgencia, dFechaIni, dFechaFin, nTipoComVenta, nEstadoComVenta);
        }
        public DataTable CNListarTipoComVenta()
        {
            return ADDeposito.ADListarTipoComVenta();
        }
        public DataTable CNListarEstadoComVenta()
        {
            return ADDeposito.ADListarEstadoComVenta();
        }
        //--=========================================================================
        //--Reporte de Cuentas Bloqueadas
        //--=========================================================================
        public DataTable CNDatosCtasBloqueadas(int idAgencia, int idMoneda, int idTipBloq, DateTime dFecInicio, DateTime dFecFin)
        {
            return ADDeposito.ADDatosCtasBloqueadas(idAgencia, idMoneda, idTipBloq, dFecInicio, dFecFin);
        }

        //--=========================================================================
        //--Reporte de Cuentas Renovadas
        //--=========================================================================
        public DataTable CNDatosCtasRenovadas(string idAgencia, string idMoneda, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADDeposito.ADDatosCtasRenovadas(idAgencia, idMoneda, dFechaIni, dFechaFin);
        }

        //Certificado de Ahorros
        public DataTable CNRetornaDatosCerti(int idCuenta,bool lOriginal)
        {
            return ADDeposito.ADRetornaDatosCerti(idCuenta, lOriginal);
        }
        
        //Lista de Intervinientes en el Depósito
        public DataTable CNRetornaDatosInterv(int idCuenta)
        {
            return ADDeposito.ADRetornaDatosInterv(idCuenta);
        }
        public DataTable CNRetornaDatosIntervDetalle(int idCuenta)
        {
            return ADDeposito.ADRetornaDatosIntervDetalle(idCuenta);
        }

        //Cronograma de Depositos
        public DataTable CNRetornaDatosCronograma(int idCuenta, int idestado)
        {
            return ADDeposito.ADRetornaDatosCronograma(idCuenta, idestado);
        }
        public DataTable CNAperturasCta(string idProduc, DateTime dFechaIni, DateTime dFechaFin, int idZona, int idAgencia)
        {
            return ADDeposito.CNAperturasCta(idProduc, dFechaIni, dFechaFin, idZona, idAgencia);
        }
        //--=========================================================================
        //--Evolución de Saldos de Ahorros : CNEstadisRangoFecha
        //--=========================================================================
        public DataTable CNEvolucionSaldosAhorros(DateTime dFecIni, DateTime dFecFin)
        {
            return ADDeposito.ADEvolucionSaldosAhorros(dFecIni, dFecFin);
        }
        //--=========================================================================
        //--Evolución Mensual de Saldos de Ahorros : CNEstadisRangoFecha
        //--=========================================================================
        public DataTable CNEvolucionMensualSaldosAhorros(DateTime dFecIni, DateTime dFecFin)
        {
            return ADDeposito.ADEvolucionMensualSaldosAhorros(dFecIni, dFecFin);
        }
        //--=========================================================================
        //--Reporte de Devengados de AHorros
        //--=========================================================================
        public DataTable CNReporteDevengados(DateTime dFecha)
        {
            return ADDeposito.ADReporteDevengados(dFecha);
        }

        //--=========================================================================
        //--Reporte de Composición de Cartera de Ahorros
        //--=========================================================================
        public DataTable CNComposicionCartera(DateTime dFecha)
        {
            return ADDeposito.ADComposicionCartera(dFecha);
        }
        //--=========================================================================
        //--Reporte de Cuentas Exoneradas de ITF
        //--=========================================================================
        public DataTable CNExoneracionITF(string idProduc, string TipoBusqueda, DateTime dFechaIni, DateTime dFechaFin, int cboAgencia, int idTipoOperacion)
        {
            return ADDeposito.ADExoneracionITF(idProduc, TipoBusqueda, dFechaIni, dFechaFin, cboAgencia, idTipoOperacion);
        }
        //--=========================================================================
        //--Reporte de Cuentas con Tasas Especiales
        //--=========================================================================
        public DataTable CNTasasEspeciales(string idProducto, int idAgencia)
        {
            return ADDeposito.ADTasasEspeciales(idProducto, idAgencia);
        }
        //--=========================================================================
        //--Reporte de Tipo de Cambio
        //--=========================================================================
        public DataTable CNTipoCambio(string cTpBusqueda, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADDeposito.ADTipoCambio(cTpBusqueda, dFechaIni, dFechaFin);
        }
        //--=========================================================================
        //--Reporte de Traslados de CTS
        //--=========================================================================
        public DataTable CNDatosTrasladosCTS(DateTime dFecInicio, DateTime dFecFin, string Agencias, string EstadoSolic1)
        {
            return ADDeposito.ADDatosTrasladosCTS(dFecInicio, dFecFin, Agencias, EstadoSolic1);
        }
        //--=========================================================================
        //-- Anexo 13 - FENACREP
        //--=========================================================================
        public DataTable CNFenacrepAnexo13(DateTime dFecProces)
        {
            return ADDeposito.ADFenacrepAnexo13(dFecProces);
        }

        //--=========================================================================
        //-- Anexo 17A (FSD) - SBS
        //--=========================================================================
        public DataSet CNSBSAnexo17_G(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17_G(dFecha, cCodSBS, cAnexo);
        }

        public DataSet CNSBSAnexo17AParteA(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17AParteA(dFecha, cCodSBS, cAnexo);
        }

        public DataSet CNSBSAnexo17AParteB(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17AParteB(dFecha, cCodSBS, cAnexo);
        }

        public DataSet CNSBSAnexo17AParteC(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17AParteC(dFecha, cCodSBS, cAnexo);
        }

        public DataSet CNSBSAnexo17AParteD(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17AParteD(dFecha, cCodSBS, cAnexo);
        }

        public DataTable CNAnexo17Afeciones(DateTime dFecha)
        {
            return ADDeposito.ADAnexo17Afecciones(dFecha);
        }

        //--=========================================================================
        //-- Anexo 17B (FSD) - SBS
        //--=========================================================================
        public DataSet CNSBSAnexo17B(string cCodInstFin, int idLimiteFSD, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADSBSAnexo17B(cCodInstFin, idLimiteFSD, cCodSBS, cAnexo);
        }
        //--=========================================================================
        //-- Certificado Deposito Plazo
        //--=========================================================================
        public DataTable CNDatosCertificadoDP(int idCuenta)
        {
            return ADDeposito.ADDatosCertificadoDP( idCuenta);
        }
        //--=========================================================================
        //-- Orden de Apertura Ahorro Plazo
        //--=========================================================================
        public DataTable CNDatosOrden(int idCuenta)
        {
            return ADDeposito.ADDatosOrden(idCuenta);
        }
        //--=========================================================================
        //-- Datos Intervinientes de cuenta de Transferencia
        //--=========================================================================
        public DataTable CNDatosCueTransfer(int idCuenta,string cNroCuenta)
        {
            return ADDeposito.ADDatosCueTransfer(idCuenta, cNroCuenta);
        }
        //--=========================================================================
        //-- Listado de clientes principales
        //--=========================================================================
        public DataTable CNListadoCliPrin(DateTime dFechaCorte, int nTop)
        {
            return ADDeposito.ADListadoCliPrin(dFechaCorte, nTop);
        }
        public DataTable CNDetalleTransaccion(int idKardex, bool nIndSaldo)
        {
            return ADDeposito.ADDetalleTransaccion(idKardex, nIndSaldo);
        }
		//--=========================================================================
        //-- Reportes de Plazo Fijo

        //--=========================================================================
        public DataTable CNRptCuentasPlazosFijoxVencer(DateTime dFecSis, int idAgencia, int idMoneda, int nNumDiasAntes, int lindRen)
        {
            return ADDeposito.ADRptCuentasPlazosFijoxVencer(dFecSis, idAgencia, idMoneda, nNumDiasAntes, lindRen);
        }
        public DataTable CNRptCuentasPlazosFijoxRenovaAuto(DateTime dFecSis, int idAgencia, int idMoneda, int nNumDiasAntes)
        {
            return ADDeposito.ADRptCuentasPlazosFijoxRenovaAuto(dFecSis, idAgencia, idMoneda, nNumDiasAntes);
        }
        //--=========================================================================
        //-- Listado de Saldo de Ahorros Historico
        //--=========================================================================
        public DataTable CNSaldoAHo(int idMoneda, string idProduc, int idAgencia, DateTime dFecProceso)
        {
            return ADDeposito.ADSaldoAHo( idMoneda,  idProduc,  idAgencia, dFecProceso);
        }
        //--=========================================================================
        //-- Listado de Detalle Saldo de Ahorros Historico
        //--=========================================================================
        public DataTable CNDetSaldoAHo(int idMoneda, string idProduc, int idAgencia, DateTime dFecProceso)
        {
            return ADDeposito.ADDetSaldoAHo(idMoneda, idProduc, idAgencia, dFecProceso);
        }
        //--=========================================================================
        //-- Listado de Saldo de Ahorros en Linea
        //--=========================================================================

        public DataTable CNSaldoLinea(int idMoneda, string idProduc, int idAgencia)
        {
            return ADDeposito.ADSaldoLinea(idMoneda, idProduc, idAgencia);
        }
         //--=========================================================================
        //-- Listado de Saldo de Ahorros en Linea
        //--=========================================================================
        public DataTable CNDetSaldoLinea(int idMoneda, string idProduc, int idAgencia)
        {
            return ADDeposito.ADDetSaldoLinea(idMoneda, idProduc, idAgencia);
        }
        
        public DataTable CNRptSaldosProductoHistAhorros(DateTime dFecha, int idAgencia)
        {
            return ADDeposito.ADRptSaldosProductoHistAhorros(dFecha, idAgencia);
        }

        public DataTable CNRptSaldosOnlineProductoAhorros(int idAgencia)
        {
            return ADDeposito.ADRptSaldosOnlineProductoAhorros(idAgencia);
        }

        public DataTable CNRptCuentasPlazosFijosxProducto(int idAgencia, int idMoneda, int idEstado)
        {
            return ADDeposito.ADRptCuentasPlazosFijosxProducto(idAgencia, idMoneda, idEstado);
        }

        public DataTable CNRptCuentasPlazosFijosxRangos(int idAgencia, int idMoneda, int idEstado, int idPlazo)
        {
            return ADDeposito.ADRptCuentasPlazosFijosxRangos(idAgencia, idMoneda, idEstado, idPlazo);
        }

        //--=========================================================================
        //-- Reporte de Compra Venta segun Tipo de Cambio
        //--=========================================================================
        public DataTable CNRptCompraVentaTipoCambio(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return ADDeposito.ADRptCompraVentaTipoCambio(dFechaInicio, dFechaFinal);
        }

        //--=========================================================================
        //-- Reporte de Concentración de Ahorros por Moneda
        //--=========================================================================
        public DataTable CNRptConAhoMonTpAho(DateTime dFechaCorte)
        {
            return ADDeposito.ADRptConAhoMonTpAho(dFechaCorte);
        }

        //--=========================================================================
        //-- Reporte de Concentración de Movimientos de Ahorros
        //--=========================================================================
        public DataTable CNRptConMovMonTpAho(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return ADDeposito.ADRptConMovMonTpAho(dFechaInicio, dFechaFinal);
        }
        //--=========================================================================
        //-- Registro del numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable CNRegistroImpresionesExtCta(int idCuenta, DateTime dFecImpresion, int idUsuImprime, int idAgeImprime)
        {
           return ADDeposito.ADRptRegistroImpresionesExtCta(idCuenta, dFecImpresion, idUsuImprime, idAgeImprime);
        }
        //--=========================================================================
        //-- obtiene el numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable CNObtieneNroImpExtractoCta(int idCuenta)
        {
            return ADDeposito.ADRptObtieneNroImpExtractoCta(idCuenta);
        }
        //--=========================================================================
        //-- obtiene el numero de impresiones del extracto de cuentas
        //--=========================================================================
        public DataTable CNRptDepositoMasivo(int idCliente, int idMoneda, int idAgencia, int idProducto, string cNombreArc)
        {
            return ADDeposito.ADRptDepositoMasivo(idCliente, idMoneda, idAgencia, idProducto, cNombreArc);
        }
        //--=========================================================================
        //-- obtiene la dirección de correo electronico la cuenta
        //--=========================================================================
        public DataTable CNObtieneDirecCorreoExtractoCta(int idCuenta)
        {
            return ADDeposito.ADObtieneDirecCorreoExtractoCta(idCuenta);
        }
        //--=========================================================================
        //-- obtiene el dato del reporte gerencia
        //--=========================================================================
        public DataTable CNRptGerencialXOfi(int idAgencia, int idMoneda, DateTime  dFecProc, int idProducto)
        {
            return ADDeposito.ADRptGerencialXOfi(idAgencia, idMoneda, dFecProc, idProducto);
        }
        //--=========================================================================
        //-- obtiene el dato concentracion de ahorro por moneda y tipo producto , el resumen
        //--=========================================================================
        public DataTable CNRptConAhoMonTipProRes(int idMoneda, DateTime dFecProc, int idProducto)
        {
            return ADDeposito.ADRptConAhoMonTipProRes(idMoneda, dFecProc, idProducto);
        }
        //--=========================================================================
        //-- Reporte Detalle de Solicitud de Cambio de Titulares de Cuenta
        //--=========================================================================
        public DataTable CNRptDetalleSolCambioTitular(int idSolicitud, int idCuenta)
        {
            return ADDeposito.ADRptDetalleSolCambioTitular(idSolicitud, idCuenta);
        }
        //--=========================================================================
        //-- Reporte Extracto de Cuenta para Envio por Correo Electronico
        //--=========================================================================
        public DataTable CNRptDetalleExtCtaCorreo(int idCuenta)
        {
            return ADDeposito.ADRptExtCtaCorreo(idCuenta);
        }
        public DataTable CNRptMovimientosExtCtaCorreo(int idCuenta, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ADDeposito.ADRptMovimientosExtCtaCorreo(idCuenta, dFechaInicio, dFechaFin);
        } 

        public DataTable CNExtractoCtaDetalle(int idCuenta, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADDeposito.ADExtractoCtaDetalle(idCuenta, dFechaIni, dFechaFin);
        }
        public DataTable CNRptListaTalonarioPorEstado(int idAgeDestino, int idAgeMod, int idTipoValorado, int idEstaVal)
        {
            return ADDeposito.ADListaTalonarioPorEstado( idAgeDestino,  idAgeMod,  idTipoValorado,  idEstaVal);
        }
        public DataSet CNFormato302(DateTime dFechaProceso, string cCodSBS, string cAnexo)
        {
            return ADDeposito.ADFormato302(dFechaProceso, cCodSBS, cAnexo);
        }

        #region reporte semestral SUNAT
        public DataTable CNObtenerDatosTitular(DateTime dPeriodo)
        {
            return ADDeposito.ADObtenerDatosTitular(dPeriodo);
        }

        public DataTable CNObtenerDatosCuenta(DateTime dPeriodo)
        {
            return ADDeposito.ADObtenerDatosCuenta(dPeriodo);
        }

        public DataTable CNObtenerCuentasPorTitular(DateTime dPeriodo)
        {
            return ADDeposito.ADObtenerCuentasPorTitular(dPeriodo);
        }
        #endregion
    }
}
