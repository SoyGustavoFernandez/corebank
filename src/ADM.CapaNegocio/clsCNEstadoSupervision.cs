using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNEstadoSupervision
    {
        clsADEstadoSupervision objSupervisor = new clsADEstadoSupervision();

        public DataTable CNListarEstadoSupervisorOperacion()
        {
            return objSupervisor.ADListarEstadoSupervisorOperacion();
        }
    }
}
