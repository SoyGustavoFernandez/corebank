using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSG.AccesoDatos
{
    public class clsADCro
    {
        public DataTable ADCR01(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO01_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable ADCR02(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO02_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable ADCR03(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO03_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable ADCR04(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO04_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable ADCR05(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO05_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable ADCR06(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsGENEjeSP().EjecSP("RPT_GeneraCRO06_Sp", dFecha, cTipoProc, cTipEnvio);
        }
        /************************REPORTE DE RIESGOS*******************************/
        public DataTable ADcliMejorarCalificacion(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListCliPosibilidadMejora_SP", dFecSel);
        }
        public DataTable ADcliEmpeorarCalificacion(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListCliPosibilidadEmpeorar_SP", dFecSel);
        }
        public DataTable ADsegCarteraClasiRiesgo(DateTime dFecSel, int idUsuario, int calificativo)
        {
            return new clsGENEjeSP().EjecSP("RSG_SegCarteraClasifRiesgoCredito_SP", dFecSel, idUsuario, calificativo);
        }

        public DataTable ADZona(int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RSG_Zona_SP", idAgencia);
        }

        public DataTable ADSeguimientoCarteraCR(DateTime dFecSel, int idZona, int idAgencia, int idUsuario, int calificativo, int nCheck, DateTime dFechaCambio)
        {
            return new clsGENEjeSP().EjecSP("RSG_SeguimientoCarteraCR_SP", dFecSel, idZona, idAgencia, idUsuario, calificativo, nCheck, dFechaCambio);
        }

        public DataTable ADsegCarteraClasiRiesgoInt(DateTime dFecSel, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RSG_AlineamientoInterno_SP", dFecSel, idUsuario);
        }

        public DataTable ADSeguimientoCarteraCRAI(DateTime dFecSel, int idZona, int idAgencia, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RSG_SeguimientoAlineamientoInterno_SP", dFecSel, idZona, idAgencia, idUsuario);
        }

        public DataTable AdCredNoPagan(DateTime dFecSel, string s)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListCreNoPaganPrimeraCuota", dFecSel, s);
        }

        public DataTable rptCreditosRiesgoPotencial(DateTime dFechaIni, int idZona, int idAgencia, int idAsesor)
        {
            return new clsGENEjeSP().EjecSP("RSG_rptCreditosRiesgoPotencial_SP", dFechaIni, idZona, idAgencia, idAsesor);
        }

        public DataTable ListarAnalistasRiesgos()
        {
            return new clsGENEjeSP().EjecSP("RSG_ListarAnalistasRiesgos_SP");
        }

        public DataTable rptCreditosConOpinionRiesgos(DateTime dFechaIni, DateTime dFechaFin, int idAnalista)
        {
            return new clsGENEjeSP().EjecSP("RSG_rptOpinionRiesgoAnalista_SP", dFechaIni, dFechaFin, idAnalista);
        }

        public DataTable rptNumeroMontoOpinionAnalista(DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RSG_rptNumeroMontoOpinionesAnalista_SP", dFechaIni, dFechaFin, idAgencia);
        }

        public DataTable rptRiesgosGral(DateTime dFechaIni, DateTime dFechaFin, int idZona,int idAgencia, bool lDesfavorable, bool lActFijLibreDisp,
            decimal nMontoDesembolso, bool semestralesAnualesUnicuotas, bool lRefinanciadoReprogramado, int nMoraPromedio, 
            bool lAtrasoPriCuota, bool lTercioCronograma)
        {
            return new clsGENEjeSP().EjecSP("RSG_ReportesRiesgosGral_SP", dFechaIni, dFechaFin, idZona, idAgencia, lDesfavorable, lActFijLibreDisp,
                nMontoDesembolso, semestralesAnualesUnicuotas, lRefinanciadoReprogramado, nMoraPromedio, lAtrasoPriCuota, lTercioCronograma);
        }

        public DataTable ADMotivoIncrementoProvision(DateTime dFecSel, int idZona, int idAgencia, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RSG_MotivoIncrementoProvision_SP", dFecSel, idZona, idAgencia, idUsuario);
        }

        public DataTable ADGeneraSaldoProvision(DateTime dFecSel, int idZona, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RSG_SaldoProvisiones_SP", dFecSel, idZona, idAgencia);
        }

        public DataTable ADIndicadoresProvision(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_RptIndicadoresProvisiones", dFecSel);
        }

        public DataTable ADIndicadoresExcepciones(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_IndicadoresExcepciones_SP", dFecSel);
        }

        public DataTable ADGeneraRefinanciamientoOculto(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_GeneraRefinanciamientoOculto_SP", dFecSel);
        }

        public DataTable ADCredAmpliadosRefiOculto(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_CredAmpliadosRefiOculto_SP", dFecSel);
        }

        public DataTable ADCredReprogramadosRefiOculto(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_CredReprogramadosRefiOculto_SP", dFecSel);
        }

        public DataTable ADIndicadoresRefinanciados(DateTime dFecSel)
        {
            return new clsGENEjeSP().EjecSP("RSG_RptIndicadoresRefinanciados_SP", dFecSel);
        }
    }
}
