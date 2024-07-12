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
    public class SolicitudDesistimientoController : ApiController
    {
        private AutorizacionUsoDatosRepository autUsoDatosRepository;

        public SolicitudDesistimientoController()
        {
            this.autUsoDatosRepository = new AutorizacionUsoDatosRepository();
        } 
        // GET api/tipoautorizacion
        public RespLisSolDesistimientoUsoDatos Get()
        {
            return new RespLisSolDesistimientoUsoDatos();
        }
        public RespLisAutorizacionTraDatos Get(string id, int idEstado, int idTipoDoc)
        {
            return autUsoDatosRepository.ObtenerAutorizacionTraUsoDatosDesistimiento(id, idEstado, idTipoDoc);
        }

        // POST api/solicituddesetimiento  
        [HttpPost]
        public RespuestaAutTraDatos Post([FromBody]object value)       
        {
            //
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            SolDesistimientoUsoDatosDTO objData = json_serializer.Deserialize<SolDesistimientoUsoDatosDTO>(value.ToString());
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(SolDesistimientoUsoDatosDTO));
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
            objRespuesta = autUsoDatosRepository.NuevoSolDesentimientoTraUsoDatos(xml);
          


            //Object to Json
            return objRespuesta;
        }

        // PUT api/solicituddesetimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/solicituddesetimiento/5
        public void Delete(int id)
        {
        }
    }
}
