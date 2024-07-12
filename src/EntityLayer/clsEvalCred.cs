using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCred
    {
        public int idEvalCred { get; set; }
        public int idTipEvalCred { get; set; }
        public string cTipEvalCred { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }

        public int idProducto { get; set; }
        public string cTipoProducto { get; set; }
        public string cSubProducto { get; set; }
        public int idSubProducto { get; set; }

        public decimal nCapitalPropuesto { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public int nCuotas { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public int idTasa { get; set; }
        public decimal nTEA { get; set; }
        public decimal nTEM { get; set; }
        public decimal nCuotaAprox { get; set; }

        public DateTime dFecUltimaEval { get; set; }
        public DateTime dFecActualEval { get; set; }
        public decimal nCajaInicial { get; set; }
        public decimal nRCCPc1 { get; set; }
        public decimal nRCCPc2 { get; set; }
        public decimal nRCCPc3 { get; set; }

        public decimal nProvBG { get; set; }
        public decimal nProvER { get; set; }

        public int idActividad { get; set; }
        public int idSectorEcon { get; set; }
        public bool lActSecundaria { get; set; }
        public int idActividadInternaPri { get; set; }
        public int idTipoActividadPri { get; set; }
        public int nActPriAnios { get; set; }
        public string cActPriDireccion { get; set; }
        public string cActPriReferencia { get; set; }
        public string cActPriDescripcion { get; set; }
        public int idActividadInternaSec { get; set; }
        public int idTipoActividadSec { get; set; }
        public int nActSecAnios { get; set; }
        public string cActSecDireccion { get; set; }
        public string cActSecReferencia { get; set; }
        public string cActSecDescripcion { get; set; }

        public string cComEntFamiliar { get; set; }
        public string cComDestCredito { get; set; }
        public string cComAnteCred { get; set; }
        public string cComAnalisisFinan { get; set; }
        public string cComGarantias { get; set; }
        public string cComConclusiones { get; set; }
        public string cComSustentoCredito { get; set; }

        public int idTipoPersona { get; set; }
        public decimal nTipoCambio { get; set; }
        public bool lEstado { get; set; }
        public decimal nSaldoAcumuladoInicial { get; set; }
        public decimal nDisponibleInicial { get; set; }
        public decimal nSaldoAcumuladoFinal { get; set; }
        public int idCultivoEval { get; set; }
        public int idVariedadCultivoEval { get; set; }
        public int idClasificacionInterna { get; set; }

        public string cComPropCliente { get; set; }
        public string cComPropCredito { get; set; }

        public clsEvalCred()
        {
            this.idEvalCred = 0;

            this.nCuotasGracia = 0;
            this.nCuotaGraciaAprox = 0;
            this.nTotalMontoPagar = 0;
            this.cCalendarioPagos = "";
            //this.dtCalendarioPagos = new DataTable();



            //clsVarGlobal.User.idEstablecimiento,
            //clsVarGlobal.User.idTipoEstablec,


            //public int idCanalAproCred { get; set; }
            //public int idEstablecimiento { get; set; }
            //public int idTipoEstablec { get; set; }
        }

        public int idCatLab { get; set; }
        public int nTipIngreso { get; set; }
        public bool lCargoRcc { get; set; }

        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idAgencia { get; set; }
        public decimal nTotalDeudas { get; set; }
        public bool lExpuestoRcc { get; set; }
        public decimal nTotalPasivoAC { get; set; }

        public decimal nMontoCuotaMaxEndeudamiento { get; set; }
        public decimal nRatCapacPago { get; set; }
        public bool lEditar { get; set; }

        public int nPlazo { get; set; }
        public int nCuotasGracia { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }
        public DataTable dtCalendarioPagos { get; set; }
        public string cCalendarioPagos { get; set; }
        public decimal nTotalMontoPagar { get; set; }
        public decimal nRemBruta { get; set; }
        public int idMonedaRemBruta { get; set; }
        public int idEmpresaConvenio { get; set; }
        public decimal nPorCuotaMax { get; set; }

        public int idCanalAproCred { get; set; }
        public int idEstablecimiento { get; set; }
        public int idTipoEstablec { get; set; }

        public decimal nActivoAdquirir { get; set; }

        public decimal nDestinoCapitalTrabajo { get; set; }
        public decimal nCapitalParacomercio { get; set; }
        public int nCodigoSectorEconomico { get; set; }

        #region métodos públicos
        public int obtenerNumeroMeses()
        {
            if (this.idTipoPeriodo == 1)
            {
                return this.nCuotas;
            }
            else if (this.idTipoPeriodo == 2)
            {
                if ((this.nCuotas * this.nPlazoCuota) % 30 == 0)
                {
                    return (this.nCuotas * this.nPlazoCuota) / 30;
                }
                else
                {
                    return (this.nCuotas * this.nPlazoCuota) / 30 + 1;
                }
            }
            else if (this.idTipoPeriodo == 3)
            {
                return Convert.ToInt32(clsVarApl.dicVarGen["nPlazoMaxEvalRural"]);
            }
            return 0;
        }

        #endregion
    }
}