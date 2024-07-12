using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsRecuperacionCondonacionLimite
    {
        public int idRecuperacionCondonacionLimite { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public int idTramo { get; set; }
        public string cTramo { get; set; }
        public int nLimiteCondonacion { get; set; }
        public DateTime dFecha { get; set; }
        public bool lVigente { get; set; }
        public EstadoRegistro idEstadoRegistro { get; set; }

        public clsRecuperacionCondonacionLimite()
        {
            this.idRecuperacionCondonacionLimite = 0;
            this.idEstablecimiento = 0;
            this.cEstablecimiento = string.Empty;
            this.idTramo = 0;
            this.cTramo = string.Empty;
            this.nLimiteCondonacion = 0;
            this.dFecha = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month,
                                    DateTime.DaysInMonth(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month));
            this.lVigente = true;
            this.idEstadoRegistro = EstadoRegistro.Creado;
        }
    }

    public class clsRecuperacionCondonacionLimiteCompareEditado : IEqualityComparer<clsRecuperacionCondonacionLimite>
    {
        public bool Equals(clsRecuperacionCondonacionLimite x, clsRecuperacionCondonacionLimite y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idEstablecimiento.Equals(y.idEstablecimiento) &&
                            !x.nLimiteCondonacion.Equals(y.nLimiteCondonacion) &&
                            x.idTramo.Equals(y.idTramo);
            return lValor;
        }

        public int GetHashCode(clsRecuperacionCondonacionLimite obj)
        {
            int hashEstablecimiento = obj.idEstablecimiento.GetHashCode();
            int hashCondonacionTramo = obj.idTramo.GetHashCode();

            return hashEstablecimiento ^ hashCondonacionTramo;
        }
    }
    public class clsRecuperacionCondonacionLimiteCompareNuevo : IEqualityComparer<clsRecuperacionCondonacionLimite>
    {
        public bool Equals(clsRecuperacionCondonacionLimite x, clsRecuperacionCondonacionLimite y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idEstablecimiento.Equals(y.idEstablecimiento) &&
                            x.idTramo.Equals(y.idTramo);
            return lValor;
        }

        public int GetHashCode(clsRecuperacionCondonacionLimite obj)
        {
            int hashEstablecimiento = obj.idEstablecimiento.GetHashCode();
            int hashCondonacionTramo = obj.idTramo.GetHashCode();

            return hashEstablecimiento ^ hashCondonacionTramo;
        }
    }

    public class clsRecuperacionCondonacionLimiteJoin : IEqualityComparer<clsRecuperacionCondonacionLimite>
    {
        public bool Equals(clsRecuperacionCondonacionLimite x, clsRecuperacionCondonacionLimite y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idEstablecimiento.Equals(y.idEstablecimiento) &&                           
                            x.idTramo.Equals(y.idTramo);
            return lValor;
        }

        public int GetHashCode(clsRecuperacionCondonacionLimite obj)
        {
            int hashEstablecimiento = obj.idEstablecimiento.GetHashCode();
            int hashCondonacionTramo = obj.idTramo.GetHashCode();

            return hashEstablecimiento ^ hashCondonacionTramo;
        }
    }
}
