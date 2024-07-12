using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudGrupoSol
    {
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public DateTime dFechaDesembolsoPropuesto { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        public int idAgencia { get; set; }
        public int idOperacion { get; set; }
        public int nCuotas { get; set; }
        public int nCuotasGracia { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public int idMoneda { get; set; }
        public int idModalidadCredito { get; set; }
        public string cModalidadCredito { get; set; }

    }

    public class clsSolCreIntegranteGrupoSol
    {
        public int idSolicitudCredGrupoSol { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int idAgencia { get; set; }
        public int idOperacion { get; set; }
        public int idUsuario { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaDesembolsoPropuesto { get; set; }
        public int nCuotas { get; set; }
        public int nDiasGracia { get; set; }
        public int nCuotasGracia { get; set; }
        public int idSolicitud { get; set; }
        public decimal nTasaAprobada { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nCapitalAprobado { get; set; }
        public int idMoneda { get; set; }
        public string cNombre { get; set; }
        public string cDocumentoID { get; set; }
        public string cXmlPlanPagos { get; set; }
        public bool lSelImpresion { get; set; }
        public bool lSelGeneraPlanPagos { get; set; }
        public int idCli { get; set; }
        public bool lAplicaSeguro { get; set; }
        public decimal nCapitalMaxCobSeg { get; set; }
        public DateTime dFechaUltimoPagoCredito { get; set; }
        public decimal nTCEA { get; set; }
        public int idDetalleGasto { get; set; }
        public int idPaqueteSeguro { get; set; }
        public int idFrmPaqueteSeguro { get; set; }
    }
}
