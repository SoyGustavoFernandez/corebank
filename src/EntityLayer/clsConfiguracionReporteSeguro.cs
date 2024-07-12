using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfiguracionReporteSeguro
    {
        public string cConfiguracion { get; set; }
        public List<int> lstPerfil { get; set; }

        public clsConfiguracionReporteSeguro()
        {
            cConfiguracion = String.Empty;
            lstPerfil = new List<int>();
        }

    }
}
