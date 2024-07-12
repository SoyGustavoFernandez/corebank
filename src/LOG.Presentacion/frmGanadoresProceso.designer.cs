namespace LOG.Presentacion
{
    partial class frmGanadoresProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGanadoresProceso));
            this.grbGrupos = new GEN.ControlesBase.grbBase(this.components);
            this.grbProveedores = new GEN.ControlesBase.grbBase(this.components);
            this.dtgGrupos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgProveedores = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVinculoProveedorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroDocumentoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProveedorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPuntajeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lGanadorTempColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grbGrupos.SuspendLayout();
            this.grbProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // grbGrupos
            // 
            this.grbGrupos.Controls.Add(this.dtgGrupos);
            this.grbGrupos.Location = new System.Drawing.Point(12, 12);
            this.grbGrupos.Name = "grbGrupos";
            this.grbGrupos.Size = new System.Drawing.Size(539, 158);
            this.grbGrupos.TabIndex = 2;
            this.grbGrupos.TabStop = false;
            this.grbGrupos.Text = "Grupos";
            // 
            // grbProveedores
            // 
            this.grbProveedores.Controls.Add(this.dtgProveedores);
            this.grbProveedores.Location = new System.Drawing.Point(12, 176);
            this.grbProveedores.Name = "grbProveedores";
            this.grbProveedores.Size = new System.Drawing.Size(539, 158);
            this.grbProveedores.TabIndex = 3;
            this.grbProveedores.TabStop = false;
            this.grbProveedores.Text = "Proveedores";
            // 
            // dtgGrupos
            // 
            this.dtgGrupos.AllowUserToAddRows = false;
            this.dtgGrupos.AllowUserToDeleteRows = false;
            this.dtgGrupos.AllowUserToResizeColumns = false;
            this.dtgGrupos.AllowUserToResizeRows = false;
            this.dtgGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Descripcion});
            this.dtgGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGrupos.Location = new System.Drawing.Point(3, 16);
            this.dtgGrupos.MultiSelect = false;
            this.dtgGrupos.Name = "dtgGrupos";
            this.dtgGrupos.ReadOnly = true;
            this.dtgGrupos.RowHeadersVisible = false;
            this.dtgGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupos.Size = new System.Drawing.Size(533, 139);
            this.dtgGrupos.TabIndex = 0;
            // 
            // dtgProveedores
            // 
            this.dtgProveedores.AllowUserToAddRows = false;
            this.dtgProveedores.AllowUserToDeleteRows = false;
            this.dtgProveedores.AllowUserToResizeColumns = false;
            this.dtgProveedores.AllowUserToResizeRows = false;
            this.dtgProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idVinculoProveedorColumn,
            this.idProveedorColumn,
            this.cNroDocumentoColumn,
            this.cProveedorColumn,
            this.nPuntajeColumn,
            this.lGanadorTempColumn});
            this.dtgProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgProveedores.Location = new System.Drawing.Point(3, 16);
            this.dtgProveedores.MultiSelect = false;
            this.dtgProveedores.Name = "dtgProveedores";
            this.dtgProveedores.ReadOnly = true;
            this.dtgProveedores.RowHeadersVisible = false;
            this.dtgProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProveedores.Size = new System.Drawing.Size(533, 139);
            this.dtgProveedores.TabIndex = 0;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(428, 337);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(491, 337);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // Grupo
            // 
            this.Grupo.FillWeight = 20F;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.FillWeight = 80F;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // idVinculoProveedorColumn
            // 
            this.idVinculoProveedorColumn.DataPropertyName = "idVinculoProveedor";
            this.idVinculoProveedorColumn.HeaderText = "idVinculoProveedor";
            this.idVinculoProveedorColumn.Name = "idVinculoProveedorColumn";
            this.idVinculoProveedorColumn.ReadOnly = true;
            this.idVinculoProveedorColumn.Visible = false;
            // 
            // idProveedorColumn
            // 
            this.idProveedorColumn.DataPropertyName = "idProveedor";
            this.idProveedorColumn.FillWeight = 15F;
            this.idProveedorColumn.HeaderText = "Código";
            this.idProveedorColumn.Name = "idProveedorColumn";
            this.idProveedorColumn.ReadOnly = true;
            // 
            // cNroDocumentoColumn
            // 
            this.cNroDocumentoColumn.DataPropertyName = "cNroDocumento";
            this.cNroDocumentoColumn.FillWeight = 20F;
            this.cNroDocumentoColumn.HeaderText = "Nro Documento";
            this.cNroDocumentoColumn.Name = "cNroDocumentoColumn";
            this.cNroDocumentoColumn.ReadOnly = true;
            // 
            // cProveedorColumn
            // 
            this.cProveedorColumn.DataPropertyName = "cProveedor";
            this.cProveedorColumn.FillWeight = 30F;
            this.cProveedorColumn.HeaderText = "Proveedor";
            this.cProveedorColumn.Name = "cProveedorColumn";
            this.cProveedorColumn.ReadOnly = true;
            // 
            // nPuntajeColumn
            // 
            this.nPuntajeColumn.DataPropertyName = "nPuntaje";
            this.nPuntajeColumn.FillWeight = 15F;
            this.nPuntajeColumn.HeaderText = "Puntaje";
            this.nPuntajeColumn.Name = "nPuntajeColumn";
            this.nPuntajeColumn.ReadOnly = true;
            // 
            // lGanadorTempColumn
            // 
            this.lGanadorTempColumn.DataPropertyName = "lGanadorTemp";
            this.lGanadorTempColumn.FillWeight = 15F;
            this.lGanadorTempColumn.HeaderText = "Ganador?";
            this.lGanadorTempColumn.Name = "lGanadorTempColumn";
            this.lGanadorTempColumn.ReadOnly = true;
            // 
            // frmGanadoresProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 414);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbProveedores);
            this.Controls.Add(this.grbGrupos);
            this.Name = "frmGanadoresProceso";
            this.Text = "Ganadores proceso de adquisición";
            this.Load += new System.EventHandler(this.frmGanadoresProceso_Load);
            this.Controls.SetChildIndex(this.grbGrupos, 0);
            this.Controls.SetChildIndex(this.grbProveedores, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbGrupos.ResumeLayout(false);
            this.grbProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbGrupos;
        private GEN.ControlesBase.dtgBase dtgGrupos;
        private GEN.ControlesBase.grbBase grbProveedores;
        private GEN.ControlesBase.dtgBase dtgProveedores;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroDocumentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProveedorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPuntajeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lGanadorTempColumn;
    }
}