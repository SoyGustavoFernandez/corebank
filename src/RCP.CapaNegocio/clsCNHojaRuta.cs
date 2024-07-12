using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EntityLayer;

namespace RCP.CapaNegocio
{
    public class clsCNHojaRuta
    {
        clsADHojaRuta adHojaRuta;

        public clsCNHojaRuta()
        {
            adHojaRuta =  new clsADHojaRuta();
        }

        public clsCNHojaRuta(bool lWS)
        {
            adHojaRuta = new clsADHojaRuta(lWS);
        }

        public DataTable listaCarteraRecuperaciones(int idUsuario, int idUbigeo, int nAtrazoMin, int nAtrazoMax, Decimal nSaldoCapitalMin, Decimal nSaldoCapitalMax, bool lSoloDirPrincipal, int nTipoInterviniente, int idPerfil)
        {
            return adHojaRuta.listaCarteraRecuperaciones(idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, lSoloDirPrincipal, nTipoInterviniente, idPerfil);
        }
        public DataTable listaCarteraRecuPasoJudicial(int idUsuario, int idPerfil)
        {
            return adHojaRuta.listaCarteraRecuPasoJudicial(idUsuario, idPerfil);
        }
        public DataTable WCFListaAgencias(int idUsuario)
        {
            return adHojaRuta.listaAgencias(idUsuario);
        }
        public DataTable WCFListaAgenciasZona(int idZona)
        {
            return adHojaRuta.listaAgenciasZona(idZona);
        }
        public DataTable WCFListaPersonalAgencia(int idAgencia)
        {
            return adHojaRuta.listaPersonalAgencia(idAgencia);
        }
        public int getZonaUsuario(int idUsuario)
        {
            DataTable dtZonaUsuario = adHojaRuta.getZonaUsuario(idUsuario);
            if (dtZonaUsuario.Rows.Count != 0)
            {
                foreach (DataRow row in dtZonaUsuario.Rows)
                {
                    return Convert.ToInt32(row["idZona"]);
                }
            }
            return -1; 
        }
        public DataTable WCFListaZonas()
        {
            return adHojaRuta.listaZonas();
        }
        public DataTable WCFListaPerfiles(int idUsuario)
        {
            return adHojaRuta.listaPerfiles(idUsuario);
        }
        public DataTable registrarHojaRuta(int idUsuario, DateTime dFechaInicio, DateTime dFechaFin, int nKilometrajeInicio, string xmlHojaRuta, DateTime dFechaSistema)
        {
            return adHojaRuta.registrarHojaRuta(idUsuario, dFechaInicio, dFechaFin, nKilometrajeInicio, xmlHojaRuta, dFechaSistema);            
        }

        public DataTable validarHojaDeRutaAnteriores(int idUsuario, DateTime dFechaSistema, DateTime dFechaInicio, DateTime dFecFin)
        {
            return adHojaRuta.validarHojaDeRutaAnteriores(idUsuario, dFechaSistema, dFechaInicio, dFecFin);            
        }

        public DataTable obtenerHojaRuta(int idHojaRuta)
        {
            return adHojaRuta.obtenerHojaRuta(idHojaRuta);            
        }

        public DataTable obtenerCreditosHojaRuta(int idHojaRuta)
        {
            return adHojaRuta.obtenerCreditosHojaRuta(idHojaRuta);            
        }

        public DataTable obtenerAcciones(int idDetalleHojaRutaSeleccionado)
        {
            return adHojaRuta.obtenerAcciones(idDetalleHojaRutaSeleccionado);            
        }

        public DataTable RegistrarAcciones(int idDetalleHojaRutaSeleccionado, string xmlHojaRuta)
        {
            return adHojaRuta.RegistrarAcciones(idDetalleHojaRutaSeleccionado, xmlHojaRuta);            
        }

