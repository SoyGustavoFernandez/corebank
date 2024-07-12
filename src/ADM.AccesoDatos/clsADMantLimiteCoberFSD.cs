using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADMantLimiteCoberFSD
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable dt = new DataTable();

        public DataTable ListarLimiteCoberFSD(int idLimiteFSD)
        {
            dt = objEjeSp.EjecSP("ADM_ListarLimiteCoberFSD_sp", idLimiteFSD);
            return dt;
        }
        public void insertarLimiteCoberFSD(DateTime dFechInicial, DateTime dFechFinal, Decimal nMaxCoberFSD, int LVigencia)
        {
            objEjeSp.EjecSP("ADM_InsertarLimiteCoberFSD_sp", dFechInicial, dFechFinal, nMaxCoberFSD, LVigencia);
        }

        public void actualizarLimiteCoberFSD(int idLimiteFSD, DateTime dFechInicial, DateTime dFechFinal, Decimal nMaxCoberFSD, int LVigencia)
        {
            objEjeSp.EjecSP("ADM_ActualizarLimiteCoberFSD_sp", idLimiteFSD, dFechInicial, dFechFinal, nMaxCoberFSD, LVigencia);
        }

        public DataTable BuscarLimiteCoberFSD(DateTime dFechInicial, DateTime dFechFinal)
        {
            dt=objEjeSp.EjecSP("ADM_BuscarLimiteCoberFSD_sp", dFechInicial, dFechFinal);
            return dt;
        }
        public DataTable ObtenerUltimaFecha()
        {
            dt=objEjeSp.EjecSP("ADM_ObtenerUltimaFecha_sp");
            return dt;
        }
    }
}