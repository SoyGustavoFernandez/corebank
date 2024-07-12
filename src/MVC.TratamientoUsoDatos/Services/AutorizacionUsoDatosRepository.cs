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
    public class AutorizacionUsoDatosRepository
    {
        private const string CacheKey = "AutorizacionStore";

        public AutorizacionUsoDatosRepository()
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
        #region Autorizacion tratamiento datos
        

        public RespLisAutorizacionTraDatos ObtenerAutorizacionTraUsoDatos(string cNroDoc,int idEstado, int idTipoDoc)
        {
             clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();
            if (idEstado == 10)
            {
                dtResGrabar = objCNTraDatos.ListarValidacionAutoUsoTratamientoDatos(cNroDoc, 1,idTipoDoc);

            }
            else
            {
                dtResGrabar = objCNTraDatos.ListarAutTratamientoUsoDatos(cNroDoc, idEstado,idTipoDoc);
            }

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatos objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatos));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatos)serializer.Deserialize(reader);
            }


            return objRespuesta;
       
        }

        public RespLisAutorizacionTraDatosDTO ObtenerHistoricoAutorizacionTraUsoDatos(string cNroDoc, int idTipoDoc)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();

            dtResGrabar = objCNTraDatos.ListarHisAutTratamientoUsoDatos(cNroDoc,   idTipoDoc);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatosDTO objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatosDTO));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatosDTO)serializer.Deserialize(reader);
            }


            return objRespuesta;

        }
        public RespLisAutorizacionTraDatosDTO ObtenerDocumentoAutorizacionTraUsoDatos(int idArchivo)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();

            dtResGrabar = objCNTraDatos.ObtieneDocAutTratamientoUsoDatos(idArchivo);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatosDTO objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatosDTO));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatosDTO)serializer.Deserialize(reader);
            }


            return objRespuesta;

        }

        public RespLisAutorizacionTraDatosDTO ListarAutorizacionesTraUsoDatos(string idCli)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.ListarManAutTraUsoDatos(idCli);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatosDTO objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatosDTO));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatosDTO)serializer.Deserialize(reader);
            } 
            return objRespuesta; 

        }
        public RespLisAutorizacionTraDatos ObtenerReporteAutorizacionTraUsoDatos(string xml)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.ListarReporteAutTratamientoUsoDatos(xml);

            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatos objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatos));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatos)serializer.Deserialize(reader);
            }


            return objRespuesta;

        } 
        public RespuestaAutTraDatos NuevoAutorizacionTraUsoDatos(string xml)
        {


            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.InsertarAutTratamientoUsoDatos(xml);

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
        public RespuestaAutTraDatos EditarAutorizacionTraUsoDatos(string xml)
        {


            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.ActualizarAutTratamientoUsoDatos(xml);

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

        public RespuestaAutTraDatos QuitarAutorizacionTraUsoDatos(string id, string usuario, string fecha)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
            DataTable dtResGrabar = new DataTable();
            dtResGrabar = objCNTraDatos.QuitarAutTratamientoUsoDatos(id, usuario, fecha);

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
        #region desistimiento de uso de datos

        public RespLisAutorizacionTraDatos ObtenerAutorizacionTraUsoDatosDesistimiento(string cNroDoc, int idEstado, int idTipoDoc)
        {
            clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();

            DataTable dtResGrabar = new DataTable();

            dtResGrabar = objCNTraDatos.ListarAutTratamientoUsoDatosDesistimiento(cNroDoc, idEstado, idTipoDoc);
         
            string testData = string.Empty;

            if (dtResGrabar.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabar.Rows[0]["RespuestaXml"]);
            }
            RespLisAutorizacionTraDatos objRespuesta;

            XmlSerializer serializer = new XmlSerializer(typeof(RespLisAutorizacionTraDatos));
            using (TextReader reader = new StringReader(testData))
            {
                objRespuesta = (RespLisAutorizacionTraDatos)serializer.Deserialize(reader);
            }


            return objRespuesta;

        }
         
            public RespuestaAutTraDatos NuevoSolDesentimientoTraUsoDatos(string xml)
            {


                clsCNTratamientoDatos objCNTraDatos = new clsCNTratamientoDatos();
                DataTable dtResGrabar = new DataTable();
                dtResGrabar = objCNTraDatos.InsertarSolicitudAutTratamientoUsoDatos(xml);

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