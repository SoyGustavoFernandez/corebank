namespace CRE.Presentacion
{
    partial class frmMantenimientoVendedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoVendedores));
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.dtgMantenimientoVendedores = new System.Windows.Forms.DataGridView();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblCanal = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.cboCanalVendedor1 = new GEN.ControlesBase.cboCanalVendedor(this.components);
            this.clsCNMantenimientoCanalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMantenimientoVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsCNMantenimientoCanalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(438, 245);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 8;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // dtgMantenimientoVendedores
            // 
            this.dtgMantenimientoVendedores.AllowUserToAddRows = false;
            this.dtgMantenimientoVendedores.AllowUserToDeleteRows = false;
            this.dtgMantenimientoVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMantenimientoVendedores.Location = new System.Drawing.Point(10, 86);
            this.dtgMantenimientoVendedores.Name = "dtgMantenimientoVendedores";
            this.dtgMantenimientoVendedores.ReadOnly = true;
            this.dtgMantenimientoVendedores.Size = new System.Drawing.Size(551, 150);
            this.dtgMantenimientoVendedores.TabIndex = 7;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(136, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Listado de Vendedores";
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCanal.ForeColor = System.Drawing.Color.Navy;
            this.lblCanal.Location = new System.Drawing.Point(23, 51);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(45, 13);
            this.lblCanal.TabIndex = 10;
            this.lblCanal.Text = "Canal:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(502, 245);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(373, 245);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 12;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // cboCanalVendedor1
            // 
            this.cboCanalVendedor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalVendedor1.FormattingEnabled = true;
            this.cboCanalVendedor1.Location = new System.Drawing.Point(70, 48);
            this.cboCanalVendedor1.Name = "cboCanalVendedor1";
            this.cboCanalVendedor1.Size = new System.Drawing.Size(167, 21);
            this.cboCanalVendedor1.TabIndex = 13;
            this.cboCanalVendedor1.SelectedIndexChanged += new System.EventHandler(this.cboCanalVendedor1_SelectedIndexChanged);
            // 
            // clsCNMantenimientoCanalesBindingSource
            // 
            this.clsCNMantenimientoCanalesBindingSource.DataSource = typeof(CRE.CapaNegocio.clsCNMantenimientoCanales);
            // 
            // frmMantenimientoVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 325);
            this.Controls.Add(this.cboCanalVendedor1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblCanal);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.dtgMantenimientoVendedores);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmMantenimientoVendedores";
            this.Text = "Mantenimiento de Vendedores";
            this.Load += new System.EventHandler(this.frmMantenimientoVendedores_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgMantenimientoVendedores, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lblCanal, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.cboCanalVendedor1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMantenimientoVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsCNMantenimientoCanalesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar1;
        private System.Windows.Forms.DataGridView dtgMantenimientoVendedores;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblCanal;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.cboCanalVendedor cboCanalVendedor1;
        private System.Windows.Forms.BindingSource clsCNMantenimientoCanalesBindingSource;
    }
}