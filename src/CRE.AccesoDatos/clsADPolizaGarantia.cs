using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADPolizaGarantia
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void insertaactPoliza(clsPolizaGarantia objpoliza)
        {
            objEjeSp.EjecSPAlm("CRE_InsActPoliza_sp", objpoliza.idPoliza, objpoliza.idGarantia, objpoliza.idCompania,
                                                    objpoliza.cNumPoliza, objpoliza.nCobertura, objpoliza.dFecIniPol,
                                                    objpoliza.dFecFinPol, objpoliza.cNumCerti, objpoliza.nIndSeguro,
                                                    objpoliza.dFechaReg, objpoliza.idUsuReg, objpoliza.dFechaMod,
                                                    objpoliza.idUsuMod, objpoliza.idEstado, objpoliza.nPrima, objpoliza.idMoneda,
                                                    objpoliza.lPolizaExterna);
        }

        public clsPolizaGarantia retornadatPoliza(int idGarantia)
        {
            clsPolizaGarantia poliza = null;
            DataTable dt = objEjeSp.EjecSP("CRE_RetDatPoliza_sp", idGarantia);

            if (dt.Rows.Count > 0)
            {
                poliza = new clsPolizaGarantia();

                poliza.idPoliza     = (int)dt.Rows[0]["idPoliza"];
                poliza.idGarantia   = (int)dt.Rows[0]["idGarantia"];
                poliza.idCompania   = (int)dt.Rows[0]["idCompania"];
                poliza.cNumPoliza   = (string)dt.Rows[0]["cNumPoliza"];
                poliza.nCobertura   = (decimal)dt.Rows[0]["nCobertura"];
                poliza.dFecIniPol   = (DateTime)dt.Rows[0]["dFecIniPol"];
                poliza.dFecFinPol   = (DateTime)dt.Rows[0]["dFecFinPol"];
                poliza.cNumCerti    = (string)dt.Rows[0]["cNumCerti"];
                poliza.nIndSeguro   = (int)dt.Rows[0]["nIndSeguro"];
                poliza.dFechaReg    = (DateTime)dt.Rows[0]["dFechaReg"];
                poliza.idUsuReg     = (int)dt.Rows[0]["idUsuReg"];
                poliza.dFechaMod    = (DateTime)dt.Rows[0]["dFechaMod"];
                poliza.idUsuMod     = (int)dt.Rows[0]["idUsuMod"];   
                poliza.idEstado     = (int)dt.Rows[0]["idEstado"];
                poliza.nPrima       = (decimal)dt.Rows[0]["nPrima"];
                poliza.idMoneda = (int)dt.Rows[0]["idMoneda"];
                poliza.lPolizaExterna = (bool)dt.Rows[0]["lPolizaExterna"];
            }

            return poliza;
        }

        public DataTable RptPolizasGarantia(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CRE_RptPolizasGarantia_sp", dFecIni, dFecFin);
        }
    }
}
