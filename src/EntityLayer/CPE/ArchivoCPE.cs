using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.CPE
{
    public class ArchivoCPE
    {

        public int IdArchivoCPE { get; set; }
        public int IdProcesoCPE { get; set; }
        public string NombreArchivo { get; set; }
        public string Serie_1 { get; set; }
        public int CorrelaIni_1 { get; set; }
        public int CorrelaFin_1 { get; set; }
        public string Serie_2 { get; set; }
        public int CorrelaIni_2 { get; set; }
        public int CorrelaFin_2 { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string NombreCDR { get; set; }
        public int IdEstadoEnvioCPE { get; set; }
        public string DescripcionEstadoEnvio { get; set; }
        public DateTime FechaRegEnv { get; set; }
        public int IdUsuarioRegEnv { get; set; }

    }
}
