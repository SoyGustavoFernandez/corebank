using MVC.TratamientoUsoDatos.Models;
using MVC.TratamientoUsoDatos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC.TratamientoUsoDatos.Controllers
{
    public class DocumentoAutTraDatosController : ApiController
    { 
        private AutorizacionUsoDatosRepository autorizacionRepository;
        public DocumentoAutTraDatosController()
        {
            this.autorizacionRepository = new AutorizacionUsoDatosRepository();
        } 

        //[HttpGet]// GET api/auttratamientousodatos/5/1
        public RespLisAutorizacionTraDatosDTO Get(int idDocumento)
        {
            return autorizacionRepository.ObtenerDocumentoAutorizacionTraUsoDatos(idDocumento);
        }
    }
}
