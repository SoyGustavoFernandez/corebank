namespace CAJ.Presentacion
{
    partial class frmIniCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIniCajaChica));
            this.txtIDResCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonFij = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNomResCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtIdCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNomCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMonRec = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtpFecEmiRec = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroRec = new GEN.ControlesBase.txtBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.cboMonRec = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.dtpFecInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.txtTotHab = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroFonFij = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDResCaj
            // 
            this.txtIDResCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDResCaj.Enabled = false;
            this.txtIDResCaj.Location = new System.Drawing.Point(533, 56);
            this.txtIDResCaj.Name = "txtIDResCaj";
            this.txtIDResCaj.Size = new System.Drawing.Size(91, 20);
            this.txtIDResCaj.TabIndex = 133;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(430, 59);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(102, 13);
            this.lblBase3.TabIndex = 134;
            this.lblBase3.Text = "ID Responsable:";
            // 
            // txtMonFij
            // 
            this.txtMonFij.Enabled = false;
            this.txtMonFij.FormatoDecimal = false;
            this.txtMonFij.Location = new System.Drawing.Point(353, 85);
            this.txtMonFij.Name = "txtMonFij";
            this.txtMonFij.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonFij.nNumDecimales = 2;
            this.txtMonFij.nvalor = 0D;
            this.txtMonFij.Size = new System.Drawing.Size(73, 20);
            this.txtMonFij.TabIndex = 132;
            this.txtMonFij.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(239, 89);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 131;
            this.lblBase6.Text = "Monto Fondo Fijo:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(95, 84);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda.TabIndex = 130;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 88);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 129;
            this.lblBase2.Text = "Moneda:";
            // 
            // txtNomResCaj
            // 
            this.txtNomResCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomResCaj.Enabled = false;
            this.txtNomResCaj.Location = new System.Drawing.Point(95, 56);
            this.txtNomResCaj.Name = "txtNomResCaj";
            this.txtNomResCaj.Size = new System.Drawing.Size(331, 20);
            this.txtNomResCaj.TabIndex = 127;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 60);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(84, 13);
            this.lblBase7.TabIndex = 128;
            this.lblBase7.Text = "Responsable:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(333, 185);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(75, 13);
            this.lblBase1.TabIndex = 126;
            this.lblBase1.Text = "Caja Chica:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 29);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 124;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.Enabled = false;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(95, 25);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(139, 21);
            this.cboAgencias.TabIndex = 123;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtIdCaj);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtMonFij);
            this.grbBase1.Controls.Add(this.txtIDResCaj);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtNomCaj);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.txtNomResCaj);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Location = new System.Drawing.Point(5, 156);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(632, 111);
            this.grbBase1.TabIndex = 135;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Fondo Fijo";
            // 
            // txtIdCaj
            // 
            this.txtIdCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdCaj.Enabled = false;
            this.txtIdCaj.Location = new System.Drawing.Point(271, 25);
            this.txtIdCaj.Name = "txtIdCaj";
            this.txtIdCaj.Size = new System.Drawing.Size(55, 20);
            this.txtIdCaj.TabIndex = 151;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(238, 29);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(26, 13);
            this.lblBase4.TabIndex = 152;
            this.lblBase4.Text = "ID:";
            // 
            // txtNomCaj
            // 
            this.txtNomCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCaj.Enabled = false;
            this.txtNomCaj.Location = new System.Drawing.Point(405, 25);
            this.txtNomCaj.Name = "txtNomCaj";
            this.txtNomCaj.Size = new System.Drawing.Size(219, 20);
            this.txtNomCaj.TabIndex = 151;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(13, 31);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(74, 13);
            this.lblBase9.TabIndex = 138;
            this.lblBase9.Text = "Nro Recibo:";
            // 
            // txtMonRec
            // 
            this.txtMonRec.Enabled = false;
            this.txtMonRec.FormatoDecimal = false;
            this.txtMonRec.Location = new System.Drawing.Point(326, 70);
            this.txtMonRec.Name = "txtMonRec";
            this.txtMonRec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonRec.nNumDecimales = 2;
            this.txtMonRec.nvalor = 0D;
            this.txtMonRec.Size = new System.Drawing.Size(74, 20);
            this.txtMonRec.TabIndex = 128;
            this.txtMonRec.Text = "0.00";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(236, 74);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(88, 13);
            this.lblBase10.TabIndex = 127;
            this.lblBase10.Text = "Monto Recibo:";
            // 
            // dtpFecEmiRec
            // 
            this.dtpFecEmiRec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEmiRec.Location = new System.Drawing.Point(522, 71);
            this.dtpFecEmiRec.Name = "dtpFecEmiRec";
            this.dtpFecEmiRec.Size = new System.Drawing.Size(100, 20);
            this.dtpFecEmiRec.TabIndex = 139;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(410, 74);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(111, 13);
            this.lblBase11.TabIndex = 140;
            this.lblBase11.Text = "Fecha de Emisión:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFecEmiRec);
            this.grbBase3.Controls.Add(this.txtNroRec);
            this.grbBase3.Controls.Add(this.btnAceptar);
            this.grbBase3.Controls.Add(this.cboMonRec);
            this.grbBase3.Controls.Add(this.lblBase17);
            this.grbBase3.Controls.Add(this.txtSustento);
            this.grbBase3.Controls.Add(this.lblBase16);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.txtMonRec);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Location = new System.Drawing.Point(7, 12);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(630, 144);
            this.grbBase3.TabIndex = 136;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Recibo de Habilitación";
            // 
            // txtNroRec
            // 
            this.txtNroRec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroRec.Location = new System.Drawing.Point(92, 28);
            this.txtNroRec.Name = "txtNroRec";
            this.txtNroRec.Size = new System.Drawing.Size(81, 20);
            this.txtNroRec.TabIndex = 150;
            this.txtNroRec.TextChanged += new System.EventHandler(this.txtNroRec_TextChanged_1);
            this.txtNroRec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroRec_KeyPress_1);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(173, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 151;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboMonRec
            // 
            this.cboMonRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonRec.Enabled = false;
            this.cboMonRec.FormattingEnabled = true;
            this.cboMonRec.Location = new System.Drawing.Point(92, 68);
            this.cboMonRec.Name = "cboMonRec";
            this.cboMonRec.Size = new System.Drawing.Size(140, 21);
            this.cboMonRec.TabIndex = 150;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(13, 71);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(56, 13);
            this.lblBase17.TabIndex = 149;
            this.lblBase17.Text = "Moneda:";
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(92, 96);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(530, 44);
            this.txtSustento.TabIndex = 150;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(13, 99);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(62, 13);
            this.lblBase16.TabIndex = 149;
            this.lblBase16.Text = "Sustento:";
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicio.Location = new System.Drawing.Point(113, 13);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpFecInicio.TabIndex = 141;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 17);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(98, 13);
            this.lblBase12.TabIndex = 142;
            this.lblBase12.Text = "Fecha de Inicio:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(238, 17);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(111, 13);
            this.lblBase14.TabIndex = 145;
            this.lblBase14.Text = "NRO FONDO FIJO:";
            // 
            // txtTotHab
            // 
            this.txtTotHab.Enabled = false;
            this.txtTotHab.FormatoDecimal = false;
            this.txtTotHab.Location = new System.Drawing.Point(532, 14);
            this.txtTotHab.Name = "txtTotHab";
            this.txtTotHab.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotHab.nNumDecimales = 2;
            this.txtTotHab.nvalor = 0D;
            this.txtTotHab.Size = new System.Drawing.Size(91, 20);
            this.txtTotHab.TabIndex = 148;
            this.txtTotHab.Text = "0.00";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(429, 17);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(91, 13);
            this.lblBase15.TabIndex = 147;
            this.lblBase15.Text = "Total Habilitar:";
            // 
            // grbBase4
            // 
            this.grbBase4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbBase4.Controls.Add(this.txtNroFonFij);
            this.grbBase4.Controls.Add(this.lblBase12);
            this.grbBase4.Controls.Add(this.txtTotHab);
            this.grbBase4.Controls.Add(this.dtpFecInicio);
            this.grbBase4.Controls.Add(this.lblBase15);
            this.grbBase4.Controls.Add(this.lblBase14);
            this.grbBase4.Location = new System.Drawing.Point(6, 270);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(631, 43);
            this.grbBase4.TabIndex = 136;
            this.grbBase4.TabStop = false;
            // 
            // txtNroFonFij
            // 
            this.txtNroFonFij.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroFonFij.Enabled = false;
            this.txtNroFonFij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFonFij.Location = new System.Drawing.Point(352, 13);
            this.txtNroFonFij.Name = "txtNroFonFij";
            this.txtNroFonFij.Size = new System.Drawing.Size(73, 20);
            this.txtNroFonFij.TabIndex = 151;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(569, 318);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 150;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(505, 318);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 149;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(441, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 151;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmIniCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 391);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase4);
            this.Name = "frmIniCajaChica";
            this.Text = "Inicio de Fondo Fijo";
            this.Load += new System.EventHandler(this.frmIniCajaChica_Load);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtIDResCaj;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMonFij;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNomResCaj;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtMonRec;
        private GEN.ControlesBase.lblBase lblBase10;
        public GEN.ControlesBase.dtpCorto dtpFecEmiRec;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase3;
        public GEN.ControlesBase.dtpCorto dtpFecInicio;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.txtNumRea txtTotHab;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboMoneda cboMonRec;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.txtBase txtNomCaj;
        private GEN.ControlesBase.txtBase txtNroFonFij;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.txtBase txtIdCaj;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNroRec;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}