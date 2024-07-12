namespace CAJ.Presentacion
{
    partial class frmAperturaCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAperturaCaja));
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.chcApeCaja = new GEN.ControlesBase.chcBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipResponsableCaja1 = new GEN.ControlesBase.cboTipResponsableCaja(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcCorteFracc = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(96, 12);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(145, 21);
            this.cboAgencias.TabIndex = 2;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(63, 13);
            this.lblBase3.TabIndex = 62;
            this.lblBase3.Text = "Agencias:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 43);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 63;
            this.lblBase1.Text = "Colaborador:";
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(96, 39);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(423, 21);
            this.cboColaborador.TabIndex = 64;
            // 
            // chcApeCaja
            // 
            this.chcApeCaja.AutoSize = true;
            this.chcApeCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcApeCaja.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcApeCaja.Location = new System.Drawing.Point(28, 93);
            this.chcApeCaja.Name = "chcApeCaja";
            this.chcApeCaja.Size = new System.Drawing.Size(199, 17);
            this.chcApeCaja.TabIndex = 65;
            this.chcApeCaja.Text = "APERTURAR CAJA CERRADA";
            this.chcApeCaja.UseVisualStyleBackColor = true;
            this.chcApeCaja.CheckedChanged += new System.EventHandler(this.chcApeCaja_CheckedChanged);
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(67, 159);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(462, 41);
            this.txtSustento.TabIndex = 67;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(1, 160);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 66;
            this.lblBase9.Text = "Sustento:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(407, 204);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 68;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(468, 204);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 69;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboTipResponsableCaja1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboColaborador);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Location = new System.Drawing.Point(4, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(525, 69);
            this.grbBase1.TabIndex = 70;
            this.grbBase1.TabStop = false;
            // 
            // cboTipResponsableCaja1
            // 
            this.cboTipResponsableCaja1.FormattingEnabled = true;
            this.cboTipResponsableCaja1.Location = new System.Drawing.Point(364, 13);
            this.cboTipResponsableCaja1.Name = "cboTipResponsableCaja1";
            this.cboTipResponsableCaja1.Size = new System.Drawing.Size(155, 21);
            this.cboTipResponsableCaja1.TabIndex = 78;
            this.cboTipResponsableCaja1.SelectedIndexChanged += new System.EventHandler(this.cboTipResponsableCaja1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(252, 17);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(109, 13);
            this.lblBase2.TabIndex = 76;
            this.lblBase2.Text = "Tipo responsable:";
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase2.Location = new System.Drawing.Point(4, 80);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(524, 35);
            this.grbBase2.TabIndex = 71;
            this.grbBase2.TabStop = false;
            this.grbBase2.Enter += new System.EventHandler(this.grbBase2_Enter);
            // 
            // chcCorteFracc
            // 
            this.chcCorteFracc.AutoSize = true;
            this.chcCorteFracc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcCorteFracc.ForeColor = System.Drawing.Color.Green;
            this.chcCorteFracc.Location = new System.Drawing.Point(24, 12);
            this.chcCorteFracc.Name = "chcCorteFracc";
            this.chcCorteFracc.Size = new System.Drawing.Size(159, 17);
            this.chcCorteFracc.TabIndex = 72;
            this.chcCorteFracc.Text = "HABILITAR BILLETAJE";
            this.chcCorteFracc.UseVisualStyleBackColor = true;
            this.chcCorteFracc.CheckedChanged += new System.EventHandler(this.chcCorteFracc_CheckedChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase3.Controls.Add(this.chcCorteFracc);
            this.grbBase3.Location = new System.Drawing.Point(4, 115);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(525, 35);
            this.grbBase3.TabIndex = 73;
            this.grbBase3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 15);
            this.label1.TabIndex = 75;
            this.label1.Text = "MANIPULAR ESTA OPCIÓN CON RESPONSABILIDAD, CUIDADO Y UN BUEN SUSTENTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 281);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.chcApeCaja);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmAperturaCaja";
            this.Text = "Aperturar Caja y Habilitar Billetaje";
            this.Load += new System.EventHandler(this.frmAperturaCaja_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.chcApeCaja, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.chcBase chcApeCaja;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.chcBase chcCorteFracc;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.cboTipResponsableCaja cboTipResponsableCaja1;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}

