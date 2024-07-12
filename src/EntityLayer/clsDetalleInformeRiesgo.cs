using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetalleInformeRiesgo
    {
       //Cabecera 
        //Tipo de lectura
		public Boolean lNuevo { get; set; }
		public Boolean lReconsidera { get; set; }
		public Boolean lEditable { get; set; }
        public int idDetalleInformeRsg { get; set; }
        //DatosCliente
        public string cNombreCliente { get; set; }
        public string cDocumento { get; set; }
        public int idCli { get; set; }
        public string cOperacion { get; set; }//
        public int idOperacion { get; set; }
        public string cTipoCliente { get; set; }
        public int idTipoCliente { get; set; }
        //DatosCredito
        public decimal nMonto { get; set; }
        public string cMoneda { get; set; }
        public int idMoneda { get; set; }
		public string cActEconomica { get; set; }
        public int idActEconomica { get; set; }
		public string cModalidad { get; set; }//
		public int idModalidad { get; set; }
        public string cTipoCredito { get; set; }
        public string cSubProducto { get; set; }
        public int idSubProducto { get; set; }
        //DatosAsesor
        public string cOficina { get; set; }
        public int idOficina { get; set; }
        public string cNombreAsesor { get; set; }
        public int idUsuarioAsesor { get; set; }
        public decimal nMoraOrigen { get; set; }
        public decimal nMoraRsgPotencial { get; set; }
        //Destino de crédito
        public string cDestinoCredito { get; set; }
        public decimal nPromDiasAtraso { get; set; }
        public decimal nSaldoVigCraclasa { get; set; }
        public decimal nFinanCraclasaImporte { get; set; }
        public decimal nAportePropImporte { get; set; }
        public string cComentario1 { get; set; }
        //Análisis de endeudamiento y análisis cualitativo
        public decimal nDeudaActualSF { get; set; }
        public decimal nTechoMaxEndeud { get; set; }
        public int nEntidadesAFecha { get; set; }
        public decimal nEscalonamientoDeuda { get; set; }
        public decimal nDeudaActualYPropuesto { get; set; }
        public int nTiempoActividad { get; set; }
        public int nTiempoResidencia { get; set; }
        public string cTipoVivienda { get; set; }
        public int idTipoVivienda { get; set; }
        public string cComentario2 { get; set; }
        //Análisis cuantitativo
        public decimal nRatioLiquidez { get; set; }
        public string cComentario3 { get; set; }
        //Colateral
        public string cGarantia { get; set; }
        public string cComentario4 { get; set; }
        //Administración de riesgo
        public string cTipoRiesgo { get; set; }
        public string cNivelRiesgo { get; set; }
        public string cComentario5 { get; set; }
        //Resultado
        public string cAnalistaRsg { get; set; }
        public int idUsuarioAnalistaRsg { get; set; }
        public bool lVisitaNegocio { get; set; }
        public bool lOpinion1 { get; set; }
        public DateTime dFechaSolicitud { get; set; }
		public DateTime? dFechaIngresoGerRisg { get; set; }
		public DateTime dFechaRecepcionSustento { get; set; }
		public DateTime dEnvioObs { get; set; }
		public DateTime dLevantamientoObs { get; set; }
        public DateTime? dFechaSalida { get; set; }
        public string cSustento1 { get; set; }
        //Reconsideración
        public bool? lOpinion2 { get; set; }
		public string cSustento2 { get; set; }
		public DateTime? dFechaSalida2 { get; set; }
		public int? idUsuarioReconsidera { get; set; }
		public string cUsuarioReconsidera { get; set; }
        public int idEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idTipEvalCred { get; set; }

        public string cFechaSolicitud { get; set; }
        public string cFechaIngresoGerRisg { get; set; }
        public string cFechaRecepcionSustento { get; set; }
        public string cEnvioObs { get; set; }
        public string cLevantamientoObs { get; set; }
        public string cFechaSalida { get; set; }
        public int lOpinion1_2 { get; set; }
        public int lOpinion2_2 { get; set; }
        public string cFechaSalida2 { get; set; }
        public int nReconsidera { get; set; }
        public string cMotivoRiesgo { get; set; }
        public bool lAtendido { get; set; }
        public string cMotivoRiesgoResu { get; set; }
        public bool lFavorable { get; set; }
        public int idPerfilRecon { get; set; }
        public int idPerfilAnalista { get; set; }
        public string cPerfilRecon { get; set; }
        public string cPerfilAnalista { get; set; }
        public int idAnalistaAtiende { get; set; }
    }
    public class clsComposicionCredito
    {
        public string cDestino { set; get; }
        public decimal nMonto { set; get; }
        public decimal nPorcentaje { set; get; }
    }
	public class clsIndicadoresFinancieros
	{
		public string cDescripcion { set; get; }
		public string cDescFormula { set; get; }
		public decimal nRatio { set; get; }
		public string cDescRegla { set; get; }
	}
}
