namespace CRE.Presentacion
{
    partial class frmReporteCartasFianzaVenYXVen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCartasFianzaVenYXVen));
            this.rbPorVencer = new System.Windows.Forms.RadioButton();
            this.rbVencidas = new System.Windows.Forms.RadioButton();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // rbPorVencer
            // 
            this.rbPorVencer.AutoSize = true;
            this.rbPorVencer.Checked = true;
            this.rbPorVencer.Location = new System.Drawing.Point(26, 21);
            this.rbPorVencer.Name = "rbPorVencer";
            this.rbPorVencer.Size = new System.Drawing.Size(143, 17);
            this.rbPorVencer.TabIndex = 2;
            this.rbPorVencer.TabStop = true;
            this.rbPorVencer.Text = "Cartas Fianza por vencer";
            this.rbPorVencer.UseVisualStyleBackColor = true;
            // 
            // rbVencidas
            // 
            this.rbVencidas.AutoSize = true;
            this.rbVencidas.Location = new System.Drawing.Point(26, 44);
            this.rbVencidas.Name = "rbVencidas";
            this.rbVencidas.Size = new System.Drawing.Size(132, 17);
            this.rbVencidas.TabIndex = 3;
            this.rbVencidas.Text = "Cartas fianza vencidas";
            this.rbVencidas.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(163, 74);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(97, 74);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmReporteCartasFianzaVenYXVen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 168);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.rbVencidas);
            this.Controls.Add(this.rbPorVencer);
            this.Name = "frmReporteCartasFianzaVenYXVen";
            this.Text = "Reporte Cartas Fianza Vencidas y por vencer";
            this.Controls.SetChildIndex(this.rbPorVencer, 0);
            this.Controls.SetChildIndex(this.rbVencidas, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPorVencer;
        private System.Windows.Forms.RadioButton rbVencidas;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;


    }
}