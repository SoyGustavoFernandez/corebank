namespace GEN.ControlesBase
{
    partial class frmBuscarTipoArchivoConfiguracion
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
            this.dtgArchivoxGrupo = new System.Windows.Forms.DataGridView();
            this.clsTipoArchivoEscaneadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivoxGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoArchivoEscaneadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgArchivoxGrupo
            // 
            this.dtgArchivoxGrupo.AllowUserToAddRows = false;
            this.dtgArchivoxGrupo.AllowUserToDeleteRows = false;
            this.dtgArchivoxGrupo.AllowUserToResizeColumns = false;
            this.dtgArchivoxGrupo.AllowUserToResizeRows = false;
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
            this.dtgArchivoxGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgArchivoxGrupo.Location = new System.Drawing.Point(0, 0);
            this.dtgArchivoxGrupo.MultiSelect = false;
            this.dtgArchivoxGrupo.Name = "dtgArchivoxGrupo";
            this.dtgArchivoxGrupo.ReadOnly = true;
            this.dtgArchivoxGrupo.RowHeadersVisible = false;
            this.dtgArchivoxGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgArchivoxGrupo.Size = new System.Drawing.Size(542, 532);
            this.dtgArchivoxGrupo.TabIndex = 2;
            this.dtgArchivoxGrupo.TabStop = false;
            this.dtgArchivoxGrupo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivoxGrupo_CellContentClick);
            this.dtgArchivoxGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivoxGrupo_CellDoubleClick);
            // 
            // clsTipoArchivoEscaneadoBindingSource
            // 
            this.clsTipoArchivoEscaneadoBindingSource.DataSource = typeof(EntityLayer.clsTipoArchivoEscaneado);
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
            this.nOrdenDataGridViewTextBoxColumn.HeaderText = "nOrden";
            this.nOrdenDataGridViewTextBoxColumn.Name = "nOrdenDataGridViewTextBoxColumn";
            this.nOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOrdenDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipoArchivoDataGridViewTextBoxColumn
            // 
            this.cTipoArchivoDataGridViewTextBoxColumn.DataPropertyName = "cTipoArchivo";
            this.cTipoArchivoDataGridViewTextBoxColumn.HeaderText = "Tipo Archivo";
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
            this.dFechaVigenciaDataGridViewTextBoxColumn.HeaderText = "dFechaVigencia";
            this.dFechaVigenciaDataGridViewTextBoxColumn.Name = "dFechaVigenciaDataGridViewTextBoxColumn";
            this.dFechaVigenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaVigenciaDataGridViewTextBoxColumn.Visible = false;
            // 
            // lConFechaVigenciaDataGridViewCheckBoxColumn
            // 
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.DataPropertyName = "lConFechaVigencia";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.HeaderText = "lConFechaVigencia";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.Name = "lConFechaVigenciaDataGridViewCheckBoxColumn";
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lConFechaVigenciaDataGridViewCheckBoxColumn.Visible = false;
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
            // frmBuscarTipoArchivoConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 554);
            this.Controls.Add(this.dtgArchivoxGrupo);
            this.Name = "frmBuscarTipoArchivoConfiguracion";
            this.Text = "Buscar tipo archivo configuración";
            this.Controls.SetChildIndex(this.dtgArchivoxGrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivoxGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoArchivoEscaneadoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgArchivoxGrupo;
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
        private System.Windows.Forms.BindingSource clsTipoArchivoEscaneadoBindingSource;
    }
}