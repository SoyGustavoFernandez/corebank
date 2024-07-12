namespace GEN.ControlesBase
{
    partial class ConCondiCreditoGrupoSol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNroCuotas = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtCuotasGracia = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtCuotaGraciaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCuotaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.nudPlazoCuota = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTasaMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboTipoPeriodo = new GEN.ControlesBase.cboTipoPeriodo(this.components);
            this.cboDestinoCredito = new GEN.ControlesBase.cboDestinoCredito(this.components);
            this.dtFechaPrimeraCuota = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtFechaDesembolso = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtTasCompensatoriaMax = new GEN.ControlesBase.txtBase(this.components);
            this.txtTasCompensatoriaMin = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoTasaCredito = new GEN.ControlesBase.cboBase(this.components);
            this.conNivelesProducto = new GEN.ControlesBase.conProducto();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase19 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlazoCuota)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Min";
            this.label7.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // txtNroCuotas
            // 
            this.txtNroCuotas.Format = "n0";
            this.errorProvider.SetIconPadding(this.txtNroCuotas, -18);
            this.txtNroCuotas.Location = new System.Drawing.Point(116, 23);
            this.txtNroCuotas.Name = "txtNroCuotas";
            this.txtNroCuotas.Size = new System.Drawing.Size(47, 20);
            this.txtNroCuotas.TabIndex = 1;
            this.txtNroCuotas.Text = "0";
            this.txtNroCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroCuotas.Leave += new System.EventHandler(this.txtNroCuotas_Leave);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboMoneda, -28);
            this.cboMoneda.Location = new System.Drawing.Point(116, 0);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(106, 21);
            this.cboMoneda.TabIndex = 0;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // txtCuotasGracia
            // 
            this.txtCuotasGracia.Format = "n0";
            this.errorProvider.SetIconPadding(this.txtCuotasGracia, -18);
            this.txtCuotasGracia.Location = new System.Drawing.Point(116, 114);
            this.txtCuotasGracia.Name = "txtCuotasGracia";
            this.txtCuotasGracia.Size = new System.Drawing.Size(47, 20);
            this.txtCuotasGracia.TabIndex = 5;
            this.txtCuotasGracia.Text = "0";
            this.txtCuotasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuotasGracia.Leave += new System.EventHandler(this.txtCuotasGracia_Leave);
            // 
            // txtCuotaGraciaAprox
            // 
            this.txtCuotaGraciaAprox.Enabled = false;
            this.txtCuotaGraciaAprox.FormatoDecimal = false;
            this.txtCuotaGraciaAprox.Location = new System.Drawing.Point(492, 158);
            this.txtCuotaGraciaAprox.Name = "txtCuotaGraciaAprox";
            this.txtCuotaGraciaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaGraciaAprox.nNumDecimales = 4;
            this.txtCuotaGraciaAprox.nvalor = 0D;
            this.txtCuotaGraciaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaGraciaAprox.TabIndex = 113;
            this.txtCuotaGraciaAprox.TabStop = false;
            this.txtCuotaGraciaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuotaGraciaAprox.Visible = false;
            // 
            // txtCuotaAprox
            // 
            this.txtCuotaAprox.Enabled = false;
            this.txtCuotaAprox.FormatoDecimal = false;
            this.txtCuotaAprox.Location = new System.Drawing.Point(492, 136);
            this.txtCuotaAprox.Name = "txtCuotaAprox";
            this.txtCuotaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaAprox.nNumDecimales = 4;
            this.txtCuotaAprox.nvalor = 0D;
            this.txtCuotaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaAprox.TabIndex = 112;
            this.txtCuotaAprox.TabStop = false;
            this.txtCuotaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuotaAprox.Visible = false;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(453, 162);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 111;
            this.lblBase5.Text = "Cuota Gracia";
            this.lblBase5.Visible = false;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(452, 140);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(83, 13);
            this.lblBase17.TabIndex = 109;
            this.lblBase17.Text = "Cuota Aprox.";
            this.lblBase17.Visible = false;
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Location = new System.Drawing.Point(116, 91);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.Size = new System.Drawing.Size(47, 20);
            this.nudDiasGracia.TabIndex = 4;
            this.nudDiasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasGracia.Leave += new System.EventHandler(this.nudDiasGracia_Leave);
            // 
            // nudPlazoCuota
            // 
            this.nudPlazoCuota.Location = new System.Drawing.Point(116, 69);
            this.nudPlazoCuota.Name = "nudPlazoCuota";
            this.nudPlazoCuota.Size = new System.Drawing.Size(47, 20);
            this.nudPlazoCuota.TabIndex = 3;
            this.nudPlazoCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPlazoCuota.ValueChanged += new System.EventHandler(this.nudPlazoCuota_ValueChanged);
            this.nudPlazoCuota.Leave += new System.EventHandler(this.nudPlazoCuota_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(165, 73);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(30, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "días";
            // 
            // txtTasaMora
            // 
            this.txtTasaMora.Enabled = false;
            this.txtTasaMora.FormatoDecimal = false;
            this.txtTasaMora.Location = new System.Drawing.Point(375, 158);
            this.txtTasaMora.Name = "txtTasaMora";
            this.txtTasaMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMora.nNumDecimales = 4;
            this.txtTasaMora.nvalor = 0D;
            this.txtTasaMora.Size = new System.Drawing.Size(50, 20);
            this.txtTasaMora.TabIndex = 14;
            this.txtTasaMora.Visible = false;
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.txtTEA.Location = new System.Drawing.Point(375, 136);
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 4;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(50, 20);
            this.txtTEA.TabIndex = 13;
            this.txtTEA.Visible = false;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(431, 162);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(19, 13);
            this.lblBase16.TabIndex = 0;
            this.lblBase16.Text = "%";
            this.lblBase16.Visible = false;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(431, 140);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(19, 13);
            this.lblBase11.TabIndex = 29;
            this.lblBase11.Text = "%";
            this.lblBase11.Visible = false;
            // 
            // cboTipoPeriodo
            // 
            this.cboTipoPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPeriodo.FormattingEnabled = true;
            this.cboTipoPeriodo.Location = new System.Drawing.Point(116, 46);
            this.cboTipoPeriodo.Name = "cboTipoPeriodo";
            this.cboTipoPeriodo.Size = new System.Drawing.Size(106, 21);
            this.cboTipoPeriodo.TabIndex = 2;
            this.cboTipoPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged);
            // 
            // cboDestinoCredito
            // 
            this.cboDestinoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinoCredito.Enabled = false;
            this.cboDestinoCredito.FormattingEnabled = true;
            this.cboDestinoCredito.Location = new System.Drawing.Point(375, 92);
            this.cboDestinoCredito.Name = "cboDestinoCredito";
            this.cboDestinoCredito.Size = new System.Drawing.Size(220, 21);
            this.cboDestinoCredito.TabIndex = 9;
            this.cboDestinoCredito.Visible = false;
            // 
            // dtFechaPrimeraCuota
            // 
            this.dtFechaPrimeraCuota.Enabled = false;
            this.dtFechaPrimeraCuota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaPrimeraCuota.Location = new System.Drawing.Point(116, 158);
            this.dtFechaPrimeraCuota.Name = "dtFechaPrimeraCuota";
            this.dtFechaPrimeraCuota.Size = new System.Drawing.Size(106, 20);
            this.dtFechaPrimeraCuota.TabIndex = 7;
            // 
            // dtFechaDesembolso
            // 
            this.dtFechaDesembolso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDesembolso.Location = new System.Drawing.Point(116, 136);
            this.dtFechaDesembolso.Name = "dtFechaDesembolso";
            this.dtFechaDesembolso.Size = new System.Drawing.Size(106, 20);
            this.dtFechaDesembolso.TabIndex = 6;
            this.dtFechaDesembolso.ValueChanged += new System.EventHandler(this.dtFechaDesembolso_ValueChanged);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(5, 162);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(109, 13);
            this.lblBase10.TabIndex = 7;
            this.lblBase10.Text = "Fecha 1era. cuota";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(344, 140);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(29, 13);
            this.lblBase9.TabIndex = 27;
            this.lblBase9.Text = "TEA";
            this.lblBase9.Visible = false;
            // 
            // txtTasCompensatoriaMax
            // 
            this.txtTasCompensatoriaMax.Enabled = false;
            this.txtTasCompensatoriaMax.Location = new System.Drawing.Point(507, 114);
            this.txtTasCompensatoriaMax.Name = "txtTasCompensatoriaMax";
            this.txtTasCompensatoriaMax.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMax.TabIndex = 12;
            this.txtTasCompensatoriaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTasCompensatoriaMax.Visible = false;
            // 
            // txtTasCompensatoriaMin
            // 
            this.txtTasCompensatoriaMin.Enabled = false;
            this.txtTasCompensatoriaMin.Location = new System.Drawing.Point(406, 114);
            this.txtTasCompensatoriaMin.Name = "txtTasCompensatoriaMin";
            this.txtTasCompensatoriaMin.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMin.TabIndex = 11;
            this.txtTasCompensatoriaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTasCompensatoriaMin.Visible = false;
            // 
            // cboTipoTasaCredito
            // 
            this.cboTipoTasaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaCredito.DropDownWidth = 200;
            this.cboTipoTasaCredito.FormattingEnabled = true;
            this.cboTipoTasaCredito.Location = new System.Drawing.Point(261, 114);
            this.cboTipoTasaCredito.Name = "cboTipoTasaCredito";
            this.cboTipoTasaCredito.Size = new System.Drawing.Size(112, 21);
            this.cboTipoTasaCredito.TabIndex = 10;
            this.cboTipoTasaCredito.Visible = false;
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            // 
            // conNivelesProducto
            // 
            this.conNivelesProducto.AutoSize = true;
            this.conNivelesProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conNivelesProducto.lBloquear3Niveles = true;
            this.conNivelesProducto.lMostrarTipoCredito = true;
            this.conNivelesProducto.Location = new System.Drawing.Point(276, -1);
            this.conNivelesProducto.Name = "conNivelesProducto";
            this.conNivelesProducto.Size = new System.Drawing.Size(322, 92);
            this.conNivelesProducto.TabIndex = 8;
            this.conNivelesProducto.ChangeProducto += new System.EventHandler(this.conNivelesProducto_ChangeProducto);
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Enabled = false;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(323, 96);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(50, 13);
            this.lblBase12.TabIndex = 20;
            this.lblBase12.Text = "Destino";
            this.lblBase12.Visible = false;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(378, 118);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(26, 13);
            this.lblBase13.TabIndex = 23;
            this.lblBase13.Text = "Min";
            this.lblBase13.Visible = false;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(475, 118);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(30, 13);
            this.lblBase14.TabIndex = 25;
            this.lblBase14.Text = "Max";
            this.lblBase14.Visible = false;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(282, 162);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(91, 13);
            this.lblBase15.TabIndex = 30;
            this.lblBase15.Text = "Tasa Moratoria";
            this.lblBase15.Visible = false;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(63, 4);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(51, 13);
            this.lblBase8.TabIndex = 0;
            this.lblBase8.Text = "Moneda";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(39, 27);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(75, 13);
            this.lblBase7.TabIndex = 1;
            this.lblBase7.Text = "Nro. Cuotas";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(64, 50);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(50, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Periodo";
            // 
            // lblBase19
            // 
            this.lblBase19.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase19.ForeColor = System.Drawing.Color.Navy;
            this.lblBase19.Location = new System.Drawing.Point(13, 73);
            this.lblBase19.Name = "lblBase19";
            this.lblBase19.Size = new System.Drawing.Size(101, 16);
            this.lblBase19.TabIndex = 3;
            this.lblBase19.Text = "Día de pago";
            this.lblBase19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(25, 95);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(89, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Días de gracia";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 118);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(104, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Cuotas de gracia";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(2, 140);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(112, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Fecha desembolso";
            // 
            // ConCondiCreditoGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCuotaGraciaAprox);
            this.Controls.Add(this.txtCuotaAprox);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.nudDiasGracia);
            this.Controls.Add(this.nudPlazoCuota);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtTasaMora);
            this.Controls.Add(this.txtTEA);
            this.Controls.Add(this.lblBase16);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.cboTipoPeriodo);
            this.Controls.Add(this.txtNroCuotas);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.cboDestinoCredito);
            this.Controls.Add(this.dtFechaPrimeraCuota);
            this.Controls.Add(this.dtFechaDesembolso);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtCuotasGracia);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtTasCompensatoriaMax);
            this.Controls.Add(this.txtTasCompensatoriaMin);
            this.Controls.Add(this.cboTipoTasaCredito);
            this.Controls.Add(this.conNivelesProducto);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.lblBase15);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase19);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.label7);
            this.Name = "ConCondiCreditoGrupoSol";
            this.Size = new System.Drawing.Size(595, 178);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlazoCuota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private lblBase lblBase2;
        private lblBase lblBase3;
        private lblBase lblBase4;
        private lblBase lblBase19;
        private lblBase lblBase6;
        private lblBase lblBase7;
        private lblBase lblBase8;
        private lblBase lblBase12;
        private lblBase lblBase13;
        private lblBase lblBase14;
        private lblBase lblBase15;
        private conProducto conNivelesProducto;
        private cboBase cboTipoTasaCredito;
        private txtBase txtTasCompensatoriaMin;
        private txtBase txtTasCompensatoriaMax;
        private lblBase lblBase9;
        private lblBase lblBase10;
        private cboDestinoCredito cboDestinoCredito;
        private cboMoneda cboMoneda;
        private lblBase lblBase11;
        private lblBase lblBase16;
        private txtNumRea txtTEA;
        private txtNumRea txtTasaMora;
        private lblBase lblBase1;
        private nudBase nudDiasGracia;
        private lblBase lblBase5;
        private lblBase lblBase17;
        private txtNumRea txtCuotaGraciaAprox;
        private txtNumRea txtCuotaAprox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        public dtLargoBase dtFechaPrimeraCuota;
        public dtLargoBase dtFechaDesembolso;
        public txtNumerico txtCuotasGracia;
        public cboTipoPeriodo cboTipoPeriodo;
        public nudBase nudPlazoCuota;
        public txtNumerico txtNroCuotas;
    }
}
