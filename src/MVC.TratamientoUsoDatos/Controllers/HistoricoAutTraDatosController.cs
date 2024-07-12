using MVC.TratamientoUsoDatos.Models;
using MVC.TratamientoUsoDatos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.TratamientoUsoDatos.Controllers
{
    public class HistoricoAutTraDatosController : ApiController
    {
        private AutorizacionUsoDatosRepository autorizacionRepository;
        public HistoricoAutTraDatosController()
        {
            this.autorizacionRepository = new AutorizacionUsoDatosRepository();
        } 
        // GET api/auttratamientousodatos
        public RespLisAutorizacionTraDatosDTO Get()
        {
            return autorizacionRepository.ObtenerHistoricoAutorizacionTraUsoDatos("0",0);
        }

        //[HttpGet]// GET api/auttratamientousodatos/5/1
        public RespLisAutorizacionTraDatosDTO Get(string cNroDoc, int idTipoDoc )
        {
            return autorizacionRepository.ObtenerHistoricoAutorizacionTraUsoDatos(cNroDoc, idTipoDoc);
        }
      
    }
}
