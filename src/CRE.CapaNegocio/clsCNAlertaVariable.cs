using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNAlertaVariable
    {
        private clsADAlertaVariable objADAlertaVariable = new clsADAlertaVariable();

        public List<clsAlertaVariable> listarAlertaVariable(int idSolicitud, int idSectorEcon)
        {
            return this.objADAlertaVariable.listarAlertaVariable(idSolicitud, idSectorEcon);
        }

        public clsRespuestaServidor grabarEvalCredAlertaVariable(List<clsEvalCredAlertaVariable> lstEvalCredAlertaVariable, bool lAplicado = true)
        {
            string xmlEvalCredAlertaVariable = string.Empty;
            xmlEvalCredAlertaVariable = lstEvalCredAlertaVariable.ListObjectToXml<clsEvalCredAlertaVariable>("EvalCredAlerta", "EvalCredAlertas");
            return this.objADAlertaVariable.grabarEvalCredAlertaVariable(xmlEvalCredAlertaVariable, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, lAplicado);
        }
        public clsEvalCredAlertaBuzon listarEvalCredAlertaResumen()
        {
            return this.objADAlertaVariable.listarEvalCredAlertaResumen(clsVarGlobal.User.idUsuario);
        }
        public List<clsEvalCredAlertaVarResumen> buscarEvalCredAlertas(int idSolicitud, int idCliente)
        {
            return this.objADAlertaVariable.buscarEvalCredAlertas(idSolicitud, idCliente);
        }
        public List<clsEvalCredAlertaVariable> listarEvalCredAlertaVariable(int idEvalCred)
        {
            return this.objADAlertaVariable.listarEvalCredAlertaVariable(idEvalCred);
        }
        public clsRespuestaServidor emitirResolucionEvalCredAlerta(int idEvalCred, int idAlertaVariable, int idTipoResolucion, int idTipoResolucionRecd)
        {
            return this.objADAlertaVariable.emitirResolucionEvalCredAlerta(idEvalCred, idAlertaVariable, clsVarGlobal.User.idUsuario, idTipoResolucion, idTipoResolucionRecd, clsVarGlobal.dFecSystem);
        }
        public clsRespuestaServidor iniciarResolucionEvalCredAlerta(int idEvalCred)
        {
            return this.objADAlertaVariable.iniciarResolucionEvalCredAlerta(idEvalCred, clsVarGlobal.User.idUsuario);
        }
        public clsRespuestaServidor ejecutarFuncionDinamica(int idFuncionDinamica, DataTable dtReemplazos)
        {
            DataSet dsReemplazos = new DataSet("Reemplazos");
            DataTable dtReemplazosCopia = dtReemplazos.Copy();
            dtReemplazosCopia.TableName = "Reemplazo";
            dsReemplazos.Tables.Add(dtReemplazosCopia);
            string xmlReemplazos = string.Empty;
            xmlReemplazos = dsReemplazos.GetXml();

            return this.objADAlertaVariable.ejecutarFuncionDinamica(idFuncionDinamica, xmlReemplazos);
        }
        public clsRespuestaServidor denegarSolicitudCredDesfavorable(int idSolicitud, int idEvalCred)
        {
            return this.objADAlertaVariable.denegarSolicitudCredDesfavorable(idSolicitud, idEvalCred, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }
        public DataTable aplicabilidadEvalCredAlertaVar(int idSolicitud, int idEvalCred)
        {
            return this.objADAlertaVariable.aplicabilidadEvalCredAlertaVar(idSolicitud, idEvalCred);
        }
        public DataTable montoMinAlertaEval(int idSolicitud)
        {
            return this.objADAlertaVariable.montoMinAlertaEval(idSolicitud);
        }
    }
}
