using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNVarApl
    {
        public void LisVar(int nIDAgencia)
        {
            try
            {
                new clsADVarApl().Listar(nIDAgencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetVarApl(int idAgencia,clsVarAplClone objVarApl)
        {
            try
            {
                new clsADVarApl().GetVarApl(idAgencia,objVarApl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
