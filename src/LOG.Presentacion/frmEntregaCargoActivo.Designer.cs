namespace LOG.Presentacion
{
    partial class frmEntregaCargoActivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaCargoActivo));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciasOri = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboCargoPersonalOri = new GEN.ControlesBase.cboCargoPersonalcs(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.cboAreaOri = new GEN.ControlesBase.cboArea(this.components);
            this.txtUsuOrigen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboMotEntregaCargo = new GEN.ControlesBase.cboBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgActivoOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.nNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEntregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciasDes = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboCargoPersonalDes = new GEN.ControlesBase.cboCargoPersonalcs(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboAreaDes = new GEN.ControlesBase.cboArea(this.components);
            this.txtUsuDestino = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnBusColOri = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.btnBusColDes = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtObserv = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtMontoTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoFaltante = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(375, 399);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 39;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboAgenciasOri);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.cboCargoPersonalOri);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.cboAreaOri);
            this.grbBase3.Controls.Add(this.txtUsuOrigen);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Location = new System.Drawing.Point(218, 7);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(200, 114);
            this.grbBase3.TabIndex = 37;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Origen:";
            // 
            // cboAgenciasOri
            // 
            this.cboAgenciasOri.Enabled = false;
            this.cboAgenciasOri.FormattingEnabled = true;
            this.cboAgenciasOri.Location = new System.Drawing.Point(60, 39);
            this.cboAgenciasOri.Name = "cboAgenciasOri";
            this.cboAgenciasOri.Size = new System.Drawing.Size(134, 21);
            this.cboAgenciasOri.TabIndex = 46;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 42);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(51, 13);
            this.lblBase7.TabIndex = 45;
            this.lblBase7.Text = "Oficina:";
            // 
            // cboCargoPersonalOri
            // 
            this.cboCargoPersonalOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargoPersonalOri.Enabled = false;
            this.cboCargoPersonalOri.FormattingEnabled = true;
            this.cboCargoPersonalOri.Location = new System.Drawing.Point(60, 87);
            this.cboCargoPersonalOri.Name = "cboCargoPersonalOri";
            this.cboCargoPersonalOri.Size = new System.Drawing.Size(134, 21);
            this.cboCargoPersonalOri.TabIndex = 44;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(6, 90);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(47, 13);
            this.lblBase12.TabIndex = 43;
            this.lblBase12.Text = "Cargo:";
            // 
            // cboAreaOri
            // 
            this.cboAreaOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaOri.Enabled = false;
            this.cboAreaOri.FormattingEnabled = true;
            this.cboAreaOri.Location = new System.Drawing.Point(60, 63);
            this.cboAreaOri.Name = "cboAreaOri";
            this.cboAreaOri.Size = new System.Drawing.Size(134, 21);
            this.cboAreaOri.TabIndex = 42;
            // 
            // txtUsuOrigen
            // 
            this.txtUsuOrigen.Enabled = false;
            this.txtUsuOrigen.Location = new System.Drawing.Point(60, 17);
            this.txtUsuOrigen.Name = "txtUsuOrigen";
            this.txtUsuOrigen.Size = new System.Drawing.Size(134, 20);
            this.txtUsuOrigen.TabIndex = 7;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 66);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(39, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Área:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Usuario:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboMotEntregaCargo);
            this.grbBase2.Location = new System.Drawing.Point(12, 7);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(200, 100);
            this.grbBase2.TabIndex = 36;
            this.grbBase2.TabStop = false;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(62, 58);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(132, 21);
            this.cboMoneda.TabIndex = 44;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 62);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 43;
            this.lblBase1.Text = "Moneda:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 24);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(49, 13);
            this.lblBase5.TabIndex = 43;
            this.lblBase5.Text = "Motivo:";
            // 
            // cboMotEntregaCargo
            // 
            this.cboMotEntregaCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotEntregaCargo.FormattingEnabled = true;
            this.cboMotEntregaCargo.Location = new System.Drawing.Point(62, 20);
            this.cboMotEntregaCargo.Name = "cboMotEntregaCargo";
            this.cboMotEntregaCargo.Size = new System.Drawing.Size(132, 21);
            this.cboMotEntregaCargo.TabIndex = 42;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(441, 399);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(507, 399);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 31;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(648, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(573, 399);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgActivoOrigen
            // 
            this.dtgActivoOrigen.AllowUserToAddRows = false;
            this.dtgActivoOrigen.AllowUserToDeleteRows = false;
            this.dtgActivoOrigen.AllowUserToResizeColumns = false;
            this.dtgActivoOrigen.AllowUserToResizeRows = false;
            this.dtgActivoOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivoOrigen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nNro,
            this.cProducto,
            this.cRubro,
            this.cMaterial,
            this.cColor,
            this.cMarca,
            this.cSerie,
            this.cModelo,
            this.nValor,
            this.lEntregado});
            this.dtgActivoOrigen.Location = new System.Drawing.Point(6, 32);
            this.dtgActivoOrigen.MultiSelect = false;
            this.dtgActivoOrigen.Name = "dtgActivoOrigen";
            this.dtgActivoOrigen.ReadOnly = true;
            this.dtgActivoOrigen.RowHeadersVisible = false;
            this.dtgActivoOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivoOrigen.Size = new System.Drawing.Size(684, 168);
            this.dtgActivoOrigen.TabIndex = 2;
            this.dtgActivoOrigen.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActivoOrigen_CellValueChanged);
            this.dtgActivoOrigen.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgActivoOrigen_CurrentCellDirtyStateChanged);
            // 
            // nNro
            // 
            this.nNro.DataPropertyName = "nNro";
            this.nNro.FillWeight = 45.6853F;
            this.nNro.HeaderText = "Nro";
            this.nNro.Name = "nNro";
            this.nNro.ReadOnly = true;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 265.922F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cRubro
            // 
            this.cRubro.DataPropertyName = "cRubro";
            this.cRubro.FillWeight = 86.04914F;
            this.cRubro.HeaderText = "Rubro";
            this.cRubro.Name = "cRubro";
            this.cRubro.ReadOnly = true;
            // 
            // cMaterial
            // 
            this.cMaterial.DataPropertyName = "cMaterial";
            this.cMaterial.FillWeight = 86.04914F;
            this.cMaterial.HeaderText = "Material";
            this.cMaterial.Name = "cMaterial";
            this.cMaterial.ReadOnly = true;
            // 
            // cColor
            // 
            this.cColor.DataPropertyName = "cColor";
            this.cColor.FillWeight = 86.04914F;
            this.cColor.HeaderText = "Color";
            this.cColor.Name = "cColor";
            this.cColor.ReadOnly = true;
            // 
            // cMarca
            // 
            this.cMarca.DataPropertyName = "cMarca";
            this.cMarca.FillWeight = 86.04914F;
            this.cMarca.HeaderText = "Marca";
            this.cMarca.Name = "cMarca";
            this.cMarca.ReadOnly = true;
            // 
            // cSerie
            // 
            this.cSerie.DataPropertyName = "cSerie";
            this.cSerie.FillWeight = 86.04914F;
            this.cSerie.HeaderText = "Serie";
            this.cSerie.Name = "cSerie";
            this.cSerie.ReadOnly = true;
            // 
            // cModelo
            // 
            this.cModelo.DataPropertyName = "cModelo";
            this.cModelo.FillWeight = 86.04914F;
            this.cModelo.HeaderText = "Modelo";
            this.cModelo.Name = "cModelo";
            this.cModelo.ReadOnly = true;
            // 
            // nValor
            // 
            this.nValor.DataPropertyName = "nValor";
            this.nValor.FillWeight = 86.04914F;
            this.nValor.HeaderText = "Valor";
            this.nValor.Name = "nValor";
            this.nValor.ReadOnly = true;
            // 
            // lEntregado
            // 
            this.lEntregado.DataPropertyName = "lEntregado";
            this.lEntregado.FillWeight = 86.04914F;
            this.lEntregado.HeaderText = "Entregado";
            this.lEntregado.Name = "lEntregado";
            this.lEntregado.ReadOnly = true;
            this.lEntregado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ORIGEN DEL ACTIVO:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.label1);
            this.grbBase1.Controls.Add(this.dtgActivoOrigen);
            this.grbBase1.Location = new System.Drawing.Point(12, 113);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(696, 216);
            this.grbBase1.TabIndex = 35;
            this.grbBase1.TabStop = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.cboAgenciasDes);
            this.grbBase4.Controls.Add(this.lblBase2);
            this.grbBase4.Controls.Add(this.cboCargoPersonalDes);
            this.grbBase4.Controls.Add(this.lblBase13);
            this.grbBase4.Controls.Add(this.cboAreaDes);
            this.grbBase4.Controls.Add(this.txtUsuDestino);
            this.grbBase4.Controls.Add(this.lblBase6);
            this.grbBase4.Controls.Add(this.lblBase8);
            this.grbBase4.Location = new System.Drawing.Point(466, 7);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(200, 114);
            this.grbBase4.TabIndex = 38;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Destino:";
            // 
            // cboAgenciasDes
            // 
            this.cboAgenciasDes.Enabled = false;
            this.cboAgenciasDes.FormattingEnabled = true;
            this.cboAgenciasDes.Location = new System.Drawing.Point(60, 39);
            this.cboAgenciasDes.Name = "cboAgenciasDes";
            this.cboAgenciasDes.Size = new System.Drawing.Size(134, 21);
            this.cboAgenciasDes.TabIndex = 51;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 50;
            this.lblBase2.Text = "Oficina:";
            // 
            // cboCargoPersonalDes
            // 
            this.cboCargoPersonalDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargoPersonalDes.Enabled = false;
            this.cboCargoPersonalDes.FormattingEnabled = true;
            this.cboCargoPersonalDes.Location = new System.Drawing.Point(59, 87);
            this.cboCargoPersonalDes.Name = "cboCargoPersonalDes";
            this.cboCargoPersonalDes.Size = new System.Drawing.Size(135, 21);
            this.cboCargoPersonalDes.TabIndex = 49;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(6, 90);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(47, 13);
            this.lblBase13.TabIndex = 45;
            this.lblBase13.Text = "Cargo:";
            // 
            // cboAreaDes
            // 
            this.cboAreaDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaDes.Enabled = false;
            this.cboAreaDes.FormattingEnabled = true;
            this.cboAreaDes.Location = new System.Drawing.Point(60, 63);
            this.cboAreaDes.Name = "cboAreaDes";
            this.cboAreaDes.Size = new System.Drawing.Size(134, 21);
            this.cboAreaDes.TabIndex = 48;
            // 
            // txtUsuDestino
            // 
            this.txtUsuDestino.Enabled = false;
            this.txtUsuDestino.Location = new System.Drawing.Point(60, 17);
            this.txtUsuDestino.Name = "txtUsuDestino";
            this.txtUsuDestino.Size = new System.Drawing.Size(134, 20);
            this.txtUsuDestino.TabIndex = 45;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 66);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(39, 13);
            this.lblBase6.TabIndex = 44;
            this.lblBase6.Text = "Área:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(6, 20);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 43;
            this.lblBase8.Text = "Usuario:";
            // 
            // btnBusColOri
            // 
            this.btnBusColOri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusColOri.BackgroundImage")));
            this.btnBusColOri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusColOri.Enabled = false;
            this.btnBusColOri.Location = new System.Drawing.Point(424, 12);
            this.btnBusColOri.Name = "btnBusColOri";
            this.btnBusColOri.Size = new System.Drawing.Size(36, 28);
            this.btnBusColOri.TabIndex = 40;
            this.btnBusColOri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusColOri.UseVisualStyleBackColor = true;
            this.btnBusColOri.Click += new System.EventHandler(this.btnBusColOri_Click);
            // 
            // btnBusColDes
            // 
            this.btnBusColDes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusColDes.BackgroundImage")));
            this.btnBusColDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusColDes.Enabled = false;
            this.btnBusColDes.Location = new System.Drawing.Point(672, 12);
            this.btnBusColDes.Name = "btnBusColDes";
            this.btnBusColDes.Size = new System.Drawing.Size(36, 28);
            this.btnBusColDes.TabIndex = 41;
            this.btnBusColDes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusColDes.UseVisualStyleBackColor = true;
            this.btnBusColDes.Click += new System.EventHandler(this.btnBusColDes_Click);
            // 
            // txtObserv
            // 
            this.txtObserv.Enabled = false;
            this.txtObserv.Location = new System.Drawing.Point(12, 354);
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.Size = new System.Drawing.Size(263, 95);
            this.txtObserv.TabIndex = 42;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(9, 338);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(96, 13);
            this.lblBase9.TabIndex = 44;
            this.lblBase9.Text = "Observaciones:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(372, 338);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(78, 13);
            this.lblBase10.TabIndex = 45;
            this.lblBase10.Text = "Monto Total:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(372, 359);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(93, 13);
            this.lblBase11.TabIndex = 46;
            this.lblBase11.Text = "Monto faltante:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.FormatoDecimal = false;
            this.txtMontoTotal.Location = new System.Drawing.Point(465, 335);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoTotal.nNumDecimales = 4;
            this.txtMontoTotal.nvalor = 0D;
            this.txtMontoTotal.Size = new System.Drawing.Size(91, 20);
            this.txtMontoTotal.TabIndex = 47;
            // 
            // txtMontoFaltante
            // 
            this.txtMontoFaltante.Enabled = false;
            this.txtMontoFaltante.FormatoDecimal = false;
            this.txtMontoFaltante.Location = new System.Drawing.Point(465, 356);
            this.txtMontoFaltante.Name = "txtMontoFaltante";
            this.txtMontoFaltante.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoFaltante.nNumDecimales = 4;
            this.txtMontoFaltante.nvalor = 0D;
            this.txtMontoFaltante.Size = new System.Drawing.Size(91, 20);
            this.txtMontoFaltante.TabIndex = 48;
            // 
            // frmEntregaCargoActivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 479);
            this.Controls.Add(this.txtMontoFaltante);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtObserv);
            this.Controls.Add(this.btnBusColDes);
            this.Controls.Add(this.btnBusColOri);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "frmEntregaCargoActivo";
            this.Text = "Entrega de Cargo - Activo";
            this.Load += new System.EventHandler(this.frmEntregaCargoActivo_Load);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnBusColOri, 0);
            this.Controls.SetChildIndex(this.btnBusColDes, 0);
            this.Controls.SetChildIndex(this.txtObserv, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtMontoTotal, 0);
            this.Controls.SetChildIndex(this.txtMontoFaltante, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuOrigen;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboMotEntregaCargo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgActivoOrigen;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.cboArea cboAreaOri;
        private GEN.ControlesBase.cboArea cboAreaDes;
        private GEN.ControlesBase.txtBase txtUsuDestino;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnMiniBusq btnBusColOri;
        private GEN.BotonesBase.btnMiniBusq btnBusColDes;
        private GEN.ControlesBase.txtBase txtObserv;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtMontoTotal;
        private GEN.ControlesBase.txtNumRea txtMontoFaltante;
        private GEN.ControlesBase.cboCargoPersonalcs cboCargoPersonalOri;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.cboCargoPersonalcs cboCargoPersonalDes;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboAgencias cboAgenciasOri;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboAgencias cboAgenciasDes;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lEntregado;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}