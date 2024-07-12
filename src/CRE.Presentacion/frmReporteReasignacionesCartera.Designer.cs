namespace CRE.Presentacion
{
    partial class frmReporteReasignacionesCartera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteReasignacionesCartera));
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecProcFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecProcIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(63, 9);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(368, 25);
            this.lblBaseCustom1.TabIndex = 16;
            this.lblBaseCustom1.Text = "REPORTE DE REASIGNACIONES DE CARTERA";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(137, 49);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(278, 21);
            this.cboColaborador.TabIndex = 93;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(48, 52);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 92;
            this.lblBase4.Text = "Colaborador:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(68, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 91;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(137, 19);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(278, 21);
            this.cboAgencias.TabIndex = 90;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtpFecProcFin);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtpFecProcIni);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Location = new System.Drawing.Point(15, 139);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(488, 42);
            this.grbBase2.TabIndex = 91;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Rango de Fechas:";
            // 
            // dtpFecProcFin
            // 
            this.dtpFecProcFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecProcFin.Location = new System.Drawing.Point(346, 16);
            this.dtpFecProcFin.Name = "dtpFecProcFin";
            this.dtpFecProcFin.Size = new System.Drawing.Size(130, 20);
            this.dtpFecProcFin.TabIndex = 86;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(275, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 87;
            this.lblBase1.Text = "Fecha Fin:";
            // 
            // dtpFecProcIni
            // 
            this.dtpFecProcIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecProcIni.Location = new System.Drawing.Point(124, 16);
            this.dtpFecProcIni.Name = "dtpFecProcIni";
            this.dtpFecProcIni.Size = new System.Drawing.Size(130, 20);
            this.dtpFecProcIni.TabIndex = 84;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(20, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(98, 13);
            this.lblBase6.TabIndex = 85;
            this.lblBase6.Text = "Fecha de Inicio:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboColaborador);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.cboAgencias);
            this.grbBase3.Location = new System.Drawing.Point(15, 53);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(488, 80);
            this.grbBase3.TabIndex = 94;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Origen";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(443, 196);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 93;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(370, 196);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 92;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmReporteReasignacionesCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 279);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBaseCustom1);
            this.Name = "frmReporteReasignacionesCartera";
            this.Text = "Reporte Reasignacion Cartera";
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase2;
        public GEN.ControlesBase.dtpCorto dtpFecProcFin;
        private GEN.ControlesBase.lblBase lblBase1;
        public GEN.ControlesBase.dtpCorto dtpFecProcIni;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}