namespace SER.Presentacion
{
    partial class frmEnvioGiroNuevo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioGiroNuevo));
            this.grbDatosRemitente = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniVerInterv = new GEN.BotonesBase.btnMiniVer();
            this.conBusPersonaRemitente = new GEN.ControlesBase.ConBusPersonaConServicios();
            this.grbDatosDestinatario = new GEN.ControlesBase.grbBase(this.components);
            this.conBusPersonaDestinatario = new GEN.ControlesBase.ConBusPersonaConServicios();
            this.grbDatosComplementarios = new GEN.ControlesBase.grbBase(this.components);
            this.cboModalidadesPagoGiro = new GEN.ControlesBase.CboModalidadesPagoGiro(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtReClave = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtClave = new GEN.ControlesBase.txtBase(this.components);
            this.btnBuscaCtaAho = new GEN.BotonesBase.Boton2();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbDatosGiro = new GEN.ControlesBase.grbBase(this.components);
            this.lblNombreAgencia = new GEN.ControlesBase.lblBase();
            this.cboEstablecimiento = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.chcIncluirComisionTotal = new GEN.ControlesBase.chcBase(this.components);
            this.txtMontoComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoRedondeo = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.txtMontoTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoGiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.btnGestionContacto = new GEN.BotonesBase.Boton();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOpe = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbDatosRemitente.SuspendLayout();
            this.grbDatosDestinatario.SuspendLayout();
            this.grbDatosComplementarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbDatosGiro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosRemitente
            // 
            this.grbDatosRemitente.Controls.Add(this.btnMiniVerInterv);
            this.grbDatosRemitente.Controls.Add(this.conBusPersonaRemitente);
            this.grbDatosRemitente.Location = new System.Drawing.Point(9, 10);
            this.grbDatosRemitente.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatosRemitente.Name = "grbDatosRemitente";
            this.grbDatosRemitente.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatosRemitente.Size = new System.Drawing.Size(701, 124);
            this.grbDatosRemitente.TabIndex = 1;
            this.grbDatosRemitente.TabStop = false;
            this.grbDatosRemitente.Text = "Datos remitente";
            // 
            // btnMiniVerInterv
            // 
            this.btnMiniVerInterv.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniVerInterv.BackgroundImage")));
            this.btnMiniVerInterv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMiniVerInterv.Location = new System.Drawing.Point(526, 69);
            this.btnMiniVerInterv.Name = "btnMiniVerInterv";
            this.btnMiniVerInterv.Size = new System.Drawing.Size(22, 22);
            this.btnMiniVerInterv.TabIndex = 1;
            this.btnMiniVerInterv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniVerInterv.UseVisualStyleBackColor = true;
            this.btnMiniVerInterv.Visible = false;
            this.btnMiniVerInterv.Click += new System.EventHandler(this.btnMiniVerInterv_Click);
            // 
            // conBusPersonaRemitente
            // 
            this.conBusPersonaRemitente.lModoEdicion = false;
            this.conBusPersonaRemitente.Location = new System.Drawing.Point(92, 17);
            this.conBusPersonaRemitente.Margin = new System.Windows.Forms.Padding(2);
            this.conBusPersonaRemitente.Name = "conBusPersonaRemitente";
            this.conBusPersonaRemitente.Size = new System.Drawing.Size(531, 100);
            this.conBusPersonaRemitente.TabIndex = 0;
            this.conBusPersonaRemitente.ehEncontrado += new System.EventHandler(this.conBusPersonaRemitente_ehEncontrado);
            this.conBusPersonaRemitente.ehCancelar += new System.EventHandler(this.conBusPersonaRemitente_ehCancelar);
            // 
            // grbDatosDestinatario
            // 
            this.grbDatosDestinatario.Controls.Add(this.conBusPersonaDestinatario);
            this.grbDatosDestinatario.Location = new System.Drawing.Point(9, 138);
            this.grbDatosDestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Name = "grbDatosDestinatario";
            this.grbDatosDestinatario.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Size = new System.Drawing.Size(701, 124);
            this.grbDatosDestinatario.TabIndex = 2;
            this.grbDatosDestinatario.TabStop = false;
            this.grbDatosDestinatario.Text = "Datos beneficiario";
            // 
            // conBusPersonaDestinatario
            // 
            this.conBusPersonaDestinatario.lModoEdicion = false;
            this.conBusPersonaDestinatario.Location = new System.Drawing.Point(92, 24);
            this.conBusPersonaDestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.conBusPersonaDestinatario.Name = "conBusPersonaDestinatario";
            this.conBusPersonaDestinatario.Size = new System.Drawing.Size(531, 100);
            this.conBusPersonaDestinatario.TabIndex = 0;
            this.conBusPersonaDestinatario.ehEncontrado += new System.EventHandler(this.conBusPersonaDestinatario_ehEncontrado);
            // 
            // grbDatosComplementarios
            // 
            this.grbDatosComplementarios.Controls.Add(this.cboModalidadesPagoGiro);
            this.grbDatosComplementarios.Controls.Add(this.lblBase9);
            this.grbDatosComplementarios.Controls.Add(this.lblBase7);
            this.grbDatosComplementarios.Controls.Add(this.txtReClave);
            this.grbDatosComplementarios.Controls.Add(this.txtNumeroCuenta);
            this.grbDatosComplementarios.Controls.Add(this.txtClave);
            this.grbDatosComplementarios.Controls.Add(this.btnBuscaCtaAho);
            this.grbDatosComplementarios.Controls.Add(this.lblBase4);
            this.grbDatosComplementarios.Controls.Add(this.lblBase2);
            this.grbDatosComplementarios.Controls.Add(this.lblBase1);
            this.grbDatosComplementarios.Controls.Add(this.lblBase3);
            this.grbDatosComplementarios.Controls.Add(this.pictureBox1);
            this.grbDatosComplementarios.Location = new System.Drawing.Point(13, 423);
            this.grbDatosComplementarios.Name = "grbDatosComplementarios";
            this.grbDatosComplementarios.Size = new System.Drawing.Size(701, 91);
            this.grbDatosComplementarios.TabIndex = 4;
            this.grbDatosComplementarios.TabStop = false;
            this.grbDatosComplementarios.Text = "Datos Complementarios del giro";
            // 
            // cboModalidadesPagoGiro
            // 
            this.cboModalidadesPagoGiro.FormattingEnabled = true;
            this.cboModalidadesPagoGiro.Location = new System.Drawing.Point(111, 16);
            this.cboModalidadesPagoGiro.Name = "cboModalidadesPagoGiro";
            this.cboModalidadesPagoGiro.Size = new System.Drawing.Size(195, 21);
            this.cboModalidadesPagoGiro.TabIndex = 0;
            this.cboModalidadesPagoGiro.SelectedIndexChanged += new System.EventHandler(this.cboModalidadesPagoGiro_SelectedIndexChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(479, 63);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(216, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "** Debe ser igual a la primera clave";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(108, 63);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(189, 13);
            this.lblBase7.TabIndex = 17;
            this.lblBase7.Text = "* La clave debe ser de 4 digitos";
            // 
            // txtReClave
            // 
            this.txtReClave.Location = new System.Drawing.Point(485, 43);
            this.txtReClave.MaxLength = 4;
            this.txtReClave.Name = "txtReClave";
            this.txtReClave.PasswordChar = '*';
            this.txtReClave.Size = new System.Drawing.Size(195, 20);
            this.txtReClave.TabIndex = 4;
            this.txtReClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReClave_KeyDown);
            this.txtReClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReClave_KeyPress);
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(484, 17);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.ReadOnly = true;
            this.txtNumeroCuenta.Size = new System.Drawing.Size(195, 20);
            this.txtNumeroCuenta.TabIndex = 2;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(111, 43);
            this.txtClave.MaxLength = 4;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(195, 20);
            this.txtClave.TabIndex = 3;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // btnBuscaCtaAho
            // 
            this.btnBuscaCtaAho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscaCtaAho.Location = new System.Drawing.Point(391, 16);
            this.btnBuscaCtaAho.Name = "btnBuscaCtaAho";
            this.btnBuscaCtaAho.Size = new System.Drawing.Size(87, 21);
            this.btnBuscaCtaAho.TabIndex = 1;
            this.btnBuscaCtaAho.Text = "Seleccionar";
            this.btnBuscaCtaAho.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscaCtaAho.UseVisualStyleBackColor = true;
            this.btnBuscaCtaAho.Click += new System.EventHandler(this.btnBuscaCtaAho_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(336, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(121, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Re ingrese clave:**";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(332, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(53, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Cuenta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(69, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Modalidad:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(97, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Ingrese clave:*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.pictureBox1.Location = new System.Drawing.Point(6, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(691, 39);
            this.pictureBox1.TabIndex = 132;
            this.pictureBox1.TabStop = false;
            // 
            // grbDatosGiro
            // 
            this.grbDatosGiro.Controls.Add(this.lblNombreAgencia);
            this.grbDatosGiro.Controls.Add(this.cboEstablecimiento);
            this.grbDatosGiro.Controls.Add(this.chcIncluirComisionTotal);
            this.grbDatosGiro.Controls.Add(this.txtMontoComision);
            this.grbDatosGiro.Controls.Add(this.txtITF);
            this.grbDatosGiro.Controls.Add(this.txtMontoRedondeo);
            this.grbDatosGiro.Controls.Add(this.cboMoneda);
            this.grbDatosGiro.Controls.Add(this.lblBase23);
            this.grbDatosGiro.Controls.Add(this.lblBase22);
            this.grbDatosGiro.Controls.Add(this.lblBase8);
            this.grbDatosGiro.Controls.Add(this.lblBase6);
            this.grbDatosGiro.Controls.Add(this.lblBase18);
            this.grbDatosGiro.Controls.Add(this.txtMontoTotal);
            this.grbDatosGiro.Controls.Add(this.txtMontoGiro);
            this.grbDatosGiro.Controls.Add(this.lblBase5);
            this.grbDatosGiro.Controls.Add(this.lblBase14);
            this.grbDatosGiro.Location = new System.Drawing.Point(9, 267);
            this.grbDatosGiro.Name = "grbDatosGiro";
            this.grbDatosGiro.Size = new System.Drawing.Size(701, 150);
            this.grbDatosGiro.TabIndex = 3;
            this.grbDatosGiro.TabStop = false;
            this.grbDatosGiro.Text = "Datos de giro";
            // 
            // lblNombreAgencia
            // 
            this.lblNombreAgencia.AutoSize = true;
            this.lblNombreAgencia.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreAgencia.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreAgencia.Location = new System.Drawing.Point(112, 74);
            this.lblNombreAgencia.Name = "lblNombreAgencia";
            this.lblNombreAgencia.Size = new System.Drawing.Size(74, 13);
            this.lblNombreAgencia.TabIndex = 138;
            this.lblNombreAgencia.Text = "NombreAge";
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(111, 50);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(195, 21);
            this.cboEstablecimiento.TabIndex = 1;
            this.cboEstablecimiento.SelectedIndexChanged += new System.EventHandler(this.cboEstablecimiento_SelectedIndexChanged);            
            this.cboEstablecimiento.Leave += new System.EventHandler(this.cboEstablecimientoGiro_Leave);
            // 
            // chcIncluirComisionTotal
            // 
            this.chcIncluirComisionTotal.AutoSize = true;
            this.chcIncluirComisionTotal.ForeColor = System.Drawing.Color.Navy;
            this.chcIncluirComisionTotal.Location = new System.Drawing.Point(543, 117);
            this.chcIncluirComisionTotal.Name = "chcIncluirComisionTotal";
            this.chcIncluirComisionTotal.Size = new System.Drawing.Size(109, 17);
            this.chcIncluirComisionTotal.TabIndex = 2;
            this.chcIncluirComisionTotal.Text = "&Incluir la comisión";
            this.chcIncluirComisionTotal.UseVisualStyleBackColor = true;
            this.chcIncluirComisionTotal.CheckedChanged += new System.EventHandler(this.chcIncluirComisionTotal_CheckedChanged);
            // 
            // txtMontoComision
            // 
            this.txtMontoComision.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoComision.Enabled = false;
            this.txtMontoComision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoComision.FormatoDecimal = true;
            this.txtMontoComision.Location = new System.Drawing.Point(466, 40);
            this.txtMontoComision.Name = "txtMontoComision";
            this.txtMontoComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoComision.nNumDecimales = 2;
            this.txtMontoComision.nvalor = 0D;
            this.txtMontoComision.Size = new System.Drawing.Size(74, 22);
            this.txtMontoComision.TabIndex = 5;
            this.txtMontoComision.Text = "0.00";
            // 
            // txtITF
            // 
            this.txtITF.BackColor = System.Drawing.SystemColors.Control;
            this.txtITF.Enabled = false;
            this.txtITF.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtITF.FormatoDecimal = true;
            this.txtITF.Location = new System.Drawing.Point(466, 65);
            this.txtITF.Name = "txtITF";
            this.txtITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtITF.nNumDecimales = 2;
            this.txtITF.nvalor = 0D;
            this.txtITF.Size = new System.Drawing.Size(74, 22);
            this.txtITF.TabIndex = 6;
            this.txtITF.Text = "0.00";
            // 
            // txtMontoRedondeo
            // 
            this.txtMontoRedondeo.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoRedondeo.Enabled = false;
            this.txtMontoRedondeo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRedondeo.FormatoDecimal = true;
            this.txtMontoRedondeo.Location = new System.Drawing.Point(466, 90);
            this.txtMontoRedondeo.Name = "txtMontoRedondeo";
            this.txtMontoRedondeo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoRedondeo.nNumDecimales = 2;
            this.txtMontoRedondeo.nvalor = 0D;
            this.txtMontoRedondeo.Size = new System.Drawing.Size(74, 22);
            this.txtMontoRedondeo.TabIndex = 7;
            this.txtMontoRedondeo.Text = "0.00";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(111, 20);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(195, 21);
            this.cboMoneda.TabIndex = 0;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(396, 94);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(69, 13);
            this.lblBase23.TabIndex = 137;
            this.lblBase23.Text = "Redondeo:";
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(435, 69);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(30, 13);
            this.lblBase22.TabIndex = 136;
            this.lblBase22.Text = "ITF:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(400, 43);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 132;
            this.lblBase8.Text = "Comisión:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(387, 117);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(77, 13);
            this.lblBase6.TabIndex = 130;
            this.lblBase6.Text = "Monto Total:";
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(7, 26);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(56, 13);
            this.lblBase18.TabIndex = 134;
            this.lblBase18.Text = "Moneda:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTotal.FormatoDecimal = true;
            this.txtMontoTotal.Location = new System.Drawing.Point(466, 115);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoTotal.nNumDecimales = 2;
            this.txtMontoTotal.nvalor = 0D;
            this.txtMontoTotal.Size = new System.Drawing.Size(74, 20);
            this.txtMontoTotal.TabIndex = 4;
            this.txtMontoTotal.Text = "0.00";
            this.txtMontoTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoTotal_KeyPress);
            this.txtMontoTotal.Leave += new System.EventHandler(this.txtMontoTotal_Leave);
            // 
            // txtMontoGiro
            // 
            this.txtMontoGiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoGiro.FormatoDecimal = true;
            this.txtMontoGiro.Location = new System.Drawing.Point(466, 17);
            this.txtMontoGiro.Name = "txtMontoGiro";
            this.txtMontoGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoGiro.nNumDecimales = 2;
            this.txtMontoGiro.nvalor = 0D;
            this.txtMontoGiro.Size = new System.Drawing.Size(74, 20);
            this.txtMontoGiro.TabIndex = 3;
            this.txtMontoGiro.Text = "0.00";
            this.txtMontoGiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoGiro_KeyPress);
            this.txtMontoGiro.Leave += new System.EventHandler(this.txtMontoGiro_Leave);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(7, 53);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(104, 13);
            this.lblBase5.TabIndex = 131;
            this.lblBase5.Text = "Agencia Destino:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(391, 19);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(74, 13);
            this.lblBase14.TabIndex = 133;
            this.lblBase14.Text = "Monto Giro:";
            // 
            // btnGestionContacto
            // 
            this.btnGestionContacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestionContacto.Location = new System.Drawing.Point(399, 520);
            this.btnGestionContacto.Name = "btnGestionContacto";
            this.btnGestionContacto.Size = new System.Drawing.Size(60, 50);
            this.btnGestionContacto.TabIndex = 9;
            this.btnGestionContacto.Text = "Gestión de Contacto";
            this.btnGestionContacto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionContacto.UseVisualStyleBackColor = true;
            this.btnGestionContacto.Click += new System.EventHandler(this.btnGestionContacto_Click);
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(20, 517);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(109, 13);
            this.lblBase17.TabIndex = 131;
            this.lblBase17.Text = "Motivo operación:";
            // 
            // cboMotivoOpe
            // 
            this.cboMotivoOpe.Enabled = false;
            this.cboMotivoOpe.FormattingEnabled = true;
            this.cboMotivoOpe.Location = new System.Drawing.Point(23, 533);
            this.cboMotivoOpe.Name = "cboMotivoOpe";
            this.cboMotivoOpe.Size = new System.Drawing.Size(255, 21);
            this.cboMotivoOpe.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(654, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(580, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(520, 520);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(459, 520);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmEnvioGiroNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 597);
            this.Controls.Add(this.btnGestionContacto);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.cboMotivoOpe);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbDatosGiro);
            this.Controls.Add(this.grbDatosComplementarios);
            this.Controls.Add(this.grbDatosDestinatario);
            this.Controls.Add(this.grbDatosRemitente);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEnvioGiroNuevo";
            this.Text = "Enviar Giro";
            this.Load += new System.EventHandler(this.frmEnvioGiroNuevo_Load);
            this.Controls.SetChildIndex(this.grbDatosRemitente, 0);
            this.Controls.SetChildIndex(this.grbDatosDestinatario, 0);
            this.Controls.SetChildIndex(this.grbDatosComplementarios, 0);
            this.Controls.SetChildIndex(this.grbDatosGiro, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboMotivoOpe, 0);
            this.Controls.SetChildIndex(this.lblBase17, 0);
            this.Controls.SetChildIndex(this.btnGestionContacto, 0);
            this.grbDatosRemitente.ResumeLayout(false);
            this.grbDatosDestinatario.ResumeLayout(false);
            this.grbDatosComplementarios.ResumeLayout(false);
            this.grbDatosComplementarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbDatosGiro.ResumeLayout(false);
            this.grbDatosGiro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosRemitente;
        private GEN.ControlesBase.ConBusPersonaConServicios conBusPersonaRemitente;
        private GEN.ControlesBase.grbBase grbDatosDestinatario;
        private GEN.ControlesBase.grbBase grbDatosComplementarios;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbDatosGiro;
        private GEN.ControlesBase.txtBase txtReClave;
        private GEN.ControlesBase.txtBase txtClave;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtNumeroCuenta;
        private GEN.BotonesBase.Boton2 btnBuscaCtaAho;
        private GEN.ControlesBase.txtNumRea txtMontoRedondeo;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase18;
        private GEN.ControlesBase.txtNumRea txtMontoTotal;
        private GEN.ControlesBase.txtNumRea txtMontoGiro;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtMontoComision;
        private GEN.ControlesBase.txtNumRea txtITF;
        private GEN.ControlesBase.chcBase chcIncluirComisionTotal;
        private GEN.BotonesBase.Boton btnGestionContacto;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOpe;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.ConBusPersonaConServicios conBusPersonaDestinatario;
        private GEN.ControlesBase.CboModalidadesPagoGiro cboModalidadesPagoGiro;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimiento;
        private GEN.ControlesBase.lblBase lblNombreAgencia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GEN.BotonesBase.btnMiniVer btnMiniVerInterv;
    }
}