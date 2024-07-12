using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNListaNivelPersonal
    {
        clsADListaNivelPersonal objEstPeriodo = new clsADListaNivelPersonal();

        public DataTable ListarNivel()
        {
            var dt = objEstPeriodo.ListarNivel();
            DataTable dtNivel = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtNivel, LoadOption.OverwriteChanges);
            return dtNivel;

        }

    }
}
