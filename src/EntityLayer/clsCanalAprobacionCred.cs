using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCanalAprobacionCred
    {
        public int idCanalAproCred { get; set; }
        public string cCanalAproCred { get; set; }
        public string cDescripcion { get; set; }
        public int idNivelAprobacionInicio { get; set; }
        public string cNivelAprobacionInicio { get; set; }
        public int idNivelAprobacionFinal { get; set; }
        public string cNivelAprobacionFinal { get; set; }

        public clsCanalAprobacionCred()
        {
            this.idCanalAproCred = 0;
            this.cCanalAproCred = String.Empty;
            this.cDescripcion = String.Empty;
            this.idNivelAprobacionInicio = 0;
            this.cNivelAprobacionInicio = String.Empty;
            this.idNivelAprobacionFinal = 0;
            this.cNivelAprobacionFinal = String.Empty;
        }
    }
}
