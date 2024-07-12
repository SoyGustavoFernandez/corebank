using CNT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.CapaNegocio
{
    public class clsCNAmortizacion
    {
        clsADAmortizacion objAmortiza = new clsADAmortizacion();
        public DataTable CNTipoIntangible()
        {
            return objAmortiza.ADTipoIntangible();
        }
        public DataTable CNComprobante(int idCompr)
        {
            return objAmortiza.ADComprobante(idCompr);
        }
        public DataTable CNActProAmorti()
        {
            return objAmortiza.ADActProAmorti();
        }
        public DataTable CNDetalleAmorti(int idItg)
        {
            return objAmortiza.ADDetalleAmorti(idItg);
        }
        public DataTable CNListaAmotizacionGen(int idItg)
        {
            return objAmortiza.ADListaAmortizacionGen(idItg);
        }
        public DataTable CNValidaComprobante(int idComprobante)
        {
            return objAmortiza.ADValidaComprobante(idComprobante);
        }

        public DataTable CNInsUpdAmorti(string cDetalleAmortiza, DateTime dFechaRegistro, int idTipoIntangible, int nPlazo,
                                        string cCuentaContableDebe, string cCuentaContableHaber, decimal nValorContable,
                                        decimal nAmortizaContable, decimal nValorNeto, int idUsuRegistro, int idEstado,
                                        string Detalle, int idIntangible, DateTime dFecIniAmort, int idMonedaGen, decimal nValConvert)
        {
            return objAmortiza.ADInsUpdAmorti(cDetalleAmortiza, dFechaRegistro, idTipoIntangible, nPlazo,
                                        cCuentaContableDebe, cCuentaContableHaber, nValorContable,
                                        nAmortizaContable, nValorNeto, idUsuRegistro, idEstado,
                                        Detalle, idIntangible, dFecIniAmort, idMonedaGen,nValConvert);
        }
        public DataTable CNReporteAmortizacion()
        {
            return objAmortiza.ADReporteAmortizacion();
        }
    }
}
