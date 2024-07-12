namespace CNT.Presentacion
{
    partial class frmBalComActPasPat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalComActPasPat));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSistema = new GEN.ControlesBase.dtpCorto(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.NumDig = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(122, 136);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(188, 136);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 57);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Moneda:";
            // 
            // dtpFechaSistema
            // 
            this.dtpFechaSistema.Location = new System.Drawing.Point(119, 25);
            this.dtpFechaSistema.Name = "dtpFechaSistema";
            this.dtpFechaSistema.Size = new System.Drawing.Size(155, 20);
            this.dtpFechaSistema.TabIndex = 16;
            // 
            // NumDig
            // 
            this.NumDig.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Location = new System.Drawing.Point(119, 82);
            this.NumDig.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Name = "NumDig";
            this.NumDig.Size = new System.Drawing.Size(154, 20);
            this.NumDig.TabIndex = 17;
            this.NumDig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumDig.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 86);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(100, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Numero Dígitos:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(119, 54);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(155, 21);
            this.cboMoneda.TabIndex = 25;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 112);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 27;
            this.lblBase3.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(119, 108);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(154, 21);
            this.cboAgencia.TabIndex = 26;
            // 
            // frmBalComActPasPat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 215);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.NumDig);
            this.Controls.Add(this.dtpFechaSistema);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmBalComActPasPat";
            this.Text = "Balance Comprobación Cuentas EEFF";
            this.Load += new System.EventHandler(this.frmBalanceGeneral_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtpFechaSistema, 0);
            this.Controls.SetChildIndex(this.NumDig, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpFechaSistema;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.nudBase NumDig;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgencia;
    }
}