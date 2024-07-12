using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNMoneda
    {
        public clsMoneda objdocide = new clsMoneda();
        public DataTable listarMoneda()
        {
            //return objdocide.ListarMoneda();
            
            var dt=objdocide.ListarMonedaXml();

            DataTable dtmoneda = dt.Clone();

           (from item in dt.AsEnumerable()
             where (bool)item["lVigente"]== true
                && (int)item["idMoneda"] > 0
             select item).CopyToDataTable(dtmoneda, LoadOption.OverwriteChanges);
            
            return dtmoneda;
        }
        public DataTable CNListaMonedas()
        {
            return objdocide.ADListaMonedas();
        }
        public DataTable listarMonedaConta()
        {
            //return objdocide.ListarMoneda();

            var dt = objdocide.ListarMonedaXml();

            DataTable dtmoneda = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true               
             select item).CopyToDataTable(dtmoneda, LoadOption.OverwriteChanges);

            return dtmoneda;
        }
    }
}
