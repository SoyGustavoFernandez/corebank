using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCreditoReprogExcel
    {
        public int idCuenta { get; set; }
        public int idCli { get; set; }
        public int nDiasReprog { get; set; }
        public double nTasaNueva { get; set; }

        public clsCreditoReprogExcel()
        {
            this.idCuenta = 0;
            this.idCli = 0;
            this.nDiasReprog = 0;
            this.nTasaNueva = 0.0;
        }
    }

    public class clsCreditoReprogExcelCompareEditado : IEqualityComparer<clsCreditoReprogExcel>
    {
        public bool Equals(clsCreditoReprogExcel x, clsCreditoReprogExcel y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idCuenta.Equals(y.idCuenta) &&
                            !x.nDiasReprog.Equals(y.nDiasReprog);
            return lValor;
        }

        public int GetHashCode(clsCreditoReprogExcel obj)
        {
            int hashEstablecimiento = obj.idCuenta.GetHashCode();

            return hashEstablecimiento;
        }
    }
    public class clsCreditoReprogExcelCompareNuevo : IEqualityComparer<clsCreditoReprogExcel>
    {
        public bool Equals(clsCreditoReprogExcel x, clsCreditoReprogExcel y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idCuenta.Equals(y.idCuenta);
            return lValor;
        }

        public int GetHashCode(clsCreditoReprogExcel obj)
        {
            int hashEstablecimiento = obj.idCuenta.GetHashCode();

            return hashEstablecimiento;
        }
    }

    public class clsCreditoReprogExcelJoin : IEqualityComparer<clsCreditoReprogExcel>
    {
        public bool Equals(clsCreditoReprogExcel x, clsCreditoReprogExcel y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            bool lValor = x != null &&
                            y != null &&
                            x.idCuenta.Equals(y.idCuenta);
            return lValor;
        }

        public int GetHashCode(clsCreditoReprogExcel obj)
        {
            int hashEstablecimiento = obj.idCuenta.GetHashCode();

            return hashEstablecimiento;
        }
    }
}
