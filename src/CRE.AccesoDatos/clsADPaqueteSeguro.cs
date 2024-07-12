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
    public class clsADPaqueteSeguro
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();
       
        public DataTable ADListarPaqueteSeguro(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            return objEjeSp.EjecSP("CRE_ListarPaqueteSeguro_SP", _clsMantenimientoPaqueteSeguro.cNombreCompleto, 
                _clsMantenimientoPaqueteSeguro.dFechaRegistro, _clsMantenimientoPaqueteSeguro.dFechaFinRegistro, 
                _clsMantenimientoPaqueteSeguro.idDetalleGasto,  _clsMantenimientoPaqueteSeguro.cEstado, _clsMantenimientoPaqueteSeguro.nFiltro);
        }
        
        public DataTable ADListarSeguroComplementario()
        {
            return objEjeSp.EjecSP("CRE_ListarSeguroComplementario_SP");
        }
        
        public DataTable ADCragarPaqueteSeguro()
        {
            return objEjeSp.EjecSP("CRE_ObtenerPaqueteSeguros_SP");
        }
        
        public DataSet ADObtenerPaqueteSeguro(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerPaqueteSeguroDetalle_SP", _clsMantenimientoPaqueteSeguro.idPaqueteSeguro);
        }
        
        public DataTable ADMantenimientoPaqueteSeguros(string xmlDatosPlanSeguro)
        {
            return objEjeSp.EjecSP("CRE_MantenimientoPaqueteSeguros_SP", xmlDatosPlanSeguro);
        }
        
        public DataTable ADMantenimientoSegurosComplementarios(int idUsuario,int idseguro,string nombreSeguro,string nombreCortoSeguro,bool seguroComplementario,bool estado, decimal nPrecio)
        {
            return objEjeSp.EjecSP("CRE_MantenimientoSegComplementario_SP",  idUsuario,  idseguro,  nombreSeguro,  nombreCortoSeguro,  seguroComplementario, estado, nPrecio);
        }
        
        public IEnumerable<clsPaqueteSeguro> ADObtenerPaqueteSeguroVenta(int idDetalleGasto, int idPerfil, int idAgencia)
        {
            return objEjeSp.LOEjecutar<clsPaqueteSeguro>("CRE_ObtenerPaqueteSeguroVenta_SP", idDetalleGasto, idPerfil, idAgencia);
        }
        
        public DataTable ADObtenerPaqueteSeguroPorIDConcepto(int idPaqueteSeguro)
        {
            return objEjeSp.EjecSP("CRE_ObtenerPaqueteSeguroPorIDConcepto_SP", idPaqueteSeguro);
        }
        
        public DataTable ADListarTodosLosPaqueteDeSeguro()
        {
            return objEjeSp.EjecSP("CRE_ObtenerListaPaquetesDeSeguro_SP");
        }
        
        public DataTable ADObtenerPromotorInicialSeguroOptativo(int idSolicitud, int idTipoSeguro)
        {
            return objEjeSp.EjecSP("CRE_ObtenerPromotorInicialSeguroOptativo_SP", idSolicitud, idTipoSeguro);
        }
        
        public DataTable ADConsultarSolicitudReactivacionSeguroOpcional(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultarSolicitudReactivacionSeguroOpcional_SP", idSolicitud);
        }
        
        public clsDBResp ADSolicitarReactivacionSeguroOpcional(int idSolicitud, int idUsuarioReactivacion, int idAgencia, int idPlan, int idFrmPlan)
        {
            return objEjeSp.OEjecutar<clsDBResp>("CRE_SolicitarReactivacionSeguroOpcional_SP", idSolicitud, idUsuarioReactivacion, idAgencia, idPlan, idFrmPlan);
        }
        
        public clsDBResp ADEjecutarReactivacionSeguroOpcionalPorGrupo(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.OEjecutar<clsDBResp>("CRE_EjecutarReactivacionSeguroOpcionalPorGrupo_SP", idSolicitudCredGrupoSol);
        }
        
        public clsDBResp ADEjecutarReactivacionSeguroOpcional(int idSolicitud)
        {
            return objEjeSp.OEjecutar<clsDBResp>("CRE_EjecutarReactivacionSeguroOpcional_SP", idSolicitud);
        }

        public clsDBResp ADDDesactivarSolicitudPorArrepentimiento(int idSolicitud)
        {
            return objEjeSp.OEjecutar<clsDBResp>("CRE_DesactivarSolicitudPorArrepentimiento_SP", idSolicitud);
        }
    }
}
