using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNEstPersonal
    {
        clsADEstPersonal objEstPersonal = new clsADEstPersonal();
        public DataTable ListaEstPersonal()
        {            
            //return objEstPersonal.ListaEstPersonal();

            var dt = objEstPersonal.ListaEstPersonalXML();
            DataTable dtEstadoPersonal = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoPersonal, LoadOption.OverwriteChanges);
            return dtEstadoPersonal;
            
        }
    }
}
