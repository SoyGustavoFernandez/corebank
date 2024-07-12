using CNE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.CapaNegocio
{
    public class clsCNPdp
    {
        clsADPdp objCtrPdp = new clsADPdp();
        
        public DataTable cnNeteo(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADRptNeteo(dFechaDesde, dFechaHasta);
        }
        public DataTable cnLogUsu(string cTransaccion, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADLogUsu(cTransaccion, dFechaDesde, dFechaHasta);
        }
        public DataTable cnLogTransac(string cTransaccion, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADLogTransac(cTransaccion, dFechaDesde, dFechaHasta);
        }
        public DataTable cnEstProcConciliacion(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADEstProcConciliacion(nModalidad, dFechaDesde, dFechaHasta);
        }
        public DataTable cnInterOpe(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADInterOpe(nModalidad, dFechaDesde, dFechaHasta);
        }
        public DataTable cnLiqGes(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADLiqGes(dFechaDesde, dFechaHasta);
        }
        public DataTable cnIncreSaldos(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADIncreSaldos(dFechaDesde, dFechaHasta);
        }
        public DataTable cnRptComisiones (DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ADRptComisiones(dFechaDesde, dFechaHasta);
        }
        public DataTable cnTipoTransac(int idModulo)
        {
            return objCtrPdp.ADTipoTransac(idModulo);
        }

        /* /// PDP Obtener Emisores y Estados /// */
        public DataTable ObtenerEmisores()
        {
            return objCtrPdp.ObtenerEmisores();
        }
        public DataTable ObtenerEstados()
        {
            return objCtrPdp.ObtenerEstados();
        }        

        /* /// PDP Gestionar Pagos /// */
        public DataTable ListarPagos(int nModulo, int idEmisor, int idEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objCtrPdp.ListarPagos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);
        }
        public DataTable ListarPago(int idSetPar)
        {
            return objCtrPdp.ListarPago(idSetPar);
        }
        public DataTable NuevoPago(int idSetPay, int idUsuario)
        {
            return objCtrPdp.NuevoPago(idSetPay, idUsuario);
        }
        public DataTable GuardarPago(int idSetPar, int idEstado, int idUsuario, string cComentario)
        {
            return objCtrPdp.GuardarPago(idSetPar, idEstado, idUsuario, cComentario);
        }
        public DataTable EnviarPago(string idSetPars, int idUsuario)
        {
            return objCtrPdp.EnviarPago(idSetPars, idUsuario);
        }

        /* /// PDP Gestionar Deposito /// */
        public DataTable ListarDepositos(int nModulo, int idEmisor, int idEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objCtrPdp.ListarDepositos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);
        }

        public DataTable ListarDeposito(int idPDPSetDep)
        {
            return objCtrPdp.ListarDeposito(idPDPSetDep);
        }

        public DataTable NuevoDeposito(int nModalidad, int idPDPEmisor, int idUsuario, decimal nMonto, string cReceptor, string cNombres, string cApellidos, int idPDPEstado, string cMensaje)
        {
            return objCtrPdp.NuevoDeposito(nModalidad, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
        }

        public DataTable ActualizarDeposito(int nModalidad, int idPDPSetDep, int idPDPEmisor, int idUsuario, decimal nMonto, string cReceptor, string cNombres, string cApellidos, int idPDPEstado, string cMensaje)
        {
            return objCtrPdp.ActualizarDeposito(nModalidad, idPDPSetDep, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
        }

        public DataTable EnviarDeposito(string idSetDeps, int idUsuario)
        {
            return objCtrPdp.EnviarDeposito(idSetDeps, idUsuario);
        }

        /* /// PDP Reversa /// */
        public DataTable ListarDepRevParaGenValEnv(int nModalidad, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objCtrPdp.ListarDepRevParaGenValEnv(nModalidad, dFechaInicial, dFechaFinal);
        }

        public DataTable RegistrarReversa(int nModalidad, int idSetDepOrRevDep, int idUsuario, string cMensaje)
        {
            return objCtrPdp.RegistrarReversa(nModalidad, idSetDepOrRevDep, idUsuario, cMensaje);
        }

        public DataTable EnviarReversa(string idSetRevDeps, int idUsuario)
        {
            return objCtrPdp.EnviarReversa(idSetRevDeps, idUsuario);
        }        

        /* --- Reportes 32A Y 32B */
        public DataTable ObtenerReporte32A(DateTime dFecInicial, DateTime dFecFinal)
        {
            return objCtrPdp.ObtenerReporte32A(dFecInicial, dFecFinal);
        }

        public DataTable ObtenerReporte32B(int nTipoReporte, DateTime dFecInicial, DateTime dFecFinal)
        {
            return objCtrPdp.ObtenerReporte32B(nTipoReporte, dFecInicial, dFecFinal);
        }
        /* --- */        

        /* --- Ingresar Saldo Fideicomiso --- */
        public DataTable ObtenerValorPatriFideicometido(DateTime dFecha)
        {
            return objCtrPdp.ObtenerValorPatriFideicometido(dFecha);
        }

        public DataTable IngresarValorPatriFideicometido(int idPDPAnexo32ADet, decimal nValorPatriFide, decimal nValorDepDispInm, decimal nToValGar)
        {
            return objCtrPdp.IngresarValorPatriFideicometido(idPDPAnexo32ADet, nValorPatriFide, nValorDepDispInm, nToValGar);
        }
        /* --- */

        /* /// PDP Reportes SPLAFT /// */
        public DataTable ObtenerReporteClientesBimListasLaft(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ObtenerReporteClientesBimListasLaft(nModalidad, dFechaDesde, dFechaHasta);
        }

        public DataTable ObtenerReporteTransacClientesBimListasLaft(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objCtrPdp.ObtenerReporteTransacClientesBimListasLaft(nModalidad, dFechaDesde, dFechaHasta);
        }
    }

}