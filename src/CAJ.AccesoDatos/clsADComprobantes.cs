using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;

namespace CAJ.AccesoDatos
{
  public  class clsADComprobantes
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
      //=============================================================
      //--Listado de los tipos de Pago
      //=============================================================
      public DataTable ADListaTipoPago()
      {
          return objEjeSp.EjecSP("CAJ_RetModalidadPago_Sp");
      }
      //=============================================================
      //--Buscar Tipo de Comision CPG.
      //=============================================================
      public DataTable BuscarTipoComisionCompPago()
      {
          return objEjeSp.EjecSP("CAJ_BuscarTipoComisionCompPago_sp");
      }
      //=============================================================
      //--Grabar Pago de Comprobante.
      //=============================================================
      public DataTable ADGrabarPagoComprobante(int idComprobante, decimal nMontoComprobante	,
          decimal nTotalOtrosDscts, decimal nTotalComisiones, bool lIndAfecRetIGV ,decimal nRetncionIgv,
          decimal nImportePagado	,   decimal nMontoITF		,   int idMoneda			,
          DateTime dFechaPag		,   int	idUsuario			,   int idAgencia			,
          int idTipoPago			,   int idEntidad			,   int idCuentaIFI		    ,
          string cNroCheque			,   string xmlComisiones    ,   string xmlAprobador     , 
          string x_cNroCuenta       ,   int idTipoTransac       ,   DateTime dfechaOpe      ,
          bool lModificaSaldoLinea  )
      {
          return objEjeSp.EjecSP("CAJ_PagarComprobante_sp", idComprobante,nMontoComprobante	,
                                                            nTotalOtrosDscts, nTotalComisiones, lIndAfecRetIGV,nRetncionIgv,
                                                            nImportePagado	,   nMontoITF		,   idMoneda		,
                                                            dFechaPag		,   idUsuario		,   idAgencia		,
                                                            idTipoPago		,   idEntidad		,   idCuentaIFI		,
                                                            cNroCheque		,   xmlComisiones   ,   xmlAprobador    ,
                                                            x_cNroCuenta    ,   idTipoTransac   ,   dfechaOpe       ,
                                                            lModificaSaldoLinea);
      }
      //=============================================================
      //--Grabar Extono de Pago de Comprobante.
      //=============================================================
      public DataTable ADExtornoPagoComprobante(int idComprobante,int idEstadoApro	,string cSustento, decimal nMontoOpe,
           DateTime dFechaOpe ,int idUsuOpe, int idMoneda, int idTipoTransac, bool lModificaSaldoLinea)
      {
          return objEjeSp.EjecSP("CAJ_ExtornoPagoComprobante_sp", idComprobante, idEstadoApro, cSustento, nMontoOpe,
            dFechaOpe , idUsuOpe, idMoneda, idTipoTransac, lModificaSaldoLinea);
      }
      //=============================================================
      //--listar entidades con cuentas
      //=============================================================
      public DataTable ADListarEntidadesConCuenta(int idTipoPago, int idMoneda)
      {
          return objEjeSp.EjecSP("CAJ_ListaEntidadConCuenta_Sp",idTipoPago,idMoneda);
      }
      //=============================================================
      //--listar entidades con cuentas
      //=============================================================
      public DataTable ADListarEntidadesConCuenta(int idTipoPago)
      {
          return objEjeSp.EjecSP("CAJ_ListaEntidadConCuenta_Sp", idTipoPago, 0);
      }
      //=============================================================
      //--listar cuentas Por Entidades con saldo
      //=============================================================
      public DataTable ADListarCuentaXEntidades(int idCuenta, int idMoneda)
      {
          return objEjeSp.EjecSP("CAJ_ListaCuentaXEntidad_Sp", idCuenta, idMoneda);
      }
      //=============================================================
      //--listar cuentas Por Entidades con saldo
      //=============================================================
      public DataTable ADListarCuentaXEntidades(int idCuenta)
      {
          return objEjeSp.EjecSP("CAJ_ListaCuentaXEntidad_Sp", idCuenta, 0);
      }
      //=============================================================
      //--Buscar comprobante pagado
      //=============================================================
      public DataTable ADBuscarComproPagado(int idComprobante)
      {
          return objEjeSp.EjecSP("CAJ_ListaCuentaXEntidad_Sp", idComprobante);
      }
      //=============================================================
      //--Buscar comision comprobante pagado
      //=============================================================
      public DataTable ADBuscarComisionComproPagado(int idComprobante)
      {
          return objEjeSp.EjecSP("CAJ_ListaComisionPagadoXCPG_Sp", idComprobante);
      }
      //=============================================================
      //--Buscar Aprobador comprobante pagado
      //=============================================================
      public DataTable ADBuscarAprobadorComproPagado(int idAgencia)
      {
          return objEjeSp.EjecSP("CAJ_ListaAprobadorPagoCPG_Sp",idAgencia);
      }
      //=============================================================
      //--Buscar Aprobador comprobante pagado
      //=============================================================
      public DataTable ADBuscarAutorizaComproPagado(int idComprobante)
      {
          return objEjeSp.EjecSP("CAJ_BuscarAutorizaComproPagado_Sp", idComprobante);
      }
      //=============================================================
      //--Validar Pago de Comprobantes
      //=============================================================
      public DataTable ADValidarPagoComprobante(int idTipoPago ,	int idInsFin	,
          int idCuentaInsFin ,string cNroCheque , decimal nMonto )
      {
          return objEjeSp.EjecSP("CAJ_ValidarPagoCPG_Sp",idTipoPago ,	idInsFin	,
           idCuentaInsFin , cNroCheque , nMonto );
      }
      //=============================================================
      //--Buscar Solicitud de Extono de Comprobantes.
      //=============================================================
      public DataTable ADBuscarSolicitudExtorno(int idComprobante, int idUsuOpe,int idAgencia)
      {
          return objEjeSp.EjecSP("CAJ_BuscarSolExtornoPagoCPG_SP", idComprobante, idUsuOpe, idAgencia);
      }
	  //=============================================================
      //--Buscar Cta Detracción Proveedor.
      //=============================================================
      public DataTable ADBuscarCtaDetracProv(int idCli)
      {
          return objEjeSp.EjecSP("CAJ_BuscarCtaDetracProveedor_Sp", idCli);
      }

