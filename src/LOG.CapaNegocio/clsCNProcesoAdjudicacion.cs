using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNProcesoAdjudicacion
    {
        public clsProcesoAdjudicacion buscarProcesoAdj(int idProcesoAdj)
        {
            return new clsADProcesoAdjudicacion().buscarProcesoAdjcaccion(idProcesoAdj);
        }

        public clsDBResp GrabarNuevaAdjudicaccion(clsProcesoAdjudicacion Adjudicacion, clsListaDetalleProcesoAdj lisDetProAdj, clslistaVinculoNotaPedido lisNotasPedido, clsListaPuntajeProcesoAdj lstPuntajes,
                                               clsListaFactoresTecnicos lstFacTecnicos, clsListaCalendarioAdj Calendario,clsListaDocumentoPorCalendario lstDocumento)
        {
            return new clsADProcesoAdjudicacion().GrabarNuevaAdjudicaccion(Adjudicacion, lisDetProAdj, lisNotasPedido, lstPuntajes, lstFacTecnicos, Calendario, lstDocumento);
        } 

        public clsListaCalendarioAdj buscaCalendarioProAdj(int idProcesoAdj)
        {
            return new clsADProcesoAdjudicacion().buscaCalendarioProcesoAdj(idProcesoAdj);
        }

        //Registra el Calendario-Proceso Adquisición
        public DataTable RegCalendario(int idProceso, clsListaCalendarioAdj lstCalendario)
        {
            return new clsADProcesoAdjudicacion().ADRegCalendario(idProceso, lstCalendario);
        }

        //Registra el Puntaje-Proceso Adquisición
        public DataTable RegPuntajeAdqui(clsProcesoAdjudicacion Adquisicion, clsListaDetalleProcesoAdj lisDetProAdqui, clslistaVinculoNotaPedido lisNotasPedido, clsListaPuntajeProcesoAdj lstPuntajes)
        {
            return new clsADProcesoAdjudicacion().ADRegPuntajeAdqui(Adquisicion, lisDetProAdqui, lisNotasPedido, lstPuntajes);
        }

        //Registra los Documentos-Proceso Adquisición
        public DataTable RegDocSolProceso(int idProceso, clsListaCalendarioAdj lstCalendario, clsListaDocumentoPorCalendario lstDocCal)
        {
            return new clsADProcesoAdjudicacion().ADRegDocSolProceso(idProceso, lstCalendario, lstDocCal);
        }

        //Registra los Factores Técnicos-Proceso Adquisición
        public DataTable RegFactorTecnico(int idProceso, clsListaFactoresTecnicos lstFactorTecnico)
        {
            return new clsADProcesoAdjudicacion().ADRegFactorTecnico(idProceso, lstFactorTecnico);
        }

        public clsListaFactoresTecnicos buscaFactoresTecnicosProAdj(int idProcesoAdj)
        {
            return new clsADProcesoAdjudicacion().buscaFactoresTecnicosProcesoAdj(idProcesoAdj);
        }

        public clsListaPuntajeProcesoAdj buscaPuntajeProAdj(int idProcesoAdj)
        {
            return new clsADProcesoAdjudicacion().buscaPuntajeProcesoAdj(idProcesoAdj);
        }

        public clsListaDocumentoPorCalendario buscarDocumentoCal(int idProcesoAdj)
        {
            return new clsADProcesoAdjudicacion().buscarDocumentoCal(idProcesoAdj);
        }

        public clsListaTipoFacPonderacion buscaFacTipPonderacion(int idTipoPedido)
        {
            return new clsADProcesoAdjudicacion().buscaTipoFacPonderacion(idTipoPedido);
        }

        public string GrabarTipFacPonderacion(clsTipoFacPonderacion TipfacPonderacion, ref int nResp)
        {
            return new clsADProcesoAdjudicacion().GrabarTipoFacPondera(TipfacPonderacion, ref nResp);
        }

        public clsListaTipoFacTecnicos buscaTipoFacTecnico(int idTipPed, int idPadre)
        {
            return new clsADProcesoAdjudicacion().buscaTipoFacTecnicos(idTipPed, idPadre);
        }

        public clsListaTipoFacTecnicos buscaTipoFacTecnicoGrupo(int idTipPed, int idPadre)
        {
            return new clsADProcesoAdjudicacion().buscaTipoFacTecnicosGrupo(idTipPed, idPadre);
        }

        public string GrabarTipFacTecnico(clsTipoFactoresTecnicos TipfacTecnico)
        {
            return new clsADProcesoAdjudicacion().GrabarTipoFacTecnico(TipfacTecnico);
        }

        public DataTable buscaTipoEvaFacTec()
        {
            return new clsADProcesoAdjudicacion().buscaTipoEvalFacTecnicos();
        }

        public DataTable CNBuscarFrmProcAdj(int idProcesoAdj, DateTime dFechIni, DateTime dFechFin, int idEstadoProcLog, int nOper)
        {
            return new clsADProcesoAdjudicacion().ADBuscarFrmProcAdj( idProcesoAdj, dFechIni, dFechFin, idEstadoProcLog, nOper);
        }
        
        public DataTable CNCargarEstProcAdj()
        {
            return new clsADProcesoAdjudicacion().ADCargarEstProcAdj();
        }

        public DataTable CNGuardarReqMinProcAdj(string xmlDetNotaPedido)
        {
            return new clsADProcesoAdjudicacion().ADGuardarReqMinProcAdj(xmlDetNotaPedido);
        }

        public DataTable CNValidaNotaPedidoEnProceso(int idNotaPedido)
        {
            return new clsADProcesoAdjudicacion().ADValidaNotaPedidoEnProceso(idNotaPedido);
        }

        public DataTable CNVerificaSiHayVinculadosAlProceso(int idProceso)
        {
            return new clsADProcesoAdjudicacion().ADVerificaSiHayVinculadosAlProceso(idProceso);
            
        }

        public clsDBResp CNDeclararDesiertoProceso(int idProceso, int idUsuario, DateTime dFecha)
        {
            return new clsADProcesoAdjudicacion().ADDeclararDesiertoProceso(idProceso, idUsuario, dFecha);
        }

        public clsDBResp ValidarProcesoAdjudicacion(int idProceso)
        {
            return new clsADProcesoAdjudicacion().ValidarProcesoAdjudicacion(idProceso);
        }

        public clsDBResp CNActualizaGanadoresProceso(List<clsVinculoProveedor> lstProveedores, int idUsuario, DateTime dFecha)
        {
            return new clsADProcesoAdjudicacion().ADActualizaGanadoresProceso(lstProveedores, idUsuario, dFecha);
        }
    }
}
