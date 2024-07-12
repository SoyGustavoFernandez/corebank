using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;


namespace CRE.CapaNegocio
{
    public class clsCNCondonacion
    {
        public clsADCondonacion ObjCredito = new clsADCondonacion();
        public DataTable SolicitudCondonacion(int idAgencia, int idCliente, int TipOper, int EstOper,
                                                  int idMoneda, int idProducto, decimal Monto, int idCuenta,
                                                   DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                                                   DateTime FecAprob, int idUsuario, Boolean lExcepcion)
        {
            return ObjCredito.SolicitudCondonacion(idAgencia, idCliente, TipOper, EstOper,
                                             idMoneda, idProducto, Monto, idCuenta,
                                              FecSolic, idMotivo, sustento, idEstSolic,
                                              FecAprob, idUsuario, lExcepcion);
        }


        public DataTable DatosSolicCond(int idCli, int NroCuenta)
        {
            return ObjCredito.DatosSolicCond(idCli, NroCuenta);
        }

        public DataTable ListarCondonaciones(DateTime dtDesde, DateTime dtHasta, int idEstadoProbacion, int idAgencia)
        {
            return ObjCredito.ListarCondonaciones(dtDesde, dtHasta, idEstadoProbacion, idAgencia);
        }

        public DataTable ListSoliciAprob()
        {
            return ObjCredito.ListSoliciAprob();
        }

        public DataTable listarAlertaCorreo()
        {
            return ObjCredito.listarAlertaCorreo();
        }

        public DataTable CNInsertaDetalleCondonado(int idAgencia, int idCliente, int TipOper, int EstOper,
                                                  int idMoneda, int idProducto, decimal Monto,
                                                   DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                                                   DateTime FecAprob, int idUsuario, Boolean lExcepcion,
                                                    int idCuenta, decimal nCapital, decimal nInteres, decimal nIntComp, decimal nMora, decimal nGastos, int idTipoCondonacion,
                                                    Decimal nCapitalDeuda, Decimal nInteresDeuda, Decimal nIntCompDeuda, Decimal nMoraDeuda, Decimal nGastosDeuda, 
                                                    bool lRefinanciamiento, string cCTAs, decimal nMontoTotalCTAs,String XMLCoutasCond, String xmlArchivos, int idTipoCorrspondencia
                                                    , string cXmlCobs   , int nNroCuotaCondo    , decimal nMontoPagar   , decimal nMontoITF, int idPerfil, int idSubTipoCorrespondencia)
        {
            return ObjCredito.ADInsertaDetalleCondonado(idAgencia, idCliente, TipOper, EstOper,
                                                        idMoneda, idProducto, Monto, 
                                                         FecSolic, idMotivo, sustento, idEstSolic,
                                                         FecAprob, idUsuario, lExcepcion,
                                                        idCuenta, nCapital, nInteres, nIntComp, nMora, nGastos, idTipoCondonacion, nCapitalDeuda, nInteresDeuda, nIntCompDeuda, nMoraDeuda, nGastosDeuda, 
                                                        lRefinanciamiento, cCTAs, nMontoTotalCTAs, XMLCoutasCond, xmlArchivos, idTipoCorrspondencia
                                                        , cXmlCobs, nNroCuotaCondo, nMontoPagar, nMontoITF, idPerfil, idSubTipoCorrespondencia);
        }
        public DataTable ListaDetalleCondXCuota(int idSol)
        {
            return ObjCredito.ListaDetalleCondXCuota(idSol);
        }
        public clsDBResp CNExtornaCondonacion(int IdKarExtornar, DateTime dFechaExtorno, int idUsuExtorno)
        {
            return ObjCredito.ADExtornaCondonacion(IdKarExtornar, dFechaExtorno, idUsuExtorno);
        }

        public DataTable CNGetDatosExtornoCondonacion(int IdKarExtornar)
        {
            return ObjCredito.ADGetDatosExtornoCondonacion(IdKarExtornar);
        }
        /*===================================================================================================================================================================*/
        /*- Lista tipos de condonaciones: Caso Excepción y campañas                                                                                                                                     */
        /*===================================================================================================================================================================*/
        public DataTable listaTipoCondonacion(int idTipoCondonacion, int idPerfil)
        {
            return ObjCredito.listaTipoCondonacion(idTipoCondonacion, idPerfil);
        }
        public DataTable listaTipoCorrespondencia()
        {
            return ObjCredito.listaTipoCorrespondencia();
        }
        public DataTable listaSubTipoCorrespondencia(int idTipoCorrespondencia)
        {
            return ObjCredito.listaSubTipoCorrespondencia(idTipoCorrespondencia);
        }    
        public DataTable listaReglasTipoCondonacion(int idTipoCondonacion)
        {
            return ObjCredito.listaReglasTipoCondonacion(idTipoCondonacion);
        }
        public DataTable guardarTipoCondonacion(int idTipoCondonacion, String cNombre, String cDescripcion, DateTime dVigInicio, DateTime dVigFin, int idUsu, DateTime dFechaReg, String xmlReglas)
        {
            return ObjCredito.guardarTipoCondonacion(idTipoCondonacion, cNombre, cDescripcion, dVigInicio, dVigFin, idUsu, dFechaReg, xmlReglas);
        }
        public DataTable listaReglasTipoCondonaXCondicCtb(int idTipoCondonacion, int idCondicionCtb)
        {
            var dt = ObjCredito.listaReglasTipoCondonacion(idTipoCondonacion);
            DataTable dtReglas = dt.Clone();
            if (idTipoCondonacion > 1 && idTipoCondonacion != 10) //distinto a la regla especial
            {
                (from item in dt.AsEnumerable()
                 where (int)item["idTipoCartera"] == idCondicionCtb
                 select item).CopyToDataTable(dtReglas, LoadOption.OverwriteChanges);
            }
            else
            {
                dtReglas = dt.Copy();
            }
            return dtReglas;
        }
        public DataTable listaReglasTipoCondonaXRangoTipoDato(int idTipoCondonacion, int idRangoTipoDato)
        {
            var dt = ObjCredito.listaReglasTipoCondonacion(idTipoCondonacion);
            DataTable dtReglas = dt.Clone();
            
                (from item in dt.AsEnumerable()
                 where (int)item["idRangoTipoDato"] == idRangoTipoDato
                 select item).CopyToDataTable(dtReglas, LoadOption.OverwriteChanges);
           
            return dtReglas;
        }
        /*===================================================================================================================================================================*/
        /* CARGA DATOS PARA REPORTE                                                  */
        /*===================================================================================================================================================================*/
        public DataTable listaDatosRptNotaAbono(int idCuenta, int idSolicitud)
        {
            return ObjCredito.listaDatosRptNotaAbono(idCuenta, idSolicitud);
        }
        /*===================================================================================================================================================================*/
        /* CARGA gastos de seguro si existe                                                  */
        /*===================================================================================================================================================================*/
        public DataTable obtieneGastosCuenta(int idCuenta, int idGrupo, int idPlanPagos, int idcuota)
        {
            return ObjCredito.obtieneGastosCuenta(idCuenta, idGrupo, idPlanPagos, idcuota);
        }

