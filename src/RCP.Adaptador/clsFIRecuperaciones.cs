using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RCP.Contratos;
using EntityLayer;
using System.Collections;
using SolIntEls.GEN.Helper;
using GEN.CapaNegocio;
using System.Data;
using RCP.CapaNegocio;

namespace RCP.Adaptador
{
    public partial class clsFARecuperaciones : IRecuperaciones
    {
        clsCNUsuarioSistema cnUsuario = new clsCNUsuarioSistema();
        string cRespuestaXML;
        string cPlantillaRpta =
                  "<?xml version=\"1.0\" encoding=\"UTF-8\" ?> " +
                    "<resultado><respuesta><idEstado>{0}</idEstado><idError>{1}</idError>" +
                        "<cMensaje>{2}</cMensaje><cToken>{3}</cToken></respuesta>" +
                    "<data>{4}</data></resultado>";
        
        public string WSListaHojasRuta(string cToken, DateTime dDesde, DateTime dA)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);
            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsHojasRuta = new DataSet("dsHojasRuta");
                DataTable dtHojasRuta = new clsCNHojaRuta().ListaHojasRuta(datosToken.idUsuario, dDesde, dA);
                dtHojasRuta.TableName = "dtHojasRuta";
                dsHojasRuta.Tables.Add(dtHojasRuta);
                xmlData = dsHojasRuta.GetXml();
                dsHojasRuta.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiró.",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSObtenerCreditosHojaRuta(string cToken, int idHojaRuta)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsCreditos = new DataSet("dsCreditos");
                DataTable dtCreditos = new clsCNHojaRuta().obtenerCreditosHojaRuta(idHojaRuta);
                dtCreditos.TableName = "dtCreditos";
                dsCreditos.Tables.Add(dtCreditos);
                xmlData = dsCreditos.GetXml();
                dsCreditos.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiró.",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSListaCarteraRecuperaciones(string cToken, int idPerfil, int idUbigeo, int nAtrazoMin, 
                                                int nAtrazoMax, Decimal nSaldoCapitalMin, Decimal nSaldoCapitalMax, 
                                                bool lSoloDirPrincipal, int nTipoInterviniente)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsCreditos = new DataSet("dsCreditos");
                DataTable dtCreditos = new clsCNHojaRuta().listaCarteraRecuperaciones(datosToken.idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, lSoloDirPrincipal, nTipoInterviniente, idPerfil);
                dtCreditos.TableName = "dtCreditos";
                dsCreditos.Tables.Add(dtCreditos);
                xmlData = dsCreditos.GetXml();
                dsCreditos.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiro",
                                                    String.Empty, String.Empty);
            }
 
            return cRespuestaXML;
        }

        public string WSAgregarCreditoHojaRuta(string cToken, int idHojaRuta, int idCuenta, int idInter,
                                                int idDirecion, int idTipoAccion, bool lDireccionRecupera)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataTable dtResultado = new clsCNHojaRuta().agregarCreditoHojaRuta(idHojaRuta, idCuenta, idInter, idDirecion, idTipoAccion, 0, datosToken.dFechaSistema, lDireccionRecupera);
                if (dtResultado.Rows.Count > 0)
                {
                    cRespuestaXML = String.Format(cPlantillaRpta, 200, dtResultado.Rows[0][0].ToString(), 
                                                dtResultado.Rows[0][1].ToString(), String.Empty, String.Empty);
                }
                else
                {
                    cRespuestaXML = String.Format(cPlantillaRpta, 500, dtResultado.Rows[0][0].ToString(),
                                                "Error al procesar la solicitud.", String.Empty, String.Empty);
                }
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiró.",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSRegistrarGestionHojaRuta(string cToken, int idDetalleHojaRuta, int idResultado, int idMotivoMora, 
                                                int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa, 
                                                Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita, 
                                                string cObservacionVisita, string nLatitud, string nLongitud, DateTime dFechaRegCliente,
                                                bool lDomVerificado, bool lNotificacionEntregada)
        {
            if (string.IsNullOrEmpty(cObservacionPromesa))
            {
                cObservacionPromesa = "";
            }
            if (string.IsNullOrEmpty(cObservacionVisita))
            {
                cObservacionVisita = "";
            }


            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                //decimal? nLat = null;
                //decimal? nLong = null;

                //decimal nLatOut = 0M;
                //decimal nLonOut = 0M;

                //nLat = !decimal.TryParse(nLatitud, out nLatOut) ? null : (decimal?)nLatOut;
                //nLong = !decimal.TryParse(nLongitud, out nLonOut) ? null : (decimal?)nLonOut;
                //DataTable dtResultado = new clsCNHojaRuta().registrarGestionHojaRutaMovil(idDetalleHojaRuta, idResultado, idMotivoMora, 
                //                                                            idTipoCliente, lRecuperable, cObservacion, dFechaPromesa, 
                //                                                            nMontoPromesa, cObservacionPromesa, lVisitar, dFechaVisita,
                //                                                            cObservacionVisita, nLat, nLong,
                //                                                            dFechaRegCliente, lDomVerificado, lNotificacionEntregada);
                //if (dtResultado.Rows.Count > 0)
                //{
                //    cRespuestaXML = String.Format(cPlantillaRpta, 200, dtResultado.Rows[0][0].ToString(),
                //                                dtResultado.Rows[0][1].ToString(), String.Empty, String.Empty);
                //}
                //else
                //{
                //    cRespuestaXML = String.Format(cPlantillaRpta, 500, dtResultado.Rows[0][0].ToString(),
                //                                "Error al procesar la solicitud.", String.Empty, String.Empty);
                //}                             
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiró.",
                                                    String.Empty, String.Empty);              
            }

            return cRespuestaXML;
        }

        public string WSFinalizarGestionHojaRuta(string cToken, int idHojaRuta, int nKilometrajeFinal)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataTable dtResultado = new clsCNHojaRuta().finalizarGestionHojaRuta(idHojaRuta, nKilometrajeFinal);

                if (dtResultado.Rows.Count > 0)
                {
                    cRespuestaXML = String.Format(cPlantillaRpta, 200, dtResultado.Rows[0][0].ToString(),
                                                dtResultado.Rows[0][1].ToString(), String.Empty, String.Empty);
                }
                else
                {
                    cRespuestaXML = String.Format(cPlantillaRpta, 500, dtResultado.Rows[0][0].ToString(),
                                                "Error al procesar la solicitud.", String.Empty, String.Empty);
                }
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiró.",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSListarTipoAccion(string cToken)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsAcciones = new DataSet("dsAcciones");
                DataTable dtAcciones = new clsCNAccion().ListarAccionesPorPerfil(datosToken.idPerfil);
                dtAcciones.TableName = "dtAcciones";
                dsAcciones.Tables.Add(dtAcciones);
                xmlData = dsAcciones.GetXml();
                dsAcciones.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiro",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSListarTipoResultados(string cToken)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsResultados = new DataSet("dsResultados");
                DataTable dtResultados = new clsCNTipoResultado().Lista();
                dtResultados.TableName = "dtResultados";
                dsResultados.Tables.Add(dtResultados);
                xmlData = dsResultados.GetXml();
                dsResultados.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiro",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSListarTipoClientes(string cToken)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsTipoClientes = new DataSet("dsTipoClientes");
                DataTable dtTipoClientes = new clsCNTipoCliente().ListaPorModulo(13);
                dtTipoClientes.TableName = "dtTipoClientes";
                dsTipoClientes.Tables.Add(dtTipoClientes);
                xmlData = dsTipoClientes.GetXml();
                dsTipoClientes.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiro",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        public string WSListarMotivoMora(string cToken)
        {
            string xmlData = String.Empty;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = cnUsuario.obtenerDatosToken(cToken);

            if (!ValidarAgenciaPerfil(datosToken))
            {
                return cRespuestaXML;
            }

            if (cnUsuario.validaToken(cToken))
            {
                DataSet dsMotivoMora = new DataSet("dsTipoClientes");
                DataTable dtMotivoMora = new clsCNMotivoMora().Lista();
                dtMotivoMora.TableName = "dtMotivoMora";
                dsMotivoMora.Tables.Add(dtMotivoMora);
                xmlData = dsMotivoMora.GetXml();
                dsMotivoMora.Tables.Clear();

                cRespuestaXML = String.Format(cPlantillaRpta, 200, 0, String.Empty, String.Empty, xmlData);
            }
            else
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido o expiro",
                                                    String.Empty, String.Empty);
            }

            return cRespuestaXML;
        }

        private bool ValidarAgenciaPerfil(clsDatosToken datosToken)
        {
            if (datosToken == null)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "Token inválido.",
                                                    String.Empty, String.Empty);
                return false;
            }

            if (datosToken.idAgencia == 0)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "La agencia de la sesión no fue asignada.",
                                                    String.Empty, String.Empty);
                return false;
            }

            if (datosToken.idPerfil == 0)
            {
                cRespuestaXML = String.Format(cPlantillaRpta, 401, -1, "El perfil de la sesión no fue asignado.",
                                                    String.Empty, String.Empty);
                return false;
            }
            return true;
        }

    }
}