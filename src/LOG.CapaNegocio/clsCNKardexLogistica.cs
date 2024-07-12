using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNKardexLogistica
    {
        public DataTable BusKardexLog(int idKardex)
        {
            return new clsADKardexLogistica().BusKardexLog(idKardex);
        }
    }
}
