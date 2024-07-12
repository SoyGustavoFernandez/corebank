using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsMatrizAgricola
    {
        public int idMatrizAgricola { get; set; }
        public int? idAgencia { get; set; }
        public int idCultivoEval { get; set; }
        public int idVariedadCultivoEval { get; set; }
        public int idTipoCultivo { get; set; }
        public int idRiesgoEvalCultivo { get; set; }
        public int idTipoFinanciamientoCultivo { get; set; }

        public int? nPeriodoFenologico { get; set; }
        public int? nPeriodoComercializacion { get; set; }
        public int? nPlazoCredito { get; set; }
        public int? nFrecuenciaPago { get; set; }

        public decimal? nCostoProduccionMN { get; set; }
        public decimal? nPorcentajeFinanciamiento { get; set; }
        public decimal? nMontoFinanciamientoMN { get; set; }

        public int idUnidadMedida { get; set; }
        public decimal? nRendimiento { get; set; }
        public decimal? nPrecioUnidadMN { get; set; }
        public decimal? nIngresoVentasMN { get; set; }
        public decimal? nUtilidadMN { get; set; }
        public decimal? nRentabilidad { get; set; }

        public DateTime dFechaCreacion { get; set; }
        public DateTime dFechaActualizacion { get; set; }
        public int idRegistroMatriz { get; set; }
        public bool lVigente { get; set; }

        public string cAgencia { get; set; }
        public string cCultivoEval { get; set; }
        public string cVariedadCultivoEval { get; set; }
        public string cTipoCultivo { get; set; }
        public string cRiesgoEvalCultivo { get; set; }
        public string cTipoFinanciamientoCultivo { get; set; }
        public string cUnidadMedida { get; set; }

        public int idUnidadProductiva { get; set; }
        public decimal nEquivHas { get; set; }

        public decimal nRendimientoEquivalente
        {
            get
            {
                return (this.nRendimiento ?? 0) * this.nEquivHas;
            }
        }

        public clsMatrizAgricola Copia()
        {
            return (clsMatrizAgricola)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.cAgencia, this.cCultivoEval, this.cVariedadCultivoEval);
        }
    }
}
