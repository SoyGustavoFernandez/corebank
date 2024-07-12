namespace GEN.ControlesBase
{
    partial class ConCreditoPrimeraCuota
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtpFecha = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.CustomFormat = "dd/MMM/yyyy";
            this.dtpFecha.Location = new System.Drawing.Point(74, 1);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(212, 20);
            this.dtpFecha.TabIndex = 21;
            this.dtpFecha.Value = new System.DateTime(2012, 5, 31, 17, 25, 32, 0);
            // 
            // lblBase7
            // 
            this.lblBase7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(4, 5);
            this.lblBase7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(68, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "1ra. Cuota";
            // 
            // ConCreditoPrimeraCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBase7);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConCreditoPrimeraCuota";
            this.Size = new System.Drawing.Size(287, 22);
            this.Load += new System.EventHandler(this.ConCreditoPrimeraCuota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private lblBase lblBase7;
        public dtLargoBase dtpFecha;
    }
}
