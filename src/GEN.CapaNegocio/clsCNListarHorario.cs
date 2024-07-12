using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListarHorario
    {
        clsADListarHorario objHorario = new clsADListarHorario();
        public DataTable ListarHorario()
        {
            return objHorario.ListarHorario();

            
        }
    }
}
