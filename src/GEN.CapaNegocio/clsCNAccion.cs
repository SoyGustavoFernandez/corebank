using EntityLayer;
using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNAccion
    {
        clsADAccion adAccion = new clsADAccion();        

        public DataTable ListarAcciones()
        {
            return adAccion.ListarAcciones();
        }

        public DataTable ListarAccionesPorPerfil(int idPerfil)
        {
            return adAccion.ListarAccionesPorPerfil(idPerfil);
        }

        public DataTable InsUpdTipoAccionPerfil(int idPerfil, int idAccion, bool lVigente)
        {
            return adAccion.InsUpdTipoAccionPerfil(idPerfil, idAccion, lVigente);
        }

        public clsDBResp GuardarTipoAccion(int idTipoAccion, string cTipoAccion, bool lNotificacion, bool lVigente)
        {
            return adAccion.GuardarTipoAccion(idTipoAccion, cTipoAccion, lNotificacion, lVigente);
        }
    }
}
