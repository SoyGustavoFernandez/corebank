using EntityLayer;
using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using System.Xml.Serialization;
using System.IO;

namespace RCP.CapaNegocio
{
    public class clsCNRecuperador
    {
        clsADRecuperador adRecuperador = new clsADRecuperador();
        
        public DataTable ListarUsuariosRecuperaciones()
        {
            return adRecuperador.ListarUsuariosRecuperaciones();
        }

        public DataTable ListarUsuariosRecuperacionesYLegal()
        {
            return adRecuperador.ListarUsuariosRecuperacionesYLegal();
        }

        public DataTable ListarUsuariosRecuperacionesYLegalUnicos()
        {
            return adRecuperador.ListarUsuariosRecuperacionesYLegalUnicos();
        }

        public DataTable ListarUsuariosSupervisados(int idUsuarioSupervisor)
        {
            return adRecuperador.ListarUsuariosSupervisados(idUsuarioSupervisor);
        }

        public DataTable ListarGestoresLegalesTodos()
        {
            return adRecuperador.ListarGestoresLegalesTodos();
        }

        public List<clsGestorRecuperacion> LstGestRecuperaEstablecimiento()
        {
            DataTable dtGestorRecuperacion = adRecuperador.LstGestRecuperaEstablecimiento();
            return (dtGestorRecuperacion.Rows.Count > 0) ?
                DataTableToList.ConvertTo<clsGestorRecuperacion>(dtGestorRecuperacion) as List<clsGestorRecuperacion> :
                new List<clsGestorRecuperacion>();
        }

        public List<clsAgenciaEstablecimiento> ListarRegionAgenciaEstabs(int idRegion)
        {
            DataTable dtAgenciaEstablecimiento = adRecuperador.ListarRegionAgenciaEstabs(idRegion);
            return (dtAgenciaEstablecimiento.Rows.Count > 0) ?
                DataTableToList.ConvertTo<clsAgenciaEstablecimiento>(dtAgenciaEstablecimiento) as List<clsAgenciaEstablecimiento> :
                new List<clsAgenciaEstablecimiento>();
        }
        public DataTable listarRegionAgenciaEstabs(int idRegion)
        {
            return adRecuperador.ListarRegionAgenciaEstabs(idRegion);
        }

        public List<clsEstablecimientoGestorRecuperacion> ListarEstablecGestorRecuperacion()
        {
            DataTable dtEstabGestorRecuperacion = adRecuperador.ListarEstablecGestorRecuperacion();
            return (dtEstabGestorRecuperacion.Rows.Count > 0) ?
                DataTableToList.ConvertTo<clsEstablecimientoGestorRecuperacion>(dtEstabGestorRecuperacion) as List<clsEstablecimientoGestorRecuperacion> :
                new List<clsEstablecimientoGestorRecuperacion>();
        }

        public DataTable GrabarEstablecGestorRecuperacion(List<clsEstablecimientoGestorRecuperacion> lstEstabGestorRecuperacion)
        {
            string xmlEstablecGesRecuperacion = lstEstabGestorRecuperacion.ListObjectToXml("EstabRecuperador", "EstabRecuperadores");
            return adRecuperador.GrabarEstablecGestorRecuperacion(clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlEstablecGesRecuperacion);
        }
    }
}
