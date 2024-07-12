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
    public class clsADAPIKasNet
    {
        private IntConexion objEjeSp;
        private int nTimeOut = 6;

        public clsADAPIKasNet()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAPIKasNet(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ADConsulta(int idCuenta, string cTraceConsulta, string cFechaConsulta, string cHoraConsulta, 
            string cCodEmpresa, string cCodServicio, string cCodAgencia, string cCodCanal, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIKasNetConsultarCredito_SP", nTimeOut, idCuenta, cTraceConsulta, cFechaConsulta, cHoraConsulta, 
                cCodEmpresa, cCodServicio, cCodAgencia, cCodCanal, cTerminal);
        }

        public DataTable ADPago(int idCuenta, decimal nMonto, decimal nComision, string cTracePago, string cTraceConsulta,
            string cFechaPago, string cHoraPago, string cCodEmpresa, string cCodServicio,
            string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIKasNetPagarCredito_SP", nTimeOut, idCuenta, nMonto, nComision, cTracePago, cTraceConsulta,
                cFechaPago, cHoraPago, cCodEmpresa, cCodServicio,
                cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }

        public DataTable ADExtorno(int idCuenta, decimal nMonto, int nUsuExtorno, string cTracePago, string cTraceConsulta, string cFechaPago, string cHoraPago,
            string cCodEmpresa, string cCodServicio, string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return this.objEjeSp.EjecSPTMO("CRE_APIKasNetExtornarPagoCredito_SP", nTimeOut, idCuenta, nMonto, nUsuExtorno, cTracePago, cTraceConsulta, cFechaPago, cHoraPago,
                cCodEmpresa, cCodServicio, cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }
    }
}
