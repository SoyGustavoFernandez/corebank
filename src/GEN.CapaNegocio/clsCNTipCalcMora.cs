using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipCalcMora
    {
        public DataTable CNGetTipCalcMora()
        {
            return new clsADTipCalcMora().ADGetTipCalcMora();
        }
    }
}
