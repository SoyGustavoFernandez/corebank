using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGiroParticipante
    {
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        public bool lCliente { get; set; }
        public int idRegistro { get; set; }
        public int idTipoDocumento { get; set; }
        public string cNumeroDocumento { get; set; }
        public string cNombreCompleto { get; set; }
        public string cPaterno { get; set; }
        public string cMaterno { get; set; }
        public string cNombres { get; set; }
        public string cDireccion { get; set; }
        public string cCelular { get; set; }        
    }
}
