using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;

namespace LOG.CapaNegocio
{
    public class clsCNDestinoPedido
    {
        private clsADDestinoPedido objCNDestPed = new clsADDestinoPedido();

        public DataTable ListaDestinoPedido(int idDestinoPedido)
        {
            return objCNDestPed.ListaDestinoPedido(idDestinoPedido);
        }

        public DataTable ListaDestinoPedidoXml()
        {
            return objCNDestPed.ListaDestinoPedidoXml();
        }
    }
}
