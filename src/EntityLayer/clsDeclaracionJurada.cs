using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    ///
    /// </summary>
    public class clsDeclaracionJurada
    {
        public int idDeclaracion { get; set; }
        public int idCli { get; set; }
        public int idActividad { get; set; }
        public int idDireccion { get; set; }
        public int idUbigeo { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }
        public bool lSujetoObligado { get; set; }
        public bool lOficialCumplimiento { get; set; }
        public string cActividad { get; set; }
        public string cDireccion { get; set; }
        public string cDistrito { get; set; }
        public string cProvincia { get; set; }
        public string cDepartamento { get; set; }
        public string cAnexo { get; set; }
        public string cOtraOcupacion { get; set; }
        public decimal nIngresosMensuales { get; set;}
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisDeclaracionJurada : List<clsDeclaracionJurada>
    {
    }

    
}
