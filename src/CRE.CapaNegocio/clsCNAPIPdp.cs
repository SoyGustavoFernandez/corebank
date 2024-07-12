using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNAPIPdp
    {
        clsADAPIPdp objADAPIPdp;

        public clsCNAPIPdp()
        {
            objADAPIPdp = new clsADAPIPdp();
        }

        public clsCNAPIPdp(bool cConex)
        {
            objADAPIPdp = new clsADAPIPdp(cConex);
        }

        public DataTable CNConsulta(int idCuenta, string cTraceConsulta, string cFechaConsulta, string cHoraConsulta, string cCodEmpresa, string cCodServicio,
            string cCodAgencia, string cCodCanal, string cTerminal)
        {
            return objADAPIPdp.ADConsulta(idCuenta, cTraceConsulta, cFechaConsulta, cHoraConsulta, cCodEmpresa, cCodServicio,
                cCodAgencia, cCodCanal, cTerminal);
        }

        public DataTable CNPago(int idCuenta, decimal nMonto, decimal nComision, string cTracePago, string cTraceConsulta,
	        string cFechaPago, string cHoraPago, string cCodEmpresa, string cCodServicio,
	        string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return objADAPIPdp.ADPago(idCuenta, nMonto, nComision, cTracePago, cTraceConsulta,
	            cFechaPago, cHoraPago, cCodEmpresa, cCodServicio,
	            cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }

        /*public DataTable CNExtorno(int idCuenta, decimal nMonto, int nUsuExtorno, string cTracePago, string cTraceConsulta, string cFechaPago, string cHoraPago,
	        string cCodEmpresa, string cCodServicio, string cCodAgencia, string cCodCanal, string cNumFactura, string cTerminal)
        {
            return objADAPIPdp.ADExtorno(idCuenta, nMonto, nUsuExtorno, cTracePago, cTraceConsulta, cFechaPago, cHoraPago,
	            cCodEmpresa, cCodServicio, cCodAgencia, cCodCanal, cNumFactura, cTerminal);
        }*/
    }
}
