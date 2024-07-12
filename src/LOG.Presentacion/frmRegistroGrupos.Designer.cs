namespace LOG.Presentacion
{
    partial class frmRegistroGrupos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroGrupos));
            this.dtgGrupo = new GEN.ControlesBase.dtgBase(this.components);
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDetalleAdj = new GEN.ControlesBase.dtgBase(this.components);
            this.nItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNotaPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsDetalleNotaPedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtgDetConGrp = new GEN.ControlesBase.dtgBase(this.components);
            this.idUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitGrupo = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregGrupo = new GEN.BotonesBase.btnMiniAgregar();
            this.txtDesGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcion = new GEN.ControlesBase.lblBase();
            this.btnAgrItem = new GEN.BotonesBase.btnMiniPasarDerecha();
            this.btnQuitItem = new GEN.BotonesBase.btnMiniPasarIzquierda();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblGrupo = new System.Windows.Forms.Label();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleNotaPedidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetConGrp)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgGrupo
            // 
            this.dtgGrupo.AllowUserToAddRows = false;
            this.dtgGrupo.AllowUserToDeleteRows = false;
            this.dtgGrupo.AllowUserToResizeColumns = false;
            this.dtgGrupo.AllowUserToResizeRows = false;
            this.dtgGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Descripcion});
            this.dtgGrupo.Location = new System.Drawing.Point(9, 46);
            this.dtgGrupo.MultiSelect = false;
            this.dtgGrupo.Name = "dtgGrupo";
            this.dtgGrupo.ReadOnly = true;
            this.dtgGrupo.RowHeadersVisible = false;
            this.dtgGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupo.Size = new System.Drawing.Size(292, 115);
            this.dtgGrupo.TabIndex = 4;
            this.dtgGrupo.SelectionChanged += new System.EventHandler(this.dtgGrupo_SelectionChanged);
            // 
            // Grupo
            // 
            this.Grupo.FillWeight = 25F;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.MinimumWidth = 15;
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // dtgDetalleAdj
            // 
            this.dtgDetalleAdj.AllowUserToAddRows = false;
            this.dtgDetalleAdj.AllowUserToDeleteRows = false;
            this.dtgDetalleAdj.AllowUserToResizeColumns = false;
            this.dtgDetalleAdj.AllowUserToResizeRows = false;
            this.dtgDetalleAdj.AutoGenerateColumns = false;
            this.dtgDetalleAdj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleAdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nItem,
            this.idNotaPedidoDataGridViewTextBoxColumn,
            this.idCatalogoDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.nCantidadDataGridViewTextBoxColumn,
            this.nPrecioUnitDataGridViewTextBoxColumn});
            this.dtgDetalleAdj.DataSource = this.clsDetalleNotaPedidoBindingSource;
            this.dtgDetalleAdj.Location = new System.Drawing.Point(304, 46);
            this.dtgDetalleAdj.MultiSelect = false;
            this.dtgDetalleAdj.Name = "dtgDetalleAdj";
            this.dtgDetalleAdj.ReadOnly = true;
            this.dtgDetalleAdj.RowHeadersVisible = false;
            this.dtgDetalleAdj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleAdj.Size = new System.Drawing.Size(373, 115);
            this.dtgDetalleAdj.TabIndex = 5;
            // 
            // nItem
            // 
            this.nItem.DataPropertyName = "nItem";
            this.nItem.FillWeight = 45F;
            this.nItem.HeaderText = "Item";
            this.nItem.Name = "nItem";
            this.nItem.ReadOnly = true;
            // 
            // idNotaPedidoDataGridViewTextBoxColumn
            // 
            this.idNotaPedidoDataGridViewTextBoxColumn.DataPropertyName = "idNotaPedido";
            this.idNotaPedidoDataGridViewTextBoxColumn.HeaderText = "idNotaPedido";
            this.idNotaPedidoDataGridViewTextBoxColumn.Name = "idNotaPedidoDataGridViewTextBoxColumn";
            this.idNotaPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idNotaPedidoDataGridViewTextBoxColumn.Visible = false;
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
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nCantidadDataGridViewTextBoxColumn
            // 
            this.nCantidadDataGridViewTextBoxColumn.DataPropertyName = "nCantidad";
            dataGridViewCellStyle9.Format = "N2";
            this.nCantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.nCantidadDataGridViewTextBoxColumn.FillWeight = 70F;
            this.nCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.nCantidadDataGridViewTextBoxColumn.Name = "nCantidadDataGridViewTextBoxColumn";
            this.nCantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPrecioUnitDataGridViewTextBoxColumn
            // 
            this.nPrecioUnitDataGridViewTextBoxColumn.DataPropertyName = "nPrecioUnit";
            dataGridViewCellStyle10.Format = "N2";
            this.nPrecioUnitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.nPrecioUnitDataGridViewTextBoxColumn.HeaderText = "Precio Unit.";
            this.nPrecioUnitDataGridViewTextBoxColumn.Name = "nPrecioUnitDataGridViewTextBoxColumn";
            this.nPrecioUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clsDetalleNotaPedidoBindingSource
            // 
            this.clsDetalleNotaPedidoBindingSource.DataSource = typeof(EntityLayer.clsDetalleNotaPedido);
            // 
            // dtgDetConGrp
            // 
            this.dtgDetConGrp.AllowUserToAddRows = false;
            this.dtgDetConGrp.AllowUserToDeleteRows = false;
            this.dtgDetConGrp.AllowUserToResizeColumns = false;
            this.dtgDetConGrp.AllowUserToResizeRows = false;
            this.dtgDetConGrp.AutoGenerateColumns = false;
            this.dtgDetConGrp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetConGrp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetConGrp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUnidad,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.cUnidad,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dtgDetConGrp.DataSource = this.clsDetalleNotaPedidoBindingSource;
            this.dtgDetConGrp.Location = new System.Drawing.Point(9, 42);
            this.dtgDetConGrp.MultiSelect = false;
            this.dtgDetConGrp.Name = "dtgDetConGrp";
            this.dtgDetConGrp.ReadOnly = true;
            this.dtgDetConGrp.RowHeadersVisible = false;
            this.dtgDetConGrp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetConGrp.Size = new System.Drawing.Size(668, 115);
            this.dtgDetConGrp.TabIndex = 4;
            // 
            // idUnidad
            // 
            this.idUnidad.DataPropertyName = "idUnidad";
            this.idUnidad.HeaderText = "idUnidad";
            this.idUnidad.Name = "idUnidad";
            this.idUnidad.ReadOnly = true;
            this.idUnidad.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nItem";
            this.dataGridViewTextBoxColumn2.FillWeight = 30F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Item";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "idNotaPedido";
            this.dataGridViewTextBoxColumn3.HeaderText = "idNotaPedido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "idCatalogo";
            this.dataGridViewTextBoxColumn4.HeaderText = "idCatalogo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cProducto";
            this.dataGridViewTextBoxColumn5.FillWeight = 250F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Articulo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // cUnidad
            // 
            this.cUnidad.DataPropertyName = "cUnidad";
            this.cUnidad.FillWeight = 60F;
            this.cUnidad.HeaderText = "Unidad";
            this.cUnidad.Name = "cUnidad";
            this.cUnidad.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "nCantidad";
            dataGridViewCellStyle11.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn6.FillWeight = 70F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "nPrecioUnit";
            dataGridViewCellStyle12.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn7.HeaderText = "Precio Unit.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // btnQuitGrupo
            // 
            this.btnQuitGrupo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitGrupo.BackgroundImage")));
            this.btnQuitGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitGrupo.Location = new System.Drawing.Point(265, 12);
            this.btnQuitGrupo.Name = "btnQuitGrupo";
            this.btnQuitGrupo.Size = new System.Drawing.Size(36, 28);
            this.btnQuitGrupo.TabIndex = 3;
            this.btnQuitGrupo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitGrupo.UseVisualStyleBackColor = true;
            this.btnQuitGrupo.Click += new System.EventHandler(this.btnQuitGrupo_Click);
            // 
            // btnAgregGrupo
            // 
            this.btnAgregGrupo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregGrupo.BackgroundImage")));
            this.btnAgregGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregGrupo.Location = new System.Drawing.Point(229, 12);
            this.btnAgregGrupo.Name = "btnAgregGrupo";
            this.btnAgregGrupo.Size = new System.Drawing.Size(36, 28);
            this.btnAgregGrupo.TabIndex = 2;
            this.btnAgregGrupo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregGrupo.UseVisualStyleBackColor = true;
            this.btnAgregGrupo.Click += new System.EventHandler(this.btnAgregGrupo_Click);
            // 
            // txtDesGrupo
            // 
            this.txtDesGrupo.Location = new System.Drawing.Point(84, 16);
            this.txtDesGrupo.Name = "txtDesGrupo";
            this.txtDesGrupo.Size = new System.Drawing.Size(139, 20);
            this.txtDesGrupo.TabIndex = 1;
            this.txtDesGrupo.TextChanged += new System.EventHandler(this.txtDesGrupo_TextChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 19);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(73, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripción";
            // 
            // btnAgrItem
            // 
            this.btnAgrItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgrItem.BackgroundImage")));
            this.btnAgrItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgrItem.Location = new System.Drawing.Point(640, 11);
            this.btnAgrItem.Name = "btnAgrItem";
            this.btnAgrItem.Size = new System.Drawing.Size(36, 28);
            this.btnAgrItem.TabIndex = 3;
            this.btnAgrItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgrItem.UseVisualStyleBackColor = true;
            this.btnAgrItem.Click += new System.EventHandler(this.btnAgregItem_Click);
            // 
            // btnQuitItem
            // 
            this.btnQuitItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitItem.BackgroundImage")));
            this.btnQuitItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitItem.Location = new System.Drawing.Point(603, 11);
            this.btnQuitItem.Name = "btnQuitItem";
            this.btnQuitItem.Size = new System.Drawing.Size(36, 28);
            this.btnQuitItem.TabIndex = 2;
            this.btnQuitItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitItem.UseVisualStyleBackColor = true;
            this.btnQuitItem.Click += new System.EventHandler(this.btnQuitItem_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(628, 335);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(562, 335);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Lista de Articulos: ";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(499, 30);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(174, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Lista de Articulos SIN GRUPO";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblGrupo);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnQuitItem);
            this.grbBase1.Controls.Add(this.dtgDetConGrp);
            this.grbBase1.Controls.Add(this.btnAgrItem);
            this.grbBase1.Location = new System.Drawing.Point(12, 163);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(688, 168);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblGrupo.Location = new System.Drawing.Point(140, 13);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(115, 18);
            this.lblGrupo.TabIndex = 1;
            this.lblGrupo.Text = "NombreGrupo";
            this.lblGrupo.Visible = false;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgDetalleAdj);
            this.grbBase2.Controls.Add(this.lblDescripcion);
            this.grbBase2.Controls.Add(this.dtgGrupo);
            this.grbBase2.Controls.Add(this.btnQuitGrupo);
            this.grbBase2.Controls.Add(this.btnAgregGrupo);
            this.grbBase2.Controls.Add(this.txtDesGrupo);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(12, 2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(688, 165);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            // 
            // frmRegistroGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 410);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegistroGrupos";
            this.Text = "Agrupación de los Items";
            this.Load += new System.EventHandler(this.frmRegistroGrupos_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleNotaPedidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetConGrp)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgGrupo;
        private GEN.ControlesBase.dtgBase dtgDetalleAdj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clsDetalleNotaPedidoBindingSource;
        private GEN.ControlesBase.dtgBase dtgDetConGrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private GEN.BotonesBase.btnMiniQuitar btnQuitGrupo;
        private GEN.BotonesBase.btnMiniAgregar btnAgregGrupo;
        private GEN.ControlesBase.txtBase txtDesGrupo;
        private GEN.ControlesBase.lblBase lblDescripcion;
        private GEN.BotonesBase.btnMiniPasarDerecha btnAgrItem;
        private GEN.BotonesBase.btnMiniPasarIzquierda btnQuitItem;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNotaPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Label lblGrupo;

    }
}