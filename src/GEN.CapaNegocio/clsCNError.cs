using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNError
    {
        public bool RegistrarError(Error error)
        {
            bool lEstado = false;
            clsADError errorData = new clsADError();
            try
            {
                errorData.RegistrarError(error);
                lEstado = true;
                return lEstado;
            }
            catch (Exception ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
               && ex.Source == ".Net SqlClient Data Provider")
                {
                    System.Windows.Forms.MessageBox.Show("Error de conexión con el servidor de base de datos" + "\n" + innerexeption);
                }
                else
                {
                    throw ex;
                }
                return false;
            }
        }
    }
}
