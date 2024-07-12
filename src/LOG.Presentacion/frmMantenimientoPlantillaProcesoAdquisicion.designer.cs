namespace LOG.Presentacion
{
    partial class frmMantenimientoPlantillaProcesoAdquisicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPlantillaProcesoAdquisicion));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboFiltroEtapas = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboFiltroTipoProceso = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoProceso = new GEN.ControlesBase.cboBase(this.components);
            this.nudNumDias = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEtapas = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.chcDocObligatorio = new GEN.ControlesBase.chcBase(this.components);
            this.cboDocumentos = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgPlantillaProceso = new GEN.ControlesBase.dtgBase(this.components);
            this.idEtapaCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRelProcesoCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescCorta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocProAdqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDiasEtapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocProAdqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDocObligatorio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumDias)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaProceso)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboFiltroEtapas);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.cboFiltroTipoProceso);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(409, 74);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtrar Plantilla Proceso de Adquisición";
            // 
            // cboFiltroEtapas
            // 
            this.cboFiltroEtapas.FormattingEnabled = true;
            this.cboFiltroEtapas.Location = new System.Drawing.Point(97, 44);
            this.cboFiltroEtapas.Name = "cboFiltroEtapas";
            this.cboFiltroEtapas.Size = new System.Drawing.Size(303, 21);
            this.cboFiltroEtapas.TabIndex = 6;
            this.cboFiltroEtapas.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(47, 47);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(44, 13);
            this.lblBase6.TabIndex = 0;
            this.lblBase6.Text = "Etapa:";
            // 
            // cboFiltroTipoProceso
            // 
            this.cboFiltroTipoProceso.FormattingEnabled = true;
            this.cboFiltroTipoProceso.Location = new System.Drawing.Point(97, 17);
            this.cboFiltroTipoProceso.Name = "cboFiltroTipoProceso";
            this.cboFiltroTipoProceso.Size = new System.Drawing.Size(303, 21);
            this.cboFiltroTipoProceso.TabIndex = 6;
            this.cboFiltroTipoProceso.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 20);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(85, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Tipo Proceso:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(85, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo Proceso:";
            // 
            // cboTipoProceso
            // 
            this.cboTipoProceso.FormattingEnabled = true;
            this.cboTipoProceso.Location = new System.Drawing.Point(97, 13);
            this.cboTipoProceso.Name = "cboTipoProceso";
            this.cboTipoProceso.Size = new System.Drawing.Size(303, 21);
            this.cboTipoProceso.TabIndex = 0;
            // 
            // nudNumDias
            // 
            this.nudNumDias.Location = new System.Drawing.Point(97, 94);
            this.nudNumDias.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.nudNumDias.Name = "nudNumDias";
            this.nudNumDias.Size = new System.Drawing.Size(78, 20);
            this.nudNumDias.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 70);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(77, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Documento:";
            // 
            // cboEtapas
            // 
            this.cboEtapas.FormattingEnabled = true;
            this.cboEtapas.Location = new System.Drawing.Point(97, 40);
            this.cboEtapas.Name = "cboEtapas";
            this.cboEtapas.Size = new System.Drawing.Size(303, 21);
            this.cboEtapas.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(5, 97);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(86, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Número Días:";
            // 
            // chcDocObligatorio
            // 
            this.chcDocObligatorio.AutoSize = true;
            this.chcDocObligatorio.Location = new System.Drawing.Point(188, 97);
            this.chcDocObligatorio.Name = "chcDocObligatorio";
            this.chcDocObligatorio.Size = new System.Drawing.Size(134, 17);
            this.chcDocObligatorio.TabIndex = 4;
            this.chcDocObligatorio.Text = "Documento Obligatorio";
            this.chcDocObligatorio.UseVisualStyleBackColor = true;
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(97, 67);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(303, 21);
            this.cboDocumentos.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(41, 43);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Etapas:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcVigente);
            this.grbBase2.Controls.Add(this.nudNumDias);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboDocumentos);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.cboTipoProceso);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.chcDocObligatorio);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.cboEtapas);
            this.grbBase2.Location = new System.Drawing.Point(12, 88);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(409, 125);
            this.grbBase2.TabIndex = 5;
            this.grbBase2.TabStop = false;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(338, 97);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 5;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(52, 372);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(186, 372);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(253, 372);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(320, 372);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgPlantillaProceso
            // 
            this.dtgPlantillaProceso.AllowUserToAddRows = false;
            this.dtgPlantillaProceso.AllowUserToDeleteRows = false;
            this.dtgPlantillaProceso.AllowUserToResizeColumns = false;
            this.dtgPlantillaProceso.AllowUserToResizeRows = false;
            this.dtgPlantillaProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlantillaProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlantillaProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEtapaCalendario,
            this.idRelProcesoCalendario,
            this.idTipoProceso,
            this.cTipoProceso,
            this.cDescCorta,
            this.idTipoDocProAdqui,
            this.nDiasEtapa,
            this.cTipoDocProAdqui,
            this.lDocObligatorio,
            this.lVigente});
            this.dtgPlantillaProceso.Location = new System.Drawing.Point(12, 219);
            this.dtgPlantillaProceso.MultiSelect = false;
            this.dtgPlantillaProceso.Name = "dtgPlantillaProceso";
            this.dtgPlantillaProceso.ReadOnly = true;
            this.dtgPlantillaProceso.RowHeadersVisible = false;
            this.dtgPlantillaProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlantillaProceso.Size = new System.Drawing.Size(408, 150);
            this.dtgPlantillaProceso.TabIndex = 10;
            // 
            // idEtapaCalendario
            // 
            this.idEtapaCalendario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idEtapaCalendario.DataPropertyName = "idEtapaCalendario";
            this.idEtapaCalendario.FillWeight = 63.45178F;
            this.idEtapaCalendario.HeaderText = "Etapa";
            this.idEtapaCalendario.MinimumWidth = 2;
            this.idEtapaCalendario.Name = "idEtapaCalendario";
            this.idEtapaCalendario.ReadOnly = true;
            this.idEtapaCalendario.Width = 40;
            // 
            // idRelProcesoCalendario
            // 
            this.idRelProcesoCalendario.DataPropertyName = "idRelProcesoCalendario";
            this.idRelProcesoCalendario.HeaderText = "idRelProcesoCalendario";
            this.idRelProcesoCalendario.Name = "idRelProcesoCalendario";
            this.idRelProcesoCalendario.ReadOnly = true;
            this.idRelProcesoCalendario.Visible = false;
            // 
            // idTipoProceso
            // 
            this.idTipoProceso.DataPropertyName = "idTipoProceso";
            this.idTipoProceso.HeaderText = "idTipoProceso";
            this.idTipoProceso.Name = "idTipoProceso";
            this.idTipoProceso.ReadOnly = true;
            this.idTipoProceso.Visible = false;
            // 
            // cTipoProceso
            // 
            this.cTipoProceso.DataPropertyName = "cTipoProceso";
            this.cTipoProceso.HeaderText = "cTipoProceso";
            this.cTipoProceso.Name = "cTipoProceso";
            this.cTipoProceso.ReadOnly = true;
            this.cTipoProceso.Visible = false;
            // 
            // cDescCorta
            // 
            this.cDescCorta.DataPropertyName = "cDescCorta";
            this.cDescCorta.HeaderText = "cDescCorta";
            this.cDescCorta.Name = "cDescCorta";
            this.cDescCorta.ReadOnly = true;
            this.cDescCorta.Visible = false;
            // 
            // idTipoDocProAdqui
            // 
            this.idTipoDocProAdqui.DataPropertyName = "idTipoDocProAdqui";
            this.idTipoDocProAdqui.HeaderText = "idTipoDocProAdqui";
            this.idTipoDocProAdqui.Name = "idTipoDocProAdqui";
            this.idTipoDocProAdqui.ReadOnly = true;
            this.idTipoDocProAdqui.Visible = false;
            // 
            // nDiasEtapa
            // 
            this.nDiasEtapa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nDiasEtapa.DataPropertyName = "nDiasEtapa";
            this.nDiasEtapa.FillWeight = 63.45177F;
            this.nDiasEtapa.HeaderText = "Días";
            this.nDiasEtapa.MinimumWidth = 2;
            this.nDiasEtapa.Name = "nDiasEtapa";
            this.nDiasEtapa.ReadOnly = true;
            this.nDiasEtapa.Width = 40;
            // 
            // cTipoDocProAdqui
            // 
            this.cTipoDocProAdqui.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cTipoDocProAdqui.DataPropertyName = "cTipoDocProAdqui";
            this.cTipoDocProAdqui.FillWeight = 246.1929F;
            this.cTipoDocProAdqui.HeaderText = "Documento";
            this.cTipoDocProAdqui.MinimumWidth = 7;
            this.cTipoDocProAdqui.Name = "cTipoDocProAdqui";
            this.cTipoDocProAdqui.ReadOnly = true;
            this.cTipoDocProAdqui.Width = 265;
            // 
            // lDocObligatorio
            // 
            this.lDocObligatorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lDocObligatorio.DataPropertyName = "lDocObligatorio";
            this.lDocObligatorio.FillWeight = 63.45177F;
            this.lDocObligatorio.HeaderText = "Obl";
            this.lDocObligatorio.MinimumWidth = 2;
            this.lDocObligatorio.Name = "lDocObligatorio";
            this.lDocObligatorio.ReadOnly = true;
            this.lDocObligatorio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lDocObligatorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lDocObligatorio.Width = 30;
            // 
            // lVigente
            // 
            this.lVigente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.FillWeight = 63.45177F;
            this.lVigente.HeaderText = "Vig";
            this.lVigente.MinimumWidth = 2;
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lVigente.Width = 30;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(119, 372);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmMantenimientoPlantillaProcesoAdquisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 447);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgPlantillaProceso);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoPlantillaProcesoAdquisicion";
            this.Text = "Mantenimiento Plantilla Proceso Adquisicion";
            this.Load += new System.EventHandler(this.frmMantenimientoPlantillaProcesoAdquisicion_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgPlantillaProceso, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumDias)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaProceso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboFiltroTipoProceso;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipoProceso;
        private GEN.ControlesBase.nudBase nudNumDias;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboEtapas;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.chcBase chcDocObligatorio;
        private GEN.ControlesBase.cboBase cboDocumentos;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgPlantillaProceso;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.cboBase cboFiltroEtapas;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEtapaCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRelProcesoCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescCorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocProAdqui;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDiasEtapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocProAdqui;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDocObligatorio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigente;
    }
}