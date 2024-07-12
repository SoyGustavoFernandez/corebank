using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNOperacionCredito
    {
        clsADOperacionCredito objOperCred = new clsADOperacionCredito();

        public DataTable CNListarOperacionCredito(string cIdsOperacion="0")
        {
            return objOperCred.ADListarOperacionCredito(cIdsOperacion);
        }
    }
}
