using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNClasifProdDepos
    {
        clsADClasifProdDepos objdocide = new clsADClasifProdDepos();

        public DataTable ListarClasifProd()
        {

            var dt = objdocide.ListarClasifProdXml();

            DataTable dtClasifiPro = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtClasifiPro, LoadOption.OverwriteChanges);

            return dtClasifiPro;
        }
    }
}
