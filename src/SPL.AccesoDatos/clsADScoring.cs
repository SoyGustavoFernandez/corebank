using SolIntEls.GEN.Helper;
using System;
using System.Data;
using EntityLayer;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Xml;

namespace SPL.AccesoDatos
{
    public class clsADScoring
    {

        clsGENEjeSP objEjeSp;

        public clsADScoring()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ListaFactoresCalificacion(int idTipoEval, int idFactor, int idPadre)
        {
            return objEjeSp.EjecSP("SPL_ListarFactoresCalific_SP", idTipoEval, idFactor, idPadre);
        }

        public DataTable ListaTiposEvaluacion(int idGrupoEval, int idTipoPersona)
        {
            return objEjeSp.EjecSP("SPL_ListaTiposEvalScoring_SP", idGrupoEval, idTipoPersona);
        }

        public DataTable ListaGruposFactoresCalific(int idTipoEval)
        {
            return objEjeSp.EjecSP("SPL_ListaSoloGruposFactorCalific_SP", idTipoEval);
        }

        public DataTable InsertarFactorCalificacion(int idTipoEval, int idFactor, int idFactorPadre, String cCodEvenRiesgo, String cFactores, Decimal nIdFactEnTabla, Decimal nValorMaximo, String cCodigo,
                                                    Decimal nPonderado, int idUsu, DateTime dFecha, String cColumna, Boolean lConID, Decimal nPuntaje, Boolean lVigente, Boolean lPorRangos)
        {
            return objEjeSp.EjecSP("SPL_InsertarFactorCalific_SP", idTipoEval, idFactor, idFactorPadre, cCodEvenRiesgo, cFactores, nIdFactEnTabla, nValorMaximo, cCodigo,
                                                            nPonderado, idUsu, dFecha, cColumna, lConID, nPuntaje, lVigente, lPorRangos);
        }

        public DataTable EliminaFactorCalific(int idFactor, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_EliminaFactorCalific_SP", idFactor, idUsu, dFecha);
        }

