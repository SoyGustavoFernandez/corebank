using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CAJ.AccesoDatos
{
    public class clsADCajaChica
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=============================================================
        //--Listado de Estados de Caja Chica
        //=============================================================
        public DataTable LisEstCajChi()
        {
            return objEjeSp.EjecSP("CAJ_ListaEstCajChica_Sp");
        }

        //=============================================================
        //--Listado de Caja Chica por Agencia
        //=============================================================
        public DataTable LisCajChi(int idAge)
        {
            return objEjeSp.EjecSP("CAJ_ListaCajChiAge_Sp", idAge);
        }

        //=============================================================
        //--Registra Caja Chica
        //=============================================================
        public DataTable RegCajChica(int idAge, string cNomCajChi, int idMon, Decimal nMontoMax, Decimal nMontoCpg, int idRes)
        {
            return objEjeSp.EjecSP("CAJ_RegistraCajChica_Sp", idAge,cNomCajChi, idMon, nMontoMax, nMontoCpg, idRes);
        }

        //=============================================================
        //--Actualizar y Eliminar Caja Chica
        //=============================================================
        public DataTable ActEliCajChica(int idCaj, string cNomCajChi, int idMon, Decimal nMontoMax, Decimal nMontoCpg, int idRes, int nOpc)
        {
            return objEjeSp.EjecSP("CAJ_ActualizaCajChica_Sp", idCaj, cNomCajChi, idMon, nMontoMax, nMontoCpg, idRes, nOpc);
        }

        //=============================================================
        //--Listado de Cajas Chicas
        //=============================================================
        public DataTable LisCajChica(int idAge, int idRes,int idOpc)
        {
            return objEjeSp.EjecSP("CAJ_ListaCajChica_Sp", idAge, idRes, idOpc);
        }

        //=============================================================
        //--Datos de la Caja Chica
        //=============================================================
        public DataTable DatCajChica(int idCaj, int idOpcion)
        {
            return objEjeSp.EjecSP("CAJ_DatHabCajChica_Sp", idCaj, idOpcion);
        }

        //=============================================================
        //--Registrar la Habilitación de Caja Chica
        //=============================================================
        public DataTable HabCajChica(int idCajChi, int idRes, int idMon, Decimal nMontoHab, Decimal nMontoItf, Decimal nMonTot,
                                    Decimal nSalAnt, string cSust, DateTime dFecReg, int idUsu, int idAge,
                                    bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objEjeSp.EjecSP("CAJ_RegHabCajaChica_Sp", idCajChi, idRes, idMon, nMontoHab, nMontoItf, nMonTot,
                                    nSalAnt, cSust, dFecReg, idUsu, idAge, lModificaSaldoLinea, idTipoTransac);
        }

        //=============================================================
        //--Retorna Datos de Caja Chica Para Iniciar
        //=============================================================
        public DataTable RetDatCajChica(int idRec)
        {
            return objEjeSp.EjecSP("CAJ_RetDatosHabCajChica_Sp", idRec);
        }

        //=============================================================
        //--Registrar Inicio de Caja Chica
        //=============================================================
        public DataTable RegIniCajChica(int idCajChi, int nNroCaj, DateTime dFecReg, int idUsu)
        {
            return objEjeSp.EjecSP("CAJ_InicioCajaChica_Sp", idCajChi, nNroCaj, dFecReg, idUsu);
        }

        //=============================================================
        //--Datos para el Cierre de Caja Chica
        //=============================================================
        public DataTable DatCieCajChica(int idCajChi, int nNroCaj, int idOpc)
        {
            return objEjeSp.EjecSP("CAJ_DatCieCajChica_Sp", idCajChi, nNroCaj, idOpc);
        }

        //=============================================================
        //--Registrar el Cierre de Caja Chica
        //=============================================================
        public DataTable RegCieCajChica(int idCajChi, int nNroCaj, DateTime dFecReg,int idOpe,int nNroCpg)
        {
            return objEjeSp.EjecSP("CAJ_RegCierreCajChica_Sp", idCajChi, nNroCaj, dFecReg, idOpe, nNroCpg);
        }
	    //=============================================================
        //--Listar el tipo de comprobantes de pago
        //=============================================================
        public DataTable ListarTipoComprPago(int nOpcion)
        {
            return objEjeSp.EjecSP("Gen_ListaTipoComprobantePago_sp",nOpcion);
        }
        //=============================================================
        //--Listar el descuentos de comprobante de pago
        //=============================================================
        public DataTable ListarOtrosDescuentoComprobantes()
        {
            return objEjeSp.EjecSP("Gen_ListaOtrosDescuentosComprobante_sp");
        }

        //=============================================================
        //--Grabar comprobante de pago
        //=============================================================
        public DataTable GuardarComprPgCajChica(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int nidCajChica)
        {
            return objEjeSp.EjecSP("CAJ_GuardarComprPgCajChica_sp", xmlComprPago, xmlDetComprPago, xmlDescComprPago,nidCajChica);
        }
        //=============================================================
        //--Listar sub conceptos 
        //=============================================================
        public DataTable ListarSubConceptos(int idConcepto)
        {
            return objEjeSp.EjecSP("CAJ_ListaSubConceptos_sp", idConcepto);
        }

        public DataTable ListarTipoOperacionDetraccion()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoOperacionDetraccion_sp");
        }

        public DataTable ListarBienServicioDetraccion(int idTipoOperDetra)
        {
            return objEjeSp.EjecSP("CAJ_ListaBienServicioDetra_sp", idTipoOperDetra);
        }

        public DataTable ListarComprPago(bool lTieneCompr, bool lCpgCajChica, int idTipoComprPago, string cSerie, string cNumero, int idEstCpg, int idComprobante, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_ListarComprPago_sp", lTieneCompr, lCpgCajChica, idTipoComprPago, cSerie, cNumero, idEstCpg, idComprobante, dFechaIni, dFechaFin);
        }

        public DataTable ListarDestinoComprPago(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListaDestinioComprPago_sp", idAgencia);
        }

        public DataTable ListarTipoOperacionVenta()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoOperacionVenta_sp");
        }
        public DataTable BuscarComprPago(int idComprPago)
        {
            return objEjeSp.EjecSP("CAJ_BuscarComprobantePago_sp", idComprPago);
        }

        public DataTable BuscarDetComprPago(int idComprPago)
        {
            return objEjeSp.EjecSP("CAJ_BuscarDetComprobantePago_sp", idComprPago);
        }

        public DataTable BuscarDescComprPago(int idComprPago)
        {
            return objEjeSp.EjecSP("CAJ_BuscarDescComprobantePago_sp", idComprPago);
        }

        public DataTable BuscarCajChicResp(int idResponsable, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_BuscarCajChicResp_sp", idResponsable, idAgencia);
        }
        public DataTable BuscarHabCajChic(int idResponsable, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_BuscarHabCajChic_sp", idResponsable, idAgencia);
        }

        public DataTable ListarNroCajChica(int idCajChica, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_BuscarNroCajaChica_sp", idCajChica, dFechaIni,  dFechaFin);
        }

        public DataTable ListarEstCheque()
        {
            return objEjeSp.EjecSP("CAJ_ListarEstCheque");
        }

        //--Comprobantes Pagados
        public DataTable ReporteComprobantes(int ntipCompr, int idAgencia,DateTime fechaIni, DateTime fechaFin, int idEstCpg)
        {
            return objEjeSp.EjecSP("CAJ_RptComprobantesPag_sp", ntipCompr, idAgencia, fechaIni, fechaFin,idEstCpg);
        }

        //--Comprobantes Emitidos
        public DataTable ReporteComprobantesEmi(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin,int idEstCpg)
        {
            return objEjeSp.EjecSP("CAJ_RptComprobantesEmi_sp", ntipCompr, idAgencia, fechaIni, fechaFin, idEstCpg);
        }

        //--Listado de los estados del Comprobante
        public DataTable ListadoEstadoCpg()
        {
            return objEjeSp.EjecSP("CAJ_ListadoEstadoCpg_sp");
        }

        public DataTable ReporteComprobantesProvision(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptProvisionComprobantes_sp", ntipCompr, idAgencia, fechaIni, fechaFin);
        }

        //--reporte de Detracciones Pagados
        public DataTable ReporteComprobantesDetraccion(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptDetraccionCpgFechaPago_sp", ntipCompr, idAgencia, fechaIni, fechaFin);
        }

        //--reporte de Detracciones solo Emitidos
        public DataTable ReporteCpgDetraccionEmitidos(int ntipCompr, int idAgencia, DateTime fechaIni, DateTime fechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptDetraccionComprobantes_sp", ntipCompr, idAgencia, fechaIni, fechaFin);
        }


        public DataTable BuscarCajChicActivo(int idResponsable, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_BuscarCajChicaActivo_sp", idResponsable, idAgencia);
        }
		public DataTable ListarMotReparoCpg()
        {
            return objEjeSp.EjecSP("Caj_ListMotReparoCpg_Sp");
        }
        public DataTable RetConfigTipoComp(int idTipoCompr)
        {
            return objEjeSp.EjecSP("Caj_RetConfigTipoComp_Sp", idTipoCompr);
        }
        public DataTable GuardarCpgCajGen(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int idCpgRef, bool lCorregir)
        {
            return objEjeSp.EjecSP("Caj_GuardarCpgCajGen_sp", xmlComprPago, xmlDetComprPago, xmlDescComprPago,idCpgRef, lCorregir, true);
        }
        public DataTable BusCIIUCliente(int idCli)
        {
            return objEjeSp.EjecSP("Caj_BusCIIUCliente_Sp",idCli);
        }
        public DataTable RetDatCajChic(int idResponsable, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_DatosCajaChica_sp", idResponsable, idAgencia);
        }
        public DataTable GuardarRegVenta(string xmlRegVenta, string xmlDetRegVenta, int idCpgRef, DateTime dFecha, int idAgencia)
        {
            return objEjeSp.EjecSP("Caj_GuardarRegVentas_sp", xmlRegVenta, xmlDetRegVenta, idCpgRef, dFecha, idAgencia);
        }
        public DataTable ListarRegVentas(int idTipoComprPago, string cSerie, string cNumero)
        {
            return objEjeSp.EjecSP("CAJ_ListarRegVenta_sp", idTipoComprPago, cSerie, cNumero);
        }

        public DataTable BuscarRegVenta(int idRegVenta)
        {
            return objEjeSp.EjecSP("CAJ_BuscarRegVenta_sp", idRegVenta);
        }

        public DataTable BuscarDetRegVenta(int idRegVenta)
        {
            return objEjeSp.EjecSP("CAJ_BuscarDetRegVenta_sp", idRegVenta);
        }

        public DataTable ListarEstadosCpg()
        {
            return objEjeSp.EjecSP("CAJ_ListarEstadosCpg_sp");
        }

        public DataTable ListarMotAnulCpg()
        {
            return objEjeSp.EjecSP("CAJ_ListarMotAnulCpg_sp");
        }

        //--===============================================================
        //--Comprobantes Pagados
        //--===============================================================
        public DataTable RptRegCompras(DateTime FecInicial,DateTime FecFinal,int idAgencia,int idTipRep,int idFiltro)
        {
            return objEjeSp.EjecSP("CAJ_RptComprCajaGen_sp",FecInicial,FecFinal,idAgencia,idTipRep,idFiltro);
        }

        //--===============================================================
        //--Comprobantes Emitidos (Solo Registrado)
        //--===============================================================
        public DataTable RptRegComprasEmitidos(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro)
        {
            return objEjeSp.EjecSP("CAJ_RptCpgCajaGenEmitidos_sp", FecInicial, FecFinal, idAgencia, idTipRep, idFiltro);
        }

        //--===============================================================
        //--Listado por Fecha de Pago
        //--===============================================================
        public DataTable RptRegComprasDetalle(DateTime FecInicial, DateTime FecFinal, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_RptComprCajaGenConcepto_sp", FecInicial, FecFinal, idAgencia);
        }

        //--===============================================================
        //--Listado por Fecha de Emisión
        //--===============================================================
        public DataTable RptRegComprasDetalleFecEmision(DateTime FecInicial, DateTime FecFinal, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_RptCpgCajaGenConceptoEmi_sp", FecInicial, FecFinal, idAgencia);
        }

        public DataTable RptRegVentas(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro, int idEstadoCpg)
        {
            return objEjeSp.EjecSP("CAJ_RptRegVentas_sp", FecInicial, FecFinal, idAgencia, idTipRep, idFiltro, idEstadoCpg);
        }
        public DataTable RptRegVentasDetalle(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idEstadoCpg)
        {
            return objEjeSp.EjecSP("CAJ_RptRegVentasConcepto_sp", FecInicial, FecFinal, idAgencia, idEstadoCpg);
        }
        public DataTable ADRptLibroCaja(DateTime FechaReg, int idMoneda, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_RptLibroCaja_Sp", FechaReg, idMoneda, idAgencia);
        }
        public DataTable BuscarRptCpgGastos(int idComprPago)
        {
            return objEjeSp.EjecSP("CAJ_RptGastosSinCPG_Sp", idComprPago);
        }
		//=============================================================
        //--Eliminar Comprobantes de Caja
        //=============================================================
        public DataTable ADEliminarCpgCaja(int idComprPago, string cMotivo, DateTime dFecEli, int idUsu, int idAge)
        {
            return objEjeSp.EjecSP("CAJ_EliminaComprobante_sp", idComprPago, cMotivo, dFecEli, idUsu, idAge);
        }
        //=============================================================
        //--Eliminar Comprobantes de Caja
        //=============================================================
        public DataTable ADExtornaCpgCajaChica(int idComprPago, string cMotivo, DateTime dFecEli, int idUsu, int idAge)
        {
            return objEjeSp.EjecSP("CAJ_ExtornaComprobanteCajaChica_sp", idComprPago, cMotivo, dFecEli, idUsu, idAge);
        }
        //=============================================================
        //--Registrar Devolucion de Caja Chica
        //=============================================================
        public DataTable DevolucionCajChica(int idCajChi, int idRes, int idMon, Decimal nMontoHab, Decimal nMontoItf, Decimal nMonTot,
                                    Decimal nSalAnt, string cSust, DateTime dFecReg, int idUsu, int idAge,
                                    bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objEjeSp.EjecSP("CAJ_RegDevolucionCajaChica_Sp", idCajChi, idRes, idMon, nMontoHab, nMontoItf, nMonTot,
                                    nSalAnt, cSust, dFecReg, idUsu, idAge, lModificaSaldoLinea, idTipoTransac);
        }
        //=============================================================
        //--Lista de Caja Chica Activa por Agencia
        //=============================================================
        public DataTable ADListCajChicaAge(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListaCajaChicaAgencia_sp", idAgencia);
        }

        //=============================================================
        //--Lista Detalle Caja Chica Activa por cod de caja chica
        //=============================================================
        public DataTable ADDatosCajChicaAct(int idCajChica)
        {
            return objEjeSp.EjecSP("CAJ_DatosCajaChicaActiva_sp", idCajChica);
        }

        //=============================================================
        //--Busca el comprobante en que Caja Chica se registro
        //=============================================================
        public DataTable ADCompCajChica(int idNumeroCpg)
        {
            return objEjeSp.EjecSP("CAJ_ComprobanteCajaChica_sp", idNumeroCpg);
        }

        //==============================================================================
        //--Elimina el registro de comprobante en que Caja Chica en estado registrado
        //==============================================================================
        public DataTable ADElimRegCompCajChica(int idComprPago, string cMotivo, DateTime dFecEli, int idUsu, int idAge)
        {
            return objEjeSp.EjecSP("CAJ_AnulaRegComprobCajaChica_SP", idComprPago, cMotivo, dFecEli, idUsu, idAge);
        }
        //==============================================================================
        //--Realiza pago de comprobante de Caja Chica
        //==============================================================================
        public DataTable ADPagoComprCajaChica(string xmlComprPago, string xmlDetComprPago, string xmlDescComprPago, int nidCajChica, DateTime dFechaPag, bool lTieneComprobante, int idUsuario, string xmlMoviliad, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_PagoComprobanteCajaChica_SP", xmlComprPago, xmlDetComprPago, xmlDescComprPago, nidCajChica, dFechaPag, lTieneComprobante, idUsuario, xmlMoviliad, idAgencia);
        }
		//==============================================================================
        //--Lista Comprobantes de pago para emision de cheque
        //==============================================================================

        public DataTable ADListarComprPendiente(bool lTieneCompr, bool lCpgCajChica, int idTipoComprPago, string cSerie, string cNumero, int idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_ListaComprobantesPendientes_sp", lTieneCompr, lCpgCajChica, idTipoComprPago, cSerie, cNumero, idMoneda);
        }
        //==============================================================================
        //--Lista Comprobantes de pago de socios y no socio para coop
        //==============================================================================
        public DataTable ADRptRegVentasSocio(DateTime FecInicial, DateTime FecFinal, int idAgencia, int idTipRep, int idFiltro, int idEstadoCpg, int lSiNoSocio)
        {
            return objEjeSp.EjecSP("CAJ_RptRegVentasSocios_sp", FecInicial, FecFinal, idAgencia, idTipRep, idFiltro, idEstadoCpg, lSiNoSocio);
        }
        //==============================================================================
        //--Lista modalidad de pago
        //==============================================================================
        public DataTable ADListarModalidadPagoRegVentas()
        {
            return objEjeSp.EjecSP("CAJ_ListarModalidadPagoRegVent_Sp");
        }

        //==============================================================================
        //--Lista datos de pago de reg de ventas
        //==============================================================================
        public DataTable ADListarDatosPagoVentas(int idRegVenta)
        {
            return objEjeSp.EjecSP("CAJ_ListaKardexRegVentas_SP", idRegVenta);
        }

        //==============================================================================
        //--Validar Comprobante si fue vinculado
        //==============================================================================
        public DataTable ADValidarComprobanteNotaEntrada(int idComprobante)
        {
            return objEjeSp.EjecSP("CRE_ValidarComprobanteNotaEntrada_SP", idComprobante);
        }
    }
}
