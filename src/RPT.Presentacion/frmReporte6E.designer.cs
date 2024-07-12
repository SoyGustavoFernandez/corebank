namespace RPT.Presentacion
{
    partial class frmReporte6E
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte6E));
            this.btnExportar1 = new GEN.BotonesBase.btnExportar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnExportar1
            // 
            this.btnExportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar1.BackgroundImage")));
            this.btnExportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar1.Location = new System.Drawing.Point(211, 113);
            this.btnExportar1.Name = "btnExportar1";
            this.btnExportar1.Size = new System.Drawing.Size(60, 50);
            this.btnExportar1.TabIndex = 13;
            this.btnExportar1.Text = "E&xportar";
            this.btnExportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar1.UseVisualStyleBackColor = true;
            this.btnExportar1.Click += new System.EventHandler(this.btnExportar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(277, 113);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(145, 113);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 11;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(81, 76);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(112, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Fecha de Proceso:";
            // 
            // dtpFechaProceso
            // 
            this.dtpFechaProceso.Location = new System.Drawing.Point(199, 74);
            this.dtpFechaProceso.Name = "dtpFechaProceso";
            this.dtpFechaProceso.Size = new System.Drawing.Size(205, 20);
            this.dtpFechaProceso.TabIndex = 9;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(71, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(341, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "TASAS DE INTERES ACTIVAS DE OPERACIONES DIARIAS";
            // 
            // frmReporte6E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 229);
            this.Controls.Add(this.btnExportar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaProceso);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmReporte6E";
            this.Text = "Reporte 6E";
            this.Load += new System.EventHandler(this.frmReporte6E_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaProceso, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnExportar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnExportar btnExportar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaProceso;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}