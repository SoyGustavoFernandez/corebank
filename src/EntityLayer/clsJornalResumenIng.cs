using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsJornalResumenIng
    {
        public int idEvalJornalResumenIng { get; set; }
        public int idEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idTipoInterviniente { get; set; }
        [XmlIgnore]
        public string cTipoInterviniente { get; set; }
        public int nTotalDiasActivos { get; set; }
        public decimal nMontoPromedio { get; set; }
        public decimal nMontoTotalSemana { get; set; }

        [XmlIgnore]
        public bool lLunes { get; set; }
        [XmlIgnore]
        public bool lMartes { get; set; }
        [XmlIgnore]
        public bool lMiercoles { get; set; }
        [XmlIgnore]
        public bool lJueves { get; set; }
        [XmlIgnore]
        public bool lViernes { get; set; }
        [XmlIgnore]
        public bool lSabado { get; set; }
        [XmlIgnore]
        public bool lDomingo { get; set; }

        public List<clsJornalDetalleIng> lstDetalleIng { get; set; }
        public bool lVigente { get; set; }

        public clsJornalResumenIng()
        {
            idEvalJornalResumenIng = 0;
            idEvalCred = 0;
            idSolicitud = 0;
            idTipoInterviniente = 0;
            cTipoInterviniente = String.Empty;
            nTotalDiasActivos = 0;
            nMontoPromedio = Decimal.Zero;
            nMontoTotalSemana = Decimal.Zero;
            lLunes = false;
            lMartes = false;
            lMiercoles = false;
            lJueves = false;
            lViernes = false;
            lSabado = false;
            lDomingo = false;
            lstDetalleIng = new List<clsJornalDetalleIng>();
            clsJornalDetalleIng objLunes = new clsJornalDetalleIng()
            {
                idDiaSemana = 2,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objMartes = new clsJornalDetalleIng()
            {
                idDiaSemana = 3,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objMiercoles = new clsJornalDetalleIng()
            {
                idDiaSemana = 4,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objJueves = new clsJornalDetalleIng()
            {
                idDiaSemana = 5,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objViernes = new clsJornalDetalleIng()
            {
                idDiaSemana = 6,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objSabado = new clsJornalDetalleIng()
            {
                idDiaSemana = 7,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            clsJornalDetalleIng objDomingo = new clsJornalDetalleIng()
            {
                idDiaSemana = 1,
                lIngresoActivo = false,
                nMontoJornada = 0,
                lVigente = true
            };
            lstDetalleIng.Add(objLunes);
            lstDetalleIng.Add(objMartes);
            lstDetalleIng.Add(objMiercoles);
            lstDetalleIng.Add(objJueves);
            lstDetalleIng.Add(objViernes);
            lstDetalleIng.Add(objSabado);
            lstDetalleIng.Add(objDomingo);
            
            lVigente = false;
        }
    }
}
