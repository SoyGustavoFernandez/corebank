using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Xml.Linq;
using SolIntEls.GEN.Helper.Interface;
namespace DEP.AccesoDatos
{
    public class clsADDeposito
    {
        IntConexion objEjeSp;

        public clsADDeposito(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADDeposito()
        {
            objEjeSp = new clsGENEjeSP();
        }        

        public DataTable ADConsultaDeposito(int idcli, string idestado)
        {
            return objEjeSp.EjecSP("Cre_RetornaCuentaDeposito_sp", idcli, idestado);
        }

        public DataTable ADCartillaDPFAbonoM()
        {
            return objEjeSp.EjecSP("DEP_RetornaCartillaDPFAM_sp");
        }
        
        public DataTable ADConsultaDatosxidCuenta(int idCuenta, string idestado)
        {
            return objEjeSp.EjecSP("DEP_RetornaCuentaDepositoxCta_sp", idCuenta, idestado);
        }

        public DataTable ADAWValidarCuentaAperturada(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_AWValidarCuentaAperturada_SP", idCuenta);
        }

        public DataTable ADConsultaDatosAbono(int idCuenta, string cTipoOpe)
        {
            return objEjeSp.EjecSP("DEP_DatosAbonoxCta_sp", idCuenta, cTipoOpe);
        }
        public DataTable ADUsuarioUsaCuenta(int idcuenta)
        {
            return objEjeSp.EjecSP("Dep_UsoCuenta_sp", idcuenta);
        }
        public DataTable ADCuentasDeposito(int idcli, string idestado)
        {
            return objEjeSp.EjecSP("Cre_RetornaCuentasDeposito_sp", idcli, idestado);
        }
        public DataTable ADUpdUsoCuenta(int idCuenta, int idUsuario)
        {
            return objEjeSp.EjecSP("DEP_UpdUsoCuenta_sp", idCuenta, idUsuario);
        }
        public DataTable ADUpdNoUsoCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_UpdNoUsoCuenta_sp", idCuenta);
        }
        public DataTable ADUpdNoUsoCuentaMasivo(int idUsuario)
        {
            return objEjeSp.EjecSP("DEP_UpdNoUsoCuentaMasivo_sp", idUsuario);
        }
        public DataTable ADAbonoCuenta(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nMonFavCli)
        {
            return objEjeSp.EjecSP("DEP_AbonoEfectivo_sp", idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, nMonFavCli);
        }
        public DataTable ADLisCuentaAbonoMasivo(int idUsuario, int idMoneda)
        {
            return objEjeSp.EjecSP("DEP_LisDepxAnaAbonoMasivo_SP", idUsuario, idMoneda);
        }
        public DataTable ADOperacion(int idKardex)
        {
            return objEjeSp.EjecSP("DEP_BusKardex_SP", idKardex);
        }
        public DataTable ADExtornoAbono(int idKardex, int idMotExt, int idcuenta, string tSustento, decimal nMonto)
        {
            return objEjeSp.EjecSP("DEP_ExtornaOperacion_SP", idKardex, idMotExt, idcuenta, tSustento, nMonto);
        }
        public DataTable ADUpdCancelacion(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_CancelaDeposito_sp", idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia);
        }
        //Retorna la Comision Fuera de Plaza
        public DataTable ADRetComisionPlaza(int idCuenta, int idAgencia, decimal nMonto)
        {
            return objEjeSp.EjecSP("DEP_RetornaComFuePlaza_sp", idCuenta, idAgencia, nMonto);
        }
        //Guarda el Retiro de Cuentas
        public DataTable ADGuardaRetiroCuenta(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nMonFavCli)
        {
            return objEjeSp.EjecSP("DEP_RetiroEfectivo_sp", idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, nMonFavCli);
        }
        //Retorna Intervinientes de la Cuenta
        public DataTable ADRetornaIntervinientes(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ListIntervCuentaDep", idCuenta);
        }
        //Retorna el Plan de Depositos
        public DataTable ADRetornaPlanDep(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_RetornaPlanDeposito", idCuenta);
        }
        //Deposito Ahorro Programado
        public DataTable ADAbonoDepProg(int idCuenta, decimal nMonto, string XmlPlanDeP, DateTime dFechaOpera, int idUsuario, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nValFavCli)
        {
            return objEjeSp.EjecSP("DEP_AbonoDepProg_sp", idCuenta, nMonto, XmlPlanDeP, dFechaOpera, idUsuario, idAgencia, nComision, nITF, idTipoPago, nValFavCli);
        }

