using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADEvalPymeEstacional
    {
        IntConexion objEjeSp;

        public clsADEvalPymeEstacional()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataSet inicializarPyme()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarPyme_Sp");
        }

        public DataSet buscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalPymeEstacional_Sp", idEvalCred);
        }

        public DataTable enviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable guardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistEstResEvalPymeEst_Sp", idEvalCred, idUsuario);
        }

        public DataTable obtenerMeses()
        {
            return objEjeSp.EjecSP("CRE_ObtenerMeses_SP");
        }

        public DataTable obtenerGastosFinancieros(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDeudasFinancieras_SP", idEvalCred);
        }

        public DataTable actualizarEval(int idEvalCred, string xmlEvalCred, string xmlReferencias, string xmlEstResEvalM, string xmlEstResEvalD, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalPymeEst_Sp", idEvalCred, xmlEvalCred, xmlReferencias, xmlEstResEvalM, xmlEstResEvalD, xmlIndicadorEval);
        }
    }
}
