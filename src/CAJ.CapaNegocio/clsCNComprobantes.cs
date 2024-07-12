using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;
namespace CAJ.CapaNegocio
{
   public class clsCNComprobantes
    {
       clsADComprobantes Comprobantes = new clsADComprobantes();
       //=============================================================
       //--Listado de los tipos de Pago
       //=============================================================
       public DataTable CNListaTipoPago()
       {
           return Comprobantes.ADListaTipoPago();
       }
       //=============================================================
       //--Listado de los tipos de comision de comprobantes de Pago
       //=============================================================
       public DataTable BuscarTipoComisionComprPago()
       {
           return Comprobantes.BuscarTipoComisionCompPago();
       }
       //=============================================================
       //--Pago de Comprobante de Caja General
       //=============================================================
       public DataTable GrabarPagoComprobantes(int idComprobante, decimal nMontoComprobante,
          decimal nTotalOtrosDscts, decimal nTotalComisiones,bool lIndAfecRetIGV, decimal nRetncionIgv,
          decimal nImportePagado, decimal nMontoITF, int idMoneda,
          DateTime dFechaPag, int idUsuario, int idAgencia,
          int idTipoPago, int idEntidad, int idCuentaIFI,
          string cNroCheque, string xmlComisiones, string xmlAprobador, string x_cNroCuenta,
          int idTipoTransac, DateTime dfechaOpe, bool lModificaSaldoLinea)
       {
           return Comprobantes.ADGrabarPagoComprobante(idComprobante, nMontoComprobante,nTotalOtrosDscts, nTotalComisiones,
                                                        lIndAfecRetIGV,nRetncionIgv, nImportePagado, nMontoITF, idMoneda,
                                                        dFechaPag, idUsuario, idAgencia,idTipoPago, 
                                                        idEntidad, idCuentaIFI,cNroCheque, xmlComisiones,
                                                        xmlAprobador, x_cNroCuenta, idTipoTransac, dfechaOpe, lModificaSaldoLinea);
       }
       //=============================================================
       //--Extornar Pago de Comprobante de Caja General
       //=============================================================
       public DataTable ExtornoPagoComprobantes(int idComprobante, int idEstadoApro, string cSustento, decimal nMontoOpe,
           DateTime dFechaOpe ,int idUsuOpe, int idMoneda, int idTipoTransac, bool lModificaSaldoLinea)
       {
           return Comprobantes.ADExtornoPagoComprobante(idComprobante, idEstadoApro, cSustento , nMontoOpe,
            dFechaOpe , idUsuOpe, idMoneda, idTipoTransac, lModificaSaldoLinea);
       }
       //=============================================================
       //--Listado de las entidades financientras con cuenta 
       //=============================================================
       public DataTable ListarEntidadesConCuenta(int idTipoPago, int idMoneda)
       {
           return Comprobantes.ADListarEntidadesConCuenta(idTipoPago, idMoneda);
       }
       //=============================================================
       //--Listado de las entidades financientras con cuenta 
       //=============================================================
       public DataTable ListarEntidadesConCuenta(int idTipoPago)
       {
           return Comprobantes.ADListarEntidadesConCuenta(idTipoPago);
       }
       //=============================================================
       //--Listado de las cuentas por entidades financieras con saldo
       //=============================================================
       public DataTable ListarCuentaXEntidades(int idEntidades, int idMoneda)
       {
           return Comprobantes.ADListarCuentaXEntidades(idEntidades, idMoneda);
       }
       //=============================================================
       //--Listado de las cuentas por entidades financieras con saldo
       //=============================================================
       public DataTable ListarCuentaXEntidades(int idEntidades)
       {
           return Comprobantes.ADListarCuentaXEntidades(idEntidades);
       }
       //=============================================================
       //--Buscar comision del comprobante pagado
       //=============================================================
       public DataTable BuscarComisionComproPagado(int idComprobante)
       {
           return Comprobantes.ADBuscarComisionComproPagado(idComprobante);
       }
       //=============================================================
       //--Buscar comision del comprobante pagado
       //=============================================================
       public DataTable BuscarAprobadorComproPagado(int idAgencia)
       {
           return Comprobantes.ADBuscarAprobadorComproPagado(idAgencia);
       }
       //=============================================================
       //--Buscar comision del comprobante pagado
       //=============================================================
       public DataTable BuscarAutorizaComproPagado(int idComprobante)
       {
           return Comprobantes.ADBuscarAutorizaComproPagado(idComprobante);
       }
       //=============================================================
       //--Validar Pago de Comprobantes
       //=============================================================
       public DataTable ValidarPagadoComprobante(int idTipoPago, int idInsFin,
          int idCuentaInsFin, string cNroCheque, decimal nMonto)
       {
           return Comprobantes.ADValidarPagoComprobante(idTipoPago, idInsFin,
           idCuentaInsFin, cNroCheque, nMonto);
       }
       //=============================================================
       //--Buscar Solicitud de Extono de Comprobantes.
       //=============================================================
       public DataTable buscarSolicitudExtorno(int idComprobante, int idUsuOpe, int idAgencia)
       {
           return Comprobantes.ADBuscarSolicitudExtorno(idComprobante, idUsuOpe, idAgencia);
       }
	   //=============================================================
       //--Buscar Cta Detracción Proveedor
       //=============================================================
       public DataTable CNBuscarCtaDetracProveedor(int idCli)
       {
           return Comprobantes.ADBuscarCtaDetracProv(idCli);
       }

