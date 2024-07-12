using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADBuscarKardex
    {
        public DataTable buscarKardex(int idKardex)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("GEN_BuscarKardexSPL", idKardex);
            return ds;
        }

        public DataTable ADRegistroSilenciosoSplaft(int idKardex)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("GEN_RegistroAutomaticoOperacionesUnicas_SP", idKardex);
            return ds;
        }

        public DataTable ADGetSustentosOperacion(int idKardex)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("SPL_ListarSustentosOperacion_SP", idKardex);
            return ds;
        }

        public DataTable ADValidarUmbralSustento(decimal _nMontoOpera, int _idMoneda, int _idTipoOperacion, int _idMotivoOperacion, int _idSubProducto, int _idTipoPago)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            return objEjeSp.EjecSP("SPL_ValidarUmbralSustento_SP", _nMontoOpera, _idMoneda, _idTipoOperacion, _idMotivoOperacion, _idSubProducto, _idTipoPago);
        }

        public DataTable ADBuscarArchivo(int idSustento)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("SPL_BuscarArchivoSustento_SP", idSustento);
        }

        public DataTable ADGuardarArchivos(string cNombreDoc, byte[] bDocument, string cExtencion, int idKardex, int idSustento, int idTipoDocumento, string cDescSustento, bool lVigente, int idUsuario, DateTime dFechaSis, int idCodOperacion)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("SPL_GuardarSustentoArchivo_SP", cNombreDoc, bDocument, cExtencion, idKardex, idSustento, idTipoDocumento, cDescSustento, lVigente, idUsuario, dFechaSis, idCodOperacion);
        }

        public DataTable ADLimpiarArchivos(int idKardex)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("SPL_LimpiarSustentoArchivo_SP", idKardex);
        }

        public DataTable ADValidaSubidaArchivosSustento(int idUsuario, DateTime dFecha)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            return objEjeSp.EjecSP("SPL_CargaSustentoPendientes_SP", idUsuario, dFecha);
        }
    }
}
