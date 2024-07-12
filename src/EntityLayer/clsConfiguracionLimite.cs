namespace EntityLayer
{
    public class clsConfiguracionLimite
    {
        public int idConfig { set; get; }
        public int idTipoOpe { set; get; }
        public string cTipoOperacion { set; get; }
        public int idLimiteExcep { set; get; }
        public int cLimiteExcep { set; get; }
        public decimal nLimiteInferior { set; get; }
        public decimal nLimiteSuperior { set; get; }
        public bool lVigente { set; get; }
        public int nUsuario { set; get; }
    }

    public class SolicitudExcepcionLimite
    {
        public int idTipoOperacion { get; set; }
        public int idTipoLimite { get; set; }
        public string cTipoLimite { get; set; }
        public int idSolicitud { get; set; }
        public bool lExcepcion { get; set; }
        public decimal nValAproba { get; set; }
        public int idMoneda { get; set; }
        public int idMotivo { get; set; }

    }
}
