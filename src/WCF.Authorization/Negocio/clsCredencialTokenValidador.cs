using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WCF.Authorization.Modelo;

namespace WCF.Authorization.Negocio
{
    public class clsCredencialTokenValidador
    {
        clsCNCredencialTokenValidador objCreTokenVal;

        public clsCredencialTokenValidador()
        {
            this.objCreTokenVal = new clsCNCredencialTokenValidador(true);            
        }

        private clsUsuario ObtenerUsuarioValido(string cUsuario, string cPassword)
        {
            string tmp = ComputeSha256Hash(cPassword);
            DataTable dtUsuarioAuth = this.objCreTokenVal.CNValidarCredenciales(cUsuario, ComputeSha256Hash(cPassword), 2); //2 por ser Call Center

            if (dtUsuarioAuth.Rows.Count > 0)
            {
                clsUsuario objUsuario = new clsUsuario();
                objUsuario.idPDPUsuarioAuth = Convert.ToInt32(dtUsuarioAuth.Rows[0]["idAPIUsuarioAuth"].ToString());
                objUsuario.cUsuario = Convert.ToString(dtUsuarioAuth.Rows[0]["cUsuario"].ToString());                
                objUsuario.cSalt = Convert.ToString(dtUsuarioAuth.Rows[0]["cSalt"].ToString());
                objUsuario.dFecReg = Convert.ToDateTime(dtUsuarioAuth.Rows[0]["dFecReg"].ToString());                

                return objUsuario;
            }
            else
            {
                return null;
            }            
        }

        public bool UsuarioValido(clsCredencial objCredencial)
        {
            clsUsuario objUsuario = this.ObtenerUsuarioValido(objCredencial.cUsuario, objCredencial.cPassword);

            if (objUsuario == null)
	        {
		        return false;    
	        }

            return true;            
        }

        public bool UsuarioValido(ref clsUsuario objUsuario, clsCredencial objCredencial)
        {
            clsUsuario objUsuarioTemp = this.ObtenerUsuarioValido(objCredencial.cUsuario, objCredencial.cPassword);

            if (objUsuarioTemp == null)
            {
                return false;
            }

            objUsuario = objUsuarioTemp;
            return true;
        }

        static string ComputeSha256Hash(string cCadena)
        {            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cCadena));
                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().ToUpper();
            }
        }
    }
}