using System;
using System.Collections.Generic;

namespace EntityLayer
{
    public class clsConfigComisiones
    {
        public int idMConfComision { get; set; }
        public int idCanal { get; set; }
        public string cCanal { get; set; }
        public string cNumeroCuenta { get; set; }
        public int idCanalServicio { get; set; }
        public string cCanalServicio { get; set; }
        public int idAsumeComision { get; set; }
        public string cAsumeComision { get; set; }
        public int idTipoRango { get; set; }
        public string cTipoRango { get; set; }
        public int idTipoModalidadPago { get; set; }
        public string cTipoModalidadPago { get; set; }
        public DateTime dFechaInicioVigencia { get; set; }
        public DateTime dFechaFinVigencia { get; set; }
        public bool lActivo { get; set; }

        public List<clsDetalleConfigComisiones> listDetalleConfigComisiones { get; set; }

        public clsConfigComisiones()
        {
            listDetalleConfigComisiones = new List<clsDetalleConfigComisiones>();
        }
    }
}
