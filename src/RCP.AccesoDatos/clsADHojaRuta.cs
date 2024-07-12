using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;

namespace RCP.AccesoDatos
{
    public class clsADHojaRuta
    {
        //clsGENEjeSP objEjeSp = new clsGENEjeSP();
        IntConexion objEjeSp;
       
        public clsADHojaRuta(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADHojaRuta()
        {
            objEjeSp = new clsGENEjeSP();
        }
        
       

        public DataTable listaCarteraRecuperaciones(int idUsuario, int idUbigeo, int nAtrazoMin, int nAtrazoMax, Decimal nSaldoCapitalMin, Decimal nSaldoCapitalMax, bool lSoloDirPrincipal, int nTipoInterviniente, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosCartera_SP", idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, lSoloDirPrincipal, nTipoInterviniente, idPerfil);
        }
        public DataTable listaCarteraRecuPasoJudicial(int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ListCredCartera_SP", idUsuario, idPerfil);
        }
        public DataTable listaAgencias(int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_ListAgenciasUsu_Sp", idUsuario);
        }
        public DataTable listaAgenciasZona(int idZona)
        {
            return objEjeSp.EjecSP("ADM_ListarOficinaByZona_SP", idZona);
        }
        public DataTable listaPersonalAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("WCF_ListarUsuarioAgencia_SP", idAgencia);
        }
        public DataTable getZonaUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_ObtieneUsuarioZonas_sp", idUsuario);
        }
        public DataTable listaZonas()
        {
            return objEjeSp.EjecSP("ADM_ListarZonaVigentes_SP");
        }
        public DataTable listaPerfiles(int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_LisPerUsu_sp", idUsuario, DateTime.Now, 0);
        }
        public DataTable registrarHojaRuta(int idUsuario, DateTime dFechaInicio, DateTime dFechaFin, int nKilometrajeInicio, string xmlHojaRuta, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("RCP_InsertarHojaDeRuta_SP", idUsuario, dFechaInicio, dFechaFin, nKilometrajeInicio, xmlHojaRuta, dFechaSistema);
        }

        public DataTable validarHojaDeRutaAnteriores(int idUsuario, DateTime dFechaSistema, DateTime dFechaInicio, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RCP_ValidarHojasDeRuta_SP", idUsuario, dFechaSistema, dFechaInicio, dFecFin);
        }

        public DataTable obtenerHojaRuta(int idHojaRuta)
        {
            return objEjeSp.EjecSP("RCP_ObtenerHojaDeRuta_SP", idHojaRuta);
        }

