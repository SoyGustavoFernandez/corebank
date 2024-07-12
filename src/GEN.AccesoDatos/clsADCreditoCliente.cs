using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADCreditoCliente
    {
        private clsGENEjeSP objGENEjeSP { get; set; }

        public clsADCreditoCliente()
        {
            objGENEjeSP= new clsGENEjeSP();
        }

        public DataTable ADListarDatosCreditoCliente(int idCliente)
        {
            return objGENEjeSP.EjecSP("GEN_ListarDatosCreditoCliente_SP", idCliente);
        }
    }
}
