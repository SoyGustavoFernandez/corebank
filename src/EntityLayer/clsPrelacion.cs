using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Entidad del concepto de pago por prelacion
    /// </summary>
    public class clsPrelacion   
    {
        public int idcuenta { get; set; }
        public string cConcepto { get; set; }
        public int nOrden { get; set; }
        public int idConcepto { get; set; }
    }

    /// <summary>
    /// Coleccion de la entidad prelacion
    /// </summary>
    public class clsLisPrelacion:List<clsPrelacion>
    {

    }
}
