using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using GEN.AccesoDatos;   

namespace GEN.CapaNegocio
{
    public class clsCNBusReports
    {
        List<clsReporte> lisRep = new List<clsReporte>();

        public List<clsReporte> LisReports(string cMOD)
        {
            try
            {
                lisRep= new clsADReporte().LisReports(cMOD);
                return lisRep;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsReporte> LisRepByName(string RepoName)
        {
            try
            {
                var query = from r in lisRep
                            where r.Reporte.ToUpper().Trim().Contains(RepoName.ToUpper().Trim())
                            orderby r.Reporte
                            select r;
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
