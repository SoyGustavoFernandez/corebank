using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.CallCenter.Modelo
{
    public class LisDatosCreContac
    {
        public string cZona { get; set; }
        public string cAgencia { get; set; }
        public int idCuenta { get; set; }
        public string cEtapaRecuperacion { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public int nDiasAtraso { get; set; }
        public decimal nSaldoCapitalVencido { get; set; }
        public decimal nSaldoCapital { get; set; }
        public decimal nSaldoInt { get; set; }
        public decimal nSaldoComp { get; set; }
        public decimal nSaldoMora { get; set; }
        public decimal nSaldoOtros { get; set; }
        public decimal nSaldoTotal { get; set; }
        public int nCuotasPendientes { get; set; }
        public int nCuotasPagadas { get; set; }
        public int nTotalCuotas { get; set; }
        public string cobs { get; set; }
        public DateTime dFechaUltimoPago { get; set; }
        public decimal nMontoCampania { get; set; }
    }
}