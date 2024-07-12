using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNPlanPagos
    {
        clsRPTADPlanPagos ADPlanPagos = new clsRPTADPlanPagos();

        public DataTable CNCronogramaCredito(int idCuenta)
        {
            return ADPlanPagos.ADCronogramaCredito(idCuenta);
        }

        public DataTable CNCronogramaCreditoGastosNoConfirmados(int idCuenta, int idSolicitud = 0, int idOperacion = 0)
        {
            return ADPlanPagos.ADCronogramaCreditoGastosNoConfirmados(idCuenta, idSolicitud, idOperacion);
        }
        public DataTable CNCronogramaPagos(int idCuenta)
        {
            return ADPlanPagos.ADCronogramaPagos(idCuenta);
        }
        public DataTable CNKardexPagos(int idCuenta)
        {
            return ADPlanPagos.ADKardexPagos(idCuenta);
        }

        public DataTable ADCronogramaXSolicitud(int idSolicitud)
        {
            return ADPlanPagos.ADCronogramaXSolicitud(idSolicitud);
        }

        public DataTable CNRptAfectKardexCuotasCred(int idCuentaCred)
        {
            return ADPlanPagos.ADRptAfectKardexCuotasCred(idCuentaCred);
        }
        public DataTable CNCronogramaCreditoGastosSeguros(int idSolicitud)
        {
            return ADPlanPagos.ADCronogramaCreditoGastosSeguros(idSolicitud);
        }
    }
}
