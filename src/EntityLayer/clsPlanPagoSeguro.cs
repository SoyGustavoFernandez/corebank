namespace EntityLayer
{
    public class clsPlanPagoSeguro
    {
        public int idTipoPlan { get; set; }
        public string cDescripcion { get; set; }
        public int nMinMes { get; set; }
        public int nMaxMes { get; set; }
        public decimal nPrecioMensual { get; set; }
        public int nMeses { get; set; }
        public bool lFijo { get; set; }
        public bool lSolicitud { get; set; }
        public int idConcepto { get; set; }
        public int idTipoSeguro { get; set; }
        public string cTipoSeguro { get; set; }
    }
}