namespace CRE.Presentacion
{
    partial class frmRefinanciacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefinanciacion));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFechaRegistro = new GEN.ControlesBase.dtpCorto(this.components);
            this.nudCuotas = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboTipoPeriodo = new GEN.ControlesBase.cboTipoPeriodo(this.components);
            this.nudDiaPago = new GEN.ControlesBase.nudBase(this.components);
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.lblDesTipo = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoRefiancia = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpFecPriCuo = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaSol = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtMonPriCuo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnGestionContacto = new GEN.BotonesBase.Boton();
            this.conBusCuentaCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Controls.Add(this.grbBase1);
            this.conBusCuentaCli.Controls.Add(this.grbBase2);
            this.conBusCuentaCli.Location = new System.Drawing.Point(21, 9);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(567, 99);
            this.conBusCuentaCli.TabIndex = 4;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(3, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 99);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase2.Location = new System.Drawing.Point(0, -1);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(554, 94);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(383, 281);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 83;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(449, 281);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 82;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(515, 281);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 80;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Enabled = false;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(170, 140);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaRegistro.TabIndex = 78;
            // 
            // nudCuotas
            // 
            this.nudCuotas.Enabled = false;
            this.nudCuotas.Location = new System.Drawing.Point(455, 115);
            this.nudCuotas.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.Size = new System.Drawing.Size(120, 20);
            this.nudCuotas.TabIndex = 77;
            this.nudCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(659, 172);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(0, 13);
            this.lblBase15.TabIndex = 76;
            // 
            // cboTipoPeriodo
            // 
            this.cboTipoPeriodo.Enabled = false;
            this.cboTipoPeriodo.FormattingEnabled = true;
            this.cboTipoPeriodo.Location = new System.Drawing.Point(170, 218);
            this.cboTipoPeriodo.Name = "cboTipoPeriodo";
            this.cboTipoPeriodo.Size = new System.Drawing.Size(113, 21);
            this.cboTipoPeriodo.TabIndex = 75;
            this.cboTipoPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged);
            // 
            // nudDiaPago
            // 
            this.nudDiaPago.Enabled = false;
            this.nudDiaPago.Location = new System.Drawing.Point(170, 248);
            this.nudDiaPago.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiaPago.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaPago.Name = "nudDiaPago";
            this.nudDiaPago.Size = new System.Drawing.Size(113, 20);
            this.nudDiaPago.TabIndex = 69;
            this.nudDiaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDiaPago.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Enabled = false;
            this.nudDiasGracia.Location = new System.Drawing.Point(170, 192);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.Size = new System.Drawing.Size(113, 20);
            this.nudDiasGracia.TabIndex = 67;
            this.nudDiasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDesTipo
            // 
            this.lblDesTipo.AutoSize = true;
            this.lblDesTipo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDesTipo.ForeColor = System.Drawing.Color.Navy;
            this.lblDesTipo.Location = new System.Drawing.Point(16, 252);
            this.lblDesTipo.Name = "lblDesTipo";
            this.lblDesTipo.Size = new System.Drawing.Size(81, 13);
            this.lblDesTipo.TabIndex = 74;
            this.lblDesTipo.Text = "Día de Pago:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 119);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(122, 13);
            this.lblBase1.TabIndex = 64;
            this.lblBase1.Text = "Monto a refinanciar:";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Enabled = false;
            this.txtTasaInteres.FormatoDecimal = false;
            this.txtTasaInteres.Location = new System.Drawing.Point(170, 166);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaInteres.nNumDecimales = 2;
            this.txtTasaInteres.nvalor = 0D;
            this.txtTasaInteres.Size = new System.Drawing.Size(113, 20);
            this.txtTasaInteres.TabIndex = 66;
            this.txtTasaInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoRefiancia
            // 
            this.txtMontoRefiancia.Enabled = false;
            this.txtMontoRefiancia.FormatoDecimal = false;
            this.txtMontoRefiancia.Location = new System.Drawing.Point(170, 115);
            this.txtMontoRefiancia.Name = "txtMontoRefiancia";
            this.txtMontoRefiancia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoRefiancia.nNumDecimales = 2;
            this.txtMontoRefiancia.nvalor = 0D;
            this.txtMontoRefiancia.Size = new System.Drawing.Size(113, 20);
            this.txtMontoRefiancia.TabIndex = 65;
            this.txtMontoRefiancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(16, 222);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(101, 13);
            this.lblBase6.TabIndex = 73;
            this.lblBase6.Text = "Tipo de Periodo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 196);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(96, 13);
            this.lblBase5.TabIndex = 72;
            this.lblBase5.Text = "Días de Gracia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 170);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(81, 13);
            this.lblBase3.TabIndex = 71;
            this.lblBase3.Text = "Tasa interés:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(293, 119);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(119, 13);
            this.lblBase4.TabIndex = 70;
            this.lblBase4.Text = "Número de Cuotas:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 144);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(146, 13);
            this.lblBase2.TabIndex = 68;
            this.lblBase2.Text = "Fecha de refinanciación:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(455, 190);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(120, 21);
            this.cboMoneda1.TabIndex = 85;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(293, 194);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 86;
            this.lblBase7.Text = "Moneda:";
            // 
            // dtpFecPriCuo
            // 
            this.dtpFecPriCuo.Enabled = false;
            this.dtpFecPriCuo.Location = new System.Drawing.Point(455, 165);
            this.dtpFecPriCuo.Name = "dtpFecPriCuo";
            this.dtpFecPriCuo.Size = new System.Drawing.Size(120, 20);
            this.dtpFecPriCuo.TabIndex = 93;
            // 
            // dtpFechaSol
            // 
            this.dtpFechaSol.Enabled = false;
            this.dtpFechaSol.Location = new System.Drawing.Point(455, 216);
            this.dtpFechaSol.Name = "dtpFechaSol";
            this.dtpFechaSol.Size = new System.Drawing.Size(118, 20);
            this.dtpFechaSol.TabIndex = 87;
            // 
            // txtMonPriCuo
            // 
            this.txtMonPriCuo.Enabled = false;
            this.txtMonPriCuo.Location = new System.Drawing.Point(455, 140);
            this.txtMonPriCuo.Name = "txtMonPriCuo";
            this.txtMonPriCuo.Size = new System.Drawing.Size(120, 20);
            this.txtMonPriCuo.TabIndex = 91;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(293, 220);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(115, 13);
            this.lblBase17.TabIndex = 94;
            this.lblBase17.Text = "Fecha de Solicitud:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(293, 169);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(165, 13);
            this.lblBase8.TabIndex = 92;
            this.lblBase8.Text = "Fecha de Pago - 1ra Cuota:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(293, 144);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(107, 13);
            this.lblBase9.TabIndex = 90;
            this.lblBase9.Text = "Monto 1ra Cuota:";
            // 
            // btnGestionContacto
            // 
            this.btnGestionContacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestionContacto.Location = new System.Drawing.Point(440, 18);
            this.btnGestionContacto.Name = "btnGestionContacto";
            this.btnGestionContacto.Size = new System.Drawing.Size(60, 50);
            this.btnGestionContacto.TabIndex = 126;
            this.btnGestionContacto.Text = "Gestión de Contacto";
            this.btnGestionContacto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionContacto.UseVisualStyleBackColor = true;
            this.btnGestionContacto.Click += new System.EventHandler(this.btnGestionContacto_Click);
            // 
            // frmRefinanciacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 367);
            this.Controls.Add(this.dtpFecPriCuo);
            this.Controls.Add(this.dtpFechaSol);
            this.Controls.Add(this.txtMonPriCuo);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.nudCuotas);
            this.Controls.Add(this.lblBase15);
            this.Controls.Add(this.cboTipoPeriodo);
            this.Controls.Add(this.nudDiaPago);
            this.Controls.Add(this.nudDiasGracia);
            this.Controls.Add(this.lblDesTipo);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtTasaInteres);
            this.Controls.Add(this.txtMontoRefiancia);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnGestionContacto);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmRefinanciacion";
            this.Text = "Refinanciación de Créditos";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.btnGestionContacto, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMontoRefiancia, 0);
            this.Controls.SetChildIndex(this.txtTasaInteres, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblDesTipo, 0);
            this.Controls.SetChildIndex(this.nudDiasGracia, 0);
            this.Controls.SetChildIndex(this.nudDiaPago, 0);
            this.Controls.SetChildIndex(this.cboTipoPeriodo, 0);
            this.Controls.SetChildIndex(this.lblBase15, 0);
            this.Controls.SetChildIndex(this.nudCuotas, 0);
            this.Controls.SetChildIndex(this.dtpFechaRegistro, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase17, 0);
            this.Controls.SetChildIndex(this.txtMonPriCuo, 0);
            this.Controls.SetChildIndex(this.dtpFechaSol, 0);
            this.Controls.SetChildIndex(this.dtpFecPriCuo, 0);
            this.conBusCuentaCli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFechaRegistro;
        private GEN.ControlesBase.nudBase nudCuotas;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboTipoPeriodo cboTipoPeriodo;
        private GEN.ControlesBase.nudBase nudDiaPago;
        private GEN.ControlesBase.nudBase nudDiasGracia;
        private GEN.ControlesBase.lblBase lblDesTipo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtTasaInteres;
        private GEN.ControlesBase.txtNumRea txtMontoRefiancia;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtpCorto dtpFecPriCuo;
        private GEN.ControlesBase.dtpCorto dtpFechaSol;
        private GEN.ControlesBase.txtBase txtMonPriCuo;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.Boton btnGestionContacto;
    }
}

