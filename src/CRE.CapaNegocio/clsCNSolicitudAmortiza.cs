using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNSolicitudAmortiza
    {
        clsADSolicitudAmortiza adsoliAmortiza = new clsADSolicitudAmortiza();
        public clsSolicitudAmortiza retornarDatSolAmortiza(int idCli)
        {
            return adsoliAmortiza.retornarDatSolAmortiza(idCli);
        }

        public void insertaActSolAmortiza(clsSolicitudAmortiza solAmortiza, clslisDetSolAmortiza listaDEtAmortiza)
        {
            adsoliAmortiza.insertaActSolAmortiza(solAmortiza, listaDEtAmortiza);
        }

        public void actualizaDetSolAmortiza(int idDetSolAmortiza)
        {
            adsoliAmortiza.actualizaDetSolAmortiza(idDetSolAmortiza);
        }

        public DataTable CNLisSolOpinionRecupera()
        {
            return adsoliAmortiza.ADLisSolOpinionRecupera();
        }

        public DataTable CNInsertarOpinionRefinanciacion(int idSolicitud, bool lFavorable, string cOpinion)
        {
            return adsoliAmortiza.ADInsertarOpinionRefinanciacion(idSolicitud, lFavorable, cOpinion);
        }

        public DataTable CNrptOpinionRefinanciacion(int idSolicitud)
        {
            return adsoliAmortiza.ADrptOpinionRefinanciacion( idSolicitud);
        }

        public DataTable CNlistaOpinionRefinaXUsuarios(int idUsuario)
        {
            return adsoliAmortiza.ADlistaOpinionRefinaXUsuarios( idUsuario);
        }

        public DataTable ObtenerDetSoliRefinancia(int idSolicitud)
        {
            return adsoliAmortiza.ObtenerDetSoliRefinancia(idSolicitud);
        }
        public DataTable consultarOpinionRecuperacion(int idSolicitud)
        {
            return adsoliAmortiza.consultarOpinionRecuperacion(idSolicitud);
        }

    }
}
