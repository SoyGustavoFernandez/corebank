using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityLayer
{
    /// <summary>
    ///Entidad credito
    /// </summary>
    public class clsCredito
    {
        public object dFechaCancelacion { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public object dFechaCulminacion { get; set; }
        public int idCuenta { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idCalificacion { get; set; }
        public int IdMoneda { get; set; }
        public int idPlanPagos { get; set; }
        public int idRecurso { get; set; }
        public int idAdeudado { get; set; }
        public int idAgencia { get; set; }
        public int nNumCre { get; set; }
        public int lRefina { get; set; }
        public int idCalificSist { get; set; }
        public int idCondContableNormal { get; set; }
        public int idCondContableVenc { get; set; }
        public int idUsuario { get; set; }
        public int nCuotas { get; set; }
        public int nAtraso { get; set; }
        public int idSolicitud { get; set; }
        public int idTipoCliente { get; set; }
        public int idUsuBlo { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public decimal nCapitalPagado { get; set; }
        public decimal nInteresPactado { get; set; }
        public decimal nInteresDia { get; set; }
        public decimal nInteresPagado { get; set; }
        public decimal nInteresComp { get; set; }
        public decimal nInteresCompPago { get; set; }
        public decimal nMoraGenerado { get; set; }
        public decimal nSaldoCapitalVenc { get; set; }
        public decimal nSaldoCapitalNormal { get; set; }
        public decimal nMoraPagada { get; set; }
        public decimal nOtrosGenerado { get; set; }
        public decimal nOtrosPagado { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaCostoEfectivo { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public string cUsuarioqUsa { get; set; }
        public int nNumReprogra { get; set; }
        public decimal nMontoCuota { get; set; }
        public bool lUnicuota { get; set; }
        public decimal nMontoSeguroMultiriesgo { get; set; }
        public decimal nPaqueteSeguro { get; set; } //Nuevo RQ401
    }

    /// <summary>
    /// coleccion de la entidad creditos
    /// </summary>
    public class clslisCredito : List<clsCredito>
    {

    }
}
