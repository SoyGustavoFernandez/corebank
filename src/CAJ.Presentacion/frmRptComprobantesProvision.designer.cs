namespace CAJ.Presentacion
{
    partial class frmRptComprobantesProvision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptComprobantesProvision));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago1 = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 109);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(43, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Desde";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(112, 106);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaIni.TabIndex = 5;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(129, 159);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 135);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(39, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(112, 131);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(90, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Comprobante:";
            // 
            // cboTipoComprobantePago1
            // 
            this.cboTipoComprobantePago1.FormattingEnabled = true;
            this.cboTipoComprobantePago1.Location = new System.Drawing.Point(112, 54);
            this.cboTipoComprobantePago1.Name = "cboTipoComprobantePago1";
            this.cboTipoComprobantePago1.Size = new System.Drawing.Size(252, 21);
            this.cboTipoComprobantePago1.TabIndex = 1;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(112, 80);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(252, 21);
            this.cboAgencia1.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 83);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Agencia:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(195, 159);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(361, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "LISTADO DE COMPROBANTES PROVISIONADOS Y PAGADOS ";
            // 
            // frmRptComprobantesProvision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 237);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.cboTipoComprobantePago1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmRptComprobantesProvision";
            this.Text = "Reporte de Comprobantes con Provisión";
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipoComprobantePago1, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}