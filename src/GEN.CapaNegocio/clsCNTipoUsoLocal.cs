using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoUsoLocal
    {
        public DataTable ListarTipoUsoLocal()
        {
            return new clsADTipoUsoLocal().ListarTipoUsoLocal();
        }
    }
}
