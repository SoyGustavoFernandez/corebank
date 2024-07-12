using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CNE.AccesoDatos
{
    public class clsADPdp
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        
        public DataTable ADRptNeteo(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPAdmRptNeteo_SP", dFechaDesde, dFechaHasta);
        }
        public DataTable ADLogUsu(string cTransaccion, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPAdmLogUsuario_SP", cTransaccion, dFechaDesde, dFechaHasta);
        }
        public DataTable ADLogTransac(string cTransaccion, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPAdmRptTransac_SP", cTransaccion, dFechaDesde, dFechaHasta);
        }
        public DataTable ADEstProcConciliacion(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPEstProcConciliacion_SP", nModalidad, dFechaDesde, dFechaHasta);
        }
        public DataTable ADInterOpe(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPObtenerRptInterOpe_SP", nModalidad, dFechaDesde, dFechaHasta);
        }
        public DataTable ADLiqGes(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPLiqGesFees_SP", dFechaDesde, dFechaHasta);
        }
        public DataTable ADIncreSaldos(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPObtenerRptSaldosBilletera_SP", dFechaDesde, dFechaHasta);
        }
        public DataTable ADRptComisiones(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPRptComisiones_SP", dFechaDesde, dFechaHasta);
        }        
        public DataTable ADTipoTransac(int idModulo)
        {
            return objEjeSp.EjecSP("CNE_PDPLisTipTransac_SP", idModulo);
        }

        /* /// PDP Obtener Emisores y Estados /// */
        public DataTable ObtenerEmisores()
        {
            return objEjeSp.EjecSP("CNE_PDPListEmisores_SP");
        }
        public DataTable ObtenerEstados()
        {
            return objEjeSp.EjecSP("CNE_PDPListEstados_SP");
        }        

        /* /// PDP Gestionar Pagos /// */
        public DataTable ListarPagos(int nModulo, int idEmisor, int idEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNE_PDPListarPagos_SP", nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);
        }
        public DataTable ListarPago(int idSetPay)
        {
            return objEjeSp.EjecSP("CNE_PDPListarPago_SP", idSetPay);
        }
        public DataTable NuevoPago(int idSetPay, int idUsuario)
        {
            return objEjeSp.EjecSP("CNE_PDPNuevoPago_SP", idSetPay, idUsuario);
        }
        public DataTable GuardarPago(int idSetPay, int idEstado, int idUsuario, string cComentario)
        {
            return objEjeSp.EjecSP("CNE_PDPGuardarPago_SP", idSetPay, idEstado, idUsuario, cComentario);
        }
        public DataTable EnviarPago(string idSetPars, int idUsuario)
        {
            return objEjeSp.EjecSP("CNE_PDPEnviarPago_SP", idSetPars, idUsuario);
        }

        /* /// PDP Gestionar Depositos /// */
        public DataTable ListarDepositos(int nModulo, int idEmisor, int idEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNE_PDPListarDepositos_SP", nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);
        }
        public DataTable ListarDeposito(int idPDPSetDep)
        {
            return objEjeSp.EjecSP("CNE_PDPListarDeposito_SP", idPDPSetDep);
        }
        public DataTable NuevoDeposito(int nModalidad, int idPDPEmisor, int idUsuario, decimal nMonto, string cReceptor, string cNombres, string cApellidos, int idPDPEstado, string cMensaje)
        {
            return objEjeSp.EjecSP("CNE_PDPRegistrarDeposito_SP", nModalidad, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
        }
        public DataTable ActualizarDeposito(int nModalidad, int idPDPSetDep, int idPDPEmisor, int idUsuario, decimal nMonto, string cReceptor, string cNombres, string cApellidos, int idPDPEstado, string cMensaje)
        {
            return objEjeSp.EjecSP("CNE_PDPGuardarDeposito_SP", nModalidad, idPDPSetDep, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
        }
        public DataTable EnviarDeposito(string idSetDeps, int idUsuario)
        {
            return objEjeSp.EjecSP("CNE_PDPEnviarDeposito_SP", idSetDeps, idUsuario);
        }               

        /* /// PDP Reversa /// */
        public DataTable ListarDepRevParaGenValEnv(int nModalidad, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNE_PDPListarReversas_SP", nModalidad, dFechaInicial, dFechaFinal);
        }
        public DataTable RegistrarReversa(int nModalidad, int idSetDepOrRevDep, int idUsuario, string cMensaje)
        {
            return objEjeSp.EjecSP("CNE_PDPRegistroReversa_SP", nModalidad, idSetDepOrRevDep, idUsuario, cMensaje);
        }
        public DataTable EnviarReversa(string idSetRevDeps, int idUsuario)
        {
            return objEjeSp.EjecSP("CNE_PDPEnviarReversa_SP", idSetRevDeps, idUsuario);
        }

        /* --- Reportes 32A Y 32B */
        public DataTable ObtenerReporte32A(DateTime dFecInicial, DateTime dFecFinal)
        {
            return objEjeSp.EjecSP("CNE_PDPAnexo32A_SP", dFecInicial, dFecFinal);
        }
        public DataTable ObtenerReporte32B(int nTipoReporte, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNE_PDPAnexo32B_SP", nTipoReporte, dFechaInicial, dFechaFinal);
        }
        /* --- */

        /* --- Ingresar Saldo Fideicomiso --- */
        public DataTable ObtenerValorPatriFideicometido(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNE_PDPObtenerValorPatriFide_SP", dFecha);
        }

        public DataTable IngresarValorPatriFideicometido(int idPDPAnexo32ADet, decimal nValorPatriFide, decimal nValorDepDispInm, decimal nToValGar)
        {
            return objEjeSp.EjecSP("CNE_PDPIngresarValorPatriFide_SP", idPDPAnexo32ADet, nValorPatriFide, nValorDepDispInm, nToValGar);
        }
        /* --- */

        /* /// PDP Reportes SPLAFT /// */
        public DataTable ObtenerReporteClientesBimListasLaft(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPRptUsuariosBimVSBaseNegativa_SP", nModalidad, dFechaDesde, dFechaHasta);
        }

        public DataTable ObtenerReporteTransacClientesBimListasLaft(int nModalidad, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNE_PDPRptTransacUsuBimVSBaseNegativa_SP", nModalidad, dFechaDesde, dFechaHasta);
        }
    }
}