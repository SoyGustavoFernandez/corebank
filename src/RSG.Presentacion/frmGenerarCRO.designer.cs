namespace RSG.Presentacion
{
    partial class frmGenerarCRO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarCRO));
            this.chklbReportes = new GEN.ControlesBase.chklbBase(this.components);
            this.lblEstCheq = new GEN.ControlesBase.lblBase();
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoEnvio = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoProceso = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnPath = new GEN.BotonesBase.Boton2();
            this.txtPath = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // chklbReportes
            // 
            this.chklbReportes.FormattingEnabled = true;
            this.chklbReportes.Location = new System.Drawing.Point(12, 31);
            this.chklbReportes.Name = "chklbReportes";
            this.chklbReportes.Size = new System.Drawing.Size(299, 169);
            this.chklbReportes.TabIndex = 2;
            // 
            // lblEstCheq
            // 
            this.lblEstCheq.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblEstCheq.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstCheq.ForeColor = System.Drawing.Color.Navy;
            this.lblEstCheq.Location = new System.Drawing.Point(12, 14);
            this.lblEstCheq.Name = "lblEstCheq";
            this.lblEstCheq.Size = new System.Drawing.Size(202, 16);
            this.lblEstCheq.TabIndex = 121;
            this.lblEstCheq.Text = "REPORTES";
            this.lblEstCheq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(201, 14);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 122;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(482, 150);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 123;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(548, 150);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 124;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(89, 13);
            this.lblBase1.TabIndex = 125;
            this.lblBase1.Text = "Tipo de Envio:";
            // 
            // cboTipoEnvio
            // 
            this.cboTipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEnvio.FormattingEnabled = true;
            this.cboTipoEnvio.Location = new System.Drawing.Point(115, 12);
            this.cboTipoEnvio.Name = "cboTipoEnvio";
            this.cboTipoEnvio.Size = new System.Drawing.Size(170, 21);
            this.cboTipoEnvio.TabIndex = 126;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 127;
            this.lblBase2.Text = "Tipo de Proceso:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 70);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 128;
            this.lblBase3.Text = "Periodo:";
            // 
            // cboTipoProceso
            // 
            this.cboTipoProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProceso.FormattingEnabled = true;
            this.cboTipoProceso.Location = new System.Drawing.Point(115, 39);
            this.cboTipoProceso.Name = "cboTipoProceso";
            this.cboTipoProceso.Size = new System.Drawing.Size(170, 21);
            this.cboTipoProceso.TabIndex = 129;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.nudAnio);
            this.grbBase1.Controls.Add(this.cboMeses);
            this.grbBase1.Controls.Add(this.btnPath);
            this.grbBase1.Controls.Add(this.txtPath);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboTipoEnvio);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboTipoProceso);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(317, 14);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(291, 128);
            this.grbBase1.TabIndex = 132;
            this.grbBase1.TabStop = false;
            // 
            // btnPath
            // 
            this.btnPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPath.Location = new System.Drawing.Point(235, 93);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(50, 21);
            this.btnPath.TabIndex = 134;
            this.btnPath.Text = "...";
            this.btnPath.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(115, 93);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(114, 20);
            this.txtPath.TabIndex = 133;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 96);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(38, 13);
            this.lblBase4.TabIndex = 132;
            this.lblBase4.Text = "Ruta:";
            // 
            // cboMeses
            // 
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(115, 66);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(95, 21);
            this.cboMeses.TabIndex = 135;
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(212, 66);
            this.nudAnio.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(73, 20);
            this.nudAnio.TabIndex = 136;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // frmGenerarCRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 234);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.chcSelec);
            this.Controls.Add(this.lblEstCheq);
            this.Controls.Add(this.chklbReportes);
            this.Name = "frmGenerarCRO";
            this.Text = "Generación de Reportes CRO";
            this.Load += new System.EventHandler(this.frmGenerarCRO_Load);
            this.Controls.SetChildIndex(this.chklbReportes, 0);
            this.Controls.SetChildIndex(this.lblEstCheq, 0);
            this.Controls.SetChildIndex(this.chcSelec, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chklbBase chklbReportes;
        private GEN.ControlesBase.lblBase lblEstCheq;
        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoEnvio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboTipoProceso;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.Boton2 btnPath;
        private GEN.ControlesBase.txtBase txtPath;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.cboMeses cboMeses;
    }
}