using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsLimCobertura
    {   
        public decimal nMonMinCobertura { get; set; }
        public decimal nMonIntCobertura { get; set; }
        public decimal nMonMaxCobertura { get; set; }
        public decimal nMonMinCoberturaDol { get; set; }
        public decimal nMonIntCoberturaDol { get; set; }
        public decimal nMonMaxCoberturaDol { get; set; }

        public int idControlTipMon { get; set; }
    }
}
