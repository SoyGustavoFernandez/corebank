using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAJ.AccesoDatos;
using System.Data;

namespace CAJ.CapaNegocio
{
    public class clsCNCajaChica
    {
        clsADCajaChica objSql = new clsADCajaChica();

        //=============================================================
        //--Listado de Estados de Caja Chica
        //=============================================================
        public DataTable ListaEstCajaChica()
        {
            return objSql.LisEstCajChi();
        }

        //=============================================================
        //--Listado de Caja Chica por Agencia
        //=============================================================
        public DataTable ListadoCajaChica(int idAge)
        {
            return objSql.LisCajChi(idAge);
        }

        //=============================================================
        //--Registra caja Chica
        //=============================================================
        public DataTable RegistraCajaChica(int idAge, string cNomCajChi, int idMon, Decimal nMontoMax,Decimal nMontoCpg, int idRes)
        {
            return objSql.RegCajChica(idAge, cNomCajChi, idMon, nMontoMax, nMontoCpg, idRes);
        }

        //=============================================================
        //--Actualiza y Elimina Caja Chica
        //=============================================================
        public DataTable ActEliCajaChica(int idCaj, string cNomCajChi, int idMon, Decimal nMontoMax, Decimal nMontoCpg, int idRes, int nOpc)
        {
            return objSql.ActEliCajChica(idCaj, cNomCajChi, idMon, nMontoMax,nMontoCpg, idRes, nOpc);
        }

        //=============================================================
        //--Listado de Caja Chica por Agencia
        //=============================================================
        public DataTable ListaCajaChica(int idAge, int idRes, int idOpc)
        {
            return objSql.LisCajChica(idAge, idRes, idOpc);
        }

        //=============================================================
        //--Datos de Caja Chica
        //=============================================================
        public DataTable DatosCajaChica(int idCaj,int idOpcion)
        {
            return objSql.DatCajChica(idCaj, idOpcion);
        }

        //=============================================================
        //--Registrar Habilitación de Caja Chica
        //=============================================================
        public DataTable RegistraHabCajaChica(int idCajChi, int idRes, int idMon, Decimal /*era double*/nMontoHab, Decimal /*era double*/nMontoItf, Decimal /*era double*/nMonTot,
                                    Decimal /*era double*/nSalAnt, string cSust, DateTime dFecReg, int idUsu, int idAge,
                                   bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objSql.HabCajChica(idCajChi, idRes, idMon, nMontoHab, nMontoItf, nMonTot,
                                    nSalAnt, cSust, dFecReg, idUsu, idAge, lModificaSaldoLinea, idTipoTransac);
        }

        //=============================================================
        //--Retorna Datos de Caja Chica
        //=============================================================
        public DataTable RetDatosCajaChica(int idRec)
        {
            return objSql.RetDatCajChica(idRec);
        }

        //=============================================================
        //--Registrar Inicio de Caja Chica
        //=============================================================
        public DataTable RegistraInicioCajaChica(int idCajChi, int nNroCaj, DateTime dFecReg, int idUsu)
        {
            return objSql.RegIniCajChica(idCajChi, nNroCaj, dFecReg, idUsu);
        }

        //=============================================================
        //--Datos para Cierre de caja Chica
        //=============================================================
        public DataTable DatosCierreCajChica(int idCajChi, int nNroCaj, int idOpc)
        {
            return objSql.DatCieCajChica(idCajChi, nNroCaj, idOpc);
        }

        //=============================================================
        //--Registrar el Cierre de Caja Chica
        //=============================================================
        public DataTable RegistrarCierreCajChica(int idCajChi, int nNroCaj, DateTime dFecReg, int idOpe, int nNroCpg)
        {
            return objSql.RegCieCajChica(idCajChi, nNroCaj, dFecReg, idOpe, nNroCpg);
        }

	//=============================================================
        //--Listar el tipo de comprobantes de pago
        //=============================================================
        public DataTable ListarTipoComprPago(int nOpcion)
        {
            return objSql.ListarTipoComprPago(nOpcion);
        }
        //=============================================================
        //--Listar otros descuentos de comprobantes de pago
        //=============================================================
        public DataTable ListarOtrosDescuentoComprobantes()
        {
            return objSql.ListarOtrosDescuentoComprobantes();
        }

