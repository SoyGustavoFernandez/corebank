using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.WMQ;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.CapaNegocio;
using System.Xml;
using System.Xml.Serialization;
using GEN.Funciones;
using System.Text.RegularExpressions;

namespace GEN.ControlesBase
{
    public class clsObtenerDatosRen
    {
        clsProcesaDatosRen ObjProcesaDatosRen = new clsProcesaDatosRen();

        #region variables Globales
        List<clsProcesaDatosRen> lisProcesaDatos = new List<clsProcesaDatosRen>();
        clsProcesaDatosRen ProcDatos = new clsProcesaDatosRen();
        clsCNConsultaDatos RegLog = new clsCNConsultaDatos(true);

        string cRespuesta = "";

        string cError, cDni;
        string cFoto, cFirma;
        int[] numbersArray = { 5002, 5003, 5004, 5008, 5009, 5010, 5011, 5020, 5021, 5030, 5031, 5032, 5033, 5034, 5036, 5037, 5100, 5101, 5102, 5103, 5104, 5105, 5108, 5109, 5110, 5111, 5112, 5113, 5114, 5200 };
        string cErrorReniec = "";

        MQQueueManager mqQMgr;
        MQQueue requestQueue;
        MQQueue responseQueue;
        MQRCText mqrcText = new MQRCText();
        MQMessage requestMessage;
        MQMessage responseMessage;
        Hashtable properties = new Hashtable();

        string strRequestQueueName = "";
        string strResponseQueueName = "";
        string strQueueManagerName = "";
        string cCodigoEmp = "";
        string cDocumentoBus = "";
        string cDocumentoAutorizado = "";
        string strRequestText = "";

        string cCadena = "";
        string cFotoF = "";
        string cFirmaF = "";

        string cHost = "172.25.38.37";
        string cPort = "1414";
        string cCodEmpresa = "LD2089";
        int idUsuario;
        string cMensajeError = "";
        Regex regDNI = new Regex("[0-9]{8}"); //Expresión que solo acepta números.
        Regex regNum = new Regex("[0-9]"); //Expresión que solo acepta números.

        int idFlagEstado = 0;// Flag de estado de conexion y estado de procesamiento

        string cCadenaFoto = "";
        string cCadenaFirma = "";

        #endregion

        public clsProcesaDatosRen BuscarDocumento(string cDniBD, string cDocAutorizado, string idUsu)
        {
            if (ValidarListaNegra(cDniBD) == true)
            {
                ObjProcesaDatosRen.GetDataNA();
                return ObjProcesaDatosRen;
            }

            if (ValidarDatosDNI(cDniBD, cDocAutorizado, idUsu) == true)
            {
                ObjProcesaDatosRen.GetDataNA();
                return ObjProcesaDatosRen;
            }

            cDocumentoAutorizado = cDocAutorizado;

            ObjProcesaDatosRen = RealizarConsulta(cDniBD, cDocAutorizado, idUsu, "0");

            return ObjProcesaDatosRen;


        }

        public clsProcesaDatosRen BuscarDocumentoConsultaDirecta(string cDniBD, string cDocAutorizado, string idUsu, string cIdConsultaDirecta)
        {
            if (ValidarListaNegra(cDniBD) == true)
            {
                ObjProcesaDatosRen.GetDataNA();
                return ObjProcesaDatosRen;
            }

            if (ValidarDatosDNI(cDniBD, cDocAutorizado, idUsu) == true)
            {
                ObjProcesaDatosRen.GetDataNA();
                return ObjProcesaDatosRen;
            }


            cDocumentoAutorizado = cDocAutorizado;

            ObjProcesaDatosRen = RealizarConsulta(cDniBD, cDocAutorizado, idUsu, cIdConsultaDirecta);

            return ObjProcesaDatosRen;

        }

