using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNAgencia
    {
        public DataTable LisAgen()
        {

            var dt = new clsADAgencia().LisAgeXml();

            DataTable dtAgencias = dt.Clone();
            DataRow drTodas = dtAgencias.NewRow();

            drTodas["idAgencia"] = 0;
            drTodas["cNombreAge"] = "TODAS LAS AGENCIAS";
            drTodas["cNomCorto"] = "TODAS";
            drTodas["idUbigeo"] = 1;
            drTodas["cDirección"] = "";
            drTodas["cRefDirec"] = "";
            drTodas["cFono"] = "";
            drTodas["lEstado"] = true;

            dtAgencias.Rows.Add(drTodas);

            (from item in dt.AsEnumerable()
             where (bool)item["lEstado"] == true
             select item).CopyToDataTable(dtAgencias, LoadOption.OverwriteChanges);           

            return dtAgencias;
        }

        public DataTable LisSoloAgencias()
        {

            var dt = new clsADAgencia().LisAgeXml();

            DataTable dtAgencias = dt.Clone();
            DataRow drTodas = dtAgencias.NewRow();

            (from item in dt.AsEnumerable()
             where (bool)item["lEstado"] == true
             select item).CopyToDataTable(dtAgencias, LoadOption.OverwriteChanges);

            return dtAgencias;
        }
    }
}
