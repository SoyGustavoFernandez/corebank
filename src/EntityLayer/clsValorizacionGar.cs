using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityLayer
{
    /// <summary>
    /// entidad valorizacion de la garantia
    /// </summary>
    public class clsValorizacionGar
    {
        public int idValorizacion { get; set; }
        public int idGarantia { get; set; }
        public int idTasador { get; set; }
        public int idCondiInmueble { get; set; }
        public int idEstadoConservacion { get; set; }
        public int idMatPared { get; set; }
        public int idMatTecho { get; set; }
        public int idMatVenPuer { get; set; }
        public int nNumPisos { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecUltVal { get; set; }
        public DateTime dFecVenVal { get; set; }
        public DateTime dFecRegistro { get; set; }
        public DateTime dFecMod { get; set; }
        public decimal nAreaTerreno { get; set; }
        public decimal nAreaContru { get; set; }
        public decimal nValorRealiza { get; set; }
        public decimal nValorComercial { get; set; }
        public decimal nValorMercado { get; set; }
        public decimal nValorEdifica { get; set; }
        public decimal nValorNuevo { get; set; }
        public decimal nValorVenta { get; set; }
        public decimal dValorContable { get; set; }
        public decimal dValorConstituido { get; set; }

    }

    /// <summary>
    /// coleccion de la entidad valorizacion
    /// </summary>
    public class clslisValorizacionGar : List<clsValorizacionGar>
    {
    }
}
