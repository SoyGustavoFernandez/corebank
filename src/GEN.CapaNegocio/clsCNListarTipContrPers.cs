using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListarTipContrPers
    {
        clsADListarTipContrPers objListaProv = new clsADListarTipContrPers();

        public DataTable ListarTipContrPers()
        {
            return objListaProv.ListarTipContrPers();
        }
    }
}
