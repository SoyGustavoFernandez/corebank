using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoIdentificacionPerJur
    {
        clsADTipoIdentificacionPerJur objlistaTipoIdentificacionPerJur = new clsADTipoIdentificacionPerJur();

        // Crear Método para Recibir Datos en un datatable
        public DataTable CNListaTipoIdentificacionPerJur()
        {
            return objlistaTipoIdentificacionPerJur.ADListaTipoidentificacion();
        }
    }
}
