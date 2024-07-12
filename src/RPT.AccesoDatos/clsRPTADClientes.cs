using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADClientes
    {
        public DataTable CNRetornoCliente(int CodigoCliente)
        {
            return new clsGENEjeSP().EjecSP("RPT_DatosClienteReport_sp", CodigoCliente);
        }
        public DataTable ADRetornoClienteJur(int idCli)
        {
            return new clsGENEjeSP().EjecSP("RPT_DatosClienteJurReport_sp", idCli);
        }
        public DataTable CNRetornoClienteJuridico(int idSocio)
        {
            return new clsGENEjeSP().EjecSP("RPT_DatosClienteJuridicoReport_sp", idSocio);
        }

        public DataTable CNRetornoClientesFallecidos(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return new clsGENEjeSP().EjecSP("CLI_ReporteCliFall_SP", dFechaDesde, dFechaHasta);
        }
        public DataTable CNRetornoPersonaJuridicaRepresentantes(Int32 idAgencia, DateTime dFechaDesde, DateTime dFechaHasta) 
        {
            return new clsGENEjeSP().EjecSP("CLI_ReporteCliJurRepLeg_SP", idAgencia, dFechaDesde, dFechaHasta);
        }

        //Reporte de clientes con código SBS diferentes
        public DataTable ADReporteCliCodSBSDif(DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CLI_RptCliCodSBSDiferente_sp", dFechaIni, dFechaFin, idAgencia);
        }
        //Reporte de clientes sin código SBS
        public DataTable ADReporteCliSinCodSBS(DateTime dFechaIni, DateTime dFechaFin, int idAgencia, Boolean lSolCreditos)
        {
            return new clsGENEjeSP().EjecSP("RPT_CliSinCodSBS_sp", dFechaIni, dFechaFin, idAgencia, lSolCreditos);
        }
        public DataTable ADRptConfirmacionUsoDatosCli()
        {
            return new clsGENEjeSP().EjecSP("RPT_ConfirmacionUsoDatosCli_SP");
        }
        public DataTable ADRptCambioDatosContactoCli(int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return new clsGENEjeSP().EjecSP("RPT_CambioDatosContactoCli_SP", idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        }
    }
}
