using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using System.Windows.Forms;

namespace CRE.CapaNegocio
{
    public class clsCNPaqueteSeguro
    {
        private clsADPaqueteSeguro objPaqueteSeguro = new clsADPaqueteSeguro();
        
        public DataTable CNListarPaqueteSeguro(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            return this.objPaqueteSeguro.ADListarPaqueteSeguro(_clsMantenimientoPaqueteSeguro);
        }

        public DataTable CNCragarPaqueteSeguro()
        {
            return this.objPaqueteSeguro.ADCragarPaqueteSeguro();
        }
        
        public DataTable CNListarSeguroComplementario()
        {
            return this.objPaqueteSeguro.ADListarSeguroComplementario();
        }
        
        public DataSet CNObtenerPaqueteSeguro(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            return this.objPaqueteSeguro.ADObtenerPaqueteSeguro(_clsMantenimientoPaqueteSeguro);
        }
        
        public DataTable CNMantenimientoPaqueteSeguros(string xmlDatosPlanSeguro)
        {
            return this.objPaqueteSeguro.ADMantenimientoPaqueteSeguros(xmlDatosPlanSeguro);
        }
        
        public DataTable CNMantenimientoSegurosComplementarios(int idUsuario, int idSeguro, string nombreSeguro, string nombreCortoSeguro, bool seguroComplementario, bool estado, decimal nPrecio)
        {
           return this.objPaqueteSeguro.ADMantenimientoSegurosComplementarios(idUsuario, idSeguro, nombreSeguro, nombreCortoSeguro, seguroComplementario, estado, nPrecio);
        }
        
        public IEnumerable<clsPaqueteSeguro> CNObtenerPaqueteSeguroVenta(int idDetalleGasto, int idPerfil, int idAgencia)
        {
            return objPaqueteSeguro.ADObtenerPaqueteSeguroVenta(idDetalleGasto, idPerfil, idAgencia);
        }
        
        public DataTable ADObtenerPaqueteSeguroPorIDConcepto(int idPaqueteSeguro)
        {
            return this.objPaqueteSeguro.ADObtenerPaqueteSeguroPorIDConcepto(idPaqueteSeguro);
        }

        public DataTable CNListarTodosLosPaqueteDeSeguro()
        {
            return this.objPaqueteSeguro.ADListarTodosLosPaqueteDeSeguro();
        }

        public DataTable CNObtenerPromotorInicialSeguroOptativo(int idSolicitud, int idTipoSeguro)
        {
            return objPaqueteSeguro.ADObtenerPromotorInicialSeguroOptativo(idSolicitud, idTipoSeguro);
        }

        public clsDBResp CNVerificarSituacionSeguroOpcional(int idSolicitud, int idUsuarioReactivacion, int idAgencia, int idPlan, int idFrmPlan)
        {
            DataTable resp = CNObtenerPromotorInicialSeguroOptativo(idSolicitud, idPlan);
            clsDBResp dbResp = new clsDBResp();
            dbResp.nMsje = -1;

            // Si no hay registros, continuar
            if (resp.Rows.Count == 0)
                return dbResp;

            bool lTieneSeguroDesactivado = Convert.ToBoolean(resp.Rows[0]["lTieneSeguroDesactivado"]);
            int idUsuarioOriginal = Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);

            if (/*lTieneSeguroDesactivado && */idUsuarioReactivacion != idUsuarioOriginal)
            {
                DataTable verificacion = CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(idSolicitud);
                if (verificacion.Rows.Count == 0)
                {
                    // Considera 0 todo bien y 1 cuando rechazado
                    dbResp = CNSolicitarReactivacionSeguroOpcional(idSolicitud, idUsuarioReactivacion, idAgencia, idPlan, idFrmPlan);
                    return dbResp;
                }

                int idUsuarioReactivacionSolicitante = Convert.ToInt32(verificacion.Rows[0]["idUsuarioReactivacion"]);
                int idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);
                if (idEstadoSolicitud == 4) //RECHAZADO
                {
                    dbResp.nMsje = 3;
                    dbResp.cMsje = "La solicitud ha sido rechazada";
                    return dbResp;
                }
                if (idEstadoSolicitud == 1) //SOLICITADO
                {
                    dbResp.nMsje = 4;
                    dbResp.cMsje = "La solicitud se encuentra pendiente de aprobación.";
                    return dbResp;
                }
                if (idEstadoSolicitud.In(2, 3)) //APROBADO O EJECUTADO
                {
                    dbResp.nMsje = -1;
                    return dbResp;
                }
            }
            return dbResp;
        }

        public DataTable CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(int idSolicitud)
        {
            return objPaqueteSeguro.ADConsultarSolicitudReactivacionSeguroOpcional(idSolicitud);
        }

        public clsDBResp CNSolicitarReactivacionSeguroOpcional(int idSolicitud, int idUsuarioReactivacion, int idAgencia, int idPlan, int idFrmPlan)
        {
            return objPaqueteSeguro.ADSolicitarReactivacionSeguroOpcional(idSolicitud, idUsuarioReactivacion, idAgencia, idPlan, idFrmPlan);
        }

        public clsDBResp CNEjecutarReactivacionSeguroOpcionalPorGrupo(int idSolicitudCredGrupoSol)
        {
            return objPaqueteSeguro.ADEjecutarReactivacionSeguroOpcionalPorGrupo(idSolicitudCredGrupoSol);
        }

        public clsDBResp CNEjecutarReactivacionSeguroOpcional(int idSolicitud)
        {
            return objPaqueteSeguro.ADEjecutarReactivacionSeguroOpcional(idSolicitud);
        }

        public clsDBResp CNEDesactivarSolicitudPorArrepentimiento(int idSolicitud)
        {
            return objPaqueteSeguro.ADDDesactivarSolicitudPorArrepentimiento(idSolicitud);
        }


    }
}
