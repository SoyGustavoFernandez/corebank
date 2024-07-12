using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
   public class clsADProcesosGenerales
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ConsultaConsolidacion(int idPeriodo)
        {
            return objEjeSp.EjecSP("GRH_ConsultaConsolTardFaltas_SP", idPeriodo);
        }
        public void Consolidar(int TipoProceso, int idPeriodo, int idUsuario, DateTime dFecRegistro)
        {
            objEjeSp.EjecSP("GRH_ConsolidarTardanFaltas_SP",TipoProceso, idPeriodo,  idUsuario,  dFecRegistro);
        }
    }
}
