using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;

namespace DEP.AccesoDatos
{
    public class clsADValorados
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSP = new clsGENEjeSP();
        //Lista Valorados Asignados a una agencia
        public DataTable ADListaValorados(string cTipoBus,int idTipoValorado, int idTipoMoneda, int idAgencia, DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("DEP_RetornaValoradoAsig_sp", cTipoBus, idTipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        //Guarda Asignacion de valorados a una Agencia
        public DataTable ADGuardarIngresoValorado(int idTipoValorado, int idTipoMoneda, int idAgencia, int idValorado,
                                                   int nNumserie, int nNumInicio, int nNumFin, int idUsuOrigen, int idUsuDestino,
                                                   DateTime dFechaEntrega, int idEstadoVal, int idUsuMod, DateTime dFechaMod, string cMotivo)
        {
            return objEjeSP.EjecSP("DEP_GuardaValoradoAsig_sp", idTipoValorado, idTipoMoneda, idAgencia, idValorado,
                                                         nNumserie, nNumInicio, nNumFin, idUsuOrigen, idUsuDestino,
                                                         dFechaEntrega, idEstadoVal, idUsuMod, dFechaMod, cMotivo);
        }
        //Guarda Generacion de valorados
        public DataTable ADGuardarGeneracionValorado( int idValorado, int nNumserie, int nNumInicio, int nNumFin, 
                                                      int idUsuOrigen, int idUsuDestino,DateTime dFechaEntrega, int idEstadoVal)
        {
            return objEjeSP.EjecSP("DEP_GuardaValoradoGen_sp",idValorado, nNumserie, nNumInicio, nNumFin, 
                                                              idUsuOrigen, idUsuDestino,dFechaEntrega, idEstadoVal);
        }
        //valida la Asignacion de Valorados
        public DataTable ADValidaAsigValorado( int idValorado,int idTipoValorado, int idTipoMoneda, int idAgencia,int nNumserie, 
                                                  int nNumInicio, int nNumFin)
        {
            return objEjeSP.EjecSP("DEP_ValidaRegValorado_sp", idValorado, idTipoValorado, idTipoMoneda, idAgencia, nNumserie, 
                                                    nNumInicio, nNumFin);
        }
        //Lista Valorados Entregados dentro de la Agencia
        public DataTable ADListaValoradosEntregados(string cTipoBus, int idTipoValorado, int idTipoMoneda, int idAgencia,
                                                    DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("DEP_ListaValoradosEntregados_sp", cTipoBus, idTipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        //Lista Valorados generados para cetificados PF
        public DataTable ADListaValoradosGeneradoCertificadoPF( int idTipoMoneda, int idAgencia, 
                                                    DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("DEP_ListaCertificadoPFGenerados_sp", idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        //Lista Valorados generados para OP
        public DataTable ADListaValoradosGeneradosOP(int idTipoMoneda, int idAgencia,  DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("DEP_ListaOrdenPagoGenerados_sp", idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
           
        //Lista Valorados Asignados a Agencia
        public DataTable ADListaValAsigAge(int idAgencia)
        {
            return objEjeSP.EjecSP("DEP_ListaValorxAgencia_sp",idAgencia);
        }
        //Lista Valorados Generados en Agencia
        public DataTable ADListaValGenAge(int idAgencia, int idMoneda, int idValorado)
        {
            return objEjeSP.EjecSP("DEP_ListaValGenerados_sp", idAgencia, idMoneda, idValorado);
        }
        //Lista Estados de Vinculacion de ordenes
        public DataTable ADListaEstVincu()
        {
            return objEjeSP.EjecSP("DEP_ListaEstVinc_sp");
        }
        //Lista Valorados por Cuenta
        public DataTable ADListaValoradosxCuenta(int idCuenta, int idTipoValorado,int idUsuario)
        {
            return objEjeSP.EjecSP("DEP_RetornaValoradosxCuenta_sp", idCuenta, idTipoValorado, idUsuario);
        }
        //Lista Detalle de Valorados
        public DataTable ADListaDetalleValorados(int idCuenta, int idVincuCuenta)
        {
            return objEjeSP.EjecSP("DEP_RetornaDetValorados_sp", idCuenta, idVincuCuenta);
        }
        //Guarda la Vinculacion a una Cuenta
        public DataTable ADGuardarVinculacion(int idVincuCuenta, int idValorado, int idCuenta, int nserie, 
                                              int nNumInicio, int nNumFin, int idUsuOpe, int idAgencia, 
                                              DateTime dFechaEntrega, int idEstadoVinc, string XMLDetalleVal,
                                               DateTime dFechaMod, int idUsuMod, string cMotivo, bool lIndBloqTot)
        {
            return objEjeSP.EjecSP("DEP_GuardaValoradoVinc_sp", idVincuCuenta, idValorado, idCuenta, nserie, 
                                                                nNumInicio, nNumFin, idUsuOpe, idAgencia, 
                                                                dFechaEntrega, idEstadoVinc, XMLDetalleVal,
                                                                dFechaMod, idUsuMod, cMotivo, lIndBloqTot);
        }
        //Lista Limites de Vinculacion de valorados
        public DataTable ADListaLimiteValorados()
        {
            return objEjeSP.EjecSP("DEP_ListaLimitesValorados_sp");
        }
        public DataTable ADListaLimiteValoradosXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinLimiteValorado");
        }
        //Lista detalle de Valorados Generados
        public DataTable ADListaDetValgen(int idvalorado,int nSerie, int nInicio, int nFin)
        {
            return objEjeSP.EjecSP("DEP_ListaDetalleValorados_sp",idvalorado, nSerie, nInicio, nFin );
        }

        public DataTable ListaValoradosPend()
        {
            return objEjeSP.EjecSP("DEP_ListarValorados_sp");
        }
        public DataTable ValorizarValPend(Boolean AcepRech, int idKardex, int idCuenta, decimal Monto, int idusuario, DateTime FecValorizacion, string Motivo, string cNroDoc, string cSerieDoc, decimal nMontoComision,
            int idAgencia, int idTipoValorado, int idConcepto)
        {
            return objEjeSP.EjecSP("DEP_ValorizarValPend_sp", AcepRech, idKardex, idCuenta, Monto, idusuario, FecValorizacion, Motivo, cNroDoc, cSerieDoc,  nMontoComision,
                idAgencia, idTipoValorado, idConcepto);
        }
        //Valida la Anulacion de Valorados
        public DataTable ADValidaModifiValorado(int idTipoValorado, int nSerie, int idAgencia, int nInicio, int idEstado)
        {
            return objEjeSP.EjecSP("DEP_ValidaModValorado_sp", idTipoValorado, nSerie, idAgencia, nInicio,idEstado);  
        }
        //Valida la vinculacion de Certificado
        public DataTable ADValidaVincuCerti(int nCertificado, int idMoneda, int idAgencia)
        {
            return objEjeSP.EjecSP("DEP_ValidaVincuCerti_sp", nCertificado, idMoneda,idAgencia);
        }
        //Valida si Existen generados los certificados


        public DataTable ADValidaGenCerti(int nCertificado, int idMoneda, int idTipoValorado, int idAgencia)
        {
            return objEjeSP.EjecSP("DEP_ValidaSerieGen_sp", nCertificado, idMoneda, idTipoValorado, idAgencia);
        }
        //Guarda Vinculacion de Certificados
        public DataTable ADGuardaVinculacionCerti(int nCertificado, int idValorado, int nSerie, int idCuenta,
                                                  int idUsuario, int idAgencia, DateTime dFechaVincu, int idKardex)
        {
            return objEjeSP.EjecSP("DEP_GuardarVincuCerti_sp", nCertificado, idValorado, nSerie, idCuenta,
                                                               idUsuario, idAgencia, dFechaVincu, idKardex);
        }
        //Lista Detalle Valorados Generados
        public DataTable ADListaDetalleValorados(string cTipoBus, int idAgencia,int idTipoValorado, int idTipoMoneda,
                                                    DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("DEP_ListaDetalleValoradosxAgencia_sp", cTipoBus, idAgencia, idTipoValorado, idTipoMoneda,
                                        dFechaInicio,  dFechaFinal);
        }

       public DataTable ADListaValorados(int idEstadoVal, DateTime dFecIni, DateTime dFecFin,DateTime dFecOpe)
        {
            return objEjeSP.EjecSP("DEP_ReporteValorados_Sp", idEstadoVal, dFecIni, dFecFin, dFecOpe);
        }
       
       //--===============================================
       //--Listar las Modalidades de Solicitud
       //--===============================================
       public DataTable ADListarModalidadSolVal()
       {
           return objEjeSP.EjecSP("DEP_ListarModalidadSolVal_sp");
       }

       //--===============================================
       //--Listar los Tipos de Pago de las Solic. Valorado
       //--===============================================
       public DataTable ADListarTiposPagoSolVal()
       {
           return objEjeSP.EjecSP("DEP_ListarTipoPagoSolVal_sp");
       }

       //--================================================================
       //--Registrar Solicitud de Orden de Pago
       //--================================================================
       public DataTable ADRegistrarSolicitudOP(int x_idCuenta, int x_idMoneda, int x_idAgencia, int x_idUsuario, DateTime x_dFechaSol,
                                                int x_nNumTalonar, int x_nCanPorTal, int x_idModPagOp, int x_idModSolOP, string x_cDescriCarta, string @xmlInterv)
       {
           return objEjeSP.EjecSP("DEP_RegistraSolicitudOp_Sp", x_idCuenta, x_idMoneda, x_idAgencia, x_idUsuario, x_dFechaSol,
                                                    x_nNumTalonar, x_nCanPorTal, x_idModPagOp, x_idModSolOP, x_cDescriCarta, @xmlInterv);
       }


       //--================================================================
       //--Obtener el Maximo Lote y Folio
       //--================================================================
       public DataTable ADNroMaximoLoteFolio(int idTipoValorado,int idMoneda)
       {
           return objEjeSP.EjecSP("DEP_NroMaxLotesValorados_sp", idTipoValorado, idMoneda);
       }

       //--================================================================
       //--Registrar Solicitud de Orden de Pago
       //--================================================================
       public DataTable ADRegistrarValorados(int x_idTipValorado, int x_idMoneda, int x_nNumLOte, int x_nInicio, int x_nfin,
                                             int x_nTotalLote, int x_nTotalMal, DateTime x_dFechaReg, int x_idUsuario, int x_idAgencia, string @xmlDetVal)
       {
           return objEjeSP.EjecSP("DEP_RegistrarValorados_Sp", x_idTipValorado, x_idMoneda, x_nNumLOte, x_nInicio, x_nfin,
                                                                x_nTotalLote, x_nTotalMal, x_dFechaReg, x_idUsuario, x_idAgencia,  @xmlDetVal);
       }

       //--================================================================
       //--Solicitudes de OP
       //--================================================================
       public DataTable ADListarSolicitudOP(int idAgencia, int idMoneda)
       {
           return objEjeSP.EjecSP("DEP_SolicitudPendienteOP_Sp", idAgencia, idMoneda);
       }

       //--================================================================
       //--Listado Detalle de OP
       //--================================================================
       public DataTable ADListarDetalleOP(int idAgencia, int idMoneda,int nCantidad,int idCuenta,int x_idSolOP, int x_idEstadoVal)
       {
           return objEjeSP.EjecSP("DEP_DetalleImpresionOP_Sp", idAgencia, idMoneda, nCantidad, idCuenta, x_idSolOP, x_idEstadoVal);
       }

       //--================================================================
       //--Registro de Vinculación de la Cta con las OP
       //--================================================================
       public DataTable ADRegistroVinculoOP(int idUsuario, int idAgencia, int idSolOP, DateTime dFechaReg, string xmlDetalleOP)
       {
           return objEjeSP.EjecSP("DEP_VinculaCuentaOP_Sp", idUsuario, idAgencia, idSolOP, dFechaReg, xmlDetalleOP);
       }

       //--================================================================
       //--Imprimir OP
       //--================================================================
       public DataTable ADImprimirOP(string XMLConfigOP,int idCuenta, int idSolOP, int idOpc,int idUsu,int idAge,DateTime dFecReg)
       {
           return objEjeSP.EjecSP("DEP_ListaImpresionOP_Sp", XMLConfigOP,idCuenta, idSolOP, idOpc, idUsu, idAge, dFecReg);
       }

       //--================================================================
       //--Valorados para Envió
       //--================================================================
       public DataTable ADValoradosParaEnvio(int idAgencia,int idEstadoval)
       {
           return objEjeSP.EjecSP("DEP_ValoradosParaEnvio_Sp", idAgencia, idEstadoval);
       }

       //--================================================================
       //--Certificados para Envió
       //--================================================================
       public DataTable ADCertificadosParaEnvio(int idAgencia, int nCantidad, int idOpcion)
       {
           return objEjeSP.EjecSP("DEP_ListadoCertificados_Sp", idAgencia, nCantidad, idOpcion);
       }

       //--================================================================
       //--Registrar Envió de OP
       //--================================================================
       public DataTable ADRegistraEnvioOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioOP, int idEstado, string cDescri, string idUsuDestino)
       {
           return objEjeSP.EjecSP("DEP_RegistraEnvioOP_Sp", idUsuario, idAgencia, dFechaReg, xmlEnvioOP, idEstado, cDescri, idUsuDestino);
       }

       //--================================================================
       //--Registrar Envió de Certificados
       //--================================================================
       public DataTable ADRegistraEnvioCertificados(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, int idEstado, string cDescri, string idUsuDestino)
       {
           return objEjeSP.EjecSP("DEP_RegistraEnvioCertificados_Sp", idUsuario, idAgencia, dFechaReg, xmlEnvioCert, idEstado, cDescri, idUsuDestino);
       }

       //--================================================================
       //--Detalle de Firmas OP
       //--================================================================
       public DataTable ADDetalleFirmasOP(int idCuenta)
       {
           return objEjeSP.EjecSP("DEP_DetalleFirmasOP_Sp", idCuenta);
       }

       //--================================================================
       //--Detalle de Solicitudes de OP Listos
       //--================================================================
       public DataTable ADDetalleOPRecepcionados(int idCuenta,int idAgencia)
       {
           return objEjeSP.EjecSP("DEP_ListadoOPEntrega_Sp", idCuenta, idAgencia);
       }

       //--===============================================
       //--Listar Estados de la Solicitud
       //--===============================================
       public DataTable ADListarEstadosSol()
       {
           return objEjeSP.EjecSP("DEP_ListarEstadosSolOP_Sp");
       }

       //--===============================================
       //--Listar Solicitudes por Estado
       //--===============================================
       public DataTable ADListarSolicitudesxEstado(int idEstado,int idCuenta)
       {
           return objEjeSP.EjecSP("DEP_ListarSolicitudesOPEstado_Sp", idEstado, idCuenta);
       }

       //--===============================================
       //--Listar Solicitudes Ordenes de Pago
       //--===============================================
       public DataTable ADListarSolicitudesOPDetalle(int idSolOP)
       {
           return objEjeSP.EjecSP("DEP_ListarOrdenesPagoSol_Sp", idSolOP);
       }

       //--================================================================
       //--Registrar Mantenimiento de OP
       //--================================================================
       public DataTable ADRegistramantenimientoOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlMantOP, int idOpcion, string cDescri,int idSolOp)
       {
           return objEjeSP.EjecSP("DEP_MantenimientoOP_Sp", idUsuario, idAgencia, dFechaReg, xmlMantOP, idOpcion, cDescri, idSolOp);
       }

       //--================================================================
       //--Vincula Certificado con Cuenta
       //--================================================================
       public DataTable ADVinculaCtaCertificado(int nNroFolio, int idCuenta, int idUsuario, int idAgencia, DateTime dFechaReg, string cMotivo, int nFolioAnt)
       {
           return objEjeSP.EjecSP("DEP_RegVinculacionCertificado_sp", nNroFolio, idCuenta, idUsuario, idAgencia, dFechaReg, cMotivo, nFolioAnt);
       }

       //--===============================================
       //--Retorna Datos del certificado
       //--===============================================
       public DataTable ADRetornaDatosCertificado(int nNroFolio)
       {
           return objEjeSP.EjecSP("DEP_MantenimientoCertificados_sp", nNroFolio);
       }

       //--===============================================
       //--Eliminar Certificado
       //--===============================================
       public DataTable ADAnularCertificado(int nNroFolio, int idCuenta, int idUsuario, int idAgencia, DateTime dFechaReg, string cMotivo)
       {
           return objEjeSP.EjecSP("DEP_AnularCertificados_sp", nNroFolio, idCuenta, idUsuario, idAgencia, dFechaReg, cMotivo);
       }
       //--===============================================
       //--Listar tipo de  plaza
       //--===============================================
       public DataTable ADTipoPlaza(int idProducto, int idTipoValorado,bool lAprobar, int idAgencia, int idConcepto)
       {
           return objEjeSP.EjecSP("DEP_ListaTipoPlaza", idProducto, idTipoValorado,lAprobar, idAgencia, idConcepto);
       }

       //--===============================================
       //--Validar Número de Folio
       //--===============================================
       public DataTable ADValidaNroFolio(int nNroFolio)
       {
           return objEjeSP.EjecSP("DEP_ValidaExisteFolio_Sp", nNroFolio);
       }

       //--===============================================
       //--Registrar Cambio de Ordenes de Pago
       //--===============================================
       public DataTable ADRegistraCambioOP(int idCuenta, int idSolOP,int idUsu,int idAgencia,DateTime dFecha,string XMLAnulados,string XMLNuevos)
       {
           return objEjeSP.EjecSP("DEP_RegCambioDeFolios_SP", idCuenta, idSolOP, idUsu, idAgencia, dFecha, XMLAnulados, XMLNuevos);
       }
       //--===============================================
       //--Datos Solicitud OP
       //--===============================================

       public DataTable ADRetornaDatosSolOP(int idSolicitud, int idCuenta)
       {

           return objEjeSP.EjecSP("DEP_RetornaDatosSolOP_sp", idSolicitud, idCuenta);
       }
       //--===============================================
       //--Eliminar Certificado
       //--===============================================
       public DataTable ADImprimirActaEntregaOP(int IdCuenta, DateTime dFechaOP,string cidSolicitud,int idagencia)
       {
           return objEjeSP.EjecSP("DEP_RptActaEntregaOP_SP", IdCuenta, dFechaOP, cidSolicitud,idagencia);
       }
       //--================================================================
       //--Registrar rechazo de valorados ordenes de pago
       //--================================================================
       public DataTable ADRechazoValoradoRecepOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, string cDescri)
       {
           return objEjeSP.EjecSP("DEP_RechazoValoradoRecepOP_Sp", idUsuario, idAgencia, dFechaReg, xmlEnvioCert, cDescri);
       }
       //--================================================================
       //--Registrar rechazo de valorados certificados
       //--================================================================
       public DataTable ADRechazoValoradoRecepCert(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, string cDescri)
       {
           return objEjeSP.EjecSP("DEP_RechazoValoradoRecepCert_Sp", idUsuario, idAgencia, dFechaReg, xmlEnvioCert, cDescri);
       }
    
       public DataTable ADRetornaDatosSolOP(int idAgenciaOrigen, int idSolicitud, int idCuenta)
       {

           return objEjeSP.EjecSP("DEP_RetornaDatosSolOP_sp", idAgenciaOrigen, idSolicitud, idCuenta);
       }
       public DataTable ADListEstSolOP()
       {
            return objEjeSP.EjecSP("DEP_ListEstSolOP");
       }
       public DataTable ADRptSolOP(int idAgencia, int idEstado, DateTime dFechaCorte)
       {
           return objEjeSP.EjecSP("DEP_RptSolOP_SP", idAgencia, idEstado, dFechaCorte);
       }

       public DataTable ListaValoradosPendActualizar(int x_idAgencia)
       {
           return objEjeSP.EjecSP("DEP_ListaValoradosActualizar_sp", x_idAgencia);
       }

       public DataTable ActualizarDatosOperacion(int x_idKardex, int x_idCuenta, DateTime x_dFechaEmi, string x_nNroDoc, string x_cSerieDoc, DateTime x_dFechaReg, int x_idUsuario)
       {
           return objEjeSP.EjecSP("DEP_ActualizarDatosOpeInterban_sp", x_idKardex, x_idCuenta, x_dFechaEmi, x_nNroDoc, x_cSerieDoc, x_dFechaReg, x_idUsuario);
       }

    }
}
