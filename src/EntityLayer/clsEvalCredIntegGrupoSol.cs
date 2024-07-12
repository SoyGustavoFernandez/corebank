using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCredIntegGrupoSol
    {
        public int idSolicitud { get; set; }
        public int idEvalCred { get; set; }
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int idActividad { get; set; }
        public int idActividadInterna { get; set; }
        public string cActividadInterna { get; set; }
        public decimal nMonto { get; set; }
        public int idGrupoSolidarioCiclo { get; set; }
        public int idGrupoSolidarioCargo { get; set; }
        public int idCiclo { get; set; }
        public int idDetalleGasto { get; set; }

        //public int idGrupoSolidarioCiclo { get; set; }
        //public int idGrupoSolidarioCargo { get; set; }
        //public int idCiclo { get; set; }
        public int idOperacion { get; set; }
        public int nCuotas { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public int nCuotasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }

        //public decimal nMonto { get; set; }
        public int idTasa { get; set; }
        public decimal nTEA { get; set; }
        public decimal nTEM { get; set; }
        public decimal nTIM { get; set; }
        public int nNro { get; set; }
        public decimal nCuotaAprox { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }
        public int nPlazo { get; set; }
        //public int idActividad { get; set; }
        //public int idActividadInterna { get; set; }
        public decimal nMontoMax { get; set; }
        public bool lConTasaNegociable { get; set; }
        public int idModalidadCredito { get; set; }
        public int idClasificacionInterna { get; set; }

        public decimal nSaldoCapital { get; set; }
        public decimal nIntMoraOtros { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public int idPaqueteSeguro { get; set; }
        public clsEvalCredIntegGrupoSol()
        {
            nCuotaAprox = 0;
            idPaqueteSeguro = -1;
        }

    }
}
