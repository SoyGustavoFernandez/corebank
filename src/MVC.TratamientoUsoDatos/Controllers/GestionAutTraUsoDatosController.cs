using MVC.TratamientoUsoDatos.Models;
using MVC.TratamientoUsoDatos.Services;
using System;
using System.Collections.Generic;
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
    public class GestionAutTraUsoDatosController : ApiController
    {
        private AutorizacionUsoDatosRepository autorizacionRepository;
        public GestionAutTraUsoDatosController()
        {
            this.autorizacionRepository = new AutorizacionUsoDatosRepository();
        }
        // GET api/auttratamientousodatos
        public RespLisAutorizacionTraDatosDTO Get()
        {
            return autorizacionRepository.ListarAutorizacionesTraUsoDatos("0");
        }

        // GET api/auttratamientousodatos/5
        public RespLisAutorizacionTraDatosDTO Get(string id)
        {
            return autorizacionRepository.ListarAutorizacionesTraUsoDatos(id);
        }

        // POST api/auttratamientousodatos
        [HttpPost]
        public RespuestaAutTraDatos Post([FromBody] object value)
        {
            //
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            AutorizaTratamientoUsoDatos objData = json_serializer.Deserialize<AutorizaTratamientoUsoDatos>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AutorizaTratamientoUsoDatos));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objData);
                    xml = sww.ToString(); // Your XML
                }
            }

            RespuestaAutTraDatos objRespuesta;
            if (objData.idAutTraDatos == 0)
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
        public async Task<string> Put(int id, [FromBody] object value)
        {

            //
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            AutorizaTratamientoUsoDatos objData = json_serializer.Deserialize<AutorizaTratamientoUsoDatos>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(TipoAutorizacion));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objData);
                    xml = sww.ToString();  
                }
            }

            RespuestaAutTraDatos objRespuesta;
            objRespuesta = autorizacionRepository.EditarAutorizacionTraUsoDatos(xml);

            //Object to Json
            return new JavaScriptSerializer().Serialize(objRespuesta);
        }

        // DELETE api/auttratamientousodatos/5
        public void Delete(int id)
        {
        }
    }
}
