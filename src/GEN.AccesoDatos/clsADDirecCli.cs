using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADDirecCli
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaDireccion(int cCodCli)
        {
            return objEjeSp.EjecSP("Gen_ListaDirCli_Sp", cCodCli);
        }

        public DataTable ListaSuministro()
        {
            return objEjeSp.EjecSP("Gen_ListaSuministro_sp");
        }

        public DataTable ListaTipoDireccion()
        {
            return objEjeSp.EjecSP("GEN_ListaTipoDireccion_SP");
        }
    }
}
