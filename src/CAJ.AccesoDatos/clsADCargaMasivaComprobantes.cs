using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CAJ.AccesoDatos
{
    public class clsADCargaMasivaComprobantes
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet ADObtieneConfiguracionPlantilla(int idTipoComp)
        {
            return objEjeSp.DSEjecSP("CAJ_ObtenerPlantillaComprobantes_SP", idTipoComp);
        }

        public DataTable ADGuardaComprobantesCargaMasiva(string xmlDatos)
        {
            return objEjeSp.EjecSP("CAJ_GuardaComprobantesCargaMasiva_SP", xmlDatos, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }

        public DataTable ADValidacionesEspecialesCargaMasiva()
        {
            return objEjeSp.EjecSP("CAJ_ValidacionesEspecialesCargaMasiva_SP");
        }
    }
}
