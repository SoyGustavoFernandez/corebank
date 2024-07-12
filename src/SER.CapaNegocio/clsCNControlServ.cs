using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SER.AccesoDatos;
using EntityLayer;
using GEN.CapaNegocio;

namespace SER.CapaNegocio
{
    public class clsCNControlServ
    {
        clsADControlServ objCtrServ = new clsADControlServ();

        //=============================================================
        //--    Registrar Giro
        //=============================================================
        public DataTable RegistrarGiro(DateTime dFecGiro, int nidUsuRegGiro, int idMoneda, int idAgeRem,
                                        Decimal nMontoGiro, Decimal nMonComGiro, string bClaveGiro, int idCliRem,
                                        string cApePatRem, string cApeMatRem, string cNombreRem, string cNroDniRem, string cDirCliRem,
                                        int idCliDes, string cApePatDes, string cApeMatDes, string cNombreDes,
                                         string cNroDniDes, string cDirCliDes, int idAgeDes, int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion,
                                        String cNumTelfRem, String cNumTelfDes, decimal nMontoItf, decimal nMontoRedondeo, int x_idTipoPago,
                                        bool lModificaSaldoLinea, int idTipoTransace, decimal nMonto_Giro)
        {
            return objCtrServ.RegistrarGiro(dFecGiro, nidUsuRegGiro, idMoneda, idAgeRem,
                                        nMontoGiro, nMonComGiro, bClaveGiro, idCliRem,
                                        cApePatRem, cApeMatRem, cNombreRem, cNroDniRem, cDirCliRem,
                                        idCliDes, cApePatDes, cApeMatDes, cNombreDes,
                                        cNroDniDes, cDirCliDes, idAgeDes, idProducto, idCanal, idTipoOperacion, idMotivoOperacion,
                                        cNumTelfRem, cNumTelfDes, nMontoItf, nMontoRedondeo, x_idTipoPago,
                                          lModificaSaldoLinea, idTipoTransace, nMonto_Giro);
        }

        //=============================================================
        //--    Registrar Giro con Cargo a Cuenta
        //=============================================================
        public DataTable RegistrarGiroConCargoACuenta(DateTime dFecGiro , int nidUsuRegGiro , int idMoneda      , int idAgeRem      ,
                                                    Decimal nMontoGiro   , Decimal nMonComGiro, string bClaveGiro , int idCliRem      ,
                                                    string cApePatRem   , string cApeMatRem , string cNombreRem , string cNroDniRem , string cDirCliRem,
                                                    int idCliDes        , string cApePatDes , string cApeMatDes , string cNombreDes ,
                                                     string cNroDniDes  , string cDirCliDes , int idAgeDes      , int numCuentaAho  ,
                                                    int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion,
                                                    String cNumTelfRem, String cNumTelfDes, decimal nMonRedondeo,decimal nMontoItf)
        {
            return objCtrServ.RegistrarGiroConCargoACuenta(dFecGiro, nidUsuRegGiro, idMoneda, idAgeRem,
                                        nMontoGiro  , nMonComGiro   , bClaveGiro    , idCliRem      ,
                                        cApePatRem  , cApeMatRem    , cNombreRem    , cNroDniRem    , cDirCliRem,
                                        idCliDes    , cApePatDes    , cApeMatDes    , cNombreDes    ,
                                        cNroDniDes  , cDirCliDes    , idAgeDes      , numCuentaAho  ,
                                        idProducto, idCanal, idTipoOperacion, idMotivoOperacion,
                                        cNumTelfRem, cNumTelfDes, nMonRedondeo,nMontoItf);
        }

        //=============================================================
        //--Retorna la Comisión por Agencia
        //=============================================================
        public DataTable RetMonComGiro(int idAge, int idAgeDes, int idMoneda, Decimal nMontoAgirar, ref int nRpta)
        {
            nRpta = 1;
            DataTable tbMonCom = objCtrServ.RetMonComGiro(idAge, idAgeDes, idMoneda, nMontoAgirar);
            if (tbMonCom.Rows.Count<1)
            {
                nRpta = 0;
            }
            return tbMonCom;
        }

        //=============================================================
        //--Retorna Lista de Eobs por Agencia
        //=============================================================
        public DataTable ListaEobPorAgencia(int idAgencia)
        {
            return objCtrServ.ListadoEobAgencia(idAgencia);
        }

