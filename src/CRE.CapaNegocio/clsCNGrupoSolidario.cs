using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNGrupoSolidario
    {
        public clsADGrupoSolidario objADGrupoSolidario = new clsADGrupoSolidario();

        public DataTable GuardarGrupoSolidario(int idGrupoSolidario, string cXmlGrupoSolidario, string cXmlGrupoSolidarioIntegrante)
        {
            return objADGrupoSolidario.GuardarGrupoSolidario(idGrupoSolidario, cXmlGrupoSolidario, cXmlGrupoSolidarioIntegrante);
        }

        public DataSet ObtenerGrupoSolidario(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ObtenerGrupoSolidario(idGrupoSolidario);
        }

        public DataSet ReporteGrupoSolidario(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ReporteGrupoSolidario(idGrupoSolidario);
        }

        public DataSet ObtenerSolCredGrupoSolidario(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objADGrupoSolidario.ObtenerSolCredGrupoSolidario(idGrupoSolidario, idSolicitudCredGrupoSol);
        }

        public DataSet ObtenerEvalCredGrupoSol(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ObtenerEvalCredGrupoSol(idGrupoSolidario);
        }

        public DataTable GuardarEvalCredGrupoSol(int idGrupoSolidario, string xmlEvalCredGrupoSol, string xmlSolCredIntegrante)
        {
            return objADGrupoSolidario.GuardarEvalCredGrupoSol(idGrupoSolidario, xmlEvalCredGrupoSol, xmlSolCredIntegrante);
        }

        public DataSet ObtenerEvalIntegrantesGrupoSol(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ObtenerEvalIntegrantesGrupoSol(idGrupoSolidario);
        }

        public DataTable RegistrarSolGrupoSolidario(string xmlSolCredGrupoSol, List<clsCreditoGrupoSolInt> lstSolicitudIntegrante, int idOperacion)
        {
            string xmlSolCredIntegrante = lstSolicitudIntegrante.ListObjectToXml("Solicitud", "Solicitudes");
            return objADGrupoSolidario.RegistrarSolGrupoSolidario(xmlSolCredGrupoSol, xmlSolCredIntegrante, idOperacion, clsVarGlobal.User.idUsuario);
        }

        public DataTable ExcepcionesGrupoDetalle(int idSolicitudCredGrupoSol)
        {
            return objADGrupoSolidario.ExcepcionesGrupoDetalle(idSolicitudCredGrupoSol);
        }

        public DataTable ExcepcionesGrupoEstado(int idSolicitudCredGrupoSol, int idEstado)
        {
            return objADGrupoSolidario.ExcepcionesGrupoEstado(idSolicitudCredGrupoSol, idEstado);
        }
        public DataTable ObtenerEvalCualitativa(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ObtenerEvalCualitativa(idEvalCredGrupoSol);
        }

        public DataTable GuardarEvalCualitativa(int idEvalCredGrupoSol, string xmlEvalCualitativa)
        {
            return objADGrupoSolidario.GuardarEvalCualitativa(idEvalCredGrupoSol, xmlEvalCualitativa);
        }

        public DataTable EnviarSolCredGSaEvaluacion(int idSolicitudCredGrupoSol, string xmlSolCredGrupoSol, List<clsCreditoGrupoSolInt> lstSolicitudIntegrante)
        {
            string xmlSolCredIntegrante = lstSolicitudIntegrante.ListObjectToXml("Solicitud", "Solicitudes");
            return objADGrupoSolidario.EnviarSolCredGSaEvaluacion(idSolicitudCredGrupoSol,xmlSolCredGrupoSol,xmlSolCredIntegrante);
        }

        public List<clsEvalCredGrupoSol> BusEvalsCredGrupoSol(int idAgencia, int idPerfil, int idUsuario)
        {
            return objADGrupoSolidario.BusEvalsCredGrupoSol(idAgencia, idPerfil, idUsuario);
        }

        public List<clsEvalCredIntegGrupoSol> ListarEvalCredsIntegsGrupoSol(int idGrupoSolidario, int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ListarEvalCredsIntegsGrupoSol(idGrupoSolidario, idEvalCredGrupoSol);
        }
        public DataTable ActualizarCondicionesCreditoGS(int idEvalCredGrupoSol, decimal nMontoGrupal, int idTasa, decimal nTEA, decimal nTEM, int nCuotas, int idTipoPeriodo, int nPlazoCuota, int nDiasGracia, int nCuotasGracia, DateTime dFechaDesembolso, int idUsuModifica, DateTime dFechaMod, string xmlCredito)
        {
            return objADGrupoSolidario.ActualizarCondicionesCreditoGS(idEvalCredGrupoSol, nMontoGrupal, idTasa, nTEA, nTEM, nCuotas, idTipoPeriodo, nPlazoCuota, nDiasGracia, nCuotasGracia, dFechaDesembolso, idUsuModifica, dFechaMod, xmlCredito);
        }
        public decimal obtenerITF()
        {
            return objADGrupoSolidario.obtenerITF();
        }
        public DataTable obtenerVariablesGrupoSolidario()
        {
            return objADGrupoSolidario.obtenerVariablesGrupoSolidario();
        }
        public DataTable obtenerExcepCalifGrupoSolidario(int idGrupoSolidario)
        {
            return objADGrupoSolidario.obtenerExcepCalifGrupoSolidario(idGrupoSolidario);
        }
        public DataTable GuardarEvalIntegrantes(int idEvalCredGrupoSol, string xmlEstResEval, string xmlIndicadorEval)
        {
            return objADGrupoSolidario.GuardarEvalIntegrantes(idEvalCredGrupoSol, xmlEstResEval, xmlIndicadorEval);
        }

        public DataTable EnviarEvalCredGSAApro(int idEvalCredGrupoSol, int idSolicitudCredGrupoSol, string xmlEvalCredIntegGrupoSol, int idUsuario, DateTime dFecha)
        {
            return objADGrupoSolidario.EnviarEvalCredGSAApro(idEvalCredGrupoSol, idSolicitudCredGrupoSol, xmlEvalCredIntegGrupoSol, idUsuario, dFecha);
        }

        public DataTable ReporteEvaluacion(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion(idEvalCredGrupoSol);
        }

        public DataTable ReporteEvaluacion3(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion3(idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion4(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion4(idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion5(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion5(idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion6(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion6(idEvalCredGrupoSol);
        }
        public DataTable ReporteEvaluacion7(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ReporteEvaluacion7(idEvalCredGrupoSol);
        }
        public DataTable ReporteSolicitud1(int idGrupoSolidario, int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud1(idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud2(int idGrupoSolidario , int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud2(idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud3(int idGrupoSolidario, int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud3(idGrupoSolidario, idSolGrupo);
        }
        /**************************/
        public DataTable ReporteSolicitud1DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud1DocuEnLinea(idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud2DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud2DocuEnLinea(idGrupoSolidario, idSolGrupo);
        }
        public DataTable ReporteSolicitud3DocuEnLinea(int idGrupoSolidario, int idSolGrupo)
        {
            return objADGrupoSolidario.ReporteSolicitud3DocuEnLinea(idGrupoSolidario, idSolGrupo);
        }
        /**************************/

        public DataSet ObtenerFichaEvalCualitativa(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ObtenerFichaEvalCualitativa(idEvalCredGrupoSol);
        }

        public DataTable ValidarIntegranteGrupoSol(int idEvalCredGrupoSol, int idCli)
        {
            return objADGrupoSolidario.ValidarIntegranteGrupoSol(idEvalCredGrupoSol, idCli);
        }

        public DataTable BusVariablesSegunNombre(string xmlNombresVariables)
        {
            return objADGrupoSolidario.BusVariablesSegunNombre(xmlNombresVariables);
        }

        public DataTable ValidarCambioTasaGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol, int idTipoTasa)
        {
            return objADGrupoSolidario.ValidarCambioTasaGrupoSol(idGrupoSolidario, idSolicitudCredGrupoSol, idTipoTasa);
        }

        public DataTable CambiarEstadoSolCredGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objADGrupoSolidario.CambiarEstadoSolCredGrupoSol( idGrupoSolidario, idSolicitudCredGrupoSol);
        }

        public DataTable ValidarGrupoSolidario(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ValidarGrupoSolidario(idEvalCredGrupoSol);
        }
        public DataTable FiltrarRepetidosGS(int idCli)
        {
            return objADGrupoSolidario.FiltrarRepetidosGS(idCli);
        }
        public DataTable BuscarCreditosActivosGS(int idCli, int idGS)
        {
            return objADGrupoSolidario.BuscarCreditosActivosGS(idCli, idGS);
        }

        public DataTable ValidarEvalCualitativaGrupoSolidario(int idEvalCredGrupoSol)
        {
            return objADGrupoSolidario.ValidarEvalCualitativaGrupoSolidario(idEvalCredGrupoSol);
        }

        public DataTable CNValidaIngregrantesPorTipoGrupoSolidario(int idTipoGrupoSol, int nNumeroIntegrantes)
        {
            return objADGrupoSolidario.ADValidaIngregrantesPorTipoGrupoSolidario(idTipoGrupoSol, nNumeroIntegrantes);
        }
        
        public DataTable CNValidaProductoTipoGrupoSolidario(int idTipoGrupoSolidario, int idProducto)
        {
            return objADGrupoSolidario.ADValidaProductoTipoGrupoSolidario(idTipoGrupoSolidario, idProducto);
        }

        public DataTable CNSolicitudesAprobadasGrupoSol(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ADSolicitudesAprobadasGrupoSol(idGrupoSolidario);
        }

        public DataTable CNDetalleSolicitudCredIntegranteGrupoSol(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            return objADGrupoSolidario.ADDetalleSolicitudCredIntegranteGrupoSol(idGrupoSolidario, idSolicitudCredGrupoSol);
        }
        public DataTable CNConsultaUits(int idGrupoSolidario)
        {
            return objADGrupoSolidario.ADConsultaUits(idGrupoSolidario);
        }
        public DataTable consultaCargoCli(int idSoliCredGS, int idCli)
        {
            return objADGrupoSolidario.ADconsultaCargoCli(idSoliCredGS, idCli);
        }
        public DataTable consultaNroExcep(int idSoliCredGS)
        {
            return objADGrupoSolidario.ADconsultaNroExcep(idSoliCredGS);
        }
        public clsGrupoSolidarioIntegrante obtenerGrupoSolidarioIntegrante(int idCli)
        {
            DataTable dtGrupoSolidarioIntegrante = this.objADGrupoSolidario.obtenerGrupoSolidarioIntegrante(idCli);

            return (dtGrupoSolidarioIntegrante.Rows.Count > 0) ?
                dtGrupoSolidarioIntegrante.Rows[0].ToObject<clsGrupoSolidarioIntegrante>() :
                new clsGrupoSolidarioIntegrante(); 
        }

        public DataTable validarExpedienteGrupoSolidario(int idSoliCredGS)
        {
            return objADGrupoSolidario.validarExpedienteGrupoSolidario(idSoliCredGS);
        }

        #region SolicitudExcepcionesNoContempladas
        public DataTable listaSolicitudesAgencia(int idAgencia)
        {
            return objADGrupoSolidario.listaSolicitudesAgencia(idAgencia);
        }
        public DataSet solicitudMiembros(int idSolicitudCredGrupoSol)
        {
            return objADGrupoSolidario.solicitudMiembros(idSolicitudCredGrupoSol);
        }
        public DataSet listaAutorizadores()
        {
            return objADGrupoSolidario.listaAutorizadores();
        }
        public void notificarAnulacion(int idSolicitudCredGrupoSol, int idReglaNoContemplada)
        {
            this.objADGrupoSolidario.notificarAnulacion(idSolicitudCredGrupoSol, idReglaNoContemplada);
        }
        public bool anularSustentoDeRNC(int idReglaNoContemplada)
        {
            return this.objADGrupoSolidario.anularSustentoDeRNC(idReglaNoContemplada);
        }
        public bool comprobarExcepcionesRNC(int idSolicitudCredGrupoSol)
        {
            var dtListaExcepcRNC = this.objADGrupoSolidario.listaExcepcionesNCEstado(idSolicitudCredGrupoSol, "0,1,2,4");
            if (dtListaExcepcRNC.Rows.Count > 0) {
                return false;
            }
            return true;
        }
        #endregion

        #region Bono Grupo Solidario
        public DataTable obtenerSolicitudCredGrupoSol(int idSolicitudCredGrupoSol)
        {
            return this.objADGrupoSolidario.obtenerSolicitudCredGrupoSol(idSolicitudCredGrupoSol);
        }
        public List<clsGrupoSolidarioBono> listarGrupoSolidarioBonoEstimado(int idGrupoSolidario, int idSolCredGrupoSolDesem, int idOperacion)
        {
            DataTable dtGrupoSolidarioBono = this.objADGrupoSolidario.listarGrupoSolidarioBonoEstimado(idGrupoSolidario, idSolCredGrupoSolDesem, idOperacion);
            return (dtGrupoSolidarioBono.Rows.Count > 0) ?
                dtGrupoSolidarioBono.ToList<clsGrupoSolidarioBono>() as List<clsGrupoSolidarioBono> :
                new List<clsGrupoSolidarioBono>();
        }
        public clsRespuestaServidor grabarGrupoSolidarioBono(clsGrupoSolidarioBono objGrupoSolidarioBono)
        {
            List<clsGrupoSolidarioBono> lstGrupoSolidarioBono = new List<clsGrupoSolidarioBono>();
            lstGrupoSolidarioBono.Add(objGrupoSolidarioBono);

            string xmlGrupoSolidarioBono = lstGrupoSolidarioBono.ListObjectToXml<clsGrupoSolidarioBono>("Bono", "Bonos");
            DataTable dtRespuestaServidor = this.objADGrupoSolidario.grabarGrupoSolidarioBono(xmlGrupoSolidarioBono, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.User.idEstablecimiento, clsVarGlobal.nIdAgencia);

            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public DataTable rptGrupoSolidarioBono(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return this.objADGrupoSolidario.rptGrupoSolidarioBono(dFechaInicio, dFechaFin);
        }        
        #endregion

        #region Desembolso Grupo Solidario
        public List<clsDesembolsoSolicitud> listarDesembolsoSolicitudGrupoSolidario(int idGrupoSolidario)
        {
            DataTable dtSolicitudes = this.objADGrupoSolidario.listarDesembolsoSolicitudGrupoSolidario(idGrupoSolidario);
            return (dtSolicitudes.Rows.Count > 0) ?
                dtSolicitudes.ToList<clsDesembolsoSolicitud>() as List<clsDesembolsoSolicitud> :
                new List<clsDesembolsoSolicitud>();
        }
        public clsRespuestaServidor grabarGrupoSolidarioVoucher(int idGrupoSolidario, int idSolicitudCredGrupoSol, int nIntegrantes, decimal nMonto)
        {
            DataSet dsGrupoSolidarioVoucher = this.objADGrupoSolidario.grabarGrupoSolidarioVoucher(idGrupoSolidario, idSolicitudCredGrupoSol, nIntegrantes, nMonto, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

            clsRespuestaServidor objRespuestaServidor = new clsRespuestaServidor();
            if (dsGrupoSolidarioVoucher.Tables.Count > 0)
            {
                objRespuestaServidor = (dsGrupoSolidarioVoucher.Tables[0].Rows.Count > 0) ?
                    dsGrupoSolidarioVoucher.Tables[0].Rows[0].ToObject<clsRespuestaServidor>() :
                    new clsRespuestaServidor();

                if(objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    objRespuestaServidor.objDatos = dsGrupoSolidarioVoucher.Tables[1].Rows[0].ToObject<clsGrupoSolidarioVoucher>();
                }
            }
            return objRespuestaServidor;
        }
        #endregion

        #region Cuenta de Ahorro Grupo Solidario
        public List<clsGrupoSolidarioAhorro> listarGrupoSolidarioAhorro(int idGrupoSolidario, int idSolicitudCredGrupoSol)
        {
            DataTable dtGrupoSolidarioAhorro = this.objADGrupoSolidario.listarGrupoSolidarioAhorro(idGrupoSolidario, idSolicitudCredGrupoSol);

            return (dtGrupoSolidarioAhorro.Rows.Count > 0) ?
                dtGrupoSolidarioAhorro.ToList<clsGrupoSolidarioAhorro>() as List<clsGrupoSolidarioAhorro> :
                new List<clsGrupoSolidarioAhorro>();
        }
        public List<clsGrupoSolIntegranteCtaAhorro> listarGrupoSolIntegranteCtaAhorro(int idGrupoSolidario, int idSolicitudCredGruposol, int idOperacion)
        {
            DataTable dtGrupoSolIntegranteCtaAhorro = this.objADGrupoSolidario.listarGrupoSolIntegranteCtaAhorro(idGrupoSolidario, idSolicitudCredGruposol, idOperacion);
            return (dtGrupoSolIntegranteCtaAhorro.Rows.Count > 0) ?
                dtGrupoSolIntegranteCtaAhorro.ToList<clsGrupoSolIntegranteCtaAhorro>() as List<clsGrupoSolIntegranteCtaAhorro> :
                new List<clsGrupoSolIntegranteCtaAhorro>();
        }
        public clsRespuestaServidor grabarGrupoSolidarioAhorro(List<clsGrupoSolidarioAhorro> lstGrupoSolidarioAhorro)
        {
            string xmlGrupoSolidarioAhorro = string.Empty;
            xmlGrupoSolidarioAhorro = lstGrupoSolidarioAhorro.ListObjectToXml("GrupoSolAhorro", "GrupoSolAhorros");

            DataTable dtRespuestaServidor = this.objADGrupoSolidario.grabarGrupoSolidarioAhorro(xmlGrupoSolidarioAhorro);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        #endregion

        #region Ampliacion Grupo Solidario
        public List<clsCreditoGrupoSolInt> listarCreditoAmpliableGrupoSol(int idGrupoSolidario)
        {
            DataTable dtGrupoSolIntegranteCtaAhorro = this.objADGrupoSolidario.listarCreditoAmpliableGrupoSol(idGrupoSolidario);
            return (dtGrupoSolIntegranteCtaAhorro.Rows.Count > 0) ?
                dtGrupoSolIntegranteCtaAhorro.ToList<clsCreditoGrupoSolInt>() as List<clsCreditoGrupoSolInt> :
                new List<clsCreditoGrupoSolInt>();
        }
        public DataTable obtenerSolCredGrupoSolAmpliable(int idSolicitudCredGrupoSol)
        {
            return this.objADGrupoSolidario.obtenerSolCredGrupoSolAmpliable(idSolicitudCredGrupoSol);
        }
        public DataTable existeAmpliacionGrupoSol(int idGrupoSolidario)
        {
            return this.objADGrupoSolidario.existeAmpliacionGrupoSol(idGrupoSolidario);
        }
        #endregion

        public DataTable obtenerDatosGrupoSolidarioCredito(int idCuenta)
        {
            return objADGrupoSolidario.obtenerDatosGrupoSolidarioCredito(idCuenta);
        }

        public DataTable obtenerGrupoSolidarioMoraAlerta(int idSolicitudGrupoSolidario)
        {
            return objADGrupoSolidario.obtenerGrupoSolidarioMoraAlerta(idSolicitudGrupoSolidario);
        }
    }
}
