namespace CAJ.Presentacion
{
    partial class frmCargaBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaBancos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportar1 = new GEN.BotonesBase.btnImportar();
            this.txtArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.dtgCargaBco = new GEN.ControlesBase.dtgBase(this.components);
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idMotOpeBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipMedPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipOpeMovBco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoTransac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIdentifica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbDatosMovimiento = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtNroConciliaBco = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoMotOpeBco = new GEN.ControlesBase.cboBase(this.components);
            this.grbCapInt = new GEN.ControlesBase.grbBase(this.components);
            this.rbtCapital = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtInteres = new GEN.ControlesBase.rbtBase(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboTipoOperacionBco = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoDestino = new GEN.ControlesBase.cboTipoDestino(this.components);
            this.cboTipoDocumentoBco = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMontoOperac = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtConcepto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboMedioPagoSunat = new GEN.ControlesBase.cboMedioPagoSunat(this.components);
            this.cboMotOperacionBco = new GEN.ControlesBase.cboMotOperacionBco(this.components);
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.dtpfechaOperac = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaOperacion = new GEN.ControlesBase.lblBase();
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.lblTipoDocumento = new GEN.ControlesBase.lblBase();
            this.lblDocumento = new GEN.ControlesBase.lblBase();
            this.lblMedioPagoSUNAT = new GEN.ControlesBase.lblBase();
            this.lblMotivoOperacion = new GEN.ControlesBase.lblBase();
            this.grbCliente = new GEN.ControlesBase.grbBase(this.components);
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusquedaDestino = new GEN.BotonesBase.btnBusqueda();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargaBco)).BeginInit();
            this.grbDatosMovimiento.SuspendLayout();
            this.grbCapInt.SuspendLayout();
            this.grbCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportar1
            // 
            this.btnImportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar1.BackgroundImage")));
            this.btnImportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar1.Enabled = false;
            this.btnImportar1.Location = new System.Drawing.Point(348, 23);
            this.btnImportar1.Name = "btnImportar1";
            this.btnImportar1.Size = new System.Drawing.Size(60, 50);
            this.btnImportar1.TabIndex = 3;
            this.btnImportar1.Text = "&Importar";
            this.btnImportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar1.UseVisualStyleBackColor = true;
            this.btnImportar1.Click += new System.EventHandler(this.btnImportar1_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(524, 25);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(191, 20);
            this.txtArchivo.TabIndex = 4;
            // 
            // dtgCargaBco
            // 
            this.dtgCargaBco.AllowUserToAddRows = false;
            this.dtgCargaBco.AllowUserToDeleteRows = false;
            this.dtgCargaBco.AllowUserToResizeColumns = false;
            this.dtgCargaBco.AllowUserToResizeRows = false;
            this.dtgCargaBco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCargaBco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCargaBco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCargaBco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dFecha,
            this.cDescripcion,
            this.cNroOpe,
            this.cUTC,
            this.nMonto,
            this.lEstado,
            this.idMotOpeBanco,
            this.idTipMedPago,
            this.idTipoDocumento,
            this.idTipoPago,
            this.idTipOpeMovBco,
            this.idTipoTransac,
            this.cDocume,
            this.idIdentifica,
            this.idCli,
            this.idTipoDestino,
            this.cNomCli});
            this.dtgCargaBco.Location = new System.Drawing.Point(13, 82);
            this.dtgCargaBco.MultiSelect = false;
            this.dtgCargaBco.Name = "dtgCargaBco";
            this.dtgCargaBco.ReadOnly = true;
            this.dtgCargaBco.RowHeadersVisible = false;
            this.dtgCargaBco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCargaBco.Size = new System.Drawing.Size(702, 184);
            this.dtgCargaBco.TabIndex = 5;
            this.dtgCargaBco.SelectionChanged += new System.EventHandler(this.dtgCargaBco_SelectionChanged);
            // 
            // dFecha
            // 
            this.dFecha.DataPropertyName = "dFecha";
            this.dFecha.FillWeight = 50F;
            this.dFecha.HeaderText = "Fecha";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cNroOpe
            // 
            this.cNroOpe.DataPropertyName = "cNroOpe";
            this.cNroOpe.FillWeight = 50F;
            this.cNroOpe.HeaderText = "Nro. Operac.";
            this.cNroOpe.Name = "cNroOpe";
            this.cNroOpe.ReadOnly = true;
            // 
            // cUTC
            // 
            this.cUTC.DataPropertyName = "cUTC";
            this.cUTC.FillWeight = 20F;
            this.cUTC.HeaderText = "Cod. Operac.";
            this.cUTC.Name = "cUTC";
            this.cUTC.ReadOnly = true;
            // 
            // nMonto
            // 
            this.nMonto.DataPropertyName = "nMonto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nMonto.DefaultCellStyle = dataGridViewCellStyle2;
            this.nMonto.FillWeight = 50F;
            this.nMonto.HeaderText = "Monto";
            this.nMonto.Name = "nMonto";
            this.nMonto.ReadOnly = true;
            // 
            // lEstado
            // 
            this.lEstado.DataPropertyName = "lEstado";
            this.lEstado.FillWeight = 10F;
            this.lEstado.HeaderText = "Mig";
            this.lEstado.Name = "lEstado";
            this.lEstado.ReadOnly = true;
            // 
            // idMotOpeBanco
            // 
            this.idMotOpeBanco.DataPropertyName = "idMotOpeBanco";
            this.idMotOpeBanco.HeaderText = "idMotOpeBanco";
            this.idMotOpeBanco.Name = "idMotOpeBanco";
            this.idMotOpeBanco.ReadOnly = true;
            this.idMotOpeBanco.Visible = false;
            // 
            // idTipMedPago
            // 
            this.idTipMedPago.DataPropertyName = "idTipMedPago";
            this.idTipMedPago.HeaderText = "idTipMedPago";
            this.idTipMedPago.Name = "idTipMedPago";
            this.idTipMedPago.ReadOnly = true;
            this.idTipMedPago.Visible = false;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // idTipoPago
            // 
            this.idTipoPago.DataPropertyName = "idTipoPago";
            this.idTipoPago.HeaderText = "idTipoPago";
            this.idTipoPago.Name = "idTipoPago";
            this.idTipoPago.ReadOnly = true;
            this.idTipoPago.Visible = false;
            // 
            // idTipOpeMovBco
            // 
            this.idTipOpeMovBco.DataPropertyName = "idTipOpeMovBco";
            this.idTipOpeMovBco.HeaderText = "idTipOpeMovBco";
            this.idTipOpeMovBco.Name = "idTipOpeMovBco";
            this.idTipOpeMovBco.ReadOnly = true;
            this.idTipOpeMovBco.Visible = false;
            // 
            // idTipoTransac
            // 
            this.idTipoTransac.DataPropertyName = "idTipoTransac";
            this.idTipoTransac.HeaderText = "idTipoTransac";
            this.idTipoTransac.Name = "idTipoTransac";
            this.idTipoTransac.ReadOnly = true;
            this.idTipoTransac.Visible = false;
            // 
            // cDocume
            // 
            this.cDocume.DataPropertyName = "cDocume";
            this.cDocume.HeaderText = "cDocume";
            this.cDocume.Name = "cDocume";
            this.cDocume.ReadOnly = true;
            this.cDocume.Visible = false;
            // 
            // idIdentifica
            // 
            this.idIdentifica.DataPropertyName = "idIdentifica";
            this.idIdentifica.HeaderText = "idIdentifica";
            this.idIdentifica.Name = "idIdentifica";
            this.idIdentifica.ReadOnly = true;
            this.idIdentifica.Visible = false;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoDestino
            // 
            this.idTipoDestino.DataPropertyName = "idTipoDestino";
            this.idTipoDestino.HeaderText = "idTipoDestino";
            this.idTipoDestino.Name = "idTipoDestino";
            this.idTipoDestino.ReadOnly = true;
            this.idTipoDestino.Visible = false;
            // 
            // cNomCli
            // 
            this.cNomCli.DataPropertyName = "cNomCli";
            this.cNomCli.HeaderText = "cNomCli";
            this.cNomCli.Name = "cNomCli";
            this.cNomCli.ReadOnly = true;
            this.cNomCli.Visible = false;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(655, 533);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(414, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(110, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Archivo a Cargar:";
            // 
            // grbDatosMovimiento
            // 
            this.grbDatosMovimiento.Controls.Add(this.lblBase12);
            this.grbDatosMovimiento.Controls.Add(this.txtNroConciliaBco);
            this.grbDatosMovimiento.Controls.Add(this.cboTipoMotOpeBco);
            this.grbDatosMovimiento.Controls.Add(this.grbCapInt);
            this.grbDatosMovimiento.Controls.Add(this.cboTipoPago);
            this.grbDatosMovimiento.Controls.Add(this.lblBase7);
            this.grbDatosMovimiento.Controls.Add(this.cboTipoOperacionBco);
            this.grbDatosMovimiento.Controls.Add(this.cboTipoDestino);
            this.grbDatosMovimiento.Controls.Add(this.cboTipoDocumentoBco);
            this.grbDatosMovimiento.Controls.Add(this.lblBase4);
            this.grbDatosMovimiento.Controls.Add(this.txtMontoOperac);
            this.grbDatosMovimiento.Controls.Add(this.lblBase3);
            this.grbDatosMovimiento.Controls.Add(this.lblBase2);
            this.grbDatosMovimiento.Controls.Add(this.txtConcepto);
            this.grbDatosMovimiento.Controls.Add(this.lblBase5);
            this.grbDatosMovimiento.Controls.Add(this.cboMedioPagoSunat);
            this.grbDatosMovimiento.Controls.Add(this.cboMotOperacionBco);
            this.grbDatosMovimiento.Controls.Add(this.txtDocumento);
            this.grbDatosMovimiento.Controls.Add(this.dtpfechaOperac);
            this.grbDatosMovimiento.Controls.Add(this.lblFechaOperacion);
            this.grbDatosMovimiento.Controls.Add(this.lblMonto);
            this.grbDatosMovimiento.Controls.Add(this.lblTipoDocumento);
            this.grbDatosMovimiento.Controls.Add(this.lblDocumento);
            this.grbDatosMovimiento.Controls.Add(this.lblMedioPagoSUNAT);
            this.grbDatosMovimiento.Controls.Add(this.lblMotivoOperacion);
            this.grbDatosMovimiento.Controls.Add(this.grbCliente);
            this.grbDatosMovimiento.Location = new System.Drawing.Point(13, 272);
            this.grbDatosMovimiento.Name = "grbDatosMovimiento";
            this.grbDatosMovimiento.Size = new System.Drawing.Size(696, 257);
            this.grbDatosMovimiento.TabIndex = 8;
            this.grbDatosMovimiento.TabStop = false;
            this.grbDatosMovimiento.Text = "Datos de Movimiento";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(393, 81);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(136, 13);
            this.lblBase12.TabIndex = 34;
            this.lblBase12.Text = "N° Oper. Concilia Bco:";
            // 
            // txtNroConciliaBco
            // 
            this.txtNroConciliaBco.Location = new System.Drawing.Point(528, 77);
            this.txtNroConciliaBco.MaxLength = 18;
            this.txtNroConciliaBco.Name = "txtNroConciliaBco";
            this.txtNroConciliaBco.Size = new System.Drawing.Size(162, 20);
            this.txtNroConciliaBco.TabIndex = 33;
            this.txtNroConciliaBco.Validated += new System.EventHandler(this.txtNroConciliaBco_Validated);
            // 
            // cboTipoMotOpeBco
            // 
            this.cboTipoMotOpeBco.FormattingEnabled = true;
            this.cboTipoMotOpeBco.Location = new System.Drawing.Point(121, 57);
            this.cboTipoMotOpeBco.Name = "cboTipoMotOpeBco";
            this.cboTipoMotOpeBco.Size = new System.Drawing.Size(150, 21);
            this.cboTipoMotOpeBco.TabIndex = 2;
            this.cboTipoMotOpeBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoMotOpeBco_SelectedIndexChanged);
            // 
            // grbCapInt
            // 
            this.grbCapInt.Controls.Add(this.rbtCapital);
            this.grbCapInt.Controls.Add(this.rbtInteres);
            this.grbCapInt.Location = new System.Drawing.Point(281, 72);
            this.grbCapInt.Name = "grbCapInt";
            this.grbCapInt.Size = new System.Drawing.Size(101, 51);
            this.grbCapInt.TabIndex = 3;
            this.grbCapInt.TabStop = false;
            // 
            // rbtCapital
            // 
            this.rbtCapital.AutoSize = true;
            this.rbtCapital.Checked = true;
            this.rbtCapital.Enabled = false;
            this.rbtCapital.ForeColor = System.Drawing.Color.Navy;
            this.rbtCapital.Location = new System.Drawing.Point(22, 10);
            this.rbtCapital.Name = "rbtCapital";
            this.rbtCapital.Size = new System.Drawing.Size(57, 17);
            this.rbtCapital.TabIndex = 0;
            this.rbtCapital.TabStop = true;
            this.rbtCapital.Text = "Capital";
            this.rbtCapital.UseVisualStyleBackColor = true;
            // 
            // rbtInteres
            // 
            this.rbtInteres.AutoSize = true;
            this.rbtInteres.Enabled = false;
            this.rbtInteres.ForeColor = System.Drawing.Color.Navy;
            this.rbtInteres.Location = new System.Drawing.Point(22, 32);
            this.rbtInteres.Name = "rbtInteres";
            this.rbtInteres.Size = new System.Drawing.Size(57, 17);
            this.rbtInteres.TabIndex = 1;
            this.rbtInteres.Text = "Interés";
            this.rbtInteres.UseVisualStyleBackColor = true;
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(528, 15);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(163, 21);
            this.cboTipoPago.TabIndex = 9;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            this.cboTipoPago.Leave += new System.EventHandler(this.cboTipoPago_Leave);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(393, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(68, 13);
            this.lblBase7.TabIndex = 32;
            this.lblBase7.Text = "Tipo Pago:";
            // 
            // cboTipoOperacionBco
            // 
            this.cboTipoOperacionBco.FormattingEnabled = true;
            this.cboTipoOperacionBco.Location = new System.Drawing.Point(121, 98);
            this.cboTipoOperacionBco.Name = "cboTipoOperacionBco";
            this.cboTipoOperacionBco.Size = new System.Drawing.Size(150, 21);
            this.cboTipoOperacionBco.TabIndex = 6;
            this.cboTipoOperacionBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoOperacionBco_SelectedIndexChanged);
            // 
            // cboTipoDestino
            // 
            this.cboTipoDestino.FormattingEnabled = true;
            this.cboTipoDestino.Location = new System.Drawing.Point(121, 119);
            this.cboTipoDestino.Name = "cboTipoDestino";
            this.cboTipoDestino.Size = new System.Drawing.Size(150, 21);
            this.cboTipoDestino.TabIndex = 7;
            this.cboTipoDestino.SelectedIndexChanged += new System.EventHandler(this.cboTipoDestino_SelectedIndexChanged);
            // 
            // cboTipoDocumentoBco
            // 
            this.cboTipoDocumentoBco.FormattingEnabled = true;
            this.cboTipoDocumentoBco.Location = new System.Drawing.Point(528, 36);
            this.cboTipoDocumentoBco.Name = "cboTipoDocumentoBco";
            this.cboTipoDocumentoBco.Size = new System.Drawing.Size(162, 21);
            this.cboTipoDocumentoBco.TabIndex = 10;
            this.cboTipoDocumentoBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumentoBco_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 123);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 27;
            this.lblBase4.Text = "Tipo Destino:";
            // 
            // txtMontoOperac
            // 
            this.txtMontoOperac.Enabled = false;
            this.txtMontoOperac.FormatoDecimal = false;
            this.txtMontoOperac.Location = new System.Drawing.Point(121, 78);
            this.txtMontoOperac.MaxLength = 17;
            this.txtMontoOperac.Name = "txtMontoOperac";
            this.txtMontoOperac.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoOperac.nNumDecimales = 4;
            this.txtMontoOperac.nvalor = 0D;
            this.txtMontoOperac.Size = new System.Drawing.Size(150, 20);
            this.txtMontoOperac.TabIndex = 5;
            this.txtMontoOperac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 102);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(74, 13);
            this.lblBase3.TabIndex = 23;
            this.lblBase3.Text = "Tipo Ident.:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 201);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Concepto:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(121, 201);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(569, 46);
            this.txtConcepto.TabIndex = 15;
            this.txtConcepto.Validated += new System.EventHandler(this.txtConcepto_Validated);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 61);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(98, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Tipo Operación:";
            // 
            // cboMedioPagoSunat
            // 
            this.cboMedioPagoSunat.FormattingEnabled = true;
            this.cboMedioPagoSunat.Location = new System.Drawing.Point(121, 36);
            this.cboMedioPagoSunat.Name = "cboMedioPagoSunat";
            this.cboMedioPagoSunat.Size = new System.Drawing.Size(259, 21);
            this.cboMedioPagoSunat.TabIndex = 1;
            this.cboMedioPagoSunat.SelectedIndexChanged += new System.EventHandler(this.cboMedioPagoSunat_SelectedIndexChanged);
            // 
            // cboMotOperacionBco
            // 
            this.cboMotOperacionBco.FormattingEnabled = true;
            this.cboMotOperacionBco.Location = new System.Drawing.Point(121, 15);
            this.cboMotOperacionBco.Name = "cboMotOperacionBco";
            this.cboMotOperacionBco.Size = new System.Drawing.Size(259, 21);
            this.cboMotOperacionBco.TabIndex = 0;
            this.cboMotOperacionBco.SelectedIndexChanged += new System.EventHandler(this.cboMotOperacionBco_SelectedIndexChanged);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(528, 57);
            this.txtDocumento.MaxLength = 18;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(162, 20);
            this.txtDocumento.TabIndex = 11;
            this.txtDocumento.Validated += new System.EventHandler(this.txtDocumento_Validated);
            // 
            // dtpfechaOperac
            // 
            this.dtpfechaOperac.Enabled = false;
            this.dtpfechaOperac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaOperac.Location = new System.Drawing.Point(527, 97);
            this.dtpfechaOperac.Name = "dtpfechaOperac";
            this.dtpfechaOperac.Size = new System.Drawing.Size(113, 20);
            this.dtpfechaOperac.TabIndex = 13;
            // 
            // lblFechaOperacion
            // 
            this.lblFechaOperacion.AutoSize = true;
            this.lblFechaOperacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaOperacion.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaOperacion.Location = new System.Drawing.Point(393, 101);
            this.lblFechaOperacion.Name = "lblFechaOperacion";
            this.lblFechaOperacion.Size = new System.Drawing.Size(107, 13);
            this.lblFechaOperacion.TabIndex = 8;
            this.lblFechaOperacion.Text = "Fecha Operación:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(6, 82);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 7;
            this.lblMonto.Text = "Monto:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoDocumento.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoDocumento.Location = new System.Drawing.Point(393, 40);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(105, 13);
            this.lblTipoDocumento.TabIndex = 5;
            this.lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDocumento.ForeColor = System.Drawing.Color.Navy;
            this.lblDocumento.Location = new System.Drawing.Point(393, 61);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(77, 13);
            this.lblDocumento.TabIndex = 4;
            this.lblDocumento.Text = "Documento:";
            // 
            // lblMedioPagoSUNAT
            // 
            this.lblMedioPagoSUNAT.AutoSize = true;
            this.lblMedioPagoSUNAT.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMedioPagoSUNAT.ForeColor = System.Drawing.Color.Navy;
            this.lblMedioPagoSUNAT.Location = new System.Drawing.Point(6, 40);
            this.lblMedioPagoSUNAT.Name = "lblMedioPagoSUNAT";
            this.lblMedioPagoSUNAT.Size = new System.Drawing.Size(114, 13);
            this.lblMedioPagoSUNAT.TabIndex = 1;
            this.lblMedioPagoSUNAT.Text = "Medio Pago Sunat:";
            // 
            // lblMotivoOperacion
            // 
            this.lblMotivoOperacion.AutoSize = true;
            this.lblMotivoOperacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotivoOperacion.ForeColor = System.Drawing.Color.Navy;
            this.lblMotivoOperacion.Location = new System.Drawing.Point(6, 19);
            this.lblMotivoOperacion.Name = "lblMotivoOperacion";
            this.lblMotivoOperacion.Size = new System.Drawing.Size(66, 13);
            this.lblMotivoOperacion.TabIndex = 0;
            this.lblMotivoOperacion.Text = "Concepto:";
            // 
            // grbCliente
            // 
            this.grbCliente.Controls.Add(this.txtCliente);
            this.grbCliente.Controls.Add(this.txtCodigo);
            this.grbCliente.Controls.Add(this.btnBusquedaDestino);
            this.grbCliente.Controls.Add(this.lblBase6);
            this.grbCliente.Controls.Add(this.lblBase8);
            this.grbCliente.Location = new System.Drawing.Point(279, 127);
            this.grbCliente.Name = "grbCliente";
            this.grbCliente.Size = new System.Drawing.Size(412, 74);
            this.grbCliente.TabIndex = 8;
            this.grbCliente.TabStop = false;
            this.grbCliente.Text = "Beneficiario/Girador";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(59, 45);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(282, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(59, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(136, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // btnBusquedaDestino
            // 
            this.btnBusquedaDestino.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusquedaDestino.BackgroundImage")));
            this.btnBusquedaDestino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusquedaDestino.Location = new System.Drawing.Point(347, 18);
            this.btnBusquedaDestino.Name = "btnBusquedaDestino";
            this.btnBusquedaDestino.Size = new System.Drawing.Size(60, 50);
            this.btnBusquedaDestino.TabIndex = 2;
            this.btnBusquedaDestino.Text = "&Buscar";
            this.btnBusquedaDestino.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusquedaDestino.UseVisualStyleBackColor = true;
            this.btnBusquedaDestino.Click += new System.EventHandler(this.btnBusquedaDestino_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 49);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(52, 13);
            this.lblBase6.TabIndex = 29;
            this.lblBase6.Text = "Cliente:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(6, 24);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 28;
            this.lblBase8.Text = "Código:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(587, 533);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(140, 51);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(180, 21);
            this.cboMoneda1.TabIndex = 10;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(81, 55);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(56, 13);
            this.lblBase9.TabIndex = 11;
            this.lblBase9.Text = "Moneda:";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(13, 25);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 12;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(140, 28);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(203, 20);
            this.txtNroCuenta.TabIndex = 13;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(81, 32);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(53, 13);
            this.lblBase10.TabIndex = 14;
            this.lblBase10.Text = "Cuenta:";
            // 
            // frmCargaBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 609);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtNroCuenta);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbDatosMovimiento);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgCargaBco);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.btnImportar1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.btnBusqueda1);
            this.Name = "frmCargaBancos";
            this.Text = "Carga Masiva Bancos";
            this.Load += new System.EventHandler(this.frmCargaBancos_Load);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.btnImportar1, 0);
            this.Controls.SetChildIndex(this.txtArchivo, 0);
            this.Controls.SetChildIndex(this.dtgCargaBco, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbDatosMovimiento, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.txtNroCuenta, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargaBco)).EndInit();
            this.grbDatosMovimiento.ResumeLayout(false);
            this.grbDatosMovimiento.PerformLayout();
            this.grbCapInt.ResumeLayout(false);
            this.grbCapInt.PerformLayout();
            this.grbCliente.ResumeLayout(false);
            this.grbCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImportar btnImportar1;
        private GEN.ControlesBase.txtBase txtArchivo;
        private GEN.ControlesBase.dtgBase dtgCargaBco;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbDatosMovimiento;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtNroConciliaBco;
        private GEN.ControlesBase.cboBase cboTipoMotOpeBco;
        private GEN.ControlesBase.grbBase grbCapInt;
        private GEN.ControlesBase.rbtBase rbtCapital;
        private GEN.ControlesBase.rbtBase rbtInteres;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboBase cboTipoOperacionBco;
        private GEN.ControlesBase.cboTipoDestino cboTipoDestino;
        private GEN.ControlesBase.cboBase cboTipoDocumentoBco;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMontoOperac;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtConcepto;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboMedioPagoSunat cboMedioPagoSunat;
        private GEN.ControlesBase.cboMotOperacionBco cboMotOperacionBco;
        private GEN.ControlesBase.txtBase txtDocumento;
        private GEN.ControlesBase.dtpCorto dtpfechaOperac;
        private GEN.ControlesBase.lblBase lblFechaOperacion;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.ControlesBase.lblBase lblTipoDocumento;
        private GEN.ControlesBase.lblBase lblDocumento;
        private GEN.ControlesBase.lblBase lblMedioPagoSUNAT;
        private GEN.ControlesBase.lblBase lblMotivoOperacion;
        private GEN.ControlesBase.grbBase grbCliente;
        private GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.BotonesBase.btnBusqueda btnBusquedaDestino;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.lblBase lblBase10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMotOpeBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipMedPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipOpeMovBco;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoTransac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocume;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIdentifica;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCli;
    }
}