        //=============================================================
        //--Grabar comporbante de pago
        //=============================================================
        public DataTable GuardarComprPgCajChica(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int nidCajChica)
        {
            return objSql.GuardarComprPgCajChica(xmlComprPago,xmlDetComprPago,xmlDescComprPago,nidCajChica);
        }

        public DataTable ListarSubConceptos(int idConcepto)
        {
            return objSql.ListarSubConceptos(idConcepto);
        }

        public DataTable ListarTipoOperacionDetraccion()
        {
            return objSql.ListarTipoOperacionDetraccion();
        }

        public DataTable ListarBienServicioDetraccion(int idTipoOperDetra)
        {
            return objSql.ListarBienServicioDetraccion(idTipoOperDetra);
        }

        public DataTable ListarComprPago(bool lTieneCompr, bool lCpgCajChica, int idTipoComprPago, string cSerie, string cNumero,int idEstCpg, int idComprobante, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objSql.ListarComprPago(lTieneCompr, lCpgCajChica, idTipoComprPago, cSerie, cNumero, idEstCpg, idComprobante, dFechaIni, dFechaFin);
        }

        public DataTable ListarDestinoComprPago(int idAgencia)
        {
            return objSql.ListarDestinoComprPago(idAgencia);
        }

        public DataTable ListarTipoOperacionVenta()
        {
            return objSql.ListarTipoOperacionVenta();
        }

        public DataTable BuscarComprPago(int idComprPago)
        {
            return objSql.BuscarComprPago(idComprPago);
        }

        public DataTable BuscarDetComprPago(int idComprPago)
        {
            return objSql.BuscarDetComprPago(idComprPago);
        }

        public DataTable BuscarDescComprPago(int idComprPago)
        {
            return objSql.BuscarDescComprPago(idComprPago);
        }

        public DataTable BuscarCajChicResp(int idResponsable, int idAgencia)
        {
            return objSql.BuscarCajChicResp(idResponsable, idAgencia);
        }
        public DataTable BuscarHabCajChic(int idResponsable, int idAgencia)
        {
            return objSql.BuscarHabCajChic(idResponsable, idAgencia);
        }
        public DataTable ListarNroCajChica(int idCajChica,DateTime dFechaIni, DateTime dFechaFin)
        {
            return objSql.ListarNroCajChica(idCajChica, dFechaIni,  dFechaFin);
        }
        public DataTable ListarEstCheque()
        {
            return objSql.ListarEstCheque();
        }

        //--Comprobantes Pagados
        public DataTable ReporteComprobantes(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin, int idEstCpg)
        {
            return objSql.ReporteComprobantes(ntipCompr, idAgencia, fechaIni, fechaFin, idEstCpg);
        }

        //--Comprobantes Emitidos
        public DataTable ReporteComprobantesEmi(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin, int idEstCpg)
        {
            return objSql.ReporteComprobantesEmi(ntipCompr, idAgencia, fechaIni, fechaFin, idEstCpg);
        }

        //--Listado Estados Comprobante
        public DataTable CNListadoEstadoCpg()
        {
            return objSql.ListadoEstadoCpg();
        }

        public DataTable ReporteComprobantesProvision(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objSql.ReporteComprobantesProvision(ntipCompr, idAgencia, fechaIni, fechaFin);
        }

        //--Reporte de Detracciones Pagados
        public DataTable ReporteComprobantesDetraccion(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objSql.ReporteComprobantesDetraccion(ntipCompr, idAgencia, fechaIni, fechaFin);
        }

        //--Reporte de Detracciones solo Emitidos
        public DataTable ReporteCpgDetraccionEmitidos(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objSql.ReporteCpgDetraccionEmitidos(ntipCompr, idAgencia, fechaIni, fechaFin);
        }

