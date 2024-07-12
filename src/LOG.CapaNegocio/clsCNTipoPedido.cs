using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;

namespace LOG.CapaNegocio
{
    public class clsCNTipoPedido
    {
        public clsListaTipoPedido buscaTipoPedido()
        {
            return new clsADTipoPedido().buscaTipoPedido();
        }

        public string GrabarTipoPedido(clsListaTipoPedido tipoPedido)
        {
            return new clsADTipoPedido().GrabarTipoPedido(tipoPedido);
        }
    }
}
