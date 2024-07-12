using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SPL.AccesoDatos
{
    public class clsADTipoCambioSPL
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public DataTable listarTipoCambio(int tipo)
        {
            ds=objEjeSp.EjecSP("GEN_ListarTipoCambioSPL", tipo);
            return ds;
        }        
        
        public void insertarTipoCambioSplaft(DateTime dFecIni, DateTime dFecFin,Decimal nTipoCambio)
        {
            objEjeSp.EjecSP("SPL_InsertarTipoCambioSplaft_SP", dFecIni, dFecFin, nTipoCambio);
        }

        public void actualizarTipoCambioSPL(int idTipoCambio, decimal nTipoCambio)
        {
            objEjeSp.EjecSP("SPL_ActTipoCambioSplaft_SP", idTipoCambio, nTipoCambio);
        }
    }
}