        public DataTable BuscarCajChicActivo(int idResponsable, int idAgencia)
        {
            return objSql.BuscarCajChicActivo(idResponsable, idAgencia);
        }
		public DataTable ListarMotReparoCpg()
        {
            return objSql.ListarMotReparoCpg();
        }
        public DataTable RetConfigTipoComp(int idTipoCompr)
        {
            return objSql.RetConfigTipoComp(idTipoCompr);
        }
        public DataTable GuardarCpgCajGen(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int idCpgRef, bool lCorregir)
        {
            return objSql.GuardarCpgCajGen(xmlComprPago, xmlDetComprPago, xmlDescComprPago,idCpgRef, lCorregir);
        }
        public DataTable BusCIIUCliente(int idCli)
        {
            return objSql.BusCIIUCliente(idCli);
        }
        public DataTable RetDatCajChic(int idResponsable, int idAgencia)
        {
            return objSql.RetDatCajChic(idResponsable, idAgencia);
        }
        public DataTable GuardarRegVenta(string xmlRegVenta, string xmlDetRegVenta, int idCpgRef, DateTime dFecha,int idAgencia)
        {
            return objSql.GuardarRegVenta(xmlRegVenta, xmlDetRegVenta, idCpgRef, dFecha, idAgencia);
        }
        public DataTable ListarRegVentas(int idTipoComprPago, string cSerie, string cNumero)
        {
            return objSql.ListarRegVentas(idTipoComprPago, cSerie, cNumero);
        }
        public DataTable BuscarRegVenta(int idRegVenta)
        {
            return objSql.BuscarRegVenta(idRegVenta);
        }
        public DataTable BuscarDetRegVenta(int idRegVenta)
        {
            return objSql.BuscarDetRegVenta(idRegVenta);
        }
        public DataTable ListarEstadosCpg()
        {
            return objSql.ListarEstadosCpg();
        }
        public DataTable ListarMotAnulCpg()
        {
            return objSql.ListarMotAnulCpg();
        }

        //--===============================================================
        //---Comprobantes Pagados
        //--===============================================================
        public DataTable RptRegCompras(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro)
        {
            return objSql.RptRegCompras(FecInicial, FecFinal, idAgencia,idTipRep,idFiltro);
        }

        //--===============================================================
        //---Comprobantes Solo Emitidos(Registrador)
        //--===============================================================
        public DataTable RptRegComprasEmitidos(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro)
        {
            return objSql.RptRegComprasEmitidos(FecInicial, FecFinal, idAgencia, idTipRep, idFiltro);
        }

        //--===============================================================
        //---Reporte de Registro de Compras por Fecha de Pago
        //--===============================================================
        public DataTable RptRegComprasDetalle(DateTime FecInicial, DateTime FecFinal, int idAgencia)
        {
            return objSql.RptRegComprasDetalle(FecInicial, FecFinal, idAgencia);
        }

        //--===============================================================
        //---Reporte de Registro de Compras por Fecha de Emisión
        //--===============================================================
        public DataTable RptRegComprasDetalleFecEmision(DateTime FecInicial, DateTime FecFinal, int idAgencia)
        {
            return objSql.RptRegComprasDetalleFecEmision(FecInicial, FecFinal, idAgencia);
        }

