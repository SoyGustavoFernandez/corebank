using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNTelefonoRecupera
    {
        clsADTelefonoRecupera adTelefonoRecupera = new clsADTelefonoRecupera();

        public DataTable InsertarTelefonoRecupera(int idCli, String cTelefono)
        {
            return adTelefonoRecupera.InsertarTelefonoRecupera(idCli, cTelefono);
        }

        public DataTable ListarTelefonoRecupera(int idCli)
        {
            return adTelefonoRecupera.ListarTelefonoRecupera(idCli);
        }

    }
}
