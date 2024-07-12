using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.AccesoDatos
{
    public class clsADAmortizacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADTipoIntangible()
        {
            return objEjeSp.EjecSP("CNT_TipoIntangible_sp");
        }
        public DataTable ADComprobante(int idCompr)
        {
            return objEjeSp.EjecSP("CNT_DatoComprobante_sp", idCompr);
        }
        public DataTable ADActProAmorti()
        {
            return objEjeSp.EjecSP("CNT_DatosActProyAmortizado_sp");
        }
        public DataTable ADDetalleAmorti(int idItg)
        {
            return objEjeSp.EjecSP("CNT_DetalleAmortItg_SP", idItg);
        }
        public DataTable ADListaAmortizacionGen(int idItg)
        {
            return objEjeSp.EjecSP("CNT_ListaAmortizacionGenerada_SP", idItg);
        }
        public DataTable ADValidaComprobante(int idComprobante)
        {
            return objEjeSp.EjecSP("CNT_ValidaRegistroComprobante_SP", idComprobante);
        }
        
        public DataTable ADInsUpdAmorti(string cDetalleAmortiza, DateTime dFechaRegistro, int idTipoIntangible, int nPlazo,
                                        string cCuentaContableDebe, string cCuentaContableHaber, decimal nValorContable,
                                        decimal nAmortizaContable, decimal nValorNeto, int idUsuRegistro, int idEstado,
                                        string Detalle, int idIntangible, DateTime dFecIniAmort, int idMonedaGen, decimal nValConvert)
        {
            return objEjeSp.EjecSP("CNT_InsUdpAmortIntg_sp", cDetalleAmortiza, dFechaRegistro, idTipoIntangible, nPlazo,
                                        cCuentaContableDebe, cCuentaContableHaber, nValorContable,
                                        nAmortizaContable, nValorNeto, idUsuRegistro, idEstado,
                                        Detalle, idIntangible, dFecIniAmort, idMonedaGen, nValConvert);
        }
        public DataTable ADReporteAmortizacion()
        {
            return objEjeSp.EjecSP("CNT_ReporteAmortizacion_SP");
        }
    }
}
