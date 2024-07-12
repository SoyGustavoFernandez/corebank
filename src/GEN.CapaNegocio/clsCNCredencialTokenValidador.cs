using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNCredencialTokenValidador
    {
        clsADCredencialTokenValidador objCreTokenVal;

        public clsCNCredencialTokenValidador()
        {
            this.objCreTokenVal = new clsADCredencialTokenValidador();
        }

        public clsCNCredencialTokenValidador(bool cConex)
        {
            this.objCreTokenVal = new clsADCredencialTokenValidador(cConex);
        }

        public DataTable CNValidarCredenciales(string cUsuario, string cPassword, int idApiEmpresa)
        {
            return objCreTokenVal.ADValidarCredenciales(cUsuario, cPassword, idApiEmpresa);
        }

        public DataTable CNValidarToken(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            return objCreTokenVal.ADValidarToken(idAPIUsuarioAuth, idApiEmpresa, cToken);
        }

        public DataTable CNGuardarToken(int idPDPUsuarioAuth, string cToken)
        {
            return objCreTokenVal.ADGuardarToken(idPDPUsuarioAuth, cToken);
        }

        public DataTable CNOnOffServicio(int idAPIEmpresa, int idAPIUsuarioAuth, bool lEstado)
        {
            return objCreTokenVal.ADOnOffServicio(idAPIEmpresa, idAPIUsuarioAuth, lEstado);
        }

        public DataTable CNObtenerEstadoServicio(int idAPIEmpresa)
        {
            return objCreTokenVal.ADObtenerEstadoServicio(idAPIEmpresa);
        }

        public DataTable CNRegRequestAPITransacLogKasNet(string cTipo, string xINxml, DateTime dFechaIni, int idPDPUsuarioAuth)
        {
            return objCreTokenVal.ADRegRequestAPITransacLogKasNet(cTipo, xINxml, dFechaIni, idPDPUsuarioAuth);
        }

        public DataTable CNRegResponseAPITransacLogKasNet(int idAPITransacLogKasNet, string xOUTxml, DateTime dFechaFin, int idAPIHisTransKasNet)
        {
            return objCreTokenVal.ADRegResponseAPITransacLogKasNet(idAPITransacLogKasNet, xOUTxml, dFechaFin, idAPIHisTransKasNet);
        }

        public DataTable CNRegLogExceptionErrorKasNet(string cTipoOper, string cNroSumin, string cTraceConsulta, string cTracePago, DateTime dFechaHora, string cCodigo, string cMensajeError)
        {
            return objCreTokenVal.ADRegLogExceptionErrorKasNet(cTipoOper, cNroSumin, cTraceConsulta, cTracePago, dFechaHora, cCodigo, cMensajeError);
        }

        public DataTable CNRegRequestAPITransacLogPdp(string cTipo, string xINxml, DateTime dFechaIni, int idPDPUsuarioAuth)
        {
            return objCreTokenVal.ADRegRequestAPITransacLogPdp(cTipo, xINxml, dFechaIni, idPDPUsuarioAuth);
        }

        public DataTable CNRegResponseAPITransacLogPdp(int idAPITransacLogPdp, string xOUTxml, DateTime dFechaFin, int idAPIHisTransPdp)
        {
            return objCreTokenVal.ADRegResponseAPITransacLogPdp(idAPITransacLogPdp, xOUTxml, dFechaFin, idAPIHisTransPdp);
        }

        public DataTable CNRegLogExceptionErrorPdp(string cTipoOper, string cNroSumin, string cTraceConsulta, string cTracePago, DateTime dFechaHora, string cCodigo, string cMensajeError)
        {
            return objCreTokenVal.ADRegLogExceptionErrorPdp(cTipoOper, cNroSumin, cTraceConsulta, cTracePago, dFechaHora, cCodigo, cMensajeError);
        }
    }
}