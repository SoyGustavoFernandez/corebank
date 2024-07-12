using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNMotCancelacion
    {
        public DataTable CNLstMotCancelacion(int idModulo)
        {
            return new clsADMotCancelacion().ADLstMotCancelacion(idModulo);
        }
    }
}
