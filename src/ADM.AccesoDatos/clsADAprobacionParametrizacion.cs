using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using GEN.Funciones;
using EntityLayer;

namespace ADM.AccesoDatos
{
    public class clsADAprobacionParametrizacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public List<clsAprobacionAutonomiaUsuario> listarAproAutonomiaUsuario()
        {
            return objEjeSp.LOEjecutar<clsAprobacionAutonomiaUsuario>("ADM_ListarAproAutonomiaUsuario_SP");
        }
        public clsRespuestaServidor grabarAproAutonomiaUsuario(clsAprobacionAutonomiaUsuario objAproAutonomiaUsuario, int idUsuario, int idPerfil)
        {
            List<clsAprobacionAutonomiaUsuario> lstAproAutoUsuario = new List<clsAprobacionAutonomiaUsuario>();
            lstAproAutoUsuario.Add(objAproAutonomiaUsuario);
            string xmlAproAutoUsuario = lstAproAutoUsuario.ListObjectToXml("AproAutoUsuario","AproAutoUsuarios");
            return objEjeSp.OEjecutar<clsRespuestaServidor>("ADM_GrabarAproAutonomiaUsuario_SP", xmlAproAutoUsuario, idUsuario, idPerfil);
        }
        public clsRespuestaServidor gestionarAproAutonomiaUsuario(int idAprobacionAutonomiaUsuario, int idEstado, int idUsuario, int idPerfil)
        {
            return objEjeSp.OEjecutar<clsRespuestaServidor>("ADM_GestionarAproAutonomiaUsuario_SP", idAprobacionAutonomiaUsuario, idEstado, idUsuario, idPerfil);
        }
        public DataTable generarReporteHistAproAutoUsu()
        {
            return this.objEjeSp.EjecSP("ADM_GenerarReporteHistAproAutoUsu_SP");
        }
    }
}
