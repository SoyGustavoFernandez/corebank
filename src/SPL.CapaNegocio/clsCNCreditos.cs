using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPL.AccesoDatos;

namespace SPL.CapaNegocio
{
    public class clsCNCreditos
    {
        clsADCreditos adCreditos;
        public clsCNCreditos()
        {
            adCreditos = new clsADCreditos();
        }
        public DataTable CNCreditosCanceladosAnticipadamente(DateTime dFecIni, DateTime dFecFin, Decimal nMontoIni, Decimal nMontoFin, int idAgencia, int idMoneda)
        {
            return adCreditos.ADCreditosCanceladosAnticipadamente( dFecIni, dFecFin, nMontoIni, nMontoFin, idAgencia, idMoneda);
        }
    }
}
