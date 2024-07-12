using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNTipoRespuestaRecuperacion
    {
        clsADTipoRespuestaRecuperacion tipoRespuesta = new clsADTipoRespuestaRecuperacion();

        public DataTable listarTipoRespuestaRecuperacion()
        {
            return tipoRespuesta.listarTipoRespuestaRecuperacion();
        }
    }
}
