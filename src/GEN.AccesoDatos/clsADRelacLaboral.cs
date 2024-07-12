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
    public class clsADRelacLaboral
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisRelacLaboral listarRelacionLaboral()
        {

            clslisRelacLaboral lista = new clslisRelacLaboral();
            DataTable dt = objEjeSp.EjecSP("GEN_RetRelLaboral_sp");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsRelacLaboral()
                    {
                        idRelacLaboral = (int)item["idRelacLaboral"],
                        cCodigoSBS = item["cCodigoSBS"].ToString(),
                        cRelacLaboral = item["cRelacLaboral"].ToString(),
                        lVigente = (bool)item["lVigente"]
                    });

                }
            }

            return lista;
        }
    }
}
