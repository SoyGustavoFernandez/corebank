using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Funciones
{
    public class clsMathFinanciera
    {
        public static decimal TEM(double tea)
        {
            return (decimal)(Math.Round((Math.Pow((1.0 + tea / 100.0), (30.0 / 360.0)) - 1.0) * 100.0, 4));
        }

        public static decimal CuotaPGracia(double tea, int periodoPago, decimal monto)
        {
            double fi = clsMathFinanciera.fi(tea, periodoPago);
            return (decimal)fi * monto;
        }

        public static decimal CuotaResultante(double tea, int nCuotas, int periodoGracia, int periodoPago, decimal monto)
        {
            double fi = clsMathFinanciera.fi(tea, periodoPago);
            double fr = clsMathFinanciera.fr(fi, nCuotas, periodoGracia, periodoPago);
            return (decimal)fr * monto;
        }

        private static double fi(double tea, int periodoPago)
        {
            return Math.Round((Math.Pow((1.0 + tea / 100), ((periodoPago * 30.0) / 360.0)) - 1.0), 6);
        }

        private static double fr(double fi, int nCuotas, int periodoGracia, int periodoPago)
        {
            double n = Math.Pow(1.0 + fi, nCuotas - periodoGracia);
            double a = (n * fi);
            double b = (n - 1.0);
            return Math.Round(a / b, 6);
        }

        public static decimal Convertir(int idMonedaOrig, int idMonedaDest, decimal valor, decimal nTipoCambio)
        {
            decimal result = 0;

            if (idMonedaOrig == idMonedaDest) return valor;

            if (nTipoCambio <= 0) return 0;

            if (idMonedaOrig == 1)              // Soles
            {
                if (idMonedaDest == 1)          // Soles
                    result = valor;
                else if (idMonedaDest == 2)     // Dolares
                    result = valor / nTipoCambio;
            }

            if (idMonedaOrig == 2)              // Dolares 
            {
                if (idMonedaDest == 1)          // Soles
                    result = valor * nTipoCambio;
                else if (idMonedaDest == 2)     // Dolares
                    result = valor;
            }

            return result;
        }
    }
}
