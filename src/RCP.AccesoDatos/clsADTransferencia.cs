using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADTransferencia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarResumenTransferencia()
        {
            return objEjeSp.EjecSP("RCP_ListarResumenTransfer_SP");
        }

        public DataTable ListaCreditosTransferencia(int idResumenTransferencia)
        {
            return objEjeSp.EjecSP("RCP_ListarCredTranfRecu_SP", idResumenTransferencia);
        }

        public object ListaCredTransfUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ListarCredTranfRecuUsuario_SP", idUsuario);
        }

        public DataTable ActualizarGlosa(int idCuenta, int idAsignacion, string cOpinion, int idMotivoMora, string cObservacion, DateTime dFechaSistema, bool lAutomatico, int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ActualizarGlosaAsigCartRecu_SP", idCuenta, idAsignacion, cOpinion, idMotivoMora, cObservacion, dFechaSistema, lAutomatico, idUsuario);
        }

        public DataTable ObtenerCreditoTransferido(int idInfPaseRecuperaciones)
        {
            return objEjeSp.EjecSP("RCP_ObtenerCredTranferido_SP", idInfPaseRecuperaciones);
        }

        public DataTable ListarIntervinientes(int idSolicitud)
        {
            return objEjeSp.EjecSP("RCP_ListarInterSolicitud_SP", idSolicitud);
        }

        public DataTable listarPromesas(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ListarPromesasCuenta_SP", idCuenta);
        }

        public DataTable listarGestiones(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ListarAccionesCuenta_SP", idCuenta);
        }

        public DataTable listarCredInformeAsesor(int idCuenta, int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListCredInformeAsesor_Sp", idCuenta, idAgencia);
        }
    }
}
