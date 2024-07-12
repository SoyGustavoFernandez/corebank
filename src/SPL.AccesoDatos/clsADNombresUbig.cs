using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SPL.AccesoDatos
{
    public class clsADNombresUbig
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public DataTable listarNombres(int pais, int dep, int prov, int dist)
        {
            ds = objEjeSp.EjecSP("GEN_ListarNombresUbig", pais, dep, prov, dist);
            return ds;
        }           
    }
}
