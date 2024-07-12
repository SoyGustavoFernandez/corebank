using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    /// <summary>
    /// clase cuenta contable
    /// </summary>
    public class clsCtaContable
    {
        public int idCuenta { get; set; }
        public int idCuentaPadre { get; set; }
        public string cCuentaContable { get; set; }
        public string cDescripcion { get; set; }
        public string cDesCtaCtb { get; set; }
        public int nLongitud { get; set; }
        public bool lVigente { get; set; }
        public bool lAgencia { get; set; }
        public int nAgencia { get; set; }
        public int nHijos { get; set; }
        public decimal nValSoles { get; set; }
        public decimal nValDolares { get; set; }
        public bool lIndicaSBS { get; set; }
        public int idNaturalezaCta { get; set; }
        public decimal nValorIntegrado { get; set; }
    }
}
