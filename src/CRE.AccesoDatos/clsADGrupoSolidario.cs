using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADGrupoSolidario
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable GuardarGrupoSolidario(int idGrupoSolidario, string cXmlGrupoSolidario, string cXmlGrupoSolidarioIntegrante)
        {
            return objEjeSp.EjecSP("CRE_GuardarGrupoSolidario_Sp", idGrupoSolidario, cXmlGrupoSolidario, cXmlGrupoSolidarioIntegrante);
        }

        public DataSet ObtenerGrupoSolidario(int idGrupoSolidario)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerGrupoSolidario_Sp", idGrupoSolidario);
        }

        public DataSet ReporteGrupoSolidario(int idGrupoSolidario)
        {
            return objEjeSp.DSEjecSP("RPT_ReporteGrupoSolidario_Sp", idGrupoSolidario);
        }

        public DataSet ObtenerSolCredGrupoSolidario(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerSolCredGrupoSolidario_SP", idGrupoSolidario, idSolicitudCredGrupoSol);
        }

        public DataSet ObtenerEvalCredGrupoSol(int idGrupoSolidario)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerEvalCredGrupoSolidario_SP", idGrupoSolidario);
        }

        public DataTable GuardarEvalCredGrupoSol(int idGrupoSolidario, string xmlEvalCredGrupoSol, string xmlSolCredIntegrante)
        {
            return objEjeSp.EjecSP("CRE_GuardarEvalCredGrupoSolidario_SP", idGrupoSolidario, xmlEvalCredGrupoSol, xmlSolCredIntegrante);
        }

        public DataSet ObtenerEvalIntegrantesGrupoSol(int idGrupoSolidario)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerEvalIntegrantesGrupoSol_SP", idGrupoSolidario);
        }

        public DataTable RegistrarSolGrupoSolidario(string xmlSolCredGrupoSol, string xmlSolCredIntegrante, int idOperacion, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_RegistrarSolGrupoSolidario_SP", xmlSolCredGrupoSol, xmlSolCredIntegrante, idOperacion, idUsuario);
        }

        public DataTable ExcepcionesGrupoDetalle(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ListaExcepcionesGeneradasGrupales_SP", idSolicitudCredGrupoSol);
        }

        public DataTable ExcepcionesGrupoEstado(int idSolicitudCredGrupoSol, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_ExcepcionesxGrupoSoli_SP", idSolicitudCredGrupoSol, idEstado);
        }
        public DataTable ObtenerEvalCualitativa(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_GrupoSolObtenerEvalCualitativa_SP", idEvalCredGrupoSol);
        }

        public DataTable GuardarEvalCualitativa(int idEvalCredGrupoSol, string xmlEvalCualitativa)
        {
            return objEjeSp.EjecSP("CRE_GrupoSolGuardarEvalCualitativa_SP", idEvalCredGrupoSol, xmlEvalCualitativa);
        }

        public DataTable EnviarSolCredGSaEvaluacion(int idSolicitudCredGrupoSol, string xmlSolCredGrupoSol, string xmlSolCredIntegrante)
        {
            return objEjeSp.EjecSP("CRE_EnviarSolCredGSaEvaluacion_SP", idSolicitudCredGrupoSol, xmlSolCredGrupoSol, xmlSolCredIntegrante);
        }      

        public List<clsEvalCredGrupoSol> BusEvalsCredGrupoSol(int idAgencia, int idPerfil, int idUsuario)
        {
            DataTable dt = objEjeSp.EjecSP("CRE_BusEvalsCredGrupoSol_SP", idAgencia, idPerfil, idUsuario);
            return DataTableToList.ConvertTo<clsEvalCredGrupoSol>(dt) as List<clsEvalCredGrupoSol>;            
        }

        public List<clsEvalCredIntegGrupoSol> ListarEvalCredsIntegsGrupoSol(int idGrupoSolidario, int idEvalCredGrupoSol)
        {
            DataTable dt = objEjeSp.EjecSP("CRE_ListarEvalCredsIntegsGrupoSol_SP", idGrupoSolidario, idEvalCredGrupoSol);
            return DataTableToList.ConvertTo<clsEvalCredIntegGrupoSol>(dt) as List<clsEvalCredIntegGrupoSol>;
        }
        public DataTable ActualizarCondicionesCreditoGS(int idEvalCredGrupoSol, decimal nMontoGrupal,int idTasa, decimal nTEA, decimal nTEM, int nCuotas, int idTipoPeriodo, int nPlazoCuota, int nDiasGracia, int nCuotasGracia, DateTime dFechaDesembolso, int idUsuModifica, DateTime dFechaMod, string xmlCredito)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCondicionesCreditoGS_SP", idEvalCredGrupoSol, nMontoGrupal, idTasa, nTEA, nTEM, nCuotas, idTipoPeriodo, nPlazoCuota, nDiasGracia, nCuotasGracia, dFechaDesembolso, idUsuModifica, dFechaMod, xmlCredito);
        }
        public decimal obtenerITF()
        {
            return Convert.ToDecimal((string)objEjeSp.EjecSP("CRE_obtenerITF_SP").Rows[0][0]);
        }
        public DataTable obtenerVariablesGrupoSolidario()
        {
            return objEjeSp.EjecSP("CRE_obtenerVariablesGrupoSolidario_SP");
        }
        public DataTable obtenerExcepCalifGrupoSolidario(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_obtenerExcepCalifGrupoSolidario_SP",idGrupoSolidario);
        }
        public DataTable GuardarEvalIntegrantes(int idEvalCredGrupoSol, string xmlEstResEval, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_GuardarEvalIntegrantesGrupoSol_Sp", idEvalCredGrupoSol, xmlEstResEval, xmlIndicadorEval);
        }

        public DataTable EnviarEvalCredGSAApro(int idEvalCredGrupoSol, int idSolicitudCredGrupoSol, string xmlEvalCredIntegGrupoSol, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_EnviarEvalCredGSAApro_SP", idEvalCredGrupoSol, idSolicitudCredGrupoSol, xmlEvalCredIntegGrupoSol, idUsuario, dFecha);
        }
        public DataTable ReporteEvaluacion(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ObtenerEvalIntegrantesGrupoSolRep2_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion3(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ObtenerEvalIntegrantesGrupoSolRep3_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion4(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_PropuestaIndividualGS_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion5(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_InformacionGrupoxEvaluacion_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion6(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ExcepcionesxGrupoSol_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion7(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_PropuestaIndividualGSExcep_SP", idEvalCredGrupoSol);
        }
        public DataTable ReporteSolicitud1(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart1_SP", idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud2(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart2_SP", idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud3(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart3_SP", idGrupoSolidario, idSolGrupo);
        }
        /***************/
        public DataTable ReporteSolicitud1DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart1DocuEnLinea_SP", idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud2DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart2DocuEnLinea_SP", idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud3DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart3DocuEnLinea_SP", idGrupoSolidario, idSolGrupo);
        }
        /************************/
        public DataSet ObtenerFichaEvalCualitativa(int idEvalCredGrupoSol)
        {
            return objEjeSp.DSEjecSP("RPT_ObtenerFichaEvalCualitativa_SP", idEvalCredGrupoSol);
        }

        public DataTable ValidarIntegranteGrupoSol(int idEvalCredGrupoSol, int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidarIntegranteGrupoSol_SP", idEvalCredGrupoSol, idCli);
        }

        public DataTable BusVariablesSegunNombre(string xmlNombresVariables)
        {
            return objEjeSp.EjecSP("GEN_BusVariablesSegunNombre_SP",xmlNombresVariables);
        }

        public DataTable ValidarCambioTasaGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol, int idTipoTasa)
        {
            return objEjeSp.EjecSP("CRE_ValidarCambioTasaGrupoSol_SP", idGrupoSolidario, idSolicitudCredGrupoSol, idTipoTasa);
        }

        public DataTable CambiarEstadoSolCredGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_CambiarEstadoSolCredGrupoSol_SP", idGrupoSolidario, idSolicitudCredGrupoSol);
        }

        public DataTable ValidarGrupoSolidario(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ValidarGrupoSolidario_SP", idEvalCredGrupoSol);
        }
        public DataTable FiltrarRepetidosGS(int idCli)
        {
            return objEjeSp.EjecSP("CRE_FiltrarClienteRepetidosGS_SP", idCli);
        }
        public DataTable BuscarCreditosActivosGS(int idCli, int idGS)
        {
            return objEjeSp.EjecSP("CRE_BuscarCreditosActivosGS_SP", idCli, idGS);
        }

        public DataTable ValidarEvalCualitativaGrupoSolidario(int idEvalCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ValidarEvalCualitativaGrupoSolidario_SP", idEvalCredGrupoSol);
        }

        public DataTable ADValidaIngregrantesPorTipoGrupoSolidario(int idTipoGrupoSol, int nNumeroIntegrantes)
        {
            return objEjeSp.EjecSP("CRE_ValidaIngregrantesPorTipoGrupoSolidario_SP", idTipoGrupoSol, nNumeroIntegrantes);
        }

        public DataTable ADValidaProductoTipoGrupoSolidario(int idTipoGrupoSolidario, int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidaProductoTipoGrupoSolidario_SP", idTipoGrupoSolidario, idProducto);
        }

        public DataTable ADSolicitudesAprobadasGrupoSol(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_SolicitudesAprobadasGrupoSol_SP", idGrupoSolidario);
        }

        public DataTable ADDetalleSolicitudCredIntegranteGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_DetalleSolicitudCredIntegranteGrupoSol_SP", idGrupoSolidario, idSolicitudCredGrupoSol);
        }
        public DataTable ADConsultaUits(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_RetornaUitxTipoGS_SP", idGrupoSolidario);
        }
        public DataTable ADconsultaCargoCli(int idSoliCredGS, int idCli)
        {
            return objEjeSp.EjecSP("CRE_DevuelveCargoCliGS_SP", idSoliCredGS, idCli);
        }
        public DataTable ADconsultaNroExcep(int idSoliCredGS)
        {
            return objEjeSp.EjecSP("CRE_ControlReglasGrupalesGS_SP", idSoliCredGS);
        }
        public DataTable obtenerGrupoSolidarioIntegrante(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ObtenerGrupoSolidarioIntegrante_SP", idCli);
        }

        public DataTable validarExpedienteGrupoSolidario(int idSoliCredGS)
        {
            return objEjeSp.EjecSP("CRE_CValidarExpdienteGrupalesGS_SP", idSoliCredGS);
        }

        #region SolicitudExcepcionesNoContempladas
        public DataTable listaSolicitudesAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_GruSolListaSolicitudesAgencia_SP", idAgencia, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public DataSet solicitudMiembros(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.DSEjecSP("CRE_GruSolSolicitudMiembros_SP", idSolicitudCredGrupoSol);
        }
        public DataSet listaAutorizadores()
        {
            return objEjeSp.DSEjecSP("CRE_GruSolListaAutorizadores_SP", clsVarGlobal.nIdAgencia, clsVarGlobal.User.idEstablecimiento);
        }
        public void notificarAnulacion(int idSolicitudCredGrupoSol, int idReglaNoContemplada)
        {
            this.objEjeSp.EjecSP("CRE_GruSolnotifiAnulacionSolRNC_SP", idSolicitudCredGrupoSol, idReglaNoContemplada);
        }
        public bool anularSustentoDeRNC(int idReglaNoContemplada)
        {
            var oRes = this.objEjeSp.EjecSP("CRE_GruSolAnularSustentosRNC_SP", idReglaNoContemplada);
            if (oRes.Rows.Count > 0)
            {
                return Convert.ToInt16(oRes.Rows[0]["nFilas"]) > 0 ? true : false;
            }
            else return false;
        }
        public DataTable listaExcepcionesNCEstado(int idSolicitudCredGruSol, string cEstados = "1")
        {
            return this.objEjeSp.EjecSP("CRE_ExcepcionesRNCxGrupoSoli_SP", idSolicitudCredGruSol, cEstados);
        }
        #endregion
        #region Bono Grupo Solidario
        public DataTable obtenerSolicitudCredGrupoSol(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolicitudCredGrupoSol_SP", idSolicitudCredGrupoSol);
        }
        public DataTable listarGrupoSolidarioBonoEstimado(int idGrupoSolidario, int idSolCredGrupoSolDesem, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_ListarGrupoSolidarioBonoEstimado_SP", idGrupoSolidario, idSolCredGrupoSolDesem, idOperacion);
        }
        public DataTable grabarGrupoSolidarioBono(string xmlGrupoSolidarioBono, int idUsuario, DateTime dFecha, int idEstablecimiento, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_GrabarGrupoSolidarioBono_SP", xmlGrupoSolidarioBono, idUsuario, dFecha, idEstablecimiento, idAgencia);
        }
        public DataTable rptGrupoSolidarioBono(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CRE_RptGrupoSolidarioBono_SP", dFechaInicio, dFechaFin);
        }        
        #endregion
        #region Desembolso Grupo Solidario
        public DataTable listarDesembolsoSolicitudGrupoSolidario(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_ListarDesembolsoSolicitudGrupoSolidario_SP", idGrupoSolidario);
        }
        public DataSet grabarGrupoSolidarioVoucher(int idGrupoSolidario, int idSolicitudCredGrupoSol, int nIntegrantes, decimal nMonto, DateTime dFecha, int idUsuario)
        {
            return objEjeSp.DSEjecSP("CRE_GrabarGrupoSolidarioVoucher_SP", idGrupoSolidario, idSolicitudCredGrupoSol, nIntegrantes, nMonto, dFecha, idUsuario);
        }
        #endregion
        #region Cuenta de Ahorro Grupo Solidario
        public DataTable listarGrupoSolidarioAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return this.objEjeSp.EjecSP("CRE_ListarGrupoSolidarioAhorro_SP", idGrupoSolidario, idSolicitudCredGrupoSol);
        }
        public DataTable listarGrupoSolIntegranteCtaAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol, int idOperacion)
        {
            return this.objEjeSp.EjecSP("CRE_ListarGrupoSolIntegranteCtaAhorro_SP", idGrupoSolidario, idSolicitudCredGrupoSol, idOperacion);
        }
        public DataTable grabarGrupoSolidarioAhorro(string xmlGrupoSolidarioAhorro)
        {
            return this.objEjeSp.EjecSP("CRE_GrabarGrupoSolidarioAhorro_SP", xmlGrupoSolidarioAhorro);
        }
        #endregion
        #region Ampliacion Grupo Solidario
        public DataTable listarCreditoAmpliableGrupoSol(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_ListarCreditoAmpliableGrupoSol_SP", idGrupoSolidario);
        }
        public DataTable obtenerSolCredGrupoSolAmpliable(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolCredGrupoSolAmpliable_SP", idSolicitudCredGrupoSol);
        }
        public DataTable existeAmpliacionGrupoSol(int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_ExisteAmpliacionGrupoSol_SP", idGrupoSolidario);
        }
        #endregion

        public DataTable obtenerDatosGrupoSolidarioCredito(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosGrupoSolidarioCredito_SP", idCuenta);
        }

        public DataTable obtenerGrupoSolidarioMoraAlerta(int idSolicitudGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_ObtenerGrupoSolidarioMoraAlerta_SP", idSolicitudGrupoSolidario);
        }
    }
}