        public DataTable agregarCreditoHojaRuta(int idHojaRuta, int idCuenta, int idInter, int idDirecion, int idTipoAccion, int idTipoNotificacion, DateTime dFechaSistema, bool lDireccionRecupera)
        {
            return adHojaRuta.agregarCreditoHojaRuta(idHojaRuta, idCuenta, idInter, idDirecion, idTipoAccion, idTipoNotificacion, dFechaSistema, lDireccionRecupera);            
        }

        public DataTable listaCarteraPendiente(int idUsuario, DateTime dFecFin)
        {
            return adHojaRuta.listaCarteraPendiente(idUsuario, dFecFin);            
        }

        public DataTable registrarGestionHojaRuta(int idDetalleHojaRuta, int idResultado, int idMotivoMora,
                                                int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa,
                                                Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita,
                                                string cObservacionVisita, DateTime dFechaRegisCliente, bool lDomVerificado, bool lNotificacionEntregada)
        {
            return adHojaRuta.registrarGestionHojaRuta(idDetalleHojaRuta, idResultado, idMotivoMora,
                                                        idTipoCliente, lRecuperable, cObservacion, dFechaPromesa,
                                                        nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                                                        cObservacionVisita, dFechaRegisCliente, lDomVerificado, lNotificacionEntregada);            
        }

        public DataTable registrarGestionHojaRutaMovil(int idDetalleHojaRuta, int idResultado, int idMotivoMora, 
                                                    int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa,
                                                    Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita,
                                                    string cObservacionVisita, string cLatitud, string cLongitud, DateTime dFechaRegisCliente,
                                                    bool lDomVerificado, bool lNotificacionEntregada)
        {
            return adHojaRuta.registrarGestionHojaRutaMovil(idDetalleHojaRuta, idResultado, idMotivoMora,
                                                        idTipoCliente, lRecuperable, cObservacion, dFechaPromesa, nMontoPromesa,
                                                        cObservacionPromesa, lVisitar, dFechaVisita,
                                                        cObservacionVisita, cLatitud, cLongitud, dFechaRegisCliente,
                                                        lDomVerificado, lNotificacionEntregada);
        }
        
        public DataTable finalizarGestionHojaRuta(int idHojaRuta, int nKilometrajeFinal)
        {
            return adHojaRuta.finalizarGestionHojaRuta(idHojaRuta, nKilometrajeFinal);            
        }

        public DataTable ListaHojasRuta(int idUsuario, DateTime dDesde, DateTime dA)
        {
            return adHojaRuta.ListaHojasRuta(idUsuario,dDesde, dA);            
        }

        public DataTable obtenerNotificacionesHojaRuta(int idHojaRuta)
        {
            return adHojaRuta.obtenerNotificacionesHojaRuta(idHojaRuta);
        }

        public DataTable listaGarantes(int idCuenta)
        {
            return adHojaRuta.listaGarantes(idCuenta);
        }

        public DataTable obtenerPrimeraHojaRutaPendiente(int idUsuario)
        {
            return adHojaRuta.obtenerPrimeraHojaRutaPendiente(idUsuario);
        }

        public DataTable listarUbicacionesGestiones(int idHojaRuta)
        {
            return adHojaRuta.listarUbicacionesGestiones(idHojaRuta);
        }

        public DataTable WCFListaHojasRuta(int idUsuario)
        {
            return adHojaRuta.WCFListaHojasRuta(idUsuario);
        }

        public DataTable WCFListaCarteraAsesor(int idUsuario)
        {
            return adHojaRuta.WCFListaCarteraAsesor(idUsuario);
        }

        public DataTable WCFListaCarteraRecuperador(int idUsuario)
        {
            return adHojaRuta.WCFListaCarteraRecuperador(idUsuario);
        }

        public DataTable WCFListaCarteraRecuperadorDet(int idUsuario)
        {
            return adHojaRuta.WCFListaCarteraRecuperadorDet(idUsuario);
        }
        public DataTable WCFListaCarteraRecuperadorParam(int idUsuario, int nDiasProximos)
        {
            return adHojaRuta.WCFListaCarteraRecuperadorParam(idUsuario, nDiasProximos);
        }

