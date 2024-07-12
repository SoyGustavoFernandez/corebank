using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNModDesembolso
    {
        public clsADModDesembolso AdModDesem = new clsADModDesembolso();
        public DataTable ListaModDesem()
        {
            return AdModDesem.ConModDes();
        }
    }
}
