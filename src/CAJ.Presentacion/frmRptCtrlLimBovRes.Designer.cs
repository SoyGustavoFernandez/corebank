namespace CAJ.Presentacion
{
    partial class frmRptCtrlLimBovRes
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
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboMeses1 = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conRptParamCaj1
            // 
            this.conRptParamCaj1.Location = new System.Drawing.Point(0, -1);
            this.conRptParamCaj1.Name = "conRptParamCaj1";
            this.conRptParamCaj1.Size = new System.Drawing.Size(377, 174);
            this.conRptParamCaj1.TabIndex = 2;
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(3, 21);
            this.nudAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(160, 20);
            this.nudAnio.TabIndex = 3;
            this.nudAnio.Value = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboMeses1);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.nudAnio);
            this.panel1.Location = new System.Drawing.Point(4, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 84);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // cboMeses1
            // 
            this.cboMeses1.FormattingEnabled = true;
            this.cboMeses1.Location = new System.Drawing.Point(3, 60);
            this.cboMeses1.Name = "cboMeses1";
            this.cboMeses1.Size = new System.Drawing.Size(160, 21);
            this.cboMeses1.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Mes:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 5);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Año:";
            // 
            // frmRptCtrlLimBovRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 197);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.conRptParamCaj1);
            this.Name = "frmRptCtrlLimBovRes";
            this.Text = "Reporte Acumulado de Cierres de Bóveda";
            this.Controls.SetChildIndex(this.conRptParamCaj1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conRptParamCaj conRptParamCaj1;
        private GEN.ControlesBase.nudBase nudAnio;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.cboMeses cboMeses1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}