using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace WCF.CallCenter.Modelo
{
    public class ContactoCli
    {
        const int nMaxValor = 100000000;

        public ContactoCli()
        {
        }

        public string ObtenerListaMotivos()
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            ReqLisMotivo objReqLisMotivo = json_serializer.Deserialize<ReqLisMotivo>("");
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqLisMotivo));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objReqLisMotivo);
                    xml = sww.ToString(); // Your XML
                }
            }

            clsCNAPICallCenter objCNAPICallCenter = new clsCNAPICallCenter(true);
            DataTable dtResLisMotivo = new DataTable();
            dtResLisMotivo = objCNAPICallCenter.CNListarMotivos(1, xml);

            string testData = string.Empty;

            if (dtResLisMotivo.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResLisMotivo.Rows[0]["Xml"]);
            }

            ResLisMotivo objResLisMotivo;
            XmlSerializer serializer = new XmlSerializer(typeof(ResLisMotivo));
            using (TextReader reader = new StringReader(testData))
            {
                objResLisMotivo = (ResLisMotivo)serializer.Deserialize(reader);
            }

            //Object to Json
            return new JavaScriptSerializer().Serialize(objResLisMotivo.Motivos);
        }

        public string ObtenerListaTipoContacto()
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            ReqLisTipoContacto objReqLisTipoContacto = json_serializer.Deserialize<ReqLisTipoContacto>("");
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqLisTipoContacto));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objReqLisTipoContacto);
                    xml = sww.ToString(); // Your XML
                }
            }

            clsCNAPICallCenter objCNAPICallCenter = new clsCNAPICallCenter(true);
            DataTable dtLisTipoContacto = new DataTable();
            dtLisTipoContacto = objCNAPICallCenter.CNListarTiposContacto(2, xml);

            string testData = string.Empty;

            if (dtLisTipoContacto.Rows.Count > 0)
            {
                testData = Convert.ToString(dtLisTipoContacto.Rows[0]["Xml"]);
            }

            ResLisTipoContacto objResLisTipoContacto;
            XmlSerializer serializer = new XmlSerializer(typeof(ResLisTipoContacto));
            using (TextReader reader = new StringReader(testData))
            {
                objResLisTipoContacto = (ResLisTipoContacto)serializer.Deserialize(reader);
            }

            //Object to Json
            return new JavaScriptSerializer().Serialize(objResLisTipoContacto.TipoContactos);
        }        

        public string GrabarContactoCli(string jsonReqRegCliContac)
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            ReqRegCliContac objReqRegCliContac = json_serializer.Deserialize<ReqRegCliContac>(jsonReqRegCliContac);
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqRegCliContac));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objReqRegCliContac);
                    xml = sww.ToString(); // Your XML
                }
            }

            clsCNAPICallCenter objCNAPICallCenter = new clsCNAPICallCenter(true);
            DataTable dtResGrabarContactoCli = new DataTable();
            dtResGrabarContactoCli = objCNAPICallCenter.CNGrabarContactoCli(3, xml);            

            string testData = string.Empty;

            if (dtResGrabarContactoCli.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResGrabarContactoCli.Rows[0]["Xml"]);
            }

            ResRegCliContac objResRegCliContac;
            XmlSerializer serializer = new XmlSerializer(typeof(ResRegCliContac));
            using (TextReader reader = new StringReader(testData))
            {
                objResRegCliContac = (ResRegCliContac)serializer.Deserialize(reader);
            }

            //Object to Json
            return new JavaScriptSerializer().Serialize(objResRegCliContac);
        }

        public string ObtenerInfoContactoCli(string jsonReqLisDatosCreCC)
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = nMaxValor;

            ReqLisDatosCreContac objReqLisDatosCreCC = json_serializer.Deserialize<ReqLisDatosCreContac>(jsonReqLisDatosCreCC);
            //
            
            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqLisDatosCreContac));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objReqLisDatosCreCC);
                    xml = sww.ToString(); // Your XML
                }
            }

            clsCNAPICallCenter objCNAPICallCenter = new clsCNAPICallCenter(true);
            DataTable dtResLisDatosCreCC = new DataTable();
            dtResLisDatosCreCC = objCNAPICallCenter.CNListarDatosCreditoCallCenter(4, xml);

            string testData = string.Empty;

            if (dtResLisDatosCreCC.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResLisDatosCreCC.Rows[0]["Xml"]);
            }

            ResLisDatosCreContac objResLisDatosCreCC;
            XmlSerializer serializer = new XmlSerializer(typeof(ResLisDatosCreContac));
            using (TextReader reader = new StringReader(testData))
            {
                objResLisDatosCreCC = (ResLisDatosCreContac)serializer.Deserialize(reader);
            }

            //Object to Json            
            return json_serializer.Serialize(objResLisDatosCreCC);
        }

        public string ObtenerPlanLlamadasDia()
        {
            //Json to Object
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = nMaxValor;

            ReqLisPlanTrabContac objReqLisTrabCC = json_serializer.Deserialize<ReqLisPlanTrabContac>("");
            //

            //Object to Xml
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqLisPlanTrabContac));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objReqLisTrabCC);
                    xml = sww.ToString(); // Your XML
                }
            }

            clsCNAPICallCenter objCNAPICallCenter = new clsCNAPICallCenter(true);
            DataTable dtResLisTrabCC = new DataTable();
            dtResLisTrabCC = objCNAPICallCenter.CNListarPlanTrabajoCallCenter(5, xml);

            string testData = string.Empty;

            if (dtResLisTrabCC.Rows.Count > 0)
            {
                testData = Convert.ToString(dtResLisTrabCC.Rows[0]["Xml"]);
            }

            ResLisPlanTrabContac objResLisTrabCC;
            XmlSerializer serializer = new XmlSerializer(typeof(ResLisPlanTrabContac));
            using (TextReader reader = new StringReader(testData))
            {
                objResLisTrabCC = (ResLisPlanTrabContac)serializer.Deserialize(reader);
            }

            //Object to Json            
            return json_serializer.Serialize(objResLisTrabCC);
        }
    }
}