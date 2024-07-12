using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADComiteCred
    {
        public clsGENEjeSP objEjesp = new clsGENEjeSP();

        public DataTable ADLstResultComiteCred()
        {
            return objEjesp.EjecSP("CRE_LstEstadoEvalCredDecisionComiteCred_Sp");
        }

        public DataTable ADLstEstadoEvalCredNivelSuperior()
        {
            return objEjesp.EjecSP("CRE_LstEstadoEvalCredNivelSuperior_Sp");
        }


        public DataTable ADLstEstComiteCred()
        {
            return objEjesp.EjecSP("CRE_LstEstComiteCre_Sp");
        }
    }
}
