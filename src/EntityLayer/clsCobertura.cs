using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    ///entidad cobertura de la garantia
    /// </summary>
    public class clsCobertura
    {
        public int idCobertura { get; set; }
        public int idEstado { get; set; }
        public string cCobertura { get; set; }
    }

    /// <summary>
    ///coleccion de la entidad cobertura
    /// </summary>
    public class clslisCobertura : List<clsCobertura>
    {
    }
}
