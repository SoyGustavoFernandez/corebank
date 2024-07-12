using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantEstablec
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEstablecimientos()
        {
            return objEjeSp.EjecSP("GRH_ListarDatosEstablecimientos_sp");
        }
        public DataTable ActualizarEstablecimiento(int idEst, string cNomEstablec, string cDireccion, int idUbigeo, string cReferencia, string cTelefono, string cCodSUNAT, int lVigente, int lCenRiesgo, int idTipoEstablecimiento, bool lAutBiometricaAgencia, bool lAutBiometricaComite, bool lVerificacionSMS)
        {
            return objEjeSp.EjecSP("GRH_ActualizarEstablec_SP", idEst, cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
        }
        public DataTable GuardarEstablecimiento(string cNomEstablec, string cDireccion, int idUbigeo, string cReferencia, string cTelefono, string cCodSUNAT, int lVigente, int lCenRiesgo, int idTipoEstablecimiento, bool lAutBiometricaAgencia, bool lAutBiometricaComite, bool lVerificacionSMS)
        {
            return objEjeSp.EjecSP("GRH_GuardarEstablec_SP", cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
        }
    }
}
