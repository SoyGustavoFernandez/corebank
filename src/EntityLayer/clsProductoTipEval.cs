using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsProductoTipEval :ICloneable
    {
        public int idProducto { get; set; }
        public int idTipEvalCred { get; set; }
        public string cProducto { get; set; }
        public int idProductoTipEval { get; set; }
        public bool lInfoRiesgosResum { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
