using System.Data;
using CLI.AccesoDatos;

namespace CLI.CapaNegocio
{
    public class clsCNCliReferidos
    {
        clsADCliReferidos objCliReferidos = new clsADCliReferidos();

         //===============================================================
        // Registrar el referido del cliente
        //===============================================================
        public DataTable CNRegistrarReferidoClie(int idCliente, int idClienteRef, int idAgencia, int idUsuAsesor, int idUsuario, string cCelular, string cCorreo)
        {
            return objCliReferidos.ADRegistrarReferidoClie(idCliente, idClienteRef, idAgencia, idUsuAsesor, idUsuario, cCelular, cCorreo);
        }

        //===============================================================
        // Lista los referidos del cliente
        //===============================================================
        public DataTable CNListaReferidoClie(int idCliente)
        {
            return objCliReferidos.ADListaReferidoClie(idCliente);
        }

        //===============================================================
        // Obtener referido del cliente
        //===============================================================
        public DataTable CNObtieneReferidoClie(int idCliente, int idClienteRef)
        {
            return objCliReferidos.ADObtieneReferidoClie(idCliente, idClienteRef);
        }

        //===============================================================
        // Obtener datos del referido
        //===============================================================
        public DataTable CNObtenerDatosReferido(int idCliente, string cDocumentoID = "")
        {
            return objCliReferidos.ADObtenerDatosReferido(idCliente, cDocumentoID);
        }

        //===============================================================
        // Obtener datos de la base negativa
        //===============================================================
        public DataTable CNbtenerDatosBaseNegativa(string cDocumentoID)
        {
            return objCliReferidos.ADObtenerDatosBaseNegativa(cDocumentoID);
        }        
    }
}
