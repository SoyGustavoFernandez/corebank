using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    public class DataCentralRiesgosPost
    {
        public bool credencialesSentinel { set; get; }
        public int idUsuario { set; get; }
        public string cUsuarioSentinelEncry { set; get; }
        public string cPasswordSentinelEncry { set; get; }
        public List<DataCentralRiesgoCliente> dataCentralRiesgoClientes { set; get; }
        public int nTipoConsulta { set; get; }
    }
}
