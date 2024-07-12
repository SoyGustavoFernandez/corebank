using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADBiometriaExcepcion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet ADObtenerRPTSolicitudBiometrica(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta, int idEstado)
        {
            return objEjeSp.DSEjecSP("ADM_ObtenerRPTSolicitudBiometrica_SP", idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta, idEstado);
        }

        public DataTable ADObtenerRPTSolicitudBiometricaCompleto(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta, int idEstado)
        {
            return objEjeSp.EjecSP("ADM_ObtenerRPTSolicitudBiometricaCompleto_SP", idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta, idEstado);
        }

        public DataTable ADObtenerDetalleArchivoExcepBiometrica(int idBiometriaExcep)
        {
            return objEjeSp.EjecSP("ADM_ObtenerArchivoExcepBiometrica_SP", idBiometriaExcep);
        }

    }
}
