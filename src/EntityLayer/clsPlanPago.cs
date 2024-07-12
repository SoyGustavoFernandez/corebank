using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Entidad cuota que contiene las caracteristicas de un registro del plan de pagos
    /// </summary>
    [Serializable]
    public class clsCuota:ICloneable
    {
        public int idCuenta { get; set; }
        public int idPlanPago { get; set; }
        public int idCuota { get; set; }
        public int idTipoCuota { get; set; }
        public int idEstadocuota { get; set; }
        public DateTime dFechaProg { get; set; }
        public object dFechaPago { get; set; }
        public object dFechaValor { get; set; }
        public decimal nCapital { get; set; }
        public decimal nCapitalPagado { get; set; }
        private decimal _nCapitalSaldo;
        public decimal nCapitalSaldo
        {
            get { return nCapital-nCapitalPagado; }
            set { _nCapitalSaldo = value; }
        }
        public decimal nInteres { get; set; }
        public decimal nInteresFecha { get; set; }
        public decimal nInteresPagado { get; set; }
        private decimal _nInteresSaldo;
        public decimal nInteresSaldo
        {
            get { return nInteres - nInteresPagado; }
            set { _nInteresSaldo = value; }
        }
        private decimal _nInteresFechaSaldo;
        public decimal nInteresFechaSaldo
        {
            get { return nInteresFecha - nInteresPagado; }
            set { _nInteresFechaSaldo = value; }
        }
        public decimal nIntComp { get; set; }
        public decimal nInteresCompPago { get; set; }
        private decimal _nIntCompSaldo;
        public decimal nIntCompSaldo
        {
            get { return nIntComp - nInteresCompPago; }
            set { _nIntCompSaldo = value; }
        }
        public decimal nOtros { get; set; }
        public decimal nOtrosPagado { get; set; }
        private decimal _nOtrosSaldo;

        public decimal nOtrosSaldo
        {
            get { return nOtros-nOtrosPagado; }
            set { _nOtrosSaldo = value; }
        }

        public decimal nMora { get; set; }
        public decimal nMoraPagada { get; set; }
        private decimal _nMoraSaldo;

        public decimal nMoraSaldo
        {
            get { return nMora-nMoraPagada; }
            set { _nMoraSaldo = value; }
        }

        public int nNumDiaCuota { get; set; }
        public int nAtrasoCuota { get; set; }
        public int idAgencia { get; set; }

        public decimal nMonCuota { get; set; }

        public int idModPagoCre { get; set; }

        public decimal nSaldoCapital { get; set; }

        public decimal nItf { get; set; }
        public decimal nComisiones { get; set; }
        public decimal nImpCuota { get; set; }
        public int idSolicitud { get; set; }
        public int nDiasAcu { get; set; }
        public decimal FRC { get; set; }

        public int idContable { get; set; }

        //Campo Sin seguro
        public decimal nOtrosSinSeg { get; set; }
        public bool lCuotaPrepago { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        private bool ldiferido = false;
        public bool lDiferido { 
            get{
                return ldiferido;
            }
            set{
                ldiferido = value;
            }
        }

        public object Clone()
        {
            clsCuota clone = (clsCuota)this.MemberwiseClone();

            return clone;

        }

        public bool ShouldSerializedFechaPago()
        {
            return dFechaPago != null;
        }
    }

    /// <summary>
    /// Entidad plan de pagos, es un listado de entidades clsCuota
    /// </summary>
    [Serializable]
    public class clsPlanPago : List<clsCuota>, ICloneable

    {
        public object Clone()
        {
            var clone = new clsPlanPago();
            ForEach(item => clone.Add((clsCuota)item.Clone()));
            return clone;

        }
    }

    public enum ModalidadPagoCre
    {
        PagoNormal = 1,
        CancelacionAnticipada = 2,
        CondonacionDeuda = 3,
        PrePago = 4,
        Otros=5
    }
}
