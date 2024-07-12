using CRE.AccesoDatos;
using System;
using System.Data;
using EntityLayer;


namespace CRE.CapaNegocio
{
    public class clsCNCartaFianza
    {
        clsADCartaFianza adCartaFianza = new clsADCartaFianza();
        public DataTable obtenerCaracteristicasCartaFianza(int idSolicitud)
        {
            return adCartaFianza.obtenerCaracteristicasCartaFianza(idSolicitud);
        }

        public DataTable actualizarCaracteristicasCartaFianza(int idCartaFianza, int idSolicitud, int idTipoCartaFianza, int idUsuBeneficiario, string cProcesoSelec)
        {
            return adCartaFianza.actualizarCaracteristicasCartaFianza(idCartaFianza, idSolicitud, idTipoCartaFianza, idUsuBeneficiario, cProcesoSelec);
        }
        /// <summary>
        /// Calcula la comision para la carta fianza
        /// </summary>
        /// <param name="nroDias"></param>
        /// <param name="tasa"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        public Decimal carlcularComision(int nroDias, Decimal tasa, Decimal monto) 
        {
            Decimal comision = 0.00m;
            Decimal tem = Convert.ToDecimal(Math.Pow((1 + (double)tasa), 1 / 12)) - 1;
            Decimal ted = tem / 30;
            nroDias = (nroDias < 60) ? 60 : nroDias;
            comision = ted * nroDias * monto;            
            return comision;
        }

        public DataTable actualizarSustentoCartaFianza(int idCartaFianza, decimal dMontoPropuesto, int nPlazo, string dFechaInicio, string cGiroNegocio, string cDestino, string cGarantia, string cConclusiones)
        {
            return adCartaFianza.actualizarSustentoCartaFianza(idCartaFianza, dMontoPropuesto, nPlazo, dFechaInicio, cGiroNegocio, cDestino, cGarantia, cConclusiones);
        }


        public DataTable listarIntervinientes(int idSolicitud)
        {
            return adCartaFianza.listarIntervinientes(idSolicitud);
        }
        public DataTable obtenerDatosClienteREAC(int idSolicitud, int idCliente, int idProducto)
        {
            return adCartaFianza.obtenerDatosClienteREAC(idSolicitud, idCliente, idProducto);
        }

        public DataTable obtenerDatosClienteREAC(int idCartaFianza)
        {
            return adCartaFianza.obtenerDatosClienteREAC(idCartaFianza);
        }


        public DataTable listarGarantias(int idSolicitud)
        {
            return adCartaFianza.listarGarantias(idSolicitud);
        }

        public DataTable obtenerDatosCartaFianzaAprobada(int idSolicitud)
        {
            return adCartaFianza.obtenerDatosCartaFianzaAprobada(idSolicitud);
        }

        public DataTable ListarComisionesCartaFianza(int idMoneda, int idProducto, int idTipopersona, Decimal nMonto, int nPlazo, int idAgencia)
        {
            return adCartaFianza.ListarComisionesCartaFianza(idMoneda, idProducto, idTipopersona, nMonto, nPlazo, idAgencia);
        }


        public DataTable pagarComision(int idCartaFianza, Decimal nComision, Decimal nItf, Decimal nRedondeoFavCli, DateTime dFecSystem, int idUsuario, int idAgencia, Decimal nItfNormal, Decimal nComisionSinAfectacion, bool lModificaSaldoLinea, int idMoneda_Saldo, int idTipoTransac)
        {
            return adCartaFianza.pagarComision(idCartaFianza, nComision, nItf, nRedondeoFavCli, dFecSystem, idUsuario, idAgencia, nItfNormal, nComisionSinAfectacion,
                                                       lModificaSaldoLinea, idMoneda_Saldo, idTipoTransac);
        }

        public DataTable listarCartasFianza(int idEstado)
        {
            return adCartaFianza.listarCartasFianza(idEstado);
        }

        public DataTable obtenerCartaFianzaImprimir(int idSolicitud)
        {
            return adCartaFianza.obtenerCartaFianzaImprimir(idSolicitud);
        }

        public DataTable obtenerConsorciados(int idSolicitud)
        {
            return adCartaFianza.obtenerConsorciados(idSolicitud);
        }

        public DataTable emitirCartaFianza(int idSolicitud, int idUsuario)
        {
            return adCartaFianza.emitirCartaFianza(idSolicitud, idUsuario);
        }

        public DataTable listarCartasFianzaAprobadas(int idUsuario)
        {
            return adCartaFianza.listarCartasFianzaAprobadas(idUsuario);
        }

        public DataTable obtenerCartaFianza(int idCartaFianza)
        {
            return adCartaFianza.obtenerCartaFianza(idCartaFianza);
        }

        public DataTable obtenerCartaFianzaCancelada(int idCartaFianza)
        {
            return adCartaFianza.obtenerCartaFianzaCancelada(idCartaFianza);
        }


