namespace CAJ.Presentacion
{
    partial class frmInicioOpe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioOpe));
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMonSoles = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMonDolares = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtSalBovDol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSalBovSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnGrabar();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboTipResponsable = new GEN.ControlesBase.cboBase(this.components);
            this.btnImprimirVoucher = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(99, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Monto en Soles:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 46);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(112, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Monto en Dólares:";
            // 
            // txtMonSoles
            // 
            this.txtMonSoles.Enabled = false;
            this.txtMonSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonSoles.FormatoDecimal = false;
            this.txtMonSoles.Location = new System.Drawing.Point(124, 17);
            this.txtMonSoles.Name = "txtMonSoles";
            this.txtMonSoles.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonSoles.nNumDecimales = 4;
            this.txtMonSoles.nvalor = 0D;
            this.txtMonSoles.Size = new System.Drawing.Size(124, 20);
            this.txtMonSoles.TabIndex = 5;
            this.txtMonSoles.Text = "0.00";
            // 
            // txtMonDolares
            // 
            this.txtMonDolares.Enabled = false;
            this.txtMonDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonDolares.FormatoDecimal = false;
            this.txtMonDolares.Location = new System.Drawing.Point(124, 42);
            this.txtMonDolares.Name = "txtMonDolares";
            this.txtMonDolares.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonDolares.nNumDecimales = 4;
            this.txtMonDolares.nvalor = 0D;
            this.txtMonDolares.Size = new System.Drawing.Size(124, 20);
            this.txtMonDolares.TabIndex = 6;
            this.txtMonDolares.Text = "0.00";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(369, 185);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtMonSoles);
            this.grbBase1.Controls.Add(this.txtMonDolares);
            this.grbBase1.Location = new System.Drawing.Point(6, 109);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(423, 70);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Saldos Iniciales";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(262, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(122, 13);
            this.lblBase2.TabIndex = 57;
            this.lblBase2.Text = "Dólares Americanos";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(262, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(84, 13);
            this.lblBase1.TabIndex = 57;
            this.lblBase1.Text = "Nuevos Soles";
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(67, 48);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(350, 20);
            this.txtNomUsu.TabIndex = 2;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(13, 51);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(57, 13);
            this.lblBase6.TabIndex = 54;
            this.lblBase6.Text = "Nombre:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(223, 21);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(33, 20);
            this.txtCodUsu.TabIndex = 0;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(172, 27);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(52, 13);
            this.lblBase7.TabIndex = 52;
            this.lblBase7.Text = "Código:";
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(72, 23);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaSis.TabIndex = 1;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(13, 26);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(45, 13);
            this.lblBase8.TabIndex = 51;
            this.lblBase8.Text = "Fecha:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtUsuario);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.txtNomUsu);
            this.grbBase2.Controls.Add(this.txtCodUsu);
            this.grbBase2.Location = new System.Drawing.Point(5, 3);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(424, 77);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos Sistema";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(319, 22);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(98, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(263, 25);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(55, 13);
            this.lblBase9.TabIndex = 49;
            this.lblBase9.Text = "Usuario:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.txtSalBovDol);
            this.grbBase3.Controls.Add(this.txtSalBovSol);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Location = new System.Drawing.Point(4, 274);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(423, 70);
            this.grbBase3.TabIndex = 58;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Saldos Iniciales Bóveda";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(254, 43);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(122, 13);
            this.lblBase3.TabIndex = 62;
            this.lblBase3.Text = "Dólares Americanos";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(254, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(84, 13);
            this.lblBase10.TabIndex = 63;
            this.lblBase10.Text = "Nuevos Soles";
            // 
            // txtSalBovDol
            // 
            this.txtSalBovDol.Enabled = false;
            this.txtSalBovDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalBovDol.FormatoDecimal = false;
            this.txtSalBovDol.Location = new System.Drawing.Point(126, 41);
            this.txtSalBovDol.Name = "txtSalBovDol";
            this.txtSalBovDol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalBovDol.nNumDecimales = 4;
            this.txtSalBovDol.nvalor = 0D;
            this.txtSalBovDol.Size = new System.Drawing.Size(124, 20);
            this.txtSalBovDol.TabIndex = 61;
            this.txtSalBovDol.Text = "0.00";
            // 
            // txtSalBovSol
            // 
            this.txtSalBovSol.Enabled = false;
            this.txtSalBovSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalBovSol.FormatoDecimal = false;
            this.txtSalBovSol.Location = new System.Drawing.Point(126, 15);
            this.txtSalBovSol.Name = "txtSalBovSol";
            this.txtSalBovSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalBovSol.nNumDecimales = 4;
            this.txtSalBovSol.nvalor = 0D;
            this.txtSalBovSol.Size = new System.Drawing.Size(124, 20);
            this.txtSalBovSol.TabIndex = 60;
            this.txtSalBovSol.Text = "0.00";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(9, 44);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(112, 13);
            this.lblBase11.TabIndex = 59;
            this.lblBase11.Text = "Monto en Dólares:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 18);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(99, 13);
            this.lblBase12.TabIndex = 58;
            this.lblBase12.Text = "Monto en Soles:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(303, 185);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 3;
            this.btnProcesar.Text = "&Grabar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(12, 88);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(109, 13);
            this.lblBase13.TabIndex = 65;
            this.lblBase13.Text = "Tipo responsable:";
            // 
            // cboTipResponsable
            // 
            this.cboTipResponsable.FormattingEnabled = true;
            this.cboTipResponsable.Location = new System.Drawing.Point(127, 85);
            this.cboTipResponsable.Name = "cboTipResponsable";
            this.cboTipResponsable.Size = new System.Drawing.Size(295, 21);
            this.cboTipResponsable.TabIndex = 1;
            this.cboTipResponsable.SelectedIndexChanged += new System.EventHandler(this.cboTipResponsable_SelectedIndexChanged);
            // 
            // btnImprimirVoucher
            // 
            this.btnImprimirVoucher.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirVoucher.BackgroundImage")));
            this.btnImprimirVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirVoucher.Location = new System.Drawing.Point(237, 185);
            this.btnImprimirVoucher.Name = "btnImprimirVoucher";
            this.btnImprimirVoucher.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirVoucher.TabIndex = 66;
            this.btnImprimirVoucher.Text = "Voucher";
            this.btnImprimirVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirVoucher.UseVisualStyleBackColor = true;
            this.btnImprimirVoucher.Click += new System.EventHandler(this.btnImprimirVoucher_Click);
            // 
            // frmInicioOpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 269);
            this.Controls.Add(this.btnImprimirVoucher);
            this.Controls.Add(this.cboTipResponsable);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtpFechaSis);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmInicioOpe";
            this.Text = "Inicio de Operaciones";
            this.Load += new System.EventHandler(this.frmInicioOP_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtpFechaSis, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.cboTipResponsable, 0);
            this.Controls.SetChildIndex(this.btnImprimirVoucher, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonSoles;
        private GEN.ControlesBase.txtNumRea txtMonDolares;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase7;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtSalBovDol;
        private GEN.ControlesBase.txtNumRea txtSalBovSol;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnGrabar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboBase cboTipResponsable;
        private GEN.BotonesBase.btnImprimir btnImprimirVoucher;
    }
}

