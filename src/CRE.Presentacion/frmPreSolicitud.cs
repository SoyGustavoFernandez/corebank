using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmPreSolicitud : frmBase
    {
        #region Variable Globales

        clsCNBuscarCli cncliente = new clsCNBuscarCli();
        clsCNRetDatosCliente cndatoscliente = new clsCNRetDatosCliente();
        clsCNPreSolicitud cnpresolicitud = new clsCNPreSolicitud();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();
        clsCNDirecCli cndireccion = new clsCNDirecCli();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        public int idCli { get; set; }
        public int idPreSolicitud { get; set; }
        Transaccion transaccion = Transaccion.Nuevo;
        string zona, via, nro, dpto, inte, km, mz, lote;

        #endregion

        public frmPreSolicitud()
        {
            InitializeComponent();

        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            limpiar();
            conBusUbiCli.cargar();
            limpiarDireccion();
        }

        private void cboTipoDocumento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento1.SelectedIndex > -1)
            {
                if (cboTipoDocumento1.SelectedValue is DataRowView) return;

                var idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);

                txtDocumento.Focus();
                txtDocumento.SelectAll();

                if (idTipoDocumento == 1)
                {
                    lblApeMaterno.Visible = true;
                    lblApePaterno.Visible = true;
                    lblNombres.Visible = true;
                    txtApeMaterno.Visible = true;
                    txtApePaterno.Visible = true;
                    txtNombres.Visible = true;

                    lblRazonSocial.Visible = false;
                    txtRazonSocial.Visible = false;

                    txtRazonSocial.Clear();
                    txtDocumento.MaxLength = 8;
                }
                else if (idTipoDocumento == 4)
                {
                    lblApeMaterno.Visible = false;
                    lblApePaterno.Visible = false;
                    lblNombres.Visible = false;
                    txtApeMaterno.Visible = false;
                    txtApePaterno.Visible = false;
                    txtNombres.Visible = false;

                    lblRazonSocial.Visible = true;
                    txtRazonSocial.Visible = true;

                    txtApeMaterno.Clear();
                    txtApePaterno.Clear();
                    txtNombres.Clear();
                    txtDocumento.MaxLength = 11;
                }
                else
                {
                    lblApeMaterno.Visible = true;
                    lblApePaterno.Visible = true;
                    lblNombres.Visible = true;
                    txtApeMaterno.Visible = true;
                    txtApePaterno.Visible = true;
                    txtNombres.Visible = true;

                    lblRazonSocial.Visible = false;
                    txtRazonSocial.Visible = false;

                    txtRazonSocial.Clear();
                    txtDocumento.MaxLength =15;
                }
            }
        }

        private void nudCuotas_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudCuotas.Value.ToString().Length;
            nudCuotas.Select(0, nLonTex);
        }

        private void nudPlazo_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudPlazo.Value.ToString().Length;
            nudPlazo.Select(0, nLonTex);
        }

        private void txtMontoSolicitado_Enter(object sender, EventArgs e)
        {
            txtMontoSolicitado.SelectAll();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var dtParametros = ArmarTablaParametros();

                var dtReglas = cnregladinamica.ObtenerReglasConResultado(dtParametros, this.Name);

                if (dtReglas.Rows.Count > 0)
                {
                    string cReglasNoCumplen = "Consideraciones a tener: \n";
                    for (int i = 0; i < dtReglas.Rows.Count; i++)
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cReglasNoCumplen = cReglasNoCumplen + " - " + dtReglas.Rows[i]["cMensajeError"].ToString() + "\n";
                        }
                    }

                    var nReglasNoCumple = dtReglas.AsEnumerable().Where(x => x["lResul"].ToString() == "NO" && (bool)x["lAlertaRiesgo"] == false).Count();

                    cReglasNoCumplen = cReglasNoCumplen + "¿Desea registrar la presolicitud de todas maneras?";
                    if (nReglasNoCumple > 0)
                    {
                        var lResultado = MessageBox.Show(cReglasNoCumplen, "Validar Reglas de Negocio", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (lResultado == System.Windows.Forms.DialogResult.OK)
                        {
                            registrarPreSolicitud();
                        }
                    }
                    else
                    {
                        registrarPreSolicitud();
                    }
                }
                else
                {
                    registrarPreSolicitud();
                }
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDocumento_Leave(sender, e);
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                this.lblDiaFrecuencia.Text = "Día de Pago:";
                this.lblDias.Text = "";
                this.nudPlazo.Maximum = 31;
            }
            else
            {
                this.lblDiaFrecuencia.Text = "Frecuencia:";
                this.lblDias.Text = "días";
                this.nudPlazo.Maximum = 1800;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Selecciona;
            limpiar();
            btnBusqueda1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            grbBase1.Enabled = true;
            habilitarControles(false);
            cboTipoDocumento1.Focus();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Nuevo;
            limpiar();
            btnBusqueda1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            grbBase1.Enabled = true;
            habilitarControles(true);
            cboTipoDocumento1.SelectedValue = 1;
            cboTipoDocumento1.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Edita;
            habilitarControles(true);
            grbBase1.Enabled = false;
            btnBusqueda1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Selecciona;
            limpiar();
            grbBase1.Enabled = true;
            habilitarControles(false);
            txtDocumento.Enabled = true;
            cboTipoDocumento1.Enabled = true;

            //realizar busqueda
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnBusqueda1.Enabled = false;

            idPreSolicitud = 0;
            idCli = 0;
            btnBusqueda1.Enabled = true;
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (idCli == 0 && idPreSolicitud == 0)
            {
                if (string.IsNullOrEmpty(txtDocumento.Text) || txtDocumento.Text.Trim().Length < 8)
                {
                    return;
                }
                limpiarDireccion();
                lblCalificaInterna.Text = "";
                txtApePaterno.Clear();
                txtApeMaterno.Clear();
                txtNombres.Clear();
                txtRazonSocial.Clear();
                txtMontoSolicitado.Text = "0";
                txtComentarios.Clear();
                txtCBNroTel.Clear();
                txtCBNroTel2.Clear();
                nudCuotas.Value = 0;
                nudPlazo.Value = 0;

                if (cargarDatosPresolicitud())
                {
                    return;
                }
                string cCriterio = "", cTipBus = "";
                var idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);
                if (idTipoDocumento == 1)
                {
                    cCriterio = "1";
                    cTipBus = "N";
                }
                else if (idTipoDocumento == 4)
                {
                    cCriterio = "3";
                    cTipBus = "J";
                }
                else
                {
                    cCriterio = "1";
                    cTipBus = "N";
                }

                var cDocumento = this.txtDocumento.Text.Trim();
                var dtCliente = cncliente.ListarClientes(cCriterio, cDocumento);

                if (dtCliente.Rows.Count > 0)
                {
                    idCli = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                    if (idTipoDocumento != Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]))
                    {
                        cboTipoDocumento1.SelectedValue = Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]);
                    }

                    var dtSolCli = cnsolicitud.SolicitudClienteEstado(idCli, 1);

                    if (dtSolCli.Rows.Count > 0)
                    {
                        var cCodSolicitud = dtSolCli.Rows[0]["idSolicitud"].ToString();
                        var cFechaRegistro = Convert.ToDateTime(dtSolCli.Rows[0]["dFechaRegistro"]).ToString("dd/MMMM/yyy").ToUpper();
                        var cCapitalSolicitado = dtSolCli.Rows[0]["nCapitalSolicitado"].ToString();

                        MessageBox.Show("Persona ingresada ya cuenta con una solicitud de Crédito. \n\t - Número de Solicitud: " + cCodSolicitud.Trim() +
                        "\n\t - Fecha: " + cFechaRegistro +"\n\t - Monto de: " + cCapitalSolicitado +"\n mayor detalle en la opción de Registro de Solicitud de Crédito", "Validación Pre Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnCancelar1.PerformClick();
                        return;
                    }

                    if (idTipoDocumento == 1)
                    {
                        var dtDetalleCliente = cndatoscliente.ListarDatosCli(idCli, cTipBus);
                        if (dtDetalleCliente.Rows.Count > 0)
                        {
                            txtApePaterno.Text = dtDetalleCliente.Rows[0]["cApellidoPaterno"].ToString();
                            txtApeMaterno.Text = dtDetalleCliente.Rows[0]["cApellidoMaterno"].ToString();
                            txtNombres.Text = dtDetalleCliente.Rows[0]["cNombre"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Datos del cliente no estan actualizados, \n por favor verificar desde la opción mantenimiento de cliente", "Validación datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else if (idTipoDocumento == 4)
                    {
                        txtRazonSocial.Text = dtCliente.Rows[0]["cNombre"].ToString();
                    }
                    txtApeMaterno.Enabled = false;
                    txtApePaterno.Enabled = false;
                    txtNombres.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    cboTipoDocumento1.Enabled = false;
                    lblCalificaInterna.Text ="Cliente ya registrado, calificación interna:"+ dtCliente.Rows[0]["cClasifInterna"].ToString();

                    var dtDireccion = cndireccion.ListaDirCli(idCli);
                    if (dtDireccion.Rows.Count > 0)
                    {
                        var drDireccion = dtDireccion.AsEnumerable().Where(x => (bool)x["lDirPrincipal"] == true).ToList()[0];
                        this.conBusUbiCli.cargarUbigeo(Convert.ToInt32(drDireccion["idUbigeo"]));

                        this.cboTipoZona.SelectedValue  = Convert.ToInt32(drDireccion["idTipoZona"]);
                        this.cboTipoVia.SelectedValue   = Convert.ToInt32(drDireccion["idTipoVia"]);
                        this.textZonas.Text             = drDireccion["cDesZona"].ToString().Trim();
                        this.textVia.Text               = drDireccion["cDesVia"].ToString().Trim();
                        this.textNro.Text               = drDireccion["cNumero"].ToString().Trim();
                        this.textDpto.Text              = drDireccion["cDepartamento"].ToString().Trim();
                        this.textInt.Text               = drDireccion["cInterior"].ToString().Trim();
                        this.textKm.Text                = drDireccion["cKilometro"].ToString().Trim();
                        this.textMz.Text                = drDireccion["cManzana"].ToString().Trim();
                        this.textLote.Text              = drDireccion["cLote"].ToString().Trim();
                        this.txtDireccion.Text          = drDireccion["cDireccion"].ToString().Trim();
                    }
                    txtCBNroTel.Focus();
                }
                else
                {

                    var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBS(cDocumento);
                    if (dtPersonaSBS.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtPersonaSBS.Rows[0]["idTipoPersona"]) == 1)
                        {
                            this.cboTipoDocumento1.SelectedValue = 1;
                            txtApePaterno.Text = dtPersonaSBS.Rows[0]["cApePaterno"].ToString();
                            txtApeMaterno.Text = dtPersonaSBS.Rows[0]["cApeMaterno"].ToString();
                            txtNombres.Text = dtPersonaSBS.Rows[0]["cPriNombre"].ToString();
                        }
                        else
                        {
                            this.cboTipoDocumento1.SelectedValue = 4;
                            txtRazonSocial.Text = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                        }
                        lblCalificaInterna.Text = "Persona encontrada desde Base de Datos SBS";
                    }
                    else
                    {
                        cboTipoDocumento1.Enabled = true;
                        txtApeMaterno.Enabled = false;
                        txtApePaterno.Enabled = false;
                        txtNombres.Enabled = false;
                        txtRazonSocial.Enabled = false;

                        if (transaccion == Transaccion.Nuevo)
                        {
                            txtApeMaterno.Enabled = true;
                            txtApePaterno.Enabled = true;
                            txtNombres.Enabled = true;
                            txtRazonSocial.Enabled = true;
                        }

                        lblCalificaInterna.Text = "";
                        txtApePaterno.Clear();
                        txtApeMaterno.Clear();
                        txtNombres.Clear();
                        txtRazonSocial.Clear();
                        txtMontoSolicitado.Text = "0";
                        txtComentarios.Clear();
                        txtCBNroTel.Clear();
                        txtCBNroTel2.Clear();
                        nudCuotas.Value = 0;
                        nudPlazo.Value = 0;
                        cboEstadoCredito1.Visible = false;
                        lblEstadoSolicitud.Visible = false;
                        lblCalificaInterna.Text = "";
                        idCli = 0;
                        idPreSolicitud = 0;
                        btnNuevo1.Enabled = true;
                    }
                }
            }
        }

        private void textZonas_TextChanged(object sender, EventArgs e)
        {
            String cadZona = "";
            if (textZonas.Text == "")
                cadZona = "";
            else if (cboTipoZona.Text == "OTROS")
                cadZona = textZonas.Text + " - ";
            else
                cadZona = cboTipoZona.Text + ": " + textZonas.Text + " - ";
            asignarDireccion(cadZona, "textZona");
        }

        private void textVia_TextChanged(object sender, EventArgs e)
        {
            String cadVia = "";
            if (textVia.Text == "")
                cadVia = "";
            else if (cboTipoVia.Text == "OTROS")
                cadVia = textVia.Text + "  ";
            else
                cadVia = cboTipoVia.Text + " " + textVia.Text + "  ";
            asignarDireccion(cadVia, "textVia");
        }

        private void textNro_TextChanged(object sender, EventArgs e)
        {
            String cadNro = "";
            if (textNro.Text != "")
                cadNro += "Nro " + textNro.Text + "   ";
            asignarDireccion(cadNro, "textNro");
        }

        private void textDpto_TextChanged(object sender, EventArgs e)
        {
            String cadDpto = "";
            if (textDpto.Text != "")
                cadDpto += "Dpto " + textDpto.Text + "   ";
            asignarDireccion(cadDpto, "textDpto");
        }

        private void textInt_TextChanged(object sender, EventArgs e)
        {
            String cadInt = "";
            if (textInt.Text != "")
                cadInt += "Int " + textInt.Text + "   ";
            asignarDireccion(cadInt, "textInt");
        }

        private void textKm_TextChanged(object sender, EventArgs e)
        {
            String cadKm = "";
            if (textKm.Text != "")
                cadKm += "Km " + textKm.Text + "   ";
            asignarDireccion(cadKm, "textKm");
        }

        private void textMz_TextChanged(object sender, EventArgs e)
        {
            String cadMz = "";
            if (textMz.Text != "")
                cadMz += "Mz " + textMz.Text + "   ";
            asignarDireccion(cadMz, "textMz");
        }

        private void textLote_TextChanged(object sender, EventArgs e)
        {
            String cadLote = "";
            if (textLote.Text != "")
                cadLote += "Lt " + textLote.Text + "   ";
            asignarDireccion(cadLote, "textLote");
        }

        private void cboTipoZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoZona.SelectedIndex > -1)
            {
                if (Convert.ToInt32(this.cboTipoZona.SelectedValue) == 1)
                {
                    textZonas.Clear();
                    textZonas.Enabled = false;
                }
                else
                {
                    textZonas.Enabled = true;
                }
            }
        }

        private void cboTipoVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoVia.SelectedIndex > -1)
            {
                if (Convert.ToInt32(this.cboTipoVia.SelectedValue) == 1)
                {
                    textVia.Clear();
                    textVia.Enabled = false;
                }
                else
                {
                    textVia.Enabled = true;
                }
            }
        }

        private void txtDocumento_Enter(object sender, EventArgs e)
        {
            idCli = 0;
            idPreSolicitud = 0;
        }

        private void btnPosInt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDocumento.Text))
            {
                string cCriterio = "";
                var cDocumento = this.txtDocumento.Text.Trim();


                if (cDocumento.Length == 8)
                {
                    cCriterio = "1";
                }
                if (cDocumento.Length == 11)
                {
                    cCriterio = "3";
                }
                var dtCliente = cncliente.ListarClientes(cCriterio, cDocumento);

                string cNombre = String.Empty;
                int idCli = 0;

                if (dtCliente.Rows.Count > 0)
                {
                    cNombre = dtCliente.Rows[0]["cNombre"].ToString();
                    idCli = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                }

                else
                {
                    var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBS(cDocumento);
                    if (dtPersonaSBS.Rows.Count > 0)
                    {
                        cNombre = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                        idCli = 0;
                    }
                    else
                    {
                        MessageBox.Show("Documento ingresado no contiene registros históricos ni base de datos de RCC",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                new frmPosicionInterv().MostrarReporte(cDocumento, cNombre, idCli);
            }
            else
            {
                MessageBox.Show("Ingrese documento válido.",
                                            "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;
            var idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);

            if (idTipoDocumento==1)
            {
                if (this.txtDocumento.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Por favor ingrese el número de documento", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocumento.Focus();
                    return lValida;
                }

                if (string.IsNullOrEmpty(txtApePaterno.Text))
                {
                    MessageBox.Show("Por favor ingrese el apellido paterno", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApePaterno.Focus();
                    return lValida;
                }

                if (string.IsNullOrEmpty(txtApeMaterno.Text))
                {
                    MessageBox.Show("Por favor ingrese el apellido materno", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApeMaterno.Focus();
                    return lValida;
                }

                if (string.IsNullOrEmpty(txtNombres.Text))
                {
                    MessageBox.Show("Por favor ingrese el nombre", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombres.Focus();
                    return lValida;
                }
            }

            if (idTipoDocumento == 4)
            {
                if (this.txtDocumento.Text.Trim().Length < 11)
                {
                    MessageBox.Show("Por favor ingrese el número de documento", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocumento.Focus();
                    return lValida;
                }

                if (string.IsNullOrEmpty(this.txtRazonSocial.Text))
                {
                    MessageBox.Show("Por favor ingrese la razón social", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRazonSocial.Focus();
                    return lValida;
                }
            }

            if (string.IsNullOrEmpty(this.txtCBNroTel2.Text))
            {
                MessageBox.Show("Por favor ingrese el teléfono celular.", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoZona.Focus();
                return lValida;
            }

            if (string.IsNullOrEmpty(this.txtDireccion.Text))
            {
                MessageBox.Show("Por favor ingrese la dirección del solicitante", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoZona.Focus();
                return lValida;
            }

            if (this.txtMontoSolicitado.nvalor == 0)
            {
                MessageBox.Show("Por favor ingrese el monto solicitado", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoSolicitado.Focus();
                return lValida;
            }

            if (this.nudCuotas.Value == 0M)
            {
                MessageBox.Show("Por favor ingrese el número de cuotas", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCuotas.Focus();
                return lValida;
            }

            if (this.nudPlazo.Value == 0M)
            {
                MessageBox.Show("Por favor ingrese el número de días", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPlazo.Focus();
                return lValida;
            }

            if (this.conBusUbiCli.cboAnexo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un ubigeo correcto", "Validación ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusUbiCli.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void habilitarControles(bool lEstado)
        {
            txtDocumento.Enabled = lEstado;
            txtApePaterno.Enabled = lEstado;
            txtApeMaterno.Enabled = lEstado;
            txtNombres.Enabled = lEstado;
            txtRazonSocial.Enabled = lEstado;
            txtMontoSolicitado.Enabled = lEstado;
            nudCuotas.Enabled = lEstado;
            nudPlazo.Enabled = lEstado;
            cboMoneda1.Enabled = lEstado;
            cboTipoDocumento1.Enabled = lEstado;
            cboTipoPeriodo.Enabled = lEstado;
            cboEstadoCredito1.Enabled = lEstado;
            txtCBNroTel.Enabled = lEstado;
            txtCBNroTel2.Enabled = lEstado;
            txtComentarios.Enabled = lEstado;
            cboTipoCaptacion1.Enabled = lEstado;
            grbDireccion.Enabled = lEstado;
        }

        private void limpiar()
        {
            txtDocumento.Clear();
            txtApePaterno.Clear();
            txtApeMaterno.Clear();
            txtNombres.Clear();
            txtRazonSocial.Clear();
            txtMontoSolicitado.Text = "0";
            txtComentarios.Clear();
            txtCBNroTel.Clear();
            txtCBNroTel2.Clear();
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            cboEstadoCredito1.Visible = false;
            lblEstadoSolicitud.Visible = false;
            lblCalificaInterna.Text = "";
            idCli = 0;
            idPreSolicitud = 0;
            limpiarDireccion();

            cboMoneda1.SelectedIndex = -1;
            cboTipoCaptacion1.SelectedIndex = -1;
            cboTipoPeriodo.SelectedIndex = -1;
            cboEstadoCredito1.SelectedValue = 0;
        }

        public void limpiarDireccion()
        {
            this.cboTipoZona.SelectedIndex = -1;
            this.cboTipoVia.SelectedIndex = -1;
            foreach (Control item in grbDireccion.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            conBusUbiCli.cboPais.SelectedValue = 173;
            conBusUbiCli.cboDepartamento.SelectedValue = 2017;
            conBusUbiCli.cboProvincia.SelectedValue = 0;
            conBusUbiCli.cboDistrito.SelectedValue = 0;
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = "'" + txtDocumento.Text.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = this.txtMontoSolicitado.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda1.SelectedValue;
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
            drfila[0] = "idUbigeoDir";
            drfila[1] = this.conBusUbiCli.cboDistrito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDireccion";
            drfila[1] = "'" + txtDireccion.Text + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = "'" + clsVarGlobal.cNomAge + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVigente";
            drfila[1] = clsVarGlobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = "'" + clsVarGlobal.User.dFechaIngreso.ToString("yyyy-MM-dd") + "'";
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
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = clsVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool cargarDatosPresolicitud()
        {
            var dtPreSolicitud = cnpresolicitud.ADBuscarPreSolicitud(Convert.ToInt32(cboTipoDocumento1.SelectedValue), txtDocumento.Text.Trim());
            if (dtPreSolicitud.Rows.Count > 0)
            {
                cboEstadoCredito1.CargarEstPreSolicitud();

                cboEstadoCredito1.SelectedValue =  Convert.ToInt32(dtPreSolicitud.Rows[0]["idEstado"]);
                txtMontoSolicitado.Text = dtPreSolicitud.Rows[0]["nMontoSolicitado"].ToString();
                cboTipoPeriodo.SelectedValue = Convert.ToInt32(dtPreSolicitud.Rows[0]["idTipoPeriodo"]);
                cboTipoDocumento1.SelectedValue= Convert.ToInt32(dtPreSolicitud.Rows[0]["idTipoDocumento"]);
                cboTipoCaptacion1.SelectedValue= Convert.ToInt32(dtPreSolicitud.Rows[0]["idTipoCaptacion"]);
                cboMoneda1.SelectedValue= Convert.ToInt32(dtPreSolicitud.Rows[0]["idMoneda"]);
                nudCuotas.Value = Convert.ToDecimal(dtPreSolicitud.Rows[0]["nCuotas"]);
                nudPlazo.Value = Convert.ToDecimal(dtPreSolicitud.Rows[0]["nPlazoCuota"]);
                txtDocumento.Text = dtPreSolicitud.Rows[0]["cDocumento"].ToString();
                txtRazonSocial.Text = dtPreSolicitud.Rows[0]["cNombreCompleto"].ToString();
                txtApePaterno.Text = dtPreSolicitud.Rows[0]["cApellidoPaterno"].ToString();
                txtApeMaterno.Text = dtPreSolicitud.Rows[0]["cApellidoMaterno"].ToString();
                txtNombres.Text = dtPreSolicitud.Rows[0]["cNombre"].ToString();
                txtCBNroTel.Text = dtPreSolicitud.Rows[0]["nNumeroTelefono"].ToString();
                txtCBNroTel2.Text = dtPreSolicitud.Rows[0]["cNumeroTelefono2"].ToString();
                txtComentarios.Text = dtPreSolicitud.Rows[0]["cObservaciones"].ToString();
                idCli = dtPreSolicitud.Rows[0]["idCli"] == DBNull.Value ? 0 : Convert.ToInt32(dtPreSolicitud.Rows[0]["idCli"]);
                idPreSolicitud = Convert.ToInt32(dtPreSolicitud.Rows[0]["idPreSolicitud"]);
                conBusUbiCli.cargarUbigeo(Convert.ToInt32(dtPreSolicitud.Rows[0]["idUbigeo"]));
                txtDireccion.Text = dtPreSolicitud.Rows[0]["cdireccion"].ToString();
                habilitarControles(false);
                btnNuevo1.Enabled = false;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnGrabar1.Enabled = false;
                btnBusqueda1.Enabled = false;
                cboEstadoCredito1.Visible = true;
                lblEstadoSolicitud.Visible = true;
                MessageBox.Show("Ya existe un registro de pre solicitud para el cliente \n si desea puede modificar los datos de la pre solicitud", "Registro Pre Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                if (transaccion== Transaccion.Selecciona)
                {
                    transaccion = Transaccion.Nuevo;
                    MessageBox.Show("No se encontro registro de pre solicitud con el documento ingresado", "Búsqueda de pre solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                idCli = 0;
                idPreSolicitud = 0;
                cboEstadoCredito1.Visible = false;
                lblEstadoSolicitud.Visible = false;
                return false;
            }
        }

        private void asignarDireccion(string letras, string Tipo)
        {
            string direccion;
            if (Tipo == "textZona")
                zona = letras;
            if (Tipo == "textVia")
                via = letras;
            if (Tipo == "textNro")
                nro = letras;
            if (Tipo == "textDpto")
                dpto = letras;
            if (Tipo == "textInt")
                inte = letras;
            if (Tipo == "textKm")
                km = letras;
            if (Tipo == "textMz")
                mz = letras;
            if (Tipo == "textLote")
                lote = letras;

            direccion = zona + via + nro + dpto + inte + km + mz + lote;
            txtDireccion.Text = direccion.Trim();
        }

        private void registrarPreSolicitud()
        {
            #region Asignación de valores

            var idEstado = Convert.ToInt32(cboEstadoCredito1.SelectedValue);
            var nMontoSolicitado = txtMontoSolicitado.nDecValor;
            var nCuotas = Convert.ToInt32(nudCuotas.Value);
            var nPlazoCuota = Convert.ToInt32(nudPlazo.Value);
            var idTipoPeriodo = Convert.ToInt32(cboTipoPeriodo.SelectedValue);
            var idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);
            var idTipoCaptacion = Convert.ToInt32(cboTipoCaptacion1.SelectedValue);
            var idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            var cDocumento = txtDocumento.Text.Trim();
            var cNombreCompleto = txtRazonSocial.Text.Trim();
            var cApellidoPaterno = txtApePaterno.Text.Trim();
            var cApellidoMaterno = txtApeMaterno.Text.Trim();
            var cNombre = txtNombres.Text.Trim();
            var nNumeroTelefono = txtCBNroTel.Text.Trim();
            var cNumeroTelefono2 = txtCBNroTel2.Text.Trim();
            var idAgencia = clsVarGlobal.nIdAgencia;
            var dFechaRegistro = clsVarGlobal.dFecSystem;
            var idUsuario = clsVarGlobal.User.idUsuario;
            var cObservaciones = txtComentarios.Text.Trim();
            var idUbigeo = Convert.ToInt32(this.conBusUbiCli.cboAnexo.SelectedValue);
            var cDireccion = txtDireccion.Text.Trim();

            #endregion

            DataTable dtResultado=new DataTable();

            if (transaccion == Transaccion.Nuevo)
            {
                dtResultado=cnpresolicitud.CNInsertarPreSolicitud(idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo,
                    idTipoDocumento, idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto,
                    cApellidoPaterno, cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario,idUbigeo,cDireccion, cObservaciones);
            }
            else if (transaccion == Transaccion.Edita)
            {
                dtResultado = cnpresolicitud.CNActualizarPreSolicitud(idPreSolicitud, idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo,
                    idTipoDocumento, idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto,
                    cApellidoPaterno, cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario, idUbigeo, cDireccion, cObservaciones);
            }

            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 1)
            {
                MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Registro de Pre Solciitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos se guardaron correctamente", "Registro de Pre Solciitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            habilitarControles(false);
            btnBusqueda1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }

        #endregion

    }
}
