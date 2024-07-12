using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsConfigTipoComprobante
    {
        public int idTipComPag { get; set; }
        public decimal nValIgv { get; set; }
        public bool? lisGravado { get; set; }
        public int? idIGV { get; set; }
    }
}
