using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNUsuComite
    {
        private clsADUsuComite objADUsuComite = new clsADUsuComite();

        public DataTable CNBusPersonalComite(string cCriterio, string cDato)
        {
            return objADUsuComite.ADBusPersonalComite(cCriterio, cDato);
        }

        public DataTable CNBuscarUsuarioExoneradoLoginComiteCred(string cWinUser)
        {
            return objADUsuComite.ADBuscarUsuarioExoneradoLoginComiteCred(cWinUser);
        }

        public DataTable CNVerificarRegionComite(int idAgenComite, int idUsuInvComite)
        {
            return objADUsuComite.ADVerificarRegionComite(idAgenComite, idUsuInvComite);
        }

    }
}
