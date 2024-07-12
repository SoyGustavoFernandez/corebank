using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNGrupoCargaArchivo
    {
        clsADGrupoCargaArchivo objGrupo = new clsADGrupoCargaArchivo();

        public DataTable CNListarGrupoCargaArchivo()
        {
            return objGrupo.ADListarGrupoArchivo();
        }
    }
}
