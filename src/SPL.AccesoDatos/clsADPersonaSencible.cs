using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADPersonaSencible
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();
       

        public clsListPersonaSencible listarPSencible()         
        {
            clsListPersonaSencible listaSencible = new clsListPersonaSencible();

            return listaSencible;
        }
    }
}
