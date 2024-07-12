using System;
using System.Collections.Generic;

namespace EntityLayer
{
    /// <summary>
    /// Entidad poliza de una garantia
    /// </summary>
    public class clsPolizaGarantia
    {
        public int idPoliza { get; set; }	
        public int idGarantia { get; set; }	
        public int idCompania { get; set; }	
        public string cNumPoliza { get; set; }	
        public decimal nCobertura { get; set; }	
        public DateTime dFecIniPol { get; set; }	
        public DateTime dFecFinPol { get; set; }	
        public string cNumCerti { get; set; }	
        public int nIndSeguro { get; set; }	
        public DateTime dFechaReg { get; set; }	
        public int idUsuReg { get; set; }	
        public DateTime dFechaMod { get; set; }	
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public decimal nPrima { get; set; }
        public int idMoneda { get; set; }
        public bool lPolizaExterna { get; set; }
    }

    /// <summary>
    /// coleccion de la entidad poliza
    /// </summary>
    public class clslisPolizaGarantia:List<clsPolizaGarantia>
    {
        
    }
}
