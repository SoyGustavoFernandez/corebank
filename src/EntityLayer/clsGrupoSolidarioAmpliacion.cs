using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsGrupoSolidarioAmpliacion
    {
        public int idGrupoSolidarioAmpliacion {get; set;}
        public int idGrupoSolidario {get; set;}
        public int idSolicitudCredGrupoSol {get; set;}
        public int idSolCredGrupoSolOrigen {get; set;}
        public int idSolCredGrupoSolAnterior {get; set;}
        public int idEstado {get; set;}
        public int nNroAmpliacion {get; set;}
        public decimal nSaldoCapital {get; set;}
        public decimal nMontoAmpliado {get; set;}
        public int idGrupoSolidarioCiclo {get; set;}

        public List<clsGrupoSolAmpliacionDetalle> lstGrupoSolAmpliacionDetalle;

        #region Atributos Descriptivos
        [XmlIgnore]
        public string cEstado {get; set;}
        #endregion

        public decimal nMontoSolicitud
        {
            get
            {
                return (this.nSaldoCapital + this.nMontoAmpliado);
            }
        }

        public clsGrupoSolidarioAmpliacion()
        {
            this.idGrupoSolidarioAmpliacion = 0;
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idSolCredGrupoSolOrigen = 0;
            this.idSolCredGrupoSolAnterior = 0;
            this.idEstado = 0;
            this.nNroAmpliacion = 0;
            this.nSaldoCapital = decimal.Zero;
            this.nMontoAmpliado = decimal.Zero;
            this.idGrupoSolidarioCiclo = 0;

            this.cEstado = string.Empty;
        }
    }
}
