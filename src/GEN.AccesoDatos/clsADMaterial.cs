using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADMaterial
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisMaterial listarMateriales()
        {

            clslisMaterial lista = new clslisMaterial();
            DataTable dt = objEjeSp.EjecSP("GEN_ListaMateriales_sp");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsMaterial()
                    {
                        idMaterial = (int)item["idMaterial"],
                        cMaterial = item["cMaterial"].ToString(),
                        nTipoContruccion = (int)item["nTipoContruccion"],
                        idEstado = (int)item["idEstado"]
                    });

                }
            }

            return lista;
        }
    }
}
