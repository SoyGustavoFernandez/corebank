using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using ADM.CapaNegocio;


namespace SolIntEls
{
    public partial class frm_Inicio : frmBase
    {
        #region Variables

        clsCNError errorbll = new clsCNError();
        Error error = new Error();
        clsCNUsuarioSistema Usuario = new clsCNUsuarioSistema();
        clsUsuario UsuarioSys = new clsUsuario();
        clsCNSeguridad seguridad = new clsCNSeguridad();
        clsCNUsuario objUsu = new clsCNUsuario();
        clsCNGenVariables RetVar = new clsCNGenVariables();
        clsCNTablaXml cntablaxml = new clsCNTablaXml();
        clsCNConfigPlantillaImp cnConfigPlantImpr = new clsCNConfigPlantillaImp();

        public static string gcCodUsu, gcNomTer, gCodPerfil;
        public bool lEstado = false, lAutenticado = false;
        int nNroCar = 6;

        #endregion

        #region Eventos del formularios

        public frm_Inicio()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.lblNomFrm.Text = this.Name;
            lnkChangePass.TabStop = false;
        }

        private void frm_Inicio_Load(object sender, EventArgs e)
        {
            //ValidarActualizadorAbierto();
            //foreach (var item in Process.GetProcesses())
            //{
            //    if (item.MainWindowTitle.Contains("..:: Validación de Usuario ::..") || item.MainWindowTitle.Contains("..:: Core Bank"))
            //    {
            //        int nCount = 0;
            //        if (clsCNSeguridad.IsCurrentUserProcess(item.Id))
            //        {
            //            nCount++;
            //        }

            //        if (nCount > 1)
            //        {
            //            MessageBox.Show("El Sistema esta Activo.", "Información", MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            //            this.Dispose();
            //        }
            //    }
            //}
            //if (seguridad.VerEstActApl())
            //{
            //    MessageBox.Show("El Sistema esta Activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Dispose();
            //}
            //else
            //{
            LoadLogeo();
            lblTipCon.Text = new Uri(Assembly.GetExecutingAssembly().Location).IsUnc ? "Conexión: Remota" : "Conexión: Local";
            ArrayList arlConexion = clsCNGENConexion.leeXML();
            clsVarGlobal.nTipoAute = Convert.ToInt32(arlConexion[4]);
            clsVarGlobal.nTipoConexion = 0;
            //}


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Ingresar();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                    && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                    error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                    error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptarPass_Click(object sender, EventArgs e)
        {
            if (!ValidarContrase()) return;
            clsAutenticacion objAut = new clsAutenticacion();
            if (objAut.Autenticar(txtUsuario.Text, txtContAct.Text))
            {
                if (ChangePass())
                {
                    clsPassword.lCambioClave = true;
                    clsPassword.cUltimaClave = txtContAct.Text;
                    grbLogeo.Enabled = false;
                    grbChangPass.Enabled = true;
                    txtContNue.Enabled = false;
                    txtContNueCon.Enabled = false;
                    btnAceptarPass.Enabled = false;
                    string user = txtUsuario.Text;
                    LoadLogeo();
                    txtUsuario.Text = user;
                    txtContraseña.Focus();
                }
                else
                {
                    txtContNue.Text = "";
                    txtContNueCon.Text = "";
                    txtContNue.Focus();
                }
            }
            else
            {
                txtContAct.Text = "";
                txtContAct.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadLogeo();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text.Length > 0)
            {
                this.txtContraseña.Enabled = true;
                if (clsVarGlobal.nTipoAute == 2)
                {
                    //lnkChangePass.Visible = true;
                    pnlCambioPass.Visible = true;
                }
            }
            else
            {
                this.txtContraseña.Enabled = false;
                //lnkChangePass.Visible = false;
                pnlCambioPass.Visible = false;
            }

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (this.txtContraseña.Text.Length >= nNroCar)
            {
                this.btnAceptar.Enabled = true;
                txtContraseña.ForeColor = System.Drawing.Color.Blue;
            }

            else
            {
                this.btnAceptar.Enabled = false;
                txtContraseña.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void cboPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerfil.SelectedItem != null)
            {
                clsVarGlobal.PerfilUsu = (clsPerfilUsu)cboPerfil.SelectedItem;
            }
        }

        private void lnkChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadChangePass();
        }