        private bool ValidarListaNegra(string cDniBD)
        {


            DataTable dtListNegra = RegLog.CNBuscarDniListaNegra(cDniBD);
            int nNumListNegra = Convert.ToInt32(dtListNegra.Rows[0]["nCantidad"].ToString());

            if (nNumListNegra > 0)
            {
                ObjProcesaDatosRen.GetDataNA();
                return true;
            }
            return false;

        }

        private bool ValidarDatosDNI(string cDniBD, string cDocAutorizado, string idUsu)
        {
                     
            if (cDniBD.Length != 8 || cDocAutorizado.Length != 8)
            {
                return true;
            }

            if (!regDNI.IsMatch(cDniBD) || !regDNI.IsMatch(cDocAutorizado) || !regNum.IsMatch(idUsu))
            {
                return true;
            }
           

            DataTable dtBuscarDniError = RegLog.CNBuscarDniError(cDniBD);
            if (dtBuscarDniError.Rows.Count > 0)
            {
                return true;
            }

            return false;

        }

        private clsProcesaDatosRen RealizarConsulta(string cDniBD, string cDocAutorizado, string idUsu, string cIdConsultaDirecta)
        {

            bool lConex = true;
            clsCNConsultaDatos CNValidaDatos;

            CNValidaDatos = new clsCNConsultaDatos(lConex);

            DataTable dtDatos;

            int nIdConsultaDirecta = Convert.ToInt32(cIdConsultaDirecta);

            if (nIdConsultaDirecta == 0)
            {
                dtDatos = CNValidaDatos.CNValidaInsDatos(cDniBD);
            }
            else
            {
                dtDatos = CNValidaDatos.CNValidaInsDatosDirecta(cDniBD);

            }


            int nIdMsj = Convert.ToInt32(dtDatos.Rows[0]["cIdMsj"].ToString());
            idUsuario = Convert.ToInt32(idUsu);

            if (nIdMsj == 0 || nIdMsj == 2)
            {

                BuscarDni(cDniBD, cDocAutorizado, this.cCodEmpresa, cIdConsultaDirecta);

                if (cCadena == "")
                {

                    DataTable tRegLog = RegLog.CNRegistraLog(cDniBD, "", "No se obtuvo trama de respuesta, para este Dni Consultado", idUsuario, cDocAutorizado);
                    ObjProcesaDatosRen.GetDataNA();
                    return ObjProcesaDatosRen;
                }
                else if (cError != "0000")
                {

                    DataTable tRegLog = RegLog.CNRegistraLog(cDniBD, cError, "Error enviado por Reniec ->SI_FinRenCodigoMensajeError<- ", idUsuario, cDocAutorizado);
                    ObjProcesaDatosRen.GetDataNA();
                    return ObjProcesaDatosRen;
                }
                else
                {
                    ObjProcesaDatosRen.GetData(cCadena, cFotoF, cFirmaF);
                    return ObjProcesaDatosRen;

                }
            }
            else
            {
                DataTable dtDatosConsulta = CNValidaDatos.CNConsultaDatos(cDniBD);
                ObjProcesaDatosRen.GetDataDt(dtDatosConsulta);
                DataTable tRegLog = RegLog.CNRegistraLog(cDniBD, ObjProcesaDatosRen.cErrorF, "Consulta sobre ->SI_FinRenDatosConsultados<-.", idUsuario, cDocAutorizado);
                return ObjProcesaDatosRen;
            }


        }



