using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GRH.AccesoDatos
{
    public class clsADEstablecimeinto
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListadoEstablec(int idAgencia)
        {
            return objEjeSp.EjecSP("GRH_ListarEstablecimientos_SP", idAgencia);
        }

        public DataTable ListarEstablecimientos(int idPadre, int idZona, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListaEstablecimientos_SP", idPadre, idZona, idAgencia);
        }
    }
}
