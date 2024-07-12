using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.AccesoDatos
{
    public class clsADEnvExtCtas
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListEnvExtCtasCorreo(int idTipoEnvioEstCta, int nTipoGenEnv, int nAnioMes)
        {
            return objEjeSp.EjecSP("DEP_ListCtasParaGenEnv_SP", idTipoEnvioEstCta, nTipoGenEnv, nAnioMes);
        }
        public DataTable ADListEnvExtCtasCorreoIndividual(int nAnioMes, int idCliente)
        {
            return objEjeSp.EjecSP("DEP_ListCtasParaGenEnvIndividual_SP", nAnioMes, idCliente);
        }

        public DataTable ADInsExtCtasGenEnv(int idTipoEnvioEstCta, int nTipoGenEnv, int idCuenta, int idUsuario, string cPath, int nAnioMes, int lCorrecto, string cMsg)
        {
            return objEjeSp.EjecSP("DEP_RegExtCtasGenEnv_SP", idTipoEnvioEstCta, nTipoGenEnv, idCuenta, idUsuario, cPath, nAnioMes, lCorrecto, cMsg);
        }

        public DataTable ADObtenerHtmlPlanExtCtaCorreo()
        {
            return objEjeSp.EjecSP("DEP_ObtenerHtmlPlanExtCtaCorreo_SP");
        }
        public DataTable ADEnvioDeCorreos(int idCuenta,string idAnioMes,int idMes, string cCorreo, string cNombre)
        {
            return objEjeSp.EjecSP("DEP_EnvioEstCuenta_SP", idCuenta,idAnioMes,idMes,cCorreo,cNombre);
        }
    }
}
