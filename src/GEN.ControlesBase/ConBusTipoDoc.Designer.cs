namespace GEN.ControlesBase
{
    partial class ConBusTipoDoc
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
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoDocumento1 = new GEN.ControlesBase.cboTipoDocumento(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo Documento:";
            // 
            // cboTipoDocumento1
            // 
            this.cboTipoDocumento1.FormattingEnabled = true;
            this.cboTipoDocumento1.Location = new System.Drawing.Point(127, 9);
            this.cboTipoDocumento1.Name = "cboTipoDocumento1";
            this.cboTipoDocumento1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento1.TabIndex = 1;
            // 
            // ConBusTipoDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboTipoDocumento1);
            this.Controls.Add(this.lblBase1);
            this.Name = "ConBusTipoDoc";
            this.Size = new System.Drawing.Size(255, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private cboTipoDocumento cboTipoDocumento1;
    }
}
