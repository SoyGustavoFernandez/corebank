using GEN.WCFLogistica.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using clsWCFUsuario_R = WCFLogistica.EntityLayer.clsWCFUsuario;

namespace WCF.Logistica.Services
{
    public class Autenticacion : AbstractConexion, IAutenticacion
    {
        #region propiedades privadas
        clsCNWCFAutenticacion cnWCFAutenticacion;
        #endregion        

        public Autenticacion()
        {
            this.cnWCFAutenticacion = new clsCNWCFAutenticacion();
        }

        public clsWCFUsuario_R IdentificarUsuario(clsWCFUsuario_R objWCFUsuario)
        {
            return this.cnWCFAutenticacion.identificarUsuario(objWCFUsuario);
        }

        public clsWCFUsuario_R IniciarSesion(clsWCFUsuario_R objWCFUsuario)
        {
            return this.cnWCFAutenticacion.iniciarSesion(objWCFUsuario);
        }

        public bool ValidarToken()
        {
            return this.cnWCFAutenticacion.validarToken(this.getToken());
        }

        public clsWCFUsuario_R ObtenerDatosUsuario()
        {
            if (!this.cnWCFAutenticacion.validarToken(this.getToken()))
                return null;
            return this.cnWCFAutenticacion.obtenerDatosUsuario(this.getToken());
        }
    }
}
