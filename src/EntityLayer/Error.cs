using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class Error
    {
        public int nIDLogErr { get; set; }
        public string cNomModGen { get; set; }
        public string cNomForGen { get; set; }
        public string cNomObjGen { get; set; }
        public string cTipErrGen { get; set; }
        public int nLinGenErr { get; set; }
        public string cDesErrGen { get; set; }
        public DateTime dFecHorGen { get; set; } 
    }
}
