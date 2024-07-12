using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNEvalCrediJornal
    {
        private clsADEvalCrediJornal objADEvalCrediJornal { get; set; }

        public clsCNEvalCrediJornal()
        {
            objADEvalCrediJornal = new clsADEvalCrediJornal();
        }

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return this.objADEvalCrediJornal.BuscarEvalCredito(idEvalCred);
        }

        public DataSet InicializarCrediJornal()
        {
            return this.objADEvalCrediJornal.InicializarCrediJornal();
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return this.objADEvalCrediJornal.RecuperarEvalCredito(idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return this.objADEvalCrediJornal.ActualizarEval(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return this.objADEvalCrediJornal.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalCrediJornal.GuardarHistoricoEstResEval(idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalCrediJornal.GuardarHistoricoBalGenEval(idEvalCred, idUsuario);
        }

        public DataTable CNValidarVisitas(int idEvalCred)
        {
            return this.objADEvalCrediJornal.ADValidarVisitas(idEvalCred);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.objADEvalCrediJornal.ActEstFinancieroslEval(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }
        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetJornalIngreso, int idUsuario)
        {
            return this.objADEvalCrediJornal.ActDetalleEstadosResultadoslEval(idEvalCred, xmlDetEstResEval, xmlDetJornalIngreso, idUsuario);
        }
        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return this.objADEvalCrediJornal.RecuperarDetalleEstResultadosEval(idEvalCred);
        }

        public DataSet RecuperarDetalleGeneralEstResultadosEval(int idEvalCred)
        {
            return this.objADEvalCrediJornal.RecuperarDetalleGeneralEstResultadosEval(idEvalCred);
        }

        public DataTable SubProductoCrediChamba()
        {
            return this.objADEvalCrediJornal.SubProductoCrediChamba();
        }
    }
}
