using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADError
    {
        /// <summary>
        /// Metodo que registra los errores generados por el sistema
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool RegistrarError(Error error)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();

            bool lEstado = false;
            try
            {
                objEjeSp.EjecSP("GEN_InsRegLogErr_sp", error.cNomModGen, error.cNomForGen, error.cNomObjGen, error.cTipErrGen, error.nLinGenErr, error.cDesErrGen);
                lEstado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lEstado;
        } 
    }
}
