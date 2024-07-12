using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNT.AccesoDatos;
using EntityLayer;
using EntityLayer.CPE;

namespace CNT.CapaNegocio
{
    public class CNComprobantePagoElectronico
    {

        private readonly ADComprobantePagoElectronico _adComprobantePagoElectronico = new ADComprobantePagoElectronico();

        public DataTable ValidaRegNuevo() 
        {
            return _adComprobantePagoElectronico.ValidaRegNuevo();
        }

        public DataTable GetEstadoProcesoCPE()
        {
            return _adComprobantePagoElectronico.GetEstadoProcesoCPE();
        }

        public IEnumerable<EstadoEnvioCPE> GetEstadoEnvioCPE()
        {
            return _adComprobantePagoElectronico.GetEstadoEnvioCPE();
        }

        public IEnumerable<ProcesoCPE> GetProcesoCPE(DateTime fechaIni, DateTime fechaFin, int idEstado)
        {
            return _adComprobantePagoElectronico.GetProcesoCPE(fechaIni, fechaFin, idEstado);
        }

        public IEnumerable<ArchivoCPE> GetArchivoCPE(int idProcesoCPE)
        {
            return _adComprobantePagoElectronico.GetArchivoCPE(idProcesoCPE);
        }

        public clsDBResp GuardarProceso(DateTime fechaIni, DateTime fechaFin, int idUsuario)
        {
            return _adComprobantePagoElectronico.GuardarProceso(fechaIni, fechaFin, idUsuario);
        }

        public clsDBResp ProcesarProceso(int idProceso, int idUsuario)
        {
            return _adComprobantePagoElectronico.ProcesarProceso(idProceso, idUsuario);
        }

        public clsDBResp NumerarProceso(int idProceso, int idUsuario)
        {
            return _adComprobantePagoElectronico.NumerarProceso(idProceso, idUsuario);
        }

        public clsDBResp GenerarArchivos(int idProceso, int idUsuario)
        {
            return _adComprobantePagoElectronico.GenerarArchivos(idProceso, idUsuario);
        }

        public DataSet ObtenerArchivos(int idProceso)
        {
            return _adComprobantePagoElectronico.ObtenerArchivos(idProceso);
        }

        public clsDBResp AnularProceso(int idProceso, int idUsuario)
        {
            return _adComprobantePagoElectronico.AnularProceso(idProceso, idUsuario);
        }

        public clsDBResp RegistrarEnvioSunat(int idArchivo, DateTime fechaEnvio, string nombreCDR,
            int idEstadoEnvio, int idUsuario)
        {
            return _adComprobantePagoElectronico.RegistrarEnvioSunat(idArchivo, fechaEnvio, nombreCDR,
                idEstadoEnvio, idUsuario);
        }

        public OperacionCPE BuscarOperacionPorKardex(int idKardex)
        {
            return _adComprobantePagoElectronico.BuscarOperacionPorKardex(idKardex);
        }

    }
}
