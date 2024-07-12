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
    public class clsADTipoRegimen
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ADListaTipoRegimen()
        {
            return objEjeSp.EjecSP("GRH_ListarTipoRegimen_SP");
        }
        public DataTable ADListaTipoRegimenXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoRegimenPensionario");
        }
    }
}
