using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsPlanTrabajoObjetivo : ICloneable
    {
        public int idPlanTrabajoObjetivo { get; set; }
        public string cPlanTrabajoResumenObjetivo { get; set; }
        public int idPlanTrabajoResumenObjetivo { get; set; }
        public string cDescripcionPlanTrabajoObjetivo { get; set; }
        public int idPlanTrabajoObjetivoPadre { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoResumenObjetivoPadre { get; set; }
        public int idObjetivoTipo { get; set; }
        [XmlIgnore]
        public string cObjetivoTipo { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public int nSemana { get; set; }
        [XmlIgnore]
        public string cSemana { get; set; }
        public int nDia { get; set; }
        public DateTime dFechaEspecifica { get;set;}
        [XmlIgnore]
        public DateTime dFechaRegistro { get; set; }
        [XmlIgnore]
        public bool lVigente { get; set; }

        public clsPlanTrabajoObjetivo()
        {
            idPlanTrabajoObjetivo               = 0;
            cDescripcionPlanTrabajoObjetivo     = String.Empty;
            idPlanTrabajoResumenObjetivo        = 0;
            cPlanTrabajoResumenObjetivo         = String.Empty;
            idPlanTrabajoObjetivoPadre          = 0;
            cPlanTrabajoResumenObjetivoPadre    = string.Empty;
            idObjetivoTipo                      = 0;
            cObjetivoTipo                       = String.Empty;
            idPlanTrabajoRecuperacion           = 0;
            nSemana                             = 0;
            nDia                                = 0;
            dFechaRegistro                      = clsVarGlobal.dFecSystem;
            lVigente                            = true;
        }

        public void asignarDatos(clsPlanTrabajoObjetivo _objPlanTrabajoObjetivo)
        {
            idPlanTrabajoObjetivo               = _objPlanTrabajoObjetivo.idPlanTrabajoObjetivo;
            cDescripcionPlanTrabajoObjetivo     = _objPlanTrabajoObjetivo.cDescripcionPlanTrabajoObjetivo;
            idPlanTrabajoResumenObjetivo        = _objPlanTrabajoObjetivo.idPlanTrabajoResumenObjetivo;
            cPlanTrabajoResumenObjetivo         = _objPlanTrabajoObjetivo.cPlanTrabajoResumenObjetivo;
            idPlanTrabajoObjetivoPadre          = _objPlanTrabajoObjetivo.idPlanTrabajoObjetivoPadre;
            cPlanTrabajoResumenObjetivoPadre    = _objPlanTrabajoObjetivo.cPlanTrabajoResumenObjetivoPadre;
            idObjetivoTipo                      = _objPlanTrabajoObjetivo.idObjetivoTipo;
            cObjetivoTipo                       = _objPlanTrabajoObjetivo.cObjetivoTipo;
            idPlanTrabajoRecuperacion           = _objPlanTrabajoObjetivo.idPlanTrabajoRecuperacion;
            nSemana                             = _objPlanTrabajoObjetivo.nSemana;
            nDia                                = _objPlanTrabajoObjetivo.nDia;
            dFechaRegistro                      = _objPlanTrabajoObjetivo.dFechaRegistro;
            lVigente                            = _objPlanTrabajoObjetivo.lVigente;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
