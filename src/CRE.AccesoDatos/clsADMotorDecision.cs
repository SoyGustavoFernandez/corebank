using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer.MotorDecisionWebService;
using System.Threading;

namespace CRE.AccesoDatos
{
    //TODO: SolTechnologies - 3.Capa de Acceso a Datos asociada al Motor de decisiones
    public class clsADMotorDecision
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable CalcularModeloDiarioRequest(int idSolicitud)
        {
            return this.objEjeSp.EjecSP("CRE_ObtenerRequestCalcularModeloDiario_SP", idSolicitud);
        }

        public clsReporteHistoricoMotorDecision InsertarReporteHistorico(clsReporteHistoricoMotorDecision oReporte)
        {
            DataTable dtResultado = this.objEjeSp.EjecSP("CRE_InsertarReporteHistoricoMotorDecision_SP"
                    , oReporte.dFechaP
                    , oReporte.idPrediccion
                    , oReporte.nNumeroSolicitud
                    , oReporte.nResultadoScore
                    , oReporte.cResultadoModelo
                    , oReporte.CMotivoRechazo
                    , oReporte.cOficina
                    , oReporte.cAsesor
                    , oReporte.nEdad
                    , oReporte.cSexo
                    , oReporte.cEstadoCivil
                    , oReporte.cTipoVivienda
                    , oReporte.cNivelInstruccion
                    , oReporte.nMontoSolicitado
                    , oReporte.nPlazo
                    , oReporte.nNroDependientes
                    , oReporte.nAniosResidencia
                    , oReporte.cTelefono
                    , oReporte.cProfesion
                    , oReporte.cDiaSemana
                    , oReporte.cDepartamento
                    , oReporte.cDestinoCredito
                    , oReporte.cUsuarioReg
                    , oReporte.dFechaReg
                    , oReporte.cFormulario
                );
            return oReporte;
        }

        public DataTable ListarConfiguracion()
        {
            return this.objEjeSp.EjecSP("CRE_ListarConfiguracionMotorDecision_SP");
        }

        public DataTable ListarScoreMNB(int idSolicitud)
        {
            return this.objEjeSp.EjecSP("CRE_ListaResultadoMNB_SP", idSolicitud);
        }

        public DataTable ListaScoroMNBxMes(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_SolicitudesMNBxMes_SP", idCliente);
        }

        public DataTable ClasificacionInternaxCli(int idSolicitud)
        {
            return this.objEjeSp.EjecSP("CRE_ClasificacionInternaxCli_SP", idSolicitud);
        }

        public DataTable ClasificacionInternaMNB(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_ClasificacionInternaMNB_SP", idCliente);
        }

        public DataTable ModificaNivelAprobacionMNB(int idEvalCredito, int idNivelAprobacionCre)
        {
            return this.objEjeSp.EjecSP("CRE_ModificaNivelAprobacionMNB_SP", idEvalCredito, idNivelAprobacionCre);
        }

        public DataTable ValidaExistenciaMNB(int idSolicitud)
        {
            return this.objEjeSp.EjecSP("CRE_ValidaExistenciaMNB_SP", idSolicitud);
        }

        public DataTable ValidaRestriccionesMNB(int idSolicitud)
        {
            return this.objEjeSp.EjecSP("CRE_ValidaRestriccionesMNB_SP", idSolicitud);
        }

        public DataTable CambiarEstadoSol(int idSolicitud, int estado)
        {
            return this.objEjeSp.EjecSP("CRE_CambiarEstadoSol_SP", idSolicitud, estado);
        }

        public DataTable BuscaScoreMNBxCliente(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_BuscaScoreMNBxCliente_SP", idCliente);
        }
        
        public DataTable ProductosMNB(int idProducto)
        {
            return this.objEjeSp.EjecSP("CRE_ProductosMNB_SP", idProducto);
        }

        public DataTable ActualizaMotivoRechazo(int idSolicitud, string motivoRechazo)      
        {
            return this.objEjeSp.EjecSP("CRE_ActualizaMotivoRechazoMotorDecisiones_SP", idSolicitud, motivoRechazo);
        }

        public DataTable MigracionEvalMNB(int idEvalCred, string frmDestino)
        {
            return this.objEjeSp.EjecSP("CRE_MigracionEvalMNB_Sp", idEvalCred, frmDestino);
        }
    }
}
