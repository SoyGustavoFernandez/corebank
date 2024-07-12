using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNNaturalezaCnt
    {
        clsADNaturalezaCnt objNatCnt = new clsADNaturalezaCnt();
        public DataTable clsCNListarNaturalezaCnt()
        {
            return objNatCnt.ADListaNaturalezaCta();
        }       
    }
}
