using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDeudasEval
    {
        public int idDeudasEval { get; set; }
        public int idEvalCred { get; set; }

        public int idTipoDeuda { get; set; }
        //public bool lCompraDeuda { get; set; }

        //public string cTipoCredito { get; set; }
        public int idTipoCredito { get; set; }
        public int idDeudaCA { get; set; }

        public string cCodigoEmpresa { get; set; }
        public string cNombreEmpresa { get; set; }
        public string cNombreIFI { get; set; }

        public int idCuenta { get; set; }
        public string cEstado { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }

        public int idMoneda { get; set; }
        public decimal nMontoAprobado { get; set; }
        public int nCuotasPag { get; set; }
        public int nCuotasPen { get; set; }
        public int nCuotasTotal
        {
            get { return (nCuotasPag + nCuotasPen); }
        }

        public decimal nSCapTotalSis { get; set; }
        public decimal nSCapTotal
        {
            get { return (nSCapCortoPlz + nSCapLargoPlz); }
        }
        public decimal nSCapCortoPlz { get; set; }
        public decimal nSCapLargoPlz { get; set; }

        //public decimal nCuotaMensual { get; set; }
        public decimal nMontoCuota { get; set; }
        public string cCronograma { get; set; }

        //public DateTime dFechaReporte { get; set; }
        public DateTime dFechaConsulta { get; set; }

        public int idMonedaMA { get; set; }

        /// <summary>
        /// Campo resultado que retorna Saldo Capital Corto Plazo convertido a Moneda definido en  el campo "idMonedaMA"
        /// </summary>
        public decimal nSCapCortoPlzMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nSCapCortoPlz, nTipoCambio);
            }
        }

        /// <summary>
        /// Campo resultado que retorna Saldo Capital Largo Plazo convertido a Moneda definido en  el campo "idMonedaMA"
        /// </summary>
        public decimal nSCapLargoPlzMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nSCapLargoPlz, nTipoCambio);
            }
        }

        /// <summary>
        /// Campo resultado que retorna Saldo Capital convertido a Moneda definido en  el campo "idMonedaMA"
        /// </summary>
        public decimal nSCapTotalMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nSCapTotal, nTipoCambio);
            }
        }

        /// <summary>
        /// Campo resultado que retorna Saldo Capital convertido a Moneda definido en  el campo "MONEDA EXTRANGERA"
        /// </summary>
        public decimal nSCapTotalME
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, 2, nSCapTotal, nTipoCambio);
            }
        }

        /// <summary>
        /// Campo resultado que retorna Saldo Capital convertido a Moneda definido en  el campo "MONEDA NACIONAL"
        /// </summary>
        public decimal nSCapTotalMN
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, 1, nSCapTotal, nTipoCambio);
            }
        }

        /// <summary>
        /// Campo resultado que retorna Monto de la Cuota en la moneda definida en el campo "idMonedaMA"
        /// </summary>
        public decimal nMontoCuotaMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nMontoCuota, nTipoCambio);
            }
        }

        public decimal nTipoCambio { get; set; }

        public bool lAutomatico { get; set; }

        public bool lUtilizada { get; set; }
        public string cUtilizada { get; set; }
        public int idTipoInterv { get; set; }
        public string cTipoInterv { get; set; }

        public List<clsCuotaPago> listCuotaPago { get; set; }
        public string cGUID { get; set; }        

        public clsDeudasEval()
        {
            idDeudasEval = 0;
            idTipoDeuda = 1;
            idDeudaCA = 1;
            cCodigoEmpresa = "99999";
            idCuenta = 0;
            idProducto = 0;
            nCuotasPag = 0;
            nCuotasPen = 0;
            nSCapCortoPlz = 0;
            nSCapLargoPlz = 0;
            idTipoCredito = 1;
            idMoneda = 1;
            nMontoAprobado = 0;
            nMontoCuota = 0;
            nSCapTotalSis = 0;
            nTipoCambio = 0;
            cCronograma = "";
            lAutomatico = false;

            lUtilizada = true;
            cUtilizada = string.Empty;
            idTipoInterv = 0;
            cTipoInterv = string.Empty;

            cGUID = System.Guid.NewGuid().ToString();
            listCuotaPago = new List<clsCuotaPago>();

            
        }

        public clsDeudasEval GetObject()
        {
            return (new clsDeudasEval()
            {
                idDeudasEval = this.idDeudasEval,
                idEvalCred = this.idEvalCred,
                idTipoDeuda = this.idTipoDeuda,
                idTipoCredito = this.idTipoCredito,
                idDeudaCA = this.idDeudaCA,
                cCodigoEmpresa = this.cCodigoEmpresa,
                cNombreEmpresa = this.cNombreEmpresa,
                cNombreIFI = this.cNombreIFI,
                idCuenta = this.idCuenta,
                cEstado = this.cEstado,
                idProducto = this.idProducto,
                cProducto = this.cProducto,
                idMoneda = this.idMoneda,
                nMontoAprobado = this.nMontoAprobado,
                nCuotasPag = this.nCuotasPag,
                nCuotasPen = this.nCuotasPen,
                nSCapTotalSis = this.nSCapTotalSis,
                nSCapCortoPlz = this.nSCapCortoPlz,
                nSCapLargoPlz = this.nSCapLargoPlz,
                nMontoCuota = this.nMontoCuota,
                cCronograma = this.cCronograma,
                dFechaConsulta = this.dFechaConsulta,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                lAutomatico = this.lAutomatico,
                listCuotaPago = this.listCuotaPago,
                cGUID = this.cGUID,

                lUtilizada = this.lUtilizada,
                cUtilizada = this.cUtilizada,
                idTipoInterv = this.idTipoInterv,
                cTipoInterv = this.cTipoInterv
            });
        }

    }
}
