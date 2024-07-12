using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoAccionesEmp
    {
        clsADTipoAccionesEmp adAccion = new clsADTipoAccionesEmp();
        public DataTable ListarTipoAccionesEmp()
        {
            return adAccion.ListarTipoAcciones();
        }
        public DataTable ListarTipoAccionEmp()
        {
            return adAccion.ListarTipoAccion();
        }   
    }
}
