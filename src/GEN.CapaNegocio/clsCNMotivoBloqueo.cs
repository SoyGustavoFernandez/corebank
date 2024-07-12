using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNMotivoBloqueo
    {
        clsADMotivoBloqueo objMotivoBloqueo = new clsADMotivoBloqueo();

        public DataTable CNListaMotivoBloqueo()
        {            
            return objMotivoBloqueo.ADListaMotivoBloqueo();
        }
    }
}
