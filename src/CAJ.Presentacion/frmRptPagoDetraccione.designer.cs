namespace CAJ.Presentacion
{
    partial class frmRptPagoDetraccione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPagoDetraccione));
            this.dtpFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboGrupo = new GEN.ControlesBase.cboBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnGrupo = new GEN.BotonesBase.btnGrupo();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecFinal
            // 
            this.dtpFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinal.Location = new System.Drawing.Point(305, 24);
            this.dtpFecFinal.Name = "dtpFecFinal";
            this.dtpFecFinal.Size = new System.Drawing.Size(130, 20);
            this.dtpFecFinal.TabIndex = 9;
            this.dtpFecFinal.ValueChanged += new System.EventHandler(this.dtpFecFinal_ValueChanged);
            // 
            // dtpFecInicial
            // 
            this.dtpFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicial.Location = new System.Drawing.Point(86, 24);
            this.dtpFecInicial.Name = "dtpFecInicial";
            this.dtpFecInicial.Size = new System.Drawing.Size(130, 20);
            this.dtpFecInicial.TabIndex = 8;
            this.dtpFecInicial.ValueChanged += new System.EventHandler(this.dtpFecInicial_ValueChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(223, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 72);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(95, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Fecha y Grupo:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Enabled = false;
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(104, 68);
            this.cboGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(191, 21);
            this.cboGrupo.TabIndex = 11;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(322, 115);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(382, 115);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Location = new System.Drawing.Point(3, 3);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase1.Size = new System.Drawing.Size(439, 47);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango Fechas";
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(1, 55);
            this.grbBase2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase2.Size = new System.Drawing.Size(439, 47);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Rango Fechas";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.btnGrupo);
            this.grbBase3.Location = new System.Drawing.Point(3, 51);
            this.grbBase3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase3.Size = new System.Drawing.Size(440, 57);
            this.grbBase3.TabIndex = 15;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Grupo";
            // 
            // btnGrupo
            // 
            this.btnGrupo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrupo.BackgroundImage")));
            this.btnGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrupo.Location = new System.Drawing.Point(365, 13);
            this.btnGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(67, 40);
            this.btnGrupo.TabIndex = 0;
            this.btnGrupo.Text = "Grupo";
            this.btnGrupo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrupo.UseVisualStyleBackColor = true;
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);
            // 
            // frmRptPagoDetraccione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 192);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboGrupo);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFecFinal);
            this.Controls.Add(this.dtpFecInicial);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmRptPagoDetraccione";
            this.Text = "Reporte Listado Pago Detracciones";
            this.Load += new System.EventHandler(this.frmRptPagoDetraccione_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFecInicial, 0);
            this.Controls.SetChildIndex(this.dtpFecFinal, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboGrupo, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecFinal;
        private GEN.ControlesBase.dtpCorto dtpFecInicial;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboGrupo;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnGrupo btnGrupo;
    }
}