using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADAPIPdp
    {
        private IntConexion objEjeSp;
        private int nTimeOut = 6;

        public clsADAPIPdp()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAPIPdp(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ADConsulta(int idCuenta, string cTraceConsulta, string cFechaConsulta, string cHoraConsulta, 
            string cCodEmpresa, string cCodServicio, string cCodAgencia, string cCodCanal, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIBimConsultarCredito_SP", nTimeOut, idCuenta, cTraceConsulta, cFechaConsulta, cHoraConsulta, 
                cCodEmpresa, cCodServicio, cCodAgencia, cCodCanal, cTerminal);
        }

        public DataTable ADPago(int idCuenta, decimal nMonto, decimal nComision, string cTracePago, string cTraceConsulta,
            string cFechaPago, string cHoraPago, string cCodEmpresa, string cCodServicio,
            string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIBimPagarCredito_SP", nTimeOut, idCuenta, nMonto, nComision, cTracePago, cTraceConsulta,
                cFechaPago, cHoraPago, cCodEmpresa, cCodServicio,
                cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }

        /*public DataTable ADExtorno(int idCuenta, decimal nMonto, int nUsuExtorno, string cTracePago, string cTraceConsulta, string cFechaPago, string cHoraPago,
            string cCodEmpresa, string cCodServicio, string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIBimExtornarPagoCredito_SP", nTimeOut, idCuenta, nMonto, nUsuExtorno, cTracePago, cTraceConsulta, cFechaPago, cHoraPago,
                cCodEmpresa, cCodServicio, cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }*/
    }
}
