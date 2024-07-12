using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.CallCenter.Modelo
{
    public class LisPlanTrabContac
    {
        public int idCli { get; set; }
        //public string cDocumentoID { get; set; }
        public string cNombreCliente { get; set; }
        public int idCuenta { get; set; }
        public string cEtapaRecuperacion { get; set; }
        //public decimal nSaldoTotal { get; set; }
        public string cTelefonos { get; set; }
    }
}