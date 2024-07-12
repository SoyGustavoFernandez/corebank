using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADDeclaracionJurada
    {

        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADDatosTrabajador(int idCliente)
        {
            return objEjeSp.EjecSP("GRH_DatosTrabajador_SP", idCliente);
        }

        public DataTable ADDatosPariente(int idCliente)
        {
            return objEjeSp.EjecSP("GRH_DatosPariente_SP", idCliente);
        }

        public DataTable ADDatosFamiliares(int idCliente)
        {
            return objEjeSp.EjecSP("GRH_DatosFamiliares_SP", idCliente);
        }
    }
}
