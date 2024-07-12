using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNPerfilUsu
    {
        #region Variables

        clsADPerfilUsu adperfilusu = new clsADPerfilUsu();

        #endregion

        public List<clsPerfilUsu> ListarPerUsu(int idUsuario)
        {
            return adperfilusu.ListarPerUsu(idUsuario);
        }

        public List<clsPerfil> ListarPerfiles()
        {
            return adperfilusu.ListarPerfil();           
        }
        public List<clsPerfil> listarPerfil(int idUsuario = 0, string cIdsPerfiles = "0")
        {
            return adperfilusu.listarPerfil(idUsuario, cIdsPerfiles);
        }

        public List<clsLimCobertura> limiteCobertura(int idTipResCaj, int idAgencia)
        {
            return adperfilusu.ListLimCober(idTipResCaj, idAgencia);
        }

        public DataTable ReportePerfilesPorUsuario(int idUsuario, DateTime dFecLimIni, DateTime dFecLimFin, int nVigente)
        {
            return adperfilusu.ReportePerfilesPorUsuario(idUsuario, dFecLimIni, dFecLimFin, nVigente);
        }

        public DataTable ReporteMenuPorPerfil(int idPerfil)
        {
            return adperfilusu.ReporteMenuPorPerfil(idPerfil);
        }

        public DataTable RetRespVentanilla(int idUsuario, DateTime dFecSis, int idAgencia)
        {
            return adperfilusu.RetRespVentanilla(idUsuario, dFecSis, idAgencia);
        }

        public List<clsPerfil> ListarPerfilRecuperadores()
        {
            return adperfilusu.ListarPerfilRecuperadores();       
        }
        public List<clsPerfil> buscarPerfil(string cValorBusqueda)
        {
            return this.adperfilusu.buscarPerfil(cValorBusqueda);
        }
        public DataTable CNListarPerfilOrdenadoAsc()
        {
            return adperfilusu.ADListarPerfilOrdenadoAsc();
        }
    }
}
