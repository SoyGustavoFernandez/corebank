namespace GEN.ControlesBase
{
    partial class conProducto
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
            this.pnlTipCred = new System.Windows.Forms.Panel();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboSubTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase20 = new GEN.ControlesBase.lblBase();
            this.cboSubProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTipCred.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTipCred
            // 
            this.pnlTipCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTipCred.Controls.Add(this.lblBase11);
            this.pnlTipCred.Controls.Add(this.cboTipoCredito);
            this.pnlTipCred.Controls.Add(this.lblBase13);
            this.pnlTipCred.Controls.Add(this.cboSubTipoCredito);
            this.pnlTipCred.Location = new System.Drawing.Point(0, 0);
            this.pnlTipCred.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTipCred.Name = "pnlTipCred";
            this.pnlTipCred.Size = new System.Drawing.Size(322, 46);
            this.pnlTipCred.TabIndex = 171;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(20, 4);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(77, 13);
            this.lblBase11.TabIndex = 65;
            this.lblBase11.Text = "Tipo Crédito";
            // 
            // cboTipoCredito
            // 
            this.cboTipoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCredito.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipoCredito, -28);
            this.cboTipoCredito.Location = new System.Drawing.Point(99, 1);
            this.cboTipoCredito.Name = "cboTipoCredito";
            this.cboTipoCredito.Size = new System.Drawing.Size(220, 21);
            this.cboTipoCredito.TabIndex = 61;
            this.cboTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoCredito_SelectedIndexChanged);
            this.cboTipoCredito.Validating += new System.ComponentModel.CancelEventHandler(this.cboTipoCredito_Validating);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(40, 27);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(57, 13);
            this.lblBase13.TabIndex = 66;
            this.lblBase13.Text = "Sub Tipo";
            // 
            // cboSubTipoCredito
            // 
            this.cboSubTipoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSubTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoCredito.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboSubTipoCredito, -28);
            this.cboSubTipoCredito.Location = new System.Drawing.Point(99, 24);
            this.cboSubTipoCredito.Name = "cboSubTipoCredito";
            this.cboSubTipoCredito.Size = new System.Drawing.Size(220, 21);
            this.cboSubTipoCredito.TabIndex = 62;
            this.cboSubTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoCredito_SelectedIndexChanged);
            this.cboSubTipoCredito.Validating += new System.ComponentModel.CancelEventHandler(this.cboSubTipoCredito_Validating);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblBase14);
            this.panel1.Controls.Add(this.cboProducto);
            this.panel1.Controls.Add(this.lblBase20);
            this.panel1.Controls.Add(this.cboSubProducto);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 46);
            this.panel1.TabIndex = 172;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(40, 4);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(57, 13);
            this.lblBase14.TabIndex = 67;
            this.lblBase14.Text = "Producto";
            // 
            // cboProducto
            // 
            this.cboProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboProducto, -28);
            this.cboProducto.Location = new System.Drawing.Point(99, 1);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(220, 21);
            this.cboProducto.TabIndex = 63;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            this.cboProducto.Validating += new System.ComponentModel.CancelEventHandler(this.cboProducto_Validating);
            // 
            // lblBase20
            // 
            this.lblBase20.AutoSize = true;
            this.lblBase20.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase20.ForeColor = System.Drawing.Color.Navy;
            this.lblBase20.Location = new System.Drawing.Point(14, 27);
            this.lblBase20.Name = "lblBase20";
            this.lblBase20.Size = new System.Drawing.Size(83, 13);
            this.lblBase20.TabIndex = 68;
            this.lblBase20.Text = "Sub Producto";
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboSubProducto, -28);
            this.cboSubProducto.Location = new System.Drawing.Point(99, 24);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(220, 21);
            this.cboSubProducto.TabIndex = 64;
            this.cboSubProducto.SelectedIndexChanged += new System.EventHandler(this.cboSubProducto_SelectedIndexChanged);
            this.cboSubProducto.Validating += new System.ComponentModel.CancelEventHandler(this.cboSubProducto_Validating);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlTipCred, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 92);
            this.tableLayoutPanel1.TabIndex = 68;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // conProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "conProducto";
            this.Size = new System.Drawing.Size(322, 92);
            this.pnlTipCred.ResumeLayout(false);
            this.pnlTipCred.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTipCred;
        private lblBase lblBase11;
        public cboProducto cboTipoCredito;
        private lblBase lblBase13;
        public cboProducto cboSubTipoCredito;
        private System.Windows.Forms.Panel panel1;
        private lblBase lblBase14;
        public cboProducto cboProducto;
        private lblBase lblBase20;
        public cboProducto cboSubProducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}
