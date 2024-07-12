using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNEstValorado
    {
        clsADEstValorado ADEstValorados = new clsADEstValorado();
        public DataTable CNEstValorado()
        {
            return ADEstValorados.ADEstValorados();
        }
        public DataTable CNEstValoradoOP()
        {
            return ADEstValorados.ADEstValoradosOP();
        }
    }
}
