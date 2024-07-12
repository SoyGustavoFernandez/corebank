namespace GEN.ControlesBase
{
    partial class frmReporteLocal
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
            this.rpvReporteLocal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvReporteLocal
            // 
            this.rpvReporteLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvReporteLocal.Location = new System.Drawing.Point(0, 0);
            this.rpvReporteLocal.Name = "rpvReporteLocal";
            this.rpvReporteLocal.ShowRefreshButton = false;
            this.rpvReporteLocal.Size = new System.Drawing.Size(1008, 540);
            this.rpvReporteLocal.TabIndex = 2;
            // 
            // frmReporteLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.rpvReporteLocal);
            this.Name = "frmReporteLocal";
            this.Text = "CoreBank - Reporteador";
            this.Load += new System.EventHandler(this.frmReporteLocal_Load);
            this.Controls.SetChildIndex(this.rpvReporteLocal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rpvReporteLocal;


    }
}

