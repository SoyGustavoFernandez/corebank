namespace LOG.Presentacion
{
    partial class frmEvaluacionEconomica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluacionEconomica));
            this.clsVinculoProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtProveedor = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroDoc = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtSubTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgDetalleNP = new GEN.ControlesBase.dtgBase(this.components);
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalleNotapedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNotPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nsubTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsDetalleProcesoAdjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clsVinculoProveedorBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clsVinculoProveedorBindingSource
            // 
            this.clsVinculoProveedorBindingSource.DataSource = typeof(EntityLayer.clsVinculoProveedor);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(527, 257);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtProveedor);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtCodigo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNroDoc);
            this.grbBase1.Location = new System.Drawing.Point(12, 6);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(575, 74);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Propuestas Econónica de los Proveedores";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(71, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(80, 46);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(475, 20);
            this.txtProveedor.TabIndex = 7;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(25, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(80, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(116, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(286, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Nº Documento:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(418, 22);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(137, 20);
            this.txtNroDoc.TabIndex = 3;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.FormatoDecimal = true;
            this.txtSubTotal.Location = new System.Drawing.Point(467, 231);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.nNumDecimales = 2;
            this.txtSubTotal.nvalor = 0D;
            this.txtSubTotal.Size = new System.Drawing.Size(120, 20);
            this.txtSubTotal.TabIndex = 10;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(359, 234);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(102, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Monto Propuesta";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(341, 257);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 34;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(401, 257);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 33;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(461, 257);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgDetalleNP
            // 
            this.dtgDetalleNP.AllowUserToAddRows = false;
            this.dtgDetalleNP.AllowUserToDeleteRows = false;
            this.dtgDetalleNP.AllowUserToResizeColumns = false;
            this.dtgDetalleNP.AllowUserToResizeRows = false;
            this.dtgDetalleNP.AutoGenerateColumns = false;
            this.dtgDetalleNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProcesoDataGridViewTextBoxColumn,
            this.idDetalleNotapedidoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.idCatalogoDataGridViewTextBoxColumn,
            this.idNotPedidoDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.idUnidadDataGridViewTextBoxColumn,
            this.cUnidadDataGridViewTextBoxColumn,
            this.nCantidadDataGridViewTextBoxColumn,
            this.nPrecioUnitDataGridViewTextBoxColumn,
            this.idGrupoDataGridViewTextBoxColumn,
            this.cDesGrupoDataGridViewTextBoxColumn,
            this.nsubTotalDataGridViewTextBoxColumn});
            this.dtgDetalleNP.DataSource = this.clsDetalleProcesoAdjBindingSource;
            this.dtgDetalleNP.Location = new System.Drawing.Point(12, 86);
            this.dtgDetalleNP.MultiSelect = false;
            this.dtgDetalleNP.Name = "dtgDetalleNP";
            this.dtgDetalleNP.ReadOnly = true;
            this.dtgDetalleNP.RowHeadersVisible = false;
            this.dtgDetalleNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNP.Size = new System.Drawing.Size(575, 139);
            this.dtgDetalleNP.TabIndex = 35;
            this.dtgDetalleNP.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNP_CellEndEdit);
            this.dtgDetalleNP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNP_CellValueChanged);
            this.dtgDetalleNP.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgDetalleNP_DataError);
            this.dtgDetalleNP.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleNP_EditingControlShowing);
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idDetalleNotapedidoDataGridViewTextBoxColumn
            // 
            this.idDetalleNotapedidoDataGridViewTextBoxColumn.DataPropertyName = "idDetalleNotapedido";
            this.idDetalleNotapedidoDataGridViewTextBoxColumn.HeaderText = "idDetalleNotapedido";
            this.idDetalleNotapedidoDataGridViewTextBoxColumn.Name = "idDetalleNotapedidoDataGridViewTextBoxColumn";
            this.idDetalleNotapedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDetalleNotapedidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nItem";
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idCatalogoDataGridViewTextBoxColumn
            // 
            this.idCatalogoDataGridViewTextBoxColumn.DataPropertyName = "idCatalogo";
            this.idCatalogoDataGridViewTextBoxColumn.FillWeight = 80F;
            this.idCatalogoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idCatalogoDataGridViewTextBoxColumn.Name = "idCatalogoDataGridViewTextBoxColumn";
            this.idCatalogoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idNotPedidoDataGridViewTextBoxColumn
            // 
            this.idNotPedidoDataGridViewTextBoxColumn.DataPropertyName = "idNotPedido";
            this.idNotPedidoDataGridViewTextBoxColumn.HeaderText = "idNotPedido";
            this.idNotPedidoDataGridViewTextBoxColumn.Name = "idNotPedidoDataGridViewTextBoxColumn";
            this.idNotPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idNotPedidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.FillWeight = 200F;
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUnidadDataGridViewTextBoxColumn
            // 
            this.idUnidadDataGridViewTextBoxColumn.DataPropertyName = "idUnidad";
            this.idUnidadDataGridViewTextBoxColumn.HeaderText = "idUnidad";
            this.idUnidadDataGridViewTextBoxColumn.Name = "idUnidadDataGridViewTextBoxColumn";
            this.idUnidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUnidadDataGridViewTextBoxColumn.Visible = false;
            // 
            // cUnidadDataGridViewTextBoxColumn
            // 
            this.cUnidadDataGridViewTextBoxColumn.DataPropertyName = "cUnidad";
            this.cUnidadDataGridViewTextBoxColumn.FillWeight = 50F;
            this.cUnidadDataGridViewTextBoxColumn.HeaderText = "Unidad";
            this.cUnidadDataGridViewTextBoxColumn.Name = "cUnidadDataGridViewTextBoxColumn";
            this.cUnidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nCantidadDataGridViewTextBoxColumn
            // 
            this.nCantidadDataGridViewTextBoxColumn.DataPropertyName = "nCantidad";
            this.nCantidadDataGridViewTextBoxColumn.FillWeight = 50F;
            this.nCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.nCantidadDataGridViewTextBoxColumn.Name = "nCantidadDataGridViewTextBoxColumn";
            this.nCantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPrecioUnitDataGridViewTextBoxColumn
            // 
            this.nPrecioUnitDataGridViewTextBoxColumn.DataPropertyName = "nPrecioUnit";
            this.nPrecioUnitDataGridViewTextBoxColumn.FillWeight = 50F;
            this.nPrecioUnitDataGridViewTextBoxColumn.HeaderText = "Precio.Unit";
            this.nPrecioUnitDataGridViewTextBoxColumn.Name = "nPrecioUnitDataGridViewTextBoxColumn";
            this.nPrecioUnitDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.nsubTotalDataGridViewTextBoxColumn.FillWeight = 50F;
            this.nsubTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            this.nsubTotalDataGridViewTextBoxColumn.Name = "nsubTotalDataGridViewTextBoxColumn";
            this.nsubTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clsDetalleProcesoAdjBindingSource
            // 
            this.clsDetalleProcesoAdjBindingSource.DataSource = typeof(EntityLayer.clsDetalleProcesoAdj);
            // 
            // frmEvaluacionEconomica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 335);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgDetalleNP);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmEvaluacionEconomica";
            this.Text = "Evaluación Económica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEvaluacionEconomica_FormClosing);
            this.Load += new System.EventHandler(this.frmEvaluacionEconomica_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.dtgDetalleNP, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtSubTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clsVinculoProveedorBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.BindingSource clsVinculoProveedorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNotaPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItemDataGridViewTextBoxColumn;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBLetra txtNroDoc;
        private GEN.ControlesBase.txtNumRea txtSubTotal;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBLetra txtProveedor;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBLetra txtCodigo;
        private GEN.ControlesBase.dtgBase dtgDetalleNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleNotapedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNotPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clsDetalleProcesoAdjBindingSource;
    }
}