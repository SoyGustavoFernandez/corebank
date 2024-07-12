using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADCredencialTokenValidador
    {
        private IntConexion objEjeSP;
        private int nTimeOut = 1;
       
        public clsADCredencialTokenValidador(bool lConexion)
        {
            objEjeSP = new clsWCFEjeSP();
        }

        public clsADCredencialTokenValidador()
        {
            objEjeSP = new clsGENEjeSP();
        }

        public DataTable ADValidarCredenciales(string cUsuario, string cPassword, int idApiEmpresa)
        {
            return objEjeSP.EjecSPTMO("GEN_APIValidarCredenciales_SP", nTimeOut, cUsuario, cPassword, idApiEmpresa);
        }

        public DataTable ADValidarToken(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            return objEjeSP.EjecSPTMO("GEN_APIValidarToken_SP", nTimeOut, idAPIUsuarioAuth, idApiEmpresa, cToken);
        }

        public DataTable ADGuardarToken(int idPDPUsuarioAuth, string cToken)
        {
            return objEjeSP.EjecSPTMO("GEN_APIGuardarToken_SP", nTimeOut, idPDPUsuarioAuth, cToken);
        }

        public DataTable ADOnOffServicio(int idAPIEmpresa, int idAPIUsuarioAuth, bool lEstado)
        {
            return objEjeSP.EjecSP("GEN_APIOnOffServicio_SP", idAPIEmpresa, idAPIUsuarioAuth, lEstado);
        }

        public DataTable ADObtenerEstadoServicio(int idAPIEmpresa)
        {
            return objEjeSP.EjecSP("GEN_APIObtenerEstadoServicio_SP", idAPIEmpresa);
        }

        public DataTable ADRegRequestAPITransacLogKasNet(string cTipo, string xINxml, DateTime dFechaIni, int idPDPUsuarioAuth)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegRequestTransacLogKasNet_SP", nTimeOut, cTipo, xINxml, dFechaIni, idPDPUsuarioAuth);
        }

        public DataTable ADRegResponseAPITransacLogKasNet(int idAPITransacLogKasNet, string xOUTxml, DateTime dFechaFin, int idAPIHisTransKasNet)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegResponseTransacLogKasNet_SP", nTimeOut, idAPITransacLogKasNet, xOUTxml, dFechaFin, idAPIHisTransKasNet);
        }

        public DataTable ADRegLogExceptionErrorKasNet(string cTipoOper, string cNroSumin, string cTraceConsulta, string cTracePago, DateTime dFechaHora, string cCodigo, string cMensajeError)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegLogExceptionErrorKasnet_SP", nTimeOut, cTipoOper, cNroSumin, cTraceConsulta, cTracePago, dFechaHora, cCodigo, cMensajeError);
        }

        public DataTable ADRegRequestAPITransacLogPdp(string cTipo, string xINxml, DateTime dFechaIni, int idPDPUsuarioAuth)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegRequestTransacLogBim_SP", nTimeOut, cTipo, xINxml, dFechaIni, idPDPUsuarioAuth);
        }

        public DataTable ADRegResponseAPITransacLogPdp(int idAPITransacLogPdp, string xOUTxml, DateTime dFechaFin, int idAPIHisTransPdp)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegResponseTransacLogBim_SP", nTimeOut, idAPITransacLogPdp, xOUTxml, dFechaFin, idAPIHisTransPdp);
        }

        public DataTable ADRegLogExceptionErrorPdp(string cTipoOper, string cNroSumin, string cTraceConsulta, string cTracePago, DateTime dFechaHora, string cCodigo, string cMensajeError)
        {
            return objEjeSP.EjecSPTMO("GEN_APIRegLogExceptionErrorBim_SP", nTimeOut, cTipoOper, cNroSumin, cTraceConsulta, cTracePago, dFechaHora, cCodigo, cMensajeError);
        }
    }
}
