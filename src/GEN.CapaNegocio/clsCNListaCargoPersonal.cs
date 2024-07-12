using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNListaCargoPersonal
    {
        clsADCargoPersonal objCargoPersonal = new clsADCargoPersonal();

        public DataTable ListacargoPersonal(int idArea)
        {
            return objCargoPersonal.ListaCargoPersonal(idArea);
        }

        public DataTable ListaPersonalxCargo(int idAgencia, int idCargo)
        {
            return objCargoPersonal.ListaPersonalxCargo(idAgencia, idCargo);
        }
        public DataTable ListacargoPersonalTodos(int idArea)
        {
            return objCargoPersonal.ListaCargoPersonalTodos(idArea);
        }
    }
}
