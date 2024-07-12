using MVC.TratamientoUsoDatos.Models;
using MVC.TratamientoUsoDatos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MVC.TratamientoUsoDatos.Controllers
{
    public class ReporteAutorizacionController : ApiController
    {
        
        private AutorizacionUsoDatosRepository autorizacionRepository;
        public ReporteAutorizacionController()
        {
            this.autorizacionRepository = new AutorizacionUsoDatosRepository();
        } 
        // GET api/reporteautorizacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/reporteautorizacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/reporteautorizacion
        [HttpPost]
        public RespLisAutorizacionTraDatos Post([FromBody]object value)
        {
            //
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            FiltroReporteAutorizacion objData = json_serializer.Deserialize<FiltroReporteAutorizacion>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(FiltroReporteAutorizacion));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objData);
                    xml = sww.ToString(); // Your XML
                }
            }

            RespLisAutorizacionTraDatos objRespuesta;
            
            objRespuesta = autorizacionRepository.ObtenerReporteAutorizacionTraUsoDatos(xml);

            //Object to Json
            return objRespuesta; 
        }

        // PUT api/reporteautorizacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/reporteautorizacion/5
        public void Delete(int id)
        {
        }
    }
}
