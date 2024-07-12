using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListarGrSanguineo
    {
        clsADListarGrSanguineo objListaProv = new clsADListarGrSanguineo();
                
        public DataTable ListarGrupoSanguineo()
        {            
            //return objListaProv.ListarGrupoSanguineo();            

            var dt = objListaProv.ListarGrupoSanguineoXML();
            DataTable dtGrupoSang = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true            
             select item).CopyToDataTable(dtGrupoSang, LoadOption.OverwriteChanges);
            return dtGrupoSang;
        }
    }
}
