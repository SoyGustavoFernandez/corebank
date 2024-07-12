namespace SolIntEls
{
    partial class frmWebReniec
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
            this.wbrDniReniec = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbrDniReniec
            // 
            this.wbrDniReniec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrDniReniec.Location = new System.Drawing.Point(0, 0);
            this.wbrDniReniec.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrDniReniec.Name = "wbrDniReniec";
            this.wbrDniReniec.Size = new System.Drawing.Size(625, 482);
            this.wbrDniReniec.TabIndex = 2;
            // 
            // frmWebReniec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 504);
            this.Controls.Add(this.wbrDniReniec);
            this.Name = "frmWebReniec";
            this.Text = "Validación DNI Reniec";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.wbrDniReniec, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrDniReniec;
    }
}

