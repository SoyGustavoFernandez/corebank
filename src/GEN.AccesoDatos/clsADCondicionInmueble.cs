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
    public class clsADCondicionInmueble
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public clslisCondicionInmueble listarCondicionInmueble()
        {
            clslisCondicionInmueble lista = new clslisCondicionInmueble();
            DataTable dt=objEjeSp.EjecSP("GEN_ListaCondiInmueble_sp");
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsCondicionInmueble()
                    {
                        idCondiInmueble = (int)item["idCondiInmueble"],
                        cCondiInmueble = item["cCondiInmueble"].ToString(),
                        idEstado = (int)item["idEstado"]
                    });

                }
            }

            return lista;
        }

        public clslisCondicionInmueble listarCondicionInmuebleXML()
        {
            clslisCondicionInmueble lista = new clslisCondicionInmueble();
            DataTable dt = cnadtabla.retonarTablaXml("SI_FinCondiInmueble");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsCondicionInmueble()
                    {
                        idCondiInmueble = (int)item["idCondiInmueble"],
                        cCondiInmueble = item["cCondiInmueble"].ToString(),
                        idEstado = (int)item["idEstado"]
                    });

                }
            }

            return lista;
        }
    }
}