        public DataTable ADListarPlazoDep(int CodSubPro)
        {
            return objEjeSp.EjecSP("DEP_LisPlaDep_SP", CodSubPro);
        }

        public DataTable ADConsultaDatosAbono(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatosGenCta_sp", idCuenta);
        }

        public DataTable ADRetornaPlazo(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatosPlazoCuenta_sp", idCuenta);
        }
        public DataTable ADLisCuentaAbonoMasivo(int idUsuario, int idMoneda, int idProducto)
        {
            return objEjeSp.EjecSP("DEP_LisDepxAnaAbonoMasivo_SP", idUsuario, idMoneda, idProducto);
        }
        public DataTable ADEntregaProducto(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_EntregaProducto_sp", idCuenta, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
        }

        public DataTable ADValCanCtaDepPro(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ValPlanDepPro_SP", idCuenta);
        }
        public DataTable ADDatCueBloq(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_RetDatCueBlo_sp", idCuenta);
        }
        public DataTable ADBloqueoCuenta( int idCuenta ,int idBloqueo, DateTime dFechaBloq, int idUsuBloq, string cMotivo)
        {
            return objEjeSp.EjecSP("DEP_BloqueoCuenta_sp", idCuenta, idBloqueo, dFechaBloq, idUsuBloq, cMotivo);
        }
        public DataTable ADListaDepositoxPer(int idusuario)
        {
            return objEjeSp.EjecSP("DEP_ListaDepositoxPer_sp", idusuario);
        }
        public DataTable ADGuadarReasig(string xmlCuentasAsig, int idAgenciaDes, int idUsuarioDes, string cMotivo, int idAgenciaOri, int idUsuarioOri, int idUsuRegigtra, int idAgeRegistra,DateTime dFechaRegistro)
        {
            return objEjeSp.EjecSP("DEP_ReasigaDepositos_SP", xmlCuentasAsig, idAgenciaDes, idUsuarioDes, cMotivo, idAgenciaOri, idUsuarioOri, idUsuRegigtra, idAgeRegistra, dFechaRegistro);
        }
        public DataTable ADListaPeriodoCTS(DateTime dtFechaOpe)
        {
            return objEjeSp.EjecSP("DEP_ListaPeriodoCTS_sp", dtFechaOpe);
        }
        public DataTable ADListaCtasCtsEmpleador(int idEmpleador, int idMoneda, int idUsuario, bool lBloquea)
        {
            return objEjeSp.EjecSP("DEP_ListaCtasCtsEmpleador_sp", idEmpleador, idMoneda, idUsuario, lBloquea);
        }
        public DataTable ADAbonoCuentaCTS(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, int idPeriodoCTS, decimal nMonFavCli)
        {
            return objEjeSp.EjecSP("DEP_AbonoEfectivoCTS_sp", idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, idPeriodoCTS, nMonFavCli);
        }
        public void ADDeclaracionRemuneracionCTS(int idCuenta, int idPeriodoCTS, decimal nMonto,int idMoneda)
        {
            objEjeSp.EjecSPAlm("DEP_DeclaracionRemuneracionCTS_sp", idCuenta, idPeriodoCTS, nMonto, idMoneda);
        }

        //=================================================================
        //--Listado de Cuentas de Ahorros
        //=================================================================
        public DataTable ADCuentasAho(int idcli, int idEstCta, int idMon, int idOpc)
        {
            return objEjeSp.EjecSP("DEP_RetornaCtasAhorroCli_sp", idcli, idEstCta, idMon, idOpc);
        }

        //=================================================================
        //--Listado de Cuentas de Ahorros Vinculadas
        //=================================================================
        public DataTable ADCuentasAhoVin(int idcli, int idEstCta, int idMon, int x_nTipPersona, string xmlInterv)
        {
            return objEjeSp.EjecSP("DEP_RetornaCtasAhorroVinCli_sp", idcli, idEstCta, idMon, x_nTipPersona, xmlInterv);
        }

        //=================================================================
        //--Retorna Listado de Cuentas de Ahorros por Cliente
        //=================================================================
        public DataTable ADRetornaCuentasAho(int idcli, int idEstCta, int idMon, int idOpc)
        {
            return objEjeSp.EjecSP("DEP_RetornaCtasAhorroCli_sp", idcli, idEstCta, idMon, idOpc);
        }

