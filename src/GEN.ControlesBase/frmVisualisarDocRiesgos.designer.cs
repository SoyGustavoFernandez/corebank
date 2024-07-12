namespace GEN.ControlesBase
{
    partial class frmVisualisarDocRiesgos
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
            
            // frmVisualisarDocRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 429);
           
            this.Name = "frmVisualisarDocRiesgos";
            this.Text = "frmVisualisarDocRiesgos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVisualisarDocRiesgos_FormClosed);
            this.Load += new System.EventHandler(this.frmVisualisarDocRiesgos_Load);
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}