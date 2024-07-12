using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using System.Web;


namespace RCP.Contratos
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    [DataContractFormat]
    public interface IRecuperaciones
    {
        [OperationContract]
        string WSListaHojasRuta(string cToken, DateTime dDesde, DateTime dA);

        [OperationContract]
        string WSObtenerCreditosHojaRuta(string cToken, int idHojaRuta);

        [OperationContract]
        string WSListaCarteraRecuperaciones(string cToken, int idPerfil, int idUbigeo, int nAtrazoMin, int nAtrazoMax, Decimal nSaldoCapitalMin, Decimal nSaldoCapitalMax, bool lSoloDirPrincipal, int nTipoInterviniente);

        [OperationContract]
        string WSAgregarCreditoHojaRuta(string cToken, int idHojaRuta, int idCuenta, int idInter, int idDirecion, int idTipoAccion, bool lDireccionRecupera);

        [OperationContract]
        string WSRegistrarGestionHojaRuta(string cToken, int idDetalleHojaRuta, int idResultado, int idMotivoMora, 
                                        int idTipoCliente, bool lRecuperable, string cObservacion, DateTime dFechaPromesa, 
                                        Decimal nMontoPromesa, string cObservacionPromesa, bool lVisitar, DateTime dFechaVisita, 
                                        string cObservacionVisita, string nLatitud, string nLongitud, DateTime dFechaRegCliente,
                                        bool lDomVerificado, bool lNotificacionEntregada);

        [OperationContract]
        string WSFinalizarGestionHojaRuta(string cToken, int idHojaRuta, int nKilometrajeFinal);

        [OperationContract]
        string WSListarTipoAccion(string cToken);

        [OperationContract]
        string WSListarTipoResultados(string cToken);

        [OperationContract]
        string WSListarTipoClientes(string cToken);

        [OperationContract]
        string WSListarMotivoMora(string cToken);        
    }
}
