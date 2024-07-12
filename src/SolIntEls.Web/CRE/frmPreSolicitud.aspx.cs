using CLI.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using SolIntEls.Web.utiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolIntEls.Web.CRE
{
    public partial class frmPreSolicitud : System.Web.UI.Page
    {
        #region Variable Globales

        private Transaccion _objTransaccion;

        public Transaccion transaccion
        {
            set
            {
                _objTransaccion = value;
                ViewState["ObjTransaccion"] = value;
            }
            get { return ViewState["ObjTransaccion"] == null ? Transaccion.Nuevo : (Transaccion)ViewState["ObjTransaccion"]; }
        }

        public clsVarGlobalClone objVarGlobal
        {
            set { Session["VarGlobal"] = value; }
            get { return Session["VarGlobal"] == null ? new clsVarGlobalClone() : (clsVarGlobalClone)Session["VarGlobal"]; }
        }

        public clsVarAplClone objVarApl
        {
            set { Session["VarApl"] = value; }
            get { return Session["VarApl"] == null ? new clsVarAplClone() : (clsVarAplClone)Session["VarApl"]; }
        }

        clsCNBuscarCli cncliente = new clsCNBuscarCli();
        clsCNRetDatosCliente cndatoscliente = new clsCNRetDatosCliente();
        clsCNPreSolicitud cnpresolicitud = new clsCNPreSolicitud();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();
        clsCNDirecCli cndireccion = new clsCNDirecCli();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        clsCNUbigeo cnubigeo = new clsCNUbigeo();

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (objVarGlobal.User == null)
                {
                    throw new Exception("La sesión de usuario terminó, vuelva a ingresar");
                }

                lblUsuario.Text = objVarGlobal.User.cWinUser;
                lblMensaje.Text = "";
            }
        }

        protected void lnkSalir_ServerClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect("../frmInicio.aspx", true);
        }

        protected void BtnGrabar1_Click(object sender, EventArgs e)
        {
            if (hdfIdPresolciitud.Value == "0")
            {
                var dtParametros = ArmarTablaParametros();

                var dtReglas = cnregladinamica.ObtenerReglasConResultado(dtParametros, "frmPreSolicitud");

                if (dtReglas.Rows.Count > 0)
                {
                    string cReglasNoCumplen = "Consideraciones a tener: \n";
                    for (int i = 0; i < dtReglas.Rows.Count; i++)
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") &&
                            (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cReglasNoCumplen = cReglasNoCumplen + " - " + dtReglas.Rows[i]["cMensajeError"].ToString() +
                                               "\n";
                        }
                    }

                    if (
                        dtReglas.AsEnumerable()
                            .Any(x => x["lResul"].ToString() == "NO" && (bool) x["lAlertaRiesgo"] == false))
                    {
                        lblReglas.Text = cReglasNoCumplen + " \n¿Desea continuar con el registro?.";
                        pnlReglas.Visible = true;
                        BtnGrabar1.Visible = false;
                        BtnAtras1.Visible = false;
                        return;
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
            else
            {
                registrarPreSolicitud();
            }

            pnlPresolicitud.Visible = false;
            pnlMensaje.Visible = true;
            limpiar();
        }

        protected void BtnNuevo1_Click(object sender, EventArgs e)
        {
            pnlConsulta.Visible = true;
            pnlPresolicitud.Visible = false;
            pnlMensaje.Visible = false;
            lblMensaje.Text = String.Empty;
            txtDocumento.Enabled = true;
            txtDocumento.Focus();
        }

        protected void rblTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoDocumento.SelectedValue == "4")
            {
                txtDocumento.MaxLength = 11;
            }
            else
            {
                txtDocumento.MaxLength = 8;
            }
        }

        protected void BtnConsultar1_Click(object sender, EventArgs e)
        {
            if (rblTipoDocumento.SelectedValue == "4")
            {
                pnlPJ.Visible = true;
                pnlPN.Visible = false;
            }
            else
            {
                pnlPJ.Visible = false;
                pnlPN.Visible = true;
            }

            pnlMensaje.Visible = false;
            pnlReglas.Visible = false;
            txtApeMaterno.Text = "";
            txtApePaterno.Text = "";
            txtComentarios.Text = "";            
            txtMonto.Text = "";
            txtNombres.Text = "";
            txtNumcuotas.Text = "";
            txtPeriodo.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
            rblMoneda.SelectedValue = "1";
            hdfIdCli.Value = "0";
            hdfIdPresolciitud.Value = "0";
            lblMensaje.Text = String.Empty;

            txtDocumento.Enabled = true;
            txtApePaterno.Enabled = true;
            txtApeMaterno.Enabled = true;
            txtNombres.Enabled = true;
            txtTelefono.Enabled = true;
            txtCelular.Enabled = true;
            cboDepartamento.Enabled = true;
            cboProvincia.Enabled = true;
            cboDistrito.Enabled = true;
            cboComunidad.Enabled = true;
            txtDireccion.Enabled = true;

            BtnAtras1.Visible = true;

            if (hdfIdCli.Value == "0" && hdfIdPresolciitud.Value == "0")
            {
                if (string.IsNullOrEmpty(txtDocumento.Text) || txtDocumento.Text.Trim().Length < 8)
                {
                    return;
                }
                cargarDepartamento();
                if (cargarDatosPresolicitud())
                {
                    return;
                }
                string cCriterio = "", cTipBus = "";
                var idTipoDocumento = Convert.ToInt32(rblTipoDocumento.SelectedValue);
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

                var cDocumento = this.txtDocumento.Text.Trim();
                var dtCliente = cncliente.ListarClientes(cCriterio, cDocumento);

                if (dtCliente.Rows.Count > 0)
                {
                    hdfIdCli.Value = dtCliente.Rows[0]["idCli"].ToString();

                    var dtSolCli = cnsolicitud.SolicitudClienteEstado(Convert.ToInt32(hdfIdCli.Value), 1);

                    if (dtSolCli.Rows.Count > 0)
                    {
                        var cCodSolicitud = dtSolCli.Rows[0]["idSolicitud"].ToString();
                        var cFechaRegistro = Convert.ToDateTime(dtSolCli.Rows[0]["dFechaRegistro"]).ToString("dd/MMMM/yyy").ToUpper();
                        var cCapitalSolicitado = dtSolCli.Rows[0]["nCapitalSolicitado"].ToString();

                        this.lblMensaje.Text = "Persona ingresada ya cuenta con una solicitud de Crédito. \n\t - Número de Solicitud: " + cCodSolicitud.Trim() +
                        "\n\t - Fecha: " + cFechaRegistro + "\n\t - Monto de: " + cCapitalSolicitado + "\n mayor detalle en la opción de Registro de Solicitud de Crédito"; ;
                        pnlInnerMsje.CssClass = "alert alert-danger";
                        pnlPresolicitud.Visible = false;
                        pnlMensaje.Visible = true;
                        return;
                    }

                    if (idTipoDocumento == 1)
                    {
                        var dtDetalleCliente = cndatoscliente.ListarDatosCli(Convert.ToInt32(hdfIdCli.Value), cTipBus);

                        if (dtDetalleCliente.Rows.Count > 0)
                        {
                            txtApePaterno.Text = dtDetalleCliente.Rows[0]["cApellidoPaterno"].ToString();
                            txtApeMaterno.Text = dtDetalleCliente.Rows[0]["cApellidoMaterno"].ToString();
                            txtNombres.Text = dtDetalleCliente.Rows[0]["cNombre"].ToString();
                        }
                        else
                        {
                            lblMensaje.Text = "Datos del cliente no estan actualizados, \n por favor verificar desde la opción mantenimiento de cliente"; ;
                            pnlInnerMsje.CssClass = "alert alert-warning";
                            pnlPresolicitud.Visible = false;
                            pnlMensaje.Visible = true;
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
                    divCalificacion.Visible = true;
                    lblCalificaInterna.Text = dtCliente.Rows[0]["cClasifInterna"].ToString();

                    var dtDireccion = cndireccion.ListaDirCli(Convert.ToInt32(hdfIdCli.Value));
                    if (dtDireccion.Rows.Count > 0)
                    {
                        var drDireccion = dtDireccion.AsEnumerable().Where(x => (bool)x["lDirPrincipal"] == true).ToList()[0];
                        cargarUbigeo(Convert.ToInt32(drDireccion["idUbigeo"]));

                        txtDireccion.Text = drDireccion["cDireccion"].ToString().Trim();
                    }
                }
                else
                {

                    var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBS(cDocumento);
                    if (dtPersonaSBS.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtPersonaSBS.Rows[0]["idTipoPersona"]) == 1)
                        {
                            this.rblTipoDocumento.SelectedValue = "1";
                            txtApePaterno.Text = dtPersonaSBS.Rows[0]["cApePaterno"].ToString();
                            txtApeMaterno.Text = dtPersonaSBS.Rows[0]["cApeMaterno"].ToString();
                            txtNombres.Text = dtPersonaSBS.Rows[0]["cPriNombre"].ToString();
                        }
                        else
                        {
                            this.rblTipoDocumento.SelectedValue = "4";
                            txtRazonSocial.Text = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                        }
                        divCalificacion.Visible = true;
                        lblCalificaInterna.Text = "Persona entontrada desde Base de Datos SBS";
                    }
                    else
                    {
                        divCalificacion.Visible = false;
                        txtApeMaterno.Enabled = true;
                        txtApePaterno.Enabled = true;
                        txtNombres.Enabled = true;
                        txtRazonSocial.Enabled = true;
                        txtApePaterno.Text = "";
                        txtApeMaterno.Text = ""; ;
                        txtNombres.Text = "";
                        txtRazonSocial.Text = "";
                        txtMonto.Text = "0";
                        txtComentarios.Text = "";
                        this.txtTelefono.Text = "";
                        this.txtNumcuotas.Text = "";
                        this.txtPeriodo.Text = "";
                        lblCalificaInterna.Text = "";
                        hdfIdCli.Value = "0";
                        hdfIdPresolciitud.Value = "0";
                    }
                }
            }

            if (lblMensaje.Text=="")
            {
                pnlMensaje.Visible = false;
            }
            else
            {
                pnlMensaje.Visible = true;
            }
            
            pnlConsulta.Visible = false;
            pnlPresolicitud.Visible = true;
            transaccion = Transaccion.Nuevo;
        }

        protected void BtnAtras1_Click(object sender, EventArgs e)
        {
            pnlMensaje.Visible = false;
            pnlReglas.Visible = false;
            pnlConsulta.Visible = true;
            pnlPresolicitud.Visible = false;
            BtnGrabar1.Visible = true;
            BtnNuevo1.Visible = true;
            hdfIdCli.Value = "0";
            hdfIdPresolciitud.Value = "0";
            rblTipoDocumento.SelectedValue = "1";
            txtDocumento.Text=String.Empty;
            txtDocumento.Enabled = true;
        }

        protected void click_Logo(object sender, EventArgs e)
        {
            if (objVarGlobal.User == null)
            {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                Response.Redirect("../frmInicio.aspx", true);
            }
            else
            {
                Response.Redirect("../frmMenu.aspx", true);
            }
        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProvincia();
            cargarDistrito();
            cargarComunidad();
        }

        protected void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDistrito();
            cargarComunidad();
        }

        protected void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComunidad();
        }

        protected void btnReglas_Click(object sender, EventArgs e)
        {
            registrarPreSolicitud();

            pnlPresolicitud.Visible = false;
            pnlMensaje.Visible = true;
            pnlInnerMsje.CssClass = "alert alert-success";
            limpiar();
        }

        protected void btnCancelar_OnClick(object sender, EventArgs e)
        {
            pnlReglas.Visible = false;
            pnlConsulta.Visible = true;
            pnlPresolicitud.Visible = false;
            BtnGrabar1.Visible = true;
            BtnNuevo1.Visible = true;
            hdfIdCli.Value = "0";
            hdfIdPresolciitud.Value = "0";
            rblTipoDocumento.SelectedValue = "1";
            txtDocumento.Text = String.Empty;
            txtDocumento.Enabled = true;
            lblMensaje.Text = String.Empty;
        }

        #endregion

        #region Métodos

        private void limpiar()
        {
            txtApeMaterno.Text = "";
            txtApePaterno.Text = "";
            txtComentarios.Text = "";
            txtDocumento.Text = "";
            txtMonto.Text = "";
            txtNombres.Text = "";
            txtNumcuotas.Text = "";
            txtPeriodo.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            rblMoneda.SelectedValue = "1";
            rblTipoDocumento.SelectedValue = "1";
        }

        private void registrarPreSolicitud()
        {
            #region Asignación de valores
            clsUsuario usuario = null;

            if (objVarGlobal.User != null)
            {
                usuario = objVarGlobal.User;
            }
            else
            {
                throw new Exception("La sesión de usuario terminó, vuelva a ingresar");
            }

            var clsvarglobal = objVarGlobal;

            var idEstado = 0;
            var nMontoSolicitado = Convert.ToDecimal(txtMonto.Text);
            var nCuotas = Convert.ToInt32(txtNumcuotas.Text);
            var nPlazoCuota = Convert.ToInt32(txtPeriodo.Text);
            var idTipoPeriodo = Convert.ToInt32(this.rblPeriodo.SelectedValue);
            var idTipoDocumento = Convert.ToInt32(this.rblTipoDocumento.SelectedValue);
            var idTipoCaptacion = 1;//Activa por defecto ya que es un registro desde campo
            var idMoneda = Convert.ToInt32(this.rblMoneda.SelectedValue);
            var cDocumento = txtDocumento.Text.Trim();
            var cNombreCompleto = txtRazonSocial.Text.Trim().ToUpper();
            var cApellidoPaterno = txtApePaterno.Text.Trim().ToUpper();
            var cApellidoMaterno = txtApeMaterno.Text.Trim().ToUpper();
            var cNombre = txtNombres.Text.Trim().ToUpper();
            var nNumeroTelefono = this.txtTelefono.Text.Trim();
            var cNumeroTelefono2 = txtCelular.Text.Trim();
            var idAgencia = usuario.idAgeCol;//Se almacena la agencia a la que pertenece el colaborador
            var dFechaRegistro = clsvarglobal.dFecSystem;
            var idUsuario = usuario.idUsuario;
            var cObservaciones = txtComentarios.Text.Trim();
            var idUbigeo = Convert.ToInt32(cboComunidad.SelectedValue);
            var cDireccion = txtDireccion.Text.Trim();

            #endregion

            string cMensaje = String.Empty;
            if (transaccion == Transaccion.Nuevo)
            {
                cnpresolicitud.CNInsertarPreSolicitud(idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo,
                    idTipoDocumento, idTipoCaptacion, Convert.ToInt32(hdfIdCli.Value), idMoneda, cDocumento, cNombreCompleto,
                    cApellidoPaterno, cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario,idUbigeo,cDireccion, cObservaciones);
                cMensaje = "Registro guardado correctamente.";

            }
            else if (transaccion == Transaccion.Edita)
            {
                cnpresolicitud.CNActualizarPreSolicitud(Convert.ToInt32(this.hdfIdPresolciitud.Value), idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo,
                    idTipoDocumento, idTipoCaptacion, Convert.ToInt32(hdfIdCli.Value), idMoneda, cDocumento, cNombreCompleto,
                    cApellidoPaterno, cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario, idUbigeo, cDireccion, cObservaciones);
                cMensaje = "Registro actualizado correctamente.";
            }
            pnlInnerMsje.CssClass = "alert alert-success";
            lblMensaje.Visible = true;
            lblMensaje.Text = cMensaje;
            BtnNuevo1.Visible = true;
        }

        private DataTable ArmarTablaParametros()
        {
            clsUsuario usuario = null;

            if (objVarGlobal.User != null)
            {
                usuario = objVarGlobal.User;
            }
            else
            {
                pnlMensaje.Visible = true;
                lblMensaje.Text = "La sesión termino, por favor vuelva a ingresar";
            }

            var clsvarglobal = objVarGlobal;

            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = "'" + txtDocumento.Text.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = usuario.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = usuario.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = hdfIdCli.Value;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsvarglobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = this.txtMonto.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = this.rblMoneda.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = txtNumcuotas.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.rblPeriodo.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = txtPeriodo.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUbigeoDir";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDireccion";
            drfila[1] = "'" + txtDireccion + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = clsvarglobal.cNomAge;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = "2";//web;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsvarglobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsvarglobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsvarglobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsvarglobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVigente";
            drfila[1] = clsvarglobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = "'" + usuario.dFechaIngreso.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = usuario.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = usuario.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = objVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = objVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = objVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = objVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = objVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = objVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = 1;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool cargarDatosPresolicitud()
        {
            var dtPreSolicitud = cnpresolicitud.ADBuscarPreSolicitud(Convert.ToInt32(this.rblTipoDocumento.SelectedValue), txtDocumento.Text.Trim());
            if (dtPreSolicitud.Rows.Count > 0)
            {
                hdfIdPresolciitud.Value = dtPreSolicitud.Rows[0]["idPreSolicitud"].ToString();
                txtMonto.Text = dtPreSolicitud.Rows[0]["nMontoSolicitado"].ToString();
                rblPeriodo.SelectedValue = Convert.ToString(dtPreSolicitud.Rows[0]["idTipoPeriodo"]);
                rblTipoDocumento.SelectedValue = Convert.ToString(dtPreSolicitud.Rows[0]["idTipoDocumento"]);
                rblMoneda.SelectedValue = Convert.ToString(dtPreSolicitud.Rows[0]["idMoneda"]);
                txtNumcuotas.Text = Convert.ToString(dtPreSolicitud.Rows[0]["nCuotas"]);
                txtPeriodo.Text = Convert.ToString(dtPreSolicitud.Rows[0]["nPlazoCuota"]);
                txtDocumento.Text = dtPreSolicitud.Rows[0]["cDocumento"].ToString();
                txtRazonSocial.Text = dtPreSolicitud.Rows[0]["cNombreCompleto"].ToString();
                txtApePaterno.Text = dtPreSolicitud.Rows[0]["cApellidoPaterno"].ToString();
                txtApeMaterno.Text = dtPreSolicitud.Rows[0]["cApellidoMaterno"].ToString();
                txtNombres.Text = dtPreSolicitud.Rows[0]["cNombre"].ToString();
                txtTelefono.Text = dtPreSolicitud.Rows[0]["nNumeroTelefono"].ToString();
                txtCelular.Text = dtPreSolicitud.Rows[0]["cNumeroTelefono2"].ToString();
                txtComentarios.Text = dtPreSolicitud.Rows[0]["cObservaciones"].ToString();
                hdfIdCli.Value = dtPreSolicitud.Rows[0]["idCli"] == DBNull.Value ? "0" : Convert.ToString(dtPreSolicitud.Rows[0]["idCli"]);
                txtDireccion.Text = dtPreSolicitud.Rows[0]["cdireccion"].ToString();

                var idUbigeo = Convert.ToInt32(dtPreSolicitud.Rows[0]["idUbigeo"]);
                cargarUbigeo(idUbigeo);
                BtnGrabar1.Visible = true;
                BtnNuevo1.Visible = false;
                pnlMensaje.Visible = true;
                pnlReglas.Visible = false;

                this.lblMensaje.Text = "Ya existe un registro de pre solicitud para el cliente, \n si desea puede modificar los datos de la pre solicitud";
                transaccion = Transaccion.Edita;
                pnlPresolicitud.Visible = true;
                pnlConsulta.Visible = false;

                txtDocumento.Enabled = false;
                txtApePaterno.Enabled = false;
                txtApeMaterno.Enabled = false;
                txtNombres.Enabled = false;
                txtTelefono.Enabled = false;
                txtCelular.Enabled = false;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;
                cboComunidad.Enabled = false;
                txtDireccion.Enabled = false;


                return true;
            }
            else
            {
                hdfIdCli.Value = "0";
                hdfIdCli.Value = "0";
                pnlPresolicitud.Visible = false;
                pnlConsulta.Visible = true;
                return false;
            }
        }

        private void cargarDepartamento()
        {           
            var dt = cnubigeo.listarUbigeo(173);
            cboDepartamento.DataSource = dt;            
            cboDepartamento.DataTextField= "cDescipcion";
            cboDepartamento.DataValueField = "idUbigeo";
            cboDepartamento.DataBind();
        }

        private void cargarProvincia()
        {
            if (cboDepartamento.SelectedIndex > -1)
            {
                int idUbigeo = Convert.ToInt32(cboDepartamento.SelectedValue);
                DataTable dt = retornaTablaVacia();
                if (idUbigeo>0)
                {
                    dt = cnubigeo.listarUbigeo(idUbigeo);
                }                
                cboProvincia.DataSource = dt;
                cboProvincia.DataTextField = "cDescipcion";
                cboProvincia.DataValueField = "idUbigeo";
                cboProvincia.DataBind();
            }
            else
            {
                DataTable dt = retornaTablaVacia();
                cboProvincia.DataSource = dt;
                cboProvincia.DataTextField = "cDescipcion";
                cboProvincia.DataValueField = "idUbigeo";
                cboProvincia.DataBind();
            }
        }

        private void cargarDistrito()
        {
            if (cboProvincia.SelectedIndex > -1)
            {
                int idUbigeo = Convert.ToInt32(cboProvincia.SelectedValue);
                DataTable dt = retornaTablaVacia();
                if (idUbigeo > 0)
                {
                    dt = cnubigeo.listarUbigeo(idUbigeo);
                } 
                cboDistrito.DataSource = dt;
                cboDistrito.DataTextField = "cDescipcion";
                cboDistrito.DataValueField = "idUbigeo";
                cboDistrito.DataBind();
            }
            else
            {
                DataTable dt = retornaTablaVacia();
                cboDistrito.DataSource = dt;
                cboDistrito.DataTextField = "cDescipcion";
                cboDistrito.DataValueField = "idUbigeo";
                cboDistrito.DataBind();
            }
        }

        private void cargarComunidad()
        {
            if (cboDistrito.SelectedIndex > -1)
            {
                int idUbigeo = Convert.ToInt32(cboDistrito.SelectedValue);
                DataTable dt = retornaTablaVacia();
                if (idUbigeo > 0)
                {
                    dt = cnubigeo.listarUbigeo(idUbigeo);
                } 
                cboComunidad.DataSource = dt;
                cboComunidad.DataTextField = "cDescipcion";
                cboComunidad.DataValueField = "idUbigeo";
                cboComunidad.DataBind();
            }
            else
            {
                DataTable dt = retornaTablaVacia();
                cboComunidad.DataSource = dt;
                cboComunidad.DataTextField = "cDescipcion";
                cboComunidad.DataValueField = "idUbigeo";
                cboComunidad.DataBind();
            }
        }

        private DataTable retornaTablaVacia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idUbigeo", typeof(int));
            dt.Columns.Add("cDescipcion", typeof(string));
            return dt;
        }

        public void cargarUbigeo(int idUbigeo)
        {
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetCliNat.RetUbiCli(idUbigeo);
            switch (tbDatUbi.Rows.Count)
            {
                case 0:
                    break;
                case 1:
                    //this.cboPais.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedIndex = -1;
                    break;
                case 2:
                    //this.cboPais.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    cargarProvincia();
                    cargarDistrito();
                    cargarComunidad();
                    this.cboProvincia.SelectedIndex = -1;
                    break;
                case 3:
                    //this.cboPais.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    cargarProvincia();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    cargarDistrito();
                    cargarComunidad();
                    this.cboDistrito.SelectedIndex = -1;
                    break;
                case 4:
                    //this.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboComunidad.SelectedIndex = -1;
                    break;
                case 5:
                    //this.cboPais.SelectedValue = tbDatUbi.Rows[4]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                    cargarProvincia();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    cargarDistrito();
                    this.cboDistrito.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    cargarComunidad();
                    this.cboComunidad.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    break;
            }
        }

        #endregion        
       
    }
}