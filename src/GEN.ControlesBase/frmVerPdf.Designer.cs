namespace GEN.ControlesBase
{
    partial class frmVerPdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerPdf));
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(0, 2);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(849, 560);
            this.contPdf.TabIndex = 2;
            // 
            // frmVerPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 587);
            this.Controls.Add(this.contPdf);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVerPdf";
            this.Text = "Ver documento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVerPdf_FormClosing);
            this.Load += new System.EventHandler(this.frmVerPdf_Load);
            this.Controls.SetChildIndex(this.contPdf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF contPdf;

    }
}