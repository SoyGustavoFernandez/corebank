using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;

namespace CRE.AccesoDatos
{
    public class clsADCobertura
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public clslisCobertura listarCoberturas()
        {
            clslisCobertura lista = new clslisCobertura();
            DataTable dtGarantias = objEjeSp.EjecSP("CRE_ListaCoberturas_sp");

            if (dtGarantias.Rows.Count > 0)
            {
                foreach (DataRow item in dtGarantias.Rows)
                {
                    lista.Add(new clsCobertura()
                    {
                        idCobertura = Convert.ToInt32(item["idCobertura"]),
                        cCobertura = Convert.ToString(item["cCobertura"]),
                        idEstado = Convert.ToInt32(item["idEstado"])
                    });
                }
            }
            return lista;
        }

        public clslisCobertura listarCoberturasXML()
        {
            clslisCobertura lista = new clslisCobertura();
            DataTable dtGarantias = cnadtabla.retonarTablaXml("SI_FinCobertura");

            if (dtGarantias.Rows.Count > 0)
            {
                foreach (DataRow item in dtGarantias.Rows)
                {
                    lista.Add(new clsCobertura()
                    {
                        idCobertura = Convert.ToInt32(item["idCobertura"]),
                        cCobertura = Convert.ToString(item["cCobertura"]),
                        idEstado = Convert.ToInt32(item["idEstado"])
                    });
                }
            }
            return lista;
        }
    }
}
