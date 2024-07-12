using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CAJ.AccesoDatos
{
    public class clsADControlLimitesBoveda
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsADControlLimitesBoveda() { }

        public DataTable resumenCtrlLimBov(Int32 idAgencia)
        {
            return this.objEjeSp.EjecSP("CAJ_resumenCtrlLimBov_SP", idAgencia);
        }

        public DataTable listaMotivosCierreBoveda()
        {
            return this.objEjeSp.EjecSP("CAJ_listaMotivosCierreBoveda_SP");
        }

        public DataTable comprobarAprobacionCierreBov(Int32 idUsuario, Int32 idAgencia, DateTime dFecSolici)
        {
            return this.objEjeSp.EjecSP("CAJ_comprobarAprobacionCierreBov_SP", idUsuario, idAgencia, dFecSolici);
        }

        public void registrarControlLimiteBoveda(
            String  cMensaje,
            DateTime dFechaope,
            Int32 idUsuario,
            Int32 idAgencia,
		    Decimal nSaldoSoles		,
		    Decimal nMontoLimSoles	,
		    Decimal nSaldoDolares	,
		    Decimal nMontoLimDolares,
            Int32 idSolicitudAprob,
            Int32 idEstablecimiento)
        { 
            this.objEjeSp.EjecSP("CAJ_RegistroControlLimiteBov_SP"
                ,0
                ,cMensaje
                ,dFechaope
                ,idUsuario
                ,idAgencia
                ,nSaldoSoles		
                ,nMontoLimSoles	
                ,nSaldoDolares	
                ,nMontoLimDolares
                ,idSolicitudAprob
                ,idEstablecimiento
                ,1);
        }

        public DataTable reporteEstadoLimiteBoveda(
            Int32 idAgencia
            , Int32 idEstablecimiento
            , Int32 idZona
            , DateTime dFechaInicio 
            , DateTime dFechaFin
            )
        {
            return this.objEjeSp.EjecSP("CAJ_reporteEstadoLimiteBoveda_SP", idAgencia, idEstablecimiento, idZona, dFechaInicio, dFechaFin);
        }

        public DataSet listaAgenciasEOBs(Int32 idUsuario) 
        {
            return this.objEjeSp.DSEjecSP("GEN_listaAgenciasbzEOBsba_SP", idUsuario);
        }

        public DataTable reporteResumenExcepciones(Int32 idAgencia, Int32 idEOB, Int32 idZona, DateTime dFechaIni, DateTime dFechaFin)
        {
            return this.objEjeSp.EjecSP("CAJ_reporteResmCtrlLimBov_SP", idAgencia, idEOB, idZona, dFechaIni, dFechaFin);
        }
    }
}
