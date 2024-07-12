using System;

namespace EntityLayer
{
    public class clsRPTCabecereFechaValor
    {
        public int idRegistro { get; set; }
        public string cMotivo { get; set; }
        public string cSustento { get; set; }
        public string cWinUser { get; set; }
        public DateTime dFechaValor { get; set; }
        public string cNombreArchivo { get; set; }
        public byte[] bArchivoBinary { get; set; }
    }
}