using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsGrupoSolidarioAhorro : ICloneable
    {
        public int idGrupoSolidarioAhorro { get; set; }
        public int idSolicitud { get; set; }
        public int idOperacion { get; set; }
        public int idCuentaAhorro { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idCliente { get; set; }
        [XmlIgnore]
        public string cDocumento { get; set; }
        [XmlIgnore]
        public string cCliente { get; set; }
        public int idTipoGrupoSolidario { get; set; }
        public DateTime dFecha { get; set; }
        public int idUsuarioRegistra { get; set; }

        [XmlIgnore]
        public decimal nSaldoContable { get; set; }
        [XmlIgnore]
        public decimal nMontoTotalBloqueado { get; set; }
        [XmlIgnore]
        public decimal nMontoBloqGrupoSol { get; set; }
        [XmlIgnore]
        public decimal nMontoAhorro { get; set; }
        [XmlIgnore]
        public decimal nMontoBloqueo
        {
            get
            {
                if (this.idTipoGrupoSolidario == (int)TipoGrupoSolidario.GrupoSolidario)
                {
                    return Math.Round(this.nCapitalAprobado * clsVarApl.dicVarGen["nGrupSolBloq"] / 100, 1);
                }
                else if (this.idTipoGrupoSolidario == (int)TipoGrupoSolidario.BancaComunal)
                {
                    return 20.00M;
                }
                else
                {
                    return decimal.Zero;
                }
            }
        }
        [XmlIgnore]
        public decimal nMontoPendiente
        {
            get
            {
                decimal nMonto = decimal.Zero;
                if(this.idOperacion == (int)OperacionCredito.Ampliacion)
                    nMonto = Math.Ceiling(this.nMontoBloqueo - (this.nSaldoDisponible + this.nMontoBloqGrupoSol));
                else
                    nMonto = Math.Ceiling(this.nMontoBloqueo - this.nSaldoDisponible);

                return (nMonto > decimal.Zero)? nMonto: decimal.Zero;
            }
        }
        [XmlIgnore]
        public decimal nCapitalAprobado { get; set; }
        [XmlIgnore]
        public Estado idEstado { get; set; }
        [XmlIgnore]
        public bool lAhorroBloqueado { get; set; }
        [XmlIgnore]
        public bool lBonoGestionado { get; set; }

        public decimal nSaldoDisponible
        {
            get
            {
                return (this.nSaldoContable - this.nMontoTotalBloqueado);
            }
        }

        public clsGrupoSolidarioAhorro()
        {
            this.idGrupoSolidarioAhorro = 0;
            this.idSolicitud = 0;
            this.idOperacion = 0;
            this.idCuentaAhorro = 0;
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idCliente = 0;
            this.cDocumento = string.Empty;
            this.cCliente = string.Empty;
            this.idTipoGrupoSolidario = 0;
            this.dFecha = clsVarGlobal.dFecSystem;
            this.idUsuarioRegistra = clsVarGlobal.User.idUsuario;

            this.nSaldoContable = decimal.Zero;
            this.nMontoTotalBloqueado = decimal.Zero;
            this.nMontoBloqGrupoSol = decimal.Zero;
            this.nMontoAhorro = decimal.Zero;
            this.idEstado = Estado.NINGUNO;
            this.lAhorroBloqueado = false;
            this.lBonoGestionado = false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
