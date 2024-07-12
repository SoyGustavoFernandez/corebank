using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.AccesoDatos;

namespace DEP.AccesoDatos
{
    public class clsADEstadoCtaDeposito
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        
        public DataTable ListarEstadoDep()
        {
            return objEjeSp.EjecSP("GEN_ListarEstadoCtaDepo_sp");
        }

        public DataTable ListarEstadoDepXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoDep");
        }

    }
}
