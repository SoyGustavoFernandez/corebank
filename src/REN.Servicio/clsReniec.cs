#region Referencias
using System;
using System.Text;
using EntityLayer;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using GEN.CapaNegocio;
using System.Data;
using EntityLayer.Bus.Response;
using Newtonsoft.Json;
using EntityLayer.Bus.Reniec;
using System.Globalization;
#endregion

namespace CLI.Servicio
{
    public class clsReniec
    {
        #region Variables

        private clsCliParamEnvioReniec objParam;
        private clsConfReniec objConf;
        private string cUrlReniecBus = string.Empty;
        private string cDocumentoAutorizado;
        public clsResponseBus objRespuesta;

        #endregion

        #region Constructores
        public clsReniec()
        {
            this.objParam = null;
            this.objConf = null;
        }

        public clsReniec(clsCliParamEnvioReniec _obj, clsConfReniec _objConf)
        {
            this.objParam = _obj;
            this.objConf = _objConf;
            ObtenerDniAut();
        }

        public clsReniec(clsCliParamEnvioReniec _obj, string cUrlBus)
        {
            this.objParam = _obj;
            this.cUrlReniecBus = cUrlBus;
            ObtenerDniAut();
        }
        #endregion

        #region Metodos

        public void setClsCliParamEnvioReniec(clsCliParamEnvioReniec _obj)
        {
            this.objParam = _obj;
        }

        public void SetUrlReniecBus(string cUrl)
        {
            this.cUrlReniecBus = cUrl;
        }

        public clsDatosReniecBus GetReniecBus(int idTipoDocumento, string cDocumentoID, int idUsuario)
        {
            this.objRespuesta = null;
            string urlWithParams = this.cUrlReniecBus + "?nTipoDocumentoID=" + idTipoDocumento + "&cDocumentoID=" + cDocumentoID + "&idUsuario=" + idUsuario;
            using (WebClient objWebClient = new WebClient())
                try
                {
                    objWebClient.Headers["Content-type"] = "application/json";
                    objWebClient.Encoding = Encoding.UTF8;
                    string cJsonResponse = objWebClient.DownloadString(urlWithParams);
                    var settings = new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy",
                        Culture = CultureInfo.InvariantCulture
                    };
                    clsResponseBus objRespBus = JsonConvert.DeserializeObject<clsResponseBus>(cJsonResponse, settings);
                    this.objRespuesta = objRespBus;
                    if (objRespBus.success == 1)
                    {
                        return new clsDatosReniecBus()
                        {
                            cApellidoCasados = objRespBus.data.cApellidoCasados,
                            cApellidoMaterno = objRespBus.data.cApellidoMaterno,
                            cApellidoPaterno = objRespBus.data.cApellidoPaterno,
                            cNombre1 = objRespBus.data.cNombre1,
                            cNombre2 = objRespBus.data.cNombre2,
                            cNombre3 = objRespBus.data.cNombre3,
                            idUsuario = objRespBus.data.idUsuario,
                            cDNI = objRespBus.data.cDNI,
                            idSexo = objRespBus.data.idSexo,
                            idEstadoCivil = objRespBus.data.idEstadoCivil,
                            idNivelInstruccion = objRespBus.data.idNivelInstruccion,
                            dFechaNacimiento = objRespBus.data.dFechaNacimiento,
                            idUbigeoNacimiento = objRespBus.data.idUbigeoNacimiento,
                            idPaisNacimiento = objRespBus.data.idPaisNacimiento,
                            cPaisNacimiento = objRespBus.data.cPaisNacimiento,
                            idDepartamentoNacimiento = objRespBus.data.idDepartamentoNacimiento,
                            cDepartamentoNacimiento = objRespBus.data.cDepartamentoNacimiento,
                            idProvinciaNacimiento = objRespBus.data.idProvinciaNacimiento,
                            cProvinciaNacimiento = objRespBus.data.cProvinciaNacimiento,
                            idDistritoNacimiento = objRespBus.data.idDistritoNacimiento,
                            cDistritoNacimiento = objRespBus.data.cDistritoNacimiento,
                            idAnexoNacimiento = objRespBus.data.idAnexoNacimiento,
                            cAnexoNacimiento = objRespBus.data.cAnexoNacimiento,
                            idUbigeoDireccion = objRespBus.data.idUbigeoDireccion,
                            idPaisDomicilio = objRespBus.data.idPaisDomicilio,
                            cPaisDomicilio = objRespBus.data.cPaisDomicilio,
                            idDepartamentoDomicilio = objRespBus.data.idDepartamentoDomicilio,
                            cDepartamentoDomicilio = objRespBus.data.cDepartamentoDomicilio,
                            idProvinciaDomicilio = objRespBus.data.idProvinciaDomicilio,
                            cProvinciaDomicilio = objRespBus.data.cProvinciaDomicilio,
                            idDistritoDomicilio = objRespBus.data.idDistritoDomicilio,
                            cDistritoDomicilio = objRespBus.data.cDistritoDomicilio,
                            idAnexoDomicilio = objRespBus.data.idAnexoDomicilio,
                            cAnexoDomicilio = objRespBus.data.cAnexoDomicilio,
                            idZona = objRespBus.data.idZona,
                            idVia = objRespBus.data.idVia,
                            cUrbanizacion = objRespBus.data.cUrbanizacion,
                            cManzana = objRespBus.data.cManzana,
                            cLote = objRespBus.data.cLote,
                            cEtapa = objRespBus.data.cEtapa,
                            cDireccion = objRespBus.data.cDireccion,
                            cRestriccion = objRespBus.data.cRestriccion,
                            dFechaInscripcion = objRespBus.data.dFechaInscripcion,
                            dFechaEmision = objRespBus.data.dFechaEmision,
                            cDigitoVerificador = objRespBus.data.cDigitoVerificador,
                            cFoto = objRespBus.data.cFoto,
                            cFotoHTMLEscapado = objRespBus.data.cFotoHTMLEscapado
                        };
                    }
                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
        }

