using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFFichaVisita
    {
        //Lista para Direcciones cliente 
        public string cCodigoFicha { get; set; } 
        public IList<clsFVItems> listItems { get; set; }
    }

    public class clsFVItems
    {
        public int idFVPreg { get; set; }
        public int idFVGrupo { get; set; }
        public string cPregunta { get; set; }
        public string cPreguntaAdicional { get; set; }
        public string cName { get; set; }
        public string cInfo { get; set; }
        public Boolean lOrientacionVertical { get; set; }
        public IList<clsFVOpcionPregunta> listOpciones { get; set; }
    }

    public class clsFVItemsRespuesta
    {
        public int idFVPreg { get; set; }
        public int idFVGrupo { get; set; }
        public string cPregunta { get; set; }
        public string cPreguntaAdicional { get; set; }
        public string cName { get; set; }
        public string cInfo { get; set; }
        public string cOpcionRespuesta { get; set; }
        public string cRespuestaTexto { get; set; }
    }

    public class clsFVOpcionPregunta{
        public int idFVFichaPregOpc { get; set; }
        public string cOpcion { get; set; }
        public Boolean lRespuesta { get; set; }
    }

    public class clsClienteDireccionesFicha
    {
        public string cTipoDir { get; set; }
        public string cReferenciaDireccion { get; set; }
        public string cPar { get; set; }
        public string cDireccion { get; set; }
    }

    public class clsResumenEvaluacionFicha
    {
       //
    }
}
