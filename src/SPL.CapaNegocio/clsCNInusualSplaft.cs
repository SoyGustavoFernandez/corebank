using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNInusualSplaft
    {
        public DataTable listarInusual()
        {

            clsADInusualSplaft objKarx = new clsADInusualSplaft();
            return objKarx.ListarInusual();

        }
    }
}
