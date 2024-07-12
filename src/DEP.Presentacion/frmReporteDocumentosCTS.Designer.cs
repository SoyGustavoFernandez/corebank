namespace DEP.Presentacion
{
    partial class frmReporteDocumentosCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteDocumentosCTS));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboEstadoRegDocCTS = new System.Windows.Forms.ComboBox();
            this.lblEstadoRegDocCTS = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(74, 166);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(171, 166);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboEstadoRegDocCTS
            // 
            this.cboEstadoRegDocCTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoRegDocCTS.FormattingEnabled = true;
            this.cboEstadoRegDocCTS.Location = new System.Drawing.Point(76, 16);
            this.cboEstadoRegDocCTS.Name = "cboEstadoRegDocCTS";
            this.cboEstadoRegDocCTS.Size = new System.Drawing.Size(193, 21);
            this.cboEstadoRegDocCTS.TabIndex = 5;
            // 
            // lblEstadoRegDocCTS
            // 
            this.lblEstadoRegDocCTS.AutoSize = true;
            this.lblEstadoRegDocCTS.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstadoRegDocCTS.ForeColor = System.Drawing.Color.Navy;
            this.lblEstadoRegDocCTS.Location = new System.Drawing.Point(20, 20);
            this.lblEstadoRegDocCTS.Name = "lblEstadoRegDocCTS";
            this.lblEstadoRegDocCTS.Size = new System.Drawing.Size(50, 13);
            this.lblEstadoRegDocCTS.TabIndex = 6;
            this.lblEstadoRegDocCTS.Text = "Estado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Agencia:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFechaIni);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpFechaFin);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(12, 76);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(257, 75);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango de Fechas:";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(83, 19);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(124, 20);
            this.dtpFechaIni.TabIndex = 10;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(83, 48);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(124, 20);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(64, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Fecha Ini:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 51);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Fecha Fin:";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(76, 44);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(143, 21);
            this.cboAgencia1.TabIndex = 15;
            // 
            // frmReporteDocumentosCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 257);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblEstadoRegDocCTS);
            this.Controls.Add(this.cboEstadoRegDocCTS);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmReporteDocumentosCTS";
            this.Text = "Reporte de Documentos CTS";
            this.Load += new System.EventHandler(this.frmReporteDocumentosCTS_Load);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboEstadoRegDocCTS, 0);
            this.Controls.SetChildIndex(this.lblEstadoRegDocCTS, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.ComboBox cboEstadoRegDocCTS;
        private GEN.ControlesBase.lblBase lblEstadoRegDocCTS;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
    }
}