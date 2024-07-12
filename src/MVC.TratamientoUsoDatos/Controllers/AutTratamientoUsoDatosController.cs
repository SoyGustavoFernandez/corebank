using GEN.WCFTratamietoDatos.CapaNegocio;
using MVC.TratamientoUsoDatos.Models;
using MVC.TratamientoUsoDatos.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MVC.TratamientoUsoDatos.Controllers
{
    public class AutTratamientoUsoDatosController : ApiController
    {
        private AutorizacionUsoDatosRepository autorizacionRepository;
        public AutTratamientoUsoDatosController()
        {
            this.autorizacionRepository = new AutorizacionUsoDatosRepository();
        } 
        // GET api/auttratamientousodatos
        public RespLisAutorizacionTraDatos Get()
        {
            return autorizacionRepository.ObtenerAutorizacionTraUsoDatos("",0,0);
        }

        //[HttpGet]// GET api/auttratamientousodatos/5/1
        public RespLisAutorizacionTraDatos Get(string id,int idEstado, int idTipoDoc)
        {
            return autorizacionRepository.ObtenerAutorizacionTraUsoDatos(id, idEstado, idTipoDoc);
        }

        // POST api/auttratamientousodatos
        [HttpPost]
        public RespuestaAutTraDatos Post([FromBody]object value)        
        { 
            //
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = 500000000;

            MaestroAutorizacion objData = json_serializer.Deserialize<MaestroAutorizacion>(value.ToString());
             
            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(MaestroAutorizacion));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objData); //objDataFinal);
                    xml = sww.ToString(); // Your XML
                }
            } 

            RespuestaAutTraDatos objRespuesta;
            if (objData.idMaestroAutorizacion == 0)
            {
                objRespuesta = autorizacionRepository.NuevoAutorizacionTraUsoDatos(xml);
            }
            else
            {
                objRespuesta = autorizacionRepository.EditarAutorizacionTraUsoDatos(xml);

            }


            //Object to Json
            return objRespuesta; 
        }

        // PUT api/auttratamientousodatos/5

        [HttpPut]  
        public RespuestaAutTraDatos Put([FromBody]object value,int id  )
        {
            RespuestaAutTraDatos objRespuesta=new RespuestaAutTraDatos();
            objRespuesta.nCodigo = "0";
            objRespuesta.cMensaje = "OK MENSAJE";
            objRespuesta.lResultado = true;

            //Object to Json
            return objRespuesta;
        }

        // DELETE api/auttratamientousodatos/5
        public RespuestaAutTraDatos Delete(string id, string usuario, string fecha)
        {
            RespuestaAutTraDatos objRespuesta;
            objRespuesta = autorizacionRepository.QuitarAutorizacionTraUsoDatos(id, usuario, fecha);
            return  objRespuesta ;
        }
    }
}
