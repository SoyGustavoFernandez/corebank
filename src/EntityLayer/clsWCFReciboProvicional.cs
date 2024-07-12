using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFReciboProvicional
    {
        public int idReciboProvisional{ get; set; }
        public int idUsuReg { get; set; }
        public int idTipoVinculo { get; set; }
        public int idCli { get; set; }
        public int idMoneda { get; set; }
        public int idTipoPersona { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombres { get; set; }
        public string cNumeroCelular { get; set; }
        public string cTipoVinculo { get; set; }
        public decimal nMonto { get; set; }
        public string cMoneda { get; set; }
        public string cCodigoConfirmacion { get; set; }
        public string cTitular { get; set; }
        public int nEstado { get; set; }
    }

    public class clsWCFResponseReciboProvisional
    {
        public int idReciboProvisional { get; set; }
        public int idMoneda { get; set; }
        public int nEstado { get; set; }
        public decimal nMonto { get; set; }
        public string cMessage { get; set; }
        public string cNombres { get; set; }
        public string cNumeroCelular { get; set; }
        public bool lEstadoEnvioSMS { get; set; }
        public string cCodigoConfirmacion { get; set; }
    }
}
