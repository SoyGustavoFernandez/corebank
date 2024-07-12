#region Referencias
using EntityLayer.Bus.Reniec;
using EntityLayer.Bus.Response;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Text;
#endregion

namespace REN.Servicio
{
    public class clsSunat
    {
        #region Variables
        private string cUrlSunatBus = string.Empty;
        public clsResponseBus objResp;
        #endregion

        #region Metodos
        public clsSunat(string cUrlBus)
        {
            this.cUrlSunatBus = cUrlBus;
        }

        public void SetUrlSunatBus(string cUrl)
        {
            this.cUrlSunatBus = cUrl;
        }

        public clsDatosSunatBus GetSunatBus(int idTipoDocumento, string cDocumentoID)
        {
            this.objResp = null;
            string urlWithParams = this.cUrlSunatBus + "?idTipoDocumento=" + idTipoDocumento + "&cDocumentoID=" + cDocumentoID;
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
                    this.objResp = objRespBus;
                    if (objRespBus.success == 1)
                    {
                        return new clsDatosSunatBus()
                        {
                            dFechaConsulta = DateTime.Now,
                            cNumeroRuc = objRespBus.data.cNumeroRuc,
                            idClasificacionTipoPersona = objRespBus.data.idClasificacionTipoPersona,
                            idTipoContribuyente = objRespBus.data.idTipoContribuyente,
                            cTipoContribuyente = objRespBus.data.cTipoContribuyente,
                            cSiglas = objRespBus.data.cSiglas,
                            dFechaInicioActividad = objRespBus.data.dFechaInicioActividad,
                            idEstadoContribuyente = objRespBus.data.idEstadoContribuyente,
                            cEstadoContribuyente = objRespBus.data.cEstadoContribuyente,
                            idCondicionDomicilio = objRespBus.data.idCondicionDomicilio,
                            cCondicionDomicilio = objRespBus.data.cCondicionDomicilio,
                            dFechaConstitucion = objRespBus.data.dFechaConstitucion,
                            cCodDependencia = objRespBus.data.cCodDependencia,
                            cRazonSocial = objRespBus.data.cRazonSocial,
                            idActividad = objRespBus.data.idActividad,
                            cActividad = objRespBus.data.cActividad,
                            idTipoZona = objRespBus.data.idTipoZona,
                            idTipoVia = objRespBus.data.idTipoVia,
                            cDireccion = objRespBus.data.cDireccion,
                            cReferencia = objRespBus.data.cReferencia,
                            idUbigeo = objRespBus.data.idUbigeo,
                            cUbigeo = objRespBus.data.cUbigeo,
                            cTelefono = objRespBus.data.cTelefono,
                            cVisorConsultaSunat = objRespBus.data.cVisorConsultaSunat
                        };
                    }
                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
        }
        #endregion
    }
}
