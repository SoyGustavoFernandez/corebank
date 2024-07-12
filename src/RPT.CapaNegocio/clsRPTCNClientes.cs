using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNClientes
    {
        clsRPTADClientes ADCodigoCliente = new clsRPTADClientes();
        public DataTable CNRetornoCliente(int CodigoCliente)
        {
            return ADCodigoCliente.CNRetornoCliente(CodigoCliente);
        }
        public DataTable CNRetornoClienteJur(int idCli)
        {
            return ADCodigoCliente.ADRetornoClienteJur(idCli);
        }
        public DataTable CNRetornoClienteJuridico(int idSocio)
        {
            return ADCodigoCliente.CNRetornoClienteJuridico(idSocio);
        }
        public DataTable CNRetornoClientesFallecidos(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return ADCodigoCliente.CNRetornoClientesFallecidos(dFechaDesde, dFechaHasta);
        }
        public DataTable CNRetornoPersonaJuridicaRepresentantes(Int32 idAgencia, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return ADCodigoCliente.CNRetornoPersonaJuridicaRepresentantes(idAgencia, dFechaDesde, dFechaHasta);
        }
	//Reporte de clientes con código SBS diferentes
        public DataTable CNReporteCliCodSBSDif(DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return  ADCodigoCliente.ADReporteCliCodSBSDif(dFechaIni, dFechaFin, idAgencia);
        }
        //Reporte de clientes sin código SBS
        public DataTable CNReporteCliSinCodSBS(DateTime dFechaIni, DateTime dFechaFin, int idAgencia, Boolean lSolCreditos)
        {
            return ADCodigoCliente.ADReporteCliSinCodSBS(dFechaIni, dFechaFin, idAgencia, lSolCreditos);
        }
        public DataTable CNRptConfirmacionUsoDatosCli()
        {
            return ADCodigoCliente.ADRptConfirmacionUsoDatosCli();
        }
        public DataTable CNRptCambioDatosContactoCli(int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return ADCodigoCliente.ADRptCambioDatosContactoCli(idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        }
    }
}
