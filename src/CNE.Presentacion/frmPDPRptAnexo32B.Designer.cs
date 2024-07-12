namespace CNE.Presentacion
{
    partial class frmPDPRptAnexo32B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPRptAnexo32B));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnExportar = new GEN.BotonesBase.btnExportar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.cboTipoReporte = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dtpFechaFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(277, 115);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar.Location = new System.Drawing.Point(211, 115);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 50);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "E&xportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(145, 115);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoReporte.FormattingEnabled = true;
            this.cboTipoReporte.Location = new System.Drawing.Point(161, 25);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Size = new System.Drawing.Size(121, 21);
            this.cboTipoReporte.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(52, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(103, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Tipo de Reporte:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(75, 54);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(80, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.CustomFormat = "MM/yyyy";
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicial.Location = new System.Drawing.Point(161, 52);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.ShowUpDown = true;
            this.dtpFechaInicial.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaInicial.TabIndex = 6;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "MM/yyyy";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(161, 78);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.ShowUpDown = true;
            this.dtpFechaFinal.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaFinal.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(90, 80);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(65, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Fecha Fin:";
            // 
            // frmPDPRptAnexo32B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 197);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoReporte);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmPDPRptAnexo32B";
            this.Text = "Reporte Anexo 32B";
            this.Load += new System.EventHandler(this.frmPDPRptAnexo32B_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.cboTipoReporte, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicial, 0);
            this.Controls.SetChildIndex(this.dtpFechaFinal, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnExportar btnExportar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboBase cboTipoReporte;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaInicial;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.dtpCorto dtpFechaFinal;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}