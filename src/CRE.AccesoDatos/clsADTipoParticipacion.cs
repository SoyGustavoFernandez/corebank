using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADTipoParticipacion
    {
        public clsGENEjeSP objEjesp = new clsGENEjeSP();

        public DataTable ADLstTipoParticip()
        {
            return objEjesp.EjecSP("CRE_LstTipoParticipComite_Sp");
        }
    }
}
