using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADCargaArchivo
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarConfiguracionArchivo(int idOperacion, int idTipEvalCred, int idDescTipoDoc)
        {
            return objEjeSp.EjecSP("CRE_ListarConfiguracionArchivo_SP", idOperacion, idTipEvalCred, idDescTipoDoc);
        }
        public DataTable ADListarConfiguracionArchivo(int idTipoArchivo)
        {
            return objEjeSp.EjecSP("CRE_ListarConfiguracionArchivoXTipo_SP", idTipoArchivo);
        }
        public DataTable ADGuardarConfiguracion(int idOperacion, int idTipEvalCred, int idDescTipoDoc, string cConfiguracionXml)
        {
            return objEjeSp.EjecSP("CRE_GuardarConfiguracionArchivo_SP", idOperacion, idTipEvalCred, idDescTipoDoc, cConfiguracionXml);
        }

        public DataTable ADObtenerArchivosObligatoriosCargados(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerArchivosObligatoriosCargados_SP", idSolicitud);
        }

        public DataTable ADGuardarNuevoArchivo(int idDescTipoDoc, string dtArchivosXml)
        {
            return objEjeSp.EjecSP("CRE_GuardarNuevoArchivo_SP", idDescTipoDoc, dtArchivosXml);
        }

        public DataTable ADControlDpsCargados(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerControlDPSSolicitud_SP", idSolicitud);
        }

        public DataTable ADObtenerParametros()
        {
            return objEjeSp.EjecSP("CRE_ObtenerParametrosCargaArchivos_SP");
        }

        public DataTable ADGuardarParametros(decimal nMontoExposicion, decimal nMontoExposicionJuridica, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CRE_GuardarParametrosCargaArchivos_SP", nMontoExposicion, nMontoExposicionJuridica, idUsuario, dFechaSistema);
        }

        public DataTable ADObtenerMotivoVinculacionArchivo()
        {
            return objEjeSp.EjecSP("CRE_ObtenerMotivoVinculacionArchivo_SP");
        }

        public DataTable ADRegistrarSustentoVinculacionArchivo(string xmlSustentoVinculacionArchivo, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CRE_RegistrarSustentoVinculacionArchivo_SP", xmlSustentoVinculacionArchivo, idUsuario, dFechaSistema);
        }

        public DataTable ADVerificarCargaArchivoSolicitud(int idSolicitud, int idTipoArchivo, int idDescTipoDoc)
        {
            return objEjeSp.EjecSP("CRE_VerificarCargaArchivoSolicitud_SP", idSolicitud, idTipoArchivo, idDescTipoDoc);
        }

        public DataTable ADObtenerListaSustentoTipoArchivo()
        {
            return objEjeSp.EjecSP("CRE_ObtenerListaSustentoTipoArchivo_SP");
        }

        public DataTable ADVerificarSustentoVinculacionArchivo(int idSolicitud, int idTipoArchivo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSustentoVinculacionArchivo_SP", idSolicitud, idTipoArchivo);
        }

        public DataTable ADVerificarCargaPagareCredito(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_VerificarCargaPagareCredito_SP", idSolicitud);
        }
        public DataTable ADVerificarVinculacionPagare(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_VerificarVinculacionPagare_SP", idSolicitud);
        }

        public DataSet ADParametrosConfiguracionCargaArchivo()
        {
            return objEjeSp.DSEjecSP("CRE_ParametrosConfiguracionCargaArchivo_SP");
        }
 
        public clsDBResp GrabarNuevaTipoDocumento(clsTipoArchivoEscaneado tipoDocumento)
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = objEjeSp.EjecSP("CRE_GuardarNuevoArchivoV2_SP", tipoDocumento.obtenerXml());
                return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public clsDBResp ADEliminarTipoArchivo(clsTipoArchivoEscaneado tipoDocumento) 
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = objEjeSp.EjecSP("CRE_EliminarTipoArchivo_SP", tipoDocumento.obtenerXml()); 
                 return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public clsDBResp ADGuardarConfiguracion(string cConfiguracionXml, int idUsuReg	, DateTime dFecReg	  , int? idUsuAct	, DateTime? dFecAct)
        {
            try
            {
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("CRE_GuardarConfiguracionArchivoV2_SP", cConfiguracionXml, idUsuReg, dFecReg, idUsuAct, dFecAct);
            return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public clsDBResp ADGuardarConfigMonto(string cConfiguracionXml, int idUsuReg, DateTime dFecReg, int? idUsuAct, DateTime? dFecAct)
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = objEjeSp.EjecSP("CRE_GuardarConfigMontoArchivos_SP", cConfiguracionXml, idUsuReg, dFecReg, idUsuAct, dFecAct);
                return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public clsDBResp GrabarOrdenTipoDocumento(clsListaTipoArchivoEscaneado listaArchivos)
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = objEjeSp.EjecSP("CRE_GuardarOrdenArchivo_SP", listaArchivos.obtenerXml());
                 return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable ADListarTipoArchivoConfigurado(int idOperacion, int idTipEvalCred, int idDescTipoDoc)
        {
            return objEjeSp.EjecSP("CRE_ListaTipArchivoConfiguracionEscaneo_SP", idOperacion, idTipEvalCred, idDescTipoDoc);
        }
        public DataTable ADListarTipoArchivoConfiguradoGeneral()
        {
            return objEjeSp.EjecSP("CRE_ListaTipArchivoConEscTotal_SP");
        } 
    }
}
