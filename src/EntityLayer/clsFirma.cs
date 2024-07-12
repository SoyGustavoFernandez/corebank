using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityLayer
{
    /// <summary>
    ///
    /// </summary>
    public class clsFirma
    {
        public Image imgFirma { get; set; }
        public int idCli { get; set; }
        public string cFirma { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }

        public override string ToString()
        {
            return cFirma;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisFirma : List<clsFirma>
    {
    }
}
