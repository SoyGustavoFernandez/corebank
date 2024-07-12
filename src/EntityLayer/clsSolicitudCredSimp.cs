using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EntityLayer
{
    public class clsSolicitudCredSimp
    {
        public int idSolicitud { get; set; }

        public int idCli { get; set; }

        public int idProducto { get; set; }
        public clsProductoCredSimp objProductoCredSimp { get; set; }

        public int idEstado { get; set; }

        public int idOperacion { get; set; }

        public int idMoneda { get; set; }

        public int idUsuario { get; set; }

        public int nCuotas { get; set; }

        public int nPlazoCuota { get; set; }

        public decimal nCapitalSolicitado { get; set; }

        public decimal nTasaCompensatoria { get; set; }

        public decimal nTasaMoratoria { get; set; }

        public DateTime dFechaRegistro { get; set; }

        public DateTime dFechaDesembolsoSugerido { get; set; }

        public string tObservacion { get; set; }

        public int idDestino { get; set; }

        public int idAgencia { get; set; }

        public int idTasa { get; set; }
        public clsTasaCredSimp objTasaCredSimp { get; set; }

        public int idModalidadDes { get; set; }

        public int nDiasGracia { get; set; }

        public int idActividad { get; set; }

        public int idTipoPeriodo { get; set; }

        public int idRecurso { get; set; }

        public decimal nMontoAmpliado { get; set; }

        public decimal nSaldoCreditos { get; set; }

        public int idModalidadCredito { get; set; }

        public int idActividadInterna { get; set; }

        public int nCuotasGracia { get; set; }

        public bool lConTasaNegociable { get; set; }

        public decimal nCuotaAprox { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }

        public DateTime dFechaPrimeraCuota { get; set; }

        public int idSectorEconomico { get; set; }

        public int idDetalleGasto { get; set; }

        public decimal nMontoSaldoRCC { get; set; }

        public int idZona { get; set; }
        public int idTipoCli { get; set; }
        public int idModalidadPago { get; set; }
        public int idCanalVendedor { get; set; }
        public int idPromotor { get; set; }

        public clsSolicitudCredSimp()
        {
            this.idSolicitud                    = 0;
            this.idCli                          = 0;
            this.idProducto                     = 0;
            this.objProductoCredSimp            = new clsProductoCredSimp();
            this.idEstado                       = 0;
            this.idOperacion                    = 0;
            this.idMoneda                       = 0;
            this.idUsuario                      = 0;
            this.nCuotas                        = 0;
            this.nPlazoCuota                    = 0;
            this.nCapitalSolicitado             = 0;
            this.nTasaCompensatoria             = 0;
            this.nTasaMoratoria                 = 0;
            this.dFechaRegistro                 = DateTime.Now;
            this.dFechaDesembolsoSugerido       = DateTime.Now;
            this.tObservacion                   = String.Empty;
            this.idDestino                      = 0;
            this.idAgencia                      = 0;
            this.idTasa                         = 0;
            this.objTasaCredSimp                = new clsTasaCredSimp();
            this.idModalidadDes                 = 0;
            this.nDiasGracia                    = 0;
            this.idActividad                    = 0;
            this.idTipoPeriodo                  = 0;
            this.idRecurso                      = 0;
            this.nMontoAmpliado                 = 0;
            this.nSaldoCreditos                 = 0;
            this.idModalidadCredito             = 0;
            this.idActividadInterna             = 0;
            this.nCuotasGracia                  = 0;
            this.lConTasaNegociable             = false;
            this.nCuotaAprox                    = 0;
            this.nCuotaGraciaAprox              = 0;
            this.dFechaPrimeraCuota             = DateTime.Now;
            this.idSectorEconomico              = 0;
            this.idDetalleGasto                 = 0;
            this.nMontoSaldoRCC                 = 0;
            this.idZona                         = 0;
            this.idTipoCli                      = 0;
            this.idModalidadPago                = 0;
            this.idCanalVendedor                = 0;
            this.idPromotor                     = 0;    
        }

    }
}
