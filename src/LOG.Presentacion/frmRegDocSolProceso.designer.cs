namespace LOG.Presentacion
{
    partial class frmRegDocSolProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegDocSolProceso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgDetalleDoc = new GEN.ControlesBase.dtgBase(this.components);
            this.idCalendarioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocProAdquiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesTipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsDocumentoPorCalendarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgCalendario = new GEN.ControlesBase.dtgBase(this.components);
            this.idCalendarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEtapaCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEtapaCalendarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIndPlantillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsCalendarioAdjudicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDocumentoPorCalendarioBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsCalendarioAdjudicacionBindingSource)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDetalleDoc
            // 
            this.dtgDetalleDoc.AllowUserToAddRows = false;
            this.dtgDetalleDoc.AllowUserToDeleteRows = false;
            this.dtgDetalleDoc.AllowUserToResizeColumns = false;
            this.dtgDetalleDoc.AllowUserToResizeRows = false;
            this.dtgDetalleDoc.AutoGenerateColumns = false;
            this.dtgDetalleDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCalendarioDataGridViewTextBoxColumn1,
            this.idTipoDocProAdquiDataGridViewTextBoxColumn,
            this.cDesTipoDocDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn1});
            this.dtgDetalleDoc.DataSource = this.clsDocumentoPorCalendarioBindingSource;
            this.dtgDetalleDoc.Location = new System.Drawing.Point(9, 19);
            this.dtgDetalleDoc.MultiSelect = false;
            this.dtgDetalleDoc.Name = "dtgDetalleDoc";
            this.dtgDetalleDoc.ReadOnly = true;
            this.dtgDetalleDoc.RowHeadersVisible = false;
            this.dtgDetalleDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleDoc.Size = new System.Drawing.Size(731, 128);
            this.dtgDetalleDoc.TabIndex = 5;
            // 
            // idCalendarioDataGridViewTextBoxColumn1
            // 
            this.idCalendarioDataGridViewTextBoxColumn1.DataPropertyName = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn1.HeaderText = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn1.Name = "idCalendarioDataGridViewTextBoxColumn1";
            this.idCalendarioDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idCalendarioDataGridViewTextBoxColumn1.Visible = false;
            // 
            // idTipoDocProAdquiDataGridViewTextBoxColumn
            // 
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.DataPropertyName = "idTipoDocProAdqui";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.HeaderText = "idTipoDocProAdqui";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.Name = "idTipoDocProAdquiDataGridViewTextBoxColumn";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.Visible = false;
            // 
            // cDesTipoDocDataGridViewTextBoxColumn
            // 
            this.cDesTipoDocDataGridViewTextBoxColumn.DataPropertyName = "cDesTipoDoc";
            this.cDesTipoDocDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.cDesTipoDocDataGridViewTextBoxColumn.Name = "cDesTipoDocDataGridViewTextBoxColumn";
            this.cDesTipoDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lVigenteDataGridViewCheckBoxColumn1
            // 
            this.lVigenteDataGridViewCheckBoxColumn1.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.Name = "lVigenteDataGridViewCheckBoxColumn1";
            this.lVigenteDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // clsDocumentoPorCalendarioBindingSource
            // 
            this.clsDocumentoPorCalendarioBindingSource.DataSource = typeof(EntityLayer.clsDocumentoPorCalendario);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(687, 368);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleDoc);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 205);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(746, 157);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Documentos Solicitados Por Calendario";
            // 
            // dtgCalendario
            // 
            this.dtgCalendario.AllowUserToAddRows = false;
            this.dtgCalendario.AllowUserToDeleteRows = false;
            this.dtgCalendario.AllowUserToResizeColumns = false;
            this.dtgCalendario.AllowUserToResizeRows = false;
            this.dtgCalendario.AutoGenerateColumns = false;
            this.dtgCalendario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCalendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCalendarioDataGridViewTextBoxColumn,
            this.idProcesoDataGridViewTextBoxColumn,
            this.idEtapaCalendario,
            this.cEtapaCalendarioDataGridViewTextBoxColumn,
            this.dFechaInicioDataGridViewTextBoxColumn,
            this.dFechaFinDataGridViewTextBoxColumn,
            this.cObservacionesDataGridViewTextBoxColumn,
            this.idUsuRegDataGridViewTextBoxColumn,
            this.idUsuModDataGridViewTextBoxColumn,
            this.dFechaRegDataGridViewTextBoxColumn,
            this.dFechaModDataGridViewTextBoxColumn,
            this.lIndPlantillaDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn});
            this.dtgCalendario.DataSource = this.clsCalendarioAdjudicacionBindingSource;
            this.dtgCalendario.Location = new System.Drawing.Point(6, 18);
            this.dtgCalendario.MultiSelect = false;
            this.dtgCalendario.Name = "dtgCalendario";
            this.dtgCalendario.ReadOnly = true;
            this.dtgCalendario.RowHeadersVisible = false;
            this.dtgCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalendario.Size = new System.Drawing.Size(263, 138);
            this.dtgCalendario.TabIndex = 8;
            this.dtgCalendario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCalendario_CellContentClick);
            this.dtgCalendario.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgCalendario_CurrentCellDirtyStateChanged);
            this.dtgCalendario.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCalendario_RowEnter);
            this.dtgCalendario.SelectionChanged += new System.EventHandler(this.dtgCalendario_SelectionChanged);
            // 
            // idCalendarioDataGridViewTextBoxColumn
            // 
            this.idCalendarioDataGridViewTextBoxColumn.DataPropertyName = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.HeaderText = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.Name = "idCalendarioDataGridViewTextBoxColumn";
            this.idCalendarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCalendarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEtapaCalendario
            // 
            this.idEtapaCalendario.DataPropertyName = "idEtapaCalendario";
            this.idEtapaCalendario.HeaderText = "idEtapaCalendario";
            this.idEtapaCalendario.Name = "idEtapaCalendario";
            this.idEtapaCalendario.ReadOnly = true;
            this.idEtapaCalendario.Visible = false;
            // 
            // cEtapaCalendarioDataGridViewTextBoxColumn
            // 
            this.cEtapaCalendarioDataGridViewTextBoxColumn.DataPropertyName = "cEtapaCalendario";
            this.cEtapaCalendarioDataGridViewTextBoxColumn.FillWeight = 38.37551F;
            this.cEtapaCalendarioDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.cEtapaCalendarioDataGridViewTextBoxColumn.Name = "cEtapaCalendarioDataGridViewTextBoxColumn";
            this.cEtapaCalendarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dFechaInicioDataGridViewTextBoxColumn
            // 
            this.dFechaInicioDataGridViewTextBoxColumn.DataPropertyName = "dFechaInicio";
            dataGridViewCellStyle1.Format = "d";
            this.dFechaInicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dFechaInicioDataGridViewTextBoxColumn.FillWeight = 15F;
            this.dFechaInicioDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio";
            this.dFechaInicioDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.dFechaInicioDataGridViewTextBoxColumn.Name = "dFechaInicioDataGridViewTextBoxColumn";
            this.dFechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaInicioDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaFinDataGridViewTextBoxColumn
            // 
            this.dFechaFinDataGridViewTextBoxColumn.DataPropertyName = "dFechaFin";
            dataGridViewCellStyle2.Format = "d";
            this.dFechaFinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dFechaFinDataGridViewTextBoxColumn.FillWeight = 15F;
            this.dFechaFinDataGridViewTextBoxColumn.HeaderText = "Fecha Fin";
            this.dFechaFinDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.dFechaFinDataGridViewTextBoxColumn.Name = "dFechaFinDataGridViewTextBoxColumn";
            this.dFechaFinDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaFinDataGridViewTextBoxColumn.Visible = false;
            // 
            // cObservacionesDataGridViewTextBoxColumn
            // 
            this.cObservacionesDataGridViewTextBoxColumn.DataPropertyName = "cObservaciones";
            this.cObservacionesDataGridViewTextBoxColumn.FillWeight = 38.37551F;
            this.cObservacionesDataGridViewTextBoxColumn.HeaderText = "Observación";
            this.cObservacionesDataGridViewTextBoxColumn.Name = "cObservacionesDataGridViewTextBoxColumn";
            this.cObservacionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.cObservacionesDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuRegDataGridViewTextBoxColumn
            // 
            this.idUsuRegDataGridViewTextBoxColumn.DataPropertyName = "idUsuReg";
            this.idUsuRegDataGridViewTextBoxColumn.HeaderText = "idUsuReg";
            this.idUsuRegDataGridViewTextBoxColumn.Name = "idUsuRegDataGridViewTextBoxColumn";
            this.idUsuRegDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuRegDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuModDataGridViewTextBoxColumn
            // 
            this.idUsuModDataGridViewTextBoxColumn.DataPropertyName = "idUsuMod";
            this.idUsuModDataGridViewTextBoxColumn.HeaderText = "idUsuMod";
            this.idUsuModDataGridViewTextBoxColumn.Name = "idUsuModDataGridViewTextBoxColumn";
            this.idUsuModDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuModDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaRegDataGridViewTextBoxColumn
            // 
            this.dFechaRegDataGridViewTextBoxColumn.DataPropertyName = "dFechaReg";
            this.dFechaRegDataGridViewTextBoxColumn.HeaderText = "dFechaReg";
            this.dFechaRegDataGridViewTextBoxColumn.Name = "dFechaRegDataGridViewTextBoxColumn";
            this.dFechaRegDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaRegDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaModDataGridViewTextBoxColumn
            // 
            this.dFechaModDataGridViewTextBoxColumn.DataPropertyName = "dFechaMod";
            this.dFechaModDataGridViewTextBoxColumn.HeaderText = "dFechaMod";
            this.dFechaModDataGridViewTextBoxColumn.Name = "dFechaModDataGridViewTextBoxColumn";
            this.dFechaModDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaModDataGridViewTextBoxColumn.Visible = false;
            // 
            // lIndPlantillaDataGridViewTextBoxColumn
            // 
            this.lIndPlantillaDataGridViewTextBoxColumn.DataPropertyName = "lIndPlantilla";
            this.lIndPlantillaDataGridViewTextBoxColumn.HeaderText = "lIndPlantilla";
            this.lIndPlantillaDataGridViewTextBoxColumn.Name = "lIndPlantillaDataGridViewTextBoxColumn";
            this.lIndPlantillaDataGridViewTextBoxColumn.ReadOnly = true;
            this.lIndPlantillaDataGridViewTextBoxColumn.Visible = false;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // clsCalendarioAdjudicacionBindingSource
            // 
            this.clsCalendarioAdjudicacionBindingSource.DataSource = typeof(EntityLayer.clsCalendarioAdjudicacion);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgCalendario);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(9, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(277, 167);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Calendario de Proceso de Adquisición:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgDocumentos);
            this.grbBase3.Location = new System.Drawing.Point(286, 12);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(467, 167);
            this.grbBase3.TabIndex = 17;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Documentos:";
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Location = new System.Drawing.Point(5, 16);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(456, 138);
            this.dtgDocumentos.TabIndex = 17;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(717, 182);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 19;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(675, 182);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Enabled = false;
            this.chcBase1.Location = new System.Drawing.Point(15, 182);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(96, 17);
            this.chcBase1.TabIndex = 26;
            this.chcBase1.Text = "Utilizar Plantilla";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(625, 368);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 31;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(562, 368);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 30;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(501, 368);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 29;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmRegDocSolProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 445);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegDocSolProceso";
            this.Text = "Registrar Documentos Solicitados para el Proceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegDocSolProceso_FormClosing);
            this.Load += new System.EventHandler(this.frmRegDocSolProceso_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDocumentoPorCalendarioBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsCalendarioAdjudicacionBindingSource)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgDetalleDoc;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgCalendario;
        private System.Windows.Forms.BindingSource clsCalendarioAdjudicacionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCalendarioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocProAdquiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesTipoDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource clsDocumentoPorCalendarioBindingSource;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.BotonesBase.btnMiniQuitar btnQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCalendarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEtapaCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEtapaCalendarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lIndPlantillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
    }
}