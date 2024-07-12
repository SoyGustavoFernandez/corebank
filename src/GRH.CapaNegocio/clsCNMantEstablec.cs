using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantEstablec
    {
        clsADMantEstablec ListaAreas = new clsADMantEstablec();

        public DataTable ListarEstablecimientos()
        {
            return ListaAreas.ListarEstablecimientos();
        }
        public DataTable ActualizarEstablecimiento(int idEst, string cNomEstablec, string cDireccion, int idUbigeo, string cReferencia, string cTelefono, string cCodSUNAT, int lVigente, int lCenRiesgo, int idTipoEstablecimiento, bool lAutBiometricaAgencia, bool lAutBiometricaComite, bool lVerificacionSMS)
        {
            return ListaAreas.ActualizarEstablecimiento(idEst, cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
        }
        public int GuardarEstablecimiento(string cNomEstablec, string cDireccion, int idUbigeo, string cReferencia, string cTelefono, string cCodSUNAT, int lVigente, int lCenRiesgo, int idTipoEstablecimiento, bool lAutBiometricaAgencia, bool lAutBiometricaComite, bool lVerificacionSMS)
        {
            DataTable dt = ListaAreas.GuardarEstablecimiento(cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
            int idNuevo=Convert.ToInt32(dt.Rows[0][0]);
            return idNuevo;
        }  
        
        
        
    }
}
