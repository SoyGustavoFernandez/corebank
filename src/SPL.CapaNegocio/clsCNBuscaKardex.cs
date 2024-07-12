using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNBuscaKardex
    {
        public DataTable busquedaKardex (int idKardex){
        
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.buscarKardex(idKardex);

        }

        public DataTable CNRegistroSilenciosoSplaft(int idKardex)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADRegistroSilenciosoSplaft(idKardex);
        }

        public DataTable CNGetSustentosOperacion(int idKardex)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADGetSustentosOperacion(idKardex);
        }

        public DataTable CNValidarUmbralSustento(decimal _nMontoOpera, int _idMoneda, int _idTipoOperacion, int _idMotivoOperacion, int _idSubProducto, int _idTipoPago)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADValidarUmbralSustento(_nMontoOpera, _idMoneda, _idTipoOperacion, _idMotivoOperacion, _idSubProducto, _idTipoPago);
        }

        public DataTable CNBuscarArchivo(int idSustento)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADBuscarArchivo(idSustento);
        }

        public DataTable CNGuardarArchivos(string cNombreDoc, byte[] bDocument, string cExtencion, int idKardex, int idSustento, int idTipoDocumento, string cDescSustento, bool lVigente, int idUsuario, DateTime dFechaSis, int idCodOperacion)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADGuardarArchivos( cNombreDoc, bDocument, cExtencion, idKardex, idSustento, idTipoDocumento, cDescSustento, lVigente, idUsuario, dFechaSis, idCodOperacion);
        }

        public DataTable CNLimpiarArchivos(int idKardex)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADLimpiarArchivos(idKardex);
        }

        public DataTable CNValidaSubidaArchivosSustento(int idUsuario, DateTime dFecha)
        {
            clsADBuscarKardex objKarx = new clsADBuscarKardex();
            return objKarx.ADValidaSubidaArchivosSustento(idUsuario, dFecha);
        }
    }
}
