using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTipoRiesgo
    {
        public int idTipoRiesgo { set; get; }
        public string cTipoRiesgo { set; get; }
    }
    public class clsNivelRiesgo
    {
        public int idNivelRiesgo { set; get; }
        public string cNivelRiesgo { set; get; }
    }
    public class clsNivelTipoRiesgo
    {
        public int idTipoRiesgo { set; get; }
        public string cTipoRiesgo { set; get; }
        public int idNivelRiesgo { set; get; }
        public string cNivelRiesgo { set; get; }
        public string cComentario5 { set; get; }
    }
}
