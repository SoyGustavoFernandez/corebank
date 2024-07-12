using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADObservacionAprobador
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsADObservacionAprobador()
        {

        }

        public DataTable GrabarObservacionAprobador(int idEvalCred, int idSolicitud, int idNivelAproReg, string xmlObsAprobador)
        {
            return objEjeSp.EjecSP("CRE_GrabarObservacionApro_SP", idEvalCred, idSolicitud, idNivelAproReg, xmlObsAprobador);
        }

        public DataTable GrabarObsAprobadorGrupoSol(int idEvalCredGrupoSol, int idSolicitudCredGrupoSol, int idNivelAproReg, string xmlObsAprobadorGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_GrabarObsAproGrupoSol_SP", idEvalCredGrupoSol, idSolicitudCredGrupoSol, idNivelAproReg, xmlObsAprobadorGrupoSol);
        }

        public List<clsObservacionAprobador>  ListarObsAprobador(int idEvalCred)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_ListaObservacionesApro_SP",idEvalCred);

            List<clsObservacionAprobador> lstObsAprobador = DataTableToList.ConvertTo<clsObservacionAprobador>(dtRes) as List<clsObservacionAprobador>;
            return lstObsAprobador;
        }

        public List<clsObsAprobadorGrupoSol> ListaObsAprobadorGrupoSol(int idEvalCredGrupoSol)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_ListaObsAprobadorGrupoSol_SP", idEvalCredGrupoSol);

            List<clsObsAprobadorGrupoSol> lstObsAprobador = DataTableToList.ConvertTo<clsObsAprobadorGrupoSol>(dtRes) as List<clsObsAprobadorGrupoSol>;
            return lstObsAprobador;
        }


        public List<clsObservacionAprobador> ListarObsAprobadorSolicitud(int idSolicitud)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_ListarObsAprobadorSolicitud_SP", idSolicitud);

            List<clsObservacionAprobador> lstObsAprobador = DataTableToList.ConvertTo<clsObservacionAprobador>(dtRes) as List<clsObservacionAprobador>;
            return lstObsAprobador;
        }

        public List<clsObsAprobadorGrupoSol> ListarObsAprobadorGrupoSol(int idSolicitudCredGrupoSol)
        {
            //return objADObsApro.ListarObsAprobadorGrupoSol(idSolicitudCredGrupoSol);

            DataTable dtRes = objEjeSp.EjecSP("CRE_ListaObsAprobadorGrupoSol_SP", idSolicitudCredGrupoSol);

            List<clsObsAprobadorGrupoSol> lstObsAprobador = DataTableToList.ConvertTo<clsObsAprobadorGrupoSol>(dtRes) as List<clsObsAprobadorGrupoSol>;
            return lstObsAprobador;
        }
    }
}
