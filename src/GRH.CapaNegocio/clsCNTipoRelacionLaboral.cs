using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNTipoRelacionLaboral
    {
        clsADTipoRelacionLaboral objTipoRelacionLaboral = new clsADTipoRelacionLaboral();

        public DataTable CNListarTipoRelacionLaboral()
        {
            //return objTipoRelacionLaboral.ADListarTipoRelacionLaboral();

            var dt = objTipoRelacionLaboral.ADListarTipoRelacionLaboralXML();
            DataTable dtRelLab = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtRelLab, LoadOption.OverwriteChanges);
            return dtRelLab;
        }

        public DataTable CNListarTipoRelacionLaboralPlanillas()
        {
            return objTipoRelacionLaboral.ADListarTipoRelacionLaboralPlanillas();
        }
    }
}
