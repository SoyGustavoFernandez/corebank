using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;

namespace CAJ.CapaNegocio
{
    public class clsCNFlujoCajaBco
    {
        clsADFlujoCajaBco objFlujoCajaBco = new clsADFlujoCajaBco();
        
        public DataTable CNReprocesarFlujoCajaBco(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objFlujoCajaBco.ADReprocesarFlujoCajaBco(dFechaIni, dFechaFin);
        }

        public DataTable CNRptFlujoCajaBco(DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return objFlujoCajaBco.ADRptFlujoCajaBco(dFechaIni, dFechaFin, idMoneda);
        }
        public DataTable CNRptFlujoMensualCajaBco(DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return objFlujoCajaBco.ADRptFlujoMensualCajaBco(dFechaIni, dFechaFin, idMoneda);
        }
    }
}
