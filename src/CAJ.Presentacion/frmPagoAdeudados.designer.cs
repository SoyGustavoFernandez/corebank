namespace CAJ.Presentacion
{
    partial class frmPagoAdeudados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoAdeudados));
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtTotalAPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblTotPagar = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase46 = new GEN.ControlesBase.lblBase();
            this.cboTipoDocumento = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.cboFormaPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase21 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.grbMontoCobar = new GEN.ControlesBase.grbBase(this.components);
            this.txtOtros = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblTextMoneda = new GEN.ControlesBase.lblBase();
            this.txtCapital = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase26 = new GEN.ControlesBase.lblBase();
            this.txtInteres = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblBase28 = new GEN.ControlesBase.lblBase();
            this.lblBase29 = new GEN.ControlesBase.lblBase();
            this.lblBase30 = new GEN.ControlesBase.lblBase();
            this.lblBase31 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboPagare = new GEN.ControlesBase.cboBase(this.components);
            this.lbUltCuota = new System.Windows.Forms.Label();
            this.chcCancelAnticipada = new GEN.ControlesBase.chcBase(this.components);
            this.txtNroDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAdeudo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNroCuota = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnExtorno1 = new GEN.BotonesBase.btnExtorno();
            this.dtgPlanPagos = new System.Windows.Forms.DataGridView();
            this.lblIC = new GEN.ControlesBase.lblBase();
            this.lblComision = new GEN.ControlesBase.lblBase();
            this.txtTotComPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbMontoCobar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(507, 404);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 19;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(629, 404);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 21;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // txtTotalAPagar
            // 
            this.txtTotalAPagar.Enabled = false;
            this.txtTotalAPagar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAPagar.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalAPagar.FormatoDecimal = false;
            this.txtTotalAPagar.Location = new System.Drawing.Point(87, 404);
            this.txtTotalAPagar.Name = "txtTotalAPagar";
            this.txtTotalAPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalAPagar.nNumDecimales = 4;
            this.txtTotalAPagar.nvalor = 0D;
            this.txtTotalAPagar.Size = new System.Drawing.Size(130, 27);
            this.txtTotalAPagar.TabIndex = 15;
            this.txtTotalAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotPagar
            // 
            this.lblTotPagar.AutoSize = true;
            this.lblTotPagar.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotPagar.ForeColor = System.Drawing.Color.Navy;
            this.lblTotPagar.Location = new System.Drawing.Point(2, 404);
            this.lblTotPagar.Name = "lblTotPagar";
            this.lblTotPagar.Size = new System.Drawing.Size(83, 13);
            this.lblTotPagar.TabIndex = 13;
            this.lblTotPagar.Text = "Total a Pagar";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 17);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Código Adeudado:";
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.Enabled = false;
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(151, 67);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(204, 21);
            this.cboTipoEntidad.TabIndex = 2;
            // 
            // cboEntidad
            // 
            this.cboEntidad.Enabled = false;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(151, 91);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(204, 21);
            this.cboEntidad.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 95);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(54, 13);
            this.lblBase4.TabIndex = 21;
            this.lblBase4.Text = "Entidad:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(21, 71);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Tipo Entidad:";
            // 
            // lblBase46
            // 
            this.lblBase46.AutoSize = true;
            this.lblBase46.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase46.ForeColor = System.Drawing.Color.Navy;
            this.lblBase46.Location = new System.Drawing.Point(21, 191);
            this.lblBase46.Name = "lblBase46";
            this.lblBase46.Size = new System.Drawing.Size(101, 13);
            this.lblBase46.TabIndex = 25;
            this.lblBase46.Text = "Nro Documento:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Items.AddRange(new object[] {
            "Cheque",
            "Comprobante de pago",
            "No identificado",
            "Nota de abono"});
            this.cboTipoDocumento.Location = new System.Drawing.Point(151, 164);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(204, 21);
            this.cboTipoDocumento.TabIndex = 6;
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(21, 167);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(105, 13);
            this.lblBase22.TabIndex = 24;
            this.lblBase22.Text = "Tipo Documento:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Items.AddRange(new object[] {
            "efectivo",
            "regularización por cambio de tasa",
            "regularización por cambio de cronograma",
            "otros"});
            this.cboFormaPago.Location = new System.Drawing.Point(151, 140);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(204, 21);
            this.cboFormaPago.TabIndex = 5;
            // 
            // lblBase21
            // 
            this.lblBase21.AutoSize = true;
            this.lblBase21.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase21.ForeColor = System.Drawing.Color.Navy;
            this.lblBase21.Location = new System.Drawing.Point(21, 144);
            this.lblBase21.Name = "lblBase21";
            this.lblBase21.Size = new System.Drawing.Size(80, 13);
            this.lblBase21.TabIndex = 23;
            this.lblBase21.Text = "Forma Pago:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(21, 45);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(76, 13);
            this.lblBase6.TabIndex = 19;
            this.lblBase6.Text = "Nro Pagaré:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(8, 70);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(78, 13);
            this.lblBase8.TabIndex = 3;
            this.lblBase8.Text = "Comisiones:";
            // 
            // txtComision
            // 
            this.txtComision.Enabled = false;
            this.txtComision.FormatoDecimal = false;
            this.txtComision.Location = new System.Drawing.Point(132, 66);
            this.txtComision.Name = "txtComision";
            this.txtComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtComision.nNumDecimales = 4;
            this.txtComision.nvalor = 0D;
            this.txtComision.ReadOnly = true;
            this.txtComision.Size = new System.Drawing.Size(123, 23);
            this.txtComision.TabIndex = 2;
            this.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(629, 10);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 10;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // grbMontoCobar
            // 
            this.grbMontoCobar.Controls.Add(this.txtOtros);
            this.grbMontoCobar.Controls.Add(this.txtMora);
            this.grbMontoCobar.Controls.Add(this.lblTextMoneda);
            this.grbMontoCobar.Controls.Add(this.txtCapital);
            this.grbMontoCobar.Controls.Add(this.lblBase26);
            this.grbMontoCobar.Controls.Add(this.txtInteres);
            this.grbMontoCobar.Controls.Add(this.txtTotal);
            this.grbMontoCobar.Controls.Add(this.btnCalcular);
            this.grbMontoCobar.Controls.Add(this.lblBase8);
            this.grbMontoCobar.Controls.Add(this.txtComision);
            this.grbMontoCobar.Controls.Add(this.lblBase28);
            this.grbMontoCobar.Controls.Add(this.lblBase29);
            this.grbMontoCobar.Controls.Add(this.lblBase30);
            this.grbMontoCobar.Controls.Add(this.lblBase31);
            this.grbMontoCobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMontoCobar.Location = new System.Drawing.Point(361, 60);
            this.grbMontoCobar.Name = "grbMontoCobar";
            this.grbMontoCobar.Size = new System.Drawing.Size(328, 169);
            this.grbMontoCobar.TabIndex = 10;
            this.grbMontoCobar.TabStop = false;
            this.grbMontoCobar.Text = "Monto a Cobrar";
            this.grbMontoCobar.Enter += new System.EventHandler(this.grbBase3_Enter);
            // 
            // txtOtros
            // 
            this.txtOtros.Enabled = false;
            this.txtOtros.FormatoDecimal = false;
            this.txtOtros.Location = new System.Drawing.Point(132, 90);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtros.nNumDecimales = 4;
            this.txtOtros.nvalor = 0D;
            this.txtOtros.Size = new System.Drawing.Size(123, 23);
            this.txtOtros.TabIndex = 3;
            this.txtOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtros.TextChanged += new System.EventHandler(this.txtOtros_TextChanged);
            // 
            // txtMora
            // 
            this.txtMora.Enabled = false;
            this.txtMora.FormatoDecimal = false;
            this.txtMora.Location = new System.Drawing.Point(132, 115);
            this.txtMora.Name = "txtMora";
            this.txtMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMora.nNumDecimales = 4;
            this.txtMora.nvalor = 0D;
            this.txtMora.Size = new System.Drawing.Size(123, 23);
            this.txtMora.TabIndex = 4;
            this.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMora.TextChanged += new System.EventHandler(this.txtMora_TextChanged);
            // 
            // lblTextMoneda
            // 
            this.lblTextMoneda.AutoSize = true;
            this.lblTextMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTextMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblTextMoneda.Location = new System.Drawing.Point(112, 145);
            this.lblTextMoneda.Name = "lblTextMoneda";
            this.lblTextMoneda.Size = new System.Drawing.Size(16, 13);
            this.lblTextMoneda.TabIndex = 7;
            this.lblTextMoneda.Text = "M";
            this.lblTextMoneda.Visible = false;
            // 
            // txtCapital
            // 
            this.txtCapital.Enabled = false;
            this.txtCapital.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapital.Location = new System.Drawing.Point(132, 18);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.ReadOnly = true;
            this.txtCapital.Size = new System.Drawing.Size(123, 22);
            this.txtCapital.TabIndex = 0;
            this.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase26
            // 
            this.lblBase26.AutoSize = true;
            this.lblBase26.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase26.ForeColor = System.Drawing.Color.Navy;
            this.lblBase26.Location = new System.Drawing.Point(8, 145);
            this.lblBase26.Name = "lblBase26";
            this.lblBase26.Size = new System.Drawing.Size(86, 13);
            this.lblBase26.TabIndex = 6;
            this.lblBase26.Text = "TOTAL PAGO:";
            // 
            // txtInteres
            // 
            this.txtInteres.Enabled = false;
            this.txtInteres.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInteres.Location = new System.Drawing.Point(132, 42);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.ReadOnly = true;
            this.txtInteres.Size = new System.Drawing.Size(123, 22);
            this.txtInteres.TabIndex = 1;
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.FormatoDecimal = true;
            this.txtTotal.Location = new System.Drawing.Point(132, 140);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotal.nNumDecimales = 2;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.Size = new System.Drawing.Size(123, 22);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(256, 140);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(67, 23);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblBase28
            // 
            this.lblBase28.AutoSize = true;
            this.lblBase28.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase28.ForeColor = System.Drawing.Color.Navy;
            this.lblBase28.Location = new System.Drawing.Point(9, 119);
            this.lblBase28.Name = "lblBase28";
            this.lblBase28.Size = new System.Drawing.Size(40, 13);
            this.lblBase28.TabIndex = 5;
            this.lblBase28.Text = "Mora:";
            // 
            // lblBase29
            // 
            this.lblBase29.AutoSize = true;
            this.lblBase29.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase29.ForeColor = System.Drawing.Color.Navy;
            this.lblBase29.Location = new System.Drawing.Point(9, 22);
            this.lblBase29.Name = "lblBase29";
            this.lblBase29.Size = new System.Drawing.Size(52, 13);
            this.lblBase29.TabIndex = 1;
            this.lblBase29.Text = "Capital:";
            // 
            // lblBase30
            // 
            this.lblBase30.AutoSize = true;
            this.lblBase30.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase30.ForeColor = System.Drawing.Color.Navy;
            this.lblBase30.Location = new System.Drawing.Point(9, 95);
            this.lblBase30.Name = "lblBase30";
            this.lblBase30.Size = new System.Drawing.Size(43, 13);
            this.lblBase30.TabIndex = 4;
            this.lblBase30.Text = "Otros:";
            // 
            // lblBase31
            // 
            this.lblBase31.AutoSize = true;
            this.lblBase31.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase31.ForeColor = System.Drawing.Color.Navy;
            this.lblBase31.Location = new System.Drawing.Point(9, 46);
            this.lblBase31.Name = "lblBase31";
            this.lblBase31.Size = new System.Drawing.Size(53, 13);
            this.lblBase31.TabIndex = 2;
            this.lblBase31.Text = "Interés:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 119);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(70, 13);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Nro Cuota:";
            // 
            // cboPagare
            // 
            this.cboPagare.FormattingEnabled = true;
            this.cboPagare.Location = new System.Drawing.Point(151, 42);
            this.cboPagare.Name = "cboPagare";
            this.cboPagare.Size = new System.Drawing.Size(204, 21);
            this.cboPagare.TabIndex = 1;
            this.cboPagare.SelectedIndexChanged += new System.EventHandler(this.cboDesembolso_SelectedIndexChanged);
            // 
            // lbUltCuota
            // 
            this.lbUltCuota.AutoSize = true;
            this.lbUltCuota.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUltCuota.ForeColor = System.Drawing.Color.Red;
            this.lbUltCuota.Location = new System.Drawing.Point(258, 120);
            this.lbUltCuota.Name = "lbUltCuota";
            this.lbUltCuota.Size = new System.Drawing.Size(90, 13);
            this.lbUltCuota.TabIndex = 170;
            this.lbUltCuota.Text = "Ultima Cuota";
            this.lbUltCuota.Visible = false;
            // 
            // chcCancelAnticipada
            // 
            this.chcCancelAnticipada.AutoSize = true;
            this.chcCancelAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcCancelAnticipada.ForeColor = System.Drawing.Color.Navy;
            this.chcCancelAnticipada.Location = new System.Drawing.Point(5, 213);
            this.chcCancelAnticipada.Name = "chcCancelAnticipada";
            this.chcCancelAnticipada.Size = new System.Drawing.Size(154, 19);
            this.chcCancelAnticipada.TabIndex = 11;
            this.chcCancelAnticipada.Text = "Cancelación Anticipada";
            this.chcCancelAnticipada.UseVisualStyleBackColor = true;
            this.chcCancelAnticipada.CheckedChanged += new System.EventHandler(this.chcCancelAnticipada_CheckedChanged);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(151, 188);
            this.txtNroDocumento.MaxLength = 35;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(204, 20);
            this.txtNroDocumento.TabIndex = 7;
            this.txtNroDocumento.TextChanged += new System.EventHandler(this.txtNroDocumento_TextChanged);
            // 
            // txtCodAdeudo
            // 
            this.txtCodAdeudo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAdeudo.Location = new System.Drawing.Point(151, 10);
            this.txtCodAdeudo.Name = "txtCodAdeudo";
            this.txtCodAdeudo.Size = new System.Drawing.Size(109, 27);
            this.txtCodAdeudo.TabIndex = 0;
            this.txtCodAdeudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodAdeudo.TextChanged += new System.EventHandler(this.txtCodAdeudo_TextChanged);
            this.txtCodAdeudo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodAdeudo_KeyPress);
            // 
            // txtNroCuota
            // 
            this.txtNroCuota.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCuota.Location = new System.Drawing.Point(151, 115);
            this.txtNroCuota.Name = "txtNroCuota";
            this.txtNroCuota.Size = new System.Drawing.Size(100, 22);
            this.txtNroCuota.TabIndex = 4;
            this.txtNroCuota.TextChanged += new System.EventHandler(this.txtNroCuota_TextChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(370, 42);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(56, 13);
            this.lblBase9.TabIndex = 27;
            this.lblBase9.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(452, 39);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(166, 21);
            this.cboMoneda.TabIndex = 9;
            // 
            // btnExtorno1
            // 
            this.btnExtorno1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno1.BackgroundImage")));
            this.btnExtorno1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno1.Location = new System.Drawing.Point(568, 403);
            this.btnExtorno1.Name = "btnExtorno1";
            this.btnExtorno1.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno1.TabIndex = 20;
            this.btnExtorno1.Text = "&Extornar";
            this.btnExtorno1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno1.UseVisualStyleBackColor = true;
            this.btnExtorno1.Click += new System.EventHandler(this.btnExtorno1_Click);
            // 
            // dtgPlanPagos
            // 
            this.dtgPlanPagos.AllowUserToAddRows = false;
            this.dtgPlanPagos.AllowUserToDeleteRows = false;
            this.dtgPlanPagos.AllowUserToResizeColumns = false;
            this.dtgPlanPagos.AllowUserToResizeRows = false;
            this.dtgPlanPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanPagos.Location = new System.Drawing.Point(4, 232);
            this.dtgPlanPagos.MultiSelect = false;
            this.dtgPlanPagos.Name = "dtgPlanPagos";
            this.dtgPlanPagos.ReadOnly = true;
            this.dtgPlanPagos.RowHeadersVisible = false;
            this.dtgPlanPagos.RowTemplate.Height = 20;
            this.dtgPlanPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanPagos.Size = new System.Drawing.Size(685, 166);
            this.dtgPlanPagos.TabIndex = 12;
            this.dtgPlanPagos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlanPagos_CellClick);
            this.dtgPlanPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlanPagos_CellContentClick);
            this.dtgPlanPagos.SelectionChanged += new System.EventHandler(this.dtgPlanPagos_SelectionChanged);
            // 
            // lblIC
            // 
            this.lblIC.AutoSize = true;
            this.lblIC.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIC.ForeColor = System.Drawing.Color.Navy;
            this.lblIC.Location = new System.Drawing.Point(2, 419);
            this.lblIC.Name = "lblIC";
            this.lblIC.Size = new System.Drawing.Size(73, 13);
            this.lblIC.TabIndex = 14;
            this.lblIC.Text = "(Cap + Int)";
            // 
            // lblComision
            // 
            this.lblComision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblComision.ForeColor = System.Drawing.Color.Navy;
            this.lblComision.Location = new System.Drawing.Point(229, 404);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(93, 28);
            this.lblComision.TabIndex = 16;
            this.lblComision.Text = "Total Comisión a Pagar";
            // 
            // txtTotComPagar
            // 
            this.txtTotComPagar.Enabled = false;
            this.txtTotComPagar.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtTotComPagar.FormatoDecimal = false;
            this.txtTotComPagar.Location = new System.Drawing.Point(320, 404);
            this.txtTotComPagar.Name = "txtTotComPagar";
            this.txtTotComPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotComPagar.nNumDecimales = 4;
            this.txtTotComPagar.nvalor = 0D;
            this.txtTotComPagar.Size = new System.Drawing.Size(116, 27);
            this.txtTotComPagar.TabIndex = 17;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(446, 404);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 18;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmPagoAdeudados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.txtTotComPagar);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.lblIC);
            this.Controls.Add(this.dtgPlanPagos);
            this.Controls.Add(this.btnExtorno1);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtNroCuota);
            this.Controls.Add(this.txtCodAdeudo);
            this.Controls.Add(this.txtNroDocumento);
            this.Controls.Add(this.cboPagare);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbMontoCobar);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase46);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.lblBase22);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.lblBase21);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboEntidad);
            this.Controls.Add(this.cboTipoEntidad);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblTotPagar);
            this.Controls.Add(this.txtTotalAPagar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lbUltCuota);
            this.Controls.Add(this.chcCancelAnticipada);
            this.Name = "frmPagoAdeudados";
            this.Text = "Pago de Adeudados";
            this.Load += new System.EventHandler(this.frmPagoAdeudados_Load);
            this.Controls.SetChildIndex(this.chcCancelAnticipada, 0);
            this.Controls.SetChildIndex(this.lbUltCuota, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtTotalAPagar, 0);
            this.Controls.SetChildIndex(this.lblTotPagar, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoEntidad, 0);
            this.Controls.SetChildIndex(this.cboEntidad, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase21, 0);
            this.Controls.SetChildIndex(this.cboFormaPago, 0);
            this.Controls.SetChildIndex(this.lblBase22, 0);
            this.Controls.SetChildIndex(this.cboTipoDocumento, 0);
            this.Controls.SetChildIndex(this.lblBase46, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.grbMontoCobar, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.cboPagare, 0);
            this.Controls.SetChildIndex(this.txtNroDocumento, 0);
            this.Controls.SetChildIndex(this.txtCodAdeudo, 0);
            this.Controls.SetChildIndex(this.txtNroCuota, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.btnExtorno1, 0);
            this.Controls.SetChildIndex(this.dtgPlanPagos, 0);
            this.Controls.SetChildIndex(this.lblIC, 0);
            this.Controls.SetChildIndex(this.lblComision, 0);
            this.Controls.SetChildIndex(this.txtTotComPagar, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbMontoCobar.ResumeLayout(false);
            this.grbMontoCobar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtNumRea txtTotalAPagar;
        private GEN.ControlesBase.lblBase lblTotPagar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase46;
        private GEN.ControlesBase.cboBase cboTipoDocumento;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.cboBase cboFormaPago;
        private GEN.ControlesBase.lblBase lblBase21;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtComision;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.grbBase grbMontoCobar;
        private GEN.ControlesBase.txtBase txtCapital;
        private GEN.ControlesBase.txtBase txtInteres;
        private GEN.ControlesBase.lblBase lblBase28;
        private GEN.ControlesBase.lblBase lblBase29;
        private GEN.ControlesBase.lblBase lblBase30;
        private GEN.ControlesBase.lblBase lblBase31;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboPagare;
        private System.Windows.Forms.Label lbUltCuota;
        private GEN.ControlesBase.chcBase chcCancelAnticipada;
        private GEN.ControlesBase.txtBase txtNroDocumento;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodAdeudo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCuota;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.BotonesBase.btnExtorno btnExtorno1;
        private System.Windows.Forms.DataGridView dtgPlanPagos;
        private System.Windows.Forms.Button btnCalcular;
        private GEN.ControlesBase.lblBase lblTextMoneda;
        private GEN.ControlesBase.lblBase lblBase26;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.lblBase lblIC;
        private GEN.ControlesBase.lblBase lblComision;
        private GEN.ControlesBase.txtNumRea txtTotComPagar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtNumRea txtMora;
        private GEN.ControlesBase.txtNumRea txtOtros;
    }
}