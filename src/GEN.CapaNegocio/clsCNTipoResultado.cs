using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    
    public class clsCNTipoResultado
    {
        clsADTipoResultado adTipoResultado = new clsADTipoResultado();

        public DataTable Lista()
        {
            return adTipoResultado.Lista();
        }
    }
}
