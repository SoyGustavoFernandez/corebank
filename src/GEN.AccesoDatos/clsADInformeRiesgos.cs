using System;
using System.Collections.Generic;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Linq;
using GEN.Funciones;
using EntityLayer;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsADInformeRiesgos
    {
        IntConexion objEjeSp;
       
        public clsADInformeRiesgos(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADInformeRiesgos()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable InsertSolicitudInformeRiesgos(string XmlSoli, int idSolCre)
        {
            return objEjeSp.EjecSP("GEN_InsSolInformeRiesgos_SP", XmlSoli, idSolCre);
        }

        public DataTable ListarSolicitudesInformeRiesgo(int idUsuarioSis)
        {
            return objEjeSp.EjecSP("GEN_ListaSolInformeRiesgos_SP", idUsuarioSis);
        }

        public DataTable InsertInformeRiesgo(int idSolCre, int idSolInfRiesgo, string cOpinion, DateTime dFecSystem, int idCli, int nIdInformeRiesgos, object DocRiesgo, string cNombreArchivo, bool lFavorable)
        {
            return objEjeSp.EjecSP("GEN_InsInformeRiesgos_SP", idSolCre, idSolInfRiesgo, cOpinion, dFecSystem, idCli, nIdInformeRiesgos, DocRiesgo, cNombreArchivo, lFavorable);
        }

        public DataTable BuscarInformeRiesgo(int nIdInformeRiesgos, DateTime? dFecInicio, DateTime? dFecFinal, int? idCli, string cNombres, int nOpcion)
        {
            return objEjeSp.EjecSP("GEN_BuscarInformeRiesgos_SP", nIdInformeRiesgos, dFecInicio, dFecFinal, idCli, cNombres, nOpcion);
        }
        public DataTable BuscarDocInformeRiesgo(int nIdInformeRiesgos)
        {
            return objEjeSp.EjecSP("SP_DocumentoAdjuntos_SP", nIdInformeRiesgos);
        }
        public DataTable ActualizaInformeRiesgo(int nIdInformeRiesgos, string cOpinion, int idDocInfRiesgo,
                                            DateTime dFecSystem, int idCli, Boolean lvigente, bool lLeido, bool lFavorable)
        {
            return objEjeSp.EjecSP("GEN_UpdInformeRiesgos_SP", nIdInformeRiesgos, cOpinion, idDocInfRiesgo,
                                    dFecSystem, idCli, lvigente, lLeido, lFavorable);
        }

        public DataTable ObtenerInformeRiesgo(int nIdSolCre)
        {
            return objEjeSp.EjecSP("GEN_ObtenerInfRiesgosxSolCre_SP", nIdSolCre);
        }

        public DataTable ListSolInformeRiesgoPendientes(int nIdSolCre)
        {
            return objEjeSp.EjecSP("GEN_ListSolInfRiesgoPendiente_SP", nIdSolCre);
        }
        public DataTable autoAsignarseSolicitudInformeRsg(int idSolInfRiesgo, int idUsuarioSis)
        {
            return objEjeSp.EjecSP("RSG_AsignarseSolInformeRsg_sp", idSolInfRiesgo, idUsuarioSis);
        }
        public List<clsDetalleInformeRiesgo> listarDetalleInformeRiesgo(int idSolInfRiesgo)
        {
            List<clsDetalleInformeRiesgo> objDetalleInformeRiesgo;
            DataTable dt = objEjeSp.EjecSP("RSG_ListarDetalleInformeRiesgo_sp", idSolInfRiesgo, clsVarGlobal.User.idUsuario);
            objDetalleInformeRiesgo = DataTableToList.ConvertTo<clsDetalleInformeRiesgo>(dt) as List<clsDetalleInformeRiesgo>;
            return objDetalleInformeRiesgo;
        }
        public List<clsComposicionCredito> destinoCreditoEvalGuardado(int idDetalleInformeRsg)
        {
            List<clsComposicionCredito> objComposicionClienteGuardado;
            DataTable dt = objEjeSp.EjecSP("RSG_DestinoCreditoEvalGuardado_SP", idDetalleInformeRsg);
            objComposicionClienteGuardado = DataTableToList.ConvertTo<clsComposicionCredito>(dt) as List<clsComposicionCredito>;
            return objComposicionClienteGuardado;
        }
        public List<clsNivelTipoRiesgo> tipoNivelRiesgoGuardado(int idDetalleInformeRsg)
        {
            List<clsNivelTipoRiesgo> objNivelRiesgoGuardado;
            DataTable dt = objEjeSp.EjecSP("RSG_TipoNivelRiesgoGuardado_sp", idDetalleInformeRsg);
            objNivelRiesgoGuardado = DataTableToList.ConvertTo<clsNivelTipoRiesgo>(dt) as List<clsNivelTipoRiesgo>;
            return objNivelRiesgoGuardado;
        }
        public List<clsComposicionCredito> listarComposicionCredito(int idEvalCred)
        {
            List<clsComposicionCredito> objComposicionCliente;
            DataTable dt = objEjeSp.EjecSP("CRE_DestinoCreditoEval_SP",idEvalCred);
            objComposicionCliente = DataTableToList.ConvertTo<clsComposicionCredito>(dt) as List<clsComposicionCredito>;
            return objComposicionCliente;
        }
		public List<clsIndicadoresFinancieros> listarIndicadoresFinancieros(int idEvalCred)
		{
			List<clsIndicadoresFinancieros> objIndicadoresFinancieros;
			DataTable dt = objEjeSp.EjecSP("CRE_IndicadoresFinEval_SP", idEvalCred);
			objIndicadoresFinancieros = DataTableToList.ConvertTo<clsIndicadoresFinancieros>(dt) as List<clsIndicadoresFinancieros>;
			return objIndicadoresFinancieros;
		}
        public List<clsTipoRiesgo> listarTipoRiesgo()
        {
            List<clsTipoRiesgo> objTipoRiesgo;
            DataTable dt = objEjeSp.EjecSP("RSG_ListarTipoRiesgo_sp");
            objTipoRiesgo = DataTableToList.ConvertTo<clsTipoRiesgo>(dt) as List<clsTipoRiesgo>;
            return objTipoRiesgo;
        }
        public List<clsNivelRiesgo> listarNivelRiesgo()
        {
            List<clsNivelRiesgo> objNivelRiesgo;
            DataTable dt = objEjeSp.EjecSP("RSG_ListarNivelRiesgo_sp");
            objNivelRiesgo = DataTableToList.ConvertTo<clsNivelRiesgo>(dt) as List<clsNivelRiesgo>;
            return objNivelRiesgo;
        }
        public DataTable regDetalleInformeRsg
                                            (int idSolInfRiesgo                 , int idCli                        , int idOperacion,
                                            int idTipoCliente                  , decimal nMonto                   , int idMoneda                     , int idActEconomica,
											int idModalidad						,
                                            int idSubProducto                  , int idOficina                    , int idUsuarioAsesor              , decimal nMoraOrigen,
                                            decimal nMoraRsgPotencial          , string cDestinoCredito            , decimal nPromDiasAtraso          , decimal nSaldoVigCraclasa,
                                            decimal nFinanCraclasaImporte      , decimal nAportePropImporte       , string cComentario1               , decimal nDeudaActualSF,
                                            decimal nTechoMaxEndeud            , int nEntidadesAFecha             , decimal nEscalonamientoDeuda     , 
                                            decimal nDeudaActualYPropuesto     , int nTiempoActividad             , int nTiempoResidencia            , int idTipoVivienda,
                                            string cComentario2                 ,decimal nRatioLiquidez         ,     string cComentario3                 , string cGarantia                  , string cComentario4               , int idUsuarioAnalistaRsg,
											bool lVisitaNegocio, bool lOpinion1, DateTime dFechaSolicitud, DateTime? dFechaIngresoGerRisg, DateTime dFechaRecepcionSustento,
                                            DateTime? dEnvioObs					,DateTime? dLevantamientoObs            , DateTime? dFechaSalida            , string cSustento1                 , bool? lOpinion2,
                                            string cSustento2                  , DateTime? dFechaSalida2			,int? idUsuarioReconsidera			, string cXml                      ,string cXmlCompFinan                ,int idSolicitud,
                                            int idUsuarioSis, bool lVigente, int nEstado , bool lAutorizadoReconcidera, int? idPerfilRecon, int idPerfilAnalista)
        {

            return objEjeSp.EjecSP("RSG_RegDetalleInformeRsg_sp",
                                            idSolInfRiesgo                  ,     idCli                    ,     idOperacion,
                                            idTipoCliente                   ,     nMonto                   ,     idMoneda                  ,     idActEconomica,
											idModalidad						,
                                            idSubProducto                   ,     idOficina                ,     idUsuarioAsesor           ,     nMoraOrigen,
                                            nMoraRsgPotencial               ,     cDestinoCredito          ,     nPromDiasAtraso           ,     nSaldoVigCraclasa,
                                            nFinanCraclasaImporte           ,     nAportePropImporte      ,      cComentario1              ,     nDeudaActualSF,
                                            nTechoMaxEndeud                 ,     nEntidadesAFecha         ,     nEscalonamientoDeuda      ,     
                                            nDeudaActualYPropuesto          ,     nTiempoActividad         ,     nTiempoResidencia         ,     idTipoVivienda,
                                            cComentario2                    ,      nRatioLiquidez            ,  cComentario3                    ,     cGarantia                ,     cComentario4              ,     idUsuarioAnalistaRsg,
											lVisitaNegocio, lOpinion1, dFechaSolicitud, dFechaIngresoGerRisg == null ? DBNull.Value : (object)dFechaIngresoGerRisg,dFechaRecepcionSustento,
											dEnvioObs , dLevantamientoObs, dFechaSalida == null ? DBNull.Value : (object)dFechaSalida, cSustento1, lOpinion2 == null ? DBNull.Value : (object)lOpinion2,
											cSustento2, dFechaSalida2 == null ? DBNull.Value : (object)dFechaSalida2, idUsuarioReconsidera == null ? DBNull.Value : (object)idUsuarioReconsidera, cXml, cXmlCompFinan, idSolicitud,
                                            idUsuarioSis, lVigente, nEstado, lAutorizadoReconcidera, idPerfilRecon, idPerfilAnalista);
        }
        public List<clsNivelTipoRiesgo> listarNivelTipoRiesgo()
        {
            List<clsNivelTipoRiesgo> objNivelTipoRiesgo;
            DataTable dt = objEjeSp.EjecSP("RSG_ListarAdministracionRiesgo_sp");
            objNivelTipoRiesgo = DataTableToList.ConvertTo<clsNivelTipoRiesgo>(dt) as List<clsNivelTipoRiesgo>;
            return objNivelTipoRiesgo;
        }
        public int RetornarSolInforme(int idInfRiesgo)
        {
            DataTable dt = objEjeSp.EjecSP("RSG_RetornarSolInforme_sp", idInfRiesgo);
            return Convert.ToInt32(dt.Rows[0]["idSolInfRiesgo"].ToString());
        }
        public int modalidadOpinionRiesgo(int idSolInfRiesgo)
        {
            DataTable dt = objEjeSp.EjecSP("RSG_ModalidadOpinionRiesgo_sp", idSolInfRiesgo);
            return Convert.ToInt32(dt.Rows[0]["idModalidad"]);
        }

        public DataTable ADRecuperarDetalleOpinionRiesgoSeguimiento(int idSolicitud)
        {
            DataTable dtResultado = objEjeSp.EjecSP("RSG_ObtenerDetalleOpinionRiesgo_SP", idSolicitud);
            return dtResultado;
        }

        public DataTable ADListarExcepcionReglaNeg(int idSolicitud, string cNombreForm, int idUsuarioAprobador, int idPerfilAprobador)
        {
            return objEjeSp.EjecSP("CRE_ListarExcepcionReglaNeg_SP", idSolicitud, cNombreForm, idUsuarioAprobador, idPerfilAprobador);
        }

        public DataTable ADRecuperaSolAsignadaSeguimiento(int idUsuario, char cTipoBusqueda, string cListaEstado)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolAsignadaSeguimiento_SP", idUsuario, cTipoBusqueda, cListaEstado);
        }

        public DataSet ADRecuperarComiteAmpliadoRiesgo(int idSolicitud, int idSolInformeRiesgo)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerComiteAmpliadoRiesgo_SP", idSolicitud, idSolInformeRiesgo);
        }

        public DataTable ADGrabarActualizarComiteAmpliadoRiesgo(string xmlComiteAmpliado, int idSolicitud, int idSolInformeRiesgo, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CRE_RegistraActualizaComiteAmpRiesgo_SP", xmlComiteAmpliado, idSolicitud, idSolInformeRiesgo, idUsuario, dFechaSistema);
        }

        public List<clsDetalleInformeRiesgo> ADListarDetalleInformeRiesgoEdit(int idSolInfRiesgo)
        {
            List<clsDetalleInformeRiesgo> objDetalleInformeRiesgo;
            DataTable dt = objEjeSp.EjecSP("RSG_ListarDetalleInformeRiesgoEdit_SP", idSolInfRiesgo, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            objDetalleInformeRiesgo = DataTableToList.ConvertTo<clsDetalleInformeRiesgo>(dt) as List<clsDetalleInformeRiesgo>;
            return objDetalleInformeRiesgo;
        }	

        public DataTable ADObtenerSolicitudesParaOpinionRiesgo(int idCli, int idSolicitud, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_ListSolicitudCredRiesgos_SP", idCli, idSolicitud, idEstado);
        }

        public DataTable ADObtenerTrakingOpinionRiesgo(int idSolicitud, int nTipo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDetalleTraking_SP", idSolicitud, nTipo);
        }

        public DataTable ADVerificarRegistroComiteAmpl(int idSolicitud, int idSolInformRiesgo)
        {
            return objEjeSp.EjecSP("CRE_VerificarRegistroComiteAmpl_SP", idSolicitud, idSolInformRiesgo );
        }

        public DataTable ADObtenerDatosComiteAmplRiesgo(int idSolicitud, int idSolInformRiesgo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosComiteAmplRiesgo_SP", idSolicitud, idSolInformRiesgo);
        }
        public void ADRegistroFechaInicioReingreso(int idSolInformRiesgo, DateTime dFecha, bool lReconcidera)
        {
            objEjeSp.EjecSP("RSG_RegistroFechaInicioReingreso_SP", idSolInformRiesgo, dFecha, lReconcidera);
        }

        

    }
}
