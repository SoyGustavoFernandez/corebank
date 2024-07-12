using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoPago
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListaTipoPago()
        {
            return objEjeSp.EjecSP("DEP_ListaTipoPago_SP");
        }

        public DataTable ADListarTipPagCanal(int idCanalTipOpe)
        {
            return objEjeSp.EjecSP("GEN_ListarTipPagCanal_SP", idCanalTipOpe);
        }
        public DataTable ADListarTipPagCredito()
        {
            return objEjeSp.EjecSP("CRE_RetModalidadPago_Sp");
        }
        public DataTable ADListaTipPagOrdenComp()
        {
            return objEjeSp.EjecSP("LOG_ListTipoPagoOrdCompra_Sp");
        }
        public DataTable ADListaTipPagOpeBanco()
        {
            return objEjeSp.EjecSP("CAJ_ListaTipoPagoOpeBanco_SP");
        }
        public DataTable ADListarTipoPagoMasivos()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoPagoMasivos_SP");
        }
    }
}
