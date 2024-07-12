using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Entidad material de contruccion
    /// </summary>
    public class clsMaterial
    {
        public int idMaterial { get; set; }
        public string cMaterial { get; set; }
        public int nTipoContruccion { get; set; }
        public int idEstado { get; set; }

        public override string ToString()
        {
            return cMaterial;
        }
    }

    /// <summary>
    /// coleccion de la entidad material de construccion
    /// </summary>
    public class clslisMaterial:List<clsMaterial>
    {
        
    }
}
