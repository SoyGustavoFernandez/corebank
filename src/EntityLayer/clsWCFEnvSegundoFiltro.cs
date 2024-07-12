using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFEnvSegundoFiltro
    {
        public string cToken { get; set; }
        public string cNroDocumento { get; set; }
        public bool lClienteRecurrente { get; set; }
        public bool lBancarizado { get; set; }
        public int nExperienciaNegocio { get; set; }
        public string cUbigeoNacimiento { get; set; }
        public bool lFormalizado { get; set; }
        public int nEdad { get; set; }
        public int idEstadoCivil { get; set; }
        public int idDestino { get; set; }
        public decimal nMontoSolicitado { get; set; }
        public int nPlazo { get; set; }
        public decimal nExcedente { get; set; }
        public decimal nDeudaFinanciera { get; set; }
        public decimal nEndeudamientoRCC { get; set; }
    }
}
