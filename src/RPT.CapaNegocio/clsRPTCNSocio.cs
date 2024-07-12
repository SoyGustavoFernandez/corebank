using RPT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.CapaNegocio
{
    public class clsRPTCNSocio
    {
        clsRPTADSocio ADSocio = new clsRPTADSocio();
        public DataTable CNDeudorAnexo6(DateTime dFecha)
        {
            return ADSocio.ADDeudorAnexo6(dFecha);
        }

        public DataTable CNRptSaldoAportes(DateTime dFecha)
        {
            return ADSocio.ADRptSaldoAportes(dFecha);
        }
    }
}
