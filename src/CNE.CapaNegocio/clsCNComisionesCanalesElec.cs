using CNE.AccesoDatos;
using EntityLayer;
using GEN.RestHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace CNE.CapaNegocio
{
    public class clsCNComisionesCanalesElec
    {
        clsADComisionCanalesElec objADComisionCanalesElec;

        private string urlAPI = (string)clsVarApl.dicVarGen["urlApiConciliacion"];

        public clsCNComisionesCanalesElec()
        {
            this.objADComisionCanalesElec = new clsADComisionCanalesElec();
        }

        #region Base de Datos CoreBank

        public DataTable ObtenerCanalesElectronicos()
        {
            return this.objADComisionCanalesElec.ObtenerCanalesElectronicos();
        }

        public DataTable ObtenerTipoCanalServicio()
        {
            return this.objADComisionCanalesElec.ObtenerTipoCanalServicio();
        }

        public DataTable ObtenerTipoAsumeComision()
        {
            return this.objADComisionCanalesElec.ObtenerTipoAsumeComision();
        }

        public DataTable ObtenerTipoRango()
        {
            return this.objADComisionCanalesElec.ObtenerTipoRango();
        }

        public DataTable ObtenerTipoModalidadPago()
        {
            return this.objADComisionCanalesElec.ObtenerTipoModalidadPago();
        }

        public DataSet ObtenerConfComisiones(int idCanal = 0)
        {
            return this.objADComisionCanalesElec.ObtenerConfComisiones(idCanal);
        }

        public DataTable GuardaConfComisiones(string xmlConfComisionM, string xmlConfComisionD)
        {
            return this.objADComisionCanalesElec.GuardaConfComisiones(xmlConfComisionM, xmlConfComisionD, clsVarGlobal.User.cNomUsu);
        }

        public DataSet ObtenerComisionesAuditoria(int idCanal, DateTime fechaDesde, DateTime fechaHasta)
        {
            return this.objADComisionCanalesElec.ObtenerComisionesAuditoria(idCanal, fechaDesde, fechaHasta);
        }

        public DataTable ObtenerComisionesCore(string xmlPagos)
        {
            return this.objADComisionCanalesElec.ObtenerComisionesCore(xmlPagos);
        }

        #endregion

        #region API Comisiones de Canales Electronicos

        public clsResponse<DataTable> ObtenerXmlHPagosCargados(int idCanal, DateTime dFechaInicio, DateTime dFechaFin)
        {
            clsFunRest<dynamic, clsResponse<DataTable>> client = new clsFunRest<dynamic, clsResponse<DataTable>>(urlAPI);
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("idCanal", idCanal.ToString());
            parametros.Add("dFechaInicio", dFechaInicio.ToString());
            parametros.Add("dFechaFin", dFechaFin.ToString());

            clsResponse<DataTable> oResult = client.Execute("ObtenerXmlHPagosCargados", HttpMethod.Get, parametros, null, null);
            return oResult;
        }

        #endregion
    }
}