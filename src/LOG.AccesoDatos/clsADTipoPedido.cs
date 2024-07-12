using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.AccesoDatos
{
    public class clsADTipoPedido
    {
        public clsListaTipoPedido buscaTipoPedido()
        {
            clsListaTipoPedido listTipoPedido = new clsListaTipoPedido();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListaTipoPedido_sp");

            foreach (DataRow item in ds.Rows)
            {
                listTipoPedido.Add(new clsTipoPedio()
                {
                    idTipoPedido = Convert.ToInt32(item["idTipoPedido"].ToString()),
                    cTipoPedido = item["cTipoPedido"].ToString(),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );

            }
            return listTipoPedido;
        }

        public string GrabarTipoPedido(clsListaTipoPedido TipPedido)
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_GrabarTipoPedido_Sp", TipPedido.obtenerXml());
            return ds.Rows[0]["nResp"].ToString();
        }
    }
}
