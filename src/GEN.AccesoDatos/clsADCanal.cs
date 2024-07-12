using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;   

namespace GEN.AccesoDatos
{
    public class clsADCanal
    {

        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ListaCanal()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCanal_sp");
        }

        public DataTable ListaCanalXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinCanal");
        }

        public DataTable ADListarCanalTipOpe(int idTipOpeProduc)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCanalTipOpe_SP", idTipOpeProduc);
        }
    }
}
