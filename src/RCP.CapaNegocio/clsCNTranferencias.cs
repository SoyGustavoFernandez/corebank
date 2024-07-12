using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNTranferencias
    {
        clsADTransferencia adTransferencia = new clsADTransferencia();

        public DataTable ListarResumenTransferencia()
        {
            return adTransferencia.ListarResumenTransferencia();
        }

        public DataTable ListaCreditosTransferencia(int idResumenTransferencia)
        {
            return adTransferencia.ListaCreditosTransferencia(idResumenTransferencia);
        }

        public object ListaCredTransfUsuario(int idUsuario)
        {
            return adTransferencia.ListaCredTransfUsuario(idUsuario);
        }

        public DataTable ActualizarGlosa(int idCuenta, int idAsignacion, string cOpinion, int idMotivoMora, string cObservacion, DateTime dFechaSistema, bool lAutomatico, int idUsuario)
        {
            return adTransferencia.ActualizarGlosa(idCuenta, idAsignacion, cOpinion, idMotivoMora, cObservacion, dFechaSistema, lAutomatico, idUsuario);
        }

        public DataTable ObtenerCreditoTransferido(int idInfPaseRecuperaciones)
        {
            return adTransferencia.ObtenerCreditoTransferido(idInfPaseRecuperaciones);
        }

        public DataTable ListarIntervinientes(int idSolicitud)
        {
            return adTransferencia.ListarIntervinientes(idSolicitud);
        }

        public DataTable listarGestiones(int idCuenta)
        {
            return adTransferencia.listarGestiones(idCuenta);
        }

        public DataTable listarPromesas(int idCuenta)
        {
            return adTransferencia.listarPromesas(idCuenta);
        }

        public DataTable listarCredInformeAsesor(int idCuenta, int idAgencia)
        {
            return adTransferencia.listarCredInformeAsesor(idCuenta, idAgencia);
        }
    }
}
