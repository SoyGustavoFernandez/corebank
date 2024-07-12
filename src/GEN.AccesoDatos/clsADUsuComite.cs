using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADUsuComite
    {
        private clsGENEjeSP objEjesp = new clsGENEjeSP();

        public DataTable ADBusPersonalComite(string cCriterio, string cDato)
        {
            return objEjesp.EjecSP("CRE_BusUsuComite_Sp", cCriterio, cDato);
        }

        public DataTable ADBuscarUsuarioExoneradoLoginComiteCred(string cWinUser)
        {
            return objEjesp.EjecSP("CRE_BuscarUsuarioExoneradoLoginComiteCred_SP", cWinUser);
        }

        public DataTable ADVerificarRegionComite(int idAgenComite, int idUsuInvComite)
        {
            return objEjesp.EjecSP("CRE_VerificarRegionComite_SP", idAgenComite, idUsuInvComite);
        }
    }
}