        public DataTable obtenerCreditosHojaRuta(int idHojaRuta)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosHojaRuta_SP", idHojaRuta);
        }

        public DataTable obtenerAcciones(int idDetalleHojaRutaSeleccionado)
        {
            return objEjeSp.EjecSP("RCP_ListarAccionesGestionHojaRuta_SP", idDetalleHojaRutaSeleccionado);
        }

        public DataTable RegistrarAcciones(int idDetalleHojaRutaSeleccionado, string xmlHojaRuta)
        {
            return objEjeSp.EjecSP("RCP_InsAccionesGestionHojaDeRuta_SP", idDetalleHojaRutaSeleccionado, xmlHojaRuta);
        }

        public DataTable agregarCreditoHojaRuta(int idHojaRuta, int idCuenta, int idInter, int idDirecion, int idTipoAccion, int idTipoNotificacion, DateTime dFechaSistema, bool lDireccionRecupera)
        {
            return objEjeSp.EjecSP("RCP_InsertarCreditoHojaDeRuta_SP", idHojaRuta, idCuenta, idInter, idDirecion, idTipoAccion, idTipoNotificacion, dFechaSistema, lDireccionRecupera);
            //return new clsWCFEjeSP().EjecSP("RCP_InsertarCreditoHojaDeRuta_SP", idHojaRuta, idCuenta, idInter, idDirecion, idTipoAccion, idTipoNotificacion, dFechaSistema, lDireccionRecupera);
        }

        public DataTable listaCarteraPendiente(int idUsuario, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosPendientesVisita_SP", idUsuario, dFecFin);
        }

        public DataTable registrarGestionHojaRuta(int idDetalleHojaRuta, int idResultado, int idMotivoMora,
                                                int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa,
                                                Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita,
                                                string cObservacionVisita, DateTime dFechaRegisCliente, bool lDomVerificado, bool lNotificacionEntregada)
        {
            return objEjeSp.EjecSP("RCP_RegistraResultadosHojaRuta_SP", idDetalleHojaRuta, idResultado, idMotivoMora,
                                        idTipoCliente, lRecuperable, cObservacion, dFechaPromesa,
                                        nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                                        cObservacionVisita, DBNull.Value, DBNull.Value, dFechaRegisCliente,
                                        lDomVerificado, lNotificacionEntregada);
        }

        public DataTable registrarGestionHojaRuta(int idDetalleHojaRuta, int idResultado, int idMotivoMora,
                                                int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa,
                                                Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita,
                                                string cObservacionVisita, string cLatitud, string cLongitud, DateTime dFechaRegCliente,
                                                bool lDomVerificado, bool lNotificacionEntregada)
        {
            return objEjeSp.EjecSP("RCP_RegistraResultadosHojaRuta_SP", idDetalleHojaRuta, idResultado, idMotivoMora,
                                    idTipoCliente, lRecuperable, cObservacion, dFechaPromesa,
                                    nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                                    cObservacionVisita, cLatitud, cLongitud, dFechaRegCliente,
                                    lDomVerificado, lNotificacionEntregada);
        }
        
        public DataTable finalizarGestionHojaRuta(int idHojaRuta, int nKilometrajeFinal)
        {
            //return new clsWCFEjeSP().EjecSP("RCP_FinalizarResultadosHojaRuta_SP", idHojaRuta, nKilometrajeFinal);            
            return objEjeSp.EjecSP("RCP_FinalizarResultadosHojaRuta_SP", idHojaRuta, nKilometrajeFinal);            
        }

        public DataTable ListaHojasRuta(int idUsuario,DateTime dDesde, DateTime dA)
        {
            return objEjeSp.EjecSP("RCP_ListarHojasRuta_SP", idUsuario, dDesde, dA);           
        }

        public DataTable obtenerNotificacionesHojaRuta(int idHojaRuta)
        {
            return objEjeSp.EjecSP("RCP_ListarNotificacionesHojaRuta_SP", idHojaRuta);
        }

        public DataTable listaGarantes(int idCuenta)
        {
            return objEjeSp.EjecSP("GEN_ListarGaranAvalXCredito_sp", idCuenta);
        }

        public DataTable obtenerPrimeraHojaRutaPendiente(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ObtenerPrimeraHojaRutaPendiente_SP", idUsuario);
        }

        public DataTable listarUbicacionesGestiones(int idHojaRuta)
        {
            return objEjeSp.EjecSP("RCP_ListarGeolocalizacionesHojaRuta_SP", idHojaRuta);
        }

        public DataTable WCFListaHojasRuta(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_WCFListarHojasRuta_SP", idUsuario);           
        }

        public DataTable WCFListaCarteraAsesor(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_WCFCarteraAsesor_SP", idUsuario);
        }

        public DataTable WCFListaCarteraRecuperador(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_WCFCarteraRecuperador_SP", idUsuario);
        }

        public DataTable WCFListaCarteraRecuperadorDet(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_WCFCarteraRecuperadorDetalle_SP", idUsuario);
        }

        public DataTable WCFListaCarteraRecuperadorParam(int idUsuario, int nDiasProximos)
        {
            return objEjeSp.EjecSP("RCP_WCFCarteraRecuperadorParam_SP", idUsuario, nDiasProximos);
            
        }

        public DataTable WCFListarGestionCliente(int idCli)
        {
            return objEjeSp.EjecSP("RCP_WCFGestionCliente_SP", idCli);
            
        }

        public DataTable WCFListaCreditosAprobacion(int idAgencia, int idPerfil, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_BusEvalCredCli_Sp", 0, new DateTime(1, 1, 1), new DateTime(9999, 12, 31), 0.0, 999999999.0, 0, idAgencia, idPerfil, idUsuario, 1, 1);
        }

        public DataTable WCFIndicadores(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_IndicadoresFinEval_SP", idEvalCred);
        }

        public DataTable WCFActividad(int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_EvaluacionActividad_SP", idEvalCred);
        }

        public DataTable WCFDeuda(int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_ObtenerRCC_SP", idEvalCred);
        }

        public DataTable WCFRiesgos(int idSolicitud)
        {
            return objEjeSp.EjecSP("WCF_InformeRiesgos_SP", idSolicitud);
        }

        public DataTable WCFEstadoResultados(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_EstadoResultadosEval_SP", idEvalCred);
        }

        public DataTable WCFIntervinientes(int idSolicitud)
        {
            return objEjeSp.EjecSP("WCF_ListaIntervinientes_SP", idSolicitud);
        }

        public DataTable WCFEvaluacionCualitativa(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_PuntajeEvalCualitativa_SP", idEvalCred);
        }

        public DataTable WCFDestino(int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_DestinoCredito_SP", idEvalCred);
        }

        public DataSet WCFInicializarCredito(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSp.DSEjecSP("CRE_InicializarAprobacionEvalCred_SP", idEvalCred, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable WCFCreditosAprobacionGestion(int idSolicitud, int idEvalCred, int idAgencia, decimal nMonto)
        {
            //return new clsWCFEjeSP().EjecSP("CRE_WCFCarteraAsesor_SP", idUsuario);
            return objEjeSp.EjecSP("CRE_GestionarAprobacion_SP", idSolicitud, idEvalCred, idAgencia, nMonto);
        }

        public DataTable WCFCreditosAprobacionGuardar(int idSolicitud, int idEvalCred, int idUsuario, int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision, string cComentario, bool lVerificacion, int idMotRechazo, DateTime idFechaFin, int idCanalAproba)
        {
            //return new clsWCFEjeSP().EjecSP("CRE_WCFCarteraAsesor_SP", idUsuario);
            return objEjeSp.EjecSP("CRE_GuardarDecisionAprobador_SP", idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision, cComentario, lVerificacion, idMotRechazo, idFechaFin, idCanalAproba);
        }

        public DataTable WCFListaTipoDocumento()
        {
            //return new clsWCFEjeSP().EjecSP("WCF_ListaTipoDocumento_SP");
            return objEjeSp.EjecSP("WCF_ListaTipoDocumento_SP");
        }

        public DataTable WCFListaDireccionesCliente(int idCli)
        {
            return objEjeSp.EjecSP("Gen_ListaDirCli_Sp", idCli);
        }

        public DataTable CNDirNumTelPar(int idCli, int idCony = -1)
        {
            return objEjeSp.EjecSP("CRE_LisDirNumTelPar_SP", idCli, idCony);
        }

        public DataTable WFCListaVinculadosCliente(int idCli)
        {
            return objEjeSp.EjecSP("Gen_ListaClienteVinculo_Sp", idCli);
        }

        public DataTable WCFListaCreditosHojasRuta(int idHojaRuta)
        {
            //return new clsWCFEjeSP().EjecSP("RCP_WCFListarCreditosHojaRuta_SP", idHojaRuta);           
            return objEjeSp.EjecSP("RCP_WCFListarCreditosHojaRuta_SP", idHojaRuta);           
        }

        public DataTable WCFListaPromesasPago(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_WCFListarPromesasPago_SP", idUsuario);
            //return new clsWCFEjeSP().EjecSP("RCP_WCFListarPromesasPago_SP", idUsuario);           
        }

        public DataTable BuscarCliente(int idCriterio, string cPalabraClave)
        {
            //return new clsWCFEjeSP().EjecSP("RCP_WCFBuscarCliente_SP", idCriterio, cPalabraClave);           
            return objEjeSp.EjecSP("RCP_WCFBuscarCliente_SP", idCriterio, cPalabraClave);           
        }

        public DataTable registrarGestionHojaRutaMovil(int idDetalleHojaRuta, int idResultado, int idMotivoMora, int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa, decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita, string cObservacionVisita, string cLatitud, string cLongitud, DateTime dFechaRegisCliente, bool lDomVerificado, bool lNotificacionEntregada)
        {
            /*return new clsWCFEjeSP().EjecSP("RCP_RegistraResultadosHojaRuta_SP", idDetalleHojaRuta, idResultado, idMotivoMora,
                                    idTipoCliente, lRecuperable, cObservacion, dFechaPromesa,
                                    nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                                    cObservacionVisita, cLatitud, cLongitud, dFechaRegisCliente,
                                    lDomVerificado, lNotificacionEntregada);*/


            return objEjeSp.EjecSP("RCP_RegistraResultadosHojaRuta_SP", idDetalleHojaRuta, idResultado, idMotivoMora,
                                    idTipoCliente, lRecuperable, cObservacion, dFechaPromesa,
                                    nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                                    cObservacionVisita, cLatitud, cLongitud, dFechaRegisCliente,
                                    lDomVerificado, lNotificacionEntregada);
        }

        public DataTable WCFADBuscarCreditoCliente(int idTipoDoc, string cDocumentoID)
        {
            //return new clsWCFEjeSP().EjecSP("WCF_BuscarCreditoCliente_SP", idTipoDoc, cDocumentoID);
            return objEjeSp.EjecSP("WCF_BuscarCreditoCliente_SP", idTipoDoc, cDocumentoID);
        }

        public DataTable WCFADObtenerFotografia(string cDocumentoID)
        {
            return objEjeSp.EjecSP("WCF_ObtenerFotografia_SP", cDocumentoID);
        }

        public DataTable WCFMonitorVisitas(string idZona, string idAgencia, string idPersonal, string dtFechaIni, string dtFechaFin, int idClasificacion, int fMora)
        {
            return objEjeSp.EjecSP("WCF_MonitorVisitas_SP", idZona, idAgencia, idPersonal, dtFechaIni, dtFechaFin, idClasificacion, fMora);
        }

        public DataTable WCFMonitorVisitasDetalle(int idVisita)
        {
            return objEjeSp.EjecSP("WCF_MonitorVisitasDetalle_SP", idVisita);
        }

        public DataTable WCFMonitorVisitasBuscar(int nTipoBusqueda, string cCriterio, string dtFechaIni, string dtFechaFin)
        {
            return objEjeSp.EjecSP("WCF_MonitorVisitasBuscar_SP", nTipoBusqueda, cCriterio, dtFechaIni, dtFechaFin);
        }

        public DataTable WCFMonitorCredito(int idCli)
        {
            return objEjeSp.EjecSP("WCF_MonitorCreditos_SP", idCli);
        }

        public DataTable WCFRenEquivSexo(string cSexo)
        {
            return objEjeSp.EjecSP("WCF_EquivSexo_SP", cSexo);
        }

        public DataTable WCFRenEquivUbigeo(string cUbigeo)
        {
            return objEjeSp.EjecSP("WCF_EquivUbigeo_SP", cUbigeo);
        }

        public DataTable WCFRenEquivEstadoCivil(string idEstado)
        {
            return objEjeSp.EjecSP("WCF_EquivEstadoCivil_SP", idEstado);
        }

        public DataTable WCFMonitorListaAgencias()
        {
            //return new clsWCFEjeSP().EjecSP("CAJ_ListaAgencias_Sp");
            return objEjeSp.EjecSP("CAJ_ListaAgencias_Sp");
        }

        public DataTable WCFMonitorListaArchivos(int idVisita)
        {
            //return new clsWCFEjeSP().EjecSP("CRE_ListarArchivosVisita_SP", idVisita, 0);
            return objEjeSp.EjecSP("CRE_ListarArchivosVisita_SP", idVisita, 0);
        }

        public DataTable WCFMonitorArchivo(int idArchivo)
        {
            //return new clsWCFEjeSP().EjecSP("CRE_ObtenerArchivoVisita_SP", idArchivo);
            return objEjeSp.EjecSP("CRE_ObtenerArchivoVisita_SP", idArchivo);
        }

        public DataTable WCFADListarCampanaVigente()
        {
            //return new clsWCFEjeSP().EjecSP("WCF_CargaCampanasVigentes_SP");
            return objEjeSp.EjecSP("WCF_CargaCampanasVigentes_SP");
        }

        public DataTable WCFADListarClienteXCampanaAsesor(int idUsuario, int idGrupoCamp)
        {
            //return new clsWCFEjeSP().EjecSP("WCF_ListarClienteXCampanaAsesor_SP",idUsuario, idGrupoCamp);
            return objEjeSp.EjecSP("WCF_ListarClienteXCampanaAsesor_SP", idUsuario, idGrupoCamp);
        }

        public DataTable ADAprobarConNivelAutonomiaAsesor(int idEvalCred, DateTime dFecha, int idPerfil, int idCanal)
        { 
            return objEjeSp.EjecSP("CRE_AprobarConNivelAutonomiaAsesor_SP", idEvalCred, dFecha, idPerfil, idCanal);
        }
    }
}
