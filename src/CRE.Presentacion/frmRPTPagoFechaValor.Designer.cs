namespace CRE.Presentacion
{
    partial class frmRPTPagoFechaValor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTPagoFechaValor));
            this.lblHasta = new GEN.ControlesBase.lblBase();
            this.lblDesde = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnBucar = new GEN.BotonesBase.btnBusqueda();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblHasta.ForeColor = System.Drawing.Color.Navy;
            this.lblHasta.Location = new System.Drawing.Point(183, 33);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(44, 13);
            this.lblHasta.TabIndex = 53;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDesde.ForeColor = System.Drawing.Color.Navy;
            this.lblDesde.Location = new System.Drawing.Point(9, 33);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(48, 13);
            this.lblDesde.TabIndex = 52;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 30);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(230, 30);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnBucar
            // 
            this.btnBucar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBucar.BackgroundImage")));
            this.btnBucar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBucar.Location = new System.Drawing.Point(348, 16);
            this.btnBucar.Name = "btnBucar";
            this.btnBucar.Size = new System.Drawing.Size(60, 50);
            this.btnBucar.TabIndex = 3;
            this.btnBucar.Text = "&Buscar";
            this.btnBucar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBucar.UseVisualStyleBackColor = true;
            this.btnBucar.Click += new System.EventHandler(this.btnBucar_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(414, 16);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDesde);
            this.groupBox1.Controls.Add(this.btnCancelar1);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.btnBucar);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.lblHasta);
            this.groupBox1.Location = new System.Drawing.Point(84, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 79);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToDeleteRows = false;
            this.dtgDatos.AllowUserToResizeColumns = false;
            this.dtgDatos.AllowUserToResizeRows = false;
            this.dtgDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgDatos.Location = new System.Drawing.Point(12, 97);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.RowHeadersVisible = false;
            this.dtgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos.Size = new System.Drawing.Size(605, 153);
            this.dtgDatos.TabIndex = 5;
            this.dtgDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellClick);
            this.dtgDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgDatos_CellFormatting);
            this.dtgDatos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellMouseEnter);
            this.dtgDatos.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellMouseLeave);
            // 
            // frmRPTPagoFechaValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 303);
            this.Controls.Add(this.dtgDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRPTPagoFechaValor";
            this.Text = "Reporte de Pagos con Fecha Valor";
            this.Load += new System.EventHandler(this.frmRPTPagoFechaValor_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dtgDatos, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblHasta;
        private GEN.ControlesBase.lblBase lblDesde;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.dtpCorto dtpHasta;
        private GEN.BotonesBase.btnBusqueda btnBucar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgDatos;
    }
}