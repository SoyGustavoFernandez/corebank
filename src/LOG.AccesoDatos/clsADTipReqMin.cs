using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace LOG.AccesoDatos
{
    public class clsADTipReqMin
    {
        public List<clsTipReqMin> ADListaTipoReqMin()
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_ListarTipoReqMin_sp");
            List<clsTipReqMin> lstTipReqMin = MapeaTablaEntidadTipReqMin(dtResult);
            return lstTipReqMin;
        }

        private List<clsTipReqMin> MapeaTablaEntidadTipReqMin(DataTable dtResult)
        {
            List<clsTipReqMin> lstTipReqMin = new List<clsTipReqMin>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsTipReqMin objTipReqMin = new clsTipReqMin();
                objTipReqMin.idTipoReqMinimo = Convert.ToInt16(row["idTipoReqMinimo"]);
                objTipReqMin.cTipoReqMinimo = Convert.ToString(row["cTipoReqMinimo"]);
                objTipReqMin.lIndAplica = Convert.ToBoolean(row["lIndAplica"]);
                lstTipReqMin.Add(objTipReqMin);
            }
            return lstTipReqMin;
        }

        public DataTable ADListaReqMinxDetalleNotaPedido(int idDetalleNota)
        {
            return new clsGENEjeSP().EjecSP("LOG_ObtenerReqMinimosxNotaPedido_SP", idDetalleNota);
        }
    }
}
