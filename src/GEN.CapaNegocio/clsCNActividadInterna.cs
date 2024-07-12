using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNActividadInterna
    {
        clsADActividadInterna objActividad = new clsADActividadInterna();
        public DataTable CNListaActividadInterna()
        {
            return objActividad.ADListaActividadInterna();
        }
    }
}
