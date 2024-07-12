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
    public class clsCNEvalPyme
    {
        clsADEvalPyme objADEvalPyme;
        
        public clsCNEvalPyme()
        { 
            objADEvalPyme = new clsADEvalPyme();
        }

        public clsCNEvalPyme(bool WS)
        {
            objADEvalPyme = new clsADEvalPyme(WS);
        }

        

        public DataSet BuscarSolicitudesPorCliente(int idCli, int idUsuario, string cTipoEval)
        {
            return this.objADEvalPyme.BuscarSolicitudesPorCliente(idCli, idUsuario, cTipoEval);
        }

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return this.objADEvalPyme.BuscarEvalCredito(idEvalCred);
        }

        public DataTable GrabarNuevaEvalCred(string xmlEvalCred, string xmlSaldosDeudas)
        {
            return this.objADEvalPyme.GrabarNuevaEvalCred(xmlEvalCred, xmlSaldosDeudas);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return this.objADEvalPyme.ActualizarEval(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataSet InicializarPyme()
        {
            return this.objADEvalPyme.InicializarPyme();
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return this.objADEvalPyme.RecuperarEvalCredito(idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return this.objADEvalPyme.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataSet ObtenerSaldosEntFinancieras(string cNumDocumento, int idCli = 0, int idSolicitud = 0)
        {
            return this.objADEvalPyme.ObtenerSaldosEntFinancieras(cNumDocumento, idCli, idSolicitud);
        }

        public DataSet DeudasEntFinancieras(int idEvalCred)
        {
            return this.objADEvalPyme.DeudasEntFinancieras(idEvalCred);
        }

        public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return this.objADEvalPyme.RecuperarDetalleBalGeneralEval(idEvalCred);
        }

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return this.objADEvalPyme.RecuperarDetalleEstResultadosEval(idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval)
        {
            return this.objADEvalPyme.ActDetalleBalanceGeneralEval(idEvalCred, nCajaInicial, xmlDetBalGenEval);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval, string xmlDetalleVenCos, string xmlDetalleCosteo, string xmlDetalleVarFCaja)
        {
            return this.objADEvalPyme.ActDetalleEstadosResultadoslEval(idEvalCred, xmlDetEstResEval, xmlDetalleVenCos, xmlDetalleCosteo, xmlDetalleVarFCaja);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.objADEvalPyme.ActEstFinancieroslEval(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable GuardarHistoricoEstResEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalPyme.GuardarHistoricoEstResEval(idEvalCred, idUsuario);
        }

        public DataTable GuardarHistoricoBalGenEval(int idEvalCred, int idUsuario)
        {
            return this.objADEvalPyme.GuardarHistoricoBalGenEval(idEvalCred, idUsuario);
        }

        public List<clsEvalCualitativa> ActualizarEvalCualit(int idEvalCred)
        {
            List<clsEvalCualitativa> lstEvalCualitativo = new List<clsEvalCualitativa>();

            DataSet ds = this.objADEvalPyme.ActualizarEvalCualit(idEvalCred);
            DataTable dt = ds.Tables[0];

            if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
            {
                lstEvalCualitativo = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[1]) as List<clsEvalCualitativa>;
            }

            return lstEvalCualitativo;
        }
        public DataTable CNRegistraOpRiesgos(int idEvalCred)
        {
            return this.objADEvalPyme.ADRegistraOpRiesgos(idEvalCred);
        }
        public DataTable CNValidarVisitas(int idEvalCred)
        {
            return this.objADEvalPyme.ADValidarVisitas(idEvalCred);
        }



        public DataSet RecuperarDetalleEstResultadosEvalPecuario(int idEvalCred)
        {
            return this.objADEvalPyme.RecuperarDetalleEstResultadosEvalPecuario(idEvalCred);
        }
        public DataSet RecuperarDetalleMovimientoEvalPecuario(int idEvaluacionPecuaria)
        {
            return this.objADEvalPyme.RecuperarDetalleMovimientosEvalPecuario(idEvaluacionPecuaria);
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
            return this.objADEvalPyme.InsertarRegistroInvPecuario(
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
            return this.objADEvalPyme.QuitarRegistroInvPecuario(idEvaluacionPecuaria);
        }
    }
}
