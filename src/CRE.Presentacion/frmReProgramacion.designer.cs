namespace CRE.Presentacion
{
    partial class frmReProgramacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReProgramacion));
            CRE.CapaNegocio.clsCNPlanPago clsCNPlanPago1 = new CRE.CapaNegocio.clsCNPlanPago();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboTipoPeriodo = new GEN.ControlesBase.cboTipoPeriodo(this.components);
            this.nudPeriodo = new GEN.ControlesBase.nudBase(this.components);
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.lblDesTipo = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMonAprobado = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.nudNumCuota = new GEN.ControlesBase.nudBase(this.components);
            this.dtpFecDesembolso = new GEN.ControlesBase.dtpCorto(this.components);
            this.clsPlanPagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.tbcReprograma = new GEN.ControlesBase.tbcBase(this.components);
            this.tabDatosRepro = new System.Windows.Forms.TabPage();
            this.btnGestionContacto = new GEN.BotonesBase.Boton();
            this.conDatosReprogramacion = new GEN.ControlesBase.conDatosReprogramacion();
            this.dtpFecPrimeraCuota = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase19 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.dtgConfigGasto = new GEN.ControlesBase.dtgBase(this.components);
            this.chcMantenerCuotasCtes = new GEN.ControlesBase.chcBase(this.components);
            this.tabPpgActual = new System.Windows.Forms.TabPage();
            this.dtgPpgActual = new GEN.ControlesBase.dtgBase(this.components);
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.conPlanPagos = new GEN.ControlesBase.conPlanPagos();
            this.btnChecklist = new GEN.BotonesBase.btnDocumento();
            this.idCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaProg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapitalSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nInteres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nInteresFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nInteresPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIntComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nInteresCompPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMoraPagada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOtros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOtrosPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNumDiaCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtrasoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conBusCuentaCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsPlanPagoBindingSource)).BeginInit();
            this.tbcReprograma.SuspendLayout();
            this.tabDatosRepro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).BeginInit();
            this.tabPpgActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpgActual)).BeginInit();
            this.tabCalendario.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Controls.Add(this.grbBase1);
            this.conBusCuentaCli.Location = new System.Drawing.Point(17, 28);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(554, 101);
            this.conBusCuentaCli.TabIndex = 2;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 94);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(663, 334);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(0, 13);
            this.lblBase15.TabIndex = 55;
            // 
            // cboTipoPeriodo
            // 
            this.cboTipoPeriodo.Enabled = false;
            this.cboTipoPeriodo.FormattingEnabled = true;
            this.cboTipoPeriodo.Location = new System.Drawing.Point(442, 191);
            this.cboTipoPeriodo.Name = "cboTipoPeriodo";
            this.cboTipoPeriodo.Size = new System.Drawing.Size(87, 21);
            this.cboTipoPeriodo.TabIndex = 54;
            this.cboTipoPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged);
            // 
            // nudPeriodo
            // 
            this.nudPeriodo.Enabled = false;
            this.nudPeriodo.Location = new System.Drawing.Point(442, 230);
            this.nudPeriodo.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudPeriodo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodo.Name = "nudPeriodo";
            this.nudPeriodo.Size = new System.Drawing.Size(87, 20);
            this.nudPeriodo.TabIndex = 49;
            this.nudPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPeriodo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Enabled = false;
            this.nudDiasGracia.Location = new System.Drawing.Point(442, 155);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudDiasGracia.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.Size = new System.Drawing.Size(87, 20);
            this.nudDiasGracia.TabIndex = 47;
            this.nudDiasGracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDesTipo
            // 
            this.lblDesTipo.AutoSize = true;
            this.lblDesTipo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDesTipo.ForeColor = System.Drawing.Color.Navy;
            this.lblDesTipo.Location = new System.Drawing.Point(340, 233);
            this.lblDesTipo.Name = "lblDesTipo";
            this.lblDesTipo.Size = new System.Drawing.Size(81, 13);
            this.lblDesTipo.TabIndex = 53;
            this.lblDesTipo.Text = "Día de Pago:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 157);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(134, 13);
            this.lblBase1.TabIndex = 43;
            this.lblBase1.Text = "Monto a reprogramar:";
            // 
            // txtMonAprobado
            // 
            this.txtMonAprobado.Enabled = false;
            this.txtMonAprobado.FormatoDecimal = false;
            this.txtMonAprobado.Location = new System.Drawing.Point(170, 154);
            this.txtMonAprobado.Name = "txtMonAprobado";
            this.txtMonAprobado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonAprobado.nNumDecimales = 2;
            this.txtMonAprobado.nvalor = 0D;
            this.txtMonAprobado.Size = new System.Drawing.Size(92, 20);
            this.txtMonAprobado.TabIndex = 44;
            this.txtMonAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(340, 193);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(101, 13);
            this.lblBase6.TabIndex = 52;
            this.lblBase6.Text = "Tipo de Periodo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(340, 157);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(96, 13);
            this.lblBase5.TabIndex = 51;
            this.lblBase5.Text = "Días de Gracia:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 231);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(119, 13);
            this.lblBase4.TabIndex = 50;
            this.lblBase4.Text = "Número de Cuotas:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 193);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(158, 13);
            this.lblBase2.TabIndex = 48;
            this.lblBase2.Text = "Fecha de reprogramación:";
            // 
            // nudNumCuota
            // 
            this.nudNumCuota.Enabled = false;
            this.nudNumCuota.Location = new System.Drawing.Point(170, 229);
            this.nudNumCuota.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudNumCuota.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumCuota.Name = "nudNumCuota";
            this.nudNumCuota.Size = new System.Drawing.Size(67, 20);
            this.nudNumCuota.TabIndex = 56;
            this.nudNumCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumCuota.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFecDesembolso
            // 
            this.dtpFecDesembolso.Enabled = false;
            this.dtpFecDesembolso.Location = new System.Drawing.Point(170, 189);
            this.dtpFecDesembolso.Name = "dtpFecDesembolso";
            this.dtpFecDesembolso.Size = new System.Drawing.Size(92, 20);
            this.dtpFecDesembolso.TabIndex = 57;
            // 
            // clsPlanPagoBindingSource
            // 
            this.clsPlanPagoBindingSource.DataSource = typeof(EntityLayer.clsPlanPago);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(914, 621);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 59;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(848, 621);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 60;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(782, 621);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 61;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(716, 621);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(627, 193);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(81, 13);
            this.lblBase3.TabIndex = 50;
            this.lblBase3.Text = "Tasa interes:";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Enabled = false;
            this.txtTasaInteres.FormatoDecimal = false;
            this.txtTasaInteres.Location = new System.Drawing.Point(724, 190);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaInteres.nNumDecimales = 2;
            this.txtTasaInteres.nvalor = 0D;
            this.txtTasaInteres.Size = new System.Drawing.Size(121, 20);
            this.txtTasaInteres.TabIndex = 44;
            this.txtTasaInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dFechaPago";
            this.dataGridViewTextBoxColumn1.HeaderText = "dFechaPago";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 24;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(650, 621);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 63;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(627, 156);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 88;
            this.lblBase7.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(724, 153);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 87;
            // 
            // tbcReprograma
            // 
            this.tbcReprograma.Controls.Add(this.tabDatosRepro);
            this.tbcReprograma.Controls.Add(this.tabPpgActual);
            this.tbcReprograma.Controls.Add(this.tabCalendario);
            this.tbcReprograma.Location = new System.Drawing.Point(12, 12);
            this.tbcReprograma.Name = "tbcReprograma";
            this.tbcReprograma.SelectedIndex = 0;
            this.tbcReprograma.Size = new System.Drawing.Size(962, 603);
            this.tbcReprograma.TabIndex = 89;
            // 
            // tabDatosRepro
            // 
            this.tabDatosRepro.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabDatosRepro.Controls.Add(this.btnGestionContacto);
            this.tabDatosRepro.Controls.Add(this.conDatosReprogramacion);
            this.tabDatosRepro.Controls.Add(this.conBusCuentaCli);
            this.tabDatosRepro.Controls.Add(this.dtpFecPrimeraCuota);
            this.tabDatosRepro.Controls.Add(this.lblBase19);
            this.tabDatosRepro.Controls.Add(this.lblBase16);
            this.tabDatosRepro.Controls.Add(this.dtgConfigGasto);
            this.tabDatosRepro.Controls.Add(this.chcMantenerCuotasCtes);
            this.tabDatosRepro.Controls.Add(this.dtpFecDesembolso);
            this.tabDatosRepro.Controls.Add(this.lblBase7);
            this.tabDatosRepro.Controls.Add(this.lblBase2);
            this.tabDatosRepro.Controls.Add(this.cboMoneda);
            this.tabDatosRepro.Controls.Add(this.lblBase4);
            this.tabDatosRepro.Controls.Add(this.lblBase3);
            this.tabDatosRepro.Controls.Add(this.lblBase5);
            this.tabDatosRepro.Controls.Add(this.lblBase6);
            this.tabDatosRepro.Controls.Add(this.txtMonAprobado);
            this.tabDatosRepro.Controls.Add(this.txtTasaInteres);
            this.tabDatosRepro.Controls.Add(this.lblBase1);
            this.tabDatosRepro.Controls.Add(this.nudNumCuota);
            this.tabDatosRepro.Controls.Add(this.lblDesTipo);
            this.tabDatosRepro.Controls.Add(this.lblBase15);
            this.tabDatosRepro.Controls.Add(this.nudDiasGracia);
            this.tabDatosRepro.Controls.Add(this.cboTipoPeriodo);
            this.tabDatosRepro.Controls.Add(this.nudPeriodo);
            this.tabDatosRepro.Location = new System.Drawing.Point(4, 22);
            this.tabDatosRepro.Name = "tabDatosRepro";
            this.tabDatosRepro.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatosRepro.Size = new System.Drawing.Size(954, 577);
            this.tabDatosRepro.TabIndex = 0;
            this.tabDatosRepro.Text = "Datos de la Reprogramación";
            // 
            // btnGestionContacto
            // 
            this.btnGestionContacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestionContacto.Location = new System.Drawing.Point(436, 37);
            this.btnGestionContacto.Name = "btnGestionContacto";
            this.btnGestionContacto.Size = new System.Drawing.Size(60, 50);
            this.btnGestionContacto.TabIndex = 140;
            this.btnGestionContacto.Text = "Gestión de Contacto";
            this.btnGestionContacto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionContacto.UseVisualStyleBackColor = true;
            this.btnGestionContacto.Click += new System.EventHandler(this.btnGestionContacto_Click);
            // 
            // conDatosReprogramacion
            // 
            this.conDatosReprogramacion.idCuenta = 0;
            this.conDatosReprogramacion.lAlerta = false;
            this.conDatosReprogramacion.lMostrarMontoCuota = false;
            this.conDatosReprogramacion.Location = new System.Drawing.Point(623, 53);
            this.conDatosReprogramacion.Margin = new System.Windows.Forms.Padding(0);
            this.conDatosReprogramacion.Name = "conDatosReprogramacion";
            this.conDatosReprogramacion.Size = new System.Drawing.Size(340, 50);
            this.conDatosReprogramacion.TabIndex = 139;
            // 
            // dtpFecPrimeraCuota
            // 
            this.dtpFecPrimeraCuota.Location = new System.Drawing.Point(725, 230);
            this.dtpFecPrimeraCuota.Name = "dtpFecPrimeraCuota";
            this.dtpFecPrimeraCuota.Size = new System.Drawing.Size(107, 20);
            this.dtpFecPrimeraCuota.TabIndex = 135;
            this.dtpFecPrimeraCuota.ValueChanged += new System.EventHandler(this.dtpFecPrimeraCuota_ValueChanged);
            // 
            // lblBase19
            // 
            this.lblBase19.AutoSize = true;
            this.lblBase19.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase19.ForeColor = System.Drawing.Color.Navy;
            this.lblBase19.Location = new System.Drawing.Point(627, 234);
            this.lblBase19.Name = "lblBase19";
            this.lblBase19.Size = new System.Drawing.Size(95, 13);
            this.lblBase19.TabIndex = 136;
            this.lblBase19.Text = "Primera Cuota:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(14, 309);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(165, 13);
            this.lblBase16.TabIndex = 129;
            this.lblBase16.Text = "Configuraciones Aplicables:";
            // 
            // dtgConfigGasto
            // 
            this.dtgConfigGasto.AllowUserToAddRows = false;
            this.dtgConfigGasto.AllowUserToDeleteRows = false;
            this.dtgConfigGasto.AllowUserToResizeColumns = false;
            this.dtgConfigGasto.AllowUserToResizeRows = false;
            this.dtgConfigGasto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigGasto.Location = new System.Drawing.Point(14, 325);
            this.dtgConfigGasto.MultiSelect = false;
            this.dtgConfigGasto.Name = "dtgConfigGasto";
            this.dtgConfigGasto.ReadOnly = true;
            this.dtgConfigGasto.RowHeadersVisible = false;
            this.dtgConfigGasto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigGasto.Size = new System.Drawing.Size(923, 223);
            this.dtgConfigGasto.TabIndex = 128;
            // 
            // chcMantenerCuotasCtes
            // 
            this.chcMantenerCuotasCtes.AutoSize = true;
            this.chcMantenerCuotasCtes.Checked = true;
            this.chcMantenerCuotasCtes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcMantenerCuotasCtes.ForeColor = System.Drawing.Color.Navy;
            this.chcMantenerCuotasCtes.Location = new System.Drawing.Point(17, 270);
            this.chcMantenerCuotasCtes.Name = "chcMantenerCuotasCtes";
            this.chcMantenerCuotasCtes.Size = new System.Drawing.Size(323, 17);
            this.chcMantenerCuotasCtes.TabIndex = 127;
            this.chcMantenerCuotasCtes.Text = "Mantener Cuotas Constantes (a pesar de Comisiones variables)";
            this.chcMantenerCuotasCtes.UseVisualStyleBackColor = true;
            // 
            // tabPpgActual
            // 
            this.tabPpgActual.Controls.Add(this.dtgPpgActual);
            this.tabPpgActual.Location = new System.Drawing.Point(4, 22);
            this.tabPpgActual.Name = "tabPpgActual";
            this.tabPpgActual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPpgActual.Size = new System.Drawing.Size(954, 577);
            this.tabPpgActual.TabIndex = 2;
            this.tabPpgActual.Text = "Plan pagos actual";
            this.tabPpgActual.UseVisualStyleBackColor = true;
            // 
            // dtgPpgActual
            // 
            this.dtgPpgActual.AllowUserToAddRows = false;
            this.dtgPpgActual.AllowUserToDeleteRows = false;
            this.dtgPpgActual.AllowUserToResizeColumns = false;
            this.dtgPpgActual.AllowUserToResizeRows = false;
            this.dtgPpgActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPpgActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPpgActual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuota,
            this.dFechaProg,
            this.dFechaValor,
            this.nSaldoCapital,
            this.nCapital,
            this.nCapitalSaldo,
            this.nInteres,
            this.nInteresFecha,
            this.nInteresPagado,
            this.nIntComp,
            this.nInteresCompPago,
            this.nMora,
            this.nMoraPagada,
            this.nOtros,
            this.nOtrosPagado,
            this.nNumDiaCuota,
            this.nAtrasoCuota});
            this.dtgPpgActual.Location = new System.Drawing.Point(6, 6);
            this.dtgPpgActual.MultiSelect = false;
            this.dtgPpgActual.Name = "dtgPpgActual";
            this.dtgPpgActual.ReadOnly = true;
            this.dtgPpgActual.RowHeadersVisible = false;
            this.dtgPpgActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPpgActual.Size = new System.Drawing.Size(942, 565);
            this.dtgPpgActual.TabIndex = 0;
            this.dtgPpgActual.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPpgActual_CellDoubleClick);
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.conPlanPagos);
            this.tabCalendario.Location = new System.Drawing.Point(4, 22);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(954, 577);
            this.tabCalendario.TabIndex = 1;
            this.tabCalendario.Text = "Calendario de Pagos";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // conPlanPagos
            // 
            this.conPlanPagos.cnplanpago = clsCNPlanPago1;
            this.conPlanPagos.dFechaDesembolso = new System.DateTime(((long)(0)));
            this.conPlanPagos.dFecPriCuota = new System.DateTime(((long)(0)));
            this.conPlanPagos.dtCalendarioPagos = null;
            this.conPlanPagos.dtCargaGastos = null;
            this.conPlanPagos.dtGastosPP = null;
            this.conPlanPagos.idMoneda = 0;
            this.conPlanPagos.IdSolicitud = 0;
            this.conPlanPagos.idTipoPlanPago = 0;
            this.conPlanPagos.lCuotaCte = false;
            this.conPlanPagos.lEditorEnabled = true;
            this.conPlanPagos.Location = new System.Drawing.Point(6, 3);
            this.conPlanPagos.Name = "conPlanPagos";
            this.conPlanPagos.nCapitalMaxCobSeg = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos.nDiasGracia = 0;
            this.conPlanPagos.nMonto = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos.nNumCuotas = 0;
            this.conPlanPagos.nPlazo = 0;
            this.conPlanPagos.nTasaInteres = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos.nTipPeriodo = ((short)(0));
            this.conPlanPagos.Size = new System.Drawing.Size(945, 564);
            this.conPlanPagos.TabIndex = 0;
            this.conPlanPagos.clickModificaciones += new System.EventHandler(this.conPlanPagos_clickModificaciones);
            this.conPlanPagos.ModificacionesCanceladas += new System.EventHandler(this.conPlanPagos_ModificacionesCanceladas);
            // 
            // btnChecklist
            // 
            this.btnChecklist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChecklist.BackgroundImage")));
            this.btnChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Location = new System.Drawing.Point(584, 621);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(60, 50);
            this.btnChecklist.TabIndex = 90;
            this.btnChecklist.Text = "Checklist";
            this.btnChecklist.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChecklist.UseVisualStyleBackColor = true;
            this.btnChecklist.Click += new System.EventHandler(this.btnChecklist_Click);
            // 
            // idCuota
            // 
            this.idCuota.DataPropertyName = "idCuota";
            this.idCuota.FillWeight = 65.15697F;
            this.idCuota.HeaderText = "N° cuota";
            this.idCuota.Name = "idCuota";
            this.idCuota.ReadOnly = true;
            // 
            // dFechaProg
            // 
            this.dFechaProg.DataPropertyName = "dFechaProg";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.dFechaProg.DefaultCellStyle = dataGridViewCellStyle1;
            this.dFechaProg.FillWeight = 150.3622F;
            this.dFechaProg.HeaderText = "Fec. Prog";
            this.dFechaProg.Name = "dFechaProg";
            this.dFechaProg.ReadOnly = true;
            // 
            // dFechaValor
            // 
            this.dFechaValor.DataPropertyName = "dFechaValor";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.dFechaValor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dFechaValor.FillWeight = 146.2691F;
            this.dFechaValor.HeaderText = "Fec. Valor";
            this.dFechaValor.Name = "dFechaValor";
            this.dFechaValor.ReadOnly = true;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            dataGridViewCellStyle3.Format = "#,0.00";
            dataGridViewCellStyle3.NullValue = null;
            this.nSaldoCapital.DefaultCellStyle = dataGridViewCellStyle3;
            this.nSaldoCapital.FillWeight = 100.2415F;
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            // 
            // nCapital
            // 
            this.nCapital.DataPropertyName = "nCapital";
            dataGridViewCellStyle4.Format = "#,0.00";
            this.nCapital.DefaultCellStyle = dataGridViewCellStyle4;
            this.nCapital.FillWeight = 100.2415F;
            this.nCapital.HeaderText = "Capital";
            this.nCapital.Name = "nCapital";
            this.nCapital.ReadOnly = true;
            // 
            // nCapitalSaldo
            // 
            this.nCapitalSaldo.DataPropertyName = "nCapitalSaldo";
            dataGridViewCellStyle5.Format = "#,0.00";
            this.nCapitalSaldo.DefaultCellStyle = dataGridViewCellStyle5;
            this.nCapitalSaldo.FillWeight = 100.2415F;
            this.nCapitalSaldo.HeaderText = "Saldo Cap.";
            this.nCapitalSaldo.Name = "nCapitalSaldo";
            this.nCapitalSaldo.ReadOnly = true;
            // 
            // nInteres
            // 
            this.nInteres.DataPropertyName = "nInteres";
            dataGridViewCellStyle6.Format = "#,0.00";
            this.nInteres.DefaultCellStyle = dataGridViewCellStyle6;
            this.nInteres.FillWeight = 100.2415F;
            this.nInteres.HeaderText = "Interes";
            this.nInteres.Name = "nInteres";
            this.nInteres.ReadOnly = true;
            // 
            // nInteresFecha
            // 
            this.nInteresFecha.DataPropertyName = "nInteresFecha";
            dataGridViewCellStyle7.Format = "#,0.00";
            this.nInteresFecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.nInteresFecha.FillWeight = 100.2415F;
            this.nInteresFecha.HeaderText = "Interes fecha";
            this.nInteresFecha.Name = "nInteresFecha";
            this.nInteresFecha.ReadOnly = true;
            // 
            // nInteresPagado
            // 
            this.nInteresPagado.DataPropertyName = "nInteresPagado";
            dataGridViewCellStyle8.Format = "#,0.00";
            this.nInteresPagado.DefaultCellStyle = dataGridViewCellStyle8;
            this.nInteresPagado.FillWeight = 100.2415F;
            this.nInteresPagado.HeaderText = "Interes pag.";
            this.nInteresPagado.Name = "nInteresPagado";
            this.nInteresPagado.ReadOnly = true;
            // 
            // nIntComp
            // 
            this.nIntComp.DataPropertyName = "nIntComp";
            dataGridViewCellStyle9.Format = "#,0.00";
            this.nIntComp.DefaultCellStyle = dataGridViewCellStyle9;
            this.nIntComp.FillWeight = 100.2415F;
            this.nIntComp.HeaderText = "Int. comp.";
            this.nIntComp.Name = "nIntComp";
            this.nIntComp.ReadOnly = true;
            // 
            // nInteresCompPago
            // 
            this.nInteresCompPago.DataPropertyName = "nInteresCompPago";
            dataGridViewCellStyle10.Format = "#,0.00";
            this.nInteresCompPago.DefaultCellStyle = dataGridViewCellStyle10;
            this.nInteresCompPago.FillWeight = 100.2415F;
            this.nInteresCompPago.HeaderText = "Int. comp. pag.";
            this.nInteresCompPago.Name = "nInteresCompPago";
            this.nInteresCompPago.ReadOnly = true;
            // 
            // nMora
            // 
            this.nMora.DataPropertyName = "nMora";
            dataGridViewCellStyle11.Format = "#,0.00";
            this.nMora.DefaultCellStyle = dataGridViewCellStyle11;
            this.nMora.FillWeight = 100.2415F;
            this.nMora.HeaderText = "Mora";
            this.nMora.Name = "nMora";
            this.nMora.ReadOnly = true;
            // 
            // nMoraPagada
            // 
            this.nMoraPagada.DataPropertyName = "nMoraPagada";
            dataGridViewCellStyle12.Format = "#,0.00";
            this.nMoraPagada.DefaultCellStyle = dataGridViewCellStyle12;
            this.nMoraPagada.FillWeight = 100.2415F;
            this.nMoraPagada.HeaderText = "Mora pag.";
            this.nMoraPagada.Name = "nMoraPagada";
            this.nMoraPagada.ReadOnly = true;
            // 
            // nOtros
            // 
            this.nOtros.DataPropertyName = "nOtros";
            this.nOtros.FillWeight = 100.2415F;
            this.nOtros.HeaderText = "Seg.|Comi.";
            this.nOtros.Name = "nOtros";
            this.nOtros.ReadOnly = true;
            // 
            // nOtrosPagado
            // 
            this.nOtrosPagado.DataPropertyName = "nOtrosPagado";
            this.nOtrosPagado.FillWeight = 100.2415F;
            this.nOtrosPagado.HeaderText = "Seg.|Comi. Pag.";
            this.nOtrosPagado.Name = "nOtrosPagado";
            this.nOtrosPagado.ReadOnly = true;
            // 
            // nNumDiaCuota
            // 
            this.nNumDiaCuota.DataPropertyName = "nNumDiaCuota";
            this.nNumDiaCuota.FillWeight = 65.15697F;
            this.nNumDiaCuota.HeaderText = "Dias cuota";
            this.nNumDiaCuota.Name = "nNumDiaCuota";
            this.nNumDiaCuota.ReadOnly = true;
            // 
            // nAtrasoCuota
            // 
            this.nAtrasoCuota.DataPropertyName = "nAtrasoCuota";
            this.nAtrasoCuota.FillWeight = 65.15697F;
            this.nAtrasoCuota.HeaderText = "Atraso";
            this.nAtrasoCuota.Name = "nAtrasoCuota";
            this.nAtrasoCuota.ReadOnly = true;
            // 
            // frmReProgramacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 696);
            this.Controls.Add(this.btnChecklist);
            this.Controls.Add(this.tbcReprograma);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmReProgramacion";
            this.Text = "Re-Programación de Crédito";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.tbcReprograma, 0);
            this.Controls.SetChildIndex(this.btnChecklist, 0);
            this.conBusCuentaCli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsPlanPagoBindingSource)).EndInit();
            this.tbcReprograma.ResumeLayout(false);
            this.tabDatosRepro.ResumeLayout(false);
            this.tabDatosRepro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).EndInit();
            this.tabPpgActual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpgActual)).EndInit();
            this.tabCalendario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboTipoPeriodo cboTipoPeriodo;
        private GEN.ControlesBase.nudBase nudPeriodo;
        private GEN.ControlesBase.nudBase nudDiasGracia;
        private GEN.ControlesBase.lblBase lblDesTipo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtMonAprobado;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.nudBase nudNumCuota;
        private GEN.ControlesBase.dtpCorto dtpFecDesembolso;
        private System.Windows.Forms.BindingSource clsPlanPagoBindingSource;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTasaInteres;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.tbcBase tbcReprograma;
        private System.Windows.Forms.TabPage tabDatosRepro;
        private System.Windows.Forms.TabPage tabCalendario;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.dtgBase dtgConfigGasto;
        private GEN.ControlesBase.chcBase chcMantenerCuotasCtes;
        private GEN.ControlesBase.dtpCorto dtpFecPrimeraCuota;
        private GEN.ControlesBase.lblBase lblBase19;
        private GEN.ControlesBase.conPlanPagos conPlanPagos;
        private System.Windows.Forms.TabPage tabPpgActual;
        private GEN.ControlesBase.dtgBase dtgPpgActual;
        private GEN.ControlesBase.conDatosReprogramacion conDatosReprogramacion;
        private GEN.BotonesBase.btnDocumento btnChecklist;
        private GEN.BotonesBase.Boton btnGestionContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaProg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapitalSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nInteres;
        private System.Windows.Forms.DataGridViewTextBoxColumn nInteresFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nInteresPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIntComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nInteresCompPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMora;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMoraPagada;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOtros;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOtrosPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNumDiaCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtrasoCuota;
    }
}

