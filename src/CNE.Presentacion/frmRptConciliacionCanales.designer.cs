namespace CNE.Presentacion
{
    partial class frmRptConciliacionCanales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptConciliacionCanales));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnReporteResultadoConciliacion = new GEN.BotonesBase.btnImprimir();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboCanalElec = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnReportePagosCargados = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 77);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Fecha:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(379, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnReporteResultadoConciliacion
            // 
            this.btnReporteResultadoConciliacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporteResultadoConciliacion.BackgroundImage")));
            this.btnReporteResultadoConciliacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReporteResultadoConciliacion.Location = new System.Drawing.Point(347, 70);
            this.btnReporteResultadoConciliacion.Name = "btnReporteResultadoConciliacion";
            this.btnReporteResultadoConciliacion.Size = new System.Drawing.Size(60, 50);
            this.btnReporteResultadoConciliacion.TabIndex = 12;
            this.btnReporteResultadoConciliacion.Text = "Imprimir";
            this.btnReporteResultadoConciliacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporteResultadoConciliacion.UseVisualStyleBackColor = true;
            this.btnReporteResultadoConciliacion.Click += new System.EventHandler(this.btnReporteResultadoConciliacion_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(72, 74);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(126, 20);
            this.dtpFecha.TabIndex = 17;
            // 
            // cboCanalElec
            // 
            this.cboCanalElec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalElec.FormattingEnabled = true;
            this.cboCanalElec.Location = new System.Drawing.Point(72, 44);
            this.cboCanalElec.Name = "cboCanalElec";
            this.cboCanalElec.Size = new System.Drawing.Size(126, 21);
            this.cboCanalElec.TabIndex = 19;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 47);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Canal:";
            // 
            // btnReportePagosCargados
            // 
            this.btnReportePagosCargados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReportePagosCargados.BackgroundImage")));
            this.btnReportePagosCargados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReportePagosCargados.Location = new System.Drawing.Point(347, 11);
            this.btnReportePagosCargados.Name = "btnReportePagosCargados";
            this.btnReportePagosCargados.Size = new System.Drawing.Size(60, 50);
            this.btnReportePagosCargados.TabIndex = 21;
            this.btnReportePagosCargados.Text = "Imprimir";
            this.btnReportePagosCargados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportePagosCargados.UseVisualStyleBackColor = true;
            this.btnReportePagosCargados.Click += new System.EventHandler(this.btnReportePagosCargados_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(228, 82);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 26);
            this.lblBase2.TabIndex = 22;
            this.lblBase2.Text = "Resultado de\r\nConciliacion Pagos";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(232, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 26);
            this.lblBase4.TabIndex = 23;
            this.lblBase4.Text = "Datos Cargados\r\ndel Canal Externo";
            this.lblBase4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblBase3);
            this.panel1.Controls.Add(this.cboCanalElec);
            this.panel1.Controls.Add(this.btnReportePagosCargados);
            this.panel1.Controls.Add(this.btnReporteResultadoConciliacion);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.lblBase4);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 139);
            this.panel1.TabIndex = 24;
            // 
            // frmRptConciliacionCanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 237);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptConciliacionCanales";
            this.Text = "Reporte del Proceso de Conciliación";
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnReporteResultadoConciliacion;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.cboBase cboCanalElec;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnReportePagosCargados;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.Panel panel1;
    }
}