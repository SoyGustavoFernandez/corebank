using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsSolicitudCreditoDetalle
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idOperacion { get; set; }
        public int IdMoneda { get; set; }
        public int idUsuario { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaDesembolsoSugerido { get; set; }
        public string tObservacion { get; set; }
        public int idTipoCli { get; set; }
        public int idDestino { get; set; }
        public int idTasa { get; set; }
        public int idModalidadDes { get; set; }
        public int idActividad { get; set; }
        public int ndiasgracia { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idRecurso { get; set; }
        public int idAdeudado { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public decimal nSaldoCreditos { get; set; }
        public int idModalidadCredito { get; set; }
        public int idPromotor { get; set; }
        public string cComentAproba { get; set; }
        public int idAsesor { get; set; }
        public int idActividadInterna { get; set; }
        public int idPreSolicitud { get; set; }
        public string cVerificacion { get; set; }
        public int idMotivoDeniega { get; set; }
        public int nCuotasGracia { get; set; }
        public int idCreditosPreAprobados { get; set; }
        public int idVisita { get; set; }
        public int idEOBDesembolso { get; set; }
        public int idClasificacionInterna { get; set; }

        [XmlIgnore]
        public DateTime dFechaPrimeraCuota { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        [XmlIgnore]
        public string cOperacion { get; set; }
        [XmlIgnore]
        public int nTipCre { get; set; }
        [XmlIgnore]
        public int nSubTip { get; set; }
        [XmlIgnore]
        public int nProdu { get; set; }
        [XmlIgnore]
        public int nSubPro { get; set; }
        [XmlIgnore]
        public string cNombre { get; set; }
        [XmlIgnore]
        public string cDocumentoID { get; set; }
        [XmlIgnore]
        public int idCIIU { get; set; }
        [XmlIgnore]
        public int idSoliCambio { get; set; }
        [XmlIgnore]
        public int idCuenta { get; set; }
        [XmlIgnore]
        public string cCodCliente { get; set; }
        [XmlIgnore]
        public int IdTipoPersona { get; set; }
        [XmlIgnore]
        public int idAgencia { get; set; }
        [XmlIgnore]
        public int idEvalCred { get; set; }
        [XmlIgnore]
        public string cTipoEvaluacion { get; set; }
        [XmlIgnore]
        public int idTipEvalCred { get; set; }
        [XmlIgnore]
        public int idAgenciaUsu { get; set; }
        [XmlIgnore]
        public int idAgenciaCli { get; set; }
        [XmlIgnore]
        public bool lVerificacion { get; set; }
        [XmlIgnore]
        public decimal nCapitalAprobado { get; set; }
        [XmlIgnore]
        public decimal nTasaAprobada { get; set; }
        [XmlIgnore]
        public int nPlazoCuotaAprobado { get; set; }
        [XmlIgnore]
        public decimal nCapitalPropuesto { get; set; }
        [XmlIgnore]
        public bool lDesembolsoExterno { get; set; }
        [XmlIgnore]
        public bool lConTasaNegociable { get; set; }
        [XmlIgnore]
        public string cModalidadCredito { get; set; }
        [XmlIgnore]
        public int idSolicitudCredGrupoSol { get; set; }
        [XmlIgnore]
        public string cDireccion { get; set; }
        [XmlIgnore]
        public int idCuentaDeposito { get; set; }
        [XmlIgnore]
        public bool lCuentaDepositoAutomatico { get; set; }
        [XmlIgnore]
        public int idTipoDocumento { get; set; }
        [XmlIgnore]
        public DateTime dFechaUltPago { get; set; }
        [XmlIgnore]
        public DateTime dFechaProximoVencimiento { get; set; }
        [XmlIgnore]
        public int idTipoPlanPago { get; set; }

        public clsSolicitudCreditoDetalle()
        {
            this.idSolicitud = 0;
            this.dFechaPrimeraCuota = clsVarGlobal.dFecSystem;
            this.idCli = 0;
            this.idProducto = 0;
            this.idEstado = 0;
            this.cEstado = string.Empty;
            this.idOperacion = 0;
            this.cOperacion = string.Empty;
            this.IdMoneda = 0;
            this.idUsuario = 0;
            this.nCuotas = 0;
            this.nPlazoCuota = 0;
            this.nCapitalSolicitado = decimal.Zero;
            this.nTasaCompensatoria = decimal.Zero;
            this.nTasaMoratoria = decimal.Zero;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.dFechaDesembolsoSugerido = clsVarGlobal.dFecSystem;
            this.tObservacion = string.Empty;
            this.nTipCre = 0;
            this.nSubTip = 0;
            this.nProdu = 0;
            this.nSubPro = 0;
            this.idTipoCli = 0;
            this.cNombre = string.Empty;
            this.cDocumentoID = string.Empty;
            this.idDestino = 0;
            this.idTasa = 0;
            this.idModalidadDes = 0;
            this.idCIIU = 0;
            this.idActividad = 0;
            this.ndiasgracia = 0;
            this.idTipoPeriodo = 0;
            this.idRecurso = 0;
            this.idAdeudado = 0;
            this.idSoliCambio = 0;
            this.idCuenta = 0;
            this.nMontoAmpliado = decimal.Zero;
            this.nSaldoCreditos = decimal.Zero;
            this.cCodCliente = string.Empty;
            this.IdTipoPersona = 0;
            this.idModalidadCredito = 0;
            this.idAgencia = 0;
            this.idPromotor = 0;
            this.cComentAproba = string.Empty;
            this.idEvalCred = 0;
            this.cTipoEvaluacion = string.Empty;
            this.idTipEvalCred = 0;
            this.idAsesor = 0;
            this.idAgenciaUsu = 0;
            this.idAgenciaCli = 0;
            this.idActividadInterna = 0;
            this.idPreSolicitud = 0;
            this.lVerificacion = false;
            this.cVerificacion = string.Empty;
            this.nCapitalAprobado = decimal.Zero;
            this.nTasaAprobada = decimal.Zero;
            this.nPlazoCuotaAprobado = 0;
            this.nCapitalPropuesto = decimal.Zero;
            this.idMotivoDeniega = 0;
            this.lDesembolsoExterno = false;
            this.nCuotasGracia = 0;
            this.lConTasaNegociable = false;
            this.cModalidadCredito = string.Empty;
            this.idSolicitudCredGrupoSol = 0;
            this.idCreditosPreAprobados = 0;
            this.idVisita = 0;
            this.idEOBDesembolso = 0;
            this.cDireccion = string.Empty;
            this.idCuentaDeposito = 0;
            this.lCuentaDepositoAutomatico = false;
            this.idTipoDocumento = 0;
            this.dFechaUltPago = clsVarGlobal.dFecSystem;
            this.dFechaProximoVencimiento = clsVarGlobal.dFecSystem;
            this.idClasificacionInterna = 0;
            this.idTipoPlanPago = 0;
        }

    }
}
