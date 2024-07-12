using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
    public class clsWCFHojaRuta
    {

        public int idHojaRuta { get; set; }
        public string dFechaInicio { get; set; }
        public string dFechaFin { get; set; }	
        public string dFechaRegistro	{ get; set; }	
        public string cEstadoHojaRuta { get; set; }
        public int nCreditos { get; set; }
        public int nKilometrajeInicio { get; set; }
        
    }
}
