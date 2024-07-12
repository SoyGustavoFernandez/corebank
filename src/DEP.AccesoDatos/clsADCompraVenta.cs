using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace DEP.AccesoDatos
{
    public class clsADCompraVenta
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=========================================================================
        //--Registrar Operación: Compra Venta Dólares
        //=========================================================================
        public DataTable ADRegCompVenta(DateTime dFecOpe, int idUsu, int idAge, int idComVen, Decimal nMonOpe, Decimal nTipCam,
                                            Decimal nMonEqui, Decimal nMonRed, Decimal nMonNeto, string cNroDoc, string cNomCli, string cDirCli, bool bTipCamEsp, int idEstSol, int idOperacion,
                                            int idSolAproba, int pidcli, int idNacionalidad, int idTipDocumento, bool lModificaSaldoLinea)
        {
            return objEjeSp.EjecSP("DEP_RegCompraVenta_Sp", dFecOpe, idUsu, idAge, idComVen, nMonOpe, nTipCam,
                                             nMonEqui, nMonRed, nMonNeto, cNroDoc, cNomCli, cDirCli, bTipCamEsp, idEstSol, idOperacion, idSolAproba, pidcli, idNacionalidad, idTipDocumento, lModificaSaldoLinea);
        }

        //============================================================================
        //---Registra Extorno de Compra Venta
        //============================================================================
        public DataTable RegExtornoOpeCV(int idKardex, int idCuenta, int idUsu, int idAge, DateTime dFechaOpe,
                                        Decimal nMonOpe, int idTipOpe, int idTippago, int idKardex_Sal, bool lModificaSaldoLinea)
        {
            return objEjeSp.EjecSP("DEP_RegistraExtornoCompraVenta_SP", idKardex, idCuenta, idUsu, idAge, dFechaOpe,
                                        nMonOpe, idTipOpe, idTippago, idKardex_Sal, lModificaSaldoLinea);
        }

        //============================================================================
        //---Lista las solicitudes de Compra Venta Aprobados 
        //============================================================================
        public DataTable ListarSolCV(DateTime dfechOpe, int idUsuOpe, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_ListarSolComVent_SP",dfechOpe, idUsuOpe ,  idAgencia);
        }
    }
}
