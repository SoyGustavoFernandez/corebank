using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipDocumento
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
 
        //Crear Método para ejecutar SP y trater datos de los Tipos de Docmento
        public DataTable ListaTipDocumento(string cTipDoc)
        {
            return objEjeSp.EjecSP("Gen_ListaTipDocumento_Sp", cTipDoc);
        }
        public DataTable ListaTipDoc()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoDocumento_sp");
        }
    }
}
