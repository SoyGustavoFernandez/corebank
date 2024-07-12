using System;

namespace EntityLayer
{
    public class clsDetalleConfigComisiones
    {
        public int idDConfComision { get; set; }
        public int idMConfComision { get; set; }
        public int idZona { get; set; }
        public string cZona { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public DateTime dFechaInicioVigencia { get; set; }
        public DateTime dFechaFinVigencia { get; set; }
        public decimal nMontoCuotaMin { get; set; }
        public decimal nMontoCuotaMax { get; set; }
        public int nCantidadMin { get; set; }
        public int nCantidadMax { get; set; }
        public decimal nMontoCosto { get; set; }
        public decimal nPorcentajeCosto { get; set; }
    }
}
