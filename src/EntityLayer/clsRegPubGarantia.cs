using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
    /// <summary>
    /// entidad datos en registros publicos de una garantia
    /// </summary>
    public class clsRegPubGarantia
    {
        public int idRegPub { get; set; }
        public int idGarantia { get; set; }
        public int idOfiRegis { get; set; }
        public int idSedeRegis { get; set; }
        public int idTipoCober { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecInsBlo { get; set; }
        public DateTime dFecConsGar { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }
        public string cPartidIns { get; set; }
        public string cAsiento { get; set; }
        public string cFicha { get; set; }
        public string cRubro { get; set; }
        public string cTomo { get; set; }
        public string cFolio { get; set; }
        public string cFojas { get; set; }
        public string cCodPredio { get; set; }
        public string cPreferente { get; set; }
        public bool lPrimeraVenta { get; set; }
        public string cTituloInscripcion { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisRegPubGarantia : List<clsRegPubGarantia>
    {
    }
}
