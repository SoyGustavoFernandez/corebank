using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoBien
    {
        clsADTipoBien clsTipoBien = new clsADTipoBien();
        public DataTable CNListaTipoBien(int idTipoPedido)
        {
            return clsTipoBien.ADListaTipoBien(idTipoPedido);
        }

    }
}
