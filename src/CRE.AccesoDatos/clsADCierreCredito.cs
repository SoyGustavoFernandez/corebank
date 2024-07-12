using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADCierreCredito
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADdtCierreCre()
        {
            return objEjeSp.EjecSP("CRE_LisDetalleProCierre_SP");
        }

        public DataTable EjeProCierre(string NomSp,int nidPro)
        {
            return objEjeSp.EjecSP(NomSp, nidPro);
        }

        public void ADCodigoEjecucionCierrePorFecha(DateTime dFechaProceso, ref int nEjecucionCierre)
        {
            List<clsGENParams> lisParametros;

            lisParametros = objEjeSp.EjecSPOut("ADM_CodigoEjecucionCierrePorFecha_SP", dFechaProceso, nEjecucionCierre);

            nEjecucionCierre = Convert.ToInt32(lisParametros[0].Parametro.Value);
        }

        public DataTable ADInsertarLogProcesoCierre(DateTime dFechaProceso, int idProceso, int nEjecucionCierre, int idUsuario, string cMensaje)
        {
            return objEjeSp.EjecSP("ADM_InsertarLogProcesoCierre_SP", dFechaProceso, idProceso, nEjecucionCierre, idUsuario, cMensaje);
        }

        public DataTable ADrptCierreDiario(DateTime dFechaProceso)
        {
            return objEjeSp.EjecSP("ADM_rptCierreDiario_SP", dFechaProceso);
        }
    }
}
