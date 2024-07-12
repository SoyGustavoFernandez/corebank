using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Xml.Linq;

namespace CRE.AccesoDatos
{
    public class clsADExpedienteLinea
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet getGrupoExpedienteLinea(string cGrupo, int idSolicitud, string cTipoSolicitud)
        {
            return objEjeSp.DSEjecSP("GEN_ListarExpedientes_SP", cGrupo, idSolicitud, cTipoSolicitud);
        }

        public DataSet getEjecutarSpExpediente(string cGrupo, int idSolicitud, string cTipoSolicitud, int idUsuario)
        {
            return objEjeSp.DSEjecSP("GEN_EjecutarSpExpedientes_SP", cGrupo, idSolicitud, cTipoSolicitud, idUsuario);
        }

        public DataTable guardarExpediente(string cXmlExpediente, int idSolicitud, int idUsuario, string cTipoSolicitud, string cGrupo)
        {
            return objEjeSp.EjecSP("GEN_GuardarExpediente_SP", cXmlExpediente, idSolicitud, idUsuario, cTipoSolicitud, cGrupo);
        }
        public DataTable ADGuardarExpedienteTN(string cXmlExpediente, int idSolicitud, int idUsuario, string cTipoSolicitud, string cGrupo)
        {
            return objEjeSp.EjecSP("GEN_GuardarExpedienteTN_SP", cXmlExpediente, idSolicitud, idUsuario, cTipoSolicitud, cGrupo);
        }
        public DataTable obtenerIdentificaridDescTipoDoc()
        {
            return objEjeSp.EjecSP("CRE_RecuperarIdentificarTdoc_SP");
        }


        public DataSet obtenerExpediente(int idArchivo, int idSolicitud, int idCategoriaArchivo, string cTipoSolicitud, string cExtension, int idSecundario)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerDatosExpedienteLinea_SP", idArchivo, idSolicitud, idCategoriaArchivo, cTipoSolicitud, cExtension, idSecundario);
        }

        public DataSet getMenuExpediente(int idSolicitud, string cTipoSolicitud)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerMenuExpediente_SP", idSolicitud, cTipoSolicitud);
        }

        public DataSet getDataSourceExpedienteNormal(int idDocTipoDesc, int idSolicitud, string cTipoSolicitud, int idSecundario)
        {
            return objEjeSp.DSEjecSP("GEN_EjecutarSpExpedienteIndividual_SP",idDocTipoDesc, idSolicitud, cTipoSolicitud, idSecundario);
        }

        public DataSet getDatosExpedienteNormal(int idDocTipoDesc, int idSolicitud, string cTipoSolicitud)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerDatosExpedienteLineaNormal_SP", idDocTipoDesc, idSolicitud, cTipoSolicitud);
        }

        public DataTable getDatosSolicitudIndividual(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetDatosSolicitudCre_SP", idSolicitud);
        }

        public DataTable getDatosSolicitudGrupal(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatosSolicitudGrupoSolidario_SP", idSolicitud);
        }

        public DataTable guardarLogError(int idSolicitud, string cGrupo, string cTipoSolicitud, string cMsgError, string cForm, int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_GuardarLogExpedientesLinea_SP", idSolicitud, cGrupo, cTipoSolicitud, cMsgError, cForm, idUsuario);
        }
    }
}
