namespace GEN.ControlesBase
{
    partial class frmBusRepo
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
            this.conBusRep1 = new GEN.ControlesBase.ConBusRep();
            this.SuspendLayout();
            // 
            // conBusRep1
            // 
            this.conBusRep1.BackColor = System.Drawing.Color.Transparent;
            this.conBusRep1.Location = new System.Drawing.Point(-1, 1);
            this.conBusRep1.Name = "conBusRep1";
            this.conBusRep1.Size = new System.Drawing.Size(355, 237);
            this.conBusRep1.TabIndex = 0;
            // 
            // frmBusRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 238);
            this.Controls.Add(this.conBusRep1);
            this.Name = "frmBusRepo";
            this.Text = "frmBusRepo";
            this.ResumeLayout(false);

        }

        #endregion

        private ConBusRep conBusRep1;
    }
}