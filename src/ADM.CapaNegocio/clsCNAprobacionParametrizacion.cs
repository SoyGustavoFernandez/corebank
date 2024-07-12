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
    public class clsCNAprobacionParametrizacion
    {
        private clsADAprobacionParametrizacion objADAproParametrizacion;
        public clsCNAprobacionParametrizacion()
        {
            this.objADAproParametrizacion = new clsADAprobacionParametrizacion();
        }

        public List<clsAprobacionAutonomiaUsuario> listarAproAutonomiaUsuario()
        {
            return this.objADAproParametrizacion.listarAproAutonomiaUsuario();
        }
        public clsRespuestaServidor grabarAproAutonomiaUsuario(clsAprobacionAutonomiaUsuario objAproAutonomiaUsuario)
        {
            return this.objADAproParametrizacion.grabarAproAutonomiaUsuario(objAproAutonomiaUsuario, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public clsRespuestaServidor gestionarAproAutonomiaUsuario(int idAprobacionAutonomiaUsuario, int idEstado)
        {
            return this.objADAproParametrizacion.gestionarAproAutonomiaUsuario(idAprobacionAutonomiaUsuario, idEstado, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public DataTable generarReporteHistAproAutoUsu()
        {
            return this.objADAproParametrizacion.generarReporteHistAproAutoUsu();
        }
    }
}
