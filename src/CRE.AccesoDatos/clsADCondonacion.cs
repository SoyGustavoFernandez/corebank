using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADCondonacion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable SolicitudCondonacion(int idAgencia, int idCliente, int TipOper, int EstOper,
                                                  int idMoneda, int idProducto, decimal Monto, int idCuenta,
                                                   DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                                                   DateTime FecAprob, int idUsuario, Boolean lExcepcion,
                                                   int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {


            return objEjeSp.EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, TipOper, EstOper,
                                             idMoneda, idProducto, Monto, idCuenta,
                                              FecSolic, idMotivo, sustento, idEstSolic,
                                              FecAprob, idUsuario, lExcepcion,
                                              idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        
        }
        public DataTable DatosSolicCond(int idCli, int NroCuenta)
        {
            return objEjeSp.EjecSP("CRE_DatosSolicCond_sp", idCli, NroCuenta);
        }
        public DataTable ADInsertaDetalleCondonado(int idAgencia, int idCliente, int TipOper, int EstOper,
                                                  int idMoneda, int idProducto, decimal Monto, 
                                                   DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                                                   DateTime FecAprob, int idUsuario, Boolean lExcepcion,
                                                    int idCuenta, decimal nCapital, decimal nInteres, decimal nIntComp, decimal nMora, decimal nGastos, int idTipoCondonacion,
                                                    Decimal nCapitalDeuda, Decimal nInteresDeuda, Decimal nIntCompDeuda, Decimal nMoraDeuda, Decimal nGastosDeuda, 
                                                    bool lRefinanciamiento, string cCTAs, decimal nMontoTotalCTAs, String XMLCoutasCond, String xmlArchivos, int idTipoCorrespondencia
                                                    , string cXmlCobs, int nNroCuotaCondo, decimal nMontoPagar, decimal nMontoITF, int idPerfil, int idSubTipoCorrespondencia)
        {
            return objEjeSp.EjecSP("CRE_InsDetalleCondonado_sp", idAgencia, idCliente, TipOper, EstOper,
                                                                 idMoneda, idProducto, Monto, 
                                                                  FecSolic, idMotivo, sustento, idEstSolic,
                                                                  FecAprob, idUsuario, lExcepcion,
                                                                idCuenta,  nCapital, nInteres, nIntComp, nMora, nGastos, idTipoCondonacion, nCapitalDeuda, nInteresDeuda, nIntCompDeuda, nMoraDeuda, nGastosDeuda, 
                                                                lRefinanciamiento, cCTAs, nMontoTotalCTAs,XMLCoutasCond, xmlArchivos, idTipoCorrespondencia
                                                                , cXmlCobs, nNroCuotaCondo, nMontoPagar, nMontoITF, idPerfil, idSubTipoCorrespondencia);
        }

        public DataTable ListarCondonaciones(DateTime dtDesde, DateTime dtHasta, int idEstadoProbacion, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarCondonacionesRealizadas_SP", dtDesde, dtHasta, idEstadoProbacion, idAgencia);
        }

        public DataTable ListaDetalleCondXCuota(int idSol)
        {
            return objEjeSp.EjecSP("CRE_ListaDetalleCondXcuota_SP", idSol);
        }
        public DataTable ListSoliciAprob()
        {
            return objEjeSp.EjecSP("CRE_ListCondSolAprob_sp", clsVarGlobal.nIdAgencia);
        }

        public DataTable listarAlertaCorreo() 
        {
            return objEjeSp.EjecSP("CRE_ListarAlertaCorreo_SP");
        }

        public clsDBResp ADExtornaCondonacion(int IdKarExtornar	,DateTime dFechaExtorno,int idUsuExtorno)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ExtornaCondonacionCredito_SP", IdKarExtornar, dFechaExtorno, idUsuExtorno);
            return new clsDBResp(dtResult);
        }

        public DataTable ADGetDatosExtornoCondonacion(int IdKarExtornar)
        {
            return objEjeSp.EjecSP("CRE_DatosExtornoCondonacion_sp", IdKarExtornar);
        }
        /*===================================================================================================================================================================*/
        /*- Lista tipos de condonaciones                                                                                                                                     */
        /*===================================================================================================================================================================*/
        public DataTable listaTipoCondonacion(int idTipoCondonacion, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListaTipoCondonacion_SP", idTipoCondonacion, idPerfil);
        }
        public DataTable listaTipoCorrespondencia()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoCorrespondencia_SP");
        }
        public DataTable listaSubTipoCorrespondencia(int idTipoCorrespondencia)
        {
            return objEjeSp.EjecSP("CRE_ListaSubTipoCorrespondencia_SP", idTipoCorrespondencia);
        }
        public DataTable listaReglasTipoCondonacion(int idTipoCondonacion)
        {
            return objEjeSp.EjecSP("CRE_listaReglasCampaniaCondonacion_SP", idTipoCondonacion);
        }
        public DataTable guardarTipoCondonacion(int idTipoCondonacion, String cNombre, String cDescripcion, DateTime dVigInicio, DateTime dVigFin, int idUsu, DateTime dFechaReg, String xmlReglas)
        {
            return objEjeSp.EjecSP("CRE_InsertaCampaniaCondonacion_SP", idTipoCondonacion, cNombre, cDescripcion, dVigInicio, dVigFin, idUsu, dFechaReg, xmlReglas);
        }
        /*===================================================================================================================================================================*/
        /* CARGA DATOS PARA REPORTE                                                  */
        /*===================================================================================================================================================================*/
        public DataTable listaDatosRptNotaAbono(int idCuenta, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_rptNotaAbono_SP", idCuenta, idSolicitud);
        }
        /*===================================================================================================================================================================*/
        /* CARGA gastos de seguro si existe                                                  */
        /*===================================================================================================================================================================*/
        public DataTable obtieneGastosCuenta(int idCuenta, int idGrupo, int idPlanPagos, int idcuota)
        {
            return objEjeSp.EjecSP("CRE_ObtieneGastosCuentaCondonacion_SP", idCuenta, idGrupo, idPlanPagos, idcuota);
        }

        public DataTable filesCondonacion(int idSolAProba, int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_filesCondonacion_SP", idSolAProba, idCuenta);
        }

        public DataTable insertarArchivos(string name, string extencion, byte[] fileBase)
        {
            return objEjeSp.EjecSP("CRE_insertFilesCondonacion_SP",name,extencion,fileBase.ToArray());
        }

        public DataTable getFile()
        {
            return objEjeSp.EjecSP("CRE_getFile_SP");
        }

        public DataTable ADBuscaSolicitudAprobacion(int idCli, int idCuenta, int idAgencia=0)
        {
            return objEjeSp.EjecSP("ADM_BuscaSolicitudAprobacion_SP", idCli, idCuenta, idAgencia);
        }

        public DataTable ADCobsVinculadasACuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_CobsVinculadasACuenta_SP", idCuenta);
        }

        public DataTable ADListaCobsVincSolicitudCondonacion(int idSolicitudAproba, int idCuenta = 0)
        {
            return objEjeSp.EjecSP("CRE_ListaCobsVincSolicitudCondonacion_SP", idSolicitudAproba, idCuenta);
        }

        public DataTable ADBuscaSolAprobaCondonacionAprobados(int idCli, int idCuenta, int idAgencia = 0)
        {
            return objEjeSp.EjecSP("ADM_BuscaSolAprobaCondonacionAprobados_SP", idCli, idCuenta,  idAgencia);
        }

        public DataTable ADBuscaCobsXNroOperacion(int idKardex)
        {
            return objEjeSp.EjecSP("CRE_BuscaCobsXNroOperacion_SP", idKardex);
        }

        public DataTable ADBuscarCondonacionesEjecutadasXIdCuenta(int idCuenta, int idTipoOperacion, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_BuscarCondonacionesEjecutadasXIdCuenta_SP", idCuenta, idTipoOperacion, idSolicitud);
        }

        public DataTable CredPendientesRefinanciar(int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_CredPendientesRefinanciar_SP", idAgencia);
        }

        public DataTable getCobsDisponibles(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarCobsDisponibles_SP", idAgencia);
        }

        public DataTable getCobsDisponiblesZona(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarCobsDisponiblesZona_SP", idAgencia);
        }

        public DataTable nombreZona(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_NombreZona_SP", idAgencia);
        }

        public DataTable validarCOBs(string xmlCOBs)
        {
            return objEjeSp.EjecSP("CRE_ValidarCobsAfectaciones_SP", xmlCOBs);
        }

        public DataTable insertarGrupoCobsAfectaciones(string xmlCOBs, DateTime dFechaSis, int idUsuario, int idTipoAfectacion, string cComentario)
        {
            return objEjeSp.EjecSP("CRE_InsertarCobsAfectaciones", xmlCOBs, dFechaSis, idUsuario, idTipoAfectacion, cComentario);
        }

        public DataTable ListarCobsGrupo(int idGrupo)
        {
            return objEjeSp.EjecSP("CRE_ListarCobsGrupo_SP", idGrupo);
        }

        public DataTable rptSBSCliente(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_rptSBSCuenta_SP", idCuenta);
        }

        public DataTable esPendienteARefinanciar(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_esPendienteARefinanciar_SP", idCuenta);
        }

        public DataTable verificarSolicitudCondonacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerficarSolicitudCondonacion_SP", idCuenta);
        }

        public DataTable verificarConsolidacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerficarConsolidacionCredito_SP", idCuenta);
        }
        
        public DataTable ADCargarAfectacionCob(int idSolicitudAproba, int idCuenta = 0)
        {
            return objEjeSp.EjecSP("CRE_CargarAfectacionCob_SP", idSolicitudAproba, idCuenta);
        }
        
        public DataTable ListarAfectaciones(DateTime dtDesde, DateTime dtHasta, int idEstadoProbacion)
        {
            return objEjeSp.EjecSP("CRE_rptAfectaciones_SP", dtDesde, dtHasta, idEstadoProbacion);
        }
        
    }
}
