namespace CAJ.Presentacion
{
    partial class frmPagoCompCajChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoCompCajChica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.conBusCli = new GEN.ControlesBase.ConBusCliRuc();
            this.grbDatosCompr = new GEN.ControlesBase.grbBase(this.components);
            this.cboCajaChica = new GEN.ControlesBase.cboBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroCajChica = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.lblTipoComprobante = new GEN.ControlesBase.lblBase();
            this.lblCodigo = new GEN.ControlesBase.lblBase();
            this.txtSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.dtpFechaPago = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaPago = new GEN.ControlesBase.lblBase();
            this.lblFechaEmision = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtNumero = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.dtpFechaEmision = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblSerie = new GEN.ControlesBase.lblBase();
            this.lblNumero = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.txtConceptoPago = new GEN.ControlesBase.txtBase(this.components);
            this.lblGlosa = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTotCompro = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotOtrosDesc = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMontoPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtMontoITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.dtgAprobador = new GEN.ControlesBase.dtgBase(this.components);
            this.lSeleccionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idAprobadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAprobadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsApruebaComprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtgOtrosDescuentos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgComisiones = new GEN.ControlesBase.dtgBase(this.components);
            this.lOpcionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobantePagoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsTipoComisionesComprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtRetIGV = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcRetIGV = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipCamProm = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbDetPago = new GEN.ControlesBase.grbBase(this.components);
            this.cboCuenta = new GEN.ControlesBase.cboBase(this.components);
            this.txtNroCheque = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblCuenta = new GEN.ControlesBase.lblBase();
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblEntidadFinan = new GEN.ControlesBase.lblBase();
            this.lblCheque = new GEN.ControlesBase.lblBase();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase7 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.rbtnSinDetraccion = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnConDetraccion = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblDestino = new GEN.ControlesBase.lblBase();
            this.cboDestino = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase8 = new GEN.ControlesBase.grbBase(this.components);
            this.grbDatosCompr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsApruebaComprobanteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtrosDescuentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoComisionesComprobanteBindingSource)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbDetPago.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.grbBase6.SuspendLayout();
            this.grbBase7.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbBase8.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(8, 116);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(522, 78);
            this.conBusCli.TabIndex = 1;
            // 
            // grbDatosCompr
            // 
            this.grbDatosCompr.Controls.Add(this.cboCajaChica);
            this.grbDatosCompr.Controls.Add(this.cboAgencias1);
            this.grbDatosCompr.Controls.Add(this.lblBase4);
            this.grbDatosCompr.Controls.Add(this.txtNroCajChica);
            this.grbDatosCompr.Controls.Add(this.lblBase6);
            this.grbDatosCompr.Controls.Add(this.lblBase10);
            this.grbDatosCompr.Controls.Add(this.txtCodigo);
            this.grbDatosCompr.Controls.Add(this.cboTipoComprobantePago);
            this.grbDatosCompr.Controls.Add(this.lblTipoComprobante);
            this.grbDatosCompr.Controls.Add(this.lblCodigo);
            this.grbDatosCompr.Controls.Add(this.txtSerie);
            this.grbDatosCompr.Controls.Add(this.dtpFechaPago);
            this.grbDatosCompr.Controls.Add(this.lblFechaPago);
            this.grbDatosCompr.Controls.Add(this.lblFechaEmision);
            this.grbDatosCompr.Controls.Add(this.btnBusqueda);
            this.grbDatosCompr.Controls.Add(this.txtNumero);
            this.grbDatosCompr.Controls.Add(this.dtpFechaEmision);
            this.grbDatosCompr.Controls.Add(this.lblSerie);
            this.grbDatosCompr.Controls.Add(this.lblNumero);
            this.grbDatosCompr.Location = new System.Drawing.Point(8, 1);
            this.grbDatosCompr.Name = "grbDatosCompr";
            this.grbDatosCompr.Size = new System.Drawing.Size(796, 97);
            this.grbDatosCompr.TabIndex = 0;
            this.grbDatosCompr.TabStop = false;
            // 
            // cboCajaChica
            // 
            this.cboCajaChica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCajaChica.Enabled = false;
            this.cboCajaChica.FormattingEnabled = true;
            this.cboCajaChica.Location = new System.Drawing.Point(608, 14);
            this.cboCajaChica.Name = "cboCajaChica";
            this.cboCajaChica.Size = new System.Drawing.Size(180, 21);
            this.cboCajaChica.TabIndex = 61;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.Enabled = false;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(128, 14);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(200, 21);
            this.cboAgencias1.TabIndex = 60;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 59;
            this.lblBase4.Text = "Agencia:";
            // 
            // txtNroCajChica
            // 
            this.txtNroCajChica.Enabled = false;
            this.txtNroCajChica.Location = new System.Drawing.Point(430, 14);
            this.txtNroCajChica.Name = "txtNroCajChica";
            this.txtNroCajChica.Size = new System.Drawing.Size(92, 20);
            this.txtNroCajChica.TabIndex = 58;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(338, 18);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(90, 13);
            this.lblBase6.TabIndex = 57;
            this.lblBase6.Text = "Caj. Chica N°:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(528, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(75, 13);
            this.lblBase10.TabIndex = 56;
            this.lblBase10.Text = "Caja Chica:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(608, 43);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(111, 20);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.Enabled = false;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(128, 42);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(394, 21);
            this.cboTipoComprobantePago.TabIndex = 2;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoComprobante.Location = new System.Drawing.Point(7, 46);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(118, 13);
            this.lblTipoComprobante.TabIndex = 0;
            this.lblTipoComprobante.Text = "Tipo Comprobante:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigo.Location = new System.Drawing.Point(528, 46);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 13);
            this.lblCodigo.TabIndex = 8;
            this.lblCodigo.Text = "Codigo:";
            // 
            // txtSerie
            // 
            this.txtSerie.Enabled = false;
            this.txtSerie.Location = new System.Drawing.Point(281, 67);
            this.txtSerie.MaxLength = 5;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(52, 20);
            this.txtSerie.TabIndex = 5;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Enabled = false;
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(608, 67);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaPago.TabIndex = 12;
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaPago.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaPago.Location = new System.Drawing.Point(528, 71);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(77, 13);
            this.lblFechaPago.TabIndex = 11;
            this.lblFechaPago.Text = "Fecha Pago:";
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaEmision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaEmision.Location = new System.Drawing.Point(9, 71);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(93, 13);
            this.lblFechaEmision.TabIndex = 1;
            this.lblFechaEmision.Text = "Fecha Emisión:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(725, 40);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 10;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(393, 67);
            this.txtNumero.MaxLength = 18;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(129, 20);
            this.txtNumero.TabIndex = 7;
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Enabled = false;
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(128, 67);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaEmision.TabIndex = 3;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSerie.ForeColor = System.Drawing.Color.Navy;
            this.lblSerie.Location = new System.Drawing.Point(236, 71);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(42, 13);
            this.lblSerie.TabIndex = 4;
            this.lblSerie.Text = "Serie:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumero.ForeColor = System.Drawing.Color.Navy;
            this.lblNumero.Location = new System.Drawing.Point(334, 71);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 13);
            this.lblNumero.TabIndex = 6;
            this.lblNumero.Text = "Numero:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.ItemHeight = 13;
            this.cboMoneda.Location = new System.Drawing.Point(109, 15);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(122, 21);
            this.cboMoneda.TabIndex = 2;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(6, 18);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 0;
            this.lblMoneda.Text = "Moneda:";
            // 
            // txtConceptoPago
            // 
            this.txtConceptoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConceptoPago.Enabled = false;
            this.txtConceptoPago.Location = new System.Drawing.Point(7, 216);
            this.txtConceptoPago.Multiline = true;
            this.txtConceptoPago.Name = "txtConceptoPago";
            this.txtConceptoPago.Size = new System.Drawing.Size(238, 93);
            this.txtConceptoPago.TabIndex = 4;
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGlosa.ForeColor = System.Drawing.Color.Navy;
            this.lblGlosa.Location = new System.Drawing.Point(5, 200);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(147, 13);
            this.lblGlosa.TabIndex = 3;
            this.lblGlosa.Text = "Glosa del Comprobante:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 333);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(86, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo de Pago:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(128, 13);
            this.lblBase1.TabIndex = 61;
            this.lblBase1.Text = "Monto Comprobante:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 41);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(145, 13);
            this.lblBase3.TabIndex = 62;
            this.lblBase3.Text = "Total Otros Descuentos:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 67);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(110, 13);
            this.lblBase5.TabIndex = 63;
            this.lblBase5.Text = "Total Comisiónes:";
            this.lblBase5.Visible = false;
            // 
            // txtTotCompro
            // 
            this.txtTotCompro.Enabled = false;
            this.txtTotCompro.FormatoDecimal = true;
            this.txtTotCompro.Location = new System.Drawing.Point(149, 13);
            this.txtTotCompro.Name = "txtTotCompro";
            this.txtTotCompro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotCompro.nNumDecimales = 2;
            this.txtTotCompro.nvalor = 0D;
            this.txtTotCompro.ReadOnly = true;
            this.txtTotCompro.Size = new System.Drawing.Size(111, 20);
            this.txtTotCompro.TabIndex = 0;
            // 
            // txtTotOtrosDesc
            // 
            this.txtTotOtrosDesc.Enabled = false;
            this.txtTotOtrosDesc.FormatoDecimal = true;
            this.txtTotOtrosDesc.Location = new System.Drawing.Point(149, 37);
            this.txtTotOtrosDesc.Name = "txtTotOtrosDesc";
            this.txtTotOtrosDesc.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotOtrosDesc.nNumDecimales = 4;
            this.txtTotOtrosDesc.nvalor = 0D;
            this.txtTotOtrosDesc.ReadOnly = true;
            this.txtTotOtrosDesc.Size = new System.Drawing.Size(111, 20);
            this.txtTotOtrosDesc.TabIndex = 1;
            // 
            // txtTotComision
            // 
            this.txtTotComision.Enabled = false;
            this.txtTotComision.FormatoDecimal = true;
            this.txtTotComision.Location = new System.Drawing.Point(149, 62);
            this.txtTotComision.Name = "txtTotComision";
            this.txtTotComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotComision.nNumDecimales = 2;
            this.txtTotComision.nvalor = 0D;
            this.txtTotComision.ReadOnly = true;
            this.txtTotComision.Size = new System.Drawing.Size(111, 20);
            this.txtTotComision.TabIndex = 2;
            this.txtTotComision.Visible = false;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.FormatoDecimal = true;
            this.txtTipoCambio.Location = new System.Drawing.Point(150, 37);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipoCambio.nNumDecimales = 2;
            this.txtTipoCambio.nvalor = 0D;
            this.txtTipoCambio.ReadOnly = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(111, 20);
            this.txtTipoCambio.TabIndex = 4;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 41);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(102, 13);
            this.lblBase7.TabIndex = 71;
            this.lblBase7.Text = "Tipo de Cambio:";
            // 
            // txtMontoPagar
            // 
            this.txtMontoPagar.Enabled = false;
            this.txtMontoPagar.FormatoDecimal = true;
            this.txtMontoPagar.Location = new System.Drawing.Point(150, 61);
            this.txtMontoPagar.Name = "txtMontoPagar";
            this.txtMontoPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoPagar.nNumDecimales = 2;
            this.txtMontoPagar.nvalor = 0D;
            this.txtMontoPagar.ReadOnly = true;
            this.txtMontoPagar.Size = new System.Drawing.Size(111, 20);
            this.txtMontoPagar.TabIndex = 5;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 65);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(120, 13);
            this.lblBase8.TabIndex = 73;
            this.lblBase8.Text = "IMPORTE A PAGAR:";
            // 
            // txtMontoITF
            // 
            this.txtMontoITF.Enabled = false;
            this.txtMontoITF.FormatoDecimal = true;
            this.txtMontoITF.Location = new System.Drawing.Point(150, 86);
            this.txtMontoITF.Name = "txtMontoITF";
            this.txtMontoITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoITF.nNumDecimales = 2;
            this.txtMontoITF.nvalor = 0D;
            this.txtMontoITF.ReadOnly = true;
            this.txtMontoITF.Size = new System.Drawing.Size(111, 20);
            this.txtMontoITF.TabIndex = 6;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 89);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(68, 13);
            this.lblBase9.TabIndex = 75;
            this.lblBase9.Text = "Monto ITF:";
            // 
            // dtgAprobador
            // 
            this.dtgAprobador.AllowUserToAddRows = false;
            this.dtgAprobador.AllowUserToDeleteRows = false;
            this.dtgAprobador.AllowUserToResizeColumns = false;
            this.dtgAprobador.AllowUserToResizeRows = false;
            this.dtgAprobador.AutoGenerateColumns = false;
            this.dtgAprobador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAprobador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAprobador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lSeleccionDataGridViewCheckBoxColumn,
            this.idAprobadorDataGridViewTextBoxColumn,
            this.cAprobadorDataGridViewTextBoxColumn,
            this.dataGridViewCheckBoxColumn1});
            this.dtgAprobador.DataSource = this.clsApruebaComprobanteBindingSource;
            this.dtgAprobador.Location = new System.Drawing.Point(6, 15);
            this.dtgAprobador.MultiSelect = false;
            this.dtgAprobador.Name = "dtgAprobador";
            this.dtgAprobador.ReadOnly = true;
            this.dtgAprobador.RowHeadersVisible = false;
            this.dtgAprobador.RowTemplate.Height = 18;
            this.dtgAprobador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAprobador.Size = new System.Drawing.Size(389, 70);
            this.dtgAprobador.TabIndex = 0;
            this.dtgAprobador.Visible = false;
            // 
            // lSeleccionDataGridViewCheckBoxColumn
            // 
            this.lSeleccionDataGridViewCheckBoxColumn.DataPropertyName = "lSeleccion";
            this.lSeleccionDataGridViewCheckBoxColumn.FillWeight = 17.2372F;
            this.lSeleccionDataGridViewCheckBoxColumn.HeaderText = "Sel";
            this.lSeleccionDataGridViewCheckBoxColumn.Name = "lSeleccionDataGridViewCheckBoxColumn";
            this.lSeleccionDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idAprobadorDataGridViewTextBoxColumn
            // 
            this.idAprobadorDataGridViewTextBoxColumn.DataPropertyName = "idAprobador";
            this.idAprobadorDataGridViewTextBoxColumn.FillWeight = 94.58545F;
            this.idAprobadorDataGridViewTextBoxColumn.HeaderText = "idAprobador";
            this.idAprobadorDataGridViewTextBoxColumn.Name = "idAprobadorDataGridViewTextBoxColumn";
            this.idAprobadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAprobadorDataGridViewTextBoxColumn.Visible = false;
            // 
            // cAprobadorDataGridViewTextBoxColumn
            // 
            this.cAprobadorDataGridViewTextBoxColumn.DataPropertyName = "cAprobador";
            this.cAprobadorDataGridViewTextBoxColumn.FillWeight = 118.5919F;
            this.cAprobadorDataGridViewTextBoxColumn.HeaderText = "Aprobador";
            this.cAprobadorDataGridViewTextBoxColumn.Name = "cAprobadorDataGridViewTextBoxColumn";
            this.cAprobadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "lVigente";
            this.dataGridViewCheckBoxColumn1.FillWeight = 94.58545F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "lVigente";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // clsApruebaComprobanteBindingSource
            // 
            this.clsApruebaComprobanteBindingSource.DataSource = typeof(EntityLayer.clsApruebaCPGPago);
            // 
            // dtgOtrosDescuentos
            // 
            this.dtgOtrosDescuentos.AllowUserToAddRows = false;
            this.dtgOtrosDescuentos.AllowUserToDeleteRows = false;
            this.dtgOtrosDescuentos.AllowUserToResizeColumns = false;
            this.dtgOtrosDescuentos.AllowUserToResizeRows = false;
            this.dtgOtrosDescuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOtrosDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOtrosDescuentos.Location = new System.Drawing.Point(6, 19);
            this.dtgOtrosDescuentos.MultiSelect = false;
            this.dtgOtrosDescuentos.Name = "dtgOtrosDescuentos";
            this.dtgOtrosDescuentos.ReadOnly = true;
            this.dtgOtrosDescuentos.RowHeadersVisible = false;
            this.dtgOtrosDescuentos.RowTemplate.Height = 18;
            this.dtgOtrosDescuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOtrosDescuentos.Size = new System.Drawing.Size(271, 89);
            this.dtgOtrosDescuentos.TabIndex = 0;
            // 
            // dtgComisiones
            // 
            this.dtgComisiones.AllowUserToAddRows = false;
            this.dtgComisiones.AllowUserToDeleteRows = false;
            this.dtgComisiones.AllowUserToResizeColumns = false;
            this.dtgComisiones.AllowUserToResizeRows = false;
            this.dtgComisiones.AutoGenerateColumns = false;
            this.dtgComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lOpcionDataGridViewCheckBoxColumn,
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn,
            this.cComisionDataGridViewTextBoxColumn,
            this.nMontoDataGridViewTextBoxColumn1,
            this.idComprobantePagoDataGridViewTextBoxColumn1,
            this.lVigenteDataGridViewCheckBoxColumn1});
            this.dtgComisiones.DataSource = this.clsTipoComisionesComprobanteBindingSource;
            this.dtgComisiones.Location = new System.Drawing.Point(6, 15);
            this.dtgComisiones.MultiSelect = false;
            this.dtgComisiones.Name = "dtgComisiones";
            this.dtgComisiones.ReadOnly = true;
            this.dtgComisiones.RowHeadersVisible = false;
            this.dtgComisiones.RowTemplate.Height = 18;
            this.dtgComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComisiones.Size = new System.Drawing.Size(271, 84);
            this.dtgComisiones.TabIndex = 0;
            this.dtgComisiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgComisiones_CellContentClick);
            this.dtgComisiones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgComisiones_CellEndEdit);
            this.dtgComisiones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgComisiones_CellValueChanged);
            this.dtgComisiones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgComisiones_DataError);
            this.dtgComisiones.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgComisiones_EditingControlShowing);
            // 
            // lOpcionDataGridViewCheckBoxColumn
            // 
            this.lOpcionDataGridViewCheckBoxColumn.DataPropertyName = "lOpcion";
            this.lOpcionDataGridViewCheckBoxColumn.FillWeight = 15F;
            this.lOpcionDataGridViewCheckBoxColumn.HeaderText = "X";
            this.lOpcionDataGridViewCheckBoxColumn.Name = "lOpcionDataGridViewCheckBoxColumn";
            this.lOpcionDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idTipoComisionComprPagoDataGridViewTextBoxColumn
            // 
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn.DataPropertyName = "idTipoComisionComprPago";
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn.HeaderText = "idTipoComisionComprPago";
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn.Name = "idTipoComisionComprPagoDataGridViewTextBoxColumn";
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoComisionComprPagoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cComisionDataGridViewTextBoxColumn
            // 
            this.cComisionDataGridViewTextBoxColumn.DataPropertyName = "cComision";
            this.cComisionDataGridViewTextBoxColumn.HeaderText = "Comisión";
            this.cComisionDataGridViewTextBoxColumn.Name = "cComisionDataGridViewTextBoxColumn";
            this.cComisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMontoDataGridViewTextBoxColumn1
            // 
            this.nMontoDataGridViewTextBoxColumn1.DataPropertyName = "nMonto";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.nMontoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.nMontoDataGridViewTextBoxColumn1.FillWeight = 35F;
            this.nMontoDataGridViewTextBoxColumn1.HeaderText = "Monto";
            this.nMontoDataGridViewTextBoxColumn1.Name = "nMontoDataGridViewTextBoxColumn1";
            this.nMontoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idComprobantePagoDataGridViewTextBoxColumn1
            // 
            this.idComprobantePagoDataGridViewTextBoxColumn1.DataPropertyName = "idComprobantePago";
            this.idComprobantePagoDataGridViewTextBoxColumn1.HeaderText = "idComprobantePago";
            this.idComprobantePagoDataGridViewTextBoxColumn1.Name = "idComprobantePagoDataGridViewTextBoxColumn1";
            this.idComprobantePagoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idComprobantePagoDataGridViewTextBoxColumn1.Visible = false;
            // 
            // lVigenteDataGridViewCheckBoxColumn1
            // 
            this.lVigenteDataGridViewCheckBoxColumn1.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.Name = "lVigenteDataGridViewCheckBoxColumn1";
            this.lVigenteDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // clsTipoComisionesComprobanteBindingSource
            // 
            this.clsTipoComisionesComprobanteBindingSource.DataSource = typeof(EntityLayer.clsTipoComisionesComprobante);
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(7, 45);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(102, 13);
            this.lblBase14.TabIndex = 1;
            this.lblBase14.Text = "Tip Cam. Prom.:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTotCompro);
            this.grbBase2.Controls.Add(this.txtTotOtrosDesc);
            this.grbBase2.Controls.Add(this.txtTotComision);
            this.grbBase2.Controls.Add(this.txtRetIGV);
            this.grbBase2.Controls.Add(this.txtTipoCambio);
            this.grbBase2.Controls.Add(this.txtMontoPagar);
            this.grbBase2.Controls.Add(this.txtMontoITF);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.chcRetIGV);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Location = new System.Drawing.Point(536, 196);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(268, 125);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            // 
            // txtRetIGV
            // 
            this.txtRetIGV.Enabled = false;
            this.txtRetIGV.FormatoDecimal = true;
            this.txtRetIGV.Location = new System.Drawing.Point(149, 86);
            this.txtRetIGV.Name = "txtRetIGV";
            this.txtRetIGV.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRetIGV.nNumDecimales = 2;
            this.txtRetIGV.nvalor = 0D;
            this.txtRetIGV.ReadOnly = true;
            this.txtRetIGV.Size = new System.Drawing.Size(111, 20);
            this.txtRetIGV.TabIndex = 3;
            this.txtRetIGV.Visible = false;
            // 
            // chcRetIGV
            // 
            this.chcRetIGV.AutoSize = true;
            this.chcRetIGV.ForeColor = System.Drawing.Color.Navy;
            this.chcRetIGV.Location = new System.Drawing.Point(10, 88);
            this.chcRetIGV.Name = "chcRetIGV";
            this.chcRetIGV.Size = new System.Drawing.Size(116, 17);
            this.chcRetIGV.TabIndex = 76;
            this.chcRetIGV.Text = "Retención del IGV:";
            this.chcRetIGV.UseVisualStyleBackColor = true;
            this.chcRetIGV.Visible = false;
            this.chcRetIGV.CheckedChanged += new System.EventHandler(this.chcRetIGV_CheckedChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtTipCamProm);
            this.grbBase3.Controls.Add(this.lblMoneda);
            this.grbBase3.Controls.Add(this.cboMoneda);
            this.grbBase3.Controls.Add(this.lblBase14);
            this.grbBase3.Location = new System.Drawing.Point(248, 315);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(238, 70);
            this.grbBase3.TabIndex = 6;
            this.grbBase3.TabStop = false;
            // 
            // txtTipCamProm
            // 
            this.txtTipCamProm.Enabled = false;
            this.txtTipCamProm.FormatoDecimal = true;
            this.txtTipCamProm.Location = new System.Drawing.Point(109, 42);
            this.txtTipCamProm.Name = "txtTipCamProm";
            this.txtTipCamProm.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamProm.nNumDecimales = 4;
            this.txtTipCamProm.nvalor = 0D;
            this.txtTipCamProm.Size = new System.Drawing.Size(122, 20);
            this.txtTipCamProm.TabIndex = 3;
            // 
            // grbDetPago
            // 
            this.grbDetPago.Controls.Add(this.cboCuenta);
            this.grbDetPago.Controls.Add(this.txtNroCheque);
            this.grbDetPago.Controls.Add(this.lblCuenta);
            this.grbDetPago.Controls.Add(this.cboEntidad);
            this.grbDetPago.Controls.Add(this.lblEntidadFinan);
            this.grbDetPago.Controls.Add(this.lblCheque);
            this.grbDetPago.ForeColor = System.Drawing.Color.Navy;
            this.grbDetPago.Location = new System.Drawing.Point(7, 461);
            this.grbDetPago.Name = "grbDetPago";
            this.grbDetPago.Size = new System.Drawing.Size(387, 90);
            this.grbDetPago.TabIndex = 11;
            this.grbDetPago.TabStop = false;
            this.grbDetPago.Text = "Detalle Pago";
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(128, 39);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(253, 21);
            this.cboCuenta.TabIndex = 25;
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(128, 64);
            this.txtNroCheque.MaxLength = 9;
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(102, 20);
            this.txtNroCheque.TabIndex = 22;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblCuenta.Location = new System.Drawing.Point(10, 43);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(95, 13);
            this.lblCuenta.TabIndex = 23;
            this.lblCuenta.Text = "Nro de Cuenta:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(128, 15);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(253, 21);
            this.cboEntidad.TabIndex = 24;
            this.cboEntidad.SelectedIndexChanged += new System.EventHandler(this.cboEntidad_SelectedIndexChanged);
            // 
            // lblEntidadFinan
            // 
            this.lblEntidadFinan.AutoSize = true;
            this.lblEntidadFinan.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidadFinan.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidadFinan.Location = new System.Drawing.Point(9, 19);
            this.lblEntidadFinan.Name = "lblEntidadFinan";
            this.lblEntidadFinan.Size = new System.Drawing.Size(116, 13);
            this.lblEntidadFinan.TabIndex = 23;
            this.lblEntidadFinan.Text = "Entidad Financiera:";
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCheque.ForeColor = System.Drawing.Color.Navy;
            this.lblCheque.Location = new System.Drawing.Point(10, 69);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(98, 13);
            this.lblCheque.TabIndex = 20;
            this.lblCheque.Text = "Nro de Cheque:";
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.dtgAprobador);
            this.grbBase5.ForeColor = System.Drawing.Color.Navy;
            this.grbBase5.Location = new System.Drawing.Point(401, 461);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(403, 90);
            this.grbBase5.TabIndex = 13;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Pago Con Autorización de Gerencia:";
            this.grbBase5.Visible = false;
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.dtgOtrosDescuentos);
            this.grbBase6.ForeColor = System.Drawing.Color.Navy;
            this.grbBase6.Location = new System.Drawing.Point(247, 197);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(283, 112);
            this.grbBase6.TabIndex = 5;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Otros Descuentos:";
            // 
            // grbBase7
            // 
            this.grbBase7.Controls.Add(this.dtgComisiones);
            this.grbBase7.ForeColor = System.Drawing.Color.Navy;
            this.grbBase7.Location = new System.Drawing.Point(8, 461);
            this.grbBase7.Name = "grbBase7";
            this.grbBase7.Size = new System.Drawing.Size(283, 103);
            this.grbBase7.TabIndex = 7;
            this.grbBase7.TabStop = false;
            this.grbBase7.Text = "Comisiones:";
            this.grbBase7.Visible = false;
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(99, 330);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(139, 21);
            this.cboTipoPago.TabIndex = 10;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(678, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Location = new System.Drawing.Point(618, 328);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 16;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(744, 327);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(558, 328);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(498, 328);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // rbtnSinDetraccion
            // 
            this.rbtnSinDetraccion.AutoSize = true;
            this.rbtnSinDetraccion.Enabled = false;
            this.rbtnSinDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnSinDetraccion.ForeColor = System.Drawing.Color.Navy;
            this.rbtnSinDetraccion.Location = new System.Drawing.Point(14, 18);
            this.rbtnSinDetraccion.Name = "rbtnSinDetraccion";
            this.rbtnSinDetraccion.Size = new System.Drawing.Size(95, 17);
            this.rbtnSinDetraccion.TabIndex = 20;
            this.rbtnSinDetraccion.TabStop = true;
            this.rbtnSinDetraccion.Text = "Sin Detracción";
            this.rbtnSinDetraccion.UseVisualStyleBackColor = true;
            // 
            // rbtnConDetraccion
            // 
            this.rbtnConDetraccion.AutoSize = true;
            this.rbtnConDetraccion.Enabled = false;
            this.rbtnConDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnConDetraccion.ForeColor = System.Drawing.Color.Navy;
            this.rbtnConDetraccion.Location = new System.Drawing.Point(134, 18);
            this.rbtnConDetraccion.Name = "rbtnConDetraccion";
            this.rbtnConDetraccion.Size = new System.Drawing.Size(99, 17);
            this.rbtnConDetraccion.TabIndex = 21;
            this.rbtnConDetraccion.TabStop = true;
            this.rbtnConDetraccion.Text = "Con Detracción";
            this.rbtnConDetraccion.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.rbtnSinDetraccion);
            this.grbBase4.Controls.Add(this.rbtnConDetraccion);
            this.grbBase4.Location = new System.Drawing.Point(536, 113);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(268, 43);
            this.grbBase4.TabIndex = 22;
            this.grbBase4.TabStop = false;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDestino.ForeColor = System.Drawing.Color.Navy;
            this.lblDestino.Location = new System.Drawing.Point(19, 16);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(55, 13);
            this.lblDestino.TabIndex = 57;
            this.lblDestino.Text = "Destino:";
            // 
            // cboDestino
            // 
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.Enabled = false;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(80, 13);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(150, 21);
            this.cboDestino.TabIndex = 56;
            // 
            // grbBase8
            // 
            this.grbBase8.Controls.Add(this.lblDestino);
            this.grbBase8.Controls.Add(this.cboDestino);
            this.grbBase8.Location = new System.Drawing.Point(536, 156);
            this.grbBase8.Name = "grbBase8";
            this.grbBase8.Size = new System.Drawing.Size(268, 43);
            this.grbBase8.TabIndex = 23;
            this.grbBase8.TabStop = false;
            // 
            // frmPagoCompCajChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 416);
            this.Controls.Add(this.grbBase8);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.grbBase5);
            this.Controls.Add(this.grbDetPago);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtConceptoPago);
            this.Controls.Add(this.lblGlosa);
            this.Controls.Add(this.grbDatosCompr);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase7);
            this.Name = "frmPagoCompCajChica";
            this.Text = "Pago de Comprobantes";
            this.Load += new System.EventHandler(this.frmPagoCompCajChica_Load);
            this.Controls.SetChildIndex(this.grbBase7, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbDatosCompr, 0);
            this.Controls.SetChildIndex(this.lblGlosa, 0);
            this.Controls.SetChildIndex(this.txtConceptoPago, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbDetPago, 0);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.Controls.SetChildIndex(this.cboTipoPago, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase8, 0);
            this.grbDatosCompr.ResumeLayout(false);
            this.grbDatosCompr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsApruebaComprobanteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtrosDescuentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoComisionesComprobanteBindingSource)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbDetPago.ResumeLayout(false);
            this.grbDetPago.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase6.ResumeLayout(false);
            this.grbBase7.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbBase8.ResumeLayout(false);
            this.grbBase8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCliRuc conBusCli;
        private GEN.ControlesBase.grbBase grbDatosCompr;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtSerie;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumero;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.lblBase lblTipoComprobante;
        private GEN.ControlesBase.lblBase lblCodigo;
        private GEN.ControlesBase.lblBase lblFechaEmision;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtpCorto dtpFechaEmision;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.lblBase lblNumero;
        private GEN.ControlesBase.lblBase lblSerie;
        private GEN.ControlesBase.dtpCorto dtpFechaPago;
        private GEN.ControlesBase.lblBase lblFechaPago;
        private GEN.ControlesBase.txtBase txtConceptoPago;
        private GEN.ControlesBase.lblBase lblGlosa;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtTotCompro;
        private GEN.ControlesBase.txtNumRea txtTotOtrosDesc;
        private GEN.ControlesBase.txtNumRea txtTotComision;
        private GEN.ControlesBase.txtNumRea txtTipoCambio;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtMontoPagar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtMontoITF;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.ControlesBase.dtgBase dtgAprobador;
        private GEN.ControlesBase.dtgBase dtgOtrosDescuentos;
        private GEN.ControlesBase.dtgBase dtgComisiones;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtTipCamProm;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbDetPago;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.grbBase grbBase7;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDescuentosComprPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobantePagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDescComPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clsTipoComisionesComprobanteBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpcionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoComisionComprPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobantePagoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn1;
        private GEN.ControlesBase.lblBase lblCuenta;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.lblBase lblEntidadFinan;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCheque;
        private GEN.ControlesBase.lblBase lblCheque;
        private GEN.ControlesBase.cboBase cboCuenta;
        private GEN.ControlesBase.txtNumRea txtRetIGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSeleccionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAprobadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAprobadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource clsApruebaComprobanteBindingSource;
        private GEN.ControlesBase.rbtnBase rbtnSinDetraccion;
        private GEN.ControlesBase.rbtnBase rbtnConDetraccion;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.chcBase chcRetIGV;
        private GEN.ControlesBase.lblBase lblDestino;
        private GEN.ControlesBase.cboBase cboDestino;
        private GEN.ControlesBase.grbBase grbBase8;
        private GEN.ControlesBase.cboBase cboCajaChica;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCajChica;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase10;
    }
}