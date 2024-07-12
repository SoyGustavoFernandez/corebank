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
    public class clsSolicitudAmortiza
    {
        public int idSolicitudAmortiza { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }
        public int idUsuReg { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaReg { get; set; }

        
        public clslisDetSolAmortiza listaDetalle = new clslisDetSolAmortiza(); 
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisSolicitudAmortiza : List<clsSolicitudAmortiza>
    {
    }

    /// <summary>
    ///
    /// </summary>
    public class clsDetSolAmortiza
    {
        public int idDetSolAmortiza { get; set; }
        public int idSolicitudAmortiza { get; set; }
        public int idCuenta { get; set; }
        public int idUsuReg { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaReg { get; set; }
        public decimal nCapital { get; set; }
        public decimal nInteres { get; set; }
        public decimal nIntComp { get; set; }
        public decimal nMora { get; set; }
        public decimal nGastos { get; set; }
        public int idMoneda { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisDetSolAmortiza : List<clsDetSolAmortiza>
    {
    }
}