        //=============================================================
        //--Listado de Criterios de Busqueda de Giros
        //=============================================================
        public DataTable ListadoCriBusGiro(int idOpc)
        {
            return objCtrServ.LisCriBusGiro(idOpc);
        }

        //=============================================================
        //--Listado de  Giros
        //=============================================================
        public DataTable ListadodeGiros(int idGiro, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            return objCtrServ.ListadoGiros(idGiro, cDniRem, cDniBen, idAge, nOpc);
        }

        //=============================================================
        //--Registrar Pago de Giros
        //=============================================================
        public DataTable RegistrarPagoGiro(int idGiro, DateTime dFecReg, int idUsu, int idMon, int idAge, Decimal nMonGiro,
                                            string cDniCliDes, string cNomCliDes, string cDirCliDes, int idProducto, int idCanal, int idTipoOperacion,
                                            int idMotivoOperacion, decimal nMonITF, decimal nMonRedondeo, decimal nMonEntregar,
                                            bool lModificaSaldoLinea, int idTipoTransac, bool lValidadoBiometrico=false, bool lValidadoClave=false)
        {
            return objCtrServ.RegPagoGiros(idGiro, dFecReg, idUsu, idMon, idAge, nMonGiro,
                                            cDniCliDes, cNomCliDes, cDirCliDes, idProducto, idCanal, idTipoOperacion,
                                            idMotivoOperacion, nMonITF, nMonRedondeo, nMonEntregar,
                                                        lModificaSaldoLinea, idTipoTransac, lValidadoBiometrico, lValidadoClave);
        }

        //=============================================================
        //--Registrar Devolución de Giros
        //=============================================================
        public DataTable RegDevolucionGiro(int idGiro, DateTime dFecReg, int idUsu, int idMon, int idAge, Decimal nMonGiro,
                                            string cDniCliRem, string cNomCliRem, string cDirCliRem, String cMotivo, int idProducto, int idCanal, int idTipoOperacion,
                                            int idMotivoOperacion, decimal nMonITF, decimal nMonRedondeo, decimal nMonEntregar,
                                            bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objCtrServ.RegDevGiros(idGiro, dFecReg, idUsu, idMon, idAge, nMonGiro,
                                            cDniCliRem, cNomCliRem, cDirCliRem, cMotivo, idProducto, idCanal, idTipoOperacion,
                                            idMotivoOperacion, nMonITF, nMonRedondeo, nMonEntregar,
                                            lModificaSaldoLinea, idTipoTransac);
        }

        //=============================================================
        //--Registrar Cambio de Destino de Giros
        //=============================================================
        public DataTable RegCambioDesGiro(int idGiro, DateTime dFecReg, int idUsu, int idAge, int idAgeNue, Decimal nMonGiro, Decimal nComGiro, int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion)
        {
            return objCtrServ.RegCamDesGiro(idGiro, dFecReg, idUsu, idAge, idAgeNue, nMonGiro, nComGiro, idProducto, idCanal, idTipoOperacion, idMotivoOperacion);
        }

        //=============================================================
        //--Listado de  Giros
        //=============================================================
        public DataTable RetDatosGiroExt(int idKar, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            return objCtrServ.RetDatGirExt(idKar, cDniRem, cDniBen, idAge, nOpc);
        }

        //=============================================================
        //--Registrar Pago de Giros
        //=============================================================
        public DataTable RegExtornoGiros(int idKar, int idGiro, DateTime dFecReg, int idUsu, int idAge, Decimal nMonOpe, int idSol,
                                         bool lModificaSaldoLinea, int idMon, int idTipoTransac)
        {
            return objCtrServ.RegExtornoGiros(idKar, idGiro, dFecReg, idUsu, idAge, nMonOpe, idSol,
                                                     lModificaSaldoLinea, idMon, idTipoTransac);
        }
        public DataTable RegExtornoGiroAcuenta(int idKar, int idGiro, DateTime dFecReg, int idUsu, int idAge, Decimal nMonOpe, int idSol)
        {
            return objCtrServ.RegExtornoGiroAcuenta(idKar, idGiro, dFecReg, idUsu, idAge, nMonOpe, idSol);
        }

        //=============================================================
        //--Registrar Intentos Fallidos
        //=============================================================
        public DataTable RegIntenFallClave(int idGiro, DateTime dFecReg, int idUsu)
        {
            return objCtrServ.RegIntFallGir(idGiro, dFecReg, idUsu);
        }

