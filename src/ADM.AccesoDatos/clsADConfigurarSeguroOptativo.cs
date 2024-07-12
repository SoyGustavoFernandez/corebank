using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.AccesoDatos
{
    public class clsADConfigurarSeguroOptativo
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListaSeguroOptativo()
        {
            return objEjeSp.EjecSP("ADM_ListarSeguroOptativo_SP");
        }
        public DataTable ADMantenimientoSeguroOptativo(int idTipoSeguro, string cTipoSeguro, decimal nValor, int idTipoValSegOptativo, int idConcepto, int idTipoPagoSeguroOptativo, bool lvigente, int idUsuario)
        {
            return objEjeSp.EjecSP("ADM_MantenimientoSegOptativo_SP", idTipoSeguro, cTipoSeguro, nValor, idTipoValSegOptativo, idConcepto, idTipoPagoSeguroOptativo, lvigente, idUsuario);
        }
        public DataTable ADListarTipValSegOpt()
        {
            return objEjeSp.EjecSP("ADM_LisTipValSegOptativo_SP");
        }
        public DataTable ADListarConceptoRecibo()
        {
            return objEjeSp.EjecSP("ADM_ListarConceptpRec_SP");
        }
        public DataTable ADListarTipPagSegOpt()
        {
            return objEjeSp.EjecSP("ADM_LisTipPagoSegOptativo_SP");
        }
        public DataTable ADListarSubProSegOptConfig(int idSeguro)
        {
            return objEjeSp.EjecSP("ADM_ListarSubProSegOptConfig_SP", idSeguro);
        }
        public DataTable ADAgregarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_AgregarSubProSegOptConfig_SP", idSeguro, idSubProducto, idUsuario, lAutorizado);
        }
        public DataTable ADEliminarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuMod)
        {
            return objEjeSp.EjecSP("ADM_EliminarSubProSegOptConfig_SP", idSeguro, idSubProducto, idUsuMod);
        }
        public DataTable ADEditarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_EditarSubProSegOptConfig_SP", idSeguro, idSubProducto, idUsuario, lAutorizado);
        }
        public DataTable ADListarPefilSegOptConfig(int idSeguro)
        {
            return objEjeSp.EjecSP("ADM_ListarPerfilSegOptConfig_SP", idSeguro);
        }
        public DataTable ADAgregarPefilSegOptConfig(int idTipoSeguro, int idPerfil, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_AgregarPerfilSegOptConfig_SP", idTipoSeguro, idPerfil, idUsuario, lAutorizado);
        }
        public DataTable ADEliminarPefilSegOptConfig(int idSeguro, int idPerfil, int idUsuario)
        {
            return objEjeSp.EjecSP("ADM_EliminarPefilSegOptConfig_SP", idSeguro, idPerfil, idUsuario);
        }
        public DataTable ADEditarPefilSegOptConfig(int idTipoSeguro, int idPerfil, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_EditarPerfilSegOptConfig_SP", idTipoSeguro, idPerfil, idUsuario, lAutorizado);
        }
        public DataTable ADListarOficinaSegOptConfig(int idSeguro)
        {
            return objEjeSp.EjecSP("ADM_ListarOficinaSegOptConfig_SP", idSeguro);
        }
        public DataTable ADAgregarOficinaSegOptConfig(int idSeguro, int idOficina, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_AgregarOficinaSegOptConfig_SP", idSeguro, idOficina, idUsuario, lAutorizado);
        }
        public DataTable ADEliminarOficinaSegOptConfig(int idSeguro, int idOficina, int idUsuario)
        {
            return objEjeSp.EjecSP("ADM_EliminarOficinaSegOptConfig_SP", idSeguro, idOficina, idUsuario);
        }
        public DataTable ADEditarOficinaSegOptConfig(int idTipoSeguro, int idAgencia, int idUsuario, bool lAutorizado)
        {
            return objEjeSp.EjecSP("ADM_EditarAgenciaSegOptConfig_SP", idTipoSeguro, idAgencia, idUsuario, lAutorizado);
        }
        public DataTable ADListaPlanSeguro(int idTipoSeguro)
        {
            return objEjeSp.EjecSP("ADM_LisPlanSeguro_SP", idTipoSeguro);
        }
    }
}
