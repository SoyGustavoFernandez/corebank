using RPT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.CapaNegocio
{
    public class clsRPTCNReporte
    {
        clsRPTADReporte ADReporte = new clsRPTADReporte();
        public DataTable CNListaReportesSBS(string cCodigoSBS)
        {
            return ADReporte.ADListaReportesSBS(cCodigoSBS);
        }
        public DataTable CNRetornaValorFSD(DateTime dFecha)
        {
            return ADReporte.ADRetornaValorFSD(dFecha);
        }
        public DataTable CNConsultaUtiAccBas(DateTime dFecha)
        {
            return ADReporte.ADConsultaUtiAccBas(dFecha);
        }
        public DataTable CNInsActUtiBasDil(DateTime dFecha, decimal nAccBas, decimal nAccDil,
                                            decimal nUtiPer, int idUsuario, DateTime dFecReg)
        {
            return ADReporte.ADInsActUtiBasDil(dFecha, nAccBas, nAccDil,
                                               nUtiPer, idUsuario, dFecReg);
        }
        public DataTable CNInsMuestraAnexo9(string XmlDetalle)
        {
            return ADReporte.ADInsMuestraAnexo9(XmlDetalle);
        }
        public DataTable CNInsDatosInversion(string XmlDetalle, DateTime dFecha, int idUsuario)
        {
            return ADReporte.ADInsDatosInversion(XmlDetalle, dFecha, idUsuario);
        }
        public DataTable CNExtraeFechaTipoCambioCNT()
        {
            return ADReporte.ADExtraeFechaTipoCambioCNT();
        }
        public DataTable ADInsDatInvValRaz(string XmlDetalle, string XmlDetalleTes, DateTime dFecha, int idUsuario)
        {
            return ADReporte.ADInsDatInvValRaz(XmlDetalle, XmlDetalleTes, dFecha, idUsuario);
        }
        public DataSet CNReporteRR3(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return ADReporte.ADReporteRR3(dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet CNReporteRR3CajCorresp(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return ADReporte.ADReporteRR3CajCorresp(dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet CNReporteRR3BIM(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return ADReporte.ADReporteRR3BIM(dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet CNReporteRR3PagoWEB(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return ADReporte.ADReporteRR3PagoWEB(dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
    }
}
