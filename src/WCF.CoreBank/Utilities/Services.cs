using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ADM.CapaNegocio;
using EntityLayer;

namespace WCF.Corebank.Utilities
{
    public class Services
    {
        private clsWCFEjeSP objectWCFE = new clsWCFEjeSP();
        public clsCNMantenimiento objCNMantenimiento = new clsCNMantenimiento(true);

        public List<Dictionary<string, object>> DataTableToJson(DataTable dt)
        {
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            return parentRow;
        }

        public Dictionary<string, dynamic> EnviarSMS(Double numero, string mensaje)
        {
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

            try
            {
                DataTable dtVariable = objCNMantenimiento.CNRecuperarVariable("cServicioWCFSms");
                string cServicio = dtVariable.Rows[0]["cValVar"].ToString();
                string dicto = "{\"cToken\":\"\",\"objMensaje\":{\"nNroCelular\":" + numero + ",\"cMensaje\":\"" + mensaje + "\"}}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto); //Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string serviceURL = string.Format(cServicio + "/EnvioMensajesTexto");
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                Stream stream = new MemoryStream(response);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                var resService = obj.ReadObject(stream) as clsResponseSMS;

                if (resService.idRespuesta == 1)
                {
                    res.Add("cEstado", "success");
                }
                else
                {
                    res.Add("cEstado", "failed");
                    res.Add("cFail", resService.cMensaje);
                }

                
            }
            catch (Exception e)
            {
                res.Add("cEstado", "failed");
                res.Add("cFail", e.ToString());
            }

            return res;
        }
    }
}