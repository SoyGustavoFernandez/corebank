using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.AccesoDatos
{
    public class clsRPTADReporte
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaReportesSBS(string cCodigoSBS)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListaReportesSBS_sp", cCodigoSBS);
        }
        public DataTable ADRetornaValorFSD(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_RetornaCoberturaFSD_SP", dFecha);
        }
        public DataTable ADConsultaUtiAccBas(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_ConsultaUtiAccBas_sp", dFecha);
        }
        public DataTable ADInsActUtiBasDil( DateTime dFecha, decimal nAccBas, decimal nAccDil, 
                                            decimal nUtiPer, int idUsuario, DateTime dFecReg)
        {
            return new clsGENEjeSP().EjecSP("RPT_RegistraUtiAccBas_sp", dFecha, nAccBas, nAccDil,
                                                                        nUtiPer, idUsuario, dFecReg);
        }
        public DataTable ADInsMuestraAnexo9(string XmlDetalle)
        {
            return new clsGENEjeSP().EjecSP("RPT_InsertaMuestraTipoCambio_sp", XmlDetalle);
        }
        public DataTable ADInsDatosInversion(string XmlDetalle, DateTime dFecha, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RPT_InsertaDatosInversiones_sp", XmlDetalle, dFecha, idUsuario);
        }
        public DataTable ADExtraeFechaTipoCambioCNT()
        {
            return new clsGENEjeSP().EjecSP("RPT_FecUltTipCamContable_SP");
        }
        public DataTable ADInsDatInvValRaz(string XmlDetalle, string XmlDetalleTes, DateTime dFecha, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RPT_InsDatInvValRaz_sp", XmlDetalle, XmlDetalleTes, dFecha, idUsuario);
        }
        public DataSet ADReporteRR3(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return objEjeSp.DSEjecSP("RPT_ReporteRR3_SP", dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet ADReporteRR3CajCorresp(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return objEjeSp.DSEjecSP("RPT_ReporteRR3CajCorresp_SP", dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet ADReporteRR3BIM(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return objEjeSp.DSEjecSP("RPT_ReporteRR3BIM_SP", dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
        public DataSet ADReporteRR3PagoWEB(DateTime dPrimerDiaDelMes, DateTime dUltimoDiaDelMes)
        {
            return objEjeSp.DSEjecSP("RPT_ReporteRR3PagoWeb_SP", dPrimerDiaDelMes, dUltimoDiaDelMes);
        }
    }
}
