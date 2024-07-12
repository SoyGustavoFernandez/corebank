using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNVarGen
    {
        public void LisVar(int nIDAgencia)
        {
            try
            {
                new clsADVarGen().Listar(nIDAgencia);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public void GetVarGlobal(int idAgencia,clsVarGlobalClone objVarGlobal)
        {
            try
            {
                new clsADVarGen().GetVarGlobal(idAgencia,objVarGlobal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
