using ADM.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNMantLimiteCoberFSD
    {
        clsADMantLimiteCoberFSD objFSD = new clsADMantLimiteCoberFSD();
        public DataTable ListarLimiteCoberFSD(int idLimiteFSD)
        {
            return objFSD.ListarLimiteCoberFSD(idLimiteFSD);
        }

        public void insertarLimiteCoberFSD(DateTime dFechInicial, DateTime dFechFinal, Decimal nMaxCoberFSD, int LVigencia)
        {
            objFSD.insertarLimiteCoberFSD(dFechInicial, dFechFinal, nMaxCoberFSD, LVigencia);
        }

        public void actualizarLimiteCoberFSD(int idLimiteFSD, DateTime dFechInicial, DateTime dFechFinal, Decimal nMaxCoberFSD, int LVigencia)
        {
            objFSD.actualizarLimiteCoberFSD(idLimiteFSD, dFechInicial, dFechFinal, nMaxCoberFSD, LVigencia);
        }

        public DataTable BuscarLimiteCoberFSD(DateTime dFechInicial, DateTime dFechFinal)
        {
           return objFSD.BuscarLimiteCoberFSD(dFechInicial, dFechFinal);
        }

        public DataTable ObtenerUltimaFecha()
        {
            return objFSD.ObtenerUltimaFecha();
        }
    }
}