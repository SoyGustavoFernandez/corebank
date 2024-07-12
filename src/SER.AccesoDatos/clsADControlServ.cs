using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace SER.AccesoDatos
{
    public class clsADControlServ
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=============================================================
        //--    Registra Envió del Giro (Deprecated)
        //=============================================================
        public DataTable RegistrarGiro(DateTime dFecGiro, int nidUsuRegGiro, int idMoneda, int idAgeRem,
                                        Decimal nMontoGiro, Decimal nMonComGiro, string bClaveGiro, int idCliRem,
                                        string cApePatRem, string cApeMatRem, string cNombreRem, string cNroDniRem, string cDirCliRem,
                                        int idCliDes, string cApePatDes, string cApeMatDes, string cNombreDes,
                                         string cNroDniDes, string cDirClides, int idAgeDes, int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion,
                                        String cNumTelfRem, String cNumTelfDes, decimal nMontoItf, decimal nMontoRedondeo, int x_idTipoPago,
                                        bool lModificaSaldoLinea, int idTipoTransac, decimal nMonto_Giro)
        {
            return objEjeSp.EjecSP("SER_RegistroGiro_Sp", dFecGiro, nidUsuRegGiro, idMoneda, idAgeRem,
                                        nMontoGiro, nMonComGiro, bClaveGiro, idCliRem,
                                        cApePatRem, cApeMatRem, cNombreRem, cNroDniRem, cDirCliRem,
                                        idCliDes, cApePatDes, cApeMatDes, cNombreDes,
                                        cNroDniDes, cDirClides, idAgeDes, idProducto, idCanal, idTipoOperacion, idMotivoOperacion,
                                        cNumTelfRem, cNumTelfDes, nMontoItf, nMontoRedondeo, x_idTipoPago,
                                         lModificaSaldoLinea, idTipoTransac, nMonto_Giro);
        }

        //=============================================================
        //--    Registrar Giro con Cargo a Cuenta (Deprecated)
        //=============================================================
        public DataTable RegistrarGiroConCargoACuenta(DateTime dFecGiro, int nidUsuRegGiro, int idMoneda, int idAgeRem,
                                                    Decimal nMontoGiro, Decimal nMonComGiro, string bClaveGiro, int idCliRem,
                                                    string cApePatRem, string cApeMatRem, string cNombreRem, string cNroDniRem, string cDirCliRem,
                                                    int idCliDes, string cApePatDes, string cApeMatDes, string cNombreDes,
                                                    string cNroDniDes, string cDirClides, int idAgeDes, int numCuentaAho,
                                                    int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion,
                                                    String cNumTelfRem, String cNumTelfDes, decimal nMonRedondeo, decimal nMontoItf)
        {
            return objEjeSp.EjecSP("SER_RegistroGiroConCargoACuenta_Sp", dFecGiro, nidUsuRegGiro, idMoneda, idAgeRem,
                                                    nMontoGiro, nMonComGiro, bClaveGiro, idCliRem,
                                                    cApePatRem, cApeMatRem, cNombreRem, cNroDniRem, cDirCliRem,
                                                    idCliDes, cApePatDes, cApeMatDes, cNombreDes,
                                                    cNroDniDes, cDirClides, idAgeDes, numCuentaAho,
                                                    idProducto, idCanal, idTipoOperacion, idMotivoOperacion,
                                                    cNumTelfRem, cNumTelfDes, nMonRedondeo, nMontoItf);
        }

        //=============================================================
        //--Retorna la Comisión por Agencia
        //=============================================================
        public DataTable RetMonComGiro(int idAge, int idAgeDes, int idMoneda, Decimal nMontoAgirar)
        {
            return objEjeSp.EjecSP("SER_RetMonComGiro_Sp", idAge, idAgeDes, idMoneda, nMontoAgirar);
        }

        //=============================================================
        //--Retorna Lista de Eobs por Agencia
        //=============================================================
        public DataTable ListadoEobAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("SER_EobPorAgencia_SP", idAgencia);
        }

        //=============================================================
        //--Listado de Criterios Busqueda de Giros
        //=============================================================
        public DataTable LisCriBusGiro(int idOpc)
        {
            return objEjeSp.EjecSP("SER_ListaCriBusGiro_Sp", idOpc);
        }

        //=============================================================
        //--Listado de Giros
        //=============================================================
        public DataTable ListadoGiros(int idGiro, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            return objEjeSp.EjecSP("SER_BuscarGiros_Sp", idGiro, cDniRem, cDniBen, idAge, nOpc);
        }

        //=============================================================
        //--Registrar Pago del Giros
        //=============================================================
        public DataTable RegPagoGiros(int idGiro, DateTime dFecReg, int idUsu, int idMon, int idAge, Decimal nMonGiro,
                                        string cDniCliDes, string cNomCliDes, string cDirCliDes, int idProducto, int idCanal, int idTipoOperacion,
                                        int idMotivoOperacion, decimal nMonITF, decimal nMonRedondeo, decimal nMonEntregar,
                                        bool lModificaSaldoLinea, int idTipoTransac, bool lValidadoBiometrico, bool lValidadoClave)
        {
            return objEjeSp.EjecSP("SER_PagoServGiros_Sp", idGiro, dFecReg, idUsu, idMon, idAge, nMonGiro,
                                                            cDniCliDes, cNomCliDes, cDirCliDes, idProducto, idCanal, idTipoOperacion,
                                                            idMotivoOperacion, nMonITF, nMonRedondeo, nMonEntregar,
                                                            lModificaSaldoLinea, idTipoTransac, lValidadoBiometrico, lValidadoClave);
        }

        //=============================================================
        //--Registrar Devolucion de Giros
        //=============================================================
        public DataTable RegDevGiros(int idGiro, DateTime dFecReg, int idUsu, int idMon, int idAge, Decimal nMonGiro,
                                    string cDniCliRem, string cNomCliRem, string cDirCliRem, String cMotivo, int idProducto, int idCanal, int idTipoOperacion,
                                    int idMotivoOperacion, decimal nMonITF, decimal nMonRedondeo, decimal nMonEntregar,
                                    bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objEjeSp.EjecSP("SER_DevolucionGiros_Sp", idGiro, dFecReg, idUsu, idMon, idAge, nMonGiro,
                                                            cDniCliRem, cNomCliRem, cDirCliRem, cMotivo, idProducto, idCanal, idTipoOperacion,
                                                            idMotivoOperacion,
                                                            lModificaSaldoLinea, idTipoTransac,
                                                            nMonITF, nMonRedondeo, nMonEntregar);
        }

        //=============================================================
        //--Registrar Cambio de Destino de Giros
        //=============================================================
        public DataTable RegCamDesGiro(int idGiro, DateTime dFecReg, int idUsu, int idAge, int idAgeNue, Decimal nMonGiro, Decimal nComGiro, int idProducto, int idCanal, int idTipoOperacion, int idMotivoOperacion)
        {
            return objEjeSp.EjecSP("SER_RegCambioDestGiros_Sp", idGiro, dFecReg, idUsu, idAge, idAgeNue, nMonGiro, nComGiro, idProducto, idCanal, idTipoOperacion, idMotivoOperacion);
        }

        //=============================================================
        //--Retorna Datos del Giro Para el Extorno
        //=============================================================
        public DataTable RetDatGirExt(int idKar, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            return objEjeSp.EjecSP("SER_RetornaGiroExt_Sp", idKar, cDniRem, cDniBen, idAge, nOpc);
        }

        //=============================================================
        //--Registrar Extorno de Giros
        //=============================================================
        public DataTable RegExtornoGiros(int idKar, int idGiro, DateTime dFecReg, int idUsu, int idAge, Decimal nMonOpe, int idSol,
                                        bool lModificaSaldoLinea, int idMon, int idTipoTransac)
        {
            return objEjeSp.EjecSP("SER_RegExtornoGiros_Sp", idKar, idGiro, dFecReg, idUsu, idAge, nMonOpe, idSol,
                                                                lModificaSaldoLinea, idMon, idTipoTransac);
        }
        public DataTable RegExtornoGiroAcuenta(int idKar, int idGiro, DateTime dFecReg, int idUsu, int idAge, Decimal nMonOpe, int idSol)
        {
            return objEjeSp.EjecSP("SER_RegExtornoGiroACuenta_SP", idKar, idGiro, dFecReg, idUsu, idAge, nMonOpe, idSol);
        }

        //=============================================================
        //--Registrar Intentos Fallidos
        //=============================================================
        public DataTable RegIntFallGir(int idGiro, DateTime dFecReg, int idUsu)
        {
            return objEjeSp.EjecSP("SER_RegIntFall_Sp", idGiro, dFecReg, idUsu);
        }

        //=============================================================
        //--Listado de Giros por Estado
        //=============================================================
        public DataTable ListaEstGiros()
        {
            return objEjeSp.EjecSP("SER_ListaEstadoGiro_SP");
        }

        //=============================================================
        //-- Solicitar Cambio Clave para envío de Giro
        //=============================================================
        public DataTable SolicitarCambioClaveEnvioGiro(int idSolAproba, int idAgencia, int idCliente, int EstOper,
                                                    int idMoneda, int idProducto, decimal Monto, int nNumGiro,
                                                    DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                                                    DateTime FecAprob, int idUsuario, string bNuevaClaveGiro)
        {
            return objEjeSp.EjecSP("SER_InsSolCambioClaveEnvioGiro_Sp", idSolAproba, idAgencia, idCliente, EstOper,
                                             idMoneda, idProducto, Monto, nNumGiro,
                                              FecSolic, idMotivo, sustento, idEstSolic,
                                              FecAprob, idUsuario, bNuevaClaveGiro);
        }

        //=================================================================
        //-- Buscar las solicitudes de Cambio de clave para envío de Giro
        //=================================================================
        public DataTable BuscarSolicitudAprobacCmbioClave(int nNumGiro, decimal nMontoGiro)
        {
            return objEjeSp.EjecSP("SER_SituacSolicAprobacCambioClaveEnvioGiro_Sp", nNumGiro, nMontoGiro);
        }

        public DataTable BuscarNuevaClave(int nNumGiro, decimal nMontoGiro)
        {
            return objEjeSp.EjecSP("SER_BuscarNuevaClaveeEnvioGiro_Sp", nNumGiro, nMontoGiro);
        }

        public object ObtenerModalidadPagoEnvioGiro(Boolean lEsClienteInstitucion)
        {
            return objEjeSp.EjecSP("SER_ObtenerModalidadPagoEnvioGiro_Sp", lEsClienteInstitucion);
        }

        public DataTable BuscarDatosComisionGiro(int idAgenciaOrigen, int idAgenciaDestino, int idMoneda)
        {
            return objEjeSp.EjecSP("SER_BuscarDatosComisionGiro_SP", idAgenciaOrigen, idAgenciaDestino, idMoneda);
        }

        //=====================================================
        // Lista los tipos de comisiones para envío de Giro
        //=====================================================
        public DataTable listarTipoComisionGiro()
        {
            return objEjeSp.EjecSP("SER_TipoComisionEnvioGiro_Sp");
        }

        public DataTable RegistaConfiguracComisionGiro(string xmlComisionGiro, DateTime dFecSystem, int idUsuario)
        {
            return objEjeSp.EjecSP("SER_RegistaConfiguracComisionGiro_SP", xmlComisionGiro, dFecSystem, idUsuario);
        }

        //=============================================================
        //-- Listado de Giros, por estado bloqueo
        //=============================================================
        public DataTable ListadoGirosXbloqueo(int idGiro, Boolean lBloqueados)
        {
            return objEjeSp.EjecSP("SER_ListaPorEstadoBloqueo_SP", idGiro, lBloqueados);
        }
        //=====================================================
        // bloquea o desbloquea la atencion de un GIRO, cOpcion => BLOQ: bloquear giro, DESBLOQ: desbloquear el giro
        //=====================================================
        public DataTable BloquearGiro(int idGiro, int idUsuario)
        {
            return objEjeSp.EjecSP("SER_BloqueoDesbloqueoGiro_SP", "BLOQ", idGiro, idUsuario);
        }
        public DataTable DesbloquearGiro(int idGiro, int idUsuario)
        {
            return objEjeSp.EjecSP("SER_BloqueoDesbloqueoGiro_SP", "DESBLOQ", idGiro, idUsuario);
        }

        //=====================================================
        // Lista los Kardex de compra y venta de dolares
        //=====================================================
        public DataTable ADListaOperCompraVenta(int idKardex)
        {
            return objEjeSp.EjecSP("SER_ListaKardexCompraVenta_Sp", idKardex);
        }

        //=====================================================
        // Mantenimiento de tarifarios
        //=====================================================

        public DataTable ADRegistrarTarifario(int idMoneda, int idTipoPersona, int idTipoComision,
                                            int idGiroTarifarioTipo, int idMonto, decimal nMontoComision,
                                            int Vigente, int idUsuario
        )
        {
            return objEjeSp.EjecSP("SER_RegistrarTarifarioGiro_SP", idMoneda, idTipoPersona, idTipoComision,
                                                                    idGiroTarifarioTipo, idMonto, nMontoComision,
                                                                    Vigente, idUsuario);
        }

        public DataTable ADActualizarTarifario(int idGiroTarifario, int Vigente, int idUsuario)
        {
            return objEjeSp.EjecSP("SER_ActualizarTarifarioGiro_SP", idGiroTarifario, Vigente, idUsuario);
        }

        public DataTable ADListarTipoGiroTarifario()
        {
            return objEjeSp.EjecSP("SER_ListarTipoTarifarioGiros_SP");
        }
        public DataTable ADVerificarTarifario(int idGiroTarifario, int idTipoGiroTarifario, int idMonto, int idMoneda, int idTipoPersona)
        {
            return objEjeSp.EjecSP("SER_VerificarTarifarioGiro_SP", idGiroTarifario, idTipoGiroTarifario, idMoneda, idTipoPersona, idMonto);
        }

        public DataTable ADEliminarTarifario(int idGiroTarifario)
        {
            return objEjeSp.EjecSP("SER_EliminarTarifarioGiro_SP", idGiroTarifario);
        }
        public DataTable ADObtenerTarifario()
        {
            return objEjeSp.EjecSP("SER_ListarTarifarioGiros_SP");
        }

        public DataTable ADListarModalidadesPago()
        {
            return objEjeSp.EjecSP("SER_ListarModalidadesPago_SP");
        }
        public DataTable ADObtenerTarifarioFiltro(int idGiroTarifarioTipo)
        {
            return objEjeSp.EjecSP("SER_ObtenerTarifarioGiro_SP", idGiroTarifarioTipo);
        }
        //=============================================================
        //--    Registra Envió del Giro (New)
        //=============================================================
        public DataTable ADRegistrarEnvioGiro(clsEnvioGiro objEnvioGiro)
        {
            return objEjeSp.EjecSP("SER_RegistrarEnvioGiro_SP",
                    objEnvioGiro.dFechaGiro, objEnvioGiro.idUsuarioRegistra, objEnvioGiro.idMoneda,
                    objEnvioGiro.nMontoGiro, objEnvioGiro.nMontoComisionGiro, objEnvioGiro.cClaveGiro,
                    objEnvioGiro.idProducto, objEnvioGiro.idCanal, objEnvioGiro.idTipoOperacion, objEnvioGiro.idMotivoOperacion,
                    objEnvioGiro.nMontoITF, objEnvioGiro.nMontoRedondeo, objEnvioGiro.idTipoPago,
                    objEnvioGiro.lModificaSaldoLinea, objEnvioGiro.idTipoTransac, objEnvioGiro.nMontoTotal,
                    //datos remitente
                    objEnvioGiro.objRemitente.lCliente, objEnvioGiro.objRemitente.idAgencia, objEnvioGiro.objRemitente.idEstablecimiento, objEnvioGiro.objRemitente.idRegistro,
                    objEnvioGiro.objRemitente.idTipoDocumento, objEnvioGiro.objRemitente.cNumeroDocumento, objEnvioGiro.objRemitente.cNombreCompleto,
                    objEnvioGiro.objRemitente.cPaterno, objEnvioGiro.objRemitente.cMaterno, objEnvioGiro.objRemitente.cNombres,
                    objEnvioGiro.objRemitente.cNumeroDocumento, objEnvioGiro.objRemitente.cDireccion, objEnvioGiro.objRemitente.cCelular,
                    //datos destinatario
                    objEnvioGiro.objDestinatario.lCliente, objEnvioGiro.objDestinatario.idAgencia, objEnvioGiro.objDestinatario.idEstablecimiento, objEnvioGiro.objDestinatario.idRegistro,
                    objEnvioGiro.objDestinatario.idTipoDocumento, objEnvioGiro.objDestinatario.cNumeroDocumento, objEnvioGiro.objDestinatario.cNombreCompleto,
                    objEnvioGiro.objDestinatario.cPaterno, objEnvioGiro.objDestinatario.cMaterno, objEnvioGiro.objDestinatario.cNombres,
                    objEnvioGiro.objDestinatario.cNumeroDocumento, objEnvioGiro.objDestinatario.cDireccion, objEnvioGiro.objDestinatario.cCelular
                );
        }
        //=============================================================
        //--    Registra Envió del Giro (New)
        //=============================================================
        public DataTable ADRegistrarEnvioGiroConCargoCuenta(clsEnvioGiro objEnvioGiro)
        {
            return objEjeSp.EjecSP("SER_RegistrarEnvioGiroConCargoCuenta_SP",
                    objEnvioGiro.dFechaGiro, objEnvioGiro.idUsuarioRegistra, objEnvioGiro.idMoneda,
                    objEnvioGiro.nMontoGiro, objEnvioGiro.nMontoComisionGiro, objEnvioGiro.cClaveGiro,
                    objEnvioGiro.idProducto, objEnvioGiro.idCanal, objEnvioGiro.idTipoOperacion, objEnvioGiro.idMotivoOperacion,
                    objEnvioGiro.nMontoITF, objEnvioGiro.nMontoRedondeo, objEnvioGiro.nMontoTotal, objEnvioGiro.idCuentaDeposito,
                    //datos remitente
                    objEnvioGiro.objRemitente.lCliente, objEnvioGiro.objRemitente.idAgencia, objEnvioGiro.objRemitente.idEstablecimiento, objEnvioGiro.objRemitente.idRegistro,
                    objEnvioGiro.objRemitente.idTipoDocumento, objEnvioGiro.objRemitente.cNumeroDocumento, objEnvioGiro.objRemitente.cNombreCompleto,
                    objEnvioGiro.objRemitente.cPaterno, objEnvioGiro.objRemitente.cMaterno, objEnvioGiro.objRemitente.cNombres,
                    objEnvioGiro.objRemitente.cNumeroDocumento, objEnvioGiro.objRemitente.cDireccion, objEnvioGiro.objRemitente.cCelular,
                    //datos destinatario
                    objEnvioGiro.objDestinatario.lCliente, objEnvioGiro.objDestinatario.idAgencia, objEnvioGiro.objDestinatario.idEstablecimiento, objEnvioGiro.objDestinatario.idRegistro,
                    objEnvioGiro.objDestinatario.idTipoDocumento, objEnvioGiro.objDestinatario.cNumeroDocumento, objEnvioGiro.objDestinatario.cNombreCompleto,
                    objEnvioGiro.objDestinatario.cPaterno, objEnvioGiro.objDestinatario.cMaterno, objEnvioGiro.objDestinatario.cNombres,
                    objEnvioGiro.objDestinatario.cNumeroDocumento, objEnvioGiro.objDestinatario.cDireccion, objEnvioGiro.objDestinatario.cCelular
                );
        }

        public DataTable ADListarGirosPendientes(int idTipoDocumento, string cNumeroDocumento)
        {
            return objEjeSp.EjecSP("SER_ListarGirosPorDocumento_SP", idTipoDocumento, cNumeroDocumento);
        }
        public DataTable ADListarGirosPendientesXRemitente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objEjeSp.EjecSP("SER_ListarGirosPorDocRemitente_SP", idTipoDocumento, cNumeroDocumento);
        }

        public DataTable ADGuardarSolicitudDesbloqueoContra(int idServicioGiro, int idSolAproba, byte[] bArchivo, string cNombreArchivo, int idTipoArchivo, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("SER_GuardarSolicitudDesbloqueoContra_SP", idServicioGiro, idSolAproba, bArchivo, cNombreArchivo, idTipoArchivo, dFechaSistema, idUsuario);
        }

        public DataTable ADObtenerDetalleSolicitudDesbloGiro(int idServicioGiro)
        {
            return objEjeSp.EjecSP("SER_ObtenerDetalleSolicitudDesblGiro_SP", idServicioGiro);
        }
        public DataTable ADListarMovimientoGiros(int idAge, DateTime dFecIni, DateTime dFecFin, int idTipoOperacion)
        {
            return objEjeSp.EjecSP("SER_ListarMovimientosGiros_SP", idAge, dFecIni, dFecFin, idTipoOperacion);
        }
        public DataTable ADListarTipoOperacionGiro()
        {
            return objEjeSp.EjecSP("SER_ListarTipoOperacionGiros_SP");
        }

        public DataTable ADEjecutarSolDesbloqueoGiro(int idServGiro, int idSolAproba, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("SER_EjecutarSolDesbloqueoGiro_SP", idServGiro, idSolAproba, idUsuario, dFechaSistema);
        }

        public DataTable ADRegistrarCambioDestinoGiro(int idServGiro, int idNuevoDestino, int idAgenciaEjecuta, decimal nComision, int idUsuario, DateTime dFechaSistema,
                                                        int idCanal, int idMotivoOpe, int idMoneda, int idProducto, bool lModificaSaldoLinea, int idTipoTransaccion)
        {
            return objEjeSp.EjecSP("SER_RegistrarCambioDestGiros_SP", idServGiro, idNuevoDestino, idAgenciaEjecuta, nComision, idUsuario, Convert.ToDateTime(dFechaSistema),
                                                        idCanal, idMotivoOpe, idMoneda, idProducto, lModificaSaldoLinea, idTipoTransaccion);
        }

        public DataTable ADListarVinculados(int idCli)
        {
            return objEjeSp.EjecSP("SER_ListarVinculadosCliente_SP", idCli);
        }
    }
}
