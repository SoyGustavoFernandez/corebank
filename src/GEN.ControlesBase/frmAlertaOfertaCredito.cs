using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using EntityLayer;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmAlertaOfertaCredito : frmBase
    {
        #region Variables Globales
        private string cKey = "8501a188afb9896c27f3c245429b583143556a9a93194c3773d588ca9166c8a21997e5cffe945863d04bffde6ede43001d077936a446ba53bbad08656bd23561";
        private string cUrlCredirap = "";
        private string cUrlSMS = "";
        private string cDocumentoID = "";
        private clsOfertaCredirap objOfertaCredirap;
        private List<clsClienteOfertas> lstClienteOfertas;
        private List<clsClienteOfertas> lstClienteOfertasSMS;
        private List<clsClienteOfertas> lstClienteOfertasCredirap;
        private bool lValidaCredirappPro = true;
        public class clsWebClient : WebClient
        {
            public int nTimeout { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                request.Timeout = this.nTimeout;
                return request;
            }
        }
        #endregion

        #region Metodos
        public frmAlertaOfertaCredito()
        {
            this.InitializeComponent();
        }

        public frmAlertaOfertaCredito(string cDocumento)
        {
            this.InitializeComponent();
            this.cDocumentoID = cDocumento;
            this.iniciarFormulario();
        }

        private void iniciarFormulario()
        {
            this.lstClienteOfertas = new List<clsClienteOfertas>();
            this.lstClienteOfertasSMS = new List<clsClienteOfertas>();
            this.lstClienteOfertasCredirap = new List<clsClienteOfertas>();
            this.dsClienteOfertas.DataSource = this.lstClienteOfertas;
            DataGridViewColumn colMensaje = this.dtgOferta.Columns["cMensaje"];
            colMensaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colMensaje.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgOferta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgOferta.DefaultCellStyle.SelectionBackColor = this.dtgOferta.DefaultCellStyle.BackColor;
            this.dtgOferta.DefaultCellStyle.SelectionForeColor= this.dtgOferta.DefaultCellStyle.ForeColor;
            this.dtgOferta.ColumnHeadersVisible = false;

            if (this.consultarBusqueda())
            {
                return;
            }
            if (!this.cargarOfertasCredirapp())
            {
                if (!this.cargarOfertasCredirappPro())
                {
                    return;
                }
                lValidaCredirappPro = false;
            }
            if(lValidaCredirappPro == true)
            {
                if (!this.cargarOfertasCredirappPro())
                {
                    return;
                }
            }

            this.lstClienteOfertas.Clear();
            this.lstClienteOfertas.AddRange(this.lstClienteOfertasCredirap.FindAll(x => x.idPerfil.In(220)));
            this.dsClienteOfertas.ResetBindings(true);
            this.dtgOferta.Refresh();

            if (this.dsClienteOfertas.Count > 0)
            {
                this.registrarBusqueda();
                this.ShowDialog();
            }
            else
            {
                this.lstClienteOfertas.Clear();
                this.lstClienteOfertas.AddRange(this.lstClienteOfertasCredirap.FindAll(x => x.idPerfil.In(34)));
                this.dsClienteOfertas.ResetBindings(true);
                this.dtgOferta.Refresh();
                if (this.dsClienteOfertas.Count > 0)
                {
                    this.registrarBusqueda();
                    this.armarEnvioSMS();
                    this.ShowDialog();
                }
            }
        }

        private bool cargarOfertasCredirappPro()
        {
            try
            {
                List<clsClienteOfertaCredirapPro> objOfertaCredirapPro = new List<clsClienteOfertaCredirapPro>();
                ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
                objOfertaCredirapPro = objCE.CNObtenerOfertaCredirapPro(this.cDocumentoID);

                if (objOfertaCredirapPro.Count() > 0)
                {
                    foreach (clsClienteOfertaCredirapPro objOferta in objOfertaCredirapPro)
                    {
                        clsClienteOfertas objTmp = new clsClienteOfertas();
                        string cMensaje;
                        string cMensajeSMS;
                        string cDescripcion;

                        switch (objOferta.idTipoGrupoCamp)
                        {
                            case 1:
                                cDescripcion = "PRE APROBADO";
                                break;
                            case 2:
                                cDescripcion = "APROBADO";
                                break;
                            default:
                                cDescripcion = "";
                                break;
                        }

                        switch (objOferta.idPerfil)
                        {
                            case 220:
                                if (objOferta.idProducto == 1848)
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI. Oferta válida para el Representante de Servicio al Cliente por CREDIRAPP PRO.";
                                }
                                else if (objOferta.idProducto == 1849)
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta válida para el Representante de Servicio al Cliente por CREDIRAPP PRO.";
                                }
                                else
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ". Oferta válida para el Representante de Servicio al Cliente por CREDIRAPP PRO.";
                                }
                                cMensajeSMS = "";
                                break;

                            case 34:
                                if (objOferta.idProducto == 1848)
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI. Oferta válida para el Asesor de Negocios por CREDIRAPP PRO.";
                                    cMensajeSMS = "El cliente " + objOferta.cNombre.ToUpper() + " con " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI. Oferta valida por CREDIRAPP PRO.";
                                }
                                else if (objOferta.idProducto == 1849)
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta válida para el Asesor de Negocios por CREDIRAPP PRO.";
                                    cMensajeSMS = "El cliente " + objOferta.cNombre.ToUpper() + " con " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta valida por CREDIRAPP PRO.";
                                }
                                else
                                {
                                    cMensaje = "El " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ". Oferta válida para el Asesor de Negocios por CREDIRAPP PRO.";
                                    cMensajeSMS = "El cliente " + objOferta.cNombre.ToUpper() + " con " + objOferta.cNomCorto.ToUpper() + " " + objOferta.cDocumentoID +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.nMontoOferta) + ". Oferta valida por CREDIRAPP PRO.";
                                }
                                break;
                            default:
                                cMensaje = "";
                                cMensajeSMS = "";
                                break;
                        }

                        objTmp.idCli = objOferta.idCli;
                        objTmp.cTipoDocumento = objOferta.cNomCorto;
                        objTmp.cDocumentoID = objOferta.cDocumentoID;
                        objTmp.cNombre = objOferta.cNombre;
                        objTmp.idEstablecimiento = objOferta.idEstablecimiento;
                        objTmp.idAsesor = objOferta.idUsuario;

                        objTmp.idProducto = objOferta.idProducto;
                        objTmp.cMoneda = objOferta.cMoneda;
                        objTmp.nCuotas = objOferta.nPlazo;
                        objTmp.nMonto = objOferta.nMontoOferta;
                        objTmp.nTaza = objOferta.nTasa;
                        objTmp.idPerfil = objOferta.idPerfil;
                        objTmp.idTipoGrupoCamp = objOferta.idTipoGrupoCamp;

                        objTmp.cMensaje = cMensaje;
                        objTmp.cMensajeSMS = cMensajeSMS;

                        this.lstClienteOfertasCredirap.Add(objTmp);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el servicio de CREDIRAPP PRO.\nPuede continuar con normalidad.", "Consulta CREDIRAPP PRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool cargarOfertasCredirapp()
        {
            clsVarGen objUrlCredirap = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cUrlCredirap"));
            this.cUrlCredirap = Convert.ToString(objUrlCredirap.cValVar) + "/cliente";

            string cJSON = "{\"documento_id\":\"" + this.cDocumentoID + "\",\"key\":\"" + this.cKey + "\"}";
            byte[] bEnvioDatos = Encoding.ASCII.GetBytes(cJSON);
            byte[] bRespuesta;

            clsWebClient objWebClient = new clsWebClient();
            objWebClient.nTimeout = 10000;
            objWebClient.Headers["Content-type"] = "application/json";
            objWebClient.Encoding = Encoding.UTF8;

            try
            {
                bRespuesta = objWebClient.UploadData(this.cUrlCredirap, "POST", bEnvioDatos);
                Stream stream = new MemoryStream(bRespuesta);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsOfertaCredirap));
                clsOfertaCredirap resultOferta = obj.ReadObject(stream) as clsOfertaCredirap;
                this.objOfertaCredirap = resultOferta;

                if (this.objOfertaCredirap == null || this.objOfertaCredirap.message != null)
                {
                    return false;
                }
                else if (this.objOfertaCredirap.cliente.Count() > 0 && this.objOfertaCredirap.propuestas.Count() > 0)
                {
                    foreach (clsOferta objOferta in this.objOfertaCredirap.propuestas)
                    {
                        clsClienteOfertas objTmp = new clsClienteOfertas();
                        string cMensaje;
                        string cMensajeSMS;
                        string cDescripcion;

                        switch (objOferta.tipo_grupo_campania)
                        {
                            case 1:
                                cDescripcion = "PRE APROBADO";
                                break;
                            case 2:
                                cDescripcion = "APROBADO";
                                break;
                            default:
                                cDescripcion = "";
                                break;
                        }

                        switch (objOferta.perfil_id)
                        {
                            case 220:
                                if (objOferta.producto == 1848)
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI. Oferta válida para el Representante de Servicio al Cliente por Credirapp Plus.";
                                }
                                else if (objOferta.producto == 1849)
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta válida para el Representante de Servicio al Cliente por Credirapp Plus.";
                                }
                                else
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ". Oferta válida para el Representante de Servicio al Cliente por Credirapp Plus.";
                                }
                                cMensajeSMS = "";
                                break;

                            case 34:
                                if (objOferta.producto == 1848)
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI. Oferta válida para el Asesor de Negocios por Credirapp Plus.";
                                    cMensajeSMS = "El cliente " + this.objOfertaCredirap.cliente[0].nombre.ToUpper() + " con " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI. Oferta valida por Credirapp Plus.";
                                }
                                else if (objOferta.producto == 1849)
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta válida para el Asesor de Negocios por Credirapp Plus.";
                                    cMensajeSMS = "El cliente " + this.objOfertaCredirap.cliente[0].nombre.ToUpper() + " con " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ", solo con DNI y RECIBO DE SERVICIOS. Oferta valida por Credirapp Plus.";
                                }
                                else
                                {
                                    cMensaje = "El " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ". Oferta válida para el Asesor de Negocios por Credirapp Plus.";
                                    cMensajeSMS = "El cliente " + this.objOfertaCredirap.cliente[0].nombre.ToUpper() + " con " + this.objOfertaCredirap.cliente[0].documento_tipo.ToUpper() + " " + this.objOfertaCredirap.cliente[0].documento_id +
                                        " se acerco a ventanilla hoy a las " + DateTime.Now.ToString("hh:mm tt") + " y tiene un monto " + cDescripcion + " de S/ " + Convert.ToInt32(objOferta.monto) + ". Oferta valida por Credirapp Plus.";
                                }
                                break;
                            default:
                                cMensaje = "";
                                cMensajeSMS = "";
                                break;
                        }

                        objTmp.idCli = this.objOfertaCredirap.cliente[0].corebank_id;
                        objTmp.cTipoDocumento = this.objOfertaCredirap.cliente[0].documento_tipo;
                        objTmp.cDocumentoID = this.objOfertaCredirap.cliente[0].documento_id;
                        objTmp.cNombre = this.objOfertaCredirap.cliente[0].nombre;
                        objTmp.idEstablecimiento = this.objOfertaCredirap.cliente[0].establecimiento_id;
                        objTmp.idAsesor = this.objOfertaCredirap.cliente[0].asesor_id;

                        objTmp.idProducto = objOferta.producto;
                        objTmp.cMoneda = objOferta.moneda;
                        objTmp.nCuotas = objOferta.cuotas;
                        objTmp.nMonto = objOferta.monto;
                        objTmp.nTaza = objOferta.tasa_interes;
                        objTmp.idPerfil = objOferta.perfil_id;
                        objTmp.idTipoGrupoCamp = objOferta.tipo_grupo_campania;

                        objTmp.cMensaje = cMensaje;
                        objTmp.cMensajeSMS = cMensajeSMS;

                        this.lstClienteOfertasCredirap.Add(objTmp);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el servicio de Credirapp Plus.\nPuede continuar con normalidad.", "Consulta al servicio Credirapp Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool enviarMensajeSMS(string cNumero, string cMensaje)
        {
            clsVarGen objUrlCredirap = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cServicioSMSInfobip"));
            this.cUrlSMS = Convert.ToString(objUrlCredirap.cValVar);

            string cJSON = "{\"phone\":\"" + cNumero + "\",\"content\":\"" + cMensaje + "\"}";
            byte[] bEnvioDatos = Encoding.UTF8.GetBytes(cJSON);
            byte[] bRespuesta;

            clsWebClient objWebClient = new clsWebClient();
            objWebClient.nTimeout = 10000;
            objWebClient.Headers["Content-type"] = "application/json";
            objWebClient.Encoding = Encoding.UTF8;

            try
            {
                bRespuesta = objWebClient.UploadData(this.cUrlSMS, "POST", bEnvioDatos);
                Stream stream = new MemoryStream(bRespuesta);
                return true;
            }
            catch (Exception e)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => MessageBox.Show("Error en el servicio de mensajería SMS, mensaje no enviado.\nPuede continuar con normalidad.", "Envió mensaje SMS", MessageBoxButtons.OK, MessageBoxIcon.Information)));
                }
                else
                {
                    MessageBox.Show("Error en el servicio de mensajería SMS, mensaje no enviado.\nPuede continuar con normalidad.", "Envió mensaje SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
        }

        private void armarEnvioSMS()
        {
            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lEnvioSMSOfertas"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (!lAlerta)
            {
                return;
            }
            this.lstClienteOfertasSMS.AddRange(this.lstClienteOfertasCredirap.FindAll(x => x.idPerfil.In(34)));
            foreach (clsClienteOfertas objOferta in this.lstClienteOfertasSMS)
            {
                ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
                DataTable objAsesorAsignado = objCE.CNAsesorAsignado(objOferta.idCli, objOferta.idEstablecimiento);
                if (objAsesorAsignado.Rows.Count > 0)
                {
                    Thread objTareaSMS = new Thread(() => this.enviarMensajeSMS(objAsesorAsignado.Rows[0]["cCelular"].ToString().Trim(), objOferta.cMensajeSMS));
                    objTareaSMS.Start();
                }
            }
        }

        private void registrarBusqueda()
        {
            ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
            objCE.CNRegistarBusqueda(this.cDocumentoID);
        }

        private bool consultarBusqueda()
        {
            int nPopUpDia = Convert.ToInt32(clsVarApl.dicVarGen["nPopUpDia"]);
            ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
            DataTable dtRespuesta = objCE.CNConsultarBusqueda(this.cDocumentoID);
            if (dtRespuesta.Rows.Count >= nPopUpDia)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Eventos
        #endregion
    }
}
