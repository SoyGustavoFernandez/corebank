using System;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;
using System.Collections.Generic;
using GEN.Funciones;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNInformeRiesgos
    {
        clsADInformeRiesgos InformeRiesgos = new clsADInformeRiesgos();

        //Inserta las solicitudes de informe de riesgo
        public DataTable InsertSolicitudInformeRiesgos(string XmlSoli, int idSolCre)
        {
            return InformeRiesgos.InsertSolicitudInformeRiesgos(XmlSoli, idSolCre);
        }

        //Lista las solicitudes de informes de riesgo
        public DataTable ListarSolicitudesInformeRiesgo(int idUsuarioSis)
        {
            return InformeRiesgos.ListarSolicitudesInformeRiesgo(idUsuarioSis);
        }

        //Inserta un nuevo informe de riesgo
        public DataTable InsertInformeRiesgo(int idSolCre, int idSolInfRiesgo, string cOpinion, DateTime dFecSystem, int idCli, int nIdInformeRiesgos, object DocRiesgo, string cNombreArchivo, bool lFavorable)
        {
            return InformeRiesgos.InsertInformeRiesgo(idSolCre, idSolInfRiesgo, cOpinion, dFecSystem, idCli, nIdInformeRiesgos, DocRiesgo, cNombreArchivo, lFavorable);
        }

        //Consultar un Informe de Riesgo
        public DataTable BuscarInformeRiesgo(int nIdInformeRiesgos, DateTime? dFecInicio, DateTime? dFecFinal, int? idCli, string cNombres, int nOpcion)
        {
            return InformeRiesgos.BuscarInformeRiesgo(nIdInformeRiesgos, dFecInicio, dFecFinal, idCli, cNombres, nOpcion);
        }
        //Consultar un documentos del Informe de Riesgo
        public DataTable BuscarDocInformeRiesgo(int nIdInformeRiesgos)
        {
            return InformeRiesgos.BuscarDocInformeRiesgo(nIdInformeRiesgos);
        }
        //Actualiza un informe de riesgo
        public DataTable ActualizaInformeRiesgo(int nIdInformeRiesgos, string cOpinion, int idDocInfRiesgo, DateTime dFecSystem, int idCli, bool lvigente, bool lLeido, bool lFavorable)
        {
            return InformeRiesgos.ActualizaInformeRiesgo(nIdInformeRiesgos, cOpinion, idDocInfRiesgo, dFecSystem, idCli, lvigente, lLeido, lFavorable);
        }

        public DataTable ObtenerInformeRiesgo(int nIdSolCre)
        {
            return InformeRiesgos.ObtenerInformeRiesgo(nIdSolCre);
        }

        public DataTable ListSolInformeRiesgoPendientes(int nIdSolCre)
        {
            return InformeRiesgos.ListSolInformeRiesgoPendientes(nIdSolCre);
        }
        public DataTable autoAsignarseSolicitudInformeRsg(int idSolInfRiesgo, int idUsuarioSis)
        {
            return InformeRiesgos.autoAsignarseSolicitudInformeRsg(idSolInfRiesgo, idUsuarioSis);
        }
        public List<clsDetalleInformeRiesgo> listarDetalleInformeRiesgo(int idSolInfRiesgo)
        {
            return InformeRiesgos.listarDetalleInformeRiesgo(idSolInfRiesgo);
        }
        public List<clsComposicionCredito> destinoCreditoEvalGuardado(int idDetalleInformeRsg)
        {
            return InformeRiesgos.destinoCreditoEvalGuardado(idDetalleInformeRsg);
        }
        public List<clsNivelTipoRiesgo> tipoNivelRiesgoGuardado(int idDetalleInformeRsg)
        {
            return InformeRiesgos.tipoNivelRiesgoGuardado(idDetalleInformeRsg);
        }
        public List<clsComposicionCredito> listarComposicionCredito(int idEvalCred)
        {
            return InformeRiesgos.listarComposicionCredito(idEvalCred);
        }
		public List<clsIndicadoresFinancieros> listarIndicadoresFinancieros(int idEvalCred)
		{
			return InformeRiesgos.listarIndicadoresFinancieros(idEvalCred);
		}
        public List<clsTipoRiesgo> listarTipoRiesgo()
        {
            return InformeRiesgos.listarTipoRiesgo();
        }
        public List<clsNivelRiesgo> listarNivelRiesgo()
        {
            return InformeRiesgos.listarNivelRiesgo();
        }
        public DataTable regDetalleInformeRsg
                                            (int idSolInfRiesgo                 , int idCli                        , int idOperacion				,
                                            int idTipoCliente                  , decimal nMonto                   , int idMoneda                     , int idActEconomica,
											int idModalidad						,
                                            int idSubProducto                  , int idOficina                    , int idUsuarioAsesor              , decimal nMoraOrigen,
                                            decimal nMoraRsgPotencial          , string cDestinoCredito            , decimal nPromDiasAtraso          , decimal nSaldoVigCraclasa,
                                            decimal nFinanCraclasaImporte      , decimal nAportePropImporte       ,string cComentario1               , decimal nDeudaActualSF,
                                            decimal nTechoMaxEndeud            , int nEntidadesAFecha             , decimal nEscalonamientoDeuda     , 
                                            decimal nDeudaActualYPropuesto     , int nTiempoActividad             , int nTiempoResidencia            , int idTipoVivienda,
                                            string cComentario2                  , decimal nRatioLiquidez         ,  string cComentario3                 , string cGarantia                  , string cComentario4               , int idUsuarioAnalistaRsg,
											bool lVisitaNegocio, bool lOpinion1, DateTime dFechaSolicitud, DateTime? dFechaIngresoGerRisg, DateTime dFechaRecepcionSustento,
                                            DateTime dEnvioObs					,DateTime dLevantamientoObs            , DateTime? dFechaSalida            , string cSustento1                 , bool? lOpinion2,
                                            string cSustento2                   ,DateTime? dFechaSalida2			,int? idUsuarioReconsidera		, string cXml                      ,string cXmlCompFinan               , int idSolicitud,
                                            int idUsuarioSis, bool lVigente, int nEstado ,bool lAutorizadoReconcidera, int? idPerfilRecon, int idPerfilAnalista)
        {
            return InformeRiesgos.regDetalleInformeRsg(
                                            idSolInfRiesgo                  ,     idCli                    ,     idOperacion,
                                            idTipoCliente                   ,     nMonto                   ,     idMoneda                  ,     idActEconomica,
											idModalidad						,
                                            idSubProducto                   ,     idOficina                ,     idUsuarioAsesor           ,     nMoraOrigen,
                                            nMoraRsgPotencial               ,     cDestinoCredito          ,     nPromDiasAtraso           ,     nSaldoVigCraclasa,
                                            nFinanCraclasaImporte           ,     nAportePropImporte       ,     cComentario1              ,     nDeudaActualSF,
                                            nTechoMaxEndeud                 ,     nEntidadesAFecha         ,     nEscalonamientoDeuda      ,     
                                            nDeudaActualYPropuesto          ,     nTiempoActividad         ,     nTiempoResidencia         ,     idTipoVivienda,
                                            cComentario2                    ,     nRatioLiquidez            ,   cComentario3                    ,     cGarantia                ,     cComentario4              ,     idUsuarioAnalistaRsg,
											lVisitaNegocio, lOpinion1, dFechaSolicitud, dFechaIngresoGerRisg, dFechaRecepcionSustento,
                                            dEnvioObs						,	dLevantamientoObs          ,     dFechaSalida             ,     cSustento1                 ,     lOpinion2,
                                            cSustento2                      ,    dFechaSalida2				, idUsuarioReconsidera		,	 cXml                     ,     cXmlCompFinan              ,     idSolicitud,
                                            idUsuarioSis, lVigente, nEstado, lAutorizadoReconcidera, idPerfilRecon, idPerfilAnalista);

        }
        public List<clsNivelTipoRiesgo> listarNivelTipoRiesgo()
        {
            return InformeRiesgos.listarNivelTipoRiesgo();
        }
        public int RetornarSolInforme(int idInfRiesgo)
        {
            return InformeRiesgos.RetornarSolInforme(idInfRiesgo);
        }
        public int modalidadOpinionRiesgo(int idSolInfRiesgo)
        {
            return InformeRiesgos.modalidadOpinionRiesgo(idSolInfRiesgo);
        }

        public List<clsDetalleOpinionRiesgo> CNRecuperarDetalleOpinionRiesgoSeguimiento(int idSolicitud)
        {
            DataTable dtResultado = InformeRiesgos.ADRecuperarDetalleOpinionRiesgoSeguimiento(idSolicitud);
            List<clsDetalleOpinionRiesgo> lstDetalleOpinion = DataTableToList.ConvertTo<clsDetalleOpinionRiesgo>(dtResultado) as List<clsDetalleOpinionRiesgo>;

            return (dtResultado.Rows.Count > 0) ? lstDetalleOpinion : new List<clsDetalleOpinionRiesgo>();
        }

        public List<clsExcepcionReglaNeg> CNListarExcepcionReglaNeg(int idSolicitud, string cNombreForm)
        {
            DataTable dtExcepReglaNeg = this.InformeRiesgos.ADListarExcepcionReglaNeg(idSolicitud, cNombreForm, 0, 0);

            return (dtExcepReglaNeg.Rows.Count > 0) ?
                DataTableToList.ConvertTo<clsExcepcionReglaNeg>(dtExcepReglaNeg) as List<clsExcepcionReglaNeg> :
                new List<clsExcepcionReglaNeg>();
        }

        public List<clsSolicitudAsignada> CNRecuperaSolAsignadaSeguimiento(int idUsuario, char cTipoBusqueda, string cListaEstado)
        {
            
            DataTable dtSolAsignadoSeg = this.InformeRiesgos.ADRecuperaSolAsignadaSeguimiento(idUsuario, cTipoBusqueda, cListaEstado);

            return (dtSolAsignadoSeg.Rows.Count > 0) ? DataTableToList.ConvertTo<clsSolicitudAsignada>(dtSolAsignadoSeg) as List<clsSolicitudAsignada> : new List<clsSolicitudAsignada>();
        }

        public clsComiteAmpRiesgo CNRecuperarComiteAmpliadoRiesgo(int idSolicitud, int idSolInformeRiesgo)
        {
            DataSet dsResultado = this.InformeRiesgos.ADRecuperarComiteAmpliadoRiesgo(idSolicitud, idSolInformeRiesgo);
            clsComiteAmpRiesgo objComiteResultado = new clsComiteAmpRiesgo();
            List<clsUsuarioComiteAmpRsg> lstParticipante = new List<clsUsuarioComiteAmpRsg>();

            if(dsResultado.Tables.Count > 0)
            {
                objComiteResultado = (dsResultado.Tables[0].Rows.Count > 0) ? (DataTableToList.ConvertTo<clsComiteAmpRiesgo>(dsResultado.Tables[0]) as List<clsComiteAmpRiesgo>)[0] : new clsComiteAmpRiesgo() ;
                lstParticipante = (dsResultado.Tables[1].Rows.Count > 0) ? DataTableToList.ConvertTo<clsUsuarioComiteAmpRsg>(dsResultado.Tables[1]) as List<clsUsuarioComiteAmpRsg> : new List<clsUsuarioComiteAmpRsg>();
                objComiteResultado.lstParticipanteComite.AddRange(lstParticipante);
            }

            return objComiteResultado;
        }

        public DataTable CNGrabarActualizarComiteAmpliadoRiesgo(string xmlComiteAmpliado, int idSolicitud, int idSolInformeRiesgo, int idUsuario, DateTime dFechaSistema)
        {
            return this.InformeRiesgos.ADGrabarActualizarComiteAmpliadoRiesgo(xmlComiteAmpliado, idSolicitud, idSolInformeRiesgo, idUsuario, dFechaSistema);
        }

        public List<clsDetalleInformeRiesgo> CNListarDetalleInformeRiesgoEdit(int idSolInfRiesgo)
        {
            return InformeRiesgos.ADListarDetalleInformeRiesgoEdit(idSolInfRiesgo);
        }

        public DataTable CNObtenerSolicitudesParaOpinionRiesgo(int idCli, int idSolicitud, int idEstado)
        {
            return this.InformeRiesgos.ADObtenerSolicitudesParaOpinionRiesgo(idCli, idSolicitud, idEstado);
        }

        public DataTable CNObtenerTrakingOpinionRiesgo(int idSolicitud, int nTipo)
        {
            return this.InformeRiesgos.ADObtenerTrakingOpinionRiesgo(idSolicitud, nTipo);
        }

        public DataTable CNVerificarRegistroComiteAmpl(int idSolicitud, int idSolInformRiesgo)
        {
            return this.InformeRiesgos.ADVerificarRegistroComiteAmpl(idSolicitud, idSolInformRiesgo);
        }

        public DataTable CNObtenerDatosComiteAmplRiesgo(int idSolicitud, int idSolInformRiesgo)
        {
            return this.InformeRiesgos.ADObtenerDatosComiteAmplRiesgo(idSolicitud, idSolInformRiesgo);
        }
        public void CNRegistroFechaInicioReingreso(int idSolInformRiesgo, DateTime dFecha, bool lReconcidera)
        {
            this.InformeRiesgos.ADRegistroFechaInicioReingreso(idSolInformRiesgo, dFecha, lReconcidera);
        }
        

    }
}
