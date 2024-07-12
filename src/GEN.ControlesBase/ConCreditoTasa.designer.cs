namespace GEN.ControlesBase
{
    partial class ConCreditoTasa
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
            this.pnlDatCred = new System.Windows.Forms.Panel();
            this.conCreditoPrimeraCuota = new GEN.ControlesBase.ConCreditoPrimeraCuota();
            this.nudCuotasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom41 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.nudCuotas = new GEN.ControlesBase.nudBase(this.components);
            this.dtFechaDesembolso = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBaseCustom43 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblDesembolso = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBaseCustom42 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.conCreditoPeriodo = new GEN.ControlesBase.ConCreditoPeriodo();
            this.pnlTipCred = new System.Windows.Forms.Panel();
            this.conNivelesProducto = new GEN.ControlesBase.conProducto();
            this.pnlTasa = new System.Windows.Forms.Panel();
            this.lblClasifInterna = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblAlertSobredeuda = new System.Windows.Forms.Label();
            this.lblSobreDeuda = new System.Windows.Forms.Label();
            this.pbxTasaAprob = new System.Windows.Forms.PictureBox();
            this.cboTipoTasaCredito = new GEN.ControlesBase.cboBase(this.components);
            this.txtTasCompensatoriaMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom30 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom4 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtTEM = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom44 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtTasaMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasCompensatoriaMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.tlpControl = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDatCred.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            this.pnlTipCred.SuspendLayout();
            this.pnlTasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTasaAprob)).BeginInit();
            this.tlpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatCred
            // 
            this.pnlDatCred.AutoSize = true;
            this.pnlDatCred.Controls.Add(this.conCreditoPrimeraCuota);
            this.pnlDatCred.Controls.Add(this.nudCuotasGracia);
            this.pnlDatCred.Controls.Add(this.lblBaseCustom1);
            this.pnlDatCred.Controls.Add(this.lblBaseCustom41);
            this.pnlDatCred.Controls.Add(this.nudDiasGracia);
            this.pnlDatCred.Controls.Add(this.nudCuotas);
            this.pnlDatCred.Controls.Add(this.dtFechaDesembolso);
            this.pnlDatCred.Controls.Add(this.lblBaseCustom43);
            this.pnlDatCred.Controls.Add(this.lblDesembolso);
            this.pnlDatCred.Controls.Add(this.txtMonto);
            this.pnlDatCred.Controls.Add(this.lblBaseCustom42);
            this.pnlDatCred.Controls.Add(this.cboMoneda);
            this.pnlDatCred.Controls.Add(this.conCreditoPeriodo);
            this.pnlDatCred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatCred.Location = new System.Drawing.Point(0, 0);
            this.pnlDatCred.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDatCred.Name = "pnlDatCred";
            this.pnlDatCred.Size = new System.Drawing.Size(325, 114);
            this.pnlDatCred.TabIndex = 0;
            // 
            // conCreditoPrimeraCuota
            // 
            this.conCreditoPrimeraCuota.cFormatoFecha = "dddd, dd \'de\' MMMM \'de\' yyyy";
            this.conCreditoPrimeraCuota.dFechaDesembolso = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.dFechaEsperada = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.dFechaSelec = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.idPeriodo = 0;
            this.conCreditoPrimeraCuota.idTipoPeriodo = 0;
            this.conCreditoPrimeraCuota.lFechaEnabled = true;
            this.conCreditoPrimeraCuota.lFechaSelec = false;
            this.conCreditoPrimeraCuota.Location = new System.Drawing.Point(16, 92);
            this.conCreditoPrimeraCuota.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPrimeraCuota.Name = "conCreditoPrimeraCuota";
            this.conCreditoPrimeraCuota.nDiasGracia = 0;
            this.conCreditoPrimeraCuota.nPeriodoDia = 0;
            this.conCreditoPrimeraCuota.Size = new System.Drawing.Size(307, 22);
            this.conCreditoPrimeraCuota.TabIndex = 152;
            // 
            // nudCuotasGracia
            // 
            this.nudCuotasGracia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconPadding(this.nudCuotasGracia, -20);
            this.nudCuotasGracia.Location = new System.Drawing.Point(272, 47);
            this.nudCuotasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudCuotasGracia.Name = "nudCuotasGracia";
            this.nudCuotasGracia.Size = new System.Drawing.Size(50, 20);
            this.nudCuotasGracia.TabIndex = 5;
            this.nudCuotasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCuotasGracia.Enter += new System.EventHandler(this.nudPeriodosGracia_Enter);
            this.nudCuotasGracia.Leave += new System.EventHandler(this.nudPeriodosGracia_Leave);
            this.nudCuotasGracia.Validating += new System.ComponentModel.CancelEventHandler(this.nudPeriodosGracia_Validating);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(204, 50);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(67, 13);
            this.lblBaseCustom1.TabIndex = 150;
            this.lblBaseCustom1.Text = "Cts Gracia";
            // 
            // lblBaseCustom41
            // 
            this.lblBaseCustom41.AutoSize = true;
            this.lblBaseCustom41.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom41.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom41.Location = new System.Drawing.Point(13, 4);
            this.lblBaseCustom41.Name = "lblBaseCustom41";
            this.lblBaseCustom41.Size = new System.Drawing.Size(75, 13);
            this.lblBaseCustom41.TabIndex = 131;
            this.lblBaseCustom41.Text = "Monto Prop.";
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiasGracia.Enabled = false;
            this.errorProvider.SetIconPadding(this.nudDiasGracia, -20);
            this.nudDiasGracia.Location = new System.Drawing.Point(272, 70);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDiasGracia.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.Size = new System.Drawing.Size(50, 20);
            this.nudDiasGracia.TabIndex = 7;
            this.nudDiasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasGracia.Enter += new System.EventHandler(this.nudDiasGracia_Enter);
            this.nudDiasGracia.Leave += new System.EventHandler(this.nudDiasGracia_Leave);
            this.nudDiasGracia.Validating += new System.ComponentModel.CancelEventHandler(this.nudDiasGracia_Validating);
            // 
            // nudCuotas
            // 
            this.nudCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconPadding(this.nudCuotas, -20);
            this.nudCuotas.Location = new System.Drawing.Point(272, 24);
            this.nudCuotas.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.Size = new System.Drawing.Size(50, 20);
            this.nudCuotas.TabIndex = 2;
            this.nudCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCuotas.ValueChanged += new System.EventHandler(this.nudCuotas_ValueChanged);
            this.nudCuotas.Enter += new System.EventHandler(this.nudCuotas_Enter);
            this.nudCuotas.Leave += new System.EventHandler(this.nudCuotas_Leave);
            this.nudCuotas.Validating += new System.ComponentModel.CancelEventHandler(this.nudCuotas_Validating);
            // 
            // dtFechaDesembolso
            // 
            this.dtFechaDesembolso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFechaDesembolso.CustomFormat = "dd/MMM/yyyy";
            this.dtFechaDesembolso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.errorProvider.SetIconPadding(this.dtFechaDesembolso, -27);
            this.dtFechaDesembolso.Location = new System.Drawing.Point(90, 70);
            this.dtFechaDesembolso.Name = "dtFechaDesembolso";
            this.dtFechaDesembolso.Size = new System.Drawing.Size(96, 20);
            this.dtFechaDesembolso.TabIndex = 6;
            this.dtFechaDesembolso.Value = new System.DateTime(2012, 5, 31, 17, 25, 32, 0);
            this.dtFechaDesembolso.ValueChanged += new System.EventHandler(this.dtFechaDesembolso_ValueChanged);
            this.dtFechaDesembolso.Enter += new System.EventHandler(this.dtFechaDesembolso_Enter);
            this.dtFechaDesembolso.Leave += new System.EventHandler(this.dtFechaDesembolso_Leave);
            this.dtFechaDesembolso.Validating += new System.ComponentModel.CancelEventHandler(this.dtFechaDesembolso_Validating);
            // 
            // lblBaseCustom43
            // 
            this.lblBaseCustom43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseCustom43.AutoSize = true;
            this.lblBaseCustom43.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom43.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom43.Location = new System.Drawing.Point(198, 74);
            this.lblBaseCustom43.Name = "lblBaseCustom43";
            this.lblBaseCustom43.Size = new System.Drawing.Size(73, 13);
            this.lblBaseCustom43.TabIndex = 137;
            this.lblBaseCustom43.Text = "Días Gracia";
            // 
            // lblDesembolso
            // 
            this.lblDesembolso.AutoSize = true;
            this.lblDesembolso.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDesembolso.ForeColor = System.Drawing.Color.Navy;
            this.lblDesembolso.Location = new System.Drawing.Point(12, 74);
            this.lblDesembolso.Name = "lblDesembolso";
            this.lblDesembolso.Size = new System.Drawing.Size(77, 13);
            this.lblDesembolso.TabIndex = 148;
            this.lblDesembolso.Text = "Desembolso";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.FormatoDecimal = false;
            this.errorProvider.SetIconPadding(this.txtMonto, -20);
            this.txtMonto.Location = new System.Drawing.Point(214, 1);
            this.txtMonto.MaxLength = 9;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(108, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.Text = "0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonto_KeyDown);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // lblBaseCustom42
            // 
            this.lblBaseCustom42.AutoSize = true;
            this.lblBaseCustom42.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom42.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom42.Location = new System.Drawing.Point(224, 27);
            this.lblBaseCustom42.Name = "lblBaseCustom42";
            this.lblBaseCustom42.Size = new System.Drawing.Size(47, 13);
            this.lblBaseCustom42.TabIndex = 136;
            this.lblBaseCustom42.Text = "Cuotas";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboMoneda, -28);
            this.cboMoneda.Location = new System.Drawing.Point(90, 1);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(110, 21);
            this.cboMoneda.TabIndex = 0;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.cboMoneda.Enter += new System.EventHandler(this.cboMoneda_Enter);
            this.cboMoneda.Validating += new System.ComponentModel.CancelEventHandler(this.cboMoneda_Validating);
            // 
            // conCreditoPeriodo
            // 
            this.conCreditoPeriodo.AutoSize = true;
            this.conCreditoPeriodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoPeriodo.lDiaEnabled = true;
            this.conCreditoPeriodo.Location = new System.Drawing.Point(4, 23);
            this.conCreditoPeriodo.lPeriodoEnabled = true;
            this.conCreditoPeriodo.lTipoPeriodoEnabled = true;
            this.conCreditoPeriodo.lUnicuota = false;
            this.conCreditoPeriodo.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPeriodo.Name = "conCreditoPeriodo";
            this.conCreditoPeriodo.Size = new System.Drawing.Size(198, 45);
            this.conCreditoPeriodo.TabIndex = 151;
            this.conCreditoPeriodo.LeaveDia += new System.EventHandler(this.conCreditoPeriodo_LeaveDia);
            this.conCreditoPeriodo.ValueChangedDia += new System.EventHandler(this.conCreditoPeriodo_ValueChangedDia);
            // 
            // pnlTipCred
            // 
            this.pnlTipCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTipCred.AutoSize = true;
            this.pnlTipCred.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTipCred.Controls.Add(this.conNivelesProducto);
            this.pnlTipCred.Location = new System.Drawing.Point(0, 114);
            this.pnlTipCred.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTipCred.Name = "pnlTipCred";
            this.pnlTipCred.Size = new System.Drawing.Size(325, 92);
            this.pnlTipCred.TabIndex = 2;
            // 
            // conNivelesProducto
            // 
            this.conNivelesProducto.AutoSize = true;
            this.conNivelesProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conNivelesProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conNivelesProducto.lBloquear3Niveles = true;
            this.conNivelesProducto.lMostrarTipoCredito = true;
            this.conNivelesProducto.Location = new System.Drawing.Point(0, 0);
            this.conNivelesProducto.Margin = new System.Windows.Forms.Padding(0);
            this.conNivelesProducto.Name = "conNivelesProducto";
            this.conNivelesProducto.Size = new System.Drawing.Size(325, 92);
            this.conNivelesProducto.TabIndex = 0;
            this.conNivelesProducto.ChangeProducto += new System.EventHandler(this.conNivelesProducto_ChangeProducto);
            // 
            // pnlTasa
            // 
            this.pnlTasa.AutoSize = true;
            this.pnlTasa.Controls.Add(this.lblClasifInterna);
            this.pnlTasa.Controls.Add(this.lblAlertSobredeuda);
            this.pnlTasa.Controls.Add(this.lblSobreDeuda);
            this.pnlTasa.Controls.Add(this.pbxTasaAprob);
            this.pnlTasa.Controls.Add(this.cboTipoTasaCredito);
            this.pnlTasa.Controls.Add(this.txtTasCompensatoriaMin);
            this.pnlTasa.Controls.Add(this.txtTEA);
            this.pnlTasa.Controls.Add(this.lblBase5);
            this.pnlTasa.Controls.Add(this.lblBaseCustom30);
            this.pnlTasa.Controls.Add(this.lblBaseCustom4);
            this.pnlTasa.Controls.Add(this.txtTEM);
            this.pnlTasa.Controls.Add(this.lblBase2);
            this.pnlTasa.Controls.Add(this.lblBaseCustom44);
            this.pnlTasa.Controls.Add(this.txtTasaMora);
            this.pnlTasa.Controls.Add(this.txtTasCompensatoriaMax);
            this.pnlTasa.Controls.Add(this.lblBase4);
            this.pnlTasa.Controls.Add(this.lblBase3);
            this.pnlTasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTasa.Location = new System.Drawing.Point(0, 206);
            this.pnlTasa.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTasa.Name = "pnlTasa";
            this.pnlTasa.Size = new System.Drawing.Size(325, 69);
            this.pnlTasa.TabIndex = 3;
            // 
            // lblClasifInterna
            // 
            this.lblClasifInterna.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblClasifInterna.ForeColor = System.Drawing.Color.Navy;
            this.lblClasifInterna.Location = new System.Drawing.Point(164, 25);
            this.lblClasifInterna.Name = "lblClasifInterna";
            this.lblClasifInterna.Size = new System.Drawing.Size(158, 18);
            this.lblClasifInterna.TabIndex = 171;
            this.lblClasifInterna.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAlertSobredeuda
            // 
            this.lblAlertSobredeuda.AutoSize = true;
            this.lblAlertSobredeuda.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertSobredeuda.ForeColor = System.Drawing.Color.Red;
            this.lblAlertSobredeuda.Location = new System.Drawing.Point(308, 50);
            this.lblAlertSobredeuda.Name = "lblAlertSobredeuda";
            this.lblAlertSobredeuda.Size = new System.Drawing.Size(11, 13);
            this.lblAlertSobredeuda.TabIndex = 170;
            this.lblAlertSobredeuda.Text = "!";
            this.lblAlertSobredeuda.Visible = false;
            // 
            // lblSobreDeuda
            // 
            this.lblSobreDeuda.AutoSize = true;
            this.lblSobreDeuda.BackColor = System.Drawing.Color.Transparent;
            this.lblSobreDeuda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSobreDeuda.ForeColor = System.Drawing.Color.Red;
            this.lblSobreDeuda.Location = new System.Drawing.Point(236, 49);
            this.lblSobreDeuda.Name = "lblSobreDeuda";
            this.lblSobreDeuda.Size = new System.Drawing.Size(76, 13);
            this.lblSobreDeuda.TabIndex = 169;
            this.lblSobreDeuda.Text = "Sobredeuda";
            this.lblSobreDeuda.Visible = false;
            this.lblSobreDeuda.Click += new System.EventHandler(this.lblSobreDeuda_Click);
            this.lblSobreDeuda.MouseLeave += new System.EventHandler(this.lblSobreDeuda_MouseLeave);
            this.lblSobreDeuda.MouseHover += new System.EventHandler(this.lblSobreDeuda_MouseHover);
            // 
            // pbxTasaAprob
            // 
            this.pbxTasaAprob.Image = global::GEN.ControlesBase.Properties.Resources.excel;
            this.pbxTasaAprob.Location = new System.Drawing.Point(120, 28);
            this.pbxTasaAprob.Name = "pbxTasaAprob";
            this.pbxTasaAprob.Size = new System.Drawing.Size(16, 16);
            this.pbxTasaAprob.TabIndex = 167;
            this.pbxTasaAprob.TabStop = false;
            this.pbxTasaAprob.Visible = false;
            this.pbxTasaAprob.Click += new System.EventHandler(this.pbxTasaAprob_Click);
            // 
            // cboTipoTasaCredito
            // 
            this.cboTipoTasaCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoTasaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaCredito.DropDownWidth = 260;
            this.cboTipoTasaCredito.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipoTasaCredito, -28);
            this.cboTipoTasaCredito.Location = new System.Drawing.Point(5, 1);
            this.cboTipoTasaCredito.Name = "cboTipoTasaCredito";
            this.cboTipoTasaCredito.Size = new System.Drawing.Size(162, 21);
            this.cboTipoTasaCredito.TabIndex = 0;
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            this.cboTipoTasaCredito.Validating += new System.ComponentModel.CancelEventHandler(this.cboTipoTasaCredito_Validating);
            // 
            // txtTasCompensatoriaMin
            // 
            this.txtTasCompensatoriaMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTasCompensatoriaMin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTasCompensatoriaMin.FormatoDecimal = false;
            this.txtTasCompensatoriaMin.Location = new System.Drawing.Point(176, 1);
            this.txtTasCompensatoriaMin.Name = "txtTasCompensatoriaMin";
            this.txtTasCompensatoriaMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasCompensatoriaMin.nNumDecimales = 4;
            this.txtTasCompensatoriaMin.nvalor = 0D;
            this.txtTasCompensatoriaMin.ReadOnly = true;
            this.txtTasCompensatoriaMin.Size = new System.Drawing.Size(65, 20);
            this.txtTasCompensatoriaMin.TabIndex = 1;
            this.txtTasCompensatoriaMin.TabStop = false;
            this.txtTasCompensatoriaMin.Text = "0";
            this.txtTasCompensatoriaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.errorProvider.SetIconPadding(this.txtTEA, -20);
            this.txtTEA.Location = new System.Drawing.Point(39, 25);
            this.txtTEA.MaxLength = 8;
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 4;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(55, 20);
            this.txtTEA.TabIndex = 1;
            this.txtTEA.Text = "0";
            this.txtTEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTEA.TextChanged += new System.EventHandler(this.txtTEA_TextChanged);
            this.txtTEA.Leave += new System.EventHandler(this.txtTEA_Leave);
            this.txtTEA.Validating += new System.ComponentModel.CancelEventHandler(this.txtTEA_Validating);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(202, 49);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(19, 13);
            this.lblBase5.TabIndex = 166;
            this.lblBase5.Text = "%";
            // 
            // lblBaseCustom30
            // 
            this.lblBaseCustom30.AutoSize = true;
            this.lblBaseCustom30.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom30.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom30.Location = new System.Drawing.Point(8, 28);
            this.lblBaseCustom30.Name = "lblBaseCustom30";
            this.lblBaseCustom30.Size = new System.Drawing.Size(29, 13);
            this.lblBaseCustom30.TabIndex = 145;
            this.lblBaseCustom30.Text = "TEA";
            // 
            // lblBaseCustom4
            // 
            this.lblBaseCustom4.AutoSize = true;
            this.lblBaseCustom4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom4.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom4.Location = new System.Drawing.Point(119, 49);
            this.lblBaseCustom4.Name = "lblBaseCustom4";
            this.lblBaseCustom4.Size = new System.Drawing.Size(28, 13);
            this.lblBaseCustom4.TabIndex = 165;
            this.lblBaseCustom4.Text = "TIM";
            // 
            // txtTEM
            // 
            this.txtTEM.Enabled = false;
            this.txtTEM.FormatoDecimal = false;
            this.txtTEM.Location = new System.Drawing.Point(39, 46);
            this.txtTEM.Name = "txtTEM";
            this.txtTEM.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEM.nNumDecimales = 4;
            this.txtTEM.nvalor = 0D;
            this.txtTEM.Size = new System.Drawing.Size(55, 20);
            this.txtTEM.TabIndex = 4;
            this.txtTEM.Text = "0";
            this.txtTEM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(243, 4);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(12, 13);
            this.lblBase2.TabIndex = 164;
            this.lblBase2.Text = "-";
            // 
            // lblBaseCustom44
            // 
            this.lblBaseCustom44.AutoSize = true;
            this.lblBaseCustom44.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom44.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom44.Location = new System.Drawing.Point(9, 49);
            this.lblBaseCustom44.Name = "lblBaseCustom44";
            this.lblBaseCustom44.Size = new System.Drawing.Size(30, 13);
            this.lblBaseCustom44.TabIndex = 144;
            this.lblBaseCustom44.Text = "TEM";
            // 
            // txtTasaMora
            // 
            this.txtTasaMora.Enabled = false;
            this.txtTasaMora.FormatoDecimal = false;
            this.txtTasaMora.Location = new System.Drawing.Point(147, 46);
            this.txtTasaMora.Name = "txtTasaMora";
            this.txtTasaMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMora.nNumDecimales = 4;
            this.txtTasaMora.nvalor = 0D;
            this.txtTasaMora.Size = new System.Drawing.Size(54, 20);
            this.txtTasaMora.TabIndex = 2;
            this.txtTasaMora.Text = "0";
            this.txtTasaMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTasCompensatoriaMax
            // 
            this.txtTasCompensatoriaMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTasCompensatoriaMax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTasCompensatoriaMax.FormatoDecimal = false;
            this.txtTasCompensatoriaMax.Location = new System.Drawing.Point(257, 1);
            this.txtTasCompensatoriaMax.Name = "txtTasCompensatoriaMax";
            this.txtTasCompensatoriaMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasCompensatoriaMax.nNumDecimales = 4;
            this.txtTasCompensatoriaMax.nvalor = 0D;
            this.txtTasCompensatoriaMax.ReadOnly = true;
            this.txtTasCompensatoriaMax.Size = new System.Drawing.Size(65, 20);
            this.txtTasCompensatoriaMax.TabIndex = 2;
            this.txtTasCompensatoriaMax.TabStop = false;
            this.txtTasCompensatoriaMax.Text = "0";
            this.txtTasCompensatoriaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(96, 49);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(19, 13);
            this.lblBase4.TabIndex = 161;
            this.lblBase4.Text = "%";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(96, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(19, 13);
            this.lblBase3.TabIndex = 160;
            this.lblBase3.Text = "%";
            // 
            // tlpControl
            // 
            this.tlpControl.AutoSize = true;
            this.tlpControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpControl.ColumnCount = 1;
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControl.Controls.Add(this.pnlDatCred, 0, 0);
            this.tlpControl.Controls.Add(this.pnlTipCred, 0, 1);
            this.tlpControl.Controls.Add(this.pnlTasa, 0, 2);
            this.tlpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControl.Location = new System.Drawing.Point(0, 0);
            this.tlpControl.Margin = new System.Windows.Forms.Padding(0);
            this.tlpControl.Name = "tlpControl";
            this.tlpControl.RowCount = 3;
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControl.Size = new System.Drawing.Size(325, 275);
            this.tlpControl.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ConCreditoTasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tlpControl);
            this.Name = "ConCreditoTasa";
            this.Size = new System.Drawing.Size(325, 275);
            this.pnlDatCred.ResumeLayout(false);
            this.pnlDatCred.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            this.pnlTipCred.ResumeLayout(false);
            this.pnlTipCred.PerformLayout();
            this.pnlTasa.ResumeLayout(false);
            this.pnlTasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTasaAprob)).EndInit();
            this.tlpControl.ResumeLayout(false);
            this.tlpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nudBase nudDiasGracia;
        private dtLargoBase dtFechaDesembolso;
        private lblBaseCustom lblDesembolso;
        private cboBase cboTipoTasaCredito;
        private lblBaseCustom lblBaseCustom44;
        private lblBaseCustom lblBaseCustom41;
        private lblBaseCustom lblBaseCustom42;
        private lblBaseCustom lblBaseCustom43;
        private txtNumRea txtTasCompensatoriaMin;
        private txtNumRea txtTEM;
        private txtNumRea txtTasCompensatoriaMax;
        private lblBase lblBase3;
        private lblBase lblBase4;
        private cboMoneda cboMoneda;
        private txtNumRea txtTasaMora;
        private lblBase lblBase2;
        private lblBaseCustom lblBaseCustom30;
        private txtNumRea txtTEA;
        private lblBaseCustom lblBaseCustom4;
        private lblBase lblBase5;
        private txtNumRea txtMonto;
        private nudBase nudCuotas;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlDatCred;
        private System.Windows.Forms.Panel pnlTasa;
        private System.Windows.Forms.Panel pnlTipCred;
        private conProducto conNivelesProducto;
        private System.Windows.Forms.TableLayoutPanel tlpControl;
        private nudBase nudCuotasGracia;
        private lblBaseCustom lblBaseCustom1;
        private System.Windows.Forms.PictureBox pbxTasaAprob;
        private System.Windows.Forms.Label lblAlertSobredeuda;
        private System.Windows.Forms.Label lblSobreDeuda;
        private lblBaseCustom lblClasifInterna;
        public ConCreditoPeriodo conCreditoPeriodo;
        private ConCreditoPrimeraCuota conCreditoPrimeraCuota;
    }
}
