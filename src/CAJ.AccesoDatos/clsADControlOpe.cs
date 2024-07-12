using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.AccesoDatos;

namespace CAJ.AccesoDatos
{
    public class clsADControlOpe
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        //=============================================================
        //--Retorna el Tipo de Cliente
        //=============================================================
        public DataTable SaldoIniOpe(DateTime dFecSis, int nidUsuario, int idAge, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_SaldoInicial_sp", dFecSis, nidUsuario, idAge, idTipResCaj);
        }

        //=============================================================
        //--Guardar Datos de Inicio de Operaciones
        //=============================================================
        public DataTable GuardaIniOpe(DateTime dFecSis, int nidUsuario, Decimal nMonSoles, Decimal nmonDolares, int ccodage, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_InicioOperaciones_sp", dFecSis, nidUsuario, nMonSoles, nmonDolares, ccodage, idTipResCaj);
        }
        //=========================================================================================================
        //--Guardar Datos de Inicio de Operaciones cuando el usuario tiene dos responsabilidades asignados
        //=========================================================================================================
        public void GuardaIniOpeCajBov(DateTime dFecSis, int nidUsuario, Decimal nMonSoles, Decimal nmonDolares, Decimal nMonSolesBov, Decimal nmonDolaresBov, int ccodage, int idTipResCaj, int idTipResCaj2)
        {
            objEjeSp.EjecSP("CAJ_InicioOperacionesCaj_sp", dFecSis, nidUsuario, nMonSoles, nmonDolares, nMonSolesBov, nmonDolaresBov, ccodage, idTipResCaj, idTipResCaj2);
        }
        //=============================================================
        //--Valida Inicio de Operaciones
        //=============================================================
        public DataTable ValIniOpe(DateTime dFecSis, int nidUsuario, int ccodage)
        {
            return objEjeSp.EjecSP("CAJ_ValidaIniOpe_sp", dFecSis, nidUsuario, ccodage);
        }
        //=============================================================
        //--Valida Inicio de Operaciones
        //=============================================================
        public DataTable ValIniOpeCaja(DateTime dFecSis, int nidUsuario, int ccodage, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ValidaIniOpeCaj_sp", dFecSis, nidUsuario, ccodage, idTipResCaj);
        }
        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable LisTipRec()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipRec_Sp");
        }

        //=============================================================
        //--Listado de Tipos de Recibos Rango
        //=============================================================
        public DataTable LisTipRecRango(string cIdTipoRecibo)
        {
            return objEjeSp.EjecSP("CAJ_ListaTipRecRango_Sp", cIdTipoRecibo);
        }

        //=============================================================
        //--Lista Concepto de Recibos
        //=============================================================
        public DataTable LisConcep(int nTipRec, string descripcion)
        {
            return objEjeSp.EjecSP("CAJ_ListaConceptos_Sp", nTipRec, descripcion);
        }

        //=============================================================
        //--Lista Concepto de Recibos MAnt Rango Ejecutivo
        //=============================================================
        public DataTable LisConcepEjCorp(int nTipRec, string descripcion, string cIdConcepto)
        {
            return objEjeSp.EjecSP("CAJ_ListaConceptosEjCorp_Sp", nTipRec, descripcion, cIdConcepto);
        }

        //=============================================================
        //--Lista Proyectos
        //=============================================================
        public DataTable LisProyectos(string descripcion)
        {
            return objEjeSp.EjecSP("CAJ_ListaProyectos_SP", descripcion);
        }

        //=============================================================
        //--Guardar Recibo
        //=============================================================
        public DataTable GuardaRec(int idTipRec, int idConc, int idCol, int idCli, int idMon, Decimal nMonRec, Decimal nMonItf, Decimal nTotRec, string cSust,
                                    DateTime dFecReg, int idOpe, int idAge, int idAgeDest, int idAdeudo, int IdCentroCosto, bool lModificaSaldoLinea, int idReciboProvisional = 0, int nMesesSeguro = 0)
        {
            return objEjeSp.EjecSP("CAJ_GuardarRecibo_Sp", idTipRec, idConc, idCol, idCli, idMon, nMonRec, nMonItf, nTotRec, cSust, dFecReg, idOpe, idAge, idAgeDest,
                                                            idAdeudo, IdCentroCosto, idReciboProvisional, lModificaSaldoLinea, nMesesSeguro);
        }

        //=============================================================
        //--Actualizar Recibo
        //=============================================================
        public DataTable ActualizarRecibo(int idRecibo, int idConcepto, string cMotivo, int idusuario, int idAgencia, DateTime dFecSystem)
        {
            return objEjeSp.EjecSP("CAJ_ActualizarRecibo_Sp", idRecibo, idConcepto, cMotivo, idusuario, idAgencia, dFecSystem);
        }

        //=============================================================
        //--Extornar Recibo
        //=============================================================
        public void ExtorRec(int nNroRec)
        {
            objEjeSp.EjecSP("CAJ_ExtornarRecibo_Sp", nNroRec);
        }

        //=============================================================
        //--Extornar Recibo
        //=============================================================
        public DataTable BurcarRec(int nNroRec)
        {
            return objEjeSp.EjecSP("CAJ_BuscarRecibo_Sp", nNroRec);
        }

        //=============================================================
        //--Listar Tipo de Habilitaciones
        //=============================================================
        public DataTable ListaTipHab(int nidPerfil, int idAgencia, int idUsuario, int idTipResponsable)
        {
            return objEjeSp.EjecSP("CAJ_ListaTipHab_Sp", nidPerfil, idAgencia, idUsuario, idTipResponsable);
        }

        //=============================================================
        //--Buscar habilitación
        //=============================================================
        public DataTable ADBuscaHab(int idKardex)
        {
            return objEjeSp.EjecSP("CAJ_BuscarHabilitacion_sp", idKardex);
        }
        //=============================================================
        //--Listar Responsable de Habilitaciones
        //=============================================================
        public DataTable ListaRespHab(int idCargo, int idAge, string cTipRes, int idUsuario, DateTime dFecSistema)
        {
            return objEjeSp.EjecSP("CAJ_ListaUsuHab_Sp", idCargo, idAge, cTipRes, idUsuario, dFecSistema);
        }
        ////=============================================================
        ////--Validar si Usuario es Responsable de Boveda anterior
        ////=============================================================
        //public DataTable ValRespBoveda(int idUsu, int idAge)
        //{
        //    return objEjeSp.EjecSP("CAJ_VerRespBoveda_Sp", idUsu, idAge);
        //}

        //=============================================================
        //--Validar si Usuario es Responsable de Boveda nuevo
        //=============================================================
        public DataTable ValRespBoveda(int idUsu, int idAge, int idTipoRes, DateTime dFecProces)
        {
            return objEjeSp.EjecSP("CAJ_VerRespCajBoveda_Sp", idUsu, idAge, idTipoRes, dFecProces);
        }

        //=============================================================
        //--Guardar Datos de las Habilitaciones
        //=============================================================
        public DataTable GuardaHab(DateTime dFecOpe, int idAge, int idTipHab, int idMon, Decimal nMonHab, string cSust, int idUsuOri, int idUsuDest, int idIngEgr, int idTipResCaja, string xmlBillete, string xmlMoneda, bool lReqBilletaje)
        {
            return objEjeSp.EjecSP("CAJ_GuardarHabilitacion_Sp", dFecOpe, idAge, idTipHab, idMon, nMonHab, cSust, idUsuOri, idUsuDest, idIngEgr, idTipResCaja, xmlBillete, xmlMoneda, lReqBilletaje);
        }

        //=============================================================
        //--Listar Habilitaciones Pendientes
        //=============================================================
        public DataTable ListarHabPen(DateTime dFecOpe, int idAge, int idUsu, int nOpc)
        {
            return objEjeSp.EjecSP("CAJ_ListarHabPendientes_Sp", dFecOpe, idAge, idUsu, nOpc);
        }

        //=============================================================
        //--Listar Habilitaciones Pendientes
        //=============================================================
        public DataTable ConfirmaHab(int idHab, DateTime dFecOpe, int idUsuOri, int idUsuDes, int nIdAgencia, int TipMon, decimal nMonTot, int idTipResCajOri, int idTipResCajDes)
        {
            return objEjeSp.EjecSP("CAJ_ConfirmarHabilitacion_Sp", idHab, dFecOpe, idUsuOri, idUsuDes, nIdAgencia, TipMon, nMonTot, idTipResCajOri, idTipResCajDes);
        }

        //=============================================================
        //--Listar Habilitaciones Pendientes
        //=============================================================
        public void RechazarHab(int idHab, string cMotRechazo)
        {
            objEjeSp.EjecSP("CAJ_RechazarHabilitacion_Sp", idHab, cMotRechazo);
        }

        //=============================================================
        //--Listar Billetes y Monedas
        //=============================================================
        public DataTable ListarBillMon(int idMon, int idBillMon)
        {
            return objEjeSp.EjecSP("CAJ_ListaBillMon_Sp", idMon, idBillMon);
        }

        //=============================================================
        //--Registrar Corte Fraccionario
        //=============================================================
        public DataTable RegCorFrac(int idusu, DateTime dFecReg, int idAge, string XmlMonSol, string XmlBillSol, string XmlBillDol, int idTipResCaja)
        {
            return objEjeSp.EjecSP("CAJ_RegistraCorFrac_Sp", idusu, dFecReg, idAge, XmlMonSol, XmlBillSol, XmlBillDol, idTipResCaja);
        }

        //=============================================================
        //--Cuadre de Operacones solo es para ventanilla
        //=============================================================
        public DataTable CuadreOpe(DateTime dFecReg, int idUsu, int idMon, int idAge, int idTipIE)
        {
            return objEjeSp.EjecSP("CAJ_ListaCuadreOpe_Sp", dFecReg, idUsu, idMon, idAge, idTipIE);
        }

        //=============================================================
        //--retorna Saldo Inicial por Operadora
        //=============================================================
        public DataTable SalIniOpe(DateTime dFecReg, int idUsu, int idAge, int ntipmov)
        {
            return objEjeSp.EjecSP("CAJ_SaldoIniOpe_sp", dFecReg, idUsu, idAge, ntipmov);
        }

        //=============================================================
        //--Guardar datos de Habilitaciones a Boveda Mediante Transferencia 
        //=============================================================
        public DataTable TrasferirHabilitacionBoveda(DateTime dFecOpe, int idAge, int idMon, Decimal nMonHab, int idUsuOri)
        {
            return objEjeSp.EjecSP("Caj_TransferirHabilitacion_Sp", dFecOpe, idAge, idMon, nMonHab, idUsuOri);
        }

        //=============================================================
        //--Registrar Cierre Operaciones
        //=============================================================
        public void RegCieOpe(DateTime dFecReg, int idusu, int idAge, int idTipOpeCaj, Decimal nSalIniSol, Decimal nSalIniDol,
                            Decimal nSalFinSol, Decimal nSalFinDol, string xmlIngSol, string XmlEgrSol, string XmlIngDol, string XmlEgrDol)
        {
            objEjeSp.EjecSP("CAJ_GuardaCierreOpe_Sp", dFecReg, idusu, idAge, idTipOpeCaj, nSalIniSol, nSalIniDol,
                                 nSalFinSol, nSalFinDol, xmlIngSol, XmlEgrSol, XmlIngDol, XmlEgrDol);
        }

        //=============================================================
        //--Valida Corte Fraccionario
        //=============================================================
        public DataTable ValCorteFrac(DateTime dFecSis, int nidUsuario, int ccodage)
        {
            return objEjeSp.EjecSP("CAJ_ValidaCorteFrac_sp", dFecSis, nidUsuario, ccodage);
        }
        //=============================================================
        //--Valida Corte Fraccionario del modulo de caja
        //=============================================================
        public DataTable ValCorteFracCaj(DateTime dFecSis, int nidUsuario, int ccodage, int idTipResCaja)
        {
            return objEjeSp.EjecSP("CAJ_ValidaCorteFracCaj_sp", dFecSis, nidUsuario, ccodage, idTipResCaja);
        }

        //=============================================================
        //--Validar si ya realizó la carga de voucher Prepago y adelanto cuota
        //=============================================================
        public DataTable ValidarCargaVoucher(DateTime dFecSis, int nidUsuario)
        {
            return objEjeSp.EjecSP("CAJ_ValidarCargaVoucher_Sp", dFecSis, nidUsuario);
        }
        //=============================================================
        //--Lista detalle de Conceptos de Recibos
        //=============================================================
        public DataTable ListaSubItem(int nCodCon)
        {
            return objEjeSp.EjecSP("CAJ_ListaSubItemConcep_Sp", nCodCon);
        }

        //=============================================================
        //--Listar Corte Fraccionario
        //=============================================================
        public DataTable ListarCorteFrac(DateTime dFecCor, int idUsu, int idAge, int idMon, int idMonBill, int idTipResCaja)
        {
            return objEjeSp.EjecSP("CAJ_CorteFraccionario_Sp", dFecCor, idUsu, idAge, idMon, idMonBill, idTipResCaja);
        }
        //=============================================================
        //--Listar billetaje por el codigo de las habilitaciones
        //=============================================================
        public DataTable ListarBilletajeXHab(DateTime dFecCor, int idMon, int idMonBill, int idHab)
        {
            return objEjeSp.EjecSP("CAJ_BilletajeHab_Sp", dFecCor, idMon, idMonBill, idHab);
        }

        //=============================================================
        //--Retorna Monto total por moneda del Corte Fraccionario
        //=============================================================
        public DataTable RetMontoCorteFrac(DateTime dFecCor, int idUsu, int idAge, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_RetMontoCorFrac_Sp", dFecCor, idUsu, idAge, idTipResCaj);
        }

        //=============================================================
        //--Listar Agencias
        //=============================================================
        public DataTable ListarAge()
        {
            return objEjeSp.EjecSP("CAJ_ListaAgencias_Sp");
        }

        public DataTable ListarAgeXml()
        {

            return cnadtabla.retonarTablaXml("SI_FinAgencia");
        }

        //=============================================================
        //--Listar Colaboradores por Agencias
        //=============================================================
        public DataTable ListarColAge(int idAge)
        {
            return objEjeSp.EjecSP("CAJ_ListaColabAge_Sp", idAge);
        }

        //=============================================================
        //--Listar Colaboradores por Agencias
        //=============================================================
        public DataTable ListarAseAge(int idAge)
        {
            return objEjeSp.EjecSP("RCP_ListaAsesoresAge_Sp", idAge);
        }
        

        //=============================================================
        //--Registra apertura de Caja Cerrada
        //=============================================================
        public void RegCajaCerrada(DateTime dFecOpe, int idUsuAut, int idAgeAut, int idColRes, int idAgeColRes, string cSust, int nOpc, int idTepResCaj)
        {
            objEjeSp.EjecSP("CAJ_AperturaCajaOpe_Sp", dFecOpe, idUsuAut, idAgeAut, idColRes, idAgeColRes, cSust, nOpc, idTepResCaj);
        }

        //=============================================================
        //--Validar Autorización para modificar el Corte Fracc.
        //=============================================================
        public DataTable ValidaAutCorte(DateTime dFecCor, int idUsu, int idAge, int nOpc, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ValidaAutCorte_Sp", dFecCor, idUsu, idAge, nOpc, idTipResCaj);
        }

        //=============================================================
        //--Validar Si tiene Pendientes de Corte Fraccionario
        //=============================================================
        public DataTable ValidaHabPen(DateTime dFecCor, int idUsu, int idAge, int nOpc, int idTipoHab)
        {
            return objEjeSp.EjecSP("CAJ_ValidaHabPend_Sp", dFecCor, idUsu, idAge, nOpc,  idTipoHab);
        }

        //=============================================================
        //--Valida Cargo del Colaborador
        //=============================================================
        public DataTable ValidaCargoPer(int idUsu)
        {
            return objEjeSp.EjecSP("CAJ_ValidaCargo_Sp", idUsu);
        }

        //=============================================================
        //--Listar Colaboradores por Agencias
        //=============================================================
        public DataTable ListarColPorAge(int idAge)
        {
            return objEjeSp.EjecSP("CAJ_ListaColPorAge_Sp", idAge);
        }

        //=============================================================
        //--Listar Responsable de Boveda por Agencias
        //=============================================================
        public DataTable ListaResBovAge(int idAge, DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("CAJ_ListaResBovAge_Sp", idAge, dFecOpe);
        }

        //=============================================================
        //--Guardar responsable de Boveda
        //=============================================================
        public DataTable GuardaRespBoveda(int idUsu, int idAge, int idAgeReg, int idUsuarioReg, DateTime dFecIni, int idTipoResp, bool lTiempoIndeter, DateTime? dfecFin)
        {
            return objEjeSp.EjecSP("CAJ_GuardaResBovAge_Sp", idUsu, idAge, idAgeReg, idUsuarioReg, dFecIni, idTipoResp, lTiempoIndeter, dfecFin);
        }
        //=============================================================
        //--Editar responsable de Boveda
        //=============================================================
        public DataTable EditarRespBoveda(int idRespBoveda, int idUsuMod, DateTime dFecMod, DateTime? dFecFin, int idAgeMod, bool lTiempoIndeter, bool lIndBaja)
        {
            return objEjeSp.EjecSP("CAJ_EditarResBovAge_Sp", idRespBoveda, idUsuMod, dFecMod, dFecFin, idAgeMod, lTiempoIndeter, lIndBaja);
        }

        //=============================================================
        //--Cuadre de Operacones
        //=============================================================
        public DataTable ConsultaCuadreOpe(DateTime dFecReg, int idUsu, int idMon, int idAge, int idTipIE, int nOpc, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ConsultaCuadreOpe_Sp", dFecReg, idUsu, idMon, idAge, idTipIE, nOpc, idTipResCaj);
        }

        //=============================================================
        //--Guardar responsable de Boveda
        //=============================================================
        public DataTable VerificaCierreOpe(DateTime dFecOpe, int idAge)
        {
            return objEjeSp.EjecSP("CAJ_ValidaCierreOpe_Sp", dFecOpe, idAge);
        }

        //=============================================================
        //--Listado Estado Cierre
        //=============================================================
        public DataTable VerificaEstadoCie(DateTime dFecPro)
        {
            return objEjeSp.EjecSP("CAJ_ListaEstadoCierre_Sp", dFecPro);
        }

        //=============================================================
        //--retorna Responsable de Boveda
        //=============================================================
        public DataTable RetResBov(int idAge)
        {
            return objEjeSp.EjecSP("CAJ_RetResBoveda_Sp", idAge);
        }

        //=============================================================
        //--Listado de saldos a Nivel Institucional
        //=============================================================
        public DataTable ListSaldoInst(DateTime dFecPro)
        {
            return objEjeSp.EjecSP("CAJ_SaldoInstitucional_Sp", dFecPro);
        }
        //=============================================================
        //--Retorna el Nivel de Autorización
        //=============================================================
        public DataTable RetNivAuto(int idOpc, int idPerfil)
        {
            return objEjeSp.EjecSP("CAJ_ValNivelAuto_Sp", idOpc, idPerfil);
        }

        //=============================================================
        //--Retorna Parametro de Configuración
        //=============================================================
        public DataTable RetParConf(int idParam)
        {
            return objEjeSp.EjecSP("CAJ_RetorValParam_Sp", idParam);
        }

        //=============================================================
        //--Lista Concepto de Recibos por Perfiles
        //=============================================================
        public DataTable LisConcepPer(int nTipRec, int IdPerfil)
        {
            return objEjeSp.EjecSP("CAJ_ListaConcepPer_Sp", nTipRec, IdPerfil);
        }
        //=============================================================
        //--Retorna el monto max por concepto
        //=============================================================
        public DataTable LisMonConcep(int idAgencia, int idConcepto)
        {
            return objEjeSp.EjecSP("CAJ_ListaMonConcep_Sp", idAgencia, idConcepto);
        }
        //=============================================================
        //--Retorna conceptos de adeudados
        //=============================================================
        public DataTable ADConceptoAdeuda()
        {
            return objEjeSp.EjecSP("CAJ_ConceptoAdeudado_sp");
        }
        //=============================================================
        //--Consulta Adeudado
        //=============================================================
        public DataTable ADConsultaAdeudado(int idAdeudo, string idEntidad, string idMoneda,
            string idEstado, string cDescripcionLinea)
        {
            return objEjeSp.EjecSP("CAJ_ConsultaAdeudado_sp", idAdeudo, idEntidad, idMoneda,
            idEstado, cDescripcionLinea);
        }
        //=============================================================
        //--Inserta Actualiza Adeudado
        //=============================================================
        public DataTable ADInsUpAdeudado(string cxmlAdeudo, string cxmlDesembolsoAdeudo, string XmlTipoProd, string XmldsDestinoAde, string XmlPlanPagoAdeudado, int idAge, DateTime dFecha, int idUsu)
        {
            return objEjeSp.EjecSP("CRE_InsUpdAdeudo_SP", cxmlAdeudo, cxmlDesembolsoAdeudo, XmlTipoProd, XmldsDestinoAde, XmlPlanPagoAdeudado, idAge, dFecha, idUsu);
        }

        //=============================================================
        //--Quitar pagare de Adeudado
        //=============================================================
        public DataTable ADQuitarPagareAdeudado(int idAdeudado, int idDesembolso, decimal nMontoPagare, int idAge, DateTime dFecha, int idUsu)
        {
            return objEjeSp.EjecSP("CRE_AnularPagareAdeudado_SP", idAdeudado, idDesembolso, nMontoPagare, idAge, dFecha, idUsu);
        }
        //=============================================================
        //--Paga adeudado
        //=============================================================
        public DataTable ADPagoAdeudado(int idAdeuda, decimal nMonto, int idSubItem)
        {
            return objEjeSp.EjecSP("CAJ_ActualizaPagoAdeudo_sp", idAdeuda, nMonto, idSubItem);
        }
        //=============================================================
        //--Movimiento Caja Pulmon-Boveda
        //=============================================================
        public DataTable MovCajaPulmonBoveda(DateTime dFecPro, int idUsu, int idMon, int idAge, int idTipIE, int nOpc)
        {
            return objEjeSp.EjecSP("CAJ_MovPulmonBoveda_sp", dFecPro, idUsu, idMon, idAge, idTipIE, nOpc);
        }

        ////=============================================================
        ////--Registrar Movimiento Caja Pulmon o Boveda
        ////=============================================================
        //public DataTable registroMovCajaBoveda(int idtipoMov, int idusu, DateTime dFecReg, int idAge, string xmlIngSol, string xmlEgrSol, string xmlIngDol, string xmlEgrDol, Decimal nSalIniSol, Decimal nSalFinSol, Decimal nSalIniDol, Decimal nSalFinDol)
        //{
        //    return objEjeSp.EjecSP("CAJ_GuardarMovimientos_Sp", idtipoMov, idusu, dFecReg, idAge, xmlIngSol, xmlEgrSol, xmlIngDol, xmlEgrDol, nSalIniSol, nSalFinSol, nSalIniDol, nSalFinDol);
        //}
        //=============================================================
        //--Eliminar Movimiento Caja Pulmon o Boveda
        //=============================================================
        public DataTable EliminarMovCajaBoveda(int idtipoMov, int idusu, DateTime dFecReg, int idAge)
        {
            return objEjeSp.EjecSP("CAJ_EliminarMovimientos_Sp", idtipoMov, idusu, dFecReg, idAge);
        }
        //=============================================================
        //--Listar limite Cobertura
        //=============================================================
        public DataTable listarLimitesCobertura(int IdTipoResponsableCaja, int idAgecias, int idMoneda)
        {
            return objEjeSp.EjecSP("caj_ListaLimiteCobertura_sp", IdTipoResponsableCaja, idAgecias, idMoneda);
        }
        //=============================================================
        //--Registrar limite Cobertura
        //=============================================================
        public void RegLimiteCobertura(int idusu, int idAge, int idTipResCaj, DateTime dFecIni, decimal nMonLimite, string cSustento, decimal nXLimMenor, decimal nXLimInter, decimal nXLimMayor, decimal nMonLimiteDol, decimal nXLimMenorDol, decimal nXLimInterDol, decimal nXLimMayorDol, int idControlTipoMoneda)
        {
            objEjeSp.EjecSP("CAJ_GuardarLimiteCobertura_sp", idusu, idAge, idTipResCaj, dFecIni, nMonLimite, cSustento, nXLimMenor, nXLimInter, nXLimMayor, nMonLimiteDol, nXLimMenorDol, nXLimInterDol, nXLimMayorDol, idControlTipoMoneda);
        }
        //=============================================================
        //--Listar tipo deuda
        //=============================================================
        public DataTable listarTipoDeuda(int IdPadre)
        {
            return objEjeSp.EjecSP("CAJ_ListarTipoDeuda_sp", IdPadre);
        }
        //=============================================================
        //--Listar estados de adeudado
        //=============================================================
        public DataTable listarEstadoAdeudado()
        {
            return objEjeSp.EjecSP("CAJ_ListarEstadoAdeudado_sp");
        }

        //=============================================================
        //--Listar desembolso de adeudado
        //=============================================================
        public DataTable ListarTipoDesembolso(int nPadre)
        {
            return objEjeSp.EjecSP("CAJ_ListarFormaDesembolso_sp", nPadre);
        }
        //=============================================================
        //--Listar Destino de adeudado
        //=============================================================
        public DataTable ListarDestinoAdeudado(int idAdeudado)
        {
            return objEjeSp.EjecSP("CAJ_ListarDestinoAdeudado_sp", idAdeudado);
        }
        //=============================================================
        //--Listar Año base de adeudado
        //=============================================================
        public DataTable ListarAñoBase()
        {
            return objEjeSp.EjecSP("CAJ_ListaAñoBase_sp");
        }
        //=============================================================
        //--Listar Mes base de adeudado
        //=============================================================
        public DataTable ListarMesBase()
        {
            return objEjeSp.EjecSP("CAJ_ListaMesBase_sp");
        }
        //=============================================================
        //--Listar desembolso de adeudado
        //=============================================================
        public DataTable ListarDesembolsoAdeudado(int idAdeudado)
        {
            return objEjeSp.EjecSP("CAJ_ListaDesembolsoAdeudado_sp", idAdeudado);
        }
        //=============================================================
        //--Retorna Tipos Entidades Financieras
        //=============================================================
        public DataTable ADTipoEntidadFinanciera(string cindicadorFondeo)
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoEntidad_sp", cindicadorFondeo);
        }
        //=============================================================
        //--Retorna Entidades Financieras por tipo
        //=============================================================
        public DataTable ADEntidadFinanciera(int idEntidad, string cindicadorFondeo)
        {
            return objEjeSp.EjecSP("CAJ_ListaEntidad_sp", idEntidad, cindicadorFondeo);
        }
        public DataTable ADEntidadFinancieraXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEntidadFinanciera");
        }

        //=============================================================
        //--Listar desembolso de adeudado
        //=============================================================
        public DataTable ListarDesembolsoAdeudado(int idAdeudado, string estado)
        {
            return objEjeSp.EjecSP("CAJ_ListaDesembolsoAdeudado_sp", idAdeudado, estado);
        }
        //=============================================================
        //--Listar productos adeudados de creditos
        //=============================================================
        public DataTable ListarProductoAdeudado(int idAdeudado)
        {
            return objEjeSp.EjecSP("CAJ_ListaProductoAdeudado_sp", idAdeudado);
        }

        //=============================================================
        //--lista las frecuancias de pagos de los adeudados
        //=============================================================
        public DataTable ListarFrecuenciaPagoAdeudado()
        {
            return objEjeSp.EjecSP("CAJ_ListaFrecuenciaPago_sp");
        }

        //=============================================================
        //--lista tipo de tasa de los adeudados
        //=============================================================
        public DataTable listarTipoTasa()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoTasaAdeudado_sp");
        }
        //=============================================================
        //--lista de linea de los adeudados
        //=============================================================
        public DataTable listarLineaAdeudado(int idpadre)
        {
            return objEjeSp.EjecSP("CAJ_ListaTipolineaAdeudado_sp", idpadre);
        }
        //=============================================================
        //--lista Plan de pago de los adeudados
        //=============================================================
        public DataTable listarPlanPagoAdeudado(int idDesembolso, string cestadoCuota)
        {
            return objEjeSp.EjecSP("CAJ_ListaPlanPagoAdeudado_sp", idDesembolso, cestadoCuota);
        }
        //=============================================================
        //--lista forma de pago de los adeudados
        //=============================================================
        public DataTable listarFormaPagoAdeudado()
        {
            return objEjeSp.EjecSP("CAJ_ListaFormaPagoAdeudado_sp");
        }
        //=============================================================
        //--lista tipo de documento de pago de los adeudados

        //=============================================================
        public DataTable listarTipoDocumentoAdeudado()
        {
            return objEjeSp.EjecSP("CAJ_ListaDocumentoPagoAdeudado_sp");

        }
        //=============================================================
        //--Pago del plan de pago del adeudado
        //=============================================================
        public DataTable GuardaPagoAdeudado(string xmlPagoAdeudado, int ncancelacion, int idAge, DateTime dFechaOpe, int idUsu)
        {
            return objEjeSp.EjecSP("Caj_InsUpdPagoAdeudo_SP", xmlPagoAdeudado, ncancelacion, idAge, dFechaOpe, idUsu);
        }
        //=============================================================
        //--ExtornO de Pago del plan de pago - adeudado
        //=============================================================
        public DataTable ExtornarPagoAdeudado(int idAdeudado, int cDesembolso, int cNroCuota)
        {
            return objEjeSp.EjecSP("Caj_ExtornoPagoAdeudo_SP", idAdeudado, cDesembolso, cNroCuota);
        }

        //=============================================================
        //--Validar Si Existe Resonsable de Boveda en la Agencia
        //=============================================================
        public DataTable ADValidarExisRespBoveda(int idAgencia, DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("CAJ_ValidarRespBoveda_Sp", idAgencia, dFecOpe);
        }

        //=============================================================
        //--Validar Si Ya Cerro Boveda
        //=============================================================
        public DataTable ADValidarCierreBoveda(int idAgencia, DateTime dFechaOpe)
        {
            return objEjeSp.EjecSP("CAJ_ValidarCierreBoveda_Sp", idAgencia, dFechaOpe);
        }
        //============================================================================
        //---Registra Extorno de Recibos
        //============================================================================
        public DataTable RegExtornoRecibos(int idKardex, int idRecibo, int idUsu, int idAge, DateTime dFechaOpe,
                                        Decimal nMonOpe, int idTipOpe, int idTippago,
                                        bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objEjeSp.EjecSP("CAJ_RegistraExtornoRecibos_SP", idKardex, idRecibo, idUsu, idAge, dFechaOpe,
                                        nMonOpe, idTipOpe, idTippago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        //============================================================================
        //---Registra tipo de relacion
        //============================================================================
        public DataTable ValidaTipoRelacion(int idUsu)
        {
            return objEjeSp.EjecSP("CAJ_ValidaTipoRelacion_SP", idUsu);
        }
        //============================================================================
        //---Grabar pago de dieta
        //============================================================================
        public DataTable GrabarPagoDieta(int idRecibo, decimal nMontoDieta, decimal nMontoRta4ta, decimal nMontoPagado)
        {
            return objEjeSp.EjecSP("CAJ_GuardarPagoDieta_Sp", idRecibo, nMontoDieta, nMontoRta4ta, nMontoPagado);
        }
        //=============================================================
        //--Buscar Recibo de Pago de Dieta
        //=============================================================
        public DataTable BurcarRecPagoDieta(int nNroRec)
        {
            return objEjeSp.EjecSP("CAJ_BuscarReciboPagoDieta_Sp", nNroRec);
        }
        //=============================================================
        //--Buscar Id de Pago de Dieta
        //=============================================================
        public int BurcarIdPagoDieta()
        {
            DataTable dt = objEjeSp.EjecSP("CAJ_BuscarIdPagoDieta_Sp");
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable LisTipoRecibos()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoRecibos_Sp");
        }
        //=============================================================
        //--Listado de Tipos de Recibos Grupo Ejecutivo
        //=============================================================
        public DataTable LisTipoRecibosGrupoEjecutivo(string cIdTipoRecibo)
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoRecibosGrupoEjecutivo_Sp", cIdTipoRecibo);
        }
        //=============================================================
        //--Buscar Id de Pago de Dieta
        //=============================================================
        public DataTable BurcarIdPagoDieta(int IdPerfil)
        {
            return objEjeSp.EjecSP("CAJ_BuscarIdPagoDieta_Sp", IdPerfil);
        }
        //=============================================================
        //--Retorna resumen de creditos otorgados por  adeudado
        //=============================================================
        public DataTable ADResumenCreditosPorAdeudado(DateTime dFechaOpe)
        {
            return objEjeSp.EjecSP("Caj_RptCreditoXAdeudado_sp", dFechaOpe);
        }
        //=============================================================
        //--Valida Inicio de Operacion de Caja General(Boveda)
        //=============================================================
        public DataTable ADValidaIniOpeCajGen(DateTime dFechaOpe, int idAgencia)
        {
            return objEjeSp.EjecSP("Caj_ValidarIniOpeCajGeneral_sp", dFechaOpe, idAgencia);
        }
        public DataTable ListarDetalleConRecidConcepto(int idConcepto, int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListarDetalleConRecidConcepto_SP", idConcepto, idAgencia);
        }

        public DataTable InsertarDetalleConRec(int idConcepto, int idAgencia, decimal nMontoMin, decimal nMontoMax, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_InsertarDetalleConRec_SP", idConcepto, idAgencia, nMontoMin, nMontoMax, idUsuario);
        }

        public DataTable ActualizarDetalleConRec(int idConcepto, int idAgencia, decimal nMontoMin, decimal nMontoMax, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_ActualizarDetalleConRec_SP", idConcepto, idAgencia, nMontoMin, nMontoMax, idUsuario);
        }
        //====================================================================
        //--Obtiene el efectivo actual
        //====================================================================
        public DataTable ObtieneEfectivoActual(int idAgencia, DateTime dfecha, int idUsuario, int idMoneda, int idTipResCaj)
        {
            return objEjeSp.EjecSP("Caj_ObtieneEfectivoActual_Sp", dfecha, idUsuario, idAgencia, idMoneda, idTipResCaj);
        }
        ////=============================================================
        ////--Listar tipo de responsable de caja
        ////=============================================================
        //public DataTable listarTipoResponsableCja(int nOpcion)
        //{
        //    return objEjeSp.EjecSP("CAJ_ListarTipoRespBoveda_sp",nOpcion);
        //}
        //=============================================================
        //--Listar todos los tipos de habilitaciones
        //=============================================================
        public DataTable listarTiposTiposHabilitaciones(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListaTodoTipoHabilitacion_sp", idAgencia);
        }
        //=====================================================================================
        //--Listar relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable listaRelacionTipoHabilitacionXResponsable(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListaVinculoTipHabPorResponsable_sp", idAgencia);
        }
        //=====================================================================================
        //--grabar relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable GrabarVincTipHabTipResponsable(int idAgencia, int idAgeReg, int idUsuarioReg, DateTime dFecReg,
           int idTipoRes, int idTipoHab, bool lNecBilletaje)
        {
            return objEjeSp.EjecSP("CAJ_InsVinTipHabPorTipResp_Sp", idAgencia, idAgeReg, idUsuarioReg, dFecReg,
            idTipoRes, idTipoHab, lNecBilletaje);
        }
        //=====================================================================================
        //--Editar relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable EditarVincTipHabTipResponsable(int idTipHabPorTipRes, int idAgeMod, int idUsuarioMod, DateTime dFecMod,
           bool lNecBilletaje, bool lVigente)
        {
            return objEjeSp.EjecSP("CAJ_ActTipHabPorTipResponsable_Sp", idTipHabPorTipRes, idAgeMod, idUsuarioMod, dFecMod, lNecBilletaje, lVigente);
        }
        //=====================================================================================
        //--Lista los tipos de responsable por usuario que inició operaciones
        //=====================================================================================
        public DataTable cargarTipRespPorUsuarioIniOpe(int idUsuario, int idAgencia, DateTime dFecOperacion)
        {
            return objEjeSp.EjecSP("CAJ_TipResPorUsuarioIniOpe_Sp", idUsuario, idAgencia, dFecOperacion);
        }
        //=====================================================================================
        //--Lista los tipos de responsable asignados por usuario 
        //=====================================================================================
        public DataTable cargarTipRespPorUsuarioAsg(int idUsuario, int idAgencia, DateTime dFecOperacion)
        {
            return objEjeSp.EjecSP("CAJ_TipResPorUsuario_Sp", idUsuario, idAgencia, dFecOperacion);
        }
        //=============================================================
        //--Buscar balancin  por habilitacion
        //=============================================================
        public DataTable ADBuscaBalancin(int idHabilitacion)
        {
            return objEjeSp.EjecSP("CAJ_rptBillPorHabilitracion_SP", idHabilitacion);
        }
        //=============================================================
        //--Listar Billetaje boveda
        //=============================================================
        public DataTable ListarBillBoveda(int idAgencia, int idMoneda, int idTipBillMon, int idTipResCaj, DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("CAJ_ListaBillMonBov_Sp", idAgencia, idMoneda, idTipBillMon, idTipResCaj, dFecOpe);
        }
        //=============================================================
        //--Retorna saldo de operador por agencia , fecha y tipo de responsable.
        //=============================================================
        public DataTable RetSaldoOperadorAge(DateTime dFechaOpe, int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_RetornaSaldoEnLinea_Sp", dFechaOpe, idUsuario, idAgencia, idTipResCaj);
        }
        //=============================================================
        //--Existencia y Utilización Recibo
        //=============================================================
        public DataTable ADDevuelveExistenciayUtilRecibo(int idRecibo)
        {
            return objEjeSp.EjecSP("ADM_DevuelveExistenciayUtilRecibo", idRecibo);
        }
        //=============================================================
        //--Monto Duplicado Voucher
        //=============================================================
        public DataTable ADDevuelveDuplicadoVoucher()
        {
            return objEjeSp.EjecSP("ADM_DevuelveMontoDuplicadoVoucher_SP");
        }
        //=============================================================
        //--Actualiza los saldos del Operador
        //=============================================================
        public void ActualizarSaldo(int idAgencia, int idUsuario, DateTime dfechaOpe, int idTipoMoneda, int IdTipoTransac_I_E, decimal nMontoOperacion, int idTipResCaj)
        {
            objEjeSp.EjecSP("CAJ_MonitoreoSaldoHab_sp", idAgencia, idUsuario, dfechaOpe, idTipoMoneda, IdTipoTransac_I_E, nMontoOperacion, idTipResCaj);
        }
        //=============================================================
        //--Valida Corte Fraccionario del modulo de caja
        //=============================================================
        public DataTable ADlistaBillbovedaInicio(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ValidaIniBillBoveda_sp", idAgencia);
        }

        //====================================================================
        //--Lista los MOtivos de Operación
        //====================================================================
        public DataTable ADListaMotivoOperacion(int idTipOperacion, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListaMotivoOperacion_Sp", idTipOperacion, idPerfil);
        }
        //=======================================================================================
        //--Listado de Colaboradore por Agencias que iniciarion operaciones en un rango de fecha
        //=======================================================================================
        public DataTable ADListarColabAgenciasIniOpe(int idAge, DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CAJ_ListaUsuarioIniOpe_SP", idAge, dFecIni, dFecFin);
        }
        //=======================================================================================
        //--valida el inicio de operaciones de boveda
        //=======================================================================================
        public DataTable ADValidarIniOpeBov(DateTime dFecOpe, int idAgencia, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ValidaIniOpeBoveda_SP", dFecOpe, idAgencia, idTipResCaj);
        }
        //=======================================================================================
        //--retorna una lista de saldos de caja para el cuadre  con contabilidad
        //=======================================================================================
        public DataTable ADListarCuadreLibroCajaCnt(DateTime dFecIni, DateTime dFecFin, int idAgencia, bool lConsolidado)
        {
            return objEjeSp.EjecSP("CAJ_ValidaSaldoCajaContabilidad_sp", dFecIni, dFecFin, idAgencia, lConsolidado);
        }
        //=============================================================
        //--lista las fechas de operacion del usuario
        //=============================================================
        public DataTable ADListaFechasOperacionXUsuario(int idUsuario, int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CAJ_ListarFechaOperacion_SP", idUsuario, idAgencia, dFecIni, dFecFin);
        }
        //=============================================================
        //--Obtiene saldos de inicio y cierre de un operador 
        //=============================================================
        public DataTable ADListarSaldoIniCieOpe(int idAgencia, DateTime dFecOpe, int idTipResCaj, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_ObtenerSaldosCajaOperador_SP", idAgencia, dFecOpe, idTipResCaj, idUsuario);
        }
        //=============================================================
        //-- lista el ultima operacion por usuario y tipo de responsable
        //=============================================================
        public DataTable ADListarUltOperacionUsuTipRes(int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ListaUltOperacion_Sp", idUsuario, idAgencia, idTipResCaj);
        }
        //=============================================================
        //--Registrar traslado de saldos de caja
        //=============================================================
        public DataTable ADInsertarTrasladoSaldoCaja(int idTipReasignacion, int idAgenciaOpe, int idUsuOri, int idTipResCajOri,
            DateTime dFecOperaOri, decimal nMonSalAntSolOri, decimal nMonSalAntDolOri, decimal nMonNueSalSolOri, decimal nMonNueSalDolOri,
    int idUsuDes, int idTipResCajDes, DateTime dFecOpeDes, decimal? nMonSalAntSolDes, decimal? nMonSalAntDolDes, decimal nMonNueSalSolDes,
    decimal nMonNueSalDolDes, DateTime dFecReasigna, int idUsuReasigna, int idAgeReasig)
        {
            return objEjeSp.EjecSP("CAJ_InsertarReasignacionCaja_SP",   idTipReasignacion, idAgenciaOpe, idUsuOri, idTipResCajOri, dFecOperaOri,
                                                                        nMonSalAntSolOri, nMonSalAntDolOri, nMonNueSalSolOri, nMonNueSalDolOri,
                                                                        idUsuDes, idTipResCajDes, dFecOpeDes, nMonSalAntSolDes, nMonSalAntDolDes, nMonNueSalSolDes,
                                                                        nMonNueSalDolDes, dFecReasigna, idUsuReasigna, idAgeReasig);
        }
        //=============================================================
        //-- lista la reasignacion de caja por usuario
        //=============================================================
        public DataTable ADListarReasignacionCajUsu(int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ListaReasigUsuCaja_SP", idUsuario, idAgencia, idTipResCaj);
        }

        public DataTable ADRetornaIdIniOpeCaj(DateTime dFecSis, int nidUsuario, int ccodage, int idTipResCaj)
        {
            return objEjeSp.EjecSP("CAJ_RetornaIdIniOpeCaj_sp", dFecSis, nidUsuario, ccodage, idTipResCaj);
        }
        //=============================================================
        //--Saldo de boveda para validar el inicio de operaciones.
        //=============================================================
        public DataTable ADValorBoveda(int idAgencia, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_ObtienValorBoveda_sp", idAgencia, idUsuario);
        }

        public DataTable ListaConceptosEspecificos(string cConceptos)
        {
            return objEjeSp.EjecSP("CAJ_ListarConceptosEspecificos_SP", cConceptos);
        }

        public DataTable GuardarReciboDinElec(int idTipRec, int idConc, int idCli, int idNoCli, int idTipoDocumento, string cNroDocumento, string cNombres, string cCelular,
                int idMon, decimal nMonRec, decimal nMonItf, decimal nTotRec, string cSust, DateTime dFecReg, int idOpe, int idAge, int idAgeDest, bool lModificaSaldoLinea)
        {
            return objEjeSp.EjecSP("CAJ_PonerSacarDineroElectronico_Sp", idTipRec, idConc, idCli, idNoCli, idTipoDocumento, cNroDocumento, cNombres, cCelular, idMon, nMonRec,
                                    nMonItf, nTotRec, cSust, dFecReg, idOpe, idAge, idAgeDest, lModificaSaldoLinea);
        }

        public DataTable reporteDineroElect(DateTime dtInicio, DateTime dtFin)
        {
            return objEjeSp.EjecSP("CAJ_ReportePonerSacarDinero_SP", dtInicio, dtFin);
        }

        public DataTable GuardarReciboRelacionadoSeguro(int idTipoRecibo, int idConceptoRecibo, int idColaborador, int idCliente,
                                                        int idMoneda, decimal nMontoRecibo, decimal nMontoItf, decimal nMontoTotal,
                                                        string cSustento, DateTime dFechaRegistro, int idOperador, int idAgencia,
                                                        int idAgenciaDestino, int idAdeudo, int idCentroCosto,
                                                        int idCreditoSeguro, bool lModificaSaldoLinea, int idReciboProvisional = 0, int idTipoPlan = 0, int nMesesSeguro = 0)
        {
            return objEjeSp.EjecSP("CAJ_GuardarReciboRelacionadoSeguro_Sp", idTipoRecibo, idConceptoRecibo, idColaborador, idCliente,
                                                                            idMoneda, nMontoRecibo, nMontoItf, nMontoTotal,
                                                                            cSustento, dFechaRegistro, idOperador, idAgencia,
                                                                            idAgenciaDestino, idAdeudo, idCentroCosto, idCreditoSeguro,
                                                                            idReciboProvisional, idTipoPlan, lModificaSaldoLinea, nMesesSeguro);
        }

        public DataTable GuardarOperacionesWesternUnion(String xmlOpWesternUnion, int idUsu, int idAgencia, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CAJ_RegistroOperacionesWesternUnion_SP", xmlOpWesternUnion, idUsu, idAgencia, idPerfil, dFechaSistema);
        }

        public DataSet ListarOperacionConciliacionWesternUnion(int idColaborador, int idAgencia, String dFecha, int idTipoRec)
        {
            return objEjeSp.DSEjecSP("CAJ_ListarOperacionesWesternUnion_SP", idColaborador, idAgencia, dFecha, idTipoRec);
        }

        public DataTable GuardarConcilicionWesternUnion(String xmlConciliacion, DateTime dFechaReg)
        {
            return objEjeSp.EjecSP("CAJ_ConciliacionRecWestern_SP", xmlConciliacion, dFechaReg);
        }

        public DataTable ResumenConciliacionWesternUnion(int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptResumenConciliacionWesternUnion_SP", idAgencia, dFechaIni, dFechaFin);
        }

        public DataTable ListarUsuariosEjecutivoServicioConciliacionWestern(DateTime dFecha, bool dFechaSistema, int nIdAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListaUsuariosEjecutivoServicioConciliacionWestern_SP", dFecha, dFechaSistema, nIdAgencia);
        }

        public DataTable obtenerDatosUsuarioZona(int idUsu)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosUsuarioZona_SP", idUsu);
        }
  
        #region Recibo de Emision de Bonos
        public DataTable ADGuardarReciboRelBono(int idTipoRecibo, int idConceptoRecibo, int idColaborador, int idCliente,
                                                        int idMoneda, decimal nMontoRecibo, decimal nMontoItf, decimal nMontoTotal,
                                                        string cSustento, DateTime dFechaRegistro, int idOperador, int idAgencia,
                                                        int idAgenciaDestino, int idAdeudo, int idCentroCosto,
                                                        int idCuenta, int idKardexOrigen, bool lModificaSaldoLinea,
                                                        int idReciboProvisional = 0)
        {
            return objEjeSp.EjecSP("CAJ_GuardarReciboRelBonoDesc_SP", idTipoRecibo, idConceptoRecibo, idColaborador, idCliente,
                                                                            idMoneda, nMontoRecibo, nMontoItf, nMontoTotal,
                                                                            cSustento, dFechaRegistro, idOperador, idAgencia,
                                                                            idAgenciaDestino, idAdeudo, idCentroCosto, idCuenta, idKardexOrigen,
                                                                            idReciboProvisional, lModificaSaldoLinea);
        }
        #endregion
    }
}
