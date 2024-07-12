using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRE.AccesoDatos;
using EntityLayer.MotorDecisionWebService;
using System.Data;
using System.Threading;


namespace CRE.CapaNegocio
{
    //TODO: SolTechnologies - 2.Capa negocio asociada al Motor de decisiones
    public class clsCNMotorDecision
    {
        private clsADMotorDecision oADCreJor = new clsADMotorDecision();

        public DataTable CalcularModeloDiarioRequest(int idSolicitud)
        {
            return oADCreJor.CalcularModeloDiarioRequest(idSolicitud);
        }

        // -- Guarda de forma historica el resultado del Motor de Decisiones para el MNB
        public clsReporteHistoricoMotorDecision InsertarReporteHistorico(clsReporteHistoricoMotorDecision oReporte)
        {
            return this.oADCreJor.InsertarReporteHistorico(oReporte);
        }

        // -- Configuracion del Motor de decisiones
        public DataTable ListarConfiguracion()
        {
            return this.oADCreJor.ListarConfiguracion();
        }

        public DataTable ListarScoreMNB(int idSolicitud)
        {
            return oADCreJor.ListarScoreMNB(idSolicitud);
        }

        public DataTable ListaScoroMNBxMes(int idCliente)
        {
            return oADCreJor.ListaScoroMNBxMes(idCliente);
        }

        // -- Valida las Restricciones del Modelo
        public DataTable ValidaRestriccionesMNB(int idSolicitud)
        {
            return oADCreJor.ValidaRestriccionesMNB(idSolicitud);
        }

        // -- Retorna la clasificacion interna de un cliente para validar el flujo del MNB x la solicitud
        public DataTable ClasificacionInternaxCli(int idSolicitud)
        {
            return oADCreJor.ClasificacionInternaxCli(idSolicitud);
        }

        // -- Retorna la clasificacion interna de un cliente para validar el flujo del MNB x el cliente
        public DataTable ClasificacionInternaMNB(int idCliente)
        {
            return oADCreJor.ClasificacionInternaMNB(idCliente);
        }

        // -- Modifica el nivel de aprobacion de la evaluacion
        public DataTable ModificaNivelAprobacionMNB(int idEvalCredito, int idNivelAprobacionCre)
        {
            return oADCreJor.ModificaNivelAprobacionMNB(idEvalCredito, idNivelAprobacionCre);
        }

        // -- Valida la existencia de una solicitud en el MNB
        public DataTable ValidaExistenciaMNB(int idSolicitud)
        {
            return oADCreJor.ValidaExistenciaMNB(idSolicitud);
        }

        // -- Cambia el estado de la solicitud
        public DataTable CambiarEstadoSol(int idSolicitud, int estado)
        {
            return oADCreJor.CambiarEstadoSol(idSolicitud, estado);
        }

        // -- Regresa las consultas al motor de decisiones de un cliente
        public DataTable BuscaScoreMNBxCliente(int idCliente)
        {
            return oADCreJor.BuscaScoreMNBxCliente(idCliente);
        }

        // -- Regresa las productos para evaluar si pertenecen al MNB
        public DataTable ProductosMNB(int idProducto)
        {
            return oADCreJor.ProductosMNB(idProducto);
        }

        // -- Actualiza el motivo de rechazo del MNB
        public DataTable ActualizaMotivoRechazo(int idSolicitud, string motivoRechazo)
        {
            return oADCreJor.ActualizaMotivoRechazo(idSolicitud, motivoRechazo);
        }

        // -- Migracion de Formulario para el MNB
        public DataTable MigracionEvalMNB(int idEvalCred, string frmDestino)
        {
            return oADCreJor.MigracionEvalMNB(idEvalCred, frmDestino);
        }
    }
}
