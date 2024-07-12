using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEnvioGiro
    {
        public DateTime dFechaGiro { get; set; }
        public int idUsuarioRegistra { get; set; }
        public int idMoneda { get; set; }
        public int idCuentaDeposito { get; set; }
        public decimal nMontoGiro { get; set; }
        public decimal nMontoComisionGiro { get; set; }  
        public decimal nMontoITF { get; set; }        
        public decimal nMontoRedondeo { get; set; }        
        public string cClaveGiro { get; set; }
        public int idProducto { get; set; }
        public int idCanal { get; set; }
        public int idTipoOperacion { get; set; }
        public int idMotivoOperacion { get; set; }
        public int idTipoPago { get; set; }
        public bool lModificaSaldoLinea { get; set; }
        public int idTipoTransac { get; set; }
        public decimal nMontoTotal { get; set; }
        public clsGiroParticipante objRemitente { get; set; }
        public clsGiroParticipante objDestinatario { get; set; }

        
    }    
}
