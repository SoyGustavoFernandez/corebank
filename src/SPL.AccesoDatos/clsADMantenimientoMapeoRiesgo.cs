using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADMapeoRiesgoYOpeInusual
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        /*=============================================================================================================================*/
        /* Funciones con productos de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaProductosRiesgo(int idProducto, int idModulo)
        {
            return objEjeSp.EjecSP("SPL_ListaProductosRiesgo_SP", idProducto, idModulo);
        }
        public DataTable insertarProductosRiesgo(int idProducto, String cProducto, int idModulo, String cIdsProdAsoc, Boolean lVigente)
        {
            return objEjeSp.EjecSP("SPL_InsertaProductoRiesgo_SP", idProducto, cProducto, idModulo, cIdsProdAsoc, lVigente);
        }
        public DataTable listaTiposProducRiesgo()
        {
            return objEjeSp.EjecSP("SPL_ListaTipoProductoRiesgo_SP");
        }        
        /*=============================================================================================================================*/
        /* Funciones actividad de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaActividadesRiesgo(int idActividad)
        {
            return objEjeSp.EjecSP("SPL_ListaActividadesRiesgo_SP", idActividad);
        }
        public DataTable insertarActividadesRiesgo(int idActividadRiesgo, String cActividadRiesgo, Boolean lVigente)
        {
            return objEjeSp.EjecSP("SPL_InsertarActividadRiesgo_SP", idActividadRiesgo, cActividadRiesgo, lVigente);
        }
        public DataTable listaActividadesXTipoMapeo(int idTipoMapeo)
        {
            return objEjeSp.EjecSP("SPL_ListaActividadesXMapeo_SP", idTipoMapeo);
        }
        public DataTable insertarActividadesXTipoMapeo(int idActividadXMapeo, int idTipoMapeo, int idActividadRiesgo, Boolean lVigente)
        {
            return objEjeSp.EjecSP("SPL_InsertarActividadXtipoMapeo_SP", idActividadXMapeo, idTipoMapeo, idActividadRiesgo, lVigente);
        }
        /*=============================================================================================================================*/
        /* funciones cualificacion riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaCalificRiesgo(int idCalific)
        {
            return objEjeSp.EjecSP("SPL_ListaCalificRiesgo_SP", idCalific);
        }
        /*=============================================================================================================================*/
        /* funciones mapeo de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaTiposMapeo(int idTipoMapeo)
        {
            return objEjeSp.EjecSP("SPL_ListaTipoMapeo_SP", idTipoMapeo);
        }
        public DataTable listarMapeoRiesgo(int idTipoMapeo)
        {
            return objEjeSp.EjecSP("SPL_ListarMapeoRiesgo_SP", idTipoMapeo);
        }
        public DataTable listaDetalleMapeo(int idMapeoRiesgo)
        {
            return objEjeSp.EjecSP("SPL_ListaDetalleMapeoRiesgo_SP", idMapeoRiesgo);
        }
        public DataTable insertarRegMapeoRiesgo(int idMapeoRiesgo, int idItem, int idTipoMapeo, Decimal nPuntaje, int idCalificRiesgo, int idUsuario, DateTime dFecha, String xmlDetalle)
        {
            return objEjeSp.EjecSP("SPL_InsertarDatosMapeoRiesgo_SP", idMapeoRiesgo, idItem, idTipoMapeo, nPuntaje, idCalificRiesgo, idUsuario, dFecha, xmlDetalle);
        }
        public DataTable eliminarRegMapeoRiesgo(int idMapeoRiesgo, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_EliminarRegMapeoRiesgo_SP", idMapeoRiesgo, idUsuario, dFecha);
        }
        /*=============================================================================================================================*/
        /* funciones de seguimiento de clientes Operaciones q superan umbral                                  */
        /*=============================================================================================================================*/
        public DataTable listaPerfilCli(int idPerfil)
        {
            return objEjeSp.EjecSP("SPL_ListarPerfilCli_SP", idPerfil);
        }
        public DataTable insertaUmbralXPerfil(int idPerfil, Decimal nUmbral, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_InsertarPerfilUmbral_SP", idPerfil, nUmbral, idUsuario, dFecha);
        }
        public DataTable listaClientesSeguiCreditos(int idPerfil, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("SPL_ListaClientesSeguiCreditos_SP", idPerfil, dFechaDesde, dFechaHasta);
        }
        public DataTable listaClientesSeguiAhorros(int idPerfil, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("SPL_ListaClienteSeguiAhorros_SP", idPerfil, dFechaDesde, dFechaHasta);
        }
        public DataTable listaClientesXPerfil(int idPerfil, int idUbigeo, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_ListaClientesXPerfil_SP", idPerfil, idUbigeo, dFecha);
        }
        public DataTable eliminaClienteDeSeguiOpe(int idCliSeguiOpe, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_EliminaClienteDeSeguiOpe_SP", idCliSeguiOpe, idUsu, dFecha);
        }
        
        /*=============================================================================================================================*/
        /* funciones de procesar operaciones inusuales                                  */
        /*=============================================================================================================================*/
        public DataTable procesaClientesOpeInusual(int idModulo, int idUbigeo, DateTime dFechaDesde, DateTime dFechaHasta, int idPerfil, DateTime dFechaHoy)
        {
            return objEjeSp.EjecSP("SPL_GestionOpeInusuales_SP", idModulo, idUbigeo, dFechaDesde, dFechaHasta, idPerfil, dFechaHoy);
        }
        public DataTable procesaSeguimSilencioso(int idKardex, DateTime dFecha)
        {
            return objEjeSp.EjecSP("SPL_GestionSeguimientoOpe_SP", idKardex, dFecha);
        }
    }
}
