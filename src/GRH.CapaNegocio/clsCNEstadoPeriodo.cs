using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;


namespace GRH.CapaNegocio
{
    public class clsCNEstadoPeriodo
    {
        clsADEstadoPeriodo objEstPeriodo = new clsADEstadoPeriodo();

        public DataTable CNListadoEstPeriodo()
        {
            var dt = objEstPeriodo.ADListadoEstPeriodo();
            DataTable dtEstPeriodo = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstPeriodo, LoadOption.OverwriteChanges);
            return dtEstPeriodo;

        }
    }
}
