namespace GEN.ControlesBase
{
    partial class ConCreditoPeriodo
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cboTipoPeriodo = new GEN.ControlesBase.cboTipoPeriodo(this.components);
            this.nudDia = new GEN.ControlesBase.nudBase(this.components);
            this.cboPeriodoCredito = new GEN.ControlesBase.cboPeriodoCredito(this.components);
            this.lblBaseCustom40 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblPeriodo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDia)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.cboTipoPeriodo);
            this.flowLayoutPanel1.Controls.Add(this.nudDia);
            this.flowLayoutPanel1.Controls.Add(this.cboPeriodoCredito);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(85, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(112, 44);
            this.flowLayoutPanel1.TabIndex = 163;
            // 
            // cboTipoPeriodo
            // 
            this.cboTipoPeriodo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTipoPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPeriodo.FormattingEnabled = true;
            this.cboTipoPeriodo.Location = new System.Drawing.Point(1, 0);
            this.cboTipoPeriodo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.cboTipoPeriodo.Name = "cboTipoPeriodo";
            this.cboTipoPeriodo.Size = new System.Drawing.Size(110, 21);
            this.cboTipoPeriodo.TabIndex = 152;
            // 
            // nudDia
            // 
            this.nudDia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudDia.Enabled = false;
            this.nudDia.Location = new System.Drawing.Point(1, 23);
            this.nudDia.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.nudDia.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nudDia.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
            this.nudDia.Name = "nudDia";
            this.nudDia.Size = new System.Drawing.Size(50, 20);
            this.nudDia.TabIndex = 153;
            this.nudDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDia.Enter += new System.EventHandler(this.nudDia_Enter);
            this.nudDia.Leave += new System.EventHandler(this.nudDia_Leave);
            // 
            // cboPeriodoCredito
            // 
            this.cboPeriodoCredito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPeriodoCredito.FormattingEnabled = true;
            this.cboPeriodoCredito.Location = new System.Drawing.Point(53, 23);
            this.cboPeriodoCredito.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.cboPeriodoCredito.Name = "cboPeriodoCredito";
            this.cboPeriodoCredito.Size = new System.Drawing.Size(58, 21);
            this.cboPeriodoCredito.TabIndex = 159;
            this.cboPeriodoCredito.Visible = false;
            // 
            // lblBaseCustom40
            // 
            this.lblBaseCustom40.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseCustom40.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom40.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom40.Location = new System.Drawing.Point(7, 5);
            this.lblBaseCustom40.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBaseCustom40.Name = "lblBaseCustom40";
            this.lblBaseCustom40.Size = new System.Drawing.Size(76, 15);
            this.lblBaseCustom40.TabIndex = 157;
            this.lblBaseCustom40.Text = "Tipo";
            this.lblBaseCustom40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodo.Location = new System.Drawing.Point(8, 28);
            this.lblPeriodo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(76, 15);
            this.lblPeriodo.TabIndex = 158;
            this.lblPeriodo.Text = "Dìa de Pago";
            this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConCreditoPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblBaseCustom40);
            this.Controls.Add(this.lblPeriodo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConCreditoPeriodo";
            this.Size = new System.Drawing.Size(198, 46);
            this.Load += new System.EventHandler(this.ConCreditoPeriodo_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nudBase nudDia;
        private lblBaseCustom lblBaseCustom40;
        private lblBaseCustom lblPeriodo;
        private cboPeriodoCredito cboPeriodoCredito;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public cboTipoPeriodo cboTipoPeriodo;

    }
}
