namespace LOG.Presentacion
{
    partial class frmListaActivosxAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaActivosxAlmacen));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgActivosxAlmacen = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.txtDescripBien = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.txtStock = new GEN.ControlesBase.txtNumRea(this.components);
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadAlmacenaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivosxAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtReferencia);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(12, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(588, 44);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(145, 16);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(372, 20);
            this.txtReferencia.TabIndex = 23;
            this.txtReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferencia_KeyPress);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(133, 13);
            this.lblBase2.TabIndex = 22;
            this.lblBase2.Text = "Referencia del Activo:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgActivosxAlmacen);
            this.grbBase2.Location = new System.Drawing.Point(12, 57);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(723, 303);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Lista Activos de Almacen";
            // 
            // dtgActivosxAlmacen
            // 
            this.dtgActivosxAlmacen.AllowUserToAddRows = false;
            this.dtgActivosxAlmacen.AllowUserToDeleteRows = false;
            this.dtgActivosxAlmacen.AllowUserToResizeColumns = false;
            this.dtgActivosxAlmacen.AllowUserToResizeRows = false;
            this.dtgActivosxAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivosxAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivosxAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCatalogo,
            this.cNombreGrupo,
            this.cNombreSubGrupo,
            this.cNombreRubro,
            this.cProducto,
            this.cNomCorto,
            this.nCantidadStock,
            this.idUnidadAlmacenaje});
            this.dtgActivosxAlmacen.Location = new System.Drawing.Point(6, 19);
            this.dtgActivosxAlmacen.MultiSelect = false;
            this.dtgActivosxAlmacen.Name = "dtgActivosxAlmacen";
            this.dtgActivosxAlmacen.ReadOnly = true;
            this.dtgActivosxAlmacen.RowHeadersVisible = false;
            this.dtgActivosxAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivosxAlmacen.Size = new System.Drawing.Size(711, 273);
            this.dtgActivosxAlmacen.TabIndex = 0;
            this.dtgActivosxAlmacen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgTransferencias_CellMouseClick);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(675, 365);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(606, 366);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 19;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // txtDescripBien
            // 
            this.txtDescripBien.Enabled = false;
            this.txtDescripBien.Location = new System.Drawing.Point(125, 391);
            this.txtDescripBien.Name = "txtDescripBien";
            this.txtDescripBien.Size = new System.Drawing.Size(404, 20);
            this.txtDescripBien.TabIndex = 20;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 394);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(107, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "Descripcion Bien:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 366);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(94, 13);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Stock del Bien:";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(606, 7);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 24;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.FormatoDecimal = false;
            this.txtStock.Location = new System.Drawing.Point(125, 366);
            this.txtStock.Name = "txtStock";
            this.txtStock.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtStock.nNumDecimales = 4;
            this.txtStock.nvalor = 0D;
            this.txtStock.Size = new System.Drawing.Size(234, 20);
            this.txtStock.TabIndex = 25;
            this.txtStock.Text = "0.00";
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.FillWeight = 25F;
            this.idCatalogo.HeaderText = "N° Cat";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // cNombreGrupo
            // 
            this.cNombreGrupo.DataPropertyName = "cNombreGrupo";
            this.cNombreGrupo.FillWeight = 50F;
            this.cNombreGrupo.HeaderText = "Grupo";
            this.cNombreGrupo.Name = "cNombreGrupo";
            this.cNombreGrupo.ReadOnly = true;
            // 
            // cNombreSubGrupo
            // 
            this.cNombreSubGrupo.DataPropertyName = "cNombreSubGrupo";
            this.cNombreSubGrupo.FillWeight = 50F;
            this.cNombreSubGrupo.HeaderText = "Sub Grupo";
            this.cNombreSubGrupo.Name = "cNombreSubGrupo";
            this.cNombreSubGrupo.ReadOnly = true;
            // 
            // cNombreRubro
            // 
            this.cNombreRubro.DataPropertyName = "cNombreRubro";
            this.cNombreRubro.FillWeight = 50F;
            this.cNombreRubro.HeaderText = "Rubro";
            this.cNombreRubro.Name = "cNombreRubro";
            this.cNombreRubro.ReadOnly = true;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.HeaderText = "Desc. Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cNomCorto
            // 
            this.cNomCorto.DataPropertyName = "cNomCorto";
            this.cNomCorto.FillWeight = 20F;
            this.cNomCorto.HeaderText = "UND.";
            this.cNomCorto.Name = "cNomCorto";
            this.cNomCorto.ReadOnly = true;
            // 
            // nCantidadStock
            // 
            this.nCantidadStock.DataPropertyName = "nCantidadStock";
            this.nCantidadStock.HeaderText = "nCantidadStock";
            this.nCantidadStock.Name = "nCantidadStock";
            this.nCantidadStock.ReadOnly = true;
            this.nCantidadStock.Visible = false;
            // 
            // idUnidadAlmacenaje
            // 
            this.idUnidadAlmacenaje.DataPropertyName = "idUnidadAlmacenaje";
            this.idUnidadAlmacenaje.HeaderText = "idUnidadAlmacenaje";
            this.idUnidadAlmacenaje.Name = "idUnidadAlmacenaje";
            this.idUnidadAlmacenaje.ReadOnly = true;
            this.idUnidadAlmacenaje.Visible = false;
            // 
            // frmListaActivosxAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 440);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDescripBien);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmListaActivosxAlmacen";
            this.Text = "Solicitud de Transferencia de Almacén";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.txtDescripBien, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.txtStock, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivosxAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgActivosxAlmacen;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtReferencia;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.ControlesBase.txtBase txtDescripBien;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.txtNumRea txtStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidadAlmacenaje;
    }
}

