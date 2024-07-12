using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace CNT.AccesoDatos
{
    public class clsADMaestroCuentas
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListaCuentas(int idCtaCtb)
        {
            return objEjeSp.EjecSP("CNT_ListaCuentaContable_sp", idCtaCtb);
        }
        public DataTable ADListaEstrucCuenta(string cCodigoCuenta)
        {
            return objEjeSp.EjecSP("CNT_ListaEstrucCtaCtb_sp", cCodigoCuenta);
        }
        public DataTable ADListaTipoAsiento()
        {
            return objEjeSp.EjecSP("CNT_ListaTipoAsiento_sp");
        }

        public DataTable ADListaMotivoOpeCnt(int idTipoOperacion)
        {
            return objEjeSp.EjecSP("CNT_ListaMotivoOperacion_Sp", idTipoOperacion);
        }
    }
}
