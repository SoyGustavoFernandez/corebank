using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace LOG.AccesoDatos
{
    public class clsADPlantillaProcesoAdquisicion
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();

        public DataTable ADCargarTipoProceso()
        {
            return objEjeSP.EjecSP("LOG_CargarTipoProceso_SP");
        }

        public DataTable ADCargarEtapas()
        {
            return objEjeSP.EjecSP("LOG_CargarEtapas_SP");
        }

        public DataTable ADCargarDocumentos()
        {
            return objEjeSP.EjecSP("LOG_CargarDocumentos_SP");
        }
        
        public DataTable ADRegistrarPlantillaProcAdq(int idTipoProceso, int idEtapa, int idDocumento, int nNumDias, bool chcDocObl, bool vigente)
        {
            return objEjeSP.EjecSP("LOG_RegistrarPlantillaProcAdq_SP", idTipoProceso, idEtapa, idDocumento, nNumDias, chcDocObl, vigente);
        }

        public DataTable ADCargarPlantilla(int idTipoProceso, int idEtapa)
        {
            return objEjeSP.EjecSP("LOG_CargarPlantilla_SP", idTipoProceso, idEtapa);
        }

        public DataTable ADActualizarPlantillaProcAdq(int idPlantilla,int idTipoProceso, int idEtapa, int idDocumento, int nNumDias, bool chcDocObl, bool vigente)
        {
            return objEjeSP.EjecSP("LOG_ActualizarPlantillaProcAdq_SP", idPlantilla, idTipoProceso, idEtapa, idDocumento, nNumDias, chcDocObl, vigente);
        }

    }
}
