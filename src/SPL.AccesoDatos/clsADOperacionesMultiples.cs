using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace SPL.AccesoDatos
{
    public class clsADOperacionesMultiples
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADRetornaSumaMontoDeOperaciones(int idKardex, DateTime dFechaSis, int idAgencia, int nTipoUmbral)
        {
            return objEjeSp.EjecSP("SPL_RetornaSumaMontoDeOperaciones_SP", idKardex, dFechaSis, idAgencia, nTipoUmbral);
        }

        public DataTable ADCargaOperacionesFraccionarias(int idKardex, DateTime dFechaSis, int idAgencia, int nTipoUmbral)
        {
            return objEjeSp.EjecSP("SPL_CargaOperacionesFraccionarias_SP", idKardex, dFechaSis, idAgencia, nTipoUmbral);
        }

        public DataTable ADRetornaTitular(int idKardex)
        {
            return objEjeSp.EjecSP("SPL_RetornaTitular_SP", idKardex);
        }

        public DataTable ADRecuperarClienteOpeMult(int idCliente)
        {
            return objEjeSp.EjecSP("SPL_RecuperarClientesOpeMult_SP", idCliente);
        }

        public DataTable ADRegistrarOperacionMultiple(string xml, int idUmbral, int idKardex, DateTime dFecha, DateTime dFechaHora
           , decimal nImporteOpe, DateTime dFechaIniOpe, DateTime dFechaFinOpe, decimal nImporteTotalOpeMuliple, int nNroTotalOpeMulti
           , int idTipoOperacion, int idMoneda, Boolean lInusual, int idInusual, int idDetalleInusual, int idCuenta
           , string cObservacion, int idModulo)
        {
            return objEjeSp.EjecSP("SPL_RegistraOperacionesMultiples_SP", xml, idUmbral, idKardex, dFecha, dFechaHora
            , nImporteOpe, dFechaIniOpe, dFechaFinOpe, nImporteTotalOpeMuliple, nNroTotalOpeMulti
            , idTipoOperacion, idMoneda, lInusual, idInusual, idDetalleInusual, idCuenta
            , cObservacion, idModulo);
        }

        public DataTable ADObtienePersonaRol(int idKardex, int idRol)
        {
            return objEjeSp.EjecSP("SPL_PersonaOpeMultIdKardex_SP", idKardex, idRol);
        }

        public DataTable ADRptOperacionMultiple(int idKardex)
        {
            return objEjeSp.EjecSP("SPL_RPTOperacionesMultiples_SP", idKardex);
        }

        public DataTable ADRptOperacionPorRango(DateTime dFechaInicio, DateTime dFechaFin, Decimal nMonto)
        {
            return objEjeSp.EjecSP("SPL_RptOperacioneRango_SP", dFechaInicio, dFechaFin, nMonto);
        }

        public DataTable ADDetalleOperacionesRangos(DateTime dFechaInicio, DateTime dFechaFin, Decimal nMonto, int idCli)
        {
            return objEjeSp.EjecSP("SPL_DetalleOperacionesRangos_SP", dFechaInicio, dFechaFin, nMonto, idCli);
        }

        public DataTable ADRptRegOperacionesMultiples(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return objEjeSp.EjecSP("SPL_ReporteOperacionesMultiples_SP", dFechaInicio, dFechaFin, idAgencia);
        }
        public DataTable ADCuentaRegOpeMult(int idKardex, int idAgencia)
        {
            return objEjeSp.EjecSP("SPL_CuentaRegOpeMult_SP", idKardex, idAgencia);
        }
        public DataTable ADObtCliRealizaOperacion(int idKardex)
        {
            return objEjeSp.EjecSP("SPL_RetornaClienteQueRealizaOperacion_SP", idKardex);
        }

        public DataTable ADValidaRegOpeMulMesy1_3(int idKardex, int idTipoUmbral)
        {
            return objEjeSp.EjecSP("SPL_ValidaRegOpeMulMesy1_3_SP", idKardex, idTipoUmbral);
        }
        
    }
}
