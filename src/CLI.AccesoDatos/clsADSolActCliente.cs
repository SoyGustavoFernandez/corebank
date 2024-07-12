using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.AccesoDatos
{
    public class clsADSolActCliente
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoActualizacion()
        {
            return objEjeSp.EjecSP("CLI_ListarTipoActCliente_sp");
        }

        public DataTable ADRegistroSolActCliente(int idSolicitud, int idCli, int idUsuario, int idAgencia, string cTipoActualizacion, int idPerfil, string cSustentoSol, int idEstado, int lVigente,
            int idTipoDocumento, string cDocumentoID, string cDigitoVerificador, string cApellidoPaterno, string cApellidoMaterno, string cNombre, string cNombreSeg, string cNombreOtros, string cApellidoCasado,
            int idUbigeoNacimiento, DateTime dFechaNacimiento, int idSexo, int idEstadoCivil, int idEstadoCli, DateTime dFechaFallecimiento, string xmlVinc, int idTipoArchivo, string cArchivo, byte[] bArchivo, DateTime dFecha)
        {
            return objEjeSp.EjecSP("CLI_RegistroSolActCliente_SP", idSolicitud, idCli, idUsuario, idAgencia, cTipoActualizacion, idPerfil, cSustentoSol, idEstado, lVigente,
                idTipoDocumento, cDocumentoID, cDigitoVerificador, cApellidoPaterno, cApellidoMaterno, cNombre, cNombreSeg, cNombreOtros, cApellidoCasado,
                idUbigeoNacimiento, dFechaNacimiento, idSexo, idEstadoCivil, idEstadoCli, dFechaFallecimiento, xmlVinc, idTipoArchivo, cArchivo, bArchivo, dFecha);
        }

        public DataTable ADBuscarSolicitudes(int idZona, int idAgencia, int idUsuarioSol, int idUsuarioApro, int idEstado, DateTime dFecha)
        {
            return objEjeSp.EjecSP("CLI_ListarSolActCliente_SP", idZona, idAgencia, idUsuarioSol, idUsuarioApro, idEstado, dFecha);
        }

        public DataSet ADCargarSolicitud(int idSolicitud, string cTipoActCliente, int idEstado)
        {
            return objEjeSp.DSEjecSP("CLI_CargarSolActCliente_SP", idSolicitud, cTipoActCliente, idEstado);
        }

        public DataTable ADResolucionSolicitud(int idSolicitud, int idEstado, int idUsuario, int idPerfil, int idTipoActualizacion, string cSustentoApro)
        {
            return objEjeSp.EjecSP("CLI_ResolucionSolActCliente_SP", idSolicitud, idEstado, idUsuario, idPerfil, idTipoActualizacion, cSustentoApro);
        }

        public DataTable ADRptSolActCliente(int idZona, int idAgencia, DateTime dFehcaInicio, DateTime dFechaFinal, int idEstado)
        {
            return objEjeSp.EjecSP("CLI_ReporteSolActCliente_SP", idZona, idAgencia, dFehcaInicio, dFechaFinal, idEstado);
        }
    }
}
