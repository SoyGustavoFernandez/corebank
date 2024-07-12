using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;


namespace GEN.CapaNegocio
{
    public class clsCNFuenteRecurso
    {
        public DataTable ListarFuenteRecurso()
        {
            return new clsADFuenteRecurso().ListarFuenteRecurso();
        }
    }
}
