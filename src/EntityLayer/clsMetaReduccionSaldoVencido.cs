using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsMetaReduccionSaldoVencido
    {
        public int idMetaReduccionSaldoVencido { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFecha { get; set; }
        public int idUsuRegistro { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public bool lVigente { get; set; }
        public EstadoRegistro idEstadoRegistro { get; set; }

        public clsMetaReduccionSaldoVencido()
        {
            this.idMetaReduccionSaldoVencido = 0;
            this.idEstablecimiento = 0;
            this.cEstablecimiento = string.Empty;
            this.nMonto = decimal.Zero;
            this.dFecha = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month,
                                    DateTime.DaysInMonth(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month));
            this.idUsuRegistro = 0;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.lVigente = true;
            this.idEstadoRegistro = EstadoRegistro.Creado;
        }
    }

    public class clsMetaReduccionSaldoVencidoCompareEditado : IEqualityComparer<clsMetaReduccionSaldoVencido>
    {
        public bool Equals(clsMetaReduccionSaldoVencido x, clsMetaReduccionSaldoVencido y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idEstablecimiento.Equals(y.idEstablecimiento) &&
                            !x.nMonto.Equals(y.nMonto) &&
                            x.dFecha.Equals(y.dFecha);
            return lValor;
        }

        public int GetHashCode(clsMetaReduccionSaldoVencido obj)
        {
            int hashMetaReduccionSVEstablecimiento = obj.idEstablecimiento.GetHashCode();
            int hashMetaReduccionSVFecha = obj.dFecha.GetHashCode();

            return hashMetaReduccionSVFecha ^ hashMetaReduccionSVEstablecimiento;
        }
    }

    public class clsMetaReduccionSaldoVencidoCompareNuevo : IEqualityComparer<clsMetaReduccionSaldoVencido>
    {
        public bool Equals(clsMetaReduccionSaldoVencido x, clsMetaReduccionSaldoVencido y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idEstablecimiento.Equals(y.idEstablecimiento) &&
                            x.dFecha.Equals(y.dFecha);
            return lValor;
        }

        public int GetHashCode(clsMetaReduccionSaldoVencido obj)
        {
            int hashMetaReduccionSVEstablecimiento = obj.idEstablecimiento.GetHashCode();
            int hashMetaReduccionSVFecha = obj.dFecha.GetHashCode();

            return hashMetaReduccionSVFecha ^ hashMetaReduccionSVEstablecimiento;
        }
    }
}
