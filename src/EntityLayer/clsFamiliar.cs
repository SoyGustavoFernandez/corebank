using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsFamiliar
    {
        public int idFam { get; set; }
        public string cNombres { get; set; }
        public string cApePaterno { get; set; }
        public string cApeMaterno { get; set; }
        public string nNumDoc { get; set; }
        public int nIdVinculo { get; set; }
        public string cDescripcion { get; set; }
        public int idTipoDoc { get; set; }
        public string cTipoDoc { get; set; }
        public string cDireccion { get; set; }
    }

    public class clsListaFamiliar:List<clsFamiliar>
    {    
    }
}
