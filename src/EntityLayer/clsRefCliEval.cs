using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsRefCliEval
    {
        public int idRefCliEval { get; set; }
        public int idEvalCred { get; set; }
        public int idTipoRefCli { get; set; }
        public string cConcepto { get; set; }
        public string cDireccion { get; set; }
        public string cVinculo { get; set; }
        public string cNumeroCelular { get; set; }
        public byte nEstado { get; set; }

        public clsRefCliEval()
        {
            idRefCliEval = 0;
            idEvalCred = 0;
            idTipoRefCli = 1;
            cConcepto = "";
            cDireccion = "";
            cVinculo = "";
            cNumeroCelular = "";
            nEstado = 1;
            //lVigente = true;
        }
    }
}
