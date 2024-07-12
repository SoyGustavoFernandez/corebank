using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using System.Data;
namespace ADM.CapaNegocio
{
    public class clsCNExperienciaCliente
    {
        private clsADExperienciaCliente objADExperienciaCliente;

        public clsCNExperienciaCliente()
        {
            this.objADExperienciaCliente = new clsADExperienciaCliente();
        }
        
        public DataTable ListaOficinasExpCliente()
        {
            return objADExperienciaCliente.ListaOficinasExpCliente();
        }

        public DataTable ListaParametrosExpCliente(int idOficina, DateTime dFecha)
        {
            return objADExperienciaCliente.ListaParametrosExpCliente(idOficina, dFecha);
        }

        public DataTable ActualizaEstadoOficinaExpCliente(int idOficina, int estado)
        {
            return objADExperienciaCliente.ActualizaEstadoOficinaExpCliente(idOficina, estado);
        }

        public DataTable RegistraOficinaExpCliente(int idOficina)
        {
            return objADExperienciaCliente.RegistraOficinaExpCliente(idOficina);
        }

        public DataTable ActualizaParametrosExpCliente(int idHorario, int idOficina, int idTipoOperacion, DateTime dFecha, decimal Porcentaje, string cUsuario)
        {
            return objADExperienciaCliente.ActualizaParametrosExpCliente(idHorario, idOficina, idTipoOperacion, dFecha, Porcentaje, cUsuario);
        }

        public DataTable BlockParametrosExpCliente(int idOficina, DateTime dFecha, string cUsuario)
        {
            return objADExperienciaCliente.BlockParametrosExpCliente(idOficina, dFecha, cUsuario);
        }

        public DataTable RegistraCalificacionExpCliente(int icalificacion, DateTime dFecha, int idTipoOperacion, int idOficina, string cComentario, string cDocumentoID, int idUsuarioReg, int idExHorario)
        {
            return objADExperienciaCliente.RegistraCalificacionExpCliente(icalificacion, dFecha, idTipoOperacion, idOficina, cComentario, cDocumentoID, idUsuarioReg, idExHorario);
        }
        
        public DataTable ListaParametrosEncuestaExpCliente(DateTime dFecha, DateTime dHora, int idTipoOperacion, int idOficina)
        {
            return objADExperienciaCliente.ListaParametrosEncuestaExpCliente(dFecha, dHora, idTipoOperacion, idOficina);
        }

        public DataTable ActualizaIntervaloEncuestaExpCliente(DateTime dFecha, DateTime dHora, int idTipoOperacion, int idOficina, int intervalo)
        {
            return objADExperienciaCliente.ActualizaIntervaloEncuestaExpCliente(dFecha, dHora, idTipoOperacion, idOficina, intervalo);
        }

        public DataTable GeneraParametrosExpCliente(DateTime dFecha, int idOficina, string cUsuario)
        {
            return objADExperienciaCliente.GeneraParametrosExpCliente(dFecha, idOficina, cUsuario);
        }

        public DataTable AlertaCumpleExpCliente(string cDocumentoID)
        {
            return objADExperienciaCliente.AlertaCumpleExpCliente(cDocumentoID);
        }

        public DataTable RegistraAlertaCumpleExpCliente(DateTime dFecha, string cSegmento, int idOficina, string cDocumentoID, int idUsuarioReg, int idUsuarioPerfil)
        {
            return objADExperienciaCliente.RegistraAlertaCumpleExpCliente(dFecha, cSegmento, idOficina, cDocumentoID, idUsuarioReg, idUsuarioPerfil);
        }

        public DataTable PerfilesAlertaCumpleExpCliente(int idUsuarioPerfil)
        {
            return objADExperienciaCliente.PerfilesAlertaCumpleExpCliente(idUsuarioPerfil);
        }

        public DataTable ListaPerfilesExpCliente()
        {
            return objADExperienciaCliente.ListaPerfilesExpCliente();
        }

        public DataTable ActualizaPerfilExpCliente(int idPerfil, int estado)
        {
            return objADExperienciaCliente.ActualizaPerfilExpCliente(idPerfil, estado);
        }

        public DataTable RegistraPerfilesExpCliente(int idPerfil, int nVeces)
        {
            return objADExperienciaCliente.RegistraPerfilesExpCliente(idPerfil, nVeces);
        }

        public DataTable CancelaParametrosExpCliente(int idOficina, DateTime dFecha)
        {
            return objADExperienciaCliente.CancelaParametrosExpCliente(idOficina, dFecha);
        }

        public DataSet ListaParametrosEncuesta()
        {
            return objADExperienciaCliente.ListaParametrosEncuesta();
        }

        public DataTable ListaModulosAlertaCumple()
        {
            return objADExperienciaCliente.ListaModulosAlertaCumple();
        }

    }
}
