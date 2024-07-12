using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;
using GEN.Funciones;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNCreditoCliente
    {
        private clsADCreditoCliente adCreditoCliente { get; set; }

        public clsCNCreditoCliente()
        {
            adCreditoCliente = new clsADCreditoCliente();
        }

        public List<clsDatosCreditoCliente> CNListarDatosCreditoCliente(int idCliente)
        {
            DataTable dtDatosCreditoCliente = adCreditoCliente.ADListarDatosCreditoCliente(idCliente);
            return dtDatosCreditoCliente.Rows.Count > 0 ? dtDatosCreditoCliente.ToList<clsDatosCreditoCliente>() as List<clsDatosCreditoCliente>  : new List<clsDatosCreditoCliente>() ;
        }

    }
}
