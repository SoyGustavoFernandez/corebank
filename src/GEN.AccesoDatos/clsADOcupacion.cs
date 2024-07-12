using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADOcupacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaOcupacion()
        {
            return objEjeSp.EjecSP("Gen_ListaOcupacion_Sp");
        }

        public DataTable ListaOcupacionPorIdDeclaracion(int idDeclaracion)
        {
            return objEjeSp.EjecSP("GEN_ListaOcupacionPorIdDeclaracion_SP", idDeclaracion);
        }
    }
}
