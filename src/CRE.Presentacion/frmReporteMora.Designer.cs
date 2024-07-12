namespace CRE.Presentacion
{
    partial class frmReporteMora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMora));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.chcReporteEnLinea = new System.Windows.Forms.CheckBox();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpPeriodo = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(136, 87);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 2;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(203, 87);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // chcReporteEnLinea
            // 
            this.chcReporteEnLinea.AutoSize = true;
            this.chcReporteEnLinea.Checked = true;
            this.chcReporteEnLinea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcReporteEnLinea.Location = new System.Drawing.Point(92, 12);
            this.chcReporteEnLinea.Name = "chcReporteEnLinea";
            this.chcReporteEnLinea.Size = new System.Drawing.Size(104, 17);
            this.chcReporteEnLinea.TabIndex = 5;
            this.chcReporteEnLinea.Text = "Reporte en linea";
            this.chcReporteEnLinea.UseVisualStyleBackColor = true;
            this.chcReporteEnLinea.CheckedChanged += new System.EventHandler(this.chcReporteEnLinea_CheckedChanged);
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.lblBase1);
            this.grbDatos.Controls.Add(this.dtpPeriodo);
            this.grbDatos.Enabled = false;
            this.grbDatos.Location = new System.Drawing.Point(23, 35);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(251, 42);
            this.grbDatos.TabIndex = 4;
            this.grbDatos.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(38, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Periodo:";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.CustomFormat = " MM/yyyy";
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(99, 16);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(126, 20);
            this.dtpPeriodo.TabIndex = 0;
            // 
            // frmReporteMora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 166);
            this.Controls.Add(this.chcReporteEnLinea);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmReporteMora";
            this.Text = "Reporte de mora";
            this.Load += new System.EventHandler(this.frmReporteMora_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbDatos, 0);
            this.Controls.SetChildIndex(this.chcReporteEnLinea, 0);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.CheckBox chcReporteEnLinea;
        private System.Windows.Forms.GroupBox grbDatos;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpPeriodo;
    }
}