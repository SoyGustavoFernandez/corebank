using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;

namespace CLI.Servicio
{
    public class clsBiometrico
    {
        String cUrlMatch;
        String cUrlBiometric;
        String cDNIusuario;
        String cDNIPersona;
        String cIPAutorizado;
        String cMacAddressAutorizado;
        String cRuta;
        String cHuella;
        public bool lColaborador { get; set; }
        public List<clsBiometriaExcep> lstBiometriaExcepcion { get; set; }

        public clsBiometrico()
        {
            this.cUrlMatch = "http://10.5.5.70:8090/match";
            this.cUrlBiometric = "http://10.5.5.70:8090/suggestedbiometries";
            this.cDNIusuario = "42155044";
            this.cDNIPersona = "70162552";
            this.cIPAutorizado = "172.25.162.50";
            this.cMacAddressAutorizado = "74-D0-2B-22-88-77";
            this.cRuta = Directory.GetCurrentDirectory() + "\\biometrico\\";
            this.cHuella = "2";
            lstBiometriaExcepcion = new List<clsBiometriaExcep>();
        }

        private void clsBiometricoCargaParametros(String _cUrlMatch, String _cUrlBiometric, String _cDNIusuario, String _cIPAutorizado, String _cMacAddressAutorizado)
        {
            this.cUrlMatch = _cUrlMatch;
            this.cUrlBiometric = _cUrlBiometric;
            this.cDNIusuario = _cDNIusuario;
            this.cIPAutorizado = "172.25.162.50";
            this.cMacAddressAutorizado = "74-D0-2B-22-88-77";
            this.cRuta = Directory.GetCurrentDirectory() + "\\biometrico\\";
            this.cHuella = "2";
            //this.cRuta = _cRuta;
            //this.cHuella = _cHuella;
            lstBiometriaExcepcion = new List<clsBiometriaExcep>();
        }

        public void autorizarUsoHuellasDactilares()
        { 

        }

        public void setDNIPersona(String cDNI)
        {
            this.cDNIPersona = cDNI;
        }

        public bool validarHuellaDactilar(string cNombres = "") 
        {

            MessageBox.Show("A continuación se procederá con la validación de la huella del " + ((lColaborador) ? "colaborador" : "cliente") + " : " + cNombres,
                        "Identificación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = cRuta + "devices.api-0.1.exe";
            p.StartInfo.Arguments = cUrlMatch + " -v " + cDNIusuario
            + " " + cDNIPersona + " " + cIPAutorizado + " " + cMacAddressAutorizado + " " + cRuta + "futronic\\devices.fp.futronic-0.1.exe"
            + " " + cHuella + " " + cUrlBiometric;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                return true; //MessageBox.Show("corresponde");
            }
            else if (p.ExitCode == 1)
            {
                return false; //MessageBox.Show("no corresponde");
            }
            else
            {
                return false; //MessageBox.Show("error " + p.ExitCode);
            }
            
        }

