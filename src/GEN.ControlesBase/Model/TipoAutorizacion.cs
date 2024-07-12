using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{
    public class TipoAutorizacion: clsAuditoria
    {
        public int idTipo { get; set; }
        public string cTipo { get; set; }
        public int nTiempoVigencia { get; set; }
        public bool lVigente { get; set; }
    }
    public enum EstadoAutorizacionDatos
    {
        AUTORIZADO = 1,
        RECHAZADO = 2,
        EXPIRADO = 3
    };
}