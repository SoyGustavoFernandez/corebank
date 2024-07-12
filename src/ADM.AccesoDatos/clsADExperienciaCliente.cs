using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using SolIntEls.GEN.Helper;
namespace ADM.AccesoDatos
{
    public class clsADExperienciaCliente
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        
        public DataTable ListaOficinasExpCliente()
        {
            return objEjeSp.EjecSP("ADM_ListaOficinasExpCliente_SP");
        }
        
        public DataTable ListaParametrosExpCliente(int idOficina, DateTime dFecha)
        {
            return objEjeSp.EjecSP("ADM_ListaParametrosExpCliente_SP", idOficina, dFecha);
        }

        public DataTable ActualizaEstadoOficinaExpCliente(int idOficina, int estado)
        {
            return objEjeSp.EjecSP("ADM_ActualizaOficinasExpCliente_SP", idOficina, estado);
        }

        public DataTable RegistraOficinaExpCliente(int idOficina)
        {
            return objEjeSp.EjecSP("ADM_RegistraOficinasExpCliente_SP", idOficina);
        }

        public DataTable ActualizaParametrosExpCliente(int idHorario, int idOficina, int idTipoOperacion, DateTime dFecha, decimal Porcentaje, string cUsuario)
        {
            return objEjeSp.EjecSP("ADM_ActualizaPorcentajeParametrosExpCliente_SP", idHorario, idOficina, idTipoOperacion, dFecha, Porcentaje, cUsuario);
        }

        public DataTable BlockParametrosExpCliente(int idOficina, DateTime dFecha, string cUsuario)
        {
            return objEjeSp.EjecSP("ADM_ActualizaBlockParametrosExpCliente_SP", idOficina, dFecha, cUsuario);
        }

        public DataTable RegistraCalificacionExpCliente(int icalificacion, DateTime dFecha, int idTipoOperacion, int idOficina, string cComentario, string cDocumentoID, int idUsuarioReg, int idExHorario)
        {
            return objEjeSp.EjecSP("ADM_RegistraCalificacionExpCliente_SP", icalificacion, dFecha, idTipoOperacion, idOficina, cComentario, cDocumentoID, idUsuarioReg, idExHorario);
        }

        public DataTable ListaParametrosEncuestaExpCliente(DateTime dFecha, DateTime dHora, int idTipoOperacion, int idOficina)
        {
            return objEjeSp.EjecSP("ADM_ListaParametrosEncuestaExpCliente_SP", dFecha, dHora, idTipoOperacion, idOficina);
        }

        public DataTable ActualizaIntervaloEncuestaExpCliente(DateTime dFecha, DateTime dHora, int idTipoOperacion, int idOficina, int intervalo)
        {
            return objEjeSp.EjecSP("ADM_ActualizaIntervaloEncuestaExpCliente_SP", dFecha, dHora, idTipoOperacion, idOficina, intervalo);
        }

        public DataTable GeneraParametrosExpCliente(DateTime dFecha, int idOficina, string cUsuario)
        {
            return objEjeSp.EjecSP("ADM_GeneraParametrosExpCliente_SP", dFecha, idOficina, cUsuario);
        }

        public DataTable AlertaCumpleExpCliente(string cDocumentoID)
        {
            return objEjeSp.EjecSP("ADM_AlertaCumpleExpCliente_SP", cDocumentoID);
        }
        
        public DataTable RegistraAlertaCumpleExpCliente(DateTime dFecha, string cSegmento, int idOficina, string cDocumentoID, int idUsuarioReg, int idUsuarioPerfil)
        {
            return objEjeSp.EjecSP("ADM_RegistraAlertaCumpleExpCliente_SP", dFecha, cSegmento, idOficina, cDocumentoID, idUsuarioReg, idUsuarioPerfil);
        }
        
        public DataTable PerfilesAlertaCumpleExpCliente(int idUsuarioPerfil)
        {
            return objEjeSp.EjecSP("ADM_PerfilesAlertaCumpleExpCliente_SP", idUsuarioPerfil);
        }
        
        public DataTable ListaPerfilesExpCliente()
        {
            return objEjeSp.EjecSP("ADM_ListaPerfilesExpCliente_SP");
        }

        public DataTable ActualizaPerfilExpCliente(int idPerfil, int estado)
        {
            return objEjeSp.EjecSP("ADM_ActualizaPerfilExpCliente_SP", idPerfil, estado);
        }

        public DataTable RegistraPerfilesExpCliente(int idPerfil, int nVeces)
        {
            return objEjeSp.EjecSP("ADM_RegistraPerfilesExpCliente_SP", idPerfil, nVeces);
        }

        public DataTable CancelaParametrosExpCliente(int idOficina, DateTime dFecha)
        {
            return objEjeSp.EjecSP("ADM_CancelaParametrosExpCliente_SP", idOficina, dFecha);
        }

        public DataSet ListaParametrosEncuesta()
        {
            return objEjeSp.DSEjecSP("GEN_ParametrosEncuesta_SP");
        }

        public DataTable ListaModulosAlertaCumple()
        {
            return objEjeSp.EjecSP("GEN_ListaModulosAlertaCumple_SP");
        }

    }
}