        //=================================================================
        //--Retorna Datos de la Cuenta
        //=================================================================
        public DataTable ADDatosdeCuenta(int idCta, string idEstCta,int nOpc)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosCta_sp", idCta, idEstCta, nOpc);
        }

        //=================================================================
        //--Retorna Datos de la Cuenta Registro de Firmas
        //=================================================================
        public DataTable ADRetornaDatosCuentaRegFirmas(int idCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosCtaRegFirmas_SP", idCta);
        }

        //=================================================================
        //--Retorna Datos de Intervinientes de la Cuenta Registro de firmas
        //=================================================================
        public DataTable ADRetornaDatosIntervRegFirmas(int idCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosIntervRegFirmas_SP", idCta);
        }

        //=================================================================
        //--Retorna Datos de Intervinientes de la Cuenta Registro de firmas PJ
        //=================================================================
        public DataTable ADRetornaDatosIntervRegFirmasPJ(int idCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosIntervRegFirmasPJ_SP", idCta);
        }
        
        
        //=================================================================
        //--Retorna Datos del tipo de pago
        //=================================================================
        public DataTable ADDatosTipoPago(int idCta, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_RetTipoPagoBycuenta_sp", idCta, idAgencia);
        }
        //=================================================================
        //--Retorna Datos del Bloqueo de la Cuenta
        //=================================================================
        public DataTable ADDatosBloqCuenta(int idCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaBloqueosCta_sp", idCta);
        }

        //=================================================================
        //--Registra Bloqueo de la Cuenta
        //=================================================================
        public DataTable ADRegBloqCuenta(string xmlBloq, int idCta, Decimal nMonto, int idUsu, DateTime dFecha, string cMotDesbloq, bool lTipOpe,int idTipSolDesbloq,string cNomSolDesbloq)
        {
            return objEjeSp.EjecSP("DEP_RegistraBloqueosCta_sp", xmlBloq, idCta, nMonto, idUsu, dFecha, cMotDesbloq, lTipOpe, idTipSolDesbloq, cNomSolDesbloq);
        }

        public DataTable grabarBloqueoCuentaMasivo(string xmlBloqueoCuenta, int idUsuario, DateTime dFechaSistema, string cMotivoDesbloqueo,
            bool lBloqueo, int idTipoSolicteDesbloqueo, string cNombreSolicteDesbloqueo)
        {
            return objEjeSp.EjecSP("DEP_GrabarBloqueoCuentaMasivo_SP", xmlBloqueoCuenta, idUsuario, dFechaSistema, cMotivoDesbloqueo,
                lBloqueo, idTipoSolicteDesbloqueo, cNombreSolicteDesbloqueo);
        }
        public DataTable grabarBloqueoCuentaGrupoSol(
            int idGrupoSolidario, int idSolicitudCredGrupoSol, int idOperacion,
            string xmlBloqueoCuenta, int idUsuario, DateTime dFechaSistema, string cMotivoDesbloqueo,
            bool lBloqueo, int idTipoSolicteDesbloqueo, string cNombreSolicteDesbloqueo)
        {
            return objEjeSp.EjecSP("DEP_GrabarBloqueoCuentaGrupoSol_SP",
                idGrupoSolidario, idSolicitudCredGrupoSol, idOperacion,
                xmlBloqueoCuenta, idUsuario, dFechaSistema, cMotivoDesbloqueo,
                lBloqueo, idTipoSolicteDesbloqueo, cNombreSolicteDesbloqueo);
        }

        //=================================================================
        //--Retorna Intervinientes de la Cuenta
        //=================================================================
        public DataTable ADDatosIntervCuenta(int idCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaIntervinientesCta_sp", idCta);
        }

        //=================================================================
        //--Retorna Ahorro Programado
        //=================================================================
        public DataTable ADRetAhoProgramado(int idCta, int idestado)
        {
            return objEjeSp.EjecSP("DEP_RetornaAhoProgramado_sp", idCta, idestado);
        }

        //=================================================================
        //--Registra Operación de Deposito
        //=================================================================
        public DataTable ADRegistraDeposito(string xmlTipPag, string xmlComision, int idCta, Decimal nMondep, int idMon, Decimal nMonComis,
                                            Decimal nMonITF, Decimal nMonRedondeo, Decimal nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int nCuota, int idProd,
                                            bool lIsAhoPrg, string cNroDoc, int idInsFin, int cCtaTransf, int nTipPag,
                                            int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal, int x_idMotivoOpe,
                                            int idTipoTransac, bool lModificaSaldoLinea, int idKardexRelacionado = 0)
        {
            return objEjeSp.EjecSP("DEP_RegistraDepositoCta_SP", xmlTipPag, xmlComision, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, nCuota, idProd,
                                             lIsAhoPrg, cNroDoc, idInsFin, cCtaTransf, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe, idKardexRelacionado,
                                             idTipoTransac, lModificaSaldoLinea);
        }

