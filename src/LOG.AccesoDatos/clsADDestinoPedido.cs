using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.AccesoDatos
{
    public class clsADDestinoPedido
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListaDestinoPedido(int idDestinoPedido)
        {
            return objEjeSp.EjecSP("LOG_ListaDestinoPedido_SP", idDestinoPedido);
        }


        public DataTable ListaDestinoPedidoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinDestinoPedido");
        }
    }
}
