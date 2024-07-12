using EntityLayer;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public class clsSeguimSilencioSPLAFT
    {
        #region Varibles globales
        clsCNMapeoRiesgoYOpeInusual cnmantenimientomapeoriesgo = new clsCNMapeoRiesgoYOpeInusual();
        clsCNBuscaKardex cnBuscaKardex = new clsCNBuscaKardex();       
        #endregion
        public clsSeguimSilencioSPLAFT(int idKardex)
        {
            clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
            DataTable dtResultado = cnmapeoriesgoyopeinusual.procesaSeguimSilencioso(idKardex, clsVarGlobal.dFecSystem);
        }
    }
}
