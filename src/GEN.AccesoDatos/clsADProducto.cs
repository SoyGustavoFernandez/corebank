using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsADProducto
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        IntConexion objEjeSp;

        public clsADProducto()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADProducto(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ListarProducto(Int32 cCodPro)
        {
            return objEjeSp.EjecSP("CRE_ListaProducto_SP", cCodPro);
        }

        public DataTable ListarProductoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinProducto");
        }

        public DataTable ListarProductoAbonoMasivo()
        {
            return objEjeSp.EjecSP("DEP_ListaProductoAbonoMasivo_SP");
        }

        public DataTable ListarProductoAbonoMasivoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinProducto");
        }

        public DataTable ListarNivelProducto()
        {
            return objEjeSp.EjecSP("GEN_LisNivelProducto_SP");
        }

        public DataTable ListarNivelProductoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinNivelProducto");
        }
        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin en la lista
        /// </summary>
        /// <param name="idModulo"></param>
        /// <param name="idNivelProd"></param>
        /// <returns></returns>
        public DataTable ListarProductoModNivel(Int32 idModulo, Int32 idNivelProd, String cIdsProductos)
        {
            return objEjeSp.EjecSP("GEN_LisProducModuloNivel_SP", idModulo, idNivelProd, cIdsProductos);
        }
        public DataTable ListarProductoModNivelRec(Int32 idModulo, Int32 idNivelProd)
        {
            return objEjeSp.EjecSP("RCP_LisProducModuloNivelRec_SP", idModulo, idNivelProd);
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin para la insercion.
        /// </summary>
        /// <param name="cProducto"></param>
        /// <param name="IdProductoPadre"></param>
        /// <param name="lVigente"></param>
        /// <param name="idModulo"></param>
        /// <param name="dVigenciaInicio"></param>
        /// <param name="dVigenciaFin"></param>
        /// <returns></returns>
        public DataTable ADInsertarProducto(string cProducto, int IdProductoPadre, bool lVigente, int idModulo, string dVigenciaInicio, string dVigenciaFin,
                                            bool lConfigurable, int idFuenteCalcMora)
        {
            return objEjeSp.EjecSP("ADM_InsertarProducto_SP", cProducto, IdProductoPadre, lVigente, idModulo, (dVigenciaInicio == null) ? (Object)DBNull.Value : (Object)dVigenciaInicio, (dVigenciaFin == null) ? (Object)DBNull.Value : (Object)dVigenciaFin,
                                        lConfigurable, idFuenteCalcMora);
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin para la actualizacion.
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="cProducto"></param>
        /// <param name="lVigente"></param>
        /// <param name="dVigenciaInicio"></param>
        /// <param name="dVigenciaFin"></param>
        /// <returns></returns>
        public DataTable ADActualizarproducto(int IdProducto, string cProducto, bool lVigente, string dVigenciaInicio, string dVigenciaFin,
                                            bool lConfigurable, int idFuenteCalcMora)
        {
            return objEjeSp.EjecSP("ADM_ActualizarProducto_SP", IdProducto, cProducto, lVigente, (dVigenciaInicio == null) ? (Object)DBNull.Value : (Object)dVigenciaInicio, (dVigenciaFin == null) ? (Object)DBNull.Value : (Object)dVigenciaFin,
                                lConfigurable, idFuenteCalcMora);
        }

        public DataTable ADListarProductoNivelesSup(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ProductoNivelesSup_sp", idProducto);
        }

        public DataTable ADListarProductoxNivel(string xmlProductos, int nNivel, int idModulo)
        {
            return objEjeSp.EjecSP("ADM_ListarProductoxNivel_SP", xmlProductos, nNivel, idModulo);
        }

        public DataTable ADListaNivelesSupProductos(int idModulo, int idProducto, int lResultado)
        {
            return objEjeSp.EjecSP("GEN_ListaNivelesSupProductos_SP", idModulo, idProducto, lResultado);
        }

        public DataTable ADListarProductoPorCampana(int idGrupoCamp)
        {
            return objEjeSp.EjecSP("WCF_ListarProductoPorCampana_SP", idGrupoCamp);
        }

        public DataTable ADListarSubProducto()
        {
            return objEjeSp.EjecSP("WCF_ObtenerSubProductos_SP");
        }

        public DataTable ADListaProductos()
        {
            return objEjeSp.EjecSP("WCF_ListaProductos_SP");
        }

        public DataTable ADComprobarProductCamp(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ComprobarProductoCamp_SP", idProducto);
        }
        public DataTable SubProductoxTipoCredito(int idTipoCredito, int idModulo)
        {
            return objEjeSp.EjecSP("CRE_ProductosTipoCredito_sp", idTipoCredito, idModulo);
        }

        public DataTable CNRecuperarProductoDetalle(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_RecuperarProductoDetalle_SP", idProducto);
        }

        public DataTable ADCargarProductoNivelTipEvalCred(string cIDsTipEvalCred, int nNivel, int idProducto)
        {
            return objEjeSp.EjecSP("CRE_BuscarProductoTipEvalCredNivel_SP", cIDsTipEvalCred, nNivel, idProducto);
        }
    }
}
