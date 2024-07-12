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
    public class clsADEstadoConservacion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisEstadoConservacion listarEstadosConservacion()
        {
            clslisEstadoConservacion lista = new clslisEstadoConservacion();
            DataTable dt = objEjeSp.EjecSP("GEN_ListaEstadoConservacion_sp");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsEstadoConservacion
                    {
                        idEstadoConservacion = (int)item["idEstadoConservacion"],
                        cEstadoConservacion = item["cEstadoConservacion"].ToString(),
                        idEstado = (int)item["idEstado"]
                    });

                }
            }

            return lista;
        }
    }
}
