namespace CAJ.Presentacion
{
    partial class frmMovimientosBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientosBancos));
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.chcVerificarFecha = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBco = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.txtSaldoContable = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSaldoDisponible = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblSaldoDisponible = new GEN.ControlesBase.lblBase();
            this.lblSaldoContable = new GEN.ControlesBase.lblBase();
            this.lblNumeroCuenta = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.btnBusCtaBco = new GEN.BotonesBase.btnBusqueda();
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
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMedioPagoSunat = new GEN.ControlesBase.cboMedioPagoSunat(this.components);
            this.cboMotOperacionBco = new GEN.ControlesBase.cboMotOperacionBco(this.components);
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpfechaOperac = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaOperacion = new GEN.ControlesBase.lblBase();
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.lblTEA = new GEN.ControlesBase.lblBase();
            this.lblTipoDocumento = new GEN.ControlesBase.lblBase();
            this.lblDocumento = new GEN.ControlesBase.lblBase();
            this.lblMedioPagoSUNAT = new GEN.ControlesBase.lblBase();
            this.lblMotivoOperacion = new GEN.ControlesBase.lblBase();
            this.grbCliente = new GEN.ControlesBase.grbBase(this.components);
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusquedaDestino = new GEN.BotonesBase.btnBusqueda();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgMovimientos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDatosCuenta.SuspendLayout();
            this.grbDatosMovimiento.SuspendLayout();
            this.grbCapInt.SuspendLayout();
            this.grbCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.btnProcesar1);
            this.grbDatosCuenta.Controls.Add(this.chcVerificarFecha);
            this.grbDatosCuenta.Controls.Add(this.lblBase11);
            this.grbDatosCuenta.Controls.Add(this.lblBase10);
            this.grbDatosCuenta.Controls.Add(this.dtpFechaFin);
            this.grbDatosCuenta.Controls.Add(this.dtpFechaInicio);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.lblBase9);
            this.grbDatosCuenta.Controls.Add(this.cboTipoCuentaBco);
            this.grbDatosCuenta.Controls.Add(this.lblBase8);
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.txtSaldoContable);
            this.grbDatosCuenta.Controls.Add(this.txtSaldoDisponible);
            this.grbDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblSaldoDisponible);
            this.grbDatosCuenta.Controls.Add(this.lblSaldoContable);
            this.grbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblEntidad);
            this.grbDatosCuenta.Controls.Add(this.btnBusCtaBco);
            this.grbDatosCuenta.Location = new System.Drawing.Point(13, 1);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(691, 135);
            this.grbDatosCuenta.TabIndex = 0;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos de la Cuenta";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(626, 79);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 19;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // chcVerificarFecha
            // 
            this.chcVerificarFecha.AutoSize = true;
            this.chcVerificarFecha.ForeColor = System.Drawing.Color.Red;
            this.chcVerificarFecha.Location = new System.Drawing.Point(17, 111);
            this.chcVerificarFecha.Name = "chcVerificarFecha";
            this.chcVerificarFecha.Size = new System.Drawing.Size(136, 17);
            this.chcVerificarFecha.TabIndex = 18;
            this.chcVerificarFecha.Text = "Filtra fecha Operacion?";
            this.chcVerificarFecha.UseVisualStyleBackColor = true;
            this.chcVerificarFecha.CheckedChanged += new System.EventHandler(this.chcVerificarCliente_CheckedChanged);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(171, 112);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(80, 13);
            this.lblBase11.TabIndex = 17;
            this.lblBase11.Text = "Fecha Inicio:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(391, 112);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(65, 13);
            this.lblBase10.TabIndex = 16;
            this.lblBase10.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(496, 106);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(123, 20);
            this.dtpFechaFin.TabIndex = 15;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(257, 106);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaInicio.TabIndex = 14;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(496, 69);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(123, 21);
            this.cboMoneda.TabIndex = 8;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(14, 72);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(81, 13);
            this.lblBase9.TabIndex = 7;
            this.lblBase9.Text = "Tipo Cuenta:";
            // 
            // cboTipoCuentaBco
            // 
            this.cboTipoCuentaBco.FormattingEnabled = true;
            this.cboTipoCuentaBco.Location = new System.Drawing.Point(116, 69);
            this.cboTipoCuentaBco.Name = "cboTipoCuentaBco";
            this.cboTipoCuentaBco.Size = new System.Drawing.Size(261, 21);
            this.cboTipoCuentaBco.TabIndex = 6;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(391, 72);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(56, 13);
            this.lblBase8.TabIndex = 5;
            this.lblBase8.Text = "Moneda:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(116, 16);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(261, 21);
            this.cboEntidad.TabIndex = 0;
            // 
            // txtSaldoContable
            // 
            this.txtSaldoContable.FormatoDecimal = false;
            this.txtSaldoContable.Location = new System.Drawing.Point(496, 43);
            this.txtSaldoContable.Name = "txtSaldoContable";
            this.txtSaldoContable.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoContable.nNumDecimales = 4;
            this.txtSaldoContable.nvalor = 0D;
            this.txtSaldoContable.Size = new System.Drawing.Size(123, 20);
            this.txtSaldoContable.TabIndex = 3;
            this.txtSaldoContable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoDisponible
            // 
            this.txtSaldoDisponible.FormatoDecimal = false;
            this.txtSaldoDisponible.Location = new System.Drawing.Point(496, 17);
            this.txtSaldoDisponible.Name = "txtSaldoDisponible";
            this.txtSaldoDisponible.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDisponible.nNumDecimales = 4;
            this.txtSaldoDisponible.nvalor = 0D;
            this.txtSaldoDisponible.Size = new System.Drawing.Size(123, 20);
            this.txtSaldoDisponible.TabIndex = 2;
            this.txtSaldoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Location = new System.Drawing.Point(116, 43);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(261, 20);
            this.txtNroCuenta.TabIndex = 1;
            // 
            // lblSaldoDisponible
            // 
            this.lblSaldoDisponible.AutoSize = true;
            this.lblSaldoDisponible.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoDisponible.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoDisponible.Location = new System.Drawing.Point(387, 20);
            this.lblSaldoDisponible.Name = "lblSaldoDisponible";
            this.lblSaldoDisponible.Size = new System.Drawing.Size(107, 13);
            this.lblSaldoDisponible.TabIndex = 3;
            this.lblSaldoDisponible.Text = "Saldo Disponible:";
            // 
            // lblSaldoContable
            // 
            this.lblSaldoContable.AutoSize = true;
            this.lblSaldoContable.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoContable.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoContable.Location = new System.Drawing.Point(388, 46);
            this.lblSaldoContable.Name = "lblSaldoContable";
            this.lblSaldoContable.Size = new System.Drawing.Size(99, 13);
            this.lblSaldoContable.TabIndex = 4;
            this.lblSaldoContable.Text = "Saldo Contable:";
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumeroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(14, 46);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNumeroCuenta.TabIndex = 2;
            this.lblNumeroCuenta.Text = "Nro. Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(14, 20);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 1;
            this.lblEntidad.Text = "Entidad:";
            // 
            // btnBusCtaBco
            // 
            this.btnBusCtaBco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCtaBco.BackgroundImage")));
            this.btnBusCtaBco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCtaBco.Location = new System.Drawing.Point(625, 14);
            this.btnBusCtaBco.Name = "btnBusCtaBco";
            this.btnBusCtaBco.Size = new System.Drawing.Size(60, 50);
            this.btnBusCtaBco.TabIndex = 4;
            this.btnBusCtaBco.Text = "&Buscar";
            this.btnBusCtaBco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCtaBco.UseVisualStyleBackColor = true;
            this.btnBusCtaBco.Click += new System.EventHandler(this.btnBusCtaBco_Click);
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
            this.grbDatosMovimiento.Controls.Add(this.lblBase1);
            this.grbDatosMovimiento.Controls.Add(this.cboMedioPagoSunat);
            this.grbDatosMovimiento.Controls.Add(this.cboMotOperacionBco);
            this.grbDatosMovimiento.Controls.Add(this.txtDocumento);
            this.grbDatosMovimiento.Controls.Add(this.txtTEA);
            this.grbDatosMovimiento.Controls.Add(this.dtpfechaOperac);
            this.grbDatosMovimiento.Controls.Add(this.lblFechaOperacion);
            this.grbDatosMovimiento.Controls.Add(this.lblMonto);
            this.grbDatosMovimiento.Controls.Add(this.lblTEA);
            this.grbDatosMovimiento.Controls.Add(this.lblTipoDocumento);
            this.grbDatosMovimiento.Controls.Add(this.lblDocumento);
            this.grbDatosMovimiento.Controls.Add(this.lblMedioPagoSUNAT);
            this.grbDatosMovimiento.Controls.Add(this.lblMotivoOperacion);
            this.grbDatosMovimiento.Controls.Add(this.grbCliente);
            this.grbDatosMovimiento.Location = new System.Drawing.Point(8, 279);
            this.grbDatosMovimiento.Name = "grbDatosMovimiento";
            this.grbDatosMovimiento.Size = new System.Drawing.Size(696, 285);
            this.grbDatosMovimiento.TabIndex = 2;
            this.grbDatosMovimiento.TabStop = false;
            this.grbDatosMovimiento.Text = "Datos de Movimiento";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(393, 91);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(134, 13);
            this.lblBase12.TabIndex = 34;
            this.lblBase12.Text = "N° Oper. Concilia Bco:";
            // 
            // txtNroConciliaBco
            // 
            this.txtNroConciliaBco.Location = new System.Drawing.Point(528, 86);
            this.txtNroConciliaBco.MaxLength = 18;
            this.txtNroConciliaBco.Name = "txtNroConciliaBco";
            this.txtNroConciliaBco.Size = new System.Drawing.Size(162, 20);
            this.txtNroConciliaBco.TabIndex = 8;
            // 
            // cboTipoMotOpeBco
            // 
            this.cboTipoMotOpeBco.FormattingEnabled = true;
            this.cboTipoMotOpeBco.Location = new System.Drawing.Point(121, 79);
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
            this.rbtCapital.ForeColor = System.Drawing.Color.Navy;
            this.rbtCapital.Location = new System.Drawing.Point(22, 10);
            this.rbtCapital.Name = "rbtCapital";
            this.rbtCapital.Size = new System.Drawing.Size(57, 17);
            this.rbtCapital.TabIndex = 0;
            this.rbtCapital.TabStop = true;
            this.rbtCapital.Text = "Capital";
            this.rbtCapital.UseVisualStyleBackColor = true;
            this.rbtCapital.CheckedChanged += new System.EventHandler(this.rbtCapital_CheckedChanged);
            // 
            // rbtInteres
            // 
            this.rbtInteres.AutoSize = true;
            this.rbtInteres.ForeColor = System.Drawing.Color.Navy;
            this.rbtInteres.Location = new System.Drawing.Point(22, 32);
            this.rbtInteres.Name = "rbtInteres";
            this.rbtInteres.Size = new System.Drawing.Size(57, 17);
            this.rbtInteres.TabIndex = 1;
            this.rbtInteres.Text = "Interés";
            this.rbtInteres.UseVisualStyleBackColor = true;
            this.rbtInteres.CheckedChanged += new System.EventHandler(this.rbtInteres_CheckedChanged);
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(528, 15);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(163, 21);
            this.cboTipoPago.TabIndex = 5;
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
            this.cboTipoOperacionBco.Location = new System.Drawing.Point(121, 171);
            this.cboTipoOperacionBco.Name = "cboTipoOperacionBco";
            this.cboTipoOperacionBco.Size = new System.Drawing.Size(150, 21);
            this.cboTipoOperacionBco.TabIndex = 11;
            this.cboTipoOperacionBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoOperacionBco_SelectedIndexChanged);
            // 
            // cboTipoDestino
            // 
            this.cboTipoDestino.FormattingEnabled = true;
            this.cboTipoDestino.Location = new System.Drawing.Point(121, 203);
            this.cboTipoDestino.Name = "cboTipoDestino";
            this.cboTipoDestino.Size = new System.Drawing.Size(150, 21);
            this.cboTipoDestino.TabIndex = 12;
            // 
            // cboTipoDocumentoBco
            // 
            this.cboTipoDocumentoBco.FormattingEnabled = true;
            this.cboTipoDocumentoBco.Location = new System.Drawing.Point(528, 40);
            this.cboTipoDocumentoBco.Name = "cboTipoDocumentoBco";
            this.cboTipoDocumentoBco.Size = new System.Drawing.Size(162, 21);
            this.cboTipoDocumentoBco.TabIndex = 6;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 205);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 27;
            this.lblBase4.Text = "Tipo Destino:";
            // 
            // txtMontoOperac
            // 
            this.txtMontoOperac.FormatoDecimal = false;
            this.txtMontoOperac.Location = new System.Drawing.Point(121, 111);
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
            this.txtMontoOperac.TabIndex = 4;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 177);
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
            this.lblBase2.Location = new System.Drawing.Point(6, 233);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Concepto:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(121, 233);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(569, 46);
            this.txtConcepto.TabIndex = 14;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 83);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Tipo Operación:";
            // 
            // cboMedioPagoSunat
            // 
            this.cboMedioPagoSunat.FormattingEnabled = true;
            this.cboMedioPagoSunat.Location = new System.Drawing.Point(121, 47);
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
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(528, 63);
            this.txtDocumento.MaxLength = 18;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(162, 20);
            this.txtDocumento.TabIndex = 7;
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.txtTEA.Location = new System.Drawing.Point(528, 109);
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 2;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(74, 20);
            this.txtTEA.TabIndex = 9;
            // 
            // dtpfechaOperac
            // 
            this.dtpfechaOperac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaOperac.Location = new System.Drawing.Point(527, 132);
            this.dtpfechaOperac.Name = "dtpfechaOperac";
            this.dtpfechaOperac.Size = new System.Drawing.Size(113, 20);
            this.dtpfechaOperac.TabIndex = 10;
            // 
            // lblFechaOperacion
            // 
            this.lblFechaOperacion.AutoSize = true;
            this.lblFechaOperacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaOperacion.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaOperacion.Location = new System.Drawing.Point(393, 139);
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
            this.lblMonto.Location = new System.Drawing.Point(6, 115);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 7;
            this.lblMonto.Text = "Monto:";
            // 
            // lblTEA
            // 
            this.lblTEA.AutoSize = true;
            this.lblTEA.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTEA.ForeColor = System.Drawing.Color.Navy;
            this.lblTEA.Location = new System.Drawing.Point(393, 114);
            this.lblTEA.Name = "lblTEA";
            this.lblTEA.Size = new System.Drawing.Size(34, 13);
            this.lblTEA.TabIndex = 6;
            this.lblTEA.Text = "TEA:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoDocumento.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoDocumento.Location = new System.Drawing.Point(393, 43);
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
            this.lblDocumento.Location = new System.Drawing.Point(393, 67);
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
            this.lblMedioPagoSUNAT.Location = new System.Drawing.Point(6, 51);
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
            this.grbCliente.Controls.Add(this.lblBase5);
            this.grbCliente.Location = new System.Drawing.Point(279, 153);
            this.grbCliente.Name = "grbCliente";
            this.grbCliente.Size = new System.Drawing.Size(412, 74);
            this.grbCliente.TabIndex = 13;
            this.grbCliente.TabStop = false;
            this.grbCliente.Text = "Beneficiario/Girador";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(59, 45);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(282, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // txtCodigo
            // 
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
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 24);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(52, 13);
            this.lblBase5.TabIndex = 28;
            this.lblBase5.Text = "Código:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(318, 570);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(441, 570);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(379, 570);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(502, 570);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Location = new System.Drawing.Point(563, 570);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 4;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(642, 570);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgMovimientos
            // 
            this.dtgMovimientos.AllowUserToAddRows = false;
            this.dtgMovimientos.AllowUserToDeleteRows = false;
            this.dtgMovimientos.AllowUserToResizeColumns = false;
            this.dtgMovimientos.AllowUserToResizeRows = false;
            this.dtgMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimientos.Location = new System.Drawing.Point(13, 142);
            this.dtgMovimientos.MultiSelect = false;
            this.dtgMovimientos.Name = "dtgMovimientos";
            this.dtgMovimientos.ReadOnly = true;
            this.dtgMovimientos.RowHeadersVisible = false;
            this.dtgMovimientos.RowHeadersWidth = 20;
            this.dtgMovimientos.RowTemplate.Height = 18;
            this.dtgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovimientos.Size = new System.Drawing.Size(691, 135);
            this.dtgMovimientos.TabIndex = 1;
            this.dtgMovimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMovimientos_CellClick);
            this.dtgMovimientos.SelectionChanged += new System.EventHandler(this.dtgMovimientos_SelectionChanged);
            // 
            // frmMovimientosBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 645);
            this.Controls.Add(this.dtgMovimientos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbDatosMovimiento);
            this.Controls.Add(this.grbDatosCuenta);
            this.Name = "frmMovimientosBancos";
            this.Text = "Movimientos Bancos";
            this.Load += new System.EventHandler(this.frmMovimientosBancos_Load);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.grbDatosMovimiento, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgMovimientos, 0);
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            this.grbDatosMovimiento.ResumeLayout(false);
            this.grbDatosMovimiento.PerformLayout();
            this.grbCapInt.ResumeLayout(false);
            this.grbCapInt.PerformLayout();
            this.grbCliente.ResumeLayout(false);
            this.grbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.ControlesBase.lblBase lblNumeroCuenta;
        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.BotonesBase.btnBusqueda btnBusCtaBco;
        private GEN.ControlesBase.txtNumRea txtSaldoContable;
        private GEN.ControlesBase.txtNumRea txtSaldoDisponible;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.lblBase lblSaldoDisponible;
        private GEN.ControlesBase.lblBase lblSaldoContable;
        private GEN.ControlesBase.grbBase grbDatosMovimiento;
        private GEN.ControlesBase.lblBase lblFechaOperacion;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.ControlesBase.lblBase lblTEA;
        private GEN.ControlesBase.lblBase lblTipoDocumento;
        private GEN.ControlesBase.lblBase lblDocumento;
        private GEN.ControlesBase.lblBase lblMedioPagoSUNAT;
        private GEN.ControlesBase.lblBase lblMotivoOperacion;
        private GEN.ControlesBase.txtBase txtDocumento;
        private GEN.ControlesBase.txtNumRea txtTEA;
        private GEN.ControlesBase.dtpCorto dtpfechaOperac;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtConcepto;
        private GEN.ControlesBase.txtNumRea txtMontoOperac;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMedioPagoSunat cboMedioPagoSunat;
        private GEN.ControlesBase.cboMotOperacionBco cboMotOperacionBco;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbCliente;
        private GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.BotonesBase.btnBusqueda btnBusquedaDestino;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboBase cboTipoDocumentoBco;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.dtgBase dtgMovimientos;
        private GEN.ControlesBase.cboTipoDestino cboTipoDestino;
        private GEN.ControlesBase.cboBase cboTipoOperacionBco;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbCapInt;
        private GEN.ControlesBase.rbtBase rbtCapital;
        private GEN.ControlesBase.rbtBase rbtInteres;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.ControlesBase.cboBase cboTipoMotOpeBco;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBco;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.chcBase chcVerificarFecha;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtNroConciliaBco;

    }
}