using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNConfigurarSeguroOptativo
    {
        public clsADConfigurarSeguroOptativo clsSeguroOptativo = new clsADConfigurarSeguroOptativo();

        public DataTable CNListaSeguroOptativo()
        {
            return clsSeguroOptativo.ADListaSeguroOptativo();
        }
        public DataTable CNMantenimientoSeguroOptativo(int idTipoSeguro, string cTipoSeguro, decimal nValor, int idTipoValSegOptativo, int idConcepto, int idTipoPagoSeguroOptativo, bool lvigente, int idUsuario)
        {
            return clsSeguroOptativo.ADMantenimientoSeguroOptativo(idTipoSeguro, cTipoSeguro, nValor, idTipoValSegOptativo, idConcepto, idTipoPagoSeguroOptativo, lvigente, idUsuario);
        }
        public DataTable CNListarTipValSegOpt()
        {
            return clsSeguroOptativo.ADListarTipValSegOpt();
        }
        public DataTable CNListarConceptoRecibo()
        {
            return clsSeguroOptativo.ADListarConceptoRecibo();
        }
        public DataTable CNListarTipPagSegOpt()
        {
            return clsSeguroOptativo.ADListarTipPagSegOpt();
        }
        public DataTable CNListarSubProSegOptConfig(int idSeguro)
        {
            return clsSeguroOptativo.ADListarSubProSegOptConfig(idSeguro);
        }
        public DataTable CNAgregarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADAgregarSubProSegOptConfig(idSeguro, idSubProducto, idUsuario, lAutorizado);
        }
        public DataTable CNEliminarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuMod)
        {
            return clsSeguroOptativo.ADEliminarSubProSegOptConfig(idSeguro, idSubProducto, idUsuMod);
        }
        public DataTable CNEditarSubProSegOptConfig(int idSeguro, int idSubProducto, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADEditarSubProSegOptConfig(idSeguro, idSubProducto, idUsuario, lAutorizado);
        }
        public DataTable CNListarPefilProSegOptConfig(int idSeguro)
        {
            return clsSeguroOptativo.ADListarPefilSegOptConfig(idSeguro);
        }
        public DataTable CNAgregarPefilProSegOptConfig(int idTipoSeguro, int idPerfil, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADAgregarPefilSegOptConfig(idTipoSeguro, idPerfil, idUsuario, lAutorizado);
        }
        public DataTable CNEliminarPefilProSegOptConfig(int idSeguro, int idPerfil, int idUsuario)
        {
            return clsSeguroOptativo.ADEliminarPefilSegOptConfig(idSeguro, idPerfil, idUsuario);
        }
        public DataTable CNEditarPefilProSegOptConfig(int idTipoSeguro, int idPerfil, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADEditarPefilSegOptConfig(idTipoSeguro, idPerfil, idUsuario, lAutorizado);
        }
        public DataTable CNListarOficinaProSegOptConfig(int idSeguro)
        {
            return clsSeguroOptativo.ADListarOficinaSegOptConfig(idSeguro);
        }
        public DataTable CNAgregarOficinaProSegOptConfig(int idSeguro, int idOficina, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADAgregarOficinaSegOptConfig(idSeguro, idOficina, idUsuario, lAutorizado);
        }
        public DataTable CNEliminarOficinaProSegOptConfig(int idSeguro, int idOficina, int idUsuario)
        {
            return clsSeguroOptativo.ADEliminarOficinaSegOptConfig(idSeguro, idOficina, idUsuario);
        }
        public DataTable CNEditarOficinaProSegOptConfig(int idTipoSeguro, int idAgencia, int idUsuario, bool lAutorizado)
        {
            return clsSeguroOptativo.ADEditarOficinaSegOptConfig(idTipoSeguro, idAgencia, idUsuario, lAutorizado);
        }
        public DataTable CNListaPlanSeguro(int idTipoSeguro)
        {
            return clsSeguroOptativo.ADListaPlanSeguro(idTipoSeguro);
        }
    }
}
