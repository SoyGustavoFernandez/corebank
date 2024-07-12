using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace DEP.AccesoDatos
{
    public class clsADAperturaCta
    {
        IntConexion objEjeSP; 
       
        public clsADAperturaCta(bool lConexion)
        {
            objEjeSP = new clsWCFEjeSP();
        }

        public clsADAperturaCta()
        {
            objEjeSP = new clsGENEjeSP();
        }

        //============================================================================
        //---Listado Campos Deposito
        //============================================================================
        public DataTable LisCamposDep(int idOpc)
        {
            return objEjeSP.EjecSP("DEP_RetTablaDeposito_Sp", idOpc);
        }

        //============================================================================
        //---Registra Confirmación de Cuenta
        //============================================================================
        public DataTable RegConfirmApeCta(int idCuenta, string xmlComision, string xmlTipPago, string xmlInterv,
                                Decimal nMondep, Decimal nIntAde, int idUsu, DateTime dFecOpe,
                                int nCuotas, bool lisAhoPrg, bool lIsRequeCert,
                                bool lIsCtaCTS, string cNroDocPag, int cCodInstFin, int cCtaTrans, int idTipPag,
                                Decimal nMonITFDep, Decimal nMonITFInt, Decimal nMonComis, Decimal nMonRedondeo, Decimal nMonCapital, int idCanal, Decimal nMonRedIntAde,
                                bool lIsDepMenEdad, int x_idMotivoOpe, int idTasa, Decimal nMonTasa, Decimal nMonIntTot,
                                bool lModificaSaldoLinea1, bool lModificaSaldoLinea2, int idMoneda, int nIdAgencia)
        {
            return objEjeSP.EjecSP("DEP_ConfirmAperDep_sp", idCuenta, xmlComision, xmlTipPago, xmlInterv,
                                                nMondep, nIntAde, idUsu, dFecOpe,
                                                nCuotas, lisAhoPrg, lIsRequeCert,
                                                lIsCtaCTS, cNroDocPag, cCodInstFin, cCtaTrans, idTipPag,
                                                nMonITFDep, nMonITFInt, nMonComis, nMonRedondeo, nMonCapital, idCanal, nMonRedIntAde,
                                                lIsDepMenEdad, x_idMotivoOpe, idTasa, nMonTasa, nMonIntTot,
                                                lModificaSaldoLinea1, lModificaSaldoLinea2, idMoneda, nIdAgencia);
        }
        //============================================================================
        //---Registra Confirmación de Cuenta de apertura automatica
        //============================================================================
        public DataTable RegConfirmApeCtaAutomatico(int idCuenta, string xmlComision, string xmlTipPago, string xmlInterv,
                                Decimal nMondep, Decimal nIntAde, int idUsu, DateTime dFecOpe,
                                int nCuotas, bool lisAhoPrg, bool lIsRequeCert,
                                bool lIsCtaCTS, string cNroDocPag, int cCodInstFin, int cCtaTrans, int idTipPag,
                                Decimal nMonITFDep, Decimal nMonITFInt, Decimal nMonComis, Decimal nMonRedondeo, Decimal nMonCapital, int idCanal, Decimal nMonRedIntAde,
                                bool lIsDepMenEdad, int x_idMotivoOpe, int idTasa, Decimal nMonTasa, Decimal nMonIntTot, bool lAperturaAutomatica)
        {
            return objEjeSP.EjecSP("DEP_ConfirmarApeturaDepositoAutomatico_sp", idCuenta, xmlComision, xmlTipPago, xmlInterv,
                                                nMondep, nIntAde, idUsu, dFecOpe,
                                                nCuotas, lisAhoPrg, lIsRequeCert,
                                                lIsCtaCTS, cNroDocPag, cCodInstFin, cCtaTrans, idTipPag,
                                                nMonITFDep, nMonITFInt, nMonComis, nMonRedondeo, nMonCapital, idCanal, nMonRedIntAde,
                                                lIsDepMenEdad, x_idMotivoOpe, idTasa, nMonTasa, nMonIntTot, lAperturaAutomatica);
        }
        //============================================================================
        //---Registra Solicitud de Cuenta
        //============================================================================
        public DataTable RegAperturaCta(string xmlDepos, string xmlInterv, string xmlTipPago, string xmlEmpleador, string xmlAhoPrg,
                                    int idUsu, DateTime dFecOpe, int nCuotas, Decimal nMonIntang, bool lisAhoPrg, bool lIsRequeCert,
                                    bool lIsCtaCTS, int idTipPago, int idCuentaTrans,DateTime dFecAhoPrg, bool lisReqEmp, string cNroDocPag, int cCodInstFin, int idCuentaRel,
                                    Decimal nMonCapital, string xmlCtasCancel)
        {
            return objEjeSP.EjecSP("DEP_RegAperturaCta_SP", xmlDepos, xmlInterv, xmlTipPago, xmlEmpleador, xmlAhoPrg,
                                     idUsu, dFecOpe, nCuotas, nMonIntang, lisAhoPrg, lIsRequeCert,
                                     lIsCtaCTS, idTipPago, idCuentaTrans, dFecAhoPrg, lisReqEmp, cNroDocPag, cCodInstFin, idCuentaRel, nMonCapital, xmlCtasCancel);
        }
        //============================================================================
        //---Retorna Datos Empleador
        //============================================================================
        public DataTable RetDatEmpleador(string cRuc)
        {
            return objEjeSP.EjecSP("DEP_RetDatosEmpleador_sp", cRuc);
        }

        //============================================================================
        //---Retorna Representantes de la Empresa
        //============================================================================
        public DataTable RetRepreJuridica(int idCli)
        {
            return objEjeSP.EjecSP("DEP_RetRepresentantesJur_Sp", idCli);
        }

        //============================================================================
        //---Retorna la Tasa de Ahorros
        //============================================================================
        public DataTable RetTasaAhorro(int nPlazo, int idProducto, Decimal nMonto, int idMoneda, int idAgencia,int idTipPer)
        {
            return objEjeSP.EjecSP("DEP_ExtraeTasaAhorro_sp", nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipPer);
        }

        //============================================================================
        //---Retorna Tipos de Bloqueo
        //============================================================================
        public DataTable RetTipoBloqueo()
        {
            return objEjeSP.EjecSP("DEP_ListaTipoBloqueos_Sp");
        }

        //============================================================================
        //---Retorna Características del Bloqueo
        //============================================================================
        public DataTable RetCaractBloqueo(int idBloq)
        {
            return objEjeSP.EjecSP("DEP_ListaCaracteristicaBloq_Sp", idBloq);
        }

        //============================================================================
        //---Retorna Datos de la Orden de Pago
        //============================================================================
        public DataTable RetornaDatosOP(int nSerie, int nNumero, int idCuenta, int idTipValorado, int idMoneda)
        {
            return objEjeSP.EjecSP("DEP_RetornaDatOrdenPago_Sp", nSerie, nNumero, idCuenta, idTipValorado, idMoneda);
        }

        //===============================================================
        //--Calcula el saldo intangible de una Cuenta CTS
        //===============================================================
        public DataTable ADCalcularSaldoIntangible(decimal nMontoDeposito, decimal nRemuTotal)
        {
            return objEjeSP.EjecSP("DEP_CalcularMontoIntangibleCTSSol_SP", nMontoDeposito, nRemuTotal);
        }
    }
}
