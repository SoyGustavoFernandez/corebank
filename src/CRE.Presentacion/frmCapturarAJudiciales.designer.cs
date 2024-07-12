namespace CRE.Presentacion
{
    partial class frmCapturarAJudiciales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturarAJudiciales));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.dtgCuentas = new GEN.ControlesBase.dtgBase(this.components);
            this.chcSeleccionarTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtTasaInteresJudicial = new GEN.ControlesBase.rbtBase(this.components);
            this.txtTasaInteresJudicial = new GEN.ControlesBase.txtNumRea(this.components);
            this.rbtTasaInteresPactada = new GEN.ControlesBase.rbtBase(this.components);
            this.txtTasaInteresPactada = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTasaMoraJudicial = new GEN.ControlesBase.txtNumRea(this.components);
            this.rbtTasaMoraJudicial = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtTasaMoraPactada = new GEN.ControlesBase.rbtBase(this.components);
            this.txtTasaMoraPactada = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbDetallesCredito = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtSaldoOtros = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtSaldoMora = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtSaldoInteres = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalDeuda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            this.grbOtros = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtAnalista = new GEN.ControlesBase.txtBase(this.components);
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtEstadoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.txtTasaMoratoria = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDiasAtraso = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentas)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbDetallesCredito.SuspendLayout();
            this.grbOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(513, 444);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(450, 444);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dtgCuentas
            // 
            this.dtgCuentas.AllowUserToAddRows = false;
            this.dtgCuentas.AllowUserToDeleteRows = false;
            this.dtgCuentas.AllowUserToResizeColumns = false;
            this.dtgCuentas.AllowUserToResizeRows = false;
            this.dtgCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentas.Location = new System.Drawing.Point(9, 15);
            this.dtgCuentas.MultiSelect = false;
            this.dtgCuentas.Name = "dtgCuentas";
            this.dtgCuentas.ReadOnly = true;
            this.dtgCuentas.RowHeadersVisible = false;
            this.dtgCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentas.Size = new System.Drawing.Size(565, 202);
            this.dtgCuentas.TabIndex = 15;
            this.dtgCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentas_CellClick);
            this.dtgCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentas_CellContentClick);
            this.dtgCuentas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentas_CellContentDoubleClick);
            this.dtgCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCuentas_KeyDown);
            // 
            // chcSeleccionarTodos
            // 
            this.chcSeleccionarTodos.AutoSize = true;
            this.chcSeleccionarTodos.Location = new System.Drawing.Point(14, 454);
            this.chcSeleccionarTodos.Name = "chcSeleccionarTodos";
            this.chcSeleccionarTodos.Size = new System.Drawing.Size(115, 17);
            this.chcSeleccionarTodos.TabIndex = 16;
            this.chcSeleccionarTodos.Text = "Seleccionar Todos";
            this.chcSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chcSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chcSeleccionarTodos_CheckedChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 1);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(54, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Cuentas";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtTasaInteresJudicial);
            this.grbBase1.Controls.Add(this.txtTasaInteresJudicial);
            this.grbBase1.Controls.Add(this.rbtTasaInteresPactada);
            this.grbBase1.Controls.Add(this.txtTasaInteresPactada);
            this.grbBase1.Location = new System.Drawing.Point(9, 370);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(278, 68);
            this.grbBase1.TabIndex = 23;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Tasa Interés Judicial";
            // 
            // rbtTasaInteresJudicial
            // 
            this.rbtTasaInteresJudicial.AutoSize = true;
            this.rbtTasaInteresJudicial.ForeColor = System.Drawing.Color.Navy;
            this.rbtTasaInteresJudicial.Location = new System.Drawing.Point(5, 39);
            this.rbtTasaInteresJudicial.Name = "rbtTasaInteresJudicial";
            this.rbtTasaInteresJudicial.Size = new System.Drawing.Size(180, 17);
            this.rbtTasaInteresJudicial.TabIndex = 22;
            this.rbtTasaInteresJudicial.TabStop = true;
            this.rbtTasaInteresJudicial.Text = "Tasa Especial de Interés Judicial";
            this.rbtTasaInteresJudicial.UseVisualStyleBackColor = true;
            // 
            // txtTasaInteresJudicial
            // 
            this.txtTasaInteresJudicial.FormatoDecimal = false;
            this.txtTasaInteresJudicial.Location = new System.Drawing.Point(184, 39);
            this.txtTasaInteresJudicial.Name = "txtTasaInteresJudicial";
            this.txtTasaInteresJudicial.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaInteresJudicial.nNumDecimales = 4;
            this.txtTasaInteresJudicial.nvalor = 0D;
            this.txtTasaInteresJudicial.Size = new System.Drawing.Size(87, 20);
            this.txtTasaInteresJudicial.TabIndex = 30;
            // 
            // rbtTasaInteresPactada
            // 
            this.rbtTasaInteresPactada.AutoSize = true;
            this.rbtTasaInteresPactada.ForeColor = System.Drawing.Color.Navy;
            this.rbtTasaInteresPactada.Location = new System.Drawing.Point(5, 16);
            this.rbtTasaInteresPactada.Name = "rbtTasaInteresPactada";
            this.rbtTasaInteresPactada.Size = new System.Drawing.Size(142, 17);
            this.rbtTasaInteresPactada.TabIndex = 21;
            this.rbtTasaInteresPactada.TabStop = true;
            this.rbtTasaInteresPactada.Text = "Tasa de Interés Pactada";
            this.rbtTasaInteresPactada.UseVisualStyleBackColor = true;
            this.rbtTasaInteresPactada.CheckedChanged += new System.EventHandler(this.rbtTasaInteresPactada_CheckedChanged);
            // 
            // txtTasaInteresPactada
            // 
            this.txtTasaInteresPactada.Enabled = false;
            this.txtTasaInteresPactada.Location = new System.Drawing.Point(184, 13);
            this.txtTasaInteresPactada.Name = "txtTasaInteresPactada";
            this.txtTasaInteresPactada.Size = new System.Drawing.Size(87, 20);
            this.txtTasaInteresPactada.TabIndex = 20;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTasaMoraJudicial);
            this.grbBase2.Controls.Add(this.rbtTasaMoraJudicial);
            this.grbBase2.Controls.Add(this.rbtTasaMoraPactada);
            this.grbBase2.Controls.Add(this.txtTasaMoraPactada);
            this.grbBase2.Location = new System.Drawing.Point(302, 370);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(272, 68);
            this.grbBase2.TabIndex = 24;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Tasa Mora Judicial";
            // 
            // txtTasaMoraJudicial
            // 
            this.txtTasaMoraJudicial.FormatoDecimal = false;
            this.txtTasaMoraJudicial.Location = new System.Drawing.Point(178, 39);
            this.txtTasaMoraJudicial.Name = "txtTasaMoraJudicial";
            this.txtTasaMoraJudicial.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMoraJudicial.nNumDecimales = 4;
            this.txtTasaMoraJudicial.nvalor = 0D;
            this.txtTasaMoraJudicial.Size = new System.Drawing.Size(87, 20);
            this.txtTasaMoraJudicial.TabIndex = 31;
            // 
            // rbtTasaMoraJudicial
            // 
            this.rbtTasaMoraJudicial.AutoSize = true;
            this.rbtTasaMoraJudicial.ForeColor = System.Drawing.Color.Navy;
            this.rbtTasaMoraJudicial.Location = new System.Drawing.Point(11, 39);
            this.rbtTasaMoraJudicial.Name = "rbtTasaMoraJudicial";
            this.rbtTasaMoraJudicial.Size = new System.Drawing.Size(172, 17);
            this.rbtTasaMoraJudicial.TabIndex = 24;
            this.rbtTasaMoraJudicial.TabStop = true;
            this.rbtTasaMoraJudicial.Text = "Tasa Especial de Mora Judicial";
            this.rbtTasaMoraJudicial.UseVisualStyleBackColor = true;
            // 
            // rbtTasaMoraPactada
            // 
            this.rbtTasaMoraPactada.AutoSize = true;
            this.rbtTasaMoraPactada.ForeColor = System.Drawing.Color.Navy;
            this.rbtTasaMoraPactada.Location = new System.Drawing.Point(11, 16);
            this.rbtTasaMoraPactada.Name = "rbtTasaMoraPactada";
            this.rbtTasaMoraPactada.Size = new System.Drawing.Size(134, 17);
            this.rbtTasaMoraPactada.TabIndex = 23;
            this.rbtTasaMoraPactada.TabStop = true;
            this.rbtTasaMoraPactada.Text = "Tasa de Mora Pactada";
            this.rbtTasaMoraPactada.UseVisualStyleBackColor = true;
            this.rbtTasaMoraPactada.CheckedChanged += new System.EventHandler(this.rbtTasaMoraPactada_CheckedChanged);
            // 
            // txtTasaMoraPactada
            // 
            this.txtTasaMoraPactada.Enabled = false;
            this.txtTasaMoraPactada.Location = new System.Drawing.Point(178, 13);
            this.txtTasaMoraPactada.Name = "txtTasaMoraPactada";
            this.txtTasaMoraPactada.Size = new System.Drawing.Size(87, 20);
            this.txtTasaMoraPactada.TabIndex = 21;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(387, 444);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 27;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Visible = false;
            // 
            // grbDetallesCredito
            // 
            this.grbDetallesCredito.Controls.Add(this.lblBase9);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoOtros);
            this.grbDetallesCredito.Controls.Add(this.lblBase8);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoMora);
            this.grbDetallesCredito.Controls.Add(this.lblBase7);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoInteres);
            this.grbDetallesCredito.Controls.Add(this.txtTotalDeuda);
            this.grbDetallesCredito.Controls.Add(this.lblBase6);
            this.grbDetallesCredito.Controls.Add(this.lblBase2);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoCapital);
            this.grbDetallesCredito.Enabled = false;
            this.grbDetallesCredito.Location = new System.Drawing.Point(9, 223);
            this.grbDetallesCredito.Name = "grbDetallesCredito";
            this.grbDetallesCredito.Size = new System.Drawing.Size(278, 144);
            this.grbDetallesCredito.TabIndex = 28;
            this.grbDetallesCredito.TabStop = false;
            this.grbDetallesCredito.Text = "Detalles de Crédito";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(11, 77);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(79, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Saldo Otros:";
            // 
            // txtSaldoOtros
            // 
            this.txtSaldoOtros.Location = new System.Drawing.Point(106, 74);
            this.txtSaldoOtros.Name = "txtSaldoOtros";
            this.txtSaldoOtros.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoOtros.TabIndex = 23;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(11, 56);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(76, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Saldo Mora:";
            // 
            // txtSaldoMora
            // 
            this.txtSaldoMora.Location = new System.Drawing.Point(106, 53);
            this.txtSaldoMora.Name = "txtSaldoMora";
            this.txtSaldoMora.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoMora.TabIndex = 21;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 35);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(89, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Saldo Interés:";
            // 
            // txtSaldoInteres
            // 
            this.txtSaldoInteres.Location = new System.Drawing.Point(106, 32);
            this.txtSaldoInteres.Name = "txtSaldoInteres";
            this.txtSaldoInteres.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoInteres.TabIndex = 19;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.Location = new System.Drawing.Point(106, 95);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.Size = new System.Drawing.Size(165, 20);
            this.txtTotalDeuda.TabIndex = 18;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(11, 98);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(80, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Total Deuda:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 14);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(88, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Saldo Capital:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Location = new System.Drawing.Point(106, 11);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoCapital.TabIndex = 0;
            // 
            // grbOtros
            // 
            this.grbOtros.Controls.Add(this.lblBase1);
            this.grbOtros.Controls.Add(this.txtAnalista);
            this.grbOtros.Controls.Add(this.txtMoneda);
            this.grbOtros.Controls.Add(this.lblBase3);
            this.grbOtros.Controls.Add(this.txtTasaInteres);
            this.grbOtros.Controls.Add(this.lblBase13);
            this.grbOtros.Controls.Add(this.lblBase10);
            this.grbOtros.Controls.Add(this.txtEstadoCredito);
            this.grbOtros.Controls.Add(this.txtTasaMoratoria);
            this.grbOtros.Controls.Add(this.lblBase11);
            this.grbOtros.Controls.Add(this.lblBase12);
            this.grbOtros.Controls.Add(this.txtDiasAtraso);
            this.grbOtros.Enabled = false;
            this.grbOtros.Location = new System.Drawing.Point(302, 223);
            this.grbOtros.Name = "grbOtros";
            this.grbOtros.Size = new System.Drawing.Size(272, 144);
            this.grbOtros.TabIndex = 29;
            this.grbOtros.TabStop = false;
            this.grbOtros.Text = "Otros";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(2, 119);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 30;
            this.lblBase1.Text = "Analista:";
            // 
            // txtAnalista
            // 
            this.txtAnalista.Location = new System.Drawing.Point(65, 116);
            this.txtAnalista.Name = "txtAnalista";
            this.txtAnalista.Size = new System.Drawing.Size(197, 20);
            this.txtAnalista.TabIndex = 29;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(107, 11);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(154, 20);
            this.txtMoneda.TabIndex = 28;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(2, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 27;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Location = new System.Drawing.Point(107, 32);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.Size = new System.Drawing.Size(154, 20);
            this.txtTasaInteres.TabIndex = 19;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(2, 100);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(96, 13);
            this.lblBase13.TabIndex = 26;
            this.lblBase13.Text = "Estado Crédito:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(2, 38);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(83, 13);
            this.lblBase10.TabIndex = 20;
            this.lblBase10.Text = "Tasa Interés:";
            // 
            // txtEstadoCredito
            // 
            this.txtEstadoCredito.Location = new System.Drawing.Point(108, 95);
            this.txtEstadoCredito.Name = "txtEstadoCredito";
            this.txtEstadoCredito.Size = new System.Drawing.Size(153, 20);
            this.txtEstadoCredito.TabIndex = 25;
            // 
            // txtTasaMoratoria
            // 
            this.txtTasaMoratoria.Location = new System.Drawing.Point(107, 53);
            this.txtTasaMoratoria.Name = "txtTasaMoratoria";
            this.txtTasaMoratoria.Size = new System.Drawing.Size(154, 20);
            this.txtTasaMoratoria.TabIndex = 21;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(2, 58);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(96, 13);
            this.lblBase11.TabIndex = 22;
            this.lblBase11.Text = "Tasa Moratoria:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(2, 79);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(96, 13);
            this.lblBase12.TabIndex = 24;
            this.lblBase12.Text = "Días de Atraso:";
            // 
            // txtDiasAtraso
            // 
            this.txtDiasAtraso.Location = new System.Drawing.Point(108, 74);
            this.txtDiasAtraso.Name = "txtDiasAtraso";
            this.txtDiasAtraso.Size = new System.Drawing.Size(153, 20);
            this.txtDiasAtraso.TabIndex = 23;
            // 
            // frmCapturarAJudiciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 524);
            this.Controls.Add(this.grbOtros);
            this.Controls.Add(this.grbDetallesCredito);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.chcSeleccionarTodos);
            this.Controls.Add(this.dtgCuentas);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmCapturarAJudiciales";
            this.Text = "Capturar a Judiciales";
            this.Load += new System.EventHandler(this.frmCapturarAJudiciales_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.dtgCuentas, 0);
            this.Controls.SetChildIndex(this.chcSeleccionarTodos, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbDetallesCredito, 0);
            this.Controls.SetChildIndex(this.grbOtros, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbDetallesCredito.ResumeLayout(false);
            this.grbDetallesCredito.PerformLayout();
            this.grbOtros.ResumeLayout(false);
            this.grbOtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.dtgBase dtgCuentas;
        private GEN.ControlesBase.chcBase chcSeleccionarTodos;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtTasaInteresJudicial;
        private GEN.ControlesBase.rbtBase rbtTasaInteresPactada;
        private GEN.ControlesBase.txtBase txtTasaInteresPactada;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.rbtBase rbtTasaMoraJudicial;
        private GEN.ControlesBase.rbtBase rbtTasaMoraPactada;
        private GEN.ControlesBase.txtBase txtTasaMoraPactada;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbDetallesCredito;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtSaldoOtros;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtSaldoMora;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtSaldoInteres;
        private GEN.ControlesBase.txtBase txtTotalDeuda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtSaldoCapital;
        private GEN.ControlesBase.grbBase grbOtros;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtTasaInteres;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtEstadoCredito;
        private GEN.ControlesBase.txtBase txtTasaMoratoria;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtDiasAtraso;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtAnalista;
        private GEN.ControlesBase.txtNumRea txtTasaInteresJudicial;
        private GEN.ControlesBase.txtNumRea txtTasaMoraJudicial;
    }
}