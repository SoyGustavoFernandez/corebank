using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoNotificacion
    {
        clsADTipoNotificacion adTipoNotificacion = new clsADTipoNotificacion();
        public DataTable obtenerTipoNotificaciones(int nAtraso, int idTipoIntev)
        {
            return adTipoNotificacion.obtenerTipoNotificaciones(nAtraso, idTipoIntev);
        }
    }
}
