namespace GEN.ControlesBase
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.sstBase = new System.Windows.Forms.StatusStrip();
            this.lbLogo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbMidle = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNomFrm = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttpControles = new System.Windows.Forms.ToolTip(this.components);
            this.sstBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // sstBase
            // 
            this.sstBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbLogo,
            this.lbMidle,
            this.lblNomFrm});
            this.sstBase.Location = new System.Drawing.Point(0, 556);
            this.sstBase.Name = "sstBase";
            this.sstBase.Size = new System.Drawing.Size(726, 22);
            this.sstBase.TabIndex = 1;
            this.sstBase.Text = "statusStrip1";
            // 
            // lbLogo
            // 
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(0, 17);
            // 
            // lbMidle
            // 
            this.lbMidle.Name = "lbMidle";
            this.lbMidle.Size = new System.Drawing.Size(649, 17);
            this.lbMidle.Spring = true;
            // 
            // lblNomFrm
            // 
            this.lblNomFrm.Name = "lblNomFrm";
            this.lblNomFrm.Size = new System.Drawing.Size(62, 17);
            this.lblNomFrm.Text = "NomForm";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(726, 578);
            this.Controls.Add(this.sstBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBase";
            this.Text = "frmBase";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBase_FormClosed);
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.sstBase.ResumeLayout(false);
            this.sstBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolStripStatusLabel lbLogo;
        protected System.Windows.Forms.ToolStripStatusLabel lbMidle;
        protected System.Windows.Forms.ToolStripStatusLabel lblNomFrm;
        public System.Windows.Forms.StatusStrip sstBase;
        private System.Windows.Forms.ToolTip ttpControles;
    }
}