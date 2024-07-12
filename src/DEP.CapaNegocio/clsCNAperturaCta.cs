using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEP.AccesoDatos;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace DEP.CapaNegocio
{
    public class clsCNAperturaCta
    {
        clsADAperturaCta objADApeCta;
        
        public clsCNAperturaCta()
        {
            objADApeCta = new clsADAperturaCta();
        }

        public clsCNAperturaCta(bool cConex)
        {
            objADApeCta = new clsADAperturaCta(cConex);
        }


        //============================================================================
        //---Listado de Modalidades de Pago
        //============================================================================
        public DataTable ListaCamposDep(int idOpc)
        {
            return objADApeCta.LisCamposDep(idOpc);
        }

        //============================================================================
        //---Registrar solicitud de apertura
        //============================================================================
        public DataTable RegistraAperturaCta(string xmlDepos, string xmlInterv, string xmlTipPago, string xmlEmpleador, string xmlAhoPrg,
                                    int idUsu, DateTime dFecOpe,int nCuotas, Decimal nMonIntang, bool lisAhoPrg,bool lIsRequeCert,
                                    bool lIsCtaCTS, int idTipPago,int idCuentaTrans,DateTime dFecAhoPrg, bool lisReqEmp, string cNroDocPag, int cCodInstFin, int idCuentaRel,
                                    Decimal nMonCapital, string xmlCtasCancel)
        {
            return objADApeCta.RegAperturaCta(xmlDepos, xmlInterv, xmlTipPago, xmlEmpleador, xmlAhoPrg,
                                     idUsu,  dFecOpe, nCuotas,  nMonIntang,  lisAhoPrg, lIsRequeCert,
                                     lIsCtaCTS, idTipPago, idCuentaTrans, dFecAhoPrg, lisReqEmp, cNroDocPag, cCodInstFin, idCuentaRel,
                                     nMonCapital, xmlCtasCancel);
        }
        //============================================================================
        //---Registrar confirmación de apertura
        //============================================================================
        public DataTable RegistraConfirmApeCta(int idCuenta, string xmlComision, string xmlTipPago, string xmlInterv,
                                Decimal nMondep, Decimal nIntAde, int idUsu, DateTime dFecOpe,
                                int nCuotas, bool lisAhoPrg, bool lIsRequeCert,
                                bool lIsCtaCTS, string cNroDocPag, int cCodInstFin, int cCtaTrans, int idTipPag,
                                Decimal nMonITFDep, Decimal nMonITFInt, Decimal nMonComis, Decimal nMonRedondeo, Decimal nMonCapital, int idCanal, Decimal nMonRedIntAde,
                                bool lIsDepMenEdad, int x_idMotivoOpe, int idTasa, Decimal nMonTasa, Decimal nMonIntTot,
                                bool lModificaSaldoLinea1, bool lModificaSaldoLinea2, int idMoneda, int nIdAgencia)
        {
            return objADApeCta.RegConfirmApeCta(idCuenta, xmlComision, xmlTipPago, xmlInterv,
                                                nMondep, nIntAde, idUsu, dFecOpe,
                                                nCuotas, lisAhoPrg, lIsRequeCert,
                                                lIsCtaCTS, cNroDocPag, cCodInstFin, cCtaTrans, idTipPag,
                                                nMonITFDep, nMonITFInt, nMonComis, nMonRedondeo, nMonCapital, idCanal, nMonRedIntAde,
                                                lIsDepMenEdad, x_idMotivoOpe, idTasa, nMonTasa, nMonIntTot,
                                                lModificaSaldoLinea1, lModificaSaldoLinea2, idMoneda, nIdAgencia);
        }

        //============================================================================
        //---Registrar confirmación de apertura
        //============================================================================
        public DataTable RegistraConfirmApeCtaAutomatico(int idCuenta, string xmlComision, string xmlTipPago, string xmlInterv,
                                Decimal nMondep, Decimal nIntAde, int idUsu, DateTime dFecOpe,
                                int nCuotas, bool lisAhoPrg, bool lIsRequeCert,
                                bool lIsCtaCTS, string cNroDocPag, int cCodInstFin, int cCtaTrans, int idTipPag,
                                Decimal nMonITFDep, Decimal nMonITFInt, Decimal nMonComis, Decimal nMonRedondeo, Decimal nMonCapital, int idCanal, Decimal nMonRedIntAde,
                                bool lIsDepMenEdad, int x_idMotivoOpe, int idTasa, Decimal nMonTasa, Decimal nMonIntTot, bool lAperturaAutomatica)
        {
            return objADApeCta.RegConfirmApeCtaAutomatico(idCuenta, xmlComision, xmlTipPago, xmlInterv,
                                                nMondep, nIntAde, idUsu, dFecOpe,
                                                nCuotas, lisAhoPrg, lIsRequeCert,
                                                lIsCtaCTS, cNroDocPag, cCodInstFin, cCtaTrans, idTipPag,
                                                nMonITFDep, nMonITFInt, nMonComis, nMonRedondeo, nMonCapital, idCanal, nMonRedIntAde,
                                                lIsDepMenEdad, x_idMotivoOpe, idTasa, nMonTasa, nMonIntTot, lAperturaAutomatica);
        }

        //============================================================================
        //---Retorna Datos del Empleador
        //============================================================================
        public DataTable RetornaDatEmpleador(string cRuc)
        {
            return objADApeCta.RetDatEmpleador(cRuc);
        }

        //============================================================================
        //---Retorna Representantes de la Jurídica
        //============================================================================
        public DataTable RetornaRepreJuridica(int idCli)
        {
            return objADApeCta.RetRepreJuridica(idCli);
        }

        //============================================================================
        //---Retorna la Tasa de Ahorros
        //============================================================================
        public DataTable RetornaTasaAhorros(int nPlazo, int idProducto, Decimal nMonto, int idMoneda, int idAgencia, int idTipPer)
        {
            return objADApeCta.RetTasaAhorro(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipPer);
        }

        //============================================================================
        //-----Retorna Tipos de Bloqueo
        //============================================================================
        public DataTable RetornaTiposBloqueo()
        {
            return objADApeCta.RetTipoBloqueo();
        }

        //============================================================================
        //---Retorna Características del Bloqueo
        //============================================================================
        public DataTable RetornaTiposCaractBloq(int idBloq)
        {
            return objADApeCta.RetCaractBloqueo(idBloq);
        }

        //============================================================================
        //---Retorna Datos de la Orden de Pago
        //============================================================================
        public DataTable RetornaDatosOrdenPago(int nSerie, int nNumero, int idCuenta, int idTipValorado, int idMoneda)
        {
            return objADApeCta.RetornaDatosOP(nSerie, nNumero, idCuenta, idTipValorado, idMoneda);
        }

        //===============================================================
        //--Calcula el saldo intangible de una Cuenta CTS
        //===============================================================
        public DataTable CNCalcularSaldoIntangible(decimal nMontoDeposito, decimal nRemuTotal)
        {
            return objADApeCta.ADCalcularSaldoIntangible(nMontoDeposito, nRemuTotal);
        }
    }
}