        private void txtContAct_TextChanged(object sender, EventArgs e)
        {
            if (txtContAct.Text.Trim().Length < nNroCar)
            {

                txtContNue.Enabled = false;
                txtContNue.Text = "";
                txtContNueCon.Text = "";
                txtContNueCon.Enabled = false;
                btnAceptarPass.Enabled = false;
            }

            else
            {

                txtContNue.Enabled = true;
            }
        }

        private void txtContNue_TextChanged(object sender, EventArgs e)
        {
            if (txtContNue.Text.Trim().Length < nNroCar)
            {
                txtContNue.ForeColor = System.Drawing.Color.Red;
                txtContNueCon.Text = "";
                txtContNueCon.Enabled = false;
                btnAceptarPass.Enabled = false;
            }

            else
            {
                txtContNue.ForeColor = System.Drawing.Color.Blue;
                txtContNueCon.Enabled = true;

            }
        }

        private void txtContNueCon_TextChanged(object sender, EventArgs e)
        {
            if (txtContNueCon.Text.Trim().Length < nNroCar)
            {
                txtContNueCon.ForeColor = System.Drawing.Color.Red;
                btnAceptarPass.Enabled = false;
            }
            else
            {
                txtContNueCon.ForeColor = System.Drawing.Color.Blue;
                btnAceptarPass.Enabled = true;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtContraseña.Text.Trim().Length >= nNroCar && e.KeyCode == Keys.Enter)
            {
                try
                {

                    Ingresar();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                        error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                        error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cboPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboPerfil.SelectedItem != null && cboAgencias.SelectedItem != null && e.KeyCode == Keys.Enter)
            {
                try
                {

                    Ingresar();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                        error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                        error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedItem != null)
            {
                clsVarGlobal.nIdAgencia = ((clsAgencia)cboAgencias.SelectedItem).idAgencia;
                clsVarGlobal.cNomAge = ((clsAgencia)cboAgencias.SelectedItem).cNombreAge;
                clsVarGlobal.cCategoria = ((clsAgencia)cboAgencias.SelectedItem).cCategoria;
            }
        }

        private void cboAgencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboPerfil.SelectedItem != null && cboAgencias.SelectedItem != null && e.KeyCode == Keys.Enter)
            {
                try
                {

                    Ingresar();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                        error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                    if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
                   && ex.Source == ".Net SqlClient Data Provider")
                    {
                        MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                        error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                        errorbll.RegistrarError(error);
                        MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Cambio de clave
        /// </summary>
        /// <returns></returns>
        private bool ChangePass()
        {
            return objUsu.ChangePassword(txtUsuario.Text, txtContAct.Text, txtContNue.Text, txtContNueCon.Text);
        }

        /// <summary>
        /// cargar cambio de clave
        /// </summary>
        private void LoadChangePass()
        {
            pnlChangePass.Visible = true;
            grbLogeo.Enabled = false;
            grbChangPass.Enabled = true;
            txtContNue.Enabled = false;
            txtContNueCon.Enabled = false;
            btnAceptarPass.Enabled = false;
            txtContAct.Text = String.Empty;
            txtContNue.Text = String.Empty;
            txtContNueCon.Text = String.Empty;
            txtContAct.Focus();
        }

        /// <summary>
        /// Cargar logueo
        /// </summary>
        private void LoadLogeo()
        {
            pnlPerfil.Visible = false;
            pnlAgencia.Visible = false;
            pnlChangePass.Visible = false;
            pnlCambioPass.Visible = false;
            lblMessagePerfil.Text = " * Asigne un perfil al Usuario";
            lblMessageAgencia.Text = " * Seleccione la agencia del sistema.";
            cboPerfil.ValueMember = "idPerfilUsu";
            cboPerfil.DisplayMember = "cPerfil";
            cboAgencias.ValueMember = "idAgencia";
            cboAgencias.DisplayMember = "cNombreAge";
            txtContraseña.Enabled = false;
            //lnkChangePass.Visible = false;
            grbLogeo.Enabled = true;
            txtUsuario.Text = "";
            txtUsuario.Enabled = true;
            txtContraseña.Text = "";
            txtUsuario.Focus();
            lAutenticado = false;
            //btnAceptar.Focus();
            //btnAceptar.Select();

            pnlConexion.Visible = false;
            cboTipoConexion.Items.Insert(0, "CoreBank");
            cboTipoConexion.Items.Insert(1, "CoreBank de Contingencia");
            cboTipoConexion.SelectedIndex = 0;
        }

        /// <summary>
        /// Validar Version del Sistema
        /// </summary>
        /// <returns></returns>
        public string ValidarVersion()
        {
            string cRpta = "OK";
            int nVersion = Convert.ToInt32(RetVar.RetornaVariable("cVersionSis", 0));
            int lIndActualizar = Convert.ToInt32(RetVar.RetornaVariable("lIndActualizar", clsVarGlobal.nIdAgencia));
            int nVersionActual = Convert.ToInt32(File.ReadAllText(clsVarGlobal.cRutPathApp + @"\version.txt"));

            if (nVersionActual != nVersion)
            {
                MessageBox.Show("La versión del Sistema no esta Actualizado \n Por favor ejecute Actualizador de Corebank", "Validar la Versión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            if (lIndActualizar == 1)
            {
                MessageBox.Show("El Sistema requiere actualización \n Por favor ejecute Actualizador de Corebank", "Validar la Versión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        /// <summary>
        /// Validar La Agencia al que Pertenece
        /// </summary>
        /// <returns></returns>
        public string ValidaAgencia()
        {
            string cRpta = "OK";
            if (clsVarGlobal.nIdAgencia != clsVarGlobal.User.idAgeCol)
            {
                MessageBox.Show("El Colaborador Pertenece a Otra Agencia", "Validar Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        /// <summary>
        /// Metodo que realiza el ingreso al sistema (validaciones)
        /// </summary>
        private void Ingresar()
        {
            clsAutenticacion objAut = new clsAutenticacion();
            Usuario.CodigoAD = txtUsuario.Text.Trim();
            Usuario.clave = txtContraseña.Text.Trim();

            if (!lAutenticado)
            {
                if (objAut.Autenticar(Usuario.CodigoAD, Usuario.clave))
                {
                    if ((!clsVarGlobal.User.lChangePass && clsVarGlobal.nTipoAute == 2) || clsVarGlobal.nTipoAute == 1)
                    {
                        var lCambiar = false;
                        if (clsVarGlobal.User.nDiasExpiracionSQL != null && clsVarGlobal.User.nDiasExpiracionSQL <= 2)
                        {
                            MessageBox.Show("Su contraseña expirará en " + clsVarGlobal.User.nDiasExpiracionSQL + " día(s), es necesario que usted cambie su contraseña antes de continuar.", "Expiración de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadChangePass();
                            lCambiar = true;
                        }
                        else if (clsVarGlobal.User.nDiasExpiracionSQL != null && clsVarGlobal.User.nDiasExpiracionSQL <= 5)
                        {
                            var Msg = MessageBox.Show("Su contraseña expirará en " + clsVarGlobal.User.nDiasExpiracionSQL + " días. ¿Desea cambiarlo ahora?", "Expiración de Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Msg == DialogResult.Yes)
                            {
                                LoadChangePass();
                                lCambiar = true;
                            }
                        }
                        if (!lCambiar)
                        {
                            // Validación si el servidor alterno esta habilidato
                            int nConexionAlterna = Convert.ToInt32(RetVar.RetornaVariable("lConexionAlterna", 0));
                            if (Convert.ToInt32(cboTipoConexion.SelectedIndex) == 1 && nConexionAlterna == 0)
                            {
                                MessageBox.Show("El servidor alterno no se encuentra habilitado. Comuníquese con el Administrador.",
                                                "Validación de conexión alterna",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                return;
                            }

                            clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();
                            List<clsPerfilUsu> lisPerfiles = new List<clsPerfilUsu>();
                            List<clsAgencia> lstAgencias = new List<clsAgencia>();
                            lstAgencias = new clsCNAgenciaUsu().CNListarAgenciasUsuario(clsVarGlobal.User.idUsuario);
                            lisPerfiles = Perfiles.ListarPerUsu(clsVarGlobal.User.idUsuario);
                            cboAgencias.DataSource = lstAgencias;
                            cboPerfil.DataSource = lisPerfiles;
                            clsVarGlobal.PerfilUsu = null;

                            if (lstAgencias.Count() > 1)
                            {
                                pnlAgencia.Visible = true;
                                cboAgencias.SelectedValue = -1;
                                txtUsuario.Enabled = false;
                                txtContraseña.Enabled = false;
                                clsVarGlobal.nIdAgencia = 0;
                            }
                            else
                            {
                                if (lstAgencias.Count > 0)
                                {
                                    clsVarGlobal.nIdAgencia = lstAgencias[0].idAgencia;
                                    clsVarGlobal.cNomAge = lstAgencias[0].cNombreAge;
                                    clsVarGlobal.cCategoria = lstAgencias[0].cCategoria;
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no tiene acceso a ninguna agencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            if (lisPerfiles.Count() > 1)
                            {
                                pnlPerfil.Visible = true;
                                cboPerfil.SelectedValue = -1;
                                txtUsuario.Enabled = false;
                                txtContraseña.Enabled = false;
                            }
                            else
                            {
                                if (lisPerfiles.Count > 0)
                                {
                                    clsVarGlobal.PerfilUsu = lisPerfiles[0];
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no tiene perfil asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                            }
                            lAutenticado = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("CAMBIO DE CONTRASEÑA" + Environment.NewLine +
                         "Es necesario que usted cambie su contraseña por alguna de las siguientes razones: Está ingresando por primera vez al Core Bank, o su contraseña ha caducado por políticas de privacidad y seguridad de la información." + Environment.NewLine +
                          "" + Environment.NewLine + "¡RECUERDE QUE SU CONTRASEÑA ES DE USO PERSONAL!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadChangePass();
                    }

                }
                else
                {
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Focus();
                    return;
                }
            }

            new clsCNVarGen().LisVar(clsVarGlobal.nIdAgencia);
            new clsCNVarApl().LisVar(clsVarGlobal.nIdAgencia); //revisar
            clsVarGlobal.nVersion = Convert.ToInt32(clsVarApl.dicVarGen["cVersionSis"]);

            string cIdentificadorPC = new clsFunUtiles().obtenerIdentificadorPC();
            DataTable dtDatPc = cnConfigPlantImpr.CNObtenerRegistroPC(cIdentificadorPC);
            clsVarGlobal.idTipoPlantillaImpresion = (dtDatPc.Rows.Count > 0) ? Convert.ToInt32(dtDatPc.Rows[0]["idTipoPlantillaImpresion"]) : 1;
            clsVarGlobal.idRegistroPC = (dtDatPc.Rows.Count > 0) ? Convert.ToInt32(dtDatPc.Rows[0]["idRegistro"]) : 0;
            if (!objAut.validarLicencia())
            {
                MessageBox.Show("Por favor comuníquese con un representante de SolIntElS para obtener la licencia del software.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }


            ///===============================================
            ///--Validar la Versión del Sistema
            ///===============================================
            //if (clsVarGlobal.nIdAgencia > 0)
            //{
            //    if (ValidarVersion() == "ERROR")
            //    {
            //        this.Dispose();
            //        return;
            //    }
            //}

            //if (!ValidarVersionAssemblies())
            //{
            //    this.Dispose();
            //    return;
            //}


            //===============================================
            //--Validar Agencia al que Pertenece
            //===============================================
            //if (ValidaAgencia() == "ERROR")
            //{
            //    this.Dispose();
            //    return;
            //}

            if (!validarDatPc())
            {
                this.Dispose();
                return;
            }

            if (lAutenticado && clsVarGlobal.PerfilUsu != null && clsVarGlobal.nIdAgencia > 0)
            {
                //clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();
                //if (clsVarGlobal.PerfilUsu.lLimCobertura)
                //{
                //    List<clsLimCobertura> listMontoCobertur = new List<clsLimCobertura>();
                //    listMontoCobertur = Perfiles.limiteCobertura(1, clsVarGlobal.nIdAgencia);
                //    clsVarGlobal.montoCobertura = listMontoCobertur[0];
                //}

                this.Hide();
                this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Ingreso al sistema", this.btnAceptar);
                frmContenedorNue frmPrincipal = new frmContenedorNue(this);
                frmPrincipal.Show();
                cntablaxml.actualizarTablas();

            }
            else if (lAutenticado)
            {
                if (pnlAgencia.Visible)
                {
                    cboAgencias.Focus();
                    return;
                }

                if (pnlPerfil.Visible)
                {
                    cboPerfil.Focus();
                    return;
                }
            }
        }

        /// <summary>
        /// Validacion de pc autorizadas para el uso del sistema
        /// </summary>
        private bool validarDatPc()
        {
            //if (!new clsPcUsuario().validarDatosPc())
            //{
            //    MessageBox.Show("Esta computadora no esta autorizada para ejecutar Core bank",
            //                        "Validar Registro de PC",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);
            //    // this.Dispose();
            //    return false;
            //}
            return true;

        }

        /// <summary>
        /// Valida si el actualizador se encuentra abierto
        /// </summary>
        private void ValidarActualizadorAbierto()
        {
            var processActualiza = Process.GetProcesses().Where(x => x.ProcessName.ToLower().Equals("corebankactualiza"));
            if (processActualiza.Any())
            {
                string cMensaje = "El actualizador se encuentra activo. No se puede iniciar el Core Bank mientras se actualiza.";
                MessageBox.Show(cMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        /// <summary>
        /// Valida que la contraseña actual y la nueva contraseña sean distintas.
        /// </summary>
        /// <returns>true -> si las contraseñas son distintas
        ///          false -> si las contraseñas son iguales</returns>
        private bool ValidarContrase()
        {
            if (string.IsNullOrEmpty(txtContNue.Text.Trim()) || string.IsNullOrEmpty(txtContNueCon.Text.Trim()))
            {
                MessageBox.Show("La nueva contraseña no pueden estar en blanco.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtContNue.Text.Trim().Equals(txtContAct.Text.Trim()))
            {
                MessageBox.Show("Las contraseña nueva no puede ser igual a la contraseña actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtContNue.Text.Trim().Length > 128)
            {
                MessageBox.Show("Las contraseña no puede exceder los 128 caracteres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            string cClave = txtContNue.Text.Trim();
            string cCaracteres = "";
            for (int i = 0; i < cClave.Length; i++)
            {
                if ((int)cClave[i] > 255)
                    cCaracteres += cClave[i];
            }
            if (cCaracteres.Length > 0)
            {
                MessageBox.Show("La contraseña contiene algún caracter no permitido. " + cCaracteres, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida la versión de los archivos del assemblies
        /// </summary>
        /// <returns>true -> si todos las versión de todos los assemblies coincide con las versiones de
        ///                     la base de datos
        ///          false -> si existen archivos no actualizados</returns>
        private bool ValidarVersionAssemblies()
        {
            List<clsAssembly> lstAssembliesDB = new clsCNMantAssemblies().GetAssembliesInfoDB();

            string cRutaEjecucion = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(cRutaEjecucion).Where(x => x.EndsWith(".dll") || x.EndsWith(".exe"));

            List<clsAssembly> lstAssemblies = new List<clsAssembly>();

            foreach (var file in files)
            {
                //Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file);
                AssemblyName assembly = AssemblyName.GetAssemblyName(file);

                clsAssembly objAssembly = new clsAssembly();
                objAssembly.cNomAssembly = assembly.Name;

                objAssembly.cVersion = FileVersionInfo.GetVersionInfo(file).FileVersion;

                lstAssemblies.Add(objAssembly);
            }

            List<clsAssembly> lstNoActualizados = (from assemblyDB in lstAssembliesDB
                                                   from assemlyLocal in lstAssemblies
                                             .Where(x => x.cNomAssembly == assemblyDB.cNomAssembly
                                                         && x.cVersion == assemblyDB.cVersion).DefaultIfEmpty().
                                             Where(x => x == null)
                                                   select assemblyDB).ToList();

            StringBuilder sbArchivos = new StringBuilder();

            foreach (var fileNoAct in lstNoActualizados)
            {
                sbArchivos.AppendFormat("{0}\n", fileNoAct.cNomAssembly);
            }


            if (lstNoActualizados.Any())
            {
                MessageBox.Show("El sistema no se encuentra actualizado. Por favor ejecute el actualizador del Core Bank. " +
                                "Los siguientes archivos no están actualizados:\n" + sbArchivos.ToString(),
                                "Validar la versión del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'n' - 96 && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                pnlConexion.Visible = true;
            }
        }

        private void cboTipoConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoConexion.SelectedIndex) == 1)
            {
                DialogResult drResult = MessageBox.Show("El cambio de conexión al servidor de contingencia esta designado a determinados usuarios para realizar sus operaciones y/o procesos con normalidad, evítese de llamadas de atención y/o sanciones si no se le comunicó para hacer uso de esta funcionalidad. Al presionar 'Aceptar' confirmo tener conocimiento y realizar el cambio de conexión al servidor alterno.", "Validación de conexión de contingencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (drResult == DialogResult.OK)
                {
                    clsVarGlobal.nTipoConexion = Convert.ToInt32(cboTipoConexion.SelectedIndex);
                }
                else
                {
                    cboTipoConexion.SelectedIndex = 0;
                    clsVarGlobal.nTipoConexion = 0;
                }
            }
            else
            {
                clsVarGlobal.nTipoConexion = 0;
            }
        }
    }
}
