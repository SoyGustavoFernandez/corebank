using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Entidad estado de conservacion del inmueble
    /// </summary>
    public class clsEstadoConservacion
    {
        public int idEstadoConservacion { get; set; }
        public string cEstadoConservacion { get; set; }
        public int idEstado { get; set; }

        public override string ToString()
        {
            return cEstadoConservacion;
        }
    }

    /// <summary>
    /// coleccion de la entidad estado de conservacion
    /// </summary>
    public class clslisEstadoConservacion:List<clsEstadoConservacion>
    {
        
    }
}
