namespace CNT.Presentacion
{
    partial class frmBuscarNotasEEFF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarNotasEEFF));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgListaNotas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgListaNotas);
            this.grbBase1.Location = new System.Drawing.Point(11, 63);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(685, 263);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            // 
            // dtgListaNotas
            // 
            this.dtgListaNotas.AllowUserToAddRows = false;
            this.dtgListaNotas.AllowUserToDeleteRows = false;
            this.dtgListaNotas.AllowUserToResizeColumns = false;
            this.dtgListaNotas.AllowUserToResizeRows = false;
            this.dtgListaNotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaNotas.Location = new System.Drawing.Point(6, 19);
            this.dtgListaNotas.MultiSelect = false;
            this.dtgListaNotas.Name = "dtgListaNotas";
            this.dtgListaNotas.ReadOnly = true;
            this.dtgListaNotas.RowHeadersVisible = false;
            this.dtgListaNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaNotas.Size = new System.Drawing.Size(673, 238);
            this.dtgListaNotas.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Desde:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 41);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(84, 10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(116, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(84, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(116, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(630, 332);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(304, 332);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(218, 9);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 2;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // frmBuscarNotasEEFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 414);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmBuscarNotasEEFF";
            this.Text = "Buscar Notas de EEFF";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgListaNotas;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.dtpCorto dtpHasta;
    }
}