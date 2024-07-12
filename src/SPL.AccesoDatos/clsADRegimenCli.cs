using SolIntEls.GEN.Helper;
using System.Data;

namespace SPL.AccesoDatos
{
    public class clsADRegimenCli
    {
        private clsGENEjeSP _objEjeSp;

        public clsADRegimenCli()
        {
            _objEjeSp = new clsGENEjeSP();
        }

        public DataTable GetRegimenCliente(int idCli)
        {
            return _objEjeSp.EjecSP("SPL_GetRegimenCliente_Sp", idCli);
        }
    }
}
