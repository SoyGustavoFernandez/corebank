using ADM.AccesoDatos;
using EntityLayer;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNPlanPagoSeguro
    {
        clsADPlanPagoSeguro objADPlanPagoSeguro = new clsADPlanPagoSeguro();

        public DataTable InsUpdPlanPagoSeguro(clsMantenimientoPlanSeguroVida objPlanPagoActual)
        {
            return objADPlanPagoSeguro.InsUpdPlanPagoSeguro(objPlanPagoActual);
        }
    }
}