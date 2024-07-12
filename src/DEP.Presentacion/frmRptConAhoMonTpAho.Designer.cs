namespace DEP.Presentacion
{
    partial class frmRptConAhoMonTpAho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptConAhoMonTpAho));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaCorte = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImpResumen = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(60, 31);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha de proceso:";
            // 
            // dtpFechaCorte
            // 
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Location = new System.Drawing.Point(176, 28);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaCorte.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(207, 70);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Detalle";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(273, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImpResumen
            // 
            this.btnImpResumen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpResumen.BackgroundImage")));
            this.btnImpResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpResumen.Location = new System.Drawing.Point(141, 70);
            this.btnImpResumen.Name = "btnImpResumen";
            this.btnImpResumen.Size = new System.Drawing.Size(60, 50);
            this.btnImpResumen.TabIndex = 6;
            this.btnImpResumen.Text = "&Resumen";
            this.btnImpResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpResumen.UseVisualStyleBackColor = true;
            this.btnImpResumen.Click += new System.EventHandler(this.btnImpResumen_Click);
            // 
            // frmRptConAhoMonTpAho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 152);
            this.Controls.Add(this.btnImpResumen);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dtpFechaCorte);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRptConAhoMonTpAho";
            this.Text = "Reporte de concentración de ahorros por moneda";
            this.Load += new System.EventHandler(this.frmRptConAhoMonTpAho_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaCorte, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImpResumen, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaCorte;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImpResumen;
    }
}