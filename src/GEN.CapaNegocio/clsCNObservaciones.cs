using EntityLayer;
using GEN.AccesoDatos;
using System.Collections.Generic;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNObservaciones
    {
        public clsDBResp CNGuardarObservaciones(string xmlObservaciones)
        {
            return new clsADObservaciones().ADGuardarObservaciones(xmlObservaciones);
        }
        public List<clsObservacion> CNGetObservaciones(int idRegistro, int idTipoOperacion)
        {
            return new clsADObservaciones().ADGetObservaciones(idRegistro, idTipoOperacion);
        }

        public DataTable CNGetTipObs(int idOrigenObs, int idGrupoObs, int idEtapaEvalCred)
        {
            return new clsADObservaciones().ADGetTipObs(idOrigenObs, idGrupoObs, idEtapaEvalCred);
        }
        public DataTable CNGetGrupoObs()
        {
            return new clsADObservaciones().ADGetGrupoObs();
        }
        public DataTable CNGetEstObs(int idEstado)
        {
            return new clsADObservaciones().ADGetEstObs(idEstado);
        }
    }
}
