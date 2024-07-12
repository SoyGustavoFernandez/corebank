using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNConvenios
    {
        public clsADConvenios Convenio = new clsADConvenios();
        public DataTable CNListaConveniosXml()
        {
            var dt = new clsADConvenios().ADListaConveniosXml();

            DataTable dtConvenio = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtConvenio, LoadOption.OverwriteChanges);

            return dtConvenio;
        }
        public DataTable CNClientesxPagarConvenio(DateTime dFechaProc, int idConvenio)
        {
            return Convenio.ADClientesxPagarConvenio(dFechaProc, idConvenio);
        }

    }
}
