using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNTipVinculo
    {
        clsADTipVinculo objlistaTipVin = new clsADTipVinculo();

        // Crear Método para Recibir Datos en un datatable
        public clslisTipoVinculo ListarTipVinculo()
        {
            return objlistaTipVin.ListaTipVinculo();
        }
    }
}
