using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;


namespace GRH.CapaNegocio
{
    public class clsCNTipoRegimen
    {
        clsADTipoRegimen objTipoRegimen = new clsADTipoRegimen();

        public DataTable CNListaTipoRegimen()
        {
            //return objPeriodoPlanilla.ADListaTipoRegimen();

            var dt = objTipoRegimen.ADListaTipoRegimenXML();
            DataTable dtTipoReg = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtTipoReg, LoadOption.OverwriteChanges);
            return dtTipoReg;
        }
    }
}
