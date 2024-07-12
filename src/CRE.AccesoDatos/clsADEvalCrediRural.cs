using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADEvalCrediRural
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet InicializarEvalCrediRural()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarEvalCrediRural_Sp");
        }

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalCrediRural_SP", idEvalCred);
        }

        public DataTable ADValidarVisitas(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalPyme_Sp", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalPyme_Sp", idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCredTemp, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCredTemp, lCanalAproCredEditable);
        }

        public DataSet ObtenerSaldosEntFinancieras(string cNumDocumento, int idCli = 0)
        {
            return objEjeSp.DSEjecSP("CRE_SaldosEntFinan_Sp", cNumDocumento, idCli);
        }

        public DataSet DeudasEntFinancieras(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DeudasEntFinancierasPyme_Sp", idEvalCred);
        }

        public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleBalGenEval_Sp", idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, string xmlDetBalGenEval)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleBalGenEval_Sp", idEvalCred, xmlDetBalGenEval);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleEstResEval_Sp", idEvalCred);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetalleVenCos, string xmlDetalleCosteo)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleEstResEval_Sp", idEvalCred, xmlDetEstResEval, xmlDetalleVenCos, xmlDetalleCosteo);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return objEjeSp.EjecSP("CRE_ActEstFinancieros_Sp", idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistEstResEval_Sp", idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistBalGenEval_Sp", idEvalCred, idUsuario);
        }

        public DataSet ActualizarEvalCualit(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ActualizarEvalCualitAgrop_Sp", idEvalCred);
        }
        public DataTable ADRegistraOpRiesgos(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaCondicionesOpRiesgos_SP", idEvalCred);
        }
        
        public DataSet ObtenerMovimientosEvalPecuario(int idEvaluacionPecuaria)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerMovimientosEvalPecuario_SP", idEvaluacionPecuaria);
        }
        public DataTable InsActMovimientosEvalPecuario(string xml, int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_InsActMovimientoEvalPecuario_SP", xml, idEvaluacionPecuaria);
        }
        public DataTable ActualizarEvaluacionPecuaria(int idEvaluacionPecuaria,
            decimal nMontoIngresos,
            decimal nMontoEgresos,
            int idTipoInventario,
            int idEspecie,
            int idRaza,
            int idAnimal,
            int idUnidadMedida,
            int idProductoDerivado,
            int idTipoCrianza,
            int idSistemaCrianza,
            decimal nValorActual
        )
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvaluacionPecuaria_SP", idEvaluacionPecuaria,
                nMontoIngresos,
                nMontoEgresos,
                idTipoInventario,
                idEspecie,
                idRaza,
                idAnimal,
                idUnidadMedida,
                idProductoDerivado,
                idTipoCrianza,
                idSistemaCrianza,
                nValorActual
            );
        }

        public DataTable ObtenerValoracionInventario(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_ObtenerValoracionInventario_SP", idEvaluacionPecuaria);
        }

        public DataTable InsActValoracionInventario(
            int idValorizacionInventario,
            int idEvaluacionPecuaria,
            int idTipoInventario,

            decimal nCantidadPP,
            int idUnidadVentaPP,
            decimal nRendimientoPP,
            decimal nPrecioPP,
            decimal nTotalPP,
            decimal nTotalAjustadoPP,

            decimal nCantidadPC,
            decimal nCostoCompraPC,
            decimal nGastoAlimentoPC,
            decimal nTotalPC,
            decimal nTotalAjustadoPC,

            decimal nCantidadSaca,
            decimal nRendimientoSaca,
            decimal nPrecioSaca,
            decimal nTotalSaca,
            decimal nTotalAjustadoSaca
        )
        {
            return objEjeSp.EjecSP("CRE_InsActValoracionInventario_SP", idValorizacionInventario,
                idEvaluacionPecuaria,
                idTipoInventario,

                nCantidadPP,
                idUnidadVentaPP,
                nRendimientoPP,
                nPrecioPP,
                nTotalPP,
                nTotalAjustadoPP,

                nCantidadPC,
                nCostoCompraPC,
                nGastoAlimentoPC,
                nTotalPC,
                nTotalAjustadoPC,

                nCantidadSaca,
                nRendimientoSaca,
                nPrecioSaca,
                nTotalSaca,
                nTotalAjustadoSaca
            );
        }

        public DataTable ObtenerTotalInventario(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_ObtenerTotalInventario_SP", idEvaluacionPecuaria);
        }

        public DataTable ObtenerTotalPlantelFijo(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_ObtenerTotalPlantelFijo_SP", idEvaluacionPecuaria);
        }

        public DataTable ObtenerTotalSaca(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_ObtenerTotalSaca_SP", idEvaluacionPecuaria);
        }

        public DataTable RestablecerValorizacionActual(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_RestablecerValorizacionActual_SP", idEvaluacionPecuaria);
        }

        public DataSet GeneraFlujoCajaRural(int idEvaluacionRural, int plazoCredito, int idTipoPeriodo, int idPeriodo, DateTime fechaPrimCuota, decimal nMontoCaja)
        {
            return objEjeSp.DSEjecSP("CRE_GeneraFlujoCajaRural_Sp", idEvaluacionRural, plazoCredito, idTipoPeriodo, idPeriodo, fechaPrimCuota, nMontoCaja);
        }

        public DataTable SelectDisenioCrediticio(int idEvaluacionRural)
        {
            return objEjeSp.EjecSP("CRE_SelectDisenioCrediticio_Sp", idEvaluacionRural);
        }

        public DataTable SelectDisenioCrediticioxSolic(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_SelectDisenioCrediticioxSolicitud_Sp", idSolicitud);
        }
        
        public DataTable CargarTipoOtroIngresosRural()
        {
            return objEjeSp.EjecSP("CRE_CargarTipoOtrosIngresosEvalRural_Sp");
        }

        public DataTable CargarPeriodoOtroIngresosRural()
        {
            return objEjeSp.EjecSP("CRE_CargarPeriodoOtrosIngresosEvalRural_Sp");
        }

        public DataSet GeneraOtrosIngresosRural(int idEvaluacionRural)
        {
            return objEjeSp.DSEjecSP("CRE_GenerarOtrosIngresosEvalRural_Sp", idEvaluacionRural);
        }

        public DataTable GenerarIngresosVentaInventario(int idEvaluacionRural)
        {
            return objEjeSp.EjecSP("CRE_GenerarIngresosVentaInventarioEvalRural_Sp", idEvaluacionRural);
        }

        public DataTable GuardaDetalleBalGenEvalRural(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval, string xmlIngresoVentaActivos)
        {
            return objEjeSp.EjecSP("CRE_GuardaDetalleBalGenEvalRural_Sp", idEvalCred, nCajaInicial, xmlDetBalGenEval, xmlIngresoVentaActivos);
        }

        public DataTable GuardarProyeccionEstacional(int idEvalCred, string xmlIngresosEstacionales, string xmlEgresosEstacionales, string xmlInversionInsumos)
        {
            return objEjeSp.EjecSP("CRE_GuardaProyeccionesEstacionales_Sp", idEvalCred, xmlIngresosEstacionales, xmlEgresosEstacionales, xmlInversionInsumos);
        }

        public DataTable GuardarDisenioCredito(int idEvalCred, string xmlDisenioCredito)
        {
            return objEjeSp.EjecSP("CRE_GuardarDisenioCredito_Sp", idEvalCred, xmlDisenioCredito);
        }

        public DataTable SelectDisenioCredito(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_SelectDisenioCredito_Sp", idEvalCred);
        }
        

        public DataSet ObtenerProyeccionRural(int idEvaluacion)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerProyeccionEstacional_SP", idEvaluacion);
        }

        public DataTable GuardaOtrosIngresosEvalRural(int idEvalCred, string xmlOtrosINgresosRuralM, string xmlOtrosINgresosRuralD, string xmlOtrosEgresosRuralM, string xmlOtrosEgresosRuralD)
        {
            return objEjeSp.EjecSP("CRE_GuardaOtrosIngresosEvalRural_Sp", idEvalCred, xmlOtrosINgresosRuralM, xmlOtrosINgresosRuralD, xmlOtrosEgresosRuralM, xmlOtrosEgresosRuralD);
        }
        
        public DataTable ObtenerConfiguracionDiseCredRural(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_SelectConfDiseCredRural_Sp", idEvalCred);
        }

        public DataTable ObtenerConfiguracionDiseCredRuralxSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_SelectConfDiseCredRuralxSolicitud_Sp", idSolicitud);
        }
        
        public DataTable GuardarConfiguracionDiseCredRural(int idEvalCre, decimal nMontoPropuesto, int idTipoPeriodo, int idPeriodo, int nplazoMeses, int ncuotas, decimal nTEA, DateTime dFechaDesembolso, DateTime dFechaPrimeraCuota, int nAlerta)
        {
            return objEjeSp.EjecSP("CRE_GuardaConfDiseCredRural_Sp", idEvalCre, nMontoPropuesto, idTipoPeriodo, idPeriodo, nplazoMeses, ncuotas, nTEA, dFechaDesembolso, dFechaPrimeraCuota, nAlerta);
        }

        public DataTable ObtenerInventarioBBGG(int idEvalCre)
        {
            return objEjeSp.EjecSP("GEN_ObtenerInventarioBBGG_sp", idEvalCre);
        }

        public DataTable RetornaOperacionxIdSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetornaOperacionxIdSolicitud_SP", idSolicitud);
        }
    }
}
