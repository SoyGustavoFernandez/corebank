using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEB.AhorroWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "app",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "AgenciaPerfilUsuario",
                url: "login/agencia-perfil-usuario",
                defaults: new { controller = "Login", action = "AgenciaPerfilUsuario" }
            );

            routes.MapRoute(
                name: "ValidarUsuario",
                url: "login/validar-usuario",
                defaults: new { controller = "Login", action = "ValidarUsuario" }
            );

            routes.MapRoute(
                name: "IdentificarUsuario",
                url: "login/identificar-usuario",
                defaults: new { controller = "Login", action = "IdentificarUsuario" }
            );

            routes.MapRoute(
                name: "Productos",
                url: "datos/productos",
                defaults: new { controller = "Datos", action = "ObtenerProductos" }
            );

            routes.MapRoute(
                name: "Monedas",
                url: "datos/monedas",
                defaults: new { controller = "Datos", action = "ObtenerMonedas" }
            );

            routes.MapRoute(
                name: "Profesiones",
                url: "datos/profesiones",
                defaults: new { controller = "Datos", action = "ObtenerProfesiones" }
            );

            routes.MapRoute(
                name: "ActividadesInternas",
                url: "datos/actividades-internas",
                defaults: new { controller = "Datos", action = "ObtenerActividadesInternas" }
            );

            routes.MapRoute(
                name: "ObjetosAhorro",
                url: "datos/objetos-ahorro",
                defaults: new { controller = "Datos", action = "ObtenerObjetosAhorro" }
            );

            //routes.MapRoute(
            //    name: "TiposCuenta",
            //    url: "data-source/tipos-cuenta",
            //    defaults: new { controller = "DataSource", action = "TiposCuenta" }
            //);

            //routes.MapRoute(
            //    name: "TiposVia",
            //    url: "data-source/tipos-via",
            //    defaults: new { controller = "DataSource", action = "TiposVia" }
            //);

            //routes.MapRoute(
            //    name: "TiposZona",
            //    url: "data-source/tipos-zona",
            //    defaults: new { controller = "DataSource", action = "TiposZona" }
            //);

            //routes.MapRoute(
            //    name: "Ocupaciones",
            //    url: "data-source/ocupaciones",
            //    defaults: new { controller = "DataSource", action = "Ocupaciones" }
            //);

            //routes.MapRoute(
            //    name: "RubrosComerciales",
            //    url: "data-source/rubros-comerciales",
            //    defaults: new { controller = "DataSource", action = "RubrosComerciales" }
            //);

            //routes.MapRoute(
            //    name: "Ubigeos",
            //    url: "data-source/ubigeos/{idUbigeoPadre}",
            //    defaults: new { controller = "DataSource", action = "Ubigeos" }
            //);

            routes.MapRoute(
                name: "IdentificarPersona",
                url: "tramitar/identificar-persona",
                defaults: new { controller = "Tramitar", action = "IdentificarPersona" }
            );

            routes.MapRoute(
                name: "ValidarCuenta",
                url: "tramitar/validar-cuenta",
                defaults: new { controller = "Tramitar", action = "ValidarCuenta" }
            );

            routes.MapRoute(
                name: "ValidarIdentidad",
                url: "tramitar/validar-identidad",
                defaults: new { controller = "Tramitar", action = "ValidarIdentidad" }
            );

            routes.MapRoute(
                name: "EnviarCodigoValidacion",
                url: "tramitar/enviar-codigo-validacion",
                defaults: new { controller = "Tramitar", action = "EnviarCodigoValidacion" }
            );

            routes.MapRoute(
                name: "RutaArchivos",
                url: "tramitar/ruta-archivos",
                defaults: new { controller = "Tramitar", action = "RutaArchivos" }
            );           

            routes.MapRoute(
                name: "ContratarCuenta",
                url: "tramitar/contratar-cuenta",
                defaults: new { controller = "Tramitar", action = "ContratarCuenta" }
            );            
        }
    }
}