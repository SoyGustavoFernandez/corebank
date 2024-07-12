using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.AccesoDatos
{
    public class clsADProcesoAdjudicacion
    {
        private clsGENEjeSP _objEjeSp;

        public clsADProcesoAdjudicacion()
        {
            _objEjeSp = new clsGENEjeSP();
        }
        public clsProcesoAdjudicacion buscarProcesoAdjcaccion(int idProcesoAdj)
        {
            clsProcesoAdjudicacion procesoAdj = new clsProcesoAdjudicacion();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarProcesoAdquisicion_SP", idProcesoAdj);
            foreach (DataRow row in ds.Rows)
            {
                procesoAdj.cObjetoAdquisicion = row["cObjetoAdquisicion"].ToString();
                procesoAdj.cObservacion = row["cObservacion"].ToString();
                procesoAdj.cUsuReg = row["cUsuReg"].ToString();
                if (row["dFechaMod"] != DBNull.Value)
                {
                    procesoAdj.dFechaMod = Convert.ToDateTime(row["dFechaMod"]);
                }
                procesoAdj.dFechaReg = Convert.ToDateTime(row["dFechaReg"]);
                procesoAdj.idEstado = Convert.ToInt32(row["idEstado"]);
                procesoAdj.idMoneda = Convert.ToInt32(row["idMoneda"]);
                procesoAdj.idProceso = Convert.ToInt32(row["idProceso"]);
                procesoAdj.idTipoEvaluacion = Convert.ToInt32(row["idTipoEvaluacion"]);
                procesoAdj.idTipoPedido = Convert.ToInt32(row["idTipoPedido"]);
                procesoAdj.idTipoProceso = Convert.ToInt32(row["idTipoProceso"]);

                if (row["idUsuMod"] != DBNull.Value)
                {
                    procesoAdj.idUsuMod = Convert.ToInt32(row["idUsuMod"]);
                }
                procesoAdj.idUsuReg = Convert.ToInt32(row["idUsuReg"].ToString());
                procesoAdj.lConfirmacion = (row["lConfirmacion"] == DBNull.Value) ? false : (bool?)Convert.ToBoolean(row["lConfirmacion"]);
                procesoAdj.dfechaCulminacion = row["dfechaCulminacion"].ToString();

                procesoAdj.lIgv = Convert.ToBoolean(row["lIgv"]);
                procesoAdj.nMontoTotalIgv = Convert.ToDecimal(row["nMontoTotalIgv"]);
            }

            clsListaDetalleProcesoAdj lstDetProAdj = new clsListaDetalleProcesoAdj();
            DataTable ds1 = new DataTable();

            ds1 = objEjeSp.EjecSP("LOG_ListarDetalleProcesoAdjud_SP", procesoAdj.idProceso);
            foreach (DataRow row in ds1.Rows)
            {
                lstDetProAdj.Add(new clsDetalleProcesoAdj()
                    {
                        cDesGrupo = Convert.ToString(row["cDesGrupo"]),
                        idGrupo = Convert.ToInt32(row["idGrupo"]),
                        idProceso = Convert.ToInt32(row["idProceso"]),
                        idDetalleNotapedido = Convert.ToInt32(row["idDetalleNotaPedido"]),
                        nItem = Convert.ToInt32(row["nItem"]),
                        idCatalogo = Convert.ToInt32(row["idCatalogo"]),
                        cUnidad = Convert.ToString(row["cUnidad"]),
                        idUnidad = Convert.ToInt32(row["idUnidad"]),
                        nCantidad = Convert.ToDecimal(row["nCantidad"]),
                        nPrecioUnit = Convert.ToDecimal(row["nPrecioUnit"]),
                        cProducto = Convert.ToString(row["cProducto"]),
                        nsubTotal = (procesoAdj.lIgv) ? Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]) + Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]) * Convert.ToDecimal((0.18)) : Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]),
                        lIgv = Convert.ToInt32(row["lIgv"])
                    }
                );
            }
            procesoAdj.listaDetalleProAdj = lstDetProAdj;

            clslistaVinculoNotaPedido lstVinNotaPed = new clslistaVinculoNotaPedido();
            DataTable ds2 = new DataTable();

            ds2 = objEjeSp.EjecSP("LOG_ListarVincNotaPedAdqui_SP", procesoAdj.idProceso);
            foreach (DataRow row in ds2.Rows)
            {
                lstVinNotaPed.Add(new clsVinculoNotaPedido()
                {
                    cAgencia = Convert.ToString(row["cAgencia"]),
                    cArea = Convert.ToString(row["cArea"]),
                    cUsuReg = Convert.ToString(row["cUsuReg"]),
                    dFechaVinculacion = Convert.ToDateTime(row["dFechaVinculacion"]),
                    idMoneda = Convert.ToInt32(row["idMoneda"]),
                    idNotaPedido = Convert.ToInt32(row["idNotaPedido"]),
                    idProceso = Convert.ToInt32(row["idProceso"]),
                    idTipoPed = Convert.ToInt32(row["idTipoPedido"]),
                    idUsuReg = Convert.ToInt32(row["idUsuReg"]),
                    lVigente = Convert.ToBoolean(row["lVigente"])
                }
                 );
            }
            procesoAdj.listarVinNotapedido = lstVinNotaPed;
            return procesoAdj;
        }

        public clsDBResp GrabarNuevaAdjudicaccion(clsProcesoAdjudicacion Adjudicacion, clsListaDetalleProcesoAdj lisDetProAdj,
                                             clslistaVinculoNotaPedido ListNotasPedido, clsListaPuntajeProcesoAdj lstPuntajes,
                                             clsListaFactoresTecnicos lstFacTecnicos, clsListaCalendarioAdj Calendario,
                                             clsListaDocumentoPorCalendario lstDocumentoCal)
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = _objEjeSp.EjecSP("LOG_GrabarProcesoAdquisicion_Sp", Adjudicacion.obtenerXml(), lisDetProAdj.obtenerXml(), ListNotasPedido.obtenerXml(), lstPuntajes.obtenerXml(), Calendario.obtenerXml(), lstDocumentoCal.obtenerXml(), lstFacTecnicos.obtenerXml());
                return new clsDBResp(dtResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public clsDBResp ValidarProcesoAdjudicacion(int idProceso)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_ValidarProcesoAdjudicacion_sp", idProceso);
            return new clsDBResp(dtResult);
        }

        public clsListaCalendarioAdj buscaCalendarioProcesoAdj(int idProcesoAdj)
        {
            clsListaCalendarioAdj lstCalAdj = new clsListaCalendarioAdj();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarCalendarioProceso_SP", idProcesoAdj);
            foreach (DataRow item in ds.Rows)
            {
                lstCalAdj.Add(new clsCalendarioAdjudicacion()
                {
                    cEtapaCalendario = item["cEtapaCalendario"].ToString(),
                    cObservaciones = item["cObservaciones"].ToString(),
                    idEtapaCalendario = Convert.ToInt32(item["idEtapaCalendario"].ToString()),
                    dFechaFin = Convert.ToDateTime(item["dFechaFin"].ToString()),
                    dFechaInicio = Convert.ToDateTime(item["dFechaInicio"].ToString()),
                    idUsuReg = Convert.ToInt32(item["idUsuReg"].ToString()),
                    idProceso = Convert.ToInt32(item["idProceso"].ToString()),
                    dFechaReg = Convert.ToDateTime(item["dFechaReg"].ToString()),
                    idCalendario = Convert.ToInt32(item["idCalendario"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                    nOrden = Convert.ToInt32(item["nOrdenEtapa"].ToString())
                }
                );
            }
            return lstCalAdj;
        }

        //Registra el Calendario-Proceso Adquisición
        public DataTable ADRegCalendario(int idProceso, clsListaCalendarioAdj lstCalendario)
        {
            return new clsGENEjeSP().EjecSP("LOG_RegCalendario_sp", idProceso, lstCalendario.obtenerXml());
        }

        //Registra el Puntaje-Proceso Adquisición
        public DataTable ADRegPuntajeAdqui(clsProcesoAdjudicacion Adquisicion, clsListaDetalleProcesoAdj lisDetProAdqui, clslistaVinculoNotaPedido lisNotasPedido, clsListaPuntajeProcesoAdj lstPuntajes)
        {
            return new clsGENEjeSP().EjecSP("LOG_RegPuntajeAdqui_sp", Adquisicion.obtenerXml(), lisDetProAdqui.obtenerXml(), lisNotasPedido.obtenerXml(), lstPuntajes.obtenerXml());
        }

        //Registra de Documentos-Proceso Adquisición
        public DataTable ADRegDocSolProceso(int idProceso, clsListaCalendarioAdj lstCalendario, clsListaDocumentoPorCalendario lstDocCal)
        {
            return new clsGENEjeSP().EjecSP("LOG_RegDocSolProceso_sp", idProceso, lstCalendario.obtenerXml(), lstDocCal.obtenerXml());
        }

        //Registra Factor Técnico-Proceso Adquisición
        public DataTable ADRegFactorTecnico(int idProceso, clsListaFactoresTecnicos lstFactorTecnico)
        {
            return new clsGENEjeSP().EjecSP("LOG_RegFactorTecnico_sp", idProceso, lstFactorTecnico.obtenerXml());
        }

        public clsListaFactoresTecnicos buscaFactoresTecnicosProcesoAdj(int idProcesoAdj)
        {
            clsListaFactoresTecnicos lstFacTecAdj = new clsListaFactoresTecnicos();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarFactoresTecnicosProceso_SP", idProcesoAdj);

            foreach (DataRow item in ds.Rows)
            {
                lstFacTecAdj.Add(new clsFactoresTecnicos()
                {
                    idFacTec = Convert.ToInt32(item["idFacTec"].ToString()),
                    cDecripcion = item["cDecripcion"].ToString(),
                    cTipoEval = item["cTipoEval"].ToString(),
                    idFacTecnicos = Convert.ToInt32(item["idFacTecnicos"].ToString()),
                    idGrupo = Convert.ToInt32(item["idGrupo"].ToString()),
                    idPadre = Convert.ToInt32(item["idPadre"].ToString()),
                    idProceso = Convert.ToInt32(item["idProceso"].ToString()),
                    idTipoEvaFacTec = Convert.ToInt32(item["idTipoEvaFacTec"].ToString()),
                    nOrden = Convert.ToInt32(item["nOrden"].ToString()),
                    nPuntaje = Convert.ToDecimal(item["nPuntaje"].ToString()),
                    P_Grupo = Convert.ToDecimal(item["P_Grupo"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );

            }

            return lstFacTecAdj;
        }

        public clsListaPuntajeProcesoAdj buscaPuntajeProcesoAdj(int idProcesoAdj)
        {
            clsListaPuntajeProcesoAdj lstPuntajeAdj = new clsListaPuntajeProcesoAdj();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarPuntajeProceso_SP", idProcesoAdj);

            foreach (DataRow item in ds.Rows)
            {
                clsPuntajeProcesoAdj procesoAdj = new clsPuntajeProcesoAdj();
                procesoAdj.idPuntaje = Convert.ToInt32(item["idPuntaje"].ToString());
                if (item["dFechaMod"] == DBNull.Value)
                {
                    procesoAdj.dFechaMod = null;
                }
                else
                {
                    procesoAdj.dFechaMod = Convert.ToDateTime(item["dFechaMod"]);
                }
                procesoAdj.dFechReg = Convert.ToDateTime(item["dFechReg"].ToString());
                if (item["dFechaMod"] == DBNull.Value)
                {
                    procesoAdj.idUsuMod = null;
                }
                else
                {
                    procesoAdj.idUsuMod = Convert.ToInt32(item["idUsuMod"]);
                }
                procesoAdj.idUsuReg = Convert.ToInt32(item["idUsuReg"].ToString());
                procesoAdj.nEvaEconomica = Convert.ToDecimal(item["nEvaEconomica"].ToString());
                procesoAdj.nEvaTecnica = Convert.ToDecimal(item["nEvaTecnica"].ToString());
                procesoAdj.nFacEconomica = Convert.ToDecimal(item["nFacEconomica"].ToString());
                procesoAdj.nFacTecnica = Convert.ToDecimal(item["nFacTecnica"].ToString());
                procesoAdj.nPuntajeMin = Convert.ToDecimal(item["nPuntajeMin"].ToString());
                procesoAdj.idGrupo = Convert.ToInt32(item["idGrupo"].ToString());
                procesoAdj.idProceso = Convert.ToInt32(item["idProceso"].ToString());
                procesoAdj.lVigente = Convert.ToBoolean(item["lVigente"].ToString());
                lstPuntajeAdj.Add(procesoAdj);
            }
            return lstPuntajeAdj;
        }

        public clsListaDocumentoPorCalendario buscarDocumentoCal(int idProcesoAdj)
        {
            clsListaDocumentoPorCalendario DocCal = new clsListaDocumentoPorCalendario();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarDocCalendarioProceso_SP", idProcesoAdj);

            foreach (DataRow item in ds.Rows)
            {
                DocCal.Add(new clsDocumentoPorCalendario()
                {

                    idCalendario = Convert.ToInt32(item["idCalendario"].ToString()),
                    idEtapaCalendario = Convert.ToInt32(item["idEtapaCalendario"].ToString()),
                    idTipoDocProAdqui = Convert.ToInt32(item["idTipoDocProAdqui"].ToString()),
                    cDesTipoDoc = item["cTipoDocProAdqui"].ToString(),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                });
            }
            return DocCal;
        }

        public clsListaTipoFacPonderacion buscaTipoFacPonderacion(int idTipoPedido)
        {
            clsListaTipoFacPonderacion listTipoFacTec = new clsListaTipoFacPonderacion();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarTipoFacPonderacion_SP", idTipoPedido);

            foreach (DataRow item in ds.Rows)
            {
                listTipoFacTec.Add(new clsTipoFacPonderacion()
                {
                    cFactorPonderacion = item["cFactorPonderacion"].ToString(),
                    idTipoPedido = Convert.ToInt32(item["idTipoPedido"].ToString()),
                    idTipoFacPonderacion = Convert.ToInt32(item["idTipoFacPonderacion"].ToString()),
                    nEvaMin = Convert.ToDecimal(item["nEvaMin"].ToString()),
                    nEvaMax = Convert.ToDecimal(item["nEvaMax"].ToString()),
                    nFacMax = Convert.ToDecimal(item["nFacMax"].ToString()),
                    nFacMin = Convert.ToDecimal(item["nFacMin"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );
            }
            return listTipoFacTec;
        }

        public string GrabarTipoFacPondera(clsTipoFacPonderacion TipfacPonderacion, ref int nResp)
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_GrabaTipoFacPonderacion_Sp", TipfacPonderacion.obtenerXml());
            nResp = Convert.ToInt32(ds.Rows[0]["nResp"]);
            return ds.Rows[0]["mResp"].ToString();
        }

        public clsListaTipoFacTecnicos buscaTipoFacTecnicos(int idTipPed, int idPadre)
        {
            clsListaTipoFacTecnicos listTipoFacTec = new clsListaTipoFacTecnicos();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarTipoFacTecnicos_SP", idTipPed, idPadre);

            foreach (DataRow item in ds.Rows)
            {
                listTipoFacTec.Add(new clsTipoFactoresTecnicos()
                {
                    cFacTecnicos = item["cFacTecnicos"].ToString(),
                    idFacTecnicos = Convert.ToInt32(item["idFacTecnicos"].ToString()),
                    idPadre = (int?)Convert.ToInt32(item["idPadre"]),
                    nPuntaje = Convert.ToDecimal(item["nPuntaje"]),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );

            }
            return listTipoFacTec;
        }

        public clsListaTipoFacTecnicos buscaTipoFacTecnicosGrupo(int idTipPed, int idPadre)
        {
            clsListaTipoFacTecnicos listTipoFacTec = new clsListaTipoFacTecnicos();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarTipoFacTecnicosGrupo_SP", idTipPed, idPadre);

            foreach (DataRow item in ds.Rows)
            {
                listTipoFacTec.Add(new clsTipoFactoresTecnicos()
                {
                    cFacTecnicos = item["cFacTecnicos"].ToString(),
                    idFacTecnicos = Convert.ToInt32(item["idFacTecnicos"].ToString()),
                    idPadre = (int?)Convert.ToInt32(item["idPadre"]),
                    nPuntaje = Convert.ToDecimal(item["nPuntaje"]),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString())
                }
                );

            }
            return listTipoFacTec;
        }

        public string GrabarTipoFacTecnico(clsTipoFactoresTecnicos TipfacTecnico)
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_GrabaTipoFacTecnicos_Sp", TipfacTecnico.obtenerXml());
            return ds.Rows[0]["nResp"].ToString();

        }

        public DataTable buscaTipoEvalFacTecnicos()
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarTipoEvalFacTecnicos_SP");
            return ds;
        }

        public DataTable ADBuscarFrmProcAdj(int idProcesoAdj, DateTime dFechIni, DateTime dFechFin, int idEstadoProcLog, int nOper)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("LOG_CargarProcAdj_SP", idProcesoAdj, dFechIni, dFechFin, idEstadoProcLog, nOper);
        }

        public DataTable ADCargarEstProcAdj()
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("LOG_CargarEstProcAdj_SP");
        }

        public DataTable ADGuardarReqMinProcAdj(string xmlDetNotaPedido)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("LOG_ActualizarReqMin_SP", xmlDetNotaPedido);
        }

        public DataTable ADValidaNotaPedidoEnProceso(int idNotaPedido)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("LOG_ValidaNotaPedidoEnProceso_SP", idNotaPedido);
        }
        public DataTable ADVerificaSiHayVinculadosAlProceso(int idProceso)
        { 
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("LOG_VerificaSiHayVinculadosAlProceso_SP", idProceso);
            
        }
        public clsDBResp ADDeclararDesiertoProceso(int idProceso, int idUsuario, DateTime dFecha)
        {
            var dtResult = _objEjeSp.EjecSP("LOG_DeclararDesiertoProceso_SP", idProceso, idUsuario, dFecha);
            return new clsDBResp(dtResult);
        }

        public clsDBResp ADActualizaGanadoresProceso(List<clsVinculoProveedor> lstProveedores, int idUsuario, DateTime dFecha)
        {
            string xmlProveedores = lstProveedores.GetXml();
            var dtResult = _objEjeSp.EjecSP("LOG_ActualizaGanadoresProceso_Sp", xmlProveedores, idUsuario, dFecha);
            return new clsDBResp(dtResult);
        }
    }
}