        public DataTable WCFListarGestionCliente(int idCli)
        {
            return adHojaRuta.WCFListarGestionCliente(idCli);
        }
        
        public DataTable WCFListaCreditosAprobacion(int idAgencia, int idPerfil, int idUsuario)
        {
            return adHojaRuta.WCFListaCreditosAprobacion(idAgencia, idPerfil, idUsuario);
        }

        public DataTable WCFIndicadores(int idEvalCred)
        {
            return adHojaRuta.WCFIndicadores(idEvalCred);
        }

        public String WCFActividadEconomica(int idEvalCred)
        {
            DataTable dtActividad = adHojaRuta.WCFActividad(idEvalCred);
            if (dtActividad.Rows.Count != 0)
            {
                return dtActividad.Rows[0]["cActividad"].ToString();
            }
            return "NO TIENE";
        }

        public DataTable WCFDeuda(int idEvalCred)
        {
            return adHojaRuta.WCFDeuda(idEvalCred);
        }

        public DataTable WCFRiesgos(int idSolicitud)
        {
            return adHojaRuta.WCFRiesgos(idSolicitud);
        }

        public DataTable WCFEstadoResultados(int idEvalCred)
        {
            return adHojaRuta.WCFEstadoResultados(idEvalCred);
        }

        public decimal WCFEvaluacionCualitativa(int idEvalCred)
        {
            DataTable dtEvaluacion = adHojaRuta.WCFEvaluacionCualitativa(idEvalCred);
            decimal value = Decimal.Parse(dtEvaluacion.Rows[0]["nPuntaje"].ToString());
            return value;
        }

        public DataTable WCFIntervinientes(int idSolicitud)
        {
            return adHojaRuta.WCFIntervinientes(idSolicitud);
        }

        public DataTable WCFEDestino(int idEvalCred)
        {
            return adHojaRuta.WCFDestino(idEvalCred);
        }

        public DataTable WCFCreditosAprobacionGestion(int idSolicitud, int idEvalCred, int idAgencia, decimal nMonto)
        {
            return adHojaRuta.WCFCreditosAprobacionGestion(idSolicitud, idEvalCred, idAgencia, nMonto);
        }

