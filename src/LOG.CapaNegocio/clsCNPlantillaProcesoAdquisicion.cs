using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LOG.AccesoDatos;

namespace LOG.CapaNegocio
{
    public class clsCNPlantillaProcesoAdquisicion
    {
        clsADPlantillaProcesoAdquisicion objPlaProAdq = new clsADPlantillaProcesoAdquisicion();

        public DataTable CNCargarTipoProceso()
        {
            return objPlaProAdq.ADCargarTipoProceso();
        }

        public DataTable CNCargarEtapas()
        {
            return objPlaProAdq.ADCargarEtapas();
        }

        public DataTable CNCargarDocumentos()
        {
            return objPlaProAdq.ADCargarDocumentos();
        }

        public DataTable CNRegistrarPlantillaProcAdq(int idTipoProceso, int idEtapa, int idDocumento, int nNumDias, bool chcDocObl, bool vigente)
        {
            return objPlaProAdq.ADRegistrarPlantillaProcAdq(idTipoProceso, idEtapa, idDocumento, nNumDias, chcDocObl, vigente);
        }

        public DataTable CNCargarPlantilla(int idTipoProceso, int idEtapa)
        {
            return objPlaProAdq.ADCargarPlantilla(idTipoProceso, idEtapa);
        }

        public DataTable CNActualizarPlantillaProcAdq(int idPlantilla,int idTipoProceso, int idEtapa, int idDocumento, int nNumDias, bool chcDocObl, bool vigente)
        {
            return objPlaProAdq.ADActualizarPlantillaProcAdq(idPlantilla, idTipoProceso, idEtapa, idDocumento, nNumDias, chcDocObl, vigente);
        }

    }
}
