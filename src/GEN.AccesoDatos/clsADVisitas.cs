using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsADVisitas
    {
        private IntConexion objConexion;
        

        public clsADVisitas(bool lWS)
        {
            objConexion = new clsWCFEjeSP();            
        }

        public clsADVisitas()
        {
            objConexion = new clsGENEjeSP();
        }

        #region WebServiceConexion
        
        public DataTable ADWSListarTipoDocVisita() {
            return objConexion.EjecSP("WCF_DocumentosTipoVisita_SP");
        }

        public DataTable ADWSListarTipoVisita()
        {
            return objConexion.EjecSP("WCF_ListarTipoVisita_SP");
        }

        public DataTable ADWSListarEstadoVisita()
        {
            return objConexion.EjecSP("WCF_ListarEstadoVisita_SP");
        }

        public DataTable ADWSListarVisita(int idUsuario, int idCli,int idSolicitud, int idEstado=0)
        {
            return objConexion.EjecSP("WCF_ListarVisitaUsuarioCliente_SP", idUsuario, idCli,idSolicitud, idEstado);
        }

        public DataTable ADWSRegistroEdicionCliente(clsClienteWFC obj)
        {
            return objConexion.EjecSP("WCF_RegistroEdicionCliente_SP", obj.idUsuario
                , obj.idTipoDocumento                   , obj.cDocumentoID                                        
                , obj.idActivEcoInterna                 , obj.idActivEcoAdicional               , obj.nIdActivEco               
                , obj.IdTipoPersona
                , obj.cApellidoPaterno                  , obj.cApellidoMaterno                  , obj.cNombre                   
                , obj.cNombres                          , obj.cRazonSocial                      , obj.idDireccion
                , obj.oDireccion.idTipoDireccion        , obj.oDireccion.idUbigeo               , obj.oDireccion.cDireccion     
                , obj.idCodTelFijo                      , obj.nNumeroTelefono                   , obj.cNumeroTelefono2
                , obj.cCorreoCli                        , obj.oDireccion.nLat                   , obj.oDireccion.nLong          , obj.idSexo
                , obj.idAgencia                         , obj.idCargo                           , obj.idUbigeoNacimiento        , obj.nDigitoVerificador        , obj.dFechaNacimiento
                , obj.idEstadoCivil                     , obj.nNumPerDepend                     , obj.idCli_vinculado
                , clsUtils.ListToXml<clsWFCDireccionCliente>((List<clsWFCDireccionCliente>)obj.xmlDireccion));            
        }

        public DataTable ADWSRegistrarVisita(clsVisita obj)
        {
            List<clsRespuestaFicha> objRptaFicha = new List<clsRespuestaFicha>();            
            if(obj.listaRespuestaFicha != null)
                objRptaFicha = obj.listaRespuestaFicha;

            clsWCFResultadoRecuperacionVisita objxmlRec = new clsWCFResultadoRecuperacionVisita();
            if (obj.resultadoRecuperacionVisita != null)
                objxmlRec = obj.resultadoRecuperacionVisita;

            return objConexion.EjecSP("WCF_RegistroVisita_SP", 
                obj.idVisita,                   obj.idCliente,                  obj.idUsuario, 
                obj.idPerfil,                   obj.nLat,                       obj.nLong, 
                obj.idTipoVisita,               obj.idEstadoVisita,             obj.cEstadoVisita,              
                obj.cObservacion,               obj.idDireccion,                clsUtils.ListToXml<clsRespuestaFicha>(objRptaFicha),
                clsUtils.toXmlObject(objxmlRec), obj.idAgencia, obj.idCuenta);
        }

        public DataTable ADWSRegistrarDetalleVisita(clsDetalleVisita obj)
        {
            List<clsDetalleVisita> objDetVisita = new List<clsDetalleVisita>();
            List<clsArchivo> objArchivos = new List<clsArchivo>();
            
            objDetVisita.Add(obj);
            objArchivos.Add(obj.ToArchivo());

            return objConexion.EjecSP("CRE_RegistroDetalleVisita_SP", clsUtils.ListToXml<clsDetalleVisita>(objDetVisita), clsUtils.ListToXml<clsArchivo>(objArchivos));
        }

        #endregion

        #region Conexion Normal
        public DataTable ADListarArchivosVisita(int idVisita, int idSolicitud)
        {
            return objConexion.EjecSP("CRE_ListarArchivosVisita_SP", idVisita, idSolicitud);
        }

        public DataTable ADObtenerArchivoVisita(int idImage)
        {
            return objConexion.EjecSP("CRE_ObtenerArchivoVisita_SP", idImage);
        }

        public DataTable ADVincularVisitaSolicitud(int idSolicitud, string cVisitas)
        {
            return objConexion.EjecSP("WCF_VincularVisitaSolicitud_SP", idSolicitud, cVisitas);
        }

        public DataTable ADListarVisitaUsuarioGrupoSolidario(int idUsuario, int idGrupoSolidario, int idSolicitudGrupoSol, int idEstado = 0)
        {
            return objConexion.EjecSP("WCF_ListarVisitaUsuarioGrupoSolidario_SP", idUsuario, idGrupoSolidario, idSolicitudGrupoSol, idEstado);
        }

        public DataTable ADVincularVisitaSolicitudGrupoSolidario(int idSolicitudGrupoSol, string cVisitas)
        {
            return objConexion.EjecSP("WCF_VincularVisitaSolicitudGrupoSolidario_SP", idSolicitudGrupoSol, cVisitas);
        }

        public DataTable ADListarVisitasVinculadasIndividual(int idSolicitud)
        {
            return objConexion.EjecSP("WCF_ListarVisitasVinculadasIndividual_SP", idSolicitud);
        }

        public DataTable ADListarVisitasVinculadasGrupoSol(int idSolicitudGrupoSol)
        {
            return objConexion.EjecSP("WCF_ListarVisitasVinculadasGrupoSol_SP", idSolicitudGrupoSol);
        }

        public DataTable RegistroEncuestaRespuesta(string cDni, string cNombreApellido, int nEdad, string cSexo, string cEstadoCivil, string cNumeroCelular, string cRespuesta, string cUsuario, string cCodEncuesta, int idFeria, string dFechaRegistro)
        {
            return objConexion.EjecSP("WCF_RegistroEncuestaRespuesta_SP", cDni, cNombreApellido, nEdad, cSexo, cEstadoCivil, cNumeroCelular, cRespuesta, cUsuario, cCodEncuesta, idFeria, dFechaRegistro);
        }

        public DataTable ReporteEncuestaRespuesta(int page, int pageSize, string fechaInicio, string fechaFinal, int idFeria)
        {
            return objConexion.EjecSP("WCF_ReporteRegistroEncuesta_SP", page, pageSize, fechaInicio, fechaFinal, idFeria);
        }

        public DataTable ListaEncuestaFeria(int page, int pageSize)
        {
            return objConexion.EjecSP("WCF_ReporteRegistroEncuestaFeria_SP", page, pageSize);
        }

        public DataTable ListaEncuestaEstablecimiento()
        {
            return objConexion.EjecSP("WCF_ListaEstablecimientosEncuesta_SP");
        }

        public DataTable RegistroEdicionEncuestaFeria(int idRegistroFeria, int idEstablecimiento, string cNombre, string cLugar, string cDias, string cHorarioInicio, string cHorarioFinal, bool lVigente)
        {
            return objConexion.EjecSP("WCF_RegistroEncuestaFeria_SP", idRegistroFeria, idEstablecimiento, cNombre, cLugar, cDias, cHorarioInicio, cHorarioFinal, lVigente);
        }

        public DataTable ListarCampaniasCliente(string cDni)
        {
            return objConexion.EjecSP("WCF_ListarCampanaXCliente_SP", 1, cDni, 0);
        }
        #endregion

        
    }
}
