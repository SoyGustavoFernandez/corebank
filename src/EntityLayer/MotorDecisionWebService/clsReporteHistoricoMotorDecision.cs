using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsReporteHistoricoMotorDecision
    {
        #region Variables

        public string dFechaP { get; set; }
        public int nNumeroSolicitud { get; set; }

        public int idPrediccion { get; set; }
        public Decimal nResultadoScore { get; set; }
        public string cResultadoModelo { get; set; }
        public string CMotivoRechazo { get; set; }

        public string cOficina { get; set; }
        public string cAsesor { get; set; }
        public int nEdad { get; set; }
        public string cSexo { get; set; }
        public string cEstadoCivil { get; set; }
        public string cTipoVivienda { get; set; }
        public string cNivelInstruccion { get; set; }
        public Decimal nMontoSolicitado { get; set; }
        public int nPlazo { get; set; }
        public int nNroDependientes { get; set; }
        public int nAniosResidencia { get; set; }
        public string cTelefono { get; set; }
        public string cProfesion { get; set; }
        public string cDiaSemana { get; set; }
        public string cDepartamento { get; set; }
        public string cDestinoCredito { get; set; }
        public string cUsuarioReg { get; set; }
        public DateTime? dFechaReg { get; set; }
        public string cFormulario { get; set; }

        #endregion
    }
}
