using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Web;
using WCF.Authorization.Modelo;

namespace WCF.Authorization.Negocio
{
    public class clsTokenGenerador
    {
        clsCNCredencialTokenValidador objCreTokenVal;        
        public static int nTokenTamanio = 100;

        public clsTokenGenerador()
        {
            this.objCreTokenVal = new clsCNCredencialTokenValidador(true);
        }
        
        private void GuardaToken(int idPDPUsuarioAuth, string cToken)
        {
            this.objCreTokenVal.CNGuardarToken(idPDPUsuarioAuth, cToken);            
        }

        public string GeneraToken(clsCredencial objCredencial)
        {            
            clsUsuario objUsuario = new clsUsuario();

            if (!new clsCredencialTokenValidador().UsuarioValido(ref objUsuario, objCredencial))
            {
                throw new AuthenticationException();
            }

            int idPDPUsuarioAuth = objUsuario.idPDPUsuarioAuth;
            string cToken = this.GeneraTokenSeguro(nTokenTamanio);

            this.GuardaToken(idPDPUsuarioAuth, cToken);
            
            return cToken;
        }

        private string GeneraTokenSeguro(int nTokenTamanio)
        {
            var buffer = new byte[nTokenTamanio];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}