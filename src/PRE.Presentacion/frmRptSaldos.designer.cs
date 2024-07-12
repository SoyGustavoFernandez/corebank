namespace PRE.Presentacion
{
    partial class frmRptSaldos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSaldos));
            this.lblPlanificacion = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal1 = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMesDesde = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMesHasta = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstructuraPresupuesto1 = new GEN.ControlesBase.cboEstructuraPresupuesto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipoReporte = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlanificacion
            // 
            this.lblPlanificacion.AutoSize = true;
            this.lblPlanificacion.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanificacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPlanificacion.Location = new System.Drawing.Point(209, 14);
            this.lblPlanificacion.Name = "lblPlanificacion";
            this.lblPlanificacion.Size = new System.Drawing.Size(91, 14);
            this.lblPlanificacion.TabIndex = 3;
            this.lblPlanificacion.Text = "Planificación";
            // 
            // cboPeriodoPresupuestal1
            // 
            this.cboPeriodoPresupuestal1.FormattingEnabled = true;
            this.cboPeriodoPresupuestal1.Location = new System.Drawing.Point(93, 12);
            this.cboPeriodoPresupuestal1.Name = "cboPeriodoPresupuestal1";
            this.cboPeriodoPresupuestal1.Size = new System.Drawing.Size(92, 21);
            this.cboPeriodoPresupuestal1.TabIndex = 0;
            this.cboPeriodoPresupuestal1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(32, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Periodo:";
            // 
            // cboMesDesde
            // 
            this.cboMesDesde.FormattingEnabled = true;
            this.cboMesDesde.Location = new System.Drawing.Point(87, 17);
            this.cboMesDesde.Name = "cboMesDesde";
            this.cboMesDesde.Size = new System.Drawing.Size(121, 21);
            this.cboMesDesde.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(33, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Desde:";
            // 
            // cboMesHasta
            // 
            this.cboMesHasta.FormattingEnabled = true;
            this.cboMesHasta.Location = new System.Drawing.Point(87, 48);
            this.cboMesHasta.Name = "cboMesHasta";
            this.cboMesHasta.Size = new System.Drawing.Size(121, 21);
            this.cboMesHasta.TabIndex = 6;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(37, 51);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Hasta:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(193, 184);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(259, 184);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboMesDesde);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.cboMesHasta);
            this.grbBase2.Location = new System.Drawing.Point(12, 101);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(307, 77);
            this.grbBase2.TabIndex = 9;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Rango de meses";
            // 
            // cboEstructuraPresupuesto1
            // 
            this.cboEstructuraPresupuesto1.FormattingEnabled = true;
            this.cboEstructuraPresupuesto1.Location = new System.Drawing.Point(93, 42);
            this.cboEstructuraPresupuesto1.Name = "cboEstructuraPresupuesto1";
            this.cboEstructuraPresupuesto1.Size = new System.Drawing.Size(160, 21);
            this.cboEstructuraPresupuesto1.TabIndex = 12;
            this.cboEstructuraPresupuesto1.SelectedIndexChanged += new System.EventHandler(this.cboEstructuraPresupuesto1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(56, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(31, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Por:";
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.FormattingEnabled = true;
            this.cboTipoReporte.Location = new System.Drawing.Point(93, 74);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Size = new System.Drawing.Size(160, 21);
            this.cboTipoReporte.TabIndex = 13;
            this.cboTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cboTipoReporte_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 77);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(75, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Reporte de:";
            // 
            // frmRptSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 260);
            this.Controls.Add(this.lblPlanificacion);
            this.Controls.Add(this.cboPeriodoPresupuestal1);
            this.Controls.Add(this.cboTipoReporte);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboEstructuraPresupuesto1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmRptSaldos";
            this.Text = "Reporte saldos";
            this.Load += new System.EventHandler(this.frmRptSaldoMensual_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboEstructuraPresupuesto1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoReporte, 0);
            this.Controls.SetChildIndex(this.cboPeriodoPresupuestal1, 0);
            this.Controls.SetChildIndex(this.lblPlanificacion, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlanificacion;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMeses cboMesDesde;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMeses cboMesHasta;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboEstructuraPresupuesto cboEstructuraPresupuesto1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboTipoReporte;
        private GEN.ControlesBase.lblBase lblBase5;

    }
}