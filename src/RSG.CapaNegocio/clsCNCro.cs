using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.AccesoDatos;
using System.Data;

namespace RSG.CapaNegocio
{
    public class clsCNCro
    {
        public DataTable CNCR01(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR01(dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable CNCR02(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR02(dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable CNCR03(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR03(dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable CNCR04(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR04(dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable CNCR05(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR05(dFecha, cTipoProc, cTipEnvio);
        }
        public DataTable CNCR06(DateTime dFecha, string cTipoProc, string cTipEnvio)
        {
            return new clsADCro().ADCR06(dFecha, cTipoProc, cTipEnvio);
        }
        /*****************REPORTE DE RIESGOS *************************/
        public DataTable cliMejorarCalificacion(DateTime dFecSel)
        {
            return new clsADCro().ADcliMejorarCalificacion(dFecSel);
        }
        public DataTable cliEmpeorarCalificacion(DateTime dFecSel)
        {
            return new clsADCro().ADcliEmpeorarCalificacion(dFecSel);
        }
        public DataTable segCarteraClasiRiesgo(DateTime dFecSel, int idUsuario, int calificativo)
        {
            return new clsADCro().ADsegCarteraClasiRiesgo(dFecSel, idUsuario, calificativo);
        }

        public DataTable Zona(int idAgencia)
        {
            return new clsADCro().ADZona(idAgencia);
        }

        public DataTable SeguimientoCarteraCR(DateTime dFecSel, int idZona, int idAgencia, int idUsuario, int calificativo, int nCheck, DateTime dFechaCambio)
        {
            return new clsADCro().ADSeguimientoCarteraCR(dFecSel, idZona, idAgencia, idUsuario, calificativo, nCheck, dFechaCambio);
        }

        public DataTable segCarteraClasiRiesgoInt(DateTime dFecSel, int idUsuario)
        {
            return new clsADCro().ADsegCarteraClasiRiesgoInt(dFecSel, idUsuario);
        }

        public DataTable SeguimientoCarteraCRAI(DateTime dFecSel, int idZona, int idAgencia, int idUsuario)
        {
            return new clsADCro().ADSeguimientoCarteraCRAI(dFecSel, idZona, idAgencia, idUsuario);
        }

        public DataTable credNoPagan(DateTime dFecSel, string s)
        {
            return new clsADCro().AdCredNoPagan(dFecSel, s);
        }

        public DataTable rptCreditosRiesgoPotencial(DateTime dFechaIni, int idZona, int idAgencia, int idAsesor)
        {
            return new clsADCro().rptCreditosRiesgoPotencial(dFechaIni, idZona, idAgencia, idAsesor);
        }

        public DataTable ListarAnalistasRiesgos()
        {
            return new clsADCro().ListarAnalistasRiesgos();
        }

        public DataTable rptCreditosConOpinionRiesgos(DateTime dFechaIni, DateTime dFechaFin, int idAnalista)
        {
            return new clsADCro().rptCreditosConOpinionRiesgos(dFechaIni, dFechaFin, idAnalista);
        }

        public DataTable rptNumeroMontoOpinionAnalista(DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return new clsADCro().rptNumeroMontoOpinionAnalista(dFechaIni, dFechaFin, idAgencia);
        }

        public DataTable rptRiesgosGral(DateTime dFechaIni, DateTime dFechaFin, int idZona,int idAgencia, bool lDesfavorable, bool lActFijLibreDisp,
            decimal nMontoDesembolso, bool semestralesAnualesUnicuotas, bool lRefinanciadoReprogramado, int nMoraPromedio, 
            bool lAtrasoPriCuota, bool lTercioCronograma)
        {
            return new clsADCro().rptRiesgosGral(dFechaIni, dFechaFin, idZona,idAgencia, lDesfavorable, lActFijLibreDisp,
                nMontoDesembolso, semestralesAnualesUnicuotas, lRefinanciadoReprogramado, nMoraPromedio, lAtrasoPriCuota, lTercioCronograma);
        }

        public DataTable MotivoIncrementoProvision(DateTime dFecSel, int idZona, int idAgencia, int idUsuario)
        {
            return new clsADCro().ADMotivoIncrementoProvision(dFecSel, idZona, idAgencia, idUsuario);
        }

        public DataTable GeneraSaldoProvision(DateTime dFecSel, int idZona, int idAgencia)
        {
            return new clsADCro().ADGeneraSaldoProvision(dFecSel, idZona, idAgencia);
        }

        public DataTable IndicadoresProvision(DateTime dFecSel)
        {
            return new clsADCro().ADIndicadoresProvision(dFecSel);
        }

        public DataTable IndicadoresExcepciones(DateTime dFecSel)
        {
            return new clsADCro().ADIndicadoresExcepciones(dFecSel);
        }

        public DataTable GeneraRefinanciamientoOculto(DateTime dFecSel)
        {
            return new clsADCro().ADGeneraRefinanciamientoOculto(dFecSel);
        }

        public DataTable CredAmpliadosRefiOculto(DateTime dFecSel)
        {
            return new clsADCro().ADCredAmpliadosRefiOculto(dFecSel);
        }

        public DataTable CredReprogramadosRefiOculto(DateTime dFecSel)
        {
            return new clsADCro().ADCredReprogramadosRefiOculto(dFecSel);
        }

        public DataTable IndicadoresRefinanciados(DateTime dFecSel)
        {
            return new clsADCro().ADIndicadoresRefinanciados(dFecSel);
        }
    }
}
