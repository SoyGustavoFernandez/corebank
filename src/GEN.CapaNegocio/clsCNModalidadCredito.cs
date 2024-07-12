using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNModalidadCredito
    {
        clsADModalidadCredito objModalidadCredito = new clsADModalidadCredito();

        public DataTable CNListarModalidadCredito()
        {
            var dt = objModalidadCredito.ADListarModalidadCreditoXml();
            DataTable dtModalidadCredito = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtModalidadCredito, LoadOption.OverwriteChanges);
            return dtModalidadCredito;
        }
    }
}
