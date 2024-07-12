using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipDocRevCred
    {
        public System.Data.DataTable GetTipDocRevCred()
        {
            return new clsADTipDocRevCred().GetTipDocRevCred();
        }
    }
}
