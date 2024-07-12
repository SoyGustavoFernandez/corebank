using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsUnidadMedida
    {
        public int idUnidadMedida { get; set; }
        public string cUnidadMedida { get; set; }
        public string cSimbolo { get; set; }



        //TODO: BORRAR DESPUES DE INTEGRAR CON BASE DE DATOS
        public int idUnidad { get; set; }
        public string cUnidad { get; set; }
    }
}
