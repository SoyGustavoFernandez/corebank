using CNE.AccesoDatos;
using EntityLayer;
using GEN.RestHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace CNE.CapaNegocio
{
    public class clsCNConciliacionPagos
    {
        clsADConciliacionPagos objADConciliacionPagos;
        private string urlAPI = (string)clsVarApl.dicVarGen["urlApiConciliacion"];

        public clsCNConciliacionPagos()
        {
            this.objADConciliacionPagos = new clsADConciliacionPagos();
        }

        #region Base de Datos CoreBank

        public DataTable ObtenerConfiguracionCanalesElectronicos()
        {
            return this.objADConciliacionPagos.ObtenerConfiguracionCanalesElectronicos();
        }

        public DataTable ObtenerPagosKardex(int idCanal, DateTime dFechaConci, DateTime dFechaConciFinal)
        {
            return this.objADConciliacionPagos.ObtenerPagosKardex(idCanal, dFechaConci, dFechaConciFinal);
        }

        #endregion

        #region API Conciliacion Pagos

        public clsResponse<DataTable> ProcesarDatos(DateTime dFechaCarga, int idCanal, string cUsuarioReg, DateTime dFechaCoreBank, MultipartFormDataContent file)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaCarga", dFechaCarga.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("cUsuarioReg", cUsuarioReg);
            parametros.Add("dFechaCoreBank", dFechaCoreBank.Date.ToString("dd/MM/yyyy"));

            clsResponse<DataTable> oResult = client.Execute("ProcesarDatos", HttpMethod.Post, parametros, null, file);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerDatosCargados(DateTime dFechaCarga, int idCanal, int idCabecera)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaCarga", dFechaCarga.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("idCabecera", idCabecera.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerDatosCargados", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerArchivosCargados(DateTime dFechaCarga, int idCanal)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaCarga", dFechaCarga.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerArchivosCargados", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerMPagosKardex(DateTime dFechaConci, int idCanal)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaConci", dFechaConci.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerMPagosKardex", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<List<clsLogCargaDatosConci>> ObtenerLogCarga(DateTime dFechaCarga, int idCanal)
        {
            clsFunRest<dynamic, clsResponse<List<clsLogCargaDatosConci>>> client = new clsFunRest<dynamic, clsResponse<List<clsLogCargaDatosConci>>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaCarga", dFechaCarga.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());

            clsResponse<List<clsLogCargaDatosConci>> oResult = client.Execute("ObtenerLogCarga", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerPagosCargados(int idCanal, DateTime dFechaPago)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFechaPago", dFechaPago.Date.ToString("dd/MM/yyyy"));

            clsResponse<DataTable> oResult = client.Execute("ObtenerPagosCargados", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> RegistraPago(int idCanal, DateTime dFecha, int idTipoOperacion, string cUsuarioReg, object data)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFecha", dFecha.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idTipoOperacion", idTipoOperacion.ToString());
            parametros.Add("cUsuarioReg", cUsuarioReg.ToString());

            clsResponse<DataTable> oResult = client.Execute("RegistraPago", HttpMethod.Post, parametros, data, null);
            return oResult;
        }

        public clsResponse<DataTable> RegistraExtorno(int idCanal, DateTime dFecha, int idTipoOperacion, string cUsuarioReg, object data)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFecha", dFecha.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idTipoOperacion", idTipoOperacion.ToString());
            parametros.Add("cUsuarioReg", cUsuarioReg.ToString());

            clsResponse<DataTable> oResult = client.Execute("RegistraExtorno", HttpMethod.Post, parametros, data, null);
            return oResult;
        }

        public clsResponse<DataTable> GuardarConciliacion(int idCanal, DateTime dFechaConci, string cUsuarioReg, object data)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFechaConci", dFechaConci.ToString("dd/MM/yyyy"));
            parametros.Add("cUsuarioReg", cUsuarioReg.ToString());

            clsResponse<DataTable> oResult = client.Execute("GuardarConciliacion", HttpMethod.Post, parametros, data, null);
            return oResult;
        }

        public clsResponse<DataTable> GuardarBitacoraConciliacion(object data)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();

            clsResponse<DataTable> oResult = client.Execute("GuardarBitacoraConciliacion", HttpMethod.Post, parametros, data, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerTransacciones(DateTime dFechaPago, int idTipoOperacion, int idCanal)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaPago", dFechaPago.Date.ToString("dd/MM/yyyy"));
            parametros.Add("idTipoOperacion", idTipoOperacion.ToString());
            parametros.Add("idCanal", idCanal.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerTransacciones", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerEstadosBitacora()
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);
            Dictionary<string, string> parametros = new Dictionary<string, string>();

            clsResponse<DataTable> oResult = client.Execute("ObtenerEstadosBitacora", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerBitacoraConciliacion(DateTime dFechaIni, DateTime dFechaFin, int idCanal)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"));
            parametros.Add("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"));
            parametros.Add("idCanal", idCanal.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerBitacoraConciliacion", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataSet> ObtenerReportePagosCargados(int idCanal, DateTime dFecha)
        {
            clsFunRest<dynamic, clsResponse<DataSet>> client = new clsFunRest<dynamic, clsResponse<DataSet>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFecha", dFecha.ToString("dd/MM/yyyy"));

            clsResponse<DataSet> oResult = client.Execute("ObtenerReportePagosCargados", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataSet> ObtenerReporteResultadoConciliacion(int idCanal, DateTime dFecha)
        {
            clsFunRest<dynamic, clsResponse<DataSet>> client = new clsFunRest<dynamic, clsResponse<DataSet>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFecha", dFecha.ToString("dd/MM/yyyy"));

            clsResponse<DataSet> oResult = client.Execute("ObtenerReporteResultadoConciliacion", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        public clsResponse<DataTable> ObtenerRangoFechasReal(int idCanal, DateTime dFechaPago)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);

            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFechaPago", dFechaPago.Date.ToString("dd/MM/yyyy"));

            clsResponse<DataTable> oResult = client.Execute("ObtenerRangoFechasReal", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        #endregion
    }
}