using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTipoTasa
    {
        public int idTipoTasa { get; set; }
        public string cTipoTasa { get; set; }
        public Nullable<bool> lVigente { get; set; }
        public Nullable<int> idModulo { get; set; }
    }
}
