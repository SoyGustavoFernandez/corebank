namespace SPL.Presentacion
{
    partial class frmMantenimientoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoProductos));
            this.dtgProducto = new GEN.ControlesBase.dtgBase(this.components);
            this.txtNombreProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.conBuscaProducto = new GEN.ControlesBase.conProducto();
            this.dtgProductosAsociados = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniCancelEst1 = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniNuevo1 = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.cboTipoProd = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductosAsociados)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgProducto
            // 
            this.dtgProducto.AllowUserToAddRows = false;
            this.dtgProducto.AllowUserToDeleteRows = false;
            this.dtgProducto.AllowUserToResizeColumns = false;
            this.dtgProducto.AllowUserToResizeRows = false;
            this.dtgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProducto.Location = new System.Drawing.Point(6, 19);
            this.dtgProducto.MultiSelect = false;
            this.dtgProducto.Name = "dtgProducto";
            this.dtgProducto.ReadOnly = true;
            this.dtgProducto.RowHeadersVisible = false;
            this.dtgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProducto.Size = new System.Drawing.Size(342, 150);
            this.dtgProducto.TabIndex = 2;
            this.dtgProducto.SelectionChanged += new System.EventHandler(this.dtgProducto_SelectionChanged);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreProducto.Location = new System.Drawing.Point(354, 34);
            this.txtNombreProducto.MaxLength = 150;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(160, 20);
            this.txtNombreProducto.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(90, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Tipo Producto:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcVigencia);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtNombreProducto);
            this.grbBase1.Controls.Add(this.dtgProducto);
            this.grbBase1.Location = new System.Drawing.Point(12, 40);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(520, 170);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Producto Riesgo";
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Location = new System.Drawing.Point(354, 153);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(67, 17);
            this.chcVigencia.TabIndex = 10;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(351, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Nombre:";
            // 
            // conBuscaProducto
            // 
            this.conBuscaProducto.AutoSize = true;
            this.conBuscaProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBuscaProducto.lMostrarTipoCredito = true;
            this.conBuscaProducto.Location = new System.Drawing.Point(6, 124);
            this.conBuscaProducto.Name = "conBuscaProducto";
            this.conBuscaProducto.Size = new System.Drawing.Size(322, 92);
            this.conBuscaProducto.TabIndex = 5;
            // 
            // dtgProductosAsociados
            // 
            this.dtgProductosAsociados.AllowUserToAddRows = false;
            this.dtgProductosAsociados.AllowUserToDeleteRows = false;
            this.dtgProductosAsociados.AllowUserToResizeColumns = false;
            this.dtgProductosAsociados.AllowUserToResizeRows = false;
            this.dtgProductosAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProductosAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductosAsociados.Location = new System.Drawing.Point(4, 17);
            this.dtgProductosAsociados.MultiSelect = false;
            this.dtgProductosAsociados.Name = "dtgProductosAsociados";
            this.dtgProductosAsociados.ReadOnly = true;
            this.dtgProductosAsociados.RowHeadersVisible = false;
            this.dtgProductosAsociados.RowTemplate.Height = 20;
            this.dtgProductosAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductosAsociados.Size = new System.Drawing.Size(528, 101);
            this.dtgProductosAsociados.TabIndex = 6;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniCancelEst1);
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Controls.Add(this.btnMiniAgregar1);
            this.grbBase2.Controls.Add(this.btnMiniNuevo1);
            this.grbBase2.Controls.Add(this.dtgProductosAsociados);
            this.grbBase2.Controls.Add(this.conBuscaProducto);
            this.grbBase2.Location = new System.Drawing.Point(4, 217);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(536, 224);
            this.grbBase2.TabIndex = 7;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Productos Internos";
            // 
            // btnMiniCancelEst1
            // 
            this.btnMiniCancelEst1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst1.BackgroundImage")));
            this.btnMiniCancelEst1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst1.Location = new System.Drawing.Point(468, 124);
            this.btnMiniCancelEst1.Name = "btnMiniCancelEst1";
            this.btnMiniCancelEst1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst1.TabIndex = 10;
            this.btnMiniCancelEst1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst1.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst1.Click += new System.EventHandler(this.btnMiniCancelEst1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(426, 124);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 9;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(384, 124);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 8;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniNuevo1
            // 
            this.btnMiniNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniNuevo1.BackgroundImage")));
            this.btnMiniNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo1.Location = new System.Drawing.Point(342, 124);
            this.btnMiniNuevo1.Name = "btnMiniNuevo1";
            this.btnMiniNuevo1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniNuevo1.TabIndex = 7;
            this.btnMiniNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo1.UseVisualStyleBackColor = true;
            this.btnMiniNuevo1.Click += new System.EventHandler(this.btnMiniNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(264, 447);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 12;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(462, 446);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(198, 447);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 9;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(330, 447);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 10;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(396, 447);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 13;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // cboTipoProd
            // 
            this.cboTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProd.FormattingEnabled = true;
            this.cboTipoProd.Location = new System.Drawing.Point(105, 13);
            this.cboTipoProd.Name = "cboTipoProd";
            this.cboTipoProd.Size = new System.Drawing.Size(121, 21);
            this.cboTipoProd.TabIndex = 8;
            this.cboTipoProd.SelectedIndexChanged += new System.EventHandler(this.cboTipoProd_SelectedIndexChanged);
            // 
            // frmMantenimientoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 521);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoProd);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoProductos";
            this.Text = "Mantenimientos de productos";
            this.Load += new System.EventHandler(this.frmMantenimientoProductos_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoProd, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductosAsociados)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgProducto;
        private GEN.ControlesBase.txtBase txtNombreProducto;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.conProducto conBuscaProducto;
        private GEN.ControlesBase.dtgBase dtgProductosAsociados;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniNuevo btnMiniNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.cboBase cboTipoProd;
    }
}