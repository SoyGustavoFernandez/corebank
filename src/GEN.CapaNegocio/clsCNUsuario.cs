using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Windows.Forms;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNUsuario
    {
        public bool ValidarUsuario(string x_User)
        {
            bool lEstado = false;
            clsUsuario lUser = new clsUsuario();
            try
            {
                lUser = new clsADUsuario().ValidarLogin(x_User);
                if (lUser.cWinUser != null)
                {
                    //new clsADVarGen().Listar();
                    lEstado = true;
                    clsVarGlobal.User = lUser;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lEstado;
        }

        public bool ValidarUsuario(string x_User,ref clsUsuario user)
        {
            bool lEstado = false;
            try
            {
                user = new clsADUsuario().ValidarLogin(x_User);
                if (user.cWinUser != null)
                {
                    lEstado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lEstado;
        }

        public bool ValidarUsuarioWCF(string x_User, ref clsUsuario user)
        {
            bool lEstado = false;
            try
            {
                user = new clsADUsuario().ValidarLoginWCF(x_User);
                if (user.cWinUser != null)
                {
                    lEstado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lEstado;
        }

        public clsUsuario SeleccionarDatUsu(string x_User)
        {
            return new clsADUsuario().ValidarLogin(x_User);
        }

        public bool ChangePassword(string cUsu, string cPassOld, string cPassNew, string cPassNewCon)
        {            
            if (cPassNewCon == cPassNew)
	        {
                DataTable dt = new clsADUsuario().ChangePassword(cUsu, cPassOld, cPassNew);
                if (dt.Rows[0]["idError"].ToString() == "0")
                {                    
                    MessageBox.Show("Cambio de contraseña realizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else if (dt.Rows[0]["idError"].ToString() == "15114")
                {
                    MessageBox.Show("La contraseña para el usuario es demasiado reciente para cambiarla.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (dt.Rows[0]["idError"].ToString() == "15115")
                {
                    MessageBox.Show("La contraseña ya fué utilizada anteriormente.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (dt.Rows[0]["idError"].ToString() == "15116")
                {
                    MessageBox.Show("La contraseña no cumple con los requisitos, es demasiado corta.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (dt.Rows[0]["idError"].ToString() == "15117")
                {
                    MessageBox.Show("La contraseña no cumple con los requisitos, es demasiado larga.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (dt.Rows[0]["idError"].ToString() == "15118")
                {
                    MessageBox.Show("La contraseña no cumple con los requisitos, no es lo suficientemente compleja.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (dt.Rows[0]["idError"].ToString() == "15119")
                {
                    MessageBox.Show("La contraseña no cumple los requisitos de la DLL de filtro de contraseña.", "Validación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else
                    MessageBox.Show("Error al cambiar de contraseña: " + dt.Rows[0]["cError"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                       
	        }
            else
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        public bool ValidarUsuarioGen(string x_User)
        {
            bool lEstado = false;
            clsUsuario lUser = new clsUsuario();
            try
            {
                lUser = new clsADUsuario().ValidarLogin(x_User);
                if (lUser.cWinUser != null)
                {
                    lEstado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lEstado;
        }

        ///// <summary>
        ///// Método que valida si el usuario tiene mas de un perfil
        ///// </summary>
        ///// <returns>o-->tiene un perfil, 1--> tiene mas de un perfil</returns>
        //private int LisPerfil()
        //{
        //    try
        //    {
        //        PerfilUsuarioBLL LisPerBllSir = new PerfilUsuarioBLL();
        //        List<PerfilUsuario> itemsPerUsu = new List<PerfilUsuario>();
        //        itemsPerUsu = LisPerBllSir.ListarPerUsu(Usuario.CodPerson, ((Empresa)cboEmpresa.SelectedItem).nIDEmpresa);
        //        int nCanPer = itemsPerUsu.Count;
        //        if (nCanPer == 1)
        //        {
        //            gCodPerfil = itemsPerUsu[0].cCodPerfil;
        //            GEN.EntityService.VariableGlobal.lAdm = itemsPerUsu[0].lAdm;
        //        }
        //        return itemsPerUsu.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable listarUsuarioSupervisores()
        {
            return new clsADUsuario().listarUsuarioSupervisores();
        }

        public DataTable ObtenerZonasUsuario(int idUsuario)
        {
            return new clsADUsuario().ObtenerZonasUsuario(idUsuario);
        }

        public DataTable agregarZona(int idUsuario, int idZona, int idUsuReg)
        {
            return new clsADUsuario().agregarZona(idUsuario, idZona, idUsuReg);
        }

        public DataTable quitarZona(int idZonaUsuario, int idUsuReg)
        {
            return new clsADUsuario().quitarZona(idZonaUsuario, idUsuReg);
        }

        //public void ValidarUsuarioClone(string x_User)
        //{
        //    bool lEstado = false;
        //    clsUsuario lUser = new clsUsuario();
        //    try
        //    {
        //        lUser = new clsADUsuario().ValidarLogin(x_User);
        //        if (lUser.cWinUser != null)
        //        {
        //            //new clsADVarGen().Listar();
        //            lEstado = true;
        //            clsVarGlobalClone.User = lUser;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return lEstado;
        //}

        public DataTable ObtenerDatosClienteBiometrico(int idCliente)
        {
            return new clsADUsuario().ObtenerDatosClienteBiometrico(idCliente);
        }
    }
}
