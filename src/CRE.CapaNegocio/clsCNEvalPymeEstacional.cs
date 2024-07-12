using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEvalPymeEstacional
    {
        clsADEvalPymeEstacional objADEvalPymeEstacional;

        public clsCNEvalPymeEstacional()
        {
            objADEvalPymeEstacional = new clsADEvalPymeEstacional();
        }

        public DataSet inicializarPyme()
        {
            return this.objADEvalPymeEstacional.inicializarPyme();
        }

        public DataSet buscarEvalCredito(int idEvalCred)
        {
            return this.objADEvalPymeEstacional.buscarEvalCredito(idEvalCred);
        }
        
        public DataTable enviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return this.objADEvalPymeEstacional.enviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable guardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalPymeEstacional.guardarHistoricoEstResEval(idEvalCred, idUsuario);
        }

        public DataTable obtenerMeses()
        {
            return this.objADEvalPymeEstacional.obtenerMeses();
        }

        public DataTable obtenerGastosFinancieros(int idEvalCred)
        {
            return this.objADEvalPymeEstacional.obtenerGastosFinancieros(idEvalCred);
        }

        public DataTable actualizarEval(int idEvalCred, string xmlEvalCred, string xmlReferencias, string xmlEstResEvalM, string xmlEstResEvalD, string xmlIndicadorEval)
        {
            return this.objADEvalPymeEstacional.actualizarEval(idEvalCred, xmlEvalCred, xmlReferencias, xmlEstResEvalM, xmlEstResEvalD, xmlIndicadorEval);
        }
    }
}
