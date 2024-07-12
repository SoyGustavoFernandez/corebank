using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Xml.Linq;

namespace DEP.AccesoDatos
{
    public class clsADRegDocumentoCTS
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoDocumentoCTS()
        {
            return objEjeSp.EjecSP("DEP_ListarTipoDocumentoCTS_SP");
        }

        public DataTable ADListarRegDocumentosCTS(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ListarRegDocumentosCTS_SP", idCuenta);
        }

        public DataTable ADGrabarRegDocumentosCTS(string xmlRegDocCTS, int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_GrabarRegDocumentosCTS_SP", xmlRegDocCTS, idCuenta);
        }

        public DataTable ADReporteRegDocumentosCTS(int nOpion,DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_RptRegDocumentosCTS_SP", nOpion, dFechaIni, dFechaFin, idAgencia);
        }
        public DataTable ADListaDocumentosCTS(int idTipo)
        {
            return objEjeSp.EjecSP("DEP_ListaDocumentoByTipo_sp", idTipo);
        }
        public DataTable ADListarRegDocumentosCTSByCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_ListaDocRegByCuenta_sp", idCuenta);
        }
    }
}
