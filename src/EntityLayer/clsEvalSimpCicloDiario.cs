using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsEvalSimpCicloDiario
    {

        public int idEvalSimpCicloDiario { get; set; }
        public int idEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idTipoCicloDiario { get; set; }
        [XmlIgnore]
        public string cTipoCicloDiario { get; set; }
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
        public int nTotalDiasActivos { get; set; }
        public decimal nMontoPromedio { get; set; }
        public decimal nMontoTotal { get; set; }
        public bool lVigente { get; set; }
        public List<clsEvalSimpCicloDiarioDetalle> lstDetalleDiario { get; set; }

        public clsEvalSimpCicloDiario()
        {
            idEvalSimpCicloDiario = 0;
            idEvalCred = 0;
            idSolicitud = 0;
            idTipoCicloDiario = 0;
            cTipoCicloDiario = String.Empty;
            nTotalDiasActivos = 0;
            nMontoPromedio = Decimal.Zero;
            nMontoTotal = Decimal.Zero;
            lLunes = false;
            lMartes = false;
            lMiercoles = false;
            lJueves = false;
            lViernes = false;
            lSabado = false;
            lDomingo = false;
            lVigente = false;
            lstDetalleDiario = new List<clsEvalSimpCicloDiarioDetalle>();

            clsEvalSimpCicloDiarioDetalle objLunes = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 2,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objMartes = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 3,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objMiercoles = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 4,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objJueves = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 5,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objViernes = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 6,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objSabado = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 7,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };
            clsEvalSimpCicloDiarioDetalle objDomingo = new clsEvalSimpCicloDiarioDetalle()
            {
                idDiaSemana = 1,
                idTipoCicloDiario = 0,
                nMontoIngreso = 0,
                lVigente = true
            };

            lstDetalleDiario.Add(objLunes);
            lstDetalleDiario.Add(objMartes);
            lstDetalleDiario.Add(objMiercoles);
            lstDetalleDiario.Add(objJueves);
            lstDetalleDiario.Add(objViernes);
            lstDetalleDiario.Add(objSabado);
            lstDetalleDiario.Add(objDomingo);
        }
    }
}
