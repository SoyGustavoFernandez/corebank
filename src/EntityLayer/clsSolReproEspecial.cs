using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntityLayer
{
    public class clsSolReproEspecial
    {
        public int idSolicitud { get; set; }
        public int idCuenta { get; set; }
        public int idCli { get; set; }
        public int idMoneda { get; set; }
        public decimal nTasa { get; set; }
        public decimal nTasaNueva { get; set; }
        public decimal nMontoDesembolso { get; set; }
        public decimal nSaldo { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nFrecuencia { get; set; }
        public int nNroCuotas { get; set; }
        public string cEstadoRepro { get; set; }
        public int idTipoPlanPagoActual { get; set; }
        public int idGrupoReprog { get; set; }
        public string cGrupoReprog { get; set; }
        public int idTipoPlanPago { get; set; }
        public string cTipoPlanPago { get; set; }

        public int nDiasGracia { get; set; }
        public int nDiasPerdon { get; set; }
        public int nDiasPerdonMax { get; set; }
        public int nNroCuotaAmpliar { get; set; }
        public int nCuotasPagadas { get; set; }
        public DateTime dFechaUltimoPago { get; set; }
        public DateTime dFechaUltimaCuota { get; set; }
        public DateTime dFechaPrimeraCuota { get; set; }
        public decimal nCapitalMaxCobSeg { get; set; }
        public bool lAplicaSeguro { get; set; }
        public DateTime dFechaProxVenc { get; set; }
        public decimal nCuotaInicial { get; set; }
        public bool lUnicuota { get; set; }
        public int nPrepagado { get; set; }
        public int nNumDiaCuotaMin { get; set; }
        public int idEstado { get; set; }
        public int nDiasGraciaOriginal { get; set; }
        public int nNroReproEspecial { get; set; }
        public bool lReprogramacion { get; set; }
        public DateTime dFechaRepro
        {
            get 
            {
                return dFechaUltimoPago.AddDays(nDiasPerdon);
            }
        }

        public int nCuotasFaltantes 
        { 
            get
            {
                return nNroCuotaAmpliar - nCuotasPagadas;
            } 
        }

        public DataTable dtConfigGastos { get; set; } 
    }
}
