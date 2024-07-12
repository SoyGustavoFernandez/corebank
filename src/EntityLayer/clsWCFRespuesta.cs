using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFRespuesta
    {
        public int idRespuesta { get; set; }
        public string cMensaje { get; set; }
        public clsWCFGestionAprobacion oAprobacion { get; set; }
    }

    public class clsWCFReporteEncuesta
    {
        public long rowId { get; set; }
        public long rowTotal { get; set; }
        public int idRegistroEncuesta { get; set; }
        public string cDni { get; set; }
        public string cNombreApellido { get; set; }
        public int nEdad { get; set; }
        public string cSexo { get; set; }
        public string cEstadoCivil { get; set; }
        public string cNumeroCelular { get; set; }
        public string cRespuesta { get; set; }
        public int idUsuario { get; set; }
        public int idEncuesta { get; set; }
        public int idFeria { get; set; }
        public string dFechaRegistro { get; set; }
        public string dFechaSincronizacion { get; set; }
    }

    public class clsWCFEncuestaFeria
    {
        public int idRegistroFeria { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public string cNombre { get; set; }
        public string cLugar { get; set; }
        public string cDias { get; set; }
        public string cHorarioInicio { get; set; }
        public string cHorarioFinal { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsWCFReporteEncuestaFeria: clsWCFEncuestaFeria
    {
        public long rowId { get; set; }
        public long rowTotal { get; set; }
    }

    public class clsWCFReporteEncuestaEstablecimiento
    {
        public int idEstablecimiento { get; set; }
        public string cNombreEstab { get; set; }
    }

    public class clsWCFCampaniaCliente
    {
        public decimal nMonto { get; set; }
        public string cProducto { get; set; }
        public string cGrupoCamp { get; set; }
        public string cTipoGrupoCamp { get; set; }
    }
}
