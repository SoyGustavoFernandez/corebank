using EntityLayer;
using CRE.AccesoDatos;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;


namespace CRE.CapaNegocio
{
    public class clsCNEvalAgrop
    {
        private clsADEvalAgrop objADEvalAgrop = new clsADEvalAgrop();

        /*public DataSet BuscarSolicitudesPorCliente(int idCli, int idUsuario)
        {
            return this.objADEvalAgrop.BuscarSolicitudesPorCliente(idCli, idUsuario);
        }*/

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return this.objADEvalAgrop.BuscarEvalCredito(idEvalCred);
        }

        /*public DataTable GrabarNuevaEvalCred(string xmlEvalCred, string xmlSaldosDeudas)
        {
            return this.objADEvalAgrop.GrabarNuevaEvalCred(xmlEvalCred, xmlSaldosDeudas);
        }*/

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return this.objADEvalAgrop.ActualizarEval(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataSet InicializarAgro()
        {
            return this.objADEvalAgrop.InicializarAgro();
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return this.objADEvalAgrop.RecuperarEvalCredito(idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCredTemp, int lCanalAproCredEditable)
        {
            return this.objADEvalAgrop.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCredTemp, lCanalAproCredEditable);
        }

        public DataSet ObtenerSaldosEntFinancieras(string cNumDocumento, int idCli)
        {
            return this.objADEvalAgrop.ObtenerSaldosEntFinancieras(cNumDocumento, idCli);
        }

        public DataSet DeudasEntFinancieras(int idEvalCred)
        {
            return this.objADEvalAgrop.DeudasEntFinancieras(idEvalCred);
        }

        public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return this.objADEvalAgrop.RecuperarDetalleBalGeneralEval(idEvalCred);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return this.objADEvalAgrop.RecuperarDetalleEstResultadosEval(idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, string xmlDetBalGenEval)
        {
            return this.objADEvalAgrop.ActDetalleBalanceGeneralEval(idEvalCred, xmlDetBalGenEval);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetalleVenCos, string xmlDetalleCosteo)
        {
            return this.objADEvalAgrop.ActDetalleEstadosResultadoslEval(idEvalCred, xmlDetEstResEval, xmlDetalleVenCos, xmlDetalleCosteo);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.objADEvalAgrop.ActEstFinancieroslEval(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalAgrop.GuardarHistoricoEstResEval(idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalAgrop.GuardarHistoricoBalGenEval(idEvalCred, idUsuario);
        }

        public List<clsEvalCualitativa> ActualizarEvalCualit(int idEvalCred)
        {
            List<clsEvalCualitativa> lstEvalCualitativo = new List<clsEvalCualitativa>();

            DataSet ds = this.objADEvalAgrop.ActualizarEvalCualit(idEvalCred);
            DataTable dt = ds.Tables[0];

            if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
            {
                lstEvalCualitativo = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[1]) as List<clsEvalCualitativa>;
            }

            return lstEvalCualitativo;
        }
        public DataTable CNRegistraOpRiesgos(int idEvalCred)
        {
            return this.objADEvalAgrop.ADRegistraOpRiesgos(idEvalCred);
        }
        public DataTable CNValidarVisitas(int idEvalCred)
        {
            return this.objADEvalAgrop.ADValidarVisitas(idEvalCred);
        }


        public DataSet ObtenerMovimientosEvalPecuario(int idEvaluacionPecuaria)
        {
            return this.objADEvalAgrop.ObtenerMovimientosEvalPecuario(idEvaluacionPecuaria);
        }
        public DataTable InsActMovimientosEvalPecuario(string xml, int idEvaluacionPecuaria)
        {
            return this.objADEvalAgrop.InsActMovimientosEvalPecuario(xml, idEvaluacionPecuaria);
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
            return this.objADEvalAgrop.ActualizarEvaluacionPecuaria(idEvaluacionPecuaria, 
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
            return this.objADEvalAgrop.ObtenerValoracionInventario(idEvaluacionPecuaria);
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
            return this.objADEvalAgrop.InsActValoracionInventario(idValorizacionInventario,
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
            DataTable dtTotalInventario = this.objADEvalAgrop.ObtenerTotalInventario(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalInventario.Rows[0]["nTotalInventario"]);
        }

        public decimal ObtenerTotalPlantelFijo(int idEvaluacionPecuaria)
        {
            DataTable dtTotalPlantelFijo = this.objADEvalAgrop.ObtenerTotalPlantelFijo(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalPlantelFijo.Rows[0]["nTotalPLantelFijo"]);
        }

        public decimal ObtenerTotalSaca(int idEvaluacionPecuaria)
        {
            DataTable dtTotalSaca = this.objADEvalAgrop.ObtenerTotalSaca(idEvaluacionPecuaria);
            return Convert.ToDecimal(dtTotalSaca.Rows[0]["nTotalSaca"]);
        }

        public void RestablecerValorizacionActual(int idEvaluacionPecuaria)
        {
            this.objADEvalAgrop.RestablecerValorizacionActual(idEvaluacionPecuaria);
        }

    }
}

