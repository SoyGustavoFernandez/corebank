namespace CLI.Servicio
{
    partial class frmDisplayPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayPDF));
            this.panel1 = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.contPdf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 531);
            this.panel1.TabIndex = 0;
            // 
            // contPdf
            // 
            this.contPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(0, 0);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(938, 531);
            this.contPdf.TabIndex = 0;
            // 
            // frmDisplayPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 531);
            this.Controls.Add(this.panel1);
            this.Name = "frmDisplayPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDisplayPDF";
            this.Load += new System.EventHandler(this.frmDisplayPDF_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AxAcroPDFLib.AxAcroPDF contPdf;


    }
}