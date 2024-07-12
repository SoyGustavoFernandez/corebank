namespace LOG.Presentacion
{
    partial class frmParcialOrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParcialOrdenCompra));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBienes = new GEN.ControlesBase.grbBase(this.components);
            this.txtSubTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDetalleNotaEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBienes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(508, 308);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 65;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(574, 308);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 66;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBienes
            // 
            this.grbBienes.Controls.Add(this.txtSubTotal);
            this.grbBienes.Controls.Add(this.lblBase14);
            this.grbBienes.Controls.Add(this.btnMiniQuitar);
            this.grbBienes.Controls.Add(this.btnMiniAgregar);
            this.grbBienes.Controls.Add(this.dtgDetalleNotaEntrada);
            this.grbBienes.Location = new System.Drawing.Point(12, 37);
            this.grbBienes.Name = "grbBienes";
            this.grbBienes.Size = new System.Drawing.Size(673, 265);
            this.grbBienes.TabIndex = 67;
            this.grbBienes.TabStop = false;
            this.grbBienes.Text = "Bienes por Ingresar";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.FormatoDecimal = true;
            this.txtSubTotal.Location = new System.Drawing.Point(500, 235);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.nNumDecimales = 2;
            this.txtSubTotal.nvalor = 0D;
            this.txtSubTotal.Size = new System.Drawing.Size(122, 20);
            this.txtSubTotal.TabIndex = 12;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(431, 238);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(65, 13);
            this.lblBase14.TabIndex = 11;
            this.lblBase14.Text = "Sub Total:";
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(628, 52);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 5;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(628, 18);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 4;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            // 
            // dtgDetalleNotaEntrada
            // 
            this.dtgDetalleNotaEntrada.AllowUserToAddRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToDeleteRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeColumns = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeRows = false;
            this.dtgDetalleNotaEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNotaEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNotaEntrada.Location = new System.Drawing.Point(14, 18);
            this.dtgDetalleNotaEntrada.MultiSelect = false;
            this.dtgDetalleNotaEntrada.Name = "dtgDetalleNotaEntrada";
            this.dtgDetalleNotaEntrada.ReadOnly = true;
            this.dtgDetalleNotaEntrada.RowHeadersVisible = false;
            this.dtgDetalleNotaEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleNotaEntrada.Size = new System.Drawing.Size(608, 211);
            this.dtgDetalleNotaEntrada.TabIndex = 1;
            this.dtgDetalleNotaEntrada.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgDetalleNotaEntrada_CellMouseClick);
            // 
            // frmParcialOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 388);
            this.Controls.Add(this.grbBienes);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "frmParcialOrdenCompra";
            this.Text = "Orden de Compra Parcial";
            this.Load += new System.EventHandler(this.frmParcialOrdenCompra_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBienes, 0);
            this.grbBienes.ResumeLayout(false);
            this.grbBienes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBienes;
        private GEN.ControlesBase.txtNumRea txtSubTotal;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.ControlesBase.dtgBase dtgDetalleNotaEntrada;
    }
}