        //=================================================================
        //--Lista Tipos de Carga Masiva
        //=================================================================
        public DataTable ADLisTipoCargaMasiva(int nModoSeleccion)
        {
            return objEjeSp.EjecSP("DEP_LisTipoCargaMasiva_sp", nModoSeleccion);
        }

        //=================================================================
        //--Valida Carga Masiva de Ahorros
        //=================================================================
        public DataTable ADValidaCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                int idAgencia, int idProducto, int idMoneda, string xmlLisCtas,DateTime dFecSistema)
        {
            return objEjeSp.EjecSP("DEP_ValidaCargaMasivaAho_SP", idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                  idAgencia, idProducto, idMoneda,dFecSistema, xmlLisCtas);
        }

        //=================================================================
        //--Retorna Datos de ctas para Carga Masiva
        //=================================================================
        public DataTable ADRetornaDatosCtaMasivo(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                int idAgencia, int idProducto, int idMoneda, string xmlLisCtas)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosCtaMasivo_sp", idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                   idAgencia, idProducto, idMoneda, xmlLisCtas);
        }
        public DataTable CNRetornaCtaMasivoPropio(int idTipoPlanillaPeriodo, int idPlanillaPeriodo, int idTipoOperac, 
                                                int idCanal, int idAgencia, int idProducto, int idMoneda, string xmlLisCtasAho)
        {
            return objEjeSp.EjecSP("DEP_DatosCtaMasivoPropio_sp",idTipoPlanillaPeriodo,  idPlanillaPeriodo, idTipoOperac,
                                                                idCanal, idAgencia, idProducto, idMoneda, xmlLisCtasAho);
        }

        //=================================================================
        //--Registra Datos de Carga Masiva
        //=================================================================
        public DataTable ADRegistraCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                 int idAgencia, int idProducto, int idMoneda, string xmlLisCtas, int idUsuOpe, int idUsuOrdenante, string cCaracteristica, DateTime dFecOpe, int idTipCarga)
        {
            return objEjeSp.EjecSP("DEP_RegistraCargaMasivaAho_SP", idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                    idAgencia, idProducto, idMoneda, xmlLisCtas, idUsuOpe, idUsuOrdenante, cCaracteristica, dFecOpe, idTipCarga);
        }

        //=================================================================
        //--Registra Operación de Deposito Masivo
        //=================================================================
        public DataTable ADRegistraDepositoCtaMasivo(int idCarga, int idCuenta, int nPlazo, int idMoneda, decimal nMonOperac,
                                                   decimal nMonComis, decimal nMonITF, int idCanal, int idAgencia, int idUsu,
                                                   DateTime dFechaOpe, int idProducto, bool lIsAhoProg, int nCuota,
                                                   int nTipPago, string xmlTipPago, string cNroDoc, int cCodInstFin,
                                                   int cCtaTransf, int idCliente, int idTipPersona, string cDniCliOpe,
                                                   string cNomCliOpe, string cDirCliOpe, int idPeriodoCTS, decimal nSumUltRemun, int x_idTipoCarga, int x_idPlanilla)
        {
            return objEjeSp.EjecSP("DEP_RegistraDepositoCtaMasivo_SP", idCarga, idCuenta, nPlazo, idMoneda, nMonOperac,
                                                                       nMonComis, nMonITF, idCanal, idAgencia, idUsu,
                                                                       dFechaOpe, idProducto, lIsAhoProg, nCuota, nTipPago,
                                                                       xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf,
                                                                       idCliente, idTipPersona, cDniCliOpe, cNomCliOpe,
                                                                       cDirCliOpe, idPeriodoCTS, nSumUltRemun, x_idTipoCarga, x_idPlanilla);
        }
        public DataTable ActualizarPlanillaPagada(int idKardex, int idTipoPlanPeriodo, int idPlanPeriodo, DateTime dFechaPago, int idCliOperac)
        {
            return objEjeSp.EjecSP("DEP_ActualizarPlanillaPagada_SP", idKardex, idTipoPlanPeriodo, idPlanPeriodo,  dFechaPago,   idCliOperac);
        }

        //=================================================================
        //--Retorna Datos de Cuenta por Nro Cuenta
        //=================================================================
        public DataTable ADRetornaDatosxCuenta(int idcuenta, int idEstCta, int idMon, int idOpc)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosxCuenta_sp", idcuenta, idEstCta, idMon, idOpc);
        }
        //=================================================================
        //--Registra Operación de Cancelación
        //=================================================================
        public DataTable ADRegistraCancelacionCta(int idCanal, int idCuenta, int idProd, int idMoneda, bool lCumplePlazo,
                                                  Decimal nTasCancelacion, Decimal nMonOperacion, Decimal nMonCapital,
                                                  Decimal nMonInteres, Decimal nMonIntPagAde, Decimal nMonComis, Decimal nMonITF,
                                                  Decimal nMonRedondeo, string xmlComision, int idCliItf, string cDniCliOpe,
                                                  string cNomCliOpe, string cDirCliOpe, int idAge, int idUsu, DateTime dFechaOpe, string xmlInterv,
                                                  string xmlTipPago, int x_idTipPago, int idMotivoOpe,
                                                   bool lModificaSaldoLinea, int idTipoTransac)
        {
            return objEjeSp.EjecSP("DEP_RegistraCancelacionCta_SP", idCanal, idCuenta, idProd, idMoneda, lCumplePlazo, nTasCancelacion,
                                                                    nMonOperacion, nMonCapital, nMonInteres, nMonIntPagAde, nMonComis,
                                                                    nMonITF, nMonRedondeo, xmlComision, idCliItf, cDniCliOpe,
                                                                    cNomCliOpe, cDirCliOpe, idAge, idUsu, dFechaOpe, xmlInterv,
                                                                    xmlTipPago, x_idTipPago, idMotivoOpe,
                                                                      lModificaSaldoLinea, idTipoTransac);
        }

        //=================================================================
        //--Registra Operación de Retiro
        //=================================================================
        public DataTable ADRegistraRetiro(string xmlTipPag, string xmlComision, string xmlInterv, int idCta, Decimal nMondep, int idMon, Decimal nMonComis,
                                         Decimal nMonITF, Decimal nMonRedondeo, Decimal nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int idProd,
                                         string cNroDoc, int nTipPag,
                                         int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal, int x_idMotivoOpe,
                                         int idTipoTransac, bool lModificaSaldoLinea)

        {
            return objEjeSp.EjecSP("DEP_RegistraRetiroCta_SP", xmlTipPag, xmlComision, xmlInterv, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, idProd,
                                             cNroDoc, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe,
                                             idTipoTransac, lModificaSaldoLinea);
        }

        //=================================================================
        //--Cargar Combo con las planillas generadas pero No pagadas
        //=================================================================
        public DataTable CargarPlanillaNoPagadas()
        {
            return objEjeSp.EjecSP("DEP_ListarPlanillasNoPag_sp");
        }
        //=================================================================
        //--Validacion de actualización de informacion de clientes menores edad
        //=================================================================
        public DataTable ADValidarActDatCli(int idCli)
        {
            return objEjeSp.EjecSP("DEP_ValidacionCliMenEdad_sp", idCli);
        }
        //=================================================================
        //--Lista solicitudes de apertura pendientes de confirmación
        //=================================================================
        public DataTable ADListaSolPenAho(int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_ListaSolicitudesAhoPend_sp", idAgencia);
        }


        //=============================================================
        //--listar cuentas Por Entidades con saldo
        //=============================================================
        public DataTable ADListarCuentaXEntidades(int idCuenta, int idMoneda)
        {
            return objEjeSp.EjecSP("DEP_ListaCuentaXEntidad_Sp", idCuenta, idMoneda);
        }

        //=============================================================
        //--listar entidades con cuentas
        //=============================================================
        public DataTable ADListarEntidadesConCuenta()
        {
            return objEjeSp.EjecSP("DEP_ListaEntidadConCuenta_Sp");
        }

        //=================================================================
        //--Registra Operación de Retiro
        //=================================================================
        public DataTable ADRegistraOpeTransferencias(string xmlTipPag, string xmlComision, string xmlInterv, int idCta, Decimal /*era double*/nMondep, int idMon, Decimal /*era double*/nMonComis,
                                           Decimal /*era double*/nMonITF, Decimal /*era double*/nMonRedondeo, Decimal /*era double*/nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int idProd,
                                           string cNroDoc, int nTipPag,
                                           int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal,
            //----Parametros Deposito-------------
                                            int nidCtaDep, Decimal nMonITFDep, string xmlComisionDep, Decimal nMonComisDep, Decimal nMonOpeDep,
            //----Parametros Pago Crédito-------------
                                            string xmlPpg, Decimal nMoraPagada, int nNumCredito, Decimal nMonRedondeoCre, Decimal nImpuestoCre, Decimal nItfNormalCre, Decimal nMontoCre,
            //----Parámetros de Aportes---------------
                                           clslisDetalleAporte detallaporte, clslisDetalleFondo detallefondo, int x_idCli, Decimal x_nMonAporte, Decimal x_nMonFondo, int idTipoAporte
,                                             //------Variables Adicionales------------------
                                            bool lisOpeCre, bool lisOpeDep, bool lisOpeApo)
        {
            string cxmlAporte = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetalleaporte",
                                          from item in detallaporte
                                          select new XElement("dtdetalleaporte",
                                                              new XAttribute("idDetAporte", item.idDetAporte),
                                                              new XAttribute("idAporte", item.idAporte),
                                                              new XAttribute("cPeriodo", item.cPeriodo),
                                                              new XAttribute("nMonApoPac", item.nMonApoPac),
                                                              new XAttribute("nMonApoPag", item.nMonApoPag),
                                                              new XAttribute("dFecVenApo", item.dFecVenApo),
                                                              new XAttribute("idEstado", item.idEstado)
                                                              ))).ToString();


            string cxmlFondo = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetallefondo",
                                          from item in detallefondo
                                          select new XElement("dtdetallefondo",
                                                              new XAttribute("idDetFondo", item.idDetFondo),
                                                              new XAttribute("idFondo", item.idFondo),
                                                              new XAttribute("cPeriodo", item.cPeriodo),
                                                              new XAttribute("dFecVenApo", item.dFecVenApo),
                                                              new XAttribute("nMontoPac", item.nMontoPac),
                                                              new XAttribute("nMontoPag", item.nMontoPag),
                                                              new XAttribute("idEstado", item.idEstado)
                                                              ))).ToString();
            return objEjeSp.EjecSP("DEP_RegTransferenciaCtaPagos_SP", xmlTipPag, xmlComision, xmlInterv, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, idProd,
                                             cNroDoc, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal,
                //---Parametros Deposito------------------
                                             nidCtaDep, nMonITFDep, xmlComisionDep, nMonComisDep, nMonOpeDep,
                //----Parametros Pago Crédito-------------
                                             xmlPpg, nMoraPagada, nNumCredito, nMonRedondeoCre, nImpuestoCre, nItfNormalCre, nMontoCre,
                //----Parámetros de Aportes---------------
                                             cxmlAporte, cxmlFondo, x_idCli, x_nMonAporte, x_nMonFondo, idTipoAporte,
                //------Variables Adicionales------------------
                                             lisOpeCre, lisOpeDep, lisOpeApo);
        }
        //=================================================================
        //--Registra Operación Aportes
        //=================================================================
        public DataTable ADRegistraOpeAportesFondos(string detalleaporte, string detallefondo, bool lPagarInscripcion, int idInscripcion, string xmlUsuarioPagador)
        {
            return objEjeSp.EjecSP("CLI_RegPagoAporteFondo_sp", detalleaporte, detallefondo, lPagarInscripcion, idInscripcion, xmlUsuarioPagador);
        }

        //=================================================================
        //--Retorna Detalle Aportes
        //=================================================================
        public DataTable ADRetDetalleAportes(int idAporte, Decimal nMontoAporte)
        {
            return objEjeSp.EjecSP("DEP_RetTablaAportes_SP", idAporte, nMontoAporte);
        }

        //=================================================================
        //--Retorna Detalle Fondos
        //=================================================================
        public DataTable ADRetDetalleFondos(int idFondo, Decimal nMontoFondo)
        {
            return objEjeSp.EjecSP("DEP_RetTablaFondos_SP", idFondo, nMontoFondo);
        }

        public DataTable rptVoucherTransferencia(int idKarRetPag, int idKarRetDep, int idKarRetApo, int idKarRetFon,
                                                 int idKarPagCre, int idKarDepCta, int idKarPagApo, int idKarPagFon)
        {
            return objEjeSp.EjecSP("DEP_VoucherTransferencia_SP", idKarRetPag,  idKarRetDep,  idKarRetApo,  idKarRetFon,
                                                  idKarPagCre,  idKarDepCta,  idKarPagApo,  idKarPagFon);
        }
		//=================================================================
        //--Validar si Tiene Bloqueo Viegente por Garantía
        //=================================================================
        public DataTable ADValidaBloqCuentaxGar(int idCta)
        {
            return objEjeSp.EjecSP("DEP_ValidaBloqCtaxGar_Sp", idCta);
        }

        //=================================================================
        //--Retornar id Cuenta
        //=================================================================
        public DataTable ADRetornaidCuenta(string cNroCta)
        {
            return objEjeSp.EjecSP("DEP_RetornaidCuenta_sp", cNroCta);
        }

        //--=========================================================================
        //-- Mantenimiento de Cuentas Especiales
        //--=========================================================================
        public DataTable ADRegistraManCtasEspeciales(int idCuenta, int idCli, string cMotivo, int idusuario, int idagencia, bool bActivo)
        {
            return new clsGENEjeSP().EjecSP("DEP_GuardarRegCtasEspeciales_SP", idCuenta, idCli, cMotivo, idusuario, idagencia, bActivo);
        }

        public DataTable ADObtenerManCtasEspeciales(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_ObtenerRegCtaEspecial_SP", idCuenta);
        }

        public DataTable ADActualizarManCtasEspeciales(int idMCtaEsp, int idCuenta, int idCli, string cMotivo, int idusuario, int idagencia, bool bActivo)
        {
            return new clsGENEjeSP().EjecSP("DEP_ActualizarRegCtaEspecial_SP", idMCtaEsp, idCuenta, idCli, cMotivo, idusuario, idagencia, bActivo);
        }

        public DataTable ADRptManCtasEspeciales(bool bActivo, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptRegCtasEspeciales_SP", bActivo, dFechaInicio, dFechaFin);
        }

        //--=========================================================================
        //-- Traslado de Cuentas CTS
        //--=========================================================================
        public DataTable ADRptTrasladosCtasCTS(int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptTrasladosCtasCTS_SP", idAgencia, dFechaInicio, dFechaFin);
        }
        //===============================================================
        // BUSCA CLIENTES FALLECIDOS POR RANGO DE FECHA
        //===============================================================
        public DataTable ADObtenerClientesFallecidos(DateTime FecInicio, DateTime FecFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptClientesFallecidos_SP", FecInicio, FecFin);
        }
        //===============================================================
        // Reporte de Cuentas Inactivas por Cancelarse
        //===============================================================
        public DataTable ADRptCtasInacPorCanc(DateTime dFechaCorte)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptCtasInacPorCanc_SP", dFechaCorte);
        }

        //===============================================================
        // Validar si CTS tiene Solicitud Aprobado
        //===============================================================
        public DataTable ADValidaSolicitudCTS(int idCuenta, DateTime FechaSol, int idProducto)
        {
            return new clsGENEjeSP().EjecSP("DEP_ValidaSolicitudCTS_SP", idCuenta, FechaSol, idProducto);
        }

        //===============================================================
        // --Validar si CTS tiene Solicitud Aprobado
        //===============================================================
        public DataTable ADRetornaSolicitudCTS(int idSolicitud)
        {
            return new clsGENEjeSP().EjecSP("DEP_DatosCTSAprobado_SP", idSolicitud);
        }

        //===============================================================
        //--Retorna una lista de los depositos masivos por fechas
        //===============================================================

        public DataTable ADListaDepositosMasivos(int idclienteEmpleandor, DateTime dFechaIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("DEP_ListaDepositoMasivos_SP", idclienteEmpleandor, dFechaIni, dFecFin);
        }

        //===============================================================
        //--Valida Si Tiene Chequeras Activas
        //===============================================================
        public DataTable ADValidaChequeraCta(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ValidaChequeraCta_Sp", idCuenta);
        }


        //===============================================================
        // Reporte de Solicitudes de Cambio de Titulares de Cuenta
        //===============================================================
        public DataTable ADRptSolCambioTitularesCta(int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("DEP_RptSolCambioTitularesCta_SP", idAgencia, dFechaInicio, dFechaFin);
        }

        //===============================================================
        // Buscar Cuentas Canceladas del Cliente
        public DataTable ADCuentasCanceladasCli(string cidCli)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarCtasCanceladasCli_SP", cidCli);
        }

        public DataTable ADListaMovimientosCuenta(string cNroCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_ListarMovimientosCuenta_SP", cNroCuenta);
        }

        //===============================================================
        //--Precancelación de Ctas de Ahorros PF
        //===============================================================
        public DataTable ADPrecancelacionCtas(int idCuenta, DateTime dFechaCancel, Decimal nTasaCancel)
        {
            return new clsGENEjeSP().EjecSP("DEP_RecalculoInteresesCta_SP", idCuenta, dFechaCancel, nTasaCancel);
        }

        //===============================================================
        //--Actualizar Empleador
        //===============================================================
        public DataTable ADActualizaEmpleador(int idCuenta, string cNroDoc, int idusuario, DateTime dFechaReg)
        {
            return new clsGENEjeSP().EjecSP("DEP_ActualizaEmpleadorCta_SP", idCuenta, cNroDoc, idusuario, dFechaReg);
        }
        //===============================================================
        // RETORNA FECHA DE CADUCIDAD AHORRO CRECER
        //===============================================================
        public DataTable ADRetornaFechaFin()
        {
            return new clsGENEjeSP().EjecSP("DEP_DevuleveFechaFin_SP");
        }
        //===============================================================
        // Mantenimiento de Cuentas de Email Ahorros
        //===============================================================
        public DataTable ADBusquedaCorreo(string xmlDatos, int idPaso)
        {
            return new clsGENEjeSP().EjecSP("DEP_BuscaClientesEmail_SP",xmlDatos,idPaso);
        }
        public DataTable ADActualizaCorreo(int idCli, string cCorreo, string cCorreoAdic, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("DEP_ActualizarEmailClientes_SP", idCli, cCorreo, cCorreoAdic, idUsuario);
        }
        public DataTable ADBuscaDatosCuenta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_BuscarDatosCuenta_SP", idCuenta);
        }
        public DataTable ADDatosInterv(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("DEP_DatosInterv_SP", idCuenta);
        }
        public DataTable ADRegistroCambio(int idCli, int idCuenta,int idUsuMod, string cSustento, int idTipoEnvioEstCta, string cDireccionEnvioEstCta)
        {
            return new clsGENEjeSP().EjecSP("DEP_RegistroActCorreo_SP", idCli, idCuenta,idUsuMod , cSustento, idTipoEnvioEstCta, cDireccionEnvioEstCta);
        }
        public DataTable ADExtraeDatosVoucher(int idRegistro, string cOfi, string cUsuario)
        {
            return new clsGENEjeSP().EjecSP("DEP_ExtraerDatosCambio_SP", idRegistro,cOfi,cUsuario);
        }
        public DataTable ADActualizaCorreoMtoClientes(int idCli, string cCorreo, string cCorreoAdic, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("DEP_ActualizarEmailMtoClientes_SP", idCli, cCorreo, cCorreoAdic, idUsuario);
        }
        //=================================================================
        //--Reporte de Cambio de Tasa
        //=================================================================
        public DataTable ADReporteCambioTasa(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("DEP_ReporteCambioTasa_SP", dFechaDesde, dFechaHasta);
        }
        public DataTable ADReporteAsignacionProd()
        {
            return objEjeSp.EjecSP("DEP_ReporteAsignacionProductos_SP");
        }
        //=================================================================
        //--Validación de deposito como garantía a credito activo
        //=================================================================
        public DataTable ADValidarCtaGarantiaVinculadoCredito(string cNroCuenta)
        {
            return objEjeSp.EjecSP("AHO_ValidarContradeposito_SP", cNroCuenta);
        }
        //=================================================================
        //--Lista usuarios de talento humano
        //=================================================================
        public DataTable ADListarUsuariosTalentoHumano()
        {
            return objEjeSp.EjecSP("DEP_ListarUsuariosTalentoHumano_SP");
        }
        //=================================================================
        //--Lista operaciones usuarios de talento humano
        //=================================================================
        public DataTable ADListarOperacionesUsuarioTH(string cListUsuarios, int idTipoCarga, DateTime tFechaInicial, DateTime tFechaFinal)
        {
            return objEjeSp.EjecSP("DEP_ListarOperacionesTalentoHumano_SP", cListUsuarios, idTipoCarga, tFechaInicial, tFechaFinal);
        }
        //=================================================================
        //--Lista cuentas sueldo y cts
        //=================================================================
        public DataTable ADListarCuentasAhorroActivas(string cListProductos)
        {
            return objEjeSp.EjecSP("DEP_ListarSueldoYCTS_SP", cListProductos);
        }
    }

}
