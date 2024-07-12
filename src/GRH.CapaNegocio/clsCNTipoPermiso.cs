using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNTipoPermiso
    {
        clsADTipoPermiso objTipoPermiso = new clsADTipoPermiso();

        public DataTable CNListarTiposPermiso()
        {
            //return objTipoPermiso.ADListarTiposPermiso();

            var dt = objTipoPermiso.ADListarTiposPermisoXML();
            DataTable dtPermiso = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtPermiso, LoadOption.OverwriteChanges);
            return dtPermiso;
        }
    }
}
