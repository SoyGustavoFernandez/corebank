namespace ADM.Presentacion
{
    partial class frmAprobacionParametrizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionParametrizacion));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgAproAutonomiaUsuario = new GEN.ControlesBase.dtgBase(this.components);
            this.cCanalAproCredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNivelAprobacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPerfilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAproAutonomiaUsuario = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeshabilitarAutoUsu = new System.Windows.Forms.ToolStripButton();
            this.tsbActivarAutoUsu = new System.Windows.Forms.ToolStripButton();
            this.tsbEditarAutoUsu = new System.Windows.Forms.ToolStripButton();
            this.tsbAgregarAutoUsu = new System.Windows.Forms.ToolStripButton();
            this.pnlAproAutoUsuarioCtrl = new System.Windows.Forms.Panel();
            this.cboCanalAproCred = new GEN.ControlesBase.cboCanalAproCred(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdUsuario = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboPerfil = new GEN.ControlesBase.cboPerfil(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.btnMiniBusqueda = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.txtMontoAutonomia = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboNivelAprobacion = new GEN.ControlesBase.cboNivelAprobacion(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImpHistorico = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAproAutonomiaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAproAutonomiaUsuario)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.pnlAproAutoUsuarioCtrl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlAproAutoUsuarioCtrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 551);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgAproAutonomiaUsuario);
            this.panel3.Controls.Add(this.toolStrip4);
            this.panel3.Location = new System.Drawing.Point(3, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(840, 297);
            this.panel3.TabIndex = 3;
            // 
            // dtgAproAutonomiaUsuario
            // 
            this.dtgAproAutonomiaUsuario.AllowUserToAddRows = false;
            this.dtgAproAutonomiaUsuario.AllowUserToDeleteRows = false;
            this.dtgAproAutonomiaUsuario.AllowUserToResizeColumns = false;
            this.dtgAproAutonomiaUsuario.AllowUserToResizeRows = false;
            this.dtgAproAutonomiaUsuario.AutoGenerateColumns = false;
            this.dtgAproAutonomiaUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAproAutonomiaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAproAutonomiaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCanalAproCredDataGridViewTextBoxColumn,
            this.cNivelAprobacionDataGridViewTextBoxColumn,
            this.idUsuarioDataGridViewTextBoxColumn,
            this.cUsuarioDataGridViewTextBoxColumn,
            this.cPerfilDataGridViewTextBoxColumn,
            this.nMontoDataGridViewTextBoxColumn,
            this.cEstado});
            this.dtgAproAutonomiaUsuario.DataSource = this.bsAproAutonomiaUsuario;
            this.dtgAproAutonomiaUsuario.Location = new System.Drawing.Point(0, 28);
            this.dtgAproAutonomiaUsuario.MultiSelect = false;
            this.dtgAproAutonomiaUsuario.Name = "dtgAproAutonomiaUsuario";
            this.dtgAproAutonomiaUsuario.ReadOnly = true;
            this.dtgAproAutonomiaUsuario.RowHeadersVisible = false;
            this.dtgAproAutonomiaUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAproAutonomiaUsuario.Size = new System.Drawing.Size(840, 266);
            this.dtgAproAutonomiaUsuario.TabIndex = 27;
            this.dtgAproAutonomiaUsuario.SelectionChanged += new System.EventHandler(this.dtgAproAutonomiaUsuario_SelectionChanged);
            // 
            // cCanalAproCredDataGridViewTextBoxColumn
            // 
            this.cCanalAproCredDataGridViewTextBoxColumn.DataPropertyName = "cCanalAproCred";
            this.cCanalAproCredDataGridViewTextBoxColumn.FillWeight = 8F;
            this.cCanalAproCredDataGridViewTextBoxColumn.HeaderText = "Canal Aprobación";
            this.cCanalAproCredDataGridViewTextBoxColumn.Name = "cCanalAproCredDataGridViewTextBoxColumn";
            this.cCanalAproCredDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNivelAprobacionDataGridViewTextBoxColumn
            // 
            this.cNivelAprobacionDataGridViewTextBoxColumn.DataPropertyName = "cNivelAprobacion";
            this.cNivelAprobacionDataGridViewTextBoxColumn.FillWeight = 18F;
            this.cNivelAprobacionDataGridViewTextBoxColumn.HeaderText = "Nivel Aprobación";
            this.cNivelAprobacionDataGridViewTextBoxColumn.Name = "cNivelAprobacionDataGridViewTextBoxColumn";
            this.cNivelAprobacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUsuarioDataGridViewTextBoxColumn
            // 
            this.idUsuarioDataGridViewTextBoxColumn.DataPropertyName = "idUsuario";
            this.idUsuarioDataGridViewTextBoxColumn.FillWeight = 7F;
            this.idUsuarioDataGridViewTextBoxColumn.HeaderText = "Cod. Usuario";
            this.idUsuarioDataGridViewTextBoxColumn.Name = "idUsuarioDataGridViewTextBoxColumn";
            this.idUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUsuarioDataGridViewTextBoxColumn
            // 
            this.cUsuarioDataGridViewTextBoxColumn.DataPropertyName = "cUsuario";
            this.cUsuarioDataGridViewTextBoxColumn.FillWeight = 30F;
            this.cUsuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.cUsuarioDataGridViewTextBoxColumn.Name = "cUsuarioDataGridViewTextBoxColumn";
            this.cUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPerfilDataGridViewTextBoxColumn
            // 
            this.cPerfilDataGridViewTextBoxColumn.DataPropertyName = "cPerfil";
            this.cPerfilDataGridViewTextBoxColumn.FillWeight = 18F;
            this.cPerfilDataGridViewTextBoxColumn.HeaderText = "Perfil";
            this.cPerfilDataGridViewTextBoxColumn.Name = "cPerfilDataGridViewTextBoxColumn";
            this.cPerfilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMontoDataGridViewTextBoxColumn
            // 
            this.nMontoDataGridViewTextBoxColumn.DataPropertyName = "nMonto";
            this.nMontoDataGridViewTextBoxColumn.FillWeight = 10F;
            this.nMontoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.nMontoDataGridViewTextBoxColumn.Name = "nMontoDataGridViewTextBoxColumn";
            this.nMontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cEstado
            // 
            this.cEstado.DataPropertyName = "cEstado";
            this.cEstado.FillWeight = 10F;
            this.cEstado.HeaderText = "Estado";
            this.cEstado.Name = "cEstado";
            this.cEstado.ReadOnly = true;
            // 
            // bsAproAutonomiaUsuario
            // 
            this.bsAproAutonomiaUsuario.DataSource = typeof(EntityLayer.clsAprobacionAutonomiaUsuario);
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator4,
            this.tsbDeshabilitarAutoUsu,
            this.tsbActivarAutoUsu,
            this.tsbEditarAutoUsu,
            this.tsbAgregarAutoUsu});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(840, 25);
            this.toolStrip4.TabIndex = 26;
            this.toolStrip4.Text = "Anular";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(212, 22);
            this.toolStripLabel4.Text = "Autonomia de Aprobación por Usuario";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeshabilitarAutoUsu
            // 
            this.tsbDeshabilitarAutoUsu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDeshabilitarAutoUsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbDeshabilitarAutoUsu.Image = global::ADM.Presentacion.Properties.Resources.prohibition_16x16;
            this.tsbDeshabilitarAutoUsu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeshabilitarAutoUsu.Name = "tsbDeshabilitarAutoUsu";
            this.tsbDeshabilitarAutoUsu.Size = new System.Drawing.Size(89, 22);
            this.tsbDeshabilitarAutoUsu.Text = "Deshabilitar";
            this.tsbDeshabilitarAutoUsu.Click += new System.EventHandler(this.tsbDeshabilitarAutoUsu_Click);
            // 
            // tsbActivarAutoUsu
            // 
            this.tsbActivarAutoUsu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbActivarAutoUsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbActivarAutoUsu.Image = global::ADM.Presentacion.Properties.Resources.check_16x16;
            this.tsbActivarAutoUsu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActivarAutoUsu.Name = "tsbActivarAutoUsu";
            this.tsbActivarAutoUsu.Size = new System.Drawing.Size(64, 22);
            this.tsbActivarAutoUsu.Text = "Activar";
            this.tsbActivarAutoUsu.Click += new System.EventHandler(this.tsbActivarAutoUsu_Click);
            // 
            // tsbEditarAutoUsu
            // 
            this.tsbEditarAutoUsu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEditarAutoUsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbEditarAutoUsu.Image = global::ADM.Presentacion.Properties.Resources.pencil_16x16;
            this.tsbEditarAutoUsu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditarAutoUsu.Name = "tsbEditarAutoUsu";
            this.tsbEditarAutoUsu.Size = new System.Drawing.Size(57, 22);
            this.tsbEditarAutoUsu.Text = "Editar";
            this.tsbEditarAutoUsu.Click += new System.EventHandler(this.tsbEditarAutoUsu_Click);
            // 
            // tsbAgregarAutoUsu
            // 
            this.tsbAgregarAutoUsu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAgregarAutoUsu.Image = global::ADM.Presentacion.Properties.Resources.add_16x16;
            this.tsbAgregarAutoUsu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAgregarAutoUsu.Name = "tsbAgregarAutoUsu";
            this.tsbAgregarAutoUsu.Size = new System.Drawing.Size(69, 22);
            this.tsbAgregarAutoUsu.Text = "Agregar";
            this.tsbAgregarAutoUsu.Click += new System.EventHandler(this.tsbAgregarAutoUsu_Click);
            // 
            // pnlAproAutoUsuarioCtrl
            // 
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.cboCanalAproCred);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.panel1);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.txtIdUsuario);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase4);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.cboPerfil);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.btnCancelar);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.btnGrabar);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.txtUsuario);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.btnMiniBusqueda);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.txtMontoAutonomia);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.cboNivelAprobacion);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase5);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase6);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase3);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase2);
            this.pnlAproAutoUsuarioCtrl.Controls.Add(this.lblBase1);
            this.pnlAproAutoUsuarioCtrl.Location = new System.Drawing.Point(3, 3);
            this.pnlAproAutoUsuarioCtrl.Name = "pnlAproAutoUsuarioCtrl";
            this.pnlAproAutoUsuarioCtrl.Size = new System.Drawing.Size(840, 186);
            this.pnlAproAutoUsuarioCtrl.TabIndex = 0;
            // 
            // cboCanalAproCred
            // 
            this.cboCanalAproCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalAproCred.FormattingEnabled = true;
            this.cboCanalAproCred.Location = new System.Drawing.Point(146, 66);
            this.cboCanalAproCred.Name = "cboCanalAproCred";
            this.cboCanalAproCred.Size = new System.Drawing.Size(224, 21);
            this.cboCanalAproCred.TabIndex = 18;
            this.cboCanalAproCred.SelectedIndexChanged += new System.EventHandler(this.cboCanalAproCred_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 53);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(18, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(666, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "* Si un usuario tiene múltiples perfiles que no pertenecen a un mismo nivel de ap" +
    "robación, se deben crear autonomías por cada perfil.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(710, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Al hacer click sobre el botón \"Agregar\" o \"Editar\" la tabla de datos será bloqu" +
    "eada hasta que haga click sobre el botón \"Grabar\" o \"Cancelar\".";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(201)))));
            this.txtIdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdUsuario.Format = "n2";
            this.txtIdUsuario.Location = new System.Drawing.Point(500, 94);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(174, 20);
            this.txtIdUsuario.TabIndex = 16;
            this.txtIdUsuario.Text = "0";
            this.txtIdUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(412, 96);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(82, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Cod.Usuario:";
            // 
            // cboPerfil
            // 
            this.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfil.FormattingEnabled = true;
            this.cboPerfil.Location = new System.Drawing.Point(146, 121);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Size = new System.Drawing.Size(224, 21);
            this.cboPerfil.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(762, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(687, 131);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(201)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Location = new System.Drawing.Point(538, 65);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(284, 20);
            this.txtUsuario.TabIndex = 10;
            // 
            // btnMiniBusqueda
            // 
            this.btnMiniBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqueda.BackgroundImage")));
            this.btnMiniBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiniBusqueda.Location = new System.Drawing.Point(500, 63);
            this.btnMiniBusqueda.Name = "btnMiniBusqueda";
            this.btnMiniBusqueda.Size = new System.Drawing.Size(32, 25);
            this.btnMiniBusqueda.TabIndex = 9;
            this.btnMiniBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqueda.UseVisualStyleBackColor = true;
            this.btnMiniBusqueda.Click += new System.EventHandler(this.btnMiniBusqueda_Click);
            // 
            // txtMontoAutonomia
            // 
            this.txtMontoAutonomia.FormatoDecimal = true;
            this.txtMontoAutonomia.Location = new System.Drawing.Point(500, 122);
            this.txtMontoAutonomia.Name = "txtMontoAutonomia";
            this.txtMontoAutonomia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoAutonomia.nNumDecimales = 2;
            this.txtMontoAutonomia.nvalor = 0D;
            this.txtMontoAutonomia.Size = new System.Drawing.Size(174, 20);
            this.txtMontoAutonomia.TabIndex = 7;
            this.txtMontoAutonomia.Text = "0.00";
            this.txtMontoAutonomia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboNivelAprobacion
            // 
            this.cboNivelAprobacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelAprobacion.FormattingEnabled = true;
            this.cboNivelAprobacion.Location = new System.Drawing.Point(146, 93);
            this.cboNivelAprobacion.Name = "cboNivelAprobacion";
            this.cboNivelAprobacion.Size = new System.Drawing.Size(224, 21);
            this.cboNivelAprobacion.TabIndex = 6;
            this.cboNivelAprobacion.SelectedIndexChanged += new System.EventHandler(this.cboNivelAprobacion_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(383, 126);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(111, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Monto Autonomia:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(439, 69);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(55, 13);
            this.lblBase6.TabIndex = 3;
            this.lblBase6.Text = "Usuario:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(35, 121);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Perfil Aprobador:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 97);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(126, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Nivel de Aprobación:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 69);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Canal Aprobación:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImpHistorico);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Location = new System.Drawing.Point(3, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnImpHistorico
            // 
            this.btnImpHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpHistorico.BackgroundImage")));
            this.btnImpHistorico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpHistorico.Location = new System.Drawing.Point(3, 0);
            this.btnImpHistorico.Name = "btnImpHistorico";
            this.btnImpHistorico.Size = new System.Drawing.Size(60, 50);
            this.btnImpHistorico.TabIndex = 1;
            this.btnImpHistorico.Text = "Histórico";
            this.btnImpHistorico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpHistorico.UseVisualStyleBackColor = true;
            this.btnImpHistorico.Click += new System.EventHandler(this.btnImpHistorico_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(777, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmAprobacionParametrizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 578);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAprobacionParametrizacion";
            this.Text = "Aprobación de Créditos Parametrización";
            this.Load += new System.EventHandler(this.frmAprobacionParametrizacion_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAproAutonomiaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAproAutonomiaUsuario)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.pnlAproAutoUsuarioCtrl.ResumeLayout(false);
            this.pnlAproAutoUsuarioCtrl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlAproAutoUsuarioCtrl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private GEN.ControlesBase.dtgBase dtgAproAutonomiaUsuario;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbEditarAutoUsu;
        private System.Windows.Forms.ToolStripButton tsbDeshabilitarAutoUsu;
        private System.Windows.Forms.ToolStripButton tsbActivarAutoUsu;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.BotonesBase.btnMiniBusqueda btnMiniBusqueda;
        private GEN.ControlesBase.txtNumRea txtMontoAutonomia;
        private GEN.ControlesBase.cboNivelAprobacion cboNivelAprobacion;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.BindingSource bsAproAutonomiaUsuario;
        private System.Windows.Forms.ToolStripButton tsbAgregarAutoUsu;
        private GEN.ControlesBase.cboPerfil cboPerfil;
        private GEN.ControlesBase.txtNumerico txtIdUsuario;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCanalAproCredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNivelAprobacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPerfilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstado;
        private GEN.BotonesBase.btnImprimir btnImpHistorico;
        private GEN.ControlesBase.cboCanalAproCred cboCanalAproCred;

    }
}