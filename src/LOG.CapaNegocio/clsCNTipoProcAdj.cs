using EntityLayer;
using LOG.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.CapaNegocio
{
    public class clsCNTipoProcAdj
    {
        public clsListaTipoProceso buscaTipoProceso()
        {
            return new clsADTipoProcAdj().buscaTipoProceso();
        }

        public string GrabarTipoProceso(clsTipoProceso tipoProceso, ref int nResp)
        {
            return new clsADTipoProcAdj().GrabarTipoProceso(tipoProceso, ref nResp);
        }

        public clsListaRangoPedidoProceso buscaRangoPedido(int idTipoProceso)
        {
            return new clsADTipoProcAdj().buscaRangoPedido(idTipoProceso);
        }


        public DataTable GrabarRangoPedido(clsRangoPedidoProceso rangoPedPro, ref int nResp)
        {
            return new clsADTipoProcAdj().GrabarRangoPedido(rangoPedPro, ref nResp);
        }

        public DataTable RetornaTipoProcesobyNP(int idTipoPedido, decimal nMontoNP)
        {
            return new clsADTipoProcAdj().ADRetornaTipoProcesoByNP(idTipoPedido, nMontoNP);
        }
    }
}
