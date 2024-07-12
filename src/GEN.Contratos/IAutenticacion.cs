using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace GEN.Contratos
{
    [ServiceContract]
    [DataContractFormat]
    public interface IAutenticacion
    {
        [OperationContract]
        string WSValidarUsuario(string cUsuario, string cClave, string cImei, string cNombEquipo, string cCaracteristicas);
        [OperationContract]
        string WSAsignarAgenPerfil(string cToken, int idAgencia, int idPerfil);
    }
}
