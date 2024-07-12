using DEP.CapaNegocio.AhorroWeb;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.AhorroWeb.Controllers
{
    public class DatosController : Controller
    {
        #region Variables Privadas
        private clsCNAWGeneral objCNAWGeneral = new clsCNAWGeneral(true);
        #endregion

        #region Métodos Públicos
        public ActionResult Index()
        {
            return View();
        }

        [RequireHttps]
        public JsonResult ObtenerProductos(int idAgencia)
        {
            return Json(objCNAWGeneral.obtenerProductos(idAgencia));
        }

        [RequireHttps]
        public JsonResult ObtenerMonedas()
        {
            return Json(objCNAWGeneral.obtenerMonedas());
        }

        [RequireHttps]
        public JsonResult ObtenerProfesiones()
        {
            return Json(objCNAWGeneral.obtenerProfesiones());
        }

        [RequireHttps]
        public JsonResult ObtenerActividadesInternas()
        {
            return Json(objCNAWGeneral.obtenerActividadesInternas());
        }

        [RequireHttps]
        public JsonResult ObtenerObjetosAhorro()
        {
            return Json(objCNAWGeneral.ObtenerObjetosAhorro());
        }
        #endregion
    }
}
