using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using RCP.AccesoDatos;

namespace RCP.CapaNegocio
{
    public class clsCNCreditoCastigo
    {
        clsADCreditoCastigo adCreditoCastigo = new clsADCreditoCastigo();
        public DataTable CNBuscarPosiblesCredParaCastigo(string cAgencias, int nDiasAtras, int idClasifi, decimal nProvision, DateTime dFecha, int nDiasImpagos)
        {
            return adCreditoCastigo.ADBuscarPosiblesCredParaCastigo(cAgencias, nDiasAtras, idClasifi, nProvision, dFecha, nDiasImpagos);
        }
        public DataTable CNMotivosCastigo()
        {
            return adCreditoCastigo.ADMotivosCastigo();
        }
        public DataTable CNGuargarListaCreditosParaCastigo(string listaCreditos, Nullable<DateTime> dFechaCastigo, int idUsuario
                , int idUsuarioMod, DateTime dFecha, int idEstado, int idLista)
        { 
            return adCreditoCastigo.ADGuargarListaCreditosParaCastigo(listaCreditos, dFechaCastigo, idUsuario, idUsuarioMod, dFecha, idEstado, idLista);
        }
        public DataTable CNListarCredParaCastigo(int idLista)
        {
            return adCreditoCastigo.ADListarCredParaCastigo(idLista);
        }
        public DataTable CNListaCreditosCastGuardados(int idLista, DateTime dFecha)
        {
            return adCreditoCastigo.ADListaCreditosCastGuardados(idLista, dFecha);
        }
        public DataTable CNAnexo7(int idLista, DateTime dFecha, int nFiltro)
        {
            return adCreditoCastigo.ADAnexo7(idLista, dFecha, nFiltro);
        }
        public DataTable CNAsignarCodigo(int idLista, string cCodigo, int idEstado, string cResolucion, DateTime dFechaCastigo)
        {
            return adCreditoCastigo.ADAsignarCodigo(idLista, cCodigo, idEstado, cResolucion, dFechaCastigo);
        }
        public DataTable CNRptGarantiasDeCredVencidos(string cAgencias, int nDiasAtras, int idClasifi, decimal nProvision, DateTime dFecha, int nDiasImpagos)
        {
            return adCreditoCastigo.ADRptGarantiasDeCredVencidos(cAgencias, nDiasAtras, idClasifi, nProvision, dFecha, nDiasImpagos);
        }
    }
}
