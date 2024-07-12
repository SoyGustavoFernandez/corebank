namespace ADM.Presentacion
{
    partial class frmVisitaSupervisionOperaciones
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
            this.SuspendLayout();
            // 
            // btnRevisar1
            // 
            this.btnRevisar1.Click += new System.EventHandler(this.btnRevisar1_Click);
            // 
            // frmVisitaSupervisionOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 400);
            this.Name = "frmVisitaSupervisionOperaciones";
            this.Text = "Evaluación de Visita de Supervisión Operativa";
            this.Load += new System.EventHandler(this.frmVisitaSupervisionOperaciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}