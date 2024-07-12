using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SolIntEls.GEN.Helper
{
    public class clsGENParams
    {
        public int nPosicion { get; set; }
        public string Tipodatos { get; set; }
        public SqlParameter Parametro { get; set; }
    }
}