        public DataSet WCFInicializarCreditoAprobacion(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return adHojaRuta.WCFInicializarCredito(idEvalCred, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable WCFCreditosAprobacionGuardar(int idSolicitud, int idEvalCred, int idUsuario, int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision, string cComentario, bool lVerificacion, int idMotRechazo, DateTime idFechaFin, int idCanalAproba)
        {
            return adHojaRuta.WCFCreditosAprobacionGuardar(idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision, cComentario, lVerificacion, idMotRechazo, idFechaFin, idCanalAproba);
        }

        public DataTable WCFListaTipoDocumento()
        {
            return adHojaRuta.WCFListaTipoDocumento();
        }

        public DataTable WCFListaDireccionesCliente(int idCli) {
            return adHojaRuta.WCFListaDireccionesCliente(idCli);
        }

        public DataTable CNDirNumTelPar(int idCli, int idCony = -1)
        {
            return adHojaRuta.CNDirNumTelPar(idCli, idCony);
        }

        public DataTable WFCListaVinculadosCliente(int idCli)
        {
            return adHojaRuta.WFCListaVinculadosCliente(idCli);
        }

        public DataTable WCFListaCreditosHojasRuta(int idHojaRuta)
        {
            return adHojaRuta.WCFListaCreditosHojasRuta(idHojaRuta);
        }

        public DataTable WCFListaPromesasPago(int idUsuario)
        {
            return adHojaRuta.WCFListaPromesasPago(idUsuario);
        }

        public DataTable BuscarCliente(int idCriterio, string cPalabraClave)
        {
            return adHojaRuta.BuscarCliente(idCriterio, cPalabraClave);
        }

        public DataTable WCFCNBuscarCreditoCliente(int idTipoDoc, string cDocumentoID)
        {
            return adHojaRuta.WCFADBuscarCreditoCliente(idTipoDoc, cDocumentoID);
        }

        public DataTable WCFCNObtenerFotografia(string cDocumentoID)
        {
            return adHojaRuta.WCFADObtenerFotografia(cDocumentoID);
        }

        public DataTable WCFMonitorVisitas(string idZona, string idAgencia, string idPersonal, string dtFechaIni, string dtFechaFin, int idClasificacion, int fMora)
        {
            return adHojaRuta.WCFMonitorVisitas(idZona, idAgencia, idPersonal, dtFechaIni, dtFechaFin, idClasificacion, fMora);
        }

        public DataTable WCFMonitorVisitasDetalle(int idVisita)
        {
            return adHojaRuta.WCFMonitorVisitasDetalle(idVisita);
        }

        public DataTable WCFMonitorVisitasBusqueda(int nTipoBusqueda, string cCriterio, string dtFechaIni, string dtFechaFin)
        {
            switch (nTipoBusqueda)
            {
                case 0:
                case 1:
                    Regex regex = new Regex(@"[^0-9]");
                    cCriterio = regex.Replace(cCriterio, "");
                    break;
                case 2:
                    Regex rgx = new Regex(@"[^A-Za-z ]");
                    cCriterio = rgx.Replace(cCriterio, "");
                    cCriterio = Regex.Replace(cCriterio, @"\s+", "%");
                    break;
            }

            return adHojaRuta.WCFMonitorVisitasBuscar(nTipoBusqueda, cCriterio, dtFechaIni, dtFechaFin);
        }

        public DataTable WCFMonitorCredito(int idCli)
        {
            return adHojaRuta.WCFMonitorCredito(idCli);
        }

        public int WCFRenEquivSexo(string cSexo)
        {
            DataTable dt = adHojaRuta.WCFRenEquivSexo(cSexo);
            if (dt.Rows.Count != 0)
            {
                return Convert.ToInt32(dt.Rows[0]["cCodCore"].ToString());
            }
            return 0;
        }

        public int WCFRenEquivUbigeo(string cUbigeo)
        {
            DataTable dt = adHojaRuta.WCFRenEquivUbigeo(cUbigeo);
            if (dt.Rows.Count != 0)
            {
                return Convert.ToInt32(dt.Rows[0]["idUbigeo"].ToString());
            }
            return 0;
        }

        public int WCFRenEquivEstadoCivil(string idEstado)
        {
            DataTable dt = adHojaRuta.WCFRenEquivEstadoCivil(idEstado);
            if (dt.Rows.Count != 0)
            {
                return Convert.ToInt32(dt.Rows[0]["cCodCore"].ToString());
            }
            return 0;
        }

        public DataTable WCFMonitorListaAgencia()
        {
            return adHojaRuta.WCFMonitorListaAgencias();
        }

        public DataTable WCFMonitorListaArchivos(int idVisita)
        {
            return adHojaRuta.WCFMonitorListaArchivos(idVisita);
        }

        public DataTable WCFMonitorArchivo(int idArchivo)
        {
            return adHojaRuta.WCFMonitorArchivo(idArchivo);
        }

        public DataTable WCFCNListarCampanaVigente()
        {
            return adHojaRuta.WCFADListarCampanaVigente();
        
        }
        public DataTable WCFCNListarClienteXCampanaAsesor(int idUsuario, int idGrupoCamp)
        {
            return adHojaRuta.WCFADListarClienteXCampanaAsesor(idUsuario, idGrupoCamp);
        }

        public DataTable CNAprobarConNivelAutonomiaAsesor(int idEvalCred, DateTime dFecha, int idPerfil, int idCanal)
        {
            return adHojaRuta.ADAprobarConNivelAutonomiaAsesor(idEvalCred, dFecha, idPerfil, idCanal);
        }
    }
}
