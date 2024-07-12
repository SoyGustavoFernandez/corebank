using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADAccion
    {

        public DataTable ListarAcciones()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipoAccion_sp");
        }

        public DataTable ListarAccionesPorPerfil(int idPerfil)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipoAccionPorPerfil_sp", idPerfil);
        }

        public DataTable InsUpdTipoAccionPerfil(int idPerfil, int idAccion, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("GEN_InsUpdAccionPerfil_SP", idPerfil, idAccion, lVigente);
        }

        public clsDBResp GuardarTipoAccion(int idTipoAccion, string cTipoAccion, bool lNotificacion, bool lVigente)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("RCP_MantAccion_Sp", idTipoAccion, cTipoAccion, lNotificacion, lVigente);
            return new clsDBResp(dtResult);
        }
    }
}
