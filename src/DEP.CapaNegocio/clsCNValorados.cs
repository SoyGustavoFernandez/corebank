using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DEP.AccesoDatos;
using EntityLayer;

namespace DEP.CapaNegocio
{
    public class clsCNValorados
    {
        clsADValorados objValorados = new clsADValorados();
        public DataTable CNListaValorados(string cTipoBus, int idTipoValorado, int idTipoMoneda, int idAgencia, DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objValorados.ADListaValorados(cTipoBus, idTipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        public DataTable CNGuardarIngresoValorado(int idTipoValorado,int idTipoMoneda,int idAgencia,int idValorado,
                                                   int nNumserie,int nNumInicio,int nNumFin,int idUsuOrigen,int idUsuDestino,
                                                   DateTime dFechaEntrega,int idEstadoVal, int idUsuMod,DateTime dFechaMod,string cMotivo)
        {
            return objValorados.ADGuardarIngresoValorado(idTipoValorado, idTipoMoneda, idAgencia, idValorado,
                                                         nNumserie, nNumInicio, nNumFin, idUsuOrigen, idUsuDestino,
                                                         dFechaEntrega, idEstadoVal,  idUsuMod, dFechaMod, cMotivo);
        }
        //Guarda Generacion de valorados

        public DataTable CNGuardarGeneracionValorado(int idValorado, int nNumserie, int nNumInicio, int nNumFin,
                                                      int idUsuOrigen, int idUsuDestino, DateTime dFechaEntrega, int idEstadoVal)
        {
            return objValorados.ADGuardarGeneracionValorado(idValorado, nNumserie, nNumInicio, nNumFin,
                                                              idUsuOrigen, idUsuDestino, dFechaEntrega, idEstadoVal);
        }
        public DataTable CNValidaAsigValorado(int idValorado, int idTipoValorado, int idTipoMoneda, int idAgencia, int nNumserie, 
                                                  int nNumInicio, int nNumFin)
        {
            return objValorados.ADValidaAsigValorado(idValorado, idTipoValorado, idTipoMoneda, idAgencia, nNumserie,
                                                    nNumInicio, nNumFin);
        }
        public DataTable CNListaValoradosGeneradoCertificadoPF(int idTipoMoneda, int idAgencia,DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objValorados.ADListaValoradosGeneradoCertificadoPF( idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        public DataTable CNListaValoradosGeneradosOP(int idTipoMoneda, int idAgencia,DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objValorados.ADListaValoradosGeneradosOP( idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        public DataTable CNListaValoradosEntregados(string cTipoBus, int idTipoValorado, int idTipoMoneda, int idAgencia,
                                                DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objValorados.ADListaValoradosEntregados(cTipoBus, idTipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFinal);
        }
        public DataTable CNListaValAsigAge(int idAgencia)
        {
            return objValorados.ADListaValAsigAge(idAgencia);
        }
        public DataTable CNListaValGenAge(int idAgencia, int idMoneda, int idValorado)
        {
            return objValorados.ADListaValGenAge(idAgencia, idMoneda, idValorado);
        }
        public DataTable CNListaEstVincu()
        {
            return objValorados.ADListaEstVincu();
        }
        public DataTable CNListaValoradosxCuenta(int idCuenta, int idTipoValorado, int idUsuario)
        {
            return objValorados.ADListaValoradosxCuenta(idCuenta, idTipoValorado, idUsuario);
        }
        public DataTable CNGeneraSerieValorados(int idVincuCuenta, int idCuenta, int nInicio, int nNum)
        {
            DataTable ValoradosGen = new DataTable();
            ValoradosGen.Columns.Add("idVincuCuenta", typeof(int));
            ValoradosGen.Columns.Add("idCuenta", typeof(int));
            ValoradosGen.Columns.Add("nNumValorado", typeof(int));
            ValoradosGen.Columns.Add("idKardex", typeof(int));
            ValoradosGen.Columns.Add("idEstadoVal", typeof(int));
            ValoradosGen.Columns.Add("dFechaOpe", typeof(DateTime));

            for (int i = 0; i < nNum; i++)
            {
                DataRow fila = ValoradosGen.NewRow();
                fila["idVincuCuenta"] = idVincuCuenta;
                fila["idCuenta"] = idCuenta;
                fila["nNumValorado"] = nInicio+i;
                fila["idKardex"] = 0;
                fila["idEstadoVal"] = 1;
                fila["dFechaOpe"] = clsVarGlobal.dFecSystem;
                ValoradosGen.Rows.Add(fila);
            }
            return ValoradosGen;
        }
        //Lista Detalle de Valorados
        public DataTable CNListaDetalleValorados(int idCuenta, int idVincuCuenta)
        {
            return objValorados.ADListaDetalleValorados(idCuenta, idVincuCuenta);
        }
        //Guardar Vinculacion de valorados a una cuenta
        public DataTable CNGuardarVinculacion(int idVincuCuenta, int idValorado, int idCuenta, int nserie,
                                              int nNumInicio, int nNumFin, int idUsuOpe, int idAgencia,
                                              DateTime dFechaEntrega, int idEstadoVinc, string XMLDetalleVal,
                                               DateTime dFechaMod, int idUsuMod, string cMotivo, bool lIndBloqTot)
        {
            return objValorados.ADGuardarVinculacion(idVincuCuenta, idValorado, idCuenta, nserie,
                                                     nNumInicio, nNumFin, idUsuOpe, idAgencia,
                                                     dFechaEntrega, idEstadoVinc, XMLDetalleVal,
                                                     dFechaMod, idUsuMod, cMotivo, lIndBloqTot);
        }
        //Lista Limites de Vinculacion de valorados
        public DataTable CNListaLimiteValorados()
        {
            //return objValorados.ADListaLimiteValorados();

            var dt = objValorados.ADListaLimiteValoradosXML();
            DataTable dtLimVal = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtLimVal, LoadOption.OverwriteChanges);
            return dtLimVal;
        }
        //Lista detalle de Valorados Generados
        public DataTable CNListaDetValgen(int idvalorado, int nSerie, int nInicio, int nFin)
        {
            return objValorados.ADListaDetValgen(idvalorado, nSerie, nInicio, nFin);
        }
        public DataTable ListaValoradosPend()
        {
            return objValorados.ListaValoradosPend();
        }
        public DataTable ValorizarValPend(Boolean AcepRech, int idKarde, int idCuenta, decimal Monto, int idusuario, DateTime FecValorizacion, string Motivo, string cNroDoc,string cSerieDoc, decimal nMontoComision,
                                    int idAgencia,int idTipoValorado,int  idConcepto)
        {
            return objValorados.ValorizarValPend(AcepRech, idKarde, idCuenta, Monto, idusuario, FecValorizacion, Motivo, cNroDoc, cSerieDoc, nMontoComision,
                                        idAgencia, idTipoValorado, idConcepto);
        }
        //Valida la Anulacion de Valorados
        public DataTable CNValidaModifiValorado(int idTipoValorado, int nSerie, int idAgencia, int nInicio, int idEstado)
        {
            return objValorados.ADValidaModifiValorado(idTipoValorado, nSerie, idAgencia, nInicio, idEstado);
        }
        //Valida la vinculacion de Certificado
        public DataTable CNValidaVincuCerti(int nCertificado, int idMoneda, int idAgencia)
        {
            return objValorados.ADValidaVincuCerti(nCertificado, idMoneda, idAgencia);
        }
        //Valida si Existen generados los certificados
     
        public DataTable CNValidaGenCerti(int nCertificado, int idMoneda, int idTipoValorado, int idAgencia)
        {
            return objValorados.ADValidaGenCerti(nCertificado, idMoneda, idTipoValorado, idAgencia);
        }
        //Guarda Vinculacion de Certificados
        public DataTable CNGuardaVinculacionCerti(int nCertificado, int idValorado, int nSerie, int idCuenta,
                                                  int idUsuario, int idAgencia, DateTime dFechaVincu, int idKardex)
        {
            return objValorados.ADGuardaVinculacionCerti(nCertificado, idValorado, nSerie, idCuenta,
                                                               idUsuario, idAgencia, dFechaVincu, idKardex);
        }
        //Lista Detalle Valorados Generados
        public DataTable CNListaDetalleValorados(string cTipoBus, int idAgencia, int idTipoValorado, int idTipoMoneda,
                                                    DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objValorados.ADListaDetalleValorados(cTipoBus, idAgencia, idTipoValorado, idTipoMoneda,
                                        dFechaInicio, dFechaFinal);
        }

       public DataTable CNEstValorados(int idEstadoVal, DateTime dFecIni, DateTime dFecFin,DateTime dFecOpe)
        {
            return objValorados.ADListaValorados(idEstadoVal, dFecIni, dFecFin, dFecOpe);
        }

       //--============================================================
       //--Listar las Modalidades de Solicitud del Valorado
       //--============================================================
       public DataTable CNListarModalidadSolVal()
       {
           return objValorados.ADListarModalidadSolVal();
       }

       //--============================================================
       //--Listar los Tipos de Pago de la Solicitud del Valorado
       //--============================================================
       public DataTable CNListarTiposPagoSolVal()
       {
           return objValorados.ADListarTiposPagoSolVal();
       }

       //--================================================================
       //--Registrar Solicitud de Orden de Pago
       //--================================================================
       public DataTable CNRegistrarSolicitudOP(int x_idCuenta, int x_idMoneda, int x_idAgencia, int x_idUsuario, DateTime x_dFechaSol, 
                                                int x_nNumTalonar, int x_nCanPorTal, int x_idModPagOp, int x_idModSolOP, string x_cDescriCarta, string @xmlInterv)
       {
           return objValorados.ADRegistrarSolicitudOP(x_idCuenta, x_idMoneda, x_idAgencia, x_idUsuario, x_dFechaSol,
                                                    x_nNumTalonar, x_nCanPorTal, x_idModPagOp, x_idModSolOP, x_cDescriCarta, @xmlInterv);
       }


       //--================================================================
       //--Obtener el Maximo Lote y Folio
       //--================================================================
       public DataTable CNNroMaximoLoteFolio(int idTipoValorado, int idMoneda)
       {
           return objValorados.ADNroMaximoLoteFolio(idTipoValorado, idMoneda);
       }

        //--================================================================
        //--Registrar Solicitud de Orden de Pago
        //--================================================================
       public DataTable CNRegistrarValorados(int x_idTipValorado, int x_idMoneda, int x_nNumLOte, int x_nInicio, int x_nfin,
                                             int x_nTotalLote, int x_nTotalMal, DateTime x_dFechaReg, int x_idUsuario, int x_idAgencia, string @xmlDetVal)
       {
           return objValorados.ADRegistrarValorados(x_idTipValorado, x_idMoneda, x_nNumLOte, x_nInicio, x_nfin,
                                                    x_nTotalLote, x_nTotalMal, x_dFechaReg, x_idUsuario, x_idAgencia, @xmlDetVal);
       }

       //--================================================================
       //--Obtener lista solicitud de OP
       //--================================================================
       public DataTable CNListarSolicitudOP(int idAgencia, int idMoneda)
       {
           return objValorados.ADListarSolicitudOP(idAgencia, idMoneda);
       }

       //--================================================================
       //--Listado Detalle de OP
       //--================================================================
       public DataTable CNListarDetalleOP(int idAgencia, int idMoneda, int nCantidad, int idCuenta, int x_idSolOP, int x_idEstadoVal)
       {
           return objValorados.ADListarDetalleOP(idAgencia, idMoneda, nCantidad, idCuenta, x_idSolOP, x_idEstadoVal);
       }

       //--================================================================
       //--Registro de Vinculación de la Cta con las OP
       //--================================================================
       public DataTable CNRegistroVinculoOP(int idUsuario, int idAgencia, int idSolOP, DateTime dFechaReg, string xmlDetalleOP)
       {
           return objValorados.ADRegistroVinculoOP(idUsuario, idAgencia, idSolOP, dFechaReg, xmlDetalleOP);
       }

       //--================================================================
       //--Registro de Impresion de OP
       //--================================================================
       public DataTable CNImprimirOP(string XMLConfigOP, int idCuenta, int idSolOP, int idOpc, int idUsu, int idAge, DateTime dFecReg)
       {
           return objValorados.ADImprimirOP(XMLConfigOP, idCuenta, idSolOP, idOpc, idUsu, idAge, dFecReg);
       }

       //--================================================================
       //--Valorados Filtrado por Estados
       //--================================================================
       public DataTable CNValoradosParaEnvio(int idAgencia, int idEstadoval)
       {
           return objValorados.ADValoradosParaEnvio(idAgencia, idEstadoval);
       }

       //--================================================================
       //--Certificados para Envió
       //--================================================================
       public DataTable CNCertificadosParaEnvio(int idAgencia, int nCantidad, int idOpcion)
       {
           return objValorados.ADCertificadosParaEnvio(idAgencia, nCantidad, idOpcion);
       }

       //--================================================================
       //--Registrar Envió de OP
       //--================================================================
       public DataTable CNRegistraEnvioOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioOP, int idEstado, string cDescri,string idUsuDestino )
       {
           return objValorados.ADRegistraEnvioOP(idUsuario, idAgencia, dFechaReg, xmlEnvioOP, idEstado, cDescri, idUsuDestino);
       }

       //--================================================================
       //--Registrar Envió de Certificados
       //--================================================================
       public DataTable CNRegistraEnvioCertificados(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, int idEstado, string cDescri,string idUsuDestino)
       {
           return objValorados.ADRegistraEnvioCertificados(idUsuario, idAgencia, dFechaReg, xmlEnvioCert, idEstado, cDescri, idUsuDestino);
       }

       //--================================================================
       //--Detalle de Firmas OP
       //--================================================================
       public DataTable CNDetalleFirmasOP(int idCuenta)
       {
           return objValorados.ADDetalleFirmasOP(idCuenta);
       }

       //--================================================================
       //--Detalle de Solicitudes de OP Listos
       //--================================================================
       public DataTable CNDetalleOPRecepcionados(int idCuenta,int idAgencia)
       {
           return objValorados.ADDetalleOPRecepcionados(idCuenta, idAgencia);
       }

       //--================================================================
       //--Listar Estados de la Solicitud
       //--================================================================
       public DataTable CNListarEstadosSol()
       {
           return objValorados.ADListarEstadosSol();
       }

       //--================================================================
       //--Listar Solicitudes por Estado
       //--================================================================
       public DataTable CNListarSolicitudesxEstado(int idEstado, int idCuenta)
       {
           return objValorados.ADListarSolicitudesxEstado(idEstado, idCuenta);
       }

       //--================================================================
       //--Listar Solicitudes de OP por id solicitud
       //--================================================================
       public DataTable CNListarSolicitudesOPDetalle(int idSolOP)
       {
           return objValorados.ADListarSolicitudesOPDetalle(idSolOP);
       }

       //--================================================================
       //---Registrar Mantenimiento de OP
       //--================================================================
       public DataTable CNRegistramantenimientoOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlMantOP, int idOpcion, string cDescri, int idSolOp)
       {
           return objValorados.ADRegistramantenimientoOP(idUsuario, idAgencia, dFechaReg, xmlMantOP, idOpcion, cDescri, idSolOp);
       }

       //--================================================================
       //---Vincula Certificado con Cuenta
       //--================================================================
       public DataTable CNVinculaCtaCertificado(int nNroFolio, int idCuenta, int idUsuario, int idAgencia, DateTime dFechaReg, string cMotivo, int nFolioAnt)
       {
           return objValorados.ADVinculaCtaCertificado(nNroFolio, idCuenta, idUsuario, idAgencia, dFechaReg, cMotivo, nFolioAnt);
       }

       //--================================================================
       //--Retorna Datos del certificado
       //--================================================================
       public DataTable CNRetornaDatosCertificado(int nNroFolio)
       {
           return objValorados.ADRetornaDatosCertificado(nNroFolio);
       }

       //--================================================================
       //--Eliminar Certificado
       //--================================================================
       public DataTable CNAnularCertificado(int nNroFolio, int idCuenta, int idUsuario, int idAgencia, DateTime dFechaReg, string cMotivo)
       {
           return objValorados.ADAnularCertificado(nNroFolio, idCuenta, idUsuario, idAgencia, dFechaReg, cMotivo);
       }
       //--================================================================
       //--Listar tipo  de plaza
       //--================================================================
       public DataTable CNListarPlaza(int idProducto, int idTipoValorado, bool lAprobar, int idAgencia, int idConcepto)
       {
           return objValorados.ADTipoPlaza(idProducto, idTipoValorado,lAprobar, idAgencia, idConcepto);
       }

       //--================================================================
       //--Validar Número de Folio
       //--================================================================
       public DataTable CNValidaNroFolio(int nNroFolio)
       {
           return objValorados.ADValidaNroFolio(nNroFolio);
       }

       //--================================================================
       //--Registrar Cambio de Ordenes de Pago
       //--================================================================
       public DataTable CNRegistraCambioOP(int idCuenta, int idSolOP, int idUsu, int idAgencia, DateTime dFecha, string XMLAnulados, string XMLNuevos)
       {
           return objValorados.ADRegistraCambioOP(idCuenta, idSolOP, idUsu, idAgencia, dFecha, XMLAnulados, XMLNuevos);
       }
       //--===============================================
       //--Datos Solicitud OP
       //--===============================================
       public DataTable CNRetornaDatosSolOP(int idSolicitud, int idCuenta)
       {
           return objValorados.ADRetornaDatosSolOP(idSolicitud, idCuenta);
       }
       //--================================================================
       //--Imprimir Acta entrega de ordenes de pago
       //--================================================================
       public DataTable CNImprimirActaEntregaOP(int IdCuenta, DateTime dFechaOP, string cidSolicitud, int idAgencia)
       {
           return objValorados.ADImprimirActaEntregaOP(IdCuenta, dFechaOP,cidSolicitud,idAgencia);
       }
       //--================================================================
       //--Registrar rechazo de valorados certificados
       //--================================================================
       public DataTable CNRechazoValoradoRecepCert(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, string cDescri)
       {
           return objValorados.ADRechazoValoradoRecepCert(idUsuario, idAgencia, dFechaReg, xmlEnvioCert, cDescri);
       }
       //--================================================================
       //--Registrar rechazo de valorados OP
       //--================================================================
       public DataTable CNRechazoValoradoRecepOP(int idUsuario, int idAgencia, DateTime dFechaReg, string xmlEnvioCert, string cDescri)
       {
           return objValorados.ADRechazoValoradoRecepOP(idUsuario, idAgencia, dFechaReg, xmlEnvioCert, cDescri);
       }
       public DataTable CNRetornaDatosSolOP(int idAgenciaOrigen, int idSolicitud, int idCuenta)
       {
           return objValorados.ADRetornaDatosSolOP(idAgenciaOrigen, idSolicitud, idCuenta);
       }
       public DataTable CNListEstSolOP()
       {
           return objValorados.ADListEstSolOP();
       }
       public DataTable CNRptSolOP(int idAgencia, int idEstado, DateTime dFechaCorte)
       {
           return objValorados.ADRptSolOP(idAgencia, idEstado, dFechaCorte);
       }

       public DataTable ListaValoradosPendActualizar(int x_idAgencia)
       {
           return objValorados.ListaValoradosPendActualizar(x_idAgencia);
       }

       public DataTable ActualizarDatosOperacion(int x_idKardex,int x_idCuenta,DateTime x_dFechaEmi,string x_nNroDoc,string x_cSerieDoc,DateTime x_dFechaReg,int x_idUsuario)
       {
           return objValorados.ActualizarDatosOperacion(x_idKardex, x_idCuenta, x_dFechaEmi, x_nNroDoc, x_cSerieDoc, x_dFechaReg, x_idUsuario);
       }
    }
}
