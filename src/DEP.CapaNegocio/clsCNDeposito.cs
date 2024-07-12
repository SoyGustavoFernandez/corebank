using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace DEP.CapaNegocio
{
    public class clsCNDeposito
    {
        public clsADDeposito ObjOperacion = new clsADDeposito();

        public clsCNDeposito(bool cConex)
        {
            ObjOperacion = new clsADDeposito(cConex);
        }

        public clsCNDeposito()
        {
            ObjOperacion = new clsADDeposito();
        }

        public DataTable CNConsultaDeposito(int idcli, string cEstado)
        {
            return ObjOperacion.ADConsultaDeposito(idcli, cEstado);
        }

        public DataTable CNCartillaDPFAbonoM()
        {
            return ObjOperacion.ADCartillaDPFAbonoM();
        }

        public DataTable CNConsultaDatosxidCuenta(int idCuenta, string cEstado)
        {
            return ObjOperacion.ADConsultaDatosxidCuenta(idCuenta, cEstado);
        }

        public DataTable CNAWValidarCuentaAperturada(int idCuenta)
        {
            return ObjOperacion.ADAWValidarCuentaAperturada(idCuenta);
        }

        public DataTable CNConsultaDatosAbono(int idCuenta, string cTipoOpe)
        {
            return ObjOperacion.ADConsultaDatosAbono(idCuenta, cTipoOpe);
        }
        public DataTable CNOperacion(int idKardex)
        {
            return ObjOperacion.ADOperacion(idKardex);
        }
        public DataTable CNCuentasDeposito(int idcli, string cEstado)
        {
            return ObjOperacion.ADCuentasDeposito(idcli, cEstado);
        }
        public DataTable ADExtornoAbono(int idKardex, int idMotExt, int idcuenta, string tSustento, decimal nMonto)
        {
            return ObjOperacion.ADExtornoAbono(idKardex, idMotExt, idcuenta, tSustento, nMonto);
        }
        public DataTable CNUpdUsoCuenta(int idcuenta, int idUsuario)
        {
            return ObjOperacion.ADUpdUsoCuenta(idcuenta, idUsuario);
        }
        public DataTable CNUpdNoUsoCuenta(int idcuenta)
        {
            return ObjOperacion.ADUpdNoUsoCuenta(idcuenta);
        }
        public DataTable CNUpdNoUsoCuentaMasivo(int idusuario)
        {
            return ObjOperacion.ADUpdNoUsoCuentaMasivo(idusuario);
        }
        public DataTable CNAbonoCuenta(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nMonFavCli)
        {
            return ObjOperacion.ADAbonoCuenta(idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, nMonFavCli);
        }
        public DataTable CNLisCuentaAbonoMasivo(int idUsuario, int idMoneda)
        {
            return ObjOperacion.ADLisCuentaAbonoMasivo(idUsuario, idMoneda);
        }
        
        public string CNVerificaBloqueo(int idcuenta)
        {
            DataTable dtEstCuenta = ObjOperacion.ADUsuarioUsaCuenta(idcuenta);
            if (dtEstCuenta.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dtEstCuenta.Rows[0][0].ToString();
            }
        }
        public DataTable CNCancelacion(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia)
        {
            return ObjOperacion.ADUpdCancelacion(idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia);
        }
        //Retorna la Comision Fuera de Plaza
        public DataTable CNRetComisionPlaza(int idCuenta, int idAgencia, decimal nMonto)
        {
            return ObjOperacion.ADRetComisionPlaza(idCuenta, idAgencia, nMonto);
        }
        //Guarda el Retiro de Cuentas
        public DataTable CNGuardaRetiroCuenta(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nMonFavCli)
        {
            return ObjOperacion.ADGuardaRetiroCuenta(idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, nMonFavCli);
             
        }
        //Retorna los Intervinientes de la Cuenta
        public DataTable CNRetornaIntervDep(int idcuenta)
        {
            return ObjOperacion.ADRetornaIntervinientes(idcuenta);
        }
        //Retorna el Plan de Depositos
        public DataTable CNRetornaPlanDep(int idCuenta)
        {
            return ObjOperacion.ADRetornaPlanDep(idCuenta);
        }
        //Abono Ahorro Programado
        public DataTable CNAbonoDepProg(int idCuenta, decimal nMonto, string XmlPlanDeP, DateTime dFechaOpera, int idUsuario, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, decimal nValFavCli)
        {
            return ObjOperacion.ADAbonoDepProg(idCuenta, nMonto, XmlPlanDeP, dFechaOpera, idUsuario, idAgencia, nComision, nITF, idTipoPago, nValFavCli);
        }

        public DataTable CNListarPlazoDep(int CodSubPro)
        {
            return ObjOperacion.ADListarPlazoDep(CodSubPro);
        }

        public DataTable CNConsultaDatosAbono(int idCuenta)
        {
            return ObjOperacion.ADConsultaDatosAbono(idCuenta);
        }
        public DataTable CNRetornaPlazo(int idCuenta)
        {
            return ObjOperacion.ADRetornaPlazo(idCuenta);
        }
        //Disribucion en el Plan de Depositos
        public DataTable CNDistribuir(DataTable dtPlanDepositos, decimal nMontoPagado)
        {
            dtPlanDepositos.Columns["nCapitalPagado"].ReadOnly = false;
            for (int i = 0; i < dtPlanDepositos.Rows.Count; i++)
            {
                if ((int)dtPlanDepositos.Rows[i]["idEstadoCuota"] == 1)
                {
                    if (Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapital"]) - Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapitalPagado"]) > nMontoPagado)
                    {
                        dtPlanDepositos.Rows[i]["nCapitalPagado"] = nMontoPagado;
                        break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapital"]) - Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapitalPagado"]));
                        dtPlanDepositos.Rows[i]["nCapitalPagado"] = Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapital"]) - Convert.ToDecimal(dtPlanDepositos.Rows[i]["nCapitalPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    if (nMontoPagado <= 0)
                    {
                        break;
                    }
                }
            }
            dtPlanDepositos.AcceptChanges();
            return dtPlanDepositos;
        }
        public DataTable CNLisCuentaAbonoMasivo(int idUsuario, int idMoneda, int idProducto)
        {
            return ObjOperacion.ADLisCuentaAbonoMasivo(idUsuario, idMoneda, idProducto);
        }
        public DataTable CNEntregaProducto(int idCuenta)
        {
            return ObjOperacion.ADEntregaProducto(idCuenta);
        }

        public DataTable CNValCanCtaDepPro(int idCuenta)
        {
            return ObjOperacion.ADValCanCtaDepPro(idCuenta);
        }
        public DataTable CNDatCueBloq(int idCuenta)
        {
            return ObjOperacion.ADDatCueBloq(idCuenta);
        }
        public DataTable CNBloqueoCuenta(int idCuenta, int idBloqueo, DateTime dFechaBloq, int idUsuBloq, string cMotivo)
        {
            return ObjOperacion.ADBloqueoCuenta(idCuenta, idBloqueo, dFechaBloq, idUsuBloq, cMotivo);
        }
        public DataTable CNListaDepositoxPer(int idUsuario)
        {
            return ObjOperacion.ADListaDepositoxPer(idUsuario);
        }
        public DataTable CNGuadarReasig(string xmlCuentasAsig, int idAgenciaDes, int idUsuarioDes, string cMotivo, int idAgenciaOri, int idUsuarioOri, int idUsuRegigtra, int idAgeRegistra, DateTime dFechaRegistro)
        {
            return ObjOperacion.ADGuadarReasig(xmlCuentasAsig, idAgenciaDes, idUsuarioDes, cMotivo, idAgenciaOri, idUsuarioOri,  idUsuRegigtra,  idAgeRegistra, dFechaRegistro);
        }
        public DataTable CNListaPeriodoCTS(DateTime dtFechaOpe)
        {
            return ObjOperacion.ADListaPeriodoCTS(dtFechaOpe);
        }
        public DataTable CNListaCtasCtsEmpleador(int idEmpleador, int idMoneda, int idUsuario, bool lBloquea)
        {
            return ObjOperacion.ADListaCtasCtsEmpleador(idEmpleador, idMoneda, idUsuario, lBloquea);
        }
        public DataTable CNAbonoCuentaCTS(int idCuenta, DateTime dFechaOpera, int idUsuario, decimal nMonto, int idAgencia, decimal nComision, decimal nITF, int idTipoPago, int idPeriodoCTS, decimal nMonFavCli)
        {
            return ObjOperacion.ADAbonoCuentaCTS(idCuenta, dFechaOpera, idUsuario, nMonto, idAgencia, nComision, nITF, idTipoPago, idPeriodoCTS, nMonFavCli);
        }
        public void CNDeclaracionRemuneracionCTS(int idCuenta, int idPeriodoCTS, decimal nMonto, int idMoneda)
        {
            ObjOperacion.ADDeclaracionRemuneracionCTS(idCuenta, idPeriodoCTS, nMonto,idMoneda);
        }

        //===============================================================
        //--Cuentas de Ahorros
        //===============================================================
        public DataTable CNCuentasAhorros(int idcli, int idEstCta, int idMon, int idOpc)
        {
            return ObjOperacion.ADCuentasAho(idcli, idEstCta, idMon, idOpc);
        }

        //===============================================================
        //--Cuentas de Ahorros Vinculadas
        //===============================================================
        public DataTable CNCuentasAhorrosVin(int idcli, int idEstCta, int idMon, int x_nTipPersona, string xmlInterv)
        {
            return ObjOperacion.ADCuentasAhoVin(idcli, idEstCta, idMon, x_nTipPersona, xmlInterv);
        }

        //===============================================================
        //--Retorna Listado de Cuentas de Ahorros
        //===============================================================
        public DataTable CNRetornaCuentasAhorros(int idcli, int idEstCta, int idMon, int idOpc)
        {
            return ObjOperacion.ADRetornaCuentasAho(idcli, idEstCta, idMon, idOpc);
        }

        //===============================================================
        //--Retorna Datos de la Cuenta
        //===============================================================
        public DataTable CNRetornaDatosCuenta(int idCta, string idEstCta, int nOpc)
        {
            return ObjOperacion.ADDatosdeCuenta(idCta, idEstCta, nOpc);
        }

        //===============================================================
        //--Retorna Datos de la Cuenta Registro de firmas
        //===============================================================
        public DataTable CNRetornaDatosCuentaRegFirmas(int idCta)
        {
            return ObjOperacion.ADRetornaDatosCuentaRegFirmas(idCta);
        }

        //===============================================================
        //--Retorna Datos de Intervinientes de la Cuenta Registro de firmas
        //===============================================================
        public DataTable CNRetornaDatosIntervRegFirmas(int idCta)
        {
            return ObjOperacion.ADRetornaDatosIntervRegFirmas(idCta);
        }
        
        //===============================================================
        //--Retorna Datos de Intervinientes de la Cuenta Registro de firmas PJ
        //===============================================================
        public DataTable CNRetornaDatosIntervRegFirmasPJ(int idCta)
        {
            return ObjOperacion.ADRetornaDatosIntervRegFirmasPJ(idCta);
        }
        
        //=================================================================
        //--Retorna Datos del tipo de pago
        //=================================================================
        public DataTable CNDatosTipoPago(int idCta, int idAgencia)
        {
            return ObjOperacion.ADDatosTipoPago(idCta, idAgencia);
        }
        //===============================================================
        //--Retorna Datos de la Cuenta
        //===============================================================
        public DataTable CNRetornaBloqueosCuenta(int idCta)
        {
            return ObjOperacion.ADDatosBloqCuenta(idCta);
        }

        //===============================================================
        //--Registra Bloqueo de Cuentas
        //===============================================================
        public DataTable CNRegistraBloqueoCuenta(string xmlBloq, int idCta, Decimal nMonto, int idUsu, DateTime dFecha,string cMotDesbloq,bool lTipOpe,int idTipSolDesbloq,string cNomSolDesbloq)
        {
            return ObjOperacion.ADRegBloqCuenta(xmlBloq, idCta, nMonto, idUsu, dFecha, cMotDesbloq, lTipOpe,idTipSolDesbloq, cNomSolDesbloq);
        }

        public clsRespuestaServidor grabarBloqueoCuentaMasivo(string xmlBloqueoCuenta, string cMotivoDesbloqueo,
            bool lBloqueo, int idTipoSolicteDesbloqueo, string cNombreSolicteDesbloqueo)
        {
            DataTable dtRespuestaServidor =  ObjOperacion.grabarBloqueoCuentaMasivo( xmlBloqueoCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cMotivoDesbloqueo,
                lBloqueo, idTipoSolicteDesbloqueo, cNombreSolicteDesbloqueo);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor grabarBloqueoCuentaGrupoSol(
            int idGrupoSolidario, int idSolicitudCredGrupoSol, int idOperacion,
            string xmlBloqueoCuenta, string cMotivoDesbloqueo,
            bool lBloqueo, int idTipoSolicteDesbloqueo, string cNombreSolicteDesbloqueo)
        {
            DataTable dtRespuestaServidor = ObjOperacion.grabarBloqueoCuentaGrupoSol(
                idGrupoSolidario, idSolicitudCredGrupoSol, idOperacion,
                xmlBloqueoCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cMotivoDesbloqueo,
                lBloqueo, idTipoSolicteDesbloqueo, cNombreSolicteDesbloqueo);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        //===============================================================
        //--Retorna Intervinientes de la Cuenta
        //===============================================================
        public DataTable CNRetornaIntervinientesCuenta(int idCta)
        {
            return ObjOperacion.ADDatosIntervCuenta(idCta);
        }
        public List<clsIntervinienteCuenta> listarIntervinientesCuenta(int idCuenta)
        {
            DataTable dtIntervinienteCuenta = this.ObjOperacion.ADDatosIntervCuenta(idCuenta);
            return (dtIntervinienteCuenta.Rows.Count > 0) ?
                dtIntervinienteCuenta.ToList<clsIntervinienteCuenta>() as List<clsIntervinienteCuenta> :
                new List<clsIntervinienteCuenta>();
        }

        //===============================================================
        //--Retorna Detalle Ahorro Programado
        //===============================================================
        public DataTable CNRetornaAhoProgramado(int idCta, int idestado)
        {
            return ObjOperacion.ADRetAhoProgramado(idCta, idestado);
        }

        //===============================================================
        //--Registra deposito de Ahorros
        //===============================================================
        public DataTable CNRegistraDepositoAHO(string xmlTipPag, string xmlComision, int idCta, Decimal nMondep, int idMon, Decimal nMonComis,
                                            Decimal nMonITF, Decimal nMonRedondeo, Decimal nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int nCuota, int idProd,
                                            bool lIsAhoPrg, string cNroDoc, int idInsFin, int cCtaTransf, int nTipPag,
                                            int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal, int x_idMotivoOpe,
                                            int idTipoTransac, bool lModificaSaldoLinea, int idKardexRelacionado = 0)
        {
            return ObjOperacion.ADRegistraDeposito(xmlTipPag, xmlComision, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, nCuota, idProd,
                                             lIsAhoPrg, cNroDoc, idInsFin, cCtaTransf, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe,
                                             idTipoTransac, lModificaSaldoLinea, idKardexRelacionado);
        }

        //===============================================================
        //--Registra Retiro
        //===============================================================
        public DataTable CNRegistraRetiroAHO(string xmlTipPag, string xmlComision, string xmlInterv, int idCta, Decimal nMondep, int idMon, Decimal nMonComis,
                                             Decimal nMonITF, Decimal nMonRedondeo, Decimal nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int idProd,
                                             string cNroDoc, int nTipPag,
                                             int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal, int x_idMotivoOpe,
                                             int idTipoTransac, bool lModificaSaldoLinea)
        {
            return ObjOperacion.ADRegistraRetiro(xmlTipPag, xmlComision, xmlInterv, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, idProd,
                                             cNroDoc, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe,
                                             idTipoTransac, lModificaSaldoLinea);
        }

        //=================================================================
        //--Lista Tipos de Carga Masiva
        //=================================================================
        public DataTable CNLisTipoCargaMasiva(int nModoSeleccion)
        {
            return ObjOperacion.ADLisTipoCargaMasiva(nModoSeleccion);
        }

        //=================================================================
        //--Valida Carga Masiva de Ahorros
        //=================================================================
        public DataTable CNValidaCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                int idAgencia, int idProducto, int idMoneda, string xmlLisCtas, DateTime dFecSistema)
        {
            return ObjOperacion.ADValidaCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                       idAgencia, idProducto, idMoneda, xmlLisCtas, dFecSistema);
        }

        //=================================================================
        //--Retorna Datos de ctas para Carga Masiva
        //=================================================================
        public DataTable CNRetornaDatosCtaMasivo(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                 int idAgencia, int idProducto, int idMoneda, string xmlLisCtas)
        {
            return ObjOperacion.ADRetornaDatosCtaMasivo(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                        idAgencia, idProducto, idMoneda, xmlLisCtas);
        }
        public DataTable CNRetornaCtaMasivoPropio(int idTipoPlanillaPeriodo, int idPlanillaPeriodo, int idTipoOperac,
                                                  int idCanal, int idAgencia, int idProducto, int idMoneda, string xmlLisCtasAho)

        {
            return ObjOperacion.CNRetornaCtaMasivoPropio(idTipoPlanillaPeriodo, idPlanillaPeriodo, idTipoOperac, 
                                                        idCanal, idAgencia, idProducto, idMoneda, xmlLisCtasAho);
        }
        
        //=================================================================
        //--Registra Datos de Carga Masiva
        //=================================================================
        public DataTable CNRegistraCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                                  int idAgencia, int idProducto, int idMoneda, string xmlLisCtas, int idUsuOpe, int idUsuOrdenante, string cCaracteristica, DateTime dFecOpe, int idTipCarga)
        {
            return ObjOperacion.ADRegistraCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                         idAgencia, idProducto, idMoneda, xmlLisCtas, idUsuOpe, idUsuOrdenante, cCaracteristica, dFecOpe, idTipCarga);
        }

        //=================================================================
        //--Registra Operación de Deposito Masivo
        //=================================================================
        public DataTable CNRegistraDepositoCtaMasivo(int idCarga, int idCuenta, int nPlazo, int idMoneda, decimal nMonOperac,
                                                     decimal nMonComis, decimal nMonITF, int idCanal, int idAgencia, int idUsu,
                                                     DateTime dFechaOpe, int idProducto, bool lIsAhoProg, int nCuota,
                                                     int nTipPago, string xmlTipPago, string cNroDoc, int cCodInstFin,
                                                     int cCtaTransf, int idCliente, int idTipPersona, string cDniCliOpe,
                                                     string cNomCliOpe, string cDirCliOpe, int idPeriodoCTS, decimal nSumUltRemun, int x_idTipoCarga, int x_idPlanilla)
        {
            return ObjOperacion.ADRegistraDepositoCtaMasivo(idCarga, idCuenta, nPlazo, idMoneda, nMonOperac,
                                                            nMonComis, nMonITF, idCanal, idAgencia, idUsu,
                                                            dFechaOpe, idProducto, lIsAhoProg, nCuota, nTipPago,
                                                            xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf,
                                                            idCliente, idTipPersona, cDniCliOpe, cNomCliOpe,
                                                            cDirCliOpe, idPeriodoCTS, nSumUltRemun, x_idTipoCarga, x_idPlanilla);
        }
       
        public DataTable  ActualizarPlanillaPagada(int idKardex, int idTipoPlanPeriodo,int idPlanPeriodo, DateTime dFechaPago, int  idCliOperac)
        {
            return ObjOperacion.ActualizarPlanillaPagada(idKardex, idTipoPlanPeriodo, idPlanPeriodo, dFechaPago,  idCliOperac);
        }


        //===============================================================
        //--Validar Operaciones
        //===============================================================
        public bool CNValidaOperacionAho(int idCta, string idEstCta, int nOpc, Decimal nMontoOpe, ref string Mensaje)
        {
            DataTable dtbNumCuentas = ObjOperacion.ADDatosdeCuenta(idCta, idEstCta, nOpc);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    Mensaje = "La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo;
                    return false;
                }

                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()) == 4)
                {
                    Mensaje = "La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones";
                    return false;
                }
                //--===========================================================================
                //--Asignar Datos para Validación
                //--===========================================================================
                Decimal nMonBloqCta = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonTotBloq"].ToString()),
                nMonMinOpe = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString()),
                nMonMinSalDis = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinSalDis"].ToString()),
                nSaldoDisp = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());

                if (nOpc==9 || nOpc==10) //--Solo validar Saldos de la Cuenta en caso de Retiro y cancelación
                {
                    if (nMonBloqCta >= nSaldoDisp)
                    {
                        Mensaje = "La Cuenta no Tiene Saldo, porque Tiene Bloqueo por Monto";
                        return false;
                    }
                    if (nSaldoDisp - nMonBloqCta < nMonMinOpe + nMonMinSalDis)
                    {
                        Mensaje = "El Saldo Disponible, es Menor a Monto Mínimo Permitido";
                        return false;
                    }

                    if (nSaldoDisp - nMonBloqCta < nMonMinSalDis)
                    {
                        Mensaje = "El Saldo de la Cuenta, es Menor al Saldo Mínimo";
                        return false;
                    }
                    if (nMontoOpe > 0.00m)
                    {
                        if (nSaldoDisp - nMonBloqCta - nMonMinSalDis < nMontoOpe)
                        {
                            Mensaje = "El Saldo Disponible de la Cuenta, es Menor al Monto de la Operación";
                            return false;
                        }
                    }
                }
                                
            }
            else
            {
                Mensaje = "La Cuenta Buscada no es Valida...VERIFICAR";
                return false;
            }
            return true;
        }

        //=================================================================
        //--Retorna datos por Nro Cuenta
        //=================================================================
        public DataTable CNRetornaDatosxCuenta(int idcuenta, int idEstCta, int idMon, int idOpc)
        {
            return ObjOperacion.ADRetornaDatosxCuenta(idcuenta, idEstCta, idMon, idOpc);
        }

        //=================================================================
        //--Registra Operación de Cancelación
        //=================================================================
        public DataTable CNRegistraCancelacionCta(int idCanal, int idCuenta, int idProd, int idMoneda, bool lCumplePlazo,
                                                 Decimal nTasCancelacion, Decimal nMonOperacion, Decimal nMonCapital,
                                                 Decimal nMonInteres, Decimal nMonIntPagAde, Decimal nMonComis, Decimal nMonITF,
                                                 Decimal nMonRedondeo, string xmlComision, int idCliItf, string cDniCliOpe,
                                                 string cNomCliOpe, string cDirCliOpe, int idAge, int idUsu, DateTime dFechaOpe,
                                                 string xmlInterv, string xmlTipPago, int x_idTipPago, int idMotivoOpe,
                                                    bool lModificaSaldoLinea, int idTipoTransac)
        {
            return ObjOperacion.ADRegistraCancelacionCta(idCanal, idCuenta, idProd, idMoneda, lCumplePlazo, nTasCancelacion,
                                                         nMonOperacion, nMonCapital, nMonInteres, nMonIntPagAde, nMonComis,
                                                         nMonITF, nMonRedondeo, xmlComision, idCliItf, cDniCliOpe,
                                                         cNomCliOpe, cDirCliOpe, idAge, idUsu, dFechaOpe, xmlInterv,
                                                         xmlTipPago, x_idTipPago, idMotivoOpe,
                                                        lModificaSaldoLinea, idTipoTransac);

        }
        //=================================================================
        //--Cargar Combo con las planillas generadas pero No pagadas
        //=================================================================
        public DataTable CargarPlanillaNoPagadas()
        {
            return ObjOperacion.CargarPlanillaNoPagadas();
        }
        //=================================================================
        //--Validacion de actualización de informacion de clientes menores edad
        //=================================================================
        public DataTable CNValidarActDatCli(int idCli)
        {
            return ObjOperacion.ADValidarActDatCli(idCli);
        }
        //=================================================================
        //--Lista solicitudes de apertura pendientes de confirmación
        //=================================================================
        public DataTable CNListaSolPenAho(int idAgencia)
        {
            return ObjOperacion.ADListaSolPenAho(idAgencia);
        }

        //=============================================================
        //--Listado de las cuentas por entidades financieras con saldo
        //=============================================================
        public DataTable ListarCuentaXEntidades(int idEntidades, int idMoneda)
        {
            return ObjOperacion.ADListarCuentaXEntidades(idEntidades, idMoneda);
        }

        //=============================================================
        //--Listado de las entidades financientras con cuenta 
        //=============================================================
        public DataTable ListarEntidadesConCuenta()
        {
            return ObjOperacion.ADListarEntidadesConCuenta();
        }

        //===============================================================
        //--Registra Retiro
        //===============================================================
        //--Registra Retiro
        //===============================================================
        public DataTable CNRegistraOpeTransferencias(string xmlTipPag, string xmlComision, string xmlInterv, int idCta, Decimal nMondep, int idMon, Decimal nMonComis,
                                             Decimal nMonITF, Decimal nMonRedondeo, Decimal nMonCapital, int idUsu, int idAge, DateTime dFecOpe, int idProd,
                                             string cNroDoc, int nTipPag,
                                             int idCliITF, string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCanal,
            //----Parametros Deposito-------------
                                             int nidCtaDep, Decimal nMonITFDep, string xmlComisionDep, Decimal nMonComisDep, Decimal nMonOpeDep,
            //----Parametros Pago Crédito-------------
                                             string xmlPpg, Decimal nMoraPagada, int nNumCredito, Decimal nMonRedondeoCre, Decimal nImpuestoCre, Decimal nItfNormalCre, Decimal nMontoCre,
            //----Parámetros de Aportes---------------
                                             clslisDetalleAporte detallaporte, clslisDetalleFondo detallefondo, int x_idCli, Decimal x_nMonAporte, Decimal x_nMonFondo, int idTipoAporte,
            //------Variables Adicionales------------------
                                             bool lisOpeCre, bool lisOpeDep, bool lisOpeApo)
        {
            
            return ObjOperacion.ADRegistraOpeTransferencias(xmlTipPag, xmlComision, xmlInterv, idCta, nMondep, idMon, nMonComis,
                                             nMonITF, nMonRedondeo, nMonCapital, idUsu, idAge, dFecOpe, idProd,
                                             cNroDoc, nTipPag,
                                             idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal,
                //---Parametros Deposito------------------
                                             nidCtaDep, nMonITFDep, xmlComisionDep, nMonComisDep, nMonOpeDep,
                //----Parametros Pago Crédito-------------
                                             xmlPpg, nMoraPagada, nNumCredito, nMonRedondeoCre, nImpuestoCre, nItfNormalCre, nMontoCre,
                //----Parámetros de Aportes---------------
                                             detallaporte, detallefondo, x_idCli, x_nMonAporte, x_nMonFondo, idTipoAporte,
                //------Variables Adicionales------------------
                                             lisOpeCre, lisOpeDep, lisOpeApo);
        }

        //===============================================================
        //--Registra Pago Aportes
        //===============================================================
        public DataTable CNRegistraOpeAportesFondos(string detalleaporte, string detallefondo, bool lPagarInscripcion, int idInscripcion, string xmlUsuarioPagador)
        {
            return ObjOperacion.ADRegistraOpeAportesFondos(detalleaporte, detallefondo, lPagarInscripcion, idInscripcion, xmlUsuarioPagador);
        }

        //===============================================================
        //--Retorna Detalle Aportes
        //===============================================================
        public DataTable CNRetDetalleAportes(int idAporte, Decimal nMontoAporte)
        {
            return ObjOperacion.ADRetDetalleAportes(idAporte, nMontoAporte);
        }

        //===============================================================
        //--Retorna Detalle Fondos
        //===============================================================
        public DataTable CNRetDetalleFondos(int idFondo, Decimal nMontoFondo)
        {
            return ObjOperacion.ADRetDetalleFondos(idFondo, nMontoFondo);
        }

        public DataTable rptVoucherTransferencia(int idKarRetPag, int idKarRetDep, int idKarRetApo, int idKarRetFon,
                                                int idKarPagCre, int idKarDepCta, int idKarPagApo, int idKarPagFon)
        {
            return ObjOperacion.rptVoucherTransferencia( idKarRetPag, idKarRetDep, idKarRetApo, idKarRetFon,
                                                        idKarPagCre, idKarDepCta, idKarPagApo, idKarPagFon);
        }
		//===============================================================
        //--Valida Bloqueo de Cuentas por Garantía
        //===============================================================
        public DataTable CNValidaBloqueoCuentaxGar(int idCta)
        {
            return ObjOperacion.ADValidaBloqCuentaxGar(idCta);
        }

        //===============================================================
        //--Retorna el id de la Cuenta
        //===============================================================
        public DataTable CNRetornaidCuenta(string cNroCuenta)
        {
            return ObjOperacion.ADRetornaidCuenta(cNroCuenta);
        }
        //--=========================================================================
        //-- Mantenimiento de Cuentas Especiales
        //--=========================================================================
        public DataTable CNRegistraManCtasEspeciales(int idCuenta, int idCli, string cMotivo, int idusuario, int idagencia, bool bActivo)
        {
            return ObjOperacion.ADRegistraManCtasEspeciales(idCuenta, idCli, cMotivo, idusuario, idagencia, bActivo);
        }

        public DataTable CNObtenerManCtasEspeciales(int idCuenta)
        {
            return ObjOperacion.ADObtenerManCtasEspeciales(idCuenta);
        }

        public DataTable CNActualizarManCtasEspeciales(int idMCtaEsp, int idCuenta, int idCli, string cMotivo, int idusuario, int idagencia, bool bActivo)
        {
            return ObjOperacion.ADActualizarManCtasEspeciales(idMCtaEsp, idCuenta, idCli, cMotivo, idusuario, idagencia, bActivo);
        }

        public DataTable CNRptManCtasEspeciales(bool bActivo, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ObjOperacion.ADRptManCtasEspeciales(bActivo, dFechaInicio, dFechaFin);
        }
        //--=========================================================================
        //-- Traslado de Cuentas CTS
        //--=========================================================================
        public DataTable CNRptTrasladosCtasCTS(int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ObjOperacion.ADRptTrasladosCtasCTS(idAgencia, dFechaInicio, dFechaFin);
        }
        //===============================================================
        // BUSCA CLIENTES FALLECIDOS POR RANGO DE FECHA 
        //===============================================================
        public DataTable CNObtenerClientesFallecidos(DateTime FecInicio, DateTime FecFin)
        {
            return ObjOperacion.ADObtenerClientesFallecidos(FecInicio, FecFin);
        }

        //===============================================================
        //--Retorna una lista de los depositos masivos por fechas
        //===============================================================
        public DataTable CNListaDepositosMasivos(int idclienteEmpleandor, DateTime dFechaIni, DateTime dFecFin)
        {
            return ObjOperacion.ADListaDepositosMasivos(idclienteEmpleandor, dFechaIni, dFecFin);
        }

        //===============================================================
        // Reporte de Cuentas Inactivas por Cancelarse
        //===============================================================
        public DataTable CNRptCtasInacPorCanc(DateTime dFechaCorte)
        {
            return ObjOperacion.ADRptCtasInacPorCanc(dFechaCorte);
        }
        //===============================================================
        // --Validar si CTS tiene Solicitud Aprobado
        //===============================================================
        public DataTable CNValidaSolicitudCTS(int idCuenta, DateTime FechaSol, int idProducto)
        {
            return ObjOperacion.ADValidaSolicitudCTS(idCuenta, FechaSol, idProducto);
        }

        //===============================================================
        // --Validar si CTS tiene Solicitud Aprobado
        //===============================================================
        public DataTable CNRetornaSolicitudCTS(int idSolicitud)
        {
            return ObjOperacion.ADRetornaSolicitudCTS(idSolicitud);
        }          

        //===============================================================
        //--Valida Si Tiene Chequeras Activas
        //===============================================================
        public DataTable CNValidaChequeraCta(int idCuenta)
        {
            return ObjOperacion.ADValidaChequeraCta(idCuenta);
        }


        //===============================================================
        // Reporte de Solicitudes de Cambio de Titulares de Cuenta
        //===============================================================
        public DataTable CNRptSolCambioTitularesCta(int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ObjOperacion.ADRptSolCambioTitularesCta(idAgencia, dFechaInicio, dFechaFin);
        }

        //===============================================================
        // Buscar Cuentas Canceladas del Cliente
        //===============================================================
        public DataTable CNCuentasCanceladasCli(string cidCli)
        {
            return ObjOperacion.ADCuentasCanceladasCli(cidCli);
        }

        public DataTable CNListaMovimientosCuenta(string cNroCuenta)
        {
            return ObjOperacion.ADListaMovimientosCuenta(cNroCuenta);
        }

        //===============================================================
        // Actualizar Empleador
        //===============================================================
        public DataTable CNActualizaEmpleador(int idCuenta, string cNroDoc, int idusuario, DateTime dFechaReg)
        {
            return ObjOperacion.ADActualizaEmpleador(idCuenta, cNroDoc, idusuario, dFechaReg);
        }
        //===============================================================
        // RETORNA FECHA DE CADUCIDAD AHORRO CRECER
        //===============================================================
        public DataTable CNRetornaFechaFin()
        {
            return ObjOperacion.ADRetornaFechaFin();
        }
        //===============================================================
        // BUSQUEDA Y ACTUALIZACION DE CORREO
        //===============================================================
        public DataTable CNBusquedaCorreo(string xmlDatos, int idPaso)
        {
            return ObjOperacion.ADBusquedaCorreo(xmlDatos,idPaso);
        }
        public DataTable CNActualizaCorreo(int idCli, string cCorreo, string cCorreoAdic, int idUsuario)
        {
            return ObjOperacion.ADActualizaCorreo(idCli,cCorreo,cCorreoAdic,idUsuario);
        }
        public DataTable CNBuscaDatosCuenta(int idCuenta)
        {
            return ObjOperacion.ADBuscaDatosCuenta(idCuenta);
        }
        public DataTable CNDatosInterv(int idCuenta)
        {
            return ObjOperacion.ADDatosInterv(idCuenta);
        }
        public DataTable CNRegistroCambio(int idCli, int idCuenta, int idUsuMod, string cSustento, int idTipoEnvioEstCta, string cDireccionEnvioEstCta)
        {
            return ObjOperacion.ADRegistroCambio(idCli, idCuenta, idUsuMod,cSustento, idTipoEnvioEstCta, cDireccionEnvioEstCta);
        }
        public DataTable CNExtraeDatosVoucher(int idRegistro,string cOfi, string cUsuario)
        {
            return ObjOperacion.ADExtraeDatosVoucher(idRegistro,cOfi,cUsuario);
        }
        public DataTable CNActualizaCorreoMtoClientes(int idCli, string cCorreo, string cCorreoAdic, int idUsuario)
        {
            return ObjOperacion.ADActualizaCorreoMtoClientes(idCli, cCorreo, cCorreoAdic, idUsuario);
        }
        //=================================================================
        //--Reporte de Cambio de Tasa
        //=================================================================
        public DataTable CNReporteCambioTasa(DateTime dFechaDesde,DateTime dFechaHasta)
        {
            return ObjOperacion.ADReporteCambioTasa(dFechaDesde,dFechaHasta);
        }
        public DataTable CNReporteAsignacionProd()
        {
            return ObjOperacion.ADReporteAsignacionProd();
        }
        //=================================================================
        //--Validación de deposito como garantía a credito activo
        //=================================================================
        public DataTable CNValidarCtaGarantiaVinculadoCredito(string cNroCta)
        {
            return ObjOperacion.ADValidarCtaGarantiaVinculadoCredito(cNroCta);
        }
        //=================================================================
        //--Lista Usuarios de Talento Humano
        //=================================================================
        public DataTable CNListarUsuariosTalentoHumano()
        {
            return ObjOperacion.ADListarUsuariosTalentoHumano();
        }
        //=================================================================
        //--Lista Operaciones de Talento Humano
        //=================================================================
        public DataTable CNListarOperacionesUsuarioTH(string cListUsuarios, int idTipoCarga, DateTime tFechaInicial, DateTime tFechaFinal)
        {
            return ObjOperacion.ADListarOperacionesUsuarioTH(cListUsuarios, idTipoCarga, tFechaInicial, tFechaFinal);
        }

        //=================================================================
        //--Lista Operaciones de Talento Humano
        //=================================================================
        public DataTable CNListarCuentasAhorroActivas(string cListProductos)
        {
            return ObjOperacion.ADListarCuentasAhorroActivas(cListProductos);
        }
    }
}
