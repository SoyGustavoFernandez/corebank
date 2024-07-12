namespace RPT.Presentacion
{
    partial class frmReporteRR3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteRR3));
            this.dtpFecha = new GEN.ControlesBase.dtpFechaSimp(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnImprimirCajCorresp = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirBIM = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirPagoWeb = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "MMMM-yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(23, 43);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(258, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(221, 147);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(23, 80);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Oficina";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 27);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(106, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Mes de Consulta:";
            // 
            // btnImprimirCajCorresp
            // 
            this.btnImprimirCajCorresp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirCajCorresp.BackgroundImage")));
            this.btnImprimirCajCorresp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirCajCorresp.Location = new System.Drawing.Point(89, 80);
            this.btnImprimirCajCorresp.Name = "btnImprimirCajCorresp";
            this.btnImprimirCajCorresp.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirCajCorresp.TabIndex = 7;
            this.btnImprimirCajCorresp.Text = "Cajero Corresp.";
            this.btnImprimirCajCorresp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirCajCorresp.UseVisualStyleBackColor = true;
            this.btnImprimirCajCorresp.Click += new System.EventHandler(this.btnImprimirCajCorresp_Click);
            // 
            // btnImprimirBIM
            // 
            this.btnImprimirBIM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirBIM.BackgroundImage")));
            this.btnImprimirBIM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirBIM.Location = new System.Drawing.Point(155, 80);
            this.btnImprimirBIM.Name = "btnImprimirBIM";
            this.btnImprimirBIM.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirBIM.TabIndex = 8;
            this.btnImprimirBIM.Text = "BIM";
            this.btnImprimirBIM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirBIM.UseVisualStyleBackColor = true;
            this.btnImprimirBIM.Click += new System.EventHandler(this.btnImprimirBIM_Click);
            // 
            // btnImprimirPagoWeb
            // 
            this.btnImprimirPagoWeb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirPagoWeb.BackgroundImage")));
            this.btnImprimirPagoWeb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirPagoWeb.Location = new System.Drawing.Point(221, 80);
            this.btnImprimirPagoWeb.Name = "btnImprimirPagoWeb";
            this.btnImprimirPagoWeb.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirPagoWeb.TabIndex = 9;
            this.btnImprimirPagoWeb.Text = "Pagos WEB";
            this.btnImprimirPagoWeb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirPagoWeb.UseVisualStyleBackColor = true;
            this.btnImprimirPagoWeb.Click += new System.EventHandler(this.btnImprimirPagoWeb_Click);
            // 
            // frmReporteRR3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 232);
            this.Controls.Add(this.btnImprimirPagoWeb);
            this.Controls.Add(this.btnImprimirBIM);
            this.Controls.Add(this.btnImprimirCajCorresp);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmReporteRR3";
            this.Text = "Reporte RR3";
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimirCajCorresp, 0);
            this.Controls.SetChildIndex(this.btnImprimirBIM, 0);
            this.Controls.SetChildIndex(this.btnImprimirPagoWeb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.dtpFechaSimp dtpFecha;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnImprimir btnImprimirCajCorresp;
        private GEN.BotonesBase.btnImprimir btnImprimirBIM;
        private GEN.BotonesBase.btnImprimir btnImprimirPagoWeb;
    }
}