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
    public class clsADTipoProcAdj
    {
        public clsListaTipoProceso buscaTipoProceso()
        {
            clsListaTipoProceso listTipoProceso = new clsListaTipoProceso();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarTipoProceso_SP");
            int i = 0;
            foreach (DataRow item in ds.Rows)
            {
                listTipoProceso.Add(new clsTipoProceso()
                {
                    idTipoProceso = Convert.ToInt32(item["idTipoProceso"].ToString()),
                    cDescCorta = item["cDescCorta"].ToString(),
                    cTipoProceso = item["cTipoProceso"].ToString(),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );
                i += 1;
            }
            return listTipoProceso;
        }

        public string GrabarTipoProceso(clsTipoProceso TipProceso, ref int nResp)
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_GrabaTipoProceso_Sp", TipProceso.obtenerXml());
            nResp = Convert.ToInt32(ds.Rows[0]["nResp"].ToString());
            return ds.Rows[0]["mResp"].ToString();
        }

        public clsListaRangoPedidoProceso buscaRangoPedido(int idTipoProceso)
        {
            clsListaRangoPedidoProceso lstRangoPedido = new clsListaRangoPedidoProceso();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarRagPedidoProceso_SP", idTipoProceso);

            foreach (DataRow item in ds.Rows)
            {
                lstRangoPedido.Add(new clsRangoPedidoProceso()
                {
                    idRelPedidoProceso = Convert.ToInt32(item["idRelPedidoProceso"].ToString()),
                    idTipoPedido = Convert.ToInt32(item["idTipoPedido"].ToString()),
                    cTipoPedio = item["cTipoPedido"].ToString(),
                    idTipoProceso = Convert.ToInt32(item["idTipoProceso"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                    nValorMax = Convert.ToDecimal(item["nValorMax"].ToString()),
                    idTipoEvaluacion = Convert.ToInt32(item["idTipoEvaluacion"].ToString()),
                    nValorMin = Convert.ToDecimal(item["nValorMin"].ToString())
                });
            }
            return lstRangoPedido;
        }

        public DataTable GrabarRangoPedido(clsRangoPedidoProceso rangoPedido, ref int nResp)
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_GrabarRangoPedidoProceso_Sp", rangoPedido.obtenerXml());
            nResp = Convert.ToInt32(ds.Rows[0]["nResp"].ToString());
            return ds;
        }

        public DataTable ADRetornaTipoProcesoByNP(int idTipoPedido, decimal nMontoNP)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaTipProcByNP_sp", idTipoPedido, nMontoNP);
        }
    }
}
