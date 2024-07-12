namespace GEN.ControlesBase
{
    partial class frmConfigurarCargaArchivoNuevo
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
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboGrupoCargaArchivo1 = new GEN.ControlesBase.cboGrupoCargaArchivo(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgArchivoxGrupo = new System.Windows.Forms.DataGridView();
            this.clsTipoArchivoEscaneadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnQuitarArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditarArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNuevoArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuardarDocumento = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDownDocumento = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpDocumento = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.clsListaConfiguracionTipoArchivoEscaneadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.grbConfiguraciones = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conConfiguracionArchivos1 = new GEN.ControlesBase.conConfiguracionArchivos();
            this.chcOrdenar = new GEN.ControlesBase.chcBase(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.idTipoArchivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoArchivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoArchivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaVigenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lConFechaVigenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lIndefinidoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipArcOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipArcOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuActDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecActDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivoxGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoArchivoEscaneadoBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaConfiguracionTipoArchivoEscaneadoBindingSource)).BeginInit();
            this.grbConfiguraciones.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 9);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(112, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Grupo de Archivo:";
            // 
            // cboGrupoCargaArchivo1
            // 
            this.cboGrupoCargaArchivo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoCargaArchivo1.FormattingEnabled = true;
            this.cboGrupoCargaArchivo1.Location = new System.Drawing.Point(121, 7);
            this.cboGrupoCargaArchivo1.Name = "cboGrupoCargaArchivo1";
            this.cboGrupoCargaArchivo1.Size = new System.Drawing.Size(270, 21);
            this.cboGrupoCargaArchivo1.TabIndex = 1;
            this.cboGrupoCargaArchivo1.SelectedIndexChanged += new System.EventHandler(this.cboGrupoCargaArchivo1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 610);
            this.panel1.TabIndex = 183;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgArchivoxGrupo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 586);
            this.panel3.TabIndex = 25;
            // 
            // dtgArchivoxGrupo
            // 
            this.dtgArchivoxGrupo.AllowUserToAddRows = false;
            this.dtgArchivoxGrupo.AllowUserToDeleteRows = false;
            this.dtgArchivoxGrupo.AllowUserToResizeColumns = false;
            this.dtgArchivoxGrupo.AllowUserToResizeRows = false;
            this.dtgArchivoxGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtgArchivoxGrupo.AutoGenerateColumns = false;
            this.dtgArchivoxGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgArchivoxGrupo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgArchivoxGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgArchivoxGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArchivoxGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoArchivoDataGridViewTextBoxColumn,
            this.nOrdenDataGridViewTextBoxColumn,
            this.cTipoArchivoDataGridViewTextBoxColumn,
            this.idGrupoArchivoDataGridViewTextBoxColumn,
            this.dFechaVigenciaDataGridViewTextBoxColumn,
            this.lConFechaVigenciaDataGridViewCheckBoxColumn,
            this.lIndefinidoDataGridViewCheckBoxColumn,
            this.idTipArcOrigenDataGridViewTextBoxColumn,
            this.cTipArcOrigenDataGridViewTextBoxColumn,
            this.idUsuRegDataGridViewTextBoxColumn,
            this.dFecRegistroDataGridViewTextBoxColumn,
            this.idUsuActDataGridViewTextBoxColumn,
            this.dFecActDataGridViewTextBoxColumn});
            this.dtgArchivoxGrupo.DataSource = this.clsTipoArchivoEscaneadoBindingSource;
            this.dtgArchivoxGrupo.Location = new System.Drawing.Point(0, 0);
            this.dtgArchivoxGrupo.MultiSelect = false;
            this.dtgArchivoxGrupo.Name = "dtgArchivoxGrupo";
            this.dtgArchivoxGrupo.ReadOnly = true;
            this.dtgArchivoxGrupo.RowHeadersVisible = false;
            this.dtgArchivoxGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgArchivoxGrupo.Size = new System.Drawing.Size(394, 583);
            this.dtgArchivoxGrupo.TabIndex = 0;
            this.dtgArchivoxGrupo.TabStop = false;
            this.dtgArchivoxGrupo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivoxGrupo_RowEnter);
            // 
            // clsTipoArchivoEscaneadoBindingSource
            // 
            this.clsTipoArchivoEscaneadoBindingSource.DataSource = typeof(EntityLayer.clsTipoArchivoEscaneado);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.menuStrip1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(394, 24);
            this.panel4.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuitarArchivo,
            this.btnEditarArchivo,
            this.btnNuevoArchivo,
            this.btnGuardarDocumento,
            this.btnDownDocumento,
            this.btnUpDocumento,
            this.btnCancelOrden});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnQuitarArchivo
            // 
            this.btnQuitarArchivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQuitarArchivo.Checked = true;
            this.btnQuitarArchivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnQuitarArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuitarArchivo.Image = global::GEN.ControlesBase.Properties.Resources.btn_quitar;
            this.btnQuitarArchivo.Name = "btnQuitarArchivo";
            this.btnQuitarArchivo.Size = new System.Drawing.Size(28, 20);
            this.btnQuitarArchivo.Text = "Quitar";
            this.btnQuitarArchivo.ToolTipText = "Eliminar registro seleccionado.";
            this.btnQuitarArchivo.Click += new System.EventHandler(this.btnQuitarArchivo_Click);
            // 
            // btnEditarArchivo
            // 
            this.btnEditarArchivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEditarArchivo.Image = global::GEN.ControlesBase.Properties.Resources.btnSmallEdit;
            this.btnEditarArchivo.Name = "btnEditarArchivo";
            this.btnEditarArchivo.Size = new System.Drawing.Size(28, 20);
            this.btnEditarArchivo.ToolTipText = "Editar documento";
            this.btnEditarArchivo.Click += new System.EventHandler(this.btnEditarArchivo_Click);
            // 
            // btnNuevoArchivo
            // 
            this.btnNuevoArchivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnNuevoArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoArchivo.Image = global::GEN.ControlesBase.Properties.Resources.btnMinNuevo;
            this.btnNuevoArchivo.Name = "btnNuevoArchivo";
            this.btnNuevoArchivo.Size = new System.Drawing.Size(28, 20);
            this.btnNuevoArchivo.Text = "Agregar";
            this.btnNuevoArchivo.ToolTipText = "Agregar nuevo documento.";
            this.btnNuevoArchivo.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnGuardarDocumento
            // 
            this.btnGuardarDocumento.Image = global::GEN.ControlesBase.Properties.Resources.btnMiniGrabar;
            this.btnGuardarDocumento.Name = "btnGuardarDocumento";
            this.btnGuardarDocumento.Size = new System.Drawing.Size(28, 20);
            this.btnGuardarDocumento.Click += new System.EventHandler(this.btnGuardarDocumento_Click);
            // 
            // btnDownDocumento
            // 
            this.btnDownDocumento.Image = global::GEN.ControlesBase.Properties.Resources.Expand;
            this.btnDownDocumento.Name = "btnDownDocumento";
            this.btnDownDocumento.Size = new System.Drawing.Size(28, 20);
            this.btnDownDocumento.ToolTipText = "abajo";
            this.btnDownDocumento.Click += new System.EventHandler(this.btnDownDocumento_Click);
            // 
            // btnUpDocumento
            // 
            this.btnUpDocumento.Image = global::GEN.ControlesBase.Properties.Resources.chevron_doble_up3;
            this.btnUpDocumento.Name = "btnUpDocumento";
            this.btnUpDocumento.Size = new System.Drawing.Size(28, 20);
            this.btnUpDocumento.Click += new System.EventHandler(this.btnUpDocumento_Click);
            // 
            // btnCancelOrden
            // 
            this.btnCancelOrden.Image = global::GEN.ControlesBase.Properties.Resources.delete;
            this.btnCancelOrden.Name = "btnCancelOrden";
            this.btnCancelOrden.Size = new System.Drawing.Size(28, 20);
            this.btnCancelOrden.ToolTipText = "Cancelar ordenamiento";
            this.btnCancelOrden.Click += new System.EventHandler(this.btnCancelOrden_Click);
            // 
            // clsListaConfiguracionTipoArchivoEscaneadoBindingSource
            // 
            this.clsListaConfiguracionTipoArchivoEscaneadoBindingSource.DataSource = typeof(EntityLayer.clsListaConfiguracionTipoArchivoEscaneado);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.White;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(884, 24);
            this.miniToolStrip.TabIndex = 0;
            this.miniToolStrip.TabStop = true;
            // 
            // grbConfiguraciones
            // 
            this.grbConfiguraciones.Controls.Add(this.lblBase1);
            this.grbConfiguraciones.Controls.Add(this.conConfiguracionArchivos1);
            this.grbConfiguraciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConfiguraciones.Location = new System.Drawing.Point(0, 0);
            this.grbConfiguraciones.Name = "grbConfiguraciones";
            this.grbConfiguraciones.Size = new System.Drawing.Size(849, 666);
            this.grbConfiguraciones.TabIndex = 2;
            this.grbConfiguraciones.TabStop = false;
            this.grbConfiguraciones.Text = "Configuraciones";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(328, 305);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(295, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "No se realiza configuración alguna de este archivo";
            this.lblBase1.Visible = false;
            // 
            // conConfiguracionArchivos1
            // 
            this.conConfiguracionArchivos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conConfiguracionArchivos1.Location = new System.Drawing.Point(3, 16);
            this.conConfiguracionArchivos1.Name = "conConfiguracionArchivos1";
            this.conConfiguracionArchivos1.Size = new System.Drawing.Size(843, 647);
            this.conConfiguracionArchivos1.TabIndex = 0;
            this.conConfiguracionArchivos1.ClicEventosNuevo += new System.EventHandler(this.conConfiguracionArchivos1_ClicEventosNuevo);
            this.conConfiguracionArchivos1.ClicEventosEditar += new System.EventHandler(this.conConfiguracionArchivos1_ClicEventosEditar);
            this.conConfiguracionArchivos1.ClicEventosGuardar += new System.EventHandler(this.conConfiguracionArchivos1_ClicEventosGuardar);
            this.conConfiguracionArchivos1.ClicEventosCancelar += new System.EventHandler(this.conConfiguracionArchivos1_ClicEventosCancelar);
            // 
            // chcOrdenar
            // 
            this.chcOrdenar.AutoSize = true;
            this.chcOrdenar.ForeColor = System.Drawing.Color.Navy;
            this.chcOrdenar.Location = new System.Drawing.Point(6, 32);
            this.chcOrdenar.Name = "chcOrdenar";
            this.chcOrdenar.Size = new System.Drawing.Size(131, 17);
            this.chcOrdenar.TabIndex = 186;
            this.chcOrdenar.Text = "Habilitar ordenamiento";
            this.chcOrdenar.UseVisualStyleBackColor = true;
            this.chcOrdenar.CheckedChanged += new System.EventHandler(this.chcOrdenar_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblBase3);
            this.panel2.Controls.Add(this.chcOrdenar);
            this.panel2.Controls.Add(this.cboGrupoCargaArchivo1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 666);
            this.panel2.TabIndex = 187;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grbConfiguraciones);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(397, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(849, 666);
            this.panel5.TabIndex = 188;
            // 
            // idTipoArchivoDataGridViewTextBoxColumn
            // 
            this.idTipoArchivoDataGridViewTextBoxColumn.DataPropertyName = "idTipoArchivo";
            this.idTipoArchivoDataGridViewTextBoxColumn.HeaderText = "idTipoArchivo";
            this.idTipoArchivoDataGridViewTextBoxColumn.Name = "idTipoArchivoDataGridViewTextBoxColumn";
            this.idTipoArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoArchivoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nOrdenDataGridViewTextBoxColumn
            // 
            this.nOrdenDataGridViewTextBoxColumn.DataPropertyName = "nOrden";
            this.nOrdenDataGridViewTextBoxColumn.FillWeight = 35F;
            this.nOrdenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.nOrdenDataGridViewTextBoxColumn.Name = "nOrdenDataGridViewTextBoxColumn";
            this.nOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cTipoArchivoDataGridViewTextBoxColumn
            // 
            this.cTipoArchivoDataGridViewTextBoxColumn.DataPropertyName = "cTipoArchivo";
            this.cTipoArchivoDataGridViewTextBoxColumn.FillWeight = 180F;
            this.cTipoArchivoDataGridViewTextBoxColumn.HeaderText = "Archivo";
            this.cTipoArchivoDataGridViewTextBoxColumn.Name = "cTipoArchivoDataGridViewTextBoxColumn";
            this.cTipoArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idGrupoArchivoDataGridViewTextBoxColumn
            // 
            this.idGrupoArchivoDataGridViewTextBoxColumn.DataPropertyName = "idGrupoArchivo";
            this.idGrupoArchivoDataGridViewTextBoxColumn.HeaderText = "idGrupoArchivo";
            this.idGrupoArchivoDataGridViewTextBoxColumn.Name = "idGrupoArchivoDataGridViewTextBoxColumn";
            this.idGrupoArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idGrupoArchivoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaVigenciaDataGridViewTextBoxColumn
            // 
            this.dFechaVigenciaDataGridViewTextBoxColumn.DataPropertyName = "dFechaVigencia";
            this.dFechaVigenciaDataGridViewTextBoxColumn.FillWeight = 90F;
            this.dFechaVigenciaDataGridViewTextBoxColumn.HeaderText = "Fec Vigencia";
            this.dFechaVigenciaDataGridViewTextBoxColumn.Name = "dFechaVigenciaDataGridViewTextBoxColumn";
            this.dFechaVigenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaVigenciaDataGridViewTextBoxColumn.Visible = false;
            // 
            // lConFechaVigenciaDataGridViewCheckBoxColumn
            // 
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.DataPropertyName = "lConFechaVigencia";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.FillWeight = 35F;
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.HeaderText = "Con Vig.";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.Name = "lConFechaVigenciaDataGridViewCheckBoxColumn";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lIndefinidoDataGridViewCheckBoxColumn
            // 
            this.lIndefinidoDataGridViewCheckBoxColumn.DataPropertyName = "lIndefinido";
            this.lIndefinidoDataGridViewCheckBoxColumn.HeaderText = "lIndefinido";
            this.lIndefinidoDataGridViewCheckBoxColumn.Name = "lIndefinidoDataGridViewCheckBoxColumn";
            this.lIndefinidoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lIndefinidoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // idTipArcOrigenDataGridViewTextBoxColumn
            // 
            this.idTipArcOrigenDataGridViewTextBoxColumn.DataPropertyName = "idTipArcOrigen";
            this.idTipArcOrigenDataGridViewTextBoxColumn.HeaderText = "idTipArcOrigen";
            this.idTipArcOrigenDataGridViewTextBoxColumn.Name = "idTipArcOrigenDataGridViewTextBoxColumn";
            this.idTipArcOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipArcOrigenDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipArcOrigenDataGridViewTextBoxColumn
            // 
            this.cTipArcOrigenDataGridViewTextBoxColumn.DataPropertyName = "cTipArcOrigen";
            this.cTipArcOrigenDataGridViewTextBoxColumn.HeaderText = "cTipArcOrigen";
            this.cTipArcOrigenDataGridViewTextBoxColumn.Name = "cTipArcOrigenDataGridViewTextBoxColumn";
            this.cTipArcOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTipArcOrigenDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuRegDataGridViewTextBoxColumn
            // 
            this.idUsuRegDataGridViewTextBoxColumn.DataPropertyName = "idUsuReg";
            this.idUsuRegDataGridViewTextBoxColumn.HeaderText = "idUsuReg";
            this.idUsuRegDataGridViewTextBoxColumn.Name = "idUsuRegDataGridViewTextBoxColumn";
            this.idUsuRegDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuRegDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFecRegistroDataGridViewTextBoxColumn
            // 
            this.dFecRegistroDataGridViewTextBoxColumn.DataPropertyName = "dFecRegistro";
            this.dFecRegistroDataGridViewTextBoxColumn.HeaderText = "dFecRegistro";
            this.dFecRegistroDataGridViewTextBoxColumn.Name = "dFecRegistroDataGridViewTextBoxColumn";
            this.dFecRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFecRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuActDataGridViewTextBoxColumn
            // 
            this.idUsuActDataGridViewTextBoxColumn.DataPropertyName = "idUsuAct";
            this.idUsuActDataGridViewTextBoxColumn.HeaderText = "idUsuAct";
            this.idUsuActDataGridViewTextBoxColumn.Name = "idUsuActDataGridViewTextBoxColumn";
            this.idUsuActDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuActDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFecActDataGridViewTextBoxColumn
            // 
            this.dFecActDataGridViewTextBoxColumn.DataPropertyName = "dFecAct";
            this.dFecActDataGridViewTextBoxColumn.HeaderText = "dFecAct";
            this.dFecActDataGridViewTextBoxColumn.Name = "dFecActDataGridViewTextBoxColumn";
            this.dFecActDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFecActDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmConfigurarCargaArchivoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1246, 688);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Name = "frmConfigurarCargaArchivoNuevo";
            this.Text = "Configuración de Carga de Archivos";
            this.Load += new System.EventHandler(this.frmConfigurarCargaArchivo_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivoxGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoArchivoEscaneadoBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaConfiguracionTipoArchivoEscaneadoBindingSource)).EndInit();
            this.grbConfiguraciones.ResumeLayout(false);
            this.grbConfiguraciones.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase3;
        private cboGrupoCargaArchivo cboGrupoCargaArchivo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgArchivoxGrupo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnQuitarArchivo;
        private System.Windows.Forms.ToolStripMenuItem btnNuevoArchivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVisibleNaturalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVisibleJuridicaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lObligatorioNaturalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lObligatorioJuridicaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem btnEditarArchivo;
        private System.Windows.Forms.ToolStripMenuItem btnDownDocumento;
        private System.Windows.Forms.ToolStripMenuItem btnGuardarDocumento;
        private System.Windows.Forms.ToolStripMenuItem btnUpDocumento;
        private System.Windows.Forms.ToolStripMenuItem btnCancelOrden;
        private System.Windows.Forms.BindingSource clsTipoArchivoEscaneadoBindingSource;
        private System.Windows.Forms.BindingSource clsListaConfiguracionTipoArchivoEscaneadoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoEvaluacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoEvaluacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOficinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOficinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private grbBase grbConfiguraciones;
        private conConfiguracionArchivos conConfiguracionArchivos1;
        private chcBase chcOrdenar;
        private lblBase lblBase1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoArchivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoArchivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoArchivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaVigenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lConFechaVigenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lIndefinidoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipArcOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipArcOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuActDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecActDataGridViewTextBoxColumn;
    }
}