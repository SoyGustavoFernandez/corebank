using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;
using EntityLayer;

namespace ADM.CapaNegocio
{
    public class clsCNAuthObjetoForm
    {
        clsADAuthObjetoForm objADAuthObjetoForm = new  clsADAuthObjetoForm();

        public DataTable listarAuthObjetoForm(int idSolicitud)
        {
            return objADAuthObjetoForm.listarAuthObjetoForm(
                clsVarGlobal.idMenu, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idEstablecimiento,
                clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario, idSolicitud);
        }
    }
}
