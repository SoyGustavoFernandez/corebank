using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListaDiasSemana
    {
        clsADListaDiasSemana objListaProv = new clsADListaDiasSemana();
        public DataTable ListarDiasSemana()
        {
            //return objListaProv.ListarDiasSemana();

            var dt = objListaProv.ListarDiasSemanaXML();
            DataTable dtDias = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtDias, LoadOption.OverwriteChanges);
            return dtDias;

        }
    }
}
