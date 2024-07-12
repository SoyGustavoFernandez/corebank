namespace LOG.Presentacion
{
    partial class frmGenCalendarioPro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenCalendarioPro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.clsCalendarioAdjudicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgEtapaProceso = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgCalendario = new GEN.ControlesBase.dtgBase(this.components);
            this.idCalendarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEtapaCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEtapaCalendarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIndPlantillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpdFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar2 = new GEN.BotonesBase.btnQuitar();
            this.chcUtilizaPlantilla = new GEN.ControlesBase.chcBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.clsCalendarioAdjudicacionBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEtapaProceso)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(548, 389);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // clsCalendarioAdjudicacionBindingSource
            // 
            this.clsCalendarioAdjudicacionBindingSource.DataSource = typeof(EntityLayer.clsCalendarioAdjudicacion);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 7);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(210, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Etapas del Calendario de Procesos:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgEtapaProceso);
            this.grbBase1.Location = new System.Drawing.Point(8, 22);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(283, 172);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // dtgEtapaProceso
            // 
            this.dtgEtapaProceso.AllowUserToAddRows = false;
            this.dtgEtapaProceso.AllowUserToDeleteRows = false;
            this.dtgEtapaProceso.AllowUserToResizeColumns = false;
            this.dtgEtapaProceso.AllowUserToResizeRows = false;
            this.dtgEtapaProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEtapaProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEtapaProceso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgEtapaProceso.Location = new System.Drawing.Point(7, 15);
            this.dtgEtapaProceso.MultiSelect = false;
            this.dtgEtapaProceso.Name = "dtgEtapaProceso";
            this.dtgEtapaProceso.ReadOnly = true;
            this.dtgEtapaProceso.RowHeadersVisible = false;
            this.dtgEtapaProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEtapaProceso.Size = new System.Drawing.Size(270, 150);
            this.dtgEtapaProceso.TabIndex = 0;
            this.dtgEtapaProceso.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgEtapaProceso_CurrentCellDirtyStateChanged);
            this.dtgEtapaProceso.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEtapaProceso_RowEnter);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgCalendario);
            this.grbBase2.Location = new System.Drawing.Point(10, 217);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(523, 168);
            this.grbBase2.TabIndex = 6;
            this.grbBase2.TabStop = false;
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
            this.cEtapaCalendario,
            this.idProcesoDataGridViewTextBoxColumn,
            this.idEtapaCalendarioDataGridViewTextBoxColumn,
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
            this.dtgCalendario.Location = new System.Drawing.Point(6, 12);
            this.dtgCalendario.MultiSelect = false;
            this.dtgCalendario.Name = "dtgCalendario";
            this.dtgCalendario.ReadOnly = true;
            this.dtgCalendario.RowHeadersVisible = false;
            this.dtgCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalendario.Size = new System.Drawing.Size(511, 150);
            this.dtgCalendario.TabIndex = 4;
            // 
            // idCalendarioDataGridViewTextBoxColumn
            // 
            this.idCalendarioDataGridViewTextBoxColumn.DataPropertyName = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.HeaderText = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.Name = "idCalendarioDataGridViewTextBoxColumn";
            this.idCalendarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCalendarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // cEtapaCalendario
            // 
            this.cEtapaCalendario.DataPropertyName = "cEtapaCalendario";
            this.cEtapaCalendario.HeaderText = "Descripción";
            this.cEtapaCalendario.MinimumWidth = 100;
            this.cEtapaCalendario.Name = "cEtapaCalendario";
            this.cEtapaCalendario.ReadOnly = true;
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEtapaCalendarioDataGridViewTextBoxColumn
            // 
            this.idEtapaCalendarioDataGridViewTextBoxColumn.DataPropertyName = "idEtapaCalendario";
            this.idEtapaCalendarioDataGridViewTextBoxColumn.HeaderText = "idEtapaCalendario";
            this.idEtapaCalendarioDataGridViewTextBoxColumn.Name = "idEtapaCalendarioDataGridViewTextBoxColumn";
            this.idEtapaCalendarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEtapaCalendarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaInicioDataGridViewTextBoxColumn
            // 
            this.dFechaInicioDataGridViewTextBoxColumn.DataPropertyName = "dFechaInicio";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dFechaInicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dFechaInicioDataGridViewTextBoxColumn.FillWeight = 45F;
            this.dFechaInicioDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio";
            this.dFechaInicioDataGridViewTextBoxColumn.MinimumWidth = 59;
            this.dFechaInicioDataGridViewTextBoxColumn.Name = "dFechaInicioDataGridViewTextBoxColumn";
            this.dFechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dFechaFinDataGridViewTextBoxColumn
            // 
            this.dFechaFinDataGridViewTextBoxColumn.DataPropertyName = "dFechaFin";
            dataGridViewCellStyle2.Format = "d";
            this.dFechaFinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dFechaFinDataGridViewTextBoxColumn.FillWeight = 45F;
            this.dFechaFinDataGridViewTextBoxColumn.HeaderText = "Fecha Fin";
            this.dFechaFinDataGridViewTextBoxColumn.MinimumWidth = 59;
            this.dFechaFinDataGridViewTextBoxColumn.Name = "dFechaFinDataGridViewTextBoxColumn";
            this.dFechaFinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cObservacionesDataGridViewTextBoxColumn
            // 
            this.cObservacionesDataGridViewTextBoxColumn.DataPropertyName = "cObservaciones";
            this.cObservacionesDataGridViewTextBoxColumn.FillWeight = 59.25434F;
            this.cObservacionesDataGridViewTextBoxColumn.HeaderText = "Observación";
            this.cObservacionesDataGridViewTextBoxColumn.Name = "cObservacionesDataGridViewTextBoxColumn";
            this.cObservacionesDataGridViewTextBoxColumn.ReadOnly = true;
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
            // txtObservacion
            // 
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(300, 80);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(308, 106);
            this.txtObservacion.TabIndex = 18;
            this.txtObservacion.Leave += new System.EventHandler(this.txtObservacion_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(297, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 19;
            this.lblBase1.Text = "Observación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(297, 32);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 20;
            this.lblBase2.Text = "Desde:";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Enabled = false;
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(351, 30);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(112, 20);
            this.dtpFechaIni.TabIndex = 16;
            this.dtpFechaIni.Leave += new System.EventHandler(this.dtpFechaIni_Leave);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(469, 34);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(23, 13);
            this.lblBase3.TabIndex = 21;
            this.lblBase3.Text = "Al:";
            // 
            // dtpdFechaFin
            // 
            this.dtpdFechaFin.Enabled = false;
            this.dtpdFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdFechaFin.Location = new System.Drawing.Point(498, 30);
            this.dtpdFechaFin.Name = "dtpdFechaFin";
            this.dtpdFechaFin.Size = new System.Drawing.Size(110, 20);
            this.dtpdFechaFin.TabIndex = 17;
            this.dtpdFechaFin.Leave += new System.EventHandler(this.dtpdFechaFin_Leave);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(548, 226);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 22;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click_1);
            // 
            // btnQuitar2
            // 
            this.btnQuitar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar2.BackgroundImage")));
            this.btnQuitar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar2.Enabled = false;
            this.btnQuitar2.Location = new System.Drawing.Point(548, 282);
            this.btnQuitar2.Name = "btnQuitar2";
            this.btnQuitar2.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar2.TabIndex = 23;
            this.btnQuitar2.Text = "&Quitar";
            this.btnQuitar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar2.UseVisualStyleBackColor = true;
            this.btnQuitar2.Click += new System.EventHandler(this.btnQuitar2_Click);
            // 
            // chcUtilizaPlantilla
            // 
            this.chcUtilizaPlantilla.AutoSize = true;
            this.chcUtilizaPlantilla.Enabled = false;
            this.chcUtilizaPlantilla.Location = new System.Drawing.Point(16, 200);
            this.chcUtilizaPlantilla.Name = "chcUtilizaPlantilla";
            this.chcUtilizaPlantilla.Size = new System.Drawing.Size(96, 17);
            this.chcUtilizaPlantilla.TabIndex = 25;
            this.chcUtilizaPlantilla.Text = "Utilizar Plantilla";
            this.chcUtilizaPlantilla.UseVisualStyleBackColor = true;
            this.chcUtilizaPlantilla.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(359, 390);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 26;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(422, 390);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 27;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(485, 390);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 28;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmGenCalendarioPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 465);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.chcUtilizaPlantilla);
            this.Controls.Add(this.btnQuitar2);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpdFechaFin);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmGenCalendarioPro";
            this.Text = "Generar Calendario del Proceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenCalendarioPro_FormClosing);
            this.Load += new System.EventHandler(this.frmGenCalendarioPro_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtpdFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar2, 0);
            this.Controls.SetChildIndex(this.chcUtilizaPlantilla, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clsCalendarioAdjudicacionBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEtapaProceso)).EndInit();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.BindingSource clsCalendarioAdjudicacionBindingSource;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgCalendario;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpdFechaFin;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar2;
        private GEN.ControlesBase.dtgBase dtgEtapaProceso;
        private GEN.ControlesBase.chcBase chcUtilizaPlantilla;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCalendarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEtapaCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEtapaCalendarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lIndPlantillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
    }
}