namespace RSG.Presentacion
{
    partial class frmRptCreditosConOpinionRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCreditosConOpinionRiesgos));
            this.cboAnalista = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dFechaFin = new GEN.ControlesBase.DatePicker();
            this.dFechaIni = new GEN.ControlesBase.DatePicker();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAnalista
            // 
            this.cboAnalista.FormattingEnabled = true;
            this.cboAnalista.Location = new System.Drawing.Point(77, 31);
            this.cboAnalista.Name = "cboAnalista";
            this.cboAnalista.Size = new System.Drawing.Size(286, 21);
            this.cboAnalista.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 39);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Analista:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dFechaFin);
            this.grbBase1.Controls.Add(this.dFechaIni);
            this.grbBase1.Controls.Add(this.cboAnalista);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(405, 117);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Créditos con Opnión de Riesgos";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(211, 67);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(39, 13);
            this.lblBase6.TabIndex = 25;
            this.lblBase6.Text = "Hasta";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(31, 64);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(43, 13);
            this.lblBase5.TabIndex = 24;
            this.lblBase5.Text = "Desde";
            // 
            // dFechaFin
            // 
            this.dFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaFin.Location = new System.Drawing.Point(252, 64);
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.Size = new System.Drawing.Size(111, 20);
            this.dFechaFin.TabIndex = 23;
            this.dFechaFin.Value = new System.DateTime(2016, 8, 11, 18, 46, 38, 407);
            // 
            // dFechaIni
            // 
            this.dFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaIni.Location = new System.Drawing.Point(77, 60);
            this.dFechaIni.Name = "dFechaIni";
            this.dFechaIni.Size = new System.Drawing.Size(111, 20);
            this.dFechaIni.TabIndex = 22;
            this.dFechaIni.Value = new System.DateTime(2016, 8, 11, 18, 46, 13, 629);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(249, 144);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Impirmir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(315, 144);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmRptCreditosConOpinionRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 238);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptCreditosConOpinionRiesgos";
            this.Text = "Reporte de Créditos con Opinión de Riesgos";
            this.Load += new System.EventHandler(this.frmRptCreditosConOpinionRiesgos_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboAnalista;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.DatePicker dFechaFin;
        private GEN.ControlesBase.DatePicker dFechaIni;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}