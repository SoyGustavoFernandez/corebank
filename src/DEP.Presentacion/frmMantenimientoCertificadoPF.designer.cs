namespace DEP.Presentacion
{
    partial class frmMantenimientoCertificadoPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCertificadoPF));
            this.nudFolio = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.nudLote = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecReg = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNroCuenta = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtCodCertificado = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMotEnvio = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtMotRecep = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMotAnu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAnular = new GEN.ControlesBase.chcBase(this.components);
            this.txtAnular = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLote)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudFolio
            // 
            this.nudFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFolio.Location = new System.Drawing.Point(253, 31);
            this.nudFolio.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudFolio.Name = "nudFolio";
            this.nudFolio.Size = new System.Drawing.Size(114, 20);
            this.nudFolio.TabIndex = 93;
            this.nudFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudFolio_KeyPress);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(47, 33);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(200, 13);
            this.lblBase8.TabIndex = 94;
            this.lblBase8.Text = "Ingrese el Nro. de Folio a Buscar:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(407, 17);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 97;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(12, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(539, 76);
            this.grbBase1.TabIndex = 98;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar Datos del Certificado";
            // 
            // nudLote
            // 
            this.nudLote.Enabled = false;
            this.nudLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLote.Location = new System.Drawing.Point(159, 45);
            this.nudLote.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudLote.Name = "nudLote";
            this.nudLote.Size = new System.Drawing.Size(87, 20);
            this.nudLote.TabIndex = 99;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 100;
            this.lblBase1.Text = "Nro LOTE:";
            // 
            // dtpFecReg
            // 
            this.dtpFecReg.Enabled = false;
            this.dtpFecReg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecReg.Location = new System.Drawing.Point(377, 45);
            this.dtpFecReg.Name = "dtpFecReg";
            this.dtpFecReg.Size = new System.Drawing.Size(131, 20);
            this.dtpFecReg.TabIndex = 102;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(277, 48);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(96, 13);
            this.lblBase5.TabIndex = 101;
            this.lblBase5.Text = "Fecha Registro:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(159, 19);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(356, 20);
            this.txtEstado.TabIndex = 104;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(125, 13);
            this.lblBase2.TabIndex = 103;
            this.lblBase2.Text = "Estado del Valorado:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(290, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(115, 13);
            this.lblBase3.TabIndex = 107;
            this.lblBase3.Text = "Nro Cta Vinculado:";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(411, 22);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(105, 20);
            this.txtNroCuenta.TabIndex = 105;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(27, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(139, 13);
            this.lblBase4.TabIndex = 108;
            this.lblBase4.Text = "Código del Certificado:";
            // 
            // txtCodCertificado
            // 
            this.txtCodCertificado.Enabled = false;
            this.txtCodCertificado.Location = new System.Drawing.Point(177, 21);
            this.txtCodCertificado.Name = "txtCodCertificado";
            this.txtCodCertificado.Size = new System.Drawing.Size(105, 20);
            this.txtCodCertificado.TabIndex = 106;
            // 
            // txtAgencia
            // 
            this.txtAgencia.BackColor = System.Drawing.SystemColors.Control;
            this.txtAgencia.Enabled = false;
            this.txtAgencia.Location = new System.Drawing.Point(176, 48);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(339, 20);
            this.txtAgencia.TabIndex = 110;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(27, 49);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(132, 13);
            this.lblBase6.TabIndex = 109;
            this.lblBase6.Text = "Agencia del Valorado:";
            // 
            // txtMotEnvio
            // 
            this.txtMotEnvio.Enabled = false;
            this.txtMotEnvio.Location = new System.Drawing.Point(127, 21);
            this.txtMotEnvio.Multiline = true;
            this.txtMotEnvio.Name = "txtMotEnvio";
            this.txtMotEnvio.Size = new System.Drawing.Size(398, 36);
            this.txtMotEnvio.TabIndex = 141;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(14, 23);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(84, 13);
            this.lblBase10.TabIndex = 140;
            this.lblBase10.Text = "Motivo Envió:";
            // 
            // txtMotRecep
            // 
            this.txtMotRecep.Enabled = false;
            this.txtMotRecep.Location = new System.Drawing.Point(127, 62);
            this.txtMotRecep.Multiline = true;
            this.txtMotRecep.Name = "txtMotRecep";
            this.txtMotRecep.Size = new System.Drawing.Size(398, 36);
            this.txtMotRecep.TabIndex = 143;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(14, 65);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(111, 13);
            this.lblBase7.TabIndex = 142;
            this.lblBase7.Text = "Motivo Recepción:";
            // 
            // txtMotAnu
            // 
            this.txtMotAnu.Enabled = false;
            this.txtMotAnu.Location = new System.Drawing.Point(127, 104);
            this.txtMotAnu.Multiline = true;
            this.txtMotAnu.Name = "txtMotAnu";
            this.txtMotAnu.Size = new System.Drawing.Size(398, 36);
            this.txtMotAnu.TabIndex = 145;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(14, 105);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(108, 13);
            this.lblBase9.TabIndex = 144;
            this.lblBase9.Text = "Motivo Anulación:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.nudLote);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtEstado);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.dtpFecReg);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Location = new System.Drawing.Point(12, 85);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(539, 75);
            this.grbBase2.TabIndex = 99;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Registro";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtCodCertificado);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.txtNroCuenta);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.txtAgencia);
            this.grbBase3.Location = new System.Drawing.Point(12, 167);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(539, 79);
            this.grbBase3.TabIndex = 99;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Vinculación";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.txtMotEnvio);
            this.grbBase4.Controls.Add(this.txtMotAnu);
            this.grbBase4.Controls.Add(this.lblBase10);
            this.grbBase4.Controls.Add(this.lblBase9);
            this.grbBase4.Controls.Add(this.lblBase7);
            this.grbBase4.Controls.Add(this.txtMotRecep);
            this.grbBase4.Location = new System.Drawing.Point(12, 256);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(539, 146);
            this.grbBase4.TabIndex = 99;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Buscar Datos del Certificado";
            // 
            // chcAnular
            // 
            this.chcAnular.AutoSize = true;
            this.chcAnular.Enabled = false;
            this.chcAnular.Location = new System.Drawing.Point(19, 445);
            this.chcAnular.Name = "chcAnular";
            this.chcAnular.Size = new System.Drawing.Size(115, 17);
            this.chcAnular.TabIndex = 100;
            this.chcAnular.Text = "Anular Certificado?";
            this.chcAnular.UseVisualStyleBackColor = true;
            this.chcAnular.CheckedChanged += new System.EventHandler(this.chcAnular_CheckedChanged);
            // 
            // txtAnular
            // 
            this.txtAnular.Enabled = false;
            this.txtAnular.Location = new System.Drawing.Point(139, 443);
            this.txtAnular.Multiline = true;
            this.txtAnular.Name = "txtAnular";
            this.txtAnular.Size = new System.Drawing.Size(398, 54);
            this.txtAnular.TabIndex = 141;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(141, 426);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(202, 13);
            this.lblBase11.TabIndex = 140;
            this.lblBase11.Text = "Motivo de Cambio del Certificado:";
            // 
            // grbBase5
            // 
            this.grbBase5.Location = new System.Drawing.Point(12, 409);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(539, 94);
            this.grbBase5.TabIndex = 99;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Anular Certificado";
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(351, 510);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 142;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(413, 511);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 144;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(491, 511);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 145;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoCertificadoPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 587);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.txtAnular);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.chcAnular);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.nudFolio);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmMantenimientoCertificadoPF";
            this.Text = "Mantenimiento de Certificados";
            this.Load += new System.EventHandler(this.frmMantenimientoCertificadoPF_Load);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.nudFolio, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.chcAnular, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtAnular, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudFolio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLote)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.nudBase nudFolio;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.nudBase nudLote;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecReg;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCuenta;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCertificado;
        private GEN.ControlesBase.txtBase txtAgencia;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtMotEnvio;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtMotRecep;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtMotAnu;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.chcBase chcAnular;
        private GEN.ControlesBase.txtBase txtAnular;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
    }
}