using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityLayer
{
    public class clsVinculado
    {

    }

    /// <summary>
    /// Entidad tipo de vinculo que mantiene una persona con otra
    /// </summary>
    public class clsTipoVinculo
    {
        public int idTipoVinculo { get; set; }
        public string cTipoVinculo { get; set; }
        public bool lVigente { get; set; }
        public int nTipVinPer { get; set; }
    }

    /// <summary>
    /// Coleccion de la entidad tipo de vinculo
    /// </summary>
    public class clslisTipoVinculo : List<clsTipoVinculo>
    {

    }
}
