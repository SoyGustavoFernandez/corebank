namespace RPT.Presentacion
{
    partial class frmSbsAnexo17B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSbsAnexo17B));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboLimiteCoberFSD = new GEN.ControlesBase.cboBase(this.components);
            this.btnExporTxt1 = new GEN.BotonesBase.btnExporTxt();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(261, 26);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "HOJA DE CONTROL DE PAGO DE PRIMAS AL\r\nFONDO DE SEGURO DE DEPOSITOS";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(172, 107);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(52, 107);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(34, 65);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Periodo:";
            // 
            // cboLimiteCoberFSD
            // 
            this.cboLimiteCoberFSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimiteCoberFSD.FormattingEnabled = true;
            this.cboLimiteCoberFSD.Location = new System.Drawing.Point(97, 61);
            this.cboLimiteCoberFSD.Name = "cboLimiteCoberFSD";
            this.cboLimiteCoberFSD.Size = new System.Drawing.Size(154, 21);
            this.cboLimiteCoberFSD.Sorted = true;
            this.cboLimiteCoberFSD.TabIndex = 19;
            // 
            // btnExporTxt1
            // 
            this.btnExporTxt1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporTxt1.BackgroundImage")));
            this.btnExporTxt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporTxt1.Location = new System.Drawing.Point(112, 107);
            this.btnExporTxt1.Name = "btnExporTxt1";
            this.btnExporTxt1.Size = new System.Drawing.Size(60, 50);
            this.btnExporTxt1.TabIndex = 20;
            this.btnExporTxt1.Text = "A&rchivo";
            this.btnExporTxt1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporTxt1.UseVisualStyleBackColor = true;
            this.btnExporTxt1.Click += new System.EventHandler(this.btnExporTxt1_Click);
            // 
            // frmSbsAnexo17B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.btnExporTxt1);
            this.Controls.Add(this.cboLimiteCoberFSD);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmSbsAnexo17B";
            this.Text = "Anexo 17B";
            this.Load += new System.EventHandler(this.frmSbsAnexo17B_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboLimiteCoberFSD, 0);
            this.Controls.SetChildIndex(this.btnExporTxt1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboLimiteCoberFSD;
        private GEN.BotonesBase.btnExporTxt btnExporTxt1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

