using GEN.WCFTratamietoDatos.CapaNegocio;
using MVC.TratamientoUsoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MVC.TratamientoUsoDatos.Services
{
    public class TipoAutorizacionRepository
    {
        private const string CacheKey = "TipoAutorizacionStore";

        public TipoAutorizacionRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new TipoAutorizacion[]
                    {
                        new TipoAutorizacion
                        {
                            idTipo = 1, cTipo = "Glenn Block"
                        },
                        new TipoAutorizacion
                        {
                            idTipo = 2, cTipo = "Dan Roth"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }
        #region Tipo Autorizacion
     
        public RespLisTipoAutorizacion ObtenerTipoAutorizacion()
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.ListarTipoAutTratamientoUsoDatos("");

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisTipoAutorizacion objRespuesta;
             
            XmlSerializer serializer = new XmlSerializer(typeof(RespLisTipoAutorizacion));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisTipoAutorizacion)serializer.Deserialize(reader);
            }


            return objRespuesta;   
        }
        public RespuestaAutTraDatos NuevoTipoAutorizacion(string xml)
        {


            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.InsertarTipoAutTratamientoUsoDatos(xml);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespuestaAutTraDatos objRespuesta;


            XmlSerializer serializer = new XmlSerializer(typeof(RespuestaAutTraDatos));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespuestaAutTraDatos)serializer.Deserialize(reader);
            }


            return objRespuesta;
        }
        public RespuestaAutTraDatos EditarTipoAutorizacion(string xml)
        {


            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.ActualizarTipoAutTratamientoUsoDatos(xml);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespuestaAutTraDatos objRespuesta;


            XmlSerializer serializer = new XmlSerializer(typeof(RespuestaAutTraDatos));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespuestaAutTraDatos)serializer.Deserialize(reader);
            }

            return objRespuesta;
        }
        #endregion
         
    }
}