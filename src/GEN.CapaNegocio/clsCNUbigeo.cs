using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
   public  class clsCNUbigeo
    {
       public clsUbigeo objdocide = new clsUbigeo();
       public DataTable listarUbigeo(Int32 nIdNodo)
        {

           //return objdocide.ListarUbigeo(nIdNodo); 

            var dt = objdocide.ListarUbigeoXml(nIdNodo); 

            DataTable dtUbigeo = dt.Clone();
            DataRow drTodas = dtUbigeo.NewRow();

            drTodas["idUbigeo"] = 0;
            drTodas["cUbigeoSBS"] = "";
            drTodas["cDescipcion"] = "";
            drTodas["idUbigeoPadre"] = 0;
            drTodas["lVigente"] = true;
            drTodas["nUbigeoSUNAT"] = 0;
            drTodas["cCodLargaDist"] = "";
           

            dtUbigeo.Rows.Add(drTodas);
            
            foreach (DataRow item in dt.Rows)
            {
                if (item["idUbigeoPadre"] == DBNull.Value)
                {
                    item["idUbigeoPadre"] = 0;
                }
            }           

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             && (int)item["idUbigeoPadre"] == nIdNodo
             orderby item["cDescipcion"]
             select item).CopyToDataTable(dtUbigeo, LoadOption.OverwriteChanges);

            return dtUbigeo;
        }

       public DataTable ListarNombresUbig(int IdPais, int nIdDepartamento, int nIdProvincia, int nIdDistrito)
       {
           return objdocide.ListarNombresUbig(IdPais, nIdDepartamento, nIdProvincia, nIdDistrito);
       }
    }
}
