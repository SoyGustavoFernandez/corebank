namespace CNE.Presentacion
{
    partial class frmRptComisionesCanalesElec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptComisionesCanalesElec));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboCanalElec = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgComisiones = new GEN.ControlesBase.dtgBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(517, 246);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(27, 12);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Canal:";
            // 
            // cboCanalElec
            // 
            this.cboCanalElec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalElec.FormattingEnabled = true;
            this.cboCanalElec.Location = new System.Drawing.Point(79, 9);
            this.cboCanalElec.Name = "cboCanalElec";
            this.cboCanalElec.Size = new System.Drawing.Size(126, 21);
            this.cboCanalElec.TabIndex = 23;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 43);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "F. Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(79, 40);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaInicio.TabIndex = 22;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(212, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(40, 13);
            this.lblBase2.TabIndex = 25;
            this.lblBase2.Text = "F. Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(263, 40);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaFin.TabIndex = 26;
            // 
            // dtgComisiones
            // 
            this.dtgComisiones.AllowUserToAddRows = false;
            this.dtgComisiones.AllowUserToDeleteRows = false;
            this.dtgComisiones.AllowUserToResizeColumns = false;
            this.dtgComisiones.AllowUserToResizeRows = false;
            this.dtgComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComisiones.Location = new System.Drawing.Point(18, 77);
            this.dtgComisiones.MultiSelect = false;
            this.dtgComisiones.Name = "dtgComisiones";
            this.dtgComisiones.ReadOnly = true;
            this.dtgComisiones.RowHeadersVisible = false;
            this.dtgComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComisiones.Size = new System.Drawing.Size(560, 163);
            this.dtgComisiones.TabIndex = 27;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(452, 12);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 28;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(518, 12);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 29;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // frmRptComisionesCanalesElec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 325);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.dtgComisiones);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboCanalElec);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptComisionesCanalesElec";
            this.Text = "frmRptComisionesCanalesElec";
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboCanalElec, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtgComisiones, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboCanalElec;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.dtgBase dtgComisiones;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
    }
}