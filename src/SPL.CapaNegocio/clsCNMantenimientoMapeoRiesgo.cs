using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SPL.AccesoDatos;namespace SPL.CapaNegocio
{
    public class clsCNMapeoRiesgoYOpeInusual
    {
        clsADMapeoRiesgoYOpeInusual admantenimientomapeoriesgo = new clsADMapeoRiesgoYOpeInusual();
        /*=============================================================================================================================*/
        /* Funciones con productos de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaProductosRiesgo(int idProducto, int idModulo)
        {
            return admantenimientomapeoriesgo.listaProductosRiesgo(idProducto, idModulo);
        }
        public DataTable listaProductosRiesgoTodos(int idModulo)
        {
            return admantenimientomapeoriesgo.listaProductosRiesgo(0, idModulo);
        }
        public DataTable insertarProductosRiesgo(int idProducto, String cProducto, int idModulo, String cIdsProdAsoc, Boolean lVigente)
        {
            return admantenimientomapeoriesgo.insertarProductosRiesgo(idProducto, cProducto, idModulo, cIdsProdAsoc, lVigente);
        }
        public DataTable listaTiposProducRiesgo()
        {
            return admantenimientomapeoriesgo.listaTiposProducRiesgo();
        }                
        /*=============================================================================================================================*/
        /* Funciones actividad de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaActividadesRiesgo(int idActividad)
        {
            return admantenimientomapeoriesgo.listaActividadesRiesgo(idActividad);
        }
        public DataTable insertarActividadesRiesgo(int idActividadRiesgo, String cActividadRiesgo, Boolean lVigente)
        {
            return admantenimientomapeoriesgo.insertarActividadesRiesgo(idActividadRiesgo, cActividadRiesgo, lVigente);
        }
        public DataTable listaActividadesXTipoMapeo(int idTipoMapeo)
        {
            return admantenimientomapeoriesgo.listaActividadesXTipoMapeo(idTipoMapeo);
        }
        public DataTable insertarActividadesXTipoMapeo(int idActividadXMapeo, int idTipoMapeo, int idActividadRiesgo, Boolean lVigente)
        {
            return admantenimientomapeoriesgo.insertarActividadesXTipoMapeo(idActividadXMapeo, idTipoMapeo, idActividadRiesgo, lVigente);
        }
        /*=============================================================================================================================*/
        /* funciones cualificacion riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaCalificRiesgo(int idCalific)
        {
            return admantenimientomapeoriesgo.listaCalificRiesgo(idCalific);
        }
        /*=============================================================================================================================*/
        /* funciones mapeo de riesgo                                  */
        /*=============================================================================================================================*/
        public DataTable listaTiposMapeo(int idTipoMapeo)
        {
            return admantenimientomapeoriesgo.listaTiposMapeo(idTipoMapeo);
        }
        public DataTable listaTiposMapeoTodos()
        {
            return admantenimientomapeoriesgo.listaTiposMapeo(0);
        }
        public DataTable listarMapeoRiesgo(int idTipoMapeo)
        {
            return admantenimientomapeoriesgo.listarMapeoRiesgo(idTipoMapeo);
        }
        public DataTable listaDetalleMapeo(int idMapeoRiesgo)
        {
            return admantenimientomapeoriesgo.listaDetalleMapeo(idMapeoRiesgo);
        }
        public DataTable insertarRegMapeoRiesgo(int idMapeoRiesgo, int idItem, int idTipoMapeo, Decimal nPuntaje, int idCalificRiesgo, int idUsuario, DateTime dFecha, String xmlDetalle)
        {
            return admantenimientomapeoriesgo.insertarRegMapeoRiesgo(idMapeoRiesgo, idItem, idTipoMapeo, nPuntaje, idCalificRiesgo, idUsuario, dFecha, xmlDetalle);
        }
        public DataTable eliminarRegMapeoRiesgo(int idMapeoRiesgo, int idUsuario, DateTime dFecha)
        {
            return admantenimientomapeoriesgo.eliminarRegMapeoRiesgo(idMapeoRiesgo, idUsuario, dFecha);
        }
        /*=============================================================================================================================*/
        /* funciones de seguimiento de clientes Operaciones q superan umbral                                  */
        /*=============================================================================================================================*/
        public DataTable listaPerfilCli(int idPerfil)
        {
            return admantenimientomapeoriesgo.listaPerfilCli(idPerfil);
        }
        public DataTable insertaUmbralXPerfil(int idPerfil, Decimal nUmbral, int idUsuario, DateTime dFecha)
        {
            return admantenimientomapeoriesgo.insertaUmbralXPerfil(idPerfil, nUmbral, idUsuario, dFecha);
        }
        public DataTable listaClientesSeguiCreditos(int idPerfil, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return admantenimientomapeoriesgo.listaClientesSeguiCreditos(idPerfil, dFechaDesde, dFechaHasta);
        }
        public DataTable listaClientesSeguiAhorros(int idPerfil, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return admantenimientomapeoriesgo.listaClientesSeguiAhorros(idPerfil, dFechaDesde, dFechaHasta);
        }
        public DataTable listaClientesXPerfil(int idPerfil, int idUbigeo, DateTime dFecha)
        {
            return admantenimientomapeoriesgo.listaClientesXPerfil(idPerfil, idUbigeo, dFecha);
        }
        public DataTable eliminaClienteDeSeguiOpe(int idCliSeguiOpe, int idUsu, DateTime dFecha)
        {
            return admantenimientomapeoriesgo.eliminaClienteDeSeguiOpe(idCliSeguiOpe, idUsu, dFecha);
        }
        /*=============================================================================================================================*/
        /* funciones de procesar operaciones inusuales                                  */
        /*=============================================================================================================================*/
        public DataTable procesaClientesOpeInusual(int idModulo, int idUbigeo, DateTime dFechaDesde, DateTime dFechaHasta, int idPerfil, DateTime dFechaHoy)
        {
            return admantenimientomapeoriesgo.procesaClientesOpeInusual(idModulo, idUbigeo , dFechaDesde, dFechaHasta, idPerfil, dFechaHoy);
        }
        public DataTable procesaSeguimSilencioso(int idKardex, DateTime dFecha)
        {
            return admantenimientomapeoriesgo.procesaSeguimSilencioso(idKardex, dFecha);
        }
    }
}
