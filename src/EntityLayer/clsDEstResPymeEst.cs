using System;

namespace EntityLayer
{
    public class clsDEstResPymeEst
    {
        public int idDEstRes { get; set; }
        public int idMEstRes { get; set; }
        public int idItemEstRes { get; set; }
        public int idEEFF { get; set; }
        public decimal nValorBase { get; set; }
        public int idMeses { get; set; }
        public string cMes { get; set; }
        public int nMes { get; set; }
        public decimal nIncremento { get; set; }
        public decimal nValorMes { get; set; }
        public int nOrden { get; set; }
        public bool lEditable { get; set; }
        public string cDescripcion { get; set; }
        public DateTime? dFechaMod { get; set; }
        public bool lVigente{ get; set; }
    }
}
