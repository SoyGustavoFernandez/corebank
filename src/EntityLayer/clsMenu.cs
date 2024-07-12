using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsMenu
    {
        public int idMenu { get; set; }
        public int idMenuPadre { get; set; }
        public int idModulo { get; set; }
        public int nOrden { get; set; }
        public string cMenu { get; set; }
        public string cFormMenu { get; set; }
        public int idTipoMenu { get; set; }
        public int idTipoProc { get; set; }
        public bool lVigente { get; set; }
        public string cNameSpace { get; set; }
        public int idTipoClass { get; set; }
        public int idMenuPerfil { get; set; }
        public bool lActivo { get; set; }
        public bool lBaseNegativa { get; set; }
    }

    public class clslisMenu:List<clsMenu>
    {
        
    }

    public enum enuModulo
    {
        CREDITOS=1,
        AHORROS=2,
        CAJA=3,
        CLIENTES=4,
        CONTABILIDAD=5,
        RECURSOS_HUMANOS=6,
        LOGISTICA=7,
        ADMINISTRACION=8,
        SERVICIOS=9,
        PLAFT=10,
        REPORTES=11,
        CANALES=12
    }
}
