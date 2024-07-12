namespace LOG.Presentacion
{
    partial class frmManTipoProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTipoProceso));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgTipoProceso = new GEN.ControlesBase.dtgBase(this.components);
            this.idTipoProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescCortaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsTipoProcesoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDesCorta = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombreProceso = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbDetTipoPro = new GEN.ControlesBase.grbBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoProcesoBindingSource)).BeginInit();
            this.grbDetTipoPro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgTipoProceso);
            this.grbBase1.Location = new System.Drawing.Point(12, 6);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(277, 191);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Tipo de Proceso";
            // 
            // dtgTipoProceso
            // 
            this.dtgTipoProceso.AllowUserToAddRows = false;
            this.dtgTipoProceso.AllowUserToDeleteRows = false;
            this.dtgTipoProceso.AllowUserToResizeColumns = false;
            this.dtgTipoProceso.AllowUserToResizeRows = false;
            this.dtgTipoProceso.AutoGenerateColumns = false;
            this.dtgTipoProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTipoProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoProcesoDataGridViewTextBoxColumn,
            this.cTipoProcesoDataGridViewTextBoxColumn,
            this.cDescCortaDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn});
            this.dtgTipoProceso.DataSource = this.clsTipoProcesoBindingSource;
            this.dtgTipoProceso.Location = new System.Drawing.Point(6, 15);
            this.dtgTipoProceso.MultiSelect = false;
            this.dtgTipoProceso.Name = "dtgTipoProceso";
            this.dtgTipoProceso.ReadOnly = true;
            this.dtgTipoProceso.RowHeadersVisible = false;
            this.dtgTipoProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoProceso.Size = new System.Drawing.Size(262, 170);
            this.dtgTipoProceso.TabIndex = 0;
            this.dtgTipoProceso.SelectionChanged += new System.EventHandler(this.dtgTipoProceso_SelectionChanged);
            // 
            // idTipoProcesoDataGridViewTextBoxColumn
            // 
            this.idTipoProcesoDataGridViewTextBoxColumn.DataPropertyName = "idTipoProceso";
            this.idTipoProcesoDataGridViewTextBoxColumn.HeaderText = "idTipoProceso";
            this.idTipoProcesoDataGridViewTextBoxColumn.Name = "idTipoProcesoDataGridViewTextBoxColumn";
            this.idTipoProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipoProcesoDataGridViewTextBoxColumn
            // 
            this.cTipoProcesoDataGridViewTextBoxColumn.DataPropertyName = "cTipoProceso";
            this.cTipoProcesoDataGridViewTextBoxColumn.FillWeight = 200F;
            this.cTipoProcesoDataGridViewTextBoxColumn.HeaderText = "Tipo de Proceso";
            this.cTipoProcesoDataGridViewTextBoxColumn.Name = "cTipoProcesoDataGridViewTextBoxColumn";
            this.cTipoProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDescCortaDataGridViewTextBoxColumn
            // 
            this.cDescCortaDataGridViewTextBoxColumn.DataPropertyName = "cDescCorta";
            this.cDescCortaDataGridViewTextBoxColumn.FillWeight = 77F;
            this.cDescCortaDataGridViewTextBoxColumn.HeaderText = "Desc. Corta";
            this.cDescCortaDataGridViewTextBoxColumn.Name = "cDescCortaDataGridViewTextBoxColumn";
            this.cDescCortaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDescCortaDataGridViewTextBoxColumn.Visible = false;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // clsTipoProcesoBindingSource
            // 
            this.clsTipoProcesoBindingSource.DataSource = typeof(EntityLayer.clsTipoProceso);
            // 
            // txtDesCorta
            // 
            this.txtDesCorta.Location = new System.Drawing.Point(134, 37);
            this.txtDesCorta.Name = "txtDesCorta";
            this.txtDesCorta.Size = new System.Drawing.Size(244, 20);
            this.txtDesCorta.TabIndex = 3;
            this.txtDesCorta.TextChanged += new System.EventHandler(this.txtDesCorta_TextChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(109, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Descripción Corta";
            // 
            // txtNombreProceso
            // 
            this.txtNombreProceso.Location = new System.Drawing.Point(134, 13);
            this.txtNombreProceso.Name = "txtNombreProceso";
            this.txtNombreProceso.Size = new System.Drawing.Size(244, 20);
            this.txtNombreProceso.TabIndex = 1;
            this.txtNombreProceso.TextChanged += new System.EventHandler(this.txtNombreProceso_TextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(122, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Nombre del Proceso";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(475, 141);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(355, 141);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(415, 141);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(612, 141);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(295, 141);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // grbDetTipoPro
            // 
            this.grbDetTipoPro.Controls.Add(this.chcVigente);
            this.grbDetTipoPro.Controls.Add(this.lblBase2);
            this.grbDetTipoPro.Controls.Add(this.txtNombreProceso);
            this.grbDetTipoPro.Controls.Add(this.lblBase1);
            this.grbDetTipoPro.Controls.Add(this.txtDesCorta);
            this.grbDetTipoPro.Location = new System.Drawing.Point(294, 7);
            this.grbDetTipoPro.Name = "grbDetTipoPro";
            this.grbDetTipoPro.Size = new System.Drawing.Size(384, 123);
            this.grbDetTipoPro.TabIndex = 1;
            this.grbDetTipoPro.TabStop = false;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Enabled = false;
            this.chcVigente.ForeColor = System.Drawing.Color.Navy;
            this.chcVigente.Location = new System.Drawing.Point(9, 83);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(79, 17);
            this.chcVigente.TabIndex = 4;
            this.chcVigente.Text = "No Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // frmManTipoProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 222);
            this.Controls.Add(this.grbDetTipoPro);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmManTipoProceso";
            this.Text = "Mantenimiento de Tipos de Proceso";
            this.Load += new System.EventHandler(this.frmMantenimientoTipoProceso_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.grbDetTipoPro, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoProcesoBindingSource)).EndInit();
            this.grbDetTipoPro.ResumeLayout(false);
            this.grbDetTipoPro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgTipoProceso;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtCBLetra txtDesCorta;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBLetra txtNombreProceso;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.BindingSource clsTipoProcesoBindingSource;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescCortaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private GEN.ControlesBase.grbBase grbDetTipoPro;
        private GEN.ControlesBase.chcBase chcVigente;
    }
}