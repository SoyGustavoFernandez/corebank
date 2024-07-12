namespace LOG.Presentacion
{
    partial class frmSolicitaTransfAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitaTransfAlmacen));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboEstadoProcLog = new GEN.ControlesBase.cboEstadoProcLog(this.components);
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgTransferencias = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnQuitarActivo = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarActivo = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgActivos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitBien = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgDetalleTransferencia = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAddBien = new GEN.BotonesBase.btnMiniAgregar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnAddTransf = new GEN.BotonesBase.btnMiniAgregar();
            this.btnRemoveTransf = new GEN.BotonesBase.btnMiniQuitar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransferencias)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.cboEstadoProcLog);
            this.grbBase1.Controls.Add(this.cboAlmacen);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Location = new System.Drawing.Point(5, 1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(777, 69);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(33, 46);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(50, 13);
            this.lblBase7.TabIndex = 18;
            this.lblBase7.Text = "Estado:";
            // 
            // cboEstadoProcLog
            // 
            this.cboEstadoProcLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoProcLog.FormattingEnabled = true;
            this.cboEstadoProcLog.Location = new System.Drawing.Point(90, 43);
            this.cboEstadoProcLog.Name = "cboEstadoProcLog";
            this.cboEstadoProcLog.Size = new System.Drawing.Size(210, 21);
            this.cboEstadoProcLog.TabIndex = 17;
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(395, 40);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(252, 21);
            this.cboAlmacen.TabIndex = 16;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(395, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(252, 21);
            this.cboAgencias.TabIndex = 15;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(330, 43);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Almacen:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(334, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(146, 19);
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
            this.lblBase2.Location = new System.Drawing.Point(2, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(28, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "De:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(679, 13);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 10;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(196, 13);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFecFin.TabIndex = 9;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(36, 13);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(104, 20);
            this.dtpFecIni.TabIndex = 8;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgTransferencias);
            this.grbBase2.Location = new System.Drawing.Point(5, 77);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(777, 196);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Almacen aTransferencias";
            // 
            // dtgTransferencias
            // 
            this.dtgTransferencias.AllowUserToAddRows = false;
            this.dtgTransferencias.AllowUserToDeleteRows = false;
            this.dtgTransferencias.AllowUserToResizeColumns = false;
            this.dtgTransferencias.AllowUserToResizeRows = false;
            this.dtgTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransferencias.Location = new System.Drawing.Point(6, 19);
            this.dtgTransferencias.MultiSelect = false;
            this.dtgTransferencias.Name = "dtgTransferencias";
            this.dtgTransferencias.ReadOnly = true;
            this.dtgTransferencias.RowHeadersVisible = false;
            this.dtgTransferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTransferencias.Size = new System.Drawing.Size(724, 173);
            this.dtgTransferencias.TabIndex = 0;
            this.dtgTransferencias.SelectionChanged += new System.EventHandler(this.dtgTransferencias_SelectionChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.btnQuitarActivo);
            this.grbBase3.Controls.Add(this.btnAgregarActivo);
            this.grbBase3.Controls.Add(this.dtgActivos);
            this.grbBase3.Controls.Add(this.btnQuitBien);
            this.grbBase3.Controls.Add(this.dtgDetalleTransferencia);
            this.grbBase3.Controls.Add(this.btnAddBien);
            this.grbBase3.Location = new System.Drawing.Point(5, 298);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(777, 234);
            this.grbBase3.TabIndex = 4;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Detalle de Transferencia";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(408, 10);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(110, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "Detalle de Activos";
            // 
            // btnQuitarActivo
            // 
            this.btnQuitarActivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarActivo.BackgroundImage")));
            this.btnQuitarActivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarActivo.Location = new System.Drawing.Point(736, 60);
            this.btnQuitarActivo.Name = "btnQuitarActivo";
            this.btnQuitarActivo.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarActivo.TabIndex = 21;
            this.btnQuitarActivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarActivo.UseVisualStyleBackColor = true;
            this.btnQuitarActivo.Click += new System.EventHandler(this.btnQuitarActivo_Click);
            // 
            // btnAgregarActivo
            // 
            this.btnAgregarActivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarActivo.BackgroundImage")));
            this.btnAgregarActivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarActivo.Location = new System.Drawing.Point(736, 26);
            this.btnAgregarActivo.Name = "btnAgregarActivo";
            this.btnAgregarActivo.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarActivo.TabIndex = 20;
            this.btnAgregarActivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarActivo.UseVisualStyleBackColor = true;
            this.btnAgregarActivo.Click += new System.EventHandler(this.btnAgregarActivo_Click);
            // 
            // dtgActivos
            // 
            this.dtgActivos.AllowUserToAddRows = false;
            this.dtgActivos.AllowUserToDeleteRows = false;
            this.dtgActivos.AllowUserToResizeColumns = false;
            this.dtgActivos.AllowUserToResizeRows = false;
            this.dtgActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivos.Location = new System.Drawing.Point(407, 26);
            this.dtgActivos.MultiSelect = false;
            this.dtgActivos.Name = "dtgActivos";
            this.dtgActivos.ReadOnly = true;
            this.dtgActivos.RowHeadersVisible = false;
            this.dtgActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivos.Size = new System.Drawing.Size(323, 202);
            this.dtgActivos.TabIndex = 19;
            // 
            // btnQuitBien
            // 
            this.btnQuitBien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitBien.BackgroundImage")));
            this.btnQuitBien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitBien.Location = new System.Drawing.Point(364, 60);
            this.btnQuitBien.Name = "btnQuitBien";
            this.btnQuitBien.Size = new System.Drawing.Size(36, 28);
            this.btnQuitBien.TabIndex = 18;
            this.btnQuitBien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitBien.UseVisualStyleBackColor = true;
            this.btnQuitBien.Click += new System.EventHandler(this.btnQuitBien_Click);
            // 
            // dtgDetalleTransferencia
            // 
            this.dtgDetalleTransferencia.AllowUserToAddRows = false;
            this.dtgDetalleTransferencia.AllowUserToDeleteRows = false;
            this.dtgDetalleTransferencia.AllowUserToResizeColumns = false;
            this.dtgDetalleTransferencia.AllowUserToResizeRows = false;
            this.dtgDetalleTransferencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleTransferencia.Location = new System.Drawing.Point(6, 26);
            this.dtgDetalleTransferencia.MultiSelect = false;
            this.dtgDetalleTransferencia.Name = "dtgDetalleTransferencia";
            this.dtgDetalleTransferencia.ReadOnly = true;
            this.dtgDetalleTransferencia.RowHeadersVisible = false;
            this.dtgDetalleTransferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleTransferencia.Size = new System.Drawing.Size(352, 202);
            this.dtgDetalleTransferencia.TabIndex = 1;
            this.dtgDetalleTransferencia.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgDetalleTransferencia_CellValidating);
            this.dtgDetalleTransferencia.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleTransferencia_EditingControlShowing);
            this.dtgDetalleTransferencia.SelectionChanged += new System.EventHandler(this.dtgDetalleTransferencia_SelectionChanged);
            // 
            // btnAddBien
            // 
            this.btnAddBien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBien.BackgroundImage")));
            this.btnAddBien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddBien.Location = new System.Drawing.Point(364, 26);
            this.btnAddBien.Name = "btnAddBien";
            this.btnAddBien.Size = new System.Drawing.Size(36, 28);
            this.btnAddBien.TabIndex = 17;
            this.btnAddBien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddBien.UseVisualStyleBackColor = true;
            this.btnAddBien.Click += new System.EventHandler(this.btnAddBien_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(717, 537);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(464, 537);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(525, 537);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(586, 537);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(647, 537);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAddTransf
            // 
            this.btnAddTransf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddTransf.BackgroundImage")));
            this.btnAddTransf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddTransf.Location = new System.Drawing.Point(741, 106);
            this.btnAddTransf.Name = "btnAddTransf";
            this.btnAddTransf.Size = new System.Drawing.Size(36, 28);
            this.btnAddTransf.TabIndex = 15;
            this.btnAddTransf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddTransf.UseVisualStyleBackColor = true;
            this.btnAddTransf.Click += new System.EventHandler(this.btnAddTransf_Click);
            // 
            // btnRemoveTransf
            // 
            this.btnRemoveTransf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveTransf.BackgroundImage")));
            this.btnRemoveTransf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveTransf.Location = new System.Drawing.Point(741, 141);
            this.btnRemoveTransf.Name = "btnRemoveTransf";
            this.btnRemoveTransf.Size = new System.Drawing.Size(36, 28);
            this.btnRemoveTransf.TabIndex = 16;
            this.btnRemoveTransf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveTransf.UseVisualStyleBackColor = true;
            this.btnRemoveTransf.Click += new System.EventHandler(this.btnRemoveTransf_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(11, 278);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(148, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Moneda de transferencia";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(158, 275);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(138, 21);
            this.cboMoneda.TabIndex = 18;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(14, 542);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 19;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmSolicitaTransfAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 617);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnRemoveTransf);
            this.Controls.Add(this.btnAddTransf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmSolicitaTransfAlmacen";
            this.Text = "Solicitud de Transferencia de Almacén";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSolicitaTransfAlmacen_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAddTransf, 0);
            this.Controls.SetChildIndex(this.btnRemoveTransf, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransferencias)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgTransferencias;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgDetalleTransferencia;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnMiniAgregar btnAddTransf;
        private GEN.BotonesBase.btnMiniQuitar btnRemoveTransf;
        private GEN.BotonesBase.btnMiniQuitar btnQuitBien;
        private GEN.BotonesBase.btnMiniAgregar btnAddBien;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarActivo;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarActivo;
        private GEN.ControlesBase.dtgBase dtgActivos;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboEstadoProcLog cboEstadoProcLog;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}

