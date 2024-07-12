using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNMagnitudEmpresarial
    {
        clsADMagnitudEmpresarial objMagnitud = new clsADMagnitudEmpresarial();
        public DataTable CNListaMagnitudEmpresarial(int idTipoPersona = 0)
        {
            return objMagnitud.ADListaMagnitudEmpresarial(idTipoPersona);
        }
    }
}
