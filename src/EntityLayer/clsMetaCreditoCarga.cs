using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsMetaCreditoCarga
    {
        [XmlIgnore]
        public string cGuidMetaCreditoCarga { get; set; }
        [XmlIgnore]
        public string cDesZona { get; set; }
        public int idAgencia { get; set; }
        [XmlIgnore]
        public string cAgenciaCarga { get; set; }
        [XmlIgnore]
        public string cEstablecimientoEOBCarga { get; set; }
        public int idUsuario { get; set; }
        [XmlIgnore]
        public string cAsesorCarga { get; set; }
        [XmlIgnore]
        public string cCargo { get; set; }
        public int idEstadoAsesor { get; set; }
        public int idTipoMetaSaldo { get; set; }
        public decimal nMetaSaldo { get; set; }
        public int idTipoMetaCrecimiento { get; set; }
        public decimal nCrecimientoClientes { get; set; }
        public int idTipoMetaClientesNuevos { get; set; }
        public decimal nClientesNuevos { get; set; }
        public int idEstadoMetaModificacion { get; set; }
        

        public clsMetaCreditoCarga()
        {
            cGuidMetaCreditoCarga       = Convert.ToString(System.Guid.NewGuid());
            cDesZona                    = String.Empty;
            idAgencia                   = 0;
            cAgenciaCarga               = String.Empty;
            cEstablecimientoEOBCarga    = String.Empty;
            idUsuario                   = 0;
            cAsesorCarga                = String.Empty;
            cCargo                      = String.Empty;
            idEstadoAsesor              = 1;
            idTipoMetaSaldo             = 0;
            nMetaSaldo                  = 0;
            idTipoMetaCrecimiento       = 0;
            nCrecimientoClientes        = 0;
            idTipoMetaClientesNuevos    = 0;
            nClientesNuevos             = 0;
            idEstadoMetaModificacion    = 1;
        }
    }

    public class clsMetaCreditoCompare : IEqualityComparer<clsMetaCreditoCarga>
    {
        public bool Equals(clsMetaCreditoCarga x, clsMetaCreditoCarga y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idUsuario.Equals(y.idUsuario) &&
                            x.idTipoMetaSaldo.Equals(y.idTipoMetaSaldo) &&
                            x.nMetaSaldo.Equals(y.nMetaSaldo) &&
                            x.idTipoMetaCrecimiento.Equals(y.idTipoMetaCrecimiento) &&
                            x.nCrecimientoClientes.Equals(y.nCrecimientoClientes) &&
                            x.idTipoMetaClientesNuevos.Equals(y.idTipoMetaClientesNuevos) &&
                            x.nClientesNuevos.Equals(x.nClientesNuevos);
            return lValor;
        }

        public int GetHashCode(clsMetaCreditoCarga obj)
        {
            int hUsuario             = obj.idUsuario.GetHashCode();
            int hTipoSaldo           = obj.idTipoMetaSaldo.GetHashCode();
            int hSaldo               = obj.nMetaSaldo.GetHashCode();
            int hTipoCrecimiento     = obj.idTipoMetaCrecimiento.GetHashCode();
            int hCrecimiento         = obj.nCrecimientoClientes.GetHashCode();
            int hTipoClientesNuevos  = obj.idTipoMetaClientesNuevos.GetHashCode();
            int hClientesNuevos      = obj.nClientesNuevos.GetHashCode();

            return hUsuario ^ hTipoSaldo ^ hSaldo ^ hTipoCrecimiento ^ hCrecimiento ^ hTipoClientesNuevos ^ hClientesNuevos;
        }
    }

    public class clsMetaCreditoCompareSimple : IEqualityComparer<clsMetaCreditoCarga>
    {
        public bool Equals(clsMetaCreditoCarga x, clsMetaCreditoCarga y)
        {
            bool lValor = true;
            if (Object.ReferenceEquals(x, y))
                return true;
            
            lValor = (lValor && x != null) ? true : false;
            lValor = (lValor && y != null) ? true : false;
            lValor = (lValor && x.idUsuario.Equals(y.idUsuario)) ? true : false;
            lValor = (lValor && x.idTipoMetaSaldo.Equals(y.idTipoMetaSaldo)) ? true : false;
            lValor = (lValor && x.idTipoMetaCrecimiento.Equals(y.idTipoMetaCrecimiento)) ? true : false;
            lValor = (lValor && x.idTipoMetaClientesNuevos.Equals(y.idTipoMetaClientesNuevos)) ? true : false;

            return lValor;
        }

        public int GetHashCode(clsMetaCreditoCarga obj)
        {
            int hUsuario                = obj.idUsuario.GetHashCode();
            int hTipoMetaSaldo          = obj.idTipoMetaSaldo.GetHashCode();
            int hTipoMetaCrecimiento    = obj.idTipoMetaCrecimiento.GetHashCode();
            int hTipoMetaClientesNuevos = obj.idTipoMetaClientesNuevos.GetHashCode();

            return hUsuario ^ hTipoMetaSaldo ^ hTipoMetaCrecimiento ^ hTipoMetaClientesNuevos;
        }
    }

    public class clsMetaCreditoCompareExcluidos : IEqualityComparer<clsMetaCreditoCarga>
    {
        public bool Equals(clsMetaCreditoCarga x, clsMetaCreditoCarga y)
        {
            bool lValor = true;
            if (Object.ReferenceEquals(x, y))
                return true;

            lValor = (lValor && x != null) ? true : false;
            lValor = (lValor && y != null) ? true : false;
            lValor = (lValor && x.idUsuario.Equals(y.idUsuario)) ? true : false;
            return lValor;
        }

        public int GetHashCode(clsMetaCreditoCarga obj)
        {
            int hUsuarioExcluido = obj.idUsuario.GetHashCode();
            return hUsuarioExcluido;
        }
    }
}
