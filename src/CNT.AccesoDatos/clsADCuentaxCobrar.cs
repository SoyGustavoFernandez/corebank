using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace CNT.AccesoDatos
{
    public class clsADCuentaxCobrar
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListaCuentasXCobrar(int idCli)
        {
            return objEjeSp.EjecSP("CNT_ListaCuentasXCobrar_sp", idCli);
        }

        public DataTable ADRegistraCuentasXCobrardiv(int idCxC, int idCli, int idTipoCxC, decimal nMonto,
            string cObservaciones, DateTime dFecIniOpe, int idUsuario, DateTime dFechaOpe, bool lVigente,int idAgencia ,int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_RegistrasCuentasXCobrar_Sp", idCxC, idCli, idTipoCxC, nMonto,   dFecIniOpe, 
                cObservaciones, idUsuario, dFechaOpe, lVigente,idAgencia ,idMoneda);
        }
        public DataTable ADListaPagoCuentasXCobrar(int idCuentasCobrar)
        {
            return objEjeSp.EjecSP("CNT_ListaPagoCuentasXCobrar_sp", idCuentasCobrar);
        }
        public DataTable ADPagoCuentasXCobrar(int idCuentasCobrar, DateTime dFecPago, decimal nMontoPago, int idTipoPago, DateTime dFecOpe, int idUsuario,int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_PagoCuentasXCobrar_sp", idCuentasCobrar, dFecPago, nMontoPago,idTipoPago, dFecOpe, idUsuario,idAgencia);
        }
        public DataTable ADExtornaPagoCuentasXCobrar(int idPagoCuentasCobrar, int idCuentasCobrar, decimal nMontoPago, DateTime dFecOpe, int idUsuario)
        {
            return objEjeSp.EjecSP("CNT_ExtornaPagoCuentasXCobrar_sp", idPagoCuentasCobrar, idCuentasCobrar, nMontoPago, dFecOpe, idUsuario);
        }
    }
}
