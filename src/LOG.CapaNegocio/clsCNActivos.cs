using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;
using EntityLayer;


namespace LOG.CapaNegocio
{
    public class clsCNActivos
    {
        public clsADActivos ObjActivo = new clsADActivos();

        //Lista activos existentes
        public List<clsActivo> CNListaActivos(int idActivo)
        {
            return ObjActivo.ADListaActivos(idActivo);
        }

        //Inserta Activos
        public DataTable CNGuardarActivos(clsActivo objActivo)
        {
            return ObjActivo.ADGuardarActivos(objActivo);
        }

        //Lista grupo de activos existentes
        public DataTable CNListaGrupoActivos(int idActivo)
        {
            return ObjActivo.ADListaGrupoActivos(idActivo);
        }

        //Lista todos de activos vigentes
        public DataTable CNListaTodosActivos(string cBuscActivo, int nTipoDato)
        {
            return ObjActivo.ADListaTodosActivos(cBuscActivo, nTipoDato);
        }
        
        //Lista activos por colaborador
        public DataTable CNListaActivosColab(string idUsuResp, int idAgencia)
        {
            return ObjActivo.ADListaActivosColab(idUsuResp, idAgencia);
        }

        //Lista activos por colaborador,agencia, cod activo, serie
        public DataTable CNListaActivosResponsable(int idUsuReg, int idAgencia, string idActivo, string cSerie,string cIdEstado)
        {
            return ObjActivo.ADListaActivosResponsable(idUsuReg, idAgencia, idActivo, cSerie, cIdEstado);
        }

        //Lista activos por cod activo
        public DataTable CNListaActivosId(string idActivo)
        {
            return ObjActivo.ADListaActivosId(idActivo);
        }

        //Actualiza la asignacion de activos
        public DataTable CNUpdActivos(string xmlDetalleActivo, int idUsuarioDest, int idAgenciaDest, int idUsuReg, int idAgenciaReg, DateTime dFechaReg, DateTime dFechaActivacion, string cSustento)
        {
            return ObjActivo.ADUpdActivos(xmlDetalleActivo, idUsuarioDest, idAgenciaDest, idUsuReg, idAgenciaReg, dFechaReg, dFechaActivacion, cSustento);
        }
        //Lista motivos de Baja de activos
        public DataTable CNMotivoBajaActivos()
        {
            return ObjActivo.ADMotivoBajaActivos();
        }
        //Da de Baja a los activos
        public DataTable CNDarBajaActivos(string xmlDetalleActivo, int idUsuBaja , int idMotBajaActivo, DateTime dFechaBaja, string cMotivoBaja)
        {           
            return ObjActivo.ADDarBajaActivos(xmlDetalleActivo,idUsuBaja, idMotBajaActivo,dFechaBaja, cMotivoBaja);
        }
        //Lista Activos a Personal Responsable
        public DataTable CNListaActPersonal(int idUsuarioResp)
        {
            return ObjActivo.ADListaActPersonal(idUsuarioResp);
        }

        //Lista Motivos de entrega de cargo
        public DataTable CNListaMotEntregaCargo()
        {
            return ObjActivo.ADListaMotEntregaCargo();
        }

        public DataTable CNListaProductosCatalogo(int idGrupoPadre)
        {
            return ObjActivo.ADListaProductosCatalogo(idGrupoPadre);
        }

        //Inserta datos de la entrega de cargo
        public DataTable CNInsertaEntregaCargo(string xmlDetalleActivo, string xmlEntregaCargo)
        {
            return ObjActivo.ADInsertaEntregaCargo(xmlDetalleActivo, xmlEntregaCargo);
        }

        public DataTable CNActivos(int idMovimiento)
        {
            return ObjActivo.ADActivos(idMovimiento);
        }

        //Lista entrega de cargo recibidos y pendientes

        public DataTable CNListaEntregaCargo(DateTime dFechaEntrega, int idUsuarioReg, int idUsuarioDes)
        {
            return ObjActivo.ADListaEntregaCargo(dFechaEntrega, idUsuarioReg, idUsuarioDes);
        }

        // ============================================
        // Asignacion de Activos y Cargo de entrega
        // ============================================

        /*
         * Lista de tipos de Cargo de Entrega
         * Requerido por el frmAsignacionActivos
         * 
         */
        public DataTable CNlistaTipoEncargo()
        {
            return ObjActivo.ADlistaTipoEncargo();
        }

        /**
         * 
         * Lista de Activos de un movimiento
         * Requerido por los frmCargoEntrega
         * 
         */
        public DataTable CNLisMovActCarEnt(int nIdMovimiento)
        {
            return ObjActivo.ADLisMovActCarEnt(nIdMovimiento);
        }

        /**
         * 
         * Registra un Cargo de Entrega
         * 
         */
        public int CNCreateCarEnt(
            int idMovimiento,
            int idTipoCargoEntrega,
            int idUsuario,
            string xDetalles // en la base de datos se registra en XML
        ){
            DataTable dtRespuesta = ObjActivo.ADCreateCarEnt(
                    idMovimiento,
                    idTipoCargoEntrega,
                    idUsuario,
                    xDetalles
                );

            if (dtRespuesta.Rows.Count != 1) 
            {
                return -1;
            }

            return Convert.ToInt32(dtRespuesta.Rows[0]["idCargoEntrega"]);
        }

        /**
        * 
        * Actualiza una fila en la tabla [SI_FinCargoEntrega]
         * o crea si el idCargoEntrega no existe
        * 
        */
        public int CNInsertCargoEntrega(
            int idCargoEntrega,
            int idMovimiento,
            int idTipoCargoEntrega,
            int idUsuario,
            string xDetalles,

            // por omision
            int nVecesImpreso = 0,
            bool lVigente = true
        )
        {
            DataTable dtRespuesta = ObjActivo.ADInsertCargoEntrega(
                    idCargoEntrega,
                    idMovimiento,
                    idTipoCargoEntrega,
                    nVecesImpreso,
                    idUsuario,
                    xDetalles,
                    lVigente
                );

            if (dtRespuesta.Rows.Count > 0)
            {
                return Convert.ToInt32(dtRespuesta.Rows[0]["idCargoEntrega"]);
            }
            else
            {
                return -1;
            }
        }

        /**
         * 
         * Retorna el cargo de entrega
         * 
         */
        public DataTable CNUltCargoEntrega(int idIde, int nModo)
        {
            return ObjActivo.ADUltCargoEntrega(idIde, nModo);
        }

        // ============================================
        // end Asignacion de Activos y Cargo de entrega
        // ============================================

    }
}
