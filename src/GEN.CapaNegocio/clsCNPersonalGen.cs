using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNPersonalGen
    {
        public clsADPersonalGen objPersonal = new clsADPersonalGen();
        public DataTable ListaPersonal(int idAgencia)
        {
            return objPersonal.ADListaPersonal(idAgencia);
        }
        public DataTable CNListaPersonalPerfil(int idAgencia, string cVarPerfil)
        {
            return objPersonal.ADListaPersonalPerfil(idAgencia, cVarPerfil);
        }
    }
}
