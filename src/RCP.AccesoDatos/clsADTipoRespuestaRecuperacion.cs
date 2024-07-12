using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADTipoRespuestaRecuperacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarTipoRespuestaRecuperacion()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoRespuestaRecuperacion_SP");
        }
    }
}
