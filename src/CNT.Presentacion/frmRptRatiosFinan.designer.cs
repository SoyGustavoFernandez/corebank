namespace CNT.Presentacion
{
    partial class frmRptRatiosFinan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRatiosFinan));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSistema = new GEN.ControlesBase.dtpCorto(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.btnGenerar1 = new GEN.BotonesBase.btnGenerar();
            this.btnEpgOfi = new GEN.BotonesBase.btnBlanco();
            this.chcDistri = new GEN.ControlesBase.chcBase(this.components);
            this.chcOriginal = new GEN.ControlesBase.chcBase(this.components);
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(41, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha:";
            // 
            // dtpFechaSistema
            // 
            this.dtpFechaSistema.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSistema.Location = new System.Drawing.Point(101, 16);
            this.dtpFechaSistema.Name = "dtpFechaSistema";
            this.dtpFechaSistema.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaSistema.TabIndex = 16;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(287, 102);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(219, 102);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(41, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(101, 41);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(161, 21);
            this.cboAgencia.TabIndex = 19;
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(15, 102);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 21;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // btnGenerar1
            // 
            this.btnGenerar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar1.BackgroundImage")));
            this.btnGenerar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar1.Location = new System.Drawing.Point(83, 102);
            this.btnGenerar1.Name = "btnGenerar1";
            this.btnGenerar1.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar1.TabIndex = 22;
            this.btnGenerar1.Text = "Gene&rar";
            this.btnGenerar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar1.UseVisualStyleBackColor = true;
            this.btnGenerar1.Click += new System.EventHandler(this.btnGenerar1_Click);
            // 
            // btnEpgOfi
            // 
            this.btnEpgOfi.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnEpgOfi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEpgOfi.Location = new System.Drawing.Point(151, 102);
            this.btnEpgOfi.Name = "btnEpgOfi";
            this.btnEpgOfi.Size = new System.Drawing.Size(60, 50);
            this.btnEpgOfi.TabIndex = 23;
            this.btnEpgOfi.Text = "&EPG Ofi";
            this.btnEpgOfi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEpgOfi.UseVisualStyleBackColor = true;
            this.btnEpgOfi.Click += new System.EventHandler(this.btnEpgOfi_Click);
            // 
            // chcDistri
            // 
            this.chcDistri.AutoSize = true;
            this.chcDistri.Checked = true;
            this.chcDistri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcDistri.Location = new System.Drawing.Point(112, 74);
            this.chcDistri.Name = "chcDistri";
            this.chcDistri.Size = new System.Drawing.Size(75, 17);
            this.chcDistri.TabIndex = 26;
            this.chcDistri.Text = "Distribuido";
            this.chcDistri.UseVisualStyleBackColor = true;
            this.chcDistri.CheckedChanged += new System.EventHandler(this.chcDistri_CheckedChanged);
            // 
            // chcOriginal
            // 
            this.chcOriginal.AutoSize = true;
            this.chcOriginal.Location = new System.Drawing.Point(189, 74);
            this.chcOriginal.Name = "chcOriginal";
            this.chcOriginal.Size = new System.Drawing.Size(61, 17);
            this.chcOriginal.TabIndex = 27;
            this.chcOriginal.Text = "Original";
            this.chcOriginal.UseVisualStyleBackColor = true;
            this.chcOriginal.CheckedChanged += new System.EventHandler(this.chcOriginal_CheckedChanged);
            // 
            // frmRptRatiosFinan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 186);
            this.Controls.Add(this.chcOriginal);
            this.Controls.Add(this.chcDistri);
            this.Controls.Add(this.btnEpgOfi);
            this.Controls.Add(this.btnGenerar1);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.dtpFechaSistema);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmRptRatiosFinan";
            this.Text = "Ratios e Indicadores Financieros";
            this.Load += new System.EventHandler(this.frmRptRatiosFinan_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFechaSistema, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.btnGenerar1, 0);
            this.Controls.SetChildIndex(this.btnEpgOfi, 0);
            this.Controls.SetChildIndex(this.chcDistri, 0);
            this.Controls.SetChildIndex(this.chcOriginal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFechaSistema;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.BotonesBase.btnGenerar btnGenerar1;
        private GEN.BotonesBase.btnBlanco btnEpgOfi;
        private GEN.ControlesBase.chcBase chcDistri;
        private GEN.ControlesBase.chcBase chcOriginal;
    }
}