using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace GEN.AccesoDatos
{
   public class clsTipoDocumento
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTipoDocumento()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoDocumento_sp");
        }
        public int CodigoSplaft(int idTipoDoc)
        {
            int codSpl;
            DataTable ds = objEjeSp.EjecSP("GEN_BuscaTipoDocumento", idTipoDoc);

            codSpl = Convert.ToInt32(ds.Rows[0]["cCodSPLAF"]);


            return codSpl;
        }
        public DataTable ADListaDocSunatSplaft()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoDocumentoCodSunatSplaft_sp");
        }

        public DataTable ListarTipDocEspecificos(string cCodigosTipDoc)
        {
            return objEjeSp.EjecSP("GEN_ListarTipDocEspecificos_SP", cCodigosTipDoc);
        }

        public DataTable ADListarTipoPersonaBusqueda()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoDocumentosBusqueda_SP");
        }
        public DataTable ADListarTipoDocumentosXDocumentoBusqueda(int idTipoPersonaBusqueda)
        {
            return objEjeSp.EjecSP("GEN_ListarTipoDocumentosXTipoPer_SP", idTipoPersonaBusqueda);
        }

        public DataTable ADListarTipoDocumentosNumerados(bool lConsiderarRUC)
        {
            return objEjeSp.EjecSP("GEN_ListarTipoDocConIndice_SP", lConsiderarRUC);
        }
    }
}
