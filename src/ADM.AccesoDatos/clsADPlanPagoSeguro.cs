using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADPlanPagoSeguro
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable InsUpdPlanPagoSeguro(clsMantenimientoPlanSeguroVida objPlanPagoActual)
        {
            return objEjeSp.EjecSP("ADM_InsUpdPlanPagoSeguro_SP", objPlanPagoActual.cDescripcion, objPlanPagoActual.nMinMes, objPlanPagoActual.nMaxMes, objPlanPagoActual.nPrecioMensual, objPlanPagoActual.nMeses, objPlanPagoActual.lFijo, objPlanPagoActual.lSolicitud, objPlanPagoActual.lRedondear, objPlanPagoActual.idConcepto, objPlanPagoActual.idTipoSeguro, objPlanPagoActual.idTipoPlan);
        }
    }
}