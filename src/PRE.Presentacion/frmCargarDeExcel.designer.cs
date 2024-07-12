namespace PRE.Presentacion
{
    partial class frmCargarDeExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarDeExcel));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.txtPath = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgPartidas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnBusqueda1);
            this.grbBase1.Controls.Add(this.txtPath);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(580, 66);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Cargar Archivo";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(514, 10);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 7;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // txtPath
            // 
            this.txtPath.AllowDrop = true;
            this.txtPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(49, 23);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(436, 20);
            this.txtPath.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(37, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Path:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(467, 487);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 12;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(532, 487);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgPartidas
            // 
            this.dtgPartidas.AllowUserToAddRows = false;
            this.dtgPartidas.AllowUserToDeleteRows = false;
            this.dtgPartidas.AllowUserToResizeColumns = false;
            this.dtgPartidas.AllowUserToResizeRows = false;
            this.dtgPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidas.Location = new System.Drawing.Point(12, 75);
            this.dtgPartidas.MultiSelect = false;
            this.dtgPartidas.Name = "dtgPartidas";
            this.dtgPartidas.ReadOnly = true;
            this.dtgPartidas.RowHeadersVisible = false;
            this.dtgPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPartidas.Size = new System.Drawing.Size(580, 406);
            this.dtgPartidas.TabIndex = 13;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(401, 487);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 14;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // frmCargarDeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 562);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.dtgPartidas);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmCargarDeExcel";
            this.Text = "Cargar partidas desde Excel";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.dtgPartidas, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.txtBase txtPath;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgPartidas;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
    }
}