        public DataTable listarDetalleGarantias(int idSolicitud)
        {
            return adCartaFianza.listarDetalleGarantias(idSolicitud);
        }

        public DataTable listarAprobadores(int idSolAproba)
        {
            return adCartaFianza.listarAprobadores(idSolAproba);
        }

        public DataTable listarDetalleComisiones(int idSolicitud)
        {
            return adCartaFianza.listarDetalleComisiones(idSolicitud);
        }

        public DataTable aprobarCartaFianza(int idCartaFianza, int idSolicitud, int idSolAproba, int idUsuario)
        {
            return adCartaFianza.aprobarCartaFianza(idCartaFianza,idSolicitud, idSolAproba, idUsuario);
        }

        public DataTable listaExtornosAprobados(int idUsuario, DateTime dFecSystem)
        {
            return adCartaFianza.listaExtornosAprobados(idUsuario, dFecSystem);
        }

        public DataTable obtenerOperacionAExtornar(int idKardex)
        {
            return adCartaFianza.obtenerOperacionAExtornar(idKardex);
        }

        public DataTable extornarComision(int idKardex, DateTime dFecSystem, int idSolicitoAproba, bool lModificaSaldoLinea, int idTipoTransac, int idAgencia, int idMoneda, decimal nMontoOpe, int IdUsuario)
        {
            return adCartaFianza.extornarComision(idKardex, dFecSystem, idSolicitoAproba, lModificaSaldoLinea, idTipoTransac, idAgencia, idMoneda, nMontoOpe, IdUsuario);
        }

        public DataTable obtenerCartaFianzaXCliente(int idCliente, int lRenovado)
        {
            return adCartaFianza.obtenerCartaFianzaXCliente(idCliente, lRenovado);
        }

        public DataTable renovarCartaFianza(int idCartaFianza, int nPlazoNuevo)
        {
            return adCartaFianza.renovarCartaFianza(idCartaFianza, nPlazoNuevo);
        }

        public DataTable listarReimpresionCartasFianzaAprobadas(int idUsuario)
        {
            return adCartaFianza.listarReimpresionCartasFianzaAprobadas(idUsuario);
        }

        public DataTable reimpresionCartaFianza(int idCartaFianza, int idSolAproba, int idUsuario)
        {
            return adCartaFianza.reimpresionCartaFianza(idCartaFianza, idSolAproba, idUsuario);
        }

        public DataTable obtenerReporteCartasFianza(DateTime dtDesde, DateTime dtA)
        {
            return adCartaFianza.obtenerReporteCartasFianza(dtDesde, dtA);
        }

        public DataTable obtenerReporteComisionesDiferidasCF(DateTime dtFecha)
        {
            return adCartaFianza.obtenerReporteComisionesDiferidasCF(dtFecha);
        }

        public DataTable obtenerCartasFianzasPorVencer()
        {
            return adCartaFianza.obtenerCartasFianzasPorVencer();
        }

        public DataTable obtenerCartasFianzasVencidas()
        {
            return adCartaFianza.obtenerCartasFianzasVencidas();
        }

        public DataTable ValidarDatosCompletos(int idSolicitud)
        {
            return adCartaFianza.ValidarDatosCompletos(idSolicitud);
        }

        public DataTable ActualizarEstadoCartaFianza(int idSolicitud, int idEstado)
        {
            return adCartaFianza.ActualizarEstadoCartaFianza(idSolicitud, idEstado);
        }

        public DataTable ObtenerDatosBasicos(int idSolicitud)
        {
            return adCartaFianza.ObtenerDatosBasicos(idSolicitud);
        }

        public DataTable cancelarCartaFianza(int idCartaFianza, int idMotivo, string cDocumentoRef, string cMotivoSustento, DateTime dFechaSistema, int idUsuario)
        {
            return adCartaFianza.cancelarCartaFianza(idCartaFianza, idMotivo, cDocumentoRef, cMotivoSustento, dFechaSistema, idUsuario);
        }

        public DataTable obtenerGarantiasDetalle(int idCartaFianza, bool lVigente)
        {
            return adCartaFianza.obtenerGarantiasDetalle(idCartaFianza, lVigente);
        }

        public DataTable DesvinculaGarantiasYDesbloqueaDep(int idCartaFianza, DateTime dFechaSistema, int idUsuario)
        {
            return adCartaFianza.DesvinculaGarantiasYDesbloqueaDep(idCartaFianza, dFechaSistema, idUsuario);
        }

        public clsDBResp EnviarPropCartaFianza(int idAgencia, int idCli, int idTipOpe, int idProducto, decimal nValAproba,
                                                    int idDocument, int nOrdenAproba, string cSustento, string xmlCreditoProp,
                                                    DateTime dFecha, int idUsuario)
        {
            return adCartaFianza.EnviarPropCartaFianza(idAgencia, idCli, idTipOpe, idProducto, nValAproba,
                                                    idDocument, nOrdenAproba, cSustento, xmlCreditoProp,
                                                    dFecha, idUsuario);
        }
    }
}
