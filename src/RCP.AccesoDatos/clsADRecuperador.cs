using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADRecuperador
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarUsuariosRecuperaciones()
        {
            return objEjeSp.EjecSP("RCP_ListarGestorRecuperacion_SP");
        }

        public DataTable ListarUsuariosRecuperacionesYLegal()
        {
            return objEjeSp.EjecSP("RCP_ListarGestorRecuperacionYLegal_SP");
        }

        public DataTable ListarUsuariosRecuperacionesYLegalUnicos()
        {
            return objEjeSp.EjecSP("RCP_ListarGestorRecuperacionYLegalUnicos_SP");
        }

        public DataTable ListarUsuariosSupervisados(int idUsuarioSupervisor)
        {
            return objEjeSp.EjecSP("RCP_ListarUsuariosSupervisados_SP", idUsuarioSupervisor);
        }

        public DataTable ListarGestoresLegalesTodos()
        {
            return objEjeSp.EjecSP("RCP_ListarGestorLegal_SP");
        }

        public DataTable LstGestRecuperaEstablecimiento()
        {
            return objEjeSp.EjecSP("RCP_LstGestRecuperaEstablecimiento_SP");
        }

        public DataTable ListarRegionAgenciaEstabs(int idRegion)
        {
            return objEjeSp.EjecSP("GEN_ListarRegionAgenciaEstabs_SP", idRegion);
        }
        public DataTable ListarEstablecGestorRecuperacion()
        {
            return objEjeSp.EjecSP("RCP_ListarEstablecGestorRecuperacion_SP");
        }
        public DataTable GrabarEstablecGestorRecuperacion(int idUsuario, DateTime dFecha, string xmlEstabGestorRecuperacion)
        {
            return objEjeSp.EjecSP("RCP_GrabarEstablecGestorRecuperacion_SP", idUsuario, dFecha, xmlEstabGestorRecuperacion);
        }
    }
}
