using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCredito
    {
        public int idSolicitud { get; set; }
        public int idEvalCred { get; set; }
        public int idCli { get; set; }
        public int idTipEvalCred { get; set; }
        public int idMoneda { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public string cMoneda { get; set; }
        public decimal nCapitalPropuesto { get; set; }
        public string cModalidadCredito { get; set; }
        public string cTipEvalCred { get; set; }
        public string cProducto { get; set; }
        public string cEstado { get; set; }
    }
}
