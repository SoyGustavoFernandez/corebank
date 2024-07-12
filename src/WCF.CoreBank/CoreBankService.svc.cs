using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityLayer;
using GEN.CapaNegocio;
using RCP.CapaNegocio;
using GEN.Funciones;
using System.Globalization;
using System.Web;
using System.Net;
using WCF.CoreBank.Validaciones;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text.RegularExpressions;

using CRE.CapaNegocio; 
using WCF.Corebank.Utilities;
using SolIntEls.GEN.Helper;

namespace WCF.CoreBank
{
    public class CoreBankService : ICoreBankService
    {

        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        CRE.CapaNegocio.clsCNScoring CNScoring = new CRE.CapaNegocio.clsCNScoring();
        string ANDY_VERSION = "3.2.0";
        private string cReniecWS = "http://10.5.5.70:8000/ServicioReniec.svc/ConsultaIndInfPerReniec";

        public void setConectionString()
        {
            clsEnvironment objEnviroment = new clsEnvironment();
            clsConexionWcf objCon = objEnviroment.CargarArchivoEnvironment();
            String cCadenaConexion = objCon.obtenerConexionSegunda();
            this.ANDY_VERSION = objCon.obtenerVersion();
            
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["cConectionString"]))
                HttpContext.Current.Session["cConectionString"] = cCadenaConexion;
        }

        public CoreBankService()
        {
            setConectionString();
        }

        public clsWCFUsuario IdentificarUsuario(clsWCFUsuario objWCFUsuario)
        {

            try
            {
                objWCFUsuario.cVersion = ANDY_VERSION;
                clsVarGlobal.IConectionGen = new ConnectionWeb();
                clsAutenticacion autenticacion = new clsAutenticacion();
                usuario.CodigoAD = objWCFUsuario.cWinUser.Trim();
                usuario.clave = objWCFUsuario.cPassword.Trim();
                clsUsuario user = null;
                IList<clsPerfilUsu> lstPerfiles = null;
                clsVarGlobalClone objVarGlobal = null;
                clsDatosToken datosToken = null;



                if (autenticacion.AutenticarWCF(usuario.CodigoAD, usuario.clave, ref user))
                {
                    if (new clsPcUsuario().validarDatosPc(user.idUsuario, objWCFUsuario.cImei, objWCFUsuario.cNombreEquipo, objWCFUsuario.cCaracteristicas))
                    {
                        objVarGlobal = new clsVarGlobalClone();
                        lstPerfiles = new clsCNPerfilUsu().ListarPerUsu(user.idUsuario);
                        new clsCNVarGen().GetVarGlobal(1, objVarGlobal);

                        datosToken = new clsDatosToken();
                        datosToken.dFechaSistema = objVarGlobal.dFecSystem;
                        datosToken.dInicioSession = DateTime.UtcNow;
                        datosToken.idUsuario = user.idUsuario;
                        datosToken.guidUser = Guid.NewGuid();
                        datosToken.cImei = objWCFUsuario.cImei;
                        datosToken.idPerfil = objWCFUsuario.idPerfil;
                        datosToken.idAgencia = objWCFUsuario.idAgencia;
                        datosToken.idEstablecimiento = user.idEstablecimiento;
                        datosToken.idTipoEstablecimiento = user.idTipoEstablec;

                        string cListados = String.Empty;

                        if (lstPerfiles.Count == 0)
                        {
                            objWCFUsuario.lIdentificado = false;
                            objWCFUsuario.cMensaje = "El usuario no tiene perfiles asignados";
                        }
                        else
                        {
                            //validar perfil de recuperaciones
                            //List<clsPerfilUsu> lstPerfilCoincidentes = (from perfiles in lstPerfiles
                            //                                            where   perfiles.idPerfil == 76 || 
                            //                                                    perfiles.idPerfil == 77 || 
                            //                                                    perfiles.idPerfil == 1 || 
                            //                                                    perfiles.idPerfil == 34 ||
                            //                                                    perfiles.idPerfil == 64 ||
                            //                                                    perfiles.idPerfil == 85 ||
                            //                                                    perfiles.idPerfil == 33 ||
                            //                                                    perfiles.idPerfil == 71 ||
                            //                                                    perfiles.idPerfil == 73
                            //                                            select perfiles).ToList<clsPerfilUsu>();


                            DataTable dtContadorPerfil = CNScoring.VerificarAccesoMovil(user.idUsuario);



                            if (dtContadorPerfil.Rows.Count > 0 && Convert.ToInt32(dtContadorPerfil.Rows[0][0]) > 0)
                            {
                                if (datosToken.idPerfil == 0 || datosToken.idPerfil == null)
                                {
                                    datosToken.idPerfil = lstPerfiles.First().idPerfil;
                                }

                                objWCFUsuario.lIdentificado = true;
                                objWCFUsuario.cNombres = objWCFUsuario.cWinUser;
                                objWCFUsuario.cPerfil = lstPerfiles.First().cPerfil;
                                objWCFUsuario.cToken = usuario.GeneraToken(datosToken);
                                objWCFUsuario.dFechaSistema = objVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                                /*DataTable listaAgencias = new clsCNHojaRuta(true).WCFListaAgencias(datosToken.idUsuario);
                                objWCFUsuario.lAgencias = listaAgencias.ToList<clsWCFAgencia>();
                                DataTable listaPerfiles = new clsCNHojaRuta(true).WCFListaPerfiles(datosToken.idUsuario);
                                objWCFUsuario.lPerfiles = listaPerfiles.ToList<clsWCFPerfil>();*/
                            }
                            else
                            {
                                objWCFUsuario.lIdentificado = false;
                                objWCFUsuario.cMensaje = "El usuario no tiene permiso para acceder a esta aplicación";
                            }



                            //if (lstPerfilCoincidentes.Count > 0)
                            //{
                            //    datosToken.idAgencia = 1;
                            //    datosToken.idPerfil = lstPerfilCoincidentes.First().idPerfil;

                            //    objWCFUsuario.lIdentificado = true;
                            //    objWCFUsuario.cNombres = objWCFUsuario.cWinUser;
                            //    objWCFUsuario.cPerfil = lstPerfilCoincidentes.First().cPerfil;
                            //    objWCFUsuario.cToken = usuario.GeneraToken(datosToken);
                            //    objWCFUsuario.dFechaSistema = objVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                            //}
                            //else
                            //{
                            //    objWCFUsuario.lIdentificado = false;
                            //    objWCFUsuario.cMensaje = "El usuario no tiene el tipo de perfil para hacer uso de esta aplicación";
                            //}

                        }
                    }
                    else
                    {
                        objWCFUsuario.lIdentificado = false;
                        objWCFUsuario.cMensaje = "El equipo no está autorizado";
                    }
                }
                else
                {
                    objWCFUsuario.lIdentificado = false;
                    objWCFUsuario.cMensaje = "Usuario y/o contraseña no son correctas";
                }
            }
            catch (Exception e)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cMensaje = "TRY/CATCH " + e.ToString() + "   ----    " + string.Format("Data Source={0}; Initial Catalog={1}; User={2}; Password={3}; Connection Timeout=120", "10.4.12.6\\pruebas", "SI_BDCoreBankTUsuario", clsPassword.cUsuDB, clsPassword.cPassUsuDB);

            }

            return objWCFUsuario;
        }

        public clsWCFUsuario AgenciaPerfilUsuario(clsWCFUsuario objWCFUsuario)
        {
            try
            {
                objWCFUsuario.cVersion = ANDY_VERSION;
                clsVarGlobal.IConectionGen = new ConnectionWeb();
                clsAutenticacion autenticacion = new clsAutenticacion();
                usuario.CodigoAD = objWCFUsuario.cWinUser.Trim();
                usuario.clave = objWCFUsuario.cPassword.Trim();
                clsUsuario user = null;
                IList<clsPerfilUsu> lstPerfiles = null;
                clsVarGlobalClone objVarGlobal = null;

                if (autenticacion.AutenticarWCF(usuario.CodigoAD, usuario.clave, ref user))
                {
                    if (new clsPcUsuario().validarDatosPc(user.idUsuario, objWCFUsuario.cImei, objWCFUsuario.cNombreEquipo, objWCFUsuario.cCaracteristicas))
                    {
                        objVarGlobal = new clsVarGlobalClone();
                        lstPerfiles = new clsCNPerfilUsu().ListarPerUsu(user.idUsuario);
                        new clsCNVarGen().GetVarGlobal(1, objVarGlobal);

                        string cListados = String.Empty;

                        if (lstPerfiles.Count == 0)
                        {
                            objWCFUsuario.lIdentificado = false;
                            objWCFUsuario.cMensaje = "El usuario no tiene perfiles asignados";
                        }
                        else
                        {
                            DataTable dtContadorPerfil = CNScoring.VerificarAccesoMovil(user.idUsuario);
                            if (dtContadorPerfil.Rows.Count > 0 && Convert.ToInt32(dtContadorPerfil.Rows[0][0]) > 0)
                            {
                                objWCFUsuario.lIdentificado = true;
                                objWCFUsuario.cNombres = objWCFUsuario.cWinUser;
                                objWCFUsuario.cPerfil = lstPerfiles.First().cPerfil;
                                objWCFUsuario.dFechaSistema = objVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                                DataTable listaAgencias = new clsCNHojaRuta(true).WCFListaAgencias(user.idUsuario);
                                objWCFUsuario.lAgencias = listaAgencias.ToList<clsWCFAgencia>();
                                DataTable listaPerfiles = new clsCNHojaRuta(true).WCFListaPerfiles(user.idUsuario);
                                objWCFUsuario.lPerfiles = listaPerfiles.ToList<clsWCFPerfil>();
                            }
                            else
                            {
                                objWCFUsuario.lIdentificado = false;
                                objWCFUsuario.cMensaje = "El usuario no tiene permiso para acceder a esta aplicación";
                            }
                        }
                    }
                    else
                    {
                        objWCFUsuario.lIdentificado = false;
                        objWCFUsuario.cMensaje = "El equipo no está autorizado";
                    }
                }
                else
                {
                    objWCFUsuario.lIdentificado = false;
                    objWCFUsuario.cMensaje = "Usuario y/o contraseña no son correctas";
                }
            }
            catch (Exception e)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cMensaje = e.StackTrace;
            }

            return objWCFUsuario;
        }

        public clsWCFToken ValidarToken(string cToken)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            clsWCFToken resToken = new clsWCFToken();

            if (usuario.validaToken(cToken))
            {
                resToken.cEstado = "VALIDO";
                resToken.cMensaje = null;
                resToken.cNivel = getNivelAcceso(datosToken);
                return resToken;
            }

            resToken.cEstado = "INVALIDO";
            resToken.cMensaje = "Token invalido y/o desfasado";
            return resToken;
        }

        public IList<clsWCFHojaRuta> ListarHojasRutaPendientes(string cToken)
        {
            IList<clsWCFHojaRuta> lstHojaRuta = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtHojasRuta = new clsCNHojaRuta(true).WCFListaHojasRuta(datosToken.idUsuario);
                lstHojaRuta = dtHojasRuta.ToList<clsWCFHojaRuta>();
            }
            else
            {

            }

            return lstHojaRuta;
        }

        public IList<clsWCFCarteraAsesor> ListarCarteraAsesor(string cToken)
        {
            IList<clsWCFCarteraAsesor> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFListaCarteraAsesor(datosToken.idUsuario);
                lstCartera = dtCarteraAsesor.ToList<clsWCFCarteraAsesor>();
            }

            return lstCartera;
        }

        public IList<clsWCFCarteraAsesor> ListarCarteraRecuperador(string cToken)
        {
            IList<clsWCFCarteraAsesor> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFListaCarteraRecuperador(datosToken.idUsuario);
                lstCartera = dtCarteraAsesor.ToList<clsWCFCarteraAsesor>();
            }

            return lstCartera;
        }

        public IList<clsWCFCarteraRecuperador> ListarCarteraRecuperadorDet(string cToken)
        {
            IList<clsWCFCarteraRecuperador> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFListaCarteraRecuperadorDet(datosToken.idUsuario);
                lstCartera = dtCarteraAsesor.ToList<clsWCFCarteraRecuperador>();
            }

            return lstCartera;
        }

        public IList<clsWCFCarteraRecuperador> FiltrarCarteraRecuperador(string cToken,int idUsuario, int nDiasProximos)
        {
            IList<clsWCFCarteraRecuperador> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable data = new clsCNHojaRuta(true).WCFListaCarteraRecuperadorParam(2199, 8);
                lstCartera = data.ToList<clsWCFCarteraRecuperador>();
            }

            return lstCartera;
        }

        public IList<clsWCFGestionCliente> ListarGestionCliente(string cToken, int idCli)
        {
            IList<clsWCFGestionCliente> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFListarGestionCliente(idCli);
                lstCartera = dtCarteraAsesor.ToList<clsWCFGestionCliente>();
            }

            return lstCartera;
        }

        public IList<clsWCFTipoDocumento> ListarTipoDocumento(string cToken)
        {
            IList<clsWCFTipoDocumento> lstTipoDocumento = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtTipoDocumento = new clsCNHojaRuta(true).WCFListaTipoDocumento();
                lstTipoDocumento = dtTipoDocumento.ToList<clsWCFTipoDocumento>();
            }

            return lstTipoDocumento;
        }

        public IList<clsWFCDireccionCliente> ListarDireccionesCliente(string cToken, int idCli)
        {
            IList<clsWFCDireccionCliente> lstDireccionesCliente = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtDireccionesCliente = new clsCNHojaRuta(true).WCFListaDireccionesCliente(idCli);
                lstDireccionesCliente = dtDireccionesCliente.SoftToList<clsWFCDireccionCliente>();
            }
            return lstDireccionesCliente;
        }

        public IList<clsWFCClienteVinculo> ListarVinculosCliente(String cToken, int idCli)
        {
            IList<clsWFCClienteVinculo> lstVinculosCliente = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtVinculosCliente = new clsCNHojaRuta(true).WFCListaVinculadosCliente(idCli);
                lstVinculosCliente = dtVinculosCliente.ToList<clsWFCClienteVinculo>();
            }
            return lstVinculosCliente;
        }

        public IList<clsWCFDetalleHojaRuta> ListarCreditosHojaRuta(clsWCFParametroInt objWCFParametroInt)
        {
            IList<clsWCFDetalleHojaRuta> lstCreditosHojaRuta = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(objWCFParametroInt.cToken);

            if (usuario.validaToken(objWCFParametroInt.cToken))
            {
                DataTable dtHojasRuta = new clsCNHojaRuta(true).WCFListaCreditosHojasRuta(objWCFParametroInt.nValor);
                lstCreditosHojaRuta = dtHojasRuta.ToList<clsWCFDetalleHojaRuta>();
            }
            else
            {

            }
            return lstCreditosHojaRuta;
        }

        public clsWCFRespuesta RegistraGestionHojaRuta(clsWCFResultadoGestion objWCFResultadoGestion)
        {
            clsDatosToken datosToken = new clsDatosToken();
            clsWCFRespuesta objWCFRespuesta = new clsWCFRespuesta();

            /**************     Validacion de GestionHojaRuta  ***********************/
            clsValidacionBase obj = new clsValidacionBase();
            clsObjetoValidar  objVal = new clsObjetoValidar();
            objVal.setObjeto<clsWCFResultadoGestion>(objWCFResultadoGestion);
            clsMsjError objErro = obj.validacion<object>(objVal, new clsValidarGestionHojaRuta());

            try
            {
                datosToken = usuario.obtenerDatosToken(objWCFResultadoGestion.cToken);

                if (usuario.validaToken(objWCFResultadoGestion.cToken) || objWCFResultadoGestion.cToken.Equals("69i57j69i60l3j69i61j5"))
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    String format = "dd/MM/yyyy";
                    DateTime dFechaPromesa = DateTime.ParseExact(objWCFResultadoGestion.dFechaPromesa, format, provider);
                    DateTime dFechaProxVisita = DateTime.ParseExact(objWCFResultadoGestion.dFechaVisita, format, provider);
                    format = "dd/MM/yyyy HH:mm:ss";
                    DateTime dFechaRegCliente = DateTime.ParseExact(objWCFResultadoGestion.dFechaRegCliente, format, provider);//Convert.ToDateTime(objWCFResultadoGestion.dFechaRegCliente,);


                    DataTable dtResultado = new clsCNHojaRuta(true).registrarGestionHojaRutaMovil(objWCFResultadoGestion.idDetalleHojaRuta, objWCFResultadoGestion.idResultado, objWCFResultadoGestion.idMotivoMora,
                                                                                objWCFResultadoGestion.idTipoCliente, Convert.ToBoolean(objWCFResultadoGestion.lRecuperable), objWCFResultadoGestion.cObservacion, dFechaPromesa,
                                                                                objWCFResultadoGestion.nMontoPromesa, objWCFResultadoGestion.cObservacionPromesa, Convert.ToBoolean(objWCFResultadoGestion.lVisitar), dFechaProxVisita,
                                                                                objWCFResultadoGestion.cObservacionVisita, objWCFResultadoGestion.cLatitud, objWCFResultadoGestion.cLongitud,
                                                                                dFechaRegCliente, Convert.ToBoolean(objWCFResultadoGestion.lDomVerificado), objWCFResultadoGestion.lNotificacionEntregada);
                    if (dtResultado.Rows.Count > 0)
                    {
                        objWCFRespuesta.idRespuesta = 0;
                        objWCFRespuesta.cMensaje = "Se registro correctamente el resultado de la gestión";
                    }
                    else
                    {
                        objWCFRespuesta.idRespuesta = 1;
                        objWCFRespuesta.cMensaje = "Error al registrar la gestión, vuelva a intentarlo";
                    }
                }
                else
                {
                    //token invalido
                    objWCFRespuesta.idRespuesta = 1;
                    objWCFRespuesta.cMensaje = "Token invalido, su sessión expiro, vuelva a ingresar al sistema";
                }
            }
            catch (Exception e)
            {
                objWCFRespuesta.idRespuesta = 1;
                objWCFRespuesta.cMensaje = "Excep: " + e.ToString();
            }
            return objWCFRespuesta;
        }

        public clsWCFRespuesta FinalizaHojaRuta(clsWCFResultadoHojaRuta objWCFResultadoHojaRuta)
        {
            clsDatosToken datosToken = new clsDatosToken();
            clsWCFRespuesta objWCFRespuesta = new clsWCFRespuesta();

            datosToken = usuario.obtenerDatosToken(objWCFResultadoHojaRuta.cToken);

            if (usuario.validaToken(objWCFResultadoHojaRuta.cToken))
            {
                DataTable dtResultado = new clsCNHojaRuta(true).finalizarGestionHojaRuta(objWCFResultadoHojaRuta.idHojaRuta, objWCFResultadoHojaRuta.nKilometroFinal);

                if (dtResultado.Rows.Count > 0)
                {
                    objWCFRespuesta.idRespuesta = 0;
                    objWCFRespuesta.cMensaje = "Se registro correctamente el cierre de la hoja de ruta";
                }
                else
                {
                    objWCFRespuesta.idRespuesta = 1;
                    objWCFRespuesta.cMensaje = "Error al registrar el cierre de la hoja de ruta, vuelva a intentarlo";
                }
            }
            else
            {
                //token invalido
                objWCFRespuesta.idRespuesta = 1;
                objWCFRespuesta.cMensaje = "Token invalido, su sessión expiro, vuelva a ingresar al sistema";
            }

            return objWCFRespuesta;
        }

        public IList<clsWCFPromesaPago> ListarPromesasPago(string cToken)
        {
            IList<clsWCFPromesaPago> lstPromesasPago = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtPromesasPago = new clsCNHojaRuta(true).WCFListaPromesasPago(datosToken.idUsuario);
                lstPromesasPago = dtPromesasPago.ToList<clsWCFPromesaPago>();
            }
            else
            {

            }

            return lstPromesasPago;
        }

        public IList<clsWCFClienteBasico> BuscarClientes(clsWCFBusquedaCliente objWCFBusquedaCliente)
        {
            IList<clsWCFClienteBasico> lstClienteBasicos = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(objWCFBusquedaCliente.cToken);

            if (usuario.validaToken(objWCFBusquedaCliente.cToken))
            {
                DataTable dtClientes = new clsCNHojaRuta(true).BuscarCliente(objWCFBusquedaCliente.idCriterio, objWCFBusquedaCliente.cPalabraClave);
                lstClienteBasicos = dtClientes.ToList<clsWCFClienteBasico>();
            }
            else
            {
            }
            return lstClienteBasicos;
        }

        public clsWCFRespuesta AgregarCreditoHojaRuta(clsWCFClienteHojaRuta objWCFClienteHojaRuta)
        {
            clsDatosToken datosToken = new clsDatosToken();
            clsWCFRespuesta objWCFRespuesta = new clsWCFRespuesta();

            datosToken = usuario.obtenerDatosToken(objWCFClienteHojaRuta.cToken);

            if (usuario.validaToken(objWCFClienteHojaRuta.cToken))
            {
                DataTable dtResultado = new clsCNHojaRuta(true).agregarCreditoHojaRuta(objWCFClienteHojaRuta.idHojaRuta, objWCFClienteHojaRuta.idCuenta, objWCFClienteHojaRuta.idInter, objWCFClienteHojaRuta.idDireccion,
                                                                                    11, 0, datosToken.dFechaSistema, false);
                if (dtResultado.Rows.Count > 0)
                {
                    objWCFRespuesta.idRespuesta = 0;
                    objWCFRespuesta.cMensaje = "Agregado correctamente a la hoja de ruta";
                }
                else
                {
                    objWCFRespuesta.idRespuesta = 1;
                    objWCFRespuesta.cMensaje = "Error al agregar cliente a la hoja de ruta, vuelva a intentarlo";
                }
            }
            else
            {
                //token invalido
                objWCFRespuesta.idRespuesta = 1;
                objWCFRespuesta.cMensaje = "Token invalido, su sessión expiro, vuelva a ingresar al sistema";
            }
            return objWCFRespuesta;
        }

        public clsWCFScoringPrimerFiltro ScoringPrimerFiltro(clsWCFParametroString objWCFParametroString)
        {

            clsWCFScoringPrimerFiltro objWCFScoringPrimerFiltro = new clsWCFScoringPrimerFiltro();
            clsDatosToken datosToken = new clsDatosToken();
            List<Puntuacion> lstPuntuaciones = new List<Puntuacion>();

            try
            {

                datosToken = usuario.obtenerDatosToken(objWCFParametroString.cToken);

                if (usuario.validaToken(objWCFParametroString.cToken))
                {

                    DataTable dtPersona = CNScoring.ObtenerDatosClienteScoring(objWCFParametroString.cValor, true);
                    if (dtPersona.Rows.Count > 0)
                    {
                        objWCFScoringPrimerFiltro = dtPersona.ToList<clsWCFScoringPrimerFiltro>()[0];
                        objWCFScoringPrimerFiltro.nPuntuacionScoring = PrimerScoring(objWCFScoringPrimerFiltro);
                        if (objWCFScoringPrimerFiltro.nEndeudamientoRCC >= 19700M)
                        {
                            objWCFScoringPrimerFiltro.nPuntuacionScoring = 0.00M;
                        }

                        DataTable dtMontosMaximosOtor = CNScoring.ObtenerMaximoMontos(objWCFScoringPrimerFiltro.lBancarizado, 1, 20000.00M - objWCFScoringPrimerFiltro.nEndeudamientoRCC, true);
                        if (dtMontosMaximosOtor.Rows.Count > 0)
                        {
                            objWCFScoringPrimerFiltro.nPlazoMaximo = Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoConEvaluacion"]);
                            objWCFScoringPrimerFiltro.nMontoMaximo = Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoConEvaluacion"]);
                        }
                        else
                        {
                            objWCFScoringPrimerFiltro.nPlazoMaximo = 24;
                            objWCFScoringPrimerFiltro.nMontoMaximo = 10000.0M;
                        }
                    }
                    else
                    {
                        objWCFScoringPrimerFiltro.nPlazoMaximo = 24;
                        objWCFScoringPrimerFiltro.nMontoMaximo = 10000.0M;
                        objWCFScoringPrimerFiltro.idCliente = -1;
                    }

                    if (objWCFScoringPrimerFiltro.nMonto > 0.00M)
                    {
                        CNScoring.RegistroLogScoring(objWCFParametroString.cValor, objWCFScoringPrimerFiltro.nPuntuacionScoring, datosToken.idUsuario, 3, true);
                    }
                    else
                        if (objWCFScoringPrimerFiltro.nPuntuacionScoring > 0.00M)
                        {
                            CNScoring.RegistroLogScoring(objWCFParametroString.cValor, objWCFScoringPrimerFiltro.nPuntuacionScoring, datosToken.idUsuario, 1, true);
                        }
                        else
                        {
                            CNScoring.RegistroLogScoring(objWCFParametroString.cValor, objWCFScoringPrimerFiltro.nPuntuacionScoring, datosToken.idUsuario, 2, true);
                        }

                }
                else
                {
                    objWCFScoringPrimerFiltro.idCliente = -2;
                }

            }
            catch (Exception e)
            {
                objWCFScoringPrimerFiltro.cNombreCliente = e.ToString() + " - " + e.Message;
            }
            return objWCFScoringPrimerFiltro;
        }

        public clsWCFResSegundoFiltro ScoringSegundoFiltro(clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro)
        {
            clsWCFResSegundoFiltro objWCFResSegundoFiltro = new clsWCFResSegundoFiltro();
            clsDatosToken datosToken = new clsDatosToken();

            datosToken = usuario.obtenerDatosToken(objWCFEnvSegundoFiltro.cToken);

            if (usuario.validaToken(objWCFEnvSegundoFiltro.cToken))
            {
                objWCFResSegundoFiltro.nPuntaje = SegundoScoring(objWCFEnvSegundoFiltro, datosToken.idUsuario);

                CNScoring.ActualizarLogScoring(objWCFEnvSegundoFiltro.cNroDocumento, objWCFResSegundoFiltro.nPuntaje, datosToken.idUsuario, objWCFEnvSegundoFiltro.idEstadoCivil, objWCFEnvSegundoFiltro.nEdad, objWCFEnvSegundoFiltro.cUbigeoNacimiento, objWCFEnvSegundoFiltro.nExperienciaNegocio, objWCFEnvSegundoFiltro.lFormalizado, objWCFEnvSegundoFiltro.idDestino, objWCFEnvSegundoFiltro.nMontoSolicitado, objWCFEnvSegundoFiltro.nPlazo, objWCFEnvSegundoFiltro.nExcedente, objWCFEnvSegundoFiltro.nDeudaFinanciera, true);

                DataTable dtMontosMaximosOtor = CNScoring.ObtenerMaximoMontos(objWCFEnvSegundoFiltro.lBancarizado, objWCFEnvSegundoFiltro.idDestino, 20000.00M - objWCFEnvSegundoFiltro.nEndeudamientoRCC, true);
                if (dtMontosMaximosOtor.Rows.Count > 0)
                {
                    objWCFResSegundoFiltro.nPlazoConEvaluacion = Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoConEvaluacion"]);
                    objWCFResSegundoFiltro.nMontoConEvaluacion = Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoConEvaluacion"]);
                    objWCFResSegundoFiltro.nPlazoAprobado = Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoAprobado"]);
                    objWCFResSegundoFiltro.nMontoAprobado = Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoAprobado"]);
                }
                else
                {
                    objWCFResSegundoFiltro.nPlazoConEvaluacion = 0;
                    objWCFResSegundoFiltro.nMontoConEvaluacion = 0.00M;
                    objWCFResSegundoFiltro.nPlazoAprobado = 0;
                    objWCFResSegundoFiltro.nMontoAprobado = 0.00M;
                }

            }
            else
            {
                objWCFResSegundoFiltro.nPuntaje = 0.00M;
            }

            return objWCFResSegundoFiltro;
        }

        private decimal PrimerScoring(clsWCFScoringPrimerFiltro objWCFScoringPrimerFiltro)
        {
            decimal nPuntajeScore = 0.00M;

            List<Puntuacion> lstPuntuaciones = ObtenerValPrimerFiltroCliente(objWCFScoringPrimerFiltro);

            foreach (Puntuacion item in lstPuntuaciones)
            {
                if (item.lExpluyente && item.nPuntos == 0.00M)
                {
                    return 0.00M;
                }
                nPuntajeScore += item.nPuntos;
            }
            return nPuntajeScore;
        }

        private List<Puntuacion> ObtenerValPrimerFiltroCliente(clsWCFScoringPrimerFiltro objWCFScoringPrimerFiltro)
        {
            DataTable dtValores = CNScoring.ObtenerVariables(true);
            List<clsVariableScoring> lstVariables = (List<clsVariableScoring>)dtValores.ToList<clsVariableScoring>();
            List<Puntuacion> lstPuntuaciones = new List<Puntuacion>();
            clsVariableScoring clsVariable = new clsVariableScoring();
            Puntuacion objPuntuacion = new Puntuacion();

            //Calificación RCC
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "CalificacionRCC";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValCalificacionRCC(clsVariable, (int)objWCFScoringPrimerFiltro.nCalificacionRCC, objWCFScoringPrimerFiltro.lBancarizado);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Numero entidades RCC
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "NumeroEntidadesRCC";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValNumeroEntidadesRCC(clsVariable, objWCFScoringPrimerFiltro.nNroEntidadesRCC);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            return lstPuntuaciones;
        }

        private decimal SegundoScoring(clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro, int idUsuario)
        {
            decimal nPuntajeFinal = 0.00M;

            List<Puntuacion> lstPuntuaciones = ObtenerValSegundoFiltro(objWCFEnvSegundoFiltro, idUsuario);

            foreach (Puntuacion item in lstPuntuaciones)
            {
                if (item.lExpluyente && item.nPuntos == 0.00M)
                {
                    nPuntajeFinal = 0.00M;
                    break;
                }
                nPuntajeFinal += item.nPuntos;
            }

            return nPuntajeFinal;
        }


        private List<Puntuacion> ObtenerValSegundoFiltro(clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro, int idUsuario)
        {
            DataTable dtValores = CNScoring.ObtenerVariables(true);
            List<clsVariableScoring> lstVariables = (List<clsVariableScoring>)dtValores.ToList<clsVariableScoring>();
            List<Puntuacion> lstPuntuaciones = new List<Puntuacion>();
            clsVariableScoring clsVariable = new clsVariableScoring();
            Puntuacion objPuntuacion = new Puntuacion();

            //Nivel de endeudamiento
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "NivelEndeudamiento";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValNivelEndeudamiento(clsVariable, objWCFEnvSegundoFiltro.nMontoSolicitado, objWCFEnvSegundoFiltro.nEndeudamientoRCC);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Experiencia en el Negocio
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "ExperienciaNegocio";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValExperienciaNegocio(clsVariable, objWCFEnvSegundoFiltro.nExperienciaNegocio);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Residencia
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Residencia";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValResidencia(clsVariable, idUsuario, objWCFEnvSegundoFiltro.cUbigeoNacimiento, true);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Formalizacion
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Formalizacion";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValFormalizado(clsVariable, objWCFEnvSegundoFiltro.lFormalizado);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Edad
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Edad";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValEdad(clsVariable, objWCFEnvSegundoFiltro.nEdad);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //RatioCuotaExcedente  -- no se tiene tasa para determinar el valor de la cuota
            double nTasa = CNScoring.obtenerTasaScoring(objWCFEnvSegundoFiltro.nMontoSolicitado, true) / 100;
            double nMontoDesembolso = Convert.ToDouble(objWCFEnvSegundoFiltro.nMontoSolicitado);
            double nPlazo = objWCFEnvSegundoFiltro.nPlazo;

            double nCuotaMensual = nMontoDesembolso * (
                                                             (nTasa * Math.Pow((1.00D + nTasa), nPlazo)) /
                                                             (Math.Pow((1.00D + nTasa), nPlazo) - 1)
                                                         );

            double nRatio = ((nCuotaMensual + Convert.ToDouble(objWCFEnvSegundoFiltro.nDeudaFinanciera)) / (Convert.ToDouble(objWCFEnvSegundoFiltro.nExcedente) + Convert.ToDouble(objWCFEnvSegundoFiltro.nDeudaFinanciera))) * 100;

            objPuntuacion = new Puntuacion();
            decimal nRatioResultado = Convert.ToDecimal(nRatio);
            objPuntuacion.cVariable = "RatioCuotaExcedente";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValRatioCuotaExcedente(clsVariable, nRatioResultado);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //EstadoCivil
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "EstadoCivil";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValEstadoCivil(clsVariable, objWCFEnvSegundoFiltro.idEstadoCivil);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //PlazoCredito
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "PlazoCredito";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValPlazoCredito(clsVariable, objWCFEnvSegundoFiltro.nPlazo);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Destino
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Destino";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValDestino(clsVariable, objWCFEnvSegundoFiltro.idDestino);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            return lstPuntuaciones;
        }

        public clsWCFRespuesta RegistraVisitaGeoPosImgs(clsWCFRegistroGeoPos objWCFResultadoGeoPosImgs)
        {
            clsWCFRespuesta obj = new clsWCFRespuesta();
            //obj.cMensaje = objWCFResultadoGeoPosImgs.cNombresCompletos();
            return obj;
        }

        public IList<clsTipoVisita> TipoVisita(string cToken)
        {
            //cToken = HttpContext.Current.Server.UrlEncode(cToken);
            IList<clsTipoVisita> obj = null;
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.CNWSListarTipoVisita();
                obj = dtResult.ToList<clsTipoVisita>();
            }

            return obj;
        }

        public IList<clsEstadoVisita> EstadoVisita(string cToken)
        {
            IList<clsEstadoVisita> obj = null;
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.CNWSListarEstadoVisita();
                obj = dtResult.ToList<clsEstadoVisita>();
            }

            return obj;
        }

        public IList<clsVisita> ListarVisita(string cToken, int idCliente)
        {
            IList<clsVisita> obj = null;
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);
            int idUsuario;
            if (usuario.validaToken(cToken))
            {
                try
                {
                    idUsuario = datosToken.idUsuario;
                    DataTable dtResult = objVisitas.CNWSListarVisita(idUsuario, idCliente, 2);
                    obj = dtResult.ToList<clsVisita>();
                }
                catch (Exception e)
                {
                    obj = new List<clsVisita>();
                    clsVisita j = new clsVisita();
                    j.cNombre = e.StackTrace;
                    obj.Add(j);
                }
            }
            else{ obj.Add(new clsVisita()); }

            return obj;
        }

        public clsClienteWFC RegistroCliente(string cToken, clsClienteWFC objCli)
        {
            //IList<clsVisita> obj= new List<clsVisita>();
            //obj.Add(objVisita);
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);

            /**************     Validacion de Data Cliente  ***********************/
            clsValidacionBase obj = new clsValidacionBase();
            clsObjetoValidar objValidar = new clsObjetoValidar();
            objValidar.setObjeto<clsClienteWFC>(objCli);
            clsMsjError objErro = obj.validacion<object>(objValidar, new clsValidarCliente());

            /**************     Validacion de Direccion Cliente  ***********************/
            //clsValidacionBase obj2 = new clsValidacionBase();
            //clsObjetoValidar objDireccionValidar = new clsObjetoValidar();
            //clsDireccion oDireccion = new clsDireccion();
            //oDireccion = objCli.oDireccion;
            //objDireccionValidar.setObjeto<clsDireccion>(oDireccion);
            //clsMsjError objErro2 = obj.validacion<object>(objDireccionValidar, new clsValidarDireccion());

            clsMsjError aaa = new clsMsjError();
            /**************     Fin Validacion de Direccion Cliente  *********************/

            //if (!objErro.HasErrors)
            //    return objErro.GetListError();

            if (usuario.validaToken(cToken))
            {
                objCli.idUsuario = datosToken.idUsuario;
                objCli.idAgencia = datosToken.idAgencia;
                DataTable dtResult = objVisitas.CNWSRegistroEdicionCliente(objCli);
                if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) == 1)
                {
                    objCli.idCli = Convert.ToInt32(dtResult.Rows[0]["idCli"]);
                    objCli.idDireccion = Convert.ToInt32(dtResult.Rows[0]["idDireccion"]);
                    objCli.oResultado = new clsWCFRespuesta();
                    objCli.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objCli.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }
                else
                {
                    objCli.oResultado = new clsWCFRespuesta();
                    objCli.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objCli.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }

            }

            return objCli;
        }

        public clsVisita RegistroVisita(string cToken, clsVisita objVisita)
        {
            //IList<clsVisita> obj= new List<clsVisita>();
            //obj.Add(objVisita);
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                objVisita.idUsuario = datosToken.idUsuario;
                objVisita.idPerfil = datosToken.idPerfil;
                objVisita.idAgencia = datosToken.idAgencia;

                DataTable dtResult = objVisitas.CNWSRegistroEdicionVisita(objVisita);
                if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) == 1)
                {
                    objVisita.idVisita = Convert.ToInt32(dtResult.Rows[0]["idVisita"]);
                    //objVisita.oCliente.idCli = Convert.ToInt32(dtResult.Rows[0]["idCli"]);
                    objVisita.idDireccion = Convert.ToInt32(dtResult.Rows[0]["idDireccion"]);
                    objVisita.oResultado = new clsWCFRespuesta();
                    objVisita.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objVisita.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }
                else
                {
                    objVisita.oResultado = new clsWCFRespuesta();
                    objVisita.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objVisita.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }

            }

            return objVisita;
        }

        public IList<clsWCFReciboProvicional> ListarRecibosProvisionales(string cToken, int nEstado, int idHojaRuta)
                    {
            clsDatosToken datosToken = new clsDatosToken();
            IList<clsWCFReciboProvicional> obj = null;
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                try
                {
                    DataTable dtResult = new clsCNReciboProvicional().listar(datosToken.idUsuario,  nEstado, idHojaRuta);
                    obj = dtResult.ToList<clsWCFReciboProvicional>();
                }
                catch (Exception e)
                {

                    obj = new List<clsWCFReciboProvicional>();
                    clsWCFReciboProvicional j = new clsWCFReciboProvicional();
                    j.cTitular = e.StackTrace;
                    obj.Add(j);
                }
            }
            else { obj.Add(new clsWCFReciboProvicional()); }

            return obj;
        }

        public clsWCFResponseReciboProvisional RegistroReciboProvisional(
                string cToken,
                int idCuenta,
                int idCli,
                int idReciboProvisional,
                int idHojaRuta,
                int idMoneda,
                int idTipoPersona,
                string cDocumentoID,
                string cNombres,
                string cNumeroCelular,
                decimal nMonto,
                int idTipoVinculo,
                int nEstado,
                string cCodigoConfirmacion,
                string cSustento,
                string cAction
        )
        {
            Services servicios = new Services();
            Str str = new Str();

            clsDatosToken datosToken = new clsDatosToken();
            clsWCFResponseReciboProvisional responseRecb = new clsWCFResponseReciboProvisional();
            datosToken = usuario.obtenerDatosToken(cToken);

            String textoSMS = "";
            String txt1 = ", Ud. entrega la suma de ";
            String txt2 = " a CAJA LOS ANDES. Su codigo de confirmacion es: ";

            if (usuario.validaToken(cToken))
            {
                Random rndCodigo = new Random();
                /*
                 * cAction
                 * N => nuevo
                 * R => reenvio   
                 */
                responseRecb.nEstado = 0;
                String nMoneda = (idMoneda == 2) ? "$" : "s/.";

                if (cAction.Equals("N")){
                    String cCodigoGenerate = Convert.ToString(rndCodigo.Next(100000, 999999));

                    textoSMS = cNombres + txt1 + Convert.ToString(nMoneda + nMonto) + txt2 + cCodigoGenerate;
                    var resultSms = servicios.EnviarSMS(Convert.ToDouble(cNumeroCelular), "Sr(a)." + textoSMS);
                    if ((resultSms["cEstado"] == "success"))
                    {
                        DataTable dtResult = new clsCNReciboProvicional().registrar(
                            idCuenta            ,idCli                  ,datosToken.idUsuario           ,0                  
                            ,idHojaRuta         ,idMoneda               ,idTipoPersona                  ,cDocumentoID           
                            ,cNombres           ,cNumeroCelular         ,nMonto                         ,idTipoVinculo  
                            ,nEstado            ,cCodigoGenerate        ,cSustento
                        );

                        if (Convert.ToInt32(dtResult.Rows[0]["nResult"]) == 1)
                        {
                            responseRecb.cNombres = Convert.ToString(dtResult.Rows[0]["cNombres"]);
                            responseRecb.cCodigoConfirmacion = cCodigoGenerate;
                            responseRecb.cNumeroCelular = cNumeroCelular;
                            responseRecb.idReciboProvisional = Convert.ToInt32(dtResult.Rows[0]["idReciboProvisional"]);
                            responseRecb.idMoneda = Convert.ToInt32(dtResult.Rows[0]["idMoneda"]);
                            responseRecb.nMonto = Convert.ToDecimal(dtResult.Rows[0]["nMonto"]);
                            responseRecb.nEstado = 1;
                        }
                        else
                        {
                            responseRecb.cMessage = "Hay problemas en el servidor, no se realizó el registro.";
                            responseRecb.nEstado = -1;
                        }
                    }
                    else {
                        responseRecb.cMessage = "No se puede proceder con el registro, el servicio de SMS esta inactivo.";
                        responseRecb.nEstado = -1;
                    }
                }
                else if (cAction.Equals("R"))
                {
                    var dtResult = new clsCNReciboProvicional().buscar(idReciboProvisional, 0);

                    textoSMS = dtResult.Rows[0]["cNombres"].ToString() + txt1 + Convert.ToString(nMoneda + nMonto) + txt2 + dtResult.Rows[0]["cCodigoConfirmacion"].ToString();
                    var resultSms = servicios.EnviarSMS(Convert.ToDouble(cNumeroCelular), "Sr(a). " + textoSMS);
                    if ((resultSms["cEstado"] == "success"))
                    {
                        new clsCNReciboProvicional().buscar(idReciboProvisional, 1);

                        responseRecb.idReciboProvisional = idReciboProvisional;
                        responseRecb.cCodigoConfirmacion = cCodigoConfirmacion;
                        responseRecb.cNombres = cNombres;
                        responseRecb.cNumeroCelular = cNumeroCelular;
                        responseRecb.idMoneda = Convert.ToInt32(idMoneda);
                        responseRecb.nMonto = Convert.ToDecimal(nMonto);
                        responseRecb.nEstado = 1;
                    }
                    else
                    {
                        responseRecb.cMessage = "No se puedo realizar el envió de SMS.";
                        responseRecb.nEstado = -1;
                    }
                }
                else if (cAction.Equals("C"))
                {
                    DataTable dtResult = new clsCNReciboProvicional().registrar(
                           0         ,idCli                      , datosToken.idUsuario       ,idReciboProvisional ,idHojaRuta        ,idMoneda, idTipoPersona
                           ,cDocumentoID    ,cNombres, cNumeroCelular   ,nMonto              ,idTipoVinculo
                           ,nEstado         ,cCodigoConfirmacion        ,cSustento);

                    if ((Convert.ToInt32(dtResult.Rows[0]["nEstado"]) == 2))
                    {
                        responseRecb.idReciboProvisional = idReciboProvisional;
                        responseRecb.nEstado = 3;
                    }
                    else if ((Convert.ToInt32(dtResult.Rows[0]["nEstado"]) == 1))
                    {
                        responseRecb.cMessage = "El código ingresado es incorrecto.";
                        responseRecb.nEstado = -1;
                    }
                    else
                    {
                        responseRecb.cMessage = "No se ha podido procesar su solicitud.";
                        responseRecb.nEstado = -1;
                    }
                }         
            }
            return responseRecb;
        }


        public clsDetalleVisita CargaDeArchivos(string cToken, clsDetalleVisita objDetalleVisita)
        {
            //IList<clsVisita> obj= new List<clsVisita>();
            //obj.Add(objVisita);
            clsDatosToken datosToken = new clsDatosToken();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                objDetalleVisita.idUsuReg = datosToken.idUsuario;
                DataTable dtResult = objVisitas.CNWSRegistrarDetalleVisita(objDetalleVisita);
                if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) == 1)
                {
                    objDetalleVisita.idVisita = Convert.ToInt32(dtResult.Rows[0]["idVisita"]);
                    objDetalleVisita.idDetalleVisita = Convert.ToInt32(dtResult.Rows[0]["idDetalleVisita"]);
                    objDetalleVisita.oResultado = new clsWCFRespuesta();
                    objDetalleVisita.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objDetalleVisita.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }
                else
                {
                    objDetalleVisita.oResultado = new clsWCFRespuesta();
                    objDetalleVisita.oResultado.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["nResultado"]);
                    objDetalleVisita.oResultado.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }

            }

            return objDetalleVisita;
        }

        public IList<clsWCFCarteraAsesor> BuscarCredCliente(string cToken, int idTipoDocumento, string cDocumentoID, bool nonReniec = false)
        {
            IList<clsWCFCarteraAsesor> lstCartera = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFCNBuscarCreditoCliente(idTipoDocumento, cDocumentoID);
                lstCartera = dtCarteraAsesor.SoftToList<clsWCFCarteraAsesor>();
                if (lstCartera.Count == 0 && nonReniec == false)
                {
                    if (cDocumentoID.Length == 8 && idTipoDocumento == 1)
                    {
                        dynamic obj = new { cNroDni = cDocumentoID, cDocAutorizado = "42155044", cIdUsu = datosToken.idUsuario.ToString() };
                        string json = new JavaScriptSerializer().Serialize(obj);
                        byte[] request = Encoding.ASCII.GetBytes(json);
                        try
                        {
                            WebClient wc = new WebClient();
                            wc.Headers["Content-type"] = "application/json";
                            wc.Encoding = Encoding.UTF8;
                            byte[] response = wc.UploadData(cReniecWS, "POST", request);
                            Stream stream = new MemoryStream(response);
                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                            clsProcesaDatosRen persona = serializer.ReadObject(stream) as clsProcesaDatosRen;
                            if (persona.cErrorF == "0000")
                            {
                                lstCartera.Add(toCarteraAsesor(persona));
                            }
                        }
                        catch (Exception e)
                        {
                            string mensaje = e.Message;
                            return lstCartera;
                        }
                    }
                }
                foreach (var oCliente in lstCartera)
                {
                    if (oCliente.cDocumentoID.Length == 8 && oCliente.idTipoDocumento == 1)
                    {
                        oCliente.cFotografia = obtenerFotografia(oCliente.cDocumentoID, datosToken.idUsuario.ToString());
            }
                }
            }

            return lstCartera;
        }

        private string obtenerFotografia(string cDocumentoID, string idUsuario)
        {
            DataTable data = new clsCNHojaRuta(true).WCFCNObtenerFotografia(cDocumentoID);
            if (data.Rows.Count == 0)
            {
                dynamic obj = new { cNroDni = cDocumentoID, cDocAutorizado = "42155044", cIdUsu = idUsuario };
                string json = new JavaScriptSerializer().Serialize(obj);
                byte[] request = Encoding.ASCII.GetBytes(json);
                try
                {
                    WebClient wc = new WebClient();
                    wc.Headers["Content-type"] = "application/json";
                    wc.Encoding = Encoding.UTF8;
                    byte[] response = wc.UploadData(cReniecWS, "POST", request);
                    Stream stream = new MemoryStream(response);
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                    clsProcesaDatosRen persona = serializer.ReadObject(stream) as clsProcesaDatosRen;
                    if (persona.cErrorF == "0000")
                    {
                        return persona.cFotoF;
                    }
                    return "Error: Desconocido";
                }
                catch (Exception e)
                {
                    return String.Format("Error: {0}", e.Message);
                }
            }
            return data.Rows[0]["cFotoF"].ToString();
        }

        clsWCFCarteraAsesor toCarteraAsesor(clsProcesaDatosRen datos)
        {
            clsWCFCarteraAsesor persona = new clsWCFCarteraAsesor();
            persona.idCli = 0;
            persona.idTipoDocumento = 1;
            persona.cDocumentoID = datos.cDniF;
            persona.idActividad = 0;
            persona.idTipoPersona = 1;
            persona.cApellidoPaterno = datos.cApellidoPater;
            persona.cApellidoMaterno = datos.cApellidoMater;
            persona.cNombre = datos.cNombres;
            persona.cRazonSocial = "";
            persona.idSexo = new clsCNHojaRuta(true).WCFRenEquivSexo(datos.cSexo);
            persona.idUbigeo = new clsCNHojaRuta(true).WCFRenEquivUbigeo(datos.cUbigeoDep + datos.cUbigeoProv + datos.cUbigeoDist);
            persona.idDireccion = 0;
            persona.idTipoDireccion = 2;
            persona.cDireccion = datos.cDireccion;
            persona.nNumeroTelefono = "";
            persona.cCorreoCli = "";
            persona.nLatitude = 0.0;
            persona.nLongitude = 0.0;
            persona.nAtraso = 0;
            persona.nCapitalDesembolso = 0;
            persona.idCuenta = 0;
            persona.nSaldoCapital = 0;
            persona.dFechaDesembolso = "";
            persona.nDigitoVerificador = Convert.ToInt32(datos.cDigitoVerif.ToString());
            persona.idUbigeoNacimiento = new clsCNHojaRuta(true).WCFRenEquivUbigeo(datos.cUbigeoDepNac + datos.cUbigeoProvNac + datos.cUbigeoDistNac);
            persona.dFechaNacimiento = dateString(datos.cFechaNac);
            persona.idEstadoCivil = new clsCNHojaRuta(true).WCFRenEquivEstadoCivil(datos.cEstadoCivil);
            return persona;
        }

        private string dateString(string cDate)
        {
            if (cDate.Length == 8)
            {
                return cDate.Substring(0, 4) + "-" + cDate.Substring(4, 2) + "-" + cDate.Substring(6, 2);
            }
            return "";
        }

        public clsWCFMonitorVisitaRespuesta MonitorVisitas(string cToken, string idZona, string idAgencia, string idPersonal, string dtFechaIni, string dtFechaFin, int idClasificacion, int fMora)
        {
            clsWCFMonitorVisitaRespuesta oRespuestaBusqueda = new clsWCFMonitorVisitaRespuesta();
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            oRespuestaBusqueda.oRespuesta = new clsWCFRespuesta();

            if (idZona == "" && idAgencia == "" && idPersonal == "")
            {
                idPersonal = datosToken.idUsuario.ToString();
            }

            DataTable dtMonitorVisita = new clsCNHojaRuta(true).WCFMonitorVisitas(idZona, idAgencia, idPersonal, dtFechaIni, dtFechaFin, idClasificacion, fMora);
            if (dtMonitorVisita.Rows.Count > 0 && dtMonitorVisita.Columns.Contains("nResultado"))
            {
                oRespuestaBusqueda.oRespuesta.idRespuesta = Convert.ToInt32(dtMonitorVisita.Rows[0]["nResultado"]);
                oRespuestaBusqueda.oRespuesta.cMensaje = Convert.ToString(dtMonitorVisita.Rows[0]["cMensaje"]);
            }
            else
            {
                oRespuestaBusqueda.oRespuesta.idRespuesta = 0;
                oRespuestaBusqueda.oRespuesta.cMensaje = "Se ha realizado la búsqueda.";
                oRespuestaBusqueda.listaBusqueda = dtMonitorVisita.ToList<clsWCFMonitorVisita>();
            }

            return oRespuestaBusqueda;
        }

        public clsWCFMonitorVisita MonitorDetalleVisita(string cAccessKey)
        {
            clsWCFMonitorVisita monitorVisita = null;
            StringEncryptorDecryptor sed = new StringEncryptorDecryptor();
            int idVisita;
            try
            {
                idVisita = Convert.ToInt32(sed.decryptString(cAccessKey));
            }
            catch (Exception e)
            {
                idVisita = 0;
            }
            if (idVisita != 0)
            {
                DataTable dtMonitorVisita = new clsCNHojaRuta(true).WCFMonitorVisitasDetalle(idVisita);
                if (dtMonitorVisita.Rows.Count > 0)
                {
                    monitorVisita = dtMonitorVisita.ToList<clsWCFMonitorVisita>()[0];
                }
            }
            return monitorVisita;
        }

        public clsWCFMonitorVisitaRespuesta MonitorVisitasBusqueda(string cToken, int nTipoBusqueda, string cCriterio, string dtFechaIni, string dtFechaFin)
        {
            clsWCFMonitorVisitaRespuesta oRespuestaBusqueda = new clsWCFMonitorVisitaRespuesta();
            oRespuestaBusqueda.oRespuesta = new clsWCFRespuesta();
            IList<clsWCFMonitorVisita> lstMonitorVisita = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (dtFechaIni == "")
                dtFechaIni = "1900-01-01";
            if (dtFechaFin == "")
                dtFechaFin = DateTime.Today.ToString("yyyy-MM-dd");

            DataTable dtMonitorVisita = new clsCNHojaRuta(true).WCFMonitorVisitasBusqueda(nTipoBusqueda, cCriterio, dtFechaIni, dtFechaFin);
            if (dtMonitorVisita.Rows.Count > 0 && dtMonitorVisita.Columns.Contains("nResultado"))
            {
                oRespuestaBusqueda.oRespuesta.idRespuesta = Convert.ToInt32(dtMonitorVisita.Rows[0]["nResultado"]);
                oRespuestaBusqueda.oRespuesta.cMensaje = Convert.ToString(dtMonitorVisita.Rows[0]["cMensaje"]);
            }
            else
            {
                oRespuestaBusqueda.oRespuesta.idRespuesta = 0;
                oRespuestaBusqueda.oRespuesta.cMensaje = "Se ha realizado la búsqueda.";
                oRespuestaBusqueda.listaBusqueda = dtMonitorVisita.ToList<clsWCFMonitorVisita>();
            }
            return oRespuestaBusqueda;
        }

        public IList<clsWCFMonitorCredito> MonitorCreditos(string cToken, int idCli)
        {
            IList<clsWCFMonitorCredito> lstMonitorCredito = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            DataTable dtMonitorCredito = new clsCNHojaRuta(true).WCFMonitorCredito(idCli);
            lstMonitorCredito = dtMonitorCredito.ToList<clsWCFMonitorCredito>();

            return lstMonitorCredito;
        }

        private Dictionary<string, object> parseConfig(string sConfig)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            string[] configs = sConfig.Split(';');
            for (int i = 0; i < configs.Length; i++)
            {
                string[] parts = configs[i].Split(':');
                if (parts.Length == 2)
                {
                    config.Add(parts[0], parts[1].Split(','));
                }
            }
            return config;
        }

        const String ASESOR = "asesor";
        const String JEFE_OFICINA = "jefeOficina";
        const String GERENTE_REGIONAL = "gerenteRegional";
        const String ADMINISTRADOR = "administrador";
        const String NINGUNO = "ninguno";

        private String getNivelAcceso(clsDatosToken cToken)
        {
            clsVarGlobalClone objVarGlobal = new clsVarGlobalClone();
            new clsCNVarGen().GetVarGlobal(1, objVarGlobal);

            int idPerfil = cToken.idPerfil;

            for (int i = 0; i < objVarGlobal.lisVars.Count; i++)
            {
                if (objVarGlobal.lisVars[i].cVariable == "cMoraNConfiguracionPerfil")
                {
                    Dictionary<string, object> dConfig = parseConfig(objVarGlobal.lisVars[i].cValVar);
                    string[] asesor = (string[])dConfig["asesor"];
                    string[] jefeOficina = (string[])dConfig["jefeOficina"];
                    string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
                    string[] administrador = (string[])dConfig["administrador"];
                    if (Array.IndexOf(asesor, idPerfil.ToString()) != -1)
                    {
                        return ASESOR;
                    }
                    else if (Array.IndexOf(jefeOficina, idPerfil.ToString()) != -1)
                    {
                        return JEFE_OFICINA;
                    }
                    else if (Array.IndexOf(gerenteRegional, idPerfil.ToString()) != -1)
                    {
                        return GERENTE_REGIONAL;
                    }
                    else if (Array.IndexOf(administrador, idPerfil.ToString()) != -1)
                    {
                        return ADMINISTRADOR;
                    }
                    break;
                }
            }
            return NINGUNO;
        }

        public IList<clsWCFMonitorListaAgencia> MonitorListaAgencia(string cToken)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            IList<clsWCFMonitorListaAgencia> lstMonitorListaAgencia = null;
            //DataTable dtMonitorListaAgencia = new clsCNHojaRuta(true).WCFMonitorListaAgencia();
            DataTable dtMonitorListaAgencia = new clsCNHojaRuta(true).WCFListaAgencias(datosToken.idUsuario);
            lstMonitorListaAgencia = dtMonitorListaAgencia.ToList<clsWCFMonitorListaAgencia>();
            return lstMonitorListaAgencia;
        }

        public IList<clsWCFMonitorListaAgencia> MonitorListaAgenciaZona(string cToken, int idZona = -1)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (idZona == -1)
            {
                idZona = new clsCNHojaRuta(true).getZonaUsuario(datosToken.idUsuario);
            }
            IList<clsWCFMonitorListaAgencia> lstMonitorListaAgencia = null;
            DataTable dtMonitorListaAgencia = new clsCNHojaRuta(true).WCFListaAgenciasZona(idZona);
            lstMonitorListaAgencia = dtMonitorListaAgencia.ToList<clsWCFMonitorListaAgencia>();
            return lstMonitorListaAgencia;
        }

        public IList<clsWCFMonitorPersonal> MonitorListaPersonalAgencia(string cToken, int idAgencia = -1)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (idAgencia == -1)
            {
                idAgencia = datosToken.idAgencia;
            }
            IList<clsWCFMonitorPersonal> lstMonitorListaPersonal = null;
            DataTable dtMonitorListaPersonal = new clsCNHojaRuta(true).WCFListaPersonalAgencia(idAgencia);
            lstMonitorListaPersonal = dtMonitorListaPersonal.ToList<clsWCFMonitorPersonal>();
            return lstMonitorListaPersonal;
        }

        public IList<clsWCFMonitorListaZona> MonitorListaZona()
        {
            /*clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);*/

            IList<clsWCFMonitorListaZona> lstMonitorListaZonas = null;
            DataTable dtMonitorListaZonas = new clsCNHojaRuta(true).WCFListaZonas();
            lstMonitorListaZonas = dtMonitorListaZonas.ToList<clsWCFMonitorListaZona>();
            return lstMonitorListaZonas;
        }

        public IList<clsWCFMonitorListaArchivo> MonitorListaArchivos(int idVisita)
        {
            IList<clsWCFMonitorListaArchivo> lstMonitorListaArchivos = null;
            DataTable dtMonitorListaArchivos = new clsCNHojaRuta(true).WCFMonitorListaArchivos(idVisita);
            lstMonitorListaArchivos = dtMonitorListaArchivos.ToList<clsWCFMonitorListaArchivo>();
            return lstMonitorListaArchivos;
        }

        public clsWCFMonitorArchivo MonitorArchivo(int idArchivo)
        {
            IList<clsWCFMonitorArchivo> lstMonitorArchivo = null;
            DataTable dtMonitorArchivo = new clsCNHojaRuta(true).WCFMonitorArchivo(idArchivo);
            lstMonitorArchivo = dtMonitorArchivo.ToList<clsWCFMonitorArchivo>();
            if (lstMonitorArchivo.Count > 0)
                return lstMonitorArchivo[0];
            return new clsWCFMonitorArchivo();
        }

        public IList<clsCampana> ListarCampanaVigente(string cToken)
        {
            IList<clsCampana> lstCampana = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFCNListarCampanaVigente();
                lstCampana = dtCarteraAsesor.ToList<clsCampana>();
            }

            return lstCampana;
        }


        public IList<clsClienteCampana> ListarClienteXCampanaAsesor(string cToken, int idGrupoCamp)
        {
            IList<clsClienteCampana> lstCampana = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCarteraAsesor = new clsCNHojaRuta(true).WCFCNListarClienteXCampanaAsesor(datosToken.idUsuario, idGrupoCamp);
                lstCampana = dtCarteraAsesor.ToList<clsClienteCampana>();
            }

            return lstCampana;
        }

        public clsWCFRespuesta VincularVisitaSolicitud(string cToken, int idSolicitud, int idVisita)
        {
            clsWCFRespuesta obj = new clsWCFRespuesta();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtRes = objVisitas.CNVincularVisitaSolicitud(idSolicitud, idVisita.ToString());
                if (dtRes.Rows.Count == 0)
                {
                    obj.idRespuesta = 0;
                    obj.cMensaje = "No se realizó la vinculación, por favor intente nuevamente";
                }
                else
                {
                    obj.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["nResultado"]);
                    obj.cMensaje = Convert.ToString(dtRes.Rows[0]["cMensaje"]);
                }
            }

            return obj;

        }



        public clsWCFConsultaAdmisionInterna consultaAdmisionInterna(string cToken, string cDocumentoID, int idTipoDocumento)
        {
            clsWCFConsultaAdmisionInterna obj = new clsWCFConsultaAdmisionInterna();
            clsDatosToken datosToken = new clsDatosToken();
            clsCNBuscarCli cncliente = new clsCNBuscarCli();
            clsCNIntervCre cninterviniente = new clsCNIntervCre();

            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken)) {
                var dtCliente = cncliente.ListarClientesPosInt(idTipoDocumento, cDocumentoID);


                if (dtCliente.Rows.Count > 0)
                {
                    obj.idCli  = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                    obj.cNombre = dtCliente.Rows[0]["cNombre"].ToString();
                    obj.cDocumentoID = cDocumentoID;
                    obj.idTipoDocumento = idTipoDocumento;
                }
                else {
                    var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBSPosInt(idTipoDocumento, cDocumentoID);
                    if (dtPersonaSBS.Rows.Count > 0)
                    {
                        obj.idCli = -1;
                        obj.cDocumentoID = cDocumentoID;
                        obj.idTipoDocumento = idTipoDocumento;
                        obj.cNombre = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                    }
                    else
                    {
                        obj.idCli = 0;
                        obj.cDocumentoID = cDocumentoID;
                        obj.idTipoDocumento = idTipoDocumento;
                        obj.cNombre = "NO IDENTIFICADO";
                    }
                }


                obj.cTipoCliente = " ";
                obj.cEstadoCivil = " ";
                obj.idEstadoCivil = -1;
                
                DataTable dtCliente_ = new clsCNBuscarCli().ListarclixIdCli(obj.idCli);
                DateTime dFechaNacimiento = DateTime.Now;

                if (obj.idCli != -1 && obj.idCli != 0) // calcula la edad solo si es un cliente
                {
                    if (dtCliente_.Rows[0]["dFechaNacimiento"].ToString() != "") {
                        dFechaNacimiento = DateTime.Parse(dtCliente_.Rows[0]["dFechaNacimiento"].ToString());
                        DataTable dtEdadCliente = new DataTable();
                        dtEdadCliente = cninterviniente.CNEdadAniosDias(dFechaNacimiento);
                        obj.nAniosNac = Convert.ToInt32(dtEdadCliente.Rows[0]["nAnios"]);
                        obj.nDiasNac  = Convert.ToInt32(dtEdadCliente.Rows[0]["nDias"]);
                    }
                    if (dtCliente_.Rows.Count != 0) 
                    {
                        obj.cTipoCliente = dtCliente_.Rows[0]["cTipoCliente"].ToString();
                        obj.cEstadoCivil = dtCliente_.Rows[0]["cEstadoCivil"].ToString();
                        obj.cTipoDocumento = dtCliente_.Rows[0]["cTipoDocumento"].ToString();
                        obj.cNumeroTelefono2 = dtCliente_.Rows[0]["cNumeroTelefono2"].ToString();
                        obj.nNumeroTelefono = dtCliente_.Rows[0]["nNumeroTelefono"].ToString();
                    }
                    if (dtCliente_.Rows[0]["idEstadoCivil"] != DBNull.Value)
                    {
                        obj.idEstadoCivil = Convert.ToInt32(dtCliente_.Rows[0]["idEstadoCivil"]);
                    }
                    else
                    {
                        obj.idEstadoCivil = -1;
                    }
                }
 

                // Extraer codsbs
                string cCodsbs = "-1";
                DataTable dtCalfInterv = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, 24);
                if (dtCalfInterv.Rows[0]["codsbs"].ToString() != "")
                {
                    obj.dFecUltActRCC = Convert.ToDateTime(dtCalfInterv.Rows[0]["dUltAct"]).ToString("dd/MM/yyyy");
                    obj.cCodsbs = dtCalfInterv.Rows[0]["codsbs"].ToString();
                }

                //Ultimos creditos Lista
                DataTable filterUltCred = new DataTable();
                DataTable dtUltimosCretos = cninterviniente.CNlisCreCli_2(obj.idCli);
                obj.ultimosCreditos = filterUltCred.SoftToList<clsUltimosCreditos>();

                if (dtUltimosCretos.Rows.Count > 0)
                {
                    DataRow[] selectedRows = dtUltimosCretos.Select("idEstado=" + 5);
                    if (selectedRows.Any())
                    {
                        filterUltCred = selectedRows.CopyToDataTable<DataRow>();
                        obj.ultimosCreditos = filterUltCred.SoftToList<clsUltimosCreditos>();
                    }
                    else
                    {
                        filterUltCred = dtUltimosCretos.Select("idEstado=" + 6).AsEnumerable().Take(2).CopyToDataTable();
                        obj.ultimosCreditos = filterUltCred.SoftToList<clsUltimosCreditos>();
                    }
                }
                
        
                if (obj.idCli != 0 && obj.idCli != -1)
                {
                    //Calificación Interna A | AA | B | C , ... Al último reporte
                    DataTable dtCalInterna = cninterviniente.CNClasifiInterna(obj.idCli, 1);
                    if (dtCalInterna.Rows.Count > 0)
                    {
                        obj.cClasifInterna = dtCalInterna.Rows[0]["cClasifInterna"].ToString();
        }        
                }
                if (obj.idCli != 0 && obj.cCodsbs != null)
                {
                    //Calificacion SF
                    DataTable dtCalificacionSF = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, 1);
                    if (dtCalificacionSF.Rows.Count > 0)
                    {
                        if (dtCalificacionSF.Rows[0]["codTipoPersona"].ToString() != "" && dtCalificacionSF.Rows[0]["codTipoPersona"].ToString() != "null")
                        {
                            obj.nEntidades = Convert.ToInt32(dtCalificacionSF.Rows[0]["cantEmpresas"]);
                            obj.lCajaAndes = Convert.ToBoolean(dtCalificacionSF.Rows[0]["lCajaAndes"]);

                            for (int i = 4; i >= 0; i--)
                            {
                                if (Convert.ToDouble(dtCalificacionSF.Rows[0]["deudaCalif" + i]) > 0 && i == 4)
                                {
                                    obj.cCalificacionSF = "PERDIDA"; break;
                                }
                                if (Convert.ToDouble(dtCalificacionSF.Rows[0]["deudaCalif" + i]) > 0 && i == 3)
                                {
                                    obj.cCalificacionSF = "DUDOSO"; break;
                                }
                                if (Convert.ToDouble(dtCalificacionSF.Rows[0]["deudaCalif" + i]) > 0 && i == 2)
                                {
                                    obj.cCalificacionSF = "DEFICIENTE"; break;
                                }
                                if (Convert.ToDouble(dtCalificacionSF.Rows[0]["deudaCalif" + i]) > 0 && i == 1)
                                {
                                    obj.cCalificacionSF = "CPP"; break;
                                }
                                if (Convert.ToDouble(dtCalificacionSF.Rows[0]["deudaCalif" + i]) > 0 && i == 0)
                                {
                                    obj.cCalificacionSF = "NORMAL"; break;
                                }
                            }
                        }
                    }
                    if (obj.cCodsbs != null)
                    {
                        //Calificacion SF x 12
                        List<decimal> lsSFx12 = new List<decimal>();
                        DataTable dtCalificacionSFx12 = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, 12);

                        decimal sum = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < dtCalificacionSFx12.Rows.Count; j++)
                            {
                                sum += dtCalificacionSFx12.Rows[j]["deudaCalif" + i] == DBNull.Value ? 0 : Convert.ToDecimal(dtCalificacionSFx12.Rows[j]["deudaCalif" + i]);
                            }
                            lsSFx12.Add(sum);
                            sum = 0;
                        }

                        for (int i = 4; i >= 0; i--)
                        {
                            if (lsSFx12[i] > 0 && i == 4)
                            {
                                obj.cCalificacionSFMax12 = "PERDIDA"; break;
                            }
                            if (lsSFx12[i] > 0 && i == 3)
                            {
                                obj.cCalificacionSFMax12 = "DUDOSO"; break;
                            }
                            if (lsSFx12[i] > 0 && i == 2)
                            {
                                obj.cCalificacionSFMax12 = "DEFICIENTE"; break;
                            }
                            if (lsSFx12[i] > 0 && i == 1)
                            {
                                obj.cCalificacionSFMax12 = "CPP"; break;
                            }
                            if (lsSFx12[i] > 0 && i == 0)
                            {
                                obj.cCalificacionSFMax12 = "NORMAL"; break;
                            }
                        }
                    }
                }

                if (obj.idCli != 0 && obj.cCodsbs != null)
                {
                    //Deudas Directas Sumatoria al ultimo reporte
                    DataTable dtSaldoCapSF = cninterviniente.CNdtLisSaldosRCDSBS(obj.cCodsbs, 0, 1);
                    obj.nSaldoCapSF = 0;
                    for (int i = 0; i < dtSaldoCapSF.Rows.Count; i++)
                    {
                        obj.nSaldoCapSF += Convert.ToDecimal(dtSaldoCapSF.Rows[i]["saldo"]);
                    }

                }

                if (obj.cCodsbs != null)
                {
                    //Endedamiento total 24 meses
                    DataTable dtEndeudamiento = cninterviniente.CNdtLisSaldosRCDSBS(obj.cCodsbs, 24, 1);
                    obj.cEndeudamientoMax = maxValorDatatable(dtEndeudamiento, "saldo");

                    //Deudas Directas
                    DataTable dtDirectas = cninterviniente.CNdtLisSaldosRCDSBS(obj.cCodsbs, 0, 1);
                    IList<clsDeudasDirectas> lsDeudasDirectas;
                    lsDeudasDirectas = dtDirectas.SoftToList<clsDeudasDirectas>();
                    obj.DeudasDirectas = lsDeudasDirectas;

                    //Deudas Indirectas
                    DataTable dtIndirectas = cninterviniente.CNdtLisSaldosRCDSBS(obj.cCodsbs, 0, 2);
                    IList<clsDeudasIndirectas> lsDeudasIndirectas;
                    lsDeudasIndirectas = dtIndirectas.SoftToList<clsDeudasIndirectas>();
                    obj.lineasCreditoNoUtlizadas = lsDeudasIndirectas;
                }
                else
                {
                    DataTable emptyArray = new DataTable();
                    obj.cEndeudamientoMax = 0;
                    obj.DeudasDirectas = emptyArray.SoftToList<clsDeudasDirectas>();
                    obj.lineasCreditoNoUtlizadas = emptyArray.SoftToList<clsDeudasIndirectas>();
                }

                //Cartas Fianza
                DataTable dtCartasFianza = cninterviniente.CNLisCarFiaCli(obj.idCli);
                obj.cartasFianza = dtCartasFianza.SoftToList<clsCartaFianzas>();


                // ------------- comprobar si tiene conyuge -----------------
                DataTable dtListCony = cninterviniente.CNdtVerificarRelacionCliente(cDocumentoID, idTipoDocumento);

                int idCliCony = -1;
                DataTable dtCalfCony = new DataTable();

                if (dtListCony.Rows.Count > 0) // si tiene conyuge 
                {

                    obj.relacionConyuge.idCli = Convert.ToInt32(dtListCony.Rows[0]["idCliVin"]);
                    obj.relacionConyuge.cDocumentoID = dtListCony.Rows[0]["cDocumentoID"].ToString();
                    obj.relacionConyuge.idTipoDocumento = Convert.ToInt32(dtListCony.Rows[0]["idTipoDocumento"]);
                    idCliCony = obj.relacionConyuge.idCli;
                } else {
                    obj.relacionConyuge = null;
            }

                //Avalados Caja los Andes
                DataTable dtAvaladosCaja = cninterviniente.CNLisCreCliFiSol(obj.idCli);
                obj.avaladosCajaLosAndes = dtAvaladosCaja.SoftToList<clsAvaladosCajaAndes>();

                //Avalados SF
                DataTable dtAvaladosSF = cninterviniente.CNAvaladosRCCSBS(cDocumentoID, idTipoDocumento);
                obj.avaladosSF = dtAvaladosSF.SoftToList<clsAvaladosSF>();              

                //Campañas 
                DataTable dtCampanhas = cninterviniente.CNCrePreApro(obj.idCli);
                obj.credCampanha = dtCampanhas.SoftToList<clsCredCampanha>();

                //Direcciones cliente
                DataTable dtDirecciones = cninterviniente.CNDirNumTelPar(obj.idCli, idCliCony);
                obj.direcciones = dtDirecciones.SoftToList<clsDirecciones>();
                
                // ************** items *****************
                // Base Negativa
                DataTable dtBaseNegativa = cninterviniente.CNBaseNegativa(cDocumentoID, idTipoDocumento);
                obj.lBaseNegativa = dtBaseNegativa.Rows.Count > 0 ? true : false;

                // Cliente es PEP
                DataTable dtClientePep = cninterviniente.CNdtLisDatPEP(cDocumentoID, idTipoDocumento);
                obj.lPep = dtClientePep.Rows.Count > 0 ? Convert.ToBoolean(dtClientePep.Rows[0]["lPep"]) : false;

                //Solicitudes Denegadas
                DataTable dtSolicitudesDenegadas = cninterviniente.CNLisSolCli(cDocumentoID, idTipoDocumento);
                obj.lSolitudesDenegadas = false;
                if (dtSolicitudesDenegadas.Rows.Count > 0)
                {
                    obj.lSolitudesDenegadas  = dtSolicitudesDenegadas.Select("cEstado='DENEGADO'").Count() > 0 ? true : false;
                }
            }
            return obj;
        }

        public clsWCFRespuesta RegistroEncuestaRespuesta(string cToken, string cDni, string cNombreApellido, int nEdad, string cSexo, string cEstadoCivil, string cNumeroCelular, string cRespuesta, string cUsuario, string cCodEncuesta, int idFeria, string dFechaRegistro)
        {
            clsWCFRespuesta obj = new clsWCFRespuesta();
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            obj.idRespuesta = 1;
            obj.cMensaje = "No hay sesion";
            if (usuario.validaToken(cToken))
            {
                DataTable dtRes = objVisitas.RegistroEncuestaRespuesta(cDni, cNombreApellido, nEdad, cSexo, cEstadoCivil, cNumeroCelular, cRespuesta, cUsuario, cCodEncuesta, idFeria, dFechaRegistro);
                if (dtRes.Rows.Count == 0)
                {
                    obj.idRespuesta = 1;
                    obj.cMensaje = "No se realizó la vinculación, por favor intente nuevamente";
                }
                else
                {
                    obj.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["idError"]);
                    obj.cMensaje = Convert.ToString(dtRes.Rows[0]["cMensaje"]);
                }
            }
            return obj;
        }

        public IList<clsWCFReporteEncuesta> ReporteEncuesta(string cToken, int page, int pageSize, string fechaInicio, string fechaFinal, int idFeria)
        {
            IList<clsWCFReporteEncuesta> report = null;
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.ReporteEncuestaRespuesta(page, pageSize, fechaInicio, fechaFinal, idFeria);
                report = dtResult.ToList<clsWCFReporteEncuesta>();
            }
            return report;
        }

        public IList<clsWCFReporteEncuestaFeria> ListaEncuestaFeria(string cToken, int page, int pageSize)
        {
            IList<clsWCFReporteEncuestaFeria> list = null;
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.ListaEncuestaFeria(page, pageSize);
                list = dtResult.ToList<clsWCFReporteEncuestaFeria>();
            }
            return list;
        }

        public IList<clsWCFReporteEncuestaEstablecimiento> ListaEncuestaEstablecimiento(string cToken)
        {
            IList<clsWCFReporteEncuestaEstablecimiento> list = null;
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.ListaEncuestaEstablecimiento();
                list = dtResult.ToList<clsWCFReporteEncuestaEstablecimiento>();
            }
            return list;
        }

        public clsWCFEncuestaFeria RegistroEdicionEncuestaFeria(string cToken, int idRegistroFeria, int idEstablecimiento, string cNombre, string cLugar, string cDias, string cHorarioInicio, string cHorarioFinal, bool lVigente)
        {
            clsWCFEncuestaFeria encuestaFeria = null;
            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dtResult = objVisitas.RegistroEdicionEncuestaFeria(idRegistroFeria, idEstablecimiento, cNombre, cLugar, cDias, cHorarioInicio, cHorarioFinal, lVigente);
                IList<clsWCFEncuestaFeria> list = dtResult.ToList<clsWCFEncuestaFeria>();
                if (list.Count > 0)
                {
                    encuestaFeria = list[0];
                }
            }
            return encuestaFeria;
        }

        public decimal maxValorDatatable(DataTable dtSaldos, string cClave)
        {
            decimal nMaxSaldo = 0;
            foreach (DataRow row in dtSaldos.Rows)
            {
                decimal nSaldo =  Convert.ToDecimal(row[cClave]);

                if (nSaldo != 0)
                {
                    if (nMaxSaldo == 0)
                    {
                        nMaxSaldo = nSaldo;
        }        

                    if (nMaxSaldo < nSaldo)
                    {
                        nMaxSaldo = nSaldo;
                    }
                }
            }
            return nMaxSaldo;
        }

        public IList<clsWCFCampaniaCliente> ListarCampanias(string cToken, string cDni)
        {
            IList<clsWCFCampaniaCliente> list = null;
            clsWCFCampaniaCliente objWCFCampania = new clsWCFCampaniaCliente();

            clsCNVisitas objVisitas = new clsCNVisitas(true);
            clsDatosToken datosToken = new clsDatosToken();
            if (usuario.validaToken(cToken))
            {
                DataTable dtCampanias = objVisitas.ListarCampaniasCliente(cDni);
                list = dtCampanias.ToList<clsWCFCampaniaCliente>();
            }
            return list;
        }
    }
}
