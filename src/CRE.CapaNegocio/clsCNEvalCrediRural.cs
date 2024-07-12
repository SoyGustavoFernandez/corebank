using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEvalCrediRural
    {
        private clsADEvalCrediRural objADEvalCrediRural = new clsADEvalCrediRural();

        public DataSet InicializarEvalCrediRural()
        {
            return this.objADEvalCrediRural.InicializarEvalCrediRural();
        }
        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return this.objADEvalCrediRural.BuscarEvalCredito(idEvalCred);
        }

        public DataTable CNValidarVisitas(int idEvalCred)
        {
            return this.objADEvalCrediRural.ADValidarVisitas(idEvalCred);
        }


        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return this.objADEvalCrediRural.ActualizarEval(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }


        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return this.objADEvalCrediRural.RecuperarEvalCredito(idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCredTemp, int lCanalAproCredEditable)
        {
            return this.objADEvalCrediRural.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCredTemp, lCanalAproCredEditable);
        }

        public DataSet ObtenerSaldosEntFinancieras(string cNumDocumento, int idCli)
        {
            return this.objADEvalCrediRural.ObtenerSaldosEntFinancieras(cNumDocumento, idCli);
        }

        public DataSet DeudasEntFinancieras(int idEvalCred)
        {
            return this.objADEvalCrediRural.DeudasEntFinancieras(idEvalCred);
        }

        public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return this.objADEvalCrediRural.RecuperarDetalleBalGeneralEval(idEvalCred);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return this.objADEvalCrediRural.RecuperarDetalleEstResultadosEval(idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, string xmlDetBalGenEval)
        {
            return this.objADEvalCrediRural.ActDetalleBalanceGeneralEval(idEvalCred, xmlDetBalGenEval);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetalleVenCos, string xmlDetalleCosteo)
        {
            return this.objADEvalCrediRural.ActDetalleEstadosResultadoslEval(idEvalCred, xmlDetEstResEval, xmlDetalleVenCos, xmlDetalleCosteo);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.objADEvalCrediRural.ActEstFinancieroslEval(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalCrediRural.GuardarHistoricoEstResEval(idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalCrediRural.GuardarHistoricoBalGenEval(idEvalCred, idUsuario);
        }

        public List<clsEvalCualitativa> ActualizarEvalCualit(int idEvalCred)
        {
            List<clsEvalCualitativa> lstEvalCualitativo = new List<clsEvalCualitativa>();

            DataSet ds = this.objADEvalCrediRural.ActualizarEvalCualit(idEvalCred);
            DataTable dt = ds.Tables[0];

            if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
            {
                lstEvalCualitativo = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[1]) as List<clsEvalCualitativa>;
            }

            return lstEvalCualitativo;
        }
        public DataTable CNRegistraOpRiesgos(int idEvalCred)
        {
            return this.objADEvalCrediRural.ADRegistraOpRiesgos(idEvalCred);
        }

        public DataSet ObtenerMovimientosEvalPecuario(int idEvaluacionPecuaria)
        {
            return this.objADEvalCrediRural.ObtenerMovimientosEvalPecuario(idEvaluacionPecuaria);
        }
        public DataTable InsActMovimientosEvalPecuario(string xml, int idEvaluacionPecuaria)
        {
            return this.objADEvalCrediRural.InsActMovimientosEvalPecuario(xml, idEvaluacionPecuaria);
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
            return this.objADEvalCrediRural.ActualizarEvaluacionPecuaria(idEvaluacionPecuaria,
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
            return this.objADEvalCrediRural.ObtenerValoracionInventario(idEvaluacionPecuaria);
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
            return this.objADEvalCrediRural.InsActValoracionInventario(idValorizacionInventario,
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
                nTotalAjustadoSaca);
        }

        public decimal ObtenerTotalInventario(int idEvaluacionPecuaria)
        {
            DataTable dtTotalInventario = this.objADEvalCrediRural.ObtenerTotalInventario(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalInventario.Rows[0]["nTotalInventario"]);
        }

        public decimal ObtenerTotalPlantelFijo(int idEvaluacionPecuaria)
        {
            DataTable dtTotalPlantelFijo = this.objADEvalCrediRural.ObtenerTotalPlantelFijo(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalPlantelFijo.Rows[0]["nTotalPLantelFijo"]);
        }

        public decimal ObtenerTotalSaca(int idEvaluacionPecuaria)
        {
            DataTable dtTotalSaca = this.objADEvalCrediRural.ObtenerTotalSaca(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalSaca.Rows[0]["nTotalSaca"]);
        }

        public void RestablecerValorizacionActual(int idEvaluacionPecuaria)
        {
            this.objADEvalCrediRural.RestablecerValorizacionActual(idEvaluacionPecuaria);
        }

        public DataSet GeneraFlujoCajaRural(int idEvaluacionRural, int plazoCredito, int idTipoPeriodo, int idPeriodo, DateTime fechaPrimCuota, decimal nMontoCaja) 
        {
            return this.objADEvalCrediRural.GeneraFlujoCajaRural(idEvaluacionRural, plazoCredito, idTipoPeriodo, idPeriodo, fechaPrimCuota, nMontoCaja);
        }

        public DataTable SelectDisenioCrediticio(int idEvaluacionRural)
        {
            return this.objADEvalCrediRural.SelectDisenioCrediticio(idEvaluacionRural);
        }

        public DataTable SelectDisenioCrediticioxSolic(int idSolicitud)
        {
            return this.objADEvalCrediRural.SelectDisenioCrediticioxSolic(idSolicitud);
        }

        public DataTable CargarTipoOtroIngresosRural()
        {
            return this.objADEvalCrediRural.CargarTipoOtroIngresosRural();
        }

        public DataTable CargarPeriodoOtroIngresosRural()
        {
            return this.objADEvalCrediRural.CargarPeriodoOtroIngresosRural();
        }

        public DataSet GeneraOtrosIngresosRural(int idEvaluacionRural)
        {
            return this.objADEvalCrediRural.GeneraOtrosIngresosRural(idEvaluacionRural);
        }

        public DataTable GenerarIngresosVentaInventario(int idEvaluacionRural)
        {
            return this.objADEvalCrediRural.GenerarIngresosVentaInventario(idEvaluacionRural);
        }

        public DataTable GuardaDetalleBalGenEvalRural(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval, string xmlIngresoVentaActivos)
        {
            return this.objADEvalCrediRural.GuardaDetalleBalGenEvalRural(idEvalCred, nCajaInicial, xmlDetBalGenEval, xmlIngresoVentaActivos);
        }

        public DataTable GuardarDisenioCredito(int idEvalCred, string xmlDisenioCredito)
        {
            return this.objADEvalCrediRural.GuardarDisenioCredito(idEvalCred, xmlDisenioCredito);
        }

        public DataTable GuardarProyeccionEstacional(int idEvalCred, string xmlIngresosEstacionales, string xmlEgresosEstacionales, string xmlInversionInsumos)
        {
            return this.objADEvalCrediRural.GuardarProyeccionEstacional(idEvalCred, xmlIngresosEstacionales, xmlEgresosEstacionales, xmlInversionInsumos);
        }

        public DataSet ObtenerProyeccionRural(int idEvaluacion)
        {
            return this.objADEvalCrediRural.ObtenerProyeccionRural(idEvaluacion);
        }

        public DataTable GuardaOtrosIngresosEvalRural(int idEvalCred, string xmlOtrosINgresosRuralM, string xmlOtrosINgresosRuralD, string xmlOtrosEgresosRuralM, string xmlOtrosEgresosRuralD)
        {
            return this.objADEvalCrediRural.GuardaOtrosIngresosEvalRural(idEvalCred, xmlOtrosINgresosRuralM, xmlOtrosINgresosRuralD, xmlOtrosEgresosRuralM, xmlOtrosEgresosRuralD);
        }

        public DataTable ObtenerConfiguracionDiseCredRural(int idEvalCred)
        {
            return this.objADEvalCrediRural.ObtenerConfiguracionDiseCredRural(idEvalCred);
        }

        public DataTable ObtenerConfiguracionDiseCredRuralxSolicitud(int idSolicitud)
        {
            return this.objADEvalCrediRural.ObtenerConfiguracionDiseCredRuralxSolicitud(idSolicitud);
        }

        public DataTable GuardarConfiguracionDiseCredRural(int idEvalCre, decimal nMontoPropuesto, int idTipoPeriodo, int idPeriodo, int nplazoMeses, int ncuotas, decimal nTEA, DateTime dFechaDesembolso, DateTime dFechaPrimeraCuota, int nAlerta)
        {
            return this.objADEvalCrediRural.GuardarConfiguracionDiseCredRural(idEvalCre, nMontoPropuesto, idTipoPeriodo, idPeriodo, nplazoMeses, ncuotas, nTEA, dFechaDesembolso, dFechaPrimeraCuota, nAlerta);
        }

        public DataTable ObtenerInventarioBBGG(int idEvalCre)
        {
            return this.objADEvalCrediRural.ObtenerInventarioBBGG(idEvalCre);
        }

        public DataTable RetornaOperacionxIdSolicitud(int idSolicitud)
        {
            return this.objADEvalCrediRural.RetornaOperacionxIdSolicitud(idSolicitud);
        }

    }
}
