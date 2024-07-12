using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GEN.Funciones;

namespace EntityLayer
{
    public class clsDesembolsoSolicitud
    {
        private clsFunUtiles utiles = new clsFunUtiles();

        public int idSolicitud { get; set; }
        public int idTipoCliente { get; set; }
        public int idModalidadCredito { get; set; }
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        [XmlIgnore]
        public string cCliente { get; set; }
        [XmlIgnore]
        public string cDocumento { get; set; }
        [XmlIgnore]
        public int idTipoDocumento { get; set; }
        public int IdMoneda { get; set; }
        public int idEstado { get; set; }
        public string cEstado { get; set; }
        [XmlIgnore]
        public int idOperacion { get; set; }
        public int idProducto { get; set; }
        [XmlIgnore]
        public int idTipoPeriodo { get; set; }
        [XmlIgnore]
        public string cTipoPeriodo { get; set; }
        public int nCuotas { get; set; }
        [XmlIgnore]
        public int nPlazoCuota { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        [XmlIgnore]
        public int idTasa { get; set; }
        public int idModalidadDes { get; set; }
        [XmlIgnore]
        public int nDiasGracia { get; set; }
        public decimal nTasaCostoEfectivo { get; set; }
        public decimal nTasaEfectivaAnual { get; set; }
        [XmlIgnore]
        public decimal nCapitalAprobado { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public int idUsuario { get; set; }
        [XmlIgnore]
        public int idAgencia { get; set; }
        [XmlIgnore]
        public DateTime dFechaRegistro { get; set; }
        [XmlIgnore]
        public DateTime dFechaDesembolsoSugerido { get; set; }

        [XmlIgnore]
        public int idGrupoSolidario { get; set; }
        [XmlIgnore]
        public int idSolicitudCredGrupoSol { get; set; }

        public int idCuentaDeposito { get; set; }
        [XmlIgnore]
        public bool lCuentaDepositoAutomatico { get; set; }
        [XmlIgnore]
        public string cNroCuentaDeposito { get; set; }

        [XmlIgnore]
        public decimal nFactorITF { get; private set; }
        [XmlIgnore]
        public bool lRestarITF { get; set; }
        [XmlIgnore]
        public decimal nMontoRoundITF
        {
            get
            {
                return utiles.truncar(clsVarGlobal.nITF / 100.00m * this.nCapitalAprobado, 2, this.idMoneda);
            }
        }
        [XmlIgnore]
        public decimal nMontoNormalITF
        {
            get
            {
                return utiles.truncarNumero(clsVarGlobal.nITF / 100.00m * this.nCapitalAprobado, 2);
            }
        }
        [XmlIgnore]
        public decimal nImpuestos { get; set; }
        [XmlIgnore]
        public decimal nSeguros { get; set; }
        [XmlIgnore]
        public decimal nMontoRedondeo { get; set; }
        public decimal nMontoEntrega { get; set; }

        [XmlIgnore]
        public int idKardexDesembolso { get; set; }
        [XmlIgnore]
        public int idKardexAhorro { get; set; }

        [XmlIgnore]
        public DateTime dFechaProg { get; set; }
        [XmlIgnore]
        public decimal nMontoCuota { get; set; }
        public decimal nInteres { get; set; }
        public decimal nOtros { get; set; }

        [XmlIgnore]
        public bool lAhorroBloqueado { get; set; }
        [XmlIgnore]
        public bool lBonoGestionado { get; set; }

        #region Atributos de Ampliacion
        public int idCuentaAmpliada { get; set; }
        public int idSolicitudOrigen { get; set; }
        public int idSolicitudAnterior { get; set; }
        public decimal nSaldoCapital { get; set; }
        public decimal nIntMoraOtros { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public decimal nMontoCancelacion
        {
            get
            {
                return this.nSaldoCapital + this.nIntMoraOtros;
            }
        }
        #endregion

        #region Atributo de Compatibilidad
        public int idMoneda
        {
            get
            {
                return this.IdMoneda;
            }
            set
            {
                this.IdMoneda = value;
            }
        }
        #endregion

        public clsDesembolsoSolicitud()
        {
            this.idSolicitud = 0;
            this.idTipoCliente = 0;
            this.idModalidadCredito = 0;
            this.idCli = 0;
            this.cCliente = string.Empty;
            this.cDocumento = string.Empty;
            this.idTipoDocumento = 0;
            this.idCuenta = 0;
            this.IdMoneda = 0;
            this.idEstado = 0;
            this.cEstado = string.Empty;
            this.idOperacion = 0;
            this.idProducto = 0;
            this.idTipoPeriodo = 0;
            this.cTipoPeriodo = string.Empty;
            this.nCuotas = 0;
            this.nPlazoCuota = 0;
            this.nTasaCompensatoria = decimal.Zero;
            this.nTasaMoratoria = decimal.Zero;
            this.idTasa = 0;
            this.idModalidadDes = 0;
            this.nDiasGracia = 0;
            this.nTasaCostoEfectivo = decimal.Zero;
            this.nTasaEfectivaAnual = decimal.Zero;
            this.nCapitalAprobado = decimal.Zero;
            this.nCapitalSolicitado = decimal.Zero;
            this.idUsuario = 0;
            this.idAgencia = 0;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.dFechaDesembolsoSugerido = clsVarGlobal.dFecSystem;

            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            
            this.idCuentaDeposito = 0;
            this.lCuentaDepositoAutomatico = false;
            this.cNroCuentaDeposito = string.Empty;

            this.nFactorITF = clsVarGlobal.nITF / 100.00m;
            this.lRestarITF = false;
            this.nImpuestos = decimal.Zero;
            this.nSeguros = decimal.Zero;
            this.nMontoEntrega = decimal.Zero;

            this.idKardexDesembolso = 0;
            this.idKardexAhorro = 0;

            this.dFechaProg = clsVarGlobal.dFecSystem;
            this.nMontoCuota = decimal.Zero;
            this.nInteres = decimal.Zero;
            this.nOtros = decimal.Zero;

            this.lAhorroBloqueado = false;
            this.lBonoGestionado = false;

            this.idCuentaAmpliada = 0;
            this.idSolicitudOrigen = 0;
            this.idSolicitudAnterior = 0;
            this.nSaldoCapital = decimal.Zero;
            this.nIntMoraOtros = decimal.Zero;
            this.nMontoAmpliado = decimal.Zero;
        }
    }
}
