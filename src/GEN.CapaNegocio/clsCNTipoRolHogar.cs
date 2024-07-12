using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoRolHogar
    {
        clsADTipoRolHogar ObjRolHogar = new clsADTipoRolHogar();
        public DataTable CNListaTipoRolHogar()
        {
            return ObjRolHogar.ADListaTipoRolHogar();
        }
    }
}
