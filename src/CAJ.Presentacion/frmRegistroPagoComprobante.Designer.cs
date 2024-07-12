namespace CAJ.Presentacion
{
    partial class frmRegistroPagoComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroPagoComprobante));
            this.btnPagar1 = new GEN.BotonesBase.btnPagar();
            this.SuspendLayout();
            // 
            // btnPagar1
            // 
            this.btnPagar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPagar1.BackgroundImage")));
            this.btnPagar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPagar1.Location = new System.Drawing.Point(679, 504);
            this.btnPagar1.Name = "btnPagar1";
            this.btnPagar1.Size = new System.Drawing.Size(60, 50);
            this.btnPagar1.TabIndex = 25;
            this.btnPagar1.Text = "&Pagar";
            this.btnPagar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPagar1.UseVisualStyleBackColor = true;
            this.btnPagar1.Click += new System.EventHandler(this.btnPagar1_Click);
            // 
            // frmRegistroPagoComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 579);
            this.Controls.Add(this.btnPagar1);
            this.Name = "frmRegistroPagoComprobante";
            this.Text = "Pago de comprobantes de la Rendición";
            this.Load += new System.EventHandler(this.frmRegistroPagoComprobante_Load);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnPagar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnPagar btnPagar1;


    }
}