namespace CNT.Presentacion
{
    partial class frmAmortizarCuentasXCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAmortizarCuentasXCobrar));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpFechControl = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtTotalPago = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoCuentasCobrar1 = new GEN.ControlesBase.cboTipoCuentasCobrar(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtSaldoAnterior = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.dtpFechPago = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMontoPago = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgPagoCxC = new System.Windows.Forms.DataGridView();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPago1 = new GEN.ControlesBase.cboTipoPago(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtNuevoSando = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnExtorno1 = new GEN.BotonesBase.btnExtorno();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCxC)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(10, 11);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            this.conBusCli.Load += new System.EventHandler(this.conBusCli_Load);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 49);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Monto :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 20);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(100, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Tipo de cuenta :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(225, 48);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(142, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Fecha inicio operación :";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.FormatoDecimal = true;
            this.txtMonto.Location = new System.Drawing.Point(110, 46);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(109, 20);
            this.txtMonto.TabIndex = 2;
            // 
            // dtpFechControl
            // 
            this.dtpFechControl.Enabled = false;
            this.dtpFechControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechControl.Location = new System.Drawing.Point(358, 46);
            this.dtpFechControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechControl.Name = "dtpFechControl";
            this.dtpFechControl.Size = new System.Drawing.Size(84, 20);
            this.dtpFechControl.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase11);
            this.grbBase1.Controls.Add(this.txtTotalPago);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtObservacion);
            this.grbBase1.Controls.Add(this.cboTipoCuentasCobrar1);
            this.grbBase1.Controls.Add(this.chcVigente);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFechControl);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtSaldoAnterior);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Location = new System.Drawing.Point(10, 120);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase1.Size = new System.Drawing.Size(531, 162);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(7, 72);
            this.lblBase11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(90, 13);
            this.lblBase11.TabIndex = 22;
            this.lblBase11.Text = "Total Pagado :";
            // 
            // txtTotalPago
            // 
            this.txtTotalPago.Enabled = false;
            this.txtTotalPago.FormatoDecimal = true;
            this.txtTotalPago.Location = new System.Drawing.Point(110, 72);
            this.txtTotalPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalPago.Name = "txtTotalPago";
            this.txtTotalPago.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPago.nNumDecimales = 2;
            this.txtTotalPago.nvalor = 0D;
            this.txtTotalPago.Size = new System.Drawing.Size(109, 20);
            this.txtTotalPago.TabIndex = 21;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 102);
            this.lblBase8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(96, 13);
            this.lblBase8.TabIndex = 19;
            this.lblBase8.Text = "Observaciones:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(110, 99);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(407, 56);
            this.txtObservacion.TabIndex = 3;
            // 
            // cboTipoCuentasCobrar1
            // 
            this.cboTipoCuentasCobrar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuentasCobrar1.Enabled = false;
            this.cboTipoCuentasCobrar1.FormattingEnabled = true;
            this.cboTipoCuentasCobrar1.Location = new System.Drawing.Point(110, 17);
            this.cboTipoCuentasCobrar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipoCuentasCobrar1.Name = "cboTipoCuentasCobrar1";
            this.cboTipoCuentasCobrar1.Size = new System.Drawing.Size(408, 21);
            this.cboTipoCuentasCobrar1.TabIndex = 0;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Enabled = false;
            this.chcVigente.Location = new System.Drawing.Point(504, 50);
            this.chcVigente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(15, 14);
            this.chcVigente.TabIndex = 4;
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(225, 76);
            this.lblBase7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(48, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Saldo :";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(451, 49);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Vigente:";
            // 
            // txtSaldoAnterior
            // 
            this.txtSaldoAnterior.Enabled = false;
            this.txtSaldoAnterior.FormatoDecimal = true;
            this.txtSaldoAnterior.Location = new System.Drawing.Point(278, 73);
            this.txtSaldoAnterior.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaldoAnterior.Name = "txtSaldoAnterior";
            this.txtSaldoAnterior.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoAnterior.nNumDecimales = 2;
            this.txtSaldoAnterior.nvalor = 0D;
            this.txtSaldoAnterior.Size = new System.Drawing.Size(109, 20);
            this.txtSaldoAnterior.TabIndex = 1;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(483, 426);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(299, 425);
            this.btnGrabar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 15;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(422, 426);
            this.btnCancelar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 14;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(238, 425);
            this.btnNuevo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 12;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // dtpFechPago
            // 
            this.dtpFechPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechPago.Location = new System.Drawing.Point(421, 17);
            this.dtpFechPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechPago.Name = "dtpFechPago";
            this.dtpFechPago.Size = new System.Drawing.Size(102, 20);
            this.dtpFechPago.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(338, 18);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(81, 13);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "Fecha pago :";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(338, 41);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(78, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "Monto pago:";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.FormatoDecimal = true;
            this.txtMontoPago.Location = new System.Drawing.Point(421, 40);
            this.txtMontoPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoPago.nNumDecimales = 2;
            this.txtMontoPago.nvalor = 0D;
            this.txtMontoPago.Size = new System.Drawing.Size(102, 20);
            this.txtMontoPago.TabIndex = 3;
            this.txtMontoPago.TextChanged += new System.EventHandler(this.txtMontoPago_TextChanged);
            // 
            // dtgPagoCxC
            // 
            this.dtgPagoCxC.AllowUserToAddRows = false;
            this.dtgPagoCxC.AllowUserToDeleteRows = false;
            this.dtgPagoCxC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagoCxC.Location = new System.Drawing.Point(4, 17);
            this.dtgPagoCxC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgPagoCxC.Name = "dtgPagoCxC";
            this.dtgPagoCxC.ReadOnly = true;
            this.dtgPagoCxC.RowTemplate.Height = 24;
            this.dtgPagoCxC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPagoCxC.Size = new System.Drawing.Size(325, 115);
            this.dtgPagoCxC.TabIndex = 0;
            this.dtgPagoCxC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPagoCxC_CellContentClick);
            this.dtgPagoCxC.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgPagoCxC_CellValidating);
            this.dtgPagoCxC.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPagoCxC_CellValueChanged);
            this.dtgPagoCxC.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPagoCxC_RowEnter);
            this.dtgPagoCxC.SelectionChanged += new System.EventHandler(this.dtgPagoCxC_SelectionChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboTipoPago1);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.txtNuevoSando);
            this.grbBase2.Controls.Add(this.dtgPagoCxC);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.dtpFechPago);
            this.grbBase2.Controls.Add(this.txtMontoPago);
            this.grbBase2.Location = new System.Drawing.Point(9, 284);
            this.grbBase2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBase2.Size = new System.Drawing.Size(532, 136);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Pagos";
            // 
            // cboTipoPago1
            // 
            this.cboTipoPago1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago1.Enabled = false;
            this.cboTipoPago1.FormattingEnabled = true;
            this.cboTipoPago1.Location = new System.Drawing.Point(421, 63);
            this.cboTipoPago1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipoPago1.Name = "cboTipoPago1";
            this.cboTipoPago1.Size = new System.Drawing.Size(102, 21);
            this.cboTipoPago1.TabIndex = 4;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(338, 65);
            this.lblBase10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(68, 13);
            this.lblBase10.TabIndex = 27;
            this.lblBase10.Text = "Tipo pago:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(338, 89);
            this.lblBase9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(88, 13);
            this.lblBase9.TabIndex = 25;
            this.lblBase9.Text = "Nuevo Saldo :";
            // 
            // txtNuevoSando
            // 
            this.txtNuevoSando.Enabled = false;
            this.txtNuevoSando.FormatoDecimal = true;
            this.txtNuevoSando.Location = new System.Drawing.Point(421, 87);
            this.txtNuevoSando.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNuevoSando.Name = "txtNuevoSando";
            this.txtNuevoSando.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNuevoSando.nNumDecimales = 2;
            this.txtNuevoSando.nvalor = 0D;
            this.txtNuevoSando.Size = new System.Drawing.Size(102, 20);
            this.txtNuevoSando.TabIndex = 5;
            // 
            // btnExtorno1
            // 
            this.btnExtorno1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno1.BackgroundImage")));
            this.btnExtorno1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno1.Location = new System.Drawing.Point(360, 426);
            this.btnExtorno1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExtorno1.Name = "btnExtorno1";
            this.btnExtorno1.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno1.TabIndex = 26;
            this.btnExtorno1.Text = "&Extornar";
            this.btnExtorno1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno1.UseVisualStyleBackColor = true;
            this.btnExtorno1.Click += new System.EventHandler(this.btnExtorno1_Click);
            // 
            // frmAmortizarCuentasXCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 505);
            this.Controls.Add(this.btnExtorno1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCli);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAmortizarCuentasXCobrar";
            this.Text = "Amortizar cuentas por cobrar";
            this.Load += new System.EventHandler(this.frmRegistroCuentasXCobrar_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnExtorno1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCxC)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.dtpCorto dtpFechControl;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTipoCuentasCobrar cboTipoCuentasCobrar1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.ControlesBase.dtpCorto dtpFechPago;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtMontoPago;
        private System.Windows.Forms.DataGridView dtgPagoCxC;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnExtorno btnExtorno1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtNuevoSando;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtSaldoAnterior;
        private GEN.ControlesBase.cboTipoPago cboTipoPago1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtTotalPago;
    }
}