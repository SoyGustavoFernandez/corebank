using System.Data;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADCliReferidos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //===============================================================
        // Registrar el referido del cliente
        //===============================================================
        public DataTable ADRegistrarReferidoClie(int idCliente, int idClienteRef, int idAgencia, int idUsuAsesor, int idUsuario, string cCelular, string cCorreo)
        {
            return objEjeSp.EjecSP("CLI_RegistraReferidoClie_SP", idCliente, idClienteRef, idAgencia, idUsuAsesor, idUsuario, cCelular, cCorreo);
        }

        //===============================================================
        // Lista los referidos del cliente
        //===============================================================
        public DataTable ADListaReferidoClie(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ListaReferidoClie_SP", idCliente);
        }

        //===============================================================
        // Obtener referido del cliente
        //===============================================================
        public DataTable ADObtieneReferidoClie(int idCliente, int idClienteRef)
        {
            return objEjeSp.EjecSP("CLI_ObtieneReferidoClie_SP", idCliente, idClienteRef);
        }

        //===============================================================
        // Obtener datos del referido
        //===============================================================
        public DataTable ADObtenerDatosReferido(int idCliente, string cDocumentoID = "")
        {
            return objEjeSp.EjecSP("CLI_ObtenerDatosReferido_SP", idCliente, cDocumentoID);
        }

        //===============================================================
        // Obtener datos de la base negativa
        //===============================================================
        public DataTable ADObtenerDatosBaseNegativa(string cDocumentoID)
        {
            return objEjeSp.EjecSP("CLI_ObtenerDatosBaseNegativa_SP", cDocumentoID);
        }        
    }
}
