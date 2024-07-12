using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipObsSol
    {
        public DataTable CNLstTipObsSol()
        {
            return new clsADTipObsSol().ADLstTipObsSol();
        }
    }
}