       //=============================================================
       //--Registrar Cta Detracción Proveedor
       //=============================================================
       public DataTable CNRegistrarCtaDetracProveedor(int idCli,string cCtaDetracion)
       {
           return Comprobantes.ADRegistrarCtaDetracProv(idCli, cCtaDetracion);
       }

       //=============================================================
       //--Listar Cta Detracción Proveedor
       //=============================================================
       public DataTable CNListarCtaDetracProveedor(int idAge, DateTime dFecIni,DateTime dFecFin,int idMoneda)
       {
           return Comprobantes.ADListarCtaDetracProv(idAge, dFecIni, dFecFin, idMoneda);
       }

       //=============================================================
       //--Listar Cta Detracción Proveedor
       //=============================================================
       public DataTable CNRegistraDetracProveedor(string xmlDetrac,DateTime dFecReg,int idUsu,int idAge)
       {
           return Comprobantes.ADRegistraDetracProv(xmlDetrac, dFecReg, idUsu, idAge);
       }

       //=============================================================
       //--Listar Pago Detracción Proveedor
       //=============================================================
       public DataTable CNListarPagoDetracProveedor(int idAge, DateTime dFecIni, DateTime dFecFin)
       {
           return Comprobantes.ADListarPagoDetracProv(idAge, dFecIni, dFecFin);
       }

       //=============================================================
       //--Listar Grupo Pago Detracción Proveedor
       //=============================================================
       public DataTable CNRptGrupoDetracProveedor(int idGrupo)
       {
           return Comprobantes.ADRptGrupoDetracProv(idGrupo);
       }

       //=============================================================
       //--Listar gasto sin comprobante de movilidad
       //=============================================================
       public DataTable CNRptPlanillaMov(int idCliente, DateTime dFechaIni, DateTime dFechaFin)
       {
           return Comprobantes.ADRptPlanillaMov(idCliente, dFechaIni, dFechaFin);
       }
       //=============================================================
       //--Lista destino de Movilidad por comprobante
       //=============================================================
       public DataTable CNListDestinoMov(int idComprobantePago)
       {
           return Comprobantes.ADListDestinoMov(idComprobantePago);
       }
       //=============================================================
       //--Lista destino de Movilidad por comprobante
       //=============================================================
       public DataTable CNListChequeComprobante(int idComprobantePago)
       {
           return Comprobantes.ADListChequeComprobante(idComprobantePago);
       }
       //=============================================================
       //--Asiento registro de comprobante
       //=============================================================
       public DataTable CNGeneraAsientoCmp(DateTime dFecha, int idNroCmp)
       {
           return Comprobantes.ADGeneraAsientoCmp(dFecha, idNroCmp);
       }
       //=============================================================
       //--Anula asiento asiento de anulado comprobante
       //=============================================================
       public DataTable CNAnulaAsientoCmp(DateTime dFecha, int idNroCmp, int idModulo)
       {
           return Comprobantes.ADAnulaAsientoCmp(dFecha, idNroCmp, idModulo);
       }

       //========================================================================
       //-- Lista la serie y numero en el que encuentra en registro de ventas
       //========================================================================
       public DataTable CNListaSerieNroRegVentas(int idTipoComprobante)
       {
           return Comprobantes.ADListaSerieNroRegVentas(idTipoComprobante);
       }
       //========================================================================
       //-- Obtiene Id y Descripcion de la Opcion SIN PROYECTO
       //========================================================================
       public DataTable CNObtenerDatoSinProyecto()
       {
           return Comprobantes.ADObtenerDatoSinProyecto();
       }
    }
}
