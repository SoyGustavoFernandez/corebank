namespace DEP.Presentacion
{
    partial class frmCalculoCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculoCTS));
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtNroRemuneraciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblRemuTotal = new GEN.ControlesBase.lblBase();
            this.lblNroRemun = new GEN.ControlesBase.lblBase();
            this.lblSaldoDispo = new GEN.ControlesBase.lblBase();
            this.lblSaldoIntangible = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chcTipCambio = new GEN.ControlesBase.chcBase(this.components);
            this.txtSaldoConvert = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtRemConvert = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtRemuTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMontoDeposito = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMontoDeposito = new GEN.ControlesBase.lblBase();
            this.btnCalcular = new GEN.BotonesBase.btnCalcular();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.txtSaldoDisponible = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSaldoIntangible = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtDolares = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtSoles = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.groupBox1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(263, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(329, 406);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtNroRemuneraciones
            // 
            this.txtNroRemuneraciones.Location = new System.Drawing.Point(180, 97);
            this.txtNroRemuneraciones.Name = "txtNroRemuneraciones";
            this.txtNroRemuneraciones.Size = new System.Drawing.Size(67, 20);
            this.txtNroRemuneraciones.TabIndex = 5;
            // 
            // lblRemuTotal
            // 
            this.lblRemuTotal.AutoSize = true;
            this.lblRemuTotal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblRemuTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblRemuTotal.Location = new System.Drawing.Point(15, 126);
            this.lblRemuTotal.Name = "lblRemuTotal";
            this.lblRemuTotal.Size = new System.Drawing.Size(130, 13);
            this.lblRemuTotal.TabIndex = 7;
            this.lblRemuTotal.Text = "Remumeración Total:";
            // 
            // lblNroRemun
            // 
            this.lblNroRemun.AutoSize = true;
            this.lblNroRemun.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroRemun.ForeColor = System.Drawing.Color.Navy;
            this.lblNroRemun.Location = new System.Drawing.Point(15, 100);
            this.lblNroRemun.Name = "lblNroRemun";
            this.lblNroRemun.Size = new System.Drawing.Size(135, 13);
            this.lblNroRemun.TabIndex = 8;
            this.lblNroRemun.Text = "Nro. Remuneraciones:";
            // 
            // lblSaldoDispo
            // 
            this.lblSaldoDispo.AutoSize = true;
            this.lblSaldoDispo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoDispo.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoDispo.Location = new System.Drawing.Point(44, 369);
            this.lblSaldoDispo.Name = "lblSaldoDispo";
            this.lblSaldoDispo.Size = new System.Drawing.Size(107, 13);
            this.lblSaldoDispo.TabIndex = 9;
            this.lblSaldoDispo.Text = "Saldo Disponible:";
            // 
            // lblSaldoIntangible
            // 
            this.lblSaldoIntangible.AutoSize = true;
            this.lblSaldoIntangible.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoIntangible.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoIntangible.Location = new System.Drawing.Point(44, 343);
            this.lblSaldoIntangible.Name = "lblSaldoIntangible";
            this.lblSaldoIntangible.Size = new System.Drawing.Size(105, 13);
            this.lblSaldoIntangible.TabIndex = 10;
            this.lblSaldoIntangible.Text = "Saldo Intangible:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chcTipCambio);
            this.groupBox1.Controls.Add(this.txtSaldoConvert);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.txtRemConvert);
            this.groupBox1.Controls.Add(this.txtTipoCambio);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.txtRemuTotal);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.txtMontoDeposito);
            this.groupBox1.Controls.Add(this.lblMontoDeposito);
            this.groupBox1.Controls.Add(this.txtNroRemuneraciones);
            this.groupBox1.Controls.Add(this.lblRemuTotal);
            this.groupBox1.Controls.Add(this.lblNroRemun);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 179);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculo CTS";
            // 
            // chcTipCambio
            // 
            this.chcTipCambio.AutoSize = true;
            this.chcTipCambio.Location = new System.Drawing.Point(249, 24);
            this.chcTipCambio.Name = "chcTipCambio";
            this.chcTipCambio.Size = new System.Drawing.Size(131, 17);
            this.chcTipCambio.TabIndex = 17;
            this.chcTipCambio.Text = "Modificar Tipo Cambio";
            this.chcTipCambio.UseVisualStyleBackColor = true;
            this.chcTipCambio.CheckedChanged += new System.EventHandler(this.chcTipCambio_CheckedChanged);
            // 
            // txtSaldoConvert
            // 
            this.txtSaldoConvert.Enabled = false;
            this.txtSaldoConvert.FormatoDecimal = false;
            this.txtSaldoConvert.Location = new System.Drawing.Point(180, 71);
            this.txtSaldoConvert.Name = "txtSaldoConvert";
            this.txtSaldoConvert.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoConvert.nNumDecimales = 4;
            this.txtSaldoConvert.nvalor = 0D;
            this.txtSaldoConvert.Size = new System.Drawing.Size(130, 20);
            this.txtSaldoConvert.TabIndex = 16;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 74);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(111, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Saldo Convertido:";
            // 
            // txtRemConvert
            // 
            this.txtRemConvert.Enabled = false;
            this.txtRemConvert.FormatoDecimal = false;
            this.txtRemConvert.Location = new System.Drawing.Point(180, 149);
            this.txtRemConvert.Name = "txtRemConvert";
            this.txtRemConvert.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRemConvert.nNumDecimales = 4;
            this.txtRemConvert.nvalor = 0D;
            this.txtRemConvert.Size = new System.Drawing.Size(130, 20);
            this.txtRemConvert.TabIndex = 14;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.FormatoDecimal = false;
            this.txtTipoCambio.Location = new System.Drawing.Point(180, 21);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipoCambio.nNumDecimales = 4;
            this.txtTipoCambio.nvalor = 0D;
            this.txtTipoCambio.Size = new System.Drawing.Size(67, 20);
            this.txtTipoCambio.TabIndex = 13;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 152);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(161, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Remuneración Convertido:";
            // 
            // txtRemuTotal
            // 
            this.txtRemuTotal.FormatoDecimal = false;
            this.txtRemuTotal.Location = new System.Drawing.Point(180, 123);
            this.txtRemuTotal.Name = "txtRemuTotal";
            this.txtRemuTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRemuTotal.nNumDecimales = 4;
            this.txtRemuTotal.nvalor = 0D;
            this.txtRemuTotal.Size = new System.Drawing.Size(130, 20);
            this.txtRemuTotal.TabIndex = 12;
            this.txtRemuTotal.Leave += new System.EventHandler(this.txtRemuTotal_Leave);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(102, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Tipo de Cambio:";
            // 
            // txtMontoDeposito
            // 
            this.txtMontoDeposito.FormatoDecimal = false;
            this.txtMontoDeposito.Location = new System.Drawing.Point(180, 47);
            this.txtMontoDeposito.Name = "txtMontoDeposito";
            this.txtMontoDeposito.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoDeposito.nNumDecimales = 4;
            this.txtMontoDeposito.nvalor = 0D;
            this.txtMontoDeposito.Size = new System.Drawing.Size(130, 20);
            this.txtMontoDeposito.TabIndex = 11;
            this.txtMontoDeposito.Leave += new System.EventHandler(this.txtMontoDeposito_Leave);
            // 
            // lblMontoDeposito
            // 
            this.lblMontoDeposito.AutoSize = true;
            this.lblMontoDeposito.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMontoDeposito.ForeColor = System.Drawing.Color.Navy;
            this.lblMontoDeposito.Location = new System.Drawing.Point(15, 50);
            this.lblMontoDeposito.Name = "lblMontoDeposito";
            this.lblMontoDeposito.Size = new System.Drawing.Size(121, 13);
            this.lblMontoDeposito.TabIndex = 10;
            this.lblMontoDeposito.Text = "Saldo Total Cuenta:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalcular.BackgroundImage")));
            this.btnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCalcular.Location = new System.Drawing.Point(197, 406);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(60, 50);
            this.btnCalcular.TabIndex = 14;
            this.btnCalcular.Text = "C&alcular";
            this.btnCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(131, 406);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtSaldoDisponible
            // 
            this.txtSaldoDisponible.FormatoDecimal = false;
            this.txtSaldoDisponible.Location = new System.Drawing.Point(157, 366);
            this.txtSaldoDisponible.Name = "txtSaldoDisponible";
            this.txtSaldoDisponible.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDisponible.nNumDecimales = 2;
            this.txtSaldoDisponible.nvalor = 0D;
            this.txtSaldoDisponible.Size = new System.Drawing.Size(140, 20);
            this.txtSaldoDisponible.TabIndex = 16;
            // 
            // txtSaldoIntangible
            // 
            this.txtSaldoIntangible.FormatoDecimal = false;
            this.txtSaldoIntangible.Location = new System.Drawing.Point(157, 341);
            this.txtSaldoIntangible.Name = "txtSaldoIntangible";
            this.txtSaldoIntangible.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoIntangible.nNumDecimales = 2;
            this.txtSaldoIntangible.nvalor = 0D;
            this.txtSaldoIntangible.Size = new System.Drawing.Size(140, 20);
            this.txtSaldoIntangible.TabIndex = 17;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(133, 13);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Moneda de la Cuenta:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(178, 21);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(162, 21);
            this.cboMoneda.TabIndex = 18;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(12, 5);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(383, 45);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Parámetros Generales";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtDolares);
            this.grbBase2.Controls.Add(this.rbtSoles);
            this.grbBase2.Location = new System.Drawing.Point(12, 63);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(383, 58);
            this.grbBase2.TabIndex = 20;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Moneda en la que Proviene su Sueldo";
            // 
            // rbtDolares
            // 
            this.rbtDolares.AutoSize = true;
            this.rbtDolares.ForeColor = System.Drawing.Color.Navy;
            this.rbtDolares.Location = new System.Drawing.Point(212, 27);
            this.rbtDolares.Name = "rbtDolares";
            this.rbtDolares.Size = new System.Drawing.Size(61, 17);
            this.rbtDolares.TabIndex = 1;
            this.rbtDolares.TabStop = true;
            this.rbtDolares.Text = "Dólares";
            this.rbtDolares.UseVisualStyleBackColor = true;
            this.rbtDolares.CheckedChanged += new System.EventHandler(this.rbtDolares_CheckedChanged);
            // 
            // rbtSoles
            // 
            this.rbtSoles.AutoSize = true;
            this.rbtSoles.ForeColor = System.Drawing.Color.Navy;
            this.rbtSoles.Location = new System.Drawing.Point(66, 27);
            this.rbtSoles.Name = "rbtSoles";
            this.rbtSoles.Size = new System.Drawing.Size(91, 17);
            this.rbtSoles.TabIndex = 0;
            this.rbtSoles.TabStop = true;
            this.rbtSoles.Text = "Nuevos Soles";
            this.rbtSoles.UseVisualStyleBackColor = true;
            this.rbtSoles.CheckedChanged += new System.EventHandler(this.rbtSoles_CheckedChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(12, 325);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(383, 69);
            this.grbBase3.TabIndex = 20;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Saldos Convertidos en la Moneda";
            // 
            // frmCalculoCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 505);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtSaldoIntangible);
            this.Controls.Add(this.txtSaldoDisponible);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblSaldoDispo);
            this.Controls.Add(this.lblSaldoIntangible);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmCalculoCTS";
            this.Text = "Calculo CTS";
            this.Load += new System.EventHandler(this.frmCalculoCTS_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblSaldoIntangible, 0);
            this.Controls.SetChildIndex(this.lblSaldoDispo, 0);
            this.Controls.SetChildIndex(this.btnCalcular, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.txtSaldoDisponible, 0);
            this.Controls.SetChildIndex(this.txtSaldoIntangible, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtNroRemuneraciones;
        private GEN.ControlesBase.lblBase lblRemuTotal;
        private GEN.ControlesBase.lblBase lblNroRemun;
        private GEN.ControlesBase.lblBase lblSaldoDispo;
        private GEN.ControlesBase.lblBase lblSaldoIntangible;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnCalcular btnCalcular;
        private GEN.ControlesBase.lblBase lblMontoDeposito;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.txtNumRea txtRemuTotal;
        private GEN.ControlesBase.txtNumRea txtMontoDeposito;
        private GEN.ControlesBase.txtNumRea txtSaldoDisponible;
        private GEN.ControlesBase.txtNumRea txtSaldoIntangible;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtNumRea txtTipoCambio;
        private GEN.ControlesBase.txtNumRea txtRemConvert;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.rbtBase rbtDolares;
        private GEN.ControlesBase.rbtBase rbtSoles;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtSaldoConvert;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.chcBase chcTipCambio;

    }
}