namespace LOG.Presentacion
{
    partial class frmEntradaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntradaAlmacen));
            this.cboTipoIngresoNotEnt = new GEN.ControlesBase.cboTipoIngresoNotEnt(this.components);
            this.grbBusca = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboAlmacenBus = new GEN.ControlesBase.cboAlmacenes(this.components);
            this.cboAgenciaBus = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgOrdenesCompra = new GEN.ControlesBase.dtgBase(this.components);
            this.grbOrdenes = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgDetalleOrdenCompra = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboAlmacenes = new GEN.ControlesBase.cboAlmacenes(this.components);
            this.grbNotasentrada = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNotaEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgNotasEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbDetalleActivos = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitDetActivos = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAddDetActivos = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDetActivos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbCpg = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.chcCajaChica = new GEN.ControlesBase.chcBase(this.components);
            this.btnBusCpg = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.txtNumCpg = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.grbBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrdenesCompra)).BeginInit();
            this.grbOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleOrdenCompra)).BeginInit();
            this.grbNotasentrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasEntrada)).BeginInit();
            this.grbDetalleActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetActivos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbCpg.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTipoIngresoNotEnt
            // 
            this.cboTipoIngresoNotEnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIngresoNotEnt.Enabled = false;
            this.cboTipoIngresoNotEnt.FormattingEnabled = true;
            this.cboTipoIngresoNotEnt.Location = new System.Drawing.Point(255, 38);
            this.cboTipoIngresoNotEnt.Name = "cboTipoIngresoNotEnt";
            this.cboTipoIngresoNotEnt.Size = new System.Drawing.Size(167, 21);
            this.cboTipoIngresoNotEnt.TabIndex = 2;
            this.cboTipoIngresoNotEnt.SelectedIndexChanged += new System.EventHandler(this.cboTipoIngresoNotEnt_SelectedIndexChanged);
            // 
            // grbBusca
            // 
            this.grbBusca.Controls.Add(this.lblBase8);
            this.grbBusca.Controls.Add(this.lblBase9);
            this.grbBusca.Controls.Add(this.cboAlmacenBus);
            this.grbBusca.Controls.Add(this.cboAgenciaBus);
            this.grbBusca.Controls.Add(this.cboTipoIngresoNotEnt);
            this.grbBusca.Controls.Add(this.lblBase1);
            this.grbBusca.Controls.Add(this.btnBusqueda);
            this.grbBusca.Controls.Add(this.lblBase3);
            this.grbBusca.Controls.Add(this.lblBase2);
            this.grbBusca.Controls.Add(this.dtpFecIni);
            this.grbBusca.Controls.Add(this.dtpFecFin);
            this.grbBusca.Location = new System.Drawing.Point(9, 8);
            this.grbBusca.Name = "grbBusca";
            this.grbBusca.Size = new System.Drawing.Size(915, 71);
            this.grbBusca.TabIndex = 3;
            this.grbBusca.TabStop = false;
            this.grbBusca.Text = "Búsqueda";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(453, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(57, 13);
            this.lblBase8.TabIndex = 27;
            this.lblBase8.Text = "Agencia:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(449, 45);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(61, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Almacén:";
            // 
            // cboAlmacenBus
            // 
            this.cboAlmacenBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenBus.FormattingEnabled = true;
            this.cboAlmacenBus.Location = new System.Drawing.Point(516, 41);
            this.cboAlmacenBus.Name = "cboAlmacenBus";
            this.cboAlmacenBus.Size = new System.Drawing.Size(340, 21);
            this.cboAlmacenBus.TabIndex = 25;
            // 
            // cboAgenciaBus
            // 
            this.cboAgenciaBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaBus.Enabled = false;
            this.cboAgenciaBus.FormattingEnabled = true;
            this.cboAgenciaBus.Location = new System.Drawing.Point(516, 14);
            this.cboAgenciaBus.Name = "cboAgenciaBus";
            this.cboAgenciaBus.Size = new System.Drawing.Size(340, 21);
            this.cboAgenciaBus.TabIndex = 26;
            this.cboAgenciaBus.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaBus_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(252, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(102, 13);
            this.lblBase1.TabIndex = 11;
            this.lblBase1.Text = "Tipo de Entrada:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(869, 22);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(36, 28);
            this.btnBusqueda.TabIndex = 13;
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(118, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Hasta:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Desde:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(8, 38);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(104, 20);
            this.dtpFecIni.TabIndex = 8;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(118, 38);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFecFin.TabIndex = 9;
            // 
            // dtgOrdenesCompra
            // 
            this.dtgOrdenesCompra.AllowUserToAddRows = false;
            this.dtgOrdenesCompra.AllowUserToDeleteRows = false;
            this.dtgOrdenesCompra.AllowUserToResizeColumns = false;
            this.dtgOrdenesCompra.AllowUserToResizeRows = false;
            this.dtgOrdenesCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOrdenesCompra.Location = new System.Drawing.Point(9, 40);
            this.dtgOrdenesCompra.MultiSelect = false;
            this.dtgOrdenesCompra.Name = "dtgOrdenesCompra";
            this.dtgOrdenesCompra.ReadOnly = true;
            this.dtgOrdenesCompra.RowHeadersVisible = false;
            this.dtgOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOrdenesCompra.Size = new System.Drawing.Size(345, 119);
            this.dtgOrdenesCompra.TabIndex = 4;
            this.dtgOrdenesCompra.SelectionChanged += new System.EventHandler(this.dtgOrdenesCompra_SelectionChanged);
            // 
            // grbOrdenes
            // 
            this.grbOrdenes.Controls.Add(this.lblBase7);
            this.grbOrdenes.Controls.Add(this.lblBase6);
            this.grbOrdenes.Controls.Add(this.dtgDetalleOrdenCompra);
            this.grbOrdenes.Controls.Add(this.dtgOrdenesCompra);
            this.grbOrdenes.Location = new System.Drawing.Point(9, 83);
            this.grbOrdenes.Name = "grbOrdenes";
            this.grbOrdenes.Size = new System.Drawing.Size(915, 167);
            this.grbOrdenes.TabIndex = 5;
            this.grbOrdenes.TabStop = false;
            this.grbOrdenes.Text = "Ordenes de Compra";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(358, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(177, 13);
            this.lblBase7.TabIndex = 13;
            this.lblBase7.Text = "Detalle de Orden de Compra:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(8, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(190, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Listado de Ordenes de Compra:";
            // 
            // dtgDetalleOrdenCompra
            // 
            this.dtgDetalleOrdenCompra.AllowUserToAddRows = false;
            this.dtgDetalleOrdenCompra.AllowUserToDeleteRows = false;
            this.dtgDetalleOrdenCompra.AllowUserToResizeColumns = false;
            this.dtgDetalleOrdenCompra.AllowUserToResizeRows = false;
            this.dtgDetalleOrdenCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleOrdenCompra.Location = new System.Drawing.Point(361, 40);
            this.dtgDetalleOrdenCompra.MultiSelect = false;
            this.dtgDetalleOrdenCompra.Name = "dtgDetalleOrdenCompra";
            this.dtgDetalleOrdenCompra.ReadOnly = true;
            this.dtgDetalleOrdenCompra.RowHeadersVisible = false;
            this.dtgDetalleOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleOrdenCompra.Size = new System.Drawing.Size(544, 119);
            this.dtgDetalleOrdenCompra.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(19, 48);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Almacén:";
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenes.FormattingEnabled = true;
            this.cboAlmacenes.Location = new System.Drawing.Point(86, 44);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(398, 21);
            this.cboAlmacenes.TabIndex = 14;
            // 
            // grbNotasentrada
            // 
            this.grbNotasentrada.Controls.Add(this.dtgDetalleNotaEntrada);
            this.grbNotasentrada.Controls.Add(this.dtgNotasEntrada);
            this.grbNotasentrada.Location = new System.Drawing.Point(9, 256);
            this.grbNotasentrada.Name = "grbNotasentrada";
            this.grbNotasentrada.Size = new System.Drawing.Size(443, 150);
            this.grbNotasentrada.TabIndex = 16;
            this.grbNotasentrada.TabStop = false;
            this.grbNotasentrada.Text = "Notas de Entrada de la Orden de Compra";
            // 
            // dtgDetalleNotaEntrada
            // 
            this.dtgDetalleNotaEntrada.AllowUserToAddRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToDeleteRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeColumns = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeRows = false;
            this.dtgDetalleNotaEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNotaEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNotaEntrada.Location = new System.Drawing.Point(114, 19);
            this.dtgDetalleNotaEntrada.MultiSelect = false;
            this.dtgDetalleNotaEntrada.Name = "dtgDetalleNotaEntrada";
            this.dtgDetalleNotaEntrada.ReadOnly = true;
            this.dtgDetalleNotaEntrada.RowHeadersVisible = false;
            this.dtgDetalleNotaEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNotaEntrada.Size = new System.Drawing.Size(322, 120);
            this.dtgDetalleNotaEntrada.TabIndex = 1;
            this.dtgDetalleNotaEntrada.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgDetalleNotaEntrada_CellValidating);
            this.dtgDetalleNotaEntrada.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNotaEntrada_CellValueChanged);
            this.dtgDetalleNotaEntrada.SelectionChanged += new System.EventHandler(this.dtgDetalleNotaEntrada_SelectionChanged);
            // 
            // dtgNotasEntrada
            // 
            this.dtgNotasEntrada.AllowUserToAddRows = false;
            this.dtgNotasEntrada.AllowUserToDeleteRows = false;
            this.dtgNotasEntrada.AllowUserToResizeColumns = false;
            this.dtgNotasEntrada.AllowUserToResizeRows = false;
            this.dtgNotasEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotasEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotasEntrada.Location = new System.Drawing.Point(6, 19);
            this.dtgNotasEntrada.MultiSelect = false;
            this.dtgNotasEntrada.Name = "dtgNotasEntrada";
            this.dtgNotasEntrada.ReadOnly = true;
            this.dtgNotasEntrada.RowHeadersVisible = false;
            this.dtgNotasEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotasEntrada.Size = new System.Drawing.Size(106, 120);
            this.dtgNotasEntrada.TabIndex = 0;
            this.dtgNotasEntrada.SelectionChanged += new System.EventHandler(this.dtgNotasEntrada_SelectionChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(861, 497);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 17;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(658, 497);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(658, 497);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(720, 497);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 20;
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
            this.btnCancelar.Location = new System.Drawing.Point(782, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(86, 17);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(398, 21);
            this.cboAgencia.TabIndex = 22;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(23, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 23;
            this.lblBase5.Text = "Agencia:";
            // 
            // grbDetalleActivos
            // 
            this.grbDetalleActivos.Controls.Add(this.btnQuitDetActivos);
            this.grbDetalleActivos.Controls.Add(this.btnAddDetActivos);
            this.grbDetalleActivos.Controls.Add(this.dtgDetActivos);
            this.grbDetalleActivos.Location = new System.Drawing.Point(458, 256);
            this.grbDetalleActivos.Name = "grbDetalleActivos";
            this.grbDetalleActivos.Size = new System.Drawing.Size(466, 150);
            this.grbDetalleActivos.TabIndex = 24;
            this.grbDetalleActivos.TabStop = false;
            this.grbDetalleActivos.Text = "Detalle de Activos";
            // 
            // btnQuitDetActivos
            // 
            this.btnQuitDetActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitDetActivos.BackgroundImage")));
            this.btnQuitDetActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitDetActivos.Location = new System.Drawing.Point(427, 53);
            this.btnQuitDetActivos.Name = "btnQuitDetActivos";
            this.btnQuitDetActivos.Size = new System.Drawing.Size(36, 28);
            this.btnQuitDetActivos.TabIndex = 2;
            this.btnQuitDetActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitDetActivos.UseVisualStyleBackColor = true;
            this.btnQuitDetActivos.Click += new System.EventHandler(this.btnQuitDetActivos_Click);
            // 
            // btnAddDetActivos
            // 
            this.btnAddDetActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDetActivos.BackgroundImage")));
            this.btnAddDetActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetActivos.Location = new System.Drawing.Point(427, 19);
            this.btnAddDetActivos.Name = "btnAddDetActivos";
            this.btnAddDetActivos.Size = new System.Drawing.Size(36, 28);
            this.btnAddDetActivos.TabIndex = 1;
            this.btnAddDetActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddDetActivos.UseVisualStyleBackColor = true;
            this.btnAddDetActivos.Click += new System.EventHandler(this.btnAddDetActivos_Click);
            // 
            // dtgDetActivos
            // 
            this.dtgDetActivos.AllowUserToAddRows = false;
            this.dtgDetActivos.AllowUserToDeleteRows = false;
            this.dtgDetActivos.AllowUserToResizeColumns = false;
            this.dtgDetActivos.AllowUserToResizeRows = false;
            this.dtgDetActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetActivos.Location = new System.Drawing.Point(6, 19);
            this.dtgDetActivos.MultiSelect = false;
            this.dtgDetActivos.Name = "dtgDetActivos";
            this.dtgDetActivos.ReadOnly = true;
            this.dtgDetActivos.RowHeadersVisible = false;
            this.dtgDetActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetActivos.Size = new System.Drawing.Size(415, 120);
            this.dtgDetActivos.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboAlmacenes);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Location = new System.Drawing.Point(9, 412);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(549, 79);
            this.grbBase1.TabIndex = 25;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Nota Entrada";
            // 
            // grbCpg
            // 
            this.grbCpg.Controls.Add(this.cboTipoComprobantePago);
            this.grbCpg.Controls.Add(this.chcCajaChica);
            this.grbCpg.Controls.Add(this.btnBusCpg);
            this.grbCpg.Controls.Add(this.lblBase16);
            this.grbCpg.Controls.Add(this.txtNumCpg);
            this.grbCpg.Controls.Add(this.lblBase13);
            this.grbCpg.Location = new System.Drawing.Point(564, 412);
            this.grbCpg.Name = "grbCpg";
            this.grbCpg.Size = new System.Drawing.Size(360, 79);
            this.grbCpg.TabIndex = 52;
            this.grbCpg.TabStop = false;
            this.grbCpg.Text = "Comprobante de Pago";
            this.grbCpg.Visible = false;
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.Enabled = false;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(90, 41);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(246, 21);
            this.cboTipoComprobantePago.TabIndex = 36;
            // 
            // chcCajaChica
            // 
            this.chcCajaChica.AutoSize = true;
            this.chcCajaChica.Location = new System.Drawing.Point(256, 17);
            this.chcCajaChica.Name = "chcCajaChica";
            this.chcCajaChica.Size = new System.Drawing.Size(83, 17);
            this.chcCajaChica.TabIndex = 35;
            this.chcCajaChica.Text = "Caja Chica?";
            this.chcCajaChica.UseVisualStyleBackColor = true;
            // 
            // btnBusCpg
            // 
            this.btnBusCpg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCpg.BackgroundImage")));
            this.btnBusCpg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCpg.Location = new System.Drawing.Point(214, 11);
            this.btnBusCpg.Name = "btnBusCpg";
            this.btnBusCpg.Size = new System.Drawing.Size(36, 28);
            this.btnBusCpg.TabIndex = 34;
            this.btnBusCpg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCpg.UseVisualStyleBackColor = true;
            this.btnBusCpg.Click += new System.EventHandler(this.btnBusCpg_Click);
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(7, 44);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(81, 13);
            this.lblBase16.TabIndex = 2;
            this.lblBase16.Text = "Tipo de Cpg:";
            // 
            // txtNumCpg
            // 
            this.txtNumCpg.Enabled = false;
            this.txtNumCpg.Location = new System.Drawing.Point(90, 15);
            this.txtNumCpg.Name = "txtNumCpg";
            this.txtNumCpg.Size = new System.Drawing.Size(117, 20);
            this.txtNumCpg.TabIndex = 1;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(31, 20);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(57, 13);
            this.lblBase13.TabIndex = 0;
            this.lblBase13.Text = "Numero:";
            // 
            // frmEntradaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 575);
            this.Controls.Add(this.grbCpg);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbDetalleActivos);
            this.Controls.Add(this.grbNotasentrada);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbBusca);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbOrdenes);
            this.Name = "frmEntradaAlmacen";
            this.Text = "Registro de Nota de Entrada a Almacén";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbOrdenes, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBusca, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.grbNotasentrada, 0);
            this.Controls.SetChildIndex(this.grbDetalleActivos, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbCpg, 0);
            this.grbBusca.ResumeLayout(false);
            this.grbBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrdenesCompra)).EndInit();
            this.grbOrdenes.ResumeLayout(false);
            this.grbOrdenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleOrdenCompra)).EndInit();
            this.grbNotasentrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasEntrada)).EndInit();
            this.grbDetalleActivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetActivos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbCpg.ResumeLayout(false);
            this.grbCpg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTipoIngresoNotEnt cboTipoIngresoNotEnt;
        private GEN.ControlesBase.grbBase grbBusca;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtgBase dtgOrdenesCompra;
        private GEN.ControlesBase.grbBase grbOrdenes;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboAlmacenes cboAlmacenes;
        private GEN.ControlesBase.dtgBase dtgDetalleOrdenCompra;
        private GEN.ControlesBase.grbBase grbNotasentrada;
        private GEN.ControlesBase.dtgBase dtgNotasEntrada;
        private GEN.ControlesBase.dtgBase dtgDetalleNotaEntrada;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbDetalleActivos;
        private GEN.BotonesBase.btnMiniQuitar btnQuitDetActivos;
        private GEN.BotonesBase.btnMiniAgregar btnAddDetActivos;
        private GEN.ControlesBase.dtgBase dtgDetActivos;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniBusq btnBusqueda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbCpg;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.chcBase chcCajaChica;
        private GEN.BotonesBase.btnMiniBusq btnBusCpg;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.txtBase txtNumCpg;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboAlmacenes cboAlmacenBus;
        private GEN.ControlesBase.cboAgencias cboAgenciaBus;
        private GEN.ControlesBase.cboAgencias cboAgencia;
    }
}

