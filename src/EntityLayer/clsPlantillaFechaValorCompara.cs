using System.Collections.Generic;

namespace EntityLayer
{
    // Compara dos filas de la plantilla de fecha valor para eliminar duplicados.
    public class clsPlantillaFechaValorCompara : IEqualityComparer<clsPlantillaFechaValor>
    {
        public bool Equals(clsPlantillaFechaValor x, clsPlantillaFechaValor y)
        {
            if (x == null || y == null)
                return false;

            return x.cCanal == y.cCanal &&
                   x.nNumeroCredito == y.nNumeroCredito &&
                   x.dFechaValor == y.dFechaValor &&
                   x.nNumeroOperacionCanalExterno == y.nNumeroOperacionCanalExterno &&
                   x.nMontoPagado == y.nMontoPagado;
        }

        public int GetHashCode(clsPlantillaFechaValor obj)
        {
            if (obj == null)
                return 0;

            int hashCanal = obj.cCanal == null ? 0 : obj.cCanal.GetHashCode();
            int hashNumeroCredito = obj.nNumeroCredito.GetHashCode();
            int hashFechaValor = obj.dFechaValor.GetHashCode();
            int hashNumeroOperacionCanalExterno = obj.nNumeroOperacionCanalExterno.GetHashCode();
            int hashMontoPagado = obj.nMontoPagado.GetHashCode();

            return hashCanal ^ hashNumeroCredito ^ hashFechaValor ^ hashNumeroOperacionCanalExterno ^ hashMontoPagado;
        }
    }
}