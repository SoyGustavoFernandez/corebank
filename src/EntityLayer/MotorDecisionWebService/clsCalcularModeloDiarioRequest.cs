using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: SolTechnologies - 4.Modelo de Entidades para el Motor de Decisiones
namespace EntityLayer.MotorDecisionWebService
{
    public class clsCalcularModeloDiarioRequest
    {
        #region Variables

        public int nNumeroSolicitud { get; set; }
        public string dFechaP{ get; set; }
        public int idEstado { get; set; }
        public Decimal nMontoSolicitado { get; set; }
        public int nPlazo { get; set; }
        public string dFechaNacimiento { get; set; }
        public string cSexo { get; set; }
        public string cEstadoCivil { get; set; }
        public string cTipoVivienda { get; set; }
        public string cNivelInstruccion { get; set; }
        public string cActividad { get; set; }
        public string cProfesion { get; set; }
        public string cDepartamento { get; set; }
        public string cTelefono { get; set; }
        public int nNroDependientes { get; set; }
        public int nAniosResidencia { get; set; }
        public string cOficina { get; set; }
        public string cAsesor { get; set; }
        public string cDestinoCredito { get; set; }
        public string cFormulario { get; set; }

        #endregion
    }
}
