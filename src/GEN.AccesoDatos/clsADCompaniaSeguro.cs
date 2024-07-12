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
    public class clsADCompaniaSeguro
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public clslisCompaniaSeguro listarCompanias()
        {
            clslisCompaniaSeguro lista = new clslisCompaniaSeguro();

            DataTable dt = objEjeSp.EjecSP("GEN_ListaCompaniasSeguros_sp");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsCompaniaSeguro()
                    {
                        idCompania = (int)item["idCompania"],
                        cCompania = item["cCompania"].ToString(),
                        idEstado = (int)item["idEstado"]
                    });

                }
            }
            return lista;
        }

        public clslisCompaniaSeguro listarCompaniasXML()
        {
            clslisCompaniaSeguro lista = new clslisCompaniaSeguro();

            DataTable dt = cnadtabla.retonarTablaXml("SI_FinCompaniasSeguro");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsCompaniaSeguro()
                    {
                        idCompania = (int)item["idCompania"],
                        cCompania = item["cCompania"].ToString(),
                        idEstado = (int)item["idEstado"]
                    });

                }
            }
            return lista;
        }

    }
}
