namespace GEN.ControlesBase
{
    partial class frmDetalleActividadPecuaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleActividadPecuaria));
            this.dtgCostosPecuario = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgVentasPecuario = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAgregarCosto = new GEN.BotonesBase.btnMiniAgregar();
            this.btnQuitarCosto = new GEN.BotonesBase.btnMiniQuitar();
            this.btnQuitarVenta = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarVenta = new GEN.BotonesBase.btnMiniAgregar();
            this.cboSubEtapa = new GEN.ControlesBase.cboBase(this.components);
            this.cboEtapa = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboFrecuenciaCostos = new GEN.ControlesBase.cboBase(this.components);
            this.cboMesIniCostos = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtPrecioUniCostos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboMesIniVentas = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.txtRendimientoUni = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPrecioUniVentas = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCantidadVentas = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboFrecuenciaVentas = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblTitulo = new GEN.ControlesBase.lblGrow();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTotalVentas = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnEditarVenta = new GEN.BotonesBase.btnMiniEditar();
            this.btnCancelarVenta = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnNuevoVenta = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboIDsVenta = new GEN.ControlesBase.cboBase(this.components);
            this.txtTotalCostos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtCantidadCostos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnEditarCosto = new GEN.BotonesBase.btnMiniEditar();
            this.btnCancelarCosto = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnNuevoCosto = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.lblGrow1 = new GEN.ControlesBase.lblGrow();
            this.lblGrow2 = new GEN.ControlesBase.lblGrow();
            this.lblGrow3 = new GEN.ControlesBase.lblGrow();
            this.lblGrow4 = new GEN.ControlesBase.lblGrow();
            this.lblTipoInventario = new GEN.ControlesBase.lblGrow();
            this.lblRaza = new GEN.ControlesBase.lblGrow();
            this.lblProductoDerivado = new GEN.ControlesBase.lblGrow();
            this.lblEspecie = new GEN.ControlesBase.lblGrow();
            this.lblAnimal = new GEN.ControlesBase.lblGrow();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblUnidadMedida = new GEN.ControlesBase.lblGrow();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCostosPecuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentasPecuario)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCostosPecuario
            // 
            this.dtgCostosPecuario.AllowUserToAddRows = false;
            this.dtgCostosPecuario.AllowUserToDeleteRows = false;
            this.dtgCostosPecuario.AllowUserToResizeColumns = false;
            this.dtgCostosPecuario.AllowUserToResizeRows = false;
            this.dtgCostosPecuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCostosPecuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCostosPecuario.Location = new System.Drawing.Point(394, 12);
            this.dtgCostosPecuario.MultiSelect = false;
            this.dtgCostosPecuario.Name = "dtgCostosPecuario";
            this.dtgCostosPecuario.ReadOnly = true;
            this.dtgCostosPecuario.RowHeadersVisible = false;
            this.dtgCostosPecuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCostosPecuario.Size = new System.Drawing.Size(760, 233);
            this.dtgCostosPecuario.TabIndex = 102;
            this.dtgCostosPecuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCostosPecuario_CellClick);
            this.dtgCostosPecuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCostosPecuario_CellDoubleClick);
            // 
            // dtgVentasPecuario
            // 
            this.dtgVentasPecuario.AllowUserToAddRows = false;
            this.dtgVentasPecuario.AllowUserToDeleteRows = false;
            this.dtgVentasPecuario.AllowUserToResizeColumns = false;
            this.dtgVentasPecuario.AllowUserToResizeRows = false;
            this.dtgVentasPecuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVentasPecuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVentasPecuario.Location = new System.Drawing.Point(394, 10);
            this.dtgVentasPecuario.MultiSelect = false;
            this.dtgVentasPecuario.Name = "dtgVentasPecuario";
            this.dtgVentasPecuario.ReadOnly = true;
            this.dtgVentasPecuario.RowHeadersVisible = false;
            this.dtgVentasPecuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVentasPecuario.Size = new System.Drawing.Size(760, 207);
            this.dtgVentasPecuario.TabIndex = 100;
            this.dtgVentasPecuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVentasPecuario_CellClick);
            this.dtgVentasPecuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVentasPecuario_CellDoubleClick);
            // 
            // btnAgregarCosto
            // 
            this.btnAgregarCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCosto.BackgroundImage")));
            this.btnAgregarCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarCosto.Location = new System.Drawing.Point(188, 218);
            this.btnAgregarCosto.Name = "btnAgregarCosto";
            this.btnAgregarCosto.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarCosto.TabIndex = 21;
            this.btnAgregarCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarCosto.UseVisualStyleBackColor = true;
            this.btnAgregarCosto.Click += new System.EventHandler(this.btnAgregarCosto_Click);
            // 
            // btnQuitarCosto
            // 
            this.btnQuitarCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarCosto.BackgroundImage")));
            this.btnQuitarCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarCosto.Location = new System.Drawing.Point(230, 218);
            this.btnQuitarCosto.Name = "btnQuitarCosto";
            this.btnQuitarCosto.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarCosto.TabIndex = 22;
            this.btnQuitarCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarCosto.UseVisualStyleBackColor = true;
            this.btnQuitarCosto.Click += new System.EventHandler(this.btnQuitarCosto_Click);
            // 
            // btnQuitarVenta
            // 
            this.btnQuitarVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarVenta.BackgroundImage")));
            this.btnQuitarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarVenta.Location = new System.Drawing.Point(230, 189);
            this.btnQuitarVenta.Name = "btnQuitarVenta";
            this.btnQuitarVenta.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarVenta.TabIndex = 9;
            this.btnQuitarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarVenta.UseVisualStyleBackColor = true;
            this.btnQuitarVenta.Click += new System.EventHandler(this.btnQuitarVenta_Click);
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarVenta.BackgroundImage")));
            this.btnAgregarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarVenta.Location = new System.Drawing.Point(188, 189);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarVenta.TabIndex = 8;
            this.btnAgregarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarVenta.UseVisualStyleBackColor = true;
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // cboSubEtapa
            // 
            this.cboSubEtapa.FormattingEnabled = true;
            this.cboSubEtapa.Location = new System.Drawing.Point(146, 70);
            this.cboSubEtapa.Name = "cboSubEtapa";
            this.cboSubEtapa.Size = new System.Drawing.Size(155, 21);
            this.cboSubEtapa.TabIndex = 14;
            // 
            // cboEtapa
            // 
            this.cboEtapa.FormattingEnabled = true;
            this.cboEtapa.Location = new System.Drawing.Point(146, 46);
            this.cboEtapa.Name = "cboEtapa";
            this.cboEtapa.Size = new System.Drawing.Size(155, 21);
            this.cboEtapa.TabIndex = 13;
            this.cboEtapa.SelectedIndexChanged += new System.EventHandler(this.cboEtapa_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(93, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(39, 13);
            this.lblBase3.TabIndex = 25;
            this.lblBase3.Text = "Etapa";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(58, 73);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(74, 13);
            this.lblBase4.TabIndex = 26;
            this.lblBase4.Text = "Sub - Etapa";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(64, 97);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(68, 13);
            this.lblBase5.TabIndex = 27;
            this.lblBase5.Text = "Frecuencia";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(70, 121);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 28;
            this.lblBase6.Text = "Mes inicio";
            // 
            // cboFrecuenciaCostos
            // 
            this.cboFrecuenciaCostos.FormattingEnabled = true;
            this.cboFrecuenciaCostos.Location = new System.Drawing.Point(146, 94);
            this.cboFrecuenciaCostos.Name = "cboFrecuenciaCostos";
            this.cboFrecuenciaCostos.Size = new System.Drawing.Size(121, 21);
            this.cboFrecuenciaCostos.TabIndex = 15;
            // 
            // cboMesIniCostos
            // 
            this.cboMesIniCostos.FormattingEnabled = true;
            this.cboMesIniCostos.Location = new System.Drawing.Point(146, 118);
            this.cboMesIniCostos.Name = "cboMesIniCostos";
            this.cboMesIniCostos.Size = new System.Drawing.Size(121, 21);
            this.cboMesIniCostos.TabIndex = 16;
            this.cboMesIniCostos.IntegralHeight = false;
            this.cboMesIniCostos.MaxDropDownItems = 12;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(59, 145);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(73, 13);
            this.lblBase7.TabIndex = 31;
            this.lblBase7.Text = "Costo x Uni";
            // 
            // txtPrecioUniCostos
            // 
            this.txtPrecioUniCostos.FormatoDecimal = false;
            this.txtPrecioUniCostos.Location = new System.Drawing.Point(146, 142);
            this.txtPrecioUniCostos.MaxLength = 10;
            this.txtPrecioUniCostos.Name = "txtPrecioUniCostos";
            this.txtPrecioUniCostos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecioUniCostos.nNumDecimales = 4;
            this.txtPrecioUniCostos.nvalor = 0D;
            this.txtPrecioUniCostos.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioUniCostos.TabIndex = 17;
            this.txtPrecioUniCostos.TextChanged += new System.EventHandler(this.txtPrecioUniCostos_TextChanged);
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(57, 97);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(75, 13);
            this.lblBase14.TabIndex = 39;
            this.lblBase14.Text = "Precio x Uni";
            // 
            // cboMesIniVentas
            // 
            this.cboMesIniVentas.FormattingEnabled = true;
            this.cboMesIniVentas.Location = new System.Drawing.Point(145, 47);
            this.cboMesIniVentas.Name = "cboMesIniVentas";
            this.cboMesIniVentas.Size = new System.Drawing.Size(121, 21);
            this.cboMesIniVentas.IntegralHeight = false;
            this.cboMesIniVentas.MaxDropDownItems = 12;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(74, 120);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(58, 13);
            this.lblBase15.TabIndex = 43;
            this.lblBase15.Text = "Cantidad";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(67, 49);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(64, 13);
            this.lblBase16.TabIndex = 44;
            this.lblBase16.Text = "Mes Inicio";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(63, 26);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(68, 13);
            this.lblBase17.TabIndex = 45;
            this.lblBase17.Text = "Frecuencia";
            // 
            // txtRendimientoUni
            // 
            this.txtRendimientoUni.FormatoDecimal = false;
            this.txtRendimientoUni.Location = new System.Drawing.Point(146, 71);
            this.txtRendimientoUni.MaxLength = 10;
            this.txtRendimientoUni.Name = "txtRendimientoUni";
            this.txtRendimientoUni.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRendimientoUni.nNumDecimales = 4;
            this.txtRendimientoUni.nvalor = 0D;
            this.txtRendimientoUni.Size = new System.Drawing.Size(100, 20);
            this.txtRendimientoUni.TabIndex = 3;
            this.txtRendimientoUni.TextChanged += new System.EventHandler(this.txtRendimientoUni_TextChanged);
            // 
            // txtPrecioUniVentas
            // 
            this.txtPrecioUniVentas.FormatoDecimal = false;
            this.txtPrecioUniVentas.Location = new System.Drawing.Point(146, 94);
            this.txtPrecioUniVentas.MaxLength = 10;
            this.txtPrecioUniVentas.Name = "txtPrecioUniVentas";
            this.txtPrecioUniVentas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecioUniVentas.nNumDecimales = 4;
            this.txtPrecioUniVentas.nvalor = 0D;
            this.txtPrecioUniVentas.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioUniVentas.TabIndex = 4;
            this.txtPrecioUniVentas.TextChanged += new System.EventHandler(this.txtPrecioUniVentas_TextChanged);
            // 
            // txtCantidadVentas
            // 
            this.txtCantidadVentas.FormatoDecimal = false;
            this.txtCantidadVentas.Location = new System.Drawing.Point(146, 117);
            this.txtCantidadVentas.MaxLength = 10;
            this.txtCantidadVentas.Name = "txtCantidadVentas";
            this.txtCantidadVentas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCantidadVentas.nNumDecimales = 4;
            this.txtCantidadVentas.nvalor = 0D;
            this.txtCantidadVentas.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadVentas.TabIndex = 5;
            this.txtCantidadVentas.TextChanged += new System.EventHandler(this.txtCantidadVentas_TextChanged);
            // 
            // cboFrecuenciaVentas
            // 
            this.cboFrecuenciaVentas.FormattingEnabled = true;
            this.cboFrecuenciaVentas.ItemHeight = 13;
            this.cboFrecuenciaVentas.Location = new System.Drawing.Point(145, 23);
            this.cboFrecuenciaVentas.Name = "cboFrecuenciaVentas";
            this.cboFrecuenciaVentas.Size = new System.Drawing.Size(121, 21);
            this.cboFrecuenciaVentas.TabIndex = 1;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(22, 74);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(110, 13);
            this.lblBase8.TabIndex = 50;
            this.lblBase8.Text = "Rendimiento x uni";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(1080, 579);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 25;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(43, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(54, 15);
            this.lblTitulo.TabIndex = 105;
            this.lblTitulo.Text = "Especie:";
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grbBase1.Controls.Add(this.txtTotalVentas);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.btnEditarVenta);
            this.grbBase1.Controls.Add(this.btnCancelarVenta);
            this.grbBase1.Controls.Add(this.btnNuevoVenta);
            this.grbBase1.Controls.Add(this.dtgVentasPecuario);
            this.grbBase1.Controls.Add(this.btnQuitarVenta);
            this.grbBase1.Controls.Add(this.btnAgregarVenta);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Controls.Add(this.cboFrecuenciaVentas);
            this.grbBase1.Controls.Add(this.txtCantidadVentas);
            this.grbBase1.Controls.Add(this.cboMesIniVentas);
            this.grbBase1.Controls.Add(this.txtPrecioUniVentas);
            this.grbBase1.Controls.Add(this.lblBase15);
            this.grbBase1.Controls.Add(this.txtRendimientoUni);
            this.grbBase1.Controls.Add(this.lblBase17);
            this.grbBase1.Controls.Add(this.lblBase16);
            this.grbBase1.Location = new System.Drawing.Point(10, 74);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(1160, 223);
            this.grbBase1.TabIndex = 106;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Ventas";
            // 
            // txtTotalVentas
            // 
            this.txtTotalVentas.Enabled = false;
            this.txtTotalVentas.FormatoDecimal = false;
            this.txtTotalVentas.Location = new System.Drawing.Point(146, 140);
            this.txtTotalVentas.Name = "txtTotalVentas";
            this.txtTotalVentas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalVentas.nNumDecimales = 4;
            this.txtTotalVentas.nvalor = 0D;
            this.txtTotalVentas.Size = new System.Drawing.Size(100, 20);
            this.txtTotalVentas.TabIndex = 6;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(98, 143);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(34, 13);
            this.lblBase9.TabIndex = 102;
            this.lblBase9.Text = "Total";
            // 
            // btnEditarVenta
            // 
            this.btnEditarVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarVenta.BackgroundImage")));
            this.btnEditarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarVenta.Location = new System.Drawing.Point(272, 189);
            this.btnEditarVenta.Name = "btnEditarVenta";
            this.btnEditarVenta.Size = new System.Drawing.Size(36, 28);
            this.btnEditarVenta.TabIndex = 10;
            this.btnEditarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarVenta.UseVisualStyleBackColor = true;
            this.btnEditarVenta.Click += new System.EventHandler(this.btnEditarVenta_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarVenta.BackgroundImage")));
            this.btnCancelarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarVenta.Location = new System.Drawing.Point(314, 189);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(36, 28);
            this.btnCancelarVenta.TabIndex = 11;
            this.btnCancelarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarVenta.UseVisualStyleBackColor = true;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnNuevoVenta
            // 
            this.btnNuevoVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoVenta.BackgroundImage")));
            this.btnNuevoVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoVenta.Location = new System.Drawing.Point(146, 189);
            this.btnNuevoVenta.Name = "btnNuevoVenta";
            this.btnNuevoVenta.Size = new System.Drawing.Size(36, 28);
            this.btnNuevoVenta.TabIndex = 7;
            this.btnNuevoVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoVenta.UseVisualStyleBackColor = true;
            this.btnNuevoVenta.Click += new System.EventHandler(this.btnNuevoVenta_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.cboIDsVenta);
            this.grbBase2.Controls.Add(this.txtTotalCostos);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.txtCantidadCostos);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.btnEditarCosto);
            this.grbBase2.Controls.Add(this.btnCancelarCosto);
            this.grbBase2.Controls.Add(this.btnNuevoCosto);
            this.grbBase2.Controls.Add(this.dtgCostosPecuario);
            this.grbBase2.Controls.Add(this.btnAgregarCosto);
            this.grbBase2.Controls.Add(this.btnQuitarCosto);
            this.grbBase2.Controls.Add(this.txtPrecioUniCostos);
            this.grbBase2.Controls.Add(this.cboSubEtapa);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.cboEtapa);
            this.grbBase2.Controls.Add(this.cboMesIniCostos);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.cboFrecuenciaCostos);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Location = new System.Drawing.Point(10, 317);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(1160, 256);
            this.grbBase2.TabIndex = 107;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Costos";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(75, 25);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(57, 13);
            this.lblBase11.TabIndex = 106;
            this.lblBase11.Text = "ID Venta";
            // 
            // cboIDsVenta
            // 
            this.cboIDsVenta.FormattingEnabled = true;
            this.cboIDsVenta.Location = new System.Drawing.Point(146, 22);
            this.cboIDsVenta.Name = "cboIDsVenta";
            this.cboIDsVenta.Size = new System.Drawing.Size(78, 21);
            this.cboIDsVenta.TabIndex = 12;
            this.cboIDsVenta.SelectedIndexChanged += new System.EventHandler(this.cboIDsVenta_SelectedIndexChanged);
            // 
            // txtTotalCostos
            // 
            this.txtTotalCostos.Enabled = false;
            this.txtTotalCostos.FormatoDecimal = false;
            this.txtTotalCostos.Location = new System.Drawing.Point(146, 188);
            this.txtTotalCostos.Name = "txtTotalCostos";
            this.txtTotalCostos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCostos.nNumDecimales = 4;
            this.txtTotalCostos.nvalor = 0D;
            this.txtTotalCostos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCostos.TabIndex = 19;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(98, 191);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(34, 13);
            this.lblBase10.TabIndex = 104;
            this.lblBase10.Text = "Total";
            // 
            // txtCantidadCostos
            // 
            this.txtCantidadCostos.FormatoDecimal = false;
            this.txtCantidadCostos.Location = new System.Drawing.Point(146, 165);
            this.txtCantidadCostos.MaxLength = 10;
            this.txtCantidadCostos.Name = "txtCantidadCostos";
            this.txtCantidadCostos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCantidadCostos.nNumDecimales = 4;
            this.txtCantidadCostos.nvalor = 0D;
            this.txtCantidadCostos.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadCostos.TabIndex = 18;
            this.txtCantidadCostos.TextChanged += new System.EventHandler(this.txtCantidadCostos_TextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(74, 168);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(58, 13);
            this.lblBase2.TabIndex = 103;
            this.lblBase2.Text = "Cantidad";
            // 
            // btnEditarCosto
            // 
            this.btnEditarCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarCosto.BackgroundImage")));
            this.btnEditarCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarCosto.Location = new System.Drawing.Point(272, 218);
            this.btnEditarCosto.Name = "btnEditarCosto";
            this.btnEditarCosto.Size = new System.Drawing.Size(36, 28);
            this.btnEditarCosto.TabIndex = 23;
            this.btnEditarCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarCosto.UseVisualStyleBackColor = true;
            this.btnEditarCosto.Click += new System.EventHandler(this.btnEditarCosto_Click);
            // 
            // btnCancelarCosto
            // 
            this.btnCancelarCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarCosto.BackgroundImage")));
            this.btnCancelarCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarCosto.Location = new System.Drawing.Point(314, 217);
            this.btnCancelarCosto.Name = "btnCancelarCosto";
            this.btnCancelarCosto.Size = new System.Drawing.Size(36, 28);
            this.btnCancelarCosto.TabIndex = 24;
            this.btnCancelarCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarCosto.UseVisualStyleBackColor = true;
            this.btnCancelarCosto.Click += new System.EventHandler(this.btnCancelarCosto_Click);
            // 
            // btnNuevoCosto
            // 
            this.btnNuevoCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoCosto.BackgroundImage")));
            this.btnNuevoCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoCosto.Location = new System.Drawing.Point(146, 218);
            this.btnNuevoCosto.Name = "btnNuevoCosto";
            this.btnNuevoCosto.Size = new System.Drawing.Size(36, 28);
            this.btnNuevoCosto.TabIndex = 20;
            this.btnNuevoCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoCosto.UseVisualStyleBackColor = true;
            this.btnNuevoCosto.Click += new System.EventHandler(this.btnNuevoCosto_Click);
            // 
            // lblGrow1
            // 
            this.lblGrow1.AutoSize = true;
            this.lblGrow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrow1.Location = new System.Drawing.Point(58, 46);
            this.lblGrow1.Name = "lblGrow1";
            this.lblGrow1.Size = new System.Drawing.Size(39, 15);
            this.lblGrow1.TabIndex = 108;
            this.lblGrow1.Text = "Raza:";
            // 
            // lblGrow2
            // 
            this.lblGrow2.AutoSize = true;
            this.lblGrow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrow2.Location = new System.Drawing.Point(462, 9);
            this.lblGrow2.Name = "lblGrow2";
            this.lblGrow2.Size = new System.Drawing.Size(48, 15);
            this.lblGrow2.TabIndex = 109;
            this.lblGrow2.Text = "Animal:";
            // 
            // lblGrow3
            // 
            this.lblGrow3.AutoSize = true;
            this.lblGrow3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrow3.Location = new System.Drawing.Point(399, 26);
            this.lblGrow3.Name = "lblGrow3";
            this.lblGrow3.Size = new System.Drawing.Size(111, 15);
            this.lblGrow3.TabIndex = 110;
            this.lblGrow3.Text = "Producto Derivado:";
            // 
            // lblGrow4
            // 
            this.lblGrow4.AutoSize = true;
            this.lblGrow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrow4.Location = new System.Drawing.Point(7, 9);
            this.lblGrow4.Name = "lblGrow4";
            this.lblGrow4.Size = new System.Drawing.Size(90, 15);
            this.lblGrow4.TabIndex = 111;
            this.lblGrow4.Text = "Tipo Inventario:";
            // 
            // lblTipoInventario
            // 
            this.lblTipoInventario.AutoSize = true;
            this.lblTipoInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoInventario.Location = new System.Drawing.Point(103, 9);
            this.lblTipoInventario.Name = "lblTipoInventario";
            this.lblTipoInventario.Size = new System.Drawing.Size(25, 15);
            this.lblTipoInventario.TabIndex = 112;
            this.lblTipoInventario.Text = "- - -";
            // 
            // lblRaza
            // 
            this.lblRaza.AutoSize = true;
            this.lblRaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaza.Location = new System.Drawing.Point(103, 46);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(25, 15);
            this.lblRaza.TabIndex = 113;
            this.lblRaza.Text = "- - -";
            // 
            // lblProductoDerivado
            // 
            this.lblProductoDerivado.AutoSize = true;
            this.lblProductoDerivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductoDerivado.Location = new System.Drawing.Point(516, 26);
            this.lblProductoDerivado.Name = "lblProductoDerivado";
            this.lblProductoDerivado.Size = new System.Drawing.Size(25, 15);
            this.lblProductoDerivado.TabIndex = 114;
            this.lblProductoDerivado.Text = "- - -";
            // 
            // lblEspecie
            // 
            this.lblEspecie.AutoSize = true;
            this.lblEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecie.Location = new System.Drawing.Point(103, 26);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(25, 15);
            this.lblEspecie.TabIndex = 115;
            this.lblEspecie.Text = "- - -";
            // 
            // lblAnimal
            // 
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal.Location = new System.Drawing.Point(516, 9);
            this.lblAnimal.Name = "lblAnimal";
            this.lblAnimal.Size = new System.Drawing.Size(25, 15);
            this.lblAnimal.TabIndex = 116;
            this.lblAnimal.Text = "- - -";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(420, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(90, 13);
            this.lblBase1.TabIndex = 117;
            this.lblBase1.Text = "Unidad Medida";
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadMedida.Location = new System.Drawing.Point(516, 46);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(25, 15);
            this.lblUnidadMedida.TabIndex = 118;
            this.lblUnidadMedida.Text = "- - -";
            // 
            // frmDetalleActividadPecuaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 657);
            this.Controls.Add(this.lblUnidadMedida);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblAnimal);
            this.Controls.Add(this.lblEspecie);
            this.Controls.Add(this.lblProductoDerivado);
            this.Controls.Add(this.lblRaza);
            this.Controls.Add(this.lblTipoInventario);
            this.Controls.Add(this.lblGrow4);
            this.Controls.Add(this.lblGrow3);
            this.Controls.Add(this.lblGrow2);
            this.Controls.Add(this.lblGrow1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmDetalleActividadPecuaria";
            this.Text = "Detalle de Actividad Pecuaria";
            this.Load += new System.EventHandler(this.frmDetalleActividadPecuaria_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblGrow1, 0);
            this.Controls.SetChildIndex(this.lblGrow2, 0);
            this.Controls.SetChildIndex(this.lblGrow3, 0);
            this.Controls.SetChildIndex(this.lblGrow4, 0);
            this.Controls.SetChildIndex(this.lblTipoInventario, 0);
            this.Controls.SetChildIndex(this.lblRaza, 0);
            this.Controls.SetChildIndex(this.lblProductoDerivado, 0);
            this.Controls.SetChildIndex(this.lblEspecie, 0);
            this.Controls.SetChildIndex(this.lblAnimal, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblUnidadMedida, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCostosPecuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentasPecuario)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCostosPecuario;
        private GEN.ControlesBase.dtgBase dtgVentasPecuario;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarCosto;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarCosto;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarVenta;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarVenta;
        private GEN.ControlesBase.cboBase cboSubEtapa;
        private GEN.ControlesBase.cboBase cboEtapa;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboBase cboFrecuenciaCostos;
        private GEN.ControlesBase.cboBase cboMesIniCostos;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtPrecioUniCostos;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboBase cboMesIniVentas;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtNumRea txtRendimientoUni;
        private GEN.ControlesBase.txtNumRea txtPrecioUniVentas;
        private GEN.ControlesBase.txtNumRea txtCantidadVentas;
        private GEN.ControlesBase.cboBase cboFrecuenciaVentas;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblGrow lblTitulo;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelarVenta;
        private GEN.BotonesBase.btnMiniNuevo btnNuevoVenta;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelarCosto;
        private GEN.BotonesBase.btnMiniNuevo btnNuevoCosto;
        private BotonesBase.btnMiniEditar btnEditarVenta;
        private BotonesBase.btnMiniEditar btnEditarCosto;
        private lblGrow lblGrow1;
        private lblGrow lblGrow2;
        private lblGrow lblGrow3;
        private lblGrow lblGrow4;
        private lblGrow lblTipoInventario;
        private lblGrow lblRaza;
        private lblGrow lblProductoDerivado;
        private lblGrow lblEspecie;
        private lblGrow lblAnimal;
        private lblBase lblBase1;
        private lblGrow lblUnidadMedida;
        private txtNumRea txtCantidadCostos;
        private lblBase lblBase2;
        private txtNumRea txtTotalVentas;
        private lblBase lblBase9;
        private txtNumRea txtTotalCostos;
        private lblBase lblBase10;
        private lblBase lblBase11;
        private cboBase cboIDsVenta;

    }
}