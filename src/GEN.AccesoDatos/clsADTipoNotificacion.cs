using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoNotificacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable obtenerTipoNotificaciones(int nAtraso, int idTipoIntev)
        {
            return objEjeSp.EjecSP("GEN_ListarTipoNotificacionAtraso_SP", nAtraso, idTipoIntev);
        }
    }
}
