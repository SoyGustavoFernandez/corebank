using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipDocRevCred
    {
        public DataTable GetTipDocRevCred()
        {
            return new clsGENEjeSP().EjecSP("CRE_GetTipDocRevCred_Sp");
        }
    }
}
