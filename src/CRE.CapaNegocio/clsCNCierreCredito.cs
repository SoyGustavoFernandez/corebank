using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNCierreCredito
    {
        clsADCierreCredito ObjCredito = new clsADCierreCredito();
        public DataTable CNdtCierreCre()
        {
            return ObjCredito.ADdtCierreCre();
        }

        public DataTable ProcesoCieDia(string cNombreSp,int nIdproc)
        {
            return ObjCredito.EjeProCierre(cNombreSp, nIdproc);
        }

        public int CNCodigoEjecucionCierrePorFecha(DateTime dFechaProceso)
        {
            int nEjecucionCierre = 1;
            
            ObjCredito.ADCodigoEjecucionCierrePorFecha(dFechaProceso, ref nEjecucionCierre);

            return nEjecucionCierre;
        }

        public DataTable CNInsertarLogProcesoCierre(DateTime dFechaProceso, int idProceso, int nEjecucionCierre, int idUsuario, string cMensaje)
        {
            return ObjCredito.ADInsertarLogProcesoCierre(dFechaProceso, idProceso, nEjecucionCierre, idUsuario, cMensaje);
        }

        public DataTable CNrptCierreDiario(DateTime dFechaProceso)
        {
            return ObjCredito.ADrptCierreDiario(dFechaProceso);
        }
    }
}
