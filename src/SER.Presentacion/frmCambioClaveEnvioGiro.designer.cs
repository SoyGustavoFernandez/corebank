namespace SER.Presentacion
{
    partial class frmCambioClaveEnvioGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioClaveEnvioGiro));
            this.btnBusGiro = new GEN.BotonesBase.btnBusqueda();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroGiro = new GEN.ControlesBase.txtCBDNI(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefCelRem = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtDirRem = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNomCliRem = new GEN.ControlesBase.txtBase(this.components);
            this.txtDniRem = new GEN.ControlesBase.txtCBDNI(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefCelDes = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.txtDirDes = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDniBen = new GEN.ControlesBase.txtCBDNI(this.components);
            this.txtNomCliBen = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonGiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.txtReClave = new GEN.ControlesBase.txtCBDNI(this.components);
            this.txtClave = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.cboMot = new GEN.ControlesBase.cboMotivos(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblEstSolicitud = new System.Windows.Forms.Label();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.cboEstablecimientoRem = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.cboEstablecimientoGiroDes = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.grbBase6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBusGiro
            // 
            this.btnBusGiro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusGiro.BackgroundImage")));
            this.btnBusGiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusGiro.Enabled = false;
            this.btnBusGiro.Location = new System.Drawing.Point(485, 3);
            this.btnBusGiro.Name = "btnBusGiro";
            this.btnBusGiro.Size = new System.Drawing.Size(60, 50);
            this.btnBusGiro.TabIndex = 73;
            this.btnBusGiro.Text = "&Buscar";
            this.btnBusGiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusGiro.UseVisualStyleBackColor = true;
            this.btnBusGiro.Click += new System.EventHandler(this.btnBusGiro_Click);
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(18, 21);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(107, 13);
            this.lblBase32.TabIndex = 72;
            this.lblBase32.Text = "Número de  Giro:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtNroGiro);
            this.grbBase3.Location = new System.Drawing.Point(9, 1);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(471, 50);
            this.grbBase3.TabIndex = 75;
            this.grbBase3.TabStop = false;
            // 
            // txtNroGiro
            // 
            this.txtNroGiro.Enabled = false;
            this.txtNroGiro.Location = new System.Drawing.Point(137, 17);
            this.txtNroGiro.Name = "txtNroGiro";
            this.txtNroGiro.Size = new System.Drawing.Size(107, 20);
            this.txtNroGiro.TabIndex = 58;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboEstablecimientoRem);
            this.grbBase1.Controls.Add(this.txtTelefCelRem);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtDirRem);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase11);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtNomCliRem);
            this.grbBase1.Controls.Add(this.txtDniRem);
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase1.Location = new System.Drawing.Point(7, 60);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(547, 117);
            this.grbBase1.TabIndex = 76;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Remitente";
            // 
            // txtTelefCelRem
            // 
            this.txtTelefCelRem.Enabled = false;
            this.txtTelefCelRem.Location = new System.Drawing.Point(439, 39);
            this.txtTelefCelRem.Name = "txtTelefCelRem";
            this.txtTelefCelRem.Size = new System.Drawing.Size(100, 20);
            this.txtTelefCelRem.TabIndex = 127;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(373, 43);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(60, 13);
            this.lblBase9.TabIndex = 126;
            this.lblBase9.Text = "Teléfono:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(11, 74);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 125;
            this.lblBase8.Text = "Dirección:";
            // 
            // txtDirRem
            // 
            this.txtDirRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDirRem.Enabled = false;
            this.txtDirRem.Location = new System.Drawing.Point(141, 65);
            this.txtDirRem.Name = "txtDirRem";
            this.txtDirRem.Size = new System.Drawing.Size(398, 20);
            this.txtDirRem.TabIndex = 121;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 124;
            this.lblBase1.Text = "Nro. Documento:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(11, 23);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(129, 13);
            this.lblBase11.TabIndex = 123;
            this.lblBase11.Text = "Apellidos y Nombres:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 94);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 72;
            this.lblBase4.Text = "Agencia:";
            // 
            // txtNomCliRem
            // 
            this.txtNomCliRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliRem.Enabled = false;
            this.txtNomCliRem.Location = new System.Drawing.Point(141, 15);
            this.txtNomCliRem.Name = "txtNomCliRem";
            this.txtNomCliRem.Size = new System.Drawing.Size(400, 20);
            this.txtNomCliRem.TabIndex = 61;
            // 
            // txtDniRem
            // 
            this.txtDniRem.Enabled = false;
            this.txtDniRem.Location = new System.Drawing.Point(141, 39);
            this.txtDniRem.Name = "txtDniRem";
            this.txtDniRem.Size = new System.Drawing.Size(127, 20);
            this.txtDniRem.TabIndex = 63;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEstablecimientoGiroDes);
            this.grbBase2.Controls.Add(this.txtTelefCelDes);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.txtDirDes);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase16);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtDniBen);
            this.grbBase2.Controls.Add(this.txtNomCliBen);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase2.Location = new System.Drawing.Point(7, 183);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(547, 117);
            this.grbBase2.TabIndex = 116;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Beneficiario";
            // 
            // txtTelefCelDes
            // 
            this.txtTelefCelDes.Enabled = false;
            this.txtTelefCelDes.Location = new System.Drawing.Point(437, 41);
            this.txtTelefCelDes.Name = "txtTelefCelDes";
            this.txtTelefCelDes.Size = new System.Drawing.Size(100, 20);
            this.txtTelefCelDes.TabIndex = 126;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(372, 44);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(60, 13);
            this.lblBase15.TabIndex = 127;
            this.lblBase15.Text = "Teléfono:";
            // 
            // txtDirDes
            // 
            this.txtDirDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDirDes.Enabled = false;
            this.txtDirDes.Location = new System.Drawing.Point(138, 67);
            this.txtDirDes.Name = "txtDirDes";
            this.txtDirDes.Size = new System.Drawing.Size(396, 20);
            this.txtDirDes.TabIndex = 119;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 94);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 73;
            this.lblBase5.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(129, 13);
            this.lblBase2.TabIndex = 69;
            this.lblBase2.Text = "Apellidos y Nombres:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(10, 70);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(65, 13);
            this.lblBase16.TabIndex = 120;
            this.lblBase16.Text = "Dirección:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 67;
            this.lblBase3.Text = "Nro. Documento:";
            // 
            // txtDniBen
            // 
            this.txtDniBen.Enabled = false;
            this.txtDniBen.Location = new System.Drawing.Point(139, 41);
            this.txtDniBen.Name = "txtDniBen";
            this.txtDniBen.Size = new System.Drawing.Size(127, 20);
            this.txtDniBen.TabIndex = 66;
            // 
            // txtNomCliBen
            // 
            this.txtNomCliBen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliBen.Enabled = false;
            this.txtNomCliBen.Location = new System.Drawing.Point(139, 16);
            this.txtNomCliBen.Name = "txtNomCliBen";
            this.txtNomCliBen.Size = new System.Drawing.Size(398, 20);
            this.txtNomCliBen.TabIndex = 68;
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.txtMonGiro);
            this.grbBase5.Controls.Add(this.cboMoneda);
            this.grbBase5.Controls.Add(this.lblBase6);
            this.grbBase5.Controls.Add(this.lblBase7);
            this.grbBase5.Location = new System.Drawing.Point(8, 306);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(546, 49);
            this.grbBase5.TabIndex = 119;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Datos del Giro";
            // 
            // txtMonGiro
            // 
            this.txtMonGiro.Enabled = false;
            this.txtMonGiro.FormatoDecimal = false;
            this.txtMonGiro.Location = new System.Drawing.Point(344, 21);
            this.txtMonGiro.Name = "txtMonGiro";
            this.txtMonGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonGiro.nNumDecimales = 4;
            this.txtMonGiro.nvalor = 0D;
            this.txtMonGiro.Size = new System.Drawing.Size(82, 20);
            this.txtMonGiro.TabIndex = 123;
            this.txtMonGiro.Text = "0.00";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(76, 19);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(169, 21);
            this.cboMoneda.TabIndex = 121;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(268, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(74, 13);
            this.lblBase6.TabIndex = 122;
            this.lblBase6.Text = "Monto Giro:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(16, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 120;
            this.lblBase7.Text = "Moneda:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(364, 524);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 63;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(429, 524);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 64;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(494, 524);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 65;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase6
            // 
            this.grbBase6.BackColor = System.Drawing.SystemColors.Info;
            this.grbBase6.Controls.Add(this.txtReClave);
            this.grbBase6.Controls.Add(this.txtClave);
            this.grbBase6.Controls.Add(this.lblBase12);
            this.grbBase6.Controls.Add(this.lblBase13);
            this.grbBase6.Location = new System.Drawing.Point(9, 474);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(547, 44);
            this.grbBase6.TabIndex = 114;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Nueva Clave:";
            // 
            // txtReClave
            // 
            this.txtReClave.Location = new System.Drawing.Point(426, 12);
            this.txtReClave.MaxLength = 4;
            this.txtReClave.Name = "txtReClave";
            this.txtReClave.PasswordChar = '*';
            this.txtReClave.Size = new System.Drawing.Size(103, 20);
            this.txtReClave.TabIndex = 114;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(195, 12);
            this.txtClave.MaxLength = 4;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(103, 20);
            this.txtClave.TabIndex = 113;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(3, 15);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(192, 13);
            this.lblBase12.TabIndex = 115;
            this.lblBase12.Text = "Ingrese Clave de cuatro digitos:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(315, 16);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(110, 13);
            this.lblBase13.TabIndex = 116;
            this.lblBase13.Text = "Re ingrese Clave:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(7, 408);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(547, 60);
            this.txtMotivo.TabIndex = 120;
            // 
            // cboMot
            // 
            this.cboMot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMot.FormattingEnabled = true;
            this.cboMot.Location = new System.Drawing.Point(62, 361);
            this.cboMot.Name = "cboMot";
            this.cboMot.Size = new System.Drawing.Size(264, 21);
            this.cboMot.TabIndex = 125;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(12, 366);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(44, 13);
            this.lblBase10.TabIndex = 126;
            this.lblBase10.Text = "Motivo";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(9, 392);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(114, 13);
            this.lblBase14.TabIndex = 127;
            this.lblBase14.Text = "Detalle del Motivo:";
            // 
            // lblEstSolicitud
            // 
            this.lblEstSolicitud.AutoSize = true;
            this.lblEstSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstSolicitud.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstSolicitud.Location = new System.Drawing.Point(6, 540);
            this.lblEstSolicitud.Name = "lblEstSolicitud";
            this.lblEstSolicitud.Size = new System.Drawing.Size(92, 17);
            this.lblEstSolicitud.TabIndex = 128;
            this.lblEstSolicitud.Text = "estSolicitud";
            this.lblEstSolicitud.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(298, 524);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 115;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboEstablecimientoRem
            // 
            this.cboEstablecimientoRem.Enabled = false;
            this.cboEstablecimientoRem.FormattingEnabled = true;
            this.cboEstablecimientoRem.Location = new System.Drawing.Point(141, 90);
            this.cboEstablecimientoRem.Name = "cboEstablecimientoRem";
            this.cboEstablecimientoRem.Size = new System.Drawing.Size(396, 21);
            this.cboEstablecimientoRem.TabIndex = 145;
            // 
            // cboEstablecimientoGiroDes
            // 
            this.cboEstablecimientoGiroDes.Enabled = false;
            this.cboEstablecimientoGiroDes.FormattingEnabled = true;
            this.cboEstablecimientoGiroDes.Location = new System.Drawing.Point(138, 90);
            this.cboEstablecimientoGiroDes.Name = "cboEstablecimientoGiroDes";
            this.cboEstablecimientoGiroDes.Size = new System.Drawing.Size(399, 21);
            this.cboEstablecimientoGiroDes.TabIndex = 147;
            // 
            // frmCambioClaveEnvioGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 600);
            this.Controls.Add(this.lblEstSolicitud);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.cboMot);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.grbBase5);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusGiro);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmCambioClaveEnvioGiro";
            this.Text = "Solicitud cambio de clave envío de Giro:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCambioClaveEnvioGiro_FormClosing);
            this.Load += new System.EventHandler(this.frmCambioClaveEnvioGiro_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.btnBusGiro, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.cboMot, 0);
            this.Controls.SetChildIndex(this.lblBase14, 0);
            this.Controls.SetChildIndex(this.lblEstSolicitud, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnBusqueda btnBusGiro;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtCBDNI txtNroGiro;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtDirRem;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNomCliRem;
        private GEN.ControlesBase.txtCBDNI txtDniRem;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtDirDes;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBDNI txtDniBen;
        private GEN.ControlesBase.txtBase txtNomCliBen;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.txtNumRea txtMonGiro;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.cboMotivos cboMot;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase14;
        private System.Windows.Forms.Label lblEstSolicitud;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.txtTelefCel txtTelefCelRem;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtTelefCel txtTelefCelDes;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.txtCBDNI txtReClave;
        private GEN.ControlesBase.txtCBDNI txtClave;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoRem;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoGiroDes;
    }
}