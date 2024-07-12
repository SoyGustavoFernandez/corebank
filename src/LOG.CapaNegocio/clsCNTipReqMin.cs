using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNTipReqMin
    {
        private clsADTipReqMin cnADTipReqMin =  new clsADTipReqMin();
        public List<clsTipReqMin> CNListaTipoReqMin()
        {
            return cnADTipReqMin.ADListaTipoReqMin();
        }

        public DataTable CNListaReqMinxDetalleNotaPedido(int idDetalleNota)
        {
            return cnADTipReqMin.ADListaReqMinxDetalleNotaPedido(idDetalleNota);
        }
    }
}
