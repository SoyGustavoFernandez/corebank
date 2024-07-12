using EntityLayer;
using SolIntEls.GEN.Helper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;


namespace CRE.AccesoDatos
{
    public class clsADEvalPyme
    {
        IntConexion objEjeSp;

        public clsADEvalPyme()
        { 
            objEjeSp = new clsGENEjeSP();
        }

        public clsADEvalPyme(bool WS)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        

        public DataSet BuscarSolicitudesPorCliente(int idCli, int idUsuario, string cTipoEval)
        {
            return objEjeSp.DSEjecSP("CRE_BusSolPorCliPyme_Sp", idCli, idUsuario, cTipoEval);
        }

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalPyme_Sp", idEvalCred);
        }

        public DataTable GrabarNuevaEvalCred(string xmlEvalCred, string xmlSaldosDeudas)
        {
            return objEjeSp.EjecSP("CRE_NuevaEvalPyme_Sp", xmlEvalCred, xmlSaldosDeudas);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalPyme_Sp", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval); //paulgpp
        }

        public DataSet InicializarPyme()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarPyme_Sp");
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalPyme_Sp", idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataSet ObtenerSaldosEntFinancieras(string cNumDocumento, int idCli = 0, int idSolicitud = 0)
        {
            return objEjeSp.DSEjecSP("CRE_SaldosEntFinan_Sp", cNumDocumento, idCli, idSolicitud);
        }

        public DataSet DeudasEntFinancieras(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DeudasEntFinancierasPyme_Sp", idEvalCred);
        }

        public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleBalGenEval_Sp", idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleBalGenEval_Sp", idEvalCred, nCajaInicial, xmlDetBalGenEval);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleEstResEval_Sp", idEvalCred);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetalleVenCos, string xmlDetalleCosteo, string xmlDetalleVarFCaja)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleEstResEval_Sp", idEvalCred, xmlDetEstResEval, xmlDetalleVenCos, xmlDetalleCosteo, xmlDetalleVarFCaja);
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
            return objEjeSp.DSEjecSP("CRE_ActualizarEvalCualitPyme_Sp", idEvalCred);
        }
        public DataTable ADRegistraOpRiesgos(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaCondicionesOpRiesgos_SP", idEvalCred);
        }
        public DataTable ADValidarVisitas(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
        }
        
        
        public DataSet RecuperarDetalleEstResultadosEvalPecuario(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerEvaluacionPecuaria_SP", idEvalCred);
        }
        public DataSet RecuperarDetalleMovimientosEvalPecuario(int idEvaluacionPecuaria)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerMovimientosEvalPecuario_SP", idEvaluacionPecuaria);
        }
        public DataTable InsertarRegistroInvPecuario(
            int idEvalCred,
            int idTipoInventario,
            int idEspecie,
            int idRaza,
            int idAnimal,
            int idProductoDerivado,
            int idTipoCrianza,
            int idSistemaCrianza,
            int idMoneda,
            int idUnidadMedida
            )
        {
            return objEjeSp.EjecSP("CRE_RegistarEvaluacionPecuaria_SP", 
            idEvalCred,
            idTipoInventario,
            idEspecie,
            idRaza,
            idAnimal,
            idProductoDerivado,
            idTipoCrianza,
            idSistemaCrianza,
            idMoneda,
            idUnidadMedida);
        }
        public DataTable QuitarRegistroInvPecuario(int idEvaluacionPecuaria)
        {
            return objEjeSp.EjecSP("CRE_EliminarEvaluacionPecuaria_SP", idEvaluacionPecuaria);
        }
    }
}
