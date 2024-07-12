namespace LOG.Presentacion
{
    partial class frmEvaReqMinimo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaReqMinimo));
            this.lblNombreEmpres = new System.Windows.Forms.Label();
            this.dtgDetProAdj = new GEN.ControlesBase.dtgBase(this.components);
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nsubTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsDetalleProcesoAdjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtgEvaREqMin = new GEN.ControlesBase.dtgBase(this.components);
            this.idProcesoAdjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nItemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoReqMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoReqMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSustentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIndica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsEvaRequisitosMinimosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetProAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaREqMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaRequisitosMinimosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreEmpres
            // 
            this.lblNombreEmpres.BackColor = System.Drawing.Color.White;
            this.lblNombreEmpres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpres.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreEmpres.Location = new System.Drawing.Point(12, 9);
            this.lblNombreEmpres.Name = "lblNombreEmpres";
            this.lblNombreEmpres.Size = new System.Drawing.Size(720, 42);
            this.lblNombreEmpres.TabIndex = 2;
            this.lblNombreEmpres.Text = "NOMBRE DE EMPRESA";
            this.lblNombreEmpres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgDetProAdj
            // 
            this.dtgDetProAdj.AllowUserToAddRows = false;
            this.dtgDetProAdj.AllowUserToDeleteRows = false;
            this.dtgDetProAdj.AllowUserToResizeColumns = false;
            this.dtgDetProAdj.AllowUserToResizeRows = false;
            this.dtgDetProAdj.AutoGenerateColumns = false;
            this.dtgDetProAdj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetProAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetProAdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProcesoDataGridViewTextBoxColumn,
            this.nItemDataGridViewTextBoxColumn,
            this.idCatalogoDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.idUnidad,
            this.cUnidad,
            this.nCantidadDataGridViewTextBoxColumn,
            this.nPrecioUnitDataGridViewTextBoxColumn,
            this.idGrupoDataGridViewTextBoxColumn,
            this.cDesGrupoDataGridViewTextBoxColumn,
            this.nsubTotalDataGridViewTextBoxColumn});
            this.dtgDetProAdj.DataSource = this.clsDetalleProcesoAdjBindingSource;
            this.dtgDetProAdj.Location = new System.Drawing.Point(12, 54);
            this.dtgDetProAdj.MultiSelect = false;
            this.dtgDetProAdj.Name = "dtgDetProAdj";
            this.dtgDetProAdj.ReadOnly = true;
            this.dtgDetProAdj.RowHeadersVisible = false;
            this.dtgDetProAdj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetProAdj.Size = new System.Drawing.Size(359, 125);
            this.dtgDetProAdj.TabIndex = 3;
            this.dtgDetProAdj.SelectionChanged += new System.EventHandler(this.dtgDetProAdj_SelectionChanged);
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nItemDataGridViewTextBoxColumn
            // 
            this.nItemDataGridViewTextBoxColumn.DataPropertyName = "nItem";
            this.nItemDataGridViewTextBoxColumn.FillWeight = 21.79531F;
            this.nItemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.nItemDataGridViewTextBoxColumn.Name = "nItemDataGridViewTextBoxColumn";
            this.nItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCatalogoDataGridViewTextBoxColumn
            // 
            this.idCatalogoDataGridViewTextBoxColumn.DataPropertyName = "idCatalogo";
            this.idCatalogoDataGridViewTextBoxColumn.HeaderText = "idCatalogo";
            this.idCatalogoDataGridViewTextBoxColumn.Name = "idCatalogoDataGridViewTextBoxColumn";
            this.idCatalogoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCatalogoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.FillWeight = 62.27232F;
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Artículo";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUnidad
            // 
            this.idUnidad.DataPropertyName = "idUnidad";
            this.idUnidad.HeaderText = "idUnidad";
            this.idUnidad.Name = "idUnidad";
            this.idUnidad.ReadOnly = true;
            this.idUnidad.Visible = false;
            // 
            // cUnidad
            // 
            this.cUnidad.DataPropertyName = "cUnidad";
            this.cUnidad.FillWeight = 21.79531F;
            this.cUnidad.HeaderText = "Unidad";
            this.cUnidad.Name = "cUnidad";
            this.cUnidad.ReadOnly = true;
            // 
            // nCantidadDataGridViewTextBoxColumn
            // 
            this.nCantidadDataGridViewTextBoxColumn.DataPropertyName = "nCantidad";
            dataGridViewCellStyle1.Format = "N2";
            this.nCantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nCantidadDataGridViewTextBoxColumn.FillWeight = 45F;
            this.nCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.nCantidadDataGridViewTextBoxColumn.Name = "nCantidadDataGridViewTextBoxColumn";
            this.nCantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPrecioUnitDataGridViewTextBoxColumn
            // 
            this.nPrecioUnitDataGridViewTextBoxColumn.DataPropertyName = "nPrecioUnit";
            this.nPrecioUnitDataGridViewTextBoxColumn.HeaderText = "nPrecioUnit";
            this.nPrecioUnitDataGridViewTextBoxColumn.Name = "nPrecioUnitDataGridViewTextBoxColumn";
            this.nPrecioUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.nPrecioUnitDataGridViewTextBoxColumn.Visible = false;
            // 
            // idGrupoDataGridViewTextBoxColumn
            // 
            this.idGrupoDataGridViewTextBoxColumn.DataPropertyName = "idGrupo";
            this.idGrupoDataGridViewTextBoxColumn.HeaderText = "idGrupo";
            this.idGrupoDataGridViewTextBoxColumn.Name = "idGrupoDataGridViewTextBoxColumn";
            this.idGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idGrupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cDesGrupoDataGridViewTextBoxColumn
            // 
            this.cDesGrupoDataGridViewTextBoxColumn.DataPropertyName = "cDesGrupo";
            this.cDesGrupoDataGridViewTextBoxColumn.HeaderText = "cDesGrupo";
            this.cDesGrupoDataGridViewTextBoxColumn.Name = "cDesGrupoDataGridViewTextBoxColumn";
            this.cDesGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDesGrupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nsubTotalDataGridViewTextBoxColumn
            // 
            this.nsubTotalDataGridViewTextBoxColumn.DataPropertyName = "nsubTotal";
            this.nsubTotalDataGridViewTextBoxColumn.HeaderText = "nsubTotal";
            this.nsubTotalDataGridViewTextBoxColumn.Name = "nsubTotalDataGridViewTextBoxColumn";
            this.nsubTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.nsubTotalDataGridViewTextBoxColumn.Visible = false;
            // 
            // clsDetalleProcesoAdjBindingSource
            // 
            this.clsDetalleProcesoAdjBindingSource.DataSource = typeof(EntityLayer.clsDetalleProcesoAdj);
            // 
            // dtgEvaREqMin
            // 
            this.dtgEvaREqMin.AllowUserToAddRows = false;
            this.dtgEvaREqMin.AllowUserToDeleteRows = false;
            this.dtgEvaREqMin.AllowUserToResizeColumns = false;
            this.dtgEvaREqMin.AllowUserToResizeRows = false;
            this.dtgEvaREqMin.AutoGenerateColumns = false;
            this.dtgEvaREqMin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvaREqMin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaREqMin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProcesoAdjDataGridViewTextBoxColumn,
            this.nItemDataGridViewTextBoxColumn1,
            this.idTipoReqMinimoDataGridViewTextBoxColumn,
            this.cTipoReqMinimoDataGridViewTextBoxColumn,
            this.cSustentoDataGridViewTextBoxColumn,
            this.lIndica});
            this.dtgEvaREqMin.DataSource = this.clsEvaRequisitosMinimosBindingSource;
            this.dtgEvaREqMin.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgEvaREqMin.Location = new System.Drawing.Point(377, 54);
            this.dtgEvaREqMin.MultiSelect = false;
            this.dtgEvaREqMin.Name = "dtgEvaREqMin";
            this.dtgEvaREqMin.ReadOnly = true;
            this.dtgEvaREqMin.RowHeadersVisible = false;
            this.dtgEvaREqMin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaREqMin.Size = new System.Drawing.Size(355, 125);
            this.dtgEvaREqMin.TabIndex = 4;
            this.dtgEvaREqMin.SelectionChanged += new System.EventHandler(this.dtgEvaREqMin_SelectionChanged);
            // 
            // idProcesoAdjDataGridViewTextBoxColumn
            // 
            this.idProcesoAdjDataGridViewTextBoxColumn.DataPropertyName = "idProcesoAdj";
            this.idProcesoAdjDataGridViewTextBoxColumn.HeaderText = "idProcesoAdj";
            this.idProcesoAdjDataGridViewTextBoxColumn.Name = "idProcesoAdjDataGridViewTextBoxColumn";
            this.idProcesoAdjDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoAdjDataGridViewTextBoxColumn.Visible = false;
            // 
            // nItemDataGridViewTextBoxColumn1
            // 
            this.nItemDataGridViewTextBoxColumn1.DataPropertyName = "nItem";
            this.nItemDataGridViewTextBoxColumn1.HeaderText = "nItem";
            this.nItemDataGridViewTextBoxColumn1.Name = "nItemDataGridViewTextBoxColumn1";
            this.nItemDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nItemDataGridViewTextBoxColumn1.Visible = false;
            // 
            // idTipoReqMinimoDataGridViewTextBoxColumn
            // 
            this.idTipoReqMinimoDataGridViewTextBoxColumn.DataPropertyName = "idTipoReqMinimo";
            this.idTipoReqMinimoDataGridViewTextBoxColumn.HeaderText = "idTipoReqMinimo";
            this.idTipoReqMinimoDataGridViewTextBoxColumn.Name = "idTipoReqMinimoDataGridViewTextBoxColumn";
            this.idTipoReqMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoReqMinimoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipoReqMinimoDataGridViewTextBoxColumn
            // 
            this.cTipoReqMinimoDataGridViewTextBoxColumn.DataPropertyName = "cTipoReqMinimo";
            this.cTipoReqMinimoDataGridViewTextBoxColumn.FillWeight = 164.467F;
            this.cTipoReqMinimoDataGridViewTextBoxColumn.HeaderText = "Tipo de Requerimiento Mínimo";
            this.cTipoReqMinimoDataGridViewTextBoxColumn.Name = "cTipoReqMinimoDataGridViewTextBoxColumn";
            this.cTipoReqMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cSustentoDataGridViewTextBoxColumn
            // 
            this.cSustentoDataGridViewTextBoxColumn.DataPropertyName = "cSustento";
            this.cSustentoDataGridViewTextBoxColumn.HeaderText = "cSustento";
            this.cSustentoDataGridViewTextBoxColumn.Name = "cSustentoDataGridViewTextBoxColumn";
            this.cSustentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cSustentoDataGridViewTextBoxColumn.Visible = false;
            // 
            // lIndica
            // 
            this.lIndica.DataPropertyName = "lIndica";
            this.lIndica.FillWeight = 35.53299F;
            this.lIndica.HeaderText = "Cumple?";
            this.lIndica.Name = "lIndica";
            this.lIndica.ReadOnly = true;
            // 
            // clsEvaRequisitosMinimosBindingSource
            // 
            this.clsEvaRequisitosMinimosBindingSource.DataSource = typeof(EntityLayer.clsEvaRequisitosMinimos);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(609, 328);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 23;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(672, 328);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 22;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(12, 185);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(720, 137);
            this.txtSustento.TabIndex = 26;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(546, 328);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 27;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(483, 328);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 28;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // frmEvaReqMinimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 409);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgEvaREqMin);
            this.Controls.Add(this.dtgDetProAdj);
            this.Controls.Add(this.lblNombreEmpres);
            this.Name = "frmEvaReqMinimo";
            this.Text = "Evaluación de Requisitos Mínimos";
            this.Load += new System.EventHandler(this.frmEvaReqMinimo_Load);
            this.Controls.SetChildIndex(this.lblNombreEmpres, 0);
            this.Controls.SetChildIndex(this.dtgDetProAdj, 0);
            this.Controls.SetChildIndex(this.dtgEvaREqMin, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetProAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaREqMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaRequisitosMinimosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreEmpres;
        private GEN.ControlesBase.dtgBase dtgDetProAdj;
        private System.Windows.Forms.BindingSource clsDetalleProcesoAdjBindingSource;
        private GEN.ControlesBase.dtgBase dtgEvaREqMin;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtSustento;
        private System.Windows.Forms.BindingSource clsEvaRequisitosMinimosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuregDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaRegDataGridViewTextBoxColumn;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoAdjDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoReqMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoReqMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSustentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lIndica;
    }
}