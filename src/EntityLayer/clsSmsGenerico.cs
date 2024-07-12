using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{

    /// <summary>
    /// Clase que representa la solicitud de SMS.
    /// </summary>
    public class clsSmsRequest
    {
        public string phone { get; set; }

        public string content { get; set; }
    }

    /// <summary>
    /// Clase que representa la respuesta de SMS.
    /// </summary>
    public class clsSmsResponse
    {
        public string id { get; set; }

        public string phone { get; set; }
    }
}
