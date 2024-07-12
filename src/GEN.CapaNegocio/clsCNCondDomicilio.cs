using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNCondDomicilio
    {
        clsADCondDomicilio objDomicilio = new clsADCondDomicilio();
        public DataTable CNListaCondDomicilio()
        {
            return objDomicilio.ADListaCondDomicilio();
        }
    }
}
