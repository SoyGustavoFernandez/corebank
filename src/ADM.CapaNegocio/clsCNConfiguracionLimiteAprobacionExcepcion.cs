using ADM.AccesoDatos;
using EntityLayer;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNConfiguracionLimiteAprobacionExcepcion
    {
        public clsADConfiguracionLimiteAprobacionExcepcion clsConfigAprobacionLimiteExcep = new clsADConfiguracionLimiteAprobacionExcepcion();

        public DataTable CNListarConfigAprobaLimiteExcep()
        {
            return clsConfigAprobacionLimiteExcep.ADListarConfiguracionAprobacionLimiteExcep();
        }

        public DataTable CNMantenimientoConfiguracionAprobaLimiteExcep(clsConfigAprobaLimiteExcepc _clsConfiguracionAprobaLimiteExcep)
        {
            return clsConfigAprobacionLimiteExcep.ADMantenimientoConfiguracionAprobaLimiteExcep(_clsConfiguracionAprobaLimiteExcep);
        }

        public DataTable CNBuscarConfiguracionAprobaLimiteExcep(clsConfigAprobaLimiteExcepc _clsConfiguracionAprobaLimiteExcep)
        {
            return clsConfigAprobacionLimiteExcep.ADBuscarConfiguracionAprobaLimiteExcep(_clsConfiguracionAprobaLimiteExcep);
        }
        public DataTable CNBuscarUsuarioXUsuario(int codUser)
        {
            return clsConfigAprobacionLimiteExcep.ADBuscarUsuarioXUsuario(codUser);
        }
        public DataTable CNObtenerUsuario(int idCriteriobusqueda, string cValorIngresado)
        {
            return clsConfigAprobacionLimiteExcep.ADObtenerUsuario(idCriteriobusqueda, cValorIngresado);
        }

        public DataTable ValidarConfigAprobLimite(int idAgencia, string usuario, string cPerfil, int idZona,int nNuevo)
        {
            return clsConfigAprobacionLimiteExcep.ValidarConfigAprobLimite(idAgencia, usuario, cPerfil, idZona, nNuevo);
        }
    }
}
