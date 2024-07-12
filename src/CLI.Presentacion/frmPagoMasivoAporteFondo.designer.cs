namespace CLI.Presentacion
{
    partial class frmPagoMasivoAporteFondo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoMasivoAporteFondo));
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNroAportes = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTotalPagoAporte = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgPagoCrditosConvenio = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cboConvenio1 = new GEN.ControlesBase.cboConvenio(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtNroFondo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtTotalPagoFondo = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboModalidad = new GEN.ControlesBase.cboBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbCheInter = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.cboCuenta = new GEN.ControlesBase.cboBase(this.components);
            this.lblCuenta = new GEN.ControlesBase.lblBase();
            this.txtNroDocumento = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase25 = new GEN.ControlesBase.lblBase();
            this.lblBase24 = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.txtNroSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboEntidad1 = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.grbCuentaAhorro = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.boton21 = new GEN.BotonesBase.Boton2();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtIdCtaAho = new GEN.ControlesBase.txtBase(this.components);
            this.txtCuentaAho = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCrditosConvenio)).BeginInit();
            this.grbCheInter.SuspendLayout();
            this.grbCuentaAhorro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 361);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(134, 13);
            this.lblBase7.TabIndex = 34;
            this.lblBase7.Text = "Nro Aporte por Pagar:";
            // 
            // txtNroAportes
            // 
            this.txtNroAportes.Enabled = false;
            this.txtNroAportes.FormatoDecimal = false;
            this.txtNroAportes.Location = new System.Drawing.Point(149, 358);
            this.txtNroAportes.Name = "txtNroAportes";
            this.txtNroAportes.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNroAportes.nNumDecimales = 4;
            this.txtNroAportes.nvalor = 0D;
            this.txtNroAportes.Size = new System.Drawing.Size(117, 20);
            this.txtNroAportes.TabIndex = 32;
            this.txtNroAportes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 385);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(105, 13);
            this.lblBase5.TabIndex = 30;
            this.lblBase5.Text = "Aportes A Pagar:";
            // 
            // txtTotalPagoAporte
            // 
            this.txtTotalPagoAporte.Enabled = false;
            this.txtTotalPagoAporte.FormatoDecimal = true;
            this.txtTotalPagoAporte.Location = new System.Drawing.Point(149, 381);
            this.txtTotalPagoAporte.Name = "txtTotalPagoAporte";
            this.txtTotalPagoAporte.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPagoAporte.nNumDecimales = 2;
            this.txtTotalPagoAporte.nvalor = 0D;
            this.txtTotalPagoAporte.Size = new System.Drawing.Size(117, 20);
            this.txtTotalPagoAporte.TabIndex = 27;
            this.txtTotalPagoAporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgPagoCrditosConvenio
            // 
            this.dtgPagoCrditosConvenio.AllowUserToAddRows = false;
            this.dtgPagoCrditosConvenio.AllowUserToDeleteRows = false;
            this.dtgPagoCrditosConvenio.AllowUserToOrderColumns = true;
            this.dtgPagoCrditosConvenio.AllowUserToResizeColumns = false;
            this.dtgPagoCrditosConvenio.AllowUserToResizeRows = false;
            this.dtgPagoCrditosConvenio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgPagoCrditosConvenio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagoCrditosConvenio.Location = new System.Drawing.Point(10, 53);
            this.dtgPagoCrditosConvenio.MultiSelect = false;
            this.dtgPagoCrditosConvenio.Name = "dtgPagoCrditosConvenio";
            this.dtgPagoCrditosConvenio.ReadOnly = true;
            this.dtgPagoCrditosConvenio.RowHeadersVisible = false;
            this.dtgPagoCrditosConvenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPagoCrditosConvenio.Size = new System.Drawing.Size(904, 272);
            this.dtgPagoCrditosConvenio.TabIndex = 21;
            this.dtgPagoCrditosConvenio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellValueChanged);
            this.dtgPagoCrditosConvenio.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgPagoCrditosConvenio_CurrentCellDirtyStateChanged);
            this.dtgPagoCrditosConvenio.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgPagoCrditosConvenio_DataError);
            this.dtgPagoCrditosConvenio.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBase1_EditingControlShowing);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(732, 394);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 22;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(794, 394);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 24;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(854, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Archivo txt (*.txt)|*.txt";
            this.openFileDialog.Title = "Planilla Convenio";
            // 
            // cboConvenio1
            // 
            this.cboConvenio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvenio1.FormattingEnabled = true;
            this.cboConvenio1.Location = new System.Drawing.Point(85, 26);
            this.cboConvenio1.Name = "cboConvenio1";
            this.cboConvenio1.Size = new System.Drawing.Size(296, 21);
            this.cboConvenio1.TabIndex = 38;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 39;
            this.lblBase2.Text = "Convenio:";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(853, 2);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 45;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(12, 406);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(130, 13);
            this.lblBase9.TabIndex = 47;
            this.lblBase9.Text = "Nro Fondo por Pagar:";
            // 
            // txtNroFondo
            // 
            this.txtNroFondo.Enabled = false;
            this.txtNroFondo.FormatoDecimal = false;
            this.txtNroFondo.Location = new System.Drawing.Point(149, 403);
            this.txtNroFondo.Name = "txtNroFondo";
            this.txtNroFondo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNroFondo.nNumDecimales = 4;
            this.txtNroFondo.nvalor = 0D;
            this.txtNroFondo.Size = new System.Drawing.Size(117, 20);
            this.txtNroFondo.TabIndex = 46;
            this.txtNroFondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(12, 430);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(95, 13);
            this.lblBase10.TabIndex = 49;
            this.lblBase10.Text = "Fondo A Pagar:";
            // 
            // txtTotalPagoFondo
            // 
            this.txtTotalPagoFondo.Enabled = false;
            this.txtTotalPagoFondo.FormatoDecimal = true;
            this.txtTotalPagoFondo.Location = new System.Drawing.Point(149, 426);
            this.txtTotalPagoFondo.Name = "txtTotalPagoFondo";
            this.txtTotalPagoFondo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPagoFondo.nNumDecimales = 2;
            this.txtTotalPagoFondo.nvalor = 0D;
            this.txtTotalPagoFondo.Size = new System.Drawing.Size(117, 20);
            this.txtTotalPagoFondo.TabIndex = 48;
            this.txtTotalPagoFondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboModalidad
            // 
            this.cboModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidad.FormattingEnabled = true;
            this.cboModalidad.Location = new System.Drawing.Point(89, 331);
            this.cboModalidad.Name = "cboModalidad";
            this.cboModalidad.Size = new System.Drawing.Size(175, 21);
            this.cboModalidad.TabIndex = 128;
            this.cboModalidad.SelectedIndexChanged += new System.EventHandler(this.cboModalidad_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(11, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Tipo de Pago:";
            // 
            // grbCheInter
            // 
            this.grbCheInter.BackColor = System.Drawing.SystemColors.Info;
            this.grbCheInter.Controls.Add(this.lblCuenta);
            this.grbCheInter.Controls.Add(this.txtNroDocumento);
            this.grbCheInter.Controls.Add(this.lblBase25);
            this.grbCheInter.Controls.Add(this.lblBase24);
            this.grbCheInter.Controls.Add(this.cboTipoEntidad);
            this.grbCheInter.Controls.Add(this.txtNroSerie);
            this.grbCheInter.Controls.Add(this.cboEntidad1);
            this.grbCheInter.Controls.Add(this.lblBase22);
            this.grbCheInter.Controls.Add(this.lblBase23);
            this.grbCheInter.Controls.Add(this.txtNroCuenta);
            this.grbCheInter.Controls.Add(this.cboCuenta);
            this.grbCheInter.ForeColor = System.Drawing.Color.Navy;
            this.grbCheInter.Location = new System.Drawing.Point(280, 332);
            this.grbCheInter.Name = "grbCheInter";
            this.grbCheInter.Size = new System.Drawing.Size(444, 114);
            this.grbCheInter.TabIndex = 131;
            this.grbCheInter.TabStop = false;
            this.grbCheInter.Text = "Detalle Pago con Intervancarios";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(121, 64);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(316, 20);
            this.txtNroCuenta.TabIndex = 127;
            this.txtNroCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.Enabled = false;
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(121, 64);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(316, 21);
            this.cboCuenta.TabIndex = 33;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblCuenta.Location = new System.Drawing.Point(5, 67);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(95, 13);
            this.lblCuenta.TabIndex = 32;
            this.lblCuenta.Text = "Nro de Cuenta:";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(308, 89);
            this.txtNroDocumento.MaxLength = 9;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(131, 20);
            this.txtNroDocumento.TabIndex = 4;
            // 
            // lblBase25
            // 
            this.lblBase25.AutoSize = true;
            this.lblBase25.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase25.ForeColor = System.Drawing.Color.Navy;
            this.lblBase25.Location = new System.Drawing.Point(187, 93);
            this.lblBase25.Name = "lblBase25";
            this.lblBase25.Size = new System.Drawing.Size(119, 13);
            this.lblBase25.TabIndex = 31;
            this.lblBase25.Text = "Nro de Documento:";
            // 
            // lblBase24
            // 
            this.lblBase24.AutoSize = true;
            this.lblBase24.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase24.ForeColor = System.Drawing.Color.Navy;
            this.lblBase24.Location = new System.Drawing.Point(3, 20);
            this.lblBase24.Name = "lblBase24";
            this.lblBase24.Size = new System.Drawing.Size(82, 13);
            this.lblBase24.TabIndex = 29;
            this.lblBase24.Text = "Tipo Entidad:";
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(121, 17);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(318, 21);
            this.cboTipoEntidad.TabIndex = 0;
            this.cboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad_SelectedIndexChanged);
            // 
            // txtNroSerie
            // 
            this.txtNroSerie.Location = new System.Drawing.Point(121, 89);
            this.txtNroSerie.MaxLength = 9;
            this.txtNroSerie.Name = "txtNroSerie";
            this.txtNroSerie.ReadOnly = true;
            this.txtNroSerie.Size = new System.Drawing.Size(60, 20);
            this.txtNroSerie.TabIndex = 3;
            // 
            // cboEntidad1
            // 
            this.cboEntidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad1.FormattingEnabled = true;
            this.cboEntidad1.Location = new System.Drawing.Point(121, 41);
            this.cboEntidad1.Name = "cboEntidad1";
            this.cboEntidad1.Size = new System.Drawing.Size(318, 21);
            this.cboEntidad1.TabIndex = 1;
            this.cboEntidad1.SelectedIndexChanged += new System.EventHandler(this.cboEntidad1_SelectedIndexChanged);
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(3, 44);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(116, 13);
            this.lblBase22.TabIndex = 23;
            this.lblBase22.Text = "Entidad Financiera:";
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(3, 93);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(84, 13);
            this.lblBase23.TabIndex = 20;
            this.lblBase23.Text = "Nro de Serie:";
            // 
            // grbCuentaAhorro
            // 
            this.grbCuentaAhorro.BackColor = System.Drawing.SystemColors.Info;
            this.grbCuentaAhorro.Controls.Add(this.cboMoneda);
            this.grbCuentaAhorro.Controls.Add(this.boton21);
            this.grbCuentaAhorro.Controls.Add(this.lblBase1);
            this.grbCuentaAhorro.Controls.Add(this.txtIdCtaAho);
            this.grbCuentaAhorro.Controls.Add(this.txtCuentaAho);
            this.grbCuentaAhorro.Enabled = false;
            this.grbCuentaAhorro.Location = new System.Drawing.Point(280, 334);
            this.grbCuentaAhorro.Name = "grbCuentaAhorro";
            this.grbCuentaAhorro.Size = new System.Drawing.Size(444, 110);
            this.grbCuentaAhorro.TabIndex = 132;
            this.grbCuentaAhorro.TabStop = false;
            this.grbCuentaAhorro.Text = "Cuenta de Ahorros:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(198, 14);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(199, 21);
            this.cboMoneda.TabIndex = 125;
            // 
            // boton21
            // 
            this.boton21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.boton21.Location = new System.Drawing.Point(271, 41);
            this.boton21.Name = "boton21";
            this.boton21.Size = new System.Drawing.Size(166, 21);
            this.boton21.TabIndex = 117;
            this.boton21.Text = "Seleccionar cuenta de Ahorros:";
            this.boton21.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.boton21.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(4, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(191, 13);
            this.lblBase1.TabIndex = 126;
            this.lblBase1.Text = "Moneda de la cuenta de Ahorro:";
            // 
            // txtIdCtaAho
            // 
            this.txtIdCtaAho.Enabled = false;
            this.txtIdCtaAho.Location = new System.Drawing.Point(8, 42);
            this.txtIdCtaAho.Name = "txtIdCtaAho";
            this.txtIdCtaAho.ReadOnly = true;
            this.txtIdCtaAho.Size = new System.Drawing.Size(66, 20);
            this.txtIdCtaAho.TabIndex = 118;
            this.txtIdCtaAho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCuentaAho
            // 
            this.txtCuentaAho.Enabled = false;
            this.txtCuentaAho.Location = new System.Drawing.Point(80, 42);
            this.txtCuentaAho.Name = "txtCuentaAho";
            this.txtCuentaAho.ReadOnly = true;
            this.txtCuentaAho.Size = new System.Drawing.Size(187, 20);
            this.txtCuentaAho.TabIndex = 119;
            this.txtCuentaAho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(729, 334);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(89, 13);
            this.lblBase3.TabIndex = 134;
            this.lblBase3.Text = "Total A Pagar:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.FormatoDecimal = true;
            this.txtTotal.Location = new System.Drawing.Point(732, 349);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 2;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(181, 20);
            this.txtTotal.TabIndex = 133;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmPagoMasivoAporteFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 473);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.cboModalidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtTotalPagoFondo);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtNroFondo);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboConvenio1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtNroAportes);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtTotalPagoAporte);
            this.Controls.Add(this.dtgPagoCrditosConvenio);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbCuentaAhorro);
            this.Controls.Add(this.grbCheInter);
            this.Name = "frmPagoMasivoAporteFondo";
            this.Text = "Cobro Masivo Aporte y Fondo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCobroCreditosDctoPlanilla_FormClosed);
            this.Load += new System.EventHandler(this.frmCobroCreditosDctoPlanilla_Load);
            this.Controls.SetChildIndex(this.grbCheInter, 0);
            this.Controls.SetChildIndex(this.grbCuentaAhorro, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.dtgPagoCrditosConvenio, 0);
            this.Controls.SetChildIndex(this.txtTotalPagoAporte, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtNroAportes, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboConvenio1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.txtNroFondo, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtTotalPagoFondo, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboModalidad, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCrditosConvenio)).EndInit();
            this.grbCheInter.ResumeLayout(false);
            this.grbCheInter.PerformLayout();
            this.grbCuentaAhorro.ResumeLayout(false);
            this.grbCuentaAhorro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtNroAportes;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtTotalPagoAporte;
        private GEN.ControlesBase.dtgBase dtgPagoCrditosConvenio;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private GEN.ControlesBase.cboConvenio cboConvenio1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtNroFondo;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtNumRea txtTotalPagoFondo;
        private GEN.ControlesBase.cboBase cboModalidad;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.grbBase grbCheInter;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroDocumento;
        private GEN.ControlesBase.lblBase lblBase25;
        private GEN.ControlesBase.lblBase lblBase24;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroSerie;
        private GEN.ControlesBase.cboEntidad cboEntidad1;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.grbBase grbCuentaAhorro;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.BotonesBase.Boton2 boton21;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtIdCtaAho;
        private GEN.ControlesBase.txtBase txtCuentaAho;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.cboBase cboCuenta;
        private GEN.ControlesBase.lblBase lblCuenta;
        private GEN.ControlesBase.txtBase txtNroCuenta;

    }
}

