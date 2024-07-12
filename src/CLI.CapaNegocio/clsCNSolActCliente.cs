using CLI.AccesoDatos;
using EntityLayer;
using System.Data;
using GEN.Funciones;
using System;

namespace CLI.CapaNegocio
{
    public class clsCNSolActCliente
    {
        private clsADSolActCliente objADSolActCliente = new clsADSolActCliente();
        public DataTable CNListarTipoActualizacion()
        {
            return objADSolActCliente.ADListarTipoActualizacion();
        }

        public clsRespuestaServidor CNRegistroSolActCliente(int idSolicitud, int idCli, int idUsuario, int idAgencia, string cTipoActualizacion, int idPerfil, string cSustentoSol, int idEstado, int lVigente,
            int idTipoDocumento, string cDocumentoID, string cDigitoVerificador, string cApellidoPaterno, string cApellidoMaterno, string cNombre, string cNombreSeg, string cNombreOtros, string cApellidoCasado,
            int idUbigeoNacimiento, DateTime dFechaNacimiento, int idSexo, int idEstadoCivil, int idEstadoCli, DateTime dFechaFallecimiento, string xmlVinc, int idTipoArchivo, string cArchivo, byte[] bArchivo)
        {
            DataTable dtRespuesta = objADSolActCliente.ADRegistroSolActCliente(idSolicitud, idCli, idUsuario, idAgencia, cTipoActualizacion, idPerfil, cSustentoSol, idEstado, lVigente,
            idTipoDocumento, cDocumentoID, cDigitoVerificador, cApellidoPaterno, cApellidoMaterno, cNombre, cNombreSeg, cNombreOtros, cApellidoCasado,
            idUbigeoNacimiento, dFechaNacimiento, idSexo, idEstadoCivil, idEstadoCli, dFechaFallecimiento, xmlVinc, idTipoArchivo, cArchivo, bArchivo, clsVarGlobal.dFecSystem);

            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public DataTable CNBuscarSolicitudes(int idZona, int idAgencia, int idUsuarioSol, int idUsuarioApro, int idEstado)
        {
            return this.objADSolActCliente.ADBuscarSolicitudes(idZona, idAgencia, idUsuarioSol, idUsuarioApro, idEstado, clsVarGlobal.dFecSystem);
        }

        public DataSet CNCargarSolicitud(int idSolicitud, string cTipoActCliente, int idEstado)
        {
            return this.objADSolActCliente.ADCargarSolicitud(idSolicitud, cTipoActCliente, idEstado);
        }

        public clsRespuestaServidor CNResolucionSolicitud(int idSolicitud, int idEstado, int idUsuario, int idPerfil, int idTipoActualizacion, string cSustentoApro)
        {
            DataTable dtRespuesta = this.objADSolActCliente.ADResolucionSolicitud(idSolicitud, idEstado, idUsuario, idPerfil, idTipoActualizacion, cSustentoApro);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public DataTable CNRptSolActCliente(int idZona, int idAgencia, DateTime dFehcaInicio, DateTime dFechaFinal, int idEstado)
        {
            return this.objADSolActCliente.ADRptSolActCliente(idZona, idAgencia, dFehcaInicio, dFechaFinal, idEstado);
        }
    }
}
