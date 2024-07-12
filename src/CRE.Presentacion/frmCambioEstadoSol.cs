using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmCambioEstadoSol : frmBase
    {
        #region Variables Globales

        DataTable Sol = new DataTable("dtSolicitud");
        int nCodPro = 1, nCodEst = 0, idCliente = 0,idAgencia = clsVarGlobal.nIdAgencia;
        bool lEstado = true, lValGarantia = false;
        decimal nMontoSolicitado = 0;
        char Transaccion = Convert.ToChar("I");
        public int idEstadoSol = 0;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        #endregion

        public frmCambioEstadoSol()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[0,1,2,13,19]";
            cboTipoCredito.CargarProducto(nCodPro);
            cboModDesemb1.SelectedIndex = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;
        }

        public frmCambioEstadoSol(int idCli, int idSolicitud)
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[0,1,2,13]";
            cboTipoCredito.CargarProducto(nCodPro);
            cboModDesemb1.SelectedIndex = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;

            this.conBusCuentaCli1.buscarCuentasPorCliente(idCli);
            buscarCuenta(idSolicitud);
            btnBusSolicitud1.Enabled = false;
        }
        #region Eventos

        private void frmCambioEstadoSol_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(nCodPro);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
            }
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                this.lblBase19.Text = "Día de Pago:";
                this.lblBase3.Text = "";
                //this.nudPlazo.Maximum = 31;
            }
            else
            {
                this.lblBase19.Text = "Frecuencia:";
                this.lblBase3.Text = "en días";
               // this.nudPlazo.Maximum = 365;
            }
        }

        private void cboOperacionCre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ampliacion
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
            {
                txtMontoAmpliado.ReadOnly = false;
                //txtMonto.Enabled = true;
            }
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 3)
            {
                txtMonto.Enabled = false;
            }
            else
            {
                txtMontoAmpliado.ReadOnly = true;
                txtSaldoCredito.Clear();
                txtMontoAmpliado.Clear();
                //txtMonto.Enabled = true;
            }
        }

        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
            }
        }

        private void cboProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            BuscarSolicitud(CodSol);
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            Int32 nIdSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            buscarCuenta(nIdSol);
        }

        private void buscarCuenta(int idSolicitud)
        {
            if (idSolicitud == 0)
            {
                limpiar();
                MessageBox.Show("No se encontró número de solicitud", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            BuscarSolicitud(idSolicitud);
        }
        private void chTasaEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chTasaEspecial.Checked)
            {
                txtTasaCom.Enabled = true;
            }
            else
            {
                txtTasaCom.Enabled = false;
                // Tasa();

                if (Sol.Rows.Count > 0)
                {
                    txtTasaCom.Text = Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                }
                else
                {
                    txtTasaCom.Text = "";
                }
            }
        }

        private void btnBusSolicitud1_Click(object sender, EventArgs e)
        {
            frmLisSolicitudCred FrmSolicitud = new frmLisSolicitudCred();
            FrmSolicitud.ShowDialog();
            if (FrmSolicitud.nNumSolicitud > 0)
            {
                limpiar();
                this.conBusCuentaCli1.txtNroBusqueda.Text = FrmSolicitud.nNumSolicitud.ToString();
                this.conBusCuentaCli1.nValBusqueda = FrmSolicitud.nNumSolicitud;
                this.conBusCuentaCli1.txtNombreCli.Text = FrmSolicitud.cNomCliente.ToString();
                this.conBusCuentaCli1.txtCodCli.Text = FrmSolicitud.idCliente.ToString();
                this.conBusCuentaCli1.txtNroDoc.Text = FrmSolicitud.cDocumentoID.ToString();
                this.conBusCuentaCli1.txtEstado.Text = FrmSolicitud.cNomEstado.ToString();
                int nNumsolicitud = Convert.ToInt32(FrmSolicitud.nNumSolicitud);
                this.BuscarSolicitud(nNumsolicitud);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();

            Habilitar(false);
            txtComentAproba.Clear();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(idCliente, 0, "Inicio - Cambio de Estado de Solicitud de Crédito", btnGrabar1);
            Validar();
            if (lEstado)
            {
                ActualizarEstado();
                txtMonto.Enabled = false;
                nudCuotas.Enabled = false;
                nudDiasGracia.Enabled = false;


                Habilitar(false);
            }
            chTasaEspecial.Checked = false;
            this.registrarRastreo(idCliente, 0, "Fin - Cambio de Estado de Solicitud de Crédito", btnGrabar1);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            CalcularMontoAmpliacion();
        }

        #endregion

        #region Métodos
        private void Habilitar(bool lHab)
        {
            cboModDesemb1.Enabled = lHab;
            cboNuevoEstado.Enabled = lHab;
            txtMonto.Enabled = lHab;
            nudCuotas.Enabled = lHab;
            nudDiasGracia.Enabled = lHab;
            btnGrabar1.Enabled = lHab;
            cboTipoPeriodo.Enabled = lHab;
            nudPlazo.Enabled = lHab;
            cboPersonalCreditos1.Enabled = lHab;
            txtComentAproba.Enabled = lHab;
            cboMotRechazoSolCreEval1.Enabled = lHab;
        }
        private void limpiar()
        {
            conBusCuentaCli1.nValBusqueda = 0;
            txtMonto.Text = "";
            cboMoneda.SelectedValue = 0;
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = DateTime.Today;
            cboOperacionCre1.SelectedValue = 1;
            cboEstadoCredito.SelectedValue = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";
            txtObservacion.Text = "";
            cboNuevoEstado.CargaEstado(999);
            cboEstadoCredito.CargaEstadoActual(999);
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";
            cboModDesemb1.SelectedIndex = 0;
            btnGrabar1.Enabled = true;
            chTasaEspecial.Checked = false;
            lblMensajeInformesRiesgo.Text = "";
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            txtMontoAmpliado.Text = "";
            txtSaldoCredito.Text = "";
            //txtMonto.Enabled = true;
            //nudCuotas.Enabled = true;
            //nudDiasGracia.Enabled = true;
            //txtObservacion.Enabled = true;
            //cboModDesemb1.Enabled = true;
            //cboNuevoEstado.Enabled = true;
            cboMotRechazoSolCreEval1.SelectedIndex = -1;
            panel3.Visible = false;
            conBusCuentaCli1.txtNroBusqueda.Focus();
            txtCobertura.Text = "0.00";
        }

        private void ActualizarEstado()
        {
            String cCumpleReglas = "";

            if (Transaccion == Convert.ToChar("X"))
            {
                lEstado = false;
            }
            if (Transaccion == Convert.ToChar("U") && Convert.ToInt32(cboNuevoEstado.SelectedValue) < 3)
            {
                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), Convert.ToInt32(cboProducto.SelectedValue),
                                                   Decimal.Parse(txtMonto.Text), idCliente, clsVarGlobal.dFecSystem,
                                                   2, Convert.ToInt32(cboEstadoCredito.SelectedValue),
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
                if (cCumpleReglas.Equals("Cumple"))
                {
                    Sol.Columns["idActividad"].ReadOnly = false;
                    Sol.Rows[0]["idEstado"] = cboNuevoEstado.SelectedValue;
                    Sol.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
                    Sol.Rows[0]["tObservacion"] = txtObservacion.Text;
                    Sol.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
                    Sol.Rows[0]["nCuotas"] = nudCuotas.Value;

                    //se agrego
                    Sol.Rows[0]["nTasaCompensatoria"] = txtTasaCom.Text;
                    Sol.Rows[0]["idProducto"] = cboSubProducto.SelectedValue;
                    Sol.Rows[0]["nPlazoCuota"] = nudPlazo.Value;
                    Sol.Rows[0]["idActividad"] = Sol.Rows[0]["CIIU"];
                    Sol.Columns["idPromotor"].ReadOnly = false;
                    Sol.Columns["cComentAproba"].ReadOnly = false;
                    Sol.Rows[0]["idPromotor"] = (int?) cboPersonalCreditos1.SelectedValue ?? 0;
                    Sol.Rows[0]["cComentAproba"] = txtComentAproba.Text;
                    Sol.Columns["idMotivoDeniega"].ReadOnly = false;
                    Sol.Rows[0]["idMotivoDeniega"] = Convert.ToInt32(cboMotRechazoSolCreEval1.SelectedValue);
                    //fin

                    DataSet ds = new DataSet("dssolici"),
                            dsCreAmp = new DataSet("dsCreAmp");
                    DataTable newDtCreAmp = new DataTable("Table1");

                    clsCreditoProp objCreditoProp;
                    String XmlSoli,
                           XmlCreAmp,
                           xmlCreditoProp;
                    Boolean lBaseNegativa = false;

                    idEstadoSol = Convert.ToInt32(cboNuevoEstado.SelectedValue);

                    if (Sol.DataSet == null)
                    {
                        ds.Tables.Add(Sol);
                    }
                    else
                    {
                        ds = Sol.DataSet;
                    }

                    XmlSoli = ds.GetXml();
                    XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);

                    //creditos Ampliados

                    dsCreAmp.Tables.Add(newDtCreAmp);
                    XmlCreAmp = dsCreAmp.GetXml();
                    XmlCreAmp = clsCNFormatoXML.EncodingXML(XmlCreAmp);

                    objCreditoProp = retornaCreditoProp();
                    xmlCreditoProp = objCreditoProp.GetXml();


                    if (cboMotRechazoSolCreEval1.SelectedItem != null)
                    {
                        lBaseNegativa = Convert.ToBoolean(((DataRowView)cboMotRechazoSolCreEval1.SelectedItem)["lBaseNegativa"]);
                    }

                    cnsolicitud.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, 0, 0, XmlCreAmp, lBaseNegativa, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                    btnGrabar1.Enabled = false;
                    MessageBox.Show("Actualización correcta", "Actualiza Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                if (cCumpleReglas.Equals("ExcepcionRechazada"))
                {
                    //original
                    Sol.Rows[0]["idEstado"] = cboNuevoEstado.SelectedValue;
                    Sol.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
                    Sol.Rows[0]["tObservacion"] = txtObservacion.Text;
                    Sol.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
                    Sol.Rows[0]["nCuotas"] = nudCuotas.Value;
                    Sol.Columns["idPromotor"].ReadOnly = false;
                    Sol.Columns["cComentAproba"].ReadOnly = false;
                    Sol.Rows[0]["idPromotor"] = (int?)cboPersonalCreditos1.SelectedValue ?? 0;
                    Sol.Rows[0]["cComentAproba"] = txtComentAproba.Text;
                    Sol.Columns["idActividad"].ReadOnly = false;
                    Sol.Rows[0]["idActividad"] = Sol.Rows[0]["CIIU"];
                    Sol.Columns["idMotivoDeniega"].ReadOnly = false;
                    Sol.Rows[0]["idMotivoDeniega"] = Convert.ToInt32(cboMotRechazoSolCreEval1.SelectedValue);
                    DataSet ds = new DataSet("dssolici");

                    if (Sol.DataSet == null)
                    {
                        ds.Tables.Add(Sol);
                    }
                    else
                    {
                        ds = Sol.DataSet;
                    }

                    String XmlSoli = ds.GetXml();
                    XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                    clsCreditoProp objCreditoProp = retornaCreditoProp();
                    string xmlCreditoProp = objCreditoProp.GetXml();
                    //verificar que se actualice
                    Boolean lBaseNegativa = false;
                    if (cboMotRechazoSolCreEval1.SelectedItem != null)
                    {
                        lBaseNegativa = Convert.ToBoolean(((DataRowView)cboMotRechazoSolCreEval1.SelectedItem)["lBaseNegativa"]);
                    }

                    cnsolicitud.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, 0, 0, "", lBaseNegativa, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                    btnGrabar1.Enabled = false;
                    idEstadoSol = Convert.ToInt32(cboNuevoEstado.SelectedValue);
                    MessageBox.Show("Actualización correcta", "Actualiza Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //terminar el original
                }
            }
            else
            {
                Sol.Rows[0]["idEstado"] = cboNuevoEstado.SelectedValue;
                Sol.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
                Sol.Rows[0]["tObservacion"] = txtObservacion.Text;
                Sol.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
                Sol.Rows[0]["nCuotas"] = nudCuotas.Value;
                Sol.Columns["idPromotor"].ReadOnly = false;
                Sol.Columns["cComentAproba"].ReadOnly = false;
                Sol.Rows[0]["idPromotor"] = cboPersonalCreditos1.SelectedValue == null ? 0 : (int)cboPersonalCreditos1.SelectedValue;
                Sol.Rows[0]["cComentAproba"] = txtComentAproba.Text;
                Sol.Columns["idActividad"].ReadOnly = false;
                Sol.Rows[0]["idActividad"] = Sol.Rows[0]["CIIU"];
                Sol.Columns["idMotivoDeniega"].ReadOnly = false;
                Sol.Rows[0]["idMotivoDeniega"] = Convert.ToInt32(cboMotRechazoSolCreEval1.SelectedValue);
                DataSet ds = new DataSet("dssolici");
                if (Sol.DataSet == null)
                {
                    ds.Tables.Add(Sol);
                }
                else
                {
                    ds = Sol.DataSet;
                }

                String XmlSoli = ds.GetXml();
                XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);

                //creditos Ampliados
                DataSet dsCreAmp = new DataSet("dsCreAmp");
                DataTable newDtCreAmp = new DataTable("Table1");
                dsCreAmp.Tables.Add(newDtCreAmp);
                String XmlCreAmp = dsCreAmp.GetXml();
                XmlCreAmp = clsCNFormatoXML.EncodingXML(XmlCreAmp);

                clsCreditoProp objCreditoProp = retornaCreditoProp();
                string xmlCreditoProp = objCreditoProp.GetXml();

                //verificar que se actualice
                Boolean lBaseNegativa = false;
                if (cboMotRechazoSolCreEval1.SelectedItem != null)
                {
                    lBaseNegativa = Convert.ToBoolean(((DataRowView)cboMotRechazoSolCreEval1.SelectedItem)["lBaseNegativa"]);
                }
                DataTable dtResultado = cnsolicitud.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, 0, 0, XmlCreAmp, lBaseNegativa, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                btnGrabar1.Enabled = false;
                cboMotRechazoSolCreEval1.Enabled = false;
                idEstadoSol = Convert.ToInt32(cboNuevoEstado.SelectedValue);
                MessageBox.Show("Actualización correcta", "Actualiza Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dtResultado.Rows[0]["cMensaje"] != DBNull.Value)
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Actualiza Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(conBusCuentaCli1.txtNroBusqueda.Text))
            {
                MessageBox.Show("Seleccione una solicitud", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            //int idTipoOperacion = 55; // CAMBIO ESTADO SOLICITUD
            //DataTable dtValidaPermisos = new clsCNAprobacion().CNValidarPermisosAprobacion((int)Sol.Rows[0]["idAgencia"], idTipoOperacion, 1, (int)cboMoneda.SelectedValue, (int)cboProducto.SelectedValue, Convert.ToDecimal /*era ToDouble*/(txtMonto.Text), clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            //if ((bool)dtValidaPermisos.Rows[0]["lPermisoApr"] == false)
            //{
            //    MessageBox.Show(dtValidaPermisos.Rows[0]["cMensaje"].ToString(), "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lEstado = false;
            //    return;
            //}

            if (Convert.ToDecimal(txtMonto.Text) > nMontoSolicitado)
            {
                MessageBox.Show("El Monto no puede ser mayor al solicitado", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            if (cboNuevoEstado.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un cambio de estado válido", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4 && Convert.ToDecimal(txtMontoAmpliado.Text) < 0)
            {
                MessageBox.Show("El Importe Debe ser Mayor o Igual al Saldo de Crédito para la Ampliación", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            if (String.IsNullOrWhiteSpace(txtObservacion.Text) && chTasaEspecial.Checked)
            {
                MessageBox.Show("Debe ingresar el sustento por el cambio de tasa en observaciones", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            if (Convert.ToInt32(cboMotRechazoSolCreEval1.SelectedValue) == 0 && Convert.ToInt32(cboNuevoEstado.SelectedValue) == 4) // cuando el estado es rechazado
            {
                MessageBox.Show("Debe seleccionar el motivo de rechazo", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }

            if (validarGarantia() && Convert.ToInt32(this.cboNuevoEstado.SelectedValue) == 2)
            {
                MessageBox.Show("La cobertura de la garantía no es la suficiente", "Validación Garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lEstado = false;
                return;
            }

            //if (cboPersonalCreditos1.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Debe de seleccionar el promotor del crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lEstado = false;
            //    return;
            //}

            if (String.IsNullOrWhiteSpace(txtComentAproba.Text))
            {
                MessageBox.Show("Debe ingresar las observaciones del cambio de estado.", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
                return;
            }


            lEstado = true;
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCliente;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Day.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSolicitud";
            drfila[1] = Convert.ToDateTime(dtpFechaSol.Value.ToString()).Year.ToString() + "-" +
                        Convert.ToDateTime(dtpFechaSol.Value.ToString()).Month.ToString() + "-" +
                        Convert.ToDateTime(dtpFechaSol.Value.ToString()).Day.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = cboOperacionCre1.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = txtMonto.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = nudCuotas.Value.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = cboTipoPeriodo.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = nudPlazo.Value.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nDiasGracia";
            drfila[1] = nudDiasGracia.Value;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaDesembolso";
            drfila[1] = Convert.ToDateTime(dtFechaDesembolso.Value.ToString()).Year.ToString() + "-" +
                        Convert.ToDateTime(dtFechaDesembolso.Value.ToString()).Month.ToString() + "-" +
                        Convert.ToDateTime(dtFechaDesembolso.Value.ToString()).Day.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "PersonalCre";
            drfila[1] = cboPersonalCreditos.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoCredito";
            drfila[1] = cboTipoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubTipoCredito";
            drfila[1] = cboSubTipoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Producto";
            drfila[1] = cboProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "DestinoCredito";
            drfila[1] = cboDestinoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "ModDesembolso";
            drfila[1] = cboModDesemb1.SelectedValue;
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
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolCre";
            drfila[1] = conBusCuentaCli1.nValBusqueda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuSistem";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void CalcularMontoAmpliacion()
        {
            //Ampliacion
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
            {
                if (txtMonto.Text.Trim().Equals(""))
                {
                    txtMontoAmpliado.Text = (Convert.ToDecimal(0) - Convert.ToDecimal(txtSaldoCredito.Text)).ToString();
                }
                else
                {
                    txtMontoAmpliado.Text = (Convert.ToDecimal(txtMonto.Text) - Convert.ToDecimal(txtSaldoCredito.Text)).ToString();
                }
            }
            else
            {
                txtMontoAmpliado.Text = "0.00";
            }
        }

        private void BuscarSolicitud(int CodigoSol)
        {

            Sol = cnsolicitud.ConsultaSolicitud(CodigoSol);

            if (Sol.Rows.Count > 0)
            {
                if (Convert.ToInt32(Sol.Rows[0]["idCanalRegistro"]) == 5)
                {
                    MessageBox.Show("No se puede cambiar estado, la solicitud ha sido registrado por Credirapp Plus", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();

                    Habilitar(false);
                    txtComentAproba.Clear();
                    return;
                }

                dtpFechaSol.Value = (Sol.Rows[0]["dFechaRegistro"] == DBNull.Value)? clsVarGlobal.dFecSystem : (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value)? "" : Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value)? 0.00m :(Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = (Sol.Rows[0]["IdMoneda"] == DBNull.Value)? 0 :Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = (Sol.Rows[0]["nCuotas"] == DBNull.Value)? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value)? 0: Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value)? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value)? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = (Sol.Rows[0]["idEstado"] == DBNull.Value)? 0: Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboPersonalCreditos.SelectedValue = (Sol.Rows[0]["idUsuario"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idUsuario"]);
                cboTipoCredito.SelectedValue = (Sol.Rows[0]["nTipCre"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = (Sol.Rows[0]["nSubTip"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = (Sol.Rows[0]["nProdu"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = (Sol.Rows[0]["nSubPro"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                cboModDesemb1.SelectedValue = (Sol.Rows[0]["idModalidadDes"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]);

                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);



                nCodEst = (Sol.Rows[0]["idEstado"] == DBNull.Value)? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                txtObservacion.Text = (Sol.Rows[0]["tObservacion"] == DBNull.Value)? "" : Convert.ToString(Sol.Rows[0]["tObservacion"]);
                cboNuevoEstado.CargaEstadoPreSol(nCodEst);
                cboEstadoCredito.CargaEstadoActual(nCodEst);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value)? 0: Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value)? 0:Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value)? 0: Convert.ToInt32(Sol.Rows[0]["idCli"]);
                txtMontoAmpliado.Text = (Sol.Rows[0]["nMontoAmpliado"] == DBNull.Value)? "": Sol.Rows[0]["nMontoAmpliado"].ToString();
                txtSaldoCredito.Text = (Sol.Rows[0]["nSaldoCreditos"] == DBNull.Value)? "": Sol.Rows[0]["nSaldoCreditos"].ToString();
                cboPersonalCreditos1.SelectedValue = (Sol.Rows[0]["idPromotor"] == DBNull.Value)? 0: (int)Sol.Rows[0]["idPromotor"];
                txtComentAproba.Text = (Sol.Rows[0]["cComentAproba"] == DBNull.Value)? "":Sol.Rows[0]["cComentAproba"].ToString();

                if(Sol.Rows[0]["idMotivoDeniega"] == DBNull.Value)
                {
                    cboMotRechazoSolCreEval1.SelectedIndex = -1;
                }
                else
	            {
                    cboMotRechazoSolCreEval1.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idMotivoDeniega"]);
	            }

                var nEvaluacion = Convert.ToInt32(Sol.Rows[0]["nEvaluacion"]);

                // if (nEvaluacion == 0)
                // {
                //     lblEvaluacion.Text = "Solicitud no tiene evaluación registrada";
                // }
                // else
                // {
                //     lblEvaluacion.Text = string.Format("Evaluación {0} Nro: {1}", Sol.Rows[0]["cTipoEvaluacion"].ToString(), nEvaluacion.ToString());
                // }

                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                    //this.nudPlazo.Maximum = 31;
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                   // this.nudPlazo.Maximum = 365;
                }
                Transaccion = Convert.ToChar("U");
                conBusCuentaCli1.btnBusCliente1.Enabled = false;
                conBusCuentaCli1.txtNroBusqueda.Enabled = false;

                cboNuevoEstado.Enabled = true;
                cboMotRechazoSolCreEval1.Enabled = true;
                btnGrabar1.Enabled = true;
                txtComentAproba.Enabled = true;

                var drGarantia = cnsolicitud.ValidaGarantiasSolicitud(CodigoSol).Rows[0];
                if (Convert.ToBoolean(drGarantia["lGarantia"]))
                {
                    rbtnSi.Checked = true;
                    rbtnNo.Checked = false;
                    lblCobertura.Visible = true;
                    txtCobertura.Visible = true;
                    txtCobertura.Text = Convert.ToString(cnsolicitud.RetornaGravamenSolicitud(CodigoSol).Rows[0][0]);
                }
                else
                {
                    rbtnSi.Checked = false;
                    rbtnNo.Checked = true;
                    lblCobertura.Visible = false;
                    txtCobertura.Visible = false;
                    txtCobertura.Text = "0.00";

                }

                //if (validarGarantia())
                //{
                //    MessageBox.Show("La cobertura de la garantía no es la suficiente", "Validación Garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //cboModDesemb1.Enabled = true;
                //cboTipoPeriodo.Enabled = true;
                //nudPlazo.Enabled = true;
                //cboPersonalCreditos1.Enabled = true;
                //btnGrabar1.Enabled = true;
                //txtMonto.Enabled = true;
                //nudCuotas.Enabled = true;
                //cboTipoPeriodo.Enabled = true;
                //cboNuevoEstado.Enabled = true;
            }
            else
            {
                limpiar();
                Transaccion = Convert.ToChar("I");
                cboModDesemb1.Enabled = false;
                cboTipoPeriodo.Enabled = false;
                nudPlazo.Enabled = false;
                cboPersonalCreditos1.Enabled = false;
                Habilitar(false);
                txtComentAproba.Clear();
                //btnGrabar1.Enabled = false;
            }

            //chTasaEspecial.Enabled = true;

            #region Mostrar el Estado SOLICITUD INFORME RIESGO, Y SI YA FUER LEIDO

            //////clsCNInformeRiesgos InformeRiesgos = new clsCNInformeRiesgos();
            //////DataTable dtListSolInfRiesgo = InformeRiesgos.ListSolInformeRiesgoPendientes(CodigoSol);//Para las solicitudes que no se han atendido

            //////DataTable dtInfRiesgo = InformeRiesgos.ObtenerInformeRiesgo(CodigoSol);//para ver el estado del informe

            //////StringBuilder sb = new StringBuilder();
            //////for (int i = 0; i < dtListSolInfRiesgo.Rows.Count; i++)
            //////{
            //////    sb.Append("La solicitud de Crédito NO TIENE INFORME DE RIESGO. Revisar la solicitud de Informe de Riesgo N° " + dtListSolInfRiesgo.Rows[i]["idSolInfRiesgo"].ToString() + " en el Menú INFORME DE RIESGO" + Environment.NewLine);
            //////}
            //////if (dtInfRiesgo.Rows.Count > 0)
            //////{
            //////    string cEstado = "";
            //////    if (Convert.ToBoolean(dtInfRiesgo.Rows[0]["lLeido"]) == true)
            //////    {
            //////        cEstado = "LEIDO";
            //////    }
            //////    else
            //////    {
            //////        cEstado = "NO LEIDO";
            //////    }
            //////    sb.Append("Informe de Riesgo N° " + dtInfRiesgo.Rows[0]["idInfRiesgos"].ToString() + " Estado: " + cEstado + Environment.NewLine);

            //////}
            //////lblMensajeInformesRiesgo.Text = sb.ToString();

        #endregion
        }

        private bool validarGarantia()
        {
            if (rbtnSi.Checked)
            {
                if ((int)this.cboOperacionCre1.SelectedValue == 4)//para la ampliación
                {
                    if (this.txtMontoAmpliado.nDecValor > txtCobertura.nDecValor)
                    {
                        lValGarantia = true;
                    }
                    else
                    {
                        lValGarantia = false;
                    }
                }
                else
                {
                    if (this.txtMonto.nDecValor > txtCobertura.nDecValor)
                    {
                        lValGarantia = true;
                    }
                    else
                    {
                        lValGarantia = false;
                    }
                }
            }
            else
            {
                lValGarantia = false;
            }
            return lValGarantia;
        }

        private clsCreditoProp retornaCreditoProp()
        {
            clsCreditoProp objCreditoProp =new clsCNSolCre().GetCreditoPropSol(Convert.ToInt32(conBusCuentaCli1.nValBusqueda));

            if (objCreditoProp == null)
            {
                objCreditoProp = new clsCreditoProp();
            }

            objCreditoProp.idOrigenCredProp = 1;
            objCreditoProp.nMonto = Convert.ToDecimal(txtMonto.Text);
            objCreditoProp.nCuotas = Convert.ToInt32(nudCuotas.Value);
            objCreditoProp.idTipoPeriodo = Convert.ToInt32(cboTipoPeriodo.SelectedValue);
            objCreditoProp.nPlazoCuota = Convert.ToInt32(nudPlazo.Value);
            objCreditoProp.nDiasGracia = Convert.ToInt32(nudDiasGracia.Value);
            objCreditoProp.dFechaDesembolso = dtFechaDesembolso.Value.Date;
            objCreditoProp.nTasaCompensatoria = Convert.ToDecimal(txtTasaCom.Text);
            objCreditoProp.cComentarios = txtObservacion.Text.Trim();

            return objCreditoProp;
        }

        #endregion

        private void cboNuevoEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNuevoEstado.SelectedValue.ToString().Equals("System.Data.DataRowView"))
                return;

            if (Convert.ToInt32(cboNuevoEstado.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["idEstadoRechazadoSolCre"]))
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
            cboMotRechazoSolCreEval1.SelectedValue = 0;
        }

        private void cboMotRechazoSolCreEval1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotRechazoSolCreEval1.SelectedItem != null)
            {
                if (Convert.ToBoolean(((DataRowView)cboMotRechazoSolCreEval1.SelectedItem)["lBaseNegativa"]))
                {
                    panel3.Visible = true;
                }
                else
                {
                    panel3.Visible = false;
                }
            }
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
