using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPep
    {
        public int idPep { get; set; }
        public string cCargo { get; set; }
        public string cNombres { get; set; }
        public string cApePaterno { get; set; }
        public string cApeMaterno { get; set; }
        public DateTime dFechaNac { get; set; }
        public string nDocumento { get; set; }
        public int idTipoDoc { get; set; }
        public bool bEstadoAprob { get; set; }
        public clsListaFamiliar familiares { get; set; }
        public string cInstitucion { get; set; }        
        public DateTime dFecIni { get; set; }
        public DateTime dFecFin { get; set; }
        public string cEmpresa { get; set; }
        public bool bEstadoPercent { get; set; }
        public string cObservaciones { get; set; }
        public int? idcli { get; set; }
        public string cEstado { get; set; }
    }

    public class clsListaPep : List<clsPep>
    {
        
    }

}
