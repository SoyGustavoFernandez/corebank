using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using System.Net;
using System.IO;

namespace SolIntEls
{
    public partial class frmSolExtorno : frmBase
    {
        public int idMod,idProd,idEstKar, idcli;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();  
        Boolean lEstado = true;
        int idSolAprob = 0;
        string cNombreUsuario = clsVarGlobal.User.cNomUsu;

        public frmSolExtorno()
        {
            InitializeComponent();
        }

        private void frmSolExtorno_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
            cboEstadoSolic1.EstSol(1);
            cboEstadoSolic1.SelectedValue = 1;
        }

        private void lblBase6_Click(object sender, EventArgs e)
        {

        }

        private void txtMonGiro_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarControles()
        {            
            this.txtModulo.Clear();
            this.txtCliente.Clear();
            this.cboMoneda.SelectedIndex = -1;
            this.cboTipoOperacion.SelectedIndex=-1;            
            this.txtMonOpe.Text = "0.00";
            this.cboMotivoExtorno.SelectedIndex = -1;
            this.txtSustento.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            btnGrabar.Enabled = false;
            idMod = 0;
            int idKar = Convert.ToInt32(this.nudNroKardex.Value);
            
            if (string.IsNullOrEmpty(idKar.ToString()))
            {
                MessageBox.Show("Debe Ingresar el número de Operación", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudNroKardex.Select();
                this.nudNroKardex.Focus();
                return;
            }
            if (idKar<=0)
            {
                MessageBox.Show("El número de operación ingresado No Es Válido", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudNroKardex.Select();
                this.nudNroKardex.Focus();
                return;
            }

            clsCNGenAdmOpe dtDatTrx = new clsCNGenAdmOpe();
            DataTable tbTrx = dtDatTrx.RetDatosOperacion(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (Convert.ToInt32(tbTrx.Rows[0]["idRpta"].ToString()) == 0)
            {
                this.txtModulo.Text = tbTrx.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = tbTrx.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = tbTrx.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = tbTrx.Rows[0]["nMontoOperacion"].ToString();
                this.txtCliente.Text = tbTrx.Rows[0]["cNomCliente"].ToString();
                idMod = Convert.ToInt32(tbTrx.Rows[0]["idModulo"].ToString());
                idProd = Convert.ToInt32(tbTrx.Rows[0]["idProducto"].ToString());
                idEstKar = Convert.ToInt32(tbTrx.Rows[0]["idEstadoKardex"].ToString());
                idcli = Convert.ToInt32(tbTrx.Rows[0]["idCliAfeITF"].ToString());
                this.nudNroKardex.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.cboMotivoExtorno.Enabled = true;
                this.txtSustento.Enabled = true;
                this.cboMotivoExtorno.Focus();                
            }
            else if(Convert.ToInt32(tbTrx.Rows[0]["idRpta"].ToString()) == 6)
            {
                DataTable dtOperacionExtorno = dtDatTrx.recuperarOperacionExtorno(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
                clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.In("lstTipoOpeAnular"));
                List<int> lstTipoOpeAnular = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

                if (dtOperacionExtorno.Rows.Count > 0)
                {
                    int idTipoOperacion = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idTipoOperacion"]);
                    idSolAprob = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idSolAproba"]);

                    if (idSolAprob != 0 && lstTipoOpeAnular.Any(item => idTipoOperacion == item))
                    {
                        this.txtModulo.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cModulo"]);
                        this.cboTipoOperacion.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idTipoOperacion"]);
                        this.cboMoneda.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idMoneda"]);
                        this.txtMonOpe.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["nMontoOperacion"]);
                        this.txtCliente.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cNomCliente"]);
                        this.cboMotivoExtorno.SelectedValue = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idMotivo"]);
                        this.txtSustento.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cSustento"]);
                        idMod = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idModulo"]);
                        idProd = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idProducto"]);
                        idEstKar = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idEstadoKardex"]);
                        idcli = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idCliAfeITF"]);
                        this.nudNroKardex.Enabled = false;
                        this.btnAceptar.Enabled = false;
                        this.btnNuevo.Enabled = false;
                        this.btnGrabar.Enabled = false;
                        this.btnCancelar.Enabled = true;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustento.Enabled = false;
                        this.btnAnular.Enabled = true;
                        this.btnAnular.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nudNroKardex.Focus();
                        this.nudNroKardex.Select();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroKardex.Focus();
                    this.nudNroKardex.Select();
                }
            }
            else
            {
                MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                this.nudNroKardex.Select();                
            }
        }       

        private void nudNroKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                this.btnAceptar.PerformClick();
            }            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.nudNroKardex.Enabled = true;
            this.btnAceptar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.cboMotivoExtorno.Enabled = false;
            this.txtSustento.Enabled = false;
            this.nudNroKardex.Value = 0;
            this.nudNroKardex.Focus();
            this.nudNroKardex.Select(0, nudNroKardex.ToString().Length);
            this.btnAnular.Enabled = false;
            this.btnAnular.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.nudNroKardex.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cboMotivoExtorno.Enabled = false;
            this.txtSustento.Enabled = false;
            this.nudNroKardex.Value = 0;
            this.btnAnular.Enabled = false;
            this.btnAnular.Visible = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor Registrar ", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Registrar la Solicitud", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                return;
            }

            if (this.cboMotivoExtorno.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMotivoExtorno.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.cboMotivoExtorno.Text))
            {
                MessageBox.Show("Debe Seleccionar el Motivo del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMotivoExtorno.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                return;
            }            

            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================
            
            int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
            int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
            string cSust = this.txtSustento.Text.Trim();

            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, idcli, Convert.ToInt32(cboTipoOperacion.SelectedValue), 2,
                                                                Convert.ToInt16(cboMoneda.SelectedValue), idProd, Convert.ToDecimal (txtMonOpe.Text),
                                                               Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivoExtorno.SelectedValue),
                                                                txtSustento.Text, 0, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                //MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idSolAprob = Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]);
                this.nudNroKardex.Enabled = false;
                this.btnAceptar.Enabled = true;
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.cboMotivoExtorno.Enabled = false;
                this.txtSustento.Enabled = false;
                if (Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]) == 4)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //ENVIO DE CORREO A APROBADORES
            //EnvioCorreoAprobador(idSolAprob);
            //ENVIO DE SMS A APROBADORES
            //EnvioSMSAprobador(idSolAprob);
            ActualizarEstado();

         
        }
        
        private void ActualizarEstado()
        {
            String cCumpleReglas = "";
            
                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name, clsVarGlobal.nIdAgencia, idcli,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMonOpe.Text), idSolAprob, clsVarGlobal.dFecSystem,
                                                   2, Convert.ToInt32(cboEstadoSolic1.SelectedValue),
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
                if (cCumpleReglas.Equals("Cumple"))
                {
                    int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                    int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                    int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                    Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
                    int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                    string cSust = this.txtSustento.Text.Trim();
                    int idEstSolicitud = 1;

                    clsCNAprobacion dtSolApr = new clsCNAprobacion();
                    DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                    if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nudNroKardex.Enabled = false;
                        this.btnAceptar.Enabled = true;
                        this.btnNuevo.Enabled = true;
                        this.btnGrabar.Enabled = false;
                        this.btnCancelar.Enabled = false;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustento.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


                if (cCumpleReglas.Equals("ExcepcionRechazada"))
                {
                    int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                    int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                    int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                    Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
                    int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                    string cSust = this.txtSustento.Text.Trim();
                    int idEstSolicitud = 4;

                    clsCNAprobacion dtSolApr = new clsCNAprobacion();
                    DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                    if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nudNroKardex.Enabled = false;
                        this.btnAceptar.Enabled = true;
                        this.btnNuevo.Enabled = true;
                        this.btnGrabar.Enabled = false;
                        this.btnCancelar.Enabled = false;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustento.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                
                 }

                DataTable dtConsultaSolApr = ValidaReglasDinamicas.CNConsultaEstExcepExtorno(idSolAprob, idProd, idcli, Convert.ToInt32(this.cboMoneda.SelectedValue.ToString()), 
                                                                                            clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, Decimal.Parse(txtMonOpe.Text));
                if (dtConsultaSolApr.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtConsultaSolApr.Rows[0]["idEstadoSol"].ToString()) == 4)
                    {
                        int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                        int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                        int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                        Decimal nMontoOpe = Convert.ToDecimal (this.txtMonOpe.Text);
                        int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                        string cSust = this.txtSustento.Text.Trim();
                        int idEstSolicitud = 4;

                        clsCNAprobacion dtSolApr = new clsCNAprobacion();
                        DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                        if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                        {
                            this.nudNroKardex.Enabled = false;
                            this.btnAceptar.Enabled = true;
                            this.btnNuevo.Enabled = true;
                            this.btnGrabar.Enabled = false;
                            this.btnCancelar.Enabled = false;
                            this.cboMotivoExtorno.Enabled = false;
                            this.txtSustento.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } 
                }                
                
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();            
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idcli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSol";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);
            
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = cboTipoOperacion.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);
            
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);
          
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            string cOpinionAnulacion = String.Empty;
            bool lValida = false;
            frmAnulaSolAprobacionOpinion frmAnulacion = new frmAnulaSolAprobacionOpinion();
            frmAnulacion.ShowDialog();
            cOpinionAnulacion = frmAnulacion.cComentarioAprobador;
            lValida = frmAnulacion.lValidado;

            if(lValida)
            {
                DialogResult drResultado = MessageBox.Show("¿Está seguro que desea Anular la solicitud de Extorno?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultado == DialogResult.No)
                    return;

                clsCNAprobacion objCNAprobacion = new clsCNAprobacion();
                DataTable dtResultado = objCNAprobacion.CNAnularSolicitudAprobacion(idSolAprob, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, cOpinionAnulacion);

                if(dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAnular.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la Anulación de la Solicitud de Extorno.", "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public Dictionary<string, dynamic> EnviarSMS(double numero, string mensaje)
        {
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

            try
            {
                //DataTable dtVariable = objCNMantenimiento.CNRecuperarVariable("cServicioWCFSms");
                //string cServicio = dtVariable.Rows[0]["cValVar"].ToString();
                string cServicio = "http://172.16.7.150:5000/sms/v1/compatibilidad/";
                string dicto = "{\"phone\":" + numero + ",\"content\":\"" + mensaje + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto); //Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string serviceURL = string.Format(cServicio);
                response = webClient.UploadData(serviceURL, "POST", bBytes);
               // Stream stream = new MemoryStream(response);
                //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                //obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                //var resService = obj.ReadObject(stream) as clsResponseSMS;

                //if (resService.idRespuesta == 1)
                //{
                //    res.Add("cEstado", "success");
                //}
                //else
                //{
                //    res.Add("cEstado", "failed");
                //    res.Add("cFail", resService.cMensaje);
                //}
            }
            catch (Exception e)
            {
                res.Add("cEstado", "failed");
                res.Add("cFail", e.ToString());
            }

            return res;
        }

        private void EnvioCorreoAprobador(int idSolAprob)
        {
            string cPerfil=string.Empty;
            string cCuerpo=string.Empty;
            string cAsunto=string.Empty;

            cPerfil = "NotificacionExtorno";
            cCuerpo = "EL RSC " + cNombreUsuario + " ESTA SOLICITANDO LA APROBACIÓN DE UN EXTORNO DE DESEMBOLSO, VERIFICAR INGRESANDO A SU BANDEJA DE APROBACION";
            cAsunto = "SOLICITUD DE APROBACIÓN DE EXTORNO";
            DataTable dtAprobadorCorreo = new DataTable();
            clsCNAprobacion objCNprobacion = new clsCNAprobacion();
            dtAprobadorCorreo = objCNprobacion.CNListarCorreoAprobaSol(idSolAprob, clsVarGlobal.nIdAgencia);
            foreach(DataRow fila in dtAprobadorCorreo.Rows)
            {
                string cCorreo=Convert.ToString(fila["cEmailInst"]);
                if(!string.IsNullOrEmpty(cCorreo))
                {
                    objCNprobacion.CNEnviarCorreoAprobador(cPerfil, cCorreo, cCuerpo, cAsunto);
                }
            }

        }

        private void EnvioSMSAprobador(int idSolAprob)
        {
            DataTable dtAprobadorSMS = new DataTable();
            clsCNAprobacion objCNprobacion = new clsCNAprobacion();
            dtAprobadorSMS = objCNprobacion.CNListarCelularAprobaSol(idSolAprob, clsVarGlobal.nIdAgencia);
            string cMensaje = string.Empty;
            cMensaje = "EL RSC " + cNombreUsuario + " ESTA SOLICITANDO LA APROBACIÓN DE UN EXTORNO DE DESEMBOLSO, VERIFICAR INGRESANDO A SU BANDEJA DE APROBACION";
            foreach (DataRow fila in dtAprobadorSMS.Rows)
            {
                string cCelular = Convert.ToString(fila["cCelular"]);
                if (!string.IsNullOrEmpty(cCelular))
                {
                    EnviarSMS(Convert.ToDouble(cCelular), cMensaje);
                }
            }
        }

    }
}
