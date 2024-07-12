using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFCredito
    {
        public int idEval { get; set; }
        public int idSolicitud { get; set; }
        public decimal nMontoProp { get; set; }
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int IdMoneda { get; set; }
        public string cMoneda { get; set; }
        public int idAsesor { get; set; }
        public string cAsesor { get; set; }
        public int idEvalCred { get; set; }
        public int idNivelAprobacion { get; set; }
        public int IdProducto { get; set; }
        public string cProducto { get; set; }
        public string cNomCorto { get; set; }
        public int idTipEvalCred { get; set; }
        public int nTieneVisita { get; set; }
        public string cComentario { get; set; }
        public string cCanalRegistro { get; set; }
        public int idOperacion { get; set; }
        public decimal nCuotaAprox { get; set; }
    }

    public class clsWCFIndicadores
    {
        public int idIndicadorEval { get; set; }
        public int nCodigo { get; set; }
        public string cDescripcion { get; set; }
        public string cDescFormula { get; set; }
        public string cDescRegla { get; set; }
        public decimal nRatio { get; set; }
        public bool lValido { get; set; }
        public int nTipoVariable { get; set; }
    }

    public class clsWCFEstadoResultados
    {
        public int idEstResEval { get; set; }
        public int idItemEstRes { get; set; }
        public string cDescripcion { get; set; }
        public int idMonedaMA { get; set; }
        public decimal nTotalMA	{ get; set; }
        public bool lVigente { get; set; }
        public int nOrden { get; set; }
        public int nTipoTrans { get; set; }
        public int idEEFF { get; set; }
        public string cMoneda { get; set; }
        public decimal nTotalUltEvMA { get; set; }
        public decimal nAnalisisHoriz { get; set; }
        public decimal nAnalisisVerti { get; set; }
    }

    public class clsWCFDestino
    {
        public string cDestino { get; set; }
        public decimal nMonto { get; set; }
        public decimal nPorcentaje { get; set; }
    }

    public class clsWCFGarantia
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
    }

    public class clsWCFInterviniente
    {
        public string cNombre { get; set; }
        public string cTipoIntervencion { get; set; }
        public int nEdad { get; set; }
    }

    public class clsWCFDeuda
    {
        public string cNombreEmpresa { get; set; }
        public decimal nSCapTotalSis { get; set; }
        public string cDesCalifiRCC { get; set; }
        public string cTipoDeuda { get; set; }
        public int idTipoDeuda { get; set; }
    }

    public class clsWCFDatosCliente
    {
        public string cActividad { get; set; }
        public decimal nEvaluacionCualitativa { get; set; }
        public IList<clsWCFIndicadores> lIndicadores { get; set; }
        //public IList<clsWCFEstadoResultados> lEstadoResultados { get; set; }
        public IList<clsComposicionCredito> lDestino { get; set; }
        public IList<clsWCFGarantia> lGarantias { get; set; }
        public IList<clsWCFInterviniente> lIntervinientes { get; set; }
        public IList<clsWCFDeuda> lDeuda { get; set; }
        public string cRiesgos { get; set; }
    }

    public class clsWCFGestionAprobacion
    {
        public string cMensaje { get; set; }
        public int idError { get; set; }
        public int idNivelAprobacion { get; set; }
        public bool lEnviaSolInfRiesgos { get; set; }
        public bool lRevision { get; set; }
        public int idEstadoEvalCred { get; set; }
    }

    public class clsWCFTasaNegociable
    {
        public int idTasaNegociada { get; set; }
        public int idTasa { get; set; }
        public int nSolicitud { get; set; }
        public DateTime dFechaReg { get; set; }
        public int idCli { get; set; }
        public string cNombreCliente { get; set; }
        public string cUsuReg { get; set; }
        public string cAgencia { get; set; }
        public decimal nTasaPropuesta { get; set; }
        public decimal nTasaSolicitada { get; set; }
        public decimal nTasaMoratoriaSol { get; set; }
        public string cJustificacion { get; set; }
        public string cJustificacionPre { get; set; }
        public int? idSolAproba { get; set; }
        public int? idNivelAprRanOpe { get; set; }
    }

    public class clsWCFDetalleTasaNegociable
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public string cNombre { get; set; }
        public string cNombreAsesor { get; set; }
        public int nCuotas { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public string cSubTip { get; set; }
        public string cSubPro { get; set; }
        public string cTipoPeriodo { get; set; }
        public decimal nTasaCompensatoria { get; set; }
    }

    public class clsWCFTasaCreditoNegociable
    {
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public int idTipoTasaCredito { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsWCFAprobacionTasaNegociable
    {
        public int idError { get; set; }
        public string cMensaje { get; set; }
    }

    public class clsWCFDatosTasaNegociable
    {
        public int idError { get; set; }
        public string cMensaje { get; set; }
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public int idTipoTasaCredito { get; set; }
        public string cDescripcion { get; set; }
        public string cJustificacion { get; set; }
        public decimal nTasaNegociada { get; set; }
        public int idSolicitud { get; set; }
        public IList<clsWCFSeleccionTasaNegociable> lListaTasas { get; set; }
        public IList<clsWCFSeguimientoTasasNegociables> lSeguimiento { get; set; }
    }

    public class clsWCFSeleccionTasaNegociable
    {
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public int idTipoTasaCredito { get; set; }
        public string cDescripcion { get; set; }
        public decimal nTasaNegAprobada { get; set; }
        public decimal nTasaMoratoriaAproba { get; set; }
    }

    public class clsWCFSeguimientoTasasNegociables
    {
        public int idTasaNegociada { get; set; }
        public int idTasa { get; set; }
        public int nSolicitud { get; set; }
        public int idCli { get; set; }
        public string cNombreCliente { get; set; }
        public string cUsuAprob { get; set; }
        public decimal nTasaPreAprobada { get; set; }
        public decimal nTasaAprobada { get; set; }
        public decimal nTasaMoratoriaSol { get; set; }
        public int idEstado { get; set; }
        public string cDescEstado { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public int nCuotas { get; set; }
        public string cDescripTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public string dFechaDesembolso { get; set; }
        public string dFechaReg { get; set; }
        public decimal nTasaSolicitada { get; set; }
        public string cComentarioReg { get; set; }
        public string cUsuReg { get; set; }
        public string cFechaPre { get; set; }
        public decimal nTasaPre { get; set; }
        public string cComentarioPre { get; set; }
        public string cUsuPre { get; set; }
        public int idEstadoPre { get; set; }
        public string cFechaAprob { get; set; }
        public decimal nTasaAprob { get; set; }
        public string cComentarioAprob { get; set; }
        public int idSolAproba { get; set; }
    }

}
