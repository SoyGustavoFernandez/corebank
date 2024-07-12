using EntityLayer;
using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADConfiguracionLimiteAprobacionExcepcion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarConfiguracionAprobacionLimiteExcep()
        {
            return objEjeSp.EjecSP("ADM_ObtenerConfigLimiteAprobacionExcepcion_SP");
        }

        public DataTable ADMantenimientoConfiguracionAprobaLimiteExcep(clsConfigAprobaLimiteExcepc _clsConfiguracionAprobaLimiteExcep)
        {
            return objEjeSp.EjecSP("ADM_MantenimientoConfigAprobaLimExcep_SP", _clsConfiguracionAprobaLimiteExcep.idConfigAproba, _clsConfiguracionAprobaLimiteExcep.idUsuario, _clsConfiguracionAprobaLimiteExcep.idPerfil,
                _clsConfiguracionAprobaLimiteExcep.idZona, _clsConfiguracionAprobaLimiteExcep.idAgencia,
                _clsConfiguracionAprobaLimiteExcep.lVigente, _clsConfiguracionAprobaLimiteExcep.nUsuReg);
        }

        public DataTable ADBuscarConfiguracionAprobaLimiteExcep(clsConfigAprobaLimiteExcepc _clsConfiguracionAprobaLimiteExcep)
        {
            return objEjeSp.EjecSP("ADM_BuscaConfigAprobaLimExcep_SP", _clsConfiguracionAprobaLimiteExcep.idPerfil, _clsConfiguracionAprobaLimiteExcep.idZona, _clsConfiguracionAprobaLimiteExcep.idAgencia,
                _clsConfiguracionAprobaLimiteExcep.idUsuario);
        }

        public DataTable ADBuscarUsuarioXUsuario(int codUser)
        {
            return objEjeSp.EjecSP("GEN_UsuarioxCodUser_SP", codUser);
        }
        public DataTable ADObtenerUsuario(int idCriteriobusqueda, string cValorIngresado)
        {
            return objEjeSp.EjecSP("GEN_BusUsuario_SP", idCriteriobusqueda, cValorIngresado);
        }

        public DataTable ValidarConfigAprobLimite(int idAgencia, string usuario, string cPerfil, int idZona, int nNuevo)
        {
            return objEjeSp.EjecSP("ADM_ObtenerValiacionAprobadoresConfig_SP", idAgencia, usuario, cPerfil, idZona, nNuevo);
        }
    }
}
