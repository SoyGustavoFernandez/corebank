using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNSolCre
    {
        private clsADSolCre objBaseDatos;

        public clsCNSolCre(bool lWebService)
        {
            objBaseDatos = new clsADSolCre(lWebService);
        }

        public clsCNSolCre()
        {
            objBaseDatos = new clsADSolCre();   
        }

        public clsCreditoProp GetCreditoPropSol(int idSolicitud)
        {
            return objBaseDatos.GetCreditoPropSol(idSolicitud);
        }

        public DataTable GetSolAprobDeneg(DateTime dFecIni, DateTime dFecFin)
        {
            return objBaseDatos.GetSolAprobDeneg(dFecIni, dFecFin);
        }

        public clsDBResp GuardarCreditoProp(string xmlCreditoProp, int idUsuario, DateTime dFecha)
        {
            return objBaseDatos.GuardarCreditoProp(xmlCreditoProp, idUsuario, dFecha);
        }

        public DataTable GetHistoricoPropuesta(int idSolicitud)
        {
            return objBaseDatos.GetHistoricoPropuesta(idSolicitud);
        }

        public DataTable GetSolAprobNiveles(int idUsuario, int idPerfil, DateTime dFecIni, DateTime dFecFin)
        {
            return objBaseDatos.GetSolAprobNiveles(idUsuario, idPerfil, dFecIni, dFecFin);
        }

        #region SolicitudCreditos

        public DataTable CNRegistrarSolicitudCredito(clsSolicitudCreditos objSol, int idUsuario, int idAgencia)
        {
            return objBaseDatos.ADRegistrarSolicitudCredito(objSol, idUsuario, idAgencia);
        }

        public DataTable CNRegistroCreditoAmpliacion(int idSolicitud, int idCuenta, int idOperacion, decimal nSaldoCapital, decimal nSaldoInteres, decimal nSaldoMora, decimal nSaldoOtros, decimal nSaldoInteresCompensatorio)
        {
            return objBaseDatos.ADRegistroCreditoAmpliacion(idSolicitud, idCuenta, idOperacion, nSaldoCapital, nSaldoInteres, nSaldoMora, nSaldoOtros, nSaldoInteresCompensatorio);
        }

        public DataTable CNListaCampanaxCliente(int idTipoDocumento, string cDocumentoID, int idUsuario)
        {
            return objBaseDatos.ADListaCampanaxCliente(idTipoDocumento, cDocumentoID, idUsuario);
        }

        public DataSet CNBuscarSolicitudCred(int idTipoDocumento, string cDocumentoID)
        {
            return objBaseDatos.ADBuscarSolicitudCred(idTipoDocumento, cDocumentoID);
        }

        public DataTable CNListaCreditosCliente(int idCli)
        {
            return objBaseDatos.ADListaCreditosCliente(idCli);
        }

        public DataTable CNListaProductoAgricolaCultivo()
        {
            return objBaseDatos.ADListaProductoAgricolaCultivo();
        }

        public DataTable CNListaProductoAgricolaCultivoVariedad(int idCultivoEval)
        {
            return objBaseDatos.ADListaProductoAgricolaCultivoVariedad(idCultivoEval);
        }

        public DataTable CNRegistroCultivoVariedadEvaluacion(int idEvalCred, int idCultivoEval, int idVariedadCultivoEval, int idAgencia)
        {
            return objBaseDatos.ADRegistroCultivoVariedadEvaluacion(idEvalCred, idCultivoEval, idVariedadCultivoEval, idAgencia);
        }

        public DataTable CNProductoAgricolaCultivoVariedad(int idCultivoEval, int idSubProducto)
        {
            return objBaseDatos.ADProductoAgricolaCultivoVariedad(idCultivoEval, idSubProducto);
        }

        #endregion

        public DataTable CNObtenerAutorizacionPolizaPendientes()
        {
            return objBaseDatos.ADObtenerAutorizacionPolizaPendientes();
        }

        public DataTable CNRegistrarAutorizacionPoliza(int idSolicitud)
        {
            return objBaseDatos.ADRegistrarAutorizacionPoliza(idSolicitud);
        }

        public DataTable CNRegistrarDecisionAutorizacionPoliza(int idSolicitud, string cSustento, bool lAprobado, int idPerfilDecision, int idUsuarioDecision)
        {
            return objBaseDatos.ADRegistrarDecisionAutorizacionPoliza(idSolicitud, cSustento, lAprobado, idPerfilDecision, idUsuarioDecision);
        }
    }
}
