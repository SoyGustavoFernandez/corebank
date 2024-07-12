using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace DEP.AccesoDatos
{
    public class clsADRetDatosCuenta
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarDatosCuenta(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatosCuenta_sp", NroCuenta);
        }
        public DataTable ListarDatCuentaProg(int NroCuenta, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_DatCuentaProg_sp", NroCuenta, idAgencia);
        }
        public DataTable ListarCronogDepos(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatCronogDepos_sp", NroCuenta);
        }
        public DataTable ListarInterv(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatosIntervCuenta_sp", NroCuenta);
        }
        public DataTable ListarComisiones(int NroCuenta, int idAgencia, int idMoneda,int idTipPersona)
        {
            return objEjeSp.EjecSP("DEP_ListarComXCuenta", NroCuenta, idAgencia, idMoneda, idTipPersona);
        }
        public DataTable ListarComiEspecial(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_ListarComXCuentaEsp", NroCuenta);
        }
        public void GuardarInterv(String Datosinterv, int NroCuenta, String IdUsuario)
        {
            objEjeSp.EjecSP("DEP_GuardarIntrvCuenta", Datosinterv, NroCuenta, IdUsuario);
        }

        public DataTable GuardarDatosCuenta(int NroCuenta, decimal SaldoMin, Boolean OrdenPago, int idTipEnvEstCta, string cCorreo, int nNumeroFirmas, string DatosComision)
        {
            return objEjeSp.EjecSP("DEP_GuardarDatosCuenta_sp", NroCuenta, SaldoMin, OrdenPago, idTipEnvEstCta, cCorreo, nNumeroFirmas, DatosComision);
        }

        public DataTable ListarRenovacionesCuenta(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_DatosRenovacionxCuenta_sp", NroCuenta);
        }

        public DataTable RetornaBloqueosxCuenta(int NroCuenta)
        {
            return objEjeSp.EjecSP("DEP_RetornaBloqueosxCta_sp", NroCuenta);
        }

        public DataTable ListarSolCambioxCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ListadoSolCambioTit_Sp", idCuenta);
        }

    }
}
