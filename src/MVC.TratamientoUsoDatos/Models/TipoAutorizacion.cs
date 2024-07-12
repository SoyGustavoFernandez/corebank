using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{
    public class TipoAutorizacion: Auditoria
    {
        public int idTipo { get; set; }
        public string cTipo { get; set; }
        public int nTiempoVigencia { get; set; }
        public bool lVigente { get; set; }
    }

}