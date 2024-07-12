using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADGarantiaRural
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarGarantiaRuralid(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ListarGarantiaRural_SP", idEvalCred);
        }

        public DataTable InsertarGarantiaRural(int idEvalCred, string cDescripcion, string cTipoDocumento, decimal nValor, int idUsuarioReg, DateTime dFechaHoraReg)
        {
            return objEjeSp.EjecSP("CRE_InsertarGarantiaRural_SP", idEvalCred, cDescripcion, cTipoDocumento, nValor, idUsuarioReg, dFechaHoraReg);
        }

        public DataTable ActualizarGarantiaRural(int idGarantia, int idEvalCred, string cDescripcion, string cTipoDocumento, decimal nValor, int idUsuarioMod, DateTime dfechaUltimaMod)
        {
            return objEjeSp.EjecSP("CRE_ActualizarGarantiaRural_SP", idGarantia, idEvalCred, cDescripcion, cTipoDocumento, nValor, idUsuarioMod, dfechaUltimaMod);
        }
    }
}