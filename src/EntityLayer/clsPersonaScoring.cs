using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPersonaScoring
    {
        public int idCliente { get; set; }
        public string cNombreCliente { get; set; }
        public bool lBancarizado { get; set; }
        public int nEdad { get; set; }
        public int idEstadoCivil { get; set; }
        public string cUbigeoRENIEC { get; set; }
        public int idCalificacionInterna { get; set; }
        public string cAgencia { get; set; }
        public decimal nEndeudamientoRCC { get; set; }
        public int nNroEntidadesRCC { get; set; }
        public decimal nCalificacionRCC { get; set; }
        public string cClasifInterna { get; set; }
        public int nNroCreditos { get; set; }
        public decimal nMonto { get; set; }
        public string cProducto { get; set; }
        public int nPlazoCapitalTrabajo { get; set; }
        public int nPlazoActivoFijo { get; set; }
        public decimal nTasa { get; set; }

        public decimal nPuntuacionScoring { get; set; }
        public decimal nMontoMaximo { get; set; }
        public int nPlazoMaximo { get; set; }

        public bool lCampanha { get; set; }
        public string cNombreCampanha { get; set; }
        public bool lRatuki { get; set; }
        public decimal nMontoPreAprobado { get; set; }
        public int nPlazoCapitalTrabajoPreAprobado { get; set; }
        public int nPlazoActivoFijoPreAprobado { get; set; }
        public int idGrupoCamp { get; set; }

    }
}
