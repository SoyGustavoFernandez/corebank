namespace CAJ.Presentacion
{
    partial class frmRegistroCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroCuenta));
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblTipoEntidad = new GEN.ControlesBase.lblBase();
            this.lblNumeroCuenta = new GEN.ControlesBase.lblBase();
            this.lblTipoCuenta = new GEN.ControlesBase.lblBase();
            this.lblNombreEntidad = new GEN.ControlesBase.lblBase();
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.dtpFechaCancelacion = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFecCancel = new GEN.ControlesBase.lblBase();
            this.txtNumeroCuenta = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboEstadoCuentaBco = new GEN.ControlesBase.cboEstadoCuentaBco(this.components);
            this.lblEstado = new GEN.ControlesBase.lblBase();
            this.txtPlazo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCuentaContable = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblCuentaContable = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtSaldoContable = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblSaldoContable = new GEN.ControlesBase.lblBase();
            this.txtSaldoDisponible = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblSaldo = new GEN.ControlesBase.lblBase();
            this.btnBuscarCuenta = new GEN.BotonesBase.btnBusqueda();
            this.lblPorcentaje = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBco = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.cboFactorInteres = new GEN.ControlesBase.cboBase(this.components);
            this.lblPlazo = new GEN.ControlesBase.lblBase();
            this.lblFactorInteres = new GEN.ControlesBase.lblBase();
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblTEA = new GEN.ControlesBase.lblBase();
            this.dtpFechaApertura = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaApertura = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.txtDescripcionCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcionCuenta = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabarCuenta = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevaCuenta = new GEN.BotonesBase.btnNuevo();
            this.btnEditarCuenta = new GEN.BotonesBase.btnEditar();
            this.grbDatosCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboEntidad
            // 
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(140, 99);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(292, 21);
            this.cboEntidad.TabIndex = 4;
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(140, 72);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(292, 21);
            this.cboTipoEntidad.TabIndex = 3;
            this.cboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad_SelectedIndexChanged);
            // 
            // lblTipoEntidad
            // 
            this.lblTipoEntidad.AutoSize = true;
            this.lblTipoEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoEntidad.Location = new System.Drawing.Point(15, 75);
            this.lblTipoEntidad.Name = "lblTipoEntidad";
            this.lblTipoEntidad.Size = new System.Drawing.Size(100, 13);
            this.lblTipoEntidad.TabIndex = 7;
            this.lblTipoEntidad.Text = "Tipo de Entidad:";
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumeroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(15, 22);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(120, 13);
            this.lblNumeroCuenta.TabIndex = 8;
            this.lblNumeroCuenta.Text = "Número de Cuenta:";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCuenta.Location = new System.Drawing.Point(15, 49);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(99, 13);
            this.lblTipoCuenta.TabIndex = 9;
            this.lblTipoCuenta.Text = "Tipo de Cuenta:";
            // 
            // lblNombreEntidad
            // 
            this.lblNombreEntidad.AutoSize = true;
            this.lblNombreEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreEntidad.Location = new System.Drawing.Point(15, 102);
            this.lblNombreEntidad.Name = "lblNombreEntidad";
            this.lblNombreEntidad.Size = new System.Drawing.Size(103, 13);
            this.lblNombreEntidad.TabIndex = 10;
            this.lblNombreEntidad.Text = "Nombre Entidad:";
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.btnMiniBusq1);
            this.grbDatosCuenta.Controls.Add(this.dtpFechaCancelacion);
            this.grbDatosCuenta.Controls.Add(this.lblFecCancel);
            this.grbDatosCuenta.Controls.Add(this.txtNumeroCuenta);
            this.grbDatosCuenta.Controls.Add(this.cboEstadoCuentaBco);
            this.grbDatosCuenta.Controls.Add(this.lblEstado);
            this.grbDatosCuenta.Controls.Add(this.txtPlazo);
            this.grbDatosCuenta.Controls.Add(this.txtCuentaContable);
            this.grbDatosCuenta.Controls.Add(this.lblCuentaContable);
            this.grbDatosCuenta.Controls.Add(this.cboAgencia);
            this.grbDatosCuenta.Controls.Add(this.lblBase3);
            this.grbDatosCuenta.Controls.Add(this.txtSaldoContable);
            this.grbDatosCuenta.Controls.Add(this.lblSaldoContable);
            this.grbDatosCuenta.Controls.Add(this.txtSaldoDisponible);
            this.grbDatosCuenta.Controls.Add(this.lblSaldo);
            this.grbDatosCuenta.Controls.Add(this.btnBuscarCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblPorcentaje);
            this.grbDatosCuenta.Controls.Add(this.cboTipoCuentaBco);
            this.grbDatosCuenta.Controls.Add(this.cboFactorInteres);
            this.grbDatosCuenta.Controls.Add(this.lblPlazo);
            this.grbDatosCuenta.Controls.Add(this.lblFactorInteres);
            this.grbDatosCuenta.Controls.Add(this.txtTEA);
            this.grbDatosCuenta.Controls.Add(this.lblTEA);
            this.grbDatosCuenta.Controls.Add(this.dtpFechaApertura);
            this.grbDatosCuenta.Controls.Add(this.lblFechaApertura);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.lblMoneda);
            this.grbDatosCuenta.Controls.Add(this.txtDescripcionCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblDescripcionCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblTipoEntidad);
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblNombreEntidad);
            this.grbDatosCuenta.Controls.Add(this.cboTipoEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblTipoCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.grbDatosCuenta.Location = new System.Drawing.Point(12, 12);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(509, 376);
            this.grbDatosCuenta.TabIndex = 12;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos de Cuenta";
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Enabled = false;
            this.btnMiniBusq1.Location = new System.Drawing.Point(467, 286);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 104;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // dtpFechaCancelacion
            // 
            this.dtpFechaCancelacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCancelacion.Location = new System.Drawing.Point(392, 265);
            this.dtpFechaCancelacion.Name = "dtpFechaCancelacion";
            this.dtpFechaCancelacion.Size = new System.Drawing.Size(106, 20);
            this.dtpFechaCancelacion.TabIndex = 102;
            this.dtpFechaCancelacion.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblFecCancel
            // 
            this.lblFecCancel.AutoSize = true;
            this.lblFecCancel.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecCancel.ForeColor = System.Drawing.Color.Navy;
            this.lblFecCancel.Location = new System.Drawing.Point(272, 267);
            this.lblFecCancel.Name = "lblFecCancel";
            this.lblFecCancel.Size = new System.Drawing.Size(118, 13);
            this.lblFecCancel.TabIndex = 103;
            this.lblFecCancel.Text = "Fecha Cancelación:";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(140, 20);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(292, 20);
            this.txtNumeroCuenta.TabIndex = 101;
            // 
            // cboEstadoCuentaBco
            // 
            this.cboEstadoCuentaBco.FormattingEnabled = true;
            this.cboEstadoCuentaBco.Location = new System.Drawing.Point(392, 342);
            this.cboEstadoCuentaBco.Name = "cboEstadoCuentaBco";
            this.cboEstadoCuentaBco.Size = new System.Drawing.Size(106, 21);
            this.cboEstadoCuentaBco.TabIndex = 12;
            this.cboEstadoCuentaBco.SelectedIndexChanged += new System.EventHandler(this.cboEstadoCuentaBco_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(272, 346);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 13);
            this.lblEstado.TabIndex = 100;
            this.lblEstado.Text = "Estado:";
            // 
            // txtPlazo
            // 
            this.txtPlazo.Location = new System.Drawing.Point(392, 316);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.Size = new System.Drawing.Size(70, 20);
            this.txtPlazo.TabIndex = 11;
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCuentaContable
            // 
            this.txtCuentaContable.FormatoDecimal = false;
            this.txtCuentaContable.Location = new System.Drawing.Point(392, 290);
            this.txtCuentaContable.MaxLength = 14;
            this.txtCuentaContable.Name = "txtCuentaContable";
            this.txtCuentaContable.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuentaContable.nNumDecimales = 4;
            this.txtCuentaContable.nvalor = 0D;
            this.txtCuentaContable.Size = new System.Drawing.Size(70, 20);
            this.txtCuentaContable.TabIndex = 9;
            // 
            // lblCuentaContable
            // 
            this.lblCuentaContable.AutoSize = true;
            this.lblCuentaContable.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuentaContable.ForeColor = System.Drawing.Color.Navy;
            this.lblCuentaContable.Location = new System.Drawing.Point(272, 293);
            this.lblCuentaContable.Name = "lblCuentaContable";
            this.lblCuentaContable.Size = new System.Drawing.Size(108, 13);
            this.lblCuentaContable.TabIndex = 37;
            this.lblCuentaContable.Text = "Cuenta Contable:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.Enabled = false;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(140, 126);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(292, 21);
            this.cboAgencia.TabIndex = 36;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 129);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 34;
            this.lblBase3.Text = "Agencia:";
            // 
            // txtSaldoContable
            // 
            this.txtSaldoContable.Enabled = false;
            this.txtSaldoContable.FormatoDecimal = false;
            this.txtSaldoContable.Location = new System.Drawing.Point(140, 343);
            this.txtSaldoContable.Name = "txtSaldoContable";
            this.txtSaldoContable.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoContable.nNumDecimales = 2;
            this.txtSaldoContable.nvalor = 0D;
            this.txtSaldoContable.Size = new System.Drawing.Size(105, 20);
            this.txtSaldoContable.TabIndex = 99;
            // 
            // lblSaldoContable
            // 
            this.lblSaldoContable.AutoSize = true;
            this.lblSaldoContable.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoContable.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoContable.Location = new System.Drawing.Point(15, 346);
            this.lblSaldoContable.Name = "lblSaldoContable";
            this.lblSaldoContable.Size = new System.Drawing.Size(99, 13);
            this.lblSaldoContable.TabIndex = 30;
            this.lblSaldoContable.Text = "Saldo Contable:";
            // 
            // txtSaldoDisponible
            // 
            this.txtSaldoDisponible.Enabled = false;
            this.txtSaldoDisponible.FormatoDecimal = false;
            this.txtSaldoDisponible.Location = new System.Drawing.Point(140, 317);
            this.txtSaldoDisponible.Name = "txtSaldoDisponible";
            this.txtSaldoDisponible.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDisponible.nNumDecimales = 2;
            this.txtSaldoDisponible.nvalor = 0D;
            this.txtSaldoDisponible.Size = new System.Drawing.Size(105, 20);
            this.txtSaldoDisponible.TabIndex = 98;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldo.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldo.Location = new System.Drawing.Point(15, 320);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(107, 13);
            this.lblSaldo.TabIndex = 29;
            this.lblSaldo.Text = "Saldo Disponible:";
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.BackgroundImage")));
            this.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(438, 16);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCuenta.TabIndex = 28;
            this.btnBuscarCuenta.Text = "&Buscar";
            this.btnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Navy;
            this.lblPorcentaje.Location = new System.Drawing.Point(234, 267);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(19, 13);
            this.lblPorcentaje.TabIndex = 27;
            this.lblPorcentaje.Text = "%";
            // 
            // cboTipoCuentaBco
            // 
            this.cboTipoCuentaBco.FormattingEnabled = true;
            this.cboTipoCuentaBco.Location = new System.Drawing.Point(140, 45);
            this.cboTipoCuentaBco.Name = "cboTipoCuentaBco";
            this.cboTipoCuentaBco.Size = new System.Drawing.Size(292, 21);
            this.cboTipoCuentaBco.TabIndex = 2;
            this.cboTipoCuentaBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoCuentaBco_SelectedIndexChanged);
            // 
            // cboFactorInteres
            // 
            this.cboFactorInteres.FormattingEnabled = true;
            this.cboFactorInteres.Location = new System.Drawing.Point(140, 290);
            this.cboFactorInteres.Name = "cboFactorInteres";
            this.cboFactorInteres.Size = new System.Drawing.Size(80, 21);
            this.cboFactorInteres.TabIndex = 10;
            // 
            // lblPlazo
            // 
            this.lblPlazo.AutoSize = true;
            this.lblPlazo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPlazo.ForeColor = System.Drawing.Color.Navy;
            this.lblPlazo.Location = new System.Drawing.Point(272, 319);
            this.lblPlazo.Name = "lblPlazo";
            this.lblPlazo.Size = new System.Drawing.Size(93, 13);
            this.lblPlazo.TabIndex = 21;
            this.lblPlazo.Text = "Plazo(en días):";
            // 
            // lblFactorInteres
            // 
            this.lblFactorInteres.AutoSize = true;
            this.lblFactorInteres.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFactorInteres.ForeColor = System.Drawing.Color.Navy;
            this.lblFactorInteres.Location = new System.Drawing.Point(15, 293);
            this.lblFactorInteres.Name = "lblFactorInteres";
            this.lblFactorInteres.Size = new System.Drawing.Size(109, 13);
            this.lblFactorInteres.TabIndex = 20;
            this.lblFactorInteres.Text = "Factor de Interés:";
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.txtTEA.Location = new System.Drawing.Point(140, 264);
            this.txtTEA.MaxLength = 10;
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 2;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(80, 20);
            this.txtTEA.TabIndex = 8;
            this.txtTEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTEA
            // 
            this.lblTEA.AutoSize = true;
            this.lblTEA.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTEA.ForeColor = System.Drawing.Color.Navy;
            this.lblTEA.Location = new System.Drawing.Point(15, 267);
            this.lblTEA.Name = "lblTEA";
            this.lblTEA.Size = new System.Drawing.Size(44, 13);
            this.lblTEA.TabIndex = 18;
            this.lblTEA.Text = "T.E.A.:";
            // 
            // dtpFechaApertura
            // 
            this.dtpFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaApertura.Location = new System.Drawing.Point(392, 238);
            this.dtpFechaApertura.Name = "dtpFechaApertura";
            this.dtpFechaApertura.Size = new System.Drawing.Size(106, 20);
            this.dtpFechaApertura.TabIndex = 7;
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaApertura.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaApertura.Location = new System.Drawing.Point(272, 240);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(99, 13);
            this.lblFechaApertura.TabIndex = 16;
            this.lblFechaApertura.Text = "Fecha Apertura:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(140, 237);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(105, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(15, 240);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 14;
            this.lblMoneda.Text = "Moneda:";
            // 
            // txtDescripcionCuenta
            // 
            this.txtDescripcionCuenta.Location = new System.Drawing.Point(140, 153);
            this.txtDescripcionCuenta.Multiline = true;
            this.txtDescripcionCuenta.Name = "txtDescripcionCuenta";
            this.txtDescripcionCuenta.Size = new System.Drawing.Size(358, 74);
            this.txtDescripcionCuenta.TabIndex = 5;
            // 
            // lblDescripcionCuenta
            // 
            this.lblDescripcionCuenta.AutoSize = true;
            this.lblDescripcionCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcionCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcionCuenta.Location = new System.Drawing.Point(15, 156);
            this.lblDescripcionCuenta.Name = "lblDescripcionCuenta";
            this.lblDescripcionCuenta.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcionCuenta.TabIndex = 12;
            this.lblDescripcionCuenta.Text = "Descripción:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(263, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabarCuenta
            // 
            this.btnGrabarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarCuenta.BackgroundImage")));
            this.btnGrabarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarCuenta.Location = new System.Drawing.Point(395, 394);
            this.btnGrabarCuenta.Name = "btnGrabarCuenta";
            this.btnGrabarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarCuenta.TabIndex = 13;
            this.btnGrabarCuenta.Text = "&Grabar";
            this.btnGrabarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarCuenta.UseVisualStyleBackColor = true;
            this.btnGrabarCuenta.Click += new System.EventHandler(this.btnGrabarCuenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(461, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCuenta
            // 
            this.btnNuevaCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevaCuenta.BackgroundImage")));
            this.btnNuevaCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevaCuenta.Location = new System.Drawing.Point(329, 394);
            this.btnNuevaCuenta.Name = "btnNuevaCuenta";
            this.btnNuevaCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnNuevaCuenta.TabIndex = 16;
            this.btnNuevaCuenta.Text = "&Nuevo";
            this.btnNuevaCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaCuenta.UseVisualStyleBackColor = true;
            this.btnNuevaCuenta.Click += new System.EventHandler(this.btnNuevaCuenta_Click);
            // 
            // btnEditarCuenta
            // 
            this.btnEditarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarCuenta.BackgroundImage")));
            this.btnEditarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarCuenta.Location = new System.Drawing.Point(11, 394);
            this.btnEditarCuenta.Name = "btnEditarCuenta";
            this.btnEditarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnEditarCuenta.TabIndex = 17;
            this.btnEditarCuenta.Text = "&Editar";
            this.btnEditarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarCuenta.UseVisualStyleBackColor = true;
            this.btnEditarCuenta.Click += new System.EventHandler(this.btnEditarCuenta_Click);
            // 
            // frmRegistroCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 471);
            this.Controls.Add(this.btnEditarCuenta);
            this.Controls.Add(this.btnNuevaCuenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabarCuenta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbDatosCuenta);
            this.Name = "frmRegistroCuenta";
            this.Text = "Registro Cuenta Otra Institución";
            this.Load += new System.EventHandler(this.frmRegistroCuenta_Load);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabarCuenta, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevaCuenta, 0);
            this.Controls.SetChildIndex(this.btnEditarCuenta, 0);
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.lblBase lblTipoEntidad;
        private GEN.ControlesBase.lblBase lblNumeroCuenta;
        private GEN.ControlesBase.lblBase lblTipoCuenta;
        private GEN.ControlesBase.lblBase lblNombreEntidad;
        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.txtBase txtDescripcionCuenta;
        private GEN.ControlesBase.lblBase lblDescripcionCuenta;
        private GEN.ControlesBase.lblBase lblPlazo;
        private GEN.ControlesBase.lblBase lblFactorInteres;
        private GEN.ControlesBase.txtNumRea txtTEA;
        private GEN.ControlesBase.lblBase lblTEA;
        private GEN.ControlesBase.dtpCorto dtpFechaApertura;
        private GEN.ControlesBase.lblBase lblFechaApertura;
        private GEN.ControlesBase.cboBase cboFactorInteres;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabarCuenta;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBco;
        private GEN.ControlesBase.lblBase lblPorcentaje;
        private GEN.BotonesBase.btnBusqueda btnBuscarCuenta;
        private GEN.ControlesBase.txtNumRea txtSaldoDisponible;
        private GEN.ControlesBase.lblBase lblSaldo;
        private GEN.BotonesBase.btnNuevo btnNuevaCuenta;
        private GEN.BotonesBase.btnEditar btnEditarCuenta;
        private GEN.ControlesBase.txtNumRea txtCuentaContable;
        private GEN.ControlesBase.lblBase lblCuentaContable;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtSaldoContable;
        private GEN.ControlesBase.lblBase lblSaldoContable;
        private GEN.ControlesBase.txtCBNumerosEnteros txtPlazo;
        private GEN.ControlesBase.lblBase lblEstado;
        private GEN.ControlesBase.cboEstadoCuentaBco cboEstadoCuentaBco;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumeroCuenta;
        private GEN.ControlesBase.dtpCorto dtpFechaCancelacion;
        private GEN.ControlesBase.lblBase lblFecCancel;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
    }
}