using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNCaracteristCta
    {
        public clsADCaracteristCta objdocide = new clsADCaracteristCta();
        public DataTable listarCaractCta()
        {
            var dt = objdocide.listarCaractCtaXml();

            DataTable dtCaracteristica = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtCaracteristica, LoadOption.OverwriteChanges);

            return dtCaracteristica;
        }
    }
}
