using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;

namespace DEP.CapaNegocio
{
    public class clsCNCompraVenta
    {
        public clsADCompraVenta ObjOperacion = new clsADCompraVenta();

        //=========================================================================
        //--Registrar Operación: Compra Venta Dólares
        //=========================================================================
        public DataTable CNRegCompraVenta(DateTime dFecOpe, int idUsu, int idAge, int idComVen, Decimal nMonOpe, Decimal nTipCam,
                                            Decimal nMonEqui, Decimal nMonRed, Decimal nMonNeto, string cNroDoc, string cNomCli, string cDirCli, bool bTipCamEsp, int idEstSol, int idOperacion,
                                            int idSolAproba, int pidcli, int idNacionalidad, int idTipDocumento, bool lModificaSaldoLinea)
        {
            return ObjOperacion.ADRegCompVenta(dFecOpe, idUsu, idAge, idComVen, nMonOpe, nTipCam,
                                             nMonEqui, nMonRed, nMonNeto, cNroDoc, cNomCli, cDirCli,
                                             bTipCamEsp, idEstSol, idOperacion, idSolAproba, pidcli, idNacionalidad, idTipDocumento, lModificaSaldoLinea);
        }

        //============================================================================
        //---Registra Extorno de Operaciones
        //============================================================================
        public DataTable RegistraExtornoOpeCV(int idKardex, int idCuenta, int idUsu, int idAge, DateTime dFechaOpe,
                                            Decimal nMonOpe, int idTipOpe, int idTippago, int idKardex_Sal, bool lModificaSaldoLinea)
        {
            return ObjOperacion.RegExtornoOpeCV(idKardex, idCuenta, idUsu, idAge, dFechaOpe,
                                            nMonOpe, idTipOpe, idTippago, idKardex_Sal, lModificaSaldoLinea);
        }

        //============================================================================
        //---Lista las solicitudes de Compra Venta Aprobados 
        //============================================================================
        public DataTable ListarSolCV(DateTime dfechOpe,int idUsuOpe, int idAgencia)
        {
            return ObjOperacion.ListarSolCV(dfechOpe,idUsuOpe, idAgencia);
        }
    }
}
