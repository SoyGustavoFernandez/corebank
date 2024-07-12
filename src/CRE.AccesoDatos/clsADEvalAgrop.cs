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
    public class clsADEvalAgrop
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalAgro_Sp", idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalPyme_Sp", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataSet InicializarAgro()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarAgro_Sp");
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
        public DataTable ADValidarVisitas(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
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
            int idValorizacionInventario ,
	        int idEvaluacionPecuaria ,
	        int idTipoInventario ,

	        decimal nCantidadPP ,
	        int idUnidadVentaPP ,
	        decimal nRendimientoPP ,
	        decimal nPrecioPP ,
	        decimal nTotalPP ,
	        decimal nTotalAjustadoPP ,

	        decimal nCantidadPC ,
	        decimal nCostoCompraPC ,
	        decimal nGastoAlimentoPC ,
	        decimal nTotalPC ,
	        decimal nTotalAjustadoPC ,

	        decimal nCantidadSaca ,
	        decimal nRendimientoSaca ,
	        decimal nPrecioSaca ,
	        decimal nTotalSaca ,
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
        
   }
}

