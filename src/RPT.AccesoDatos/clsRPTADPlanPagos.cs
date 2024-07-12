using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADPlanPagos
    {
        clsGENEjeSP objejecsp = new clsGENEjeSP();

        public DataTable ADCronogramaCredito(int idCuenta)
        {
            return objejecsp.EjecSP("CRE_LisPpgSolImp_SP", idCuenta);
        }
        public DataTable ADCronogramaCreditoGastosNoConfirmados(int idCuenta, int idSolicitud, int idOperacion)
        {
            return objejecsp.EjecSP("CRE_LisPpgSolImpGastNoConf_Sp", idCuenta, idSolicitud, idOperacion);
        }
        public DataTable ADCronogramaPagos(int idCuenta)
        {
            return objejecsp.EjecSP("CRE_LisPlanPagCre_SP", idCuenta);
        }
        public DataTable ADKardexPagos(int idCuenta)
        {
            return objejecsp.EjecSP("CRE_LisKardexPagoCre_SP", idCuenta);
        }

        public DataTable ADCronogramaXSolicitud(int idSolicitud)
        {
            return objejecsp.EjecSP("CRE_PpgSolicitudImp_SP", idSolicitud);
        }

        public DataTable ADRptAfectKardexCuotasCred(int idCuentaCred)
        {
            return objejecsp.EjecSP("RPT_DetAfectacionPlanPagos_sp", idCuentaCred);
        }
        public DataTable ADCronogramaCreditoGastosSeguros(int idSolicitud)
        {
            return objejecsp.EjecSP("CRE_RptPlanPagosCalendarioSeg_SP", idSolicitud);
        }
    }
}
