using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNBalance
    {
        public clsADBalance ObjBalance = new clsADBalance();
        public DataTable CNProcesaEPG(DateTime dfecha, decimal nPorImpRent)
        {
            return ObjBalance.ADProcesaEPG(dfecha, nPorImpRent);
        }
        public DataTable CNProcesaBG(DateTime dFecha)
        {
            return ObjBalance.ADProcesaBG(dFecha);
        }
        public DataTable CNProcesaBalance(DateTime dFecha)
        {
            return ObjBalance.ADProcesaBalance(dFecha);
        }
        public DataTable CNResumMovSaldo(DateTime dFecIni, DateTime dFecFin)
        {
            return ObjBalance.ADResumMovSaldo(dFecIni, dFecFin);
        }
        public DataTable CNResumMovSaldoAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return ObjBalance.ADResumMovSaldoAge(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNResumCobranAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return ObjBalance.ADResumCobranAge(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNResumDeposito(DateTime dFecIni, DateTime dFecFin)
        {
            return ObjBalance.ADResumDeposito(dFecIni, dFecFin);
        }
        public DataTable CNResumDepositoAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return ObjBalance.ADResumDepositoAge(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNActualizaSaldoEnPresupuesto(DateTime dFecFin)
        {
            return ObjBalance.ADActualizaSaldoEnPresupuesto(dFecFin);
        }
        public DataTable CNInsEPGManual(DateTime dFecha, string cXMLDatos)
        {
            return ObjBalance.ADInsEPGManual(dFecha, cXMLDatos);
        }
        public DataTable CNGeneraEPG(DateTime dFecha)
        {
            return ObjBalance.ADGeneraEPG(dFecha);
        }
        public DataTable CNBSI(DateTime dFecha)
        {
            return ObjBalance.ADBSI(dFecha);
        }
        public DataTable CNConsultaBSI(DateTime dFecha)
        {
            return ObjBalance.ADConsultaBSI(dFecha);
        }
        public DataTable CNInteresGracia(DateTime dFecha)
        {
            return ObjBalance.ADInteresGracia(dFecha);
        }
        public DataTable ValidaProcesoEEFF(string cFrm, int idUsuario)
        {
            return ObjBalance.ValidaProcesoEEFF(cFrm, idUsuario);
        }
        public DataTable LiberaProcesoEEFF(string cFrm, int idUsuario)
        {
            return ObjBalance.LiberaProcesoEEFF(cFrm, idUsuario);
        }
        public DataTable DiferidoxAmpliacion(DateTime dFecha)
        {
            return ObjBalance.DiferidoxAmpliacion(dFecha);
        }
        public DataTable DiferidoxCapNeg(DateTime dFecha)
        {
            return ObjBalance.DiferidoxCapNeg(dFecha);
        }
    }
}
