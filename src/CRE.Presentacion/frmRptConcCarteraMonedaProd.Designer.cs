namespace CRE.Presentacion
{
    partial class frmRptConcCarteraMonedaProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptConcCarteraMonedaProd));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtTEP = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtGrafico = new GEN.ControlesBase.rbtBase(this.components);
            this.dtpFecReporte = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(92, 117);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(159, 117);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtTEP);
            this.grbBase1.Controls.Add(this.rbtGrafico);
            this.grbBase1.Controls.Add(this.dtpFecReporte);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(300, 99);
            this.grbBase1.TabIndex = 13;
            this.grbBase1.TabStop = false;
            // 
            // rbtTEP
            // 
            this.rbtTEP.AutoSize = true;
            this.rbtTEP.Checked = true;
            this.rbtTEP.ForeColor = System.Drawing.Color.Navy;
            this.rbtTEP.Location = new System.Drawing.Point(29, 46);
            this.rbtTEP.Name = "rbtTEP";
            this.rbtTEP.Size = new System.Drawing.Size(168, 17);
            this.rbtTEP.TabIndex = 12;
            this.rbtTEP.TabStop = true;
            this.rbtTEP.Text = "Tasa Efectiva Promedio (TEP)";
            this.rbtTEP.UseVisualStyleBackColor = true;
            // 
            // rbtGrafico
            // 
            this.rbtGrafico.AutoSize = true;
            this.rbtGrafico.ForeColor = System.Drawing.Color.Navy;
            this.rbtGrafico.Location = new System.Drawing.Point(29, 69);
            this.rbtGrafico.Name = "rbtGrafico";
            this.rbtGrafico.Size = new System.Drawing.Size(59, 17);
            this.rbtGrafico.TabIndex = 13;
            this.rbtGrafico.Text = "Gráfico";
            this.rbtGrafico.UseVisualStyleBackColor = true;
            // 
            // dtpFecReporte
            // 
            this.dtpFecReporte.Location = new System.Drawing.Point(94, 10);
            this.dtpFecReporte.Name = "dtpFecReporte";
            this.dtpFecReporte.Size = new System.Drawing.Size(131, 20);
            this.dtpFecReporte.TabIndex = 8;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Fecha:";
            // 
            // frmRptConcCarteraMonedaProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 195);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptConcCarteraMonedaProd";
            this.Text = "Moneda Producto TEP";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecReporte;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.rbtBase rbtTEP;
        private GEN.ControlesBase.rbtBase rbtGrafico;
    }
}

