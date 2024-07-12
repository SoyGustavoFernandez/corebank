using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADCargoPersonal
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ListaCargoPersonal(int idArea)
        {
            return objEjeSp.EjecSP("Gen_ListaCargoPersonal_sp", idArea);
        }

        public DataTable ListaPersonalxCargo(int idAgencia, int idCargo)
        {
            return objEjeSp.EjecSP("GEN_ListaPersonalxCargo_sp", idAgencia, idCargo);
        }

        public DataTable ListaCargoPersonalTodos(int idArea)
        {
            return objEjeSp.EjecSP("Gen_ListaCargoPersonalTodos_sp", idArea);
        }
        
    }
}
