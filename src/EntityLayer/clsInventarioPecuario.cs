using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsInventarioPecuario
    {
        public int idEvaluacionPecuaria { get; set; }
        public int idEvalCred { get; set; }
        public int idTipoInventario { get; set; }
        public string cDescripcion { get; set; }
        public int idEspecie { get; set; }
        public string cEspecie { get; set; }
        public int idRaza { get; set; }
        public string cRaza { get; set; }
        public int idAnimal { get; set; }
        public string cAnimal { get; set; }
        public int idProductoDerivado { get; set; }
        public string cProductoDerivado { get; set; }
        public int idUnidadMedida { get; set; }
        public string cUnidadMedida { get; set; }
        public int idTipoCrianza { get; set; }
        public string cTipoCrianza { get; set; }
        public int idSistemaCrianza { get; set; }
        public string cSistemaCrianza { get; set; }
        public int idMoneda { get; set; }
        public decimal nMontoIngresos { get; set; }
        public decimal nMontoEgresos { get; set; }
        public decimal nValorActual { get; set; }
    }
}
