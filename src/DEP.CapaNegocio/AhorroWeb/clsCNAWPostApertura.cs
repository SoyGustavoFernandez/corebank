using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using DEP.AccesoDatos.AhorroWeb;
using System.Data;
using EntityLayer;

namespace DEP.CapaNegocio.AhorroWeb
{    
    public class clsCNAWPostApertura
    {
        #region Variables Privadas
        private clsADAWPostApertura objADAWPostApertura;
        #endregion

        #region Constructores
        public clsCNAWPostApertura(bool lConexion)
        {
            this.objADAWPostApertura = new clsADAWPostApertura(true);
        }

        public clsCNAWPostApertura()
        {
            this.objADAWPostApertura = new clsADAWPostApertura();
        }
        #endregion

        #region Métodos Públicos
        public clsAWDireccion obtenerDireccionPrincipal(int idCliente)
        {
            clsAWDireccion objAWDireccion = null;
            DataTable dt = this.objADAWPostApertura.obtenerDireccionPrincipal(idCliente);
            if (dt.Rows.Count == 1)
                objAWDireccion = dt.Rows[0].ToObject<clsAWDireccion>();
            return objAWDireccion;
        }

        public DataTable actualizarCliente(params object[] parametros)
        {
            return this.objADAWPostApertura.actualizarCliente(parametros);
        }

        public DataTable registrarRegularizacion(int idCuenta, clsAWTramite objAWTramite)
        {
            DataTable dt = this.objADAWPostApertura.registrarRegularizacion(
                idCuenta,                
                objAWTramite.idAgenciaRegulariza,
                objAWTramite.idUsuarioRegulariza,
                objAWTramite.dFechaRegulariza,
                objAWTramite.lIdentidadConfirmada,
                objAWTramite.lDatosRegularizados,
                objAWTramite.lDocumentosRegularizados
            );
            return dt;
        }
        #endregion
    }
}
