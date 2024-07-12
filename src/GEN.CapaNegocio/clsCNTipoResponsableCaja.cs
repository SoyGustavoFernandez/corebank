using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoResponsableCaja
    {
        clsADTipoResponsableCaja objListaDir = new clsADTipoResponsableCaja();
        
        // Crear metodo para recibir datos en un datatable del diario de operaciones
        public DataTable ListaTipoRespobableCajaOpe(int idAgencia, DateTime dFecOperacion)
        {
            return objListaDir.ListaTipoRespobableCajaOpe(idAgencia, dFecOperacion);
        }
        // Crear metodo para recibir datos en un datatable para la administracion 
        public DataTable ListaTipoRespobableCajaAdm(int idAgencia)
        {
            return objListaDir.ListaTipoRespobableCajaAdm(idAgencia);
        }

        public DataTable ListaTipoRespobableCajaSupervision(string cTipoVisita)
        {
            return objListaDir.ListaTipoRespobableCajaSupervision(cTipoVisita);
        }
    }
}
