using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADEstadoCivil
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaEstadoCivil( int nInd)
        {
            return objEjeSp.EjecSP("Gen_ListaEstadoCivil_sp",nInd);
        }
    }
}
