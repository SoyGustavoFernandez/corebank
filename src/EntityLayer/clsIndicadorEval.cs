using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsIndicadorEval
    {
        public int idIndicadorEval { get; set; }
        public int nCodigo { get; set; }
        public string cDescripcion { get; set; }
        public string cDescFormula { get; set; }
        public string cDescRegla { get; set; }
        public decimal nRatio { get; set; }
        public bool lValido { get; set; }
        public decimal nValorMinimo { get; set; }
        public decimal nValorMaximo { get; set; }
        public int nTipoVariable { get; set; }
        public int idItemIndicador { get; set; }
        public int idEvalCred { get; set; }

        public clsIndicadorEval()
        {
            idIndicadorEval = 0;	
            nCodigo			= 0;	
            cDescripcion	= "";	
            cDescFormula	= "";	
            cDescRegla		= "";

            nRatio = 0;
            lValido = false;
            nValorMinimo = 0;
            nValorMaximo = 0;
        }
    }
}
