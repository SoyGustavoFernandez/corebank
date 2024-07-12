namespace PRE.Presentacion
{
    partial class frmDialogoQueValorPartid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogoQueValorPartid));
            this.cboQueValor = new GEN.ControlesBase.cboBase(this.components);
            this.cboMes = new GEN.ControlesBase.cboMeses(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblPlanificacion = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal1 = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstructuraPresupuesto = new GEN.ControlesBase.cboEstructuraPresupuesto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboQueValor
            // 
            this.cboQueValor.FormattingEnabled = true;
            this.cboQueValor.Location = new System.Drawing.Point(152, 118);
            this.cboQueValor.Name = "cboQueValor";
            this.cboQueValor.Size = new System.Drawing.Size(150, 21);
            this.cboQueValor.TabIndex = 3;
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(152, 87);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 2;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(246, 146);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 4;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(312, 146);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(37, 121);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(109, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Valor de partidas:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(37, 90);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(72, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Hasta mes:";
            // 
            // lblPlanificacion
            // 
            this.lblPlanificacion.AutoSize = true;
            this.lblPlanificacion.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanificacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPlanificacion.Location = new System.Drawing.Point(194, 16);
            this.lblPlanificacion.Name = "lblPlanificacion";
            this.lblPlanificacion.Size = new System.Drawing.Size(91, 14);
            this.lblPlanificacion.TabIndex = 3;
            this.lblPlanificacion.Text = "Planificación";
            // 
            // cboPeriodoPresupuestal1
            // 
            this.cboPeriodoPresupuestal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoPresupuestal1.FormattingEnabled = true;
            this.cboPeriodoPresupuestal1.Location = new System.Drawing.Point(67, 14);
            this.cboPeriodoPresupuestal1.Name = "cboPeriodoPresupuestal1";
            this.cboPeriodoPresupuestal1.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoPresupuestal1.TabIndex = 0;
            this.cboPeriodoPresupuestal1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 1;
            this.lblBase3.Text = "Periodo:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblPlanificacion);
            this.grbBase1.Controls.Add(this.cboPeriodoPresupuestal1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(31, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(316, 38);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // cboEstructuraPresupuesto
            // 
            this.cboEstructuraPresupuesto.FormattingEnabled = true;
            this.cboEstructuraPresupuesto.Location = new System.Drawing.Point(152, 56);
            this.cboEstructuraPresupuesto.Name = "cboEstructuraPresupuesto";
            this.cboEstructuraPresupuesto.Size = new System.Drawing.Size(155, 21);
            this.cboEstructuraPresupuesto.TabIndex = 1;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(37, 59);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(54, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "Ver por:";
            // 
            // frmDialogoQueValorPartid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.cboEstructuraPresupuesto);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboQueValor);
            this.Name = "frmDialogoQueValorPartid";
            this.Text = "Reporte detalle partidas presupuestales";
            this.Load += new System.EventHandler(this.frmDialogoQueValorPartid_Load);
            this.Controls.SetChildIndex(this.cboQueValor, 0);
            this.Controls.SetChildIndex(this.cboMes, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboEstructuraPresupuesto, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboQueValor;
        private GEN.ControlesBase.cboMeses cboMes;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.Label lblPlanificacion;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboEstructuraPresupuesto cboEstructuraPresupuesto;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}