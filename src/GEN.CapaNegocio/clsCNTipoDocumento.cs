using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;


namespace GEN.CapaNegocio
{
   public  class clsCNTipoDocumento
    {
       public clsTipoDocumento objdocide = new clsTipoDocumento();
        public DataTable listarTipoDocumento()
        {
            return objdocide.ListarTipoDocumento();
        }

        public int BuscarDocumento(int tipoDoc)
        {
            return objdocide.CodigoSplaft(tipoDoc);
        }

        public DataTable CNListaDocSunatSplaft()
        {
            return objdocide.ADListaDocSunatSplaft();
        }

        public DataTable listarTipDocEsp(string cCodTipDoc)
        {
            return objdocide.ListarTipDocEspecificos(cCodTipDoc);
        }

        public DataTable CNListarTipoPersonaBusqueda()
        {
            return objdocide.ADListarTipoPersonaBusqueda();
        }
        public DataTable CNListarTipoDocumentosXDocumentoBusqueda(int idTipoPersonaBusqueda)
        {
            return objdocide.ADListarTipoDocumentosXDocumentoBusqueda(idTipoPersonaBusqueda);
        }

        public DataTable CNListarTipoDocumentosNumerados(bool lConsiderarRUC)
        {
            return objdocide.ADListarTipoDocumentosNumerados(lConsiderarRUC);
        }
    }
}
