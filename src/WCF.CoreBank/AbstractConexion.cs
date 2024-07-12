using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Interface;
using EntityLayer;
using GEN.CapaNegocio;
using SolIntEls.GEN.Helper;

namespace WCF.CoreBank
{
    public class AbstractConexion : IntConexionWebService
    {
        private clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();


        public void setConectionString()
        {
            clsEnvironment objEnviroment = new clsEnvironment();
            clsConexionWcf objCon = objEnviroment.CargarArchivoEnvironment();

            String cCadenaConexion = objCon.obtenerConexionSegunda();
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["cConectionString"]))
                HttpContext.Current.Session["cConectionString"] = cCadenaConexion;

        }

        public clsWCFUsuario IdentificarUsuario(clsWCFUsuario objWCFUsuario)
        {
            return new clsWCFUsuario();
        }

        public clsCNUsuarioSistema getUsuario()
        {
            return this.usuario;
        }
    }
}