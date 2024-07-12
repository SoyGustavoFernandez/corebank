using GEN.Funciones;
using System;
using System.Data;

namespace EntityLayer
{
    public class clsCreditoProp
    {
        public int idOrigenCredProp { get; set; }
        public int idSolicitud { get; set; }
        public int idSolAproba { set; get; }
        public int idNivelAprRanOpe { set; get; }
        public int idCli { get; set; }
        public int idActividad { get; set; }
        public int idActividadInterna { get; set; }
        public decimal nMonto { get; set; }
        public decimal nMontoMinimo { get; set; }
        public decimal nMontoMaximo { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public int nCuotas { get; set; }
        public int nPlazo { get; set; }
        public int idTipoPeriodo { get; set; }
        public string cDescripTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public string cModalidadCredito { get; set; }
        public int idModalidadCredito { get; set; }
        public string cOperacion { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public string cTipoCredito { get; set; }
        public string cSubTipo { get; set; }
        public string cTipoProducto { get; set; }
        public string cSubProducto { get; set; }
        public string cComentarios { set; get; }
        public int idAsesor { set; get; }
        public int idOperacion { set; get; }
        public int idEvalCred { set; get; }
        public int idEstado { set; get; }
        public string cEstado { set; get; }
        public int idSubProducto { get; set; }
        public decimal nActivo { get; set; }
        public decimal nPasivo { get; set; }
        public decimal nInventario { get; set; }
        public decimal nPatrimonio { get; set; }
        public decimal nCostos { get; set; }
        public decimal nDeudas { get; set; }
        public decimal nNeto { get; set; }
        public decimal nDisponible { get; set; }
        public decimal nCuotaAprox { get; set; }
        public bool lVerificacion { get; set; }
        public int idMotRechazo { get; set; }
        public int idAgencia { get; set; }
        public int nPlazoTotalDias { get; set; }
        public int idModalidadDes { get; set; }
        public int idGrupoSolidario{ get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idEvalCredGrupoSol { get; set; }
        public int idGrupoSolidarioCiclo { get; set; }
        public int idGrupoSolidarioTipo { get; set; }
        public bool lConTasaNegociable { get; set; }
        public int idClasificacionInterna { get; set; }
        public int idOferta { get; set; }
        /// <summary>
        /// Retorna Tasa Efectivo Anual (TEA)
        /// </summary>
        public decimal nTea { get { return nTasaCompensatoria; } }

        /// <summary>
        /// Retorna Tasa Efectivo Mensual (TEM)
        /// </summary>
        public decimal nTem { get { return Convert.ToDecimal(clsMathFinanciera.TEM(Convert.ToDouble(nTea))); } }
        public decimal nSaldoCapital { get; set; }
        public decimal nMontoCancelacion { get; set; }
        public decimal nMontoAmpliar { get; set; }
        public int idPaqueteSeguro { get; set; }

        public clsCreditoProp()
        {
            this.idMoneda = 1;
            this.dFechaDesembolso = clsVarGlobal.dFecSystem;
            this.lVerificacion = false;

            this.nCuotasGracia = 0;
            this.nCuotaGraciaAprox = 0;
            this.nTotalMontoPagar = 0;
            this.cCalendarioPagos = "";
            this.idEstado = 0;
            this.idAgencia = 0;

            this.nPlazoTotalDias = 0;
            this.nSaldoCapital = decimal.Zero;
            this.nMontoCancelacion = decimal.Zero;
            this.nMontoAmpliar = decimal.Zero;
            idPaqueteSeguro = -1;
        }

        public bool lExpuestoRCC { get; set; }

        public int nCuotasGracia { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }
        public DataTable dtCalendarioPagos { get; set; }
        public string cCalendarioPagos { get; set; }
        public decimal nTotalMontoPagar { get; set; }
        public decimal nMontoSolicitado { get; set; }

        public DateTime dFechaPrimeraCuota { get; set; }
        public int idDetalleGasto { get; set; }
        public int idDestino { get; set; }
        public string cDestino { get; set; }
        public string cNombreCli { get; set; }
        public string cNombreGrupoSol { get; set; }
        public bool lTieneTasa { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public string cActividadInterna { get; set; }
        public decimal nTIM { get; set; }

        public clsWCFRespuesta oRespuesta;
        public clsCreditoProp Clone()
        {
            return new clsCreditoProp()
            {
                idOrigenCredProp = this.idOrigenCredProp,
                idSolicitud = this.idSolicitud,
                idSolAproba = this.idSolAproba,
                idNivelAprRanOpe = this.idNivelAprRanOpe,
                idCli = this.idCli,
                idActividad = this.idActividad,
                idActividadInterna = this.idActividadInterna,
                nMonto = this.nMonto,
                idMoneda = this.idMoneda,
                cMoneda = this.cMoneda,
                nCuotas = this.nCuotas,
                nPlazo = this.nPlazo,
                idTipoPeriodo = this.idTipoPeriodo,
                cDescripTipoPeriodo = this.cDescripTipoPeriodo,
                nPlazoCuota = this.nPlazoCuota,
                nDiasGracia = this.nDiasGracia,
                dFechaDesembolso = this.dFechaDesembolso,
                idTasa = this.idTasa,
                nTasaCompensatoria = this.nTasaCompensatoria,
                cModalidadCredito = this.cModalidadCredito,
                cOperacion = this.cOperacion,
                idProducto = this.idProducto,
                cProducto = this.cProducto,
                cTipoCredito = this.cTipoCredito,
                cSubTipo = this.cSubTipo,
                cTipoProducto = this.cTipoProducto,
                cSubProducto = this.cSubProducto,
                cComentarios = this.cComentarios,
                idAsesor = this.idAsesor,
                idOperacion = this.idOperacion,
                idEvalCred = this.idEvalCred,
                idEstado = this.idEstado,
                cEstado = this.cEstado,
                idSubProducto = this.idSubProducto,
                nActivo = this.nActivo,
                nPasivo = this.nPasivo,
                nInventario = this.nInventario,
                nPatrimonio = this.nPatrimonio,
                nCostos = this.nCostos,
                nDeudas = this.nDeudas,
                nNeto = this.nNeto,
                nDisponible = this.nDisponible,
                nCuotaAprox = this.nCuotaAprox,
                lVerificacion = this.lVerificacion,
                idMotRechazo = this.idMotRechazo,
                lExpuestoRCC = this.lExpuestoRCC,
                nCuotasGracia = this.nCuotasGracia,
                nCuotaGraciaAprox = this.nCuotaGraciaAprox,
                dtCalendarioPagos = this.dtCalendarioPagos,
                cCalendarioPagos = this.cCalendarioPagos,
                nTotalMontoPagar = this.nTotalMontoPagar,
                idAgencia = this.idAgencia,
                nMontoSolicitado = this.nMontoSolicitado,
                idClasificacionInterna = this.idClasificacionInterna,
                idOferta = this.idOferta,
                idPaqueteSeguro = this.idPaqueteSeguro,
            };
        }
    }
}
