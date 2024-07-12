namespace CAJ.Presentacion
{
    partial class frmRptReporteMEF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReporteMEF));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtCalendarioAdeudado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtPagoAdeudado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtDesembolsoAdeudado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtCreditoAdeudado = new GEN.ControlesBase.rbtBase(this.components);
            this.btnExportar = new GEN.BotonesBase.btnExportar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(89, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha Proceso";
            // 
            // dtpFechaProceso
            // 
            this.dtpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaProceso.Location = new System.Drawing.Point(107, 10);
            this.dtpFechaProceso.Name = "dtpFechaProceso";
            this.dtpFechaProceso.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaProceso.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(132, 149);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtCalendarioAdeudado);
            this.grbBase1.Controls.Add(this.rbtPagoAdeudado);
            this.grbBase1.Controls.Add(this.rbtDesembolsoAdeudado);
            this.grbBase1.Controls.Add(this.rbtCreditoAdeudado);
            this.grbBase1.Location = new System.Drawing.Point(11, 35);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(232, 107);
            this.grbBase1.TabIndex = 10;
            this.grbBase1.TabStop = false;
            // 
            // rbtCalendarioAdeudado
            // 
            this.rbtCalendarioAdeudado.AutoSize = true;
            this.rbtCalendarioAdeudado.ForeColor = System.Drawing.Color.Navy;
            this.rbtCalendarioAdeudado.Location = new System.Drawing.Point(11, 84);
            this.rbtCalendarioAdeudado.Name = "rbtCalendarioAdeudado";
            this.rbtCalendarioAdeudado.Size = new System.Drawing.Size(127, 17);
            this.rbtCalendarioAdeudado.TabIndex = 3;
            this.rbtCalendarioAdeudado.TabStop = true;
            this.rbtCalendarioAdeudado.Text = "Calendario Adeudado";
            this.rbtCalendarioAdeudado.UseVisualStyleBackColor = true;
            // 
            // rbtPagoAdeudado
            // 
            this.rbtPagoAdeudado.AutoSize = true;
            this.rbtPagoAdeudado.ForeColor = System.Drawing.Color.Navy;
            this.rbtPagoAdeudado.Location = new System.Drawing.Point(11, 61);
            this.rbtPagoAdeudado.Name = "rbtPagoAdeudado";
            this.rbtPagoAdeudado.Size = new System.Drawing.Size(102, 17);
            this.rbtPagoAdeudado.TabIndex = 2;
            this.rbtPagoAdeudado.TabStop = true;
            this.rbtPagoAdeudado.Text = "Pago Adeudado";
            this.rbtPagoAdeudado.UseVisualStyleBackColor = true;
            // 
            // rbtDesembolsoAdeudado
            // 
            this.rbtDesembolsoAdeudado.AutoSize = true;
            this.rbtDesembolsoAdeudado.ForeColor = System.Drawing.Color.Navy;
            this.rbtDesembolsoAdeudado.Location = new System.Drawing.Point(11, 38);
            this.rbtDesembolsoAdeudado.Name = "rbtDesembolsoAdeudado";
            this.rbtDesembolsoAdeudado.Size = new System.Drawing.Size(135, 17);
            this.rbtDesembolsoAdeudado.TabIndex = 1;
            this.rbtDesembolsoAdeudado.TabStop = true;
            this.rbtDesembolsoAdeudado.Text = "Desembolso Adeudado";
            this.rbtDesembolsoAdeudado.UseVisualStyleBackColor = true;
            // 
            // rbtCreditoAdeudado
            // 
            this.rbtCreditoAdeudado.AutoSize = true;
            this.rbtCreditoAdeudado.ForeColor = System.Drawing.Color.Navy;
            this.rbtCreditoAdeudado.Location = new System.Drawing.Point(11, 15);
            this.rbtCreditoAdeudado.Name = "rbtCreditoAdeudado";
            this.rbtCreditoAdeudado.Size = new System.Drawing.Size(115, 17);
            this.rbtCreditoAdeudado.TabIndex = 0;
            this.rbtCreditoAdeudado.TabStop = true;
            this.rbtCreditoAdeudado.Text = "Créditos Adeudado";
            this.rbtCreditoAdeudado.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar.Location = new System.Drawing.Point(63, 149);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 50);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "E&xportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmRptReporteMEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 224);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dtpFechaProceso);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRptReporteMEF";
            this.Text = "Reporte Adeudado MEF";
            this.Load += new System.EventHandler(this.frmRptReporteMEF_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaProceso, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaProceso;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtCalendarioAdeudado;
        private GEN.ControlesBase.rbtBase rbtPagoAdeudado;
        private GEN.ControlesBase.rbtBase rbtDesembolsoAdeudado;
        private GEN.ControlesBase.rbtBase rbtCreditoAdeudado;
        private GEN.BotonesBase.btnExportar btnExportar;
    }
}