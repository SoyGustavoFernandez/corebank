using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsGrupoSolidarioBono
    {
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idCuenta { get; set; }
        public int idSolicitud { get; set; }
        [XmlIgnore]
        public int idEstado { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        public int idGrupoSolidarioCargo { get; set; }
        public int idCli { get; set; }
        [XmlIgnore]
        public string cCliente { get; set; }
        [XmlIgnore]
        public string cDocumento { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public int nMesesCancelacion { get; set; }
        public int nAtrasoMaximo { get; set; }
        public decimal nFactorCapDesembolso { get; set; }
        public decimal nBono { get; set; }
        public bool lExcepcionado { get; set; }
        [XmlIgnore]
        public string cObservacion { get; set; }
        public bool lEntregado { get; set; }

        public clsGrupoSolidarioBono()
        {
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idCuenta = 0;
            this.idSolicitud = 0;
            this.idEstado = 0;
            this.cEstado = string.Empty;
            this.idGrupoSolidarioCargo = 0;
            this.idCli = 0;
            this.cCliente = string.Empty;
            this.cDocumento = string.Empty;
            this.nCapitalDesembolso = decimal.Zero;
            this.nMesesCancelacion = 0;
            this.nAtrasoMaximo = 0;
            this.nFactorCapDesembolso = decimal.Zero;
            this.nBono = decimal.Zero;
            this.lExcepcionado = false;
            this.cObservacion = string.Empty;
            this.lEntregado = false;
        }
    }
}
