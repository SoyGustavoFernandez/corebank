using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

namespace EntityLayer
{
    public class clsEvalCredComite
    {
        public clsComiteCred ComiteCred { set; get; }
        public int idEvalComiteCred { get; set; }
        public int idEval { set; get; }
        public int idSolicitud { set; get; }
        public int idTipEval { set; get; }
        public string cTipEvalCred { set; get; }
        public int idProducto { set; get; }
        public string cProducto { set; get; }
        public int idModalidadCredito { set; get; }
        public string cModalidadCredito { set; get; }
        public int idOperacion { set; get; }
        public string cOperacion { set; get; }
        public int idMoneda { set; get; }
        public string cMoneda { set; get; }
        public decimal? nMontoProp { set; get; }
        public decimal nMontoSoli { set; get; }
        public int? idEstSol { set; get; }
        public string cEstSol { set; get; }
        public DateTime? dFecSol { set; get; }
        public int? idUsuResponsable { set; get; }
        public string cNombreResponsable { set; get; }
        public List<clsDecisComite> lstDecisComite { set; get; }
        public string cComentario {set;get;}
        public string cComentRev { set; get; }
        public int? idMotRechazo { set; get; }
        public List<clsObservacion> lstObservaciones { set; get; }
        public List<clsObservacionAprobador> lstObsAprobador { set; get; }
        public int idCli { set; get; }
        public string cDocumentoID { set; get; }
        public string cNombre { set; get; }
        public bool lEstado { set; get; }
        public bool lEditar { set; get; }
        public bool lFinalizoComite { set; get; }
        public int? idNivelAprRanOpe { set; get; }
        public string cNivelAproba { set; get; }
        public string cRangoAproba { set; get; }
        public bool lVerificacion { set; get; }
        public decimal? nLongitud { set; get; }
        public decimal? nLatitud { set; get; }
        public int idAsesor { set; get; }
        public string cAsesor { set; get; }
        public int idNivelAprobacion { set; get; }
        public int idEstadoEvalCred { set; get; }
        public string cEstado { set; get; }
        public int idEtapaEvalCred { set; get; }
        public string cEtapa { set; get; }
        public int? idResultado { set; get; }
        public string cResultado { set; get; }
        public int idClasificacionInterna { set; get; }

        public bool ShouldSerializeidResultado()
        {
            return idResultado != null;
        }
        public bool ShouldSerializenMontoSol()
        {
            return nMontoProp != null;
        }
        public bool ShouldSerializeidEstSol()
        {
            return idEstSol != null;
        }
        public bool ShouldSerializedFecSol()
        {
            return dFecSol != null;
        }
        public bool ShouldSerializeidUsuResponsable()
        {
            return idUsuResponsable != null;
        }
        public bool ShouldSerializeidNivelAprRanOpe()
        {
            return idNivelAprRanOpe != null;
        }
        public bool ShouldSerializenLongitud()
        {
            return nLongitud != null;
        }
        public bool ShouldSerializenLatitud()
        {
            return nLatitud != null;
        }
        public bool ShouldSerializeComiteCred()
        {
            return false;
        }

        public string cCanalAproCred { set; get; }
        public string cNomCorto { set; get; }
        public string cNombreEstab { set; get; }
    }
}
