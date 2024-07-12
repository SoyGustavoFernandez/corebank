using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADEvalCrediJornal
    {
        IntConexion objEjeSp;
        public clsADEvalCrediJornal()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalCrediJornal_SP", idEvalCred);
        }

        public DataSet InicializarCrediJornal()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarCrediJornal_SP");
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalPyme_Sp", idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalCrediJornal_SP", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistEstResEval_Sp", idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistBalGenEval_Sp", idEvalCred, idUsuario);
        }

        public DataTable ADValidarVisitas(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
        }
        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return objEjeSp.EjecSP("CRE_ActEstFinancieros_Sp", idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetJornalIngreso, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ActDetEstResultadoJornal_Sp", idEvalCred, xmlDetEstResEval, xmlDetJornalIngreso, idUsuario);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuperarDetEstResultadosEvalJornal_SP", idEvalCred);
        }

        public DataSet RecuperarDetalleGeneralEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleGeneralEstResEvalJornal_Sp", idEvalCred);
        }

        public DataTable SubProductoCrediChamba()
        {
            return objEjeSp.EjecSP("CRE_ListarSubProductoCrediChamba_SP");
        }

    }
}
