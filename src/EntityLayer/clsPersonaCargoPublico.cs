using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsPersonaCargoPublico
    {
        public int idCod { get; set; }
        public string cNombres { get; set; }
        public string cApePaterno { get; set; }
        public string cApeMaterno { get; set; }
        public string cCargo { get; set; }
        public string cInstitucion { get; set; }
        public int nNumDoc { get; set; }
    }


    public class clsListaPersonaCargoPub : List<clsPersonaCargoPublico>
    {

    }
}
