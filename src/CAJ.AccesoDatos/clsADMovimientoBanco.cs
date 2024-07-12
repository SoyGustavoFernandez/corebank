using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;

namespace CAJ.AccesoDatos
{
    public class clsADMovimientoBanco
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        //=============================================================
        // listar estados de las cuentas en instituciones financieras
        //=============================================================
        public DataTable listarEstadoCuenta()
        {
            return objEjeSp.EjecSP("CAJ_LisEstadoCuentaBco_sp");
        }

        public DataTable listarEstadoCuentaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstCuentaInst");
        }



        //=============================================================
        //--Graba las cuentas de las intituciones
        //=============================================================

        public DataTable grabarCuentaInstitucion(int idCuentaInst, int idEntidad, int idAgencia, int idTipoCuentaInst,
                                                 String cNumeroCuenta, String cDescripcionCuenta, int idMoneda,
                                                DateTime dFechaApertura, decimal nTEA, int nFactorInteres,
                                                int nPlazo, String cCuentaContable, int idEstado, DateTime dFechaCancelacion)
        {
            return objEjeSp.EjecSP("CAJ_GrabarCuentaInst_sp", idCuentaInst, idEntidad, idAgencia, idTipoCuentaInst,
                                                cNumeroCuenta, cDescripcionCuenta, idMoneda,
                                                dFechaApertura, nTEA, nFactorInteres,
                                                nPlazo, cCuentaContable, idEstado, dFechaCancelacion);

        }
        //=============================================================
        //--busca las cuentas de las intituciones financieras
        //=============================================================

        public DataTable BuscarCuentas(string idAgencia, string idTipoEntidad, string idEntidad,
                                      string idTipoCuenta, string cNumeroCuenta)
        {
            return objEjeSp.EjecSP("CAJ_BuscarCuentaInst_sp", idAgencia, idTipoEntidad, idEntidad,
                                    idTipoCuenta, cNumeroCuenta);
        }
        //=============================================================
        //--Guarda Talonario de una institucion seleccionada
        //=============================================================

        public DataTable GuardarChequeBco(int idChequeBco, int idCuentaInst,
                                      int nNroInicial, int nCantCheques, int nNroFinal)
        {
            return objEjeSp.EjecSP("CAJ_GuardarChequeBco_sp", idChequeBco, idCuentaInst,
                                    nNroInicial, nCantCheques, nNroFinal);
        }
        //=============================================================
        //--Verifica la existencia y estado de un talonario
        //=============================================================

        public DataTable VerificarExisteTalonario(int idCuentaInst)
        {
            return objEjeSp.EjecSP("CAJ_VerificarExisteTalonario_sp", idCuentaInst);
        }
        //=============================================================
        //--Lista los cheques de un talonario activo
        //=============================================================

        public DataTable ListarCheques(int idCuentaInst, int idChequeBco, int idEstadoCheque)
        {
            return objEjeSp.EjecSP("CAJ_ListaChequesInst_sp",idCuentaInst, idChequeBco, idEstadoCheque);
        }
        //=============================================================
        //--Emite cheque de la institucion seleccionada
        //=============================================================

        public DataTable EmitirCheque(int idChequeBco, int nNroCheque, DateTime dFechaEmision, int idCliente,
                                      string cNroDocCli, string cApNomCli, string CDireccionCli, int idMotOperBco,
                                        string cDescMot, decimal nMonto, int idEstadoCheque, int idComprobantePago,
                                        int idUsuario, int idAgencia, int x_idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_EmitirCheque_sp", idChequeBco, nNroCheque, dFechaEmision, idCliente,
                                                           cNroDocCli, cApNomCli, CDireccionCli, idMotOperBco,
                                                           cDescMot, nMonto, idEstadoCheque, idComprobantePago,
                                                           idUsuario, idAgencia, x_idMoneda);
        }
        //=============================================================
        //--Valoriza los cheques seleccionados
        //=============================================================

        public DataTable ValorizarCheque(string xmlMovCheque, string xmlDetCheque, DateTime dFechaOpe, int idUsuario,
                                        int idAgeSaldo, int idAgeOpera, int idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_ValorizarCheque_sp", xmlMovCheque, xmlDetCheque,dFechaOpe,  idUsuario,
                                    idAgeSaldo,  idAgeOpera,  idMoneda);
        }
        //=============================================================
        // listar movimientos de las instituciones financieras
        //=============================================================
        public DataTable listarMovimientos(int idEntidad, string cNumeroCuenta, DateTime dFechaIni, DateTime dFechaFin, Boolean lFiltraFecha)
        {
            return objEjeSp.EjecSP("CAJ_LisMovimientoBancos_sp",idEntidad ,cNumeroCuenta, dFechaIni,  dFechaFin,  lFiltraFecha);
        }
        //=============================================================
        //--Graba los movimientos bancarios de las intituciones
        //=============================================================

        public DataTable grabarMovimientoBancos(string stgMovBco, DateTime dFechaOpe, int idUsuario, int idAgeSaldo,
                                                int idAgeOpera, int idMoneda)          
        {
            return objEjeSp.EjecSP("CAJ_GrabarMovimientoBanco_sp", stgMovBco, dFechaOpe , idUsuario , idAgeSaldo,
                                   idAgeOpera , idMoneda );

        }
        //=============================================================
        // extornar movimiento de bancos
        //=============================================================

        public DataTable ExtornarMovimientoBancos(int idMovimiento, int idCuentaInstitucion, decimal nMontoOpe)
        {
            return objEjeSp.EjecSP("CAJ_ExtornarMovimientoBanco_SP", idMovimiento, idCuentaInstitucion, nMontoOpe);

        }
        //=============================================================
        // listar los operacion identificadas o no identificadas de bancos
        //=============================================================
        public DataTable ListarTipoidentificadOSBanco()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoOperacBco_sp");
        }
        
        //=============================================================
        // listar los tipos de operacion bancos
        //=============================================================
        public DataTable ListarTipoDocumentoBanco()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoDocBco_sp");
        }
        //=============================================================
        // grabra las trasferencias
        //=============================================================
        public DataTable grabarTransferencia(string xmlTransferncia, DateTime dFechaOpe ,int idUsuario ,int idAgeSaldo,
                                            int idAgeOpera ,int idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_GrabaTrasferenciaBco_sp", xmlTransferncia, dFechaOpe, idUsuario, idAgeSaldo,
                                    idAgeOpera, idMoneda);
        }
        //=============================================================
        // listar las transferencias
        //=============================================================
        public DataTable ListarTransferencia(int idCuentaOrigen,string cNroCuentaOrigen)
        {
            return objEjeSp.EjecSP("CAJ_ListarTrasferenciaBco_sp", idCuentaOrigen, cNroCuentaOrigen);
        }
        //=============================================================
        // listar los extornos de las transferencias
        //=============================================================
        public DataTable ExtornarTransferenciaBancos(int idTrasferencia, int idMovOri, int idMovDes)
        {
            return objEjeSp.EjecSP("CAJ_ExtornarTrasferenciaBco_sp", idTrasferencia, idMovOri,idMovDes);
        }
        //=============================================================
        // listar los tipos de operaciones de bancos
        //=============================================================
        public DataTable listarTipoOperMovBanco()
        {
            return objEjeSp.EjecSP("CAJ_LisTipoOperacMovBancos_SP");
        }
        //=============================================================
        // Listar fechas de Cierre de Bancos procesados
        //=============================================================
        public DataTable ListarPeriodosProcCierreBcos()
        {
            return objEjeSp.EjecSP("Caj_ListMesesProcCierreBancos_Sp");
        }
        //=============================================================
        // Retornar la Fecha de Cierre de Bancos
        //=============================================================
        public DataTable RetornarFecUltCierreBco()
        {
            return objEjeSp.EjecSP("Caj_RetFecUltCierreBco_Sp");
        }
        //=============================================================
        // Retornar los datos del Cierre de Bancos
        //=============================================================
        public DataTable RetornarDatosCierreBcos(DateTime dFecCierre)
        {
            return objEjeSp.EjecSP("Caj_RetDatosCierreBancos_Sp", dFecCierre);
        }    
        //=============================================================
        // Graba el cierre de Bancos
        //=============================================================
        public DataTable CierreBancos(DateTime dFecCierre)
        {
            return objEjeSp.EjecSP("Caj_CierreBancos_Sp", dFecCierre);
        }
        //=============================================================
        // Listado de instituciones del periodo de cierre de Bancos
        //=============================================================
        public DataTable ListInstPeriodCierreBco(DateTime dFecCierre)
        {
            return objEjeSp.EjecSP("Caj_ListInstPeriodCierreBco_Sp", dFecCierre);
        }
        public DataTable ADTransMovBco(string cMovBco)
        {
            return objEjeSp.EjecSP("CAJ_TransExcelMovBco_sp", cMovBco);
        }
    }
}
