using System.Data;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADProgFidelizacionClie
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //===============================================================
        // Registrar el programa de fidelización del cliente.
        //===============================================================
        public DataTable ADRegistrarProgFidelizacionClie(int idCliente, int idEstado, int idUsuario)
        {
            return objEjeSp.EjecSP("CLI_RegProgFidelizacionClie_SP", idCliente, idEstado, idUsuario);
        }

        //===============================================================
        // Obtener el programa de fidelización del cliente.
        //===============================================================
        public DataTable ADObtenerProgFidelizacionClie(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ObtProgFidelizacionClie_SP", idCliente);
        }

        //===============================================================
        // Obtener los estados del programa de fidelización.
        //===============================================================
        public DataTable ADObtEstProgFidelizacion()
        {
            return objEjeSp.EjecSP("CLI_ObtEstProgFidelizacion_SP");
        }

        //===============================================================
        // Obtiene los datos del colaborador.
        //===============================================================
        public DataTable ADObtenerDatosColaborador(int idCliente, string cDocumentoID = "")
        {
            return objEjeSp.EjecSP("CLI_ObtenerDatosColaborador_SP", idCliente, cDocumentoID);
        }
     
        //===============================================================
        // Registrar el log de estados del programa de fidelización del cliente.
        //===============================================================
        public DataTable ADRegistrarLogEstClieProgFid(int idCliente, int idEstado, int idUsuario)
        {
            return objEjeSp.EjecSP("CLI_RegLogEstClieProgFid_SP", idCliente, idEstado, idUsuario);
        }        
    }
}
