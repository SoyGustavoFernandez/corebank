using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoPago
    {
        public clsADTipoPago objdocide = new clsADTipoPago();

        public DataTable ListaTipoPago()
        {
            return objdocide.ADListaTipoPago();
        }
        public DataTable CNListarTipPagCanal(int idCanalTipOpe)
        {
            return objdocide.ADListarTipPagCanal(idCanalTipOpe);
        }
        public DataTable CNListarTipPagCredito()
        {
            return objdocide.ADListarTipPagCredito();
        }
        public DataTable CNListaTipPagOrdenComp()
        {
            return objdocide.ADListaTipPagOrdenComp();
        }
        public DataTable CNListaTipPagOpeBanco()
        {
            return objdocide.ADListaTipPagOpeBanco();
        }
        public DataTable CNListarTipoPagoMasivos()
        {
            return objdocide.ADListarTipoPagoMasivos();
        }
        
    }
}
