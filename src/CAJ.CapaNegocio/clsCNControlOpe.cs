using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAJ.AccesoDatos;
using System.Data;
using System.Data.Linq.SqlClient;

namespace CAJ.CapaNegocio
{
    public class clsCNControlOpe
    {

        clsADControlOpe objSaldos = new clsADControlOpe();
        //=============================================================
        // Crear metodo para recibir datos en un datatable
        //=============================================================
        public DataTable ListarSaldos(DateTime dFecSis, int nidUsuario, int idAge, int idTipResCaj)
        {
            return objSaldos.SaldoIniOpe(dFecSis, nidUsuario, idAge, idTipResCaj);
        }

        //=============================================================
        // Crear metodo para recibir datos en un datatable
        //=============================================================
        public int GrabarIniOpe(DateTime dFecSis, int nidUsuario, Decimal nMonSoles, Decimal nmonDolares, int cCodAge, int idTipResCaj)
        {
            int cRpta = 0;

            DataTable dtResp = objSaldos.GuardaIniOpe(dFecSis, nidUsuario, nMonSoles, nmonDolares, cCodAge, idTipResCaj);
            if (dtResp.Rows.Count > 0)
            {
                cRpta = Convert.ToInt32(dtResp.Rows[0]["nResp"].ToString());
            }


            return cRpta;
        }
        //=============================================================
        // inicio de operaciones con dos responsabilidades.
        //=============================================================
        public string GrabarIniOpeCajBov(DateTime dFecSis, int nidUsuario, Decimal nMonSoles, Decimal nmonDolares, Decimal nMonSolesBov, Decimal nmonDolaresBov, int cCodAge, int idTipResCaj, int idTipResCaj2)
        {
            string cRpta;
            try
            {
                objSaldos.GuardaIniOpeCajBov(dFecSis, nidUsuario, nMonSoles, nmonDolares, nMonSolesBov, nmonDolaresBov, cCodAge, idTipResCaj, idTipResCaj2);
                cRpta = "OK";
            }
            catch (Exception e)
            {
                cRpta = e.Message;
            }
            return cRpta;
        }
        //=============================================================
        // Crear Metodo para Validar Inicio de Operaciones
        //=============================================================
        public string ValidaIniOpe(DateTime dFecSis, int nidUsuario, int cCodAge)
        {
            string cEstCie;
            try
            {
                DataTable tbValOpe = objSaldos.ValIniOpe(dFecSis, nidUsuario, cCodAge);
                cEstCie = tbValOpe.Rows[0]["cEstadoCie"].ToString();
                // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            }
            catch (Exception e)
            {
                cEstCie = e.Message;
            }
            return cEstCie;
        }
        //=============================================================
        // Crear Metodo para Validar Inicio de Operaciones
        //=============================================================
        public string ValidaIniOpeCaja(DateTime dFecSis, int nidUsuario, int cCodAge, int idTipResCaj)
        {
            string cEstCie;
            try
            {
                DataTable tbValOpe = objSaldos.ValIniOpeCaja(dFecSis, nidUsuario, cCodAge, idTipResCaj);
                cEstCie = tbValOpe.Rows[0]["cEstadoCie"].ToString();
                // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            }
            catch (Exception e)
            {
                cEstCie = e.Message;
            }
            return cEstCie;
        }

        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable ListarTipRec()
        {
            return objSaldos.LisTipRec();
        }
        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable LisTipRecRango(string cIdTipoRecibo)
        {
            return objSaldos.LisTipRecRango(cIdTipoRecibo);
        }
        
        //=============================================================
        //--Existencia y Utilización Recibo
        //=============================================================
        public DataTable CNDevuelveExistenciayUtilRecibo(int idRecibo)
        {
            return objSaldos.ADDevuelveExistenciayUtilRecibo(idRecibo);
        }
        //=============================================================
        //--Monto Duplicado Voucher
        //=============================================================
        public DataTable CNDevuelveDuplicadoVoucher()
        {
            return objSaldos.ADDevuelveDuplicadoVoucher();
        }
        //=============================================================
        //--Lista Concepto de Recibos
        //=============================================================
        public DataTable ListaConceptos(int nTipRec, string descripcion)
        {
            return objSaldos.LisConcep(nTipRec, descripcion);
        }
        
        //=============================================================
        //--Lista Concepto de Recibos MAnt Rango Ejecutivo
        //=============================================================
        public DataTable LisConcepEjCorp(int nTipRec, string descripcion, string cIdConcepto)
        {
            return objSaldos.LisConcepEjCorp(nTipRec, descripcion, cIdConcepto);
        }

        //=============================================================
        //--Lista Proyectos
        //=============================================================
        public DataTable ListaProyectos(string descripcion)
        {
            return objSaldos.LisProyectos(descripcion);
        }

        //=============================================================
        //--Registro de Recibos
        //=============================================================
        public DataTable GuardarRecibo(int idTipRec, int idConc, int idCol, int idCli, int idMon, Decimal nMonRec, Decimal nMonItf, Decimal nTotRec, string cSust, DateTime dFecReg, int idOpe,
                                        int idAge, int idAgeDest, int idAdeudo, ref string msg, int IdCentroCosto, bool lModificaSaldoLinea, int idReciboProvicional = 0, int nmeses = 0)
        {
            return objSaldos.GuardaRec(idTipRec, idConc, idCol, idCli, idMon, nMonRec, nMonItf, nTotRec, cSust, dFecReg, idOpe, idAge, idAgeDest,
                                        idAdeudo, IdCentroCosto, lModificaSaldoLinea, idReciboProvicional, nmeses);
        }

        //=============================================================
        //--Actualizar Recibo
        //=============================================================
        public DataTable ActualizarRecibo(int idRecibo, int idConcepto, string cMotivo,int idusuario,int idAgencia,DateTime dFecSystem)
        {
            return objSaldos.ActualizarRecibo(idRecibo, idConcepto, cMotivo, idusuario, idAgencia, dFecSystem);
        }

        //=============================================================
        //--Extornar  Recibos
        //=============================================================
        public string ExtornarRecibo(int nNroRec, ref string msg)
        {
            try
            {
                objSaldos.ExtorRec(nNroRec);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        //--Buscar  Recibos
        //=============================================================
        public DataTable BuscarRecibo(int nNroRec, ref string msg)
        {
            try
            {
                DataTable tbRec = objSaldos.BurcarRec(nNroRec);
                msg = "OK";
                return tbRec;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Buscar habilitación
        //=============================================================
        public DataTable CNBuscaHab(int idKardex)
        {
            return objSaldos.ADBuscaHab(idKardex);
        }

        //=============================================================
        //--Listar Tipo de habilitaciones
        //=============================================================
        public DataTable LisTipHab(int nidPerfil, int idAgencia, int idUsuario, ref string msg, int idTipResponsable)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListaTipHab(nidPerfil, idAgencia, idUsuario, idTipResponsable);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }


        //=============================================================
        //--Listar Responsables de habilitaciones
        //=============================================================
        public DataTable LisRespHab(int idCargo, int idAge, string cTipRes, int idUsuario, ref string msg, DateTime dFecSistema)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListaRespHab(idCargo, idAge, cTipRes, idUsuario, dFecSistema);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Retorna Responsable de Boveda anterior
        //=============================================================
        //public string RetRespBoveda(int idUsu, int idAge)
        //{
        //    DataTable dtResBov = objSaldos.ValRespBoveda(idUsu, idAge);

        //    return dtResBov.Rows[0]["idUsuario"].ToString();
        //}

        //=============================================================
        //--Retorna Responsable de Boveda nuevo
        //=============================================================
        public DataTable RetRespBoveda(int idUsu, int idAge, int idTipoRes, DateTime dFecProces)
        {
            DataTable dtResBov = objSaldos.ValRespBoveda(idUsu, idAge, idTipoRes, dFecProces);
            return dtResBov;
        }

        //=============================================================
        //--Guardar Habilitaciones
        //=============================================================
        public string GuardarHabilitacion(DateTime dFecOpe, int idAge, int idTipHab, int idMon,
                                            Decimal nMonHab, string cSust, int idUsuOri, int idUsuDest, ref string msg, int idIngEgr, int idTipResCaja, string xmlBillete, string xmlMoneda, bool lReqBilletaje)
        {
            try
            {
                DataTable tbRetHab = objSaldos.GuardaHab(dFecOpe, idAge, idTipHab, idMon, nMonHab, cSust, idUsuOri, idUsuDest, idIngEgr, idTipResCaja, xmlBillete, xmlMoneda, lReqBilletaje);
                msg = "OK";
                return tbRetHab.Rows[0]["idHabilita"].ToString();
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Guardar Habilitaciones
        //=============================================================
        public DataTable ListarHabPen(DateTime dFecOpe, int idAge, int idUsu, int nOpc, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListarHabPen(dFecOpe, idAge, idUsu, nOpc);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Confirmar Habilitaciones
        //=============================================================
        public DataTable ConfirmarHab(int idHab, DateTime dFecOpe, int idUsuOri, int idUsuDes, int nIdAgencia, int TipMon, decimal nMonTot, int idTipResCajOri, int idTipResCajDes)
        {
            try
            {
                return objSaldos.ConfirmaHab(idHab, dFecOpe, idUsuOri, idUsuDes, nIdAgencia, TipMon, nMonTot, idTipResCajOri, idTipResCajDes);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //=============================================================
        //--Rechazar Habilitaciones
        //=============================================================
        public String RechazarHab(int idHab, string cMotRechazo)
        {
            string msg;

            try
            {
                objSaldos.RechazarHab(idHab, cMotRechazo);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        //--Listar Billetes Monedas
        //=============================================================
        public DataTable ListarBillMon(int idMon, int idBillMon, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListarBillMon(idMon, idBillMon);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Registrar Corte Fraccionario
        //=============================================================
        public string registroCorFrac(int idusu, DateTime dFecReg, int idAge, string XmlMonSol, string XmlBillSol, string XmlBillDol, int idTipResCaja)
        {
            string msg;
            try
            {
                objSaldos.RegCorFrac(idusu, dFecReg, idAge, XmlMonSol, XmlBillSol, XmlBillDol, idTipResCaja);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        //--Cuadre de Operaciones
        //=============================================================
        public DataTable CuadreOperaciones(DateTime dFecReg, int idUsu, int idMon, int idAge, int idTipIE, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.CuadreOpe(dFecReg, idUsu, idMon, idAge, idTipIE);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

            //return objSaldos.CuadreOpe(dFecReg, idUsu, idMon, idAge, idTipIE);
        }

        //=============================================================
        //--Saldo Inicial por Operadora
        //=============================================================
        public DataTable SaldoinicialOpe(DateTime dFecReg, int idUsu, int idAge, int ntipmov, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.SalIniOpe(dFecReg, idUsu, idAge, ntipmov);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
            //return objSaldos.SalIniOpe(dFecReg, idUsu, idAge, ntipmov);
        }

        //=============================================================
        //--Guardar Habilitaciones a Boveda Mediante Transferencia 
        //=============================================================
        public string TrasferirHabilitacionBoveda(DateTime dFecOpe, int idAge, int idMon,
                                            Decimal nMonHab, int idUsuOri, ref string msg)
        {
            DataTable tbRetHab = objSaldos.TrasferirHabilitacionBoveda(dFecOpe, idAge, idMon, nMonHab, idUsuOri); ;
            try
            {
                msg = "OK";
                return tbRetHab.Rows[0]["idHabilita"].ToString();
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Registrar Cierre de Operaciones
        //=============================================================
        public string RegCierreOperaciones(DateTime dFecReg, int idusu, int idAge, int idTipOpeCaj, Decimal nSalIniSol, Decimal nSalIniDol,
                            Decimal nSalFinSol, Decimal nSalFinDol, string xmlIngSol, string XmlEgrSol, string XmlIngDol, string XmlEgrDol)
        {
            string msg;
            try
            {
                objSaldos.RegCieOpe(dFecReg, idusu, idAge, idTipOpeCaj, nSalIniSol, nSalIniDol,
                                 nSalFinSol, nSalFinDol, xmlIngSol, XmlEgrSol, XmlIngDol, XmlEgrDol);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        // Crear Metodo para Validar Inicio de Operaciones
        //=============================================================
        public string ValidaCorteFracc(DateTime dFecSis, int nidUsuario, int cCodAge, ref string msg)
        {
            string cEstCie;
            DataTable tbValCorFra = objSaldos.ValCorteFrac(dFecSis, nidUsuario, cCodAge);
            cEstCie = tbValCorFra.Rows[0]["cEstCorFra"].ToString();
            try
            {
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return cEstCie;
        }
        //===========================================================================
        // Crear Metodo para Validar Inicio de Operaciones para modulo de caja
        //===========================================================================
        public string ValidaCorteFraccCaja(DateTime dFecSis, int nidUsuario, int cCodAge, /*ref string msg,*/int idTipResCaj)
        {
            string cEstCie;
            DataTable tbValCorFra = objSaldos.ValCorteFracCaj(dFecSis, nidUsuario, cCodAge, idTipResCaj);
            cEstCie = tbValCorFra.Rows[0]["cEstCorFra"].ToString();
            //try
            //{
            //    msg = "OK";
            //}
            //catch (Exception e)
            //{
            //    msg = e.Message;
            //}
            return cEstCie;
        }

        //======================================================================================
        // Crear Metodo para Validar si ya Realizó la carga de voucher Prepago y adelanto cuota
        //======================================================================================
        public string ValidarCargaVoucher(DateTime dFecSis, int nidUsuario)
        {
            string cEstCarVou;
            DataTable tbEstCarVou = objSaldos.ValidarCargaVoucher(dFecSis, nidUsuario);
            cEstCarVou = tbEstCarVou.Rows[0]["cEstCarVou"].ToString();
            return cEstCarVou;
        }


        //=============================================================
        //--Lista Detalle de Conceptos de Recibos
        //=============================================================
        public DataTable ListarSubItemCon(int nCodItem)
        {
            return objSaldos.ListaSubItem(nCodItem);
        }

        //=============================================================
        //--retorna el Corte Fraccionario
        //=============================================================
        public DataTable ListarCorteFrac(DateTime dFecCor, int idUsu, int idAge, int idMon, int idMonBill, int idTipResCaja, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListarCorteFrac(dFecCor, idUsu, idAge, idMon, idMonBill, idTipResCaja);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
        //=============================================================
        //--retorna el Corte Fraccionario
        //=============================================================
        public DataTable ListarBilletajeXHab(DateTime dFecCor, int idMon, int idMonBill, int idHab, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListarBilletajeXHab(dFecCor, idMon, idMonBill, idHab);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
        //=============================================================
        // Retorna Monto Total del Corte Fraccionario
        //=============================================================
        public string RetMontoCorFracc(DateTime dFecSis, int nidUsuario, int cCodAge, ref Decimal nMonCorSoles, ref Decimal nMonCorDolar, int idTipResCaj)
        {
            string msg;
            try
            {
                DataTable tbMonCorFra = objSaldos.RetMontoCorteFrac(dFecSis, nidUsuario, cCodAge, idTipResCaj);
                if (tbMonCorFra.Rows.Count > 0)
                {
                    nMonCorSoles = Convert.ToDecimal (tbMonCorFra.Rows[0]["nTotal"].ToString());
                    nMonCorDolar = Convert.ToDecimal (tbMonCorFra.Rows[1]["nTotal"].ToString());
                }
                else
                {
                    nMonCorSoles = 0.00m;
                    nMonCorDolar = 0.00m;
                }
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        //--Listado de Agencias
        //=============================================================
        public DataTable ListarAgencias()
        {

            var dt = objSaldos.ListarAgeXml();

            DataTable dtAgencias = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lEstado"] == true
             select item).CopyToDataTable(dtAgencias, LoadOption.OverwriteChanges);

            return dtAgencias;
        }
        //=============================================================
        //--Listado de Agencias que son apliclables a GIRO
        //=============================================================
        public DataTable ListarAgenciasAptasAgiro()
        {

            var dt = objSaldos.ListarAgeXml();

            DataTable dtAgencias = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lEstado"] == true
                && (bool)item["lAplicaGiros"] == true
             select item).CopyToDataTable(dtAgencias, LoadOption.OverwriteChanges);

            return dtAgencias;
        }
        //=============================================================
        //--Listado de Colaboradore Agencias
        //=============================================================
        public DataTable ListarColabAgencias(int idAge)
        {
            return objSaldos.ListarColAge(idAge);
        }

        //=============================================================
        //--Listado de Colaboradore Agencias
        //=============================================================
        public DataTable ListarAsesoresAgencias(int idAge)
        {
            return objSaldos.ListarAseAge(idAge);
        }

        //=============================================================
        //--Registrar Cierre de Operaciones
        //=============================================================
        public string RegApeCajaCerrada(DateTime dFecOpe, int idUsuAut, int idAgeAut, int idColRes, int idAgeColRes, string cSust, int nOpc, int idTepResCaj)
        {
            string msg;
            try
            {
                objSaldos.RegCajaCerrada(dFecOpe, idUsuAut, idAgeAut, idColRes, idAgeColRes, cSust, nOpc, idTepResCaj);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        //=============================================================
        // Retorna Validacion para Modificar Corte Fraccionario
        //=============================================================
        public string ValAutCorteFracc(DateTime dFecCor, int idUsu, int idAge, int nOpc, ref string msg, int idTipResCaj)
        {
            DataTable tbValCorte = objSaldos.ValidaAutCorte(dFecCor, idUsu, idAge, nOpc, idTipResCaj);
            string cRpta = tbValCorte.Rows[0]["cEstadoAut"].ToString();
            try
            {
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return cRpta;
        }

        //=============================================================
        // Retorna Validacion para Modificar Corte Fraccionario
        //=============================================================
        public string ValidaHabPendientes(DateTime dFecCor, int idUsu, int idAge, int nOpc, int idTipoHab)
        {
            DataTable tbHabPen = objSaldos.ValidaHabPen(dFecCor, idUsu, idAge, nOpc, idTipoHab);
            return tbHabPen.Rows[0]["nNumHab"].ToString();
        }

        //=============================================================
        // Retorna Validacion para Modificar Corte Fraccionario
        //=============================================================
        public string ValidacargoPer(int idUsu)
        {
            DataTable tbHabPen = objSaldos.ValidaCargoPer(idUsu);
            return tbHabPen.Rows[0]["nRpta"].ToString();
        }

        //=============================================================
        //--Listado de Colaboradore Agencias
        //=============================================================
        public DataTable ListarColPorAgencias(int idAge)
        {
            return objSaldos.ListarColPorAge(idAge);
        }

        //=============================================================
        //--Listado responsable de Boveda por Agencias
        //=============================================================
        public DataTable ListarResBovAge(int idAge, DateTime dFecOpe)
        {
            return objSaldos.ListaResBovAge(idAge, dFecOpe);
        }

        //=============================================================
        //--Guardar Responsable de Boveda
        //=============================================================
        public string GuardarResBovAge(int idUsu, int idAge, int idAgeReg, int idUsuarioReg, DateTime dFecIni, int idTipoResp, bool lTiempoIndeter, DateTime? dfecFin)
        {
            string msg;
            try
            {
                DataTable dtResBov = objSaldos.GuardaRespBoveda(idUsu, idAge, idAgeReg, idUsuarioReg, dFecIni, idTipoResp, lTiempoIndeter, dfecFin);
                if (dtResBov.Rows[0]["nResp"].ToString().Equals("1"))
                {
                    msg = "OK";
                }
                else
                {
                    msg = dtResBov.Rows[0]["mResp"].ToString();
                }

            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        //=============================================================
        //--Editar Responsable de Boveda
        //=============================================================
        public string EditarResBovAge(int idRespBoveda, int idUsuMod, DateTime dFecMod, DateTime? dFecFin, int idAgeMod, bool lTiempoIndeter, bool lIndBaja)
        {
            string msg;
            try
            {
                DataTable dtResBov = objSaldos.EditarRespBoveda(idRespBoveda, idUsuMod, dFecMod, dFecFin, idAgeMod, lTiempoIndeter, lIndBaja);
                if (dtResBov.Rows[0]["nResp"].ToString().Equals("1"))
                {
                    msg = "OK";
                }
                else
                {
                    msg = dtResBov.Rows[0]["mResp"].ToString();
                }

            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        //=============================================================
        //--Cuadre de Operaciones
        //=============================================================
        public DataTable ConsultaCuadreOpe(DateTime dFecReg, int idUsu, int idMon, int idAge, int idTipIE, int nOpc, ref string msg, int idTipResCaj)
        {
            try
            {
                msg = "OK";
                return objSaldos.ConsultaCuadreOpe(dFecReg, idUsu, idMon, idAge, idTipIE, nOpc, idTipResCaj);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Validar Cierre Operaciones
        //=============================================================
        public DataTable ValidarCierreOpe(DateTime dFecOpe, int idAge, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.VerificaCierreOpe(dFecOpe, idAge);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        //--Validar Cierre Operaciones
        //=============================================================
        public DataTable VerificarEstadoCierre(DateTime dFecPro, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.VerificaEstadoCie(dFecPro);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        //=============================================================
        // Retorna Responsable de Boveda
        //=============================================================
        public int RetornaResBoveda(int idAge)
        {

            DataTable tbHabPen = objSaldos.RetResBov(idAge);
            return Convert.ToInt32(tbHabPen.Rows[0]["nResBoveda"].ToString());
        }

        //=============================================================
        //--Listado saldos institucional
        //=============================================================
        public DataTable ListadosaldosInstit(DateTime dFecPro, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListSaldoInst(dFecPro);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }
        //=============================================================
        // Retorna Nivel de Atorización
        //=============================================================
        public int RetNivelAutorizacion(int idOpc, int idPerfil)
        {

            DataTable tbNivAut = objSaldos.RetNivAuto(idOpc, idPerfil);
            return Convert.ToInt32(tbNivAut.Rows[0]["idOpcion"].ToString());
        }

        //=============================================================
        // Retorna Parametro de Configuración
        //=============================================================
        public int RetParamConfiguracion(int idParam)
        {

            DataTable tbParamAut = objSaldos.RetParConf(idParam);
            return Convert.ToInt32(tbParamAut.Rows[0]["nValParam"].ToString());
        }

        //=============================================================
        //--Lista Concepto de Recibos Por Perfiles
        //=============================================================
        public DataTable ListaConceptosPer(int nTipRec, int IdPerfil)
        {
            return objSaldos.LisConcepPer(nTipRec, IdPerfil);
        }

        //=============================================================
        //--Retorna el monto max por concepto
        //=============================================================
        public DataTable LisMonConcep(int idAgencia, int idConcepto)
        {
            return objSaldos.LisMonConcep(idAgencia, idConcepto);
        }

        //=============================================================
        //--Retorna conceptos adeudados
        //=============================================================
        public DataTable CNConceptoAdeuda()
        {
            return objSaldos.ADConceptoAdeuda();
        }

        //=============================================================
        //--Consulta adeudados
        //=============================================================
        public DataTable CNConsultaAdeudado(int idAdeudo, string idEntidad, string idMoneda,
            string idEstado, string cDescripcionLinea)
        {
            return objSaldos.ADConsultaAdeudado(idAdeudo, idEntidad, idMoneda,
            idEstado, cDescripcionLinea);
        }

        //=============================================================
        //--Inserta o Actualiza Adeudado
        //=============================================================
        public DataTable CNInsUpAdeudado(string cxmlAdeudo, string cxmlDesembolsoAdeudo, string XmlTipoProd, string XmldsDestinoAde, string XmlPlanPagoAdeudado, int idAge, DateTime dFecha, int idUsu)
        {
            return objSaldos.ADInsUpAdeudado(cxmlAdeudo, cxmlDesembolsoAdeudo, XmlTipoProd, XmldsDestinoAde, XmlPlanPagoAdeudado, idAge, dFecha, idUsu);
        }

        //=============================================================
        //--Quitar pagare de Adeudado
        //=============================================================
        public DataTable CNQuitarPagareAdeudado(int idAdeudado,int idDesembolso,decimal nMontoPagare, int idAge, DateTime dFecha, int idUsu)
        {
            return objSaldos.ADQuitarPagareAdeudado(idAdeudado, idDesembolso, nMontoPagare,idAge, dFecha, idUsu);
        }
        //=============================================================
        //--Pago de Adeudados
        //=============================================================
        public DataTable CNPagoAdeudado(int idAdeuda, decimal nMonto, int idSubItem)
        {
            return objSaldos.ADPagoAdeudado(idAdeuda, nMonto, idSubItem);
        }
        //=============================================================
        //--Movimiento Caja Pulmon -Boveda
        //=============================================================
        public DataTable MovCajaPulmonBoveda(DateTime dFecPro, int idUsu, int idMon, int idAge, int idTipIE, int nOpc, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.MovCajaPulmonBoveda(dFecPro, idUsu, idMon, idAge, idTipIE, nOpc);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }

        }

        ////=============================================================
        ////--Registrar Movimiento Caja Pulmon o Boveda
        ////=============================================================
        //public string registroMovCajaBoveda(int idtipoMov, int idusu, DateTime dFecReg, int idAge, string xmlIngSol, string xmlEgrSol, string xmlIngDol, string xmlEgrDol, Decimal nSalIniSol, Decimal nSalFinSol, Decimal nSalIniDol, Decimal nSalFinDol)
        //{
        //    string msg;
        //    try
        //    {
        //        objSaldos.registroMovCajaBoveda(idtipoMov, idusu, dFecReg, idAge, xmlIngSol, xmlEgrSol, xmlIngDol, xmlEgrDol, nSalIniSol, nSalFinSol, nSalIniDol, nSalFinDol);
        //        msg = "OK";
        //    }
        //    catch (Exception e)
        //    {
        //        msg = e.Message;
        //    }
        //    return msg;
        //}
        //=============================================================
        //--Elimina el Movimiento Caja Pulmon o Boveda
        //=============================================================
        public string EliminarMovCajaBoveda(int idtipoMov, int idusu, DateTime dFecReg, int idAge)
        {
            string msg;
            try
            {
                objSaldos.EliminarMovCajaBoveda(idtipoMov, idusu, dFecReg, idAge);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        //=============================================================
        //--lista de limites de cobertura
        //=============================================================
        public DataTable listarLimitesCobertura(int IdTipoResponsableCaja, int idAgecias, int idMoneda)
        {
            return objSaldos.listarLimitesCobertura(IdTipoResponsableCaja, idAgecias, idMoneda);
        }
        //=============================================================
        //--Registrar limite de cobertura
        //=============================================================
        public string RegLimiteCobertura(int idusu, int idAge, int idTipResCaj, DateTime dFecIni, decimal nMonLimiteSol, string cSustento, decimal nXLimMenorSol, decimal nXLimInterSol, decimal nXLimMayorSol, decimal nMonLimiteDol, decimal nXLimMenorDol, decimal nXLimInterDol, decimal nXLimMayorDol, int idControlTipoMoneda)
        {
            string msg;
            try
            {
                objSaldos.RegLimiteCobertura(idusu, idAge, idTipResCaj, dFecIni, nMonLimiteSol, cSustento, nXLimMenorSol, nXLimInterSol, nXLimMayorSol, nMonLimiteDol, nXLimMenorDol, nXLimInterDol, nXLimMayorDol, idControlTipoMoneda);
                msg = "OK";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        //=============================================================
        //--lista Tipo de Deuda
        //=============================================================
        public DataTable listarTipoDeuda(int IdPadre)
        {
            return objSaldos.listarTipoDeuda(IdPadre);
        }
        //=============================================================
        //--lista Estado de Adeudado
        //=============================================================
        public DataTable listarEstadoAdeudado()
        {
            return objSaldos.listarEstadoAdeudado();
        }
        //=============================================================
        //--lista forma desembolso adeudado
        //=============================================================
        public DataTable ListarTipoDesembolso(int npadre)
        {
            return objSaldos.ListarTipoDesembolso(npadre);
        }
        //=============================================================
        //--lista destino de adeudado
        //=============================================================
        public DataTable ListarDestinoAdeudado(int idAdeudado)
        {
            return objSaldos.ListarDestinoAdeudado(idAdeudado);
        }
        //=============================================================
        //--lista año base de adeudado
        //=============================================================
        public DataTable ListarAñoBase()
        {
            return objSaldos.ListarAñoBase();
        }
        //=============================================================
        //--lista Mes base de adeudado
        //=============================================================
        public DataTable ListarMesBase()
        {
            return objSaldos.ListarMesBase();
        }
        //=============================================================
        //--lista Desembolso adeudado
        //=============================================================
        public DataTable ListarDesembolsoAdeudado(int idAdeudado)
        {
            return objSaldos.ListarDesembolsoAdeudado(idAdeudado);
        }
        //=============================================================
        //--Retorna Tipos Entidades Financieras
        //=============================================================
        public DataTable CNTipoEntidadFinanciera(string cindicadorFondeo)
        {
            return objSaldos.ADTipoEntidadFinanciera(cindicadorFondeo);
        }
        //=============================================================
        //--Retorna Entidades Financieras por tipo
        //=============================================================
        public DataTable CNEntidadFinanciera(int idEntidad, string cindicadorFondeo)
        {
            //return objSaldos.ADEntidadFinanciera(idEntidad, cindicadorFondeo);
            var dt = objSaldos.ADEntidadFinancieraXml();

            DataTable dtEntidadFinanciera = dt.Clone();

            switch (cindicadorFondeo)
            {
                case "0": (from item in dt.AsEnumerable()
                           where
                              (int)item["idTipoEntidad"] == idEntidad
                              && (bool)item["lVigente"] == true
                              && (bool)item["lindicadorFondeo"] == false
                           orderby (string)item["cNombreCorto"]
                           select item).CopyToDataTable(dtEntidadFinanciera, LoadOption.OverwriteChanges);
                    break;


                case "1": (from item in dt.AsEnumerable()
                           where
                              (int)item["idTipoEntidad"] == idEntidad
                              && (bool)item["lVigente"] == true
                              && (bool)item["lindicadorFondeo"] == true
                           orderby (string)item["cNombreCorto"]
                           select item).CopyToDataTable(dtEntidadFinanciera, LoadOption.OverwriteChanges);
                    break;


                case "%": (from item in dt.AsEnumerable()
                           where
                              (int)item["idTipoEntidad"] == idEntidad
                              && (bool)item["lVigente"] == true
                           orderby (string)item["cNombreCorto"]
                           select item).CopyToDataTable(dtEntidadFinanciera, LoadOption.OverwriteChanges);
                    break;

                default: break;
            }

            //Para el uso de alias cNombre
            //Reemplazar la columna que ya existía
            for (int i = 0; i < dtEntidadFinanciera.Columns.Count; i++)
            {
                if (dtEntidadFinanciera.Columns[i].ColumnName.Equals("cNombre"))
                {
                    dtEntidadFinanciera.Columns[i].ColumnName = "cNombre1";
                    break;
                }
            }
            //Reemplazar la columna que se va utilizar
            for (int i = 0; i < dtEntidadFinanciera.Columns.Count; i++)
            {
                if (dtEntidadFinanciera.Columns[i].ColumnName.Equals("cNombreCorto"))
                {
                    dtEntidadFinanciera.Columns[i].ColumnName = "cNombre";
                    break;
                }
            }

            return dtEntidadFinanciera;
        }


        //=============================================================
        //--lista Desembolso adeudado
        //=============================================================
        public DataTable ListarDesembolsoAdeudado(int idAdeudado, string estado)
        {
            return objSaldos.ListarDesembolsoAdeudado(idAdeudado, estado);
        }
        //=============================================================
        //--lista Producto adeudados para creditos
        //=============================================================
        public DataTable ListarProductoAdeudado(int idAdeudado)
        {
            return objSaldos.ListarProductoAdeudado(idAdeudado);
        }
        //=============================================================
        //--lista las frecuancias de pagos de los adeudados
        //=============================================================
        public DataTable ListarFrecuenciaPagoAdeudado()
        {

            return objSaldos.ListarFrecuenciaPagoAdeudado();
        }
        //=============================================================
        //--lista tipo de tasa de los adeudados
        //=============================================================
        public DataTable listarTipoTasa()
        {

            return objSaldos.listarTipoTasa();
        }
        //=============================================================
        //--lista tipo de linea de los adeudados
        //=============================================================
        public DataTable listarLineaAdeudado(int idpadre)
        {

            return objSaldos.listarLineaAdeudado(idpadre);
        }
        //=============================================================
        //--lista Plan de pago de los adeudados
        //=============================================================
        public DataTable listarPlanPagoAdeudado(int idDesembolso, string cestadoCuota)
        {
            return objSaldos.listarPlanPagoAdeudado(idDesembolso, cestadoCuota);

        }
        //=============================================================
        //--lista las  formas de pago de pago de los adeudados

        //=============================================================
        public DataTable listarFormaPagoAdeudado()
        {

            return objSaldos.listarFormaPagoAdeudado();

        }
        //=============================================================
        //--lista el tipo de documento de pago de los adeudados
        //=============================================================
        public DataTable listarTipoDocumentoAdeudado()
        {

            return objSaldos.listarTipoDocumentoAdeudado();
        }
        //=============================================================
        //--guarda el pago de los adeudados
        //=============================================================
        public string GuardaPagoAdeudado(string xmlPagoAdeudado, int ncancelacion, ref string msg, int idAge, DateTime dFechaOpe, int idUsu)
        {
            string cRpta;
            try
            {
                DataTable dt = objSaldos.GuardaPagoAdeudado(xmlPagoAdeudado, ncancelacion, idAge, dFechaOpe, idUsu);
                cRpta = dt.Rows[0]["nNroCuota"].ToString();
            }
            catch (Exception e)
            {
                cRpta = e.Message;
            }
            return cRpta;
        }
        //=============================================================
        //--extorno de pago de adeudados
        //=============================================================
        public string ExtornarPagoAdeudado(int idAdeudado, int cDesembolso, int cNroCuota, ref string msg)
        {
            string cRpta;
            try
            {
                DataTable dt = objSaldos.ExtornarPagoAdeudado(idAdeudado, cDesembolso, cNroCuota);
                cRpta = dt.Rows[0]["nNroCuota"].ToString();
            }
            catch (Exception e)
            {
                cRpta = e.Message;
            }
            return cRpta;

        }
        //=============================================================
        //--Valida existencia de adeudados
        //=============================================================
        public int CNValidarExistenciaAdeudado(string nNroPagare, DataTable dtListaPagare, int indice)
        {
            //return objSaldos.ADValidarExistenciaAdeudado(nNroPagare, idEntidad);
            int cantidad = 0;
            int index = 0;
            foreach (DataRow Rows in dtListaPagare.Rows)
            {
                index = index + 1;
                if (Rows["cNroPagre"].ToString().Equals(nNroPagare) && index != indice)
                {
                    cantidad = cantidad + 1;
                }
            }
            return cantidad;
        }

        //=============================================================
        //--Valida si Existe Resp Boveda en la Agencia
        //=============================================================
        public int CNValidarExisRespBoveda(int idAgencia, DateTime dFechaOpe, ref string mRespuesta)
        {
            int nResp = 0;
            DataTable tbResBov = objSaldos.ADValidarExisRespBoveda(idAgencia, dFechaOpe);
            mRespuesta = tbResBov.Rows[0][1].ToString();
            nResp = Convert.ToInt32(tbResBov.Rows[0][0].ToString());
            return nResp;
        }

        //=============================================================
        //--Valida si Existe Resp Boveda en la Agencia
        //=============================================================
        public bool CNValidarCierreBoveda(int idAgencia, DateTime dFechaOpe)
        {
            DataTable tbResBov = objSaldos.ADValidarCierreBoveda(idAgencia, dFechaOpe);
            if (tbResBov.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //=============================================================
        //--Registra Extorno de Recibos
        //=============================================================
        public DataTable CNRegistraExtornoRecibos(int idKardex, int idRecibo, int idUsu, int idAge, DateTime dFechaOpe,
                                        Decimal nMonOpe, int idTipOpe, int idTippago,
                                         bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return objSaldos.RegExtornoRecibos(idKardex, idRecibo, idUsu, idAge, dFechaOpe,
                                        nMonOpe, idTipOpe, idTippago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        //=============================================================
        //--Valida Tipo de relacion
        //=============================================================
        public DataTable CNValidaTipoRelacion(int idUsu)
        {
            return objSaldos.ValidaTipoRelacion(idUsu);
        }
        //=============================================================
        //--Grabar Pago de Dieta
        //=============================================================
        public DataTable CNGrabarPagoDieta(int idRecibo, decimal nMontoDieta, decimal nMontoRta4ta, decimal nMontoPagado)
        {
            return objSaldos.GrabarPagoDieta(idRecibo, nMontoDieta, nMontoRta4ta, nMontoPagado);
        }
        //=============================================================
        //--Buscar Pago de Dieta
        //=============================================================
        public DataTable CNBuscarPagoDieta(int idRecibo, ref string msg)
        {
            try
            {
                DataTable tbRec = objSaldos.BurcarRecPagoDieta(idRecibo);
                msg = "OK";
                return tbRec;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
        //=============================================================
        //--Buscar Id Pago de Dieta
        //=============================================================
        public int CNBuscarIdPagoDieta()
        {
            return objSaldos.BurcarIdPagoDieta();
        }
        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable ListarTipoRecibos()
        {
            return objSaldos.LisTipoRecibos();
        }
        //=============================================================
        //--Listado de Tipos de Recibos
        //=============================================================
        public DataTable LisTipoRecibosGrupoEjecutivo(string cIdTipoRecibo)
        {
            return objSaldos.LisTipoRecibosGrupoEjecutivo(cIdTipoRecibo);
        }
        
        //=============================================================
        //--Buscar Id Pago de Dieta
        //=============================================================
        public DataTable CNBuscarIdPagoDieta(int IdPerfil)
        {
            return objSaldos.BurcarIdPagoDieta(IdPerfil);
        }
        //=============================================================
        //--Retorna resumen de creditos otorgados por  adeudado
        //=============================================================
        public DataTable CNResCreditosPorAdeudado(DateTime dfechaOpe)
        {
            return objSaldos.ADResumenCreditosPorAdeudado(dfechaOpe);
        }
        //=============================================================
        //--Valida Inicio de Operacion de Caja General
        //=============================================================
        public string CNValidaIniOpeCajGen(DateTime dfechaOpe, int idAgencia)
        {
            string cEstCie;
            try
            {
                DataTable tbValOpe = objSaldos.ADValidaIniOpeCajGen(dfechaOpe, idAgencia);
                cEstCie = tbValOpe.Rows[0]["cEstadoCie"].ToString();
            }
            catch (Exception e)
            {
                cEstCie = e.Message;
            }
            return cEstCie;
        }

        public DataTable ListarDetalleConRecidConcepto(int idConcepto, int idAgencia)
        {
            return objSaldos.ListarDetalleConRecidConcepto(idConcepto, idAgencia);
        }

        public DataTable InsertarDetalleConRec(int idConcepto, int idAgencia, decimal nMontoMin, decimal nMontoMax, int idUsuario)
        {
            return objSaldos.InsertarDetalleConRec(idConcepto, idAgencia, nMontoMin, nMontoMax, idUsuario);
        }

        public DataTable ActualizarDetalleConRec(int idConcepto, int idAgencia, decimal nMontoMin, decimal nMontoMax, int idUsuario)
        {
            return objSaldos.ActualizarDetalleConRec(idConcepto, idAgencia, nMontoMin, nMontoMax, idUsuario);
        }
        //============================================================================================================
        //--Obtiene el efectivo actual
        //============================================================================================================
        public decimal ObtieneEfectivoActual(int idAgencia, DateTime dfecha, int idUsuario, int idMoneda, int idTipResCaj)
        {
            DataTable dt = objSaldos.ObtieneEfectivoActual(idAgencia, dfecha, idUsuario, idMoneda, idTipResCaj);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["nSaldoOpe"].ToString());
            }
            return 0;
        }

        //=============================================================
        //--lista todos los tipos de habilitacion
        //=============================================================
        public DataTable listarTodosTiposHabilitacion(int idAgencia)
        {
            return objSaldos.listarTiposTiposHabilitaciones(idAgencia);
        }
        //=====================================================================================
        //--Listar relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable listaRelacionTipoHabilitacionXResponsable(int idAgencia)
        {
            return objSaldos.listaRelacionTipoHabilitacionXResponsable(idAgencia);
        }
        //=====================================================================================
        //--Registra relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable GrabarVincTipHabTipResponsable(int idAgencia, int idAgeReg, int idUsuarioReg, DateTime dFecReg,
           int idTipoRes, int idTipoHab, bool lNecBilletaje)
        {
            return objSaldos.GrabarVincTipHabTipResponsable(idAgencia, idAgeReg, idUsuarioReg, dFecReg,
            idTipoRes, idTipoHab, lNecBilletaje);
        }
        //=====================================================================================
        //--Editar relacion entre tipos de habilitacion y tipos de responsable de caja
        //=====================================================================================
        public DataTable EditarVincTipHabTipResponsable(int idVinTipHabxResp, int idAgeMod, int idUsuarioMod, DateTime dFecMod,
           bool lNecBilletaje, bool lVigente)
        {
            return objSaldos.EditarVincTipHabTipResponsable(idVinTipHabxResp, idAgeMod, idUsuarioMod, dFecMod, lNecBilletaje, lVigente);
        }
        //=====================================================================================
        //--Lista los tipos de responsable por usuario que inició operaciones
        //=====================================================================================
        public DataTable cargarTipRespPorUsuarioIniOpe(int idUsuario, int idAgencia, DateTime dFecOperacion)
        {
            return objSaldos.cargarTipRespPorUsuarioIniOpe(idUsuario, idAgencia, dFecOperacion);
        }
        //=====================================================================================
        //--Lista los tipos de responsable asignados por usuario 
        //=====================================================================================
        public DataTable cargarTipRespPorUsuarioAsg(int idUsuario, int idAgencia, DateTime dFecOperacion)
        {
            return objSaldos.cargarTipRespPorUsuarioAsg(idUsuario, idAgencia, dFecOperacion);
        }
        //=============================================================
        //--Buscar habilitación por habilitacion
        //=============================================================
        public DataTable CNBuscaBalancin(int idHabilitacion)
        {
            return objSaldos.ADBuscaBalancin(idHabilitacion);
        }
        //=============================================================
        //--Listar Billetaje de boveda 
        //=============================================================
        public DataTable ListarBillBov(int idAgencia, int idMoneda, int idTipBillMon, int idTipResCaj, DateTime dFecOpe, ref string msg)
        {
            try
            {
                msg = "OK";
                return objSaldos.ListarBillBoveda(idAgencia, idMoneda, idTipBillMon, idTipResCaj, dFecOpe);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
        //=============================================================
        //--Retorna saldo de operador por agencia y fecha.
        //=============================================================
        public DataTable RetornaSaldoOperadorAge(DateTime dFechaOpe, int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objSaldos.RetSaldoOperadorAge(dFechaOpe, idUsuario, idAgencia, idTipResCaj);
        }
        //=============================================================
        // Actualiza el Saldo
        //=============================================================
        public void ActualizarSaldo(int idAgencia, int idUsuario, DateTime dfechaOpe, int idTipoMoneda, int IdTipoTransac_I_E, decimal nMontoOperacion, int idTipResCaj)
        {
            try
            {
                objSaldos.ActualizarSaldo(idAgencia, idUsuario, dfechaOpe, idTipoMoneda, IdTipoTransac_I_E, nMontoOperacion, idTipResCaj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //===========================================================================
        // Crear Metodo para Validar Inicio de Operaciones para modulo de caja
        //===========================================================================
        public DataTable CNlistaBillbovedaInicio(int idAgencia)
        {
            DataTable tbValList = objSaldos.ADlistaBillbovedaInicio(idAgencia);
            return tbValList;
        }

        //=============================================================
        //--Listar Motivo de Operación
        //=============================================================
        public DataTable CNListaMotivoOperacion(int idTipOperacion, int idPerfil)
        {
            return objSaldos.ADListaMotivoOperacion(idTipOperacion, idPerfil);
        }

        //=======================================================================================
        //--Listado de Colaboradore por Agencias que iniciarion operaciones en un rango de fecha
        //=======================================================================================
        public DataTable CNListarColabAgenciasIniOpe(int idAge, DateTime dFecIni, DateTime dFecFin)
        {
            return objSaldos.ADListarColabAgenciasIniOpe(idAge, dFecIni, dFecFin);
        }
        //=======================================================================================
        //--valida el inicio de operaciones de boveda
        //=======================================================================================
        public string CNValidarIniOpeBov(DateTime dFecOpe, int idAgencia, int idTipResCaj)
        {
            DataTable dtIniOpe = objSaldos.ADValidarIniOpeBov(dFecOpe, idAgencia, idTipResCaj);
            string cEstCie = dtIniOpe.Rows[0]["cEstadoCie"].ToString();
            return cEstCie;

        }
        //=======================================================================================
        //--retorna una lista de saldos de caja para el cuadre  con contabilidad
        //=======================================================================================
        public DataTable CNListarCuadreLibroCajaCnt(DateTime dFecIni, DateTime dFecFin, int idAgencia, bool lConsolidado)
        {
            return objSaldos.ADListarCuadreLibroCajaCnt(dFecIni, dFecFin, idAgencia, lConsolidado);
        }
        //=============================================================
        //--lista las fechas de operacion del usuario
        //=============================================================
        public DataTable CNListaFechasOperacionXUsuario(int idUsuario, int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objSaldos.ADListaFechasOperacionXUsuario(idUsuario, idAgencia, dFecIni, dFecFin);
        }

        //=============================================================
        //-- Obtiene saldos de inicio y cierre de un operador 
        //=============================================================
        public DataTable CNListarSaldoIniCieOpe(int idAgencia, DateTime dFecOpe, int idTipResCaj, int idUsuario)
        {
            return objSaldos.ADListarSaldoIniCieOpe(idAgencia, dFecOpe, idTipResCaj, idUsuario);
        }
        //=============================================================
        //-- lista el ultima operacion por usuario y tipo de responsable
        //=============================================================
        public DataTable CNListarUltOperacionUsuTipRes(int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objSaldos.ADListarUltOperacionUsuTipRes(idUsuario, idAgencia, idTipResCaj);
        }

        //=============================================================
        //--Registrar traslado de saldos de caja
        //=============================================================
        public DataTable CNInsertarTrasladoSaldoCaja(int idTipReasignacion, int idAgenciaOpe, int idUsuOri, int idTipResCajOri,
            DateTime dFecOperaOri, decimal nMonSalAntSolOri, decimal nMonSalAntDolOri, decimal nMonNueSalSolOri, decimal nMonNueSalDolOri,
    int idUsuDes, int idTipResCajDes, DateTime dFecOpeDes, decimal? nMonSalAntSolDes, decimal? nMonSalAntDolDes, decimal nMonNueSalSolDes,
    decimal nMonNueSalDolDes, DateTime dFecReasigna, int idUsuReasigna, int idAgeReasigna)
        {
            return objSaldos.ADInsertarTrasladoSaldoCaja(idTipReasignacion, idAgenciaOpe, idUsuOri, idTipResCajOri, dFecOperaOri,
                                                        nMonSalAntSolOri, nMonSalAntDolOri, nMonNueSalSolOri, nMonNueSalDolOri,
                                                        idUsuDes, idTipResCajDes, dFecOpeDes, nMonSalAntSolDes, nMonSalAntDolDes, nMonNueSalSolDes,
                                                        nMonNueSalDolDes, dFecReasigna, idUsuReasigna, idAgeReasigna);
        }
        //=============================================================
        //-- lista la reasignacion de caja por usuario
        //=============================================================
        public DataTable CNListarReasignacionCajUsu(int idUsuario, int idAgencia, int idTipResCaj)
        {
            return objSaldos.ADListarReasignacionCajUsu(idUsuario, idAgencia, idTipResCaj);
        }

        public DataTable CNRetornaIdIniOpeCaj(DateTime dFecSis, int nidUsuario, int ccodage, int idTipResCaj)
        {
            return objSaldos.ADRetornaIdIniOpeCaj(dFecSis, nidUsuario, ccodage, idTipResCaj);
        }
        //=============================================================
        //--Saldo de boveda para validar el inicio de operaciones.
        //=============================================================
        public DataTable CNValorBoveda( int idAgencia,int idUsuario)
        {
            return objSaldos.ADValorBoveda(idAgencia,idUsuario);
        }

        public DataTable ListaConceptosEspecificos(string cConceptos)
        {
            return objSaldos.ListaConceptosEspecificos(cConceptos);
        }

        //=============================================================
        //--Registro de Recibos
        //=============================================================
        public DataTable GuardarReciboDinElec(int idTipRec, int idConc, int idCli, int idNoCli, int idTipoDocumento, string cNroDocumento, string cNombres, string cCelular, int idMon, Decimal nMonRec,
                            Decimal nMonItf, Decimal nTotRec, string cSust, DateTime dFecReg, int idOpe, int idAge, int idAgeDest, bool lModificaSaldoLinea)
        {
            return objSaldos.GuardarReciboDinElec(idTipRec, idConc, idCli, idNoCli, idTipoDocumento, cNroDocumento, cNombres, cCelular, idMon, nMonRec, nMonItf, nTotRec, cSust, dFecReg, idOpe, idAge, idAgeDest, lModificaSaldoLinea);
        }

        public DataTable reporteDineroElect(DateTime dtInicio, DateTime dtFin)
        {
            return objSaldos.reporteDineroElect(dtInicio, dtFin);
        }

        //=============================================================
        //--Registro de Recibos relacionados a un kardex
        //=============================================================
        public DataTable GuardarReciboRelacionadoSeguro(int idTipoRecibo, int idConceptoRecibo, int idColaborador, int idCliente,
                                                            int idMoneda, decimal nMontoRecibo, decimal nMontoItf, decimal nMontoTotal,
                                                            string cSustento, DateTime dFechaRegistro, int idOperador, int idAgencia,
                                                            int idAgenciaDestino, int idAdeudo, ref string cMensaje, int idCentroCosto,
                                                            int idCreditoSeguro, bool lModificaSaldoLinea, int idReciboProvisional = 0, int idTipoPlan = 0, int nmeses = 0)
        {
            return objSaldos.GuardarReciboRelacionadoSeguro(idTipoRecibo, idConceptoRecibo, idColaborador, idCliente,
                                                            idMoneda, nMontoRecibo, nMontoItf, nMontoTotal,
                                                            cSustento, dFechaRegistro, idOperador, idAgencia,
                                                            idAgenciaDestino, idAdeudo, idCentroCosto, idCreditoSeguro,
                                                            lModificaSaldoLinea, idReciboProvisional, idTipoPlan, nmeses);
        }

        //===============================================================
        //--Registro de Operaciones WesternUnion volcados de excel
        //===============================================================
        public DataTable GuardarOperacionesWesternUnion(String xmlOpWesternUnion, int idUsu, int idAgencia, int idPerfil, DateTime dFechaSistema)
        {
            return objSaldos.GuardarOperacionesWesternUnion(xmlOpWesternUnion, idUsu, idAgencia, idPerfil, dFechaSistema);
        }

        // Recuperar volcado de excel registrado
        public DataSet ListarOperacionConciliacionWesternUnion(int idColaborador, int idAgencia, String dFecha, int idTipoRec)
        {
            return objSaldos.ListarOperacionConciliacionWesternUnion(idColaborador, idAgencia, dFecha, idTipoRec);
        }

        //Realizar conciliación
        public DataTable GuardarConcilicionWesternUnion(String xmlConciliacion, DateTime dFechaReg)
        {
            return objSaldos.GuardarConcilicionWesternUnion(xmlConciliacion, dFechaReg);
        }

        public DataTable ResumenConciliacionWesternUnion(int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objSaldos.ResumenConciliacionWesternUnion(idAgencia, dFechaIni, dFechaFin);
        }

        public DataTable ListarUsuariosEjecutivoServicioConciliacionWestern(DateTime dFecha, bool dFechaSistema, int nIdAgencia)
        {
            return objSaldos.ListarUsuariosEjecutivoServicioConciliacionWestern(dFecha, dFechaSistema, nIdAgencia);
        }

        public DataTable obtenerDatosUsuarioZona(int idUsu)
        {
            return objSaldos.obtenerDatosUsuarioZona(idUsu);
        }

        #region Recibos de Emision Bonos

        //=============================================================
        //--Registro de Recibos relacionados a un kardex
        //=============================================================
        public DataTable CNGuardarReciboRelBono(int idTipoRecibo, int idConceptoRecibo, int idColaborador, int idCliente,
                                                            int idMoneda, decimal nMontoRecibo, decimal nMontoItf, decimal nMontoTotal,
                                                            string cSustento, DateTime dFechaRegistro, int idOperador, int idAgencia,
                                                            int idAgenciaDestino, int idAdeudo, ref string cMensaje, int idCentroCosto,
                                                            int idCuenta, int idKardexOrigen,
                                                            bool lModificaSaldoLinea, int idReciboProvisional = 0)

        {
            return objSaldos.ADGuardarReciboRelBono(idTipoRecibo, idConceptoRecibo, idColaborador, idCliente,
                                                        idMoneda, nMontoRecibo, nMontoItf, nMontoTotal,
                                                        cSustento, dFechaRegistro, idOperador, idAgencia,
                                                        idAgenciaDestino, idAdeudo, idCentroCosto, idCuenta, idKardexOrigen,
                                                        lModificaSaldoLinea, idReciboProvisional);
        }
        #endregion

    }
}
