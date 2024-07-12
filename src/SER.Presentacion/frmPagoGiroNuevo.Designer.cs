namespace SER.Presentacion
{
    partial class frmPagoGiroNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoGiroNuevo));
            this.grbDatosDestinatario = new GEN.ControlesBase.grbBase(this.components);
            this.conBusPersonaDestinatario = new GEN.ControlesBase.ConBusPersonaConServicios();
            this.txtCelular = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.dtgGiros = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDatosGiro = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMontoGiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcItf = new GEN.ControlesBase.chcBase(this.components);
            this.txtMontoEntregar = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtMontoRedondeo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.txtMontoITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbClave = new GEN.ControlesBase.grbBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtClave = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbDatosDestinatario.SuspendLayout();
            this.conBusPersonaDestinatario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).BeginInit();
            this.grbDatosGiro.SuspendLayout();
            this.grbClave.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosDestinatario
            // 
            this.grbDatosDestinatario.Controls.Add(this.conBusPersonaDestinatario);
            this.grbDatosDestinatario.Location = new System.Drawing.Point(11, 11);
            this.grbDatosDestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Name = "grbDatosDestinatario";
            this.grbDatosDestinatario.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Size = new System.Drawing.Size(701, 124);
            this.grbDatosDestinatario.TabIndex = 3;
            this.grbDatosDestinatario.TabStop = false;
            this.grbDatosDestinatario.Text = "Datos beneficiario";
            // 
            // conBusPersonaDestinatario
            // 
            this.conBusPersonaDestinatario.Controls.Add(this.txtCelular);
            this.conBusPersonaDestinatario.Controls.Add(this.txtDireccion);
            this.conBusPersonaDestinatario.Controls.Add(this.txtNombre);
            this.conBusPersonaDestinatario.Controls.Add(this.txtNumeroDocumento);
            this.conBusPersonaDestinatario.lConsiderarRUC = true;
            this.conBusPersonaDestinatario.lModoEdicion = false;
            this.conBusPersonaDestinatario.Location = new System.Drawing.Point(92, 24);
            this.conBusPersonaDestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.conBusPersonaDestinatario.Name = "conBusPersonaDestinatario";
            this.conBusPersonaDestinatario.Size = new System.Drawing.Size(531, 100);
            this.conBusPersonaDestinatario.TabIndex = 0;
            this.conBusPersonaDestinatario.ehEncontrado += new System.EventHandler(this.conBusPersonaDestinatario_ehEncontrado);
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(143, 74);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(2);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(282, 20);
            this.txtCelular.TabIndex = 5;
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(143, 50);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(282, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(143, 26);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(286, 2);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(113, 20);
            this.txtNumeroDocumento.TabIndex = 0;
            // 
            // dtgGiros
            // 
            this.dtgGiros.AllowUserToAddRows = false;
            this.dtgGiros.AllowUserToDeleteRows = false;
            this.dtgGiros.AllowUserToResizeColumns = false;
            this.dtgGiros.AllowUserToResizeRows = false;
            this.dtgGiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGiros.Location = new System.Drawing.Point(11, 141);
            this.dtgGiros.MultiSelect = false;
            this.dtgGiros.Name = "dtgGiros";
            this.dtgGiros.ReadOnly = true;
            this.dtgGiros.RowHeadersVisible = false;
            this.dtgGiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGiros.Size = new System.Drawing.Size(701, 150);
            this.dtgGiros.TabIndex = 4;
            this.dtgGiros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGiros_CellClick);
            this.dtgGiros.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGiros_CellEnter);
            // 
            // grbDatosGiro
            // 
            this.grbDatosGiro.Controls.Add(this.cboMoneda);
            this.grbDatosGiro.Controls.Add(this.lblBase7);
            this.grbDatosGiro.Controls.Add(this.lblBase1);
            this.grbDatosGiro.Controls.Add(this.txtMontoGiro);
            this.grbDatosGiro.Controls.Add(this.chcItf);
            this.grbDatosGiro.Controls.Add(this.txtMontoEntregar);
            this.grbDatosGiro.Controls.Add(this.lblBase12);
            this.grbDatosGiro.Controls.Add(this.txtMontoRedondeo);
            this.grbDatosGiro.Controls.Add(this.lblBase23);
            this.grbDatosGiro.Controls.Add(this.lblBase22);
            this.grbDatosGiro.Controls.Add(this.txtMontoITF);
            this.grbDatosGiro.Location = new System.Drawing.Point(12, 297);
            this.grbDatosGiro.Name = "grbDatosGiro";
            this.grbDatosGiro.Size = new System.Drawing.Size(700, 118);
            this.grbDatosGiro.TabIndex = 119;
            this.grbDatosGiro.TabStop = false;
            this.grbDatosGiro.Text = "Datos del Giro";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(164, 19);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(159, 21);
            this.cboMoneda.TabIndex = 130;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(104, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 129;
            this.lblBase7.Text = "Moneda:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(413, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(72, 13);
            this.lblBase1.TabIndex = 128;
            this.lblBase1.Text = "Monto giro:";
            // 
            // txtMontoGiro
            // 
            this.txtMontoGiro.Enabled = false;
            this.txtMontoGiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoGiro.FormatoDecimal = true;
            this.txtMontoGiro.Location = new System.Drawing.Point(492, 11);
            this.txtMontoGiro.Name = "txtMontoGiro";
            this.txtMontoGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoGiro.nNumDecimales = 2;
            this.txtMontoGiro.nvalor = 0D;
            this.txtMontoGiro.Size = new System.Drawing.Size(115, 20);
            this.txtMontoGiro.TabIndex = 127;
            this.txtMontoGiro.Text = "0.00";
            // 
            // chcItf
            // 
            this.chcItf.AutoSize = true;
            this.chcItf.Enabled = false;
            this.chcItf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcItf.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chcItf.Location = new System.Drawing.Point(164, 49);
            this.chcItf.Name = "chcItf";
            this.chcItf.Size = new System.Drawing.Size(93, 17);
            this.chcItf.TabIndex = 126;
            this.chcItf.Text = "Cobrar ITF?";
            this.chcItf.UseVisualStyleBackColor = true;
            this.chcItf.CheckedChanged += new System.EventHandler(this.chcItf_CheckedChanged);
            // 
            // txtMontoEntregar
            // 
            this.txtMontoEntregar.Enabled = false;
            this.txtMontoEntregar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoEntregar.Location = new System.Drawing.Point(492, 85);
            this.txtMontoEntregar.Name = "txtMontoEntregar";
            this.txtMontoEntregar.ShortcutsEnabled = false;
            this.txtMontoEntregar.Size = new System.Drawing.Size(115, 22);
            this.txtMontoEntregar.TabIndex = 125;
            this.txtMontoEntregar.Text = "0.00";
            // 
            // lblBase12
            // 
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(375, 87);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(113, 18);
            this.lblBase12.TabIndex = 124;
            this.lblBase12.Text = "Monto a Entregar:";
            // 
            // txtMontoRedondeo
            // 
            this.txtMontoRedondeo.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoRedondeo.Enabled = false;
            this.txtMontoRedondeo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRedondeo.FormatoDecimal = true;
            this.txtMontoRedondeo.Location = new System.Drawing.Point(492, 60);
            this.txtMontoRedondeo.Name = "txtMontoRedondeo";
            this.txtMontoRedondeo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoRedondeo.nNumDecimales = 2;
            this.txtMontoRedondeo.nvalor = 0D;
            this.txtMontoRedondeo.Size = new System.Drawing.Size(115, 22);
            this.txtMontoRedondeo.TabIndex = 123;
            this.txtMontoRedondeo.Text = "0.00";
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(416, 64);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(69, 13);
            this.lblBase23.TabIndex = 122;
            this.lblBase23.Text = "Redondeo:";
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(455, 40);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(30, 13);
            this.lblBase22.TabIndex = 115;
            this.lblBase22.Text = "ITF:";
            // 
            // txtMontoITF
            // 
            this.txtMontoITF.Enabled = false;
            this.txtMontoITF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoITF.FormatoDecimal = true;
            this.txtMontoITF.Location = new System.Drawing.Point(492, 37);
            this.txtMontoITF.Name = "txtMontoITF";
            this.txtMontoITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoITF.nNumDecimales = 2;
            this.txtMontoITF.nvalor = 0D;
            this.txtMontoITF.Size = new System.Drawing.Size(115, 20);
            this.txtMontoITF.TabIndex = 114;
            this.txtMontoITF.Text = "0.00";
            // 
            // grbClave
            // 
            this.grbClave.Controls.Add(this.label1);
            this.grbClave.Controls.Add(this.txtClave);
            this.grbClave.Location = new System.Drawing.Point(86, 421);
            this.grbClave.Name = "grbClave";
            this.grbClave.Size = new System.Drawing.Size(546, 48);
            this.grbClave.TabIndex = 120;
            this.grbClave.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "INGRESE LA CLAVE:";
            // 
            // txtClave
            // 
            this.txtClave.Enabled = false;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(255, 13);
            this.txtClave.MaxLength = 4;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(120, 29);
            this.txtClave.TabIndex = 119;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(90, 490);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(109, 13);
            this.lblBase17.TabIndex = 130;
            this.lblBase17.Text = "Motivo operación:";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.Enabled = false;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(90, 506);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(260, 21);
            this.cboMotivoOperacion.TabIndex = 129;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(572, 484);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 128;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(504, 484);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 127;
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
            this.btnGrabar.Location = new System.Drawing.Point(443, 484);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 126;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(383, 484);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 125;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmPagoGiroNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 567);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.cboMotivoOperacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbClave);
            this.Controls.Add(this.grbDatosGiro);
            this.Controls.Add(this.dtgGiros);
            this.Controls.Add(this.grbDatosDestinatario);
            this.Name = "frmPagoGiroNuevo";
            this.Text = "Pago de giros";
            this.Load += new System.EventHandler(this.frmPagoGiroNuevo_Load);
            this.Controls.SetChildIndex(this.grbDatosDestinatario, 0);
            this.Controls.SetChildIndex(this.dtgGiros, 0);
            this.Controls.SetChildIndex(this.grbDatosGiro, 0);
            this.Controls.SetChildIndex(this.grbClave, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboMotivoOperacion, 0);
            this.Controls.SetChildIndex(this.lblBase17, 0);
            this.grbDatosDestinatario.ResumeLayout(false);
            this.conBusPersonaDestinatario.ResumeLayout(false);
            this.conBusPersonaDestinatario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).EndInit();
            this.grbDatosGiro.ResumeLayout(false);
            this.grbDatosGiro.PerformLayout();
            this.grbClave.ResumeLayout(false);
            this.grbClave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosDestinatario;
        private GEN.ControlesBase.ConBusPersonaConServicios conBusPersonaDestinatario;        
        private GEN.ControlesBase.txtBase txtCelular;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNumeroDocumento;        
        private GEN.ControlesBase.dtgBase dtgGiros;
        private GEN.ControlesBase.grbBase grbDatosGiro;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtMontoGiro;
        private GEN.ControlesBase.chcBase chcItf;
        private GEN.ControlesBase.txtBase txtMontoEntregar;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtNumRea txtMontoRedondeo;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.txtNumRea txtMontoITF;
        private GEN.ControlesBase.grbBase grbClave;
        private GEN.ControlesBase.txtBase txtClave;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}