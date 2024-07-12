using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADProvincia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaProvincia(string cCodDpto)
        {
            return objEjeSp.EjecSP("Gen_ListaProvincia_Sp", cCodDpto);
        }
    }
}
