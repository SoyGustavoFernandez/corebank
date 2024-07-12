using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;

namespace LOG.CapaNegocio
{
    public class clcCNTipoComprobantes
    {
        clsADTipoComprobantes clsComprobantes = new clsADTipoComprobantes();

        public DataTable CNListarTipoComprobantes()
        {
            return clsComprobantes.ListarTipoComprobantes();
        }

    }
}
