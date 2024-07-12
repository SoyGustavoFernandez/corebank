using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoDocumentoSustento
    {
        private clsADTipoDocumentoSustento clsTipoDoc = new clsADTipoDocumentoSustento();

        public DataTable listarTipoDocumentoSustento()
        {
            return clsTipoDoc.listarTipoDocumentoSustento();
        }
    }
}
