using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPropCredito
    {
        public bool lActSecundaria { get; set; }
        public clsActividadEconomica oActPrincipal { get; set; }
        public clsActividadEconomica oActSecundaria { get; set; }
        
        public string cComEntFamiliar { get; set; }
        public string cComDestCredito { get; set; }
        public string cComAnteCred { get; set; }
        public string cComAnalisisFinan { get; set; }
        public string cComGarantias { get; set; }
        public string cComConclusiones { get; set; }
        public string cComSustentoCredito { get; set; }

        public clsPropCredito()
        {
            lActSecundaria = false;
            oActPrincipal = new clsActividadEconomica();
            oActSecundaria = new clsActividadEconomica();

            cComEntFamiliar = "";
            cComDestCredito = "";
            cComAnteCred = "";
            cComAnalisisFinan = "";
            cComGarantias = "";
            cComConclusiones = "";
        }
    }
}
