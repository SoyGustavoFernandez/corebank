using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsReporte
    {
        public int IDReporte { get; set; }
        public string IDModulo { get; set; }
        public string Reporte { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public bool lActivo { get; set; }

    }

    public enum enuFormatoReporte
    {
        Excel=1,
        Word=2,
        Pdf=3,
        Imagen=4,
        Ninguno=0
    }
}
