using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNCuentasXCobrar
    {
        public clsADCuentaxCobrar ObjCxC = new clsADCuentaxCobrar();
        
        //registro de cuentas por cobrar
        public DataTable CNListaCuentasxCobrar(int idCliente)
        {
            return ObjCxC.ADListaCuentasXCobrar(idCliente);
        }
        public DataTable CNRegistraCuentasXcobrar(int idCxC, int idCli, int idTipoCxC, decimal nMonto,
            string cObservaciones, DateTime dFecIniOpe, int idUsuario, DateTime dFechaOpe, bool lVigente, int idAgencia, int idMoneda)
        {
            return ObjCxC.ADRegistraCuentasXCobrardiv(idCxC, idCli, idTipoCxC, nMonto,
                cObservaciones, dFecIniOpe, idUsuario, dFechaOpe, lVigente, idAgencia , idMoneda);
        }
        //pago de cuentas por cobrar
        public DataTable CNListaPagoCuentasxCobrar(int idCuentasXCobrar)
        {
            return ObjCxC.ADListaPagoCuentasXCobrar(idCuentasXCobrar);
        }
        public DataTable CNPagoCuentasxCobrar(int idCuentasCobrar,DateTime dFecPago,decimal nMontoPago,int idTipoPago,DateTime dFecOpe,
            int idUsuario, int idAgencia)
        {
            return ObjCxC.ADPagoCuentasXCobrar(idCuentasCobrar, dFecPago, nMontoPago, idTipoPago, dFecOpe, idUsuario, idAgencia);
        }
        public DataTable CNExtornaPagoCuentasxCobrar(int idPagoCuentasCobrar, int idCuentasCobrar, decimal nMontoPago, DateTime dFecOpe, int idUsuario)
        {
            return ObjCxC.ADExtornaPagoCuentasXCobrar(idPagoCuentasCobrar, idCuentasCobrar, nMontoPago, dFecOpe, idUsuario);
        }
    }
}
