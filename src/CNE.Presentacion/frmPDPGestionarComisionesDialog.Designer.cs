namespace CNE.Presentacion
{
    partial class frmPDPGestionarComisionesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPGestionarComisionesDialog));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.cboBase1 = new GEN.ControlesBase.cboBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(50, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "lblBase1";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(37, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "lblBase2";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(40, 91);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "lblBase3";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(184, 100);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            // 
            // cboBase1
            // 
            this.cboBase1.FormattingEnabled = true;
            this.cboBase1.Location = new System.Drawing.Point(127, 20);
            this.cboBase1.Name = "cboBase1";
            this.cboBase1.Size = new System.Drawing.Size(121, 21);
            this.cboBase1.TabIndex = 6;
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(117, 48);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(100, 20);
            this.txtBase1.TabIndex = 7;
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(117, 74);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(100, 20);
            this.txtBase2.TabIndex = 8;
            // 
            // frmPDPGestionarComisionesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 185);
            this.Controls.Add(this.txtBase2);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.cboBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmPDPGestionarComisionesDialog";
            this.Text = "frmPDPGestionarComisionesDialog";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.cboBase1, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.txtBase2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboBase cboBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
    }
}