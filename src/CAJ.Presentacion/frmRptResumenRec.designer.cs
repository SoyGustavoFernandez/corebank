namespace CAJ.Presentacion
{
    partial class frmRptResumenRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptResumenRec));
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipRec = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chklbConcep = new GEN.ControlesBase.chklbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 57);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 97;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(88, 55);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(209, 21);
            this.cboAgencias.TabIndex = 96;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(0, 41);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(538, 40);
            this.grbBase1.TabIndex = 100;
            this.grbBase1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(473, 242);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 112;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(410, 242);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 111;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(381, 15);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFecFin.TabIndex = 108;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(302, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(75, 13);
            this.lblBase7.TabIndex = 109;
            this.lblBase7.Text = "Fecha Final:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(88, 15);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFecIni.TabIndex = 106;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(83, 13);
            this.lblBase8.TabIndex = 107;
            this.lblBase8.Text = "Fecha Inicial:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFecFin);
            this.grbBase3.Location = new System.Drawing.Point(2, 0);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(538, 42);
            this.grbBase3.TabIndex = 110;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Rango Fechas";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(382, 14);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(150, 21);
            this.cboMoneda.TabIndex = 16;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 102);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 114;
            this.lblBase3.Text = "Tipo Recibo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(302, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Moneda:";
            // 
            // cboTipRec
            // 
            this.cboTipRec.FormattingEnabled = true;
            this.cboTipRec.Location = new System.Drawing.Point(88, 99);
            this.cboTipRec.Name = "cboTipRec";
            this.cboTipRec.Size = new System.Drawing.Size(183, 21);
            this.cboTipRec.TabIndex = 113;
            this.cboTipRec.SelectedIndexChanged += new System.EventHandler(this.cboTipRec_SelectedIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(1, 85);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(540, 43);
            this.grbBase2.TabIndex = 115;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Filtros";
            // 
            // chklbConcep
            // 
            this.chklbConcep.FormattingEnabled = true;
            this.chklbConcep.Location = new System.Drawing.Point(4, 155);
            this.chklbConcep.Name = "chklbConcep";
            this.chklbConcep.Size = new System.Drawing.Size(338, 139);
            this.chklbConcep.TabIndex = 116;
            // 
            // lblBase2
            // 
            this.lblBase2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(4, 137);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(337, 16);
            this.lblBase2.TabIndex = 117;
            this.lblBase2.Text = "CONCEPTOS DE RECIBOS";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(231, 136);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 118;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // frmRptResumenRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 317);
            this.Controls.Add(this.chcSelec);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.chklbConcep);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipRec);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboAgencias);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptResumenRec";
            this.Text = "Detalle de recibos por agencia";
            this.Load += new System.EventHandler(this.frmRptResumenRec_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencias, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboTipRec, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chklbConcep, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.chcSelec, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        public GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase7;
        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipRec;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.chklbBase chklbConcep;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chcBase chcSelec;
    }
}