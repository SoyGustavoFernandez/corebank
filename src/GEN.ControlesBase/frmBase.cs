using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using GEN.BotonesBase;
using System.Reflection;
using ADM.CapaNegocio;
using System.Text.RegularExpressions;

namespace GEN.ControlesBase
{
    public partial class frmBase : Form
    {
        #region Variables
        clsCNFormulario objform = new clsCNFormulario();
        clsFormulario form = new clsFormulario();
        clslisControl controles = new clslisControl();
        clsCNImpresion objImpresion = new clsCNImpresion();
        clsCNBuscarCli ValidaCliBN = new clsCNBuscarCli();
        int nNumImpresion, idKardexRelacionado, idModuloRel, idTipoOperel, idEstadoCuenta;
        public static bool lindicaEjecucion = false;
        string cPlantillaCliente = "";
        public Semaforo objFrmSemaforo;
        public bool lBloqueaBusquedaNombre = false;

        #endregion

        public frmBase()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!designMode)
                Load += FormLoad_ControlObjectos;
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.lblNomFrm.Text = this.Name;
            this.StartPosition = FormStartPosition.CenterScreen;
            

            AddEventControls();
        }

        private void AddEventControls()
        {
            IEnumerable<Boton> enumBtnNuevo = GetAllControlsOfType<btnNuevo>(this);
            IEnumerable<Boton> enumBtnEditar = GetAllControlsOfType<btnEditar>(this);
            IEnumerable<Boton> enumBtnCancelar = GetAllControlsOfType<btnCancelar>(this);
            IEnumerable<Boton> enumBtnGrabar = GetAllControlsOfType<btnGrabar>(this);
            IEnumerable<Boton> enumBtnImprimir = GetAllControlsOfType<btnImprimir>(this);

            IEnumerable<Boton> enumBotones = enumBtnNuevo.Union(enumBtnEditar)
                                                            .Union(enumBtnCancelar)
                                                            .Union(enumBtnGrabar)
                                                            .Union(enumBtnImprimir);

            foreach (var btn in enumBotones)
            {
                EventInfo evClick = typeof(Boton).GetEvent("Click");
                Type tDelegate = evClick.EventHandlerType;
                MethodInfo miHandler = typeof(frmBase).GetMethod("Click_ControlObjectos", BindingFlags.NonPublic | BindingFlags.Instance);
                Delegate d = Delegate.CreateDelegate(tDelegate, this, miHandler);
                MethodInfo addHandler = evClick.GetAddMethod();
                object[] addHandlerArgs = { d };
                addHandler.Invoke(btn, addHandlerArgs);
            }
        }

        protected void FormLoad_ControlObjectos(object sender, EventArgs e)
        {
            if (Name.Equals("frm_Inicio") || Name.Equals("frmContenedorNue"))
                return;

            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        protected void Click_ControlObjectos(object sender, EventArgs e)
        {
            if (Name.Equals("frm_Inicio") || Name.Equals("frmContenedorNue"))
                return;
            if (sender is btnNuevo)
                activarControlObjetos(this, EventoFormulario.NUEVO);
            else if (sender is btnEditar)
                activarControlObjetos(this, EventoFormulario.EDITAR);
            else if (sender is btnCancelar)
                activarControlObjetos(this, EventoFormulario.CANCELAR);
            else if (sender is btnImprimir)
                activarControlObjetos(this, EventoFormulario.IMPRIMIR);
            else if (sender is btnGrabar)
                activarControlObjetos(this, EventoFormulario.GRABAR);
        }

        public bool ValidaCliBaseNegativa(string x_cNroDocumento, int x_idModulo, bool lBaseNegativa)
        {
            if (ValidaCliBN.ValidaCliBaseNegativa(x_cNroDocumento, x_idModulo, lBaseNegativa))
            {
                return true;
            }
            return false;
        }


        public string ValidarInicioOpe()
        {
            if (!clsVarGlobal.PerfilUsu.lResVentanilla)
            {
                MessageBox.Show("Debe ser responsable de ventanilla para realizar esta operación.", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";
            }
            if (!clsVarGlobal.PerfilUsu.lLimCobertura)
            {
                MessageBox.Show("Debe asignar los montos del límite de cobertura para VENTANILLA", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";
            }
            string cResp = ValidarBilletaje(1, clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), "Ya registró su billetaje,");
            if (cResp.Equals("R"))
            {
                return cResp;
            }

            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, 1);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            {
                case "F":
                    MessageBox.Show("Falta realizar el inicio de Operaciones \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Dispose();
                    break;
            }

            return cEstCie;
        }

        public string ValidarSistema()
        {
            string cRpta = "OK";
            clsCNGenVariables RetVar = new clsCNGenVariables();
            string cfecha = RetVar.RetornaVariable("dFechaAct", clsVarGlobal.nIdAgencia).Trim();
            if (clsVarGlobal.dFecSystem != Convert.ToDateTime(cfecha))
            {
                MessageBox.Show("La fecha actual es distinto al del sistema", "Validar el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            return cRpta;
        }

        //public bool ActualizarSaldo(int idUsuario, int idAgencia, int idTipoMoneda, int IdTipoTransac_I_E, Decimal nMontoOperacion)
        //{
        //    if (!clsVarGlobal.PerfilUsu.lLimCobertura)
        //    {
        //        MessageBox.Show("PERFIL NO TIENE ASIGNADO ..." + "\r\n" + "CONTROL DE LIMITE DE COBERTURA", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    if (clsVarGlobal.montoCobertura.nMonMinCobertura <= 0)
        //    {
        //        MessageBox.Show("DEBE ASIGNAR LOS ..." + "\r\n" + "MONTOS DEL LIMITE DE COBERTURA", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    //Valida si esta Permitido la ejeccion de la operacion
        //    if (clsVarGlobal.lFlagPermiteOperacion == false)
        //    {
        //        MessageBox.Show("NO PUEDE REALIZAR OPERACIÓN..." + "\r\n" + "SU SALDO ESTÁ EN LIMITES DE ALTO RIESGO", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    decimal nSaldoAnterio = 0;
        //    decimal nNuevoSaldo = 0;

        //    //Obtener Saldo Anterior
        //    clsCNGenAdmOpe cnSaldo = new clsCNGenAdmOpe();
        //    DataTable tbSaldo = cnSaldo.RetornaSaldoOperadorAge(clsVarGlobal.dFecSystem, idUsuario, clsVarGlobal.nIdAgencia);

        //    if (tbSaldo.Rows.Count > 0)
        //    {
        //        if (idTipoMoneda == 1)
        //        {
        //            nSaldoAnterio = Convert.ToDecimal(tbSaldo.Rows[0]["nSalSoles"].ToString());
        //        }
        //        else
        //        {
        //            nSaldoAnterio = Convert.ToDecimal(tbSaldo.Rows[0]["nSalDolar"].ToString());
        //        }
        //    }

        //    //Nuevo Saldo
        //    nNuevoSaldo = (IdTipoTransac_I_E == 1) ? (/*Convert.ToDecimal*/(nMontoOperacion) + nSaldoAnterio) : (nSaldoAnterio - /*Convert.ToDecimal*/(nMontoOperacion));
        //    if (nNuevoSaldo < 0 && IdTipoTransac_I_E == 2)
        //    {
        //        MessageBox.Show("Efectivo insuficiente para la operación...", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    else
        //    {
        //        clsCNGenVariables RetVar = new clsCNGenVariables();
        //        DateTime fecha = clsVarGlobal.dFecSystem;
        //        RetVar.ActualizarSaldo(idAgencia, idUsuario, fecha, idTipoMoneda, IdTipoTransac_I_E, /*Convert.ToDecimal*/(nMontoOperacion));
        //    }
        //    lindicaEjecucion = true;
        //    return false;
        //}

        public string ValidarBilletaje(int idTipResCaja, DateTime dtFecSis, int idUsuario, string cMensaje)
        {
            string cRpta = "OK";

            clsCNControlOpe ValCorFra = new clsCNControlOpe();

            string cCorFra = ValCorFra.ValidaCorteFraccCaja(dtFecSis, idUsuario, clsVarGlobal.nIdAgencia, idTipResCaja);

            if (cCorFra != "0")
            {
                MessageBox.Show(cMensaje + " \n Primero debe activar para realizar operaciones...", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "R";
            }

            return cRpta;
        }

        public string ValidarInicioOpeSoloCaja()
        {
            if (!clsVarGlobal.PerfilUsu.lResVentanilla)
            {
                MessageBox.Show("Debe ser responsable de ventanilla para realizar esta operación.", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";
            }
            if (!clsVarGlobal.PerfilUsu.lLimCobertura)
            {
                MessageBox.Show("Debe asignar los montos del límite de cobertura para VENTANILLA", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";

            }

            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, 1);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            {
                case "F":
                    MessageBox.Show("Falta realizar el inicio de Operaciones \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Dispose();
                    break;
            }

            return cEstCie;
        }

        public bool ValidaSaldoLinea(int idUsuario, int idAgencia, int idTipoMoneda, int IdTipoTransac_I_E, Decimal nMontoOperacion)
        {
            if (!clsVarGlobal.PerfilUsu.lLimCobertura)
            {
                MessageBox.Show("USUARIO NO TIENE ASIGNADO ..." + "\r\n" + "CONTROL DE LIMITE DE COBERTURA", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (clsVarGlobal.montoCobertura.nMonMinCobertura <= 0)
            {
                MessageBox.Show("DEBE ASIGNAR LOS ..." + "\r\n" + "MONTOS DEL LIMITE DE COBERTURA", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            //Valida si esta Permitido la ejecucion de la operacion
            if (clsVarGlobal.lFlagPermiteOperacion == false)
            {
                MessageBox.Show("NO PUEDE REALIZAR OPERACIÓN..." + "\r\n" + "SU SALDO ESTÁ EN LIMITES DE ALTO RIESGO", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            decimal nSaldoAnterio = 0;
            decimal nNuevoSaldo = 0;

            //Obtener Saldo Anterior
            clsCNGenAdmOpe cnSaldo = new clsCNGenAdmOpe();
            DataTable tbSaldo = cnSaldo.RetornaSaldoOperadorAge(clsVarGlobal.dFecSystem, idUsuario, clsVarGlobal.nIdAgencia);

            if (tbSaldo.Rows.Count > 0)
            {
                if (idTipoMoneda == 1)
                {
                    nSaldoAnterio = Convert.ToDecimal(tbSaldo.Rows[0]["nSalSoles"].ToString());
                }
                else
                {
                    nSaldoAnterio = Convert.ToDecimal(tbSaldo.Rows[0]["nSalDolar"].ToString());
                }
            }

            //Nuevo Saldo
            nNuevoSaldo = (IdTipoTransac_I_E == 1) ? (nMontoOperacion + nSaldoAnterio) : (nSaldoAnterio - nMontoOperacion);
            if (nNuevoSaldo < 0 && IdTipoTransac_I_E == 2)
            {
                MessageBox.Show("Efectivo insuficiente para la operación...", "Validar Saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            lindicaEjecucion = true;
            return false;
        }

        public void ActualizaSaldoLinea(int idUsuario, int idTipoMoneda, int IdTipoTransac_I_E, Decimal nMontoTrx)
            {
                clsCNGenVariables RetVar = new clsCNGenVariables();
                DateTime fecha = clsVarGlobal.dFecSystem;
                int idAge = clsVarGlobal.nIdAgencia;
                int nRespuesta = 0;
                nRespuesta = RetVar.ActualizarSaldo(idAge, idUsuario, fecha, idTipoMoneda, IdTipoTransac_I_E, nMontoTrx);
                int nConteo = 0;
            while (nRespuesta == 0 && nConteo < 5)//actualiza mientras exista error.
                {
                    nRespuesta = RetVar.ActualizarSaldo(idAge, idUsuario, fecha, idTipoMoneda, IdTipoTransac_I_E, Convert.ToDecimal(nMontoTrx));
                    nConteo++;
                }

                objFrmSemaforo.ValidarSaldoSemaforo();
            }

        public void habilitarControles(grbBase migbx, bool lval)
        {
            foreach (Control miControl in migbx.Controls)
            {
                if (miControl is TextBoxBase || miControl is cboBase || miControl is DateTimePicker || miControl is RadioButton)
                {
                    miControl.Enabled = lval;
                }
            }
        }

        /// <summary>
        /// Habilita el control de objetos
        /// </summary>
        /// <param name="frmControl">formulario a ser controlado</param>
        /// <param name="idTipoEvento">tipo de evento: 1 --> inicio 2--> nuevo 3--> editar 4--> cancelar 5-->grabar 6-->imprimir</param>
        public void activarControlObjetos(Control frmControl, EventoFormulario idTipoEvento)
        {
            EstadoFormulario estadoform = objform.validarRegFormulario(frmControl.Name);

            recorrerControles(frmControl);

            if (estadoform == EstadoFormulario.NoRegistradoBD)
            {
                form.cFormulario = frmControl.Name;
                form.lisControles = controles;
                form.idModulo = clsVarGlobal.idModulo;
                objform.insertarControles(form);
            }
            else if (estadoform == EstadoFormulario.Actualizar)
            {
                objform.actualizarControles(form);
            }

            clslisControl liscontrolesperfil = objform.listarcontrolesByPerfil(frmControl.Name, clsVarGlobal.PerfilUsu.idPerfil, (int)idTipoEvento);
            habilitar(liscontrolesperfil);
        }

        private void recorrerControles(Control frmControl)
        {
            foreach (Control c in frmControl.Controls)
            {
                if (c.Name != "")
                    controles.Add(new clsControl() { cControl = c.Name, control = c });

                if (c.Controls.Count > 0)
                    recorrerControles(c);
            }
        }

        private void habilitar(clslisControl controlesperfil)
        {

            var lista = (from x in controlesperfil
                         join y in controles
                         on x.cControl equals y.cControl
                         select new { y.control, x });

            foreach (var item in lista)
            {

                switch (item.x.idEstado)
                {

                    case 1:
                        item.control.Visible = false;
                        break;
                    case 2:
                        item.control.Visible = true;
                        break;
                    case 3:
                        item.control.Enabled = false;
                        break;
                    case 4:
                        item.control.Enabled = true;
                        break;
                }

            }
        }

        /// <summary>
        /// Realiza la sobrecarga para utilizar los comandos F3 y F4
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                Process procCalculadora = new Process();
                procCalculadora.StartInfo.FileName = @"calc.exe";
                procCalculadora.Start();
                procCalculadora.WaitForExit();
                return true;
            }
            if (keyData == Keys.F12)
            {
                PrintDialog impre = new PrintDialog();
                impre.ShowDialog();
                return true;
            }
            if (keyData == Keys.F1)
            {
                string cRuta = clsVarGlobal.cRutPathApp + @"\HelpCoreBank.chm";
                Help.ShowHelp(this, cRuta);

                return true;
            }

            if (keyData == Keys.F3)
            {
                #region Búsquedas

                IEnumerable<ConBusCli> enumConBusCli = GetAllControlsOfType<ConBusCli>(this);
                IEnumerable<ConBusCuentaCli> enumConBusCuentaCli = GetAllControlsOfType<ConBusCuentaCli>(this);
                IEnumerable<conBusCtaAho> enumConBusCtaAho = GetAllControlsOfType<conBusCtaAho>(this);

                if (enumConBusCli.Count() == 1 && !enumConBusCuentaCli.Any() && !enumConBusCtaAho.Any())
                {
                    (enumConBusCli.First()).btnBusCliente.PerformClick();
                    return true;
                }

                if (!enumConBusCli.Any() && enumConBusCuentaCli.Count() == 1 && !enumConBusCtaAho.Any())
                {
                    (enumConBusCuentaCli.First()).btnBusCliente1.PerformClick();
                    return true;
                }

                if (!enumConBusCli.Any() && !enumConBusCuentaCli.Any() && enumConBusCtaAho.Count() == 1)
                {
                    (enumConBusCtaAho.First()).btnBusCliente.PerformClick();
                    return true;
                }

                if (enumConBusCli.Any(x => x.Parent == this))
                {
                    (enumConBusCli.First(x => x.Parent == this)).btnBusCliente.PerformClick();
                    return true;
                }

                if (enumConBusCuentaCli.Any(x => x.Parent == this))
                {
                    (enumConBusCuentaCli.First()).btnBusCliente1.PerformClick();
                    return true;
                }
                if (enumConBusCtaAho.Any(x => x.Parent == this))
                {
                    (enumConBusCtaAho.First()).btnBusCliente.PerformClick();
                    return true;
                }

                #endregion

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// metodo para almacenar los eventos del usuario con el fin de saber a que opciones y eventos ingreso
        /// </summary>
        /// <param name="idCli">id del cliente, si no se tiene enviar 0</param>
        /// <param name="idCuenta">id de la cuenta, si no te tiene enviar 0</param>
        /// <param name="cDescripcion">descripcion de la accion y evento realizado</param>
        /// <param name="control">control donde se ejecuta la accion; Ejm: botongrabar1</param>
        public void registrarRastreo(int idCli, int idCuenta, string cDescripcion, Control control, string cDocumentoID = "")
        {
            GEN.Funciones.clsFunUtiles funcion = new Funciones.clsFunUtiles();

            clsRastreo objrastreo = new clsRastreo();

            objrastreo.idCuenta = idCuenta;
            objrastreo.idCli = idCli;
            objrastreo.idMenu = clsVarGlobal.idMenu;
            objrastreo.idModulo = clsVarGlobal.idModulo;
            objrastreo.idUsuReg = clsVarGlobal.User.idUsuario;
            objrastreo.cAccion = cDescripcion;
            objrastreo.cCodMac = funcion.obtenerMac();
            objrastreo.cControl = control.Name;
            objrastreo.cNomTerminal = funcion.obtenerNomPc();
            objrastreo.dFechaSis = clsVarGlobal.dFecSystem;
            objrastreo.dFechaReg = clsVarGlobal.dFecSystem;
            objrastreo.cFormulario = this.Name;
            objrastreo.idAgencia = clsVarGlobal.nIdAgencia;
            objrastreo.cDocumentoID = cDocumentoID;
            objrastreo.cIPUsuarioNET = funcion.obtenerIPUsuario();

            new clsCNRastreo().insertarRastreo(objrastreo);
        }

       public void registrarRastreoPosicionConsolidada(int idCli, int idCuenta, string cDescripcion, Control control, string cDocumentoID = "")
        {
            GEN.Funciones.clsFunUtiles funcion = new Funciones.clsFunUtiles();

            clsRastreo objrastreo = new clsRastreo();

            objrastreo.idCuenta = idCuenta;
            objrastreo.idCli = idCli;
            objrastreo.idMenu = clsVarGlobal.idMenu;
            objrastreo.idModulo = clsVarGlobal.idModulo;
            objrastreo.idUsuReg = clsVarGlobal.User.idUsuario;
            objrastreo.cAccion = cDescripcion;
            objrastreo.cCodMac = funcion.obtenerMac();
            objrastreo.cControl = control.Name;
            objrastreo.cNomTerminal = funcion.obtenerNomPc();
            objrastreo.dFechaSis = clsVarGlobal.dFecSystem;
            objrastreo.dFechaReg = clsVarGlobal.dFecSystem;
            objrastreo.cFormulario = this.Name;
            objrastreo.idAgencia = clsVarGlobal.nIdAgencia;
            objrastreo.cDocumentoID = cDocumentoID;
            objrastreo.cIPUsuarioNET = funcion.obtenerIPUsuario();

            new clsCNRastreo().insertarRastreoPosicionConsolidada(objrastreo);
        }
        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Método que se encarga de realizar la impresión de vouchers. Para esto retorna de la base de datos todos
        /// las operaciones relacionadas e imprime el voucher uno por uno. Al terminar de imprimir el(los) voucher(s),
        /// pregunta al usuario si desea volver a imprimir.
        /// </summary>
        /// <param name="nIdKardex">Kardex de la operación principal</param>
        /// <param name="idModulo">Módulo de la operación principal</param>
        /// <param name="idTipoOpe">Tipo de operación de la operación principal</param>
        /// <param name="idEstadoKardex">Estado del kardex de la operación principal</param>
        /// <param name="nValRec">Monto recibido en la operación</param>
        /// <param name="nValdev">Monto devuelto al cliente como vuelto en la operación</param>
        /// <param name="idKardexAd">Kardex para el caso de habilitaciones</param>
        /// <param name="idTipoImpresion">Tipo de impresion del voucher 1-->IMPRESION,2-->REIMPRESION</param>
        public void ImpresionVoucher(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                        decimal nValRec, decimal nValdev, int idKardexAd, int idTipoImpresion)
        {
            int idKardexImpr = 0;
            int idModuloImpr = 0;
            int idTipoOperacionImpr = 0;
            int idEstadoKardexImpr = 0;
            decimal nValRecImpr = 0M;
            decimal nValdevImpr = 0M;
            int idEstCtaCred = 0;
            bool lImprimir = false;
            if (idModulo == 3 && idTipoOpe == 0)
            {
                idKardexImpr = nIdKardex;
                idModuloImpr = idModulo;
                idTipoOperacionImpr = idTipoOpe;
                idEstadoKardexImpr = idEstadoKardex;
                nValRecImpr = nValRec;
                nValdevImpr = nValdev;
                Imprimir(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                   nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion);

                if (idTipoImpresion == 1)//NORMAL
                {
                    while (MessageBox.Show("¿Desea reimprimir el voucher?", "IMPRESION DE VOUCHER",
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Imprimir(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                                    nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion);
                    }
                }
                return;
            }

            DataTable dtOrdenKardex = objImpresion.CNOrdenImpresionKardex(nIdKardex);

            foreach (DataRow row in dtOrdenKardex.Rows)
            {
                idKardexImpr = Convert.ToInt32(row["idKardex"]);
                idModuloImpr = Convert.ToInt32(row["idModulo"]);
                idTipoOperacionImpr = Convert.ToInt32(row["idTipoOperacion"]);
                idEstadoKardexImpr = Convert.ToInt32(row["idEstadoKardex"]);
                nValRecImpr = Convert.ToInt32(row["idKardexRelacionado"]) == 0 ? nValRec : 0;
                nValdevImpr = Convert.ToInt32(row["idKardexRelacionado"]) == 0 ? nValdev : 0;
                idEstCtaCred = Convert.ToInt32(row["idEstCtaCred"]);
                lImprimir = Convert.ToBoolean(row["lImprimir"]);
                if (!lImprimir) continue;
                if (idModulo == 3 && idTipoOpe == 0)
                {
                    idKardexImpr = nIdKardex;
                    idModuloImpr = idModulo;
                    idTipoOperacionImpr = idTipoOpe;
                    idEstadoKardexImpr = idEstadoKardex;
                    nValRecImpr = nValRec;
                    nValdevImpr = nValdev;
                }
                Imprimir(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                        nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion);
                if (idEstCtaCred == 6 && idTipoOperacionImpr == 2)//Cuenta de crédito cancelado
                {
                    MessageBox.Show("A continuación se imprimirá la CONSTANCIA DE CANCELACIÓN.\n", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Imprimir(nIdKardex, idModulo, 999, 1, 0, 0, 0, idTipoImpresion);
                }
            }

            if (idTipoImpresion == 1)//NORMAL
            {
                while (MessageBox.Show("¿Desea reimprimir el voucher?", "IMPRESION DE VOUCHER",
                                                                        MessageBoxButtons.YesNo,
                                                                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataRow row in dtOrdenKardex.Rows)
                    {
                        idKardexImpr = Convert.ToInt32(row["idKardex"]);
                        idModuloImpr = Convert.ToInt32(row["idModulo"]);
                        idTipoOperacionImpr = Convert.ToInt32(row["idTipoOperacion"]);
                        idEstadoKardexImpr = Convert.ToInt32(row["idEstadoKardex"]);
                        nValRecImpr = Convert.ToInt32(row["idKardexRelacionado"]) == 0 ? nValRec : 0;
                        nValdevImpr = Convert.ToInt32(row["idKardexRelacionado"]) == 0 ? nValdev : 0;
                        idEstCtaCred = Convert.ToInt32(row["idEstCtaCred"]);
                        lImprimir = Convert.ToBoolean(row["lImprimir"]);
                        if (!lImprimir) continue;
                        if (idModulo == 3 && idTipoOpe == 0)
                        {
                            idKardexImpr = nIdKardex;
                            idModuloImpr = idModulo;
                            idTipoOperacionImpr = idTipoOpe;
                            idEstadoKardexImpr = idEstadoKardex;
                            nValRecImpr = nValRec;
                            nValdevImpr = nValdev;
                        }
                        Imprimir(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                                    nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion);
                        if (idEstCtaCred == 6 && idTipoOperacionImpr == 2)//Cuenta de crédito cancelado
                        {
                            MessageBox.Show("A continuación se imprimirá la CONSTANCIA DE CANCELACIÓN.\n", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Imprimir(nIdKardex, idModulo, 999, 1, 0, 0, 0, idTipoImpresion);
                        }
                    }
                }
            }
        }

        private void Imprimir(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                decimal nValRec, decimal nValdev, int idKardexAd, int idTipoImpresion)
        {
            cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = idTipoImpresion == 1 ? "   " : "COPIA";

            if (idModulo == 3 && idTipoOpe == 0)
            {
                cPlantillaEmpresa = objImpresion.CNValorImpIniOpe(nIdKardex, clsVarGlobal.nIdAgencia, idModulo, idTipoOpe);
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaEmpresa = ValImpresion(nIdKardex, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion);
            }

            if (idTipoOpe == 6 || idTipoOpe == 8 || idTipoOpe == 63)//Para el caso de habilitaciones
            {
                string cPlantillaIngreso = cPlantillaEmpresa;
                string cPlantillaEgreso = ValImpresion(idKardexAd, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion);
                for (int i = 0; i < nNumImpresion; i++)
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("cTextoIngreso", cPlantillaIngreso, false));
                    paramlist.Add(new ReportParameter("cTextoEgreso", cPlantillaEgreso, false));
                    paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
                    paramlist.Add(new ReportParameter("cRUC", cRUC, false));
                    string reportpath = "rptVoucherHabilitacion.rdlc";

                    if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                    {
                        reportpath = "rptVoucherHabilitacionTicketMatIng.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                        reportpath = "rptVoucherHabilitacionTicketMatEgr.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                    }
                    else
                    {
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                    }
                }
            }
            else
            {

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                if (idTipoOpe == 999)
                {
                    DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();
                    dtslist.Add(new ReportDataSource("dtVariables", dtVariable));
                }
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
                paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
                paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
                paramlist.Add(new ReportParameter("cRUC", cRUC, false));
                paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
                paramlist.Add(new ReportParameter("nIdKardex", nIdKardex.ToString(), false));
                string reportpath = "rptVoucher.rdlc";

                if (idTipoOpe == 999)
                {
                    reportpath = "rptVoucherConstanciaCancelado1.rdlc";
                }

                if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                {
                    reportpath = "rptVoucherTicketMatricial.rdlc";

                    if (idTipoOpe == 999)
                    {
                        reportpath = "rptVoucherConstanciaCancelado2.rdlc";
                    }

                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }
                else
                {
                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }
                
            }
        }

        private string ValImpresion(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                    decimal nValRec, decimal nValdev, int idTipoImpre)
        {
            int idAgencia = 0;
            DataTable dtDatosOperacion = objImpresion.CNDatosOperacion(nIdKardex, idModulo, nValRec, nValdev, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosOperacion.Rows.Count > 0)
            {
                idAgencia = clsVarGlobal.nIdAgencia;
                nNumImpresion = Convert.ToInt32(dtDatosOperacion.Rows[0]["nNumIpresionVou"]);
                if (idEstadoCuenta == 6)
                {
                    idEstadoCuenta = 0;
                }
                else
                {
                    idEstadoCuenta = Convert.ToInt32(dtDatosOperacion.Rows[0]["idEstadoCuenta"]);
                }

                //Recuperando el estado de la cuenta
                DataTable dtParametrosImpEmpresa = objImpresion.CNListarParamImp(idModulo, idTipoOpe, idAgencia, 1, idEstadoKardex, true, false, idTipoImpre);
                DataTable dtParametrosImpCliente = objImpresion.CNListarParamImp(idModulo, idTipoOpe, idAgencia, 1, idEstadoKardex, false, true, idTipoImpre);

                //--------------------------------------------------------------
                //---Solo para Aho, Retiro con OP
                //--------------------------------------------------------------
                if (Convert.ToInt32(dtDatosOperacion.Rows[0]["idTipoPago"]) == 5 && idTipoOpe == 11)//TipoOPe=Orden de Pago y TipoOpe=Retiro
                {
                    DataView dtView = dtParametrosImpCliente.DefaultView;
                    dtView.RowFilter = "cNombreCampo <> 'nMontoDisp' AND cNombreCampo <> 'nMontContable'";
                    dtParametrosImpCliente = dtView.ToTable();
                }

                DataTable dtDetOperacion = objImpresion.CNDetalleOpe(nIdKardex, idAgencia, idModulo);
                string cPlantillaEmpresa = "", cDetalle = "";
                for (int i = 0; i < dtParametrosImpEmpresa.Rows.Count; i++)
                {
                    cPlantillaEmpresa += dtParametrosImpEmpresa.Rows[i]["cLineaPlanti"].ToString() + Environment.NewLine;
                }
                for (int i = 0; i < dtParametrosImpCliente.Rows.Count; i++)
                {
                    cPlantillaCliente += dtParametrosImpCliente.Rows[i]["cLineaPlanti"].ToString() + Environment.NewLine;
                }

                //Concatenando el Detalle
                if (dtDetOperacion.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDetOperacion.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dtDetOperacion.Rows[j]["nOrden"]) == 99)
                        {
                            if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                            {
                                cDetalle += (" ").ToString().PadRight(20, ' ') + ("").ToString().PadLeft(16, '-') + Environment.NewLine;
                                cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().Trim().PadRight(18, ' ') + ": " + (Convert.ToDecimal(dtDetOperacion.Rows[j]["nMonto"]).ToString("N2")).PadLeft(16, '*');
                            }
                            else
                            {
                                cDetalle += (" ").ToString().PadRight(18, ' ') + ("").ToString().PadLeft(12, '-') + Environment.NewLine;
                                cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().Trim().PadRight(17, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(12, '*');
                            }

                        }
                        else
                        {
                            if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().Trim().PadRight(18, ' ') + ": " + (Convert.ToDecimal(dtDetOperacion.Rows[j]["nMonto"]).ToString("N2")).PadLeft(16, '*') + Environment.NewLine;
                            }
                            else
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().Trim().PadRight(17, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(12, '*') + Environment.NewLine;
                            }
                            
                        }

                    }
                    //Añadiendo el Nro de Columnas
                    for (int i = 0; i < dtDetOperacion.Columns.Count; i++)
                    {
                        dtDatosOperacion.Columns.Add(dtDetOperacion.Columns[i].ColumnName, typeof(string));
                        dtDatosOperacion.Rows[0][dtDetOperacion.Columns[i].ColumnName] = dtDetOperacion.Rows[0][i].ToString(); ;
                    }
                    dtDatosOperacion.Rows[0]["cDetalle"] = cDetalle;
                    
                    if (clsVarGlobal.idTipoPlantillaImpresion == 1)
                    {
                        dtDatosOperacion.Rows[0]["cProducto"] = Regex.Replace(dtDatosOperacion.Rows[0]["cProducto"].ToString().Trim(), @"\s+", " ");
                    }
                    
                    if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                    {
                        DataTable dtCloned = dtDatosOperacion.Clone();
                        if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "DEPOSITO" || dtDatosOperacion.Rows[0]["cModulo"].ToString() == "AHORROS")
                         {
                             dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                             dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                         }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CREDITOS")
                        {
                            dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                            dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                            dtCloned.Columns["nSaldoCapital"].DataType = typeof(String);
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CAJA")
                        {
                            dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                            dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                        }
                        
                        foreach (DataRow row in dtDatosOperacion.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        dtDatosOperacion = dtCloned;
                        if (Convert.ToString(dtDatosOperacion.Rows[0]["cNombre"]).Length > 25 && idTipoOpe != 999)
	                        {
                            dtDatosOperacion.Rows[0]["cNombre"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cNombre"]), 25, 9);
	                        }
                        
                        dtDatosOperacion.Rows[0]["cProducto"] = dtDatosOperacion.Rows[0]["cProducto"].ToString();

                        if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "DEPOSITO" || dtDatosOperacion.Rows[0]["cModulo"].ToString() == "AHORROS")
                        {
                            dtDatosOperacion.Rows[0]["nMontDisp"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontDisp"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontContable"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontContable"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CREDITOS")
                        {
                            dtDatosOperacion.Rows[0]["nMontProxPag"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontProxPag"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nSaldoCapital"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nSaldoCapital"]).ToString("N2").PadLeft(20, '*');
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "SERVICIOS")
                        {
                            dtDatosOperacion.Rows[0]["cNomDestinat"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cNomDestinat"]), 25, 9);
                            dtDatosOperacion.Rows[0]["cTipoOperacion"] = string.Concat(Enumerable.Repeat(" ", (36 - dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim().Length) / 2)) + dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim();
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CAJA")
                        {
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');
                            //dtDatosOperacion.Rows[0]["cTipoOperacion"] = string.Concat(Enumerable.Repeat(" ", (36 - dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim().Length) / 2)) + dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim();
                            if (Convert.ToString(dtDatosOperacion.Rows[0]["cMotivo"]).Length > 25)
                            {
                                dtDatosOperacion.Rows[0]["cMotivo"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cMotivo"]), 25, 9);
                            }
                            
                        }
                           /* dtDatosOperacion.Rows[0]["cProducto"] = dtDatosOperacion.Rows[0]["cProducto"].ToString().Trim();*/
                        
                    }
                    
                    foreach (DataColumn Column in dtDatosOperacion.Columns)
                    {
                        cPlantillaEmpresa = cPlantillaEmpresa.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                        cPlantillaCliente = cPlantillaCliente.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                        //if (Convert.ToInt32(dtDatosOperacion.Rows[0]["idTipoPago"]) == 5 && idTipoOpe == 11)//TipoOPe=Orden de Pago y TipoOpe=Retiro
                        //{
                        //    //cPlantillaCliente = cPlantillaEmpresa;
                        //    if (Column.ColumnName=="nMontoDisp")
                        //    {
                                
                        //    }
                        //    cPlantillaCliente = cPlantillaCliente.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                        //}
                        //else
                        //{
                        //    cPlantillaCliente = cPlantillaCliente.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                        //}

                    }
                }

                if (string.IsNullOrEmpty(cPlantillaEmpresa))
                {
                    MessageBox.Show("Ocurrió un problema al intentar imprimir", "Impresión de voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
                else
                {
                    return cPlantillaEmpresa;
                }

            }
            else
            {
                return "";
            }
        }

        private IEnumerable<T> GetAllControlsOfType<T>(Control parent) where T : Control
        {
            var result = new List<T>();
            foreach (Control control in parent.Controls)
            {
                if (control is T)
                {
                    result.Add((T)control);
                }
                if (control.Controls.Count > 0)
                {
                    result.AddRange(GetAllControlsOfType<T>(control));
                }
            }
            return result;
        }
        private string procesarNombre(String cNombreCast, int nSaltoLinea, int nEspaciado)
        {
            String cRetornar = cNombreCast;
            string cCompleto = string.Empty;
            nSaltoLinea = 25;

                for (var i = 0; i < cNombreCast.Length; i++)
                {
                    if (nSaltoLinea == i)
                    {
                        while (cNombreCast[i] != ' ' && i > 0)
                        {
                            i--;
                        }
                        var s = cRetornar;
                        var index = i;
                        s = s.Substring(0, index) + '\n' + s.Substring(index + 1);
                        cRetornar = s;
                        nSaltoLinea = nSaltoLinea + 25;
                    }
                }

                cRetornar = cRetornar.Replace("\n", "\n" + string.Concat(Enumerable.Repeat(" ", nEspaciado)));
                return cRetornar;
        }

        /// <summary>
        /// Método que se encarga de realizar la impresión de vouchers. Para esto retorna de la base de datos todos
        /// las operaciones relacionadas e imprime el voucher uno por uno. Al terminar de imprimir el(los) voucher(s),
        /// pregunta al usuario si desea volver a imprimir.
        /// </summary>
        /// <param name="nIdKardex">Kardex de la operación principal</param>
        /// <param name="idModulo">Módulo de la operación principal</param>
        /// <param name="idTipoOpe">Tipo de operación de la operación principal</param>
        /// <param name="idEstadoKardex">Estado del kardex de la operación principal</param>
        /// <param name="nValRec">Monto recibido en la operación</param>
        /// <param name="nValdev">Monto devuelto al cliente como vuelto en la operación</param>
        /// <param name="idKardexAd">Kardex para el caso de habilitaciones</param>
        /// <param name="idTipoImpresion">Tipo de impresion del voucher 1-->IMPRESION,2-->REIMPRESION</param>
        public void ImpresionVoucherRelacionado(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                        decimal nValRec, decimal nValdev, int idKardexAd, int idTipoImpresion)
        {
            int idKardexImpr = 0;
            int idModuloImpr = 0;
            int idTipoOperacionImpr = 0;
            int idEstadoKardexImpr = 0;
            decimal nValRecImpr = 0M;
            decimal nValdevImpr = 0M;
            int idEstCtaCred = 0;
            bool lImprimir = false;

            DataTable dtOrdenKardex = objImpresion.CNOrdenImpresionKardex(nIdKardex);

            if (idModulo == 3 && idTipoOpe == 0)
            {
                idKardexImpr = nIdKardex;
                idModuloImpr = idModulo;
                idTipoOperacionImpr = idTipoOpe;
                idEstadoKardexImpr = idEstadoKardex;
                nValRecImpr = nValRec;
                nValdevImpr = nValdev;
                ImprimirRelacionado(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                   nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion, dtOrdenKardex);

                if (idTipoImpresion == 1)//NORMAL
                {
                    while (MessageBox.Show("¿Desea reimprimir el voucher?", "IMPRESION DE VOUCHER",
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImprimirRelacionado(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                                    nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion, dtOrdenKardex);
                    }
                }
                return;
            }
            DataRow drOpePrincipal;
            if(dtOrdenKardex.Rows.Count > 0)
                 drOpePrincipal = dtOrdenKardex.Rows[0];
            else
                return;

            idKardexImpr = Convert.ToInt32(drOpePrincipal["idKardex"]);
            idModuloImpr = Convert.ToInt32(drOpePrincipal["idModulo"]);
            idTipoOperacionImpr = Convert.ToInt32(drOpePrincipal["idTipoOperacion"]);
            idEstadoKardexImpr = Convert.ToInt32(drOpePrincipal["idEstadoKardex"]);
            nValRecImpr = Convert.ToInt32(drOpePrincipal["idKardexRelacionado"]) == 0 ? nValRec : 0;
            nValdevImpr = Convert.ToInt32(drOpePrincipal["idKardexRelacionado"]) == 0 ? nValdev : 0;
            idEstCtaCred = Convert.ToInt32(drOpePrincipal["idEstCtaCred"]);
            lImprimir = Convert.ToBoolean(drOpePrincipal["lImprimir"]);
            if (lImprimir)
            {
                if (idModulo == 3 && idTipoOpe == 0)
                {
                    idKardexImpr = nIdKardex;
                    idModuloImpr = idModulo;
                    idTipoOperacionImpr = idTipoOpe;
                    idEstadoKardexImpr = idEstadoKardex;
                    nValRecImpr = nValRec;
                    nValdevImpr = nValdev;
                }
                ImprimirRelacionado(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                        nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion, dtOrdenKardex);
                if (idEstCtaCred == 6 && idTipoOperacionImpr == 2)//Cuenta de crédito cancelado
                {
                    MessageBox.Show("A continuación se imprimirá la CONSTANCIA DE CANCELACIÓN.\n", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ImprimirRelacionado(nIdKardex, idModulo, 999, 1, 0, 0, 0, idTipoImpresion, dtOrdenKardex);
                }
            }

            if (idTipoImpresion == 1)//NORMAL
            {
                while (MessageBox.Show("¿Desea reimprimir el voucher?", "IMPRESION DE VOUCHER",
                                                                        MessageBoxButtons.YesNo,
                                                                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    idKardexImpr = Convert.ToInt32(drOpePrincipal["idKardex"]);
                    idModuloImpr = Convert.ToInt32(drOpePrincipal["idModulo"]);
                    idTipoOperacionImpr = Convert.ToInt32(drOpePrincipal["idTipoOperacion"]);
                    idEstadoKardexImpr = Convert.ToInt32(drOpePrincipal["idEstadoKardex"]);
                    nValRecImpr = Convert.ToInt32(drOpePrincipal["idKardexRelacionado"]) == 0 ? nValRec : 0;
                    nValdevImpr = Convert.ToInt32(drOpePrincipal["idKardexRelacionado"]) == 0 ? nValdev : 0;
                    idEstCtaCred = Convert.ToInt32(drOpePrincipal["idEstCtaCred"]);
                    lImprimir = Convert.ToBoolean(drOpePrincipal["lImprimir"]);
                    if (lImprimir)
                    {
                        if (idModulo == 3 && idTipoOpe == 0)
                        {
                            idKardexImpr = nIdKardex;
                            idModuloImpr = idModulo;
                            idTipoOperacionImpr = idTipoOpe;
                            idEstadoKardexImpr = idEstadoKardex;
                            nValRecImpr = nValRec;
                            nValdevImpr = nValdev;
                        }
                        ImprimirRelacionado(idKardexImpr, idModuloImpr, idTipoOperacionImpr, idEstadoKardexImpr,
                                    nValRecImpr, nValdevImpr, idKardexAd, idTipoImpresion, dtOrdenKardex);
                    }

                    if (idEstCtaCred == 6 && idTipoOperacionImpr == 2)//Cuenta de crédito cancelado
                    {
                        MessageBox.Show("A continuación se imprimirá la CONSTANCIA DE CANCELACIÓN.\n", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ImprimirRelacionado(nIdKardex, idModulo, 999, 1, 0, 0, 0, idTipoImpresion, dtOrdenKardex);
                    }
                }
            }
        }

        private void ImprimirRelacionado(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                decimal nValRec, decimal nValdev, int idKardexAd, int idTipoImpresion, DataTable dtOperacion)
        {
            cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = idTipoImpresion == 1 ? "   " : "COPIA";

            if (idModulo == 3 && idTipoOpe == 0)
            {
                cPlantillaEmpresa = objImpresion.CNValorImpIniOpe(nIdKardex, clsVarGlobal.nIdAgencia, idModulo, idTipoOpe);
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaEmpresa = ValImpresionRelacion(nIdKardex, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion, dtOperacion);
            }

            if (idTipoOpe == 6 || idTipoOpe == 8 || idTipoOpe == 63)//Para el caso de habilitaciones
            {
                string cPlantillaIngreso = cPlantillaEmpresa;
                string cPlantillaEgreso = ValImpresionRelacion(idKardexAd, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion, dtOperacion);
                for (int i = 0; i < nNumImpresion; i++)
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("cTextoIngreso", cPlantillaIngreso, false));
                    paramlist.Add(new ReportParameter("cTextoEgreso", cPlantillaEgreso, false));
                    paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
                    paramlist.Add(new ReportParameter("cRUC", cRUC, false));
                    string reportpath = "rptVoucherHabilitacion.rdlc";

                    if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                    {
                        reportpath = "rptVoucherHabilitacionTicketMatIng.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                        reportpath = "rptVoucherHabilitacionTicketMatEgr.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                    }
                    else
                    {
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                    }
                }
            }
            else
            {

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                if (idTipoOpe == 999)
                {
                    DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();
                    dtslist.Add(new ReportDataSource("dtVariables", dtVariable));
                }
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
                paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
                paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
                paramlist.Add(new ReportParameter("cRUC", cRUC, false));
                paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
                paramlist.Add(new ReportParameter("nIdKardex", nIdKardex.ToString(), false));
                string reportpath = "rptVoucher.rdlc";

                if (idTipoOpe == 999)
                {
                    reportpath = "rptVoucherConstanciaCancelado1.rdlc";
                }

                if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                {
                    reportpath = "rptVoucherTicketMatricial.rdlc";

                    if (idTipoOpe == 999)
                    {
                        reportpath = "rptVoucherConstanciaCancelado2.rdlc";
                    }

                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }
                else
                {
                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }

            }
        }

        private string ValImpresionRelacion(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                    decimal nValRec, decimal nValdev, int idTipoImpre, DataTable dtOperacion)
        {
            int idAgencia = 0;
            DataTable dtDatosOperacion = objImpresion.CNDatosOperacion(nIdKardex, idModulo, nValRec, nValdev, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosOperacion.Rows.Count > 0)
            {
                

                idAgencia = clsVarGlobal.nIdAgencia;
                nNumImpresion = Convert.ToInt32(dtDatosOperacion.Rows[0]["nNumIpresionVou"]);
                if (idEstadoCuenta == 6)
                {
                    idEstadoCuenta = 0;
                }
                else
                {
                    idEstadoCuenta = Convert.ToInt32(dtDatosOperacion.Rows[0]["idEstadoCuenta"]);
                }

                //Recuperando el estado de la cuenta
                DataTable dtParametrosImpEmpresa = objImpresion.CNListarParamImp(idModulo, idTipoOpe, idAgencia, 1, idEstadoKardex, true, false, idTipoImpre);
                DataTable dtParametrosImpCliente = objImpresion.CNListarParamImp(idModulo, idTipoOpe, idAgencia, 1, idEstadoKardex, false, true, idTipoImpre);

                //--------------------------------------------------------------
                //---Solo para Aho, Retiro con OP
                //--------------------------------------------------------------
                if (Convert.ToInt32(dtDatosOperacion.Rows[0]["idTipoPago"]) == 5 && idTipoOpe == 11)//TipoOPe=Orden de Pago y TipoOpe=Retiro
                {
                    DataView dtView = dtParametrosImpCliente.DefaultView;
                    dtView.RowFilter = "cNombreCampo <> 'nMontoDisp' AND cNombreCampo <> 'nMontContable'";
                    dtParametrosImpCliente = dtView.ToTable();
                }
                DataTable dtDetOperacion = new DataTable();

                dtDetOperacion = objImpresion.CNDetalleOpeImpRelacionado(nIdKardex, idAgencia, idModulo, clsVarGlobal.idTipoPlantillaImpresion);



                string cPlantillaEmpresa = "", cDetalle = "";
                for (int i = 0; i < dtParametrosImpEmpresa.Rows.Count; i++)
                {
                    cPlantillaEmpresa += dtParametrosImpEmpresa.Rows[i]["cLineaPlanti"].ToString() + Environment.NewLine;
                }
                for (int i = 0; i < dtParametrosImpCliente.Rows.Count; i++)
                {
                    cPlantillaCliente += dtParametrosImpCliente.Rows[i]["cLineaPlanti"].ToString() + Environment.NewLine;
                }

                //Concatenando el Detalle
                if (dtDetOperacion.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDetOperacion.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dtDetOperacion.Rows[j]["nOrden"]) == 99)
                        {
                            if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString() + Environment.NewLine; ;
                            }
                            else
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString() + Environment.NewLine; ;
                                //cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString().Trim().PadRight(17, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(12, '*');
                            }

                        }
                        else
                        {
                            if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString() + Environment.NewLine; ;
                            }
                            else
                            {
                                cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString() + Environment.NewLine; ;
                                //cDetalle += dtDetOperacion.Rows[j]["cCadenaImpr"].ToString().Trim().PadRight(17, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(12, '*') + Environment.NewLine;
                            }

                        }

                    }
                    //Añadiendo el Nro de Columnas
                    for (int i = 0; i < dtDetOperacion.Columns.Count; i++)
                    {
                        if (!dtDatosOperacion.Columns.Contains(dtDetOperacion.Columns[i].ColumnName))
                        {
                            dtDatosOperacion.Columns.Add(dtDetOperacion.Columns[i].ColumnName, typeof(string));
                            dtDatosOperacion.Rows[0][dtDetOperacion.Columns[i].ColumnName] = dtDetOperacion.Rows[0][i].ToString();
                        }
                    }
                    dtDatosOperacion.Rows[0]["cDetalle"] = cDetalle;

                    if (clsVarGlobal.idTipoPlantillaImpresion == 1)
                    {
                        dtDatosOperacion.Rows[0]["cProducto"] = Regex.Replace(dtDatosOperacion.Rows[0]["cProducto"].ToString().Trim(), @"\s+", " ");
                    }

                    if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                    {
                        DataTable dtCloned = dtDatosOperacion.Clone();
                        if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "DEPOSITO" || dtDatosOperacion.Rows[0]["cModulo"].ToString() == "AHORROS")
                        {
                            dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                            dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CREDITOS")
                        {
                            dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                            dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                            dtCloned.Columns["nSaldoCapital"].DataType = typeof(String);
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CAJA")
                        {
                            dtCloned.Columns["nMontoRecibido"].DataType = typeof(String);
                            dtCloned.Columns["nMontoVuelto"].DataType = typeof(String);
                        }

                        foreach (DataRow row in dtDatosOperacion.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        dtDatosOperacion = dtCloned;
                        if (Convert.ToString(dtDatosOperacion.Rows[0]["cNombre"]).Length > 25 && idTipoOpe != 999)
                        {
                            dtDatosOperacion.Rows[0]["cNombre"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cNombre"]), 25, 9);
                        }

                        dtDatosOperacion.Rows[0]["cProducto"] = dtDatosOperacion.Rows[0]["cProducto"].ToString();

                        if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "DEPOSITO" || dtDatosOperacion.Rows[0]["cModulo"].ToString() == "AHORROS")
                        {
                            dtDatosOperacion.Rows[0]["nMontDisp"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontDisp"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontContable"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontContable"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CREDITOS")
                        {
                            dtDatosOperacion.Rows[0]["nMontProxPag"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontProxPag"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nSaldoCapital"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nSaldoCapital"]).ToString("N2").PadLeft(20, '*');
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "SERVICIOS")
                        {
                            dtDatosOperacion.Rows[0]["cNomDestinat"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cNomDestinat"]), 25, 9);
                            dtDatosOperacion.Rows[0]["cTipoOperacion"] = string.Concat(Enumerable.Repeat(" ", (36 - dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim().Length) / 2)) + dtDatosOperacion.Rows[0]["cTipoOperacion"].ToString().Trim();
                        }
                        else if (dtDatosOperacion.Rows[0]["cModulo"].ToString() == "CAJA")
                        {
                            dtDatosOperacion.Rows[0]["nMontoRecibido"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoRecibido"]).ToString("N2").PadLeft(20, '*');
                            dtDatosOperacion.Rows[0]["nMontoVuelto"] = Convert.ToDecimal(dtDatosOperacion.Rows[0]["nMontoVuelto"]).ToString("N2").PadLeft(20, '*');

                            if (Convert.ToString(dtDatosOperacion.Rows[0]["cMotivo"]).Length > 25)
                            {
                                dtDatosOperacion.Rows[0]["cMotivo"] = procesarNombre(Convert.ToString(dtDatosOperacion.Rows[0]["cMotivo"]), 25, 9);
                            }

                        }

                    }

                    foreach (DataColumn Column in dtDatosOperacion.Columns)
                    {
                        cPlantillaEmpresa = cPlantillaEmpresa.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                        cPlantillaCliente = cPlantillaCliente.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());

                    }
                }

                if (string.IsNullOrEmpty(cPlantillaEmpresa))
                {
                    MessageBox.Show("Ocurrió un problema al intentar imprimir", "Impresión de voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
                else
                {
                    return cPlantillaEmpresa;
                }

            }
            else
            {
                return "";
            }
        }

        public string RecuperarVoucher(int nIdKardex, int idModulo, int idTipoOpe, int idEstadoKardex,
                                decimal nValRec, decimal nValdev, int idKardexAd, int idTipoImpresion)
        {
            cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = idTipoImpresion == 1 ? "   " : "COPIA";

            if (idModulo == 3 && idTipoOpe == 0)
            {
                cPlantillaEmpresa = objImpresion.CNValorImpIniOpe(nIdKardex, clsVarGlobal.nIdAgencia, idModulo, idTipoOpe);
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaEmpresa = ValImpresion(nIdKardex, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion);
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            if (idTipoOpe == 999)
            {
                DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();
                dtslist.Add(new ReportDataSource("dtVariables", dtVariable));
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
            paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
            paramlist.Add(new ReportParameter("cRUC", cRUC, false));
            paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
            paramlist.Add(new ReportParameter("nIdKardex", nIdKardex.ToString(), false));
            string reportpath = "rptVoucher.rdlc";

            if (idTipoOpe == 999)
            {
                reportpath = "rptVoucherConstanciaCancelado1.rdlc";
            }

            return cPlantillaCliente;


        }


    }
}