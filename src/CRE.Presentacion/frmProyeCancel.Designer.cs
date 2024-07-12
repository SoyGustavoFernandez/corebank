namespace CRE.Presentacion
{
    partial class frmProyeCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProyeCancel));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtIntComp = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.txtTotalAPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtRedondeo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtImpuestos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.txtCapital = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoNeto = new GEN.ControlesBase.txtBase(this.components);
            this.txtOtros = new GEN.ControlesBase.txtBase(this.components);
            this.txtMoraCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtInteres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dFechaProyec = new System.Windows.Forms.DateTimePicker();
            this.pnlDatCliente = new System.Windows.Forms.Panel();
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.grbBase2.SuspendLayout();
            this.pnlDatCliente.SuspendLayout();
            this.conBusCuentaCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.Color.Transparent;
            this.grbBase2.Controls.Add(this.txtIntComp);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.txtTotalAPagar);
            this.grbBase2.Controls.Add(this.txtRedondeo);
            this.grbBase2.Controls.Add(this.txtImpuestos);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase17);
            this.grbBase2.Controls.Add(this.txtCapital);
            this.grbBase2.Controls.Add(this.txtMontoNeto);
            this.grbBase2.Controls.Add(this.txtOtros);
            this.grbBase2.Controls.Add(this.txtMoraCredito);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtInteres);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grbBase2.Location = new System.Drawing.Point(36, 140);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(297, 260);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            // 
            // txtIntComp
            // 
            this.txtIntComp.Enabled = false;
            this.txtIntComp.Location = new System.Drawing.Point(144, 71);
            this.txtIntComp.Name = "txtIntComp";
            this.txtIntComp.Size = new System.Drawing.Size(129, 20);
            this.txtIntComp.TabIndex = 23;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(15, 74);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(123, 13);
            this.lblBase15.TabIndex = 24;
            this.lblBase15.Text = "Int. Compensatorio:";
            // 
            // txtTotalAPagar
            // 
            this.txtTotalAPagar.Enabled = false;
            this.txtTotalAPagar.FormatoDecimal = false;
            this.txtTotalAPagar.Location = new System.Drawing.Point(144, 227);
            this.txtTotalAPagar.Name = "txtTotalAPagar";
            this.txtTotalAPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalAPagar.nNumDecimales = 4;
            this.txtTotalAPagar.nvalor = 0D;
            this.txtTotalAPagar.Size = new System.Drawing.Size(129, 20);
            this.txtTotalAPagar.TabIndex = 8;
            // 
            // txtRedondeo
            // 
            this.txtRedondeo.Enabled = false;
            this.txtRedondeo.FormatoDecimal = false;
            this.txtRedondeo.Location = new System.Drawing.Point(144, 201);
            this.txtRedondeo.Name = "txtRedondeo";
            this.txtRedondeo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRedondeo.nNumDecimales = 4;
            this.txtRedondeo.nvalor = 0D;
            this.txtRedondeo.Size = new System.Drawing.Size(129, 20);
            this.txtRedondeo.TabIndex = 7;
            // 
            // txtImpuestos
            // 
            this.txtImpuestos.Enabled = false;
            this.txtImpuestos.FormatoDecimal = false;
            this.txtImpuestos.Location = new System.Drawing.Point(144, 175);
            this.txtImpuestos.Name = "txtImpuestos";
            this.txtImpuestos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImpuestos.nNumDecimales = 4;
            this.txtImpuestos.nvalor = 0D;
            this.txtImpuestos.Size = new System.Drawing.Size(129, 20);
            this.txtImpuestos.TabIndex = 6;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(15, 152);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(89, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "MONTO NETO:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(15, 230);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(85, 13);
            this.lblBase17.TabIndex = 6;
            this.lblBase17.Text = "TOTAL PAGO:";
            // 
            // txtCapital
            // 
            this.txtCapital.Enabled = false;
            this.txtCapital.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtCapital.Location = new System.Drawing.Point(144, 19);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.Size = new System.Drawing.Size(129, 20);
            this.txtCapital.TabIndex = 1;
            // 
            // txtMontoNeto
            // 
            this.txtMontoNeto.Enabled = false;
            this.txtMontoNeto.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtMontoNeto.Location = new System.Drawing.Point(144, 149);
            this.txtMontoNeto.Name = "txtMontoNeto";
            this.txtMontoNeto.Size = new System.Drawing.Size(129, 20);
            this.txtMontoNeto.TabIndex = 5;
            // 
            // txtOtros
            // 
            this.txtOtros.Enabled = false;
            this.txtOtros.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtOtros.Location = new System.Drawing.Point(144, 123);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.Size = new System.Drawing.Size(129, 20);
            this.txtOtros.TabIndex = 4;
            // 
            // txtMoraCredito
            // 
            this.txtMoraCredito.Enabled = false;
            this.txtMoraCredito.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtMoraCredito.Location = new System.Drawing.Point(144, 97);
            this.txtMoraCredito.Name = "txtMoraCredito";
            this.txtMoraCredito.Size = new System.Drawing.Size(129, 20);
            this.txtMoraCredito.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 204);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Redondeo:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(15, 100);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(107, 13);
            this.lblBase8.TabIndex = 10;
            this.lblBase8.Text = "Mora del Crédito:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 178);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(100, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Impuestos(ITF):";
            // 
            // txtInteres
            // 
            this.txtInteres.Enabled = false;
            this.txtInteres.Location = new System.Drawing.Point(144, 45);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(129, 20);
            this.txtInteres.TabIndex = 2;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(15, 126);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(43, 13);
            this.lblBase9.TabIndex = 11;
            this.lblBase9.Text = "Otros:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(15, 48);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(53, 13);
            this.lblBase7.TabIndex = 9;
            this.lblBase7.Text = "Interés:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(52, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Capital:";
            // 
            // dFechaProyec
            // 
            this.dFechaProyec.Enabled = false;
            this.dFechaProyec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaProyec.Location = new System.Drawing.Point(343, 147);
            this.dFechaProyec.Margin = new System.Windows.Forms.Padding(2);
            this.dFechaProyec.Name = "dFechaProyec";
            this.dFechaProyec.Size = new System.Drawing.Size(157, 20);
            this.dFechaProyec.TabIndex = 4;
            this.dFechaProyec.ValueChanged += new System.EventHandler(this.dFechaProyec_ValueChanged);
            // 
            // pnlDatCliente
            // 
            this.pnlDatCliente.Controls.Add(this.conBusCuentaCli);
            this.pnlDatCliente.Location = new System.Drawing.Point(36, 15);
            this.pnlDatCliente.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDatCliente.Name = "pnlDatCliente";
            this.pnlDatCliente.Size = new System.Drawing.Size(574, 110);
            this.pnlDatCliente.TabIndex = 6;
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Controls.Add(this.grbBase1);
            this.conBusCuentaCli.Controls.Add(this.grbBase3);
            this.conBusCuentaCli.Location = new System.Drawing.Point(3, 6);
            this.conBusCuentaCli.Margin = new System.Windows.Forms.Padding(4);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(562, 102);
            this.conBusCuentaCli.TabIndex = 1;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(4, -2);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(4);
            this.grbBase1.Size = new System.Drawing.Size(739, 122);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // grbBase3
            // 
            this.grbBase3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase3.Location = new System.Drawing.Point(3, -2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(554, 99);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Cliente";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(521, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnRechazar1;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(448, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.Control;
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(521, 140);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 59;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // frmProyeCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(623, 442);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlDatCliente);
            this.Controls.Add(this.dFechaProyec);
            this.Controls.Add(this.grbBase2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProyeCancel";
            this.Text = "Simulador - Proyección de Cancelación";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProyeCancel_FormClosed);
            this.Load += new System.EventHandler(this.frmProyeCancel_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.dFechaProyec, 0);
            this.Controls.SetChildIndex(this.pnlDatCliente, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.pnlDatCliente.ResumeLayout(false);
            this.conBusCuentaCli.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtIntComp;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.txtNumRea txtTotalAPagar;
        private GEN.ControlesBase.txtNumRea txtRedondeo;
        private GEN.ControlesBase.txtNumRea txtImpuestos;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtBase txtCapital;
        private GEN.ControlesBase.txtBase txtMontoNeto;
        private GEN.ControlesBase.txtBase txtOtros;
        private GEN.ControlesBase.txtBase txtMoraCredito;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtInteres;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DateTimePicker dFechaProyec;
        private System.Windows.Forms.Panel pnlDatCliente;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnProcesar btnProcesar;


    }
}