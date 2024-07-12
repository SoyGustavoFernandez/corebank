using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADMontos
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarMontos(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_ListaMontos_sp", idModulo);
        }

        public DataTable ListarMontosTodos(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_ListaMontos_sp", idModulo);
        }
    }
}
