using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;

namespace ADM.AccesoDatos
{
    public class clsADMantmtoAprobacionGen
    {
        private clsGENEjeSP objGENEjeSP;
        public clsADMantmtoAprobacionGen()
        {
            this.objGENEjeSP = new clsGENEjeSP();
        }

        public List<clsAprobacionCanal> listarAprobacionCanal()
        {
            DataTable dtAprobacionCanal = this.objGENEjeSP.EjecSP("ADM_ListarAprobacionCanal_SP");

            return (dtAprobacionCanal.Rows.Count > 0) ? dtAprobacionCanal.ToList<clsAprobacionCanal>() as List<clsAprobacionCanal> :
                new List<clsAprobacionCanal>();
        }
        public clsRespuestaServidor grabarAprobacionCanal(string xmlAprobacionCanal)
        {
            DataTable dtResultado = this.objGENEjeSP.EjecSP("ADM_GrabarAprobacionCanal_SP", xmlAprobacionCanal);
            return (dtResultado.Rows.Count > 0) ? dtResultado.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public List<clsAprobacionSolicitudTipo> listarAprobacionSolTipo()
        {
            DataTable dtAprobacionSolTipo = this.objGENEjeSP.EjecSP("ADM_ListarAprobacionSolTipo_SP");

            return (dtAprobacionSolTipo.Rows.Count > 0) ? dtAprobacionSolTipo.ToList<clsAprobacionSolicitudTipo>() as List<clsAprobacionSolicitudTipo> :
                new List<clsAprobacionSolicitudTipo>();
        }
        public clsRespuestaServidor grabarAprobacionSolTipo(string xmlAprobacionSolTipo)
        {
            DataTable dtResultado = this.objGENEjeSP.EjecSP("ADM_GrabarAprobacionSolTipo_SP", xmlAprobacionSolTipo);
            return (dtResultado.Rows.Count > 0) ? dtResultado.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public List<clsAprobacionNivel> listarAprobacionNivel(int idAprobacionCanal)
        {
            DataTable dtAprobacionNivel = this.objGENEjeSP.EjecSP("ADM_ListarAprobacionNivel_SP", idAprobacionCanal);

            return (dtAprobacionNivel.Rows.Count>0)? dtAprobacionNivel.ToList<clsAprobacionNivel>() as List<clsAprobacionNivel>:
                new List<clsAprobacionNivel>();
        }
        public clsRespuestaServidor grabarAprobacionNivel(string xmlAprobacionNivel)
        {
            DataTable dtResultado = this.objGENEjeSP.EjecSP("ADM_GrabarAprobacionNivel_SP", xmlAprobacionNivel);
            return (dtResultado.Rows.Count > 0) ? dtResultado.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public List<clsPerfil> listarPerfilAprobador(int idAprobacionNivel)
        {
            DataTable dtPerfil = this.objGENEjeSP.EjecSP("ADM_ListarPerfilAprobador_SP", idAprobacionNivel);

            return (dtPerfil.Rows.Count > 0) ? dtPerfil.ToList<clsPerfil>() as List<clsPerfil> :
                new List<clsPerfil>();
        }
    }
}