      //=============================================================
      //--Registrar Cta Detracción Proveedor.
      //=============================================================
      public DataTable ADRegistrarCtaDetracProv(int idCli, string cCtaDetracion)
      {
          return objEjeSp.EjecSP("CAJ_InsertaCtaDetracProveedor_Sp", idCli, cCtaDetracion);
      }

      //=============================================================
      //--Listar Cta Detracción Proveedor.
      //=============================================================
      public DataTable ADListarCtaDetracProv(int idAge, DateTime dFecIni, DateTime dFecFin, int idMoneda)
      {
          return objEjeSp.EjecSP("CAJ_ListaCtaDetraccion_sp", idAge, dFecIni, dFecFin, idMoneda);
      }

      //=============================================================
      //--Registra Detracción Proveedor.
      //=============================================================
      public DataTable ADRegistraDetracProv(string xmlDetrac, DateTime dFecReg, int idUsu, int idAge)
      {
          return objEjeSp.EjecSP("CAJ_RegistraDetracProveedor_sp", xmlDetrac, dFecReg, idUsu, idAge);
      }

      //=============================================================
      //--Listar Cta Detracción Proveedor.
      //=============================================================
      public DataTable ADListarPagoDetracProv(int idAge, DateTime dFecIni, DateTime dFecFin)
      {
          return objEjeSp.EjecSP("CAJ_ListaPagoDetraccion_sp", idAge, dFecIni, dFecFin);
      }

      //=============================================================
      //--Listar Cta Detracción Proveedor.
      //=============================================================
      public DataTable ADRptGrupoDetracProv(int idGrupo)
      {
          return objEjeSp.EjecSP("CAJ_RptGrupoDetraccion_sp", idGrupo);
      }
      //=============================================================
      //--Listar gasto sin comprobante de movilidad
      //=============================================================
      public DataTable ADRptPlanillaMov(int idCliente, DateTime dFechaIni, DateTime dFechaFin)
      {
          return objEjeSp.EjecSP("RPT_PlanillaMovilidadCliente_SP", idCliente, dFechaIni, dFechaFin);
      }
      //=============================================================
      //--Lista destino de Movilidad por comprobante
      //=============================================================
      public DataTable ADListDestinoMov(int idComprobantePago)
      {
          return objEjeSp.EjecSP("CAJ_ListaDestinoMovilidad_SP", idComprobantePago);
      }
      //=============================================================
      //--Lista destino de Movilidad por comprobante
      //=============================================================
      public DataTable ADListChequeComprobante(int idComprobantePago)
      {
          return objEjeSp.EjecSP("CAJ_ListaChequeComprobRegistrado_sp", idComprobantePago);
      }
      //=============================================================
      //--Genera asiento contable en registro de comprobante
      //=============================================================
      public DataTable ADGeneraAsientoCmp(DateTime dFecha, int idNroCmp)
      {
          return objEjeSp.EjecSP("CAJ_GeneraAsiCPGProvisionadosFecha_SP", dFecha, idNroCmp);
      }
      //=============================================================
      //--anula asiento contable si anula comprobante
      //=============================================================
      public DataTable ADAnulaAsientoCmp(DateTime dFecha, int idNroCmp, int idModulo)
      {
          return objEjeSp.EjecSP("CNT_AnulaAsientoTrx_sp", dFecha, idNroCmp, idModulo);
      }

      //=============================================================
      //-- Lista la serie y numero en el que encuentra en registro de ventas
      //=============================================================
      public DataTable ADListaSerieNroRegVentas(int idTipoComprobante)
      {
          return objEjeSp.EjecSP("CAJ_ListaSerieNroRegVentas_SP", idTipoComprobante);
      }

      //========================================================================
      //-- Obtiene Id y Descripcion de la Opcion SIN PROYECTO
      //========================================================================
      public DataTable ADObtenerDatoSinProyecto()
      {
          return objEjeSp.EjecSP("CAJ_ObtenerDatoSinProyecto_SP");
      }
    }
}
