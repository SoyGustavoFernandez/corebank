using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.CallCenter.Interfaces;
using WCF.CallCenter.Modelo;

namespace WCF.CallCenter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CallCenter" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CallCenter.svc or CallCenter.svc.cs at the Solution Explorer and start debugging.
    public class CallCenter : ICallCenter
    {
        public string ObtenerListMotivos()
        {
            return new ContactoCli().ObtenerListaMotivos();
        }

        public string ObtenerListTipoContacto()
        {
            return new ContactoCli().ObtenerListaTipoContacto();
        }        

        public string GuardarContactoCli(string jsonReqRegCliContac)
        {
            return new ContactoCli().GrabarContactoCli(jsonReqRegCliContac);
        }

        public string ObtenerInfoContactoCli(string jsonReqLisDatosCreCC)
        {
            return new ContactoCli().ObtenerInfoContactoCli(jsonReqLisDatosCreCC);
        }

        public string ObtenerPlanLlamadasDia()
        {
            return new ContactoCli().ObtenerPlanLlamadasDia();
        }               
    }
}