        public clsProcesaDatosRen GetReniec()
        {
            string cConsultaWCF,
                    cServicio;
            byte[] nBytesConsulta,
                    nRespuesta;

            if (this.objParam == null)
            {
                return null;
            }

            if (this.objConf == null)
            {
                return null;
            }


            cConsultaWCF = this.cConstruirConsulta();

            cServicio = this.objConf.cURLServicio;

            nBytesConsulta = Encoding.ASCII.GetBytes(cConsultaWCF);

            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            string serviceURL = string.Format(cServicio + "/ConsultaIndInfPerReniec", cConsultaWCF);

            try
            {
                nRespuesta = webClient.UploadData(serviceURL, "POST", nBytesConsulta);
                Stream stream = new MemoryStream(nRespuesta);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                clsProcesaDatosRen resultPersona = obj.ReadObject(stream) as clsProcesaDatosRen;
                return resultPersona;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public clsProcesaDatosRen GetReniec(int idConsultaDirecta)
        {
            string cConsultaWCF,
                    cServicio;
            byte[] nBytesConsulta,
                    nRespuesta;

            if (this.objParam == null)
            {
                return null;
            }

            if (this.objConf == null)
            {
                return null;
            }


            cConsultaWCF = this.cConstruirConsultaDirecta(idConsultaDirecta);

            cServicio = this.objConf.cURLServicio;

            nBytesConsulta = Encoding.ASCII.GetBytes(cConsultaWCF);

            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            string serviceURL = string.Format(cServicio + "/ConsultaIndInfPerReniecDirecta", cConsultaWCF);

            try
            {
                nRespuesta = webClient.UploadData(serviceURL, "POST", nBytesConsulta);
                Stream stream = new MemoryStream(nRespuesta);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                clsProcesaDatosRen resultPersona = obj.ReadObject(stream) as clsProcesaDatosRen;
                return resultPersona;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        private string cConstruirConsulta()
        {
            return "{\"cNroDni\":\"" + objParam.cDocumentoID + "\",\"cDocAutorizado\":\"" + this.cDocumentoAutorizado + "\",\"cIdUsu\":\"" + objParam.idUsuario.ToString() + "\"}";
        }

        private string cConstruirConsultaDirecta(int idConsultaDirecta)
        {
            string cIdConsultaDirecta = Convert.ToString(idConsultaDirecta);

            return "{\"cNroDni\":\"" + objParam.cDocumentoID + "\",\"cDocAutorizado\":\"" + this.cDocumentoAutorizado + "\",\"cIdUsu\":\"" + objParam.idUsuario.ToString() + "\",\"cIdConsultaDirecta\":\"" + cIdConsultaDirecta + "\"}";
        }

        private void ObtenerDniAut()
        {
            clsCNConsultaDatos ConsultaDNI = new clsCNConsultaDatos();
            DataTable dtDniAut = ConsultaDNI.CNConsultaDatosDniAut(Convert.ToInt32(objParam.idModulo));
            this.cDocumentoAutorizado = dtDniAut.Rows[0]["cDocumentoID"].ToString();
        }

        #endregion
    }
}
