namespace CAJ.Presentacion
{
    partial class frmRptCtrlLimBov
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
            this.conRptParamCaj1 = new GEN.ControlesBase.conRptParamCaj();
            this.cboExcepcion = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // conRptParamCaj1
            // 
            this.conRptParamCaj1.Location = new System.Drawing.Point(0, 0);
            this.conRptParamCaj1.Name = "conRptParamCaj1";
            this.conRptParamCaj1.Size = new System.Drawing.Size(377, 174);
            this.conRptParamCaj1.TabIndex = 2;
            // 
            // cboExcepcion
            // 
            this.cboExcepcion.FormattingEnabled = true;
            this.cboExcepcion.Location = new System.Drawing.Point(181, 67);
            this.cboExcepcion.Name = "cboExcepcion";
            this.cboExcepcion.Size = new System.Drawing.Size(183, 21);
            this.cboExcepcion.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(178, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Excepciones:";
            // 
            // frmRptCtrlLimBov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 198);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboExcepcion);
            this.Controls.Add(this.conRptParamCaj1);
            this.Name = "frmRptCtrlLimBov";
            this.Text = "Control Límites Bóveda";
            this.Controls.SetChildIndex(this.conRptParamCaj1, 0);
            this.Controls.SetChildIndex(this.cboExcepcion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conRptParamCaj conRptParamCaj1;
        private GEN.ControlesBase.cboBase cboExcepcion;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}