        //=============================================================
        //--Reporte de Giros por Estado
        //=============================================================
        public DataTable ListadoGirosEstado()
        {
            return objCtrServ.ListaEstGiros();
        }

        //=============================================================
        //-- Solicitar Cambio Clave para envío de Giro
        //=============================================================
        public DataTable SolicitarCambioClaveEnvioGiro(int idSolAproba,int idAgencia    , int idCliente        , int EstOper,
                                                        int idMoneda        , int idProducto, decimal Monto     , int nNumGiro,
                                                        DateTime FecSolic   , int idMotivo  , string sustento   , int idEstSolic,
                                                        DateTime FecAprob, int idUsuario, string bNuevaClaveGiro)
        {
            return objCtrServ.SolicitarCambioClaveEnvioGiro(idSolAproba, idAgencia, idCliente, EstOper,
                                                            idMoneda, idProducto, Monto, nNumGiro,
                                                            FecSolic, idMotivo, sustento, idEstSolic,
                                                            FecAprob, idUsuario, bNuevaClaveGiro);
        }

        //=================================================================
        //-- Buscar las solicitudes de Cambio de clave para envío de Giro
        //=================================================================
        public DataTable BuscarSolicitudAprobacCmbioClave(int nNumGiro, decimal nMontoGiro)
        {
            return objCtrServ.BuscarSolicitudAprobacCmbioClave(nNumGiro, nMontoGiro);
        }

        //=================================================================
        //-- Buscar Si se tiene una nueva clave de envío de giro
        //=================================================================
        public DataTable BuscarNuevaClave(int nNumGiro, decimal nMontoGiro)
        {
            return objCtrServ.BuscarNuevaClave(nNumGiro, nMontoGiro);
        }

        //=================================================================
        //-- Obtiene las modalidades de pago por el envío de Giro
        //=================================================================
        public object ObtenerModalidadPagoEnvioGiro(Boolean lEsClienteInstitucion)
        {
            return objCtrServ.ObtenerModalidadPagoEnvioGiro(lEsClienteInstitucion);
        }

        //========================================================================
        //-- Obtiene los datos de la configuración de Comisión por envío de Giro
        //========================================================================
        public DataTable BuscarDatosComisionGiro(int idAgenciaOrigen, int idAgenciaDestino, int idMoneda)
        {
            return objCtrServ.BuscarDatosComisionGiro(idAgenciaOrigen, idAgenciaDestino, idMoneda);
        }

        public DataTable listarTipoComisionGiro()
        {
            return objCtrServ.listarTipoComisionGiro();
        }

        public DataTable RegistaConfiguracComisionGiro(string xmlComisionGiro, DateTime dFecSystem, int idUsuario)
        {
            return objCtrServ.RegistaConfiguracComisionGiro(xmlComisionGiro, dFecSystem, idUsuario);
        }

        //=============================================================
        //-- Listado de Giros, por estado bloqueo
        //=============================================================
        public DataTable ListadoGirosXbloqueo(int idGiro, Boolean lBloqueados)
        {
            return objCtrServ.ListadoGirosXbloqueo(idGiro, lBloqueados);
        }
        //=====================================================
        // bloquea o desbloquea la atencion de un GIRO, cOpcion => BLOQ: bloquear giro, DESBLOQ: desbloquear el giro
        //=====================================================
        public DataTable BloquearGiro(int idGiro, int idUsuario)
        {
            return objCtrServ.BloquearGiro(idGiro, idUsuario);
        }
        public DataTable DesbloquearGiro(int idGiro, int idUsuario)
        {
            return objCtrServ.DesbloquearGiro(idGiro, idUsuario);
        }

        //=====================================================
        // Lista los Kardex de compra y venta de dolares
        //=====================================================
        public DataTable CNListaOperCompraVenta(int idKardex)
        {
            return objCtrServ.ADListaOperCompraVenta(idKardex);
        }
        //=====================================================
        // Mantenimiento de tarifarios
        //=====================================================

        public DataTable CNRegistrarTarifario(int idMoneda, int idTipoPersona, int idTipoComision,
                                            int idGiroTarifarioTipo, int idMonto, decimal nMontoComision,
                                            int Vigente, int idUsuario
        )
        {
            return objCtrServ.ADRegistrarTarifario(idMoneda, idTipoPersona, idTipoComision, idGiroTarifarioTipo,
                                                 idMonto, nMontoComision, Vigente, idUsuario);
        }