        private void InsertTramas(string cDocumentoBus, string cDocAutorizado)
        {
            cError = "";
            cCadena = "";
            cDni = "";
            cRespuesta = "";
            cCadenaFirma = "";
            cCadenaFoto = "";
            cFotoF = "";
            cFirmaF = "";

            DataTable tBUsTramaResp = RegLog.CNBuscarDniTrama(cDocumentoBus);

            if (tBUsTramaResp.Rows.Count > 0)
            {
                string cCadenaLogTrama = tBUsTramaResp.Rows[0]["cTrama"].ToString();

                cCadenaFoto = tBUsTramaResp.Rows[0]["cFotoTrama"].ToString();
                cCadenaFirma = tBUsTramaResp.Rows[0]["cFirmaTrama"].ToString();

                cRespuesta = cCadenaLogTrama;
                cCadena = cRespuesta;

                cError = cRespuesta.Substring(128, 4);
                int nError = Convert.ToInt32(cError);
                cFotoF = cCadenaFoto;
                cFirmaF = cCadenaFirma;
                cDni = cRespuesta.Substring(132, 8);

                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "cError enviado por Reniec y recogido del Log de tramas Base 0: " + cError, idUsuario, cDocAutorizado);

                ObjProcesaDatosRen.GetData(cCadena, cFotoF, cFirmaF);
                ConvertirYGuardar(ObjProcesaDatosRen);
                DataTable tRegLog1 = RegLog.CNRegistraLog(cDni, cError, "Se guardan los datos del Dni Consultado en ->SI_FinRenDatosConsultados<-.", idUsuario, cDocAutorizado);

            }

        }

        private void GuardarDatos(string cCadena, string cFotoF, string cFirmaF, string cDocAutorizado)
        {
            ObjProcesaDatosRen.GetData(cCadena, cFotoF, cFirmaF);
            ConvertirYGuardar(ObjProcesaDatosRen);
            DataTable tRegLog = RegLog.CNRegistraLog(ObjProcesaDatosRen.cDniF, ObjProcesaDatosRen.cErrorF, "Se guardan los datos del Dni Consultado en ->SI_FinRenDatosConsultados<-, desde Paso 5. ", idUsuario, cDocAutorizado);
        }

        private void ConvertirYGuardar(clsProcesaDatosRen DataRecibida)
        {
            List<clsProcesaDatosRen> obj = new List<clsProcesaDatosRen>();
            obj.Add(DataRecibida);
            bool lConex = true;
            clsCNConsultaDatos VerDatos;
            VerDatos = new clsCNConsultaDatos(lConex);

            DataTable dtDatos = VerDatos.CNVerDatos(clsUtils.ListToXml<clsProcesaDatosRen>(obj), idUsuario, cDocumentoAutorizado);

        }

        private void Inicializar()
        {
            if (properties.Count == 0)
            {

                properties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                properties.Add(MQC.HOST_NAME_PROPERTY, cHost);
                properties.Add(MQC.PORT_PROPERTY, Convert.ToInt32(cPort));
                properties.Add(MQC.CHANNEL_PROPERTY, "CAJARUANDES.RENIEC");
                properties.Add(MQC.USE_MQCSP_AUTHENTICATION_PROPERTY, true);
            }
        }

