using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNCanal
    {
        public DataTable ListaCanal()
        {
            var dt = new clsADCanal().ListaCanalXml();

            DataTable dtCAnal = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtCAnal, LoadOption.OverwriteChanges);

            return dtCAnal;
        }

        public DataTable CNListarCanalTipOpe(int idTipOpeProduc)
        {
            return new clsADCanal().ADListarCanalTipOpe(idTipOpeProduc);
        }

        public DataTable CNListaCanalActivo()
        {
            return new clsADCanal().ListaCanal();
        }
    }
}
