using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADDistrito
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaDistrito(string cCodProv)
        {
            return objEjeSp.EjecSP("Gen_ListaDistrito_Sp", cCodProv);
        }
    }
}
