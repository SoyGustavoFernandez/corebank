using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoComiteCred
    {
        clsADTipoComiteCred objTipoComiteCred = new clsADTipoComiteCred();

        public DataTable ListarTipoComiteCred()
        {
            return objTipoComiteCred.ListarTipoComiteCred();
        }
    }
}
