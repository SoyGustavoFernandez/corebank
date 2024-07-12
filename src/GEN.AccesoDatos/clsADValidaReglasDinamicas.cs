using System;
using System.Text;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADValidaReglasDinamicas
    {
        IntConexion objEjeSp;

        public clsADValidaReglasDinamicas()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADValidaReglasDinamicas(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        

        //Obtiene las Funciones (En estado vigente) que se usan en las reglas Dinámicas de acuerdo al nombre de la Opción
        public DataTable ExtraeFuncionesReglasDinamicas(String cNombreFormulario)
        {
            return objEjeSp.EjecSP("Gen_ListaFunciones_SP", cNombreFormulario);
        }

        //Obtiene todas las Funciones (En estado vigente y no vigente) que se usan en las Reglas Dinámicas de acuerdo al Identificador de la Opción
        //Se usará en el mantenedor de reglas dinámicas
        public DataTable ObtieneFuncionesParaReglasDinamicas(int idOpcion)
        {
            return objEjeSp.EjecSP("GEN_ListaFuncxOpc_SP", idOpcion);
        }

        //Obtiene las Reglas (En estado vigente) de acuerdo al nombre de la Opción
        public DataTable ExtraeReglasDinamicas(String cNombreFormulario, int idRegistroExcep)
        {
            return objEjeSp.EjecSP("Gen_ListaReglasDinamicas_SP", cNombreFormulario, idRegistroExcep);
        }
        //Obtiene las Reglas (En estado vigente y no vigente) de acuerdo al Identificador de la Opción
        //Sólo reglas (lIndExcepcion=0 ó lIndExcepcion=1) ('No se considera los niveles de permiso' lIndExcepcion=2)
        public DataTable ObtieneReglasDinamicas(int idOpcion)
        {
            return objEjeSp.EjecSP("Gen_ListaReglasDinamicasxOpc_SP", idOpcion);
        }

        public String CalcularValorFuncion(String cCadenaFuncion)
        {
            return objEjeSp.EjecSP("Gen_ValorFuncion_SP", cCadenaFuncion).Rows[0][0].ToString();
        }

        public DataTable GuardarSolicitudAprobac(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, bool lExcepcion,
                                            int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSp.EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto,
                                    nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, lExcepcion,
                                    idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }

        public DataTable GuardarSolicitudExcepciones(int idSolicitud, int idUsuRegistra, string xml, int idFlag, string cNombreFormulario)
        {
            return objEjeSp.EjecSP("GEN_InsExcepciones_SP", idSolicitud, idUsuRegistra, xml, idFlag, cNombreFormulario);
        }
        public DataTable GuardarSolicitudNOExcepciones(int idSolicitud, int idUsuRegistra, string xml, int idFlag, string cNombreFormulario)
        {
            return objEjeSp.EjecSP("CRE_InsExcepNoContempladas_SP", idSolicitud, idUsuRegistra, xml, idFlag, cNombreFormulario);
        }

        public bool verificarReglaGenerada(int idSolicitud, int idRegla)
        {
            bool lEstado;
            DataTable ds = objEjeSp.EjecSP("CRE_VerificarReglaGenerada_SP", idSolicitud, idRegla);
            lEstado = Convert.ToBoolean(ds.Rows[0]["lEstado"]);
            return lEstado;
        }

        public DataTable GuardarSolicitudExcepcionesCred(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal /*era double*/nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, bool lExcepcion)
        {
            return objEjeSp.EjecSP("GEN_InsExcepciones_SP", idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto,
                                    nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, lExcepcion);
        }

        public DataTable ConsultaSolicitudesAprobadas(int idTipoOperacion, int idDocument)
        {
            return objEjeSp.EjecSP("Gen_ConsulAprobacSolici_SP", idTipoOperacion, idDocument);
        }

        public DataTable ConsultaSolicitudesAprobadasCreditos(int idTipoOperacion, int idDocument)
        {
            return objEjeSp.EjecSP("Gen_ConsulAprobaSoliciCre_SP", idTipoOperacion, idDocument);
        }

        public DataTable ConsultaSolicitudesAprobadasCred(int idTipoOperacion, int idDocument)
        {
            return objEjeSp.EjecSP("Gen_ConsulAprobaSoliciCre_SP", idTipoOperacion, idDocument);
        }

        public DataTable CargarListaOpciones(int idModulo)
        {
            return objEjeSp.EjecSP("GEN_ListaOpcModulo_SP", idModulo);
        }

        public DataTable InsReglaDinamica(string XmlRegla)
        {
            return objEjeSp.EjecSP("GEN_InsReglaDinamica_SP", XmlRegla);
        }

        //--Solicitud de Nivel de Aprobacion
        public DataTable ConsultaAprobSolicitud(int idTipoOperacion, int idDocument, int idProd, int idCli,
                                        int idMoneda, DateTime dFechaSol, int idUsuReg, Decimal nMontoOpe)
        {
            return objEjeSp.EjecSP("Gen_ConsultaSolicitudApr_SP", idTipoOperacion, idDocument, idProd, idCli,
                                                                idMoneda, dFechaSol, idUsuReg, nMontoOpe);
        }

        //--Actualiza el Nivel de Aprobacion
        public DataTable ActualizaSolicitudApr(int idSolApr, int idEstadoSol)
        {
            return objEjeSp.EjecSP("Gen_ActualizaSolicitud_SP", idSolApr, idEstadoSol);
        }
        //consulta el estado y el id de SI_FINSoliciAprob
        public DataTable ADConsultaEstExcepExtorno(int idDocument, int idProd, int idCli,
                                        int idMoneda, DateTime dFechaSol, int idUsuReg, Decimal nMontoOpe)
        {
            return objEjeSp.EjecSP("Gen_ConsultaEstExcepExtorno_SP", idDocument, idProd, idCli,
                                                                idMoneda, dFechaSol, idUsuReg, nMontoOpe);
        }
        public DataTable ADUpdVigSolicitudAprob(int idDocument)
        {
            return objEjeSp.EjecSP("GEN_UpdVigSolicitudAprobacion_SP", idDocument);
        }

        public DataTable asignarValoresAFunciones(string xmlFunciones)
        {
            return objEjeSp.EjecSP("GEN_AsignarValorAFuncion_SP", xmlFunciones);
        }


        public DataTable ADValidarReglasClr(DataTable dtTablaParametros, string cNombreFormulario, int idAgencia, int idCliente,
                                            int idEstadoOperac, int idMoneda, int idProducto, Decimal nValAproba, int idDocument,
                                            DateTime dFecSolici, int idMotivo, int idEstadoSol, int idUsuRegist)
        {
            string cxmlParametros = "";
            if (dtTablaParametros.DataSet==null)
            {
                DataSet dsParametros = new DataSet();
                dsParametros.Tables.Add(dtTablaParametros);
                cxmlParametros = dsParametros.GetXml();
            }
            else
            {
                cxmlParametros = dtTablaParametros.DataSet.GetXml();
            }

            return objEjeSp.EjecSP("GEN_ValidaReglasDinamicas_SP", cxmlParametros, cNombreFormulario, idAgencia, idCliente,
                                                                 idEstadoOperac, idMoneda, idProducto, nValAproba,
                                                                 idDocument, dFecSolici, idMotivo, idEstadoSol,
                                                                 idUsuRegist);
        }

        public DataTable ADRegistrarSolAprExcepciones(string xmlReglas, int idAgencia, int idCliente, int idEstadoOperac, int idMoneda, int idProducto,
                                                        decimal nValAproba, int idDocument, DateTime dFecSolici, int idMotivo, int idEstadoSol,
                                                        DateTime dFecAprSol, int idUsuRegist)
        {
            return objEjeSp.EjecSP("GEN_RegistrarSolAprExcepciones_SP",xmlReglas, idAgencia, idCliente, idEstadoOperac, idMoneda, idProducto,
                                                        nValAproba, idDocument, dFecSolici, idMotivo, idEstadoSol, dFecAprSol, idUsuRegist);
        }

        public DataTable ADObtenerReglasConResultado(DataTable dtTablaParametros, string cNombreFormulario)
        {
            string cxmlParametros = "";
            if (dtTablaParametros.DataSet == null)
            {
                DataSet dsParametros = new DataSet();
                dsParametros.Tables.Add(dtTablaParametros);
                cxmlParametros = dsParametros.GetXml();
            }
            else
            {
                cxmlParametros = dtTablaParametros.DataSet.GetXml();
            }

            return objEjeSp.EjecSP("GEN_ObtenerReglasConResultado_SP", cxmlParametros, cNombreFormulario);
        }
        public DataTable obtenerCantidadExcepcionesManuales(int idSolicitud, string cNombreFormulario)
        {
            return objEjeSp.EjecSP("GEN_CantidadExcepcionesManuales_SP", idSolicitud, cNombreFormulario);
        }
        public DataTable obtenerRegla(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaRNC_SP", idSolicitud);
        }
        public DataTable buscarReglaNegocio(int idRegla, string cNombreForm, int idMetodoBusq, int idSolicitud)
        {
            return objEjeSp.EjecSP("GEN_BuscarReglaNegocio_SP", idRegla, cNombreForm, idMetodoBusq, idSolicitud);
        }
        public DataTable ExtraeReglasDinamicasCondiciones(String cNombreFormulario, int idRegistroExcep, string cTipoPer)
        {
            return objEjeSp.EjecSP("GEN_ListaReglasDinamicasCondiciones_SP", cNombreFormulario, idRegistroExcep, cTipoPer);
        }

        #region Validación de Limites EOB

        public DataTable ADObtenerTipoOpeEOBMenu()
        {
            return objEjeSp.EjecSP("GEN_ObtenerTipoOpeEOBMenu_SP");
        }

        public DataTable ADSolicitudExcepcionLimite(string cFormMenu, decimal nMonto, int idCli, int idEstab, int idTipoOpeEOB)
        {
            return new clsGENEjeSP().EjecSP("ADM_ValidarTransacionEOB_SP", cFormMenu, nMonto, idCli, idEstab, idTipoOpeEOB);
        }

        public DataTable ConsultaSolicitudesAprobadasLimiteExcepcion(int idTipoOperacion, int idDocument, int idProd, int idCli,
                                        int idMoneda, DateTime dFechaSol, int idUsuReg, decimal nMontoOpe, int idTipoOpeExp)
        {
            return objEjeSp.EjecSP("Gen_ConsultaSolicitudAprobExcepEOB_SP", idTipoOperacion, idDocument, idProd, idCli,
                                                                idMoneda, dFechaSol, idUsuReg, nMontoOpe, idTipoOpeExp);
        }

        #endregion

        public DataTable ADObtenerListaReglasConfig(String cNombreFormulario, int nTipoEvalConfig)
        {
            return objEjeSp.EjecSP("GEN_RecuperaReglaConfig_SP", cNombreFormulario, nTipoEvalConfig);
        }
        public DataTable ADObtenerListaFuncionesConfig(String cNombreFormulario, int nTipoEvalConfig)
        {
            return objEjeSp.EjecSP("GEN_ListaFuncionesReglaConfig_SP", cNombreFormulario, nTipoEvalConfig);
        }
        public DataTable asignarValoresAFuncionesConfig(string xmlFunciones)
        {
            return objEjeSp.EjecSP("GEN_AsignarValorAFuncionConfig_SP", xmlFunciones);
        }
        public DataTable ADListaTipoEvaluacion()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoEvaluacion_SP");
        }
        public DataTable ADListaTipoEvaluacionCred(int idProducto, int idModalidadCredito)
        {
            return objEjeSp.EjecSP("CRE_RecuperaEvalCredRemotaPresencial_SP", idProducto, idModalidadCredito);
        }
    }
}