        public DataTable RptRegVentas(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro, int idEstadoCpg)
        {
            return objSql.RptRegVentas(FecInicial, FecFinal, idAgencia, idTipRep, idFiltro, idEstadoCpg);
        }
        public DataTable RptRegVentasDetalle(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idEstadoCpg)
        {
            return objSql.RptRegVentasDetalle(FecInicial, FecFinal, idAgencia, idEstadoCpg);
        }
        //=============================================================
        //--En lista las operaciones realizas por caja
        //=============================================================
        public DataTable RptLibroCaja(DateTime FechaReg, int idMoneda, int idAgencia)
        {
            return objSql.ADRptLibroCaja(FechaReg, idMoneda, idAgencia);
        }
        public DataTable RptCpgGastos(int idComprPago)
        {
            return objSql.BuscarRptCpgGastos(idComprPago);
        }
		//=============================================================
        //--Eliminar Comprobantes de Caja
        //=============================================================
        public DataTable CNEliminarComprobanteCaja(int idComprPago,string cMotivo,DateTime dFecEli,int idUsu,int idAge)
        {
            return objSql.ADEliminarCpgCaja(idComprPago,cMotivo,dFecEli,idUsu,idAge);
        }
        //=============================================================
        //--Extorna pago de Comprobantes de Caja chica
        //=============================================================
        public DataTable CNExtornaComprobanteCajaChica(int idComprPago, string cMotivo, DateTime dFecEli, int idUsu, int idAge)
        {
            return objSql.ADExtornaCpgCajaChica(idComprPago, cMotivo, dFecEli, idUsu, idAge);
        }
        //=============================================================
        //--Registrar Devolucion de Caja Chica
        //=============================================================
        public DataTable RegistraDevCajaChica(int idCajChi, int idRes, int idMon, Decimal /*era double*/nMontoHab, Decimal /*era double*/nMontoItf, Decimal /*era double*/nMonTot, Decimal /*era double*/nSalAnt, string cSust, DateTime dFecReg, int idUsu, int idAge,
                                    bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objSql.DevolucionCajChica(idCajChi, idRes, idMon, nMontoHab, nMontoItf, nMonTot,
                                    nSalAnt, cSust, dFecReg, idUsu, idAge, lModificaSaldoLinea, idTipoTransac);
        }
        //=============================================================
        //--Lista de Caja Chica Activa por Agencia
        //=============================================================
        public DataTable CNListCajChicaAge(int idAge)
        {
            return objSql.ADListCajChicaAge(idAge);
        }
        //=============================================================
        //--Lista Detalle Caja Chica Activa por cod de caja chica
        //=============================================================
        public DataTable CNDatosCajChicaAct(int idCajChica)
        {
            return objSql.ADDatosCajChicaAct(idCajChica);
        }
        //=============================================================
        //--Busca el comprobante en que Caja Chica se registro
        //=============================================================
        public DataTable CNCompCajChica(int idNumeroCpg)
        {
            return objSql.ADCompCajChica(idNumeroCpg);
        }

        //=============================================================
        //--Busca el comprobante en que Caja Chica se registro
        //=============================================================
        public DataTable CNElimRegCompCajChica(int idComprPago, string cMotivo, DateTime dFecEli, int idUsu, int idAge)
        {
            return objSql.ADElimRegCompCajChica(idComprPago, cMotivo, dFecEli, idUsu, idAge);
        }
        //==============================================================================
        //--Realiza pago de comprobante de Caja Chica
        //==============================================================================
        public DataTable CNPagoComprCajaChica(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int nidCajChica, DateTime dFechaPag, bool lTieneComprobante, int idUsuario, string xmlMoviliad, int idAgencia)
        {
            return objSql.ADPagoComprCajaChica(xmlComprPago, xmlDetComprPago, xmlDescComprPago, nidCajChica, dFechaPag, lTieneComprobante, idUsuario, xmlMoviliad, idAgencia);
        }

        //==============================================================================
        //--Lista Comprobantes de pago para emision de cheque
        //==============================================================================

        public DataTable CNListarComprPendiente(bool lTieneCompr, bool lCpgCajChica, int idTipoComprPago, string cSerie, string cNumero, int idMoneda)
        {
            return objSql.ADListarComprPendiente(lTieneCompr, lCpgCajChica, idTipoComprPago, cSerie, cNumero, idMoneda);
        }

        //==============================================================================
        //--Lista Comprobantes de pago de socios y no socio para coop
        //==============================================================================
        public DataTable CNRptRegVentasSocio(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro, int idEstadoCpg, int lSiNoSocio)
        {
            return objSql.ADRptRegVentasSocio(FecInicial, FecFinal, idAgencia, idTipRep, idFiltro, idEstadoCpg, lSiNoSocio);
        }
        //==============================================================================
        //--Lista modalidad de pago
        //==============================================================================
        public DataTable CNListarModalidadPagoRegVentas()
        {
            return objSql.ADListarModalidadPagoRegVentas();
        }

        //==============================================================================
        //--Lista datos de pago de reg de ventas
        //==============================================================================
        public DataTable CNListarDatosPagoVentas(int idRegVenta)
        {
            return objSql.ADListarDatosPagoVentas(idRegVenta);
        }

        //==============================================================================
        //--Validar Comprobante si fue vinculado
        //==============================================================================
        public DataTable CNValidarComprobanteNotaEntrada(int idComprobante)
        {
            return objSql.ADValidarComprobanteNotaEntrada(idComprobante);
        }
    }
}
