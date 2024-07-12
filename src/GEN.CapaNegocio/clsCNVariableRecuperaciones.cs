using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNVariableRecuperaciones
    {
        clsADVariableRecuperaciones adVariableRecuperaciones = new clsADVariableRecuperaciones();
        public DataTable listar()
        {
            return adVariableRecuperaciones.listar();
        }
    }
}
