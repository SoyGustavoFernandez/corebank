using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;
using EntityLayer;

namespace DEP.CapaNegocio
{
    public class clsCNRegDocumentoCTS
    {
        public clsADRegDocumentoCTS objRegDocumentoCTS = new clsADRegDocumentoCTS();

        public DataTable CNListarTipoDocumentoCTS()
        {
            return objRegDocumentoCTS.ADListarTipoDocumentoCTS();
        }

        public DataTable CNListarRegDocumentosCTS(int idCuenta)
        {
            return objRegDocumentoCTS.ADListarRegDocumentosCTS(idCuenta);
        }

        public DataTable CNGrabarRegDocumentosCTS(string xmlRegDocCTS, int idCuenta)
        {
            return objRegDocumentoCTS.ADGrabarRegDocumentosCTS(xmlRegDocCTS, idCuenta);
        }

        public DataTable CNReporteRegDocumentosCTS(int nOpion, DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return objRegDocumentoCTS.ADReporteRegDocumentosCTS(nOpion, dFechaIni, dFechaFin, idAgencia);
        }
        public DataTable CNListaDocumentosCTS(int idTipo)
        {
            return objRegDocumentoCTS.ADListaDocumentosCTS(idTipo);
        }
        public DataTable CNListarRegDocumentosCTSByCuenta(int idCuenta)
        {
            return objRegDocumentoCTS.ADListarRegDocumentosCTSByCuenta(idCuenta);
        }
    }
}
