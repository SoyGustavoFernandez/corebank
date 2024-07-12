using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WCF.Authorization.Modelo;

namespace WCF.Authorization.Negocio
{
    public class clsTokenValidador
    {
        clsCNCredencialTokenValidador objCreTokenVal;
        public static int DefaultMinutesUntilTokenExpires = 1440;

        public clsTokenValidador()
        {
            this.objCreTokenVal = new clsCNCredencialTokenValidador(true);            
        }
        
        private clsToken ObtenerTokenValido(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            DataTable dtTokenAuth = this.objCreTokenVal.CNValidarToken(idAPIUsuarioAuth, idApiEmpresa, cToken);

            if (dtTokenAuth.Rows.Count > 0)
            {
                clsToken objToken = new clsToken();                
                objToken.idPDPUsuarioAuth = Convert.ToInt32(dtTokenAuth.Rows[0]["idAPIUsuarioAuth"].ToString());
                objToken.cToken = Convert.ToString(dtTokenAuth.Rows[0]["cToken"].ToString());
                objToken.dFecCrea = Convert.ToDateTime(dtTokenAuth.Rows[0]["dFecCrea"].ToString());                

                return objToken;
            }
            else
            {
                return null;
            }            
        }

        public bool TokenValido(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            clsToken objToken = this.ObtenerTokenValido(idAPIUsuarioAuth, idApiEmpresa, cToken);

            if (objToken == null)
	        {
		        return false;    
	        }

            if (TokenExpirado(objToken))
            {
                return false;
            }

            return true;            
        }

        public bool TokenValido(ref clsToken objToken, int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            clsToken objTokenTemp = this.ObtenerTokenValido(idAPIUsuarioAuth, idApiEmpresa, cToken);

            if (objTokenTemp == null)
            {
                return false;
            }

            if (TokenExpirado(objTokenTemp))
            {
                return false;
            }

            objToken = objTokenTemp;
            return true; 
        }

        internal bool TokenExpirado(clsToken objTokenAuth)
        {
            var dFecDif = DateTime.Now - objTokenAuth.dFecCrea;
            return (dFecDif.TotalMinutes > DefaultMinutesUntilTokenExpires);
        }
    }
}