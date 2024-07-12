using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// entidad tipo de relacion laboral
    /// </summary>
    public class clsRelacLaboral
    {
        public int idRelacLaboral { get; set; }
        public bool lVigente { get; set; }
        public string cRelacLaboral { get; set; }
        public string cCodigoSBS { get; set; }
    }

    /// <summary>
    /// coleccion de la entidad relacion laboral
    /// </summary>
    public class clslisRelacLaboral : List<clsRelacLaboral>
    {
    }
}