        public DataTable ListaDatosCliEvaluacion(List<int> lstClientes)
        {
            
            XElement xmlElements = new XElement("Clientes", lstClientes.Select(i => new XElement("Cliente", new XElement("idCli", i))));
            var doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),xmlElements);
            string xmlClientes = xmlElements.Document.ToString();
            return objEjeSp.EjecSP("SPL_DatosCliParaScoring_SP", xmlClientes);
        }

        public DataTable ListaRegimenes(int idRegimen)
        {
            return objEjeSp.EjecSP("SPL_ListaRegimenes_SP", idRegimen);
        }

        public DataTable ListaDesCalificacion(int idCalificativo)
        {
            return objEjeSp.EjecSP("SPL_ListaCalificRiesgoScoring_SP", idCalificativo);
        }

        public DataTable GuardaDesCalificacion(int idCalificativo, String cCalificativo, Decimal nRangoMin, Decimal nRangoMax, Boolean lRequiereAprob, Boolean lVigente, int idUsu, DateTime dFecha, String cColor)
        {
            return objEjeSp.EjecSP("SPL_GuardaCalificRiesgoScoring_SP", idCalificativo, cCalificativo, nRangoMin, nRangoMax, lRequiereAprob, lVigente, idUsu, dFecha, cColor);
        }

        //TODO EVALUACION PROPIA SCORING
        public DataTable GuardaEvaluacionScoring(int idCli, int idTipoEval, int idAgencia, decimal nPuntaje, int idCalificativo,
                                                int idUsu, DateTime dFecha, string cEvalBatch, bool lBatch, string xmlDetalle)
        {
            return objEjeSp.EjecSP("SPL_GuardaEvaluacionScoring_SP", idCli, idTipoEval, idAgencia, nPuntaje, idCalificativo,
                                    idUsu, dFecha, cEvalBatch, lBatch, xmlDetalle);
        }

        public DataTable ListarEvaluacionesScoring(int idCli, DateTime dFechaDesde, DateTime dFechaHasta, int idRiesgo,
                                                    int idRegimen, int idAgencia, bool lNuevos, bool lRecurrentes)
        {
            return objEjeSp.EjecSP("SPL_ListaEvaluacionCliScoring_SP", idCli, dFechaDesde, dFechaHasta, idRiesgo, idRegimen, idAgencia, lNuevos, lRecurrentes);
        }

        public DataTable ListarEvaluacionHistoricoScoring(int idCli, Boolean lIncluirBatch)
        {
            return objEjeSp.EjecSP("SPL_ListaEvaluacionHistoricoCliScoring_SP", idCli, lIncluirBatch);
        }

        public DataTable ListarDetalleEvalScoring(int idEval)
        {
            return objEjeSp.EjecSP("SPL_ListaDetalleEvalCliScoring_SP", idEval);
        }

        public DataTable ActualizarAvistoEval(int idEval, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_ActualizaVistoEvalScoring_SP", idEval, idUsu, dFecha);
        }

        public DataTable ListaEvalScoringReporte(String cIdsEval)
        {
            return objEjeSp.EjecSP("SPL_ListaEvalCliScoringReporte_SP", cIdsEval);
        }

        public DataTable ListarClientesConProd(int idAgencia, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_ListaTodosClientesConProd_SP", idAgencia, dFecha);
        }

        public DataTable ListarPerfilSuperEvalScoring()
        {
            return objEjeSp.EjecSP("SPL_ListaPerfilSupEvalScoring_SP");
        }

        public DataTable VerificarDatosActualCli(int idCli, string cDocumentoID, int idAgencia, int idTipoOpe, int idCliTitular)
        {
            return objEjeSp.EjecSP("SPL_VerificaDatosActualCli_SP", idCli, cDocumentoID, idAgencia, idTipoOpe, idCliTitular);
        }

        public DataTable VerificarDatosActualCliWeb(int idCli)
        {
            return objEjeSp.EjecSP("SPL_VerificaDatosActualCliWeb_SP", idCli);
        }

        //MANTENIMIENTO DE BLOQUEO DE OPERACIONES
        public DataTable ListarGrupBloqOpe(int idGrupoBloq)
        {
            return objEjeSp.EjecSP("SPL_ListaGrupoBloqueOpeScoring_SP", idGrupoBloq);
        }

        public DataTable ListarDetalleBloOpe(int idGrupoBloq)
        {
            return objEjeSp.EjecSP("SPL_ListaDetalleGrupBloqOpeScoring_SP", idGrupoBloq);
        }

        public DataTable GuardaConfiBloqueOpe(int idGrupoBloq, String cDescripcion, DateTime dFechaIni, DateTime dFechaFin, Boolean lVigencia, int idUsu, DateTime dFecha, String xmlDetalle)
        {
            return objEjeSp.EjecSP("SPL_GuardaMantBloqOpeScoring_SP", idGrupoBloq, cDescripcion, dFechaIni, dFechaFin, lVigencia, idUsu, dFecha, xmlDetalle);
        }

        public DataTable GetTipoRiesgoSPLAFT()
        {
            return objEjeSp.EjecSP("SPL_GetTiposRiesgo_Sp");
        }

        public clsDBResp SaveConfigProductoEvalScoring(int idProducto,decimal nPonderado,bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("SPL_SaveConfigProductosEvalScoring_Sp", idProducto, nPonderado, lVigente);
            return new clsDBResp(dtResult);
        }

        public DataTable GetConfigProductoEvalScoring(int id)
        {
            return objEjeSp.EjecSP("SPL_GetConfigProductoEvalScoring_Sp", id);
        }

        public clsDBResp SaveEscalaMontosEvalScoring(int id, decimal nRanMin, decimal nRanMax, decimal nPonderado, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("SPL_SaveEscalaMontosEvalScoring_Sp", id, nRanMin, nRanMax, nPonderado, lVigente);
            return new clsDBResp(dtResult);
        }

        public DataTable GetEscalaMontosEvalScoring(int id)
        {
            return objEjeSp.EjecSP("SPL_GetEscalaMontosEvalScoring_Sp", id);
        }

        public DataTable GetRegimenScoring()
        {
            return objEjeSp.EjecSP("SPL_GetRegimenScoring_Sp");
        }

        public DataTable ADImpresionMasiva( int idEvalIni, int idEvalFin, int idTipoEvaluacion)
        {
            return objEjeSp.EjecSP("spl_ImprimirEvalMasivas_SP", idEvalIni, idEvalFin, idTipoEvaluacion);
        }
        public clsDBResp ADProcesaDatos(string cIdMes, string cIdAnio)
        {
            DataTable dtResult = objEjeSp.EjecSP("SPL_ActualizacionRegistros_SP", cIdMes,cIdAnio);
            return new clsDBResp(dtResult);
        }

    }
}
