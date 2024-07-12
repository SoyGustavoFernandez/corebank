using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase.Model
{
    public class DatosJuridico
    {
        public int idAutTraDatosJuridico { get; set; }
        public int idAutTraDatosFK { get; set; }
        public int idCli { get; set; } 
        public string cNroDocumento { get; set; }
        public string cCodCliente { get; set; }
        public string cNomCliente { get; set; }
        public string cDireccion { get; set; } 

    }
}
