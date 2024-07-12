using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADSupervisor
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarAgenciasSupervisadas(int idUsuarioSupervisor)
        {
            return objEjeSp.EjecSP("RCP_ListarAgenciasSupervisadas_SP", idUsuarioSupervisor);
        }

        public DataTable RegistraAgenciaSupervisada(int idUsuarioSupervisor, int idAgencia, int idUsuarioRegistra)
        {
            return objEjeSp.EjecSP("RCP_RegistraAgenciaSupervisada_SP", idUsuarioSupervisor, idAgencia, idUsuarioRegistra);
        }

        public DataTable QuitarAgenciaSupervisada(int idAgenciaSupervisada, int idUsuarioRegistra)
        {
            return objEjeSp.EjecSP("RCP_QuitarAgenciaSupervisada_SP", idAgenciaSupervisada, idUsuarioRegistra);
        }
    }
}
