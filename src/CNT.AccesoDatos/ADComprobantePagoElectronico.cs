using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer.CPE;
using EntityLayer;
using GEN.Funciones;
using System.Data;

namespace CNT.AccesoDatos
{
    public class ADComprobantePagoElectronico
    {

        private readonly clsGENEjeSP _genEjeSP = new clsGENEjeSP();

        public DataTable ValidaRegNuevo()
        {
            return _genEjeSP.EjecSP("CNT_ValidaProcesoNuevoCPE_SP"); 
        }


        public DataTable GetEstadoProcesoCPE()
        {
            return _genEjeSP.EjecSP("CNT_ListarEstadoProcesoCPE_SP");           
        }

        public IEnumerable<EstadoEnvioCPE> GetEstadoEnvioCPE()
        {
            var res = _genEjeSP.EjecSP("CNT_ListarEstadoEnvioCPE_SP");
            return res.ToList<EstadoEnvioCPE>();
        }

        public IEnumerable<ProcesoCPE> GetProcesoCPE(DateTime fechaIni, DateTime fechaFin, int idEstado)
        {
            var res = _genEjeSP.EjecSP("CNT_ListarProcesosCPE_SP", fechaIni, fechaFin, idEstado);
            return res.ToList<ProcesoCPE>();
        }

        public IEnumerable<ArchivoCPE> GetArchivoCPE(int idProcesoCPE)
        {
            var res = _genEjeSP.EjecSP("CNT_ListarArchivosCPE_SP", idProcesoCPE);
            return res.ToList<ArchivoCPE>();
        }

        public clsDBResp GuardarProceso(DateTime fechaIni, DateTime fechaFin, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_GuardarProcesoCPE_SP", fechaIni, fechaFin, idUsuario);
            return new clsDBResp(dtRes);
        }

        public clsDBResp ProcesarProceso(int idProceso, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_ProcesarOperacionesCPE_SP", idProceso, idUsuario);
            return new clsDBResp(dtRes);
        }

        public clsDBResp NumerarProceso(int idProceso, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_NumerarOperacionesCPE_SP", idProceso, idUsuario);
            return new clsDBResp(dtRes);
        }

        public clsDBResp GenerarArchivos(int idProceso, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_GenerarArchivoCPE_SP", idProceso, idUsuario);
            return new clsDBResp(dtRes);
        }

        public DataSet ObtenerArchivos(int idProceso)
        {
            var dsRes = _genEjeSP.DSEjecSP("CNT_GetArchivoCPE_SP", idProceso);
            return dsRes;
        }

        public clsDBResp AnularProceso(int idProceso, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_AnularProcesoCPE_SP", idProceso, idUsuario);
            return new clsDBResp(dtRes);
        }

        public clsDBResp RegistrarEnvioSunat(int idArchivo, DateTime fechaEnvio, string nombreCDR,
            int idEstadoEnvio, int idUsuario)
        {
            var dtRes = _genEjeSP.EjecSP("CNT_GuardarEnvioSunatCPE_SP", idArchivo, fechaEnvio,
                nombreCDR, idEstadoEnvio, idUsuario);
            return new clsDBResp(dtRes);
        }

        public OperacionCPE BuscarOperacionPorKardex(int idKardex)
        {
            var res = _genEjeSP.EjecSP("CNT_BuscarCPEByKardex_SP", idKardex);
            return res.ToList<OperacionCPE>().FirstOrDefault();
        }

    }
}