        public DataTable CNActualizarTarifario(int idGiroTarifario, int Vigente, int idUsuario)
        {
            return objCtrServ.ADActualizarTarifario(idGiroTarifario, Vigente, idUsuario);
        }

        public DataTable CNListarTipoGiroTarifario()
        {
            return objCtrServ.ADListarTipoGiroTarifario();
        }

        public DataTable CNVerificarTarifario(int idGiroTarifario, int idTipoGiroTarifario, int idMonto, int idMoneda, int idTipoPersona)
        {
            return objCtrServ.ADVerificarTarifario(idGiroTarifario, idTipoGiroTarifario, idMonto, idMoneda, idTipoPersona);
        }

        public DataTable CNObtenerTarifario()
        {
            return objCtrServ.ADObtenerTarifario();
        }

        public DataTable CNListarModalidadesPago()
        {
            return objCtrServ.ADListarModalidadesPago();
        }
        public DataTable CNObtenerTarifarioFiltro(int idGiroTarifarioTipo)
        {
            return objCtrServ.ADObtenerTarifarioFiltro(idGiroTarifarioTipo);
        }
        public DataTable CNRegistrarEnvioGiro(clsEnvioGiro objEnvioGiro)
        {
            objEnvioGiro.cClaveGiro = new clsCNSeguridad().GeneratePasswordHash(objEnvioGiro.cClaveGiro);
            if(objEnvioGiro.idTipoPago == 1)
                return objCtrServ.ADRegistrarEnvioGiro(objEnvioGiro);
            else
                return objCtrServ.ADRegistrarEnvioGiroConCargoCuenta(objEnvioGiro);
        }
        public DataTable CNListarGirosPendientes(int idTipoDocumento, string cNumeroDocumento)
        {
            return objCtrServ.ADListarGirosPendientes(idTipoDocumento, cNumeroDocumento);
        }
        public DataTable CNListarGirosPendientesXRemitente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objCtrServ.ADListarGirosPendientesXRemitente(idTipoDocumento, cNumeroDocumento);
        }

        public DataTable CNGuardarSolicitudDesbloqueoContra(int idServicioGiro, int idSolAproba, byte[] bArchivo, string cNombreArchivo, int idTipoArchivo, DateTime dFechaSistema, int idUsuario)
        {
            return objCtrServ.ADGuardarSolicitudDesbloqueoContra(idServicioGiro, idSolAproba, bArchivo, cNombreArchivo, idTipoArchivo, dFechaSistema, idUsuario);
        }

        public DataTable CNObtenerDetalleSolicitudDesbloGiro(int idServicioGiro)
        {
            return objCtrServ.ADObtenerDetalleSolicitudDesbloGiro(idServicioGiro);
        }
        public DataTable CNListaMovimientosGiros(int idAge, DateTime dFecIni, DateTime dFecFin, int idTipoOperacion)
        {
            return objCtrServ.ADListarMovimientoGiros(idAge, dFecIni, dFecFin, idTipoOperacion);
        }
        public DataTable CNListarTipoOperacionGiro()
        {
            return objCtrServ.ADListarTipoOperacionGiro();
        }

        public DataTable CNEjecutarSolDesbloqueoGiro(int idServGiro, int idSolAproba, int idUsuario, DateTime dFechaSistema )
        {
            return objCtrServ.ADEjecutarSolDesbloqueoGiro(idServGiro, idSolAproba, idUsuario, dFechaSistema);
        }

        public DataTable CNRegistrarCambioDestinoGiro(int idServGiro, int idNuevoDestino, int idAgenciaEjecuta, decimal nComision, int idUsuario, DateTime dFechaSistema,
                                                        int idCanal, int idMotivoOpe, int idMoneda, int idProducto, bool lModificaSaldoLinea, int idTipoTransaccion)
        {
            return objCtrServ.ADRegistrarCambioDestinoGiro(idServGiro, idNuevoDestino, idAgenciaEjecuta, nComision, idUsuario, dFechaSistema,
                                                        idCanal, idMotivoOpe, idMoneda, idProducto, lModificaSaldoLinea, idTipoTransaccion);
        }

        public DataTable CNListarVinculados(int idCli)
        {
            return objCtrServ.ADListarVinculados(idCli);
        }
    }
}
