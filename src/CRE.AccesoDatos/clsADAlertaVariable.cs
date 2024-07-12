using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADAlertaVariable
    {
        private clsGENEjeSP objGENEjeSP = new clsGENEjeSP();

        public List<clsAlertaVariable> listarAlertaVariable(int idSolicitud, int idSectorEcon)
        {
            DataTable dtAlertaVariable = this.objGENEjeSP.EjecSP("CRE_ListarAlertaVariable_SP", idSolicitud, idSectorEcon);
            return (dtAlertaVariable.Rows.Count > 0) ?
                dtAlertaVariable.ToList<clsAlertaVariable>() as List<clsAlertaVariable>:
                new List<clsAlertaVariable>();
        }

        public clsRespuestaServidor grabarEvalCredAlertaVariable(string xmlEvalCredAlertaVariable, int idUsuario, DateTime dFechaSistema, bool lAplicado)
        {
            DataTable dtRespuestaServidor = this.objGENEjeSP.EjecSP("CRE_GrabarEvalCredAlertaVariable_SP", xmlEvalCredAlertaVariable, idUsuario, dFechaSistema, lAplicado);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsEvalCredAlertaBuzon listarEvalCredAlertaResumen(int idUsuario)
        {
            DataSet dsEvalCredAlertaResumen = this.objGENEjeSP.DSEjecSP("CRE_ListarEvalCredAlertaResumen_SP", idUsuario);

            clsEvalCredAlertaBuzon objEvalCredAlertaBuzon = new clsEvalCredAlertaBuzon();

            if (dsEvalCredAlertaResumen.Tables.Count < 3)
            {
                objEvalCredAlertaBuzon.lstNuevo = new List<clsEvalCredAlertaVarResumen>();
                objEvalCredAlertaBuzon.lstAtencion = new List<clsEvalCredAlertaVarResumen>();
                objEvalCredAlertaBuzon.lstReconsideracion = new List<clsEvalCredAlertaVarResumen>();
            }
            else
            {
                objEvalCredAlertaBuzon.lstNuevo = (dsEvalCredAlertaResumen.Tables[0].Rows.Count > 0) ?
                    dsEvalCredAlertaResumen.Tables[0].ToList<clsEvalCredAlertaVarResumen>() as List<clsEvalCredAlertaVarResumen> :
                    new List<clsEvalCredAlertaVarResumen>();

                objEvalCredAlertaBuzon.lstAtencion = (dsEvalCredAlertaResumen.Tables[1].Rows.Count > 0) ?
                    dsEvalCredAlertaResumen.Tables[1].ToList<clsEvalCredAlertaVarResumen>() as List<clsEvalCredAlertaVarResumen> :
                    new List<clsEvalCredAlertaVarResumen>();

                objEvalCredAlertaBuzon.lstReconsideracion = (dsEvalCredAlertaResumen.Tables[2].Rows.Count > 0) ?
                    dsEvalCredAlertaResumen.Tables[2].ToList<clsEvalCredAlertaVarResumen>() as List<clsEvalCredAlertaVarResumen> :
                    new List<clsEvalCredAlertaVarResumen>();
            }

            return objEvalCredAlertaBuzon;
        }

        public List<clsEvalCredAlertaVarResumen> buscarEvalCredAlertas(int idSolicitud, int idCliente)
        {
            DataTable dtEvalCredAlertaResumen = this.objGENEjeSP.EjecSP("CRE_BuscarEvalCredAlertas_SP", idSolicitud, idCliente);

            return (dtEvalCredAlertaResumen.Rows.Count > 0) ?
                dtEvalCredAlertaResumen.ToList<clsEvalCredAlertaVarResumen>() as List<clsEvalCredAlertaVarResumen>:
                new List<clsEvalCredAlertaVarResumen>();
        }

        public List<clsEvalCredAlertaVariable> listarEvalCredAlertaVariable(int idEvalCred)
        {
            DataTable dtEvalCredAlerta = this.objGENEjeSP.EjecSP("CRE_ListarEvalCredAlertaVariable_SP", idEvalCred);
            return (dtEvalCredAlerta.Rows.Count > 0) ?
                dtEvalCredAlerta.ToList<clsEvalCredAlertaVariable>() as List<clsEvalCredAlertaVariable> :
                new List<clsEvalCredAlertaVariable>();
        }
        public clsRespuestaServidor emitirResolucionEvalCredAlerta(int idEvalCred, int idAlertaVariable, int idUsuario, int idTipoResolucion, int idTipoResolucionRecd, DateTime dFechaSistema)
        {
            DataTable dtRespuestaServidor = this.objGENEjeSP.EjecSP("CRE_EmitirResolucionEvalCredAlerta_SP", idEvalCred, idAlertaVariable, idUsuario, idTipoResolucion, idTipoResolucionRecd, dFechaSistema);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor iniciarResolucionEvalCredAlerta(int idEvalCred, int idUsuario)
        {
            DataTable dtRespuestaServidor = this.objGENEjeSP.EjecSP("CRE_IniciarResolucionEvalCredAlerta_SP", idEvalCred, idUsuario);
            return (dtRespuestaServidor.Rows.Count>0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor ejecutarFuncionDinamica(int idFuncionDinamica, string xmlReemplazos)
        {
            DataTable dtRespuestaServidor = this.objGENEjeSP.EjecSP("GEN_EjecutarFuncionDinamica_SP", idFuncionDinamica, xmlReemplazos);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor denegarSolicitudCredDesfavorable(int idSolicitud, int idEvalCred, int idUsuario, DateTime dFechaSistema)
        {
            DataTable dtRespuestaServidor = this.objGENEjeSP.EjecSP("CRE_DenegarSolicitudCredDesfavorable_SP", idSolicitud, idEvalCred, idUsuario, dFechaSistema);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public DataTable aplicabilidadEvalCredAlertaVar(int idSolicitud, int idEvalCred)
        {
            return this.objGENEjeSP.EjecSP("CRE_AplicabilidadEvalCredAlertaVar_SP", idSolicitud, idEvalCred);
        }
        public DataTable montoMinAlertaEval(int idSolicitud)
        {
            return this.objGENEjeSP.EjecSP("CRE_MontoMinAlertEval_SP", idSolicitud);
        }
    }
}
