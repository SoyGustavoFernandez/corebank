using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.TratamientoUsoDatos.Controllers
{
    public class DocumentosFirmarController : ApiController
    {
        // GET api/documentosfirmar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/documentosfirmar/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/documentosfirmar
        public void Post([FromBody]string value)
        {
        }

        // PUT api/documentosfirmar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/documentosfirmar/5
        public void Delete(int id)
        {
        }
    }
}