        public clsResponseSMS validarHuella(string cDocumentoID, int idCli, string cNombres, int idMoneda, decimal nMontoOperacion, int idProducto, int idTipoOperacion)//, Form fr)
        {
            clsCNAprobacion oApro = new clsCNAprobacion();
            int idEstado = 0;
            int idSolAproba = 0;

            DataTable dt = oApro.ConsultarSolicitudExcepBiometria(cDocumentoID, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, idCli,  clsVarGlobal.dFecSystem, idTipoOperacion);

            if (dt.Rows.Count != 0)
            {
                idEstado = Convert.ToInt32(dt.Rows[0]["idEstadoSol"]);
                idSolAproba = Convert.ToInt32(dt.Rows[0]["idSolAproba"]);

                if (idEstado == 2)
                {
                    if (nMontoOperacion > Convert.ToDecimal(dt.Rows[0]["nValAproba"]))
                    {
                        DialogResult oRes = MessageBox.Show("La solicitud de Excepción se ha Aprobado para el monto como máximo de " + Convert.ToDecimal(dt.Rows[0]["nValAproba"]).ToString("N2") + ", por lo cual se tendrá que pasar nuevamente por el control biométrico. ¿Esta seguro de continuar?", "Identificación Biométrica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (oRes == DialogResult.Yes)
                        {
                            DataTable dtE = oApro.EjecutarSolicitudExcepBiometria(Convert.ToInt32(dt.Rows[0]["idSolAproba"]), Convert.ToInt32(dt.Rows[0]["idBiometriaExcep"]), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                            if (Convert.ToInt32(dtE.Rows[0]["nResultado"]) != 1)
                            {
                                return new clsResponseSMS(0, "Ha ocurrido un error al ejecutar la excepción. \n Intente nuevamente");
                            }
                        }
                        else
                        {
                            return new clsResponseSMS(0, "Aun no se ha ejecutado la excepción solicitada. \nIntente nuevamente");
                        }
                    }
                    else
                    {
                        DataTable dtE = oApro.EjecutarSolicitudExcepBiometria(Convert.ToInt32(dt.Rows[0]["idSolAproba"]), Convert.ToInt32(dt.Rows[0]["idBiometriaExcep"]), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                        if (Convert.ToInt32(dtE.Rows[0]["nResultado"]) == 1)
                        {
                            lstBiometriaExcepcion = lstBiometriaExcepcion.Select(item => { item.idEstadoSolicitud = (item.cDocumentoID == cDocumentoID) ? 2 : item.idEstadoSolicitud; item.idBiometriaExcep = (item.cDocumentoID == cDocumentoID) ? Convert.ToInt32(dt.Rows[0]["idBiometriaExcep"]) : item.idBiometriaExcep; return item; }).ToList();

                            return new clsResponseSMS(1, "Se ha aprobado y ejecutado la excepción para: " + cNombres);
                        }
                        else
                        {
                            return new clsResponseSMS(0, "Ha ocurrido un error al ejecutar la excepción. \n Intente nuevamente");
                        }
                    }
                }
                else if(idEstado == 1)
                {
                    string cMensaje = "Se tiene una solicitud de excepción biométrica pendiente de aprobación para: " + cNombres;
                    cMensaje = (idSolAproba != 0) ? "Se tiene la solicitud de excepción biométrica Nro. " + Convert.ToString(idSolAproba) +" pendiente de aprobación para: " + cNombres : cMensaje ;
                    return new clsResponseSMS(0, cMensaje); 
                }
                else if(idEstado == 4)
                {
                    
                    DataTable dtE = oApro.EjecutarSolicitudExcepBiometria(Convert.ToInt32(dt.Rows[0]["idSolAproba"]), Convert.ToInt32(dt.Rows[0]["idBiometriaExcep"]), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                    if (Convert.ToInt32(dtE.Rows[0]["nResultado"]) != 1)
                    {
                        return new clsResponseSMS(0, "Ha ocurrido un error al ejecutar la excepción. \n Intente nuevamente");
                    }
                    MessageBox.Show("La solicitud de excepción de " + cNombres+ " fue rechazada, se realizará nuevamente el control biométrico", "Identificación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            bool lBool = false;
            int nIntentos = 0;
            while (!lBool && nIntentos< Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                this.cDNIPersona = cDocumentoID;
                lBool = this.validarHuellaDactilar(cNombres);
                nIntentos++;
                if (!lBool)
                {
                    DialogResult oRes = MessageBox.Show(
                                             "Su huella digital no ha sido identificada por RENIEC. \n ¿Desea reintentar?"
                                            , "Identificación Biométrica"
                                            , MessageBoxButtons.RetryCancel
                                            , MessageBoxIcon.Warning);
                    if (oRes != DialogResult.Retry)
                    {
                        break;
                    }

                }
            }
            if (lBool)
            {
                return new clsResponseSMS(1, "Identificación Exitosa");
            }
            else if (nIntentos >= Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                if(lColaborador)
                {
                    return new clsResponseSMS(0, "No se logro autenticar al colaborador.");
                }

                DialogResult oRes2 = MessageBox.Show( 
                                             "Su huella digital no ha sido identificada por RENIEC, por " + Convert.ToString(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) + " " + ((Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) == 1) ? "vez" : "veces")  + ". \n ¿Desea solicitar una excepción para continuar con la operación?"
                                            , "Identificación Biométrica"
                                            , MessageBoxButtons.YesNo
                                            , MessageBoxIcon.Warning);
                if (oRes2 == DialogResult.Yes)
                {
                    frmMensajeSustento oMen = new frmMensajeSustento();
                    oMen.idTipoOperacion = idTipoOperacion;
                    oMen.nMontoOperacion = nMontoOperacion;
                    oMen.cDocumentoID = cDocumentoID;
                    oMen.iniciarMensaje(oApro.CNListarMotivoExcepBiometrica());
                    oMen.idMoneda = idMoneda;
                    oMen.ShowDialog();

                    if (oMen.obtenerAceptacion())
                    {
                        DataTable dt2 = oApro.RegistrarSolicitudExcepBiometria(0, "MOTIVO DE EXCEPCIÓN: " + oMen.getMotivo() + "\n " + oMen.getMensaje(), cDocumentoID, 1
                            , oMen.getIdMotivo()
                            , oMen.getNombreArchivo()
                            , oMen.getExtencion()
                            , oMen.getArchivo()
                            , oMen.obtenerTipoArchivo()
                            , oMen.obtenerXMLUsuariosVerificadores()
                            , oMen.obtenerDerivacionDirecta()
                            , clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.dFecSystem, true, clsVarGlobal.nIdAgencia, idCli, idTipoOperacion, idMoneda, nMontoOperacion, idProducto);
                        if (dt2.Rows.Count != 0)
                        {
                            return new clsResponseSMS(0, Convert.ToString(dt2.Rows[0]["cMensaje"]));
                        }
                        else
                        {
                            return new clsResponseSMS(0, "No se ha podido registrar la solicitud de excepción biométrica");
                        }
                    }
                }
            }
            else {
                return new clsResponseSMS(0, "No se ha podido verificar la huella del " + ((lColaborador) ? "colaborador" : "cliente") + ".");    
            }

            return new clsResponseSMS(0, "No se ha podido verificar la huella del " + ((lColaborador) ? "colaborador" : "cliente") + ".");

        }

        public clsResponseSMS validarHuellaPagoGiro(string cDocumentoID, string cNombres)
        {
            clsCNAprobacion oApro = new clsCNAprobacion();

            bool lBool = false;
            int nIntentos = 0;
            while (!lBool && nIntentos < Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                this.cDNIPersona = cDocumentoID;
                lBool = this.validarHuellaDactilar(cNombres);
                nIntentos++;
                if (!lBool)
                {
                    DialogResult oRes = MessageBox.Show(
                                             "Su huella digital no ha sido identificada por RENIEC. \n ¿Desea reintentar?"
                                            , "Identificación Biométrica"
                                            , MessageBoxButtons.RetryCancel
                                            , MessageBoxIcon.Warning);
                    if (oRes != DialogResult.Retry)
                    {
                        break;
                    }

                }
            }
            if (lBool)
            {
                return new clsResponseSMS(1, "Identificación Exitosa");
            }
            else if (nIntentos >= Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                string cMensaje = " Huella digital no ha sido identificada por RENIEC, por " + Convert.ToString(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) + " " + ((Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) == 1) ? "vez de " : "veces de ");
                return new clsResponseSMS(0, cMensaje);

            }
            else
            {
                return new clsResponseSMS(0, "No se ha podido verificar la huella de la persona " + cNombres);
            }
        }

        public clsResponseSMS validarHuellaAutorizacion(string cDocumentoID, int idCli, string cNombres, int idMoneda, decimal nMontoOperacion, int idProducto, int idTipoOperacion)//, Form fr)
        {
            clsCNAprobacion oApro = new clsCNAprobacion();

            bool lBool = false;
            int nIntentos = 0;
            while (!lBool && nIntentos < Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                this.cDNIPersona = cDocumentoID;
                lBool = this.validarHuellaDactilar(cNombres);
                nIntentos++;
                if (!lBool)
                {
                    DialogResult oRes = MessageBox.Show(
                                             "Su huella digital no ha sido identificada por RENIEC. \n ¿Desea reintentar?"
                                            , "Identificación Biométrica"
                                            , MessageBoxButtons.RetryCancel
                                            , MessageBoxIcon.Warning);
                    if (oRes != DialogResult.Retry)
                    {
                        break;
                    }

                }
            }
            if (lBool)
            {
                return new clsResponseSMS(1, "Identificación Exitosa");
            }
            else if (nIntentos >= Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]))
            {
                string cMensaje = " Huella digital no ha sido identificada por RENIEC, por " + Convert.ToString(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) + " " + ((Convert.ToInt32(clsVarApl.dicVarGen["nIntentoOpeBiometrico"]) == 1) ? "vez de " : "veces de ");
                return new clsResponseSMS(0, cMensaje);

            }
            else
            {
                return new clsResponseSMS(0, "No se ha podido verificar la huella del " + ((lColaborador) ? "colaborador" : "cliente") + " ");
            }

            return new clsResponseSMS(0, "No se ha podido verificar la huella del " + ((lColaborador) ? "colaborador" : "cliente") + " ");

        }


        public bool validacionBiometrica(EnumerableRowCollection<DataRow> lstTitulares, int idMoneda, int idProducto, decimal nMontoEnt, int idTipoOperacion)
        {
            #region Huellas
            if(!File.Exists(cRuta + "devices.api-0.1.exe"))
            {
                MessageBox.Show("No se encontró los archivos para el uso del huellero. Consulte con el area de soporte.", "Identificación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
                
            // Validar el tipo de operacion en efectivo. y validar las firmas 
            clsFunUtiles objFuncion = new clsFunUtiles();
            this.clsBiometricoCargaParametros(
                Convert.ToString(clsVarApl.dicVarGen["cUrlBiometricoMatch"])
                , Convert.ToString(clsVarApl.dicVarGen["cUrlBiometrico"])
                , "42155044" // jose sandoval se registra por defecto
                , objFuncion.GetMacAddress()
                , objFuncion.obtenerMac());

            lstBiometriaExcepcion.Clear();
            lstBiometriaExcepcion = lstTitulares.Select(item => new clsBiometriaExcep   {
                                                                                            idBiometriaExcep = 0,
                                                                                            cDocumentoID = item.Field<string>("cDocumentoID"),
                                                                                            idCli = item.Field<int>("idCli"),
                                                                                            idEstadoSolicitud = 0,
                                                                                            idKardexOperacion = 0
                                                                                        }).ToList();

            int nTotalFirmasReq = 0;
            int nTotalHuellasValidadas = 0;
            foreach (var titular in lstTitulares)
            {
                if (titular.Field<bool>("isReqFirma"))
                {
                    nTotalFirmasReq++;
                    clsResponseSMS oRes = this.validarHuella(
                        titular.Field<string>("cDocumentoID")
                        , titular.Field<int>("idCli")
                        , titular.Field<string>("cNombre")
                        , idMoneda
                        , nMontoEnt
                        , idProducto
                        , idTipoOperacion
                    );
                    MessageBox.Show(oRes.cMensaje, "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (oRes.idRespuesta == 1)
                    {
                        nTotalHuellasValidadas++;
                    }
                }

            }

            if (nTotalFirmasReq != nTotalHuellasValidadas)
            {
                MessageBox.Show("No se ha identificado la totalidad del/los interviniente(s)", "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
            #endregion
        }
        public bool validacionBiometricaAutorizacion(EnumerableRowCollection<DataRow> lstTitulares, int idMoneda, int idProducto, decimal nMontoEnt, int idTipoOperacion, ref string cMensaje)
        {
            #region Huellas
            if (!File.Exists(cRuta + "devices.api-0.1.exe"))
            {
                cMensaje = "No se encontró los archivos para el uso del huellero. Consulte con el área de soporte.";
                return false;
            }

            // Validar el tipo de operacion en efectivo. y validar las firmas 
            clsFunUtiles objFuncion = new clsFunUtiles();
            this.clsBiometricoCargaParametros(
                Convert.ToString(clsVarApl.dicVarGen["cUrlBiometricoMatch"])
                , Convert.ToString(clsVarApl.dicVarGen["cUrlBiometrico"])
                , "42155044" // jose sandoval se registra por defecto
                , objFuncion.GetMacAddress()
                , objFuncion.obtenerMac());

            lstBiometriaExcepcion.Clear();
            lstBiometriaExcepcion = lstTitulares.Select(item => new clsBiometriaExcep
            {
                idBiometriaExcep = 0,
                cDocumentoID = item.Field<string>("cDocumentoID"),
                idCli = item.Field<int>("idCli"),
                idEstadoSolicitud = 0,
                idKardexOperacion = 0
            }).ToList();

            int nTotalFirmasReq = 0;
            int nTotalHuellasValidadas = 0;
            foreach (var titular in lstTitulares)
            {
                if (titular.Field<bool>("isReqFirma"))
                {
                    nTotalFirmasReq++;
                    clsResponseSMS oRes = this.validarHuellaAutorizacion(
                        titular.Field<string>("cDocumentoID")
                        , titular.Field<int>("idCli")
                        , titular.Field<string>("cNombre")
                        , idMoneda
                        , nMontoEnt
                        , idProducto
                        , idTipoOperacion
                    );
                    if (oRes.idRespuesta == 1)
                    {
                        MessageBox.Show(oRes.cMensaje, "Validación Biométrica.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nTotalHuellasValidadas++;
                    }
                    else
                    {
                        cMensaje = cMensaje + "\n" + oRes.cMensaje + titular.Field<string>("cNombre") + ".";
                    }
                }

            }

            if (nTotalFirmasReq != nTotalHuellasValidadas)
            {
                if (nTotalFirmasReq > 1)
                {
                    cMensaje = cMensaje + "\n No se ha identificado la totalidad de los intervinientes.";
                }
                return false;
            }

            return true;
            #endregion
        }
        public void registrarOperacionKardexExcepcion(int idOperacion)
        {
            clsCNAprobacion oApro = new clsCNAprobacion();

            if(!lstBiometriaExcepcion.Any(item => item.idBiometriaExcep != 0))
            {
                return;
            }

            List<clsBiometriaExcep> lstBioExcepcion = lstBiometriaExcepcion.Select(item => { item.idKardexOperacion = idOperacion; return item;  }).ToList();
            string xmlBiometriaExcepcion = lstBioExcepcion.GetXml();

            DataTable dtResultado =  oApro.CNRegistrarOperacionKardexBioExcepcion(xmlBiometriaExcepcion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

            if(dtResultado.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != 0)
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error durante la vinculación del número de operación las solicitudes de excepción.", "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
