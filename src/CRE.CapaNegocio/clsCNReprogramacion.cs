using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNReprogramacion
    {
        private clsADReprogramacion objADReprogramacion= new clsADReprogramacion();

        public clsCNReprogramacion()
        {
        }
        public DataSet grabarSolicitudReprogMasivo(List<clsCreditoReprogExcel> lstCreditoReprog, int idTipoPlanPago)
        {
            string xmlCuentas;
            if (idTipoPlanPago == 3) {
                xmlCuentas = lstCreditoReprog.ListObjectToXmlWithColumnFilter("Cuenta", "Cuentas", new String[] { "nDiasReprog" });
                return this.objADReprogramacion.grabarSolicitudReprogMasivoTEA(xmlCuentas);
            }
            xmlCuentas = lstCreditoReprog.ListObjectToXmlWithColumnFilter("Cuenta", "Cuentas", new String[] { "nTasaNueva" });
            return this.objADReprogramacion.grabarSolicitudReprogMasivo(xmlCuentas, idTipoPlanPago);
        }
    }
}
