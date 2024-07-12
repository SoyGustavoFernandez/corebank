namespace DEP.Presentacion
{
    partial class frmMantenimientoPersonasExcluidasFSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPersonasExcluidasFSD));
            this.conBusCliExcluido = new GEN.ControlesBase.ConBusCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.cboMotivoExclusion = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgExcluido = new GEN.ControlesBase.dtgBase(this.components);
            this.idCliExclDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExcluidoFSDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idExcluidoFSDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsClienteExcluidoFSD = new System.Windows.Forms.BindingSource(this.components);
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcluido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClienteExcluidoFSD)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCliExcluido
            // 
            this.conBusCliExcluido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliExcluido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliExcluido.idCli = 0;
            this.conBusCliExcluido.Location = new System.Drawing.Point(6, 19);
            this.conBusCliExcluido.Name = "conBusCliExcluido";
            this.conBusCliExcluido.Size = new System.Drawing.Size(532, 105);
            this.conBusCliExcluido.TabIndex = 2;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnEliminar1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFechaHasta);
            this.grbBase1.Controls.Add(this.dtpFechaInicio);
            this.grbBase1.Controls.Add(this.btnNuevo1);
            this.grbBase1.Controls.Add(this.cboMotivoExclusion);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnCancelar1);
            this.grbBase1.Controls.Add(this.btnEditar1);
            this.grbBase1.Controls.Add(this.conBusCliExcluido);
            this.grbBase1.Controls.Add(this.btnGrabar1);
            this.grbBase1.Controls.Add(this.btnSalir1);
            this.grbBase1.Location = new System.Drawing.Point(12, 168);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(562, 255);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Mantenimiento";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(350, 176);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(89, 13);
            this.lblBase3.TabIndex = 45;
            this.lblBase3.Text = "Fecha Hasta : ";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 176);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(93, 13);
            this.lblBase2.TabIndex = 44;
            this.lblBase2.Text = "Fecha Desde : ";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(452, 170);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaHasta.TabIndex = 43;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(117, 170);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaInicio.TabIndex = 42;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(232, 199);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 41;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // cboMotivoExclusion
            // 
            this.cboMotivoExclusion.FormattingEnabled = true;
            this.cboMotivoExclusion.Location = new System.Drawing.Point(157, 139);
            this.cboMotivoExclusion.Name = "cboMotivoExclusion";
            this.cboMotivoExclusion.Size = new System.Drawing.Size(388, 21);
            this.cboMotivoExclusion.TabIndex = 40;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 139);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(132, 13);
            this.lblBase1.TabIndex = 39;
            this.lblBase1.Text = "Motivo de Exclusión : ";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(430, 199);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 38;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(298, 199);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 37;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(364, 199);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 36;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(496, 199);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 35;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgExcluido
            // 
            this.dtgExcluido.AllowUserToAddRows = false;
            this.dtgExcluido.AllowUserToDeleteRows = false;
            this.dtgExcluido.AllowUserToResizeColumns = false;
            this.dtgExcluido.AllowUserToResizeRows = false;
            this.dtgExcluido.AutoGenerateColumns = false;
            this.dtgExcluido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExcluido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliExclDataGridViewTextBoxColumn,
            this.idCliDataGridViewTextBoxColumn,
            this.cDocumentoIDDataGridViewTextBoxColumn,
            this.cNombreDataGridViewTextBoxColumn,
            this.cExcluidoFSDDataGridViewTextBoxColumn,
            this.dFechaInicioDataGridViewTextBoxColumn,
            this.dFechaFinalDataGridViewTextBoxColumn,
            this.idExcluidoFSDDataGridViewTextBoxColumn,
            this.idTipoPersonaDataGridViewTextBoxColumn});
            this.dtgExcluido.DataSource = this.bsClienteExcluidoFSD;
            this.dtgExcluido.Location = new System.Drawing.Point(12, 12);
            this.dtgExcluido.MultiSelect = false;
            this.dtgExcluido.Name = "dtgExcluido";
            this.dtgExcluido.ReadOnly = true;
            this.dtgExcluido.RowHeadersVisible = false;
            this.dtgExcluido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcluido.Size = new System.Drawing.Size(562, 150);
            this.dtgExcluido.TabIndex = 4;
            // 
            // idCliExclDataGridViewTextBoxColumn
            // 
            this.idCliExclDataGridViewTextBoxColumn.DataPropertyName = "idCliExcl";
            this.idCliExclDataGridViewTextBoxColumn.HeaderText = "idCliExcl";
            this.idCliExclDataGridViewTextBoxColumn.Name = "idCliExclDataGridViewTextBoxColumn";
            this.idCliExclDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCliExclDataGridViewTextBoxColumn.Visible = false;
            // 
            // idCliDataGridViewTextBoxColumn
            // 
            this.idCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idCliDataGridViewTextBoxColumn.DataPropertyName = "idCli";
            this.idCliDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idCliDataGridViewTextBoxColumn.Name = "idCliDataGridViewTextBoxColumn";
            this.idCliDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCliDataGridViewTextBoxColumn.Width = 65;
            // 
            // cDocumentoIDDataGridViewTextBoxColumn
            // 
            this.cDocumentoIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDocumentoIDDataGridViewTextBoxColumn.DataPropertyName = "cDocumentoID";
            this.cDocumentoIDDataGridViewTextBoxColumn.HeaderText = "Documento ID";
            this.cDocumentoIDDataGridViewTextBoxColumn.Name = "cDocumentoIDDataGridViewTextBoxColumn";
            this.cDocumentoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDocumentoIDDataGridViewTextBoxColumn.Width = 101;
            // 
            // cNombreDataGridViewTextBoxColumn
            // 
            this.cNombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cNombreDataGridViewTextBoxColumn.DataPropertyName = "cNombre";
            this.cNombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.cNombreDataGridViewTextBoxColumn.Name = "cNombreDataGridViewTextBoxColumn";
            this.cNombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.cNombreDataGridViewTextBoxColumn.Width = 69;
            // 
            // cExcluidoFSDDataGridViewTextBoxColumn
            // 
            this.cExcluidoFSDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cExcluidoFSDDataGridViewTextBoxColumn.DataPropertyName = "cExcluidoFSD";
            this.cExcluidoFSDDataGridViewTextBoxColumn.HeaderText = "Motivo Excluido FSD";
            this.cExcluidoFSDDataGridViewTextBoxColumn.Name = "cExcluidoFSDDataGridViewTextBoxColumn";
            this.cExcluidoFSDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cExcluidoFSDDataGridViewTextBoxColumn.Width = 131;
            // 
            // dFechaInicioDataGridViewTextBoxColumn
            // 
            this.dFechaInicioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dFechaInicioDataGridViewTextBoxColumn.DataPropertyName = "dFechaInicio";
            this.dFechaInicioDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio";
            this.dFechaInicioDataGridViewTextBoxColumn.Name = "dFechaInicioDataGridViewTextBoxColumn";
            this.dFechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaInicioDataGridViewTextBoxColumn.Width = 90;
            // 
            // dFechaFinalDataGridViewTextBoxColumn
            // 
            this.dFechaFinalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dFechaFinalDataGridViewTextBoxColumn.DataPropertyName = "dFechaFinal";
            this.dFechaFinalDataGridViewTextBoxColumn.HeaderText = "Fecha hasta";
            this.dFechaFinalDataGridViewTextBoxColumn.Name = "dFechaFinalDataGridViewTextBoxColumn";
            this.dFechaFinalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaFinalDataGridViewTextBoxColumn.Width = 91;
            // 
            // idExcluidoFSDDataGridViewTextBoxColumn
            // 
            this.idExcluidoFSDDataGridViewTextBoxColumn.DataPropertyName = "idExcluidoFSD";
            this.idExcluidoFSDDataGridViewTextBoxColumn.HeaderText = "idExcluidoFSD";
            this.idExcluidoFSDDataGridViewTextBoxColumn.Name = "idExcluidoFSDDataGridViewTextBoxColumn";
            this.idExcluidoFSDDataGridViewTextBoxColumn.ReadOnly = true;
            this.idExcluidoFSDDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipoPersonaDataGridViewTextBoxColumn
            // 
            this.idTipoPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idTipoPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdTipoPersona";
            this.idTipoPersonaDataGridViewTextBoxColumn.HeaderText = "IdTipoPersona";
            this.idTipoPersonaDataGridViewTextBoxColumn.Name = "idTipoPersonaDataGridViewTextBoxColumn";
            this.idTipoPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoPersonaDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsClienteExcluidoFSD
            // 
            this.bsClienteExcluidoFSD.DataSource = typeof(EntityLayer.clsClienteExcluidoFSD);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(166, 199);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 46;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // frmMantenimientoPersonasExcluidasFSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 451);
            this.Controls.Add(this.dtgExcluido);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoPersonasExcluidasFSD";
            this.Text = "Mantenimiento de Personas Excluidas del FSD";
            this.Load += new System.EventHandler(this.frmMantenimientoPersonasExcluidasFSD_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgExcluido, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcluido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClienteExcluidoFSD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCliExcluido;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.cboBase cboMotivoExclusion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaHasta;
        private GEN.ControlesBase.dtgBase dtgExcluido;
        private System.Windows.Forms.BindingSource bsClienteExcluidoFSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliExclDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExcluidoFSDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExcluidoFSDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPersonaDataGridViewTextBoxColumn;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
    }
}