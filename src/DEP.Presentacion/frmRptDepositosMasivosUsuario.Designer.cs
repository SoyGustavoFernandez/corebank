namespace DEP.Presentacion
{
    partial class frmRptDepositosMasivosUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptDepositosMasivosUsuario));
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chklbDatUsu = new GEN.ControlesBase.chklbBase(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpFechaSimp(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpFechaSimp(this.components);
            this.lblFechaInicial = new GEN.ControlesBase.lblBase();
            this.lblFechaFinal = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.cboTipoCargaMasivaAho = new GEN.ControlesBase.cboTipoCargaMasivaAho(this.components);
            this.lblTipoCarga = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(312, 95);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 138;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 95);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(410, 16);
            this.lblBase2.TabIndex = 136;
            this.lblBase2.Text = "Usuarios Talento Humano";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chklbDatUsu
            // 
            this.chklbDatUsu.FormattingEnabled = true;
            this.chklbDatUsu.Location = new System.Drawing.Point(12, 114);
            this.chklbDatUsu.Name = "chklbDatUsu";
            this.chklbDatUsu.Size = new System.Drawing.Size(410, 184);
            this.chklbDatUsu.TabIndex = 135;
            this.chklbDatUsu.Click += new System.EventHandler(this.chklbDatPcUsu_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 23);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 143;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(222, 23);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 144;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaInicial.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaInicial.Location = new System.Drawing.Point(9, 7);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(78, 13);
            this.lblFechaInicial.TabIndex = 145;
            this.lblFechaInicial.Text = "Fecha Inicial";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaFinal.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaFinal.Location = new System.Drawing.Point(219, 7);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(70, 13);
            this.lblFechaFinal.TabIndex = 146;
            this.lblFechaFinal.Text = "Fecha Final";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(362, 304);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 148;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(296, 304);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 147;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboTipoCargaMasivaAho
            // 
            this.cboTipoCargaMasivaAho.FormattingEnabled = true;
            this.cboTipoCargaMasivaAho.Location = new System.Drawing.Point(12, 65);
            this.cboTipoCargaMasivaAho.Name = "cboTipoCargaMasivaAho";
            this.cboTipoCargaMasivaAho.Size = new System.Drawing.Size(200, 21);
            this.cboTipoCargaMasivaAho.TabIndex = 149;
            // 
            // lblTipoCarga
            // 
            this.lblTipoCarga.AutoSize = true;
            this.lblTipoCarga.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoCarga.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCarga.Location = new System.Drawing.Point(9, 49);
            this.lblTipoCarga.Name = "lblTipoCarga";
            this.lblTipoCarga.Size = new System.Drawing.Size(70, 13);
            this.lblTipoCarga.TabIndex = 150;
            this.lblTipoCarga.Text = "Tipo Carga";
            // 
            // frmRptDepositosMasivosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 382);
            this.Controls.Add(this.lblTipoCarga);
            this.Controls.Add(this.cboTipoCargaMasivaAho);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblFechaFinal);
            this.Controls.Add(this.lblFechaInicial);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.chcSelec);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.chklbDatUsu);
            this.Name = "frmRptDepositosMasivosUsuario";
            this.Text = "Reporte depósitos masivos por usuario";
            this.Load += new System.EventHandler(this.frmRptDepositosMasivosUsuario_Load);
            this.Controls.SetChildIndex(this.chklbDatUsu, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.chcSelec, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblFechaInicial, 0);
            this.Controls.SetChildIndex(this.lblFechaFinal, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboTipoCargaMasivaAho, 0);
            this.Controls.SetChildIndex(this.lblTipoCarga, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chklbBase chklbDatUsu;
        private GEN.ControlesBase.dtpFechaSimp dtpFechaInicio;
        private GEN.ControlesBase.dtpFechaSimp dtpFechaFin;
        private GEN.ControlesBase.lblBase lblFechaInicial;
        private GEN.ControlesBase.lblBase lblFechaFinal;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboTipoCargaMasivaAho cboTipoCargaMasivaAho;
        private GEN.ControlesBase.lblBase lblTipoCarga;
    }
}