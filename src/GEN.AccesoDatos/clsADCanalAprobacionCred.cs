using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace GEN.AccesoDatos
{
    public class clsADCanalAprobacionCred
    {
        private clsGENEjeSP objGENEjeSP = new clsGENEjeSP();

        public DataTable ListarCanalesAprobacionCred(string xmlCanalesAprobacionCred)
        {
            return objGENEjeSP.EjecSP("GEN_ListarCanalesAproCred_SP", xmlCanalesAprobacionCred);
        }
        public List<clsCanalAprobacionCred> listarCanalAprobacionCred(string cIdsCanalAproCred)
        {
            return objGENEjeSP.LOEjecutar<clsCanalAprobacionCred>("ADM_ListarCanalAprobacionCred_SP", cIdsCanalAproCred);
        }
    }
}
