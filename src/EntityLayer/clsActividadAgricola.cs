using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityLayer
{
    public class clsEvaluacionCultivo
    {
        public int idEvaluacionCultivo { get; set; }
        public int idCultivoEval { get; set; }
        public int idVariedadCultivoEval { get; set; }
        public int idZona { get; set; }
        public int idEvalCred { get; set; }
        public decimal nUniProdPropias { get; set; }
        public decimal nUniProdAlquiladas { get; set; }
        public decimal nUniProdPropiasFin { get; set; }
        public decimal nUniProdAlquiladasFin { get; set; }
        public decimal nMontoIngresos { get; set; }
        public decimal nMontoEgresos { get; set; }
        public bool lVigente { get; set; }
        public int idTipoSiembra { get; set; }
        public int idUnidadProductiva { get; set; }
        public int idUnidadMedida { get; set; }
        public string cCampanha { get; set; }

        public decimal nUniProdPropiasAct { get; set; }
        public decimal nUniProdAlquiladasAct { get; set; }
        public int? idMatrizAgricola { get; set; }
        public int idTipoCultivo { get; set; }
        public int idTipoFinanciamientoCultivo { get; set; }

    }

    public class clsEvaluacionCultivoAgrico : clsEvaluacionCultivo
    {
        public string cCultivoEval { get; set; }
        public string cVariedadCultivoEval { get; set; }
        public string cUnidadProductiva { get; set; }
        public string cUnidadMedida { get; set; }
        public List<clsMovimientoEval> lstMovimientosEval { get; set; }

        public clsMatrizAgricola objMatrizAgricola;

        public decimal nMontoEgresosMatriz { get; set; }
        public decimal nMontoIngresosMatriz { get; set; }

        public int idRegistroMatriz
        {
            get
            {
                if (this.idMatrizAgricola == null)
                    return -1;
                else if (this.idMatrizAgricola == 0)
                    return 0;
                else
                    return this.objMatrizAgricola.idRegistroMatriz;
            }
        }

        public clsEvaluacionCultivoAgrico()
        {
            this.idCultivoEval = 0;
            this.idVariedadCultivoEval = 0;
            this.idTipoSiembra = 0;
            this.idUnidadProductiva = 0;
        }
    }

    public class clsMovimientoEval
    {
        public int idMovimientoEval { get; set; }
        public int nMesMovimientoPadre { get; set; }
        public string cMesMovimiento
        {
            get
            {
                return this.dMesMovimiento.ToString("MMM yyyy");
            }
        }
        public DateTime dMesMovimiento { get; set; }
        public int idEtapaCultivo { get; set; }
        public string cEtapaCultivo { get; set; }
        public int idActividadCultivo { get; set; }
        public string cActividadCultivo { get; set; }
        public decimal nUnidadesAFinanciar { get; set; }
        public decimal nRendimiento { get; set; }
        public int idEvaluacionCultivo { get; set; }
        public int idUnidadMedida { get; set; }
        public string cUnidadMedida { get; set; }
        public decimal nMonto { get; set; }
        public decimal nMontoTotal { get; set; }
        public int idTipoMovEvalCultivo { get; set; }
        public int idPadre { get; set; }

    }
}
