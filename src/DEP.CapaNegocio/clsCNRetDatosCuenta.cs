using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEP.AccesoDatos;
using System.Data;
using EntityLayer;


namespace DEP.CapaNegocio
{
    public class clsCNRetDatosCuenta
    {
        clsADRetDatosCuenta objLista = new clsADRetDatosCuenta();

        
        public DataTable ListarDatosCuenta(int NroCuenta)
        {
            return objLista.ListarDatosCuenta(NroCuenta);
        }

        public DataTable ListarDatCuentaProg(int NroCuenta, int agencia)
        {
            return objLista.ListarDatCuentaProg(NroCuenta, agencia);
        }
        public DataTable ListarCronogDepos(int NroCuenta)
        {
            return objLista.ListarCronogDepos(NroCuenta);
        }

        public DataTable ListarInterv(int NroCuenta)
        {
            return objLista.ListarInterv(NroCuenta);
        }
        public DataTable ListarComisiones(int NroCuenta, int idAgencia, int idMoneda, int idTipPersona)
        {
            return objLista.ListarComisiones(NroCuenta, idAgencia, idMoneda, idTipPersona);
        }
        public DataTable ListarComiEspecial(int NroCuenta)
        {
            return objLista.ListarComiEspecial(NroCuenta);
        }
        public void GuardarInterv(String Datosinterv, int NroCuenta, String IdUsuario)
        {
            objLista.GuardarInterv(Datosinterv, NroCuenta, IdUsuario);
        }
        public DataTable GuardarDatosCuenta(int NroCuenta, decimal SaldoMin, Boolean OrdenPago, int idTipEnvEstCta, string cCorreo, int nNumeroFirmas, string DatosComision)
        {
            return objLista.GuardarDatosCuenta(NroCuenta, SaldoMin, OrdenPago, idTipEnvEstCta, cCorreo, nNumeroFirmas, DatosComision);
        }

        public DataTable ListarRenovacionesxCuenta(int NroCuenta)
        {
            return objLista.ListarRenovacionesCuenta(NroCuenta);
        }

        public DataTable RetornaBloqueosxCuenta(int NroCuenta)
        {
            return objLista.RetornaBloqueosxCuenta(NroCuenta);
        }

        public DataTable ListarSolCambioxCuenta(int idCuenta)
        {
            return objLista.ListarSolCambioxCuenta(idCuenta);
        }

    }
}
