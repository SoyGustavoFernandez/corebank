using RPT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.CapaNegocio
{
    public class clsRPTCNSaldoDeposito
    {
        clsRPTADSaldoDeposito ADSaldoDep= new clsRPTADSaldoDeposito();
        public DataTable CNSaldoDeposito(DateTime dFecha)
        {
            return ADSaldoDep.ADSaldoDeposito(dFecha);
        }
    }
}
