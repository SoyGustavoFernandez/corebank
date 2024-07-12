using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNObservacionAprobador
    {
        clsADObservacionAprobador objADObsApro = new clsADObservacionAprobador();

        public clsCNObservacionAprobador()
        {

        }

        public DataTable GrabarObservacionAprobador(int idEvalCred, int idSolicitud, int idNivelAproReg, string xmlObsAprobador)
        {
            return objADObsApro.GrabarObservacionAprobador(idEvalCred,idSolicitud,idNivelAproReg,xmlObsAprobador);
        }

        public DataTable GrabarObsAprobadorGrupoSol(int idEvalCredGrupoSol, int idSolicitudCredGrupoSol, int idNivelAproReg, string xmlObsAprobadorGrupoSol)
        {
            return objADObsApro.GrabarObsAprobadorGrupoSol( idEvalCredGrupoSol, idSolicitudCredGrupoSol, idNivelAproReg, xmlObsAprobadorGrupoSol);
        }

        public List<clsObservacionAprobador> ListarObsAprobador(int idEvalCred)
        {
            return objADObsApro.ListarObsAprobador(idEvalCred);
        }

        public List<clsObservacionAprobador> ListarObsAprobadorSolicitud(int idSolicitud)
        {
            return objADObsApro.ListarObsAprobadorSolicitud(idSolicitud);
        }

        public List<clsObsAprobadorGrupoSol> ListarObsAprobadorGrupoSol(int idSolicitudCredGrupoSol)
        {
            return objADObsApro.ListarObsAprobadorGrupoSol(idSolicitudCredGrupoSol);
        }
    }
}
