using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNVisitas
    {
        private clsADVisitas objVisitas;

        public clsCNVisitas(bool lWS)
        {
            objVisitas = new clsADVisitas(lWS);
        }

        public clsCNVisitas()
        {
            objVisitas = new clsADVisitas();
        }

        #region WebServiceConexion

        public DataTable CNWSListarTipoDocVisita()
        {
            return objVisitas.ADWSListarTipoDocVisita();
        }

        public DataTable CNWSListarTipoVisita()
        {
            return objVisitas.ADWSListarTipoVisita();
        }

        public DataTable CNWSListarEstadoVisita()
        {
            return objVisitas.ADWSListarEstadoVisita();
        }

        public DataTable CNWSListarVisita(int idUsuario, int idCli, int idSolicitud, int idEstado = 0)
        {
            return objVisitas.ADWSListarVisita(idUsuario, idCli,idSolicitud, idEstado);
        }

        public DataTable CNWSRegistroEdicionCliente(clsClienteWFC obj)
        {
            return objVisitas.ADWSRegistroEdicionCliente(obj);
        }

        public DataTable CNWSRegistroEdicionVisita(clsVisita obj)
        {
            return objVisitas.ADWSRegistrarVisita(obj);
        }

        public DataTable CNWSRegistrarDetalleVisita(clsDetalleVisita obj)
        {
            return objVisitas.ADWSRegistrarDetalleVisita(obj);
        }

        #endregion

        #region Conexion Normal

        public DataTable CNListarArchivosVisita(int idVisita, int idSolicitud)
        {
            return objVisitas.ADListarArchivosVisita(idVisita, idSolicitud);
        }

        public DataTable CNObtenerArchivoVisita(int idImage)
        {
            return objVisitas.ADObtenerArchivoVisita(idImage);
        }

        public DataTable CNVincularVisitaSolicitud(int idSolicitud, string cVisitas)
        {
            return objVisitas.ADVincularVisitaSolicitud(idSolicitud, cVisitas);
        }

        public DataTable RegistroEncuestaRespuesta(string cDni, string cNombreApellido, int nEdad, string cSexo, string cEstadoCivil, string cNumeroCelular, string cRespuesta, string cUsuario, string cCodEncuesta, int idFeria, string dFechaRegistro)
        {
            return objVisitas.RegistroEncuestaRespuesta(cDni, cNombreApellido, nEdad, cSexo, cEstadoCivil, cNumeroCelular, cRespuesta, cUsuario, cCodEncuesta, idFeria, dFechaRegistro);
        }

        public DataTable ReporteEncuestaRespuesta(int page, int pageSize, string fechaInicio, string fechaFinal, int idFeria)
        {
            return objVisitas.ReporteEncuestaRespuesta(page, pageSize, fechaInicio, fechaFinal, idFeria);
        }

        public DataTable ListaEncuestaFeria(int page, int pageSize)
        {
            return objVisitas.ListaEncuestaFeria(page, pageSize);
        }

        public DataTable ListaEncuestaEstablecimiento()
        {
            return objVisitas.ListaEncuestaEstablecimiento();
        }

        public DataTable RegistroEdicionEncuestaFeria(int idRegistroFeria, int idEstablecimiento, string cNombre, string cLugar, string cDias, string cHorarioInicio, string cHorarioFinal, bool lVigente)
        {
            return objVisitas.RegistroEdicionEncuestaFeria(idRegistroFeria, idEstablecimiento, cNombre, cLugar, cDias, cHorarioInicio, cHorarioFinal, lVigente);
        }

        public DataTable CNListarVisitaUsuarioGrupoSolidario(int idUsuario, int idGrupoSolidario, int idSolicitudGrupoSol, int idEstado = 0)
        {
            return objVisitas.ADListarVisitaUsuarioGrupoSolidario(idUsuario, idGrupoSolidario, idSolicitudGrupoSol, idEstado);
        }

        public DataTable CNVincularVisitaSolicitudGrupoSolidario(int idSolicitudGrupoSol, string cVisitas)
        {
            return objVisitas.ADVincularVisitaSolicitudGrupoSolidario(idSolicitudGrupoSol, cVisitas);
        }

        public DataTable CNListarVisitasVinculadasIndividual(int idSolicitud)
        {
            return objVisitas.ADListarVisitasVinculadasIndividual(idSolicitud);
        }

        public DataTable CNListarVisitasVinculadasGrupoSol(int idSolicitudGrupoSol)
        {
            return objVisitas.ADListarVisitasVinculadasGrupoSol(idSolicitudGrupoSol);
        }

        public DataTable ListarCampaniasCliente(string cDni)
        {
            return objVisitas.ListarCampaniasCliente(cDni);
        }
        #endregion
    }
}
