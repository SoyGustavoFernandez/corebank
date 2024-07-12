namespace CLI.Presentacion
{
    partial class frmBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalance));
            this.conTLVBalance1 = new GEN.ControlesBase.conTLVBalance();
            this.grbAuditado = new GEN.ControlesBase.grbBase(this.components);
            this.rbtAuditaNo = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtAuditaSi = new GEN.ControlesBase.rbtBase(this.components);
            this.grbMonExt = new GEN.ControlesBase.grbBase(this.components);
            this.rbtMonedaNo = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMonedaSi = new GEN.ControlesBase.rbtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnExportar1 = new GEN.BotonesBase.btnExportar();
            this.grbDatContador = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtDocIde = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtContador = new GEN.ControlesBase.txtBase(this.components);
            this.txtTelefono = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCpp = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtEmail1 = new GEN.ControlesBase.txtEmail(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.cboBalances = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbAuditado.SuspendLayout();
            this.grbMonExt.SuspendLayout();
            this.grbDatContador.SuspendLayout();
            this.SuspendLayout();
            // 
            // conTLVBalance1
            // 
            this.conTLVBalance1.Enabled = false;
            this.conTLVBalance1.Location = new System.Drawing.Point(18, 186);
            this.conTLVBalance1.Name = "conTLVBalance1";
            this.conTLVBalance1.Size = new System.Drawing.Size(493, 374);
            this.conTLVBalance1.TabIndex = 2;
            // 
            // grbAuditado
            // 
            this.grbAuditado.Controls.Add(this.rbtAuditaNo);
            this.grbAuditado.Controls.Add(this.rbtAuditaSi);
            this.grbAuditado.Enabled = false;
            this.grbAuditado.Location = new System.Drawing.Point(12, 47);
            this.grbAuditado.Name = "grbAuditado";
            this.grbAuditado.Size = new System.Drawing.Size(90, 40);
            this.grbAuditado.TabIndex = 6;
            this.grbAuditado.TabStop = false;
            this.grbAuditado.Text = "Auditado";
            // 
            // rbtAuditaNo
            // 
            this.rbtAuditaNo.AutoSize = true;
            this.rbtAuditaNo.Checked = true;
            this.rbtAuditaNo.ForeColor = System.Drawing.Color.Navy;
            this.rbtAuditaNo.Location = new System.Drawing.Point(46, 19);
            this.rbtAuditaNo.Name = "rbtAuditaNo";
            this.rbtAuditaNo.Size = new System.Drawing.Size(39, 17);
            this.rbtAuditaNo.TabIndex = 0;
            this.rbtAuditaNo.TabStop = true;
            this.rbtAuditaNo.Text = "No";
            this.rbtAuditaNo.UseVisualStyleBackColor = true;
            // 
            // rbtAuditaSi
            // 
            this.rbtAuditaSi.AutoSize = true;
            this.rbtAuditaSi.ForeColor = System.Drawing.Color.Navy;
            this.rbtAuditaSi.Location = new System.Drawing.Point(6, 19);
            this.rbtAuditaSi.Name = "rbtAuditaSi";
            this.rbtAuditaSi.Size = new System.Drawing.Size(34, 17);
            this.rbtAuditaSi.TabIndex = 0;
            this.rbtAuditaSi.Text = "Si";
            this.rbtAuditaSi.UseVisualStyleBackColor = true;
            // 
            // grbMonExt
            // 
            this.grbMonExt.Controls.Add(this.rbtMonedaNo);
            this.grbMonExt.Controls.Add(this.rbtMonedaSi);
            this.grbMonExt.Enabled = false;
            this.grbMonExt.Location = new System.Drawing.Point(144, 47);
            this.grbMonExt.Name = "grbMonExt";
            this.grbMonExt.Size = new System.Drawing.Size(164, 40);
            this.grbMonExt.TabIndex = 7;
            this.grbMonExt.TabStop = false;
            this.grbMonExt.Text = "Opera con Moneda Extranjera";
            // 
            // rbtMonedaNo
            // 
            this.rbtMonedaNo.AutoSize = true;
            this.rbtMonedaNo.Checked = true;
            this.rbtMonedaNo.ForeColor = System.Drawing.Color.Navy;
            this.rbtMonedaNo.Location = new System.Drawing.Point(46, 19);
            this.rbtMonedaNo.Name = "rbtMonedaNo";
            this.rbtMonedaNo.Size = new System.Drawing.Size(39, 17);
            this.rbtMonedaNo.TabIndex = 0;
            this.rbtMonedaNo.TabStop = true;
            this.rbtMonedaNo.Text = "No";
            this.rbtMonedaNo.UseVisualStyleBackColor = true;
            // 
            // rbtMonedaSi
            // 
            this.rbtMonedaSi.AutoSize = true;
            this.rbtMonedaSi.ForeColor = System.Drawing.Color.Navy;
            this.rbtMonedaSi.Location = new System.Drawing.Point(6, 19);
            this.rbtMonedaSi.Name = "rbtMonedaSi";
            this.rbtMonedaSi.Size = new System.Drawing.Size(34, 17);
            this.rbtMonedaSi.TabIndex = 0;
            this.rbtMonedaSi.Text = "Si";
            this.rbtMonedaSi.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(561, 510);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(561, 454);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnExportar1
            // 
            this.btnExportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar1.BackgroundImage")));
            this.btnExportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar1.Location = new System.Drawing.Point(561, 398);
            this.btnExportar1.Name = "btnExportar1";
            this.btnExportar1.Size = new System.Drawing.Size(60, 50);
            this.btnExportar1.TabIndex = 10;
            this.btnExportar1.Text = "E&xportar";
            this.btnExportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar1.UseVisualStyleBackColor = true;
            this.btnExportar1.Click += new System.EventHandler(this.btnExportar1_Click);
            // 
            // grbDatContador
            // 
            this.grbDatContador.Controls.Add(this.lblBase6);
            this.grbDatContador.Controls.Add(this.txtDocIde);
            this.grbDatContador.Controls.Add(this.lblBase5);
            this.grbDatContador.Controls.Add(this.lblBase3);
            this.grbDatContador.Controls.Add(this.lblBase4);
            this.grbDatContador.Controls.Add(this.lblBase2);
            this.grbDatContador.Controls.Add(this.lblBase1);
            this.grbDatContador.Controls.Add(this.txtContador);
            this.grbDatContador.Controls.Add(this.txtTelefono);
            this.grbDatContador.Controls.Add(this.txtCodCpp);
            this.grbDatContador.Controls.Add(this.txtDireccion);
            this.grbDatContador.Controls.Add(this.txtEmail1);
            this.grbDatContador.Enabled = false;
            this.grbDatContador.Location = new System.Drawing.Point(12, 97);
            this.grbDatContador.Name = "grbDatContador";
            this.grbDatContador.Size = new System.Drawing.Size(615, 93);
            this.grbDatContador.TabIndex = 11;
            this.grbDatContador.TabStop = false;
            this.grbDatContador.Text = "Datos del Contador";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(443, 70);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(60, 13);
            this.lblBase6.TabIndex = 5;
            this.lblBase6.Text = "Teléfono:";
            // 
            // txtDocIde
            // 
            this.txtDocIde.Location = new System.Drawing.Point(517, 41);
            this.txtDocIde.Name = "txtDocIde";
            this.txtDocIde.Size = new System.Drawing.Size(92, 20);
            this.txtDocIde.TabIndex = 4;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(443, 45);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(68, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Doc. Iden:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 70);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(65, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Dirección:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(43, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Email:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(293, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(79, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Código CPP:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Contador:";
            // 
            // txtContador
            // 
            this.txtContador.Location = new System.Drawing.Point(88, 16);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(521, 20);
            this.txtContador.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(517, 67);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(92, 20);
            this.txtTelefono.TabIndex = 1;
            // 
            // txtCodCpp
            // 
            this.txtCodCpp.Location = new System.Drawing.Point(374, 41);
            this.txtCodCpp.Name = "txtCodCpp";
            this.txtCodCpp.Size = new System.Drawing.Size(63, 20);
            this.txtCodCpp.TabIndex = 1;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(88, 67);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(349, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(88, 42);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(199, 20);
            this.txtEmail1.TabIndex = 0;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(561, 342);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 12;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // cboBalances
            // 
            this.cboBalances.FormattingEnabled = true;
            this.cboBalances.Location = new System.Drawing.Point(144, 12);
            this.cboBalances.Name = "cboBalances";
            this.cboBalances.Size = new System.Drawing.Size(121, 21);
            this.cboBalances.TabIndex = 13;
            this.cboBalances.SelectedIndexChanged += new System.EventHandler(this.cboBalances_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(18, 15);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(116, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Balances por fecha";
            // 
            // frmBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 590);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.cboBalances);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbDatContador);
            this.Controls.Add(this.btnExportar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbMonExt);
            this.Controls.Add(this.grbAuditado);
            this.Controls.Add(this.conTLVBalance1);
            this.Name = "frmBalance";
            this.Text = "Balance General";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.conTLVBalance1, 0);
            this.Controls.SetChildIndex(this.grbAuditado, 0);
            this.Controls.SetChildIndex(this.grbMonExt, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnExportar1, 0);
            this.Controls.SetChildIndex(this.grbDatContador, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.cboBalances, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.grbAuditado.ResumeLayout(false);
            this.grbAuditado.PerformLayout();
            this.grbMonExt.ResumeLayout(false);
            this.grbMonExt.PerformLayout();
            this.grbDatContador.ResumeLayout(false);
            this.grbDatContador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conTLVBalance conTLVBalance1;
        private GEN.ControlesBase.grbBase grbAuditado;
        private GEN.ControlesBase.rbtBase rbtAuditaNo;
        private GEN.ControlesBase.rbtBase rbtAuditaSi;
        private GEN.ControlesBase.grbBase grbMonExt;
        private GEN.ControlesBase.rbtBase rbtMonedaNo;
        private GEN.ControlesBase.rbtBase rbtMonedaSi;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnExportar btnExportar1;
        private GEN.ControlesBase.grbBase grbDatContador;
        private GEN.ControlesBase.txtBase txtContador;
        private GEN.ControlesBase.txtBase txtTelefono;
        private GEN.ControlesBase.txtBase txtCodCpp;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtEmail txtEmail1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBDNI txtDocIde;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.cboBase cboBalances;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}

