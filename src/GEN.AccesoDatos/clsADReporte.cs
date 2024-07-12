using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADReporte
    {
        /// <summary>
        /// Metodo que lista reportes por modulo
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public List<clsReporte> LisReports(string cMOD)
        {
            List<clsReporte> lisRep = new List<clsReporte>();
            try
            {
               clsGENEjeSP objEjeSp = new clsGENEjeSP();
                var query=objEjeSp.EjecSP("GEN_LisReports", cMOD);
                foreach (DataRow item in query.Rows)
                {
                    lisRep.Add(new clsReporte()
                    {
                        IDReporte = (int)item["IDReporte"],
                        IDModulo = (string)item["IDModulo"],
                        Reporte= (string)item["Reporte"],
                        Descripcion = (string)item["Descripcion"],
                        Ruta=(string)item["Ruta"],
                        lActivo = (bool)item["lActivo"],
                    });
                }
                return lisRep;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 


    }
}
