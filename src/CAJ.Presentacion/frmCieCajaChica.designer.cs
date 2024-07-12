namespace CAJ.Presentacion
{
    partial class frmCieCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCieCajaChica));
            this.txtIDResCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoFij = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNomResCaj = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboCajChica = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtSalCaja = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroFonFij = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.txtMonCierre = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtpFecInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpCierre = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.dtgLisCpgCajChi = new GEN.ControlesBase.dtgBase(this.components);
            this.idNumeroCpg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaEmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoCpg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalCpg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtNroCpg = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisCpgCajChi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIDResCaj
            // 
            this.txtIDResCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDResCaj.Enabled = false;
            this.txtIDResCaj.Location = new System.Drawing.Point(628, 79);
            this.txtIDResCaj.Name = "txtIDResCaj";
            this.txtIDResCaj.Size = new System.Drawing.Size(93, 20);
            this.txtIDResCaj.TabIndex = 133;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(499, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(102, 13);
            this.lblBase3.TabIndex = 134;
            this.lblBase3.Text = "ID Responsable:";
            // 
            // txtMontoFij
            // 
            this.txtMontoFij.Enabled = false;
            this.txtMontoFij.FormatoDecimal = false;
            this.txtMontoFij.Location = new System.Drawing.Point(396, 68);
            this.txtMontoFij.Name = "txtMontoFij";
            this.txtMontoFij.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoFij.nNumDecimales = 2;
            this.txtMontoFij.nvalor = 0D;
            this.txtMontoFij.Size = new System.Drawing.Size(89, 20);
            this.txtMontoFij.TabIndex = 132;
            this.txtMontoFij.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(286, 71);
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
            this.cboMoneda.Location = new System.Drawing.Point(117, 68);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(154, 21);
            this.cboMoneda.TabIndex = 130;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 73);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 129;
            this.lblBase2.Text = "Moneda:";
            // 
            // txtNomResCaj
            // 
            this.txtNomResCaj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomResCaj.Enabled = false;
            this.txtNomResCaj.Location = new System.Drawing.Point(117, 42);
            this.txtNomResCaj.Name = "txtNomResCaj";
            this.txtNomResCaj.Size = new System.Drawing.Size(368, 20);
            this.txtNomResCaj.TabIndex = 127;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 44);
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
            this.lblBase1.Location = new System.Drawing.Point(291, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(75, 13);
            this.lblBase1.TabIndex = 126;
            this.lblBase1.Text = "Caja Chica:";
            // 
            // cboCajChica
            // 
            this.cboCajChica.FormattingEnabled = true;
            this.cboCajChica.Location = new System.Drawing.Point(372, 14);
            this.cboCajChica.Name = "cboCajChica";
            this.cboCajChica.Size = new System.Drawing.Size(350, 21);
            this.cboCajChica.TabIndex = 125;
            this.cboCajChica.SelectedIndexChanged += new System.EventHandler(this.cboCajChica_SelectedIndexChanged);
            this.cboCajChica.Click += new System.EventHandler(this.cboCajChica_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(8, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 124;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.Enabled = false;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(96, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(180, 21);
            this.cboAgencias.TabIndex = 123;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Location = new System.Drawing.Point(5, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(737, 43);
            this.grbBase1.TabIndex = 135;
            this.grbBase1.TabStop = false;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtSalCaja);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.txtNroFonFij);
            this.grbBase2.Controls.Add(this.lblBase14);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.txtNomResCaj);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.txtMontoFij);
            this.grbBase2.Location = new System.Drawing.Point(5, 37);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(738, 102);
            this.grbBase2.TabIndex = 136;
            this.grbBase2.TabStop = false;
            // 
            // txtSalCaja
            // 
            this.txtSalCaja.Enabled = false;
            this.txtSalCaja.FormatoDecimal = false;
            this.txtSalCaja.Location = new System.Drawing.Point(623, 68);
            this.txtSalCaja.Name = "txtSalCaja";
            this.txtSalCaja.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalCaja.nNumDecimales = 2;
            this.txtSalCaja.nvalor = 0D;
            this.txtSalCaja.Size = new System.Drawing.Size(94, 20);
            this.txtSalCaja.TabIndex = 124;
            this.txtSalCaja.Text = "0.00";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(499, 73);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(111, 13);
            this.lblBase4.TabIndex = 123;
            this.lblBase4.Text = "Saldo Caja Chica:";
            // 
            // txtNroFonFij
            // 
            this.txtNroFonFij.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroFonFij.Enabled = false;
            this.txtNroFonFij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFonFij.Location = new System.Drawing.Point(117, 16);
            this.txtNroFonFij.Name = "txtNroFonFij";
            this.txtNroFonFij.Size = new System.Drawing.Size(64, 20);
            this.txtNroFonFij.TabIndex = 153;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(6, 18);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(111, 13);
            this.lblBase14.TabIndex = 152;
            this.lblBase14.Text = "NRO FONDO FIJO:";
            // 
            // txtMonCierre
            // 
            this.txtMonCierre.Enabled = false;
            this.txtMonCierre.FormatoDecimal = false;
            this.txtMonCierre.Location = new System.Drawing.Point(622, 18);
            this.txtMonCierre.Name = "txtMonCierre";
            this.txtMonCierre.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonCierre.nNumDecimales = 2;
            this.txtMonCierre.nvalor = 0D;
            this.txtMonCierre.Size = new System.Drawing.Size(93, 20);
            this.txtMonCierre.TabIndex = 126;
            this.txtMonCierre.Text = "0.00";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(504, 23);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(86, 13);
            this.lblBase8.TabIndex = 125;
            this.lblBase8.Text = "Monto Cierre:";
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.Enabled = false;
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicio.Location = new System.Drawing.Point(116, 17);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(154, 20);
            this.dtpFecInicio.TabIndex = 143;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(7, 20);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(98, 13);
            this.lblBase12.TabIndex = 144;
            this.lblBase12.Text = "Fecha de Inicio:";
            // 
            // grbBase3
            // 
            this.grbBase3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbBase3.Controls.Add(this.dtpCierre);
            this.grbBase3.Controls.Add(this.dtpFecInicio);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Controls.Add(this.txtMonCierre);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Location = new System.Drawing.Point(6, 142);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(737, 49);
            this.grbBase3.TabIndex = 136;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Cierre";
            // 
            // dtpCierre
            // 
            this.dtpCierre.Enabled = false;
            this.dtpCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCierre.Location = new System.Drawing.Point(395, 20);
            this.dtpCierre.Name = "dtpCierre";
            this.dtpCierre.Size = new System.Drawing.Size(89, 20);
            this.dtpCierre.TabIndex = 145;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(289, 23);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(103, 13);
            this.lblBase9.TabIndex = 146;
            this.lblBase9.Text = "Fecha de Cierre:";
            // 
            // dtgLisCpgCajChi
            // 
            this.dtgLisCpgCajChi.AllowUserToAddRows = false;
            this.dtgLisCpgCajChi.AllowUserToDeleteRows = false;
            this.dtgLisCpgCajChi.AllowUserToResizeColumns = false;
            this.dtgLisCpgCajChi.AllowUserToResizeRows = false;
            this.dtgLisCpgCajChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLisCpgCajChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLisCpgCajChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idNumeroCpg,
            this.dFechaEmi,
            this.dFechaPago,
            this.nMontoCpg,
            this.nTotalCpg});
            this.dtgLisCpgCajChi.Location = new System.Drawing.Point(8, 198);
            this.dtgLisCpgCajChi.MultiSelect = false;
            this.dtgLisCpgCajChi.Name = "dtgLisCpgCajChi";
            this.dtgLisCpgCajChi.ReadOnly = true;
            this.dtgLisCpgCajChi.RowHeadersVisible = false;
            this.dtgLisCpgCajChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLisCpgCajChi.Size = new System.Drawing.Size(733, 270);
            this.dtgLisCpgCajChi.TabIndex = 137;
            // 
            // idNumeroCpg
            // 
            this.idNumeroCpg.DataPropertyName = "idNumeroCpg";
            this.idNumeroCpg.FillWeight = 350F;
            this.idNumeroCpg.HeaderText = "ID Comprobante";
            this.idNumeroCpg.Name = "idNumeroCpg";
            this.idNumeroCpg.ReadOnly = true;
            // 
            // dFechaEmi
            // 
            this.dFechaEmi.DataPropertyName = "dFechaEmi";
            this.dFechaEmi.FillWeight = 500F;
            this.dFechaEmi.HeaderText = "Fecha Emisión";
            this.dFechaEmi.Name = "dFechaEmi";
            this.dFechaEmi.ReadOnly = true;
            // 
            // dFechaPago
            // 
            this.dFechaPago.DataPropertyName = "dFechaPago";
            this.dFechaPago.FillWeight = 500F;
            this.dFechaPago.HeaderText = "Fecha Pago";
            this.dFechaPago.Name = "dFechaPago";
            this.dFechaPago.ReadOnly = true;
            // 
            // nMontoCpg
            // 
            this.nMontoCpg.DataPropertyName = "nMontoCpg";
            this.nMontoCpg.FillWeight = 300F;
            this.nMontoCpg.HeaderText = "Monto";
            this.nMontoCpg.Name = "nMontoCpg";
            this.nMontoCpg.ReadOnly = true;
            // 
            // nTotalCpg
            // 
            this.nTotalCpg.DataPropertyName = "nTotalCpg";
            this.nTotalCpg.HeaderText = "nTotalCpg";
            this.nTotalCpg.Name = "nTotalCpg";
            this.nTotalCpg.ReadOnly = true;
            this.nTotalCpg.Visible = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(618, 471);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 138;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(681, 471);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 139;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtNroCpg
            // 
            this.txtNroCpg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroCpg.Enabled = false;
            this.txtNroCpg.Location = new System.Drawing.Point(175, 472);
            this.txtNroCpg.Name = "txtNroCpg";
            this.txtNroCpg.Size = new System.Drawing.Size(60, 20);
            this.txtNroCpg.TabIndex = 140;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(5, 475);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(170, 13);
            this.lblBase10.TabIndex = 141;
            this.lblBase10.Text = "TOTAL DE COMPROBANTES:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(555, 471);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 142;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmCieCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 546);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtNroCpg);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.dtgLisCpgCajChi);
            this.Controls.Add(this.txtIDResCaj);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboCajChica);
            this.Controls.Add(this.cboAgencias);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmCieCajaChica";
            this.Text = "Cierre de Fondo Fijo";
            this.Load += new System.EventHandler(this.frmCieCajaChica_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencias, 0);
            this.Controls.SetChildIndex(this.cboCajChica, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtIDResCaj, 0);
            this.Controls.SetChildIndex(this.dtgLisCpgCajChi, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtNroCpg, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisCpgCajChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtIDResCaj;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMontoFij;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNomResCaj;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboCajChica;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtNumRea txtMonCierre;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtSalCaja;
        private GEN.ControlesBase.lblBase lblBase4;
        public GEN.ControlesBase.dtpCorto dtpFecInicio;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.grbBase grbBase3;
        public GEN.ControlesBase.dtpCorto dtpCierre;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.dtgBase dtgLisCpgCajChi;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtNroCpg;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtNroFonFij;
        private GEN.ControlesBase.lblBase lblBase14;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNumeroCpg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaEmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoCpg;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalCpg;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}