        private void BuscarDni(string cDocumentoBuscado, string cDocumentoAut, string cCodEmp, string cIdConsultaDirecta)
        {
            Inicializar();
            cDocumentoBus = cDocumentoBuscado;
            procesar(cDocumentoBus, cDocumentoAut, cCodEmp, idFlagEstado, cIdConsultaDirecta);
            int nContador = 0;
            if (cError == "0000")
            {
                if (cDocumentoBus == cDni)
                {
                    DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "1.- Se obtuvieron los datos para el Dni Consultado", idUsuario, cDocumentoAut);
                }
                else
                {

                    while (cDocumentoBus != cDni && nContador < 10 && idFlagEstado == 1)
                    {
                        procesar(cDocumentoBus, cDocumentoAut, cCodEmp, idFlagEstado, cIdConsultaDirecta);
                        DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "1 .- Se recojen datos de la cola de Reniec.", idUsuario, cDocumentoAut);

                        nContador += 1;
                    }
                    nContador = 0;
                    idFlagEstado = 0;
                }
            }
            else if (numbersArray.Equals(cError))
            {
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "Error enviado por Reniec ->SI_FinRenCodigoMensajeError<-", idUsuario, cDocumentoAut);
                if (cDocumentoBus == cDni)
                {
                    tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "2.- Se obtuvieron los datos para el Dni Consultado", idUsuario, cDocumentoAut);
                }
                else
                {
                    while (cDocumentoBus != cDni && nContador < 10 && idFlagEstado == 1)
                    {
                        procesar(cDocumentoBus, cDocumentoAut, cCodEmp, idFlagEstado, cIdConsultaDirecta);
                        tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "2 .- Se recojen datos de la cola de Reniec.", idUsuario, cDocumentoAut);
                        nContador += 1;
                    }

                    nContador = 0;
                    idFlagEstado = 0;
                }
            }
            else
            {
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", "Existe un error en la TRAMA", idUsuario, cDocumentoAut);
            }
        }

        private bool CrearAdmColas()
        {
            //Step 1. Create Queue Manager Object. This will also CONNECT the Queue Manager
            try
            {
                mqQMgr = new MQQueueManager(strQueueManagerName, properties);
                return true;
            }
            catch (Exception mqe)
            {
                cMensajeError = ("Paso 1. Error al crear el objeto del administrado de colas. tambien se conectará al administrador de colas:" + mqe.Message + " , " + mqe.Source + " , " + mqe.TargetSite + " , " + mqe.HelpLink + " , " + mqe.StackTrace + " , " + mqe.TargetSite + " , " + mqe.InnerException + " , " + mqe.HResult);
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", cMensajeError, idUsuario, cDocumentoAutorizado);
                cMensajeError = "";
                return false;
            }
        }
        private bool AbrirColaSolicitudes()
        {
            //Step 2. Open Request Queue for writing our request
            try
            {
                requestQueue = mqQMgr.AccessQueue(strRequestQueueName,
                    MQC.MQOO_OUTPUT                     // open queue for output
                    + MQC.MQOO_FAIL_IF_QUIESCING);      // but not if MQM stopping
                return true;
            }
            catch (Exception mqe)
            {
                cMensajeError = ("Paso 2: Error al intentar abrir la cola de solicitudes para escribir nuestra solicitud: " + mqe.Message + " , " + mqe.Source + " , " + mqe.TargetSite + " , " + mqe.HelpLink + " , " + mqe.StackTrace + " , " + mqe.TargetSite + " , " + mqe.InnerException + " , " + mqe.HResult);
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", cMensajeError, idUsuario, cDocumentoAutorizado);
                cMensajeError = "";

                mqQMgr.Disconnect();
                return false;
            }
        }
        private bool AbrirColaRespuestas()
        {
            //Step 3. Open Response Queue for reading the response.
            //Note: You can do this AFTER writing the request too. Depends on the protocol
            //you are using - may be you are not supposed to write the request unless you
            //ensure that you are listening for response too. If that is not the case,
            //you can do this after writing the request message (before step 5).
            try
            {
                responseQueue = mqQMgr.AccessQueue(strResponseQueueName,
                    MQC.MQOO_INPUT_AS_Q_DEF             // open queue for input
                    + MQC.MQOO_FAIL_IF_QUIESCING);      // but not if MQM stopping
                return true;
            }
            catch (Exception mqe)
            {
                cMensajeError = ("Paso 3: Error al intentar abrir Response Queue para leer:" + mqe.Message + " , " + mqe.Source + " , " + mqe.TargetSite + " , " + mqe.HelpLink + " , " + mqe.StackTrace + " , " + mqe.TargetSite + " , " + mqe.InnerException + " , " + mqe.HResult);
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", cMensajeError, idUsuario, cDocumentoAutorizado);

                cMensajeError = "";

                if (requestQueue.OpenStatus)
                    requestQueue.Close();

                mqQMgr.Disconnect();
                return false;
            }

        }
        private bool RealizarConsultaCola(string cIdConsultaDirecta, int idFlag)
        {
            /********
             * buscar en la base de datos si se hizo ya una consulta
             * 
             * **************/
            int nIdConsultaDirecta = Convert.ToInt32(cIdConsultaDirecta);
            DataTable dtConsulta;
            if (nIdConsultaDirecta == 0)
            {
                dtConsulta = RegLog.CNBuscarDniEnvioCola(cDocumentoBus);
            }
            else
            {
                dtConsulta = RegLog.CNBuscarDniEnvioColaDirect(cDocumentoBus);
            }

            int nCantidad = Convert.ToInt32(dtConsulta.Rows[0]["nCantidad"].ToString());


            if (idFlag == 0 && nCantidad == 0)
            {

                //Step 4. PUT Request Message in Request Queue. Note the options needed to be set.
                //Note that once PUT is successful, you can close the Request Queue. Note that you are
                //asking whoever receives this request to copy the MSG ID to CORREL ID so that
                //you can later "match" the response you get with the request you sent.
                try
                {

                    requestMessage = new MQMessage();

                    requestMessage.CharacterSet = 819;

                    requestMessage.Format = MQC.MQFMT_NONE;

                    requestMessage.WriteString(strRequestText);


                    requestMessage.MessageType = MQC.MQMT_REQUEST;
                    requestMessage.Report = MQC.MQRO_COPY_MSG_ID_TO_CORREL_ID;
                    requestMessage.ReplyToQueueName = strResponseQueueName;
                    requestMessage.ReplyToQueueManagerName = strQueueManagerName;
                    requestQueue.Put(requestMessage);

                    if (requestQueue.OpenStatus)
                        requestQueue.Close();

                    string MensajeError = (cDocumentoBus + ": Se realizó la solicitud de datos a reniec con éxito.(Paso 4)");
                    DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "9999", MensajeError, idUsuario, cDocumentoAutorizado);
                    idFlagEstado = 1;

                    return true;

                }
                catch (Exception mqe)
                {
                    cMensajeError = ("Paso 4: Error al intentar PONER mensaje en la cola de solicitudes:" + mqe.Message + " , " + mqe.Source + " , " + mqe.TargetSite + " , " + mqe.HelpLink + " , " + mqe.StackTrace + " , " + mqe.TargetSite + " , " + mqe.InnerException + " , " + mqe.HResult);
                    DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", cMensajeError, idUsuario, cDocumentoAutorizado);

                    cMensajeError = "";

                    if (requestQueue.OpenStatus)
                        requestQueue.Close();
                    if (responseQueue.OpenStatus)
                        responseQueue.Close();

                    mqQMgr.Disconnect();
                    return false;
                }
            }
            else
            {
                idFlagEstado = 1;
                return true;
            }
        }
        private bool ObtenerResultadosCola(string cDocumentoAut, int idFlag)
        {
            if (idFlag == 0 || idFlag == 1)
            {
                //Step 5. Read the response from response queue. Note the options to be set.
                //It may happen that you get no response. Also note that you decide how long you wait
                //for the response. In order to get the response, note the "matching" criterion.
                try
                {
                    responseMessage = new MQMessage();
                    responseMessage.CharacterSet = 819;
                    responseMessage.CorrelationId = requestMessage.MessageId;
                    MQGetMessageOptions gmo = new MQGetMessageOptions();
                    gmo.Options = MQC.MQGMO_WAIT;


                    gmo.WaitInterval = 1000;


                    gmo.MatchOptions = MQC.MQRO_COPY_MSG_ID_TO_CORREL_ID;

                    responseQueue.Get(responseMessage, gmo);


                    cRespuesta = Convert.ToString(responseMessage.ReadString(responseMessage.MessageLength));
                    cCadena = cRespuesta;


                    // Registra el trama de Respuesta 
                    string cDniTrama = cRespuesta.Substring(132, 8);

                    convertirFotoFirma(cRespuesta);
                    string cFotoTrama = cFotoF;
                    string cFirmaTrama = cFirmaF;
                    string cCadenaTrama = cRespuesta.Substring(0, 945);

                    DataTable tRegTramaResp = RegLog.CNRegistraTrama(cDocumentoBus, cDniTrama, cCadenaTrama, cFotoTrama, cFirmaTrama, 2);

                    string cErrorDocEncontrado = cRespuesta.Substring(128, 4);
                    string cDocEncontrado = cRespuesta.Substring(132, 8);


                    if (cErrorDocEncontrado == "0000")
                    {
                        // guardar todos los DNI que no sean el buscado
                        convertirFotoFirma(cRespuesta);
                        GuardarDatos(cCadena, cFotoF, cFirmaF, cDocumentoAut);
                    }


                    //busqueda en el log de tramas el dni
                    DataTable tBUsTramaResp = RegLog.CNBuscarDniTrama(cDocumentoBus);

                    if (tBUsTramaResp.Rows.Count > 0)
                    {
                        string cCadenaLogTrama = tBUsTramaResp.Rows[0]["cTrama"].ToString();

                        cCadenaFoto = tBUsTramaResp.Rows[0]["cFotoTrama"].ToString();
                        cCadenaFirma = tBUsTramaResp.Rows[0]["cFirmaTrama"].ToString();

                        cRespuesta = cCadenaLogTrama;
                        cCadena = cRespuesta;

                        cError = cRespuesta.Substring(128, 4);
                        int nError = Convert.ToInt32(cError);
                        cFotoF = cCadenaFoto;
                        cFirmaF = cCadenaFirma;
                        cDni = cRespuesta.Substring(132, 8);

                        DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "cError enviado por Reniec y recogido del Log de tramas Base 1: " + cError, idUsuario, cDocumentoAutorizado);

                    }
                    else
                    {
                        cError = cRespuesta.Substring(128, 4);
                        int nError = Convert.ToInt32(cError);
                        DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "cError enviado por Reniec Base 1: " + cError, idUsuario, cDocumentoAutorizado);

                        if (cError == "0000")
                        {
                            convertirFotoFirma(cCadena);
                        }
                        else
                        {

                            DataTable tRegLog2 = RegLog.CNRegistraLog(cDocumentoBus, cError, "cError enviado por Reniec Base 2: " + cError, idUsuario, cDocumentoAutorizado);
                        }

                    }


                    return true;
                }
                catch (Exception mqe)
                {
                    cMensajeError = ("Paso 5: Error al intentar SACAR mensaje en la cola de solicitudes:" + MQC.MQMO_MATCH_CORREL_ID + "--" + MQC.MQRO_COPY_MSG_ID_TO_CORREL_ID + "--" + mqe.Message + " , " + mqe.Source + " , " + mqe.TargetSite + " , " + mqe.HelpLink + " , " + mqe.StackTrace + " , " + mqe.TargetSite + " , " + mqe.InnerException + " , " + mqe.HResult);
                    DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, "", cMensajeError, idUsuario, cDocumentoAutorizado);

                    cMensajeError = "";

                    if (responseQueue.OpenStatus)
                        responseQueue.Close();

                    mqQMgr.Disconnect();
                    return false;
                }
            }
            return false;
        }


        private void procesar(string cDocumentoBus, string cDocumentoAut, string cCodEmp, int idFlag, string cIdConsultaDirecta)
        {
            cError = "";
            cCadena = "";
            cDni = "";
            cRespuesta = "";
            cCadenaFirma = "";
            cCadenaFoto = "";
            cFotoF = "";
            cFirmaF = "";

            cErrorReniec = "5002, 5003, 5004, 5008, 5009, 5010, 5011, 5020, 5021, 5030, 5031, 5032, 5033, 5034, 5036, 5037, 5100, 5101, 5102, 5103, 5104, 5105, 5108, 5109, 5110, 5111, 5112, 5113, 5114, 5200";
            String[] cArrayErrorReniec;
            int[] nArrayErrorReniec;
            cArrayErrorReniec = cErrorReniec.Split(',');
            nArrayErrorReniec = Array.ConvertAll<string, int>(cArrayErrorReniec, int.Parse);


            strRequestQueueName = "CEN.CAJARUANDES";
            strResponseQueueName = "CRES.CAJARUANDES";
            strQueueManagerName = "RENIECQM";

            cDocumentoAutorizado = cDocumentoAut;
            cCodigoEmp = cCodEmp;
            strRequestText = "00020128000000000158                      0000000002RENIECPERURENIEC" + cCodigoEmp + "    RENIEC001 PUNOPUNOPU" + cDocumentoAutorizado + "  PRODUCCION          " + cDocumentoBus + "123  1                ";

            // Registra el trama de envío
            if (idFlag == 0)
            {
                DataTable tRegTramaEnv = RegLog.CNRegistraTrama(cDocumentoBus, cDocumentoBus, strRequestText, "", "", 1); // Primer Trama
            }
            else if (idFlag == 1)
            {
                DataTable tRegTramaEnv = RegLog.CNRegistraTrama(cDocumentoBus, cDocumentoBus, strRequestText, "", "", 3); // Tramas siguientes
            }


            if (CrearAdmColas() == true && AbrirColaSolicitudes() == true && AbrirColaRespuestas() == true)
            {

                if (RealizarConsultaCola(cIdConsultaDirecta, idFlag))
                {
                    if (ObtenerResultadosCola(cDocumentoAut, idFlag))
                    {
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }

            //Step 6. Close Response Queue, Disconnect Manager. Note that you have already
            //closed the request queue in step 4.
            if (requestQueue.OpenStatus)
                requestQueue.Close();
            if (responseQueue.OpenStatus)
                responseQueue.Close();

            mqQMgr.Disconnect();
            return;

        }
        private void convertirFotoFirma(string cCadena)
        {
            string cCadenaConvert = cCadena;

            cFoto = cCadenaConvert.Substring(895, 9);
            cFirma = cCadenaConvert.Substring(904, 9);
            int nFoto = Convert.ToInt32(cFoto);
            int nFirma = Convert.ToInt32(cFirma);

            try
            {
                if (!String.IsNullOrEmpty(cCadenaFoto) && !String.IsNullOrEmpty(cCadenaFirma))
                {
                    cFotoF = cCadenaFoto;
                    cFirmaF = cCadenaFirma;

                }
                else
                {
                    /*conversorde imagen*/

                    if (responseMessage.Format == MQC.MQFMT_STRING)
                    {
                        responseMessage.DataOffset = 945;
                        byte[] readByte = (byte[])responseMessage.ReadBytes(responseMessage.DataLength - nFirma);
                        cFotoF = Convert.ToBase64String(readByte);

                    }
                    else
                    {

                        DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "Imagen/foto No Cargada", idUsuario, cDocumentoAutorizado);
                    }


                    if (responseMessage.Format == MQC.MQFMT_STRING)
                    {
                        responseMessage.DataOffset = 945 + nFoto;
                        byte[] readByte = (byte[])responseMessage.ReadBytes(responseMessage.DataLength);
                        cFirmaF = Convert.ToBase64String(readByte);

                    }
                    else
                    {

                        DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, "Imagen/firma No Cargada", idUsuario, cDocumentoAutorizado);
                    }
                }
            }
            catch (Exception e)
            {
                string cMensaje = "Try/Catch Convertir Imagen" + e.Message + "," + e.Source + "," + e.StackTrace + "," + e.TargetSite;
                DataTable tRegLog = RegLog.CNRegistraLog(cDocumentoBus, cError, cMensaje, idUsuario, cDocumentoAutorizado);

            }

        }

    }
}
