using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;   

namespace GEN.AccesoDatos
{
    public class clsADArea
    {
        public DataTable CNListadoArea(int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarAreas_sp", idAgencia);
        }
        public DataTable CNListarTodasAreas()
        {
            return new clsGENEjeSP().EjecSP("GRH_ListarTodasAreas_sp" );
        }

        public DataTable CNListadoTodosPorArea(int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTodasAreasxAge_sp", idAgencia);
        }
    }
}
