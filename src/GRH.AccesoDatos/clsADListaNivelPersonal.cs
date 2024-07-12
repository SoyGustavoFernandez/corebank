using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;

namespace GRH.AccesoDatos
{
    public class clsADListaNivelPersonal
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarNivel()
        {
            return cnadtabla.retonarTablaXml("SI_FinNivelPersonal");
        }

    }
}
