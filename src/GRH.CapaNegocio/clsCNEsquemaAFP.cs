using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNEsquemaAFP
    {
        clsADEsquemaAFP objPeriodoPlanilla = new clsADEsquemaAFP();

        public DataTable ListarEsquemaComAFP()
        {
            //return objPeriodoPlanilla.ListarEsquemaComAFP();

            var dt = objPeriodoPlanilla.ListarEsquemaComAFPXML();
            DataTable dtEsquema = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEsquema, LoadOption.OverwriteChanges);
            return dtEsquema;

        }
    }
}
