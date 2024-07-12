using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace RCP.AccesoDatos
{
    public class clsADCreditoCastigo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADBuscarPosiblesCredParaCastigo(string cAgencias, int nDiasAtras, int idClasifi, decimal nProvision, DateTime dFecha, int nDiasImpagos)
        {
            return objEjeSp.EjecSP("RCP_ListaPosiblesCreditosParaCastigar_SP", cAgencias, nDiasAtras, idClasifi, nProvision, dFecha, nDiasImpagos);
        }
        public DataTable ADMotivosCastigo()
        {
            return objEjeSp.EjecSP("RCP_RetornoMotivoCastigo_SP");
        }
        public DataTable ADGuargarListaCreditosParaCastigo(string listaCreditos, Nullable<DateTime> dFechaCastigo, int idUsuario
                , int idUsuarioMod, DateTime dFecha, int idEstado, int idLista)
        {
            Object dFC;
            if (dFechaCastigo == null)
            {
                dFC = DBNull.Value;
            }
            else
            {
                dFC = dFechaCastigo;
            }
            return objEjeSp.EjecSP("RCP_RegistraListaCreditosCastigados_SP", listaCreditos, dFC, idUsuario, idUsuarioMod, dFecha, idEstado, idLista);
        }
        public DataTable ADListarCredParaCastigo(int idLista)
        {
            return objEjeSp.EjecSP("RCP_ListaCreditosParaCastigar_SP", idLista);
        }
        public DataTable ADListaCreditosCastGuardados(int idLista, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosCastGuardados_SP", idLista, dFecha);
        }
        public DataTable ADAnexo7(int idLista, DateTime dFecha, int nFiltro)
        {
            return objEjeSp.EjecSP("RCP_Anexo7Recuperaciones_SP", idLista, dFecha, nFiltro);
        }
        public DataTable ADAsignarCodigo(int idLista, string cCodigo, int idEstado, string cResolucion, DateTime dFechaCastigo)
        {
            return objEjeSp.EjecSP("RCP_ActualizarCodigoLista_SP", idLista, cCodigo, idEstado, cResolucion, dFechaCastigo);
        }

        public DataTable ADRptGarantiasDeCredVencidos(string cAgencias, int nDiasAtras, int idClasifi, decimal nProvision, DateTime dFecha, int nDiasImpagos)
        {
            return objEjeSp.EjecSP("RPC_RptGarantiasDeCredVencidos_SP", cAgencias, nDiasAtras, idClasifi, nProvision, dFecha, nDiasImpagos);
        }
    }
}
