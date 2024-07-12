using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCostos : clsDetEstResEval
    {
        public override decimal nPUnitario
        {
            get { return listCosteo.Sum(x => x.nTotalMA); }
            set { }
        }
        
        public List<clsCosteo> listCosteo { get; set; }

        public clsCostos()
        {
            listCosteo = new List<clsCosteo>();
        }
    }
}
