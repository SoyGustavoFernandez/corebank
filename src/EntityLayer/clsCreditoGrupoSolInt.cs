using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsCreditoGrupoSolInt
    {
        public int idCuenta { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idMoneda { get; set; }
        public int idAgencia { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public decimal nSaldoCapital { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public int idSolicitud { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idDestino { get; set; }
        public int idActividad { get; set; }
        public int idActividadInterna { get; set; }        
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaEfectivaAnual { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nCuotaAprox { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }
        public int idDetalleGasto { get; set; }
        public bool lConTasaNegociable { get; set; }
        public int idClasifInterna { get; set; }
        [XmlIgnore]
        public bool lIndDatosBasic { get; set; }
        [XmlIgnore]
        public bool lSolicitudActiva { get; set; }
        [XmlIgnore]
        public bool lTieneTasa { get; set; }
        public int idGrupoSolidarioCargo { get; set; }
        public int idOperacion { get; set; }
        public int idPaqueteSeguro { get; set; }
        public int idFrmPaqueteSeguro { get; set; }

        private decimal _nMonto;
        public decimal nMonto
        {
            get
            {
                if (this.idOperacion == (int)OperacionCredito.Ampliacion)
                {
                    return this.nMontoCancelacion + this.nMontoAmpliado;
                }
                else
                {
                    return this._nMonto;
                }

            }
            set
            {
                this._nMonto = value;
            }
        }
        public int idClasificacionInterna { get; set; }
        public decimal nTea
        {
            get
            {
                return this.nTasaCompensatoria;
            }
            set
            {
                this.nTasaCompensatoria = value;
            }
        }
        [XmlIgnore]
        public int nNro { get; set; }
        [XmlIgnore]
        public string cNombre
        {
            get
            {
                return this.cCliente;
            }
            set
            {
                this.cCliente = value;
            }
        }


        #region Atributos Descriptivos
        [XmlIgnore]
        public string cCliente { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        [XmlIgnore]
        public string cProducto { get; set; }
        [XmlIgnore]
        public string cAgencia { get; set; }
        [XmlIgnore]
        public string cDestino { get; set; }
        [XmlIgnore]
        public string cActividadInterna { get; set; }
        #endregion

        #region Atributos Ampliacion
        public int idGrupoSolAmpliacionDetalle { get; set; }
        public int idGrupoSolidarioAmpliacion { get; set; }

        public int idSolicitudOrigen { get; set; }
        public int idSolicitudAnterior { get; set; }
        public int idCuentaAmpliada { get; set; }
        public int nNroAmpliacion { get; set; }
        public decimal nIntMoraOtros { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public decimal nMontoSolAmpliacion
        {
            get
            {
                return this.nMontoCancelacion + this.nMontoAmpliado;
            }
        }
        public decimal nMontoCancelacion
        {
            get
            {
                return this.nSaldoCapital + this.nIntMoraOtros;
            }
        }
        #endregion

        public clsCreditoGrupoSolInt()
        {
            this.idCuenta = 0;
            this.idCli = 0;
            this.idProducto = 0;
            this.idEstado = (int)Estado.REGISTRADO;
            this.cEstado = string.Empty;
            this.idMoneda = 0;
            this.idAgencia = 0;
            this.nCapitalDesembolso = decimal.Zero;
            this.nSaldoCapital = decimal.Zero;
            this.dFechaDesembolso = DateTime.Now;
            this.idSolicitud = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idGrupoSolidario = 0;
            this.cCliente = string.Empty;
            this.idDestino = 0;
            this.cDestino = string.Empty;
            this.idActividad = 0;
            this.idActividadInterna = 0;
            this.cActividadInterna = string.Empty;
            this.idTasa = 0;
            this.nTasaCompensatoria = decimal.Zero;
            this.nTasaEfectivaAnual = decimal.Zero;
            this.nTasaMoratoria = decimal.Zero;
            this.nCuotaAprox = decimal.Zero;
            this.nCuotaGraciaAprox = decimal.Zero;
            this.idDetalleGasto = 0;
            this.lConTasaNegociable = false;
            this.idClasifInterna = 0;
            this.lIndDatosBasic = false;
            this.lSolicitudActiva = false;
            this.lTieneTasa = false;
            this.idGrupoSolidarioCargo = 0;
            this.idOperacion = 0;
            this.nMonto = decimal.Zero;

            this.idGrupoSolAmpliacionDetalle = 0;
            this.idGrupoSolidarioAmpliacion = 0;

            this.idSolicitudOrigen = 0;
            this.idSolicitudAnterior = 0;
            this.idCuentaAmpliada = 0;
            this.nNroAmpliacion = 0;
            idPaqueteSeguro = -1;
        }

    }
}
