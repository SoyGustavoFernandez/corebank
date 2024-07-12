using GEN.WCFTratamietoDatos.CapaNegocio;
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
    public class TipoAutorizacionController : ApiController
    {
        private TipoAutorizacionRepository tipoautorizacionRepository;

        public TipoAutorizacionController()
        {
            this.tipoautorizacionRepository = new TipoAutorizacionRepository();
        } 
        // GET api/tipoautorizacion
        public RespLisTipoAutorizacion Get()
        {
            return tipoautorizacionRepository.ObtenerTipoAutorizacion();
        }

        // GET api/tipoautorizacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tipoautorizacion
        [HttpPost]
        public RespuestaAutTraDatos Post([FromBody]object value)
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            TipoAutorizacion objData = json_serializer.Deserialize<TipoAutorizacion>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(TipoAutorizacion));
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
            if (objData.idTipo == 0)
            {
                objRespuesta = tipoautorizacionRepository.NuevoTipoAutorizacion(xml);
            }
            else
            {
                objRespuesta = tipoautorizacionRepository.EditarTipoAutorizacion(xml);

            }


            //Object to Json
            return objRespuesta ;
        }

        // PUT api/tipoautorizacion/5
  
        public async Task<object> Put(int id, [FromBody]object value)
        {

            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            TipoAutorizacion objData = json_serializer.Deserialize<TipoAutorizacion>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(TipoAutorizacion));
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
            objRespuesta = tipoautorizacionRepository.EditarTipoAutorizacion(xml);

            //Object to Json
            return new JavaScriptSerializer().Serialize(objRespuesta);
        }

        // DELETE api/tipoautorizacion/5
        public void Delete(int id)
        {
        }
    }
}
