using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNFrecTiempo
    {
        clsADFrecTiempo obj = new clsADFrecTiempo();

        public DataTable ListarFrecTiempo()
        {            
            //return new clsADFrecTiempo().ListarFrecTiempo();

            var dt = obj.ListarFrecTiempoXML();
            DataTable dtFrecTiempo = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtFrecTiempo, LoadOption.OverwriteChanges);
            return dtFrecTiempo;
        }
    }
}
