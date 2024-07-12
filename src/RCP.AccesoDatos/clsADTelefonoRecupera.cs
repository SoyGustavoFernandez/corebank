using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADTelefonoRecupera
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable InsertarTelefonoRecupera(int idCli, String cTelefono)
        {
            return objEjeSp.EjecSP("RCP_InsertarTelefonoRecupera_SP", idCli, cTelefono);
        }

        public DataTable ListarTelefonoRecupera(int idCli)
        {
            return objEjeSp.EjecSP("RCP_ListarTelefonoRecupera_SP", idCli);
        }

    }
}
