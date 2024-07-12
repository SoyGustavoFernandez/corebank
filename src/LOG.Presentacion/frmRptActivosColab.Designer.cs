namespace LOG.Presentacion
{
    partial class frmRptActivosColab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptActivosColab));
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.lblEstCheq = new GEN.ControlesBase.lblBase();
            this.chklbEstados = new GEN.ControlesBase.chklbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboArea1 = new GEN.ControlesBase.cboArea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(239, 100);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 128;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // lblEstCheq
            // 
            this.lblEstCheq.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblEstCheq.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstCheq.ForeColor = System.Drawing.Color.Navy;
            this.lblEstCheq.Location = new System.Drawing.Point(12, 101);
            this.lblEstCheq.Name = "lblEstCheq";
            this.lblEstCheq.Size = new System.Drawing.Size(337, 16);
            this.lblEstCheq.TabIndex = 127;
            this.lblEstCheq.Text = "COLABORADORES";
            this.lblEstCheq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chklbEstados
            // 
            this.chklbEstados.FormattingEnabled = true;
            this.chklbEstados.Location = new System.Drawing.Point(12, 119);
            this.chklbEstados.Name = "chklbEstados";
            this.chklbEstados.Size = new System.Drawing.Size(338, 139);
            this.chklbEstados.TabIndex = 126;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(290, 264);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 125;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(224, 264);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 124;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboArea1);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.cboAgencias1);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(12, 12);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(337, 69);
            this.grbBase3.TabIndex = 123;
            this.grbBase3.TabStop = false;
            // 
            // cboArea1
            // 
            this.cboArea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea1.FormattingEnabled = true;
            this.cboArea1.Location = new System.Drawing.Point(71, 41);
            this.cboArea1.Name = "cboArea1";
            this.cboArea1.Size = new System.Drawing.Size(152, 21);
            this.cboArea1.TabIndex = 113;
            this.cboArea1.SelectedIndexChanged += new System.EventHandler(this.cboArea1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 44);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(39, 13);
            this.lblBase1.TabIndex = 112;
            this.lblBase1.Text = "Área:";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(71, 15);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(152, 21);
            this.cboAgencias1.TabIndex = 111;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(8, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(57, 13);
            this.lblBase8.TabIndex = 110;
            this.lblBase8.Text = "Agencia:";
            // 
            // frmRptActivosxParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 343);
            this.Controls.Add(this.chcSelec);
            this.Controls.Add(this.lblEstCheq);
            this.Controls.Add(this.chklbEstados);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmRptActivosColab";
            this.Text = "Reporte de Activos";
            this.Load += new System.EventHandler(this.frmRptActivosColab_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.chklbEstados, 0);
            this.Controls.SetChildIndex(this.lblEstCheq, 0);
            this.Controls.SetChildIndex(this.chcSelec, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.ControlesBase.lblBase lblEstCheq;
        private GEN.ControlesBase.chklbBase chklbEstados;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.cboArea cboArea1;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}