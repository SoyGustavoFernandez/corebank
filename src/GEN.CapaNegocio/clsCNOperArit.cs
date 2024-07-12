using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEN.CapaNegocio
{
    public class clsCNOperArit
    {
        /// <summary>
        /// Método que btiene el valor numerico redondeado por Exceso.
        /// </summary>
        /// <param name="nNum">Valor Numerico.</param>
        /// <param name="nNroDec">Número de Decimales.</param>
        /// <returns></returns>
        public Decimal RedxExceso(Decimal nNum, int nNroDec)
        {
            try
            {
                Decimal nAux;
                nAux = nNum * (Decimal)Math.Pow(10, nNroDec);
                nAux = Math.Ceiling(nAux) / (Decimal)Math.Pow(10, nNroDec);
                return nAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Método que btiene el valor numerico redondeado por Defecto.
        /// </summary>
        /// <param name="nNum">Valor Numerico.</param>
        /// <param name="nNroDec">Número de Decimales.</param>
        /// <returns></returns>
        public Decimal RedxDefecto(Decimal nNum, int nNroDec)
        {
            try
            {
                Decimal nAux;
                nAux = nNum * (Decimal)Math.Pow(10, nNroDec);
                if (nAux < 0)
                    nAux -= 0.5m;
                else
                    nAux += 0.5m;
                nAux = Math.Truncate(nAux);
                nAux = nAux / (Decimal)Math.Pow(10, nNroDec);
                return nAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
