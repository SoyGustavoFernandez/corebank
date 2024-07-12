using DEP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.CapaNegocio
{
    public class clsCNEnvExtCtas
    {
        public clsADEnvExtCtas ObjEnvExtCtas = new clsADEnvExtCtas();

        public DataTable CNListEnvExtCtasCorreo(int idTipoEnvioEstCta, int nTipoGenEnv, int nAnioMes)
        {
            return ObjEnvExtCtas.ADListEnvExtCtasCorreo(idTipoEnvioEstCta, nTipoGenEnv, nAnioMes);            
        }
        public DataTable CNListEnvExtCtasCorreoIndividual(int nAnioMes, int idCliente)
        {
            return ObjEnvExtCtas.ADListEnvExtCtasCorreoIndividual(nAnioMes, idCliente);
        }

        public DataTable CNInsExtCtasGenEnv(int idTipoEnvioEstCta, int nTipoGenEnv, int idCuenta, int idUsuario, string cPath, int nAnioMes, int lCorrecto, string cMsg)
        {
            return ObjEnvExtCtas.ADInsExtCtasGenEnv(idTipoEnvioEstCta, nTipoGenEnv, idCuenta, idUsuario, cPath, nAnioMes, lCorrecto, cMsg);
        }

        public DataTable CNObtenerHtmlPlanExtCtaCorreo()
        {
            return ObjEnvExtCtas.ADObtenerHtmlPlanExtCtaCorreo();
        }
        public DataTable CNEnvioDeCorreos(int idCuenta,string idAnioMes,int idMes, string cCorreo, string cNombre)
        {
            return ObjEnvExtCtas.ADEnvioDeCorreos(idCuenta,idAnioMes,idMes,cCorreo,cNombre);
        }
    }
}
