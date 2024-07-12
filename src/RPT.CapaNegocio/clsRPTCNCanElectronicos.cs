using RPT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.CapaNegocio
{
    public class clsRPTCNCanElectronicos
    {
        public DataTable CNAdmTarjetas(int idEstado, int idTipTarjeta, int idAgencia)
        {
            return new clsRPTADCanElectronicos().ADAdmTarjetas(idEstado, idTipTarjeta, idAgencia);
        }

        public DataTable CNTarjVincCtas(int idTipTarjeta, int idAgencia)
        {
            return new clsRPTADCanElectronicos().ADTarjVincCtas(idTipTarjeta, idAgencia);
        }

        public DataTable CNTarjBloqueadas(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return new clsRPTADCanElectronicos().ADTarjBloqueadas(idAgencia, dFecIni, dFecFin);
        }
    }
}
