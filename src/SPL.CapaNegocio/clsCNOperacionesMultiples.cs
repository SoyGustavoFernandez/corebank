using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using SPL.AccesoDatos;

namespace SPL.CapaNegocio
{
    public class clsCNOperacionesMultiples
    {
        clsADOperacionesMultiples adOpeMult = new clsADOperacionesMultiples();
        public DataTable CNRetornaSumaMontoDeOperaciones(int idKardex, DateTime dFechaSis, int idAgencia, int nTipoUmbral)
        {
            return adOpeMult.ADRetornaSumaMontoDeOperaciones(idKardex, dFechaSis, idAgencia, nTipoUmbral);
        }

        public DataTable CNCargaOperacionesFraccionarias(int idKardex, DateTime dFechaSis, int idAgencia, int nTipoUmbral)
        {
            return adOpeMult.ADCargaOperacionesFraccionarias(idKardex, dFechaSis, idAgencia, nTipoUmbral);
        }
        public DataTable CNRetornaTitular(int idKardex)
        {
            return adOpeMult.ADRetornaTitular(idKardex);
        }

        public DataTable CNRecuperarClienteOpeMult(int idCliente)
        {
            return adOpeMult.ADRecuperarClienteOpeMult(idCliente);
        }

        public DataTable CNRegistrarOperacionMultiple(string xml    , int idUmbral      , int idKardex                      , DateTime dFecha       , DateTime dFechaHora
            , decimal nImporteOpe, DateTime dFechaIniOpe    , DateTime dFechaFinOpe     , decimal nImporteTotalOpeMuliple   , int nNroTotalOpeMulti
            , int idTipoOperacion, int idMoneda             , Boolean lInusual          , int idInusual                     , int idDetalleInusual  , int idCuenta
            , string cObservacion, int idModulo)
        {
            return adOpeMult.ADRegistrarOperacionMultiple(xml               , idUmbral                      , idKardex                  , dFecha            , dFechaHora
            , nImporteOpe       , dFechaIniOpe         , dFechaFinOpe       , nImporteTotalOpeMuliple       , nNroTotalOpeMulti
            , idTipoOperacion   , idMoneda             , lInusual           , idInusual                     , idDetalleInusual          , idCuenta
            , cObservacion      , idModulo);
        }

        public DataTable CNObtienePersonaRol(int idKardex, int idRol)
        {
            return adOpeMult.ADObtienePersonaRol(idKardex, idRol);
        }

        public DataTable CNRptOperacionMultiple(int idKardex)
        {
            return adOpeMult.ADRptOperacionMultiple(idKardex);
        }

        public DataTable CNRptOperacionPorRango(DateTime dFechaInicio, DateTime dFechaFin, Decimal nMonto)
        {
            return adOpeMult.ADRptOperacionPorRango(dFechaInicio, dFechaFin, nMonto);
        }

        public DataTable CNDetalleOperacionesRangos(DateTime dFechaInicio, DateTime dFechaFin, Decimal nMonto, int idCli)
        {
            return adOpeMult.ADDetalleOperacionesRangos(dFechaInicio, dFechaFin, nMonto, idCli);
        }

        public DataTable CNRptRegOperacionesMultiples(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return adOpeMult.ADRptRegOperacionesMultiples(dFechaInicio, dFechaFin, idAgencia);
        }

        public DataTable CNCuentaRegOpeMult(int idKardex, int idAgencia)
        {
            return adOpeMult.ADCuentaRegOpeMult(idKardex, idAgencia);
        }
        public DataTable CNObtCliRealizaOperacion(int idKardex)
        {
            return adOpeMult.ADObtCliRealizaOperacion(idKardex);
        }

        public DataTable CNValidaRegOpeMulMesy1_3(int idKardex, int idTipoUmbral)
        {
            return adOpeMult.ADValidaRegOpeMulMesy1_3(idKardex, idTipoUmbral);
        }
    }
}