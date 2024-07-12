using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    ///
    /// </summary>
    public class clsTablasXml
    {
        public int idTabla { get; set; }
        public int idEstado { get; set; }
        public bool lVigente { get; set; }
        public string cTabla { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisTablasXml : List<clsTablasXml>
    {
    }
}
