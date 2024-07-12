using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WCF.CallCenter.Interfaces;
using WCF.CallCenter.Modelo;

namespace WCF.CallCenter.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Authentication" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Authentication.svc or Authentication.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Authentication : IAuthentication
    {
        /*public string Authenticate(clsCredencial objCrendecial)
        {
            if (objCrendecial == null && WebOperationContext.Current != null)
            {
                var basicAuthHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                if (!string.IsNullOrWhiteSpace(basicAuthHeader))
                    objCrendecial = new BasicAuth(basicAuthHeader).ObtenerCred;
            }

            return new clsTokenGenerador().GeneraToken(objCrendecial);
        }*/
    }
}
