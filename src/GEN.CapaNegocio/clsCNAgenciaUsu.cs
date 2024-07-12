using System.Collections.Generic;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNAgenciaUsu
    {
        public List<clsAgencia> CNListarAgenciasUsuario(int idUsuario)
        {
            return new clsADAgenciaUsu().ADListarAgenciasUsuario(idUsuario);
        } 
    }
}