        public DataTable filesCondonacion(int idSolAproba, int idCuenta)
        {
            return ObjCredito.filesCondonacion(idSolAproba, idCuenta);
        }   

        public DataTable getFile()
        {
            return ObjCredito.getFile();
        }

        public DataTable CNBuscaSolicitudAprobacion(int idCli, int idCuenta, int idAgencia = 0)
        {
            return ObjCredito.ADBuscaSolicitudAprobacion(idCli, idCuenta, idAgencia);
        }

        public DataTable CNCobsVinculadasACuenta(int idCuenta)
        {
            return ObjCredito.ADCobsVinculadasACuenta(idCuenta);
        }

        public DataTable CNListaCobsVincSolicitudCondonacion(int idSolicitudAproba, int idCuenta = 0)
        {
            return ObjCredito.ADListaCobsVincSolicitudCondonacion(idSolicitudAproba, idCuenta);
        }

        public DataTable CNBuscaSolAprobaCondonacionAprobados(int idCli, int idCuenta, int idAgencia = 0)
        {
            return ObjCredito.ADBuscaSolAprobaCondonacionAprobados(idCli, idCuenta, idAgencia);
        }

        public DataTable CNBuscaCobsXNroOperacion(int idKardex)
        {
            return ObjCredito.ADBuscaCobsXNroOperacion(idKardex);
        }

        public DataTable CNBuscarCondonacionesEjecutadasXIdCuenta(int idCuenta, int idTipoOperacion, int idSolicitud)
        {
            return ObjCredito.ADBuscarCondonacionesEjecutadasXIdCuenta(idCuenta, idTipoOperacion, idSolicitud);
        }

        public DataTable CNCredPendientesRefinanciar(int idAgencia)
        {
            return ObjCredito.CredPendientesRefinanciar(idAgencia);
        }

        public DataTable getCobsDisponibles(int idAgencia)
        {
            return ObjCredito.getCobsDisponibles(idAgencia);
        }

        public DataTable getCobsDisponiblesZona(int idAgencia)
        {
            return ObjCredito.getCobsDisponiblesZona(idAgencia);
        }

        public DataTable nombreZona(int idAgencia)
        {
            return ObjCredito.nombreZona(idAgencia);
        }

        public DataTable validarCOBs(string xmlCOBs)
        {
            return ObjCredito.validarCOBs(xmlCOBs);
        }

        public DataTable insertarGrupoCobsAfectaciones(string xmlCOBs, DateTime dFechaSis, int idUsuario, int idTipoAfectacion, string cComentario)
        {
            return ObjCredito.insertarGrupoCobsAfectaciones(xmlCOBs, dFechaSis, idUsuario, idTipoAfectacion, cComentario);
        }

        public DataTable ListarCobsGrupo(int idGrupo)
        {
            return ObjCredito.ListarCobsGrupo(idGrupo);
        }

        public DataTable rptSBSCliente(int idCuenta)
        {
            return ObjCredito.rptSBSCliente(idCuenta);
        }

        public DataTable esPendienteARefinanciar(int idCuenta)
        {
            return ObjCredito.esPendienteARefinanciar(idCuenta);
        }

        public DataTable verificarSolicitudCondonacion(int idCuenta)
        {
            return ObjCredito.verificarSolicitudCondonacion(idCuenta);
        }

        public DataTable verificarConsolidacion(int idCuenta)
        {
            return ObjCredito.verificarConsolidacion(idCuenta);
        }
        
        public DataTable CNCargarAfectacionCob(int idSolicitudAproba, int idCuenta = 0)
        {
            return ObjCredito.ADCargarAfectacionCob(idSolicitudAproba, idCuenta);
        }

        public DataTable ListarAfectaciones(DateTime dtDesde, DateTime dtHasta, int idEstadoProbacion)
        {
            return ObjCredito.ListarAfectaciones(dtDesde, dtHasta, idEstadoProbacion);
        }
    }
}
