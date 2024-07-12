using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCP.AccesoDatos;
using GEN.Funciones;
using System.Data;

using EntityLayer;
namespace RCP.CapaNegocio
{
    public class clsCNRecuperacionComision
    {
        private clsADRecuperacionComision objADRecuperacionComision =  new clsADRecuperacionComision();

        public DataTable ListarRecuperacionComisionTipo()
        {
            return this.objADRecuperacionComision.ListarRecuperacionComisionTipo();
        }
        public List<clsRecuperacionComisionDetalle> listarRecuperacionComision(int idRecuperacionComisionTipo, DateTime dFecha)
        {
            DataTable dtRecuperacionComision = objADRecuperacionComision.listarRecuperacionComision(idRecuperacionComisionTipo, dFecha);
            return (dtRecuperacionComision.Rows.Count > 0) ?
                dtRecuperacionComision.ToList<clsRecuperacionComisionDetalle>() as List<clsRecuperacionComisionDetalle> :
                new List<clsRecuperacionComisionDetalle>();
        }

        public DataTable grabarRecuperacionComision(int idRecuperacionComisionTipo, DateTime dFecha, List<clsRecuperacionComision> lstRecuperacioncomision)
        {
            string xmlRecuperacionComision = string.Empty;
            xmlRecuperacionComision = lstRecuperacioncomision.ListObjectToXml<clsRecuperacionComision>("Comision", "Comisiones");

            return objADRecuperacionComision.grabarRecuperacionComision(idRecuperacionComisionTipo, clsVarGlobal.User.idUsuario, dFecha,  xmlRecuperacionComision);
        }

        public List<clsMetaReduccionSaldoVencido> listarMetaReduccionSaldoVencido(int nAnio, int nMes)
        {
            DataTable dtMeta = objADRecuperacionComision.listarMetaReduccionSaldoVencido(nAnio, nMes);

            return (dtMeta.Rows.Count > 0)?
                dtMeta.ToList<clsMetaReduccionSaldoVencido>() as List<clsMetaReduccionSaldoVencido> :
                new List<clsMetaReduccionSaldoVencido>();
        }

        public DataTable grabarMetaReduccionSaldoVencido(List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencido)
        {
            string xmlMetaReducSaldoVencido;

            xmlMetaReducSaldoVencido = lstMetaReduccionSaldoVencido.ListObjectToXml("Meta", "Metas");
            return objADRecuperacionComision.grabarMetaReduccionSaldoVencido( clsVarGlobal.User.idUsuario, xmlMetaReducSaldoVencido);
        }

        public List<clsRecuperacionCondonacionLimite> listarRecuperacionCondonacionLimite(int nAnio, int nMes)
        {
            DataTable dtLimite = objADRecuperacionComision.listarRecuperacionCondonacionLimite(nAnio, nMes);
            return (dtLimite.Rows.Count > 0) ? dtLimite.ToList<clsRecuperacionCondonacionLimite>() as List<clsRecuperacionCondonacionLimite> :
                new List<clsRecuperacionCondonacionLimite>();
        }

        public DataTable grabarRecuperacionCondonacionLimite(List<clsRecuperacionCondonacionLimite> lstRecuperacionCondonacionLimite)
        {
            string xmlRecuperacionCondonacionLimite;

            xmlRecuperacionCondonacionLimite = lstRecuperacionCondonacionLimite.ListObjectToXml("Limite", "Limites");
            return objADRecuperacionComision.grabarRecuperacionCondonacionLimite(clsVarGlobal.User.idUsuario, xmlRecuperacionCondonacionLimite);
        }

        public List<clsGrabadoRecupComision> revisarGrabadoRecuperacionComision(DateTime dFecha)
        {
            DataTable dtGrabadoRecup = objADRecuperacionComision.revisarGrabadoRecuperacionComision(dFecha);
            return (dtGrabadoRecup.Rows.Count > 0)?
                dtGrabadoRecup.ToList<clsGrabadoRecupComision>() as List<clsGrabadoRecupComision>:
                new List<clsGrabadoRecupComision>();
        }

        public DataTable grabarAproSolicitudRecComision( DateTime dFechaComision, decimal nMontoComision)
        {
            return objADRecuperacionComision.grabarAproSolicitudRecComision( clsVarGlobal.dFecSystem, dFechaComision, nMontoComision, clsVarGlobal.User.idUsuario);
        }

        public List<clsAproSolicitudRecComision> listarAproSolicitudRecComision()
        {
            DataTable dtAproSolicitudRecComision = objADRecuperacionComision.listarAproSolicitudRecComision(clsVarGlobal.PerfilUsu.idPerfil);
            return (dtAproSolicitudRecComision.Rows.Count > 0) ?
                dtAproSolicitudRecComision.ToList<clsAproSolicitudRecComision>() as List<clsAproSolicitudRecComision> :
                new List<clsAproSolicitudRecComision>();
        }
        public DataTable gestionarAprobacionRecuperacionComision(int idNivelAprobacion)
        {
            return objADRecuperacionComision.gestionarAprobacionRecuperacionComision(idNivelAprobacion, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public DataTable grabarResolucionAproSolRecComision(int idAproSolicitudRecComision, int idEstado,int idNivelAprobacion, int idNivelAprobacionSig,
            decimal nMontoComision, DateTime dFechaComision, string cComentario)
        {
            return objADRecuperacionComision.grabarResolucionAproSolRecComision(idAproSolicitudRecComision, idEstado,idNivelAprobacion, idNivelAprobacionSig, clsVarGlobal.User.idUsuario,
                nMontoComision, dFechaComision, cComentario);
        }
        public DataTable calcularRecuperacionComisionMora()
        {
            return objADRecuperacionComision.calcularRecuperacionComisionMora(clsVarGlobal.dFecSystem);
        }
        public DataSet recuperacionComisionHistorico(DateTime dFecha)
        {
            return objADRecuperacionComision.recuperacionComisionHistorico(dFecha);
        }
    }
}
