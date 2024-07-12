using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipPersona
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater datos de los Tipos de Persona

        public DataTable ADListarTipoPersona()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoPersona_sp");
        }

        public DataTable ADListarTipPersonaProducto(int idProducto)
        {
            return objEjeSp.EjecSP("GEN_ListarTipPersonaProducto_SP", idProducto);
        }
    }
}
