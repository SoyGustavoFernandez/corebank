namespace LOG.Presentacion
{
    partial class frmEstimaPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstimaPrecios));
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtpFechaNP = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNP = new GEN.ControlesBase.dtgBase(this.components);
            this.idGrupoActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitProveedor = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgrProveedor = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgProveedores = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(265, 10);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(122, 20);
            this.txtMoneda.TabIndex = 44;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(75, 9);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(122, 20);
            this.txtUsuario.TabIndex = 43;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(203, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 41;
            this.lblBase1.Text = "Moneda:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(14, 12);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 40;
            this.lblBase8.Text = "Usuario:";
            // 
            // dtpFechaNP
            // 
            this.dtpFechaNP.Enabled = false;
            this.dtpFechaNP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNP.Location = new System.Drawing.Point(465, 12);
            this.dtpFechaNP.Name = "dtpFechaNP";
            this.dtpFechaNP.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaNP.TabIndex = 38;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(414, 16);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 39;
            this.lblBase5.Text = "Fecha:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleNP);
            this.grbBase1.Location = new System.Drawing.Point(12, 30);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(587, 169);
            this.grbBase1.TabIndex = 45;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgDetalleNP
            // 
            this.dtgDetalleNP.AllowUserToAddRows = false;
            this.dtgDetalleNP.AllowUserToDeleteRows = false;
            this.dtgDetalleNP.AllowUserToResizeColumns = false;
            this.dtgDetalleNP.AllowUserToResizeRows = false;
            this.dtgDetalleNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idGrupoActivo});
            this.dtgDetalleNP.Location = new System.Drawing.Point(6, 19);
            this.dtgDetalleNP.MultiSelect = false;
            this.dtgDetalleNP.Name = "dtgDetalleNP";
            this.dtgDetalleNP.ReadOnly = true;
            this.dtgDetalleNP.RowHeadersVisible = false;
            this.dtgDetalleNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNP.Size = new System.Drawing.Size(575, 139);
            this.dtgDetalleNP.TabIndex = 5;
            this.dtgDetalleNP.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgDetalleNP_CellValidating);
            this.dtgDetalleNP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNP_CellValueChanged);
            this.dtgDetalleNP.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleNP_EditingControlShowing);
            this.dtgDetalleNP.SelectionChanged += new System.EventHandler(this.dtgDetalleNP_SelectionChanged);
            // 
            // idGrupoActivo
            // 
            this.idGrupoActivo.DataPropertyName = "idGrupoActivo";
            this.idGrupoActivo.FillWeight = 55F;
            this.idGrupoActivo.HeaderText = "Código";
            this.idGrupoActivo.Name = "idGrupoActivo";
            this.idGrupoActivo.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(539, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 52;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnQuitProveedor);
            this.grbBase2.Controls.Add(this.btnAgrProveedor);
            this.grbBase2.Controls.Add(this.dtgProveedores);
            this.grbBase2.Location = new System.Drawing.Point(9, 227);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(590, 117);
            this.grbBase2.TabIndex = 46;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Proveedor";
            // 
            // btnQuitProveedor
            // 
            this.btnQuitProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitProveedor.BackgroundImage")));
            this.btnQuitProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitProveedor.Location = new System.Drawing.Point(548, 56);
            this.btnQuitProveedor.Name = "btnQuitProveedor";
            this.btnQuitProveedor.Size = new System.Drawing.Size(36, 28);
            this.btnQuitProveedor.TabIndex = 22;
            this.btnQuitProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitProveedor.UseVisualStyleBackColor = true;
            this.btnQuitProveedor.Click += new System.EventHandler(this.btnQuitProveedor_Click);
            // 
            // btnAgrProveedor
            // 
            this.btnAgrProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgrProveedor.BackgroundImage")));
            this.btnAgrProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgrProveedor.Location = new System.Drawing.Point(548, 22);
            this.btnAgrProveedor.Name = "btnAgrProveedor";
            this.btnAgrProveedor.Size = new System.Drawing.Size(36, 28);
            this.btnAgrProveedor.TabIndex = 21;
            this.btnAgrProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgrProveedor.UseVisualStyleBackColor = true;
            this.btnAgrProveedor.Click += new System.EventHandler(this.btnAgrProveedor_Click);
            // 
            // dtgProveedores
            // 
            this.dtgProveedores.AllowUserToAddRows = false;
            this.dtgProveedores.AllowUserToDeleteRows = false;
            this.dtgProveedores.AllowUserToResizeColumns = false;
            this.dtgProveedores.AllowUserToResizeRows = false;
            this.dtgProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProveedores.Location = new System.Drawing.Point(6, 22);
            this.dtgProveedores.MultiSelect = false;
            this.dtgProveedores.Name = "dtgProveedores";
            this.dtgProveedores.ReadOnly = true;
            this.dtgProveedores.RowHeadersVisible = false;
            this.dtgProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProveedores.Size = new System.Drawing.Size(532, 89);
            this.dtgProveedores.TabIndex = 20;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(473, 350);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 55;
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
            this.lblBase2.Location = new System.Drawing.Point(391, 208);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(104, 13);
            this.lblBase2.TabIndex = 56;
            this.lblBase2.Text = "Valor Referencial";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.FormatoDecimal = true;
            this.txtTotal.Location = new System.Drawing.Point(502, 204);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 2;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.Size = new System.Drawing.Size(91, 20);
            this.txtTotal.TabIndex = 57;
            // 
            // frmEstimaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 432);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.dtpFechaNP);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmEstimaPrecios";
            this.Text = "Estimación de Precios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstimaPrecios_FormClosing);
            this.Load += new System.EventHandler(this.frmEstimaPrecios_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.dtpFechaNP, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).EndInit();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtpCorto dtpFechaNP;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgDetalleNP;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnMiniQuitar btnQuitProveedor;
        private GEN.BotonesBase.btnMiniAgregar btnAgrProveedor;
        private GEN.ControlesBase.dtgBase dtgProveedores;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRubroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
    }
}