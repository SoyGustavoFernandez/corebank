using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNSupervisor
    {
        clsADSupervisor adSupervisor = new clsADSupervisor();

        public DataTable ListarUsuariosSupervisados(int idUsuarioSupervisor)
        {
            return adSupervisor.ListarAgenciasSupervisadas(idUsuarioSupervisor);
        }
        
        public DataTable registrarNuevoSupervisado(int idUsuarioSupervisor, int idAgencia, int idUsuarioRegistra)
        {
            return adSupervisor.RegistraAgenciaSupervisada(idUsuarioSupervisor, idAgencia, idUsuarioRegistra);
        }

        public DataTable QuitarAgenciaSupervisada(int idAgenciaSupervisada, int idUsuarioRegistra)
        {
            return adSupervisor.QuitarAgenciaSupervisada(idAgenciaSupervisada, idUsuarioRegistra);
        }
    }
}
