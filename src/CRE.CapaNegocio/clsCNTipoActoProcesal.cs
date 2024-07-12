using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNTipoActoProcesal
    {
        clsADTipoActoProcesal adTipoActoProcesal = new clsADTipoActoProcesal();
        public DataTable listarTipoActoProcesal()
        {
            return adTipoActoProcesal.listarTipoActoProcesal();
        }
    }
}
