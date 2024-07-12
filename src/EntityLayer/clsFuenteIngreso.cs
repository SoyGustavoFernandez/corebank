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
    public class clsFuentesIngreso
    {
        public int idFuenteIngreso { get; set; }
        public int idCli { get; set; }
        public int idTipoFuente { get; set; }
        public int idCliFuente { get; set; }
        public int idRelacLaboral { get; set; }
        public int idCondiLaboral { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuModifica { get; set; }
        public int idEstado { get; set; }
        public int nLaboraDesde { get; set; }
        public int nFamMasculino { get; set; }
        public int nFamFemenino { get; set; }
        public int nNoFamMascu { get; set; }
        public int nNoFamFeme { get; set; }
        public int idCondicion { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaModifica { get; set; }
        public decimal nIngresos { get; set; }
        public string cCodEmpleado { get; set; }
        public int idActivEco { get; set; }
        public bool lIndPrincipal { get; set; }
        public string cReferCentroLaboral { get; set; }
        public string cDetalleActivLaboral { get; set; }
        public int nDias { get; set; }
        public int nAnios { get; set; }
        public int nMeses { get; set; } 
        public clslisBalanceFueIng listaBalances = new clslisBalanceFueIng();
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisFuentesIngreso : List<clsFuentesIngreso>
    {
    }
}
