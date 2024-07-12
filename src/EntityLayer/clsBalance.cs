using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    /// <summary>
    /// entidad item del balance general
    /// </summary>
    public class clsItemBalance
    {
        public int idItem { get; set; }
        public int nOrden { get; set; }
        public int idItemPadre { get; set; }
        public int nNivel { get; set; }
        public int lVigente { get; set; }
        public string cDesItem { get; set; }
        public decimal nMonto { get; set; }
    }

    /// <summary>
    /// coleccion de item del balance general
    /// </summary>
    public class clsBalance : List<clsItemBalance>
    {

    }

    /// <summary>
    /// entidad balance de una fuente de ingreso independiente
    /// </summary>
    public class clsBalanceFueIng
    {
        public int idBalance { get; set; }
        public string cDateBalance { get; set; }
        public int idFuenteIngreso { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }
        public bool lAuditado { get; set; }
        public bool lMonExtran { get; set; }
        public string cContador { get; set; }
        public string cMailConta { get; set; }
        public string cDirConta { get; set; }
        public string cDocideCon { get; set; }
        public string cNumTelCon { get; set; }
        public string cCodCpp { get; set; }
        public clslisDetalleBalance DetalleBalance = new clslisDetalleBalance();
    }

    /// <summary>
    /// coleccion de la entidad clsBalanceFueIng
    /// </summary>
    public class clslisBalanceFueIng : List<clsBalanceFueIng>
    {
    }

    /// <summary>
    /// entidad detalle del balance de fuente de ingreso independiente
    /// </summary>
    public class clsDetalleBalance
    {
        public int idBalance { get; set; }
        public int nOrden { get; set; }
        public int nNivel { get; set; }
        public int lVigente { get; set; }
        public decimal nMonto { get; set; }
        public string cDesItem { get; set; }
    }

    /// <summary>
    /// coleccion de la entidad clsDetalleBalance
    /// </summary>
    public class clslisDetalleBalance : List<clsDetalleBalance>
    {
    }
}
