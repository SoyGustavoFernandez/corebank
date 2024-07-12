using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADActivos
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Lista activos existentes
        public List<clsActivo> ADListaActivos(int idActivo)
        {
            List<clsActivo> LstActivos;
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaActivos_SP", idActivo);
            LstActivos = MapeaTablaEntidadActivo(dtResult);
            return LstActivos;
        }

        //Inserta y actualiza Activos
        public DataTable ADGuardarActivos(clsActivo objActivo)
        {
            List<clsActivo> LstActivos = new List<clsActivo>();
            LstActivos.Add(objActivo);
            string XmlActivos = LstActivos.GetXml<clsActivo>();
            return objEjeSp.EjecSP("LOG_InsertarActivos_SP", XmlActivos);
        }

        //Lista grupo de activos existentes
        public DataTable ADListaGrupoActivos(int idPadre)
        {
            return objEjeSp.EjecSP("LOG_ListGrupoActivo_SP", idPadre);
        }

        //Lista todos de activos vigentes
        public DataTable ADListaTodosActivos(string cBuscActivo, int nTipoDato)
        {
            return objEjeSp.EjecSP("LOG_ListaTodosActivos_SP", cBuscActivo, nTipoDato);
        }

        //Lista activos por colaborador
        public DataTable ADListaActivosColab(string idUsuResp, int idAgencia)
        {
            return objEjeSp.EjecSP("LOG_ListaActivosColab_SP", idUsuResp, idAgencia);
        }

        //Lista activos por colaborador,agencia, cod activo, serie
        public DataTable ADListaActivosResponsable(int idUsuReg, int idAgencia, string idActivo, string cSerie,string cIdEstado)
        {
            return objEjeSp.EjecSP("LOG_ListaActivosResponsable_SP", idUsuReg, idAgencia, idActivo, cSerie, cIdEstado);
        }

        //Lista activos por cod activo
        public DataTable ADListaActivosId(string idActivo)
        {
            return objEjeSp.EjecSP("LOG_ListActivosxId_SP", idActivo);
        }

        //Actualiza la asignacion de activos
        public DataTable ADUpdActivos(string xmlDetalleActivo, int idUsuarioDest, int idAgenciaDest, int idUsuReg, int idAgenciaReg, DateTime dFechaReg, DateTime dFechaActivacion, string cSustento)
        {
            return objEjeSp.EjecSP("LOG_InsMovimientoActivos_SP", xmlDetalleActivo, idUsuarioDest, idAgenciaDest, idUsuReg, idAgenciaReg, dFechaReg, dFechaActivacion, cSustento);
        }

        //Lista motivos de Baja de activos
        public DataTable ADMotivoBajaActivos()
        {
            return objEjeSp.EjecSP("LOG_ListaMotivoBajaActivos_SP");
        }

        //Da de Baja a los activos
        public DataTable ADDarBajaActivos(string xmlDetalleActivo,int idUsuBaja, int idMotBajaActivo, DateTime dFechaBaja, string cMotivoBaja)
        {
            return objEjeSp.EjecSP("LOG_DarBajaActivos_SP", xmlDetalleActivo, idUsuBaja,idMotBajaActivo, dFechaBaja, cMotivoBaja);
        }

        //Lista Activos a Personal Responsable
        public DataTable ADListaActPersonal(int idUsuarioResp)
        {
            return objEjeSp.EjecSP("LOG_ListarActivosPersonal_SP", idUsuarioResp);
        }

        //Lista Motivos de entrega de cargo
        public DataTable ADListaMotEntregaCargo()
        {
            return objEjeSp.EjecSP("LOG_ListarMotivoEntregaCargo_SP");
        }

        //Inserta datos de la entrega de cargo
        public DataTable ADInsertaEntregaCargo(string xmlDetalleActivo, string xmlEntregaCargo)
        {
            return objEjeSp.EjecSP("LOG_InsEntregaCargo_SP", xmlDetalleActivo, xmlEntregaCargo);
        }

        public DataTable ADListaProductosCatalogo(int idGrupoPadre)
        {
            return objEjeSp.EjecSP("LOG_ListarProdCatalogo_Sp", idGrupoPadre);
        }

        private List<clsActivo> MapeaTablaEntidadActivo(DataTable dtResult)
        {
            List<clsActivo> LstActivos = new List<clsActivo>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsActivo objActivo = new clsActivo();
                objActivo.idActivo = Convert.ToInt32(row["idActivo"]);
                objActivo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objActivo.idTipoActivo = row["idTipoActivo"] == DBNull.Value ? 0 : Convert.ToInt32(row["idTipoActivo"]);
                objActivo.cColor = Convert.ToString(row["cColor"]);
                objActivo.cMaterial = Convert.ToString(row["cMaterial"]);
                objActivo.cRubro = Convert.ToString(row["cRubro"]);
                objActivo.cMarca = Convert.ToString(row["cMarca"]);
                objActivo.cSerie = Convert.ToString(row["cSerie"]);
                objActivo.cModelo = Convert.ToString(row["cModelo"]);
                objActivo.idEstadoActivo = Convert.ToInt32(row["idEstadoActivo"]);                
                objActivo.cDetalleCpg = Convert.ToString(row["cDetalleCpg"]);
                objActivo.cSerieCpg = Convert.ToString(row["cSerieCpg"]);
                objActivo.cNumeroCpg = Convert.ToString(row["cNumeroCpg"]);                
                objActivo.cProducto = Convert.ToString(row["cProducto"]);
                objActivo.idTipoBien = Convert.ToInt32(row["idTipoBien"]);
                objActivo.idSubTipoBien = Convert.ToInt32(row["idSubTipoBien"]);
                objActivo.idGrupo = Convert.ToInt32(row["idGrupo"]);
                objActivo.idSubGrupo = row["idSubGrupo"]==DBNull.Value ? 0 : Convert.ToInt32(row["idSubGrupo"]);
                objActivo.idUnidadCompra = Convert.ToInt32(row["idUnidadCompra"]);
                objActivo.idUnidadAlmacenaje = Convert.ToInt32(row["idUnidadAlmacenaje"]);
                objActivo.nValConversion = Convert.ToInt32(row["nValConversion"]);
                objActivo.lIndActivo = Convert.ToBoolean(row["lIndActivo"]);
                objActivo.cObservacion = Convert.ToString(row["cObservacion"]);
                objActivo.idEstado = Convert.ToInt32(row["idEstado"]);      
                objActivo.cObservacionBaja = Convert.ToString(row["cObservacionBaja"]);
                objActivo.idUsuReg = Convert.ToInt32(row["idUsuReg"]);
                objActivo.dFechaReg = Convert.ToDateTime(row["dFechaReg"]);
                objActivo.cUbicActivo = Convert.ToString(row["cUbicActivo"]);
                objActivo.cNombreColResp = Convert.ToString(row["cNombreColResp"]);
                objActivo.cDocProveedor = Convert.ToString(row["cDocProveedor"]);
                objActivo.cNomProveedor = Convert.ToString(row["cNomProveedor"]);
                objActivo.cObsActiv = Convert.ToString(row["cObsActiv"]);
                objActivo.cCodInstActivo = Convert.ToString(row["cCodInstActivo"]);
                objActivo.nValorCompra = row["nValorCompra"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nValorCompra"]);
                objActivo.idUsuResp = Convert.ToInt32(row["idUsuResp"]);

                objActivo.nPorcDeprec = row["nPorcDeprec"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nPorcDeprec"]);
                objActivo.dFechaCompra = row["dFechaCompra"] == DBNull.Value ? clsVarGlobal.dFecSystem : Convert.ToDateTime(row["dFechaCompra"]);
                objActivo.nMontoDeprec = row["nMontoDeprec"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nMontoDeprec"]);
                objActivo.nValorActual = row["nValorActual"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nValorActual"]);
                objActivo.idTipComPag = row["idTipComPag"] == DBNull.Value ? -1 : Convert.ToInt32(row["idTipComPag"]);
                objActivo.dFechaActivacion = row["dFechaActivacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaActivacion"]);
                objActivo.nCantidadTotal = row["nCantidad"] == DBNull.Value ? 0 : Convert.ToInt32(row["nCantidad"]);
                objActivo.nPrecioUnit = row["nPrecioUnit"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nPrecioUnit"]);
                objActivo.idMotBajaActivo = row["idMotBajaActivo"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idMotBajaActivo"]);
                objActivo.dFechaBaja = row["dFechaBaja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaBaja"]);                 
                objActivo.idUsuMod = row["idUsuMod"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idUsuMod"]);
                objActivo.dFechaMod = row["dFechaMod"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaMod"]);               
                objActivo.idAgencia = row["idAgencia"] == DBNull.Value ? -1 : Convert.ToInt32(row["idAgencia"]);
                objActivo.idCliProveedor = row["idCliProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(row["idCliProveedor"]);

                objActivo.nAdquisicionAdicion = row["nAdquisicionAdicion"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nAdquisicionAdicion"]);
                objActivo.nMejoras = row["nMejoras"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nMejoras"]);
                objActivo.nAjusteInflacion = row["nAjusteInflacion"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nAjusteInflacion"]);
                
                LstActivos.Add(objActivo);
            }
            return LstActivos;
        }


        public DataTable ADActivos(int idMovimiento)
        {
            return objEjeSp.EjecSP("LOG_AsigActivos_SP", idMovimiento); 
        }

        public DataTable ADListaEntregaCargo(DateTime dFechaEntrega, int idUsuarioReg, int idUsuarioDes)
        {
            return objEjeSp.EjecSP("RPT_ListaActivosEntregados_SP", dFechaEntrega, idUsuarioReg, idUsuarioDes);
        }

        // ============================================
        // Asignacion de Activos y Cargo de entrega
        // ============================================
        public DataTable ADlistaTipoEncargo() 
        {
            return objEjeSp.EjecSP("LOG_LisTipCarEnt_SP");
        }

        /**
         * 
         * Listado de activos para el formato de cargo de entrega
         * 
         */
        public DataTable ADLisMovActCarEnt(int nIdMovimiento)
        {
            return objEjeSp.EjecSP("LOG_LisMovActCarEnt_SP", nIdMovimiento);
        }

        /**
         * 
         * Crea una nueva fila en la tabla [SI_FinCargoEntrega]
         * 
         */
        public DataTable ADCreateCarEnt(
            int idMovimiento,
            int idTipoCargoEntrega,
            int idUsuario,
            string xDetalles
        ){
            return objEjeSp.EjecSP("LOG_CreateCargoEntrega_SP", 
                    idMovimiento,
                    idTipoCargoEntrega,
                    idUsuario,
                    xDetalles
                );
        }

        /**
        * 
        * Actualiza una fila en la tabla [SI_FinCargoEntrega]
        * 
        */
        public DataTable ADInsertCargoEntrega(
            int idCargoEntrega,
            int idMovimiento,
            int idTipoCargoEntrega,
            int nVecesImpreso,
            int idUsuario,
            string xDetalles,
            bool lVigente
        )
        {
            return objEjeSp.EjecSP("LOG_InsCargoEntrega_SP",
                    idCargoEntrega,
                    idMovimiento,
                    idTipoCargoEntrega,
                    nVecesImpreso,
                    idUsuario,
                    xDetalles,
                    lVigente
                );
        }

        /**
         * 
         * Retorna el cargo de entrega
         * 
         */
        public DataTable ADUltCargoEntrega(int idIde, int nModo = 1)
        {
            return objEjeSp.EjecSP("LOG_UltCargoEntrega_SP", idIde, nModo);
        }

        // ============================================
        // end Asignacion de Activos y Cargo de entrega
        // ============================================
    }
}
